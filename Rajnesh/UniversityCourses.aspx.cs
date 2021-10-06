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
                UniversityListClass objUniversity = new UniversityListClass();
                objUniversity.strTitle = RouteData.Values["University"].ToString().Replace("-", " ");
                CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_getUniversityByName();
                if (objUniversityList.Count > 0)
                {
                    int iInstituteID = objUniversityList[0].iID;
                    string strTitle = objUniversityList[0].strTitle + " Courses";

                    ltl_Title.Text = "<h1>" + objUniversityList[0].strTitle + " Courses offered</h1>";

                    fn_BindUniversityCourses(iInstituteID);

                    string strMetaTitle = strTitle + " offered list, 2015-16, Syllabus, Fees, Results";
                    string strMetaDesc = strTitle + " offered list in 2015-16 with fees, syllabus and results. Also find courses after 12th, graduation, ug, pg courses in commerce, science and arts";
                    string strMetaKeys = strTitle + " offered";

                    string strUniversityLink = VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString());

                    hyp_UniversityLink.HRef = strUniversityLink;
                    hyp_UniversityLink.InnerText = "About " + objUniversityList[0].strTitle;

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
                    ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='https://www.eduvidya.com/University.aspx'>University India</a><a href='" + strUniversityLink + "'>" + objUniversityList[0].strTitle + "</a>Courses";
                }
            }
        }
    }

    protected void fn_BindUniversityCourses(int iUniversityID)
    {
        try
        {
            UniversityListClass objCourse = new UniversityListClass();
            objCourse.iID = iUniversityID;
            CoreWebList<UniversityListClass> objCourseList = objCourse.fn_GetUniversityCourseListByUniversityID();
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
