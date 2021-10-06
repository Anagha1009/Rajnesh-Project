using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Drawing;

public partial class admin_CategoryLinks : System.Web.UI.Page
{
    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
            {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }

            return (SortDirection)ViewState["sortDirection"];
        }
        set
        {
            ViewState["sortDirection"] = value;
        }
    }

    private CoreWebList<CategoryLinkClass> chCategoryLinkList
    {
        get
        {
            if (Cache["chCategoryLinkList"] != null)
                return (CoreWebList<CategoryLinkClass>)Cache["chCategoryLinkList"];
            return null;
        }
        set
        {
            Cache["chCategoryLinkList"] = value;
        }
    }

    int iCategoryID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Check login session 
            //If not logged in redirect to admin login page
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx?flag=1", false);
            }

            if (Request.QueryString["CategoryID"] != null)
            {
                iCategoryID = int.Parse(Request.QueryString["CategoryID"].ToString());
            }
            else
            {
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/admin/Category.aspx"));
            }

            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;

            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class=link href=default.aspx>Home</a>&nbsp;>&nbsp;<a class=link href=Category.aspx>Category</a>&nbsp;>&nbsp;News";


            if (!IsPostBack)
            {

                // Bind Data To grid
                CategoryLinkClass objCategoryLink = new CategoryLinkClass();
                objCategoryLink.iCategoryID = iCategoryID;
                chCategoryLinkList = objCategoryLink.fn_getCategoryLinkByCategoryID();

                if (chCategoryLinkList.Count > 0)
                {
                    grd_CategoryLinks.DataSource = chCategoryLinkList;
                }
                else
                {
                    grd_CategoryLinks.DataSource = null;
                }
                grd_CategoryLinks.DataBind();

                if (grd_CategoryLinks.SelectedIndex < 0)
                {
                    dv_CategoryLinks.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_CategoryLinks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_CategoryLinks.PageIndex = e.NewPageIndex;
            grd_CategoryLinks.DataSource = chCategoryLinkList;
            grd_CategoryLinks.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_CategoryLinks_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            CategoryLinkClass objCategoryLink = new CategoryLinkClass();
            objCategoryLink.iID = int.Parse(grd_CategoryLinks.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objCategoryLink.fn_deleteCategoryLink();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info.FindControl("mssg")).Text = strResponse;
                info.Visible = true;
            }
            else
            {
                ((Label)error.FindControl("mssg")).Text = strResponse;
                error.Visible = true;
            }

            objCategoryLink.iCategoryID = iCategoryID;
            chCategoryLinkList = objCategoryLink.fn_getCategoryLinkByCategoryID();
            grd_CategoryLinks.DataSource = chCategoryLinkList;
            grd_CategoryLinks.DataBind();

            dv_CategoryLinks.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_CategoryLinks_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_CategoryLinks.SelectedIndex < 0)
            {
                // Insert Mode
                dv_CategoryLinks.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_CategoryLinks.ChangeMode(DetailsViewMode.Edit);

                CategoryLinkClass objCategoryLink = new CategoryLinkClass();
                objCategoryLink.iID = int.Parse(grd_CategoryLinks.SelectedDataKey.Value.ToString());

                dv_CategoryLinks.DataSource = objCategoryLink.fn_getCategoryLinkByID();
                dv_CategoryLinks.DataBind();

                #region "Scroll to Details"
                StringBuilder sb = new StringBuilder();
                sb.Append("$('html,body').animate({ scrollTop: $('#ScrollHere').offset().top }, 2000);");
                ClientScript.RegisterStartupScript(this.GetType(), "Scroll", sb.ToString(), true);
                #endregion
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_CategoryLinks_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            CategoryLinkClass objCategoryLink = new CategoryLinkClass();

            DataTable dt = (DataTable)chCategoryLinkList;
            DataView dv = new DataView(dt);

            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                dv.Sort = e.SortExpression + " DESC";
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                dv.Sort = e.SortExpression + " ASC";
            }

            grd_CategoryLinks.DataSource = dv;
            grd_CategoryLinks.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_CategoryLinks_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            string strRanFileName = "";
            string strDocPath = "";

            TextBox txtTitle = (TextBox)dv_CategoryLinks.FindControl("txtTitle");
            TextBox txtUrl = (TextBox)dv_CategoryLinks.FindControl("txtUrl");

            CategoryLinkClass objCategoryLink = new CategoryLinkClass();
            objCategoryLink.iCategoryID = iCategoryID;
            objCategoryLink.strTitle = txtTitle.Text;
            objCategoryLink.strUrl = txtUrl.Text;

            string strResponse = objCategoryLink.fn_saveCategoryLink();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info_dv.FindControl("mssg")).Text = strResponse;
                info_dv.Visible = true;
            }
            else
            {
                ((Label)error_dv.FindControl("mssg")).Text = strResponse;
                error_dv.Visible = true;
            }

            // Bind Data To grid
            chCategoryLinkList = objCategoryLink.fn_getCategoryLinkByCategoryID();
            grd_CategoryLinks.DataSource = chCategoryLinkList;
            grd_CategoryLinks.DataBind();

            // reset fields
            txtTitle.Text = "";
            txtUrl.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_CategoryLinks_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            string strResponse = "";
            string strRanFileName = "";
            string strDocPath = "";

            TextBox txtTitle = (TextBox)dv_CategoryLinks.FindControl("txtTitle");
            TextBox txtUrl = (TextBox)dv_CategoryLinks.FindControl("txtUrl");

            CategoryLinkClass objCategoryLink = new CategoryLinkClass();
            int iWebsiteID = int.Parse(dv_CategoryLinks.DataKey.Value.ToString());
            objCategoryLink.iID = iWebsiteID;
            objCategoryLink.iCategoryID = iCategoryID;
            objCategoryLink.strTitle = txtTitle.Text;
            objCategoryLink.strUrl = txtUrl.Text;

            strResponse = objCategoryLink.fn_editCategoryLink();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info_dv.FindControl("mssg")).Text = strResponse;
                info_dv.Visible = true;
            }
            else
            {
                ((Label)error_dv.FindControl("mssg")).Text = strResponse;
                error_dv.Visible = true;
            }

            dv_CategoryLinks.ChangeMode(DetailsViewMode.ReadOnly);

            objCategoryLink.iID = int.Parse(grd_CategoryLinks.SelectedDataKey.Value.ToString());

            dv_CategoryLinks.DataSource = objCategoryLink.fn_getCategoryLinkByID();
            dv_CategoryLinks.DataBind();

            // Bind Data To grid    
            chCategoryLinkList = objCategoryLink.fn_getCategoryLinkByCategoryID();
            grd_CategoryLinks.DataSource = chCategoryLinkList;
            grd_CategoryLinks.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_CategoryLinks_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_CategoryLinks.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_CategoryLinks.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_CategoryLinks.ChangeMode(e.NewMode);

                if (grd_CategoryLinks.SelectedIndex >= 0)
                {
                    CategoryLinkClass objCategoryLink = new CategoryLinkClass();
                    objCategoryLink.iID = int.Parse(grd_CategoryLinks.SelectedDataKey.Value.ToString());

                    dv_CategoryLinks.DataSource = objCategoryLink.fn_getCategoryLinkByID();
                    dv_CategoryLinks.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (txtSearch.Text != "")
            {
                CategoryLinkClass objCategoryLink = new CategoryLinkClass();
                objCategoryLink.strTitle = txtSearch.Text.Trim();
                chCategoryLinkList = objCategoryLink.fn_getCategoryLinkByKeys();
                if (chCategoryLinkList.Count > 0)
                {
                    grd_CategoryLinks.DataSource = chCategoryLinkList;
                }
                else
                {
                    grd_CategoryLinks.DataSource = null;
                }
                grd_CategoryLinks.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}