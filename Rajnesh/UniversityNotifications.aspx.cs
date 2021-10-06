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
                    string strTitle = objUniversityList[0].strTitle + " Admission Notifications 2015-16, Exam timetable and Results ";

                    ltl_Title.Text = "<h4>" + strTitle + "</h4>";

                    string strMetaTitle = strTitle;
                    string strMetaDesc = strTitle;
                    string strMetaKeys = strTitle;

                    fn_BindUniversityNotifications(iInstituteID);

                    string strUniversityLink = VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString());

                    ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                    ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                    ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                    Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                    ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='https://www.eduvidya.com/University.aspx'>University India</a><a href='" + strUniversityLink + "'>" + objUniversityList[0].strTitle + "</a>Notifications";
                }
            }
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
