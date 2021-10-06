using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class Admissions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ContentMasterClass objContent = new ContentMasterClass();
                objContent.strContentType = "Contact Us";
                CoreWebList<ContentMasterClass> objContentList = objContent.fn_getContent();
                if (objContentList.Count > 0)
                {
                    ltl_Title.Text = "About us";
                    ltl_Desc.Text = objContentList[0].strContentText;

                    Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                    ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a>Contact us";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}