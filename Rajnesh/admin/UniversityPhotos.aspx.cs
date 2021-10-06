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

public partial class admin_UniversityPhoto : System.Web.UI.Page
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
    
	int iUniversityID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;
            
			if (Request.QueryString["UniversityID"] != null)
			{
				iUniversityID = int.Parse(Request.QueryString["UniversityID"].ToString());
			}
			else
			{
				Response.Redirect(VirtualPathUtility.ToAbsolute("~/admin/University.aspx"), true);
			}

            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;UniversityPhoto";

            if (!IsPostBack)
            {
                fn_BindRecords();

                if (grd_Records.SelectedIndex < 0)
                {
                    dv_Records.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void fn_BindRecords()
    {
        try
        {
            UniversityPhotoClass objUniversityPhoto = new UniversityPhotoClass();
			objUniversityPhoto.iUniversityID = iUniversityID;
			CoreWebList<UniversityPhotoClass> objUniversityPhotoList = objUniversityPhoto.fn_getUniversityPhotoByUniversityID();
			if (objUniversityPhotoList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objUniversityPhotoList;
				grd_Records.DataSource = objUniversityPhotoList;
			}
			else
			{
				grd_Records.DataSource = null;
			}
			grd_Records.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void fn_BindDetails(int iRecordID)
    {
        try
        {
            UniversityPhotoClass objUniversityPhoto = new UniversityPhotoClass();
			objUniversityPhoto.iID = iRecordID;
			CoreWebList<UniversityPhotoClass> objUniversityPhotoList = objUniversityPhoto.fn_getUniversityPhotoByID();
			if (objUniversityPhotoList.Count > 0)
			{
				dv_Records.DataSource = objUniversityPhotoList;
				dv_Records.DataBind();
			}
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Records_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (ViewState["dtRecords"] != null)
            {
                DataTable dtRecords = (DataTable)ViewState["dtRecords"];
                grd_Records.PageIndex = e.NewPageIndex;
                grd_Records.DataSource = dtRecords;
                grd_Records.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Records_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            UniversityPhotoClass objUniversityPhoto = new UniversityPhotoClass();
			objUniversityPhoto.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());
			CoreWebList<UniversityPhotoClass> objUniversityPhotoList = objUniversityPhoto.fn_getUniversityPhotoByID();
			if (objUniversityPhotoList.Count > 0)
			{
				if (File.Exists(MapPath("~/files/UniversityPhoto/" + objUniversityPhotoList[0].strPhoto)))
				{
					File.Delete((MapPath("~/files/UniversityPhoto/" + objUniversityPhotoList[0].strPhoto)));
				}
			}

			string strResponse = objUniversityPhoto.fn_deleteUniversityPhoto();

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

			fn_BindRecords();
			dv_Records.ChangeMode(DetailsViewMode.Insert);

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Records_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Records.SelectedIndex < 0)
            {
                dv_Records.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Records.ChangeMode(DetailsViewMode.Edit);
                int iRecordID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                fn_BindDetails(iRecordID);

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

    protected void grd_Records_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (ViewState["dtRecords"] != null)
            {
                DataTable dtRecords = (DataTable)ViewState["dtRecords"];
                DataView dv = new DataView(dtRecords);

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

                grd_Records.DataSource = dv;
                grd_Records.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Records_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
			TextBox txtTitle = (TextBox)dv_Records.FindControl("txtTitle");
			FileUpload fu_Photo = (FileUpload)dv_Records.FindControl("fu_Photo");

			UniversityPhotoClass objUniversityPhoto = new UniversityPhotoClass();
			objUniversityPhoto.iUniversityID = iUniversityID;
			objUniversityPhoto.strTitle = txtTitle.Text;

			if (fu_Photo.HasFile)
			{
				cls_common objCFC = new cls_common();
				string strRanFileName = objCFC.file_name(fu_Photo.FileName);
				string strDocPath = Server.MapPath("~/files/UniversityPhoto/" + strRanFileName);
				fu_Photo.SaveAs(strDocPath);
				objUniversityPhoto.strPhoto = strRanFileName;
			}

			string strResponse = objUniversityPhoto.fn_saveUniversityPhoto();

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

			fn_BindRecords();

			txtTitle.Text = "";

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Records_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
			TextBox txtTitle = (TextBox)dv_Records.FindControl("txtTitle");
			FileUpload fu_Photo = (FileUpload)dv_Records.FindControl("fu_Photo");
			HiddenField hf_Photo = (HiddenField)dv_Records.FindControl("hf_Photo");

			UniversityPhotoClass objUniversityPhoto = new UniversityPhotoClass();
			objUniversityPhoto.iID = int.Parse(dv_Records.DataKey.Value.ToString());
			objUniversityPhoto.strTitle = txtTitle.Text;

			if (fu_Photo.HasFile)
			{
				UniversityPhotoClass oUniversityPhoto = new UniversityPhotoClass();
				oUniversityPhoto.iID = int.Parse(dv_Records.DataKey.Value.ToString());
				CoreWebList<UniversityPhotoClass> oUniversityPhotoList = oUniversityPhoto.fn_getUniversityPhotoByID();
				if (oUniversityPhotoList.Count > 0)
				{
					if (File.Exists(MapPath("~/files/UniversityPhoto/" + oUniversityPhotoList[0].strPhoto)))
					{
						File.Delete((MapPath("~/files/UniversityPhoto/" + oUniversityPhotoList[0].strPhoto)));
					}
					cls_common objCFC = new cls_common();
					string strRanFileName = objCFC.file_name(fu_Photo.FileName);
					string strDocPath = Server.MapPath("~/files/UniversityPhoto/" + strRanFileName);
					fu_Photo.SaveAs(strDocPath);
					objUniversityPhoto.strPhoto = strRanFileName;
				}	
			}
			else
			{
				objUniversityPhoto.strPhoto = hf_Photo.Value;
			}

			string strResponse = objUniversityPhoto.fn_editUniversityPhoto();

			if (strResponse.StartsWith("SUCCESS"))
			{				((Label)info.FindControl("mssg")).Text = strResponse;
				info.Visible = true;
			}
			else
			{
				((Label)error.FindControl("mssg")).Text = strResponse;
				error.Visible = true;
			}

			dv_Records.ChangeMode(DetailsViewMode.ReadOnly);
			int iRecordID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
			fn_BindDetails(iRecordID);
			fn_BindRecords();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Records_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Records.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Records.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Records.ChangeMode(e.NewMode);

                if (grd_Records.SelectedIndex >= 0)
                {
                    int iRecordID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                    fn_BindDetails(iRecordID);
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
            UniversityPhotoClass objUniversityPhoto = new UniversityPhotoClass();
			objUniversityPhoto.strTitle = txtSearch.Text.Trim();
			CoreWebList<UniversityPhotoClass> objUniversityPhotoList = objUniversityPhoto.fn_getUniversityPhotoByKeys();
			if (objUniversityPhotoList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objUniversityPhotoList;
				grd_Records.DataSource = objUniversityPhotoList;
			}
			else
			{
				grd_Records.DataSource = null;
			}
			grd_Records.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    
}