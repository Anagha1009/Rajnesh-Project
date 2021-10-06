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
            if (RouteData.Values["University"] != null)
            {
                DistanceLearningClass objUniversity = new DistanceLearningClass();
                objUniversity.strName = RouteData.Values["University"].ToString().Replace("-", " ");
                CoreWebList<DistanceLearningClass> objUniversityList = objUniversity.fn_GetDistanceLearningListByName();
                if (objUniversityList.Count > 0)
                {
                    int iInstituteID = objUniversityList[0].iID;
                    string strTitle = objUniversityList[0].strName + " Courses";

                    ltl_Title.Text = "<h3>" + objUniversityList[0].strName + " Courses offered</h3>";

                    fn_BindUniversityCourses(iInstituteID);

                    string strMetaTitle = strTitle + " offered list, 2015-16, syllabus, fees, results";
                    string strMetaDesc = strTitle + " offered in 2015-16 with fees, syllabus and results for mba, mca, phd, bca, bba, b,ed, law";
                    string strMetaKeys = strTitle + " offered";

                    string strUniversityLink = VirtualPathUtility.ToAbsolute("~/Distance-University/" + RouteData.Values["University"].ToString());

                    hyp_UniversityLink.HRef = strUniversityLink;
                    hyp_UniversityLink.InnerText = "About " + objUniversityList[0].strName;

                    if (objUniversityList[0].strDesc.Length > 210)
                    {
                        ltl_UniversityDetails.Text = objUniversityList[0].strDesc.Substring(0, 210) + "..";
                    }
                    else
                    {
                        ltl_UniversityDetails.Text = objUniversityList[0].strDesc;
                    }

                    ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                    ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                    ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                    Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                    ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='https://www.eduvidya.com/Distance-University.aspx'>Distance University India</a><a href='" + strUniversityLink + "'>" + objUniversityList[0].strName + "</a>Courses";
                }
            }
        }
    }

    protected void fn_BindUniversityCourses(int iUniversityID)
    {
        try
        {
            DLCoursesClass objCourse = new DLCoursesClass();
            objCourse.iDistanceID = iUniversityID;
            CoreWebList<DLCoursesClass> objCourseList = objCourse.fn_getDLCourseByDistanceID();
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
}
