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

public partial class admin_TeamMember : System.Web.UI.Page
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
            TeamMemberClass objTeamMember = new TeamMemberClass();
			CoreWebList<TeamMemberClass> objTeamMemberList = objTeamMember.fn_getTeamMemberList();
			if (objTeamMemberList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objTeamMemberList;
				grd_Records.DataSource = objTeamMemberList;
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
            TeamMemberClass objTeamMember = new TeamMemberClass();
			objTeamMember.iID = iRecordID;
			CoreWebList<TeamMemberClass> objTeamMemberList = objTeamMember.fn_getTeamMemberByID();
			if (objTeamMemberList.Count > 0)
			{
				dv_Records.DataSource = objTeamMemberList;
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
            TeamMemberClass objTeamMember = new TeamMemberClass();
			objTeamMember.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());
			CoreWebList<TeamMemberClass> objTeamMemberList = objTeamMember.fn_getTeamMemberByID();
			if (objTeamMemberList.Count > 0)
			{
				if (File.Exists(MapPath("~/files/TeamMember/" + objTeamMemberList[0].strPhoto)))
				{
					File.Delete((MapPath("~/files/TeamMember/" + objTeamMemberList[0].strPhoto)));
				}
			}

			string strResponse = objTeamMember.fn_deleteTeamMember();

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
			TextBox txtName = (TextBox)dv_Records.FindControl("txtName");
			TextBox txtDesignation = (TextBox)dv_Records.FindControl("txtDesignation");
			TextBox txtDetails = (TextBox)dv_Records.FindControl("txtDetails");
			TextBox txtFacebook = (TextBox)dv_Records.FindControl("txtFacebook");
			TextBox txtTwitter = (TextBox)dv_Records.FindControl("txtTwitter");
			TextBox txtLinkedIn = (TextBox)dv_Records.FindControl("txtLinkedIn");
			TextBox txtGooglePlus = (TextBox)dv_Records.FindControl("txtGooglePlus");
			FileUpload fu_Photo = (FileUpload)dv_Records.FindControl("fu_Photo");

			TeamMemberClass objTeamMember = new TeamMemberClass();
			objTeamMember.strName = txtName.Text;
			objTeamMember.strDesignation = txtDesignation.Text;
			objTeamMember.strDetails = txtDetails.Text;
			objTeamMember.strFacebook = txtFacebook.Text;
			objTeamMember.strTwitter = txtTwitter.Text;
			objTeamMember.strLinkedIn = txtLinkedIn.Text;
			objTeamMember.strGooglePlus = txtGooglePlus.Text;

			if (fu_Photo.HasFile)
			{
				cls_common objCFC = new cls_common();
				string strRanFileName = objCFC.file_name(fu_Photo.FileName);
				string strDocPath = Server.MapPath("~/files/TeamMember/" + strRanFileName);
				fu_Photo.SaveAs(strDocPath);
				objTeamMember.strPhoto = strRanFileName;
			}

			string strResponse = objTeamMember.fn_saveTeamMember();

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

			txtName.Text = "";
			txtDesignation.Text = "";
			txtDetails.Text = "";
			txtFacebook.Text = "";
			txtTwitter.Text = "";
			txtLinkedIn.Text = "";
			txtGooglePlus.Text = "";

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
			TextBox txtName = (TextBox)dv_Records.FindControl("txtName");
			TextBox txtDesignation = (TextBox)dv_Records.FindControl("txtDesignation");
			TextBox txtDetails = (TextBox)dv_Records.FindControl("txtDetails");
			TextBox txtFacebook = (TextBox)dv_Records.FindControl("txtFacebook");
			TextBox txtTwitter = (TextBox)dv_Records.FindControl("txtTwitter");
			TextBox txtLinkedIn = (TextBox)dv_Records.FindControl("txtLinkedIn");
			TextBox txtGooglePlus = (TextBox)dv_Records.FindControl("txtGooglePlus");
			FileUpload fu_Photo = (FileUpload)dv_Records.FindControl("fu_Photo");
			HiddenField hf_Photo = (HiddenField)dv_Records.FindControl("hf_Photo");

			TeamMemberClass objTeamMember = new TeamMemberClass();
			objTeamMember.iID = int.Parse(dv_Records.DataKey.Value.ToString());
			objTeamMember.strName = txtName.Text;
			objTeamMember.strDesignation = txtDesignation.Text;
			objTeamMember.strDetails = txtDetails.Text;
			objTeamMember.strFacebook = txtFacebook.Text;
			objTeamMember.strTwitter = txtTwitter.Text;
			objTeamMember.strLinkedIn = txtLinkedIn.Text;
			objTeamMember.strGooglePlus = txtGooglePlus.Text;

			if (fu_Photo.HasFile)
			{
				TeamMemberClass oTeamMember = new TeamMemberClass();
				oTeamMember.iID = int.Parse(dv_Records.DataKey.Value.ToString());
				CoreWebList<TeamMemberClass> oTeamMemberList = oTeamMember.fn_getTeamMemberByID();
				if (oTeamMemberList.Count > 0)
				{
					if (File.Exists(MapPath("~/files/TeamMember/" + oTeamMemberList[0].strPhoto)))
					{
						File.Delete((MapPath("~/files/TeamMember/" + oTeamMemberList[0].strPhoto)));
					}
					cls_common objCFC = new cls_common();
					string strRanFileName = objCFC.file_name(fu_Photo.FileName);
					string strDocPath = Server.MapPath("~/files/TeamMember/" + strRanFileName);
					fu_Photo.SaveAs(strDocPath);
					objTeamMember.strPhoto = strRanFileName;
				}	
			}
			else
			{
				objTeamMember.strPhoto = hf_Photo.Value;
			}

			string strResponse = objTeamMember.fn_editTeamMember();

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
            TeamMemberClass objTeamMember = new TeamMemberClass();
			objTeamMember.strName = txtSearch.Text.Trim();
			CoreWebList<TeamMemberClass> objTeamMemberList = objTeamMember.fn_getTeamMemberByKeys();
			if (objTeamMemberList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objTeamMemberList;
				grd_Records.DataSource = objTeamMemberList;
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