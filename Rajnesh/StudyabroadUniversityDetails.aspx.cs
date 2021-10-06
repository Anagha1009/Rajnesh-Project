using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Data;

public partial class Studyabroad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UniversityClass objUniversity = new UniversityClass();
            objUniversity.strTitle = RouteData.Values["Name"].ToString().Replace("-", " ");
            CoreWebList<UniversityClass> objUniversityList = objUniversity.fn_getUniversityByName();
            if (objUniversityList.Count > 0)
            {
                int iUniversityId = objUniversityList[0].iID;
                ViewState["UniversityId"] = iUniversityId;

                ltl_Title.Text = objUniversityList[0].strTitle;
                ltl_Details.Text = objUniversityList[0].strDetails;
                ltl_EstablishedIn.Text = objUniversityList[0].strEstablishedIn;
                ltl_AffiliatedTo.Text = objUniversityList[0].strAffiliatedTo;
                ltl_Email.Text = objUniversityList[0].strEmail;

                hlnk_Website.HRef = "https://" + objUniversityList[0].strWebsite.ToLower().Replace("https://", "");
                hlnk_Website.InnerText = objUniversityList[0].strWebsite;

                imgUniversity.ImageUrl = VirtualPathUtility.ToAbsolute("~/files/University/" + objUniversityList[0].strLogo);
                imgUniversity.AlternateText = objUniversityList[0].strTitle;

                ltl_Admission.Text = objUniversityList[0].strTitle + " Admissions";
                ltl_AdmissionDetails.Text = objUniversityList[0].strAdmissions;

                ltl_Infrastructure.Text = objUniversityList[0].strTitle + " Infrastructure";
                ltl_InfrastructureDetails.Text = objUniversityList[0].strInfrastructure;

                ltl_Placements.Text = objUniversityList[0].strTitle + " Placements";
                ltl_PlacementDetails.Text = objUniversityList[0].strPlacements;

                ltl_Courses.Text = objUniversityList[0].strTitle + " Courses";
                ltl_Images.Text = objUniversityList[0].strTitle + " Images";
                ltl_Videos.Text = objUniversityList[0].strTitle + " Videos";

                ltl_Ranking.Text = objUniversityList[0].strTitle + " Rankings";
                ltl_RankingDetails.Text = objUniversityList[0].strRanking;

                ltl_Contact.Text = objUniversityList[0].strTitle + " Contact Details";
                ltl_ContactDetails.Text = objUniversityList[0].strContactDetails;

                fn_BindCourses();
                fn_BindPhotos();
                fn_BindUniversityVideos();
                fn_BindRating();

                string strMetaTitle = objUniversityList[0].strTitle + " Ranking, Scholarships, Fees, Courses, Admission" ;
                string strMetaDesc = "Get Details about " + objUniversityList[0].strTitle +" Ranking, Scholarships, Admission 2021-22, Fees and courses like mba, engineering, phd, computer science, arts, masters and bachelors.";
                string strMetaKeys = objUniversityList[0].strTitle;

                ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                ltl_metaKeys.Text = "<meta name=\"Keywords\" content=\"" + strMetaKeys + "\" />";

                Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                ltl_bredcrumbs.Text = "<a href='" + VirtualPathUtility.ToAbsolute("~/") + "'>Home</a><a href='" + VirtualPathUtility.ToAbsolute("~/Studyabroad.aspx") + "'>Studyabroad</a><a href='" + VirtualPathUtility.ToAbsolute("~/Studyabroad/" + RouteData.Values["Country"].ToString()) + "'>" + RouteData.Values["Country"].ToString().Replace("-", " ") + "</a>" + objUniversityList[0].strTitle;
            }
        }
    }

    private void fn_BindCourses()
    {
        try
        {
            CourseClass objCourses = new CourseClass();
            objCourses.iUniversityID = int.Parse(ViewState["UniversityId"].ToString());
            CoreWebList<CourseClass> objCourseList = objCourses.fn_getCourseByUniversityID();
            if (objCourseList.Count > 0)
            {
                rptr_UniversityCourses.DataSource = objCourseList;
                rptr_UniversityCourses.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    private void fn_BindPhotos()
    {
        try
        {
            UniversityPhotoClass objPhotos = new UniversityPhotoClass();
            objPhotos.iUniversityID = int.Parse(ViewState["UniversityId"].ToString());
            CoreWebList<UniversityPhotoClass> objPhotoList = objPhotos.fn_getUniversityPhotoByUniversityID();
            if (objPhotoList.Count > 0)
            {
                dl_Images.DataSource = objPhotoList;
                dl_Images.DataBind();

                rpt_Photos.DataSource = objPhotoList;
                rpt_Photos.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindUniversityVideos()
    {
        try
        {
            UniversityVideosClass objUniversity = new UniversityVideosClass();
            objUniversity.iUniversityID = int.Parse(ViewState["UniversityId"].ToString());
            CoreWebList<UniversityVideosClass> objUniversityList = objUniversity.fn_getUniversityVideoByUniversityID();
            if (objUniversityList.Count > 0)
            {
                dl_CollegeVideos.DataSource = objUniversityList;
                dl_CollegeVideos.DataBind();
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
            objRate.strType = "SAUniversity";
            objRate.iTypeID = int.Parse(ViewState["UniversityId"].ToString());
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
            objRate.strType = "SAUniversity";
            objRate.iTypeID = int.Parse(ViewState["UniversityId"].ToString());
            CoreWebList<RatingClass> objRateList = objRate.fn_getRatingByTypeID();
            if (objRateList.Count > 0)
            {
                double dRate = Math.Round(objRateList[0].fCount / objRateList[0].iClicks);
                rt_Rate.CurrentRating = (int)dRate;

                ltl_RatingBox.Text = "(<span itemprop=\"rating\" itemscope itemtype=\"https://data-vocabulary.org/Rating\"><span itemprop=\"average\">" + dRate.ToString() + "</span> out of <span itemprop=\"best\">5</span> </span>based on <span itemprop=\"count\">" + objRateList[0].iClicks + "</span> Ratings)";
            }
            else
            {
                ltl_RatingBox.Text = "(Become first to Rate this University!)";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}
