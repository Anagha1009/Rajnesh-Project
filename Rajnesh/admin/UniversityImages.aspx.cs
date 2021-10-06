using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;
using System.Data;
using System.IO;

public partial class admin_UniversityImages : System.Web.UI.Page
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

    string strRanFileName1 = string.Empty;
    string strDocPath1 = string.Empty;
    string strOrgFileName1 = string.Empty;


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
                if (Request.QueryString["UniversityID"] != null)
                {
                    ImagesClass objImc = new ImagesClass();
                    objImc.strType = "University";
                    objImc.iTypeID = int.Parse(Request.QueryString["UniversityID"].ToString());
                    grd_Images.DataSource = objImc.fn_getImageByTypeAndTypeID();
                    grd_Images.DataBind();
                    if (grd_Images.SelectedIndex < 0)
                    {
                        dv_Images.ChangeMode(DetailsViewMode.Insert);
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

    protected void grd_Images_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Images.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Images.ChangeMode(DetailsViewMode.Insert);
            }
            //else
            //{
            //    // Edit Mode
            //    dv_Images.ChangeMode(DetailsViewMode.Edit);

            //    ImagesClass objImc = new ImagesClass();
            //    objImc.iID = int.Parse(grd_Images.SelectedDataKey.Value.ToString());
            //    dv_Images.DataSource = objImc.fn_getImageByID();
            //    dv_Images.DataBind();                
            //}
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_Images_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            ImagesClass objImc = new ImagesClass();
            objImc.iID = int.Parse(grd_Images.DataKeys[e.RowIndex].Value.ToString());
            string strResponse = objImc.fn_deleteImage();

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
            objImc.strType = "University";
            objImc.iTypeID = int.Parse(Request.QueryString["UniversityID"].ToString());
            grd_Images.DataSource = objImc.fn_getImageByTypeAndTypeID();
            grd_Images.DataBind();

            dv_Images.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_Images_Sorting(object sender, GridViewSortEventArgs e)
    {
        // Bind Data To grid
        ImagesClass objImc = new ImagesClass();
        objImc.strType = "University";
        objImc.iTypeID = int.Parse(Request.QueryString["UniversityID"].ToString());
        DataTable dt = (DataTable)objImc.fn_getImageByTypeAndTypeID();
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

        grd_Images.DataSource = dv;
        grd_Images.DataBind();
    }
    protected void grd_Images_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ImagesClass objImc = new ImagesClass();
        objImc.strType = "University";
        objImc.iTypeID = int.Parse(Request.QueryString["UniversityID"].ToString());
        grd_Images.PageIndex = e.NewPageIndex;
        grd_Images.DataSource = objImc.fn_getImageByTypeAndTypeID();
        grd_Images.DataBind();
    }
    protected void dv_Images_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtImageTitle = (TextBox)dv_Images.FindControl("txtImageTitle");
            FileUpload fuThumbnailImage = (FileUpload)dv_Images.FindControl("fuThumbnailImage");
            FileUpload fuBigImage = (FileUpload)dv_Images.FindControl("fuBigImage");

            if (fuThumbnailImage.HasFile)
            {
                cls_common objCFC = new cls_common();
                //Calling function to get the name of the file with timestamp
                strRanFileName = objCFC.file_name(fuThumbnailImage.FileName);
                strDocPath = Server.MapPath("~/admin/RelatedImages/Universities/" + strRanFileName);
                fuThumbnailImage.SaveAs(strDocPath);
            }
            if (fuBigImage.HasFile)
            {
                cls_common objCFC = new cls_common();
                //Calling function to get the name of the file with timestamp
                strRanFileName1 = objCFC.file_name(fuBigImage.FileName);
                strDocPath1 = Server.MapPath("~/admin/RelatedImages/Universities/" + strRanFileName1);
                fuBigImage.SaveAs(strDocPath1);
            }
            ImagesClass objImc = new ImagesClass();
            objImc.iTypeID = int.Parse(Request.QueryString["UniversityID"].ToString());
            objImc.strType = "University";
            objImc.strTitle = txtImageTitle.Text;
            objImc.strThumbnail = strRanFileName;
            objImc.strBigImage = strRanFileName1;

            if (!IsRefresh)
            {
                string strResponse = objImc.fn_saveImage();

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
            objImc.strType = "University";
            objImc.iTypeID = int.Parse(Request.QueryString["UniversityID"].ToString());
            grd_Images.DataSource = objImc.fn_getImageByTypeAndTypeID();
            grd_Images.DataBind();

            // reset fields
            txtImageTitle.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    //protected void dv_Images_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    //{
    //    try
    //    {
    //        TextBox txtImageTitle = (TextBox)dv_Images.FindControl("txtImageTitle");
    //        FileUpload fuThumbnailImage = (FileUpload)dv_Images.FindControl("fuThumbnailImage");
    //        FileUpload fuBigImage = (FileUpload)dv_Images.FindControl("fuBigImage");

    //        ImagesClass objImc = new ImagesClass();
    //        objImc.strTitle = txtImageTitle.Text;
    //        objImc.strThumbnail = strRanFileName;
    //        objImc.strBigImage = strOrgFileName1;
    //        objImc.iID = int.Parse(dv_Images.DataKey.Value.ToString());

    //        if (!IsRefresh)
    //        {
    //            string strResponse = string.Empty;
    //            if (fuThumbnailImage.HasFile)
    //            {
    //                DataTable dt = (DataTable)objImc.fn_getImageByID();
    //                strRanFileName = dt.Rows[0]["strThumbnail"].ToString();

    //                if (File.Exists(MapPath("~/admin/RelatedImages/Institutes/" + strRanFileName)))
    //                {
    //                    //Deletes the Image file from the Folder
    //                    File.Delete((MapPath("~/admin/RelatedImages/Institutes/" + strRanFileName)));
    //                }
    //                cls_common objCFC = new cls_common();
    //                //Calling function to get the name of the file with timestamp
    //                strRanFileName = objCFC.file_name(fuThumbnailImage.FileName);
    //                strDocPath = Server.MapPath("~/admin/RelatedImages/Institutes/" + strRanFileName);
    //                fuThumbnailImage.SaveAs(strDocPath);
    //                objImc.strThumbnail = strRanFileName;
    //                strResponse = objImc.fn
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
    //        error.Visible = true;
    //    }

    //}

    protected void dv_Images_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (dv_Images.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
        {
            dv_Images.ChangeMode(DetailsViewMode.Insert);
        }
        else
        {
            dv_Images.ChangeMode(e.NewMode);

            if (grd_Images.SelectedIndex >= 0)
            {
                ImagesClass objImc = new ImagesClass();
                objImc.iID = int.Parse(grd_Images.SelectedDataKey.Value.ToString());
                dv_Images.DataSource = objImc.fn_getImageByID();
                dv_Images.DataBind();
            }
        }
    }
}
