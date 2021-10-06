using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class UserControls_InstituteBanner : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strUrl = Request.Url.ToString();

            BannerClass objBanner = new BannerClass();
            objBanner.strTargetUrl = strUrl;
            CoreWebList<BannerClass> objBannerList = objBanner.fn_getBannerByTargetUrl();
            if (objBannerList.Count > 0)
            {

                ltl_Title.Text = objBannerList[0].strTitle;

                img_BannerDetailPhoto.Src = VirtualPathUtility.ToAbsolute("~/files/BannerDetail/" + objBannerList[0].strDetailPhoto);
                img_BannerDetailPhoto.Alt = objBannerList[0].strTitle;

                ltl_BannerDetailTitle.Text = objBannerList[0].strDetailTitle;

                string strGalleryUrl = "Gallery.aspx?Banner=" + objBannerList[0].strTitle.Replace(" ", "-");
                string strGallery_Url = "~/Gallery.aspx?Banner=" + objBannerList[0].strTitle.Replace(" ", "-");
                ltl_Rank.Text = "Rank : " + objBannerList[0].iOrderID;

                hyp_Next.HRef = strGallery_Url;
            }
            else
            {
                Banner_Box.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}