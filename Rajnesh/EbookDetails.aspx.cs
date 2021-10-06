using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class EbookDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (RouteData.Values["Ebook"] != null)
                {
                    EbookClass objEbook = new EbookClass();
                    objEbook.strTitle = RouteData.Values["Ebook"].ToString().Replace("-", " ");
                    CoreWebList<EbookClass> objEbookList = objEbook.fn_getEbookByName();
                    if (objEbookList.Count > 0)
                    {
                        string strTitle = objEbookList[0].strTitle;

                        ltl_Title.Text = strTitle;
                        ltl_Details.Text = objEbookList[0].strDetails;

                        hyp_Ebook.HRef = VirtualPathUtility.ToAbsolute("~/files/Ebook/" + objEbookList[0].strFile);
                        hyp_Ebook.InnerText = objEbookList[0].strFile;

                        string strMetaTitle = strTitle;
                        string strMetaDesc = strTitle;
                        string strMetaKeys = strTitle;

                        ltl_metaTitle.Text = "<title>" + strMetaTitle.ToUpper() + "</title>";
                        ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                        ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                        Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                        ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='https://www.eduvidya.com/Ebooks.aspx'>Ebooks</a>" + strTitle;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + ex.StackTrace);
            }
        }
    }
}