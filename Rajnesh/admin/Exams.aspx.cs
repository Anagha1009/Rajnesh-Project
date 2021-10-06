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

public partial class admin_Exams : System.Web.UI.Page
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
    
    private CoreWebList<ExamClass> chExamList
    {
        get
        {
            if (Cache["chExamList"] != null)
                return (CoreWebList<ExamClass>)Cache["chExamList"];
            return null;
        }
        set
        {
            Cache["chExamList"] = value;
        }
    }

    int UniversityID = 0;

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
            BredCrumbs.InnerHtml = "<a class='link' href='default.aspx'>Home</a> &nbsp; > &nbsp;Exams";

            if (Request.QueryString["UniversityID"] != null)
            {
                UniversityID=int.Parse(Request.QueryString["UniversityID"].ToString());
            }

            if (!IsPostBack)
            {
                // Bind Data To grid
                ExamClass objExam = new ExamClass();
                objExam.iUniversityID = UniversityID;
                chExamList = objExam.fn_getExamByUniversityID();

                if (chExamList.Count > 0)
                {
                    grd_Exams.DataSource = chExamList;
                }
                else
                {
                    grd_Exams.DataSource = null;
                }
                grd_Exams.DataBind();

                if (grd_Exams.SelectedIndex < 0)
                {
                    dv_Exams.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Exams_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Exams.PageIndex = e.NewPageIndex;
            grd_Exams.DataSource = chExamList;
            grd_Exams.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Exams_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            ExamClass objExam = new ExamClass();
            objExam.iID = int.Parse(grd_Exams.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objExam.fn_deleteExam();

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
            objExam.iUniversityID = UniversityID;
            chExamList = objExam.fn_getExamByUniversityID();
            grd_Exams.DataSource = chExamList;
            grd_Exams.DataBind();

            dv_Exams.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Exams_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Exams.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Exams.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_Exams.ChangeMode(DetailsViewMode.Edit);

                ExamClass objExam = new ExamClass();
                objExam.iID = int.Parse(grd_Exams.SelectedDataKey.Value.ToString());
                
                dv_Exams.DataSource = objExam.fn_getExamByID();
                dv_Exams.DataBind();

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

    protected void grd_Exams_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            ExamClass objExam = new ExamClass();

            DataTable dt = (DataTable)chExamList;
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

            grd_Exams.DataSource = dv;
            grd_Exams.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Exams_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_Exams.FindControl("txtTitle");
            TextBox txtDescription = (TextBox)dv_Exams.FindControl("txtDescription");
            
            ExamClass objExam = new ExamClass();
            objExam.iUniversityID = UniversityID;
            objExam.strExamTitle = txtTitle.Text;
            objExam.strExamDesc = txtDescription.Text;

            string strResponse = objExam.fn_saveExam();

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
            objExam.iUniversityID = UniversityID;
            chExamList = objExam.fn_getExamByUniversityID();
            grd_Exams.DataSource = chExamList;
            grd_Exams.DataBind();

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

    protected void dv_Exams_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            string strResponse = "";

            TextBox txtTitle = (TextBox)dv_Exams.FindControl("txtTitle");
            TextBox txtDescription = (TextBox)dv_Exams.FindControl("txtDescription");

            ExamClass objExam = new ExamClass();
            objExam.iID = int.Parse(dv_Exams.DataKey.Value.ToString());
            objExam.iUniversityID = UniversityID;
            objExam.strExamTitle = txtTitle.Text;
            objExam.strExamDesc = txtDescription.Text;

            strResponse = objExam.fn_editExam();

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

            dv_Exams.ChangeMode(DetailsViewMode.ReadOnly);

            objExam.iID = int.Parse(grd_Exams.SelectedDataKey.Value.ToString());

            dv_Exams.DataSource = objExam.fn_getExamByID();
            dv_Exams.DataBind();

            // Bind Data To grid           
            objExam.iUniversityID = UniversityID;
            chExamList = objExam.fn_getExamByUniversityID();
            grd_Exams.DataSource = chExamList;
            grd_Exams.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Exams_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Exams.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Exams.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Exams.ChangeMode(e.NewMode);

                if (grd_Exams.SelectedIndex >= 0)
                {
                    ExamClass objExam = new ExamClass();
                    objExam.iID = int.Parse(grd_Exams.SelectedDataKey.Value.ToString());

                    dv_Exams.DataSource = objExam.fn_getExamByID();
                    dv_Exams.DataBind();
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
            ExamClass objExam = new ExamClass();
            chExamList = objExam.fn_getExamByKeys(txtSearch.Text.Trim());

            if (chExamList.Count > 0)
            {
                grd_Exams.DataSource = chExamList;
                grd_Exams.DataBind();
            }
            else
            {
                grd_Exams.DataSource = null;
                grd_Exams.DataBind();
            }

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}