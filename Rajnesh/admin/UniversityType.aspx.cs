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

public partial class admin_UniversityType : System.Web.UI.Page
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
            // Response.Redirect("Type.aspx");
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
                UniversityTypeClass objCM = new UniversityTypeClass();
                grd_UniversityType.DataSource = objCM.fn_getTypeList();
                grd_UniversityType.DataBind();

                if (grd_UniversityType.SelectedIndex < 0)
                {
                    dv_UniversityType.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_UniversityType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        UniversityTypeClass objCM = new UniversityTypeClass();
        grd_UniversityType.PageIndex = e.NewPageIndex;
        grd_UniversityType.DataSource = objCM.fn_getTypeList();
        grd_UniversityType.DataBind();
    }
    protected void grd_UniversityType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            UniversityTypeClass objCM = new UniversityTypeClass();
            objCM.iID = int.Parse(grd_UniversityType.DataKeys[e.RowIndex].Value.ToString());
            string strResponse = objCM.fn_deleteType();

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
            grd_UniversityType.DataSource = objCM.fn_getTypeList();
            grd_UniversityType.DataBind();

            dv_UniversityType.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_UniversityType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_UniversityType.SelectedIndex < 0)
            {
                // Insert Mode
                dv_UniversityType.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_UniversityType.ChangeMode(DetailsViewMode.Edit);

                UniversityTypeClass objCM = new UniversityTypeClass();
                objCM.iID = int.Parse(grd_UniversityType.SelectedDataKey.Value.ToString());
                dv_UniversityType.DataSource = objCM.fn_getTypeByID();
                dv_UniversityType.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_UniversityType_Sorting(object sender, GridViewSortEventArgs e)
    {
        // Bind Data To grid            
        UniversityTypeClass objCM = new UniversityTypeClass();
        DataTable dt = (DataTable)objCM.fn_getTypeList();
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

        grd_UniversityType.DataSource = dv;
        grd_UniversityType.DataBind();
    }
    protected void dv_UniversityType_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtTypeTitle = (TextBox)dv_UniversityType.FindControl("txtTypeTitle");
            //TextBox txtTypeDesc = (TextBox)dv_UniversityType.FindControl("txtTypeDesc");
            FCKeditor fckDesc = (FCKeditor)dv_UniversityType.FindControl("fckDesc");

            UniversityTypeClass objCM = new UniversityTypeClass();
            objCM.strTypeTitle = txtTypeTitle.Text;
            objCM.strTypeDesc = fckDesc.Value;

            if (!IsRefresh)
            {
                string strResponse = objCM.fn_saveType();

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
            grd_UniversityType.DataSource = objCM.fn_getTypeList();
            grd_UniversityType.DataBind();

            // reset fields
            txtTypeTitle.Text = "";
            fckDesc.Value = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void dv_UniversityType_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtTypeTitle = (TextBox)dv_UniversityType.FindControl("txtTypeTitle");
            //TextBox txtTypeDesc = (TextBox)dv_UniversityType.FindControl("txtTypeDesc");
            FCKeditor fckDesc = (FCKeditor)dv_UniversityType.FindControl("fckDesc");

            UniversityTypeClass objCM = new UniversityTypeClass();
            objCM.strTypeTitle = txtTypeTitle.Text;
            objCM.strTypeDesc = fckDesc.Value;
            objCM.iID = int.Parse(dv_UniversityType.DataKey.Value.ToString());
            string strResponse = objCM.fn_editType();

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

            dv_UniversityType.ChangeMode(DetailsViewMode.ReadOnly);

            objCM.iID = int.Parse(grd_UniversityType.SelectedDataKey.Value.ToString());
            dv_UniversityType.DataSource = objCM.fn_getTypeByID();
            dv_UniversityType.DataBind();

            // Bind Data To grid            
            grd_UniversityType.DataSource = objCM.fn_getTypeList();
            grd_UniversityType.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void dv_UniversityType_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (dv_UniversityType.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
        {
            dv_UniversityType.ChangeMode(DetailsViewMode.Insert);
        }
        else
        {
            dv_UniversityType.ChangeMode(e.NewMode);

            if (grd_UniversityType.SelectedIndex >= 0)
            {
                UniversityTypeClass objCM = new UniversityTypeClass();
                objCM.iID = int.Parse(grd_UniversityType.SelectedDataKey.Value.ToString());
                dv_UniversityType.DataSource = objCM.fn_getTypeByID();
                dv_UniversityType.DataBind();
            }
        }
    }
}
