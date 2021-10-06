using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;
using System.Web.UI.HtmlControls;

public partial class College_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (RouteData.Values["Exam"] != null)
            {
                if (!IsPostBack)
                {
                    fn_BindRating();
                }

                EntranceExamClass objEntrance = new EntranceExamClass();
                objEntrance.strTitle = RouteData.Values["Exam"].ToString().Replace("-", " ");
                CoreWebList<EntranceExamClass> objEntranceList = objEntrance.fn_getEntranceExamByName();
                if (objEntranceList.Count > 0)
                {
                    int iEntranceID = objEntranceList[0].iID;
                    string strTitle = objEntranceList[0].strTitle;

                    Literal1.Text = strTitle;
                    ltl_Title.Text = "<h1>" + strTitle + "</h1>";

                    ltl_RegistraionTitle.Text = strTitle + " Registration / Application Form";
                    ltl_ExamTitle.Text = strTitle + " Exam Dates";
                    ltl_SyllabusTitle.Text = strTitle + " Syllabus";
                    ltl_PreparationTitle.Text = strTitle + " Preparation";
                    ltl_NotificationTitle.Text = strTitle + " Notification";

                    ltl_Desc.Text = objEntranceList[0].strDesc;
                    ltl_Admissions.Text = objEntranceList[0].strAdmissions;
                    ltl_ExamDates.Text = objEntranceList[0].strDates;
                    ltl_Syllabus.Text = objEntranceList[0].strSyllabus;
                    ltl_PaperPattern.Text = objEntranceList[0].strPaperPatterns;
                    ltl_Preparation.Text = objEntranceList[0].strPreparation;
                    ltl_Notification.Text = objEntranceList[0].strNotifications;

                    string strMetaTitle = strTitle + " 2021 Exam dates, Syllabus, Application Form, Pattern, Notification";
                    string strMetaDesc = "Get details on " + strTitle + " 2021 like Exam Date, Syllabus, Application Form, Notification, Admit card and Preparation.";
                    string strMetaKeys = strTitle + " Exam";

                    ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                    ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                    ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                    Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                    ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='" + VirtualPathUtility.ToAbsolute("~/Entrance-Exams.aspx") + "'>Entrance Exams</a>" + strTitle;

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
