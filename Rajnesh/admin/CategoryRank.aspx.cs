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

public partial class admin_CategoryRank : System.Web.UI.Page
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
    
	int iInstituteID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;
            
			if (Request.QueryString["InstituteID"] != null)
			{
				iInstituteID = int.Parse(Request.QueryString["InstituteID"].ToString());
			}
			else
			{
				Response.Redirect(VirtualPathUtility.ToAbsolute("~/admin/Institute.aspx"), true);
			}

            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;CategoryRank";

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
            CategoryRankClass objCategoryRank = new CategoryRankClass();
			objCategoryRank.iInstituteID = iInstituteID;
			CoreWebList<CategoryRankClass> objCategoryRankList = objCategoryRank.fn_getCategoryRankByInstituteID();
			if (objCategoryRankList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objCategoryRankList;
				grd_Records.DataSource = objCategoryRankList;
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
            CategoryRankClass objCategoryRank = new CategoryRankClass();
			objCategoryRank.iID = iRecordID;
			CoreWebList<CategoryRankClass> objCategoryRankList = objCategoryRank.fn_getCategoryRankByID();
			if (objCategoryRankList.Count > 0)
			{
				dv_Records.DataSource = objCategoryRankList;
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
            CategoryRankClass objCategoryRank = new CategoryRankClass();
			objCategoryRank.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());

			string strResponse = objCategoryRank.fn_deleteCategoryRank();

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
			DropDownList ddlCategory = (DropDownList)dv_Records.FindControl("ddlCategory");
			TextBox txtRank = (TextBox)dv_Records.FindControl("txtRank");

			CategoryRankClass objCategoryRank = new CategoryRankClass();
			objCategoryRank.iInstituteID = iInstituteID;
			objCategoryRank.iCategoryID = int.Parse(ddlCategory.Text);
			objCategoryRank.iRank = int.Parse(txtRank.Text);

			string strResponse = objCategoryRank.fn_saveCategoryRank();

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

			ddlCategory.SelectedIndex = 0;
			txtRank.Text = "";

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
            DropDownList ddlCategory = (DropDownList)dv_Records.FindControl("ddlCategory");
            TextBox txtRank = (TextBox)dv_Records.FindControl("txtRank");

			CategoryRankClass objCategoryRank = new CategoryRankClass();
			objCategoryRank.iID = int.Parse(dv_Records.DataKey.Value.ToString());
            objCategoryRank.iCategoryID = int.Parse(ddlCategory.Text);
            objCategoryRank.iRank = int.Parse(txtRank.Text);

			string strResponse = objCategoryRank.fn_editCategoryRank();

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

    protected void dv_Records_DataBound(object sender, EventArgs e)
	{
		try
		{
			DropDownList ddlCategory = (DropDownList)dv_Records.FindControl("ddlCategory");
			fn_BindCategoryDropDownList();
			if (dv_Records.CurrentMode == DetailsViewMode.Edit || dv_Records.CurrentMode == DetailsViewMode.ReadOnly)
			{

                CategoryRankClass objRank = new CategoryRankClass();
                objRank.iID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                CoreWebList<CategoryRankClass> objRankList = objRank.fn_getCategoryRankByID();
                if (objRankList.Count > 0)
                {
                    InstituteCategoryClass objCategory = new InstituteCategoryClass();
                    objCategory.iID = objRankList[0].iCategoryID;
                    CoreWebList<InstituteCategoryClass> objCategoryList = objCategory.fn_getCategoryByID();
                    if (objCategoryList.Count > 0)
                    {
                        ddlCategory.SelectedValue = objCategoryList[0].iID.ToString();
                    }
                    if (dv_Records.CurrentMode == DetailsViewMode.ReadOnly)
                    {
                        ddlCategory.Enabled = false;
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

	protected void fn_BindCategoryDropDownList()
	{
		try
		{
			DropDownList ddlCategory = (DropDownList)dv_Records.FindControl("ddlCategory");
			if (ddlCategory != null)
			{
                InstituteCategoryClass objCategory = new InstituteCategoryClass();
				ddlCategory.DataSource = objCategory.fn_getCategoryList();
                ddlCategory.DataTextField = "strCategoryTitle";
				ddlCategory.DataValueField = "iID";
				ddlCategory.DataBind();
				ddlCategory.Items.Insert(0, new ListItem("Select", "0"));
			}
		}
		catch (Exception ex)
		{
			((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
			error.Visible = true;
		}
	}



}