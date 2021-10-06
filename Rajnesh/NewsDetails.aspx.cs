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
                if (RouteData.Values["News"] != null)
                {
                    NewsClass objNews = new NewsClass();
                    objNews.strTitle = RouteData.Values["News"].ToString().Replace("-", " ");
                    CoreWebList<NewsClass> objNewsList = objNews.fn_getNewsByName();
                    if (objNewsList.Count > 0)
                    {
                        ltl_Title.Text = objNewsList[0].strTitle;
                        ltl_Desc.Text = objNewsList[0].strDesc;

                        string strMetaTitle = objNewsList[0].strTitle;
                        string strMetaDesc = objNewsList[0].strTitle;
                        string strMetaKeys = objNewsList[0].strTitle;

                        ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                        ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                        ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                        Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                        ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='https://www.eduvidya.com/News.aspx'>News</a>" + objNewsList[0].strTitle;
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