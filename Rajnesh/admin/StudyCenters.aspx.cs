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

public partial class admin_StudyCenters : System.Web.UI.Page
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
    
    private CoreWebList<StudyCenterClass> chStudyCenterList
    {
        get
        {
            if (Cache["chStudyCenterList"] != null)
                return (CoreWebList<StudyCenterClass>)Cache["chStudyCenterList"];
            return null;
        }
        set
        {
            Cache["chStudyCenterList"] = value;
        }
    }

    int UniversityID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Check login session 
            //If not logged in redirect to admin login page
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx?flag=1");
            }

            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;
            
            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='default.aspx'>Home</a> &nbsp; > &nbsp;StudyCenters";

            if (Request.QueryString["UniversityID"] != null)
            {
                UniversityID=int.Parse(Request.QueryString["UniversityID"].ToString());
            }

            if (!IsPostBack)
            {
                // Bind Data To grid
                StudyCenterClass objStudyCenter = new StudyCenterClass();
                objStudyCenter.iUniversityID = UniversityID;
                chStudyCenterList = objStudyCenter.fn_getStudyCenterByUniversityID();

                if (chStudyCenterList.Count > 0)
                {
                    grd_StudyCenters.DataSource = chStudyCenterList;
                }
                else
                {
                    grd_StudyCenters.DataSource = null;
                }
                grd_StudyCenters.DataBind();

                if (grd_StudyCenters.SelectedIndex < 0)
                {
                    dv_StudyCenters.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_StudyCenters_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_StudyCenters.PageIndex = e.NewPageIndex;
            grd_StudyCenters.DataSource = chStudyCenterList;
            grd_StudyCenters.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_StudyCenters_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            StudyCenterClass objStudyCenter = new StudyCenterClass();
            objStudyCenter.iID = int.Parse(grd_StudyCenters.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objStudyCenter.fn_deleteStudyCenter();

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
            objStudyCenter.iUniversityID = UniversityID;
            chStudyCenterList = objStudyCenter.fn_getStudyCenterByUniversityID();
            grd_StudyCenters.DataSource = chStudyCenterList;
            grd_StudyCenters.DataBind();

            dv_StudyCenters.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_StudyCenters_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_StudyCenters.SelectedIndex < 0)
            {
                // Insert Mode
                dv_StudyCenters.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_StudyCenters.ChangeMode(DetailsViewMode.Edit);

                StudyCenterClass objStudyCenter = new StudyCenterClass();
                objStudyCenter.iID = int.Parse(grd_StudyCenters.SelectedDataKey.Value.ToString());
                
                dv_StudyCenters.DataSource = objStudyCenter.fn_getStudyCenterByID();
                dv_StudyCenters.DataBind();

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

    protected void grd_StudyCenters_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            StudyCenterClass objStudyCenter = new StudyCenterClass();

            DataTable dt = (DataTable)chStudyCenterList;
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

            grd_StudyCenters.DataSource = dv;
            grd_StudyCenters.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_StudyCenters_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_StudyCenters.FindControl("txtTitle");
            TextBox txtDescription = (TextBox)dv_StudyCenters.FindControl("txtDescription");
            TextBox txtAddress = (TextBox)dv_StudyCenters.FindControl("txtAddress");
            
            StudyCenterClass objStudyCenter = new StudyCenterClass();
            objStudyCenter.iUniversityID = UniversityID;
            objStudyCenter.strStudyCenterTitle = txtTitle.Text;
            objStudyCenter.strStudyCenterDesc = txtDescription.Text;
            objStudyCenter.strStudyCenterAddrs = txtAddress.Text;

            string strResponse = objStudyCenter.fn_saveStudyCenter();

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
            objStudyCenter.iUniversityID = UniversityID;
            chStudyCenterList = objStudyCenter.fn_getStudyCenterByUniversityID();
            grd_StudyCenters.DataSource = chStudyCenterList;
            grd_StudyCenters.DataBind();

            // reset fields
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtAddress.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_StudyCenters_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            string strResponse = "";

            TextBox txtTitle = (TextBox)dv_StudyCenters.FindControl("txtTitle");
            TextBox txtDescription = (TextBox)dv_StudyCenters.FindControl("txtDescription");
            TextBox txtAddress = (TextBox)dv_StudyCenters.FindControl("txtAddress");

            StudyCenterClass objStudyCenter = new StudyCenterClass();
            objStudyCenter.iID = int.Parse(dv_StudyCenters.DataKey.Value.ToString());
            objStudyCenter.iUniversityID = UniversityID;
            objStudyCenter.strStudyCenterTitle = txtTitle.Text;
            objStudyCenter.strStudyCenterDesc = txtDescription.Text;
            objStudyCenter.strStudyCenterAddrs = txtAddress.Text;

            strResponse = objStudyCenter.fn_editStudyCenter();

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

            dv_StudyCenters.ChangeMode(DetailsViewMode.ReadOnly);

            objStudyCenter.iID = int.Parse(grd_StudyCenters.SelectedDataKey.Value.ToString());

            dv_StudyCenters.DataSource = objStudyCenter.fn_getStudyCenterByID();
            dv_StudyCenters.DataBind();

            // Bind Data To grid           
            objStudyCenter.iUniversityID = UniversityID;
            chStudyCenterList = objStudyCenter.fn_getStudyCenterByUniversityID();
            grd_StudyCenters.DataSource = chStudyCenterList;
            grd_StudyCenters.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_StudyCenters_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_StudyCenters.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_StudyCenters.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_StudyCenters.ChangeMode(e.NewMode);

                if (grd_StudyCenters.SelectedIndex >= 0)
                {
                    StudyCenterClass objStudyCenter = new StudyCenterClass();
                    objStudyCenter.iID = int.Parse(grd_StudyCenters.SelectedDataKey.Value.ToString());

                    dv_StudyCenters.DataSource = objStudyCenter.fn_getStudyCenterByID();
                    dv_StudyCenters.DataBind();
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
            StudyCenterClass objStudyCenter = new StudyCenterClass();
            chStudyCenterList = objStudyCenter.fn_getStudyCenterByKeys(txtSearch.Text.Trim());

            if (chStudyCenterList.Count > 0)
            {
                grd_StudyCenters.DataSource = chStudyCenterList;
                grd_StudyCenters.DataBind();
            }
            else
            {
                grd_StudyCenters.DataSource = null;
                grd_StudyCenters.DataBind();
            }

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}