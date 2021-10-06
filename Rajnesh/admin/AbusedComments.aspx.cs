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
using System.IO;
using yo_lib;

public partial class admin_Comments : System.Web.UI.Page
{
    private CoreWebList<CommentsMasterClass> chCommentList
    {
        get 
        {
            if (Cache["chCommentList"] != null)
                return (CoreWebList<CommentsMasterClass>)Cache["chCommentList"];
            return null;
        }
        set 
        {
            Cache["chCommentList"] = value;
        }
    }

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

    string strRanFileName = string.Empty;
    string strDocPath = string.Empty;
    string strOrgFileName = string.Empty;

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
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    void BindGrid()
    {
        try
        {
            CommentsMasterClass objComment = new CommentsMasterClass();
            chCommentList = objComment.fn_getAbusedComments();
            if (chCommentList.Count > 0)
            {
                grd_Comments.DataSource = chCommentList;
            }
            else
            {
                grd_Comments.DataSource = null;
            }
            grd_Comments.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Comments_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Comments.PageIndex = e.NewPageIndex;
            grd_Comments.DataSource = chCommentList;
            grd_Comments.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Comments_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            CommentsMasterClass objComment = new CommentsMasterClass();
            objComment.iID = int.Parse(grd_Comments.DataKeys[e.RowIndex].Value.ToString());
            string strResponse = objComment.fn_deleteComment();

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
            BindGrid();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
   
 
    protected void grd_Comments_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            CommentsMasterClass objUL = new CommentsMasterClass();
            CoreWebList<CommentsMasterClass> objUniversityList = chCommentList;
            if (objUniversityList.Count > 0)
            {
                DataTable dt = (DataTable)objUniversityList;
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

                grd_Comments.DataSource = dv;
                grd_Comments.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    
    protected void grd_Comments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Abuse")
            {
                CommentsMasterClass objComment = new CommentsMasterClass();
                ImageButton btnAbuse = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnAbuse.Parent.Parent;

                objComment.iID = Convert.ToInt32(e.CommandArgument);;
                CoreWebList<CommentsMasterClass> objCommentList = objComment.fn_getCommentByID();
                if (objCommentList.Count > 0)
                {
                    if (objCommentList[0].bAbuse == true)
                    {
                        btnAbuse.ImageUrl = "~/admin/images/cross.gif";
                        objComment.bAbuse = false;
                    }
                    else
                    {
                        btnAbuse.ImageUrl = "~/admin/images/Tick.gif";
                        objComment.bAbuse = true;
                        
                    }
                    objComment.fn_ChangeAbusedCommentStatus();
                }
            }

            else if (e.CommandName == "Enable")
            {
                CommentsMasterClass objComment = new CommentsMasterClass();
                ImageButton btnEnable = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnEnable.Parent.Parent;

                objComment.iID = Convert.ToInt32(e.CommandArgument); ;
                CoreWebList<CommentsMasterClass> objCommentList = objComment.fn_getCommentByID();
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
                    objComment.fn_ChangeCommentStatus();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    
    protected void grd_Comments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hfAbuse = (HiddenField)e.Row.FindControl("hfAbuse");
                ImageButton btnAbuse = (ImageButton)e.Row.FindControl("btnAbuse");

                HiddenField hfEnable = (HiddenField)e.Row.FindControl("hfEnable");
                ImageButton btnEnable = (ImageButton)e.Row.FindControl("btnEnable");   

                if (bool.Parse(hfAbuse.Value) == true)
                {
                    btnAbuse.ImageUrl = "~/admin/images/Tick.gif";
                }
                else
                {
                    btnAbuse.ImageUrl = "~/admin/images/Cross.gif";
                }

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
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message ;
            error.Visible = true;
        }
    }



}
