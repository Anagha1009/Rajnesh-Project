using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class admin_InstituteRequire : Page
{
    #region "view state methods for checking the user refresh here"

    private bool _isRefresh;
    private bool _refreshState;

    public bool IsRefresh
    {
        get { return _isRefresh; }
    }

    protected override void LoadViewState(object savedState)
    {
        var allStates = (object[]) savedState;
        base.LoadViewState(allStates[0]);
        _refreshState = (bool) allStates[1];
        if (Session["__ISREFRESH"] != null)
        {
            _isRefresh = _refreshState == (bool) Session["__ISREFRESH"];
        }
    }

    protected override object SaveViewState()
    {
        Session["__ISREFRESH"] = _refreshState;
        var allStates = new object[2];
        allStates[0] = base.SaveViewState();
        allStates[1] = !_refreshState;
        return allStates;
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["admin"] == null)
            {
                //Response.Redirect("Login.aspx?flag=1");
            }

            if (Request.QueryString["Mode"] != null)
            {
                btnUpdate.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }

            if (rb_Institutes.Checked)
            {
                ddl_Category.Visible = true;
                ddl_Subcategory.Visible = true;
                ddl_City.Visible = true;

                ddl_Company.Visible = false;
            }

            if (rb_Company.Checked)
            {
                ddl_Category.Visible = false;
                ddl_Subcategory.Visible = false;
                ddl_City.Visible = false;

                ddl_Company.Visible = true;
            }

            info.Visible = false;
            error.Visible = false;
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                if (Request.QueryString["Mode"] != null)
                {
                    fn_EditQueryGenerator();
                }
                else
                {
                    fn_BindCategoryDDL();
                    fn_BindSubCategoryDDL();
                    fn_BindCityDropDownList();
                    fn_BindCompanyDDL();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label) error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!IsRefresh)
            {
                var objPage = new JobGeneratorClass
                {
                    strFileName = txtQuery.Text.Replace(" ", "-") + ".aspx",
                    strPageTitle = txtPageTitle.Text,
                    strType = "Jobs"
                };


                if (ddl_Category.Enabled)
                {
                    objPage.iCategory = int.Parse(ddl_Category.SelectedValue);
                }

                if (ddl_Subcategory.Enabled)
                {
                    objPage.iSubCategory = int.Parse(ddl_Subcategory.SelectedValue);
                }

                if (ddl_City.Enabled)
                {
                    objPage.strCity = ddl_City.SelectedItem.Text;
                }

                if (ddl_Company.Enabled)
                {
                    objPage.iComapny = int.Parse(ddl_Company.SelectedValue);
                }

                if (chkCompany.Checked)
                {
                    objPage.bCompany = true;
                }

                if (chkCategory.Checked)
                {
                    objPage.bCategory = true;
                }

                if (chkLocation.Checked)
                {
                    objPage.bLocation = true;
                }

                if (rd_yes.Checked)
                {
                    objPage.bLinkStatus = true;
                }
                else
                {
                    objPage.bLinkStatus = false;
                    objPage.strTargetUrl = txtTargetUrl.Text;
                }

                string strIdentity = "";

                for (int i = 0; i < ListBox_Institute.Items.Count; i++)
                {
                    if (ListBox_Institute.Items[i].Selected)
                    {
                        strIdentity += ListBox_Institute.Items[i].Value + ",";
                    }
                }

                strIdentity = strIdentity.TrimEnd(',');

                objPage.strIdentities = strIdentity;

                objPage.strH1 = txtH1.Text;
                objPage.strH2 = txtH2.Text;
                objPage.strH3 = txtH3.Value;
                objPage.strH4 = txtH4.Text;
                objPage.strMetaTitle = txtMetaTitle.Text;
                objPage.strMetaDescription = txtMetaDesc.Text;
                objPage.strKeywords = txtMetaKeys.Text;

                string strResponse = objPage.fn_SaveJobGenerator();

                if (strResponse.StartsWith("SUCCESS"))
                {
                    ((Label) info.FindControl("mssg")).Text = strResponse;
                    info.Visible = true;
                }
                else
                {
                    ((Label) info.FindControl("mssg")).Text = strResponse;
                    info.Visible = true;
                }
                txtPageTitle.Text = "";
                txtH1.Text = "";
                txtH2.Text = "";
                txtH3.Value = "";
                txtH4.Text = "";
                txtMetaDesc.Text = "";
                txtMetaKeys.Text = "";
                txtMetaTitle.Text = "";
                txtQuery.Text = "";
            }
        }
        catch (Exception ex)
        {
            ((Label) error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    public void fn_BindCategoryDDL()
    {
        var objCm = new JobCategoryClass();
        ddl_Category.DataValueField = "iID";
        ddl_Category.DataTextField = "strJobCategoryName";
        ddl_Category.DataSource = objCm.fn_GetJobCategoryList();
        ddl_Category.DataBind();
        ddl_Category.Items.Insert(0, new ListItem("All", "0"));
    }

    public void fn_BindSubCategoryDDL()
    {
        var objCm = new JobSubCategoryClass();
        ddl_Subcategory.DataValueField = "iID";
        ddl_Subcategory.DataTextField = "strJobSubCategoryName";
        ddl_Subcategory.DataSource = objCm.fn_GetJobSubCategoryList();
        ddl_Subcategory.DataBind();
        ddl_Subcategory.Items.Insert(0, new ListItem("All", "0"));
    }

    private void fn_BindCityDropDownList()
    {
        var objCm = new CityMasterClass();
        ddl_City.DataTextField = "strCityName";
        ddl_City.DataValueField = "iID";
        ddl_City.DataSource = objCm.fn_getCityListForIndia();
        ddl_City.DataBind();
        ddl_City.Items.Insert(0, new ListItem("All", "0"));
    }

    public void fn_BindCompanyDDL()
    {
        var objCm = new JobCompanyClass();
        ddl_Company.DataValueField = "iID";
        ddl_Company.DataTextField = "strJobCompanyName";
        ddl_Company.DataSource = objCm.fn_GetJobCompanyList();
        ddl_Company.DataBind();
        ddl_Company.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void rb_Institutes_CheckedChanged(object sender, EventArgs e)
    {
        ddl_Category.Visible = true;
        ddl_Subcategory.Visible = true;
        ddl_City.Visible = true;

        ddl_Company.Visible = false;

        fn_Institute();
    }

    protected void rb_Company_CheckedChanged(object sender, EventArgs e)
    {
        ddl_Category.Visible = false;
        ddl_Subcategory.Visible = false;
        ddl_City.Visible = false;

        ddl_Company.Visible = true;
    }

    public void fn_Institute()
    {
        var objCm = new JobCategoryClass();
        ddl_Category.DataValueField = "iID";
        ddl_Category.DataTextField = "strJobCategoryName";
        ddl_Category.DataSource = objCm.fn_GetJobCategoryList();
        ddl_Category.DataBind();
        ddl_Category.Items.Insert(0, new ListItem("All", "0"));
        ddl_Category.Visible = true;
        ListBox_Institute.Items.Clear();
        fn_BindCityDropDownList();
        fn_BindSubCategoryDDL();
        fn_BindCompanyDDL();

        lblCategory.Visible = true;
        td_Category.Visible = true;
    }

    public void fn_EditQueryGenerator()
    {
        try
        {
            var objPage = new JobGeneratorClass {iID = int.Parse(Request.QueryString["JobId"])};

            CoreWebList<JobGeneratorClass> objPageList = objPage.fn_GetJobById();
            if (objPageList.Count > 0)
            {
                txtQuery.Text = objPageList[0].strFileName;
                txtPageTitle.Text = objPageList[0].strPageTitle;
                txtH1.Text = objPageList[0].strH1;
                txtH2.Text = objPageList[0].strH2;
                txtH3.Value = objPageList[0].strH3;
                txtH4.Text = objPageList[0].strH4;
                txtMetaTitle.Text = objPageList[0].strMetaTitle;
                txtMetaDesc.Text = objPageList[0].strMetaDescription;
                txtMetaKeys.Text = objPageList[0].strKeywords;

                if (objPageList[0].bCompany)
                {
                    chkCompany.Checked = true;
                }

                if (objPageList[0].bCategory)
                {
                    chkCategory.Checked = true;
                }

                if (objPageList[0].bLocation)
                {
                    chkLocation.Checked = true;
                }

                if (objPageList[0].bLinkStatus)
                {
                    rd_yes.Checked = true;
                    rd_no.Checked = false;
                }
                else
                {
                    rd_yes.Checked = false;
                    rd_no.Checked = true;
                    txtTargetUrl.Text = objPageList[0].strTargetUrl;
                }

                string strType = objPageList[0].strType;
                if (strType == "Jobs")
                {
                    if (objPageList[0].iComapny > 0)
                    {
                        rb_Institutes.Checked = false;
                        rb_Company.Checked = true;
                        fn_BindCompanyDDL();

                        ddl_Company.SelectedValue = objPageList[0].iComapny.ToString(CultureInfo.InvariantCulture);
                        ddl_Category.Visible = false;
                        ddl_Subcategory.Visible = false;
                        ddl_City.Visible = false;

                        ddl_Company.Visible = true;
                        fn_BindJobs();
                    }

                    else if (objPageList[0].iComapny == 0)
                    {
                        rb_Institutes.Checked = true;
                        rb_Company.Checked = false;
                        fn_BindCategoryDDL();
                        fn_BindSubCategoryDDL();
                        fn_BindCityDropDownList();

                        ddl_Category.SelectedValue = objPageList[0].iCategory.ToString(CultureInfo.InvariantCulture);
                        ddl_Subcategory.SelectedValue = objPageList[0].iSubCategory.ToString(CultureInfo.InvariantCulture);
                        ddl_City.SelectedItem.Text = objPageList[0].strCity;

                        ddl_Category.Visible = true;
                        ddl_Subcategory.Visible = true;
                        ddl_City.Visible = true;

                        ddl_Company.Visible = false;

                        fn_BindInstitutes();
                    }


                    string strIDs = objPageList[0].strIdentities;
                    strIDs = strIDs.Replace("'", "");
                    string[] myArray = strIDs.Split(',');

                    for (int i = 0; i < ListBox_Institute.Items.Count; i++)
                    {
                        int iCatId = int.Parse(ListBox_Institute.Items[i].Value);

                        foreach (string id in myArray)
                        {
                            int category = int.Parse(id);
                            if (category == iCatId)
                            {
                                ListBox_Institute.Items[i].Selected = true;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void lnk_proceed_Click(object sender, EventArgs e)
    {
        if (rb_Institutes.Checked)
        {
            fn_BindInstitutes();
        }
        else
        {
            ListBox_Institute.Items.Clear();
        }
    }

    public void fn_BindInstitutes()
    {
        try
        {
            string strQuery = "Select * From edu_Jobs";
            bool blnflag = false;

            if (ddl_Category.SelectedValue != "0")
            {
                strQuery += " WHERE Job_CategoryID = " + ddl_Category.SelectedValue;
                blnflag = true;
            }

            if (ddl_Subcategory.SelectedValue != "0")
            {
                if (blnflag)
                {
                    strQuery += "  AND Job_SubCategoryID = " + ddl_Subcategory.SelectedValue;
                }
                else
                {
                    strQuery += "  WHERE Job_SubCategoryID = " + ddl_Subcategory.SelectedValue;
                    blnflag = true;
                }
            }

            if (ddl_City.SelectedValue != "0")
            {
                if (blnflag)
                {
                    strQuery += "  AND Job_LocationID = " + ddl_City.SelectedValue;
                }
                else
                {
                    strQuery += "  WHERE Job_LocationID = " + ddl_City.SelectedValue;
                }
            }

            if (ddl_Company.SelectedValue != "0" && rb_Company.Checked)
            {
                strQuery += "  WHERE Job_CompanyID = " + ddl_Company.SelectedValue;
            }


            var objJobs = new JobClass();
            CoreWebList<JobClass> objJobsList = objJobs.fn_get_JobListByQuery(strQuery);
            if (objJobsList.Count > 0)
            {
                ListBox_Institute.DataSource = objJobsList;
                ListBox_Institute.DataTextField = "strTitle";
                ListBox_Institute.DataValueField = "iID";
                ListBox_Institute.DataBind();
            }
            else
            {
                ListBox_Institute.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            ((Label) error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    public void fn_BindJobs()
    {
        try
        {
            string strQuery = "Select * From edu_Jobs";

            if (ddl_Company.SelectedValue != "0")
            {
                strQuery += "  WHERE Job_CompanyID = " + ddl_Company.SelectedValue;
            }


            var objJobs = new JobClass();
            CoreWebList<JobClass> objJobsList = objJobs.fn_get_JobListByQuery(strQuery);
            if (objJobsList.Count > 0)
            {
                ListBox_Institute.DataSource = objJobsList;
                ListBox_Institute.DataTextField = "strTitle";
                ListBox_Institute.DataValueField = "iID";
                ListBox_Institute.DataBind();
            }
            else
            {
                ListBox_Institute.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            ((Label) error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (!IsRefresh)
            {
                var objPage = new JobGeneratorClass
                {
                    iID = int.Parse(Request.QueryString["JobId"]),
                    strFileName = txtQuery.Text,
                    strPageTitle = txtPageTitle.Text,
                    strType = "Jobs"
                };

                if (ddl_Category.Enabled && rb_Institutes.Checked)
                {
                    objPage.iCategory = int.Parse(ddl_Category.SelectedValue);
                }

                if (ddl_Category.Enabled && rb_Institutes.Checked)
                {
                    objPage.iSubCategory = int.Parse(ddl_Subcategory.SelectedValue);
                }

                if (ddl_City.Enabled && rb_Institutes.Checked)
                {
                    objPage.strCity = ddl_City.SelectedItem.Text;
                }

                if (ddl_Company.Enabled && rb_Company.Checked)
                {
                    objPage.iComapny = int.Parse(ddl_Company.SelectedValue);
                }

                if (chkCompany.Checked)
                {
                    objPage.bCompany = true;
                }

                if (chkCategory.Checked)
                {
                    objPage.bCategory = true;
                }

                if (chkLocation.Checked)
                {
                    objPage.bLocation = true;
                }

                if (rd_yes.Checked)
                {
                    objPage.bLinkStatus = true;
                }
                else
                {
                    objPage.bLinkStatus = false;
                    objPage.strTargetUrl = txtTargetUrl.Text;
                }

                string strIdentity = "";

                for (int i = 0; i < ListBox_Institute.Items.Count; i++)
                {
                    if (ListBox_Institute.Items[i].Selected)
                    {
                        strIdentity += ListBox_Institute.Items[i].Value + ",";
                    }
                }

                strIdentity = strIdentity.TrimEnd(',');

                objPage.strIdentities = strIdentity;

                objPage.strH1 = txtH1.Text;
                objPage.strH2 = txtH2.Text;
                objPage.strH3 = txtH3.Value;
                objPage.strH4 = txtH4.Text;
                objPage.strMetaTitle = txtMetaTitle.Text;
                objPage.strMetaDescription = txtMetaDesc.Text;
                objPage.strKeywords = txtMetaKeys.Text;

                string strResponse = objPage.fn_EditJob();

                if (strResponse.StartsWith("SUCCESS"))
                {
                    ((Label) info.FindControl("mssg")).Text = strResponse;
                    info.Visible = true;
                }
                else
                {
                    ((Label) info.FindControl("mssg")).Text = strResponse;
                    info.Visible = true;
                }
                txtPageTitle.Text = "";
                txtH1.Text = "";
                txtH2.Text = "";
                txtH3.Value = "";
                txtH4.Text = "";
                txtMetaDesc.Text = "";
                txtMetaKeys.Text = "";
                txtMetaTitle.Text = "";
                txtQuery.Text = "";
            }
        }

        catch (Exception ex)
        {
            ((Label) error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
    {
        var objJobSubCategory = new JobSubCategoryClass {iCategoryID = int.Parse(ddl_Category.SelectedValue)};
        ddl_Subcategory.DataValueField = "iID";
        ddl_Subcategory.DataTextField = "strJobSubCategoryName";
        ddl_Subcategory.DataSource = objJobSubCategory.fn_GetJobSubCategoryByCategoryID();
        ddl_Subcategory.DataBind();
        ddl_Subcategory.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void ddl_Company_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strQuery = "Select * From edu_Jobs Where Job_CompanyID = " + ddl_Company.SelectedValue;
        var objJobs = new JobClass();
        CoreWebList<JobClass> objJobsList = objJobs.fn_get_JobListByQuery(strQuery);
        if (objJobsList.Count > 0)
        {
            ListBox_Institute.DataSource = objJobsList;
            ListBox_Institute.DataTextField = "strTitle";
            ListBox_Institute.DataValueField = "iID";
            ListBox_Institute.DataBind();
        }
        else
        {
            ListBox_Institute.Items.Clear();
        }
    }
}