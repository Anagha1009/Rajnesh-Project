using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Collections;


public partial class SACourseDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                if (RouteData.Values["Course"] != null)
                {
                    CourseClass objCourse = new CourseClass();
                    objCourse.strTitle = RouteData.Values["Course"].ToString().Replace("-", " ");
                    CoreWebList<CourseClass> objCourseList = objCourse.fn_getCourseByName();
                    if (objCourseList.Count > 0)
                    {
                        ltl_Title.Text = "<h1>" + objCourseList[0].strTitle + "</h1>";

                        ltl_Desc.Text = objCourseList[0].strDetails;

                        ltl_Details.Text = "<h2>Fees</h2>" + objCourseList[0].strFees + "<br/>";
                        ltl_Details.Text += "<h2>Mode of Study</h2>" + objCourseList[0].strFees + "<br/>";
                        ltl_Details.Text += "<h2>Mode of Study</h2>" + objCourseList[0].strModeofStudy + "<br/>";
                        ltl_Details.Text += "<h2>Level of Study</h2>" + objCourseList[0].strLevelofStudy + "<br/>";
                        ltl_Details.Text += "<h2>Eligibility</h2>" + objCourseList[0].strEligibility + "<br/>";
                        ltl_Details.Text += "<h2>Admission Criteria</h2>" + objCourseList[0].strAdmissionCriteria + "<br/>";

                        string strMetaTitle = objCourseList[0].strTitle;
                        string strMetaDesc = objCourseList[0].strTitle;
                        string strMetaKeys = objCourseList[0].strTitle;

                        ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                        ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                        ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                        Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                        ltl_bredcrumbs.Text = "<a href='" + VirtualPathUtility.ToAbsolute("~/") + "'>Home</a>&nbsp;>&nbsp;<a href='" + VirtualPathUtility.ToAbsolute("~/Studyabroad.aspx") + "'>Studyabroad</a>&nbsp;>&nbsp;<a href='" + VirtualPathUtility.ToAbsolute("~/Studyabroad/" + RouteData.Values["Country"].ToString()) + "'>" + RouteData.Values["Country"].ToString().Replace("-", " ") + "</a>&nbsp;>&nbsp;<a href='" + VirtualPathUtility.ToAbsolute("~/Studyabroad/" + RouteData.Values["Country"].ToString() + "/University/" + RouteData.Values["University"].ToString()) + "'>" + RouteData.Values["University"].ToString().Replace("-", " ") + "</a>&nbsp;>&nbsp;" + objCourseList[0].strTitle;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}
