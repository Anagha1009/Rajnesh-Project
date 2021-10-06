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
using System.IO;
using FredCK.FCKeditorV2;

public partial class admin_InstituteCategory : System.Web.UI.Page
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

    string strRanFileName = string.Empty;
    string strDocPath = string.Empty;
    string strOrgFileName = string.Empty;


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
                InstituteCategoryClass objIC = new InstituteCategoryClass();
                grd_InstCategory.DataSource = objIC.fn_getCategoryList();
                grd_InstCategory.DataBind();

                if (grd_InstCategory.SelectedIndex < 0)
                {
                    dv_InstCategory.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_InstCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        InstituteCategoryClass objIC = new InstituteCategoryClass();
        grd_InstCategory.PageIndex = e.NewPageIndex;
        grd_InstCategory.DataSource = objIC.fn_getCategoryList();
        grd_InstCategory.DataBind();
    }
    protected void grd_InstCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            InstituteCategoryClass objIC = new InstituteCategoryClass();
            objIC.iID = int.Parse(grd_InstCategory.DataKeys[e.RowIndex].Value.ToString());
            string strResponse = objIC.fn_deleteCategory();

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
            grd_InstCategory.DataSource = objIC.fn_getCategoryList();
            grd_InstCategory.DataBind();

            dv_InstCategory.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_InstCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_InstCategory.SelectedIndex < 0)
            {
                // Insert Mode
                dv_InstCategory.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_InstCategory.ChangeMode(DetailsViewMode.Edit);

                InstituteCategoryClass objIC = new InstituteCategoryClass();
                objIC.iID = int.Parse(grd_InstCategory.SelectedDataKey.Value.ToString());
                dv_InstCategory.DataSource = objIC.fn_getCategoryByID();
                dv_InstCategory.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_InstCategory_Sorting(object sender, GridViewSortEventArgs e)
    {
        // Bind Data To grid            
        InstituteCategoryClass objIC = new InstituteCategoryClass();
        DataTable dt = (DataTable)objIC.fn_getCategoryList();
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

        grd_InstCategory.DataSource = dv;
        grd_InstCategory.DataBind();
    }
    protected void dv_InstCategory_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtCategoryTitle = (TextBox)dv_InstCategory.FindControl("txtCategoryTitle");
            //TextBox txtCategoryDesc = (TextBox)dv_InstCategory.FindControl("txtCategoryDesc");
            FCKeditor fckDesc = (FCKeditor)dv_InstCategory.FindControl("fckDesc");
            FileUpload fuCategoryImage = (FileUpload)dv_InstCategory.FindControl("fuCategoryImage");

            if (fuCategoryImage.HasFile)
            {
                cls_common objCFC = new cls_common();
                //Calling function to get the name of the file with timestamp
                strRanFileName = objCFC.file_name(fuCategoryImage.FileName);
                strDocPath = Server.MapPath("~/admin/Upload/InstituteCategory/" + strRanFileName);
                fuCategoryImage.SaveAs(strDocPath);
            }

            InstituteCategoryClass objIC = new InstituteCategoryClass();
            objIC.strCategoryTitle = txtCategoryTitle.Text;
            objIC.strCategoryDesc = fckDesc.Value;
            objIC.strImage = strRanFileName;

            objIC.iOrder = objIC.fn_getCategoryList().Count + 1;

            if (!IsRefresh)
            {
                string strResponse = objIC.fn_saveCategory();

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
            grd_InstCategory.DataSource = objIC.fn_getCategoryList();
            grd_InstCategory.DataBind();

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
    protected void dv_InstCategory_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtCategoryTitle = (TextBox)dv_InstCategory.FindControl("txtCategoryTitle");
            //TextBox txtCategoryDesc = (TextBox)dv_InstCategory.FindControl("txtCategoryDesc");
            FCKeditor fckDesc = (FCKeditor)dv_InstCategory.FindControl("fckDesc");
            FileUpload fuCategoryImage = (FileUpload)dv_InstCategory.FindControl("fuCategoryImage");
            DropDownList ddl_Order = (DropDownList)dv_InstCategory.FindControl("ddl_Order");

            InstituteCategoryClass objIC = new InstituteCategoryClass();
            objIC.strCategoryTitle = txtCategoryTitle.Text;
            objIC.strCategoryDesc = fckDesc.Value;
            objIC.strImage = strRanFileName;
            objIC.iID = int.Parse(dv_InstCategory.DataKey.Value.ToString());
            objIC.iOrder = int.Parse(ddl_Order.SelectedValue);
            if (!IsRefresh)
            {                
                string strResponse = string.Empty;
                if (fuCategoryImage.HasFile)
                {
                    DataTable dt = (DataTable)objIC.fn_getCategoryByID();
                    strRanFileName = dt.Rows[0]["strImage"].ToString();

                    if (File.Exists(MapPath("~/admin/Upload/InstituteCategory/" + strRanFileName)))
                    {
                        //Deletes the Image file from the Folder
                        File.Delete((MapPath("~/admin/Upload/InstituteCategory/" + strRanFileName)));
                    }
                    cls_common objCFC = new cls_common();
                    //Calling function to get the name of the file with timestamp
                    strRanFileName = objCFC.file_name(fuCategoryImage.FileName);
                    strDocPath = Server.MapPath("~/admin/Upload/InstituteCategory/" + strRanFileName);
                    fuCategoryImage.SaveAs(strDocPath);
                    objIC.strImage = strRanFileName;
                    strResponse = objIC.fn_editCategory();
                }
                else
                {
                    strResponse = objIC.fn_editCategoryWithoutImage();
                }

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

            dv_InstCategory.ChangeMode(DetailsViewMode.ReadOnly);

            objIC.iID = int.Parse(grd_InstCategory.SelectedDataKey.Value.ToString());
            dv_InstCategory.DataSource = objIC.fn_getCategoryByID();
            dv_InstCategory.DataBind();

            // Bind Data To grid            
            grd_InstCategory.DataSource = objIC.fn_getCategoryList();
            grd_InstCategory.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void dv_InstCategory_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (dv_InstCategory.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
        {
            dv_InstCategory.ChangeMode(DetailsViewMode.Insert);
        }
        else
        {
            dv_InstCategory.ChangeMode(e.NewMode);

            if (grd_InstCategory.SelectedIndex >= 0)
            {
                InstituteCategoryClass objIC = new InstituteCategoryClass();
                objIC.iID = int.Parse(grd_InstCategory.SelectedDataKey.Value.ToString());
                dv_InstCategory.DataSource = objIC.fn_getCategoryByID();
                dv_InstCategory.DataBind();
            }
        }
    }
    protected void dv_InstCategory_DataBound(object sender, EventArgs e)
    {
        if (dv_InstCategory.CurrentMode == DetailsViewMode.ReadOnly)
        {
            dv_InstCategory.Fields[4].Visible = false;
            dv_InstCategory.Fields[5].Visible = true;
        }

        if (dv_InstCategory.CurrentMode == DetailsViewMode.Insert)
        {
            dv_InstCategory.Fields[4].Visible = true;
            dv_InstCategory.Fields[5].Visible = false;
        }

        if (dv_InstCategory.CurrentMode == DetailsViewMode.Edit)
        {
            fn_BindMaxValue();
            dv_InstCategory.Fields[4].Visible = true;
            dv_InstCategory.Fields[5].Visible = true;
        }
    }

    void fn_BindMaxValue()
    {
        try
        {
            InstituteCategoryClass objIC = new InstituteCategoryClass();             
            DropDownList ddl_Order = (DropDownList)dv_InstCategory.FindControl("ddl_Order");
            HiddenField hfOrder = (HiddenField)dv_InstCategory.FindControl("hfOrder");
            if (ddl_Order != null)
            {
                ddl_Order.Items.Clear();
                int iMax = objIC.fn_getCategoryList().Count;
                ddl_Order.Items.Insert(0, new ListItem("Select", "-1"));
                for (int i = 1; i <= iMax; i++)
                {
                    ddl_Order.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
                }
                if (hfOrder != null)
                {                    
                    (ddl_Order.Items.FindByValue(hfOrder.Value)).Selected = true;                   
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
}
