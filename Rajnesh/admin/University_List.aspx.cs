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
using yo_lib;
using FredCK.FCKeditorV2;
using System.Text.RegularExpressions;

public partial class admin_University_List : System.Web.UI.Page
{
    private CoreWebList<UniversityListClass> chUniversityList
    {
        get 
        {
            if (Cache["UniversityList"] != null)
                return (CoreWebList<UniversityListClass>)Cache["UniversityList"];
            return null;
        }
        set 
        {
            Cache["UniversityList"] = value;
        }
    }

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
            // Response.Redirect("CategoryMaster.aspx");
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

    string strRanFileName = string.Empty;
    string strDocPath = string.Empty;
    string strOrgFileName = string.Empty;

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
                BindGrid();
                    
                UniversityTypeClass objType = new UniversityTypeClass();
                ddlType.DataValueField = "iID";
                ddlType.DataTextField = "strTypeTitle";
                ddlType.DataSource = objType.fn_getTypeList();
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("All", "0"));

                BindDDLCity();
                fn_bindTypeDLL();
                fn_bindStateDLL();

                if (grd_UniversityList.SelectedIndex < 0)
                {
                    dv_UniversityList.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    void BindGrid()
    {
        try
        {
            UniversityListClass objUL = new UniversityListClass();
            chUniversityList = objUL.fn_getUniversityList();
            if (chUniversityList.Count > 0)
            {
                grd_UniversityList.DataSource = chUniversityList;
                grd_UniversityList.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    public void fn_bindTypeDLL()
    {
        DropDownList ddlUniversityType = (DropDownList)dv_UniversityList.FindControl("ddlUniversityType");
        if (ddlUniversityType != null)
        {
            UniversityTypeClass objCM = new UniversityTypeClass();
            ddlUniversityType.DataValueField = "iID";
            ddlUniversityType.DataTextField = "strTypeTitle";
            ddlUniversityType.DataSource = objCM.fn_getTypeList();
            ddlUniversityType.DataBind();
            ddlUniversityType.Items.Insert(0, new ListItem("Select", "0"));
        }
    }

    public void fn_bindStateDLL()
    {
        DropDownList ddlState = (DropDownList)dv_UniversityList.FindControl("ddlState");
        if (ddlState != null)
        {
            StateMasterClass objCM = new StateMasterClass();
            ddlState.DataValueField = "iID";
            ddlState.DataTextField = "strStateName";
            ddlState.DataSource = objCM.fn_getStateList();
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("Select", "0"));
        }
    }

    protected void grd_UniversityList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_UniversityList.PageIndex = e.NewPageIndex;
            grd_UniversityList.DataSource = chUniversityList;
            grd_UniversityList.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void grd_UniversityList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            UniversityListClass objUL = new UniversityListClass();
            objUL.iID = int.Parse(grd_UniversityList.DataKeys[e.RowIndex].Value.ToString());
            if (!IsRefresh)
            {
                DataTable dtPro = (DataTable)objUL.fn_getUniversityByID();
                strRanFileName = dtPro.Rows[0]["strImage"].ToString();

                string strResponse = objUL.fn_deleteUniversity();

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
            }
            BindGrid();
            dv_UniversityList.ChangeMode(DetailsViewMode.Insert);

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_UniversityList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_UniversityList.SelectedIndex < 0)
            {
                dv_UniversityList.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_UniversityList.ChangeMode(DetailsViewMode.Edit);

                UniversityListClass objUL = new UniversityListClass();
                objUL.iID = int.Parse(grd_UniversityList.SelectedDataKey.Value.ToString());
                DataTable dt = (DataTable)objUL.fn_getUniversityByID();
                dv_UniversityList.DataSource = dt;
                dv_UniversityList.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void grd_UniversityList_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            UniversityListClass objUL = new UniversityListClass();
            CoreWebList<UniversityListClass> objUniversityList = chUniversityList;
            if (objUniversityList.Count > 0)
            {
                DataTable dt = (DataTable)objUniversityList;
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

                grd_UniversityList.DataSource = dv;
                grd_UniversityList.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void dv_UniversityList_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            DropDownList ddlUniversityType = (DropDownList)dv_UniversityList.FindControl("ddlUniversityType");
            TextBox txtUniversityTitle = (TextBox)dv_UniversityList.FindControl("txtUniversityTitle");
            FCKeditor fckDescription = (FCKeditor)dv_UniversityList.FindControl("fckDescription");
            FCKeditor fckExamTimeTable = (FCKeditor)dv_UniversityList.FindControl("fckExamTimeTable");

            FCKeditor fckAdmissions = (FCKeditor)dv_UniversityList.FindControl("fckAdmissions");
            FCKeditor fckInfrastructure = (FCKeditor)dv_UniversityList.FindControl("fckInfrastructure");
            FCKeditor fckResults = (FCKeditor)dv_UniversityList.FindControl("fckResults");

            FCKeditor fckAddress = (FCKeditor)dv_UniversityList.FindControl("fckAddress");
            TextBox txtEmail = (TextBox)dv_UniversityList.FindControl("txtEmail");
            TextBox txtWebsite = (TextBox)dv_UniversityList.FindControl("txtWebsite");
            DropDownList ddlCity = (DropDownList)dv_UniversityList.FindControl("ddlCity");
            FileUpload fuUniversityImage = (FileUpload)dv_UniversityList.FindControl("fuUniversityImage");
            CheckBox chkBox_Featured = (CheckBox)dv_UniversityList.FindControl("chkBox_Featured");
            TextBox txtEstablishedIn = (TextBox)dv_UniversityList.FindControl("txtEstablishedIn");
            TextBox txtAffiliatedTo = (TextBox)dv_UniversityList.FindControl("txtAffiliatedTo");
            TextBox txtRank = (TextBox)dv_UniversityList.FindControl("txtRank");

            TextBox txtFileName = (TextBox)dv_UniversityList.FindControl("txtFileName");
            DropDownList ddlState = (DropDownList)dv_UniversityList.FindControl("ddlState");
            TextBox txtheader1 = (TextBox)dv_UniversityList.FindControl("txtheader1");
            TextBox txtheader2 = (TextBox)dv_UniversityList.FindControl("txtheader2");
            TextBox txtheader3 = (TextBox)dv_UniversityList.FindControl("txtheader3");
            TextBox txtMetaTitle = (TextBox)dv_UniversityList.FindControl("txtMetaTitle");
            TextBox txtMetaDesc = (TextBox)dv_UniversityList.FindControl("txtMetaDesc");
            TextBox txtMetaKeys = (TextBox)dv_UniversityList.FindControl("txtMetaKeys");
            TextBox txtSearch = (TextBox)dv_UniversityList.FindControl("txtSearch");

            string FileName = txtFileName.Text.ToString().Trim().Replace(" ", "-").Replace("&", "-").Replace(":", "-").Replace("?", "-").Replace(",", "-").Replace("%", "-").Replace("/", "-").Replace("---", "-").Replace("--", "-") + ".aspx";

            UniversityListClass objUL = new UniversityListClass();

            if (fuUniversityImage.HasFile)
            {
                cls_common objCFC = new cls_common();
                strRanFileName = objCFC.file_name(fuUniversityImage.FileName);
                strDocPath = Server.MapPath("~/admin/Upload/University/" + strRanFileName);
                fuUniversityImage.SaveAs(strDocPath);
                objUL.strImage = strRanFileName;
            }

            
            objUL.strTitle = txtUniversityTitle.Text;
            objUL.iTypeID = int.Parse(ddlUniversityType.SelectedValue);
            objUL.strDesc = fckDescription.Value;
            objUL.strExamTimeTable = fckExamTimeTable.Value;
            objUL.strAddress = fckAddress.Value;
            objUL.strEmail = txtEmail.Text;
            objUL.strWebsite = txtWebsite.Text;
            objUL.strCity = ddlCity.SelectedItem.Text;
            objUL.bFeatured = chkBox_Featured.Checked;
            objUL.strAffiliatedTo = txtAffiliatedTo.Text;
            objUL.strEstablishedIn = txtEstablishedIn.Text;
            objUL.iRank = int.Parse(txtRank.Text);

            objUL.strFileName = FileName;
            objUL.strState = ddlState.SelectedItem.Text;
            objUL.strHeader1 = txtheader1.Text;
            objUL.strHeader2 = txtheader2.Text;
            objUL.strHeader3 = txtheader3.Text;
            objUL.strMetaTitle = txtMetaTitle.Text;
            objUL.strMetaDesc = txtMetaDesc.Text;
            objUL.strMetaKeywords = txtMetaKeys.Text;
            objUL.strKeywords = txtSearch.Text;

            objUL.strAdmissions = fckAdmissions.Value;
            objUL.strInfrastructure = fckInfrastructure.Value;
            objUL.strResults = fckResults.Value;
            
            if (!IsRefresh)
            {
                string strResponse = objUL.fn_saveUniversityList();

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

            BindGrid();

            txtUniversityTitle.Text = "";
            fckDescription.Value = "";
            fckExamTimeTable.Value = "";
            fckAddress.Value = "";
            fckAdmissions.Value = "";
            fckInfrastructure.Value = "";
            fckResults.Value = "";
            txtEmail.Text = "";

            txtFileName.Text = "";
            txtheader1.Text = "";
            txtheader2.Text = "";
            txtheader3.Text = "";
            txtMetaTitle.Text = "";
            txtMetaKeys.Text = "";
            txtMetaDesc.Text = "";
            txtSearch.Text = "";
            ddlState.SelectedIndex = 0;

            txtWebsite.Text = "";
            ddlCity.SelectedIndex = 0;
            ddlUniversityType.SelectedIndex = 0;
            chkBox_Featured.Checked = false;
            txtEstablishedIn.Text = "";
            txtAffiliatedTo.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void dv_UniversityList_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            DropDownList ddlUniversityType = (DropDownList)dv_UniversityList.FindControl("ddlUniversityType");
            TextBox txtUniversityTitle = (TextBox)dv_UniversityList.FindControl("txtUniversityTitle");
            FCKeditor fckDescription = (FCKeditor)dv_UniversityList.FindControl("fckDescription");
            FCKeditor fckExamTimeTable = (FCKeditor)dv_UniversityList.FindControl("fckExamTimeTable");
            FCKeditor fckAddress = (FCKeditor)dv_UniversityList.FindControl("fckAddress");
            TextBox txtEmail = (TextBox)dv_UniversityList.FindControl("txtEmail");
            TextBox txtWebsite = (TextBox)dv_UniversityList.FindControl("txtWebsite");
            DropDownList ddlCity = (DropDownList)dv_UniversityList.FindControl("ddlCity");
            FileUpload fuUniversityImage = (FileUpload)dv_UniversityList.FindControl("fuUniversityImage");
            CheckBox chkBox_Featured = (CheckBox)dv_UniversityList.FindControl("chkBox_Featured");
            TextBox txtEstablishedIn = (TextBox)dv_UniversityList.FindControl("txtEstablishedIn");
            TextBox txtAffiliatedTo = (TextBox)dv_UniversityList.FindControl("txtAffiliatedTo");
            TextBox txtRank = (TextBox)dv_UniversityList.FindControl("txtRank");

            FCKeditor fckAdmissions = (FCKeditor)dv_UniversityList.FindControl("fckAdmissions");
            FCKeditor fckInfrastructure = (FCKeditor)dv_UniversityList.FindControl("fckInfrastructure");
            FCKeditor fckResults = (FCKeditor)dv_UniversityList.FindControl("fckResults");

            TextBox txtFileName = (TextBox)dv_UniversityList.FindControl("txtFileName");
            DropDownList ddlState = (DropDownList)dv_UniversityList.FindControl("ddlState");
            TextBox txtheader1 = (TextBox)dv_UniversityList.FindControl("txtheader1");
            TextBox txtheader2 = (TextBox)dv_UniversityList.FindControl("txtheader2");
            TextBox txtheader3 = (TextBox)dv_UniversityList.FindControl("txtheader3");
            TextBox txtMetaTitle = (TextBox)dv_UniversityList.FindControl("txtMetaTitle");
            TextBox txtMetaDesc = (TextBox)dv_UniversityList.FindControl("txtMetaDesc");
            TextBox txtMetaKeys = (TextBox)dv_UniversityList.FindControl("txtMetaKeys");
            TextBox txtSearch = (TextBox)dv_UniversityList.FindControl("txtSearch");

            HiddenField hfFile = (HiddenField)dv_UniversityList.FindControl("hfFile");

            string FileName = "";

            if (txtFileName.Text.Contains(".aspx"))
            {
                FileName = txtFileName.Text.ToString().Replace(" ", "-").Replace("&", "-").Replace(":", "-").Replace("?", "-").Replace(",", "-").Replace("%", "-").Replace("/", "-").Replace("---", "-").Replace("--", "-");
            }
            else
            {
                FileName = txtFileName.Text.ToString().Trim().Replace(" ", "-").Replace("&", "-").Replace(":", "-").Replace("?", "-").Replace(",", "-").Replace("%", "-").Replace("/", "-").Replace("---", "-").Replace("--", "-") + ".aspx";
            }
            UniversityListClass objUL = new UniversityListClass();
            objUL.strTitle = txtUniversityTitle.Text;
            objUL.iTypeID = int.Parse(ddlUniversityType.SelectedValue);
            objUL.strDesc = fckDescription.Value;
            objUL.strExamTimeTable = fckExamTimeTable.Value;
            objUL.strAddress = fckAddress.Value;
            objUL.strEmail = txtEmail.Text;
            objUL.strWebsite = txtWebsite.Text;
            objUL.strCity = ddlCity.SelectedItem.Text;
            objUL.bFeatured = chkBox_Featured.Checked;
            objUL.strAffiliatedTo = txtAffiliatedTo.Text;
            objUL.strEstablishedIn = txtEstablishedIn.Text;
            objUL.iID = int.Parse(dv_UniversityList.DataKey.Value.ToString());
            objUL.iRank = int.Parse(txtRank.Text);

            objUL.strFileName = FileName;
            objUL.strState = ddlState.SelectedItem.Text;
            objUL.strHeader1 = txtheader1.Text;
            objUL.strHeader2 = txtheader2.Text;
            objUL.strHeader3 = txtheader3.Text;
            objUL.strMetaTitle = txtMetaTitle.Text;
            objUL.strMetaDesc = txtMetaDesc.Text;
            objUL.strMetaKeywords = txtMetaKeys.Text;
            objUL.strKeywords = txtSearch.Text;

            objUL.strAdmissions = fckAdmissions.Value;
            objUL.strInfrastructure = fckInfrastructure.Value;
            objUL.strResults = fckResults.Value;

            if (!IsRefresh)
            {
                string strResponse = string.Empty;
                if (fuUniversityImage.HasFile)
                {
                    DataTable dt = (DataTable)objUL.fn_getUniversityByID();
                    strRanFileName = dt.Rows[0]["strImage"].ToString();

                    if (File.Exists(MapPath("~/admin/Upload/University/" + strRanFileName)))
                    {
                        File.Delete((MapPath("~/admin/Upload/University/" + strRanFileName)));
                    }

                    cls_common objCFC = new cls_common();
                    strRanFileName = objCFC.file_name(fuUniversityImage.FileName);
                    strDocPath = Server.MapPath("~/admin/Upload/University/" + strRanFileName);
                    fuUniversityImage.SaveAs(strDocPath);
                    objUL.strImage = strRanFileName;
                    strResponse = objUL.fn_editUniversityList();
                }
                else
                {
                    strResponse = objUL.fn_editUniversityWithoutImage();
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

            }

            dv_UniversityList.ChangeMode(DetailsViewMode.ReadOnly);
            objUL.iID = int.Parse(grd_UniversityList.SelectedDataKey.Value.ToString());
            dv_UniversityList.DataSource = objUL.fn_getUniversityByID();
            dv_UniversityList.DataBind();
            BindGrid();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void dv_UniversityList_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_UniversityList.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_UniversityList.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_UniversityList.ChangeMode(e.NewMode);

                if (grd_UniversityList.SelectedIndex >= 0)
                {
                    UniversityListClass objUL = new UniversityListClass();
                    objUL.iID = int.Parse(grd_UniversityList.SelectedDataKey.Value.ToString());
                    DataTable dt = (DataTable)objUL.fn_getUniversityByID();
                    dv_UniversityList.DataSource = dt;
                    dv_UniversityList.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    
    protected void dv_UniversityList_DataBound(object sender, EventArgs e)
    {
        fn_bindTypeDLL();
        fn_bindStateDLL();
        DropDownList ddlCity = (DropDownList)dv_UniversityList.FindControl("ddlCity");
        DropDownList ddlState = (DropDownList)dv_UniversityList.FindControl("ddlState");
        DropDownList ddlUniversityType = (DropDownList)dv_UniversityList.FindControl("ddlUniversityType");
        Label lbl_Featured = (Label)dv_UniversityList.FindControl("lbl_Featured");
        TextBox txtFileName = (TextBox)dv_UniversityList.FindControl("txtFileName");
        Label lblState = (Label)dv_UniversityList.FindControl("lblState");

        CheckBox chkBox_Featured = (CheckBox)dv_UniversityList.FindControl("chkBox_Featured");
        
        if (dv_UniversityList.CurrentMode == DetailsViewMode.Insert)
        {
            fn_getCityForIndia();
            fn_bindStateDLL();
            dv_UniversityList.Fields[11].Visible = true;
        }

        if (dv_UniversityList.CurrentMode == DetailsViewMode.ReadOnly)
        {
            UniversityListClass objICII = new UniversityListClass();
            objICII.iID = int.Parse(grd_UniversityList.SelectedDataKey.Value.ToString());
            DataTable dtt = (DataTable)objICII.fn_getUniversityByID();

            lblState.Text = dtt.Rows[0]["strState"].ToString();

            //Bind Type DropDown
            UniversityTypeClass objUTC = new UniversityTypeClass();
            objUTC.iID = int.Parse(dtt.Rows[0]["iTypeID"].ToString());
            Label lblUniversityType = (Label)dv_UniversityList.FindControl("lblUniversityType");
            DataTable dtType = (DataTable)objUTC.fn_getTypeByID();
            lblUniversityType.Text = dtType.Rows[0]["strTypeTitle"].ToString();
            dv_UniversityList.Fields[11].Visible = false;

            if (bool.Parse(dtt.Rows[0]["bFeatured"].ToString()))
            {
                lbl_Featured.Text = "YES";
            }
            else
            {
                lbl_Featured.Text = "NO";
            }
        }

        if (dv_UniversityList.CurrentMode == DetailsViewMode.Edit)
        {
            UniversityListClass objICI = new UniversityListClass();
            objICI.iID = int.Parse(grd_UniversityList.SelectedDataKey.Value.ToString());
            DataTable dt = (DataTable)objICI.fn_getUniversityByID();
            
            fn_getCityForIndia();
            fn_bindStateDLL();

            ddlCity.Items.FindByText(dt.Rows[0]["strCity"].ToString()).Selected = true;
            if (dt.Rows[0]["strState"] != null)
            {
                if (dt.Rows[0]["strState"] != "")
                {
                    ddlState.Items.FindByText(dt.Rows[0]["strState"].ToString()).Selected = true;
                }
            }
            ddlUniversityType.Items.FindByValue(dt.Rows[0]["iTypeID"].ToString()).Selected = true;

            if (bool.Parse(dt.Rows[0]["bFeatured"].ToString()))
            {
                chkBox_Featured.Checked = true;
            }
            else
            {
                chkBox_Featured.Checked = false;
            }

            dv_UniversityList.Fields[11].Visible = true;
        }

    }

    protected void fn_getCityForIndia()
    {
        DropDownList ddlCity = (DropDownList)dv_UniversityList.FindControl("ddlCity");

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

    protected void grd_UniversityList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Featured")
            {
                int iId = Convert.ToInt32(e.CommandArgument);
                ImageButton btnFeatured = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnFeatured.Parent.Parent;
                
                UniversityListClass objIM = new UniversityListClass();
                objIM.iID = iId;
                bool bFeatured = objIM.fn_getFeaturedStatusByID();
                if (bFeatured == true)
                {
                    btnFeatured.ImageUrl = "~/admin/images/cross.gif";
                    objIM.bFeatured = false;
                    objIM.fn_changeFeaturedStatus();
                }
                else
                {
                    btnFeatured.ImageUrl = "~/admin/images/Tick.gif";
                    objIM.bFeatured = true;
                    objIM.fn_changeFeaturedStatus();
                }
            }

            else if (e.CommandName == "HomeFeatured")
            {
                ImageButton btnHomeFeatured = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnHomeFeatured.Parent.Parent;

                UniversityListClass objUniversity = new UniversityListClass();
                objUniversity.iID = Convert.ToInt32(e.CommandArgument);
                CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_getUniversityByID();
                if (objUniversityList.Count > 0)
                {
                    if (objUniversityList[0].bHomeFeatured == true)
                    {
                        btnHomeFeatured.ImageUrl = "~/admin/images/cross.gif";
                        objUniversity.bHomeFeatured = false;
                    }
                    else
                    {
                        btnHomeFeatured.ImageUrl = "~/admin/images/Tick.gif";
                        objUniversity.bHomeFeatured = true;
                    }
                }

                objUniversity.fn_changeHomeFeaturedStatus();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void grd_UniversityList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hfFeatured = (HiddenField)e.Row.FindControl("hfFeatured");
                ImageButton btnFeatured = (ImageButton)e.Row.FindControl("btnFeatured");                
                if (bool.Parse(hfFeatured.Value) == true)
                {
                    btnFeatured.ImageUrl = "~/admin/images/Tick.gif";
                }
                else
                {
                    btnFeatured.ImageUrl = "~/admin/images/Cross.gif";
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
            UniversityListClass objUL = new UniversityListClass();
            chUniversityList = objUL.fn_searchUniversityListinAdmin(fn_SearchUniversityQuery());
            grd_UniversityList.DataSource = chUniversityList;
            grd_UniversityList.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    public string fn_SearchUniversityQuery()
    {
        string strQuery = "select Distinct(universityList_title),universityList_id,universityList_typeID,universityList_city,universityList_image,universityList_featured,universityType_title from edu_UniversityList inner Join edu_UniversityType on universityList_typeID = universityType_id  ";
        bool blnflag = false;

        if (txt_UniversityTitle.Text != "")
        {
            if (blnflag)
            {
                strQuery += " AND universityList_title LIKE '%" + txt_UniversityTitle.Text.Trim() + "%'";
            }

            else
            {
                strQuery += " WHERE universityList_title LIKE '%" + txt_UniversityTitle.Text.Trim() + "%'";
            }
            blnflag = true;
        }

        if (ddlCity.SelectedIndex != 0)
        {
            if (blnflag)
            {
                strQuery += "  AND universityList_city ='" + ddlCity.SelectedItem.Text + "' ";
            }
            else
            {
                strQuery += "  WHERE universityList_city ='" + ddlCity.SelectedItem.Text + "'";
            }
            blnflag = true;
        }
        if (ddlType.SelectedIndex != 0)
        {
            if (blnflag)
            {
                strQuery += "  AND universityList_typeID ='" + ddlType.SelectedValue + "' ";
            }
            else
            {
                strQuery += "  WHERE universityList_typeID ='" + ddlType.SelectedValue + "'";
            }
            blnflag = true;
        }

        return strQuery;
    }

    void BindDDLCity()
    {
        try
        {
            CityMasterClass objCM = new CityMasterClass();
            ddlCity.DataSource = objCM.fn_getCityListForIndia();
            ddlCity.DataTextField = "strCityName";
            ddlCity.DataValueField = "iID";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("All", "0"));
        }

        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }


    


}
