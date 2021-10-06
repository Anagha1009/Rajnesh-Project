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

public partial class admin_CountryMaster : System.Web.UI.Page
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
                CountryMasterClass objCM = new CountryMasterClass();
                grdCountryList.DataSource = objCM.fn_getCountryList();
                grdCountryList.DataBind();

                if (grdCountryList.SelectedIndex < 0)
                {
                    dvCountry.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dvCountry_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtCountryName = (TextBox) dvCountry.FindControl("txtCountryName");
            TextBox txtGMT = (TextBox) dvCountry.FindControl("txtGMT");

            CountryMasterClass objCM = new CountryMasterClass();
            objCM.strCountryName = txtCountryName.Text;

            if (!IsRefresh)
            {
                string strResponse = objCM.fn_saveCountry();

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
            grdCountryList.DataSource = objCM.fn_getCountryList();
            grdCountryList.DataBind();

            // reset fields
            txtCountryName.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grdCountryList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            CountryMasterClass objCM = new CountryMasterClass();
            objCM.iID = int.Parse(grdCountryList.DataKeys[e.RowIndex].Value.ToString());
            string strResponse = objCM.fn_deleteCountry();

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
            grdCountryList.DataSource = objCM.fn_getCountryList();
            grdCountryList.DataBind();

	        dvCountry.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grdCountryList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grdCountryList.SelectedIndex < 0)
            {
                // Insert Mode
                dvCountry.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dvCountry.ChangeMode(DetailsViewMode.Edit);

                CountryMasterClass objCM = new CountryMasterClass();
                objCM.iID = int.Parse(grdCountryList.SelectedDataKey.Value.ToString());
                dvCountry.DataSource = objCM.fn_getCountryByID();
                dvCountry.DataBind();                
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dvCountry_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtCountryName = (TextBox)dvCountry.FindControl("txtCountryName");

            CountryMasterClass objCM = new CountryMasterClass();
            objCM.strCountryName = txtCountryName.Text;
            objCM.iID = int.Parse(dvCountry.DataKey.Value.ToString());
            string strResponse = objCM.fn_editCountry();

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

            dvCountry.ChangeMode(DetailsViewMode.ReadOnly);

            objCM.iID = int.Parse(grdCountryList.SelectedDataKey.Value.ToString());
            dvCountry.DataSource = objCM.fn_getCountryByID();
            dvCountry.DataBind();                

            // Bind Data To grid            
            grdCountryList.DataSource = objCM.fn_getCountryList();
            grdCountryList.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dvCountry_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (dvCountry.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
        {
            dvCountry.ChangeMode(DetailsViewMode.Insert);
        }
        else
        {
            dvCountry.ChangeMode(e.NewMode);

            if (grdCountryList.SelectedIndex >= 0)
            {
                CountryMasterClass objCM = new CountryMasterClass();
                objCM.iID = int.Parse(grdCountryList.SelectedDataKey.Value.ToString());
                dvCountry.DataSource = objCM.fn_getCountryByID();
                dvCountry.DataBind();
            }
        }
    }

    protected void grdCountryList_Sorting(object sender, GridViewSortEventArgs e)
    {
        // Bind Data To grid            
        CountryMasterClass objCM = new CountryMasterClass();
        DataTable dt = (DataTable)objCM.fn_getCountryList();
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
        
        grdCountryList.DataSource = dv;
        grdCountryList.DataBind();
    }

    protected void grdCountryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CountryMasterClass objCM = new CountryMasterClass();
        grdCountryList.PageIndex = e.NewPageIndex;
        grdCountryList.DataSource = objCM.fn_getCountryList();
        grdCountryList.DataBind();
    }
}
