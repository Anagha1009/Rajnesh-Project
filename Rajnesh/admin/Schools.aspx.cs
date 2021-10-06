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

public partial class admin_Schools : System.Web.UI.Page
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
    
    private CoreWebList<SchoolClass> chSchoolList
    {
        get
        {
            if (Cache["chSchoolList"] != null)
                return (CoreWebList<SchoolClass>)Cache["chSchoolList"];
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
                SchoolClass objSchool = new SchoolClass();
                chSchoolList = objSchool.fn_getSchoolList();
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
            SchoolClass objSchool = new SchoolClass();
            objSchool.iID = int.Parse(grd_Schools.DataKeys[e.RowIndex].Value.ToString());
            CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolByID();
            if (objSchoolList.Count > 0)
            {
                if (File.Exists(MapPath("~/admin/Upload/Schools/" + objSchoolList[0].strPhoto)))
                {
                    File.Delete((MapPath("~/admin/Upload/Schools/" + objSchoolList[0].strPhoto)));
                }
            }

            string strResponse = objSchool.fn_deleteSchool();

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

            grd_Schools.DataSource = objSchool.fn_getSchoolList();
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

                SchoolClass objSchool = new SchoolClass();
                objSchool.iID = int.Parse(grd_Schools.SelectedDataKey.Value.ToString());
                
                dv_Schools.DataSource = objSchool.fn_getSchoolByID();
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
            SchoolClass objSchool = new SchoolClass();

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
            DropDownList ddl_City = (DropDownList)dv_Schools.FindControl("ddl_City");
            TextBox txtTitle = (TextBox)dv_Schools.FindControl("txtTitle");
            TextBox txtRank = (TextBox)dv_Schools.FindControl("txtRank");
            TextBox txtBoard = (TextBox)dv_Schools.FindControl("txtBoard");
            TextBox txtTrust = (TextBox)dv_Schools.FindControl("txtTrust");
            TextBox txtPrincipal = (TextBox)dv_Schools.FindControl("txtPrincipal");
            TextBox txtWebsite = (TextBox)dv_Schools.FindControl("txtWebsite");
            TextBox txtDesc = (TextBox)dv_Schools.FindControl("txtDesc");
            TextBox txtAdmissions = (TextBox)dv_Schools.FindControl("txtAdmissions");
            TextBox txtFacility = (TextBox)dv_Schools.FindControl("txtFacility");
            TextBox txtContactDetails = (TextBox)dv_Schools.FindControl("txtContactDetails");
            FileUpload fu_Image = (FileUpload)dv_Schools.FindControl("fu_Image");
            
            SchoolClass objSchool = new SchoolClass();

            objSchool.iCityID = int.Parse(ddl_City.SelectedValue);
            objSchool.iRank = int.Parse(txtRank.Text);
            objSchool.strTitle = txtTitle.Text;
            objSchool.strDesc = txtDesc.Text;
            objSchool.strAdmissions= txtAdmissions.Text;
            objSchool.strFacilities= txtFacility.Text;
            objSchool.strContactDetails = txtContactDetails.Text;
            objSchool.strAfflialtedBoard= txtBoard.Text;
            objSchool.strTrust = txtTrust.Text;
            objSchool.strPrincipal = txtPrincipal.Text;
            objSchool.strWebsite = txtWebsite.Text;
            
            if (fu_Image.HasFile)
            {
                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_Image.FileName);
                string strDocPath = Server.MapPath("~/admin/Upload/Schools/" + strRanFileName);
                fu_Image.SaveAs(strDocPath);
                objSchool.strPhoto = strRanFileName;
            }
            
            string strResponse = objSchool.fn_saveSchool();

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
            grd_Schools.DataSource = objSchool.fn_getSchoolList();
            grd_Schools.DataBind();

            // reset fields
            ddl_City.SelectedIndex = 0;
            txtTitle.Text = "";
            txtRank.Text = "";
            txtDesc.Text = "";
            txtBoard.Text = "";
            txtPrincipal.Text = "";
            txtContactDetails.Text = "";
            txtTrust.Text = "";
            txtAdmissions.Text = "";
            txtFacility.Text = "";
            txtWebsite.Text = "";
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
            DropDownList ddl_City = (DropDownList)dv_Schools.FindControl("ddl_City");
            TextBox txtTitle = (TextBox)dv_Schools.FindControl("txtTitle");
            TextBox txtRank = (TextBox)dv_Schools.FindControl("txtRank");
            TextBox txtBoard = (TextBox)dv_Schools.FindControl("txtBoard");
            TextBox txtTrust = (TextBox)dv_Schools.FindControl("txtTrust");
            TextBox txtPrincipal = (TextBox)dv_Schools.FindControl("txtPrincipal");
            TextBox txtWebsite = (TextBox)dv_Schools.FindControl("txtWebsite");
            TextBox txtDesc = (TextBox)dv_Schools.FindControl("txtDesc");
            TextBox txtAdmissions = (TextBox)dv_Schools.FindControl("txtAdmissions");
            TextBox txtFacility = (TextBox)dv_Schools.FindControl("txtFacility");
            TextBox txtContactDetails = (TextBox)dv_Schools.FindControl("txtContactDetails");
            FileUpload fu_Image = (FileUpload)dv_Schools.FindControl("fu_Image");
            HiddenField hfImage = (HiddenField)dv_Schools.FindControl("hfImage");

            SchoolClass objSchool = new SchoolClass();
            objSchool.iID = int.Parse(dv_Schools.DataKey.Value.ToString());
            objSchool.iCityID = int.Parse(ddl_City.SelectedValue);
            objSchool.iRank = int.Parse(txtRank.Text);
            objSchool.strTitle = txtTitle.Text;
            objSchool.strDesc = txtDesc.Text;
            objSchool.strAdmissions = txtAdmissions.Text;
            objSchool.strFacilities = txtFacility.Text;
            objSchool.strContactDetails = txtContactDetails.Text;
            objSchool.strAfflialtedBoard = txtBoard.Text;
            objSchool.strTrust = txtTrust.Text;
            objSchool.strPrincipal = txtPrincipal.Text;
            objSchool.strWebsite = txtWebsite.Text;

            if (fu_Image.HasFile)
            {
                SchoolClass oSchoolImages = new SchoolClass();
                oSchoolImages.iID = int.Parse(dv_Schools.DataKey.Value.ToString());
                CoreWebList<SchoolClass> oSchoolImagesList = oSchoolImages.fn_getSchoolByID();
                if (oSchoolImagesList.Count > 0)
                {
                    if (File.Exists(MapPath("~/admin/Upload/Schools/" + oSchoolImagesList[0].strPhoto)))
                    {
                        File.Delete((MapPath("~/admin/Upload/Schools/" + oSchoolImagesList[0].strPhoto)));
                    }
                }

                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_Image.FileName);
                string strDocPath = Server.MapPath("~/admin/Upload/Schools/" + strRanFileName);
                fu_Image.SaveAs(strDocPath);
                objSchool.strPhoto = strRanFileName;
            }
            else
            {
                objSchool.strPhoto = hfImage.Value;
            }

            string strResponse = objSchool.fn_editSchool();

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

            objSchool.iID = int.Parse(grd_Schools.SelectedDataKey.Value.ToString());

            dv_Schools.DataSource = objSchool.fn_getSchoolByID();
            dv_Schools.DataBind();

            // Bind Data To grid            
            grd_Schools.DataSource = objSchool.fn_getSchoolList();
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
                    SchoolClass objSchool = new SchoolClass();
                    objSchool.iID = int.Parse(grd_Schools.SelectedDataKey.Value.ToString());

                    dv_Schools.DataSource = objSchool.fn_getSchoolByID();
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
            DropDownList ddl_City = (DropDownList)dv_Schools.FindControl("ddl_City");

            if (dv_Schools.CurrentMode == DetailsViewMode.Insert)
            {
                fn_BindCityDropDownList();
            }

            if (dv_Schools.CurrentMode == DetailsViewMode.Edit)
            {
                SchoolClass objSchool = new SchoolClass();
                objSchool.iID = int.Parse(grd_Schools.SelectedDataKey.Value.ToString());
                CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolByID();
                if (objSchoolList.Count > 0)
                {
                    fn_BindCityDropDownList();
                    ddl_City.SelectedValue = objSchoolList[0].iCityID.ToString();
                }
            }

            if (dv_Schools.CurrentMode == DetailsViewMode.ReadOnly)
            {
                Label lblCity = (Label)dv_Schools.FindControl("lblCity");

                SchoolClass objSchool = new SchoolClass();
                objSchool.iID = int.Parse(grd_Schools.SelectedDataKey.Value.ToString());
                CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolByID();
                if (objSchoolList.Count > 0)
                {
                    CityClass objCity = new CityClass();
                    objCity.iID = objSchoolList[0].iCityID;
                    CoreWebList<CityClass> objCityList = objCity.fn_getCityByID();
                    if (objCityList.Count > 0)
                    {
                        lblCity.Text = objCityList[0].strTitle;
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

    protected void fn_BindCityDropDownList()
    {
        try
        {
            DropDownList ddl_City = (DropDownList)dv_Schools.FindControl("ddl_City");
            if (ddl_City != null)
            {
                CityClass objCity = new CityClass();
                ddl_City.DataSource = objCity.fn_getCityList();
                ddl_City.DataTextField = "strTitle";
                ddl_City.DataValueField = "iID";
                ddl_City.DataBind();
                ddl_City.Items.Insert(0, new ListItem("Select", "0"));
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
            SchoolClass objSchool = new SchoolClass();
            objSchool.strTitle = txtSearch.Text;
            chSchoolList = objSchool.fn_getSchoolByKeys();
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

    protected void grd_Records_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Featured")
            {
                ImageButton btnFeatured = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnFeatured.Parent.Parent;

                SchoolClass objSchool = new SchoolClass();
                objSchool.iID = Convert.ToInt32(e.CommandArgument);
                CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolByID();
                if (objSchoolList.Count > 0)
                {
                    if (objSchoolList[0].bFeatured == true)
                    {
                        btnFeatured.ImageUrl = "~/admin/images/cross.gif";
                        objSchool.bFeatured = false;
                    }
                    else
                    {
                        btnFeatured.ImageUrl = "~/admin/images/Tick.gif";
                        objSchool.bFeatured = true;
                    }
                }

                objSchool.fn_ChangeSchoolFeaturedStatus();
            }

            else if (e.CommandName == "HomeFeatured")
            {
                ImageButton btnHomeFeatured = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnHomeFeatured.Parent.Parent;

                SchoolClass objSchool = new SchoolClass();
                objSchool.iID = Convert.ToInt32(e.CommandArgument);
                CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolByID();
                if (objSchoolList.Count > 0)
                {
                    if (objSchoolList[0].bHomeFeatured == true)
                    {
                        btnHomeFeatured.ImageUrl = "~/admin/images/cross.gif";
                        objSchool.bHomeFeatured = false;
                    }
                    else
                    {
                        btnHomeFeatured.ImageUrl = "~/admin/images/Tick.gif";
                        objSchool.bHomeFeatured = true;
                    }
                }

                objSchool.fn_ChangeSchoolHomeFeaturedStatus();
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
                HiddenField hfFeatured = (HiddenField)e.Row.FindControl("hfFeatured");
                ImageButton btnFeatured = (ImageButton)e.Row.FindControl("btnFeatured");

                if (hfFeatured != null)
                {
                    if (bool.Parse(hfFeatured.Value) == true)
                    {
                        btnFeatured.ImageUrl = "~/admin/images/Tick.gif";
                    }
                    else
                    {
                        btnFeatured.ImageUrl = "~/admin/images/cross.gif";
                    }
                }

                HiddenField hfHomeFeatured = (HiddenField)e.Row.FindControl("hfHomeFeatured");
                ImageButton btnHomeFeatured = (ImageButton)e.Row.FindControl("btnHomeFeatured");

                if (hfHomeFeatured != null)
                {
                    if (bool.Parse(hfHomeFeatured.Value) == true)
                    {
                        btnHomeFeatured.ImageUrl = "~/admin/images/Tick.gif";
                    }
                    else
                    {
                        btnHomeFeatured.ImageUrl = "~/admin/images/cross.gif";
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
}