using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.IO;
using System.Text;

public partial class admin_Videos : System.Web.UI.Page
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
    
    private CoreWebList<InstituteVideoClass> chInstituteVideoList
    {
        get
        {
            if (Cache["chInstituteVideoList"] != null)
                return (CoreWebList<InstituteVideoClass>)Cache["chInstituteVideoList"];
            return null;
        }
        set
        {
            Cache["chInstituteVideoList"] = value;
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
                InstituteVideoClass objVideo = new InstituteVideoClass();
                objVideo.iInstituteID = InstituteID;
                chInstituteVideoList = objVideo.fn_getInstituteVideoByInstituteID();

                if (chInstituteVideoList.Count > 0)
                {
                    grd_Videos.DataSource = chInstituteVideoList;
                }
                else
                {
                    grd_Videos.DataSource = null;
                }
                grd_Videos.DataBind();

                if (grd_Videos.SelectedIndex < 0)
                {
                    dv_Videos.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Videos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Videos.PageIndex = e.NewPageIndex;
            grd_Videos.DataSource = chInstituteVideoList;
            grd_Videos.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Videos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            InstituteVideoClass objVideo = new InstituteVideoClass();
            objVideo.iID = int.Parse(grd_Videos.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objVideo.fn_deleteInstituteVideo();

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
            objVideo.iInstituteID = InstituteID;
            grd_Videos.DataSource = objVideo.fn_getInstituteVideoByInstituteID();
            grd_Videos.DataBind();

            dv_Videos.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Videos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Videos.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Videos.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_Videos.ChangeMode(DetailsViewMode.Edit);

                InstituteVideoClass objVideo = new InstituteVideoClass();
                objVideo.iID = int.Parse(grd_Videos.SelectedDataKey.Value.ToString());
                
                dv_Videos.DataSource = objVideo.fn_getInstituteVideoByID();
                dv_Videos.DataBind();

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

    protected void grd_Videos_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            InstituteVideoClass objVideo = new InstituteVideoClass();

            DataTable dt = (DataTable)chInstituteVideoList;
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

            grd_Videos.DataSource = dv;
            grd_Videos.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Videos_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_Videos.FindControl("txtTitle");
            TextBox txtUrl = (TextBox)dv_Videos.FindControl("txtUrl");
            
            InstituteVideoClass objVideo = new InstituteVideoClass();
            objVideo.iInstituteID = InstituteID;
            objVideo.strTitle = txtTitle.Text;
            objVideo.strUrl= txtUrl.Text;

            string strResponse = objVideo.fn_saveInstituteVideo();

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
            objVideo.iInstituteID = InstituteID;
            grd_Videos.DataSource = objVideo.fn_getInstituteVideoByInstituteID();
            grd_Videos.DataBind();

            // reset fields
            txtTitle.Text = "";
            txtUrl.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Videos_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            string strResponse = "";

            TextBox txtTitle = (TextBox)dv_Videos.FindControl("txtTitle");
            TextBox txtUrl = (TextBox)dv_Videos.FindControl("txtUrl");

            InstituteVideoClass objVideo = new InstituteVideoClass();
            objVideo.iID = int.Parse(dv_Videos.DataKey.Value.ToString());
            objVideo.iInstituteID = InstituteID;
            objVideo.strTitle = txtTitle.Text;
            objVideo.strUrl = txtUrl.Text;

            strResponse = objVideo.fn_editInstituteVideo();

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

            dv_Videos.ChangeMode(DetailsViewMode.ReadOnly);

            objVideo.iID = int.Parse(grd_Videos.SelectedDataKey.Value.ToString());

            dv_Videos.DataSource = objVideo.fn_getInstituteVideoByID();
            dv_Videos.DataBind();

            // Bind Data To grid           
            objVideo.iInstituteID = InstituteID;
            grd_Videos.DataSource = objVideo.fn_getInstituteVideoByInstituteID();
            grd_Videos.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Videos_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Videos.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Videos.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Videos.ChangeMode(e.NewMode);

                if (grd_Videos.SelectedIndex >= 0)
                {
                    InstituteVideoClass objVideo = new InstituteVideoClass();
                    objVideo.iID = int.Parse(grd_Videos.SelectedDataKey.Value.ToString());

                    dv_Videos.DataSource = objVideo.fn_getInstituteVideoByID();
                    dv_Videos.DataBind();
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
            InstituteVideoClass objVideo = new InstituteVideoClass();
            objVideo.strTitle = txtSearch.Text.Trim();
            chInstituteVideoList = objVideo.fn_getInstituteVideoByKeys();

            if (chInstituteVideoList.Count > 0)
            {
                grd_Videos.DataSource = chInstituteVideoList;
                grd_Videos.DataBind();
            }
            else
            {
                grd_Videos.DataSource = null;
                grd_Videos.DataBind();
            }

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}