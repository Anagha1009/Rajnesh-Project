using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Collections;

public partial class BlogDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                if (RouteData.Values["Video"] != null && RouteData.Values["VideoID"] != null)
                {
                    QueryGeneratorClass objQuery = new QueryGeneratorClass();
                    CoreWebList<QueryGeneratorClass> objQueryList = objQuery.fn_getQueryGeneratorList();
                    if (objQueryList.Count > 0)
                    {
                        ltl_Title.Text = "<h1>" + objQueryList[0].strTitle + "</h1>";

                        YoutubeFrame.Attributes.Add("src", "https://www.youtube.com/embed/" + fn_GetUrl(objQueryList[0].strYoutube));

                        ltl_metaTitle.Text = "<title>" + objQueryList[0].strYoutubeTitle + "</title>";
                        ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + objQueryList[0].strYoutubeTitle + "\" />";
                        ltl_metaKeys.Text = "<meta name=\"Keywords\" content=\"" + objQueryList[0].strYoutubeTitle + "\" />";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected string fn_GetUrl(string strRawUrl)
    {
        try
        {
            Uri tempUri = new Uri(strRawUrl);
            string sQuery = tempUri.Query;
            string sUrl = HttpUtility.ParseQueryString(sQuery).Get("v");
            return sUrl;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
