using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Data;
using System.Text.RegularExpressions;

public partial class University_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (RouteData.Values["University"] != null)
            {

                DistanceLearningClass objUniversity = new DistanceLearningClass();
                objUniversity.strName = RouteData.Values["University"].ToString().Replace("-", " ").Replace("_", ".");
                CoreWebList<DistanceLearningClass> objUniversityList = objUniversity.fn_GetDistanceLearningListByName();
                if (objUniversityList.Count > 0)
                {
                    int iUniversityID = objUniversityList[0].iID;
                    string strTitle = objUniversityList[0].strName;
                    string strCity = objUniversityList[0].strCity;

                    ViewState["TypeID"] = iUniversityID;
                    fn_BindRating();
                    fn_BindUniversityCourses(iUniversityID);
                    ltl_Title.Text = strTitle;

                    ltl_CoursesOffered.Text = strTitle + " Courses offered";

                    ltl_City.Text = strCity;
                    ltl_Desc.Text = objUniversityList[0].strDesc;
                    ltl_Results.Text = objUniversityList[0].strResults;
                    ltl_NotificationTitle.Text = strTitle + " Notifications";

                    string strAddress = string.Empty;

                    DLCenterClass objCentre = new DLCenterClass();
                    objCentre.iDLInstituteID = iUniversityID;
                    CoreWebList<DLCenterClass> objCentreList = objCentre.fn_get_DLCentreListByInstituteID();
                    if (objCentreList.Count > 0)
                    {
                        strAddress = objCentreList[0].strCity + " " + objCentreList[0].strAddress;
                    }

                    ltl_ContactDetails.Text = strAddress;

                    ltl_Admissions.Text = objUniversityList[0].strAdmissions;

                    hf_ContactDetails.Value = objUniversityList[0].strName + ", " + objUniversityList[0].strCity;

                    ltl_Details.Text = "<b>Email : </b>" + objUniversityList[0].strEmail + "<br/><b>Website : </b>" + objUniversityList[0].strWebsite + "<br/><b>Address : </b>" + fn_StripHTMLTags(strAddress);

                    img_Photo.Src = "https://www.eduvidya.com/admin/Upload/DistanceLearning/" + objUniversityList[0].strImage;
                    img_Photo.Alt = strTitle;

                    fn_BindRandomUniversity();
                    fn_BindNotifications(iUniversityID);

                    string strMetaTitle = strTitle + " " + strCity + " Admission 2021-22, Results, Exam Timetable, Address";
                    string strMetaDesc = "Get details on " + strTitle + " " + strCity + " Admissions 2021-22, Results and Exam timetable. Also know its Address, Hall ticket, Courses offered and fees";
                    string strMetaKeys = strTitle;

                    ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                    ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                    ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                    Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                    ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='" + VirtualPathUtility.ToAbsolute("~/Distance-University.aspx") + "'>Distance Universities </a>" + strTitle;
                }
            }
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
            objRate.strType = "DistanceUniversity";
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
            objRate.strType = "DistanceUniversity";
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

    protected void fn_BindUniversityCourses(int iUniversityID)
    {
        try
        {
            DLCoursesClass objCourse = new DLCoursesClass();
            objCourse.iDistanceID = iUniversityID;
            CoreWebList<DLCoursesClass> objCourseList = objCourse.fn_getRandomDLCourseByDistanceID();
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

    protected void fn_BindRandomUniversity()
    {
        try
        {
            DistanceLearningClass objUniversity = new DistanceLearningClass();
            CoreWebList<DistanceLearningClass> objUniversityList = objUniversity.fn_GetRandomDistanceLearning();
            if (objUniversityList.Count > 0)
            {
                rpt_University.DataSource = objUniversityList;
                rpt_University.DataBind();
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

    protected void fn_BindNotifications(int iUniversityID)
    {
        try
        {
            NotificationClass objNotifications = new NotificationClass();
            objNotifications.iUniversityID = iUniversityID;
            CoreWebList<NotificationClass> objNotificationsList = objNotifications.fn_getNotificationByUniversityID();
            if (objNotificationsList.Count > 0)
            {
                rpt_Notifications.DataSource = objNotificationsList;
                rpt_Notifications.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}
