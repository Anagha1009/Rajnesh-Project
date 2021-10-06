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

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check login session 
        //If not logged in redirect to admin login page
        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx?flag=1");
        }
        else
        {
            username.Text = Session["admin"].ToString();
        }
    }
}
