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

public partial class admin_Faculty : System.Web.UI.Page
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
    
    private CoreWebList<FacultyClass> chFacultyList
    {
        get
        {
            if (Cache["chFacultyList"] != null)
                return (CoreWebList<FacultyClass>)Cache["chFacultyList"];
            return null;
        }
        set
        {
            Cache["chFacultyList"] = value;
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

            if (Request.QueryString["UniversityID"] != null)
            {
                UniversityID = int.Parse(Request.QueryString["UniversityID"].ToString());
            }
            
            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='default.aspx'>Home</a>&nbsp;>&nbsp;Faculty";

            if (!IsPostBack)
            {
                // Bind Data To grid
                fn_BindRecords();

                if (grd_Faculty.SelectedIndex < 0)
                {
                    dv_Faculty.ChangeMode(DetailsViewMode.Insert);
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
            FacultyClass objFaculty = new FacultyClass();
            objFaculty.iUniversityID = UniversityID;
            chFacultyList = objFaculty.fn_getFacultyByUniversityID();

            if (chFacultyList.Count > 0)
            {
                grd_Faculty.DataSource = chFacultyList;
            }
            else
            {
                grd_Faculty.DataSource = null;
            }
            grd_Faculty.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void grd_Faculty_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Faculty.PageIndex = e.NewPageIndex;
            grd_Faculty.DataSource = chFacultyList;
            grd_Faculty.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Faculty_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            FacultyClass objFaculty = new FacultyClass();
            objFaculty.iID = int.Parse(grd_Faculty.DataKeys[e.RowIndex].Value.ToString());
            CoreWebList<FacultyClass> oArticleList = objFaculty.fn_getFacultyByID();
            if (oArticleList.Count > 0)
            {
                if (File.Exists(MapPath("~/admin/Upload/Faculty/" + oArticleList[0].strFacultyPhoto)))
                {
                    File.Delete((MapPath("~/admin/Upload/Faculty/" + oArticleList[0].strFacultyPhoto)));
                }
            }

            string strResponse = objFaculty.fn_deleteFaculty();

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

            dv_Faculty.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Faculty_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Faculty.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Faculty.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_Faculty.ChangeMode(DetailsViewMode.Edit);

                FacultyClass objFaculty = new FacultyClass();
                objFaculty.iID = int.Parse(grd_Faculty.SelectedDataKey.Value.ToString());
                
                dv_Faculty.DataSource = objFaculty.fn_getFacultyByID();
                dv_Faculty.DataBind();

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

    protected void grd_Faculty_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            FacultyClass objFaculty = new FacultyClass();

            DataTable dt = (DataTable)chFacultyList;
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

            grd_Faculty.DataSource = dv;
            grd_Faculty.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Faculty_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtName = (TextBox)dv_Faculty.FindControl("txtName");
            TextBox txtDepartment = (TextBox)dv_Faculty.FindControl("txtDepartment");
            TextBox txtDesignation = (TextBox)dv_Faculty.FindControl("txtDesignation");
            TextBox txtProfile = (TextBox)dv_Faculty.FindControl("txtProfile");
            FileUpload fu_Image = (FileUpload)dv_Faculty.FindControl("fu_Image");
            
            FacultyClass objFaculty = new FacultyClass();
            objFaculty.iUniversityID = UniversityID;
            objFaculty.strFacultyName = txtName.Text;
            objFaculty.strFacultyDept = txtDepartment.Text;
            objFaculty.strFacultyDesignation = txtDesignation.Text;
            objFaculty.strFacultyProfile= txtProfile.Text;

            if (fu_Image.HasFile)
            {
                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_Image.FileName);
                string strDocPath = Server.MapPath("~/admin/Upload/Faculty/" + strRanFileName);
                fu_Image.SaveAs(strDocPath);
                objFaculty.strFacultyPhoto = strRanFileName;
            }

            string strResponse = objFaculty.fn_saveFaculty();

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
            fn_BindRecords();

            // reset fields
            txtName.Text = "";
            txtDepartment.Text = "";
            txtDesignation.Text = "";
            txtProfile.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void dv_Faculty_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            string strResponse = "";

            TextBox txtName = (TextBox)dv_Faculty.FindControl("txtName");
            TextBox txtDepartment = (TextBox)dv_Faculty.FindControl("txtDepartment");
            TextBox txtDesignation = (TextBox)dv_Faculty.FindControl("txtDesignation");
            TextBox txtProfile = (TextBox)dv_Faculty.FindControl("txtProfile");
            FileUpload fu_Image = (FileUpload)dv_Faculty.FindControl("fu_Image");
            HiddenField hfImage = (HiddenField)dv_Faculty.FindControl("hfImage");

            FacultyClass objFaculty = new FacultyClass();
            objFaculty.iID = int.Parse(dv_Faculty.DataKey.Value.ToString());
            objFaculty.iUniversityID = UniversityID;
            objFaculty.strFacultyName = txtName.Text;
            objFaculty.strFacultyDept = txtDepartment.Text;
            objFaculty.strFacultyDesignation = txtDesignation.Text;
            objFaculty.strFacultyProfile = txtProfile.Text;

            if (fu_Image.HasFile)
            {
                FacultyClass oArticle = new FacultyClass();
                oArticle.iID = int.Parse(dv_Faculty.DataKey.Value.ToString());
                CoreWebList<FacultyClass> oArticleList = oArticle.fn_getFacultyByID();
                if (oArticleList.Count > 0)
                {
                    if (File.Exists(MapPath("~/admin/Upload/Faculty/" + oArticleList[0].strFacultyPhoto)))
                    {
                        File.Delete((MapPath("~/admin/Upload/Faculty/" + oArticleList[0].strFacultyPhoto)));
                    }
                }

                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_Image.FileName);
                string strDocPath = Server.MapPath("~/admin/Upload/Faculty/" + strRanFileName);
                fu_Image.SaveAs(strDocPath);
                objFaculty.strFacultyPhoto = strRanFileName;
            }
            else
            {
                objFaculty.strFacultyPhoto = hfImage.Value;
            }

            strResponse = objFaculty.fn_editFaculty();

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

            dv_Faculty.ChangeMode(DetailsViewMode.ReadOnly);

            objFaculty.iID = int.Parse(grd_Faculty.SelectedDataKey.Value.ToString());

            dv_Faculty.DataSource = objFaculty.fn_getFacultyByID();
            dv_Faculty.DataBind();

            // Bind Data To grid           
            fn_BindRecords();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Faculty_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Faculty.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Faculty.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Faculty.ChangeMode(e.NewMode);

                if (grd_Faculty.SelectedIndex >= 0)
                {
                    FacultyClass objFaculty = new FacultyClass();
                    objFaculty.iID = int.Parse(grd_Faculty.SelectedDataKey.Value.ToString());

                    dv_Faculty.DataSource = objFaculty.fn_getFacultyByID();
                    dv_Faculty.DataBind();
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
            FacultyClass objFaculty = new FacultyClass();

            chFacultyList = objFaculty.fn_getFacultyByKeys(txtSearch.Text.Trim());

            if (chFacultyList.Count > 0)
            {
                grd_Faculty.DataSource = chFacultyList;
                grd_Faculty.DataBind();
            }
            else
            {
                grd_Faculty.DataSource = null;
                grd_Faculty.DataBind();
            }

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}