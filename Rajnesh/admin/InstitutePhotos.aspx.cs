﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.IO;
using System.Text;

public partial class admin_Photos : System.Web.UI.Page
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
    
    private CoreWebList<InstitutePhotoClass> chInstitutePhotoList
    {
        get
        {
            if (Cache["chInstitutePhotoList"] != null)
                return (CoreWebList<InstitutePhotoClass>)Cache["chInstitutePhotoList"];
            return null;
        }
        set
        {
            Cache["chInstitutePhotoList"] = value;
        }
    }

    int InstituteID = 0;

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

            if (Request.QueryString["InstituteID"] != null)
            {
                InstituteID=int.Parse(Request.QueryString["InstituteID"].ToString());
            }

            if (!IsPostBack)
            {
                // Bind Data To grid
                InstitutePhotoClass objPhotos = new InstitutePhotoClass();
                objPhotos.iInstituteID = InstituteID;
                chInstitutePhotoList = objPhotos.fn_getInstitutePhotoByInstituteID();

                if (chInstitutePhotoList.Count > 0)
                {
                    grd_Photos.DataSource = chInstitutePhotoList;
                }
                else
                {
                    grd_Photos.DataSource = null;
                }
                grd_Photos.DataBind();

                if (grd_Photos.SelectedIndex < 0)
                {
                    dv_Photos.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Photos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Photos.PageIndex = e.NewPageIndex;
            grd_Photos.DataSource = chInstitutePhotoList;
            grd_Photos.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Photos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            InstitutePhotoClass objPhotos = new InstitutePhotoClass();
            objPhotos.iID = int.Parse(grd_Photos.DataKeys[e.RowIndex].Value.ToString());

            CoreWebList<InstitutePhotoClass> objCityPhotoList = objPhotos.fn_getInstitutePhotoByID();
            if (objCityPhotoList.Count > 0)
            {
                if (File.Exists(MapPath("~/admin/Upload/Institutes/" + objCityPhotoList[0].strPhoto)))
                {
                    File.Delete((MapPath("~/admin/Upload/Institutes/" + objCityPhotoList[0].strPhoto)));
                }
            }

            string strResponse = objPhotos.fn_deleteInstitutePhoto();

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
            objPhotos.iInstituteID = InstituteID;
            grd_Photos.DataSource = objPhotos.fn_getInstitutePhotoByInstituteID();
            grd_Photos.DataBind();

            dv_Photos.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Photos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Photos.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Photos.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_Photos.ChangeMode(DetailsViewMode.Edit);

                InstitutePhotoClass objPhotos = new InstitutePhotoClass();
                objPhotos.iID = int.Parse(grd_Photos.SelectedDataKey.Value.ToString());
                
                dv_Photos.DataSource = objPhotos.fn_getInstitutePhotoByID();
                dv_Photos.DataBind();

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

    protected void grd_Photos_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            InstitutePhotoClass objPhotos = new InstitutePhotoClass();

            DataTable dt = (DataTable)chInstitutePhotoList;
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

            grd_Photos.DataSource = dv;
            grd_Photos.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Photos_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_Photos.FindControl("txtTitle");
            FileUpload fu_Image = (FileUpload)dv_Photos.FindControl("fu_Image");
            
            InstitutePhotoClass objPhotos = new InstitutePhotoClass();
            objPhotos.iInstituteID = InstituteID;
            objPhotos.strTitle = txtTitle.Text;

            if (fu_Image.HasFile)
            {
                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_Image.FileName);
                string strDocPath = Server.MapPath("~/admin/Upload/Institutes/" + strRanFileName);
                fu_Image.SaveAs(strDocPath);
                objPhotos.strPhoto = strRanFileName;
            }

            string strResponse = objPhotos.fn_saveInstitutePhoto();

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
            objPhotos.iInstituteID = InstituteID;
            grd_Photos.DataSource = objPhotos.fn_getInstitutePhotoByInstituteID();
            grd_Photos.DataBind();

            // reset fields
            txtTitle.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Photos_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            string strResponse = "";

            TextBox txtTitle = (TextBox)dv_Photos.FindControl("txtTitle");
            FileUpload fu_Image = (FileUpload)dv_Photos.FindControl("fu_Image");
            HiddenField hfImage = (HiddenField)dv_Photos.FindControl("hfImage");

            InstitutePhotoClass objPhotos = new InstitutePhotoClass();
            objPhotos.iID = int.Parse(dv_Photos.DataKey.Value.ToString());
            objPhotos.iInstituteID = InstituteID;
            objPhotos.strTitle = txtTitle.Text;

            if (fu_Image.HasFile)
            {
                InstitutePhotoClass objCityPhoto = new InstitutePhotoClass();
                objCityPhoto.iID = int.Parse(dv_Photos.DataKey.Value.ToString());
                CoreWebList<InstitutePhotoClass> objCityPhotoList = objCityPhoto.fn_getInstitutePhotoByID();
                if (objCityPhotoList.Count > 0)
                {
                    if (File.Exists(MapPath("~/admin/Upload/Institutes/" + objCityPhotoList[0].strPhoto)))
                    {
                        File.Delete((MapPath("~/admin/Upload/Institutes/" + objCityPhotoList[0].strPhoto)));
                    }
                }

                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_Image.FileName);
                string strDocPath = Server.MapPath("~/admin/Upload/Institutes/" + strRanFileName);
                fu_Image.SaveAs(strDocPath);
                objPhotos.strPhoto = strRanFileName;
            }
            else
            {
                objPhotos.strPhoto = hfImage.Value;
            }

            strResponse = objPhotos.fn_editInstitutePhoto();

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

            dv_Photos.ChangeMode(DetailsViewMode.ReadOnly);

            objPhotos.iID = int.Parse(grd_Photos.SelectedDataKey.Value.ToString());

            dv_Photos.DataSource = objPhotos.fn_getInstitutePhotoByID();
            dv_Photos.DataBind();

            // Bind Data To grid           
            objPhotos.iInstituteID = InstituteID;
            grd_Photos.DataSource = objPhotos.fn_getInstitutePhotoByInstituteID();
            grd_Photos.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Photos_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Photos.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Photos.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Photos.ChangeMode(e.NewMode);

                if (grd_Photos.SelectedIndex >= 0)
                {
                    InstitutePhotoClass objPhotos = new InstitutePhotoClass();
                    objPhotos.iID = int.Parse(grd_Photos.SelectedDataKey.Value.ToString());

                    dv_Photos.DataSource = objPhotos.fn_getInstitutePhotoByID();
                    dv_Photos.DataBind();
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
            InstitutePhotoClass objPhotos = new InstitutePhotoClass();
            objPhotos.strTitle = txtSearch.Text.Trim();
            chInstitutePhotoList = objPhotos.fn_getInstitutePhotoByKeys();

            if (chInstitutePhotoList.Count > 0)
            {
                grd_Photos.DataSource = chInstitutePhotoList;
                grd_Photos.DataBind();
            }
            else
            {
                grd_Photos.DataSource = null;
                grd_Photos.DataBind();
            }

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}