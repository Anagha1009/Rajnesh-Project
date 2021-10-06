using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using yo_lib;
using FredCK.FCKeditorV2;

public partial class admin_DistanceLearningCourses : System.Web.UI.Page
{
    #region "view state methods for checking the user refresh here"

    private bool _refreshState;
    private bool _isRefresh;

    public bool IsRefresh
    {
        get
        {
            return _isRefresh;
        }
    }

    protected override void LoadViewState(object savedState)
    {
        object[] allStates = (object[])savedState;
        base.LoadViewState(allStates[0]);
        _refreshState = (bool)allStates[1];
        if (Session["__ISREFRESH"] != null)
        {
            _isRefresh = _refreshState == (bool)Session["__ISREFRESH"];
        }
        else
        {
            // Response.Redirect("Category.aspx");
        }
    }

    protected override object SaveViewState()
    {
        Session["__ISREFRESH"] = _refreshState;
        object[] allStates = new object[2];
        allStates[0] = base.SaveViewState();
        allStates[1] = !_refreshState;
        return allStates;
    }
    #endregion
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
            //Check login session 
            //If not logged in redirect to admin login page
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx?flag=1");
            }
            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    DistanceLearningClass objDM = new DistanceLearningClass();
                    objDM.iID = int.Parse(Request.QueryString["ID"].ToString());
                    CoreWebList<DistanceLearningClass> objList = objDM.fn_GetDistanceLearningByID();
                    if (objList.Count > 0)
                    {
                        DataTable dt = (DataTable)objList;
                        lbl_Title.Text = dt.Rows[0]["strName"].ToString();
                    }

                    // Bind Data To grid                
                    DLCoursesClass objCM = new DLCoursesClass();
                    objCM.iDistanceID = int.Parse(Request.QueryString["ID"].ToString());
                    grd_DLearningCourses.DataSource = objCM.fn_getDLCourseByDistanceID();
                    grd_DLearningCourses.DataBind();

                    if (grd_DLearningCourses.SelectedIndex < 0)
                    {
                        dv_DLearningCourses.ChangeMode(DetailsViewMode.Insert);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    public void fn_BindCourseTypeDDL()
    {
        DropDownList ddlType = (DropDownList)dv_DLearningCourses.FindControl("ddlType");
        CourseTypeClass objCM = new CourseTypeClass();
        ddlType.DataSource = objCM.fn_getTypeList();
        ddlType.DataTextField = "strTypeTitle";
        ddlType.DataValueField = "iID";
        ddlType.DataBind();
        ddlType.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void grd_DLearningCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DLCoursesClass objCM = new DLCoursesClass();
        objCM.iDistanceID = int.Parse(Request.QueryString["ID"].ToString());
        grd_DLearningCourses.PageIndex = e.NewPageIndex;
        grd_DLearningCourses.DataSource = objCM.fn_getDLCourseByDistanceID();
        grd_DLearningCourses.DataBind();
    }
    protected void grd_DLearningCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DLCoursesClass objCM = new DLCoursesClass();
            objCM.iID = int.Parse(grd_DLearningCourses.DataKeys[e.RowIndex].Value.ToString());    
            string strResponse = objCM.fn_deleteDLCourse();
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
            // Bind Data To grid  
            objCM.iDistanceID = int.Parse(Request.QueryString["ID"].ToString());
            grd_DLearningCourses.DataSource = objCM.fn_getDLCourseByDistanceID();
            grd_DLearningCourses.DataBind();
            dv_DLearningCourses.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void grd_DLearningCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_DLearningCourses.SelectedIndex < 0)
            {
                // Insert Mode
                dv_DLearningCourses.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_DLearningCourses.ChangeMode(DetailsViewMode.Edit);
                DLCoursesClass objCM = new DLCoursesClass();
                objCM.iID = int.Parse(grd_DLearningCourses.SelectedDataKey.Value.ToString());
                CoreWebList<DLCoursesClass> objList = objCM.fn_getDLCourseByID();
                DataTable dt = null;
                if (objList.Count > 0)
                {
                    dt = (DataTable)objList;
                    dv_DLearningCourses.DataSource = dt;
                    dv_DLearningCourses.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void grd_DLearningCourses_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DLCoursesClass objCL = new DLCoursesClass();
            objCL.iDistanceID = int.Parse(Request.QueryString["ID"].ToString());
            DataTable dt = (DataTable)objCL.fn_getDLCourseByDistanceID();
            DataView dv = new DataView(dt);

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

            grd_DLearningCourses.DataSource = dv;
            grd_DLearningCourses.DataBind();

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }   
    protected void dv_DLearningCourses_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtName = (TextBox)dv_DLearningCourses.FindControl("txtName");
            FCKeditor FCKDesc = (FCKeditor)dv_DLearningCourses.FindControl("FCKDesc");
            DropDownList ddlType = (DropDownList)dv_DLearningCourses.FindControl("ddlType");

            DLCoursesClass objCM = new DLCoursesClass();
            objCM.strName = txtName.Text;
            objCM.iDistanceID = int.Parse(Request.QueryString["ID"].ToString());
            objCM.iTypeID = int.Parse(ddlType.SelectedValue);
            objCM.strDescription = FCKDesc.Value.Trim();
           
            if (!IsRefresh)
            {
                string strResponse = objCM.fn_saveDLCourse();
                if (strResponse.StartsWith("SUCCESS"))
                {
                    ((Label)info_dv.FindControl("mssg")).Text = strResponse;
                    info_dv.Visible = true;
                }
                else
                {
                    ((Label)error_dv.FindControl("mssg")).Text = strResponse;
                    error_dv.Visible = true;
                }
            }

            // Bind Data To grid            
            grd_DLearningCourses.DataSource = objCM.fn_getDLCourseByDistanceID();
            grd_DLearningCourses.DataBind();

            // reset fields
            txtName.Text = string.Empty;
            FCKDesc.Value = string.Empty;
            ddlType.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void dv_DLearningCourses_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtName = (TextBox)dv_DLearningCourses.FindControl("txtName");
            FCKeditor FCKDesc = (FCKeditor)dv_DLearningCourses.FindControl("FCKDesc");
            DropDownList ddlType = (DropDownList)dv_DLearningCourses.FindControl("ddlType");

            DLCoursesClass objCM = new DLCoursesClass();
            objCM.strName = txtName.Text;
            objCM.iDistanceID = int.Parse(Request.QueryString["ID"].ToString());
            objCM.iTypeID = int.Parse(ddlType.SelectedValue);
            objCM.strDescription = FCKDesc.Value.Trim();

            objCM.iID = int.Parse(dv_DLearningCourses.DataKey.Value.ToString());

            string strResponse = objCM.fn_editDLCourse();            
            
            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info_dv.FindControl("mssg")).Text = strResponse;
                info_dv.Visible = true;
            }
            else
            {
                ((Label)error_dv.FindControl("mssg")).Text = strResponse;
                error_dv.Visible = true;
            }

            dv_DLearningCourses.ChangeMode(DetailsViewMode.ReadOnly);
            objCM.iID = int.Parse(grd_DLearningCourses.SelectedDataKey.Value.ToString());
            dv_DLearningCourses.DataSource = objCM.fn_getDLCourseByID();
            dv_DLearningCourses.DataBind();

            // Bind Data To grid            
            grd_DLearningCourses.DataSource = objCM.fn_getDLCourseByDistanceID();
            grd_DLearningCourses.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void dv_DLearningCourses_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (dv_DLearningCourses.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
        {
            dv_DLearningCourses.ChangeMode(DetailsViewMode.Insert);
        }
        else
        {
            dv_DLearningCourses.ChangeMode(e.NewMode);
            if (grd_DLearningCourses.SelectedIndex >= 0)
            {
                DLCoursesClass objCM = new DLCoursesClass();
                objCM.iID = int.Parse(grd_DLearningCourses.SelectedDataKey.Value.ToString());
                dv_DLearningCourses.DataSource = objCM.fn_getDLCourseByID();
                dv_DLearningCourses.DataBind();
            }
        }
    }
    
    protected void dv_DLearningCourses_DataBound(object sender, EventArgs e)
    {
        if (dv_DLearningCourses.CurrentMode == DetailsViewMode.Insert)
        {
            fn_BindCourseTypeDDL();
        }
        else if (dv_DLearningCourses.CurrentMode == DetailsViewMode.Edit)
        {
            fn_BindCourseTypeDDL();
            DropDownList ddlType = (DropDownList)dv_DLearningCourses.FindControl("ddlType");
            DLCoursesClass objCM = new DLCoursesClass();
            objCM.iID = int.Parse(dv_DLearningCourses.DataKey.Value.ToString());
            CoreWebList<DLCoursesClass> objList = objCM.fn_getDLCourseByID();
            DataTable dt = null;
            if (objList.Count > 0)
            {
                dt = (DataTable)objList;
                ddlType.Items.FindByValue(dt.Rows[0]["iTypeID"].ToString()).Selected = true;
            }
        }
    }
}
