using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;

public partial class Resume_tips : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Info1.Visible = false;
        Error1.Visible = false;

        if (Session["userId"] != null)
        {
            tr_Answer.Visible = true;
            tr_Question.Visible = false;
        }
        else
        {
            tr_Answer.Visible = false;
            tr_Question.Visible = true;
        }

        if (!IsPostBack)
        {
            try
            {
                if (RouteData.Values["Question"] != null && RouteData.Values["QuestionID"] != null)
                {
                    QuestionMasterClass objQuest = new QuestionMasterClass();
                    objQuest.iID = int.Parse(RouteData.Values["QuestionID"].ToString());
                    CoreWebList<QuestionMasterClass> cwQuest = objQuest.fn_getQuestionByID();
                    if (cwQuest.Count > 0)
                    {
                        ltl_Question.Text = cwQuest[0].strQuestion;

                        hyp.NavigateUrl = "https://www.recruitmentexam.com/Login.aspx?ReturnUrl=" + Request.Url.ToString();
                    }

                    fillData();
                }
            }
            catch (Exception ex)
            {
                ((Label)Error1.FindControl("mssg")).Text = "Error : " + ex.StackTrace + ex.Message;
                Error1.Visible = true;
            }
        }
    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Session["userId"] != null)
            {
                AnswerMasterClass objAns = new AnswerMasterClass();

                objAns.strReply = txtAnswer.Text.Trim();
                objAns.iQuestionID = int.Parse(RouteData.Values["QuestionID"].ToString());
                objAns.iUserID = int.Parse(Session["userId"].ToString());
                objAns.strUserName = "";

                string strResponse = objAns.fn_saveAnswer();

                if (strResponse.StartsWith("SUCCESS"))
                {
                    txtAnswer.Text = "";
                    fillData();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)Error1.FindControl("mssg")).Text = "Error : " + ex.StackTrace + ex.Message;
            Error1.Visible = true;
        }
    }

    protected void fillData()
    {
        try
        {
            AnswerMasterClass objAns = new AnswerMasterClass();
            objAns.iQuestionID = int.Parse(RouteData.Values["QuestionID"].ToString());
            grd_Answer.DataSource = objAns.fn_getAnswerListByQuestionID();
            grd_Answer.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)Error1.FindControl("mssg")).Text = "Error : " + ex.StackTrace + ex.Message;
            Error1.Visible = true;
        }
    }

    protected void btn_ReportAbuse_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("https://www.recruitmentexam.com/Login.aspx?ReturnUrl=" + Request.Url.ToString());
            }
            else
            {
                QuestionMasterClass objQuest = new QuestionMasterClass();
                objQuest.iUserID = int.Parse(Session["userId"].ToString());
                objQuest.iID = int.Parse(RouteData.Values["QuestionID"].ToString());
                string strResponse = objQuest.fn_RemoveFromClient();
                if (strResponse.Contains("SUCCESS"))
                {
                    ((Label)Info1.FindControl("mssg")).Text = "Reported Abuse Successfully..!";
                    Info1.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)Error1.FindControl("mssg")).Text = "Error : " + ex.StackTrace + ex.Message;
            Error1.Visible = true;
        }
    }

    protected void grd_Answer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hfUserID = (HiddenField)e.Row.FindControl("hfUserID");
                Literal ltl_user = (Literal)e.Row.FindControl("ltl_user");

                UserClass objuser = new UserClass();
                objuser.iID = int.Parse(hfUserID.Value);
                CoreWebList<UserClass> objuserList = objuser.fn_getUserByID();
                if (objuserList.Count > 0)
                {
                    ltl_user.Text = "Posted by : " + objuserList[0].strName;
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)Info1.FindControl("mssg")).Text = "Error : " + ex.StackTrace + ex.Message;
            Info1.Visible = true;
        }
    }
}
