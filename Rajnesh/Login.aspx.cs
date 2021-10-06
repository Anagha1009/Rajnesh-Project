using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;
using System.Net.Mail;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            info1.Visible = false;
            error1.Visible = false;

            Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
            ltl_bredcrumbs.Text = "<a href='https://www.recruitmentexam.com/'>Home</a>Login";
        }
    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (txtEmail.Text != null && txtPassword.Text != null)
            {
                UserClass objUser = new UserClass();
                objUser.strEmail = txtEmail.Text.Trim();
                objUser.strPassword = txtPassword.Text.Trim();
                CoreWebList<UserClass> objUserList = objUser.fn_CheckLogin();
                if (objUserList.Count > 0)
                {
                    Session.Add("userId", objUserList[0].iID.ToString());
                    Session.Add("userName", objUserList[0].strName);
                    Session.Add("userEmail", objUserList[0].strEmail);

                    if (Request.QueryString["ReturnUrl"] != null)
                    {
                        Response.Redirect(Request.QueryString["ReturnUrl"].ToString());
                    }
                    else
                    {
                        Response.Redirect("https://www.recruitmentexam.com/");
                    }
                }
                else
                {
                    ((Label)error1.FindControl("mssg")).Text = "Invalid User Name or Password";
                    error1.Visible = true;
                }
            }
            else
            {
                ((Label)error1.FindControl("mssg")).Text = "Please Enter Values in Input Fields";
                error1.Visible = true;
            }
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }
}