using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Collections;


public partial class SearchDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                if (RouteData.Values["Article"] != null)
                {
                    ArticleClass objArticle = new ArticleClass();
                    objArticle.strTitle = RouteData.Values["Article"].ToString().Replace("-", " ");
                    CoreWebList<ArticleClass> objArticleList = objArticle.fn_getArticleByName();
                    if (objArticleList.Count > 0)
                    {
                        ltl_Title.Text = "<h1>" + objArticleList[0].strTitle + "</h1>";

                        img_Pages.Src = "https://www.eduvidya.com/files/Article/" + objArticleList[0].strPhoto;
                        img_Pages.Alt = objArticleList[0].strTitle;

                        ltl_Desc.Text = objArticleList[0].strDetails;

                        string strMetaTitle = objArticleList[0].strTitle;
                        string strMetaDesc = objArticleList[0].strTitle;
                        string strMetaKeys = objArticleList[0].strTitle;

                        ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                        ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                        ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                        Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                        ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a>&nbsp;&nbsp;/&nbsp;&nbsp;<a href='" + VirtualPathUtility.ToAbsolute("~/Studyabroad.aspx") + "'>Studyabroad</a>&nbsp;&nbsp;/&nbsp;&nbsp;<a href='" + VirtualPathUtility.ToAbsolute("~/Studyabroad/" + RouteData.Values["Country"].ToString()) + "'>" + RouteData.Values["Country"].ToString().Replace("-"," ") + "</a>&nbsp;&nbsp;/&nbsp;&nbsp;" + objArticleList[0].strTitle;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}
