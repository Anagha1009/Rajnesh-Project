using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Text;
using System.IO;

public partial class admin_ControlPanel : System.Web.UI.Page
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

    private CoreWebList<EntranceCategoryClass> chEntranceCategoryList
    {
        get
        {
            if (Cache["chEntranceCategoryList"] != null)
                return (CoreWebList<EntranceCategoryClass>)Cache["chEntranceCategoryList"];
            return null;
        }
        set
        {
            Cache["chEntranceCategoryList"] = value;
        }
    }

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

            if (!IsPostBack)
            {
                fn_BindRecords();

                if (grd_Records.SelectedIndex < 0)
                {
                    dv_Records.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void fn_BindRecords()
    {
        try
        {
            EntranceCategoryClass objCategory = new EntranceCategoryClass();
            chEntranceCategoryList = objCategory.fn_getEntranceCategoryList();
            if (chEntranceCategoryList.Count > 0)
            {
                grd_Records.DataSource = chEntranceCategoryList;
            }
            else
            {
                grd_Records.DataSource = null;
            }
            grd_Records.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void grd_Records_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Records.PageIndex = e.NewPageIndex;
            grd_Records.DataSource = chEntranceCategoryList;
            grd_Records.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Records_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            EntranceCategoryClass objCategory = new EntranceCategoryClass();
            objCategory.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objCategory.fn_deleteEntranceCategory();

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

            fn_BindRecords();

            dv_Records.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Records_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Records.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Records.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_Records.ChangeMode(DetailsViewMode.Edit);

                EntranceCategoryClass objCategory = new EntranceCategoryClass();
                objCategory.iID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                
                dv_Records.DataSource = objCategory.fn_getEntranceCategoryByID();
                dv_Records.DataBind();

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

    protected void grd_Records_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            EntranceCategoryClass objCategory = new EntranceCategoryClass();

            DataTable dt = (DataTable)chEntranceCategoryList;
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

            grd_Records.DataSource = dv;
            grd_Records.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Records_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_Records.FindControl("txtTitle");
            TextBox txtDesc = (TextBox)dv_Records.FindControl("txtDesc");
            
            EntranceCategoryClass objCategory = new EntranceCategoryClass();
            objCategory.strTitle = txtTitle.Text;
            objCategory.strDesc = txtDesc.Text;

            string strResponse = objCategory.fn_saveEntranceCategory();

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
            fn_BindRecords();

            // reset fields
            txtTitle.Text = "";
            txtDesc.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Records_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_Records.FindControl("txtTitle");
            TextBox txtDesc = (TextBox)dv_Records.FindControl("txtDesc");

            EntranceCategoryClass objCategory = new EntranceCategoryClass();
            objCategory.iID = int.Parse(dv_Records.DataKey.Value.ToString());
            objCategory.strTitle = txtTitle.Text;
            objCategory.strDesc = txtDesc.Text;
            
            string strResponse = objCategory.fn_editEntranceCategory();

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

            dv_Records.ChangeMode(DetailsViewMode.ReadOnly);

            objCategory.iID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());

            dv_Records.DataSource = objCategory.fn_getEntranceCategoryByID();
            dv_Records.DataBind();

            // Bind Data To grid            
            fn_BindRecords();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Records_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Records.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Records.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Records.ChangeMode(e.NewMode);

                if (grd_Records.SelectedIndex >= 0)
                {
                    EntranceCategoryClass objCategory = new EntranceCategoryClass();
                    objCategory.iID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());

                    dv_Records.DataSource = objCategory.fn_getEntranceCategoryByID();
                    dv_Records.DataBind();
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
            EntranceCategoryClass objCategory = new EntranceCategoryClass();
            objCategory.strTitle = txtSearch.Text;
            chEntranceCategoryList = objCategory.fn_getEntranceCategoryByKeys();

            if (chEntranceCategoryList.Count > 0)
            {
                grd_Records.DataSource = chEntranceCategoryList;
                grd_Records.DataBind();
            }
            else
            {
                grd_Records.DataSource = null;
                grd_Records.DataBind();
            }

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}