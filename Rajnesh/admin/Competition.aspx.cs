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

public partial class admin_Competition : System.Web.UI.Page
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
            BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;Competition";

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
            CompetitionClass objCompetition = new CompetitionClass();
			CoreWebList<CompetitionClass> objCompetitionList = objCompetition.fn_getCompetitionList();
			if (objCompetitionList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objCompetitionList;
				grd_Records.DataSource = objCompetitionList;
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
            CompetitionClass objCompetition = new CompetitionClass();
			objCompetition.iID = iRecordID;
			CoreWebList<CompetitionClass> objCompetitionList = objCompetition.fn_getCompetitionByID();
			if (objCompetitionList.Count > 0)
			{
				dv_Records.DataSource = objCompetitionList;
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
            CompetitionClass objCompetition = new CompetitionClass();
			objCompetition.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());
			CoreWebList<CompetitionClass> objCompetitionList = objCompetition.fn_getCompetitionByID();
			if (objCompetitionList.Count > 0)
			{
				if (File.Exists(MapPath("~/files/Competition/" + objCompetitionList[0].strPhoto)))
				{
					File.Delete((MapPath("~/files/Competition/" + objCompetitionList[0].strPhoto)));
				}
			}

			string strResponse = objCompetition.fn_deleteCompetition();

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
            DropDownList ddl_CompetitionType = (DropDownList)dv_Records.FindControl("ddl_CompetitionType");
			TextBox txtTitle = (TextBox)dv_Records.FindControl("txtTitle");
			TextBox txtShortDetails = (TextBox)dv_Records.FindControl("txtShortDetails");
			TextBox txtDetails = (TextBox)dv_Records.FindControl("txtDetails");
			TextBox txtPrizeDetails = (TextBox)dv_Records.FindControl("txtPrizeDetails");
			TextBox txtBgColor = (TextBox)dv_Records.FindControl("txtBgColor");
			FileUpload fu_Photo = (FileUpload)dv_Records.FindControl("fu_Photo");

			CompetitionClass objCompetition = new CompetitionClass();
            objCompetition.strType = ddl_CompetitionType.SelectedValue;
			objCompetition.strTitle = txtTitle.Text;
			objCompetition.strShortDetails = txtShortDetails.Text;
			objCompetition.strDetails = txtDetails.Text;
			objCompetition.strPrizeDetails = txtPrizeDetails.Text;
			objCompetition.strBgColor = txtBgColor.Text;

			if (fu_Photo.HasFile)
			{
				cls_common objCFC = new cls_common();
				string strRanFileName = objCFC.file_name(fu_Photo.FileName);
				string strDocPath = Server.MapPath("~/files/Competition/" + strRanFileName);
				fu_Photo.SaveAs(strDocPath);
				objCompetition.strPhoto = strRanFileName;
			}

			string strResponse = objCompetition.fn_saveCompetition();

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

            ddl_CompetitionType.SelectedIndex = 0;
			txtTitle.Text = "";
			txtShortDetails.Text = "";
			txtDetails.Text = "";
			txtPrizeDetails.Text = "";
			txtBgColor.Text = "";

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
            DropDownList ddl_CompetitionType = (DropDownList)dv_Records.FindControl("ddl_CompetitionType");
			TextBox txtTitle = (TextBox)dv_Records.FindControl("txtTitle");
			TextBox txtShortDetails = (TextBox)dv_Records.FindControl("txtShortDetails");
			TextBox txtDetails = (TextBox)dv_Records.FindControl("txtDetails");
			TextBox txtPrizeDetails = (TextBox)dv_Records.FindControl("txtPrizeDetails");
			TextBox txtBgColor = (TextBox)dv_Records.FindControl("txtBgColor");
			FileUpload fu_Photo = (FileUpload)dv_Records.FindControl("fu_Photo");
			HiddenField hf_Photo = (HiddenField)dv_Records.FindControl("hf_Photo");

			CompetitionClass objCompetition = new CompetitionClass();
			objCompetition.iID = int.Parse(dv_Records.DataKey.Value.ToString());
            objCompetition.strType = ddl_CompetitionType.SelectedValue;
			objCompetition.strTitle = txtTitle.Text;
			objCompetition.strShortDetails = txtShortDetails.Text;
			objCompetition.strDetails = txtDetails.Text;
			objCompetition.strPrizeDetails = txtPrizeDetails.Text;
			objCompetition.strBgColor = txtBgColor.Text;

			if (fu_Photo.HasFile)
			{
				CompetitionClass oCompetition = new CompetitionClass();
				oCompetition.iID = int.Parse(dv_Records.DataKey.Value.ToString());
				CoreWebList<CompetitionClass> oCompetitionList = oCompetition.fn_getCompetitionByID();
				if (oCompetitionList.Count > 0)
				{
					if (File.Exists(MapPath("~/files/Competition/" + oCompetitionList[0].strPhoto)))
					{
						File.Delete((MapPath("~/files/Competition/" + oCompetitionList[0].strPhoto)));
					}
					cls_common objCFC = new cls_common();
					string strRanFileName = objCFC.file_name(fu_Photo.FileName);
					string strDocPath = Server.MapPath("~/files/Competition/" + strRanFileName);
					fu_Photo.SaveAs(strDocPath);
					objCompetition.strPhoto = strRanFileName;
				}	
			}
			else
			{
				objCompetition.strPhoto = hf_Photo.Value;
			}

			string strResponse = objCompetition.fn_editCompetition();

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
            CompetitionClass objCompetition = new CompetitionClass();
			objCompetition.strTitle = txtSearch.Text.Trim();
			CoreWebList<CompetitionClass> objCompetitionList = objCompetition.fn_getCompetitionByKeys();
			if (objCompetitionList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objCompetitionList;
				grd_Records.DataSource = objCompetitionList;
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

    protected void grd_Records_RowCommand(object sender, GridViewCommandEventArgs e)
	{
        try
        {
            if (e.CommandName == "Active")
            {
                string strResponse = "";
                CompetitionClass objCompetition = new CompetitionClass();
                objCompetition.iID = Convert.ToInt32(e.CommandArgument);
                CoreWebList<CompetitionClass> objCompetitionList = objCompetition.fn_getCompetitionByID();
                if (objCompetitionList.Count > 0)
                {
                    ImageButton btnActive = (ImageButton)e.CommandSource;
                    GridViewRow objSelectedRow = (GridViewRow)btnActive.Parent.Parent;
                    if (objCompetitionList[0].bActive == true)
                    {
                        btnActive.ImageUrl = "~/admin/images/cross.gif";
                        objCompetition.bActive = false;
                    }
                    else
                    {
                        btnActive.ImageUrl = "~/admin/images/Tick.gif";
                        objCompetition.bActive = true;
                    }
                    strResponse = objCompetition.fn_ChangeCompetitionActiveStatus();
                }

                if (strResponse.Contains("SUCCESS"))
                {
                    ((Label)info.FindControl("mssg")).Text = strResponse;
                    info.Visible = true;
                }
                else
                {
                    ((Label)error.FindControl("mssg")).Text = strResponse;
                    error.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
	}

	protected void grd_Records_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				ImageButton btnActive = (ImageButton)e.Row.FindControl("btnActive");
				HiddenField hfActive = (HiddenField)e.Row.FindControl("hfActive");
				if (hfActive != null)
				{
					if (bool.Parse(hfActive.Value) == true)
					{
						btnActive.ImageUrl = "~/admin/images/Tick.gif";
					}
					else
					{
						btnActive.ImageUrl = "~/admin/images/cross.gif";
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

    protected void dv_Records_DataBound(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddl_CompetitionType = (DropDownList)dv_Records.FindControl("ddl_CompetitionType");

            if (dv_Records.CurrentMode == DetailsViewMode.Edit)
            {
                CompetitionClass objCompetition = new CompetitionClass();
                objCompetition.iID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                CoreWebList<CompetitionClass> objCompetitionList = objCompetition.fn_getCompetitionByID();
                if (objCompetitionList.Count > 0)
                {
                    ddl_CompetitionType.SelectedValue = objCompetitionList[0].strType.ToString();
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