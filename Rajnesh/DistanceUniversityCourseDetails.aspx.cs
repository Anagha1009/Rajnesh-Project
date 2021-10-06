using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class CollegeCourses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (RouteData.Values["University"] != null && RouteData.Values["Course"] != null)
            {
                DistanceLearningClass objUniversity = new DistanceLearningClass();
                objUniversity.strName = RouteData.Values["University"].ToString().Replace("-", " ").Replace("_", ".");
                CoreWebList<DistanceLearningClass> objUniversityList = objUniversity.fn_GetDistanceLearningListByName();
                if (objUniversityList.Count > 0)
                {
                    int iUniversityID = objUniversityList[0].iID;
                    string strUniversity = objUniversityList[0].strName + " Courses";

                    DLCoursesClass objCourses = new DLCoursesClass();
                    objCourses.iID = iUniversityID;
                    objCourses.strName = RouteData.Values["Course"].ToString().Replace("-", " ").Replace("_", ".");
                    CoreWebList<DLCoursesClass> objCoursesList = objCourses.fn_getCourseByName();
                    if (objCoursesList.Count > 0)
                    {
                        string strTitle = objCoursesList[0].strName + " Course syllabus, fees, exam timetable, results, admission 2021-22";
                        string strMetaTitle = strTitle;
                        string strMetaDesc = "Get details on " + objCoursesList[0].strName + " course admission 2021-22, syllabus, exam timetable, fee structure, results and hall ticket.";
                        string strMetaKeys = objCoursesList[0].strName;

                        ltl_Title.Text = "<h3>" + objCoursesList[0].strName + "</h3>";
                        ltl_Desc.Text = objCoursesList[0].strDescription;

                        ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                        ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                        ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                        string strUniversityLink = VirtualPathUtility.ToAbsolute("~/Distance-University/" + RouteData.Values["University"].ToString());
                        string strCourseLink = VirtualPathUtility.ToAbsolute("~/Distance-University/" + RouteData.Values["University"].ToString() + "/Courses");

                        Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                        ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='https://www.eduvidya.com/Distance-University.aspx'>Distance Universities in India</a><a href='" + strUniversityLink + "'>" + objUniversityList[0].strName + "</a><a href='" + strCourseLink + "'>Courses</a>" + objCoursesList[0].strName;

                    }
                }
            }
        }
    }
}
