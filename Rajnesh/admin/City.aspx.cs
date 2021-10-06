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
using yo_lib;

public partial class Admin_Machine : System.Web.UI.Page
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
                // Bind Data To grid
                if (Request.QueryString["CountryID"] != null)
                {
                    //Bind grid......................................................................
                    BindGrid();

                    //Bind State Name on top label...................................................
                    //StateMasterClass objCM = new StateMasterClass();
                    //objCM.iID = int.Parse(Request.QueryString["CountryID"].ToString());

                    //DataTable dt = (DataTable)objCM.fn_getStateListByID();
                    //lblState.Text = dt.Rows[0]["strStateName"].ToString();

                    //Bind country name on top label..................................................
                    CountryMasterClass objCMS = new CountryMasterClass();
                    objCMS.iID = int.Parse(Request.QueryString["CountryID"].ToString());

                    DataTable dtCountry = (DataTable)objCMS.fn_getCountryByID();
                    lblCountry.Text = dtCountry.Rows[0]["strCountryName"].ToString();
                }

                if (grdCityList.SelectedIndex < 0)
                {
                    dvCity.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    void BindGrid()
    {
        try
        {
            CityMasterClass objMM = new CityMasterClass();
            objMM.iCountryID = int.Parse(Request.QueryString["CountryID"].ToString());
            
            CoreWebList<CityMasterClass> objCityList = objMM.fn_getCityListByCountryID();
            
            if (objCityList.Count > 0)
            {
                DataTable dtCourse = (DataTable)objCityList;

                grdCityList.DataSource = dtCourse;
                grdCityList.DataBind();
            }
        }

        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dvCity_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtName = (TextBox)dvCity.FindControl("txtName");
            CityMasterClass objMM = new CityMasterClass();

            objMM.strCityName = txtName.Text;
            objMM.iCountryID = int.Parse(Request.QueryString["CountryID"].ToString());

            if (!IsRefresh)
            {
                string strResponse = objMM.fn_saveCity();

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

            BindGrid();
            
            txtName.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grdCityList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            CityMasterClass objMM = new CityMasterClass();
            objMM.iID = int.Parse(grdCityList.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objMM.fn_deleteCity();

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

            BindGrid();

            dvCity.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grdCityList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grdCityList.SelectedIndex < 0)
            {
                // Insert Mode
                dvCity.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dvCity.ChangeMode(DetailsViewMode.Edit);

                CityMasterClass objMM = new CityMasterClass();
                objMM.iID = int.Parse(grdCityList.SelectedDataKey.Value.ToString());

                CoreWebList<CityMasterClass> cwCity = objMM.fn_getCityListByID();
                
                if (cwCity.Count > 0)
                {
                    DataTable dtCity = (DataTable)cwCity;

                    dvCity.DataSource = dtCity;
                    dvCity.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void dvCity_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            CityMasterClass objMM = new CityMasterClass();
            
            TextBox txtName = (TextBox)dvCity.FindControl("txtName");
            
            objMM.strCityName = txtName.Text;
            objMM.iCountryID = int.Parse(Request.QueryString["CountryID"].ToString());
            objMM.iID = int.Parse(grdCityList.SelectedDataKey.Value.ToString());

            string strResponse = objMM.fn_editCity();

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

            BindGrid();

            dvCity.ChangeMode(DetailsViewMode.ReadOnly);

            dvCity.DataSource = objMM.fn_getCityListByID();
            dvCity.DataBind();

            txtName.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dvCity_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dvCity.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dvCity.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dvCity.ChangeMode(e.NewMode);

                CityMasterClass objMM = new CityMasterClass();

                if (grdCityList.SelectedIndex >= 0)
                {
                    objMM.iID = int.Parse(grdCityList.SelectedDataKey.Value.ToString());

                    dvCity.DataSource = objMM.fn_getCityListByID();
                    dvCity.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grdCityList_Sorting(object sender, GridViewSortEventArgs e)
    {
        // Bind Data To grid            
        CityMasterClass objMM = new CityMasterClass();
        objMM.iCountryID = int.Parse(Request.QueryString["CountryID"].ToString());

        CoreWebList<CityMasterClass> objCityList = objMM.fn_getCityListByCountryID();
        
        if (objCityList.Count > 0)
        {
            DataTable dt = (DataTable)objCityList;
            
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

            grdCityList.DataSource = dv;
            grdCityList.DataBind();
        }
    }

    protected void grdCityList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CityMasterClass objMM = new CityMasterClass();

        grdCityList.PageIndex = e.NewPageIndex;

        BindGrid();
    }    
}