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

public partial class admin_BannerDetail : System.Web.UI.Page
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
    
	int iBannerID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;
            
			if (Request.QueryString["BannerID"] != null)
			{
				iBannerID = int.Parse(Request.QueryString["BannerID"].ToString());
			}
			else
			{
				Response.Redirect(VirtualPathUtility.ToAbsolute("~/admin/Banner.aspx"), true);
			}

            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;BannerDetail";

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
            BannerDetailClass objBannerDetail = new BannerDetailClass();
			objBannerDetail.iBannerID = iBannerID;
			CoreWebList<BannerDetailClass> objBannerDetailList = objBannerDetail.fn_getBannerDetailByBannerID();
			if (objBannerDetailList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objBannerDetailList;
				grd_Records.DataSource = objBannerDetailList;
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
            BannerDetailClass objBannerDetail = new BannerDetailClass();
			objBannerDetail.iID = iRecordID;
			CoreWebList<BannerDetailClass> objBannerDetailList = objBannerDetail.fn_getBannerDetailByID();
			if (objBannerDetailList.Count > 0)
			{
				dv_Records.DataSource = objBannerDetailList;
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
            BannerDetailClass objBannerDetail = new BannerDetailClass();
			objBannerDetail.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());
			CoreWebList<BannerDetailClass> objBannerDetailList = objBannerDetail.fn_getBannerDetailByID();
			if (objBannerDetailList.Count > 0)
			{
				if (File.Exists(MapPath("~/files/BannerDetail/" + objBannerDetailList[0].strPhoto)))
				{
					File.Delete((MapPath("~/files/BannerDetail/" + objBannerDetailList[0].strPhoto)));
				}
			}

			string strResponse = objBannerDetail.fn_deleteBannerDetail();

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
			TextBox txtOrder = (TextBox)dv_Records.FindControl("txtOrder");
			TextBox txtTitle = (TextBox)dv_Records.FindControl("txtTitle");
			TextBox txtDetails = (TextBox)dv_Records.FindControl("txtDetails");
			TextBox txtLink = (TextBox)dv_Records.FindControl("txtLink");
			FileUpload fu_Photo = (FileUpload)dv_Records.FindControl("fu_Photo");

			BannerDetailClass objBannerDetail = new BannerDetailClass();
			objBannerDetail.iBannerID = iBannerID;
			objBannerDetail.iOrder = int.Parse(txtOrder.Text);
			objBannerDetail.strTitle = txtTitle.Text;
			objBannerDetail.strDetails = txtDetails.Text;
			objBannerDetail.strLink = txtLink.Text;

			if (fu_Photo.HasFile)
			{
				cls_common objCFC = new cls_common();
				string strRanFileName = objCFC.file_name(fu_Photo.FileName);
				string strDocPath = Server.MapPath("~/files/BannerDetail/" + strRanFileName);
				fu_Photo.SaveAs(strDocPath);
				objBannerDetail.strPhoto = strRanFileName;
			}

			string strResponse = objBannerDetail.fn_saveBannerDetail();

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

			txtOrder.Text = "";
			txtTitle.Text = "";
			txtDetails.Text = "";
			txtLink.Text = "";

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
			TextBox txtOrder = (TextBox)dv_Records.FindControl("txtOrder");
			TextBox txtTitle = (TextBox)dv_Records.FindControl("txtTitle");
			TextBox txtDetails = (TextBox)dv_Records.FindControl("txtDetails");
			TextBox txtLink = (TextBox)dv_Records.FindControl("txtLink");
			FileUpload fu_Photo = (FileUpload)dv_Records.FindControl("fu_Photo");
			HiddenField hf_Photo = (HiddenField)dv_Records.FindControl("hf_Photo");

			BannerDetailClass objBannerDetail = new BannerDetailClass();
			objBannerDetail.iID = int.Parse(dv_Records.DataKey.Value.ToString());
			objBannerDetail.iOrder = int.Parse(txtOrder.Text);
			objBannerDetail.strTitle = txtTitle.Text;
			objBannerDetail.strDetails = txtDetails.Text;
			objBannerDetail.strLink = txtLink.Text;

			if (fu_Photo.HasFile)
			{
				BannerDetailClass oBannerDetail = new BannerDetailClass();
				oBannerDetail.iID = int.Parse(dv_Records.DataKey.Value.ToString());
				CoreWebList<BannerDetailClass> oBannerDetailList = oBannerDetail.fn_getBannerDetailByID();
				if (oBannerDetailList.Count > 0)
				{
					if (File.Exists(MapPath("~/files/BannerDetail/" + oBannerDetailList[0].strPhoto)))
					{
						File.Delete((MapPath("~/files/BannerDetail/" + oBannerDetailList[0].strPhoto)));
					}
					cls_common objCFC = new cls_common();
					string strRanFileName = objCFC.file_name(fu_Photo.FileName);
					string strDocPath = Server.MapPath("~/files/BannerDetail/" + strRanFileName);
					fu_Photo.SaveAs(strDocPath);
					objBannerDetail.strPhoto = strRanFileName;
				}	
			}
			else
			{
				objBannerDetail.strPhoto = hf_Photo.Value;
			}

			string strResponse = objBannerDetail.fn_editBannerDetail();

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
            BannerDetailClass objBannerDetail = new BannerDetailClass();
			objBannerDetail.strTitle = txtSearch.Text.Trim();
			CoreWebList<BannerDetailClass> objBannerDetailList = objBannerDetail.fn_getBannerDetailByKeys();
			if (objBannerDetailList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objBannerDetailList;
				grd_Records.DataSource = objBannerDetailList;
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