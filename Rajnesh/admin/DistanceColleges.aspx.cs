using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using yo_lib;
using FredCK.FCKeditorV2;
using System.IO;

public partial class admin_DistanceLearning_Colleges : Page
{
    #region "view state methods for checking the user refresh here"

    private bool _refreshState;
    private bool _isRefresh;

    public bool IsRefresh
    {
        get
        {
            return _isRefresh;
        }
    }

    protected override void LoadViewState(object savedState)
    {
        object[] allStates = (object[])savedState;
        base.LoadViewState(allStates[0]);
        _refreshState = (bool)allStates[1];
        if (Session["__ISREFRESH"] != null)
        {
            _isRefresh = _refreshState == (bool)Session["__ISREFRESH"];
        }
        else
        {
            // Response.Redirect("Category.aspx");
        }
    }

    protected override object SaveViewState()
    {
        Session["__ISREFRESH"] = _refreshState;
        object[] allStates = new object[2];
        allStates[0] = base.SaveViewState();
        allStates[1] = !_refreshState;
        return allStates;
    }
    #endregion
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
                fn_BindCategoryDropDownList();
                fn_BindCityDropDownList();

                // Bind Data To grid     

                string strQuery = "SELECT * FROM edu_distancelearning WHERE distancelearning_type='Institute' ORDER BY distancelearning_name ASC";

                ViewState["strQuery"] = strQuery;

                DistanceLearningClass objIM = new DistanceLearningClass();
                CoreWebList<DistanceLearningClass> objIMList = objIM.fn_SearchDistanceLearningList(strQuery);
                if (objIMList.Count > 0)
                {
                    grd_DLearning.DataSource = objIMList;
                    grd_DLearning.DataBind();
                }
                else
                {
                    grd_DLearning.DataSource = null;
                    grd_DLearning.DataBind();
                }

