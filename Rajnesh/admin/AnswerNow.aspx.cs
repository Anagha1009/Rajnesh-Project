using System;
using System.Collections.Generic;
using System.Data;
using FredCK.FCKeditorV2;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;
using System.Net.Mail;
using System.Configuration;

public partial class admin_Articles : System.Web.UI.Page
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
                if (Request.QueryString["QID"] != null)
                {
                    int QuestionId = int.Parse(Request.QueryString["QID"].ToString());

                    QuestionMasterClass objQuestion = new QuestionMasterClass();
                    objQuestion.iID = QuestionId;
                    CoreWebList<QuestionMasterClass> objQuestionList = objQuestion.fn_getQuestionByID();
                    if (objQuestionList.Count > 0)
                    {
                        lblQuestion.Text = objQuestionList[0].strQuestion;                        
                        
                    }

                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int UserId=0;
        string strLink = "";
        string strEmail = "";
        string strName = "";

        if (Request.QueryString["QID"] != null)
        {
            int QuestionId = int.Parse(Request.QueryString["QID"].ToString());

            QuestionMasterClass objQuestion = new QuestionMasterClass();
            objQuestion.iID = QuestionId;
            CoreWebList<QuestionMasterClass> objQuestionList = objQuestion.fn_getQuestionByID();
            if (objQuestionList.Count > 0)
            {
                UserId = objQuestionList[0].iUserID;
                strLink = "http://www.eduvidya.com/Question/" + objQuestionList[0].strQuestion.ToString().Replace("&", "-").Replace("?", "-").Replace(" ", "-").Replace(",", "-").Replace("---", "-").Replace("--", "-").Replace(":", "-") + "/" + Request.QueryString["QID"].ToString();
            }
        }

        UserClass objUserInfo = new UserClass();
        objUserInfo.iID = UserId;
        CoreWebList<UserClass> objUserInfoList = objUserInfo.fn_getUserByID();
        if (objUserInfoList.Count > 0)
        {
            strEmail = objUserInfoList[0].strEmail;
            strName = objUserInfoList[0].strName;
        }

        AnswerMasterClass objAnswer = new AnswerMasterClass();
        objAnswer.iQuestionID = int.Parse(Request.QueryString["QID"].ToString());
        objAnswer.strReply = fckDesc.Value.ToString();       
        objAnswer.strUserName = "Recruitment Exam counsellor";

        string strResponse= objAnswer.fn_saveAnswer();

        if (strResponse.StartsWith("SUCCESS"))
        {
            ((Label)info.FindControl("mssg")).Text = strResponse;
            info.Visible = true;

            if (UserId != 0)
            {
                SmtpClient mailClient = null;
                MailMessage message = null;

                mailClient = new SmtpClient();
                message = new MailMessage();

                //SMTP MAIL HOST
                mailClient.Host = ConfigurationManager.AppSettings["SMTP_MAIL_SERVER"];

                //SMTP MAIL PORT
                mailClient.Port = 25;

                //NETWORK CREDENTIALS
                string strMailUserName = ConfigurationManager.AppSettings["FROM_ADDR"];
                string strMailPassword = ConfigurationManager.AppSettings["FROM_ADDR_PASS"];

                System.Net.NetworkCredential SMTPUserInfo =
                    new System.Net.NetworkCredential(strMailUserName, strMailPassword);
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = SMTPUserInfo;

                //FROM MAIL ADDRESS
                MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FROM_ADDR"]);
                message.From = fromAddress;

                //TO MAIL ADDRESS
                message.To.Add(strEmail);

                message.Subject = "eduvidya.com : DistanceEducationUniversity Exam Counsellor has answered your question";

                message.Body = "Hi " + strName + ", <br/>Please Click on following link to view answer to your question.<br/><a href='" + strLink + "'>" + strLink + "</a><br/>Thank you,<br/> RecruitmentExam.com";

                message.IsBodyHtml = true;
                mailClient.Send(message);
            }
            else
            {
                ((Label)error.FindControl("mssg")).Text = "Email error: Question asked by this user is not Registered";
                error.Visible = true;
            }
        }
        else
        {
            ((Label)error.FindControl("mssg")).Text = strResponse;
            error.Visible = true;
        }

    }
}
