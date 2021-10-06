using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using FredCK.FCKeditorV2;
using yo_lib;

public partial class admin_DistanceLearningCenters : System.Web.UI.Page
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
                if (Request.QueryString["DLID"] != null)
                {
                    // Bind Data To grid                
                    DLCenterClass objCM = new DLCenterClass();
                    objCM.iDLInstituteID = int.Parse(Request.QueryString["DLID"].ToString());
                    grd_DLCentres.DataSource = objCM.fn_get_DLCentreListByInstituteID();
                    grd_DLCentres.DataBind();

                    if (grd_DLCentres.SelectedIndex < 0)
                    {
                        dv_DLCentres.ChangeMode(DetailsViewMode.Insert);
                    }

                    //Bind Institute Title On Top
                    DistanceLearningClass objIF = new DistanceLearningClass();
                    objIF.iID = int.Parse(Request.QueryString["DLID"].ToString());
                    CoreWebList<DistanceLearningClass> objIMCList = objIF.fn_GetDistanceLearningByID();
                    DataTable dt = null;
                    if (objIMCList.Count > 0)
                    {
                        dt = (DataTable)objIMCList;
                        lbl_TestPrepare.Text = dt.Rows[0]["strName"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_DLCentres_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DLCenterClass objCM = new DLCenterClass();
        objCM.iDLInstituteID = int.Parse(Request.QueryString["DLID"].ToString());
        grd_DLCentres.PageIndex = e.NewPageIndex;
        grd_DLCentres.DataSource = objCM.fn_get_DLCentreListByInstituteID();
        grd_DLCentres.DataBind();
    }
    protected void grd_DLCentres_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DLCenterClass objCM = new DLCenterClass();
            objCM.iDLInstituteID = int.Parse(Request.QueryString["DLID"].ToString());
            objCM.iID = int.Parse(grd_DLCentres.DataKeys[e.RowIndex].Value.ToString());
            string strResponse = objCM.fn_DeleteDLCentre();

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
            grd_DLCentres.DataSource = objCM.fn_get_DLCentreListByInstituteID();
            grd_DLCentres.DataBind();

            dv_DLCentres.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_DLCentres_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_DLCentres.SelectedIndex < 0)
            {
                // Insert Mode
                dv_DLCentres.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_DLCentres.ChangeMode(DetailsViewMode.Edit);
                DLCenterClass objCM = new DLCenterClass();
                objCM.iID = int.Parse(grd_DLCentres.SelectedDataKey.Value.ToString());
                dv_DLCentres.DataSource = objCM.fn_GetDLCentreByID();
                dv_DLCentres.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_DLCentres_Sorting(object sender, GridViewSortEventArgs e)
    {
        // Bind Data To grid            
        DLCenterClass objCM = new DLCenterClass();
        objCM.iDLInstituteID = int.Parse(Request.QueryString["DLID"].ToString());
        DataTable dt = (DataTable)objCM.fn_get_DLCentreListByInstituteID();
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

        grd_DLCentres.DataSource = dv;
        grd_DLCentres.DataBind();
    }
    protected void dv_DLCentres_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            FCKeditor fckAddress = (FCKeditor)dv_DLCentres.FindControl("fckAddress");
            DropDownList ddlCity = (DropDownList)dv_DLCentres.FindControl("ddlCity");

            DLCenterClass objCM = new DLCenterClass();
            objCM.strCity = ddlCity.SelectedItem.Text;
            objCM.strAddress = fckAddress.Value;
            objCM.iDLInstituteID = int.Parse(Request.QueryString["DLID"].ToString());

            if (!IsRefresh)
            {
                string strResponse = objCM.fn_SaveDLCentre();
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
            grd_DLCentres.DataSource = objCM.fn_get_DLCentreListByInstituteID();
            grd_DLCentres.DataBind();

            // reset fields
            ddlCity.SelectedIndex = 0;
            fckAddress.Value = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void dv_DLCentres_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            FCKeditor fckAddress = (FCKeditor)dv_DLCentres.FindControl("fckAddress");
            DropDownList ddlCity = (DropDownList)dv_DLCentres.FindControl("ddlCity");
            DLCenterClass objCM = new DLCenterClass();
            objCM.strCity = ddlCity.SelectedItem.Text;
            objCM.strAddress = fckAddress.Value;
            objCM.iDLInstituteID = int.Parse(Request.QueryString["DLID"].ToString());
            objCM.iID = int.Parse(dv_DLCentres.DataKey.Value.ToString());
            string strResponse = objCM.fn_EditDLCentre();

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

            dv_DLCentres.ChangeMode(DetailsViewMode.ReadOnly);

            objCM.iID = int.Parse(grd_DLCentres.SelectedDataKey.Value.ToString());
            dv_DLCentres.DataSource = objCM.fn_GetDLCentreByID();
            dv_DLCentres.DataBind();

            // Bind Data To grid            
            grd_DLCentres.DataSource = objCM.fn_get_DLCentreListByInstituteID();
            grd_DLCentres.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void dv_DLCentres_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (dv_DLCentres.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
        {
            dv_DLCentres.ChangeMode(DetailsViewMode.Insert);
        }
        else
        {
            dv_DLCentres.ChangeMode(e.NewMode);

            if (grd_DLCentres.SelectedIndex >= 0)
            {
                DLCenterClass objCM = new DLCenterClass();
                objCM.iID = int.Parse(grd_DLCentres.SelectedDataKey.Value.ToString());
                dv_DLCentres.DataSource = objCM.fn_GetDLCentreByID();
                dv_DLCentres.DataBind();
            }
        }
    }

    protected void fn_getCityForIndia()
    {
        DropDownList ddlCity = (DropDownList)dv_DLCentres.FindControl("ddlCity");
        if (ddlCity != null)
        {
            CityMasterClass objCM = new CityMasterClass();
            ddlCity.DataValueField = "iID";
            ddlCity.DataTextField = "strCityName";
            ddlCity.DataSource = objCM.fn_getCityListForIndia();
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("Select", "0"));
        }
    }

    protected void dv_DLCentres_DataBound(object sender, EventArgs e)
    {
        if (dv_DLCentres.CurrentMode == DetailsViewMode.Insert)
        {
            fn_getCityForIndia();
        }
        else if (dv_DLCentres.CurrentMode == DetailsViewMode.Edit)
        {
            fn_getCityForIndia();
            DLCenterClass objCM = new DLCenterClass();
            DropDownList ddlCity = (DropDownList)dv_DLCentres.FindControl("ddlCity");
            objCM.iID = int.Parse(grd_DLCentres.SelectedDataKey.Value.ToString());
            DataTable dt = (DataTable)objCM.fn_GetDLCentreByID();
            ddlCity.Items.FindByText(dt.Rows[0]["strCity"].ToString()).Selected = true;
        }
    }
}
