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

public partial class admin_Ebook : System.Web.UI.Page
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
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;
            
            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;Ebook";

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
            EbookClass objEbook = new EbookClass();
			CoreWebList<EbookClass> objEbookList = objEbook.fn_getEbookList();
			if (objEbookList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objEbookList;
				grd_Records.DataSource = objEbookList;
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
            EbookClass objEbook = new EbookClass();
			objEbook.iID = iRecordID;
			CoreWebList<EbookClass> objEbookList = objEbook.fn_getEbookByID();
			if (objEbookList.Count > 0)
			{
				dv_Records.DataSource = objEbookList;
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
            EbookClass objEbook = new EbookClass();
			objEbook.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());
			CoreWebList<EbookClass> objEbookList = objEbook.fn_getEbookByID();
			if (objEbookList.Count > 0)
			{
				if (File.Exists(MapPath("~/files/Ebook/" + objEbookList[0].strFile)))
				{
					File.Delete((MapPath("~/files/Ebook/" + objEbookList[0].strFile)));
				}
			}

			string strResponse = objEbook.fn_deleteEbook();

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
			TextBox txtDetails = (TextBox)dv_Records.FindControl("txtDetails");
			FileUpload fu_File = (FileUpload)dv_Records.FindControl("fu_File");

			EbookClass objEbook = new EbookClass();
			objEbook.strTitle = txtTitle.Text;
			objEbook.strDetails = txtDetails.Text;

			if (fu_File.HasFile)
			{
				cls_common objCFC = new cls_common();
				string strRanFileName = objCFC.file_name(fu_File.FileName);
				string strDocPath = Server.MapPath("~/files/Ebook/" + strRanFileName);
				fu_File.SaveAs(strDocPath);
				objEbook.strFile = strRanFileName;
			}

			string strResponse = objEbook.fn_saveEbook();

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
			txtDetails.Text = "";

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
			TextBox txtDetails = (TextBox)dv_Records.FindControl("txtDetails");
			FileUpload fu_File = (FileUpload)dv_Records.FindControl("fu_File");
			HiddenField hf_File = (HiddenField)dv_Records.FindControl("hf_File");

			EbookClass objEbook = new EbookClass();
			objEbook.iID = int.Parse(dv_Records.DataKey.Value.ToString());
			objEbook.strTitle = txtTitle.Text;
			objEbook.strDetails = txtDetails.Text;

			if (fu_File.HasFile)
			{
				EbookClass oEbook = new EbookClass();
				oEbook.iID = int.Parse(dv_Records.DataKey.Value.ToString());
				CoreWebList<EbookClass> oEbookList = oEbook.fn_getEbookByID();
				if (oEbookList.Count > 0)
				{
					if (File.Exists(MapPath("~/files/Ebook/" + oEbookList[0].strFile)))
					{
						File.Delete((MapPath("~/files/Ebook/" + oEbookList[0].strFile)));
					}
					cls_common objCFC = new cls_common();
					string strRanFileName = objCFC.file_name(fu_File.FileName);
					string strDocPath = Server.MapPath("~/files/Ebook/" + strRanFileName);
					fu_File.SaveAs(strDocPath);
					objEbook.strFile = strRanFileName;
				}	
			}
			else
			{
				objEbook.strFile = hf_File.Value;
			}

			string strResponse = objEbook.fn_editEbook();

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
            EbookClass objEbook = new EbookClass();
			objEbook.strTitle = txtSearch.Text.Trim();
			CoreWebList<EbookClass> objEbookList = objEbook.fn_getEbookByKeys();
			if (objEbookList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objEbookList;
				grd_Records.DataSource = objEbookList;
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