using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using yo_lib;

public partial class CollegeCourses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (RouteData.Values["College"] != null && RouteData.Values["Course"] != null)
            {
                InstituteClass objInstitute = new InstituteClass();
                objInstitute.strTitle = RouteData.Values["College"].ToString().Replace("-", " ");
                CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByName();
                if (objInstituteList.Count > 0)
                {
                    int iInstituteID = objInstituteList[0].iID;
                    int CityId = objInstituteList[0].iCityID;
                    string strInstitute = objInstituteList[0].strTitle + " Courses";

                    InstituteCourseClass objCourses = new InstituteCourseClass();
                    objCourses.iInstituteID = iInstituteID;
                    objCourses.strTitle = RouteData.Values["Course"].ToString().Replace("-", " ");
                    CoreWebList<InstituteCourseClass> objCoursesList = objCourses.fn_getInstituteCourseByCourse();
                    if (objCoursesList.Count > 0)
                    {
                        string strTitle = objCoursesList[0].strTitle + " Course in " + objInstituteList[0].strTitle + ", Syllabus, Fees, Eligibility";
                        string strMetaTitle = strTitle;
                        string strMetaDesc = "Get details on " + objCoursesList[0].strTitle + " course, Its Syllabus, Fees and Eligibility details from " + objInstituteList[0].strTitle;
                        string strMetaKeys = objCoursesList[0].strTitle;

                        ltl_Title.Text = "<h4>" + objCoursesList[0].strTitle + "</h4>";
                        ltl_Fees.Text = "<b>Fees : </b>" + objCoursesList[0].strFees;
                        ltl_Desc.Text = objCoursesList[0].strDesc;
                        ltl_Syllabus.Text = objCoursesList[0].strSyllabus;
                        ltl_Eligibility.Text = objCoursesList[0].strEligibility;

                        InstituteCourseClass objCourse = new InstituteCourseClass();
                        objCourse.iID = objCoursesList[0].iID;
                        objCourse.iCategoryID = objCoursesList[0].iCategoryID;
                        CoreWebList<InstituteCourseClass> objCourseList = objCourse.fn_getSimilarCourseByCityCategory(CityId);
                        if (objCourseList.Count > 0)
                        {
                            rpt_Courses.DataSource = objCourseList;
                            rpt_Courses.DataBind();
                        }

                        ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                        ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                        ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                        string strCollegeLink = VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString());
                        string strCourseLink = VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString() + "/Courses");

                        hyp_CollegeLink.HRef = strCollegeLink;
                        hyp_CollegeLink.InnerText = "About " + objInstituteList[0].strTitle;

                        if (objInstituteList[0].strDesc.Length > 210)
                        {
                            ltl_CollegeDetails.Text = objInstituteList[0].strDesc.Substring(0, 210) + "..";
                        }
                        else
                        {
                            ltl_CollegeDetails.Text = objInstituteList[0].strDesc;
                        }

                        Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                        ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='https://www.eduvidya.com/Colleges-in-india.aspx'>Colleges in India</a><a href='" + strCollegeLink + "'>" + objInstituteList[0].strTitle + "</a><a href='" + strCourseLink + "'>Courses</a>" + objCoursesList[0].strTitle;


                        HtmlControl dynamicid = (HtmlControl)Master.FindControl("dynamicid");
                        dynamicid.ID = "details-page";
                    }
                }
            }
        }
    }
}