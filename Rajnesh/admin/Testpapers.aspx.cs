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

public partial class admin_Testpapers : System.Web.UI.Page
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
    
    private CoreWebList<TestpaperClass> chTestpaperList
    {
        get
        {
            if (Cache["chTestpaperList"] != null)
                return (CoreWebList<TestpaperClass>)Cache["chTestpaperList"];
            return null;
        }
        set
        {
            Cache["chTestpaperList"] = value;
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
            BredCrumbs.InnerHtml = "<a class='link' href='default.aspx'>Home</a> &nbsp; > &nbsp;Testpapers";

            if (Request.QueryString["CourseID"] != null)
            {
                CourseID=int.Parse(Request.QueryString["CourseID"].ToString());
            }

            if (!IsPostBack)
            {
                // Bind Data To grid
                TestpaperClass objTestpaper = new TestpaperClass();
                objTestpaper.iCourseID = CourseID;
                chTestpaperList = objTestpaper.fn_getTestpaperByCourseID();

                if (chTestpaperList.Count > 0)
                {
                    grd_Testpapers.DataSource = chTestpaperList;
                }
                else
                {
                    grd_Testpapers.DataSource = null;
                }
                grd_Testpapers.DataBind();

                if (grd_Testpapers.SelectedIndex < 0)
                {
                    dv_Testpapers.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Testpapers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Testpapers.PageIndex = e.NewPageIndex;
            grd_Testpapers.DataSource = chTestpaperList;
            grd_Testpapers.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Testpapers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            TestpaperClass objTestpaper = new TestpaperClass();
            objTestpaper.iID = int.Parse(grd_Testpapers.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objTestpaper.fn_deleteTestpaper();

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
            objTestpaper.iCourseID = CourseID;
            chTestpaperList = objTestpaper.fn_getTestpaperByCourseID();
            grd_Testpapers.DataSource = chTestpaperList;
            grd_Testpapers.DataBind();

            dv_Testpapers.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Testpapers_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Testpapers.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Testpapers.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_Testpapers.ChangeMode(DetailsViewMode.Edit);

                TestpaperClass objTestpaper = new TestpaperClass();
                objTestpaper.iID = int.Parse(grd_Testpapers.SelectedDataKey.Value.ToString());
                
                dv_Testpapers.DataSource = objTestpaper.fn_getTestpaperByID();
                dv_Testpapers.DataBind();

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

    protected void grd_Testpapers_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            TestpaperClass objTestpaper = new TestpaperClass();

            DataTable dt = (DataTable)chTestpaperList;
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

            grd_Testpapers.DataSource = dv;
            grd_Testpapers.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Testpapers_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_Testpapers.FindControl("txtTitle");
            TextBox txtDescription = (TextBox)dv_Testpapers.FindControl("txtDescription");
            
            TestpaperClass objTestpaper = new TestpaperClass();
            objTestpaper.iCourseID = CourseID;
            objTestpaper.strTestpaperTitle = txtTitle.Text;
            objTestpaper.strTestpaperDesc = txtDescription.Text;

            string strResponse = objTestpaper.fn_saveTestpaper();

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
            objTestpaper.iCourseID = CourseID;
            chTestpaperList = objTestpaper.fn_getTestpaperByCourseID();
            grd_Testpapers.DataSource = chTestpaperList;
            grd_Testpapers.DataBind();

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

    protected void dv_Testpapers_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            string strResponse = "";

            TextBox txtTitle = (TextBox)dv_Testpapers.FindControl("txtTitle");
            TextBox txtDescription = (TextBox)dv_Testpapers.FindControl("txtDescription");

            TestpaperClass objTestpaper = new TestpaperClass();
            objTestpaper.iID = int.Parse(dv_Testpapers.DataKey.Value.ToString());
            objTestpaper.iCourseID = CourseID;
            objTestpaper.strTestpaperTitle = txtTitle.Text;
            objTestpaper.strTestpaperDesc = txtDescription.Text;

            strResponse = objTestpaper.fn_editTestpaper();

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

            dv_Testpapers.ChangeMode(DetailsViewMode.ReadOnly);

            objTestpaper.iID = int.Parse(grd_Testpapers.SelectedDataKey.Value.ToString());

            dv_Testpapers.DataSource = objTestpaper.fn_getTestpaperByID();
            dv_Testpapers.DataBind();

            // Bind Data To grid           
            objTestpaper.iCourseID = CourseID;
            chTestpaperList = objTestpaper.fn_getTestpaperByCourseID();
            grd_Testpapers.DataSource = chTestpaperList;
            grd_Testpapers.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Testpapers_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Testpapers.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Testpapers.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Testpapers.ChangeMode(e.NewMode);

                if (grd_Testpapers.SelectedIndex >= 0)
                {
                    TestpaperClass objTestpaper = new TestpaperClass();
                    objTestpaper.iID = int.Parse(grd_Testpapers.SelectedDataKey.Value.ToString());

                    dv_Testpapers.DataSource = objTestpaper.fn_getTestpaperByID();
                    dv_Testpapers.DataBind();
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
            TestpaperClass objTestpaper = new TestpaperClass();
            chTestpaperList = objTestpaper.fn_getTestpaperByKeys(txtSearch.Text.Trim());

            if (chTestpaperList.Count > 0)
            {
                grd_Testpapers.DataSource = chTestpaperList;
                grd_Testpapers.DataBind();
            }
            else
            {
                grd_Testpapers.DataSource = null;
                grd_Testpapers.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}