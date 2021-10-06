using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.IO;
using System.Text;

public partial class admin_Course : System.Web.UI.Page
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

    int UniversityID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;

            if (Request.QueryString["UniversityID"] != null)
            {
                UniversityID = int.Parse(Request.QueryString["UniversityID"].ToString());
            }
            else
            {
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/admin/Country.aspx"), true);
            }

            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;Courses";

            if (!IsPostBack)
            {
                fn_BindRecords();

                if (grd_Records.SelectedIndex < 0)
                {
                    dv_Records.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void fn_BindRecords()
    {
        try
        {
            CourseClass objCourse = new CourseClass();
            objCourse.iUniversityID = UniversityID;
            CoreWebList<CourseClass> objCourseList = objCourse.fn_getCourseByUniversityID();
            if (objCourseList.Count > 0)
            {
                ViewState["dtRecords"] = (DataTable)objCourseList;
                grd_Records.DataSource = objCourseList;
            }
            else
            {
                grd_Records.DataSource = null;
            }
            grd_Records.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void fn_BindDetails(int iRecordID)
    {
        try
        {
            CourseClass objCourse = new CourseClass();
            objCourse.iID = iRecordID;
            CoreWebList<CourseClass> objCourseList = objCourse.fn_getCourseByID();
            if (objCourseList.Count > 0)
            {
                dv_Records.DataSource = objCourseList;
                dv_Records.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Records_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (ViewState["dtRecords"] != null)
            {
                DataTable dtRecords = (DataTable)ViewState["dtRecords"];
                grd_Records.PageIndex = e.NewPageIndex;
                grd_Records.DataSource = dtRecords;
                grd_Records.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Records_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            CourseClass objCourse = new CourseClass();
            objCourse.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objCourse.fn_deleteCourse();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info.FindControl("mssg")).Text = strResponse;
                info.Visible = true;
            }
            else
            {
                ((Label)error.FindControl("mssg")).Text = strResponse;
                error.Visible = true;
            }

            fn_BindRecords();
            dv_Records.ChangeMode(DetailsViewMode.Insert);

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Records_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Records.SelectedIndex < 0)
            {
                dv_Records.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Records.ChangeMode(DetailsViewMode.Edit);
                int iRecordID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                fn_BindDetails(iRecordID);

                #region "Scroll to Details"
                StringBuilder sb = new StringBuilder();
                sb.Append("$('html,body').animate({ scrollTop: $('#ScrollHere').offset().top }, 2000);");
                ClientScript.RegisterStartupScript(this.GetType(), "Scroll", sb.ToString(), true);
                #endregion
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
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
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Records_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            DropDownList ddlModeofStudy = (DropDownList)dv_Records.FindControl("ddlModeofStudy");
            DropDownList ddlLevelofStudy = (DropDownList)dv_Records.FindControl("ddlLevelofStudy");
            TextBox txtTitle = (TextBox)dv_Records.FindControl("txtTitle");
            TextBox txtFees = (TextBox)dv_Records.FindControl("txtFees");
            TextBox txtDetails = (TextBox)dv_Records.FindControl("txtDetails");
            TextBox txtEligibility = (TextBox)dv_Records.FindControl("txtEligibility");
            TextBox txtAdmissionCriteria = (TextBox)dv_Records.FindControl("txtAdmissionCriteria");

            CourseClass objCourse = new CourseClass();
            objCourse.iUniversityID = UniversityID;
            objCourse.iModeofStudyID = int.Parse(ddlModeofStudy.SelectedValue);
            objCourse.iLevelofStudyID = int.Parse(ddlLevelofStudy.SelectedValue);
            objCourse.strTitle = txtTitle.Text;
            objCourse.strFees = txtFees.Text;
            objCourse.strDetails = txtDetails.Text;
            objCourse.strEligibility = txtEligibility.Text;
            objCourse.strAdmissionCriteria = txtAdmissionCriteria.Text;

            string strResponse = objCourse.fn_saveCourse();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info.FindControl("mssg")).Text = strResponse;
                info.Visible = true;
            }
            else
            {
                ((Label)error.FindControl("mssg")).Text = strResponse;
                error.Visible = true;
            }

            fn_BindRecords();

            ddlModeofStudy.SelectedIndex = 0;
            ddlLevelofStudy.SelectedIndex = 0;
            txtTitle.Text = "";
            txtFees.Text = "";
            txtDetails.Text = "";
            txtEligibility.Text = "";
            txtAdmissionCriteria.Text = "";

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Records_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            DropDownList ddlModeofStudy = (DropDownList)dv_Records.FindControl("ddlModeofStudy");
            DropDownList ddlLevelofStudy = (DropDownList)dv_Records.FindControl("ddlLevelofStudy");
            TextBox txtTitle = (TextBox)dv_Records.FindControl("txtTitle");
            TextBox txtFees = (TextBox)dv_Records.FindControl("txtFees");
            TextBox txtDetails = (TextBox)dv_Records.FindControl("txtDetails");
            TextBox txtEligibility = (TextBox)dv_Records.FindControl("txtEligibility");
            TextBox txtAdmissionCriteria = (TextBox)dv_Records.FindControl("txtAdmissionCriteria");

            CourseClass objCourse = new CourseClass();
            objCourse.iID = int.Parse(dv_Records.DataKey.Value.ToString());
            objCourse.iModeofStudyID = int.Parse(ddlModeofStudy.SelectedValue);
            objCourse.iLevelofStudyID = int.Parse(ddlLevelofStudy.SelectedValue);
            objCourse.strTitle = txtTitle.Text;
            objCourse.strFees = txtFees.Text;
            objCourse.strDetails = txtDetails.Text;
            objCourse.strEligibility = txtEligibility.Text;
            objCourse.strAdmissionCriteria = txtAdmissionCriteria.Text;

            string strResponse = objCourse.fn_editCourse();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info.FindControl("mssg")).Text = strResponse;
                info.Visible = true;
            }
            else
            {
                ((Label)error.FindControl("mssg")).Text = strResponse;
                error.Visible = true;
            }

            dv_Records.ChangeMode(DetailsViewMode.ReadOnly);
            int iRecordID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
            fn_BindDetails(iRecordID);
            fn_BindRecords();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Records_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Records.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Records.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Records.ChangeMode(e.NewMode);

                if (grd_Records.SelectedIndex >= 0)
                {
                    int iRecordID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                    fn_BindDetails(iRecordID);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CourseClass objCourse = new CourseClass();
            objCourse.strTitle = txtSearch.Text.Trim();
            CoreWebList<CourseClass> objCourseList = objCourse.fn_getCourseByKeys();
            if (objCourseList.Count > 0)
            {
                ViewState["dtRecords"] = (DataTable)objCourseList;
                grd_Records.DataSource = objCourseList;
            }
            else
            {
                grd_Records.DataSource = null;
            }
            grd_Records.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void dv_Records_DataBound(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlModeofStudy = (DropDownList)dv_Records.FindControl("ddlModeofStudy");
            fn_BindModeofStudyDropDownList();

            if (dv_Records.CurrentMode == DetailsViewMode.Edit || dv_Records.CurrentMode == DetailsViewMode.ReadOnly)
            {
                CourseClass objCourses = new CourseClass();
                objCourses.iID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                CoreWebList<CourseClass> objCourseList = objCourses.fn_getCourseByID();
                if (objCourseList.Count > 0)
                {
                    ddlModeofStudy.SelectedValue = objCourseList[0].iModeofStudyID.ToString();
                }

                if (dv_Records.CurrentMode == DetailsViewMode.ReadOnly)
                {
                    ddlModeofStudy.Enabled = false;
                }
            }

            DropDownList ddlLevelofStudy = (DropDownList)dv_Records.FindControl("ddlLevelofStudy");
            fn_BindLevelofStudyDropDownList();

            if (dv_Records.CurrentMode == DetailsViewMode.Edit || dv_Records.CurrentMode == DetailsViewMode.ReadOnly)
            {
                CourseClass objCourses = new CourseClass();
                objCourses.iID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                CoreWebList<CourseClass> objCourseList = objCourses.fn_getCourseByID();
                if (objCourseList.Count > 0)
                {
                    ddlLevelofStudy.SelectedValue = objCourseList[0].iLevelofStudyID.ToString();
                }

                if (dv_Records.CurrentMode == DetailsViewMode.ReadOnly)
                {
                    ddlLevelofStudy.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void fn_BindModeofStudyDropDownList()
    {
        try
        {
            DropDownList ddlModeofStudy = (DropDownList)dv_Records.FindControl("ddlModeofStudy");
            if (ddlModeofStudy != null)
            {
                ModeofStudyClass objModeofStudy = new ModeofStudyClass();
                ddlModeofStudy.DataSource = objModeofStudy.fn_getModeofStudyList();
                ddlModeofStudy.DataTextField = "strTitle";
                ddlModeofStudy.DataValueField = "iID";
                ddlModeofStudy.DataBind();
                ddlModeofStudy.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void fn_BindLevelofStudyDropDownList()
    {
        try
        {
            DropDownList ddlLevelofStudy = (DropDownList)dv_Records.FindControl("ddlLevelofStudy");
            if (ddlLevelofStudy != null)
            {
                LevelofStudyClass objLevelofStudy = new LevelofStudyClass();
                ddlLevelofStudy.DataSource = objLevelofStudy.fn_getLevelofStudyList();
                ddlLevelofStudy.DataTextField = "strTitle";
                ddlLevelofStudy.DataValueField = "iID";
                ddlLevelofStudy.DataBind();
                ddlLevelofStudy.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
}