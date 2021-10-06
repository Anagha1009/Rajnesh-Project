using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Text;
using System.IO;

public partial class admin_Entrance : System.Web.UI.Page
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
    
    private CoreWebList<EntranceExamClass> chSchoolList
    {
        get
        {
            if (Cache["chSchoolList"] != null)
                return (CoreWebList<EntranceExamClass>)Cache["chSchoolList"];
            return null;
        }
        set
        {
            Cache["chSchoolList"] = value;
        }
    }

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
            
            if (!IsPostBack)
            {
                // Bind Data To grid
                EntranceExamClass objEntranceExam = new EntranceExamClass();
                chSchoolList = objEntranceExam.fn_getEntranceExamList();
                if (chSchoolList.Count > 0)
                {
                    grd_Schools.DataSource = chSchoolList;
                }
                else
                {
                    grd_Schools.DataSource = null;
                }
                grd_Schools.DataBind();

                if (grd_Schools.SelectedIndex < 0)
                {
                    dv_Schools.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Schools_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Schools.PageIndex = e.NewPageIndex;
            grd_Schools.DataSource = chSchoolList;
            grd_Schools.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Schools_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            EntranceExamClass objEntranceExam = new EntranceExamClass();
            objEntranceExam.iID = int.Parse(grd_Schools.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objEntranceExam.fn_deleteEntranceExam();

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

            grd_Schools.DataSource = objEntranceExam.fn_getEntranceExamList();
            grd_Schools.DataBind();

            dv_Schools.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Schools_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Schools.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Schools.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_Schools.ChangeMode(DetailsViewMode.Edit);

                EntranceExamClass objEntranceExam = new EntranceExamClass();
                objEntranceExam.iID = int.Parse(grd_Schools.SelectedDataKey.Value.ToString());
                
                dv_Schools.DataSource = objEntranceExam.fn_getEntranceExamByID();
                dv_Schools.DataBind();

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

    protected void grd_Schools_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            EntranceExamClass objEntranceExam = new EntranceExamClass();

            DataTable dt = (DataTable)chSchoolList;
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

            grd_Schools.DataSource = dv;
            grd_Schools.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Schools_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            DropDownList ddl_Category = (DropDownList)dv_Schools.FindControl("ddl_Category");
            TextBox txtTitle = (TextBox)dv_Schools.FindControl("txtTitle");
            TextBox txtDesc = (TextBox)dv_Schools.FindControl("txtDesc");
            TextBox txtAdmissions = (TextBox)dv_Schools.FindControl("txtAdmissions");
            TextBox txtDates = (TextBox)dv_Schools.FindControl("txtDates");
            TextBox txtSyllabus = (TextBox)dv_Schools.FindControl("txtSyllabus");
            TextBox txtPaperPattern = (TextBox)dv_Schools.FindControl("txtPaperPattern");
            TextBox txtPreparation = (TextBox)dv_Schools.FindControl("txtPreparation");
            TextBox txtNotifications = (TextBox)dv_Schools.FindControl("txtNotifications");
            
            EntranceExamClass objEntranceExam = new EntranceExamClass();

            objEntranceExam.iCategoryID = int.Parse(ddl_Category.SelectedValue);
            objEntranceExam.strTitle = txtTitle.Text;
            objEntranceExam.strDesc = txtDesc.Text;
            objEntranceExam.strAdmissions= txtAdmissions.Text;
            objEntranceExam.strDates= txtDates.Text;
            objEntranceExam.strSyllabus = txtSyllabus.Text;
            objEntranceExam.strPaperPatterns= txtPaperPattern.Text;
            objEntranceExam.strPreparation = txtPreparation.Text;
            objEntranceExam.strNotifications = txtNotifications.Text;
            
            string strResponse = objEntranceExam.fn_saveEntranceExam();

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
            grd_Schools.DataSource = objEntranceExam.fn_getEntranceExamList();
            grd_Schools.DataBind();

            // reset fields
            ddl_Category.SelectedIndex = 0;
            txtTitle.Text = "";
            txtDesc.Text = "";
            txtAdmissions.Text = "";
            txtDates.Text = "";
            txtSyllabus.Text = "";
            txtPaperPattern.Text = "";
            txtAdmissions.Text = "";
            txtPreparation.Text = "";
            txtNotifications.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Schools_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            DropDownList ddl_Category = (DropDownList)dv_Schools.FindControl("ddl_Category");
            TextBox txtTitle = (TextBox)dv_Schools.FindControl("txtTitle");
            TextBox txtDesc = (TextBox)dv_Schools.FindControl("txtDesc");
            TextBox txtAdmissions = (TextBox)dv_Schools.FindControl("txtAdmissions");
            TextBox txtDates = (TextBox)dv_Schools.FindControl("txtDates");
            TextBox txtSyllabus = (TextBox)dv_Schools.FindControl("txtSyllabus");
            TextBox txtPaperPattern = (TextBox)dv_Schools.FindControl("txtPaperPattern");
            TextBox txtPreparation = (TextBox)dv_Schools.FindControl("txtPreparation");
            TextBox txtNotifications = (TextBox)dv_Schools.FindControl("txtNotifications");

            EntranceExamClass objEntranceExam = new EntranceExamClass();
            objEntranceExam.iID = int.Parse(dv_Schools.DataKey.Value.ToString());
            objEntranceExam.iCategoryID = int.Parse(ddl_Category.SelectedValue);
            objEntranceExam.strTitle = txtTitle.Text;
            objEntranceExam.strDesc = txtDesc.Text;
            objEntranceExam.strAdmissions = txtAdmissions.Text;
            objEntranceExam.strDates = txtDates.Text;
            objEntranceExam.strSyllabus = txtSyllabus.Text;
            objEntranceExam.strPaperPatterns = txtPaperPattern.Text;
            objEntranceExam.strPreparation = txtPreparation.Text;
            objEntranceExam.strNotifications = txtNotifications.Text;

            string strResponse = objEntranceExam.fn_editEntranceExam();

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

            dv_Schools.ChangeMode(DetailsViewMode.ReadOnly);

            objEntranceExam.iID = int.Parse(grd_Schools.SelectedDataKey.Value.ToString());

            dv_Schools.DataSource = objEntranceExam.fn_getEntranceExamByID();
            dv_Schools.DataBind();

            // Bind Data To grid            
            grd_Schools.DataSource = objEntranceExam.fn_getEntranceExamList();
            grd_Schools.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Schools_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Schools.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Schools.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Schools.ChangeMode(e.NewMode);

                if (grd_Schools.SelectedIndex >= 0)
                {
                    EntranceExamClass objEntranceExam = new EntranceExamClass();
                    objEntranceExam.iID = int.Parse(grd_Schools.SelectedDataKey.Value.ToString());

                    dv_Schools.DataSource = objEntranceExam.fn_getEntranceExamByID();
                    dv_Schools.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Schools_DataBound(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddl_Category = (DropDownList)dv_Schools.FindControl("ddl_Category");

            if (dv_Schools.CurrentMode == DetailsViewMode.Insert)
            {
                fn_BindCategoryDropDownList();
            }

            if (dv_Schools.CurrentMode == DetailsViewMode.Edit)
            {
                EntranceExamClass objEntranceExam = new EntranceExamClass();
                objEntranceExam.iID = int.Parse(grd_Schools.SelectedDataKey.Value.ToString());
                CoreWebList<EntranceExamClass> objEntranceExamList = objEntranceExam.fn_getEntranceExamByID();
                if (objEntranceExamList.Count > 0)
                {
                    fn_BindCategoryDropDownList();
                    ddl_Category.SelectedValue = objEntranceExamList[0].iCategoryID.ToString();
                }
            }

            if (dv_Schools.CurrentMode == DetailsViewMode.ReadOnly)
            {
                Label lblCategory = (Label)dv_Schools.FindControl("lblCategory");

                EntranceExamClass objEntranceExam = new EntranceExamClass();
                objEntranceExam.iID = int.Parse(grd_Schools.SelectedDataKey.Value.ToString());
                CoreWebList<EntranceExamClass> objEntranceExamList = objEntranceExam.fn_getEntranceExamByID();
                if (objEntranceExamList.Count > 0)
                {
                    EntranceCategoryClass objCategory = new EntranceCategoryClass();
                    objCategory.iID = objEntranceExamList[0].iCategoryID;
                    CoreWebList<EntranceCategoryClass> objCategoryList = objCategory.fn_getEntranceCategoryByID();
                    if (objCategoryList.Count > 0)
                    {
                        lblCategory.Text = objCategoryList[0].strTitle;
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
            DropDownList ddl_Category = (DropDownList)dv_Schools.FindControl("ddl_Category");
            if (ddl_Category != null)
            {
                EntranceCategoryClass objCategory = new EntranceCategoryClass();
                ddl_Category.DataSource = objCategory.fn_getEntranceCategoryList();
                ddl_Category.DataTextField = "strTitle";
                ddl_Category.DataValueField = "iID";
                ddl_Category.DataBind();
                ddl_Category.Items.Insert(0, new ListItem("Select", "0"));
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
            EntranceExamClass objEntranceExam = new EntranceExamClass();
            objEntranceExam.strTitle = txtSearch.Text;
            chSchoolList = objEntranceExam.fn_getEntranceExamByKeys();
            if (chSchoolList.Count > 0)
            {
                grd_Schools.DataSource = chSchoolList;
                grd_Schools.DataBind();
            }
            else
            {
                grd_Schools.DataSource = null;
                grd_Schools.DataBind();
            }

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}