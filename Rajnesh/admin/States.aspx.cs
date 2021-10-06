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
    
    private CoreWebList<StateClass> chStateList
    {
        get
        {
            if (Cache["chStateList"] != null)
                return (CoreWebList<StateClass>)Cache["chStateList"];
            return null;
        }
        set
        {
            Cache["chStateList"] = value;
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
                // Bind Data To grid
                StateClass objState = new StateClass();
                chStateList = objState.fn_getStateList();
                if (chStateList.Count > 0)
                {
                    grd_Records.DataSource = chStateList;
                }
                else
                {
                    grd_Records.DataSource = null;
                }
                grd_Records.DataBind();

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

    protected void grd_Records_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Records.PageIndex = e.NewPageIndex;
            grd_Records.DataSource = chStateList;
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
            StateClass objState = new StateClass();
            objState.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objState.fn_deleteState();

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
            
            grd_Records.DataSource = objState.fn_getStateList();
            grd_Records.DataBind();

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

                StateClass objState = new StateClass();
                objState.iID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                
                dv_Records.DataSource = objState.fn_getStateByID();
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
            StateClass objState = new StateClass();

            DataTable dt = (DataTable)chStateList;
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
            
            StateClass objState = new StateClass();

            objState.strTitle = txtTitle.Text;
            objState.strDesc = txtDesc.Text;

            string strResponse = objState.fn_saveState();

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
            grd_Records.DataSource = objState.fn_getStateList();
            grd_Records.DataBind();

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

            StateClass objState = new StateClass();
            objState.iID = int.Parse(dv_Records.DataKey.Value.ToString());
            objState.strTitle = txtTitle.Text;
            objState.strDesc = txtDesc.Text;

            string strResponse = objState.fn_editState();

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

            objState.iID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());

            dv_Records.DataSource = objState.fn_getStateByID();
            dv_Records.DataBind();

            // Bind Data To grid            
            grd_Records.DataSource = objState.fn_getStateList();
            grd_Records.DataBind();
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
                    StateClass objState = new StateClass();
                    objState.iID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());

                    dv_Records.DataSource = objState.fn_getStateByID();
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
            StateClass objState = new StateClass();
            objState.strTitle = txtSearch.Text;
            chStateList = objState.fn_getStateByKeys();
            if (chStateList.Count > 0)
            {
                grd_Records.DataSource = chStateList;
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