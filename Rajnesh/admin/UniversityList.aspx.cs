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
using yo_lib;
using System.IO;
using FredCK.FCKeditorV2;

public partial class admin_UniversityList : System.Web.UI.Page
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
                // Bind Data To grid
                BindGrid();

                //BindDDLCategoryAll();

                BindDDLCity();

                UniversityTypeClass objType = new UniversityTypeClass();
                ddlType.DataValueField = "iID";
                ddlType.DataTextField = "strTypeTitle";

                ddlType.DataSource = objType.fn_getTypeList();
                ddlType.DataBind();

                ddlType.Items.Insert(0, new ListItem("All", "0"));

                BindAlphanumericRepeater();

                
                if (grd_UniversityList.SelectedIndex < 0)
                {
                    //dv_UniversityList.ChangeMode(DetailsViewMode.Insert);                    
                    dv_UniversityList.Visible = false;
                    Label_Title.Visible = false;
                    Horz_Line.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    void BindAlphanumericRepeater()
    {
        try
        {
            DataTable dt = new DataTable();
            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "All" };

            dt.Columns.Add(new DataColumn("Letter",
typeof(string)));

            for (int i = 0; i < letters.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = letters[i];
                dt.Rows.Add(dr);
            }

            rprAlphanumeric.DataSource = dt.DefaultView;
            rprAlphanumeric.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    void BindGrid()
    {
        try
        {
            UniversityListClass objUL = new UniversityListClass();
            CoreWebList<UniversityListClass> objList = objUL.fn_getUniversityList();
            if (objList.Count > 0)
            {
                DataTable dt = (DataTable)objList;
                ViewState["grid"] = dt;

                grd_UniversityList.DataSource = dt;
                grd_UniversityList.DataBind();
            }            
        }

        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    //void BindDDLCategory()
    //{
    //    try
    //    {
    //        DropDownList ddlCategory = dv_UniversityList.FindControl("ddlCategory") as DropDownList;
    //        DropDownList ddlSubCategory = dv_UniversityList.FindControl("ddlSubCategory") as DropDownList;
    //        if (ddlCategory != null)
    //        {
    //            UniversityCategoryClass objCC = new UniversityCategoryClass();
    //            ddlCategory.DataSource = objCC.fn_getCategoryList();
    //            ddlCategory.DataTextField = "strCategoryTitle";
    //            ddlCategory.DataValueField = "iID";
    //            ddlCategory.DataBind();
    //            ddlCategory.Items.Insert(0, new ListItem("Select", "0"));
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
    //        error.Visible = true;
    //    }
    //}

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

    //void BindDDLCategoryAll()
    //{
    //    try
    //    {

    //        UniversityCategoryClass objCC = new UniversityCategoryClass();
    //        ddlCategory.DataSource = objCC.fn_getCategoryList();
    //        ddlCategory.DataTextField = "strCategoryTitle";
    //        ddlCategory.DataValueField = "iID";
    //        ddlCategory.DataBind();
    //        ddlCategory.Items.Insert(0, new ListItem("All", "0"));
    //        BindDDLSubCategoryAll(int.Parse(ddlCategory.SelectedValue.ToString()));

    //    }
    //    catch (Exception ex)
    //    {
    //        ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
    //        error.Visible = true;
    //    }
    //}
    //void BindDDLSubCategory(int CatID)
    //{
    //    try
    //    {
    //        DropDownList ddlSubCategory = dv_UniversityList.FindControl("ddlSubCategory") as DropDownList;
    //        UniversitySubCategoryClass objCS = new UniversitySubCategoryClass();
    //        objCS.iCatID = CatID;
    //        CoreWebList<UniversitySubCategoryClass> objList = objCS.fn_getSubCategoryByCatID();
    //        if (ddlSubCategory != null)
    //        {
    //            ddlSubCategory.DataSource = objList;
    //            ddlSubCategory.DataTextField = "strSubCategoryTitle";
    //            ddlSubCategory.DataValueField = "iID";
    //            ddlSubCategory.DataBind();
    //            ddlSubCategory.Items.Insert(0, new ListItem("Select", "0"));
    //        }

    //    }

    //    catch (Exception ex)
    //    {
    //        ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
    //        error.Visible = true;
    //    }
    //}
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
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    //void BindDDLSubCategoryAll(int CatID)
    //{
    //    try
    //    {
            
    //        UniversitySubCategoryClass objCS = new UniversitySubCategoryClass();
    //        objCS.iCatID = CatID;
    //        CoreWebList<UniversitySubCategoryClass> objList = objCS.fn_getSubCategoryByCatID();
           
    //            ddlSubCategory.DataSource = objList;
    //            ddlSubCategory.DataTextField = "strSubCategoryTitle";
    //            ddlSubCategory.DataValueField = "iID";
    //            ddlSubCategory.DataBind();
    //            ddlSubCategory.Items.Insert(0, new ListItem("All", "0"));
            

    //    }

    //    catch (Exception ex)
    //    {
    //        ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
    //        error.Visible = true;
    //    }
    //}

    protected void grd_UniversityList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            UniversityListClass objUL = new UniversityListClass();
            grd_UniversityList.PageIndex = e.NewPageIndex;
            //BindGrid();
            grd_UniversityList.DataSource = ViewState["grid"];
            grd_UniversityList.DataBind();

            dv_UniversityList.Visible = false;
            Label_Title.Visible = false;
            Horz_Line.Visible = false;
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
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

                if (File.Exists(MapPath("~/admin/Upload/University/" + strRanFileName)))
                {
                    //Deletes the Image file from the Folder
                    File.Delete((MapPath("~/admin/Upload/University/" + strRanFileName)));
                }

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
            // Bind Data To grid            
            //BindGrid();
            grd_UniversityList.DataSource = objUL.fn_searchUniversityList(fn_SearchUniversityQuery());
            grd_UniversityList.DataBind();

            dv_UniversityList.Visible = false;
            Label_Title.Visible = false;
            Horz_Line.Visible = false;

            //dv_UniversityList.ChangeMode(DetailsViewMode.Insert);

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
            //HtmlControl Horz_Line = this.FindControl("Horz_Line") as HtmlControl;
            if (grd_UniversityList.SelectedIndex < 0)
            {
                // Insert Mode
                dv_UniversityList.ChangeMode(DetailsViewMode.Insert);
                dv_UniversityList.Visible = true;
                Label_Title.Visible = true;
                //Horz_Line.Visible = true;
            }
            else
            {
                // Edit Mode
                Label_Title.Visible = true;
                Horz_Line.Visible = true;
                dv_UniversityList.Visible = true;
                dv_UniversityList.ChangeMode(DetailsViewMode.Edit);

                UniversityListClass objUL = new UniversityListClass();
                objUL.iID = int.Parse(grd_UniversityList.SelectedDataKey.Value.ToString());
                DataTable dt = (DataTable)objUL.fn_getUniversityByID();
                dv_UniversityList.DataSource = dt;
                dv_UniversityList.DataBind();

                //BindValueToDDL(dt);
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
            //DataTable dt = (DataTable)objUL.fn_getUniversityList();
            DataTable dt = (DataTable)ViewState["grid"];
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
            ViewState["grid"] = dv.ToTable();
            dv_UniversityList.Visible = false;
            Label_Title.Visible = false;
            Horz_Line.Visible = false;
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void dv_UniversityList_ItemCreated(object sender, EventArgs e)
    {

    }
    //protected void dv_UniversityList_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    //{
    //    try
    //    {

    //        DropDownList ddlCategory = dv_UniversityList.FindControl("ddlCategory") as DropDownList;
    //        DropDownList ddlSubCategory = dv_UniversityList.FindControl("ddlSubCategory") as DropDownList;
    //        TextBox txtUniversityTitle = (TextBox)dv_UniversityList.FindControl("txtUniversityTitle");
    //        FCKeditor fckDescription = (FCKeditor)dv_UniversityList.FindControl("fckDescription");
    //        TextBox txtAddress = (TextBox)dv_UniversityList.FindControl("txtAddress");
    //        TextBox txtEmail = (TextBox)dv_UniversityList.FindControl("txtEmail");
    //        TextBox txtWebsite = (TextBox)dv_UniversityList.FindControl("txtWebsite");
    //        TextBox txtFax = (TextBox)dv_UniversityList.FindControl("txtFax");
    //        TextBox txtPhone = (TextBox)dv_UniversityList.FindControl("txtPhone");
    //        TextBox txtPinCode = (TextBox)dv_UniversityList.FindControl("txtPinCode");
    //        DropDownList ddlCountry = (DropDownList)dv_UniversityList.FindControl("ddlCountry");
    //        DropDownList ddlState = (DropDownList)dv_UniversityList.FindControl("ddlState");
    //        DropDownList ddlCity = (DropDownList)dv_UniversityList.FindControl("ddlCity");

    //        UniversityListClass objUL = new UniversityListClass();
    //        objUL.strTitle = txtUniversityTitle.Text;
    //        objUL.iCatID = int.Parse(ddlCategory.SelectedValue.ToString());
    //        objUL.iSubCatID = int.Parse(ddlSubCategory.SelectedValue.ToString());
    //        objUL.strDesc = fckDescription.Value;
    //        objUL.strAddress = txtAddress.Text;
    //        objUL.strEmail = txtEmail.Text;
    //        objUL.strWebsite = txtWebsite.Text;
    //        objUL.strFax = txtFax.Text;
    //        objUL.strPhone = txtPhone.Text;
    //        objUL.strPinCode = txtPinCode.Text;
    //        objUL.strCountry = ddlCountry.SelectedItem.Text;
    //        objUL.strState = ddlState.SelectedItem.Text;
    //        objUL.strCity = ddlCity.SelectedItem.Text;

    //        if (!IsRefresh)
    //        {
    //            string strResponse = objUL.fn_saveUniversityList();

    //            if (strResponse.StartsWith("SUCCESS"))
    //            {
    //                ((Label)info_dv.FindControl("mssg")).Text = strResponse;
    //                info_dv.Visible = true;
    //            }
    //            else
    //            {
    //                ((Label)error_dv.FindControl("mssg")).Text = strResponse;
    //                error_dv.Visible = true;
    //            }
    //        }

    //        // Bind Data To grid            
    //        BindGrid();

    //        // reset fields
    //        txtUniversityTitle.Text = "";
    //        ddlSubCategory.SelectedIndex = 0;
    //        ddlCategory.SelectedIndex = 0;
    //        fckDescription.Value = "";
    //        txtAddress.Text = "";
    //        txtEmail.Text = "";
    //        txtWebsite.Text = "";
    //        txtFax.Text = "";
    //        txtPhone.Text = "";
    //        txtPinCode.Text = "";
    //        ddlCountry.SelectedIndex = 0;
    //        ddlState.SelectedIndex = 0;
    //        ddlCity.SelectedIndex = 0;

    //    }
    //    catch (Exception ex)
    //    {
    //        ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
    //        error.Visible = true;
    //    }
    //}
    protected void dv_UniversityList_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            //DropDownList ddlCategory = dv_UniversityList.FindControl("ddlCategory") as DropDownList;
            //DropDownList ddlSubCategory = dv_UniversityList.FindControl("ddlSubCategory") as DropDownList;
            //DropDownList ddlEligibility = dv_UniversityList.FindControl("ddlEligibility") as DropDownList;
            DropDownList ddlType = dv_UniversityList.FindControl("ddlType") as DropDownList;
            DropDownList ddlUniversityType = (DropDownList)dv_UniversityList.FindControl("ddlUniversityType");
            TextBox txtUniversityTitle = (TextBox)dv_UniversityList.FindControl("txtUniversityTitle");
            FCKeditor fckDescription = (FCKeditor)dv_UniversityList.FindControl("fckDescription");
            FCKeditor fckAddress = (FCKeditor)dv_UniversityList.FindControl("fckAddress");
            TextBox txtEmail = (TextBox)dv_UniversityList.FindControl("txtEmail");
            TextBox txtWebsite = (TextBox)dv_UniversityList.FindControl("txtWebsite");
            //TextBox txtFax = (TextBox)dv_UniversityList.FindControl("txtFax");
            //TextBox txtPhone = (TextBox)dv_UniversityList.FindControl("txtPhone");
            //TextBox txtPinCode = (TextBox)dv_UniversityList.FindControl("txtPinCode");
            //DropDownList ddlCountry = (DropDownList)dv_UniversityList.FindControl("ddlCountry");
            //DropDownList ddlState = (DropDownList)dv_UniversityList.FindControl("ddlState");
            DropDownList ddlCity = (DropDownList)dv_UniversityList.FindControl("ddlCity");
            FileUpload fuUniversityImage = (FileUpload)dv_UniversityList.FindControl("fuUniversityImage");
            CheckBox chkBox_Featured = (CheckBox)dv_UniversityList.FindControl("chkBox_Featured");
            TextBox txtEstablishedIn = (TextBox)dv_UniversityList.FindControl("txtEstablishedIn");
            TextBox txtAffiliatedTo = (TextBox)dv_UniversityList.FindControl("txtAffiliatedTo");

            UniversityListClass objUL = new UniversityListClass();
            objUL.strTitle = txtUniversityTitle.Text;
            //objUL.iCatID = int.Parse(ddlCategory.SelectedValue.ToString());
            //objUL.iSubCatID = int.Parse(ddlSubCategory.SelectedValue.ToString());
            objUL.iTypeID = int.Parse(ddlUniversityType.SelectedValue);
            objUL.strDesc = fckDescription.Value;
            objUL.strAddress = fckAddress.Value;
            objUL.strEmail = txtEmail.Text;
            objUL.strWebsite = txtWebsite.Text;
            //objUL.strFax = txtFax.Text;
            //objUL.strPhone = txtPhone.Text;
            //objUL.strPinCode = txtPinCode.Text;
            //objUL.strCountry = ddlCountry.SelectedItem.Text;
            //objUL.strState = "";
            objUL.strCity = ddlCity.SelectedItem.Text;
            objUL.strImage = strRanFileName;
            objUL.bFeatured = chkBox_Featured.Checked;
            objUL.strAffiliatedTo = txtAffiliatedTo.Text;
            objUL.strEstablishedIn = txtEstablishedIn.Text;
            objUL.iID = int.Parse(dv_UniversityList.DataKey.Value.ToString());
            
            if (!IsRefresh)
            {
                //string strResponse = objUL.fn_editUniversityList();

                string strResponse = string.Empty;

                if (fuUniversityImage.HasFile)
                {
                    DataTable dt = (DataTable)objUL.fn_getUniversityByID();
                    strRanFileName = dt.Rows[0]["strImage"].ToString();

                    if (File.Exists(MapPath("~/admin/Upload/University/" + strRanFileName)))
                    {
                        //Deletes the Image file from the Folder
                        File.Delete((MapPath("~/admin/Upload/University/" + strRanFileName)));
                    }

                    cls_common objCFC = new cls_common();
                    //Calling function to get the name of the file with timestamp
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

            // Bind Data To grid            
            //BindGrid();
            grd_UniversityList.DataSource = objUL.fn_searchUniversityList(fn_SearchUniversityQuery());
            grd_UniversityList.DataBind();
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

                    //BindValueToDDL(dt);

                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            //DropDownList ddlCategory = dv_UniversityList.FindControl("ddlCategory") as DropDownList;

            //if (ddlCategory != null)
            //{
            //    BindDDLSubCategory(int.Parse(ddlCategory.SelectedValue.ToString()));

            //}

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_UniversityList_DataBound(object sender, EventArgs e)
    {
        try
        {
            //fn_getCountry();
            //BindDDLCategory();
            fn_bindTypeDLL();
            //DropDownList ddlCategory = dv_UniversityList.FindControl("ddlCategory") as DropDownList;
            //DropDownList ddlSubCategory = dv_UniversityList.FindControl("ddlSubCategory") as DropDownList;
            //DropDownList ddlCountry = (DropDownList)dv_UniversityList.FindControl("ddlCountry");
            //DropDownList ddlState = (DropDownList)dv_UniversityList.FindControl("ddlState");
            DropDownList ddlCity = (DropDownList)dv_UniversityList.FindControl("ddlCity");
            Label lbl_Featured = (Label)dv_UniversityList.FindControl("lbl_Featured");
            CheckBox chkBox_Featured = (CheckBox)dv_UniversityList.FindControl("chkBox_Featured");
            DropDownList ddlUniversityType = (DropDownList)dv_UniversityList.FindControl("ddlUniversityType");

            if (dv_UniversityList.CurrentMode == DetailsViewMode.Insert)
            {
                //ddlState.Items.Insert(0, new ListItem("Select", "0"));
                fn_getCityForIndia();
                ddlCity.Items.Insert(0, new ListItem("Select", "0"));
                //ddlSubCategory.Items.Insert(0, new ListItem("Select", "0"));
            }

            if (dv_UniversityList.CurrentMode == DetailsViewMode.ReadOnly)
            {
                UniversityListClass objICII = new UniversityListClass();
                objICII.iID = int.Parse(grd_UniversityList.SelectedDataKey.Value.ToString());
                DataTable dtt = (DataTable)objICII.fn_getUniversityByID();

                //Bind Type DropDown
                UniversityTypeClass objUTC = new UniversityTypeClass();
                objUTC.iID = int.Parse(dtt.Rows[0]["iTypeID"].ToString());
                Label lblUniversityType = (Label)dv_UniversityList.FindControl("lblUniversityType");
                DataTable dtType = (DataTable)objUTC.fn_getTypeByID();
                lblUniversityType.Text = dtType.Rows[0]["strTypeTitle"].ToString();

                //Bind Feature Yes/No
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

                //Bind Category And SubCategory 
                //ddlCategory.Items.FindByValue(dt.Rows[0]["iCatID"].ToString()).Selected = true;
                //BindDDLSubCategory(int.Parse(dt.Rows[0]["iCatID"].ToString()));
                //ddlSubCategory.Items.FindByValue(dt.Rows[0]["iSubCatID"].ToString()).Selected = true;

                //Bind Country ,State ,City 
                //ddlCountry.Items.FindByText(dt.Rows[0]["strCountry"].ToString()).Selected = true;
                //string strCountryName = dt.Rows[0]["strCountry"].ToString();
                //CountryMasterClass objCMC = new CountryMasterClass();
                //objCMC.strCountryName = strCountryName;
                //DataTable dtCountry = (DataTable)objCMC.fn_getCountryByCoutryName();
                //fn_getStateByCountry(int.Parse(dtCountry.Rows[0]["iID"].ToString()));
                //ddlState.Items.FindByText(dt.Rows[0]["strState"].ToString()).Selected = true;
                //StateMasterClass objSMC = new StateMasterClass();
                //string strStateName = dt.Rows[0]["strState"].ToString();
                //objSMC.strStateName = strStateName;
                //DataTable dtState = (DataTable)objSMC.fn_getStateByStateName();
                fn_getCityForIndia();
                ddlCity.Items.FindByText(dt.Rows[0]["strCity"].ToString()).Selected = true;

                //Bind University Type Drop Down List
                ddlUniversityType.Items.FindByValue(dt.Rows[0]["iTypeID"].ToString()).Selected = true;

                //Bind Feature Yes/No
                if (bool.Parse(dt.Rows[0]["bFeatured"].ToString()))
                {
                    chkBox_Featured.Checked = true;
                }
                else
                {
                    chkBox_Featured.Checked = false;
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    #region"Country ,State ,City Dropdown Events"

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlCountry = (DropDownList)dv_UniversityList.FindControl("ddlCountry");
            DropDownList ddlState = (DropDownList)dv_UniversityList.FindControl("ddlState");
            DropDownList ddlCity = (DropDownList)dv_UniversityList.FindControl("ddlCity");
            if (ddlCountry.SelectedValue == "0")
            {
                //ddlState.SelectedValue = "0";
                //lState.Enabled = false;
                ddlCity.SelectedValue = "0";
                ddlCity.Enabled = false;

            }
            else
            {
                ddlCity.Enabled = true;
                //int iCountryID = int.Parse(ddlCountry.SelectedValue);
                fn_getCityForIndia();
            }
            if (dv_UniversityList.CurrentMode == DetailsViewMode.Edit)
            {
                //ddlCity.SelectedIndex = 0;
                //ddlCity.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //DropDownList ddlState = (DropDownList)dv_UniversityList.FindControl("ddlState");
            //DropDownList ddlCity = (DropDownList)dv_UniversityList.FindControl("ddlCity");
            //if (ddlState.SelectedValue == "0")
            //{
            //    ddlCity.SelectedValue = "0";
            //    ddlCity.Enabled = false;
            //}
            //else
            //{
            //    ddlCity.Enabled = true;
            //    int iStateID = int.Parse(ddlState.SelectedValue);
            //    fn_getCityByState(iStateID);
            //}
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    //protected void fn_getCountry()
    //{
    //    DropDownList ddlCountry = (DropDownList)dv_UniversityList.FindControl("ddlCountry");
    //    CountryMasterClass objCountry = new CountryMasterClass();
    //    if (ddlCountry != null)
    //    {
    //        ddlCountry.DataSource = objCountry.fn_getCountryList();
    //        ddlCountry.DataValueField = "iID";
    //        ddlCountry.DataTextField = "strCountryName";
    //        ddlCountry.DataBind();
    //        ddlCountry.Items.Insert(0, new ListItem("Select", "0"));
    //    }
    //}

    //protected void fn_getStateByCountry(int iCountryID)
    //{
    //    DropDownList ddlState = (DropDownList)dv_UniversityList.FindControl("ddlState");
    //    if (ddlState != null)
    //    {
    //        StateMasterClass objState = new StateMasterClass();
    //        objState.iCountryID = iCountryID;
    //        ddlState.DataValueField = "iID";
    //        ddlState.DataTextField = "strStateName";
    //        ddlState.DataSource = objState.fn_getStateListByCountryID();
    //        ddlState.DataBind();
    //        ddlState.Items.Insert(0, new ListItem("Select", "0"));
    //    }
    //}

    //protected void fn_getState()
    //{
    //    DropDownList ddlState = (DropDownList)dv_UniversityList.FindControl("ddlState");
    //    if (ddlState != null)
    //    {
    //        StateMasterClass objState = new StateMasterClass();
    //        ddlState.DataValueField = "iID";
    //        ddlState.DataTextField = "strStateName";
    //        ddlState.DataSource = objState.fn_getStateList();
    //        ddlState.DataBind();
    //        ddlState.Items.Insert(0, new ListItem("Select", "0"));
    //    }
    //}

    //protected void fn_getCityByState(int iStateID)
    //{
    //    DropDownList ddlCity = (DropDownList)dv_UniversityList.FindControl("ddlCity");
    //    if (ddlCity != null)
    //    {
    //        CityMasterClass objCM = new CityMasterClass();
    //        objCM.iStateID = iStateID;
    //        ddlCity.DataValueField = "iID";
    //        ddlCity.DataTextField = "strCityName";
    //        ddlCity.DataSource = objCM.fn_getCityListByCountryID();
    //        ddlCity.DataBind();
    //        ddlCity.Items.Insert(0, new ListItem("Select", "0"));
    //    }
    //}

    protected void fn_getCity()
    {
        DropDownList ddlCity = (DropDownList)dv_UniversityList.FindControl("ddlCity");
        if (ddlCity != null)
        {
            CityMasterClass objCM = new CityMasterClass();
            ddlCity.DataValueField = "iID";
            ddlCity.DataTextField = "strCityName";
            ddlCity.DataSource = objCM.fn_getCityList();
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("Select", "0"));
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

    #endregion


    protected void ddlCategoryAll_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //BindDDLSubCategoryAll(int.Parse(ddlCategory.SelectedValue.ToString()));
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            UniversityListClass objUL = new UniversityListClass();
            grd_UniversityList.DataSource = objUL.fn_searchUniversityList(fn_SearchUniversityQuery());
            grd_UniversityList.DataBind();

            dv_UniversityList.Visible = false;
            Label_Title.Visible = false;
            Horz_Line.Visible = false;
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    public string fn_SearchUniversityQuery()
    {
        string strQuery = "SELECT * FROM edu_UniversityList";
        bool blnflag = false;

        if (txtUniversityTitle.Text != "")
        {
            if (blnflag)
            {
                strQuery += " AND universityList_title LIKE '" + txtUniversityTitle.Text + "%'";
            }

            else
            {
                strQuery += " WHERE universityList_title LIKE '" + txtUniversityTitle.Text + "%'";
            }
            blnflag = true;
        }


        //if (ddlCategory.SelectedIndex != 0)
        //{
        //    if (blnflag)
        //    {

        //        strQuery += " AND universityList_catID='" + ddlCategory.SelectedValue.ToString() + "'";
        //    }
        //    else
        //    {
        //        strQuery += " WHERE universityList_catID='" + ddlCategory.SelectedValue.ToString() + "'";
        //    }
        //    blnflag = true;
        //}

        //if (ddlSubCategory.SelectedIndex != 0)
        //{
        //    if (blnflag)
        //    {
        //        strQuery += "  AND universityList_subCatID ='" + ddlSubCategory.SelectedValue + "' ";
        //    }
        //    else
        //    {
        //        strQuery += "  WHERE universityList_subCatID ='" + ddlSubCategory.SelectedValue + "'";
        //    }
        //    blnflag = true;
        //}


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
    protected void rprAlphanumeric_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Filter")
            {
                string _letterFilter = (string)e.CommandArgument;
                //ViewState["FilterKey"] = _letterFilter;

                UniversityListClass objUL = new UniversityListClass();
                CoreWebList<UniversityListClass>objList = objUL.fn_getUniversityList();
                
                if (objList.Count > 0)
                {
                    DataTable dtUniversity = (DataTable)objList;
                    if (_letterFilter == "All")
                        dtUniversity.DefaultView.RowFilter = string.Empty;
                    else
                        dtUniversity.DefaultView.RowFilter = "strTitle LIKE '" + _letterFilter + "%'";
                    grd_UniversityList.DataSource = dtUniversity;
                    grd_UniversityList.DataBind();
                }
                //ddlCategory.SelectedIndex = 0;
                //ddlSubCategory.SelectedIndex = 0;
                ddlCity.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void grd_UniversityList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Featured")
            {
                int iId = Convert.ToInt32(e.CommandArgument);
                UniversityListClass objIM = new UniversityListClass();
                ImageButton btnFeatured = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnFeatured.Parent.Parent;

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
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
}
