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
using System.Text.RegularExpressions;
using System.Globalization;
using System.Drawing;

public partial class admin_Courses : System.Web.UI.Page
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

    private CoreWebList<InstituteCourseClass> chInstituteCourseList
    {
        get
        {
            if (Cache["chInstituteCourseList"] != null)
                return (CoreWebList<InstituteCourseClass>)Cache["chInstituteCourseList"];
            return null;
        }
        set
        {
            Cache["chInstituteCourseList"] = value;
        }
    }

    int InstituteID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Check login session 
            //If not logged in redirect to admin login page
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx?flag=1", false);
            }

            if (Request.QueryString["InstituteID"] != null)
            {
                InstituteID = int.Parse(Request.QueryString["InstituteID"].ToString());
            }

            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {

                // Bind Data To grid
                InstituteCourseClass objCourse = new InstituteCourseClass();
                objCourse.iInstituteID = InstituteID;
                chInstituteCourseList = objCourse.fn_getInstituteCourseByInstituteID();

                if (chInstituteCourseList.Count > 0)
                {
                    grd_Courses.DataSource = chInstituteCourseList;
                }
                else
                {
                    grd_Courses.DataSource = null;
                }
                grd_Courses.DataBind();

                if (grd_Courses.SelectedIndex < 0)
                {
                    dv_Courses.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Courses_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Courses.PageIndex = e.NewPageIndex;
            grd_Courses.DataSource = chInstituteCourseList;
            grd_Courses.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Courses_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            InstituteCourseClass objCourse = new InstituteCourseClass();
            objCourse.iID = int.Parse(grd_Courses.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objCourse.fn_deleteInstituteCourse();

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

            objCourse.iInstituteID = InstituteID;
            chInstituteCourseList = objCourse.fn_getInstituteCourseByInstituteID();
            grd_Courses.DataSource = chInstituteCourseList;
            grd_Courses.DataBind();

            dv_Courses.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Courses_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Courses.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Courses.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_Courses.ChangeMode(DetailsViewMode.Edit);

                InstituteCourseClass objCourse = new InstituteCourseClass();
                objCourse.iID = int.Parse(grd_Courses.SelectedDataKey.Value.ToString());

                dv_Courses.DataSource = objCourse.fn_getInstituteCourseByID();
                dv_Courses.DataBind();

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

    protected void grd_Courses_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            InstituteCourseClass objCourse = new InstituteCourseClass();

            DataTable dt = (DataTable)chInstituteCourseList;
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

            grd_Courses.DataSource = dv;
            grd_Courses.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Courses_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            DropDownList ddl_Category = (DropDownList)dv_Courses.FindControl("ddl_Category");
            TextBox txtTitle = (TextBox)dv_Courses.FindControl("txtTitle");
            TextBox txtDesc = (TextBox)dv_Courses.FindControl("txtDesc");

            TextBox txtFees = (TextBox)dv_Courses.FindControl("txtFees");
            TextBox txtSyllabus = (TextBox)dv_Courses.FindControl("txtSyllabus");
            TextBox txtEligibility = (TextBox)dv_Courses.FindControl("txtEligibility");

            InstituteCourseClass objCourse = new InstituteCourseClass();
            objCourse.iCategoryID = int.Parse(ddl_Category.SelectedValue);
            objCourse.iInstituteID = InstituteID;
            objCourse.strTitle = txtTitle.Text;
            objCourse.strDesc = txtDesc.Text;

            objCourse.strFees= txtFees.Text;
            objCourse.strSyllabus = txtSyllabus.Text;
            objCourse.strEligibility = txtEligibility.Text;

            string strResponse = objCourse.fn_saveInstituteCourse();

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
            chInstituteCourseList = objCourse.fn_getInstituteCourseByInstituteID();
            grd_Courses.DataSource = chInstituteCourseList;
            grd_Courses.DataBind();

            // reset fields
            txtTitle.Text = "";
            txtDesc.Text = "";

            txtFees.Text = "";
            txtSyllabus.Text = "";
            txtEligibility.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Courses_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            DropDownList ddl_Category = (DropDownList)dv_Courses.FindControl("ddl_Category");
            TextBox txtTitle = (TextBox)dv_Courses.FindControl("txtTitle");
            TextBox txtDesc = (TextBox)dv_Courses.FindControl("txtDesc");

            TextBox txtFees = (TextBox)dv_Courses.FindControl("txtFees");
            TextBox txtSyllabus = (TextBox)dv_Courses.FindControl("txtSyllabus");
            TextBox txtEligibility = (TextBox)dv_Courses.FindControl("txtEligibility");

            InstituteCourseClass objCourse = new InstituteCourseClass();
            int iWebsiteID = int.Parse(dv_Courses.DataKey.Value.ToString());
            objCourse.iCategoryID = int.Parse(ddl_Category.SelectedValue);
            objCourse.iID = iWebsiteID;
            objCourse.iInstituteID = InstituteID;
            objCourse.strTitle = txtTitle.Text;
            objCourse.strDesc = txtDesc.Text;

            objCourse.strFees = txtFees.Text;
            objCourse.strSyllabus = txtSyllabus.Text;
            objCourse.strEligibility = txtEligibility.Text;

            string strResponse = objCourse.fn_editInstituteCourse();

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

            dv_Courses.ChangeMode(DetailsViewMode.ReadOnly);

            objCourse.iID = int.Parse(grd_Courses.SelectedDataKey.Value.ToString());

            dv_Courses.DataSource = objCourse.fn_getInstituteCourseByID();
            dv_Courses.DataBind();

            // Bind Data To grid    
            chInstituteCourseList = objCourse.fn_getInstituteCourseByInstituteID();
            grd_Courses.DataSource = chInstituteCourseList;
            grd_Courses.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Courses_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Courses.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Courses.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Courses.ChangeMode(e.NewMode);

                if (grd_Courses.SelectedIndex >= 0)
                {
                    InstituteCourseClass objCourse = new InstituteCourseClass();
                    objCourse.iID = int.Parse(grd_Courses.SelectedDataKey.Value.ToString());

                    dv_Courses.DataSource = objCourse.fn_getInstituteCourseByID();
                    dv_Courses.DataBind();
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
            if (txtSearch.Text != "")
            {
                InstituteCourseClass objCourse = new InstituteCourseClass();
                objCourse.strTitle = txtSearch.Text.Trim();
                chInstituteCourseList = objCourse.fn_getInstituteCourseByKeys();
                if (chInstituteCourseList.Count > 0)
                {
                    grd_Courses.DataSource = chInstituteCourseList;
                }
                else
                {
                    grd_Courses.DataSource = null;
                }
                grd_Courses.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void dv_Courses_DataBound(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddl_Category = (DropDownList)dv_Courses.FindControl("ddl_Category");

            if (dv_Courses.CurrentMode == DetailsViewMode.Insert)
            {
                fn_BindCategoryDropDownList();
            }

            if (dv_Courses.CurrentMode == DetailsViewMode.Edit)
            {
                InstituteCourseClass objCourse = new InstituteCourseClass();
                objCourse.iID = int.Parse(grd_Courses.SelectedDataKey.Value.ToString());
                CoreWebList<InstituteCourseClass> objCourseList = objCourse.fn_getInstituteCourseByID();
                if (objCourseList.Count > 0)
                {
                    fn_BindCategoryDropDownList();
                    ddl_Category.SelectedValue = objCourseList[0].iCategoryID.ToString();
                }
            }

            if (dv_Courses.CurrentMode == DetailsViewMode.ReadOnly)
            {
                Label lblCategory = (Label)dv_Courses.FindControl("lblCategory");

                InstituteCourseClass objCourse = new InstituteCourseClass();
                objCourse.iID = int.Parse(grd_Courses.SelectedDataKey.Value.ToString());
                CoreWebList<InstituteCourseClass> objCourseList = objCourse.fn_getInstituteCourseByID();
                if (objCourseList.Count > 0)
                {
                    InstituteCategoryClass objCategory = new InstituteCategoryClass();
                    objCategory.iID = objCourseList[0].iCategoryID;
                    CoreWebList<InstituteCategoryClass> objCategoryList = objCategory.fn_getCategoryByID();
                    if (objCategoryList.Count > 0)
                    {
                        lblCategory.Text = objCategoryList[0].strCategoryTitle;
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
            DropDownList ddl_Category = (DropDownList)dv_Courses.FindControl("ddl_Category");
            if (ddl_Category != null)
            {
                InstituteCategoryClass objCategory = new InstituteCategoryClass();
                ddl_Category.DataSource = objCategory.fn_getCategoryList();
                ddl_Category.DataTextField = "strCategoryTitle";
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
}