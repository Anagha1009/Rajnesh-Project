using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;
using System.Web.UI.HtmlControls;

public partial class College_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (RouteData.Values["Exam"] != null)
            {
                EntranceExamClass objEntrance = new EntranceExamClass();
                objEntrance.strTitle = RouteData.Values["Exam"].ToString().Replace("-", " ");
                CoreWebList<EntranceExamClass> objEntranceList = objEntrance.fn_getEntranceExamByName();
                if (objEntranceList.Count > 0)
                {
                    int iEntranceID = objEntranceList[0].iID;
                    string strTitle = objEntranceList[0].strTitle + " Colleges";

                    ltl_Title.Text = strTitle;

                    fn_BindColleges(iEntranceID);

                    string strMetaTitle = objEntranceList[0].strTitle + " Colleges Accepting " + objEntranceList[0].strTitle + " Score, Institutes under " + objEntranceList[0].strTitle;
                    string strMetaDesc = "Get details on " + objEntranceList[0].strTitle + " Colleges Accepting " + objEntranceList[0].strTitle + " Score, Institutes under " + objEntranceList[0].strTitle; ;
                    string strMetaKeys = strTitle;

                    ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                    ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                    ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                    Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                    ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='" + VirtualPathUtility.ToAbsolute("~/Entrance-Exams.aspx") + "'>Entrance Exams</a><a href='" + VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString()) + "'>" + objEntranceList[0].strTitle + "</a>Colleges";
                }
            }
        }
    }

    protected void fn_BindColleges(int iEntranceID)
    {
        try
        {
            InstituteClass objInstitute = new InstituteClass();
            objInstitute.iEntranceExamID = iEntranceID;
            CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByEntranceExamID();
            if (objInstituteList.Count > 0)
            {
                CPager.DataSource = objInstituteList;
                CPager.BindToControl = rpt_Institutes;
                CPager.SecondPageHolderId = PagerDiv.UniqueID;
                CPager.DataBind();
                rpt_Institutes.DataSource = CPager.DataSourcePaged;
                rpt_Institutes.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}