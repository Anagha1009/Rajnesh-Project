using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Data;
using System.Text.RegularExpressions;

public partial class School_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (RouteData.Values["School"] != null)
            {
                SchoolClass objSchool = new SchoolClass();
                objSchool.strTitle = RouteData.Values["School"].ToString().Replace("-", " ").Replace("_", ".");
                CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolByName();
                if (objSchoolList.Count > 0)
                {
                    int iInstituteID = objSchoolList[0].iID;
                    string strTitle = objSchoolList[0].strTitle;
                    string strCity = objSchoolList[0].strCity;

                    Session["InstitutionType"] = "School";
                    Session["InstitutionName"] = strTitle;
                    Session["InstitutionTypeID"] = iInstituteID;

                    ViewState["TypeID"] = iInstituteID;
                    fn_BindRating();
                    fn_BindReviews("School", iInstituteID);

                    ltl_Title.Text = strTitle;

                    ltl_SchAddrs.Text = strTitle + " Address";
                    ltl_AdmTitle.Text = strTitle + " Admissions";

                    ltl_City.Text = objSchoolList[0].strCity;

                    ltl_Desc.Text = objSchoolList[0].strDesc;
                    ltl_ContactDetails.Text = objSchoolList[0].strContactDetails;
                    ltl_Admissions.Text = objSchoolList[0].strAdmissions;
                    ltl_Facilities.Text = objSchoolList[0].strFacilities;

                    hf_ContactDetails.Value = objSchoolList[0].strTitle + ", " + objSchoolList[0].strCity;

                    ltl_Details.Text = "<b>Affiliated Board : </b>" + objSchoolList[0].strAfflialtedBoard + "<br/><b>Website : </b>" + objSchoolList[0].strWebsite + "<br/><b>Contact Details : </b>" + fn_StripHTMLTags(objSchoolList[0].strContactDetails);

                    img_Photo.Src = "https://www.eduvidya.com/admin/Upload/Schools/" + objSchoolList[0].strPhoto;
                    img_Photo.Alt = strTitle;

                    fn_BindSchoolPhotos(iInstituteID);
                    fn_BindSchoolVideos(iInstituteID);

                    string strMetaTitle = strTitle + " " + strCity + " Admissions, Address, Fees, Review";
                    string strMetaDesc = "Get details on " + strTitle + " " + strCity + " Admissions 2021-22. Also get its Admission Procedure, Fees Structure, Review and Address.";
                    string strMetaKeys = strTitle;

                    ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                    ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                    ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                    Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                    ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='" + VirtualPathUtility.ToAbsolute("~/Schools-in-India.aspx") + "'>Schools in India</a>" + strTitle;

                    HtmlControl dynamicid = (HtmlControl)Master.FindControl("dynamicid");
                    dynamicid.ID = "details-page";
                }
            }
        }
    }

    protected void fn_BindSchoolPhotos(int iSchoolID)
    {
        try
        {
            SchoolPhotoClass objPhotos = new SchoolPhotoClass();
            objPhotos.iSchoolID = iSchoolID;
            CoreWebList<SchoolPhotoClass> objPhotosList = objPhotos.fn_getSchoolPhotoBySchoolID();
            if (objPhotosList.Count > 0)
            {
                dl_Photos.DataSource = objPhotosList;
                dl_Photos.DataBind();

                rpt_Photos.DataSource = objPhotosList;
                rpt_Photos.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindSchoolVideos(int iSchoolID)
    {
        try
        {
            SchoolVideoClass objVideo = new SchoolVideoClass();
            objVideo.iSchoolID = iSchoolID;
            CoreWebList<SchoolVideoClass> objVideoList = objVideo.fn_getSchoolVideoBySchoolID();
            if (objVideoList.Count > 0)
            {
                dl_Videos.DataSource = objVideoList;
                dl_Videos.DataBind();
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
            objRate.strType = "Schools";
            objRate.iTypeID = int.Parse(ViewState["TypeID"].ToString());
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
            objRate.strType = "Schools";
            objRate.iTypeID = int.Parse(ViewState["TypeID"].ToString());
            CoreWebList<RatingClass> objRateList = objRate.fn_getRatingByTypeID();
            if (objRateList.Count > 0)
            {
                double dRate = Math.Round(objRateList[0].fCount / objRateList[0].iClicks);
                rt_Rate.CurrentRating = (int)dRate;

                ltl_RatingBox.Text = "(<span itemprop=\"rating\" itemscope itemtype=\"https://data-vocabulary.org/Rating\"><span itemprop=\"average\">" + dRate.ToString() + "</span> out of <span itemprop=\"best\">5</span> </span>based on <span itemprop=\"count\">" + objRateList[0].iClicks + "</span> Ratings)";
            }
            else
            {
                ltl_RatingBox.Text = "(Become first to Rate this School!)";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    private void fn_BindReviews(string strInstitutionType, int iInstituteID)
    {
        try
        {
            EduReviewClass objEduReview = new EduReviewClass();
            objEduReview.strInstitutionType = strInstitutionType;
            objEduReview.iInstitutionID = iInstituteID;
            CoreWebList<EduReviewClass> objEduReviewList = objEduReview.fn_getEduReviewByType();
            if (objEduReviewList.Count > 0)
            {
                rpt_Review.DataSource = objEduReviewList;
                rpt_Review.DataBind();
            }
            else
            {
                lnkReviews.Visible = false;
                ReviewBox.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    public static string fn_ShortDetails(string strText)
    {
        strText = Regex.Replace(strText, "<.*?>", string.Empty);

        if (strText.Length > 210)
        {
            strText = strText.Substring(0, 210);
        }

        return strText;

    }

    public static string fn_StripHTMLTags(string strText)
    {
        return Regex.Replace(strText, "<.*?>", string.Empty);
    }
}
