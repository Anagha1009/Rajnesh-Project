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

public partial class admin_AbuseQuestions : System.Web.UI.Page
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

    private CoreWebList<QuestionMasterClass> chAbuseQuestionList
    {
        get
        {
            if (Cache["chAbuseQuestionList"] != null)
                return (CoreWebList<QuestionMasterClass>)Cache["chAbuseQuestionList"];
            return null;
        }
        set
        {
            Cache["chAbuseQuestionList"] = value;
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
                Response.Redirect("Login.aspx?flag=1", false);
            }

            info.Visible = false;
            error.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;

            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class=link href=default.aspx>Home</a>&nbsp;>&nbsp;Abuse Questions";


            if (!IsPostBack)
            {

                // Bind Data To grid
                QuestionMasterClass objQuestion = new QuestionMasterClass();
                chAbuseQuestionList = objQuestion.fn_getAbuseQuestionList();

                if (chAbuseQuestionList.Count > 0)
                {
                    grd_Questions.DataSource = chAbuseQuestionList;
                }
                else
                {
                    grd_Questions.DataSource = null;
                }
                grd_Questions.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Questions_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Questions.PageIndex = e.NewPageIndex;
            grd_Questions.DataSource = chAbuseQuestionList;
            grd_Questions.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Questions_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            QuestionMasterClass objQuestion = new QuestionMasterClass();
            objQuestion.iID = int.Parse(grd_Questions.DataKeys[e.RowIndex].Value.ToString());
            
            string strResponse = objQuestion.fn_deleteQuestion();

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

            chAbuseQuestionList = objQuestion.fn_getAbuseQuestionList();
            grd_Questions.DataSource = chAbuseQuestionList;
            grd_Questions.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Questions_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            QuestionMasterClass objQuestion = new QuestionMasterClass();

            DataTable dt = (DataTable)chAbuseQuestionList;
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

            grd_Questions.DataSource = dv;
            grd_Questions.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Questions_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Approve")
            {
                ImageButton btnFeatured = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnFeatured.Parent.Parent;

                QuestionMasterClass objQuestion = new QuestionMasterClass();
                objQuestion.iID = Convert.ToInt32(e.CommandArgument);
                objQuestion.iAbuseUserID = 0;
                objQuestion.bAbuse = false;

                string strResponse = objQuestion.fn_RemoveFromadmin();

                if (strResponse.Contains("SUCCESS"))
                {
                    ((Label)info.FindControl("mssg")).Text = "Record have been moved to Question Section";
                    info.Visible = true;

                    chAbuseQuestionList = objQuestion.fn_getAbuseQuestionList();
                    grd_Questions.DataSource = chAbuseQuestionList;
                    grd_Questions.DataBind();
                }
                else
                {
                    ((Label)error.FindControl("mssg")).Text = strResponse;
                    error.Visible = true;
                }
                
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Questions_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hfApprove = (HiddenField)e.Row.FindControl("hfApprove");
                ImageButton btnApprove = (ImageButton)e.Row.FindControl("btnApprove");

                HyperLink hypUser = (HyperLink)e.Row.FindControl("hypUser");
                HiddenField hfUser = (HiddenField)e.Row.FindControl("hfUser");

                HyperLink hyp_User = (HyperLink)e.Row.FindControl("hyp_User");
                HiddenField hf_User = (HiddenField)e.Row.FindControl("hfUser");

                if (hypUser != null && hfUser != null)
                {
                    UserClass objUser = new UserClass();
                    objUser.iID = int.Parse(hfUser.Value);
                    CoreWebList<UserClass> objUserList = objUser.fn_getUserByID();
                    if (objUserList.Count > 0)
                    {
                        hypUser.Text = objUserList[0].strName;
                    }
                }

                if (hyp_User != null && hf_User != null)
                {
                    UserClass obj_User = new UserClass();
                    obj_User.iID = int.Parse(hf_User.Value);
                    CoreWebList<UserClass> obj_UserList = obj_User.fn_getUserByID();
                    if (obj_UserList.Count > 0)
                    {
                        hyp_User.Text = obj_UserList[0].strName;
                    }
                }

                if (btnApprove != null && hfApprove != null)
                {
                    if (bool.Parse(hfApprove.Value) == true)
                    {
                        btnApprove.ImageUrl = "~/admin/images/cross.gif";
                    }
                    else
                    {
                        btnApprove.ImageUrl = "~/admin/images/Tick.gif";
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

   
}