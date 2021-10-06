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

public partial class admin_CompetitionEntry : System.Web.UI.Page
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
            tr_details.Visible = false;
            
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
            BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;CompetitionEntry";

            if (!IsPostBack)
            {
                fn_BindRecords();
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
            CompetitionUserClass objCompetitionEntry = new CompetitionUserClass();
            objCompetitionEntry.iCompetitionID = iCompetitionID;
            CoreWebList<CompetitionUserClass> objCompetitionEntryList = objCompetitionEntry.fn_getCompetitionUserByCompetitionID();
			if (objCompetitionEntryList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objCompetitionEntryList;
				grd_Records.DataSource = objCompetitionEntryList;
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
            CompetitionUserClass objCompetitionEntry = new CompetitionUserClass();
			objCompetitionEntry.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());

			string strResponse = objCompetitionEntry.fn_deleteCompetitionUser();

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
            }
            else
            {
                int iRecordID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                fn_BindDetails(iRecordID);
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

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CompetitionUserClass objCompetitionEntry = new CompetitionUserClass();
            objCompetitionEntry.iCompetitionID = iCompetitionID;
            objCompetitionEntry.strName = txtSearch.Text.Trim();
            CoreWebList<CompetitionUserClass> objCompetitionEntryList = objCompetitionEntry.fn_getCompetitionUserByKeys();
            if (objCompetitionEntryList.Count > 0)
            {
                ViewState["dtRecords"] = (DataTable)objCompetitionEntryList;
                grd_Records.DataSource = objCompetitionEntryList;
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

    protected void fn_BindDetails(int iLeadId)
    {
        try
        {
            tr_details.Visible = true;

            #region "Scroll to Details"
            StringBuilder sb = new StringBuilder();
            sb.Append("$('html,body').animate({ scrollTop: $('#ScrollHere').offset().top }, 2000);");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Scroll", sb.ToString(), true);
            #endregion

            CompetitionUserClass objCompetitionUser = new CompetitionUserClass();
            objCompetitionUser.iID = iLeadId;
            CoreWebList<CompetitionUserClass> objCompetitionUserList = objCompetitionUser.fn_getCompetitionUserByID();
            if (objCompetitionUserList.Count > 0)
            {
                ltl_Name.Text = objCompetitionUserList[0].strName;
                ltl_Email.Text = objCompetitionUserList[0].strEmail;
                ltl_DoB.Text = objCompetitionUserList[0].dtDoB.ToLongDateString();
                ltl_Qualification.Text = objCompetitionUserList[0].strQualification;
                ltl_MobileNo.Text = objCompetitionUserList[0].strMobile;
                ltl_City.Text = objCompetitionUserList[0].strCity;
                ltl_Address.Text = objCompetitionUserList[0].strAddress;
                ltl_IpAddress.Text = objCompetitionUserList[0].strIpAddrs;
                ltl_Date.Text = objCompetitionUserList[0].dtDate.ToLongDateString();
                if (objCompetitionUserList[0].bGender == true)
                {
                    ltl_Gender.Text = "Male";
                }
                else
                {
                    ltl_Gender.Text = "Female";
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void grd_Records_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hfUserID = (HiddenField)e.Row.FindControl("hfUserID");
                HtmlImage img_Result = (HtmlImage)e.Row.FindControl("img_Result");

                if (hfUserID != null && img_Result != null)
                {
                    CompetitionUserClass objCompetiton = new CompetitionUserClass();
                    objCompetiton.iCompetitionID = iCompetitionID;
                    objCompetiton.iID = int.Parse(hfUserID.Value);
                    CoreWebList<CompetitionUserClass> objCompetitonList = objCompetiton.fn_getCompetitionUserAnswersByID();
                    if (objCompetitonList.Count > 0)
                    {
                        bool bCorrect = true;

                        for (int i = 0; i < objCompetitonList.Count; i++)
                        {
                            if (objCompetitonList[i].bAnswer == false)
                            {
                                bCorrect = false;
                            }
                        }

                        if (bCorrect == true)
                        {
                            img_Result.Src = "~/admin/images/Tick.gif";
                        }
                        else
                        {
                            img_Result.Src = "~/admin/images/Cross.gif";
                        }
                    }
                    else
                    {
                        img_Result.Src = "~/admin/images/Cross.gif";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}