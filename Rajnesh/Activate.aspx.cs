using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class Activate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.MaintainScrollPositionOnPostBack = true;

            Error1.Visible = false;
            Info1.Visible = false;

            if (Request.QueryString["key"] != null && Request.QueryString["Id"] != null)
            {
                string strMD5 = MD5(Request.QueryString["Id"].ToString());

                if (Request.QueryString["key"].ToString() == strMD5)
                {
                    UserClass objUM = new UserClass();
                    objUM.iID = int.Parse(Request.QueryString["Id"].ToString());
                    objUM.bActive = true;
                    string strStatus = objUM.fn_editUserStatus();

                    if (strStatus.Contains("SUCCESS"))
                    {
                        ((Label)Info1.FindControl("mssg")).Text = "Thank you for registering with eduvidya.com<br/><a href='Login.aspx' class='normalLinks'>Click here to Login</a><br/><b>Note:</b></i>&nbsp; Please read the&nbsp; <a href='Terms-and-Conditions.aspx' class='normalLinks' target='_blank'>Terms and Conditions</a>&nbsp;and&nbsp;<a href='Privacy-Policy.aspx' class='normalLinks' target='_blank'>Privacy Policy</a>&nbsp;before you continue.";
                        Info1.Visible = true;
                    }
                    else
                    {
                        ((Label)Error1.FindControl("mssg")).Text = "Invalid Request!";
                        Error1.Visible = true;
                    }
                }
                else
                {
                    ((Label)Error1.FindControl("mssg")).Text = "Invalid Request!";
                    Error1.Visible = true;
                }
            }
            else
            {
                ((Label)Error1.FindControl("mssg")).Text = "Invalid Request!";
                Error1.Visible = true;
            }
        }
        catch (Exception ex)
        {
            ((Label)Error1.FindControl("mssg")).Text = ex.Message + ex.StackTrace;
            Error1.Visible = true;
        }
    }

    static string MD5(string strString)
    {
        byte[] textBytes = System.Text.Encoding.Default.GetBytes(strString);
        try
        {
            System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler;
            cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] hash = cryptHandler.ComputeHash(textBytes);
            string ret = "";

            foreach (byte a in hash)
            {
                if (a < 16)
                {
                    ret += "0" + a.ToString("x");
                }
                else
                {
                    ret += a.ToString("x");
                }
            }

            return ret;
        }
        catch
        {
            throw;
        }
    }
}