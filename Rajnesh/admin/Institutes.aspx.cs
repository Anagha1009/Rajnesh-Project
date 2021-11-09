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

public partial class admin_Institutes : System.Web.UI.Page
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
    
    private CoreWebList<InstituteClass> chInstituteList
    {
        get
        {
            if (Cache["chInstituteList"] != null)
                return (CoreWebList<InstituteClass>)Cache["chInstituteList"];
            return null;
        }
        set
        {
            Cache["chInstituteList"] = value;
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
                InstituteClass objInstitute = new InstituteClass();
                chInstituteList = objInstitute.fn_getInstituteList();
                if (chInstituteList.Count > 0)
                {
                    grd_Institutes.DataSource = chInstituteList;
                }
                else
                {
                    grd_Institutes.DataSource = null;
                }
                grd_Institutes.DataBind();

                if (grd_Institutes.SelectedIndex < 0)
                {
                    dv_Institutes.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Institutes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Institutes.PageIndex = e.NewPageIndex;
            grd_Institutes.DataSource = chInstituteList;
            grd_Institutes.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Institutes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            InstituteClass objInstitute = new InstituteClass();
            objInstitute.iID = int.Parse(grd_Institutes.DataKeys[e.RowIndex].Value.ToString());
            CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByID();
            if (objInstituteList.Count > 0)
            {
                if (File.Exists(MapPath("~/admin/Upload/Institutes/" + objInstituteList[0].strPhoto)))
                {
                    File.Delete((MapPath("~/admin/Upload/Institutes/" + objInstituteList[0].strPhoto)));
                }
            }

            string strResponse = objInstitute.fn_deleteInstitute();

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

            grd_Institutes.DataSource = objInstitute.fn_getInstituteList();
            grd_Institutes.DataBind();

            dv_Institutes.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Institutes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Institutes.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Institutes.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_Institutes.ChangeMode(DetailsViewMode.Edit);

                InstituteClass objInstitute = new InstituteClass();
                objInstitute.iID = int.Parse(grd_Institutes.SelectedDataKey.Value.ToString());
                
                dv_Institutes.DataSource = objInstitute.fn_getInstituteByID();
                dv_Institutes.DataBind();

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

    protected void grd_Institutes_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            InstituteClass objInstitute = new InstituteClass();

            DataTable dt = (DataTable)chInstituteList;
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

            grd_Institutes.DataSource = dv;
            grd_Institutes.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Institutes_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            DropDownList ddl_City = (DropDownList)dv_Institutes.FindControl("ddl_City");
            TextBox txtTitle = (TextBox)dv_Institutes.FindControl("txtTitle");
            TextBox txtEstablishedIn = (TextBox)dv_Institutes.FindControl("txtEstablishedIn");
            TextBox txtAffiliatedTo = (TextBox)dv_Institutes.FindControl("txtAffiliatedTo");
            TextBox txtWebsite = (TextBox)dv_Institutes.FindControl("txtWebsite");
            TextBox txtDesc = (TextBox)dv_Institutes.FindControl("txtDesc");
            TextBox txtPlacements = (TextBox)dv_Institutes.FindControl("txtPlacements");
            TextBox txtFacility = (TextBox)dv_Institutes.FindControl("txtFacility");
            TextBox txtAdmissions = (TextBox)dv_Institutes.FindControl("txtAdmissions");
            TextBox txtContactDetails = (TextBox)dv_Institutes.FindControl("txtContactDetails");
            FileUpload fu_Image = (FileUpload)dv_Institutes.FindControl("fu_Image");
            
            InstituteClass objInstitute = new InstituteClass();

            objInstitute.iCityID = int.Parse(ddl_City.SelectedValue);
            objInstitute.strTitle = txtTitle.Text;
            objInstitute.strDesc = txtDesc.Text;
            objInstitute.strEstablishedIn= txtEstablishedIn.Text;
            objInstitute.strAffiliatedTo= txtAffiliatedTo.Text;
            objInstitute.strContactDetails = txtContactDetails.Text;
            objInstitute.strPlacements = txtPlacements.Text;
            objInstitute.strAdmissions = txtAdmissions.Text;
            objInstitute.strFacilities = txtFacility.Text;
            objInstitute.strWebsite = txtWebsite.Text;

            string strResponse = "";
            if (fu_Image.HasFile)
            {
                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_Image.FileName);
                decimal size = Math.Round(((decimal)fu_Image.PostedFile.ContentLength / (decimal)1024), 2);
                if (size < 500)
                {
                    string strDocPath = Server.MapPath("~/admin/Upload/Institutes/" + strRanFileName);
                    fu_Image.SaveAs(strDocPath);
                    objInstitute.strPhoto = strRanFileName;
                    strResponse = objInstitute.fn_saveInstitute();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your file size should be less than 500kb')", true);
                }                
            }

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
            grd_Institutes.DataSource = objInstitute.fn_getInstituteList();
            grd_Institutes.DataBind();

            // reset fields
            ddl_City.SelectedIndex = 0;
            txtTitle.Text = "";
            txtDesc.Text = "";
            txtEstablishedIn.Text = "";
            txtAffiliatedTo.Text = "";
            txtContactDetails.Text = "";
            txtPlacements.Text = "";
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

    protected void dv_Institutes_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            DropDownList ddl_City = (DropDownList)dv_Institutes.FindControl("ddl_City");
            TextBox txtTitle = (TextBox)dv_Institutes.FindControl("txtTitle");
            TextBox txtEstablishedIn = (TextBox)dv_Institutes.FindControl("txtEstablishedIn");
            TextBox txtAffiliatedTo = (TextBox)dv_Institutes.FindControl("txtAffiliatedTo");
            TextBox txtWebsite = (TextBox)dv_Institutes.FindControl("txtWebsite");
            TextBox txtDesc = (TextBox)dv_Institutes.FindControl("txtDesc");
            TextBox txtPlacements = (TextBox)dv_Institutes.FindControl("txtPlacements");
            TextBox txtFacility = (TextBox)dv_Institutes.FindControl("txtFacility");
            TextBox txtAdmissions = (TextBox)dv_Institutes.FindControl("txtAdmissions");
            TextBox txtContactDetails = (TextBox)dv_Institutes.FindControl("txtContactDetails");
            FileUpload fu_Image = (FileUpload)dv_Institutes.FindControl("fu_Image");
            HiddenField hfImage = (HiddenField)dv_Institutes.FindControl("hfImage");

            InstituteClass objInstitute = new InstituteClass();
            objInstitute.iID = int.Parse(dv_Institutes.DataKey.Value.ToString());
            objInstitute.iCityID = int.Parse(ddl_City.SelectedValue);
            objInstitute.strTitle = txtTitle.Text;
            objInstitute.strDesc = txtDesc.Text;
            objInstitute.strEstablishedIn = txtEstablishedIn.Text;
            objInstitute.strAffiliatedTo = txtAffiliatedTo.Text;
            objInstitute.strContactDetails = txtContactDetails.Text;
            objInstitute.strPlacements = txtPlacements.Text;
            objInstitute.strAdmissions = txtAdmissions.Text;
            objInstitute.strFacilities = txtFacility.Text;
            objInstitute.strWebsite = txtWebsite.Text;

            string strResponse = "";
            if (fu_Image.HasFile)
            {
                InstituteClass oInstituteImages = new InstituteClass();
                oInstituteImages.iID = int.Parse(dv_Institutes.DataKey.Value.ToString());
                CoreWebList<InstituteClass> oInstituteImagesList = oInstituteImages.fn_getInstituteByID();
                if (oInstituteImagesList.Count > 0)
                {
                    if (File.Exists(MapPath("~/admin/Upload/Institutes/" + oInstituteImagesList[0].strPhoto)))
                    {
                        File.Delete((MapPath("~/admin/Upload/Institutes/" + oInstituteImagesList[0].strPhoto)));
                    }
                }

                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_Image.FileName);
                decimal size = Math.Round(((decimal)fu_Image.PostedFile.ContentLength / (decimal)1024), 2);
                if (size < 500)
                {
                    string strDocPath = Server.MapPath("~/admin/Upload/Institutes/" + strRanFileName);
                    fu_Image.SaveAs(strDocPath);
                    objInstitute.strPhoto = strRanFileName;
                    strResponse = objInstitute.fn_editInstitute();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your file size should be less than 500kb')", true);
                }
            }
            else
            {
                objInstitute.strPhoto = hfImage.Value;
            }

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

            dv_Institutes.ChangeMode(DetailsViewMode.ReadOnly);

            objInstitute.iID = int.Parse(grd_Institutes.SelectedDataKey.Value.ToString());

            dv_Institutes.DataSource = objInstitute.fn_getInstituteByID();
            dv_Institutes.DataBind();

            // Bind Data To grid            
            grd_Institutes.DataSource = objInstitute.fn_getInstituteList();
            grd_Institutes.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Institutes_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Institutes.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Institutes.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Institutes.ChangeMode(e.NewMode);

                if (grd_Institutes.SelectedIndex >= 0)
                {
                    InstituteClass objInstitute = new InstituteClass();
                    objInstitute.iID = int.Parse(grd_Institutes.SelectedDataKey.Value.ToString());

                    dv_Institutes.DataSource = objInstitute.fn_getInstituteByID();
                    dv_Institutes.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Institutes_DataBound(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddl_City = (DropDownList)dv_Institutes.FindControl("ddl_City");

            if (dv_Institutes.CurrentMode == DetailsViewMode.Insert)
            {
                fn_BindCityDropDownList();
            }

            if (dv_Institutes.CurrentMode == DetailsViewMode.Edit)
            {
                InstituteClass objInstitute = new InstituteClass();
                objInstitute.iID = int.Parse(grd_Institutes.SelectedDataKey.Value.ToString());
                CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByID();
                if (objInstituteList.Count > 0)
                {
                    fn_BindCityDropDownList();
                    ddl_City.SelectedValue = objInstituteList[0].iCityID.ToString();
                }
            }

            if (dv_Institutes.CurrentMode == DetailsViewMode.ReadOnly)
            {
                Label lblCity = (Label)dv_Institutes.FindControl("lblCity");

                InstituteClass objInstitute = new InstituteClass();
                objInstitute.iID = int.Parse(grd_Institutes.SelectedDataKey.Value.ToString());
                CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByID();
                if (objInstituteList.Count > 0)
                {
                    CityClass objCity = new CityClass();
                    objCity.iID = objInstituteList[0].iCityID;
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
            DropDownList ddl_City = (DropDownList)dv_Institutes.FindControl("ddl_City");
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
            InstituteClass objInstitute = new InstituteClass();
            objInstitute.strTitle = txtSearch.Text;
            chInstituteList = objInstitute.fn_getInstituteByKeys();
            if (chInstituteList.Count > 0)
            {
                grd_Institutes.DataSource = chInstituteList;
                grd_Institutes.DataBind();
            }
            else
            {
                grd_Institutes.DataSource = null;
                grd_Institutes.DataBind();
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

                InstituteClass objInstitute = new InstituteClass();
                objInstitute.iID = Convert.ToInt32(e.CommandArgument);
                CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByID();
                if (objInstituteList.Count > 0)
                {
                    if (objInstituteList[0].bFeatured == true)
                    {
                        btnFeatured.ImageUrl = "~/admin/images/cross.gif";
                        objInstitute.bFeatured = false;
                    }
                    else
                    {
                        btnFeatured.ImageUrl = "~/admin/images/Tick.gif";
                        objInstitute.bFeatured = true;
                    }
                }

                objInstitute.fn_ChangeInstituteFeaturedStatus();
            }

            else if (e.CommandName == "HomeFeatured")
            {
                ImageButton btnHomeFeatured = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnHomeFeatured.Parent.Parent;

                InstituteClass objInstitute = new InstituteClass();
                objInstitute.iID = Convert.ToInt32(e.CommandArgument);
                CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByID();
                if (objInstituteList.Count > 0)
                {
                    if (objInstituteList[0].bHomeFeatured == true)
                    {
                        btnHomeFeatured.ImageUrl = "~/admin/images/cross.gif";
                        objInstitute.bHomeFeatured = false;
                    }
                    else
                    {
                        btnHomeFeatured.ImageUrl = "~/admin/images/Tick.gif";
                        objInstitute.bHomeFeatured = true;
                    }
                }

                objInstitute.fn_ChangeInstituteHomeFeaturedStatus();
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