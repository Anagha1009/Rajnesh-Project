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
                if (RouteData.Values["Title"] != null)
                {
                    fn_BindRating();

                    PageGeneratorClass objPage = new PageGeneratorClass();
                    objPage.strTitle = RouteData.Values["Title"].ToString().Replace("-", " ");
                    CoreWebList<PageGeneratorClass> objPageList = objPage.fn_getPageGeneratorByName();
                    if (objPageList.Count > 0)
                    {
                        ltl_Title.Text = objPageList[0].strTitle;

                        img_Pages.Src = "https://www.eduvidya.com/files/PageGenerator/" + objPageList[0].strPhoto;
                        img_Pages.Alt = objPageList[0].strTitle;

                        ltl_Desc.Text = objPageList[0].strDetails;

                        fn_BindPhotos(objPageList[0].iID);

                        string strMetaTitle = objPageList[0].strMetaTitle;
                        string strMetaDesc = objPageList[0].strMetaDesc;
                        string strMetaKeys = objPageList[0].strMetaKeys;

                        ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                        ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                        ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                        Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                        ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='" + VirtualPathUtility.ToAbsolute("~/Search.aspx") + "'>Search</a>" + objPageList[0].strTitle;

                        HtmlControl dynamicid = (HtmlControl)Master.FindControl("dynamicid");
                        dynamicid.ID = "inner-list-page";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindPhotos(int Id)
    {
        try
        {
            PagePhotoClass objPhotos = new PagePhotoClass();
            objPhotos.iPageID = Id;
            CoreWebList<PagePhotoClass> objPhotosList = objPhotos.fn_getPagePhotoByPageID();
            if (objPhotosList.Count > 0)
            {
                dl_Photos.DataSource = objPhotosList;
                dl_Photos.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }



    protected void rt_Rate_Changed(object sender, EventArgs e)
    {
        try
        {
            fn_StarRating();
            fn_BindRating();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_StarRating()
    {
        try
        {
            string strResponse = "";

            RatingClass objRate = new RatingClass();
            objRate.strType = Request.Url.ToString();
            objRate.iTypeID = 1;
            CoreWebList<RatingClass> objRateList = objRate.fn_getRatingByTypeID();
            if (objRateList.Count > 0)
            {
                objRate.iID = objRateList[0].iID;
                objRate.fCount = rt_Rate.CurrentRating + objRateList[0].fCount;
                objRate.iClicks = objRateList[0].iClicks + 1;

                strResponse = objRate.fn_EditRating();
            }
            else
            {
                objRate.fCount = rt_Rate.CurrentRating;
                objRate.iClicks = 1;

                strResponse = objRate.fn_SaveRating();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindRating()
    {
        try
        {
            RatingClass objRate = new RatingClass();
            objRate.strType = Request.Url.ToString();
            objRate.iTypeID = 1;
            CoreWebList<RatingClass> objRateList = objRate.fn_getRatingByTypeID();
            if (objRateList.Count > 0)
            {
                double dRate = Math.Round(objRateList[0].fCount / objRateList[0].iClicks);
                rt_Rate.CurrentRating = (int)dRate;

                ltl_RatingBox.Text = "(<span itemprop=\"rating\" itemscope itemtype=\"https://data-vocabulary.org/Rating\"><span itemprop=\"average\">" + dRate.ToString() + "</span> out of <span itemprop=\"best\">5</span> </span>based on <span itemprop=\"count\">" + objRateList[0].iClicks + "</span> Ratings)";
            }
            else
            {
                ltl_RatingBox.Text = "(Become first to Rate this!)";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}
