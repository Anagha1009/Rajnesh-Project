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
                if (RouteData.Values["Content"] != null)
                {
                    ContentMasterClass objContent = new ContentMasterClass();
                    objContent.strContentType = RouteData.Values["Content"].ToString().Replace("-"," ");
                    CoreWebList<ContentMasterClass> objContentList = objContent.fn_getContent();
                    if (objContentList.Count > 0)
                    {
                        ltl_Title.Text = objContentList[0].strContentType;
                        ltl_Desc.Text = objContentList[0].strContentText;

                        string strMetaTitle = objContentList[0].strContentType;
                        string strMetaDesc = objContentList[0].strContentType;
                        string strMetaKeys = objContentList[0].strContentType;

                        ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                        ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                        ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                        Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                        ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a>" + objContentList[0].strContentType;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}