                if (grd_DLearning.SelectedIndex < 0)
                {
                    dv_DLearning.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void grd_DLearning_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DistanceLearningClass objIM = new DistanceLearningClass();
            grd_DLearning.PageIndex = e.NewPageIndex;
            grd_DLearning.DataSource = objIM.fn_SearchDistanceLearningList(ViewState["strQuery"].ToString());
            grd_DLearning.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void grd_DLearning_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DistanceLearningClass objIM = new DistanceLearningClass();
            objIM.iID = int.Parse(grd_DLearning.DataKeys[e.RowIndex].Value.ToString());

            DataTable dtPro = (DataTable)objIM.fn_GetDistanceLearningByID();
            strRanFileName = dtPro.Rows[0]["strImage"].ToString();

            if (File.Exists(MapPath("~/admin/Upload/DistanceLearning/" + strRanFileName)))
            {
                //Deletes the Image file from the Folder
                File.Delete((MapPath("~/admin/Upload/DistanceLearning/" + strRanFileName)));
            }

            string strResponse = objIM.fn_DeleteDistanceLearning();
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
            // Bind Data To grid            
            grd_DLearning.DataSource = objIM.fn_SearchDistanceLearningList(ViewState["strQuery"].ToString());
            grd_DLearning.DataBind();
            dv_DLearning.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void grd_DLearning_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_DLearning.SelectedIndex < 0)
            {
                // Insert Mode
                dv_DLearning.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_DLearning.ChangeMode(DetailsViewMode.Edit);

                DistanceLearningClass objCM = new DistanceLearningClass();
                objCM.iID = int.Parse(grd_DLearning.SelectedDataKey.Value.ToString());
                CoreWebList<DistanceLearningClass> objList = objCM.fn_GetDistanceLearningByID();
                DataTable dt = null;
                if (objList.Count > 0)
                {
                    dt = (DataTable)objList;
                    dv_DLearning.DataSource = dt;
                    dv_DLearning.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void grd_DLearning_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DistanceLearningClass objCL = new DistanceLearningClass();
            DataTable dt = (DataTable)objCL.fn_SearchDistanceLearningList(ViewState["strQuery"].ToString());
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

            grd_DLearning.DataSource = dv;
            grd_DLearning.DataBind();

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    string strRanFileName = string.Empty;
    string strDocPath = string.Empty;
    protected void dv_DLearning_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtName = (TextBox)dv_DLearning.FindControl("txtName");
            FCKeditor FCKDesc = (FCKeditor)dv_DLearning.FindControl("FCKDesc");
            FileUpload fu_Logo = (FileUpload)dv_DLearning.FindControl("fu_Logo");
            //DropDownList ddlCity = (DropDownList)dv_DLearning.FindControl("ddlCity");
            TextBox txtEmail = (TextBox)dv_DLearning.FindControl("txtEmail");
            TextBox txtWebsite = (TextBox)dv_DLearning.FindControl("txtWebsite");
            //FCKeditor FCKContactInfo = (FCKeditor)dv_DLearning.FindControl("FCKContactInfo");            
            CheckBox chkFeatured = (CheckBox)dv_DLearning.FindControl("chkFeatured");            

            DistanceLearningClass objCM = new DistanceLearningClass();
            objCM.strType = "Institute";
            objCM.strName = txtName.Text;
            //objCM.strCity = ddlCity.SelectedItem.Text;
            objCM.strCity = "";
            objCM.strEmail = txtEmail.Text;
            objCM.strWebsite = txtWebsite.Text;
            objCM.strDesc = FCKDesc.Value.Trim();
            //objCM.strContactInfo = FCKContactInfo.Value.Trim();
            objCM.strContactInfo = "";
            objCM.bIsFeatured = chkFeatured.Checked;

            if (fu_Logo.HasFile)
            {
                cls_common objCFC = new cls_common();
                //Calling function to get the name of the file with timestamp
                strRanFileName = objCFC.file_name(fu_Logo.FileName);
                strDocPath = Server.MapPath("~/admin/Upload/DistanceLearning/" + strRanFileName);
                fu_Logo.SaveAs(strDocPath);
                objCM.strImage = strRanFileName;
            }
            else
            {
                objCM.strImage = string.Empty;
            }

            if (!IsRefresh)
            {
                string strResponse = objCM.fn_SaveDistanceLearning();
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
            }

            // Bind Data To grid            
            grd_DLearning.DataSource = objCM.fn_SearchDistanceLearningList(ViewState["strQuery"].ToString());
            grd_DLearning.DataBind();

            // reset fields
            txtName.Text = string.Empty;
            FCKDesc.Value = string.Empty;
            //ddlCity.SelectedIndex = 0;
            txtEmail.Text = string.Empty;
            txtWebsite.Text = string.Empty;
            //FCKContactInfo.Value = string.Empty;
            chkFeatured.Checked = false;
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void dv_DLearning_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtName = (TextBox)dv_DLearning.FindControl("txtName");
            FCKeditor FCKDesc = (FCKeditor)dv_DLearning.FindControl("FCKDesc");
            FileUpload fu_Logo = (FileUpload)dv_DLearning.FindControl("fu_Logo");
            //DropDownList ddlCity = (DropDownList)dv_DLearning.FindControl("ddlCity");
            TextBox txtEmail = (TextBox)dv_DLearning.FindControl("txtEmail");
            TextBox txtWebsite = (TextBox)dv_DLearning.FindControl("txtWebsite");
            //FCKeditor FCKContactInfo = (FCKeditor)dv_DLearning.FindControl("FCKContactInfo");
            CheckBox chkFeatured = (CheckBox)dv_DLearning.FindControl("chkFeatured");

            DistanceLearningClass objCM = new DistanceLearningClass();
            objCM.strType = "Institute";
            objCM.strName = txtName.Text;
            objCM.strCity = "";
            objCM.strEmail = txtEmail.Text;
            objCM.strWebsite = txtWebsite.Text;
            objCM.strDesc = FCKDesc.Value.Trim();
            //objCM.strContactInfo = FCKContactInfo.Value.Trim();
            objCM.strContactInfo = "";
            objCM.bIsFeatured = chkFeatured.Checked;

            objCM.iID = int.Parse(dv_DLearning.DataKey.Value.ToString());

            string strResponse = string.Empty;

            if (fu_Logo.HasFile)
            {
                DataTable dt = (DataTable)objCM.fn_GetDistanceLearningByID();
                strRanFileName = dt.Rows[0]["strImage"].ToString();

                if (File.Exists(MapPath("~/admin/Upload/DistanceLearning/" + strRanFileName)))
                {
                    //Deletes the Image file from the Folder
                    File.Delete((MapPath("~/admin/Upload/DistanceLearning/" + strRanFileName)));
                }

                cls_common objCFC = new cls_common();
                //Calling function to get the name of the file with timestamp
                strRanFileName = objCFC.file_name(fu_Logo.FileName);
                strDocPath = Server.MapPath("~/admin/Upload/DistanceLearning/" + strRanFileName);
                fu_Logo.SaveAs(strDocPath);
                objCM.strImage = strRanFileName;
                strResponse = objCM.fn_EditDistanceLearning();
            }
            else
            {
                strResponse = objCM.fn_EditDistanceLearningWithoutImage();
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

            dv_DLearning.ChangeMode(DetailsViewMode.ReadOnly);
            objCM.iID = int.Parse(grd_DLearning.SelectedDataKey.Value.ToString());
            dv_DLearning.DataSource = objCM.fn_GetDistanceLearningByID();
            dv_DLearning.DataBind();

            // Bind Data To grid            
            grd_DLearning.DataSource = objCM.fn_SearchDistanceLearningList(ViewState["strQuery"].ToString());
            grd_DLearning.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void dv_DLearning_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_DLearning.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_DLearning.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_DLearning.ChangeMode(e.NewMode);
                if (grd_DLearning.SelectedIndex >= 0)
                {
                    DistanceLearningClass objIM = new DistanceLearningClass();
                    objIM.iID = int.Parse(grd_DLearning.SelectedDataKey.Value.ToString());
                    dv_DLearning.DataSource = objIM.fn_GetDistanceLearningByID();
                    dv_DLearning.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    
    protected void dv_DLearning_DataBound(object sender, EventArgs e)
    {
        try
        {
            if (dv_DLearning.CurrentMode == DetailsViewMode.ReadOnly || dv_DLearning.CurrentMode == DetailsViewMode.Edit)
            {
                Image imgLogo = (Image)dv_DLearning.FindControl("imgLogo");
                DistanceLearningClass objEC = new DistanceLearningClass();
                objEC.iID = int.Parse(dv_DLearning.DataKey.Value.ToString());
                DataTable dt = (DataTable)objEC.fn_GetDistanceLearningByID();
                if (dt.Rows[0]["strImage"].ToString() == string.Empty)
                {
                    imgLogo.ImageUrl = "~/admin/images/noimage.jpg";
                }
                if (dv_DLearning.CurrentMode == DetailsViewMode.ReadOnly)
                {
                    dv_DLearning.Fields[4].Visible = false;
                }
                else if (dv_DLearning.CurrentMode == DetailsViewMode.Edit)
                {
                    dv_DLearning.Fields[4].Visible = true;
                }
            }

            if (dv_DLearning.CurrentMode == DetailsViewMode.Edit)
            {
                Image imgLogo = (Image)dv_DLearning.FindControl("imgLogo");
                //DropDownList ddlCity = (DropDownList)dv_DLearning.FindControl("ddlCity");
                DistanceLearningClass objCM = new DistanceLearningClass();
                objCM.iID = int.Parse(dv_DLearning.DataKey.Value.ToString());
                CoreWebList<DistanceLearningClass> objList = objCM.fn_GetDistanceLearningByID();
                DataTable dt = null;
                //fn_getCityForIndia();
                if (objList.Count > 0)
                {
                    dt = (DataTable)objList;
                    string strImageName = dt.Rows[0]["strImage"].ToString();
                    if (strImageName == string.Empty)
                    {
                        imgLogo.ImageUrl = "~/admin/images/noImage.jpg";
                    }
                }
                dv_DLearning.Fields[4].Visible = true;
                //ddlCity.Items.FindByText(dt.Rows[0]["strCity"].ToString()).Selected = true;

            }
            else if (dv_DLearning.CurrentMode == DetailsViewMode.ReadOnly)
            {
                Label lblFeatured = (Label)dv_DLearning.FindControl("lblFeatured");
                DistanceLearningClass objCM = new DistanceLearningClass();
                objCM.iID = int.Parse(dv_DLearning.DataKey.Value.ToString());
                CoreWebList<DistanceLearningClass> objList = objCM.fn_GetDistanceLearningByID();
                DataTable dt = null;
                //fn_getCityForIndia();
                if (objList.Count > 0)
                {
                    dt = (DataTable)objList;
                    bool bIsFeatured = Convert.ToBoolean(dt.Rows[0]["bIsFeatured"].ToString());
                    if (bIsFeatured == true)
                    {
                        lblFeatured.Text = "Yes";
                    }
                    else if (bIsFeatured == false)
                    {
                        lblFeatured.Text = "No";
                    }
                }

                dv_DLearning.Fields[4].Visible = false;
            }
            else if (dv_DLearning.CurrentMode == DetailsViewMode.Insert)
            {
                fn_getCityForIndia();
                dv_DLearning.Fields[4].Visible = true;
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void grd_DLearning_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Featured")
            {
                int iId = Convert.ToInt32(e.CommandArgument);
                DistanceLearningClass objCM = new DistanceLearningClass();
                ImageButton btnFeatured = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnFeatured.Parent.Parent;

                objCM.iID = iId;
                bool bFeatured = objCM.fn_GetFeaturedStatusByID();
                if (bFeatured == true)
                {
                    btnFeatured.ImageUrl = "~/admin/images/cross.gif";
                    objCM.bIsFeatured = false;
                    objCM.fn_ChangeFeaturedStatus();
                }
                else
                {
                    btnFeatured.ImageUrl = "~/admin/images/Tick.gif";
                    objCM.bIsFeatured = true;
                    objCM.fn_ChangeFeaturedStatus();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void grd_DLearning_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hfFeatured = (HiddenField)e.Row.FindControl("hfFeatured");
                ImageButton btnFeatured = (ImageButton)e.Row.FindControl("btnFeatured");
                Image imgProduct = (Image)e.Row.FindControl("imgProduct");
                HiddenField hf_ImageName = (HiddenField)e.Row.FindControl("hf_ImageName");
                if (hf_ImageName.Value == string.Empty)
                {
                    imgProduct.ImageUrl = "~/admin/images/noImage.jpg";
                }
                if (bool.Parse(hfFeatured.Value) == true)
                {
                    //Response.Write("Inside Row Data Bound");
                    btnFeatured.ImageUrl = "~/admin/images/Tick.gif";
                }
                else
                {
                    //Response.Write("Inside Row Data Bound");
                    btnFeatured.ImageUrl = "~/admin/images/Cross.gif";
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    //this function is for admin ddlCity
    protected void fn_getCityForIndia()
    {
        try
        {
            DropDownList ddlCity = (DropDownList)dv_DLearning.FindControl("ddlCity");

            if (ddlCity != null)
            {
                CityMasterClass objCM = new CityMasterClass();

                ddlCity.DataValueField = "iID";
                ddlCity.DataTextField = "strCityName";

                ddlCity.DataSource = objCM.fn_getCityListForIndia();
                ddlCity.DataBind();

                ddlCity.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    private void fn_BindCityDropDownList()
    {
        try
        {
            CityMasterClass objCM = new CityMasterClass();

            CoreWebList<CityMasterClass> objCMList = objCM.fn_getCityListForIndia();

            if (objCMList.Count > 0)
            {
                DataTable dtCM = (DataTable)objCMList;

                ddl_City.DataSource = dtCM;

                ddl_City.DataTextField = "strCityName";
                ddl_City.DataValueField = "iID";

                ddl_City.DataBind();
            }

            ddl_City.Items.Insert(0, new ListItem("All", "0"));            
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    private void fn_BindCategoryDropDownList()
    {
        try
        {
            InstituteCategoryClass objCC = new InstituteCategoryClass();

            CoreWebList<InstituteCategoryClass> objList = objCC.fn_getCategoryList();

            if (objList.Count > 0)
            {
                DataTable dtIC = (DataTable)objList;
                ddlCategory.DataSource = dtIC;

                ddlCategory.DataTextField = "strCategoryTitle";
                ddlCategory.DataValueField = "iID";

                ddlCategory.DataBind();
            }

            ddlCategory.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strQuery = "SELECT I.distancelearning_id, I.distancelearning_name, I.distancelearning_email, I.distancelearning_website, I.distancelearning_logo, I.distancelearning_featured FROM  edu_DLCenter IC RIGHT JOIN edu_DistanceLearning I ON IC.dlCenter_DLInstituteID = I.distancelearning_id  ";

        strQuery += " WHERE distancelearning_type='Institute' AND distancelearning_name LIKE '%" + txtInstituteTitle.Text.ToString().Trim() + "%' ";

        if (ddlCategory.SelectedItem.Text != "All")
        {
            strQuery += " AND I.distancelearning_id IN(SELECT DISTINCT(DLCategoryList_DLID) FROM edu_DLCategoryList WHERE DLCategoryList_CatID = " + ddlCategory.SelectedValue + " GROUP BY DLCategoryList_CatID, DLCategoryList_DLID)";
        }

        if (ddl_City.SelectedItem.Text != "All")
        {
            strQuery += " AND  IC.dlCenter_City = '" + ddl_City.SelectedItem.Text + "' ";
        }

        strQuery += " GROUP BY I.distancelearning_id, I.distancelearning_name, I.distancelearning_email, I.distancelearning_website,I.distancelearning_logo, I.distancelearning_featured ORDER BY I.distancelearning_featured DESC, I.distancelearning_name ASC  ";

        ViewState["strQuery"] = strQuery;

        DistanceLearningClass objIM = new DistanceLearningClass();
        CoreWebList<DistanceLearningClass> objIMList = objIM.fn_SearchDistanceLearningList(strQuery);
        if (objIMList.Count > 0)
        {
            grd_DLearning.DataSource = objIMList;
            grd_DLearning.DataBind();
        }
        else
        {
            grd_DLearning.DataSource = null;
            grd_DLearning.DataBind();
        }
    }
}

