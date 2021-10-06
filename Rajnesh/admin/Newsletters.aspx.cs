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
using System.Net.Mail;
using System.Configuration;

public partial class admin_NewsLetters : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.MaintainScrollPositionOnPostBack = true;
            
            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;NewsLetters";

            if (!IsPostBack)
            {
                info.Visible = false;
                error.Visible = false;

                ddl_EduCationLeads.Visible = false;
                chk_EducationLoan.Visible = false;

                StreamReader reader = new StreamReader(Server.MapPath("~/admin/NewsLetters.htm"));
                string content = reader.ReadToEnd();
                reader.Close();
                txt_Body.Text = content;
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void chk_Newsletters_CheckedChanged(object sender, EventArgs e)
    {
        fn_getRecords();
    }

    protected void ddl_EduCationLeads_SelectedIndexChanged(object sender, EventArgs e)
    {
        fn_getRecords();
    }

    
    protected void chk_EduCationLeads_CheckedChanged(object sender, EventArgs e)
    {
        ddl_EduCationLeads.Visible = true;
        chk_EducationLoan.Visible = true;

        fn_getRecords();
    }

    protected void fn_getRecords()
    {
        try
        {
            string strQuery = "";

            bool bStatus = false;

            if (chk_Comments.Checked == true)
            {
                strQuery += "SELECT Comment_Name AS Name, Comment_Email AS Email FROM tbl_Comments";
                bStatus = true;
            }

            if (chk_Competitions.Checked == true)
            {
                if (bStatus == false)
                {
                    strQuery += " SELECT CompetitionUser_Name AS Name, CompetitionUser_Email AS Email FROM tbl_CompetitionUsers";
                }
                else
                {
                    strQuery += " UNION ALL SELECT CompetitionUser_Name AS Name, CompetitionUser_Email AS Email FROM tbl_CompetitionUsers";
                }

                bStatus = true;
            }

            if (chk_EduCationLeads.Checked == true)
            {
                string strEducationLeadQuery = "";

                bool bCheck = false;

                if (ddl_EduCationLeads.SelectedValue == "All")
                {
                    strEducationLeadQuery += " SELECT EduLead_FirstName + ' ' + EduLead_LastName AS Name, EduLead_Email AS Email FROM tbl_EducationLeads";
                }
                else
                {
                    strEducationLeadQuery += " SELECT EduLead_FirstName + ' ' + EduLead_LastName AS Name, EduLead_Email AS Email FROM tbl_EducationLeads WHERE EduLead_Type='" + ddl_EduCationLeads.SelectedValue + "'";
                    bCheck = true;
                }

                if (chk_EducationLoan.Checked == true)
                {
                    if (bCheck == false)
                    {
                        strEducationLeadQuery += " WHERE EduLead_EducationLoan='true'";
                    }
                    else
                    {
                        strEducationLeadQuery += " AND EduLead_EducationLoan='true'";
                    }
                }

                if (bStatus == true)
                {
                    strQuery = strQuery + " UNION ALL " + strEducationLeadQuery;
                }
                else
                {
                    strQuery = strQuery + strEducationLeadQuery;
                }
            }

            if (strQuery != "")
            {
                CompetitionUserClass objUser = new CompetitionUserClass();
                CoreWebList<CompetitionUserClass> objUserList = objUser.fn_getNewsLetterUsers(strQuery.Trim());
                if (objUserList.Count > 0)
                {
                    DataTable dtEmailList = (DataTable)objUserList;
                    ViewState["dtEmailList"] = dtEmailList;
                    rpt_Users.DataSource = objUserList;
                }
                else
                {
                    ViewState["dtEmailList"] = null;
                    rpt_Users.DataSource = null;
                }
                rpt_Users.DataBind();
            }
            else
            {
                ViewState["dtEmailList"] = null;
                rpt_Users.DataSource = null;
                rpt_Users.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    

    protected void btn_Send_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["dtEmailList"] != null)
            {
                string strEmail = "";

                DataTable dtEmailList = (DataTable)ViewState["dtEmailList"];
                foreach (DataRow row in dtEmailList.Rows)
                {
                    strEmail = row["strEmail"].ToString();
                    if (strEmail != "")
                    {
                        fn_SendMail(strEmail);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    public void fn_SendMail(string strEmail)
    {
        SmtpClient mailClient = null;
        MailMessage message = null;

        try
        {
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

            message.Subject = txt_Subject.Text.Trim();

            message.Body = txt_Body.Text;

            message.IsBodyHtml = true;
            mailClient.Send(message);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
        finally
        {

        }
    }
}