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
                UniversityListClass objUniversity = new UniversityListClass();
                objUniversity.strTitle = RouteData.Values["University"].ToString().Replace("-", " ").Replace("_", ".");
                CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_getUniversityByName();
                if (objUniversityList.Count > 0)
                {
                    int iUniversityID = objUniversityList[0].iID;
                    string strUniversity = objUniversityList[0].strTitle + " Courses";

                    UniversityListClass objCourses = new UniversityListClass();
                    objCourses.iID = iUniversityID;
                    objCourses.strCourseName = RouteData.Values["Course"].ToString().Replace("-", " ").Replace("_", ".");
                    CoreWebList<UniversityListClass> objCoursesList = objCourses.fn_getUniversityCourseByName();
                    if (objCoursesList.Count > 0)
                    {
                        string strTitle = objCoursesList[0].strCourseName + " Admission 2021-22, Exam timetable, Syllabus, Fees, Results";
                        string strMetaTitle = strTitle;
                        string strMetaDesc = "Get details on " + objCoursesList[0].strCourseName + " admission 2021-22, entrance exam, its fees, syllabus, timetable and results";
                        string strMetaKeys = objCoursesList[0].strCourseName;

                        ltl_Title.Text = "<h1>" + objCoursesList[0].strCourseName + "</h1>";
                        ltl_Desc.Text = objCoursesList[0].strCourseDetails;

                        ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                        ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                        ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                        string strUniversityLink = VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString());
                        string strCourseLink = VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString() + "/Courses");

                        Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                        ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='https://www.eduvidya.com/University.aspx'>Universities in India</a><a href='" + strUniversityLink + "'>" + objUniversityList[0].strTitle + "</a><a href='" + strCourseLink + "'>Courses</a>" + objCoursesList[0].strTitle;

                    }
                }
            }
        }
    }
}
