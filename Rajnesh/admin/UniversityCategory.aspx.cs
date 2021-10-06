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

public partial class admin_UniversityCategory : System.Web.UI.Page
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
                // Bind Data To grid                
                UniversityCategoryClass objUM = new UniversityCategoryClass();
                grd_UniversityCategory.DataSource = objUM.fn_getCategoryList();
                grd_UniversityCategory.DataBind();

                if (grd_UniversityCategory.SelectedIndex < 0)
                {
                    dv_UniversityCategory.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
            
    }
    protected void grd_UniversityCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        UniversityCategoryClass objCM = new UniversityCategoryClass();
        grd_UniversityCategory.PageIndex = e.NewPageIndex;
        grd_UniversityCategory.DataSource = objCM.fn_getCategoryList();
        grd_UniversityCategory.DataBind();
    }
    protected void grd_UniversityCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            UniversityCategoryClass objUM = new UniversityCategoryClass();
            objUM.iID = int.Parse(grd_UniversityCategory.DataKeys[e.RowIndex].Value.ToString());
            string strResponse = objUM.fn_deleteCategory();

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
            grd_UniversityCategory.DataSource = objUM.fn_getCategoryList();
            grd_UniversityCategory.DataBind();

            dv_UniversityCategory.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_UniversityCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_UniversityCategory.SelectedIndex < 0)
            {
                // Insert Mode
                dv_UniversityCategory.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_UniversityCategory.ChangeMode(DetailsViewMode.Edit);

                UniversityCategoryClass objUM = new UniversityCategoryClass();
                objUM.iID = int.Parse(grd_UniversityCategory.SelectedDataKey.Value.ToString());
                dv_UniversityCategory.DataSource = objUM.fn_getCategoryByID();
                dv_UniversityCategory.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_UniversityCategory_Sorting(object sender, GridViewSortEventArgs e)
    {
        // Bind Data To grid            
        UniversityCategoryClass objUM = new UniversityCategoryClass();
        DataTable dt = (DataTable)objUM.fn_getCategoryList();
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

        grd_UniversityCategory.DataSource = dv;
        grd_UniversityCategory.DataBind();
    }
    protected void dv_UniversityCategory_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtCategoryTitle = (TextBox)dv_UniversityCategory.FindControl("txtCategoryTitle");
            //TextBox txtCategoryDesc = (TextBox)dv_UniversityCategory.FindControl("txtCategoryDesc");
            FCKeditor fckDesc = (FCKeditor)dv_UniversityCategory.FindControl("fckDesc");

            UniversityCategoryClass objUM = new UniversityCategoryClass();
            objUM.strCategoryTitle = txtCategoryTitle.Text;
            objUM.strCategoryDesc = fckDesc.Value;

            if (!IsRefresh)
            {
                string strResponse = objUM.fn_saveCategory();

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
            grd_UniversityCategory.DataSource = objUM.fn_getCategoryList();
            grd_UniversityCategory.DataBind();

            // reset fields
            txtCategoryTitle.Text = "";
            fckDesc.Value = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void dv_UniversityCategory_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtCategoryTitle = (TextBox)dv_UniversityCategory.FindControl("txtCategoryTitle");
            //TextBox txtCategoryDesc = (TextBox)dv_UniversityCategory.FindControl("txtCategoryDesc");
            FCKeditor fckDesc = (FCKeditor)dv_UniversityCategory.FindControl("fckDesc");

            UniversityCategoryClass objUM = new UniversityCategoryClass();
            objUM.strCategoryTitle = txtCategoryTitle.Text;
            objUM.strCategoryDesc = fckDesc.Value;
            objUM.iID = int.Parse(dv_UniversityCategory.DataKey.Value.ToString());
            string strResponse = objUM.fn_editCategory();

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

            dv_UniversityCategory.ChangeMode(DetailsViewMode.ReadOnly);

            objUM.iID = int.Parse(grd_UniversityCategory.SelectedDataKey.Value.ToString());
            dv_UniversityCategory.DataSource = objUM.fn_getCategoryByID();
            dv_UniversityCategory.DataBind();

            // Bind Data To grid            
            grd_UniversityCategory.DataSource = objUM.fn_getCategoryList();
            grd_UniversityCategory.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void dv_UniversityCategory_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (dv_UniversityCategory.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
        {
            dv_UniversityCategory.ChangeMode(DetailsViewMode.Insert);
        }
        else
        {
            dv_UniversityCategory.ChangeMode(e.NewMode);

            if (grd_UniversityCategory.SelectedIndex >= 0)
            {
                UniversityCategoryClass objUM = new UniversityCategoryClass();
                objUM.iID = int.Parse(grd_UniversityCategory.SelectedDataKey.Value.ToString());
                dv_UniversityCategory.DataSource = objUM.fn_getCategoryByID();
                dv_UniversityCategory.DataBind();
            }
        }
    }
}
