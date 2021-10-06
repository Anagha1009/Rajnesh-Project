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
            if (RouteData.Values["College"] != null)
            {
                InstituteClass objInstitute = new InstituteClass();
                objInstitute.strTitle = RouteData.Values["College"].ToString().Replace("-", " ");
                CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByName();
                if (objInstituteList.Count > 0)
                {
                    int iInstituteID = objInstituteList[0].iID;
                    string strTitle = objInstituteList[0].strTitle + " Courses";

                    ltl_Title.Text = "<h3>" + objInstituteList[0].strTitle + " Courses offered</h3>";

                    fn_BindInstituteCourses(iInstituteID);

                    string strMetaTitle = strTitle + " offered, 2021, Fees";
                    string strMetaDesc = strTitle + " offered in 2021 with fees";
                    string strMetaKeys = strTitle + " offered";

                    string strCollegeLink = VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString());

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

                    ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                    ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                    ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                    Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                    ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='https://www.eduvidya.com/Colleges-in-india.aspx'>Colleges in India</a><a href='" + strCollegeLink + "'>" + objInstituteList[0].strTitle + "</a>Courses";
                }
            }
        }
    }

    protected void fn_BindInstituteCourses(int iInstituteID)
    {
        try
        {
            InstituteCourseClass objCourse = new InstituteCourseClass();
            objCourse.iInstituteID = iInstituteID;
            CoreWebList<InstituteCourseClass> objCourseList = objCourse.fn_getInstituteCourseByInstituteID();
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
