using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using yo_lib;
using System.Data;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

public partial class Education_Help : System.Web.UI.Page
{
    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
            {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }

            return (SortDirection)ViewState["sortDirection"];
        }
        set
        {
            ViewState["sortDirection"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                if (Session["EduLeads_admin"] != null)
                {
                    mainContent.Visible = true;
                    adminBox.Visible = false;
                    btn_LogOut.Text = "Log Out";
                }
                else
                {
                    mainContent.Visible = false;
                    adminBox.Visible = true;
                    btn_LogOut.Text = "Log In";

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login", "fn_displayLogin();", true);
                }
            }

            if (!IsPostBack)
            {
                info1.Visible = false;
                error1.Visible = false;
                tr_details.Visible = false;

                fn_BindEducationInterestDDL();
                fn_BindCityDDL();

                fn_BindRecords();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindRecords()
    {
        try
        {
            EduLeadClass objEduLeads = new EduLeadClass();
            CoreWebList<EduLeadClass>objEduLeadList = objEduLeads.fn_getEduLeadList();
            if (objEduLeadList.Count > 0)
            {
                ViewState["dtRecords"] = (DataTable)objEduLeadList;
                grd_Records.DataSource = objEduLeadList;
            }
            else
            {
                grd_Records.DataSource = null;
            }
            grd_Records.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void grd_Records_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Records.PageIndex = e.NewPageIndex;
            fn_BindRecords();
            
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error1.Visible = true;
        }
    }

    protected void grd_Records_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            EduLeadClass objEduLead = new EduLeadClass();
            objEduLead.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());
            string strResponse = objEduLead.fn_deleteEduLead();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info1.FindControl("mssg")).Text = strResponse;
                info1.Visible = true;
            }
            else
            {
                ((Label)error1.FindControl("mssg")).Text = strResponse;
                error1.Visible = true;
            }

            fn_BindRecords();
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void grd_Records_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (ViewState["dtRecords"] != null)
            {
                DataTable dtRecords = (DataTable)ViewState["dtRecords"];
                DataView dv = new DataView(dtRecords);

                if (GridViewSortDirection == SortDirection.Ascending)
                {
                    GridViewSortDirection = SortDirection.Descending;
                    dv.Sort = e.SortExpression + " DESC";
                }
                else
                {
                    GridViewSortDirection = SortDirection.Ascending;
                    dv.Sort = e.SortExpression + " ASC";
                }

                grd_Records.DataSource = dv;
                grd_Records.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error1.Visible = true;
        }
    }

    protected void grd_Records_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Records.SelectedIndex < 0)
            {
            }
            else
            {
                int iRecordID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                fn_BindDetails(iRecordID);
            }
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error1.Visible = true;
        }
    }

    protected void fn_BindDetails(int iLeadId)
    {
        try
        {
            tr_details.Visible = true;

            #region "Scroll to Details"
            StringBuilder sb = new StringBuilder();
            sb.Append("$('html,body').animate({ scrollTop: $('#ScrollHere').offset().top }, 2000);");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Scroll", sb.ToString(), true);
            #endregion

            EduLeadClass objEduLeads = new EduLeadClass();
            objEduLeads.iID = iLeadId;
            CoreWebList<EduLeadClass> objEduLeadList = objEduLeads.fn_getEduLeadByID();
            if (objEduLeadList.Count > 0)
            {
                ltl_FirstName.Text = objEduLeadList[0].strFirstName;
                ltl_LastName.Text = objEduLeadList[0].strLastName;
                ltl_Email.Text = objEduLeadList[0].strEmail;
                ltl_DoB.Text = objEduLeadList[0].dtDoB.ToLongDateString();
                ltl_Qualification.Text = objEduLeadList[0].strCurrentQualification;
                ltl_EducationInterest.Text = objEduLeadList[0].strEducationInterest;
                ltl_MobileNo.Text = objEduLeadList[0].strMobileNo;
                ltl_City.Text = objEduLeadList[0].strCity;
                ltl_Type.Text = objEduLeadList[0].strType;
                ltl_InstitutionName.Text = objEduLeadList[0].strInstitutionName;

                string strTick = "";

                if (objEduLeadList[0].bEducationLoan == true)
                {
                    strTick = "<img src='" + VirtualPathUtility.ToAbsolute("~/admin/images/Tick.gif") + "' />";
                }
                else
                {
                    strTick = "<img src='" + VirtualPathUtility.ToAbsolute("~/admin/images/cross.gif") + "' />";
                }

                ltl_EducationLoan.Text = strTick;
                
                ltl_Comments.Text = objEduLeadList[0].strComment;
                ltl_IpAddress.Text = objEduLeadList[0].strIpAddrs;
                ltl_Date.Text = objEduLeadList[0].dtRegDate.ToLongDateString();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string strType = ddl_Type.SelectedValue;
            switch (strType)
            {
                case "Institute":
                    {
                        fn_BindInstitutes();
                        break;
                    }

                case "Schools":
                    {
                        fn_BindSchools();
                        break;
                    }

                case "University":
                    {
                        fn_BindUniversity();
                        break;
                    }

                case "DistanceUniversity":
                    {
                        fn_BindDistanceUniversity("University");
                        break;
                    }

                case "DistanceCollege":
                    {
                        fn_BindDistanceUniversity("Institute");
                        break;
                    }

                case "InstitueCourses":
                    {
                        fn_BindInstituteCourses();
                        break;
                    }

                case "UniversityCourses":
                    {
                        fn_BindUniversityCourses();
                        break;
                    }

                case "DistanceUniversityCourses":
                    {
                        fn_BindDistanceUniversityCourses();
                        break;
                    }

                case "Exam":
                    {
                        fn_BindExams();
                        break;
                    }

                case "Links":
                    {
                        fn_BindLinks();
                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindEducationInterestDDL()
    {
        try
        {
            EducationInterestClass objEducationInterest = new EducationInterestClass();
            ddl_EducationInterest.DataSource = objEducationInterest.fn_getEducationInterestList();
            ddl_EducationInterest.DataTextField = "strTitle";
            ddl_EducationInterest.DataValueField = "iID";
            ddl_EducationInterest.DataBind();
            ddl_EducationInterest.Items.Insert(0, new ListItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindCityDDL()
    {
        try
        {
            CityClass objCity = new CityClass();
            ddl_City.DataSource = objCity.fn_getCityList();
            ddl_City.DataTextField = "strTitle";
            ddl_City.DataValueField = "iID";
            ddl_City.DataBind();
            ddl_City.Items.Insert(0, new ListItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindInstitutes()
    {
        try
        {
            InstituteClass objInstitutes = new InstituteClass();
            ddl_Institution.DataSource = objInstitutes.fn_getInstituteList();
            ddl_Institution.DataTextField = "strTitle";
            ddl_Institution.DataValueField = "iID";
            ddl_Institution.DataBind();
            ddl_Institution.Items.Insert(0, new ListItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindSchools()
    {
        try
        {
            SchoolClass objSchools = new SchoolClass();
            ddl_Institution.DataSource = objSchools.fn_getSchoolList();
            ddl_Institution.DataTextField = "strTitle";
            ddl_Institution.DataValueField = "iID";
            ddl_Institution.DataBind();
            ddl_Institution.Items.Insert(0, new ListItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindUniversity()
    {
        try
        {
            UniversityListClass objUniversity = new UniversityListClass();
            ddl_Institution.DataSource = objUniversity.fn_getUniversityList();
            ddl_Institution.DataTextField = "strTitle";
            ddl_Institution.DataValueField = "iID";
            ddl_Institution.DataBind();
            ddl_Institution.Items.Insert(0, new ListItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindDistanceUniversity(string strType)
    {
        try
        {
            DistanceLearningClass objDistanceUniversity = new DistanceLearningClass();
            objDistanceUniversity.strType = strType;
            ddl_Institution.DataSource = objDistanceUniversity.fn_GetDistanceLearningListByType();
            ddl_Institution.DataTextField = "strName";
            ddl_Institution.DataValueField = "iID";
            ddl_Institution.DataBind();
            ddl_Institution.Items.Insert(0, new ListItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindInstituteCourses()
    {
        try
        {
            InstituteCourseClass objCourses = new InstituteCourseClass();
            ddl_Institution.DataSource = objCourses.fn_get_Institute_CourseList();
            ddl_Institution.DataTextField = "strTitle";
            ddl_Institution.DataValueField = "iID";
            ddl_Institution.DataBind();
            ddl_Institution.Items.Insert(0, new ListItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindUniversityCourses()
    {
        try
        {
            UniversityListClass objCourses = new UniversityListClass();
            ddl_Institution.DataSource = objCourses.fn_GetUniversityCourseList();
            ddl_Institution.DataTextField = "strCourseName";
            ddl_Institution.DataValueField = "iID";
            ddl_Institution.DataBind();
            ddl_Institution.Items.Insert(0, new ListItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindDistanceUniversityCourses()
    {
        try
        {
            DLCoursesClass objCourses = new DLCoursesClass();
            ddl_Institution.DataSource = objCourses.fn_getCoursesList();
            ddl_Institution.DataTextField = "strName";
            ddl_Institution.DataValueField = "iID";
            ddl_Institution.DataBind();
            ddl_Institution.Items.Insert(0, new ListItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindExams()
    {
        try
        {
            EntranceExamClass objExam = new EntranceExamClass();
            ddl_Institution.DataSource = objExam.fn_getEntranceExamList();
            ddl_Institution.DataTextField = "strTitle";
            ddl_Institution.DataValueField = "iID";
            ddl_Institution.DataBind();
            ddl_Institution.Items.Insert(0, new ListItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindLinks()
    {
        try
        {
            EduLeadClass objLeads = new EduLeadClass();
            ddl_Institution.DataSource = objLeads.fn_getEduLeadLinks();
            ddl_Institution.DataTextField = "strType";
            ddl_Institution.DataValueField = "strType";
            ddl_Institution.DataBind();
            ddl_Institution.Items.Insert(0, new ListItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string strType = "";
            
            if (ddl_Type.SelectedValue == "Links")
            {
                if (ddl_Institution.SelectedValue != "-1")
                {
                    strType = ddl_Institution.SelectedValue;
                }
            }

            else if (ddl_Type.SelectedValue != "0")
            {
                strType = ddl_Type.SelectedValue;
            }

            EduLeadClass objEduLeads = new EduLeadClass();
            objEduLeads.strType = strType;
            objEduLeads.iTypeId = int.Parse(ddl_Institution.SelectedValue);
            objEduLeads.iEducationInterestID = int.Parse(ddl_EducationInterest.SelectedValue);
            objEduLeads.iCityID = int.Parse(ddl_City.SelectedValue);
            objEduLeads.strFromDate = txtFromDate.Text;
            objEduLeads.strToDate = txtToDate.Text;
            objEduLeads.strKeys = txtKeys.Text;

            CoreWebList<EduLeadClass> objEduLeadList = objEduLeads.fn_SearchEducationLeads();
            if (objEduLeadList.Count > 0)
            {
                ViewState["dtRecords"] = (DataTable)objEduLeadList;
                grd_Records.DataSource = objEduLeadList;
            }
            else
            {
                grd_Records.DataSource = null;
            }
            grd_Records.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtRecords =  (DataTable)ViewState["dtRecords"];

            dtRecords.Columns["iID"].ColumnName = "Lead ID";

            dtRecords.Columns["strType"].ColumnName = "Lead Type";
            dtRecords.Columns["strInstitutionName"].ColumnName = "Institution Name";

            dtRecords.Columns["strFullName"].ColumnName = "Name";
            dtRecords.Columns["strEmail"].ColumnName = "Email";
            dtRecords.Columns["dtDoB"].ColumnName = "Date of Birth";
            dtRecords.Columns["strMobileNo"].ColumnName = "Mobile No";
            dtRecords.Columns["strCity"].ColumnName = "City";

            dtRecords.Columns["strCurrentQualification"].ColumnName = "Current Qualification";
            dtRecords.Columns["strEducationInterest"].ColumnName = "Education Interest";
            
            dtRecords.Columns["strComment"].ColumnName = "Comments";
            dtRecords.Columns["bEducationLoan"].ColumnName = "Education Loan";

            dtRecords.Columns["strIpAddrs"].ColumnName = "Ip Address";
            dtRecords.Columns["dtRegDate"].ColumnName = "Date";

            dtRecords.Columns.Remove("iCurrentQualificationID");
            dtRecords.Columns.Remove("iEducationInterestID");
            dtRecords.Columns.Remove("iTypeId");
            dtRecords.Columns.Remove("iCityID");
            dtRecords.Columns.Remove("strFirstName");
            dtRecords.Columns.Remove("strLastName");

            dtRecords.Columns.Remove("strFromDate");
            dtRecords.Columns.Remove("strToDate");
            dtRecords.Columns.Remove("strKeys");

            StringBuilder sb = new StringBuilder();

            foreach (DataColumn col in dtRecords.Columns)
            {
                sb.Append(col.ColumnName + ',');
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append(Environment.NewLine);

            foreach (DataRow row in dtRecords.Rows)
            {
                row["Comments"] = fn_StripHTMLTags(row["Comments"].ToString());
                row["Institution Name"] = fn_StripHTMLTags(row["Institution Name"].ToString());

                for (int i = 0; i < dtRecords.Columns.Count; i++)
                {
                    sb.Append(row[i].ToString() + ",");
                }

                sb.Append(Environment.NewLine);
            }

            cls_common objCFC = new cls_common();
            string strRanFileName = "EducationLeads_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year;
            File.WriteAllText(Server.MapPath("~/files/Reports/" + strRanFileName + ".csv"), sb.ToString());
            Response.Redirect(VirtualPathUtility.ToAbsolute("~/files/Reports/" + strRanFileName + ".csv"));
            
            up_Progress.Dispose();
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    public static string fn_StripHTMLTags(string source)
    {
        return Regex.Replace(source, "<.*?>", string.Empty).Replace(",", "");
    }

    protected void btn_Login_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtUser.Text == System.Configuration.ConfigurationManager.AppSettings["EduLeads_user"].ToString() && txtPassword.Text == System.Configuration.ConfigurationManager.AppSettings["EduLeads_Password"].ToString())
            {
                Session["EduLeads_admin"] = true;
                mainContent.Visible = true;
                adminBox.Visible = false;

                btn_LogOut.Text = "Log Out";
            }
            else
            {
                ltl_Info.Text = "Login Incorrect, please enter valid login information!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login", "fn_displayLogin();", true);
            }
        }
        catch (Exception ex)
        {
            ltl_Info.Text = "ERROR : " + ex.Message + ex.StackTrace;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login", "fn_displayLogin();", true);
        }
    }

    protected void btn_LogOut_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["EduLeads_admin"] != null)
            {
                Session.Clear();
                Session.Abandon();

                mainContent.Visible = false;
                adminBox.Visible = true;
                btn_LogOut.Text = "Log In";
            }
            else
            {
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/EducationLeads/"));
            }
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }
}