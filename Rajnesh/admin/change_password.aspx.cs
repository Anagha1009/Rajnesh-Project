using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_change_password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check login session 
        //If not logged in redirect to admin login page
        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx?flag=1");
        }
        
        info.Visible = false;
        error.Visible = false;
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        try
        {
            string strOldPassword = System.Configuration.ConfigurationManager.AppSettings["AdminPassword"];

            if (strOldPassword == txtOldPassword.Text.Trim())
            {
                //Change the Admin Password in web.config file

                Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
                AppSettingsSection appSection = (AppSettingsSection)config.GetSection("appSettings");
                appSection.Settings["AdminPassword"].Value = txtNewPassword.Text.Trim();
                config.Save();
                
                ((Label)info.FindControl("mssg")).Text = "SUCCESS : Password has been changed";
                info.Visible = true;
            }
            else
            {
                ((Label)error.FindControl("mssg")).Text = "ERROR : Old Password is incorrect";
                error.Visible = true;
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
}
