using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class Gallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (RouteData.Values["Banner"] != null)
            {
                int iIndex = 0;
                string strNextUrl = "";
                string strPreviousUrl = "";

                string strUrl = "Banners/" + RouteData.Values["Banner"].ToString();

                if (RouteData.Values["PhotoID"] != null)
                {
                    string strQuery = "/Photos/" + RouteData.Values["PhotoID"].ToString();
                    strUrl = strUrl.Replace(strQuery, "");
                }

                BannerClass objBanner = new BannerClass();
                objBanner.strTitle = RouteData.Values["Banner"].ToString().Replace("-"," ");
                CoreWebList<BannerClass> objBannerList = objBanner.fn_getBannerByName();
                if (objBannerList.Count > 0)
                {

                    int iCounter = objBannerList.Count;

                    if (RouteData.Values["PhotoID"] == null)
                    {
                        iIndex = 0;
                        hyp_Previous.Visible = false;

                        if (iCounter > 1)
                        {
                            strNextUrl = strUrl + "/Image-" + (iIndex + 1);
                        }
                        else
                        {
                            hyp_Next.Visible = false;
                        }
                    }
                    else
                    {
                        iIndex = int.Parse(RouteData.Values["PhotoID"].ToString().Replace("Image-",""));

                        if (iIndex == 1)
                        {
                            strPreviousUrl = strUrl;
                        }
                        else
                        {
                            strPreviousUrl = strUrl + "/Image-" + (iIndex - 1);
                        }

                        if ((iCounter - 1) == iIndex)
                        {
                            hyp_Next.Visible = false;
                        }
                        else
                        {
                            strNextUrl = strUrl + "/Image-" + (iIndex + 1);
                        }
                    }

                    hyp_Next.HRef = VirtualPathUtility.ToAbsolute("~/" + strNextUrl);
                    hyp_Previous.HRef = VirtualPathUtility.ToAbsolute("~/" + strPreviousUrl);

                    ltl_Title.Text = objBannerList[iIndex].strTitle;

                    ltl_Rank.Text = "<b>" + objBannerList[iIndex].strDetailTitle + "</b><br/>Rank : " + objBannerList[iIndex].iOrderID;
                    img_BannerPhoto.Src = VirtualPathUtility.ToAbsolute("~/files/BannerDetail/" + objBannerList[iIndex].strDetailPhoto);
                    img_BannerPhoto.Alt = objBannerList[iIndex].strDetailTitle;
                    hyp_link.NavigateUrl = objBannerList[iIndex].strDetailLink;
                    hyp_link.Text= objBannerList[iIndex].strDetailTitle;

                    string strMetaTitle ="";
                    string strMetaDesc = "";
                    string strMetaKeys = "";

                    strMetaTitle = objBannerList[iIndex].strTitle + " - " + objBannerList[iIndex].strDetailTitle + " - Rank " + objBannerList[iIndex].iOrderID;
                    strMetaDesc = objBannerList[iIndex].strTitle + " - " + objBannerList[iIndex].strDetailTitle + " - Rank " + objBannerList[iIndex].iOrderID;
                    strMetaKeys = objBannerList[iIndex].strTitle + " - " + objBannerList[iIndex].strDetailTitle + " - Rank " + objBannerList[iIndex].iOrderID;


                    ltl_MetaTitle.Text = "<title>" + strMetaTitle + "</title>";
                    ltl_MetaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                    ltl_MetaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";
                }
                else
                {
                    Banner_Box.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}