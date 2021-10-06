using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using yo_lib;

public partial class admin_Comments : System.Web.UI.Page
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

    private CoreWebList<CommentClass> ch_Comment_List
    {
        get
        {
            if (Cache["ch_Comment_List"] != null)
                return (CoreWebList<CommentClass>)Cache["ch_Comment_List"];
            return null;
        }
        set
        {
            Cache["ch_Comment_List"] = value;
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

            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                // Bind Data To grid                
                fn_BindRecords();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }

    }

    private void fn_BindRecords()
    {
        try
        {
            CommentClass objCM = new CommentClass();
            ch_Comment_List = objCM.fn_getCommentList();
            if (ch_Comment_List.Count > 0)
            {
                grd_Comment.DataSource = ch_Comment_List;
            }
            else
            {
                grd_Comment.DataSource = null;
            }
            grd_Comment.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    
    protected void grd_Comment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_Comment.PageIndex = e.NewPageIndex;
        grd_Comment.DataSource = ch_Comment_List;
        grd_Comment.DataBind();
    }

    protected void grd_Comment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            CommentClass objCM = new CommentClass();
            objCM.iID = int.Parse(grd_Comment.DataKeys[e.RowIndex].Value.ToString());
            string strResponse = objCM.fn_deleteComment();
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

            // Bind Data To grid            
            fn_BindRecords();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Comment_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            CommentClass objCM = new CommentClass();
            DataTable dt = null;
            dt = (DataTable)ch_Comment_List;
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

            grd_Comment.DataSource = dv;
            grd_Comment.DataBind();

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_Comment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string strResponse = "";
            if (e.CommandName == "Enable")
            {
                CommentClass objComment = new CommentClass();
                ImageButton btnEnable = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnEnable.Parent.Parent;

                objComment.iID = Convert.ToInt32(e.CommandArgument); ;
                CoreWebList<CommentClass> objCommentList = objComment.fn_getCommentByID();
                if (objCommentList.Count > 0)
                {
                    if (objCommentList[0].bActive == true)
                    {
                        btnEnable.ImageUrl = "~/admin/images/cross.gif";
                        objComment.bActive = false;
                    }
                    else
                    {
                        btnEnable.ImageUrl = "~/admin/images/Tick.gif";
                        objComment.bActive = true;

                    }

                    strResponse = objComment.fn_ChangeCommentActiveStatus();

                    if (strResponse.Contains("SUCCESS"))
                    {
                        ((Label)info.FindControl("mssg")).Text = strResponse;
                        info.Visible = true;
                    }
                    else
                    {
                        ((Label)error.FindControl("mssg")).Text = strResponse;
                        error.Visible = true;
                    }

                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void grd_Comment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hfEnable = (HiddenField)e.Row.FindControl("hfEnable");
                ImageButton btnEnable = (ImageButton)e.Row.FindControl("btnEnable");

                if (bool.Parse(hfEnable.Value) == true)
                {
                    btnEnable.ImageUrl = "~/admin/images/Tick.gif";
                }
                else
                {
                    btnEnable.ImageUrl = "~/admin/images/Cross.gif";
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
            CommentClass objCM = new CommentClass();
            objCM.strTitle = txtSearch.Text.Trim();
            ch_Comment_List = objCM.fn_getSearchComment();
            if (ch_Comment_List.Count > 0)
            {
                grd_Comment.DataSource = ch_Comment_List;
            }
            else
            {
                grd_Comment.DataSource = null;
            }
            grd_Comment.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
}
