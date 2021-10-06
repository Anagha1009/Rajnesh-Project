using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class admin_UniversityDownloads : System.Web.UI.Page
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
                if (Request.QueryString["UniversityID"] != null)
                {
                    DownloadsClass objDwn = new DownloadsClass();
                    //ImagesClass objImc = new ImagesClass();
                    objDwn.strType = "University";
                    objDwn.iTypeID = int.Parse(Request.QueryString["UniversityID"].ToString());
                    grd_Downloads.DataSource = objDwn.fn_getFileByTypeAndTypeID();
                    grd_Downloads.DataBind();
                    if (grd_Downloads.SelectedIndex < 0)
                    {
                        dv_Downloads.ChangeMode(DetailsViewMode.Insert);
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


    protected void grd_Downloads_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Downloads.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Downloads.ChangeMode(DetailsViewMode.Insert);
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
    protected void grd_Downloads_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DownloadsClass objDwn = new DownloadsClass();
            objDwn.iID = int.Parse(grd_Downloads.DataKeys[e.RowIndex].Value.ToString());
            string strResponse = objDwn.fn_deleteFile();

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
            objDwn.strType = "University";
            objDwn.iTypeID = int.Parse(Request.QueryString["UniversityID"].ToString());
            grd_Downloads.DataSource = objDwn.fn_getFileByTypeAndTypeID();
            grd_Downloads.DataBind();

            dv_Downloads.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_Downloads_Sorting(object sender, GridViewSortEventArgs e)
    {
        // Bind Data To grid
        DownloadsClass objDwn = new DownloadsClass();

        objDwn.strType = "University";
        objDwn.iTypeID = int.Parse(Request.QueryString["UniversityID"].ToString());
        DataTable dt = (DataTable)objDwn.fn_getFileByTypeAndTypeID();
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

        grd_Downloads.DataSource = dv;
        grd_Downloads.DataBind();
    }
    protected void grd_Downloads_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DownloadsClass objDwn = new DownloadsClass();
        objDwn.strType = "University";
        objDwn.iTypeID = int.Parse(Request.QueryString["UniversityID"].ToString());
        grd_Downloads.PageIndex = e.NewPageIndex;
        grd_Downloads.DataSource = objDwn.fn_getFileByTypeAndTypeID();
        grd_Downloads.DataBind();
    }
    protected void dv_Downloads_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtFileTitle = (TextBox)dv_Downloads.FindControl("txtFileTitle");
            FileUpload fuFile = (FileUpload)dv_Downloads.FindControl("fuFile");
            

            if (fuFile.HasFile)
            {
                cls_common objCFC = new cls_common();
                //Calling function to get the name of the file with timestamp
                strRanFileName = objCFC.file_name(fuFile.FileName);
                strDocPath = Server.MapPath("~/admin/Downloads/Universities/" + strRanFileName);
                fuFile.SaveAs(strDocPath);
            }
                        
            DownloadsClass objDwn = new DownloadsClass();
            objDwn.iTypeID = int.Parse(Request.QueryString["UniversityID"].ToString());
            objDwn.strType = "University";
            objDwn.strTitle = txtFileTitle.Text;
            objDwn.strFileName = strRanFileName;
            
            if (!IsRefresh)
            {
                string strResponse = objDwn.fn_saveFile();

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
            objDwn.strType = "University";
            objDwn.iTypeID = int.Parse(Request.QueryString["UniversityID"].ToString());
            grd_Downloads.DataSource = objDwn.fn_getFileByTypeAndTypeID();
            grd_Downloads.DataBind();

            // reset fields
            txtFileTitle.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void dv_Downloads_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (dv_Downloads.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
        {
            dv_Downloads.ChangeMode(DetailsViewMode.Insert);
        }
        else
        {
            dv_Downloads.ChangeMode(e.NewMode);

            if (grd_Downloads.SelectedIndex >= 0)
            {
                DownloadsClass objDwn = new DownloadsClass();

                objDwn.iID = int.Parse(grd_Downloads.SelectedDataKey.Value.ToString());
                dv_Downloads.DataSource = objDwn.fn_getFileByID();
                dv_Downloads.DataBind();
            }
        }
    }
}
