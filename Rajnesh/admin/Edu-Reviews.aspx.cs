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

public partial class admin_EduReview : System.Web.UI.Page
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

    string strInstitutionType = "";
    int InstitutionTypeID = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            info.Visible = false;
            error.Visible = false;
            tr_details.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;

            if (Request.QueryString["Type"] != null && Request.QueryString["TypeID"] != null)
            {
                strInstitutionType = Request.QueryString["Type"].ToString();
                InstitutionTypeID = int.Parse(Request.QueryString["TypeID"].ToString());
            }
            else
            {
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/admin/"));
            }

            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;Edu Reviews";

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
            EduReviewClass objEduReview = new EduReviewClass();
            objEduReview.strInstitutionType = strInstitutionType;
            objEduReview.iInstitutionID = InstitutionTypeID;
            CoreWebList<EduReviewClass> objEduReviewList = objEduReview.fn_getEduReviewByType();
			if (objEduReviewList.Count > 0)
			{
				ViewState["dt_Records"] = (DataTable)objEduReviewList;
				grd_Records.DataSource = objEduReviewList;
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
            if (ViewState["dt_Records"] != null)
            {
                DataTable dtRecords = (DataTable)ViewState["dt_Records"];
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
            EduReviewClass objEduReview = new EduReviewClass();
			objEduReview.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());

			string strResponse = objEduReview.fn_deleteEduReview();

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
                fn_BindReviewFactors();

                tr_details.Visible = true;

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

    protected void fn_BindDetails(int iRecordID)
    {
        try
        {
            EduReviewClass objEduReview = new EduReviewClass();
            objEduReview.iID = iRecordID;
            CoreWebList<EduReviewClass> objEduReviewList = objEduReview.fn_getEduReviewByID();
            if (objEduReviewList.Count > 0)
            {
                int InstitutionID = objEduReviewList[0].iInstitutionID;
                string strInstitute = "";
                string strInstitutionType = "";
                hf_ReviewID.Value = iRecordID.ToString();

                ltl_Name.Text = objEduReviewList[0].strName;
                ltl_Email.Text = objEduReviewList[0].strEmail;
                ltl_MobileNo.Text = objEduReviewList[0].strMobileNo;
                ltl_Title.Text = objEduReviewList[0].strTitle;
                ltl_Details.Text = objEduReviewList[0].strDetails;
                ltl_UserType.Text = objEduReviewList[0].strUserType;
                
                ltl_Date.Text = objEduReviewList[0].dtDate.ToLongDateString();

                strInstitutionType = objEduReviewList[0].strInstitutionType;

                if (strInstitutionType == "Institute")
                {
                    InstituteClass objInstitute = new InstituteClass();
                    objInstitute.iID = InstitutionID;
                    CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByID();
                    if (objInstituteList.Count > 0)
                    {
                        strInstitute = objInstituteList[0].strTitle;
                    }
                }

                else if (strInstitutionType == "University")
                {
                    UniversityListClass objUniversity = new UniversityListClass();
                    objUniversity.iID = InstitutionID;
                    CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_getUniversityByID();
                    if (objUniversityList.Count > 0)
                    {
                        strInstitute = objUniversityList[0].strTitle;
                    }
                }

                else if (strInstitutionType == "School")
                {
                    SchoolClass objSchool = new SchoolClass();
                    objSchool.iID = InstitutionID;
                    CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolByID();
                    if (objSchoolList.Count > 0)
                    {
                        strInstitute = objSchoolList[0].strTitle;
                    }
                }

                else if (strInstitutionType == "DistanceUniversity" || strInstitutionType == "DistanceCollege")
                {
                    DistanceLearningClass objDistance = new DistanceLearningClass();
                    objDistance.iID = InstitutionID;
                    CoreWebList<DistanceLearningClass> objDistanceList = objDistance.fn_GetDistanceLearningByID();
                    if (objDistanceList.Count > 0)
                    {
                        strInstitute = objDistanceList[0].strName;
                    }
                }

                ltl_Institute.Text = strInstitute;

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
            if (ViewState["dt_Records"] != null)
            {
                DataTable dtRecords = (DataTable)ViewState["dt_Records"];
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
            EduReviewClass objEduReview = new EduReviewClass();
            objEduReview.strInstitutionType = strInstitutionType;
            objEduReview.strTitle = txtSearch.Text.Trim();
            CoreWebList<EduReviewClass> objEduReviewList = objEduReview.fn_getEduReviewByTypeKeys();
			if (objEduReviewList.Count > 0)
			{
				ViewState["dt_Records"] = (DataTable)objEduReviewList;
				grd_Records.DataSource = objEduReviewList;
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
            string strResponse = "";
            if (e.CommandName == "Enable")
            {
                EduReviewClass objReview = new EduReviewClass();
                ImageButton btnEnable = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnEnable.Parent.Parent;

                objReview.iID = Convert.ToInt32(e.CommandArgument); ;
                CoreWebList<EduReviewClass> objReviewList = objReview.fn_getEduReviewByID();
                if (objReviewList.Count > 0)
                {
                    if (objReviewList[0].bActive == true)
                    {
                        btnEnable.ImageUrl = "~/admin/images/cross.gif";
                        objReview.bActive = false;
                    }
                    else
                    {
                        btnEnable.ImageUrl = "~/admin/images/Tick.gif";
                        objReview.bActive = true;

                    }

                    strResponse = objReview.fn_ChangeReviewActiveStatus();

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
                HiddenField hfEnable = (HiddenField)e.Row.FindControl("hfEnable");
                ImageButton btnEnable = (ImageButton)e.Row.FindControl("btnEnable");

                if (bool.Parse(hfEnable.Value) == true)
                {
                    btnEnable.ImageUrl = "~/admin/images/Tick.gif";
                }
                else
                {
                    btnEnable.ImageUrl = "~/admin/images/Cross.gif";
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void fn_BindReviewFactors()
    {
        try
        {
            FactorHeadingClass objFactor = new FactorHeadingClass();
            CoreWebList<FactorHeadingClass> objFactorList = objFactor.fn_getFactorHeadingList();
            if (objFactorList.Count > 0)
            {
                rpt_ReviewFactors.DataSource = objFactorList;
                rpt_ReviewFactors.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void rpt_ReviewFactors_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hf_FactorID = (HiddenField)e.Item.FindControl("hf_FactorID");
                Repeater rpt_Ratings = (Repeater)e.Item.FindControl("rpt_Ratings");
                int ReviewID = int.Parse(hf_ReviewID.Value);

                if (hf_FactorID != null && rpt_Ratings != null)
                {
                    EduReviewDetailClass objReviewDetail = new EduReviewDetailClass();
                    objReviewDetail.iReviewID = ReviewID;
                    objReviewDetail.iFactorID = int.Parse(hf_FactorID.Value);
                    CoreWebList<EduReviewDetailClass> objReviewDetailList = objReviewDetail.fn_getEduReviewDetailByFactorHeadingID();
                    if (objReviewDetailList.Count > 0)
                    {
                        rpt_Ratings.DataSource = objReviewDetailList;
                        rpt_Ratings.DataBind();
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