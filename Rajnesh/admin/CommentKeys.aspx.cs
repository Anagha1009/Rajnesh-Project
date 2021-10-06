using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Text;

public partial class admin_CommentKeys : System.Web.UI.Page
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

    private CoreWebList<CommentKeysClass> chCommentKeyList
    {
        get
        {
            if (Cache["chCommentKeyList"] != null)
                return (CoreWebList<CommentKeysClass>)Cache["chCommentKeyList"];
            return null;
        }
        set
        {
            Cache["chCommentKeyList"] = value;
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
                CommentKeysClass objCommentKey = new CommentKeysClass();
                chCommentKeyList = objCommentKey.fn_getCommentKeysList();

                if (chCommentKeyList.Count > 0)
                {
                    grd_IndustryType.DataSource = chCommentKeyList;
                }
                else
                {
                    grd_IndustryType.DataSource = null;
                }
                grd_IndustryType.DataBind();

                if (grd_IndustryType.SelectedIndex < 0)
                {
                    dv_IndustryType.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_IndustryType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_IndustryType.PageIndex = e.NewPageIndex;
            grd_IndustryType.DataSource = chCommentKeyList;
            grd_IndustryType.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_IndustryType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            CommentKeysClass objCommentKey = new CommentKeysClass();
            objCommentKey.iID = int.Parse(grd_IndustryType.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objCommentKey.fn_deleteCommentKeys();

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
            
            grd_IndustryType.DataSource = objCommentKey.fn_getCommentKeysList();
            grd_IndustryType.DataBind();

            dv_IndustryType.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_IndustryType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_IndustryType.SelectedIndex < 0)
            {
                // Insert Mode
                dv_IndustryType.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_IndustryType.ChangeMode(DetailsViewMode.Edit);

                CommentKeysClass objCommentKey = new CommentKeysClass();
                objCommentKey.iID = int.Parse(grd_IndustryType.SelectedDataKey.Value.ToString());

                dv_IndustryType.DataSource = objCommentKey.fn_getCommentKeyByID();
                dv_IndustryType.DataBind();

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

    protected void grd_IndustryType_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            CommentKeysClass objCommentKey = new CommentKeysClass();

            DataTable dt = (DataTable)chCommentKeyList;
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

            grd_IndustryType.DataSource = dv;
            grd_IndustryType.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_IndustryType_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_IndustryType.FindControl("txtTitle");

            CommentKeysClass objCommentKey = new CommentKeysClass();

            objCommentKey.strTitle = txtTitle.Text;

            string strResponse = objCommentKey.fn_saveCommentKeys();

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
            grd_IndustryType.DataSource = objCommentKey.fn_getCommentKeysList();
            grd_IndustryType.DataBind();

            // reset fields
            txtTitle.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_IndustryType_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_IndustryType.FindControl("txtTitle");

            CommentKeysClass objCommentKey = new CommentKeysClass();
            objCommentKey.iID = int.Parse(dv_IndustryType.DataKey.Value.ToString());
            objCommentKey.strTitle = txtTitle.Text;

            string strResponse = objCommentKey.fn_editCommentKeys();

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

            dv_IndustryType.ChangeMode(DetailsViewMode.ReadOnly);

            objCommentKey.iID = int.Parse(grd_IndustryType.SelectedDataKey.Value.ToString());

            dv_IndustryType.DataSource = objCommentKey.fn_getCommentKeyByID();
            dv_IndustryType.DataBind();

            // Bind Data To grid         
            grd_IndustryType.DataSource = objCommentKey.fn_getCommentKeysList();
            grd_IndustryType.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_IndustryType_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_IndustryType.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_IndustryType.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_IndustryType.ChangeMode(e.NewMode);

                if (grd_IndustryType.SelectedIndex >= 0)
                {
                    CommentKeysClass objCommentKey = new CommentKeysClass();
                    objCommentKey.iID = int.Parse(grd_IndustryType.SelectedDataKey.Value.ToString());

                    dv_IndustryType.DataSource = objCommentKey.fn_getCommentKeyByID();
                    dv_IndustryType.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        try
        {
            CommentKeysClass objCommentKey = new CommentKeysClass();
            chCommentKeyList = objCommentKey.fn_getCommentKeyByKeys(txtSearch.Text.Trim());
            if (chCommentKeyList.Count > 0)
            {
                grd_IndustryType.DataSource = chCommentKeyList;
                grd_IndustryType.DataBind();
            }
            else
            {
                grd_IndustryType.DataSource = null;
                grd_IndustryType.DataBind();
            }

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}