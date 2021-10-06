using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class CollegeStudyCenters : System.Web.UI.Page
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
                    string strTitle = objUniversityList[0].strName + " Admission Notifications 2017-18, Exam Time Table, Results";

                    NotificationClass objNotifications = new NotificationClass();
                    objNotifications.iUniversityID = iInstituteID;
                    CoreWebList<NotificationClass> objNotificationsList = objNotifications.fn_getNotificationByUniversityID();
                    if (objNotificationsList.Count > 0)
                    {
                        rpt_Notifications.DataSource = objNotificationsList;
                        rpt_Notifications.DataBind();
                    }

                    ltl_Title.Text = "<h4>" + strTitle + "</h4>";

                    string strMetaTitle = strTitle;
                    string strMetaDesc = strTitle;
                    string strMetaKeys = strTitle;

                    string strUniversityLink = VirtualPathUtility.ToAbsolute("~/Distance-University/" + RouteData.Values["University"].ToString());

                    ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                    ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                    ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                    Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                    ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='https://www.eduvidya.com/Distance-University.aspx'>Distance University India</a><a href='" + strUniversityLink + "'>" + objUniversityList[0].strName + "</a>Notifications";
                }
            }
        }
    }
}
