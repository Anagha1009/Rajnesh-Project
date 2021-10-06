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

public partial class admin_Vote : System.Web.UI.Page
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
            VoteClass objVote = new VoteClass();
			CoreWebList<VoteClass> objVoteList = objVote.fn_getVoteList();
			if (objVoteList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objVoteList;
				grd_Records.DataSource = objVoteList;
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
            VoteClass objVote = new VoteClass();
			objVote.iID = iRecordID;
			CoreWebList<VoteClass> objVoteList = objVote.fn_getVoteByID();
			if (objVoteList.Count > 0)
			{
				dv_Records.DataSource = objVoteList;
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
            VoteClass objVote = new VoteClass();
			objVote.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());
            CoreWebList<VoteClass> objVoteList = objVote.fn_getVoteByID();
            if (objVoteList.Count > 0)
            {
                if (File.Exists(MapPath("~/files/Votes/" + objVoteList[0].strIcon)))
                {
                    File.Delete((MapPath("~/files/Votes/" + objVoteList[0].strIcon)));
                }
            }
			
            string strResponse = objVote.fn_deleteVote();

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
            TextBox txtUrl = (TextBox)dv_Records.FindControl("txtUrl");
            FileUpload fu_Icon = (FileUpload)dv_Records.FindControl("fu_Icon");

			VoteClass objVote = new VoteClass();
			objVote.strTitle = txtTitle.Text;
            objVote.strUrl = txtUrl.Text;

            if (fu_Icon.HasFile)
            {
                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_Icon.FileName);
                string strDocPath = Server.MapPath("~/files/Votes/" + strRanFileName);
                fu_Icon.SaveAs(strDocPath);
                objVote.strIcon = strRanFileName;
            }

			string strResponse = objVote.fn_saveVote();

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
            TextBox txtUrl = (TextBox)dv_Records.FindControl("txtUrl");
            FileUpload fu_Icon = (FileUpload)dv_Records.FindControl("fu_Icon");
            HiddenField hf_Icon = (HiddenField)dv_Records.FindControl("hf_Icon");

			VoteClass objVote = new VoteClass();
			objVote.iID = int.Parse(dv_Records.DataKey.Value.ToString());
			objVote.strTitle = txtTitle.Text;
            objVote.strUrl = txtUrl.Text;

            if (fu_Icon.HasFile)
            {
                VoteClass oVote = new VoteClass();
                oVote.iID = int.Parse(dv_Records.DataKey.Value.ToString());
                CoreWebList<VoteClass> oVoteList = oVote.fn_getVoteByID();
                if (oVoteList.Count > 0)
                {
                    if (File.Exists(MapPath("~/files/Votes/" + oVoteList[0].strIcon)))
                    {
                        File.Delete((MapPath("~/files/Votes/" + oVoteList[0].strIcon)));
                    }
                    cls_common objCFC = new cls_common();
                    string strRanFileName = objCFC.file_name(fu_Icon.FileName);
                    string strDocPath = Server.MapPath("~/files/Votes/" + strRanFileName);
                    fu_Icon.SaveAs(strDocPath);
                    objVote.strIcon = strRanFileName;
                }
            }
            else
            {
                objVote.strIcon = hf_Icon.Value;
            }
			
			string strResponse = objVote.fn_editVote();

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
            VoteClass objVote = new VoteClass();
			objVote.strTitle = txtSearch.Text.Trim();
			CoreWebList<VoteClass> objVoteList = objVote.fn_getVoteByKeys();
			if (objVoteList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objVoteList;
				grd_Records.DataSource = objVoteList;
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
                VoteClass objVote = new VoteClass();
                objVote.iID = Convert.ToInt32(e.CommandArgument);
                CoreWebList<VoteClass> objVoteList = objVote.fn_getVoteByID();
                if (objVoteList.Count > 0)
                {

                    ImageButton btnActive = (ImageButton)e.CommandSource;
                    GridViewRow objSelectedRow = (GridViewRow)btnActive.Parent.Parent;
                    if (objVoteList[0].bActive == true)
                    {
                        btnActive.ImageUrl = "~/admin/images/cross.gif";
                        objVote.bActive = false;
                    }
                    else
                    {
                        btnActive.ImageUrl = "~/admin/images/Tick.gif";
                        objVote.bActive = true;
                    }
                    strResponse = objVote.fn_ChangeVoteActiveStatus();

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
}