using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class UserControls_EducationLeads : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strTitle = "";
            string strType = "";
            int TypeId = 0;

            if (this.Page.RouteData.Values["College"] != null)
            {
                InstituteClass objInstitute = new InstituteClass();
                objInstitute.strTitle = this.Page.RouteData.Values["College"].ToString().Replace("-", " ").Replace("_", ".");
                CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByName();
                if (objInstituteList.Count > 0)
                {
                    strType = "Institute";
                    TypeId = objInstituteList[0].iID;
                    strTitle = objInstituteList[0].strTitle;
                }
            }

            else if (this.Page.RouteData.Values["School"] != null)
            {
                SchoolClass objSchool = new SchoolClass();
                objSchool.strTitle = this.Page.RouteData.Values["School"].ToString().Replace("-", " ").Replace("_", ".");
                CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolByName();
                if (objSchoolList.Count > 0)
                {
                    strType = "Schools";
                    TypeId = objSchoolList[0].iID;
                    strTitle = objSchoolList[0].strTitle;
                }
            }

            else if (this.Page.RouteData.Values["University"] != null && this.Page.RouteData.Values["UniversityName"] != null)
            {
                string strDistance = this.Page.RouteData.Values["UniversityName"].ToString().Replace("-", " ");

                DistanceLearningClass objDistance = new DistanceLearningClass();
                objDistance.strName = strDistance;
                CoreWebList<DistanceLearningClass> objDistanceList = objDistance.fn_GetDistanceLearningListByName();
                if (objDistanceList.Count > 0)
                {
                    if (objDistanceList[0].strType == "University")
                    {
                        strType = "DistanceUniversity";
                    }

                    else if (objDistanceList[0].strType == "Institute")
                    {
                        strType = "DistanceCollege";
                    }

                    TypeId = objDistanceList[0].iID;
                    strTitle = objDistanceList[0].strName;
                }
            }

            else if (this.Page.RouteData.Values["University"] != null)
            {
                UniversityListClass objCC = new UniversityListClass();
                objCC.strTitle = this.Page.RouteData.Values["University"].ToString().Replace("-", " ").Replace("_", ".");
                CoreWebList<UniversityListClass> objList = objCC.fn_getUniversityByTitle();
                if (objList.Count > 0)
                {
                    strType = "University";
                    TypeId = objList[0].iID;
                    strTitle = objList[0].strTitle;
                }
            }
            

            else if (this.Page.RouteData.Values["College"] != null && this.Page.RouteData.Values["Course"] != null)
            {
                InstituteClass objInstitute = new InstituteClass();
                objInstitute.strTitle = this.Page.RouteData.Values["College"].ToString().Replace("-", " ");
                CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByName();
                if (objInstituteList.Count > 0)
                {
                    int iInstituteID = objInstituteList[0].iID;
                    int CityId = objInstituteList[0].iCityID;
                    string strInstitute = objInstituteList[0].strTitle + " Courses";

                    InstituteCourseClass objCourses = new InstituteCourseClass();
                    objCourses.iInstituteID = iInstituteID;
                    objCourses.strTitle = this.Page.RouteData.Values["Course"].ToString().Replace("-", " ");
                    CoreWebList<InstituteCourseClass> objCoursesList = objCourses.fn_getInstituteCourseByCourse();
                    if (objCoursesList.Count > 0)
                    {
                        strType = "InstitueCourses";
                        TypeId = objInstituteList[0].iID;
                        strTitle = objCoursesList[0].strTitle;
                    }
                }
            }

            else if (this.Page.RouteData.Values["Course"] != null)
            {
                UniversityListClass objUniversity = new UniversityListClass();
                objUniversity.strTitle = this.Page.RouteData.Values["Course"].ToString().Replace("-", " ");
                CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_GetUniversityCoursebyTitle();
                if (objUniversityList.Count > 0)
                {
                    strType = "UniversityCourses";
                    TypeId = objUniversityList[0].iCourseID;
                    strTitle = objUniversityList[0].strCourseName;
                }
            }

            else if (this.Page.RouteData.Values["CourseID"] != null)
            {
                int iCourseID = int.Parse(this.Page.RouteData.Values["CourseID"].ToString());

                DLCoursesClass objCourse = new DLCoursesClass();
                objCourse.iID = iCourseID;
                CoreWebList<DLCoursesClass> objCourseList = objCourse.fn_getDL_Course_By_ID();
                if (objCourseList.Count > 0)
                {
                    strType = "DistanceUniversityCourses";
                    TypeId = objCourseList[0].iID;
                    strTitle = objCourseList[0].strName;
                }
            }

            else if (this.Page.RouteData.Values["Exam"] != null)
            {
                EntranceExamClass objEntrance = new EntranceExamClass();
                objEntrance.strTitle = this.Page.RouteData.Values["Exam"].ToString().Replace("-", " ");
                CoreWebList<EntranceExamClass> objEntranceList = objEntrance.fn_getEntranceExamByName();
                if (objEntranceList.Count > 0)
                {
                    strType = "Exam";
                    TypeId = objEntranceList[0].iID;
                    strTitle = objEntranceList[0].strTitle;
                }
            }
            else
            {
                strType = this.Page.Request.Url.ToString();
                TypeId = 0;
                strTitle = " Getting Education Help like Admissions, Career etc.";
            }

            ltl_Title.Text = "<b>Are you Interested in " + strTitle + "</b>.";

            Session["Type"] = strType;
            Session["TypeId"] = TypeId;
            
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}