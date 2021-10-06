using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;

public partial class AuthorBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
            ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a>Sitemaps";
        }
    }
}