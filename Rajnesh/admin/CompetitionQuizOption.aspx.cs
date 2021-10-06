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

public partial class admin_CompetitionQuizOption : System.Web.UI.Page
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
    
	int iQuizID = 0;
    int iCompetionID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;
            
			if (Request.QueryString["QuizID"] != null)
			{
				iQuizID = int.Parse(Request.QueryString["QuizID"].ToString());
			}
			else
			{
				Response.Redirect(VirtualPathUtility.ToAbsolute("~/admin/Quiz.aspx"), true);
			}

            if (!IsPostBack)
            {

                CompetitionQuizClass objQuiz = new CompetitionQuizClass();
                objQuiz.iID = iQuizID;
                CoreWebList<CompetitionQuizClass> objQuizList = objQuiz.fn_getCompetitionQuizByID();
                if (objQuizList.Count > 0)
                {
                    iCompetionID = objQuizList[0].iCompetitionID;
                }
                
                HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
                BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/Competition.aspx") + "'>Competition</a> &nbsp; > &nbsp; &nbsp;<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/CompetitionQuiz.aspx?CompetitionID=" + iCompetionID) + "'>Quiz</a> &nbsp; > &nbsp; &nbsp;Options";

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
            CompetitionQuizOptionClass objCompetitionQuizOption = new CompetitionQuizOptionClass();
			objCompetitionQuizOption.iQuizID = iQuizID;
			CoreWebList<CompetitionQuizOptionClass> objCompetitionQuizOptionList = objCompetitionQuizOption.fn_getCompetitionQuizOptionByQuizID();
			if (objCompetitionQuizOptionList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objCompetitionQuizOptionList;
				grd_Records.DataSource = objCompetitionQuizOptionList;
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
            CompetitionQuizOptionClass objCompetitionQuizOption = new CompetitionQuizOptionClass();
			objCompetitionQuizOption.iID = iRecordID;
			CoreWebList<CompetitionQuizOptionClass> objCompetitionQuizOptionList = objCompetitionQuizOption.fn_getCompetitionQuizOptionByID();
			if (objCompetitionQuizOptionList.Count > 0)
			{
				dv_Records.DataSource = objCompetitionQuizOptionList;
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
            CompetitionQuizOptionClass objCompetitionQuizOption = new CompetitionQuizOptionClass();
			objCompetitionQuizOption.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());

			string strResponse = objCompetitionQuizOption.fn_deleteCompetitionQuizOption();

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
			FileUpload fu_Logo = (FileUpload)dv_Records.FindControl("fu_Logo");

			CompetitionQuizOptionClass objCompetitionQuizOption = new CompetitionQuizOptionClass();
			objCompetitionQuizOption.iQuizID = iQuizID;
			objCompetitionQuizOption.strTitle = txtTitle.Text;

			if (fu_Logo.HasFile)
			{
				cls_common objCFC = new cls_common();
				string strRanFileName = objCFC.file_name(fu_Logo.FileName);
				string strDocPath = Server.MapPath("~/files/CompetitionQuizOption/" + strRanFileName);
				fu_Logo.SaveAs(strDocPath);
				objCompetitionQuizOption.strLogo = strRanFileName;
			}

			string strResponse = objCompetitionQuizOption.fn_saveCompetitionQuizOption();

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
			FileUpload fu_Logo = (FileUpload)dv_Records.FindControl("fu_Logo");
			HiddenField hf_Logo = (HiddenField)dv_Records.FindControl("hf_Logo");

			CompetitionQuizOptionClass objCompetitionQuizOption = new CompetitionQuizOptionClass();
			objCompetitionQuizOption.iID = int.Parse(dv_Records.DataKey.Value.ToString());
			objCompetitionQuizOption.strTitle = txtTitle.Text;

			if (fu_Logo.HasFile)
			{
				CompetitionQuizOptionClass oCompetitionQuizOption = new CompetitionQuizOptionClass();
				oCompetitionQuizOption.iID = int.Parse(dv_Records.DataKey.Value.ToString());
				CoreWebList<CompetitionQuizOptionClass> oCompetitionQuizOptionList = oCompetitionQuizOption.fn_getCompetitionQuizOptionByID();
				if (oCompetitionQuizOptionList.Count > 0)
				{
					if (File.Exists(MapPath("~/files/CompetitionQuizOption/" + oCompetitionQuizOptionList[0].strLogo)))
					{
						File.Delete((MapPath("~/files/CompetitionQuizOption/" + oCompetitionQuizOptionList[0].strLogo)));
					}
					cls_common objCFC = new cls_common();
					string strRanFileName = objCFC.file_name(fu_Logo.FileName);
					string strDocPath = Server.MapPath("~/files/CompetitionQuizOption/" + strRanFileName);
					fu_Logo.SaveAs(strDocPath);
					objCompetitionQuizOption.strLogo = strRanFileName;
				}	
			}
			else
			{
				objCompetitionQuizOption.strLogo = hf_Logo.Value;
			}

			string strResponse = objCompetitionQuizOption.fn_editCompetitionQuizOption();

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
            CompetitionQuizOptionClass objCompetitionQuizOption = new CompetitionQuizOptionClass();
			objCompetitionQuizOption.strTitle = txtSearch.Text.Trim();
			CoreWebList<CompetitionQuizOptionClass> objCompetitionQuizOptionList = objCompetitionQuizOption.fn_getCompetitionQuizOptionByKeys();
			if (objCompetitionQuizOptionList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objCompetitionQuizOptionList;
				grd_Records.DataSource = objCompetitionQuizOptionList;
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
            if (e.CommandName == "Answer")
            {
                string strResponse = "";
                CompetitionQuizOptionClass objCompetitionQuizOption = new CompetitionQuizOptionClass();
                objCompetitionQuizOption.iID = Convert.ToInt32(e.CommandArgument);
                CoreWebList<CompetitionQuizOptionClass> objCompetitionQuizOptionList = objCompetitionQuizOption.fn_getCompetitionQuizOptionByID();
                if (objCompetitionQuizOptionList.Count > 0)
                {
                    ImageButton btnAnswer = (ImageButton)e.CommandSource;
                    GridViewRow objSelectedRow = (GridViewRow)btnAnswer.Parent.Parent;
                    if (objCompetitionQuizOptionList[0].bAnswer == true)
                    {
                        btnAnswer.ImageUrl = "~/admin/images/cross.gif";
                        objCompetitionQuizOption.bAnswer = false;
                    }
                    else
                    {
                        btnAnswer.ImageUrl = "~/admin/images/Tick.gif";
                        objCompetitionQuizOption.bAnswer = true;
                    }
                    strResponse = objCompetitionQuizOption.fn_ChangeCompetitionQuizOptionAnswerStatus();

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
				ImageButton btnAnswer = (ImageButton)e.Row.FindControl("btnAnswer");
				HiddenField hfAnswer = (HiddenField)e.Row.FindControl("hfAnswer");
				if (hfAnswer != null)
				{
					if (bool.Parse(hfAnswer.Value) == true)
					{
						btnAnswer.ImageUrl = "~/admin/images/Tick.gif";
					}
					else
					{
						btnAnswer.ImageUrl = "~/admin/images/cross.gif";
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