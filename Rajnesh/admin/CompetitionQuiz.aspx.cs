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

public partial class admin_CompetitionQuiz : System.Web.UI.Page
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
    
	int iCompetitionID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;
            
			if (Request.QueryString["CompetitionID"] != null)
			{
				iCompetitionID = int.Parse(Request.QueryString["CompetitionID"].ToString());
			}
			else
			{
				Response.Redirect(VirtualPathUtility.ToAbsolute("~/admin/Competition.aspx"), true);
			}

            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/Competition.aspx") + "'>Competition</a> &nbsp; > &nbsp; &nbsp;Competition Quiz";

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
            CompetitionQuizClass objCompetitionQuiz = new CompetitionQuizClass();
			objCompetitionQuiz.iCompetitionID = iCompetitionID;
			CoreWebList<CompetitionQuizClass> objCompetitionQuizList = objCompetitionQuiz.fn_getCompetitionQuizByCompetitionID();
			if (objCompetitionQuizList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objCompetitionQuizList;
				grd_Records.DataSource = objCompetitionQuizList;
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
            CompetitionQuizClass objCompetitionQuiz = new CompetitionQuizClass();
			objCompetitionQuiz.iID = iRecordID;
			CoreWebList<CompetitionQuizClass> objCompetitionQuizList = objCompetitionQuiz.fn_getCompetitionQuizByID();
			if (objCompetitionQuizList.Count > 0)
			{
				dv_Records.DataSource = objCompetitionQuizList;
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
            CompetitionQuizClass objCompetitionQuiz = new CompetitionQuizClass();
			objCompetitionQuiz.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());
            CoreWebList<CompetitionQuizClass> objCompetitionQuizList = objCompetitionQuiz.fn_getCompetitionQuizByID();
            if (objCompetitionQuizList.Count > 0)
            {
                if (File.Exists(MapPath("~/files/CompetitionIcon/" + objCompetitionQuizList[0].strIcon)))
                {
                    File.Delete((MapPath("~/files/CompetitionIcon/" + objCompetitionQuizList[0].strIcon)));
                }
            }

			string strResponse = objCompetitionQuiz.fn_deleteCompetitionQuiz();

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
            FileUpload fu_Icon = (FileUpload)dv_Records.FindControl("fu_Icon");

			CompetitionQuizClass objCompetitionQuiz = new CompetitionQuizClass();
			objCompetitionQuiz.iCompetitionID = iCompetitionID;
			objCompetitionQuiz.strTitle = txtTitle.Text;

            if (fu_Icon.HasFile)
            {
                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_Icon.FileName);
                string strDocPath = Server.MapPath("~/files/CompetitionIcon/" + strRanFileName);
                fu_Icon.SaveAs(strDocPath);
                objCompetitionQuiz.strIcon = strRanFileName;
            }

			string strResponse = objCompetitionQuiz.fn_saveCompetitionQuiz();

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
            FileUpload fu_Icon = (FileUpload)dv_Records.FindControl("fu_Icon");
            HiddenField hf_Icon = (HiddenField)dv_Records.FindControl("hf_Icon");

			CompetitionQuizClass objCompetitionQuiz = new CompetitionQuizClass();
			objCompetitionQuiz.iID = int.Parse(dv_Records.DataKey.Value.ToString());
			objCompetitionQuiz.strTitle = txtTitle.Text;

            if (fu_Icon.HasFile)
            {
                CompetitionQuizClass oCompetitionQuiz = new CompetitionQuizClass();
                oCompetitionQuiz.iID = int.Parse(dv_Records.DataKey.Value.ToString());
                CoreWebList<CompetitionQuizClass> oCompetitionQuizList = oCompetitionQuiz.fn_getCompetitionQuizByID();
                if (oCompetitionQuizList.Count > 0)
                {
                    if (File.Exists(MapPath("~/files/CompetitionIcon/" + oCompetitionQuizList[0].strIcon)))
                    {
                        File.Delete((MapPath("~/files/CompetitionIcon/" + oCompetitionQuizList[0].strIcon)));
                    }
                    cls_common objCFC = new cls_common();
                    string strRanFileName = objCFC.file_name(fu_Icon.FileName);
                    string strDocPath = Server.MapPath("~/files/CompetitionIcon/" + strRanFileName);
                    fu_Icon.SaveAs(strDocPath);
                    objCompetitionQuiz.strIcon = strRanFileName;
                }
            }
            else
            {
                objCompetitionQuiz.strIcon = hf_Icon.Value;
            }

			string strResponse = objCompetitionQuiz.fn_editCompetitionQuiz();

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
            CompetitionQuizClass objCompetitionQuiz = new CompetitionQuizClass();
			objCompetitionQuiz.strTitle = txtSearch.Text.Trim();
			CoreWebList<CompetitionQuizClass> objCompetitionQuizList = objCompetitionQuiz.fn_getCompetitionQuizByKeys();
			if (objCompetitionQuizList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objCompetitionQuizList;
				grd_Records.DataSource = objCompetitionQuizList;
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