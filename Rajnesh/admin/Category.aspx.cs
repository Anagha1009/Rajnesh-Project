using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Text;
using System.IO;

public partial class admin_Category : System.Web.UI.Page
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
    
    private CoreWebList<CategoryClass> ch_Category_List
    {
        get
        {
            if (Cache["ch_Category_List"] != null)
                return (CoreWebList<CategoryClass>)Cache["ch_Category_List"];
            return null;
        }
        set
        {
            Cache["ch_Category_List"] = value;
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
                //Bind Data To grid
                CategoryClass objCategory = new CategoryClass();
                ch_Category_List = objCategory.fn_getCategoryList();

                if (ch_Category_List.Count > 0)
                {
                    grd_Category.DataSource = ch_Category_List;
                }
                else
                {
                    grd_Category.DataSource = null;
                }
                grd_Category.DataBind();

                if (grd_Category.SelectedIndex < 0)
                {
                    dv_Category.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Category_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Category.PageIndex = e.NewPageIndex;
            grd_Category.DataSource = ch_Category_List;
            grd_Category.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Category_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            CategoryClass objCategory = new CategoryClass();
            objCategory.iID = int.Parse(grd_Category.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objCategory.fn_deleteCategory();

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

            grd_Category.DataSource = objCategory.fn_getCategoryList();
            grd_Category.DataBind();

            dv_Category.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Category_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Category.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Category.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_Category.ChangeMode(DetailsViewMode.Edit);

                CategoryClass objCategory = new CategoryClass();
                objCategory.iID = int.Parse(grd_Category.SelectedDataKey.Value.ToString());
                
                dv_Category.DataSource = objCategory.fn_getCategoryByID();
                dv_Category.DataBind();

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

    protected void grd_Category_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            CategoryClass objCategory = new CategoryClass();

            DataTable dt = (DataTable)ch_Category_List;
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

            grd_Category.DataSource = dv;
            grd_Category.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Category_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_Category.FindControl("txtTitle");
            TextBox txtUrl = (TextBox)dv_Category.FindControl("txtUrl");
            TextBox txtOrderNo = (TextBox)dv_Category.FindControl("txtOrderNo");
            TextBox txtTitleColor = (TextBox)dv_Category.FindControl("txtTitleColor");
            TextBox txtBoxColor = (TextBox)dv_Category.FindControl("txtBoxColor");
            TextBox txtShortDesc = (TextBox)dv_Category.FindControl("txtShortDesc");
            TextBox txtLongDesc = (TextBox)dv_Category.FindControl("txtLongDesc");
            FileUpload fu_SmallImage = (FileUpload)dv_Category.FindControl("fu_SmallImage");
            FileUpload fu_MediumImage = (FileUpload)dv_Category.FindControl("fu_MediumImage");
            FileUpload fu_BigImage = (FileUpload)dv_Category.FindControl("fu_BigImage");
            
            CategoryClass objCategory = new CategoryClass();
            objCategory.iOrderNo = int.Parse(txtOrderNo.Text);
            objCategory.strTitle = txtTitle.Text;
            objCategory.strUrl = txtUrl.Text;
            objCategory.strTitleColorCode = txtTitleColor.Text;
            objCategory.strContentColorCode = txtBoxColor.Text;
            objCategory.strShortDesc = txtShortDesc.Text;
            objCategory.strLongDesc = txtLongDesc.Text;

            if (fu_SmallImage.HasFile)
            {
                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_SmallImage.FileName);
                string strDocPath = Server.MapPath("~/admin/Upload/Category/" + strRanFileName);
                fu_SmallImage.SaveAs(strDocPath);
                objCategory.strSmallImage = strRanFileName;
            }

            if (fu_MediumImage.HasFile)
            {
                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_MediumImage.FileName);
                string strDocPath = Server.MapPath("~/admin/Upload/Category/" + strRanFileName);
                fu_MediumImage.SaveAs(strDocPath);
                objCategory.strMediumImage = strRanFileName;
            }

            if (fu_BigImage.HasFile)
            {
                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_BigImage.FileName);
                string strDocPath = Server.MapPath("~/admin/Upload/Category/" + strRanFileName);
                fu_BigImage.SaveAs(strDocPath);
                objCategory.strBigImage = strRanFileName;
            }

            string strResponse = objCategory.fn_saveCategory();

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

            // Bind Data To grid
            grd_Category.DataSource = objCategory.fn_getCategoryList();
            grd_Category.DataBind();

            // reset fields
            txtTitle.Text = "";
            txtOrderNo.Text = "";
            txtUrl.Text = "";
            txtTitleColor.Text = "";
            txtBoxColor.Text = "";
            txtShortDesc.Text = "";
            txtLongDesc.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Category_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_Category.FindControl("txtTitle");
            TextBox txtUrl = (TextBox)dv_Category.FindControl("txtUrl");
            TextBox txtOrderNo = (TextBox)dv_Category.FindControl("txtOrderNo");
            TextBox txtTitleColor = (TextBox)dv_Category.FindControl("txtTitleColor");
            TextBox txtBoxColor = (TextBox)dv_Category.FindControl("txtBoxColor");
            TextBox txtShortDesc = (TextBox)dv_Category.FindControl("txtShortDesc");
            TextBox txtLongDesc = (TextBox)dv_Category.FindControl("txtLongDesc");
            FileUpload fu_SmallImage = (FileUpload)dv_Category.FindControl("fu_SmallImage");
            FileUpload fu_MediumImage = (FileUpload)dv_Category.FindControl("fu_MediumImage");
            FileUpload fu_BigImage = (FileUpload)dv_Category.FindControl("fu_BigImage");

            CategoryClass objCategory = new CategoryClass();
            objCategory.iID = int.Parse(dv_Category.DataKey.Value.ToString());
            objCategory.iOrderNo = int.Parse(txtOrderNo.Text);
            objCategory.strTitle = txtTitle.Text;
            objCategory.strUrl = txtUrl.Text;
            objCategory.strTitleColorCode = txtTitleColor.Text;
            objCategory.strContentColorCode = txtBoxColor.Text;
            objCategory.strShortDesc = txtShortDesc.Text;
            objCategory.strLongDesc = txtLongDesc.Text;

            CategoryClass oCategory = new CategoryClass();
            oCategory.iID = int.Parse(dv_Category.DataKey.Value.ToString());
            CoreWebList<CategoryClass> oCategoryList = oCategory.fn_getCategoryByID();
            if (oCategoryList.Count > 0)
            {
                if (fu_SmallImage.HasFile)
                {

                    if (File.Exists(MapPath("~/admin/Upload/Category/" + oCategoryList[0].strSmallImage)))
                    {
                        File.Delete((MapPath("~/admin/Upload/Category/" + oCategoryList[0].strSmallImage)));
                    }

                    cls_common objCFC = new cls_common();
                    string strRanFileName = objCFC.file_name(fu_SmallImage.FileName);
                    string strDocPath = Server.MapPath("~/admin/Upload/Category/" + strRanFileName);
                    fu_SmallImage.SaveAs(strDocPath);
                    objCategory.strSmallImage = strRanFileName;
                }
                else
                {
                    objCategory.strSmallImage = oCategoryList[0].strSmallImage;
                }


                if (fu_MediumImage.HasFile)
                {

                    if (File.Exists(MapPath("~/admin/Upload/Category/" + oCategoryList[0].strMediumImage)))
                    {
                        File.Delete((MapPath("~/admin/Upload/Category/" + oCategoryList[0].strMediumImage)));
                    }

                    cls_common objCFC = new cls_common();
                    string strRanFileName = objCFC.file_name(fu_MediumImage.FileName);
                    string strDocPath = Server.MapPath("~/admin/Upload/Category/" + strRanFileName);
                    fu_MediumImage.SaveAs(strDocPath);
                    objCategory.strMediumImage = strRanFileName;
                }
                else
                {
                    objCategory.strMediumImage = oCategoryList[0].strMediumImage;
                }


                if (fu_BigImage.HasFile)
                {

                    if (File.Exists(MapPath("~/admin/Upload/Category/" + oCategoryList[0].strBigImage)))
                    {
                        File.Delete((MapPath("~/admin/Upload/Category/" + oCategoryList[0].strBigImage)));
                    }

                    cls_common objCFC = new cls_common();
                    string strRanFileName = objCFC.file_name(fu_BigImage.FileName);
                    string strDocPath = Server.MapPath("~/admin/Upload/Category/" + strRanFileName);
                    fu_BigImage.SaveAs(strDocPath);
                    objCategory.strBigImage = strRanFileName;
                }
                else
                {
                    objCategory.strBigImage = oCategoryList[0].strBigImage;
                }

            }
            
        

            string strResponse = objCategory.fn_editCategory();

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

            dv_Category.ChangeMode(DetailsViewMode.ReadOnly);

            objCategory.iID = int.Parse(grd_Category.SelectedDataKey.Value.ToString());

            dv_Category.DataSource = objCategory.fn_getCategoryByID();
            dv_Category.DataBind();

            // Bind Data To grid            
            grd_Category.DataSource = objCategory.fn_getCategoryList();
            grd_Category.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Category_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Category.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Category.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Category.ChangeMode(e.NewMode);

                if (grd_Category.SelectedIndex >= 0)
                {
                    CategoryClass objCategory = new CategoryClass();
                    objCategory.iID = int.Parse(grd_Category.SelectedDataKey.Value.ToString());

                    dv_Category.DataSource = objCategory.fn_getCategoryByID();
                    dv_Category.DataBind();
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
            CategoryClass objCategory = new CategoryClass();
            objCategory.strTitle = txtSearch.Text;
            ch_Category_List = objCategory.fn_getCategoryByKeys();

            if (ch_Category_List.Count > 0)
            {
                grd_Category.DataSource = ch_Category_List;
                grd_Category.DataBind();
            }
            else
            {
                grd_Category.DataSource = null;
                grd_Category.DataBind();
            }

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Category_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Featured")
            {
                ImageButton btnFeatured = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnFeatured.Parent.Parent;

                CategoryClass objClassCategory = new CategoryClass();
                objClassCategory.iID = Convert.ToInt32(e.CommandArgument);
                CoreWebList<CategoryClass> objClassCategoryList = objClassCategory.fn_getCategoryByID();
                if (objClassCategoryList.Count > 0)
                {
                    if (objClassCategoryList[0].bShowHome == true)
                    {
                        btnFeatured.ImageUrl = "~/admin/images/cross.gif";
                        objClassCategory.bShowHome = false;
                    }
                    else
                    {
                        btnFeatured.ImageUrl = "~/admin/images/Tick.gif";
                        objClassCategory.bShowHome = true;
                    }
                }

                objClassCategory.fn_ChangeCategoryShowHomeStatus();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Category_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hfFeatured = (HiddenField)e.Row.FindControl("hfFeatured");
                ImageButton btnFeatured = (ImageButton)e.Row.FindControl("btnFeatured");

                if (hfFeatured != null)
                {
                    if (bool.Parse(hfFeatured.Value) == true)
                    {
                        btnFeatured.ImageUrl = "~/admin/images/Tick.gif";
                    }
                    else
                    {
                        btnFeatured.ImageUrl = "~/admin/images/cross.gif";
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
}