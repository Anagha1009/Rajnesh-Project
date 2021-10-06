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

                UniversityListClass objUniversity = new UniversityListClass();
                objUniversity.strTitle = RouteData.Values["University"].ToString().Replace("-", " ").Replace("_", ".");
                CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_getUniversityByName();
                if (objUniversityList.Count > 0)
                {
                    int iUniversityID = objUniversityList[0].iID;
                    string strTitle = objUniversityList[0].strTitle;
                    string strCity = objUniversityList[0].strCity;

                    ViewState["TypeID"] = iUniversityID;
                    fn_BindRating();
                    fn_BindUniversityCourses(iUniversityID);
                    ltl_Title.Text = strTitle;

                    ltl_CoursesOffered.Text = strTitle + " Courses offered";

                    ltl_City.Text = strCity;
                    ltl_Desc.Text = objUniversityList[0].strDesc;
                    ltl_ContactDetails.Text = objUniversityList[0].strAddress;
                    ltl_Admissions.Text = objUniversityList[0].strAdmissions;
                    ltl_NotificationTitle.Text = strTitle + " Notifications";

                    hf_ContactDetails.Value = objUniversityList[0].strTitle + ", " + objUniversityList[0].strCity;

                    ltl_Details.Text = "<b>Established In : </b>" + objUniversityList[0].strEstablishedIn + "<br/><b>Affiliated To : </b>" + objUniversityList[0].strAffiliatedTo + "<br/><b>Website : </b>" + objUniversityList[0].strWebsite + "<br/><b>Address : </b>" + fn_StripHTMLTags(objUniversityList[0].strAddress);

                    img_Photo.Src = "https://www.eduvidya.com/admin/Upload/University/" + objUniversityList[0].strImage;
                    img_Photo.Alt = strTitle;

                    fn_BindRandomUniversity();
                    fn_BindUniversityNotifications(iUniversityID);

                    string strMetaTitle = strTitle + " " + strCity + ", Admissions 2021-22, Results, Exam Timetable, Date sheet";
                    string strMetaDesc = "Find about " + strTitle + " " + strCity + " Admissions 2021-22, results, exam timetable and date sheet. Get details on fee structure, ranking, admid card, application forms, reviews, hostel address and courses offered.";
                    string strMetaKeys = strTitle;

                    ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                    ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                    ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                    Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                    ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='" + VirtualPathUtility.ToAbsolute("~/University.aspx") + "'>Universities in India</a>" + strTitle;

                    HtmlControl dynamicid = (HtmlControl)Master.FindControl("dynamicid");
                    dynamicid.ID = "details-page";
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
            objRate.strType = "University";
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
            objRate.strType = "University";
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
            UniversityListClass objCourse = new UniversityListClass();
            objCourse.iID = iUniversityID;
            CoreWebList<UniversityListClass> objCourseList = objCourse.fn_GetRandomUniversityCourseListByUniversityID();
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
            UniversityListClass objUniversity = new UniversityListClass();
            CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_getRandomUniversityList();
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

    protected void fn_BindUniversityNotifications(int iUniversityID)
    {
        try
        {
            NoticClass objNotic = new NoticClass();
            objNotic.iUniversityID = iUniversityID;
            CoreWebList<NoticClass> objNoticList = objNotic.fn_getNotificationByUniversityID();
            if (objNoticList.Count > 0)
            {
                rpt_Notifications.DataSource = objNoticList;
                rpt_Notifications.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}
