using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Data;

public partial class Universities_in_India : System.Web.UI.Page
{
    int iUniversityID = 0;
    int iCourseID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            UniversityListClass objUniversity = new UniversityListClass();
            objUniversity.strTitle = RouteData.Values["Course"].ToString().Replace("-", " ");
            CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_GetUniversityCoursebyTitle();
            if (objUniversityList.Count > 0)
            {
                iUniversityID = objUniversityList[0].iID;
                iCourseID = objUniversityList[0].iCourseID;

                string strMetaTitle = objUniversityList[0].strCourseName + " Admission 2018-19, Forms, Syllabus, Exam Results";
                string strMetaDesc = "Get details about " + objUniversityList[0].strCourseName + ", Admission 2018 - 2019, Forms, Syllabus and Exam Results.";
                string strMetaKeys = objUniversityList[0].strCourseName;

                ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                ltl_metaKeys.Text = "<meta name=\"Keywords\" content=\"" + strMetaKeys + "\" />";

                Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                ltl_bredcrumbs.Text = "<a href='" + VirtualPathUtility.ToAbsolute("~/") + "'>Home</a><a href='" + VirtualPathUtility.ToAbsolute("~/Indian-Universities.aspx") + "'>Indian Universities</a><a href='" + VirtualPathUtility.ToAbsolute("~/Universities/" + objUniversityList[0].strInstitute.Replace(" ", "-")) + "'>" + objUniversityList[0].strInstitute + "</a><a href='" + VirtualPathUtility.ToAbsolute("~/Universities/" + objUniversityList[0].strInstitute.Replace(" ","-") + "/Courses") + "'>" + objUniversityList[0].strInstitute + " Courses</a>" + objUniversityList[0].strCourseName;

                lblTitle.Text = objUniversityList[0].strCourseName;

                UniversityListClass obj_University = new UniversityListClass();
                obj_University.iID = objUniversityList[0].iID;
                CoreWebList<UniversityListClass> obj_UniversityList = obj_University.fn_getUniversityByID();
                if (obj_UniversityList.Count > 0)
                {
                    lblUniversity.Text = obj_UniversityList[0].strTitle;
                    lblother.Text = "Other Courses offered by " + obj_UniversityList[0].strTitle;

                    lblDescription.Text = "<b>" + objUniversityList[0].strCourseName + " Course Details : </b></br></br>" + objUniversityList[0].strCourseDetails;
                }


                hyp_InstitutionLink.HRef = VirtualPathUtility.ToAbsolute("~/Universities/" + objUniversityList[0].strInstitute.Replace(" ", "-"));
                hyp_InstitutionLink.InnerText = "About " + obj_UniversityList[0].strTitle;

                if (obj_UniversityList[0].strDesc.Length > 210)
                {
                    ltl_InstitutionDetails.Text = obj_UniversityList[0].strDesc.Substring(0, 210) + "..";
                }
                else
                {
                    ltl_InstitutionDetails.Text = obj_UniversityList[0].strDesc;
                }

                UniversityListClass objUniv = new UniversityListClass();
                objUniv.iID = iUniversityID;

                CoreWebList<UniversityListClass> objUnivList = objUniv.fn_GetUniversityCourseListByUniversityID();
                if (objUnivList.Count > 0)
                {
                    rptOther.DataSource = objUnivList;
                }
                else
                {
                    rptOther.DataSource = null;
                }
                rptOther.DataBind();

                if (!IsPostBack)
                {
                    fn_BindRating();
                }

            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    /*Rating ---- Like ---- Dislike*/
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
            objRate.strType = "Courses";
            objRate.iTypeID = iCourseID;
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
            objRate.strType = "Courses";
            objRate.iTypeID = iCourseID;
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
