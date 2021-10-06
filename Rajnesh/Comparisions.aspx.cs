using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Compare : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlControl dynamicid = (HtmlControl)Master.FindControl("dynamicid");
        dynamicid.ID = "comparisions-page";

    }
}