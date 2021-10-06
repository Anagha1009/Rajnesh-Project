using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using FredCK.FCKeditorV2;
using yo_lib;
using System.Text.RegularExpressions;

public partial class admin_UniversityCourses : System.Web.UI.Page
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
                fn_BindGrid();

                if (grd_CourseList.SelectedIndex < 0)
                {
                    dv_CourseList.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }


    protected void grd_CourseList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            UniversityListClass objUC = new UniversityListClass();
            objUC.iCourseID = int.Parse(grd_CourseList.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objUC.fn_DeleteUniversityCourses();

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

            fn_BindGrid();

            dv_CourseList.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_CourseList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_CourseList.SelectedIndex < 0)
            {
                dv_CourseList.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_CourseList.ChangeMode(DetailsViewMode.Edit);

                fn_BindDetailsView();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_InstFeature_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            UniversityListClass objUC = new UniversityListClass();
            objUC.iID = int.Parse(Request.QueryString["UniversityID"].ToString());
            CoreWebList<UniversityListClass> objUCList = objUC.fn_GetUniversityCourseListByUniversityID();

            if (objUCList.Count > 0)
            {
                DataTable dtIM = (DataTable)objUCList;

                DataView dv = new DataView(dtIM);

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

                grd_CourseList.DataSource = dv;
                grd_CourseList.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_InstFeature_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_CourseList.PageIndex = e.NewPageIndex;

            fn_BindGrid();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_CourseList_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_CourseList.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_CourseList.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_CourseList.ChangeMode(e.NewMode);

                if (grd_CourseList.SelectedIndex >= 0)
                {
                    fn_BindDetailsView();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }


    protected void dv_CourseList_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtCourseTitle = (TextBox)dv_CourseList.FindControl("txtCourseTitle");
            FCKeditor FckCourseDetails = (FCKeditor)dv_CourseList.FindControl("FckCourseDetails");

            TextBox txtFileName = (TextBox)dv_CourseList.FindControl("txtFileName");
            TextBox txtheader1 = (TextBox)dv_CourseList.FindControl("txtheader1");
            TextBox txtheader2 = (TextBox)dv_CourseList.FindControl("txtheader2");
            TextBox txtheader3 = (TextBox)dv_CourseList.FindControl("txtheader3");
            TextBox txtMetaTitle = (TextBox)dv_CourseList.FindControl("txtMetaTitle");
            TextBox txtMetaDesc = (TextBox)dv_CourseList.FindControl("txtMetaDesc");
            TextBox txtMetaKeys = (TextBox)dv_CourseList.FindControl("txtMetaKeys");
            TextBox txtSearch = (TextBox)dv_CourseList.FindControl("txtSearch");

            string FileName = txtFileName.Text.ToString().Trim().Replace(" ", "-").Replace("&", "-").Replace(":", "-").Replace("?", "-").Replace(",", "-").Replace("%", "-").Replace("/", "-").Replace("---", "-").Replace("--", "-") + ".aspx";

            UniversityListClass objUC = new UniversityListClass();

            objUC.iID = int.Parse(Request.QueryString["UniversityID"].ToString());

            objUC.strCourseName = txtCourseTitle.Text.Trim();
            objUC.strCourseDetails = FckCourseDetails.Value;

            objUC.strFileName = FileName;
            objUC.strHeader1 = txtheader1.Text;
            objUC.strHeader2 = txtheader2.Text;
            objUC.strHeader3 = txtheader3.Text;
            objUC.strMetaTitle = txtMetaTitle.Text;
            objUC.strMetaDesc = txtMetaDesc.Text;
            objUC.strMetaKeywords = txtMetaKeys.Text;
            objUC.strKeywords = txtSearch.Text;

            string strResponse = objUC.fn_SaveUniversityCourses();

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

            txtCourseTitle.Text = "";
            FckCourseDetails.Value = "";
            
            txtFileName.Text = "";
            txtheader1.Text = "";
            txtheader2.Text = "";
            txtheader3.Text = "";
            txtMetaTitle.Text = "";
            txtMetaKeys.Text = "";
            txtMetaDesc.Text = "";
            txtSearch.Text = "";

            fn_BindGrid();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void dv_CourseList_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtCourseTitle = (TextBox)dv_CourseList.FindControl("txtCourseTitle");
            FCKeditor FckCourseDetails = (FCKeditor)dv_CourseList.FindControl("FckCourseDetails");

            TextBox txtFileName = (TextBox)dv_CourseList.FindControl("txtFileName");
            TextBox txtheader1 = (TextBox)dv_CourseList.FindControl("txtheader1");
            TextBox txtheader2 = (TextBox)dv_CourseList.FindControl("txtheader2");
            TextBox txtheader3 = (TextBox)dv_CourseList.FindControl("txtheader3");
            TextBox txtMetaTitle = (TextBox)dv_CourseList.FindControl("txtMetaTitle");
            TextBox txtMetaDesc = (TextBox)dv_CourseList.FindControl("txtMetaDesc");
            TextBox txtMetaKeys = (TextBox)dv_CourseList.FindControl("txtMetaKeys");
            TextBox txtSearch = (TextBox)dv_CourseList.FindControl("txtSearch");
            HiddenField hfFile = (HiddenField)dv_CourseList.FindControl("hfFile");

            string FileName = "";

            if (txtFileName.Text.Contains(".aspx"))
            {
                FileName = txtFileName.Text.ToString().Replace(" ", "-").Replace("&", "-").Replace(":", "-").Replace("?", "-").Replace(",", "-").Replace("%", "-").Replace("/", "-").Replace("---", "-").Replace("--", "-");
            }
            else
            {
                FileName = txtFileName.Text.ToString().Trim().Replace(" ", "-").Replace("&", "-").Replace(":", "-").Replace("?", "-").Replace(",", "-").Replace("%", "-").Replace("/", "-").Replace("---", "-").Replace("--", "-") + ".aspx";
            }

            UniversityListClass objUC = new UniversityListClass();
            objUC.iCourseID = int.Parse(dv_CourseList.DataKey.Value.ToString());
            objUC.strCourseName = txtCourseTitle.Text.Trim();
            objUC.strCourseDetails = FckCourseDetails.Value;

            objUC.strFileName = FileName;
            objUC.strHeader1 = txtheader1.Text;
            objUC.strHeader2 = txtheader2.Text;
            objUC.strHeader3 = txtheader3.Text;
            objUC.strMetaTitle = txtMetaTitle.Text;
            objUC.strMetaDesc = txtMetaDesc.Text;
            objUC.strMetaKeywords = txtMetaKeys.Text;
            objUC.strKeywords = txtSearch.Text;


            string strResponse = objUC.fn_EditUniversityCourses();

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

            fn_BindGrid();

            dv_CourseList.ChangeMode(DetailsViewMode.ReadOnly);

            fn_BindDetailsView();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    private void fn_BindGrid()
    {
        try
        {

            UniversityListClass objUC = new UniversityListClass();
            objUC.iID = int.Parse(Request.QueryString["UniversityID"].ToString());
            CoreWebList<UniversityListClass> objUCList = objUC.fn_GetUniversityCourseListByUniversityID();

            if (objUCList.Count > 0)
            {
                DataTable dtIM = (DataTable)objUCList;

                grd_CourseList.DataSource = dtIM;
            }

            grd_CourseList.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    private void fn_BindDetailsView()
    {
        try
        {
            UniversityListClass objUC = new UniversityListClass();
            objUC.iCourseID = int.Parse(grd_CourseList.SelectedDataKey.Value.ToString());

            CoreWebList<UniversityListClass> objUCList = objUC.fn_GetUniversityCourseListByCourseID();

            if (objUCList.Count > 0)
            {
                DataTable dtIM = (DataTable)objUCList;

                dv_CourseList.DataSource = dtIM;
                dv_CourseList.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}