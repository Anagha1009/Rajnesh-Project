using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Data;
using System.Text.RegularExpressions;

public partial class Institute_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (RouteData.Values["College"] != null)
            {

                InstituteClass objInstitute = new InstituteClass();
                objInstitute.strTitle = RouteData.Values["College"].ToString().Replace("-", " ").Replace("_", ".");
                CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByName();
                if (objInstituteList.Count > 0)
                {
                    int iInstituteID = objInstituteList[0].iID;
                    int iCityID = objInstituteList[0].iCityID;
                    string strTitle = objInstituteList[0].strTitle;
                    string strCity = objInstituteList[0].strCity;

                    ViewState["TypeID"] = iInstituteID;
                    fn_BindRating();
                    fn_BindInstituteCourses(iInstituteID);
                    fn_BindInstituteExams(iInstituteID);
                    ltl_Title.Text = strTitle;

                    ltl_CoursesOffered.Text = strTitle + " Courses offered";

                    ltl_City.Text = strCity;
                    ltl_Desc.Text = objInstituteList[0].strDesc;
                    ltl_ContactDetails.Text = objInstituteList[0].strContactDetails;
                    ltl_Admissions.Text = objInstituteList[0].strAdmissions;
                    ltl_Facilities.Text = objInstituteList[0].strFacilities;
                    ltl_Placements.Text = objInstituteList[0].strPlacements;

                    hf_ContactDetails.Value = objInstituteList[0].strTitle + ", " + objInstituteList[0].strCity;

                    ltl_Details.Text = "<b>Established In : </b>" + objInstituteList[0].strEstablishedIn + "<br/><b>Affiliated To : </b>" + objInstituteList[0].strAffiliatedTo + "<br/><b>Website : </b>" + objInstituteList[0].strWebsite + "<br/><b>Address : </b>" + fn_StripHTMLTags(objInstituteList[0].strContactDetails);

                    img_Photo.Src = "https://www.eduvidya.com/admin/Upload/Institutes/" + objInstituteList[0].strPhoto;
                    img_Photo.Alt = strTitle;

                    Session["InstitutionType"] = "Institute";
                    Session["InstitutionName"] = objInstituteList[0].strTitle;
                    Session["InstitutionTypeID"] = objInstituteList[0].iID;

                    fn_BindPlacePhotos(iInstituteID);
                    fn_BindInstituteVideos(iInstituteID);
                    fn_BindCityColleges(iCityID);

                    string strMetaTitle = strTitle + " " + strCity + ", Admissions 2021-22, Placements, Fees, Address";
                    string strMetaDesc = "Find about " + strTitle + " " + strCity + " admissions 2021-22, placements, fee structure, cut off, ranking and hostel address. Also get its exam syllabus, application forms, reviews, admission procedure and eligibility.";
                    string strMetaKeys = strTitle;

                    fn_BindReviews("Institute", iInstituteID);

                    ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                    ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                    ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                    Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                    ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='" + VirtualPathUtility.ToAbsolute("~/Colleges-in-India.aspx") + "'>Colleges in India</a>" + strTitle;

                    //lnkCompareColleges.HRef = "https://www.eduvidya.com/Comparisions.aspx";

                     HtmlControl dynamicid = (HtmlControl)Master.FindControl("dynamicid");
                     dynamicid.ID = "details-page";
                   
                }
            }
        }
    }

    protected void fn_BindPlacePhotos(int iInstituteID)
    {
        try
        {
            InstitutePhotoClass objPhotos = new InstitutePhotoClass();
            objPhotos.iInstituteID = iInstituteID;
            CoreWebList<InstitutePhotoClass> objPhotosList = objPhotos.fn_getInstitutePhotoByInstituteID();
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

    protected void fn_BindInstituteVideos(int iInstituteID)
    {
        try
        {
            InstituteVideoClass objVideo = new InstituteVideoClass();
            objVideo.iInstituteID = iInstituteID;
            CoreWebList<InstituteVideoClass> objVideoList = objVideo.fn_getInstituteVideoByInstituteID();
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
            objRate.strType = "College";
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
            objRate.strType = "College";
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
                ltl_RatingBox.Text = "(Become first to Rate this College!)";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindInstituteCourses(int iInstituteID)
    {
        try
        {
            InstituteCourseClass objCourse = new InstituteCourseClass();
            objCourse.iInstituteID = iInstituteID;
            CoreWebList<InstituteCourseClass> objCourseList = objCourse.fn_getInstituteCourseByInstituteID();
            if (objCourseList.Count > 0)
            {
                rpt_Courses.DataSource = objCourseList;
                rpt_Courses.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindInstituteExams(int iInstituteID)
    {
        try
        {
            InstituteExamClass objInstituteExam = new InstituteExamClass();
            objInstituteExam.iInstituteID = iInstituteID;
            CoreWebList<InstituteExamClass> objInstituteExamList = objInstituteExam.fn_getInstituteExamByInstituteID();
            if (objInstituteExamList.Count > 0)
            {
                string strLinks = "";
                for (int i = 0; i < objInstituteExamList.Count; i++)
                {
                    strLinks += "<a href='" + VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + objInstituteExamList[i].strTitle.Replace(" ", "-")) + "' class'rec_links'>" + objInstituteExamList[i].strTitle + "</a>,&nbsp;&nbsp;";
                }

                ltl_ExamAccepted.Text = strLinks.TrimEnd(",&nbsp;&nbsp;".ToCharArray());
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

    public static string fn_StripHTMLTags(string strText)
    {
        return Regex.Replace(strText, "<.*?>", string.Empty);

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

    protected void fn_BindCityColleges(int iCityID)
    {
        try
        {
            InstituteClass obj_Institute = new InstituteClass();
            obj_Institute.iCityID = iCityID;
            CoreWebList<InstituteClass> obj_InstituteList = obj_Institute.fn_getRandomInstituteByCityID();
            if (obj_InstituteList.Count > 0)
            {
                rpt_Institutes.DataSource = obj_InstituteList;
                rpt_Institutes.DataBind();
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
