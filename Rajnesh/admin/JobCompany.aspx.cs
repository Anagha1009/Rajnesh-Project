using System;
using System.Collections.Generic;
using System.Data;
using FredCK.FCKeditorV2;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;
using System.IO;

public partial class admin_Articles : System.Web.UI.Page
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

    private CoreWebList<JobCompanyClass> chJobCompanyList
    {
        get
        {
            if (Cache["chJobCompanyList"] != null)
                return (CoreWebList<JobCompanyClass>)Cache["chJobCompanyList"];
            return null;
        }
        set
        {
            Cache["chJobCompanyList"] = value;
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
                JobCompanyClass objIC = new JobCompanyClass();
                chJobCompanyList = objIC.fn_Get_JobCompanyList();
                if (chJobCompanyList.Count > 0)
                {
                    grdCompany.DataSource = chJobCompanyList;
                }
                else
                {
                    grdCompany.DataSource = null;
                }

                grdCompany.DataBind();

                if (grdCompany.SelectedIndex < 0)
                {
                    dvCompany.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + "Line :" + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grdCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            JobCompanyClass objAC = new JobCompanyClass();

            grdCompany.PageIndex = e.NewPageIndex;
            grdCompany.DataSource = chJobCompanyList;
            grdCompany.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grdCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            JobCompanyClass objIC = new JobCompanyClass();
            objIC.iID = int.Parse(grdCompany.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objIC.fn_DeleteJobCompany();

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

            chJobCompanyList = objIC.fn_Get_JobCompanyList();
            grdCompany.DataSource = chJobCompanyList;
            grdCompany.DataBind();

            dvCompany.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grdCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grdCompany.SelectedIndex < 0)
            {
                // Insert Mode
                dvCompany.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dvCompany.ChangeMode(DetailsViewMode.Edit);

                JobCompanyClass objIC = new JobCompanyClass();
                objIC.iID = int.Parse(grdCompany.SelectedDataKey.Value.ToString());

                dvCompany.DataSource = objIC.fn_GetJobCompanyByID();
                dvCompany.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }


    protected void dvCompany_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            DropDownList ddlCategory = (DropDownList)dvCompany.FindControl("ddlCategory");
            TextBox txtTitle = (TextBox)dvCompany.FindControl("txtTitle");
            FCKeditor fckDesc = (FCKeditor)dvCompany.FindControl("fckDesc");
            FCKeditor fckContacts = (FCKeditor)dvCompany.FindControl("fckContacts");
            TextBox txtEmail = (TextBox)dvCompany.FindControl("txtEmail");
            CheckBox chkFeatured = (CheckBox)dvCompany.FindControl("chkFeatured");
            FileUpload fu_Image = (FileUpload)dvCompany.FindControl("fu_Image");

            JobCompanyClass objIC = new JobCompanyClass();
            objIC.iCategoryID = int.Parse(ddlCategory.SelectedValue.ToString());
            objIC.strJobCompanyName = txtTitle.Text;
            objIC.strJobCompanyDesc = fckDesc.Value;
            objIC.strContactDetails = fckContacts.Value;

            if (chkFeatured.Checked)
            {
                objIC.bFeatured = true;
            }
            else
            {
                objIC.bFeatured = false;
            }

            if (fu_Image.HasFile)
            {
                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_Image.FileName);
                string strDocPath = Server.MapPath("~/Logos/" + strRanFileName);
                fu_Image.SaveAs(strDocPath);
                objIC.strLogo = strRanFileName;
            }

            objIC.strEmail = txtEmail.Text;

            string strResponse = objIC.fn_SaveJobCompany();

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
            chJobCompanyList = objIC.fn_Get_JobCompanyList();
            grdCompany.DataSource = chJobCompanyList;
            grdCompany.DataBind();

            // reset fields
            txtTitle.Text = "";
            fckDesc.Value = "";
            fckContacts.Value = "";
            txtEmail.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dvCompany_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            DropDownList ddlCategory = (DropDownList)dvCompany.FindControl("ddlCategory");
            TextBox txtTitle = (TextBox)dvCompany.FindControl("txtTitle");
            FCKeditor fckDesc = (FCKeditor)dvCompany.FindControl("fckDesc");
            FCKeditor fckContacts = (FCKeditor)dvCompany.FindControl("fckContacts");
            TextBox txtEmail = (TextBox)dvCompany.FindControl("txtEmail");
            CheckBox chkFeatured = (CheckBox)dvCompany.FindControl("chkFeatured");
            FileUpload fu_Image = (FileUpload)dvCompany.FindControl("fu_Image");
            HiddenField hfImage = (HiddenField)dvCompany.FindControl("hfImage");

            JobCompanyClass objIC = new JobCompanyClass();
            objIC.iID = int.Parse(dvCompany.DataKey.Value.ToString());
            objIC.iCategoryID = int.Parse(ddlCategory.SelectedValue.ToString());
            objIC.strJobCompanyName = txtTitle.Text;
            objIC.strJobCompanyDesc = fckDesc.Value;
            objIC.strContactDetails = fckContacts.Value;
            objIC.strEmail = txtEmail.Text;


            if (chkFeatured.Checked)
            {
                objIC.bFeatured = true;
            }
            else
            {
                objIC.bFeatured = false;
            }

            if (fu_Image.HasFile)
            {
                JobCompanyClass oCompany = new JobCompanyClass();
                oCompany.iID = int.Parse(dvCompany.DataKey.Value.ToString());
                CoreWebList<JobCompanyClass> oCompanyList = oCompany.fn_GetJobCompanyByID();
                if (oCompanyList.Count > 0)
                {
                    if (File.Exists(MapPath("~/Logos/" + oCompanyList[0].strLogo)))
                    {
                        File.Delete((MapPath("~/Logos/" + oCompanyList[0].strLogo)));
                    }
                }

                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_Image.FileName);
                string strDocPath = Server.MapPath("~/Logos/" + strRanFileName);
                fu_Image.SaveAs(strDocPath);
                objIC.strLogo = strRanFileName;
            }
            else
            {
                objIC.strLogo = hfImage.Value;
            }

            objIC.iID = int.Parse(dvCompany.DataKey.Value.ToString());

            string strResponse = objIC.fn_EditJobCompany();

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

            dvCompany.ChangeMode(DetailsViewMode.ReadOnly);

            objIC.iID = int.Parse(grdCompany.SelectedDataKey.Value.ToString());

            dvCompany.DataSource = objIC.fn_GetJobCompanyByID();
            dvCompany.DataBind();

            // Bind Data To grid        
            chJobCompanyList = objIC.fn_Get_JobCompanyList();
            grdCompany.DataSource = chJobCompanyList;
            grdCompany.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dvCompany_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dvCompany.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dvCompany.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dvCompany.ChangeMode(e.NewMode);

                if (grdCompany.SelectedIndex >= 0)
                {
                    JobCompanyClass objIC = new JobCompanyClass();
                    objIC.iID = int.Parse(grdCompany.SelectedDataKey.Value.ToString());

                    dvCompany.DataSource = objIC.fn_GetJobCompanyByID();
                    dvCompany.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dvCompany_DataBound(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkFeatured = (CheckBox)dvCompany.FindControl("chkFeatured");
            Label lblFeatured = (Label)dvCompany.FindControl("lblFeatured");
            HiddenField hfFeatured = (HiddenField)dvCompany.FindControl("hfFeatured");
            DropDownList ddlCategory = (DropDownList)dvCompany.FindControl("ddlCategory");

            JobCompanyClass objCM = new JobCompanyClass();

            if (dvCompany.CurrentMode == DetailsViewMode.Insert)
            {
                fn_CategoryDropDownList();
            }

            if (dvCompany.CurrentMode == DetailsViewMode.Edit)
            {
                if (hfFeatured != null)
                {
                    if (bool.Parse(hfFeatured.Value) == true)
                    {
                        chkFeatured.Checked = true;
                    }
                    else
                    {
                        chkFeatured.Checked = false;
                    }
                }

                JobCompanyClass objCompany = new JobCompanyClass();
                objCompany.iID = int.Parse(grdCompany.SelectedDataKey.Value.ToString());
                CoreWebList<JobCompanyClass> objCompanyList = objCompany.fn_GetJobCompanyByID();
                if (objCompanyList.Count > 0)
                {
                    fn_CategoryDropDownList();

                    ddlCategory.SelectedValue = objCompanyList[0].iCategoryID.ToString();
                }
            }

            if (dvCompany.CurrentMode == DetailsViewMode.ReadOnly)
            {
                if (hfFeatured != null)
                {
                    if (bool.Parse(hfFeatured.Value) == true)
                    {
                        lblFeatured.Text = "Yes";
                    }
                    else
                    {
                        lblFeatured.Text = "No";
                    }
                }

                Label lblCategory = (Label)dvCompany.FindControl("lblCategory");

                JobCompanyClass objCompany = new JobCompanyClass();
                objCompany.iID = int.Parse(grdCompany.SelectedDataKey.Value.ToString());
                CoreWebList<JobCompanyClass> objCompanyList = objCompany.fn_GetJobCompanyByID();
                if (objCompanyList.Count > 0)
                {
                    JobCategoryClass objCategory = new JobCategoryClass();
                    objCategory.iID = objCompanyList[0].iCategoryID;
                    CoreWebList<JobCategoryClass> objCategoryList = objCategory.fn_GetJobCategoryByID();
                    if (objCategoryList.Count > 0)
                    {
                        lblCategory.Text = objCategoryList[0].strJobCategoryName;
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

    protected void grdCompany_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Featured")
            {
                int iId = Convert.ToInt32(e.CommandArgument);
                JobCompanyClass objIM = new JobCompanyClass();
                ImageButton btnFeatured = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnFeatured.Parent.Parent;

                objIM.iID = iId;

                CoreWebList<JobCompanyClass> objJobList = objIM.fn_GetJobCompanyByID();

                if (objJobList[0].bFeatured == true)
                {
                    btnFeatured.ImageUrl = "~/admin/images/cross.gif";
                    objIM.bFeatured = false;
                    objIM.fn_EditFeatured();
                }
                else
                {
                    btnFeatured.ImageUrl = "~/admin/images/Tick.gif";
                    objIM.bFeatured = true;
                    objIM.fn_EditFeatured();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grdCompany_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hfFeatured = (HiddenField)e.Row.FindControl("hfFeatured");
                ImageButton btnFeatured = (ImageButton)e.Row.FindControl("btnFeatured");

                if (btnFeatured != null && btnFeatured != null)
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
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            JobCompanyClass objCompany = new JobCompanyClass();
            objCompany.strJobCompanyName = txtSearch.Text.Trim();
            chJobCompanyList = objCompany.fn_SearchJobCompanyByName();
            if (chJobCompanyList.Count > 0)
            {
                grdCompany.DataSource = chJobCompanyList;
            }
            else
            {
                grdCompany.DataSource = null;
            }
            grdCompany.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_CategoryDropDownList()
    {
        try
        {
            DropDownList ddlCategory = (DropDownList)dvCompany.FindControl("ddlCategory");
            if (ddlCategory != null)
            {
                JobCategoryClass objCategory = new JobCategoryClass();
                ddlCategory.DataSource = objCategory.fn_GetJobCategoryList();
                ddlCategory.DataTextField = "strJobCategoryName";
                ddlCategory.DataValueField = "iID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
}