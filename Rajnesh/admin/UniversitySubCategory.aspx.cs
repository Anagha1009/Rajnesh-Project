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

public partial class admin_UniversitySubCategory : System.Web.UI.Page
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
                if (Request.QueryString["CatID"] != null)
                {
                    UniversitySubCategoryClass objCM = new UniversitySubCategoryClass();
                    objCM.iCatID = int.Parse(Request.QueryString["CatID"].ToString());
                    grd_UniversitySubCategory.DataSource = objCM.fn_getSubCategoryByCatID();
                    grd_UniversitySubCategory.DataBind();

                    UniversityCategoryClass objCC = new UniversityCategoryClass();
                    objCC.iID = int.Parse(Request.QueryString["CatID"].ToString());
                    DataTable dtCatPro = (DataTable)objCC.fn_getCategoryByID();
                    lbl_Title.Text = dtCatPro.Rows[0]["strCategoryTitle"].ToString();


                    if (grd_UniversitySubCategory.SelectedIndex < 0)
                    {
                        dv_UniversitySubCategory.ChangeMode(DetailsViewMode.Insert);
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
    protected void grd_UniversitySubCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        UniversitySubCategoryClass objCM = new UniversitySubCategoryClass();
        objCM.iCatID = int.Parse(Request.QueryString["CatID"].ToString());
        grd_UniversitySubCategory.PageIndex = e.NewPageIndex;
        grd_UniversitySubCategory.DataSource = objCM.fn_getSubCategoryByCatID();
        grd_UniversitySubCategory.DataBind();
    }
    protected void grd_UniversitySubCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            UniversitySubCategoryClass objCM = new UniversitySubCategoryClass();
            objCM.iCatID = int.Parse(Request.QueryString["CatID"].ToString());
            objCM.iID = int.Parse(grd_UniversitySubCategory.DataKeys[e.RowIndex].Value.ToString());
            string strResponse = objCM.fn_deleteSubCategory();

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
            grd_UniversitySubCategory.DataSource = objCM.fn_getSubCategoryByCatID();
            grd_UniversitySubCategory.DataBind();

            dv_UniversitySubCategory.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_UniversitySubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_UniversitySubCategory.SelectedIndex < 0)
            {
                // Insert Mode
                dv_UniversitySubCategory.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_UniversitySubCategory.ChangeMode(DetailsViewMode.Edit);

                UniversitySubCategoryClass objCM = new UniversitySubCategoryClass();
                objCM.iID = int.Parse(grd_UniversitySubCategory.SelectedDataKey.Value.ToString());
                dv_UniversitySubCategory.DataSource = objCM.fn_getSubCategoryByID();
                dv_UniversitySubCategory.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_UniversitySubCategory_Sorting(object sender, GridViewSortEventArgs e)
    {
        // Bind Data To grid            
        UniversitySubCategoryClass objCM = new UniversitySubCategoryClass();
        objCM.iCatID = int.Parse(Request.QueryString["CatID"].ToString());
        DataTable dt = (DataTable)objCM.fn_getSubCategoryByCatID();
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

        grd_UniversitySubCategory.DataSource = dv;
        grd_UniversitySubCategory.DataBind();
    }
    protected void dv_UniversitySubCategory_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtSubCategoryTitle = (TextBox)dv_UniversitySubCategory.FindControl("txtSubCategoryTitle");
            //TextBox txtSubCategoryDesc = (TextBox)dv_UniversitySubCategory.FindControl("txtSubCategoryDesc");
            FCKeditor fckDesc = (FCKeditor)dv_UniversitySubCategory.FindControl("fckDesc");

            UniversitySubCategoryClass objCM = new UniversitySubCategoryClass();
            objCM.iCatID = int.Parse(Request.QueryString["CatID"].ToString());
            objCM.strSubCategoryTitle = txtSubCategoryTitle.Text;
            objCM.strSubCategoryDesc = fckDesc.Value;

            if (!IsRefresh)
            {
                string strResponse = objCM.fn_saveSubCategory();

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
            grd_UniversitySubCategory.DataSource = objCM.fn_getSubCategoryByCatID();
            grd_UniversitySubCategory.DataBind();

            // reset fields
            txtSubCategoryTitle.Text = "";
            fckDesc.Value = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void dv_UniversitySubCategory_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtSubCategoryTitle = (TextBox)dv_UniversitySubCategory.FindControl("txtSubCategoryTitle");
            //TextBox txtSubCategoryDesc = (TextBox)dv_UniversitySubCategory.FindControl("txtSubCategoryDesc");
            FCKeditor fckDesc = (FCKeditor)dv_UniversitySubCategory.FindControl("fckDesc");

            UniversitySubCategoryClass objCM = new UniversitySubCategoryClass();
            objCM.iCatID = int.Parse(Request.QueryString["CatID"].ToString());
            objCM.strSubCategoryTitle = txtSubCategoryTitle.Text;
            objCM.strSubCategoryDesc = fckDesc.Value;
            objCM.iID = int.Parse(dv_UniversitySubCategory.DataKey.Value.ToString());
            string strResponse = objCM.fn_editSubCategory();

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

            dv_UniversitySubCategory.ChangeMode(DetailsViewMode.ReadOnly);

            objCM.iID = int.Parse(grd_UniversitySubCategory.SelectedDataKey.Value.ToString());
            dv_UniversitySubCategory.DataSource = objCM.fn_getSubCategoryByID();
            dv_UniversitySubCategory.DataBind();

            // Bind Data To grid            
            grd_UniversitySubCategory.DataSource = objCM.fn_getSubCategoryByCatID();
            grd_UniversitySubCategory.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void dv_UniversitySubCategory_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (dv_UniversitySubCategory.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
        {
            dv_UniversitySubCategory.ChangeMode(DetailsViewMode.Insert);
        }
        else
        {
            dv_UniversitySubCategory.ChangeMode(e.NewMode);

            if (grd_UniversitySubCategory.SelectedIndex >= 0)
            {
                UniversitySubCategoryClass objCM = new UniversitySubCategoryClass();
                objCM.iID = int.Parse(grd_UniversitySubCategory.SelectedDataKey.Value.ToString());
                dv_UniversitySubCategory.DataSource = objCM.fn_getSubCategoryByID();
                dv_UniversitySubCategory.DataBind();
            }
        }
    }
}
