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

public partial class admin_DistanceLearningFeatures : System.Web.UI.Page
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
                    DistanceLearningClass objDLM = new DistanceLearningClass();
                    objDLM.iID = int.Parse(Request.QueryString["ID"].ToString());
                    CoreWebList<DistanceLearningClass> objDLList = objDLM.fn_GetDistanceLearningByID();
                    if (objDLList.Count > 0)
                    {
                        DataTable dt = (DataTable)objDLList;
                        lbl_DistanceLearningTitle.Text = dt.Rows[0]["strName"].ToString();
                    }

                    DLCoursesClass objDM = new DLCoursesClass();
                    objDM.iID = int.Parse(Request.QueryString["CourseID"].ToString());
                    CoreWebList<DLCoursesClass> objList = objDM.fn_getDLCourseByID();
                    if (objList.Count > 0)
                    {
                        DataTable dt = (DataTable)objList;
                        lbl_Title.Text = dt.Rows[0]["strName"].ToString();
                    }

                    // Bind Data To grid                
                    DLFeatureClass objCM = new DLFeatureClass();
                    objCM.iCourseID = int.Parse(Request.QueryString["CourseID"].ToString());
                    grd_DLearningFeatures.DataSource = objCM.fn_getDLFeatureByCourseID();
                    grd_DLearningFeatures.DataBind();

                    if (grd_DLearningFeatures.SelectedIndex < 0)
                    {
                        dv_DLearningFeatures.ChangeMode(DetailsViewMode.Insert);
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

    protected void grd_DLearningFeatures_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DLFeatureClass objCM = new DLFeatureClass();
        objCM.iCourseID = int.Parse(Request.QueryString["CourseID"].ToString());
        grd_DLearningFeatures.PageIndex = e.NewPageIndex;
        grd_DLearningFeatures.DataSource = objCM.fn_getDLFeatureByCourseID();
        grd_DLearningFeatures.DataBind();
    }
    protected void grd_DLearningFeatures_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DLFeatureClass objCM = new DLFeatureClass();
            objCM.iID = int.Parse(grd_DLearningFeatures.DataKeys[e.RowIndex].Value.ToString());
            string strResponse = objCM.fn_deleteDLFeature();
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
            objCM.iCourseID = int.Parse(Request.QueryString["CourseID"].ToString());
            grd_DLearningFeatures.DataSource = objCM.fn_getDLFeatureByCourseID();
            grd_DLearningFeatures.DataBind();
            dv_DLearningFeatures.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void grd_DLearningFeatures_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_DLearningFeatures.SelectedIndex < 0)
            {
                // Insert Mode
                dv_DLearningFeatures.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_DLearningFeatures.ChangeMode(DetailsViewMode.Edit);
                DLFeatureClass objCM = new DLFeatureClass();
                objCM.iID = int.Parse(grd_DLearningFeatures.SelectedDataKey.Value.ToString());
                CoreWebList<DLFeatureClass> objList = objCM.fn_getDLFeatureByID();
                DataTable dt = null;
                if (objList.Count > 0)
                {
                    dt = (DataTable)objList;
                    dv_DLearningFeatures.DataSource = dt;
                    dv_DLearningFeatures.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void grd_DLearningFeatures_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DLFeatureClass objCL = new DLFeatureClass();
            objCL.iCourseID = int.Parse(Request.QueryString["CourseID"].ToString());
            DataTable dt = (DataTable)objCL.fn_getDLFeatureByCourseID();
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

            grd_DLearningFeatures.DataSource = dv;
            grd_DLearningFeatures.DataBind();

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void dv_DLearningFeatures_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtName = (TextBox)dv_DLearningFeatures.FindControl("txtName");
            FCKeditor FCKDesc = (FCKeditor)dv_DLearningFeatures.FindControl("FCKDesc");            

            DLFeatureClass objCM = new DLFeatureClass();
            objCM.strName = txtName.Text;
            objCM.iDistanceID = int.Parse(Request.QueryString["ID"].ToString());
            objCM.iCourseID = int.Parse(Request.QueryString["CourseID"].ToString());
            objCM.strDescription = FCKDesc.Value.Trim();

            if (!IsRefresh)
            {
                string strResponse = objCM.fn_saveDLFeature();
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
            grd_DLearningFeatures.DataSource = objCM.fn_getDLFeatureByCourseID();
            grd_DLearningFeatures.DataBind();

            // reset fields
            txtName.Text = string.Empty;
            FCKDesc.Value = string.Empty;            
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void dv_DLearningFeatures_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtName = (TextBox)dv_DLearningFeatures.FindControl("txtName");
            FCKeditor FCKDesc = (FCKeditor)dv_DLearningFeatures.FindControl("FCKDesc");            

            DLFeatureClass objCM = new DLFeatureClass();
            objCM.strName = txtName.Text;
            objCM.iDistanceID = int.Parse(Request.QueryString["ID"].ToString());
            objCM.iCourseID = int.Parse(Request.QueryString["CourseID"].ToString());
            objCM.strDescription = FCKDesc.Value.Trim();

            objCM.iID = int.Parse(dv_DLearningFeatures.DataKey.Value.ToString());

            string strResponse = objCM.fn_editDLFeature();

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

            dv_DLearningFeatures.ChangeMode(DetailsViewMode.ReadOnly);
            objCM.iID = int.Parse(grd_DLearningFeatures.SelectedDataKey.Value.ToString());
            dv_DLearningFeatures.DataSource = objCM.fn_getDLFeatureByID();
            dv_DLearningFeatures.DataBind();

            // Bind Data To grid            
            grd_DLearningFeatures.DataSource = objCM.fn_getDLFeatureByCourseID();
            grd_DLearningFeatures.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void dv_DLearningFeatures_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (dv_DLearningFeatures.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
        {
            dv_DLearningFeatures.ChangeMode(DetailsViewMode.Insert);
        }
        else
        {
            dv_DLearningFeatures.ChangeMode(e.NewMode);
            if (grd_DLearningFeatures.SelectedIndex >= 0)
            {
                DLFeatureClass objCM = new DLFeatureClass();
                objCM.iID = int.Parse(grd_DLearningFeatures.SelectedDataKey.Value.ToString());
                dv_DLearningFeatures.DataSource = objCM.fn_getDLFeatureByID();
                dv_DLearningFeatures.DataBind();
            }
        }
    }
    
}
