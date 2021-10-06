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

public partial class admin_University : System.Web.UI.Page
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

    int CountryID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;
            
			if (Request.QueryString["CountryID"] != null)
			{
                CountryID = int.Parse(Request.QueryString["CountryID"].ToString());
			}
			else
			{
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/admin/Country.aspx"), true);
			}

            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;University";

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
            UniversityClass objUniversity = new UniversityClass();
            objUniversity.iCountryID = CountryID;
			CoreWebList<UniversityClass> objUniversityList = objUniversity.fn_getUniversityByCountryID();
			if (objUniversityList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objUniversityList;
				grd_Records.DataSource = objUniversityList;
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
            UniversityClass objUniversity = new UniversityClass();
			objUniversity.iID = iRecordID;
			CoreWebList<UniversityClass> objUniversityList = objUniversity.fn_getUniversityByID();
			if (objUniversityList.Count > 0)
			{
				dv_Records.DataSource = objUniversityList;
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
            UniversityClass objUniversity = new UniversityClass();
			objUniversity.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());

			string strResponse = objUniversity.fn_deleteUniversity();

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
			TextBox txtEstablishedIn = (TextBox)dv_Records.FindControl("txtEstablishedIn");
			TextBox txtAffiliatedTo = (TextBox)dv_Records.FindControl("txtAffiliatedTo");
			TextBox txtAdmissions = (TextBox)dv_Records.FindControl("txtAdmissions");
			TextBox txtInfraucture = (TextBox)dv_Records.FindControl("txtInfraucture");
			TextBox txtPlacements = (TextBox)dv_Records.FindControl("txtPlacements");
			TextBox txtRanking = (TextBox)dv_Records.FindControl("txtRanking");
			TextBox txtContactDetails = (TextBox)dv_Records.FindControl("txtContactDetails");
			TextBox txtEmail = (TextBox)dv_Records.FindControl("txtEmail");
			TextBox txtWebsite = (TextBox)dv_Records.FindControl("txtWebsite");
			FileUpload fu_Logo = (FileUpload)dv_Records.FindControl("fu_Logo");

			UniversityClass objUniversity = new UniversityClass();
			objUniversity.iCountryID = CountryID;
			objUniversity.strTitle = txtTitle.Text;
			objUniversity.strDetails = txtDetails.Text;
			objUniversity.strEstablishedIn = txtEstablishedIn.Text;
			objUniversity.strAffiliatedTo = txtAffiliatedTo.Text;
			objUniversity.strAdmissions = txtAdmissions.Text;
			objUniversity.strInfrastructure = txtInfraucture.Text;
			objUniversity.strPlacements = txtPlacements.Text;
			objUniversity.strRanking = txtRanking.Text;
			objUniversity.strContactDetails = txtContactDetails.Text;
			objUniversity.strEmail = txtEmail.Text;
			objUniversity.strWebsite = txtWebsite.Text;

			if (fu_Logo.HasFile)
			{
				cls_common objCFC = new cls_common();
				string strRanFileName = objCFC.file_name(fu_Logo.FileName);
				string strDocPath = Server.MapPath("~/files/University/" + strRanFileName);
				fu_Logo.SaveAs(strDocPath);
				objUniversity.strLogo = strRanFileName;
			}

			string strResponse = objUniversity.fn_saveUniversity();

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
			txtEstablishedIn.Text = "";
			txtAffiliatedTo.Text = "";
			txtAdmissions.Text = "";
			txtInfraucture.Text = "";
			txtPlacements.Text = "";
			txtRanking.Text = "";
			txtContactDetails.Text = "";
			txtEmail.Text = "";
			txtWebsite.Text = "";

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
			TextBox txtEstablishedIn = (TextBox)dv_Records.FindControl("txtEstablishedIn");
			TextBox txtAffiliatedTo = (TextBox)dv_Records.FindControl("txtAffiliatedTo");
			TextBox txtAdmissions = (TextBox)dv_Records.FindControl("txtAdmissions");
			TextBox txtInfraucture = (TextBox)dv_Records.FindControl("txtInfraucture");
			TextBox txtPlacements = (TextBox)dv_Records.FindControl("txtPlacements");
			TextBox txtRanking = (TextBox)dv_Records.FindControl("txtRanking");
			TextBox txtContactDetails = (TextBox)dv_Records.FindControl("txtContactDetails");
			TextBox txtEmail = (TextBox)dv_Records.FindControl("txtEmail");
			TextBox txtWebsite = (TextBox)dv_Records.FindControl("txtWebsite");
			FileUpload fu_Logo = (FileUpload)dv_Records.FindControl("fu_Logo");
			HiddenField hf_Logo = (HiddenField)dv_Records.FindControl("hf_Logo");

			UniversityClass objUniversity = new UniversityClass();
			objUniversity.iID = int.Parse(dv_Records.DataKey.Value.ToString());
			objUniversity.strTitle = txtTitle.Text;
			objUniversity.strDetails = txtDetails.Text;
			objUniversity.strEstablishedIn = txtEstablishedIn.Text;
			objUniversity.strAffiliatedTo = txtAffiliatedTo.Text;
			objUniversity.strAdmissions = txtAdmissions.Text;
			objUniversity.strInfrastructure = txtInfraucture.Text;
			objUniversity.strPlacements = txtPlacements.Text;
			objUniversity.strRanking = txtRanking.Text;
			objUniversity.strContactDetails = txtContactDetails.Text;
			objUniversity.strEmail = txtEmail.Text;
			objUniversity.strWebsite = txtWebsite.Text;

			if (fu_Logo.HasFile)
			{
				UniversityClass oUniversity = new UniversityClass();
				oUniversity.iID = int.Parse(dv_Records.DataKey.Value.ToString());
				CoreWebList<UniversityClass> oUniversityList = oUniversity.fn_getUniversityByID();
				if (oUniversityList.Count > 0)
				{
					if (File.Exists(MapPath("~/files/University/" + oUniversityList[0].strLogo)))
					{
						File.Delete((MapPath("~/files/University/" + oUniversityList[0].strLogo)));
					}
					cls_common objCFC = new cls_common();
					string strRanFileName = objCFC.file_name(fu_Logo.FileName);
					string strDocPath = Server.MapPath("~/files/University/" + strRanFileName);
					fu_Logo.SaveAs(strDocPath);
					objUniversity.strLogo = strRanFileName;
				}	
			}
			else
			{
				objUniversity.strLogo = hf_Logo.Value;
			}

			string strResponse = objUniversity.fn_editUniversity();

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
            UniversityClass objUniversity = new UniversityClass();
			objUniversity.strTitle = txtSearch.Text.Trim();
			CoreWebList<UniversityClass> objUniversityList = objUniversity.fn_getUniversityByKeys();
			if (objUniversityList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objUniversityList;
				grd_Records.DataSource = objUniversityList;
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