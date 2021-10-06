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

public partial class admin_ExamResults : System.Web.UI.Page
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
    
    private CoreWebList<ExamResultClass> chExamResultList
    {
        get
        {
            if (Cache["chExamResultList"] != null)
                return (CoreWebList<ExamResultClass>)Cache["chExamResultList"];
            return null;
        }
        set
        {
            Cache["chExamResultList"] = value;
        }
    }

    int CourseID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Check login session 
            //If not logged in redirect to admin login page
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx?flag=1");
            }

            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;
            
            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='default.aspx'>Home</a> &nbsp; > &nbsp;ExamResults";

            if (Request.QueryString["CourseID"] != null)
            {
                CourseID=int.Parse(Request.QueryString["CourseID"].ToString());
            }

            if (!IsPostBack)
            {
                // Bind Data To grid
                ExamResultClass objExamResult = new ExamResultClass();
                objExamResult.iCourseID = CourseID;
                chExamResultList = objExamResult.fn_getExamResultByCourseID();

                if (chExamResultList.Count > 0)
                {
                    grd_ExamResults.DataSource = chExamResultList;
                }
                else
                {
                    grd_ExamResults.DataSource = null;
                }
                grd_ExamResults.DataBind();

                if (grd_ExamResults.SelectedIndex < 0)
                {
                    dv_ExamResults.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_ExamResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_ExamResults.PageIndex = e.NewPageIndex;
            grd_ExamResults.DataSource = chExamResultList;
            grd_ExamResults.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_ExamResults_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            ExamResultClass objExamResult = new ExamResultClass();
            objExamResult.iID = int.Parse(grd_ExamResults.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objExamResult.fn_deleteExamResult();

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
            objExamResult.iCourseID = CourseID;
            chExamResultList = objExamResult.fn_getExamResultByCourseID();
            grd_ExamResults.DataSource = chExamResultList;
            grd_ExamResults.DataBind();

            dv_ExamResults.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_ExamResults_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_ExamResults.SelectedIndex < 0)
            {
                // Insert Mode
                dv_ExamResults.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_ExamResults.ChangeMode(DetailsViewMode.Edit);

                ExamResultClass objExamResult = new ExamResultClass();
                objExamResult.iID = int.Parse(grd_ExamResults.SelectedDataKey.Value.ToString());
                
                dv_ExamResults.DataSource = objExamResult.fn_getExamResultByID();
                dv_ExamResults.DataBind();

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

    protected void grd_ExamResults_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            ExamResultClass objExamResult = new ExamResultClass();

            DataTable dt = (DataTable)chExamResultList;
            DataView dv = new DataView(dt);

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

            grd_ExamResults.DataSource = dv;
            grd_ExamResults.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_ExamResults_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_ExamResults.FindControl("txtTitle");
            TextBox txtDescription = (TextBox)dv_ExamResults.FindControl("txtDescription");
            
            ExamResultClass objExamResult = new ExamResultClass();
            objExamResult.iCourseID = CourseID;
            objExamResult.strExamResultTitle = txtTitle.Text;
            objExamResult.strExamResultDesc = txtDescription.Text;

            string strResponse = objExamResult.fn_saveExamResult();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info_dv.FindControl("mssg")).Text = strResponse;
                info_dv.Visible = true;
            }
            else
            {
                ((Label)error_dv.FindControl("mssg")).Text = strResponse;
                error_dv.Visible = true;
            }

            // Bind Data To grid
            objExamResult.iCourseID = CourseID;
            chExamResultList = objExamResult.fn_getExamResultByCourseID();
            grd_ExamResults.DataSource = chExamResultList;
            grd_ExamResults.DataBind();

            // reset fields
            txtTitle.Text = "";
            txtDescription.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_ExamResults_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            string strResponse = "";

            TextBox txtTitle = (TextBox)dv_ExamResults.FindControl("txtTitle");
            TextBox txtDescription = (TextBox)dv_ExamResults.FindControl("txtDescription");

            ExamResultClass objExamResult = new ExamResultClass();
            objExamResult.iID = int.Parse(dv_ExamResults.DataKey.Value.ToString());
            objExamResult.iCourseID = CourseID;
            objExamResult.strExamResultTitle = txtTitle.Text;
            objExamResult.strExamResultDesc = txtDescription.Text;

            strResponse = objExamResult.fn_editExamResult();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info_dv.FindControl("mssg")).Text = strResponse;
                info_dv.Visible = true;
            }
            else
            {
                ((Label)error_dv.FindControl("mssg")).Text = strResponse;
                error_dv.Visible = true;
            }

            dv_ExamResults.ChangeMode(DetailsViewMode.ReadOnly);

            objExamResult.iID = int.Parse(grd_ExamResults.SelectedDataKey.Value.ToString());

            dv_ExamResults.DataSource = objExamResult.fn_getExamResultByID();
            dv_ExamResults.DataBind();

            // Bind Data To grid           
            objExamResult.iCourseID = CourseID;
            chExamResultList = objExamResult.fn_getExamResultByCourseID();
            grd_ExamResults.DataSource = chExamResultList;
            grd_ExamResults.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_ExamResults_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_ExamResults.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_ExamResults.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_ExamResults.ChangeMode(e.NewMode);

                if (grd_ExamResults.SelectedIndex >= 0)
                {
                    ExamResultClass objExamResult = new ExamResultClass();
                    objExamResult.iID = int.Parse(grd_ExamResults.SelectedDataKey.Value.ToString());

                    dv_ExamResults.DataSource = objExamResult.fn_getExamResultByID();
                    dv_ExamResults.DataBind();
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
            ExamResultClass objExamResult = new ExamResultClass();
            chExamResultList = objExamResult.fn_getExamResultByKeys(txtSearch.Text.Trim());

            if (chExamResultList.Count > 0)
            {
                grd_ExamResults.DataSource = chExamResultList;
                grd_ExamResults.DataBind();
            }
            else
            {
                grd_ExamResults.DataSource = null;
                grd_ExamResults.DataBind();
            }

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}