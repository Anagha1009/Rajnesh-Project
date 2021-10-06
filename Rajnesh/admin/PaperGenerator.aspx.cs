using System;
using System.Activities.Expressions;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class admin_Papers : Page
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
        var allStates = (object[])savedState;
        base.LoadViewState(allStates[0]);
        _refreshState = (bool)allStates[1];
        if (Session["__ISREFRESH"] != null)
        {
            _isRefresh = _refreshState == (bool)Session["__ISREFRESH"];
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
                    fn_BindCompanyDDL();
                    fn_BindCategoryDDL();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!IsRefresh)
            {
                var objPage = new PaperGeneratorClass
                {
                    strFileName = txtQuery.Text.Trim().Replace(" ", "-") + ".aspx",
                    strPageTitle = txtPageTitle.Text,
                    strType = "Papers",
                    strCompany = ddl_Company.SelectedValue != "0" ? ddl_Company.SelectedValue : "All",
                    strCategory = ddlCategory.SelectedValue,
                    bPaper = false,
                    bQuestion = false,
                };

                string strIdentity = "";

                for (int i = 0; i < ListBox_Papers.Items.Count; i++)
                {
                    if (ListBox_Papers.Items[i].Selected)
                    {
                        strIdentity += ListBox_Papers.Items[i].Value + ",";
                    }
                }

                strIdentity = strIdentity.TrimEnd(',');

                objPage.strIdentities = strIdentity;

                objPage.strH3 = txtH3.Value;
                objPage.strMetaTitle = txtPageTitle.Text.Trim() + " Placement Papers in " + txtPageTitle.Text.Trim();
                objPage.strMetaDescription = txtPageTitle.Text.Trim() + " Placement Papers in " + txtPageTitle.Text.Trim();
                objPage.strKeywords = txtPageTitle.Text.Trim() + " Placement Papers in " + txtPageTitle.Text.Trim();

                string strResponse = objPage.fn_SavePaperGenerator();

                if (strResponse.StartsWith("SUCCESS"))
                {
                    ((Label)info.FindControl("mssg")).Text = strResponse;
                    info.Visible = true;
                }
                else
                {
                    ((Label)info.FindControl("mssg")).Text = strResponse;
                    info.Visible = true;
                }

                ddlCategory.SelectedIndex = 0;
                ddl_Company.SelectedIndex = 0;
                txtPageTitle.Text = "";
                txtH3.Value = "";
                txtQuery.Text = "";
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    public void fn_BindCompanyDDL()
    {
        var objCm = new JobCompanyClass();
        ddl_Company.DataValueField = "strJobCompanyName";
        ddl_Company.DataTextField = "strJobCompanyName";
        ddl_Company.DataSource = objCm.fn_GetJobCompanyList();
        ddl_Company.DataBind();
        ddl_Company.Items.Insert(0, new ListItem("All", "0"));
    }

    public void fn_BindCategoryDDL()
    {
        var objCm = new JobCategoryClass();
        ddlCategory.DataSource = objCm.fn_GetJobCategoryList();
        ddlCategory.DataTextField = "strJobCategoryName";
        ddlCategory.DataValueField = "iID";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("All", "0"));
    }

    public void fn_Institute()
    {
        ListBox_Papers.Items.Clear();
        fn_BindCompanyDDL();
    }

    public void fn_EditQueryGenerator()
    {
        try
        {
            var objPage = new PaperGeneratorClass { iID = int.Parse(Request.QueryString["PaperId"]) };

            CoreWebList<PaperGeneratorClass> objPageList = objPage.fn_GetPaperById();
            if (objPageList.Count > 0)
            {
                txtQuery.Text = objPageList[0].strFileName;
                txtPageTitle.Text = objPageList[0].strPageTitle;
                txtH3.Value = objPageList[0].strH3;

                string strType = objPageList[0].strType;
                if (strType == "Papers")
                {
                    fn_BindCompanyDDL();
                    fn_BindCategoryDDL();
                    ddl_Company.SelectedValue = objPageList[0].strCompany;
                    ddlCategory.SelectedValue = objPageList[0].strCategory;
                    var company = (objPageList[0].strCompany != "0" && objPageList[0].strCompany != "All") ? objPageList[0].strCompany : "";
                    var category = (objPageList[0].strCategory != "0" && objPageList[0].strCategory != "All") ? objPageList[0].strCategory : "";

                    fn_BindPapers(company, category);

                    //if (objPageList[0].strCompany != "All")
                    //{
                    //    fn_BindCompanyDDL();
                    //    fn_BindCategoryDDL();
                    //    ddl_Company.SelectedValue = objPageList[0].strCompany;
                    //    ddlCategory.SelectedValue = objPageList[0].strCategory;
                    //    fn_BindPapers();
                    //}

                    //else if (objPageList[0].strCompany == "All")
                    //{
                    //    fn_BindCompanyDDL();
                    //    fn_BindCategoryDDL();
                    //    ddl_Company.SelectedIndex = 0;
                    //    ddlCategory.SelectedIndex = 0;
                    //    fn_BindPapers();
                    //}

                    string strIDs = objPageList[0].strIdentities;
                    strIDs = strIDs.Replace("'", "");
                    string[] myArray = strIDs.Split(',');

                    //for (int i = 0; i < ListBox_Papers.Items.Count; i++)
                    //{
                    //    int iCatId = int.Parse(ListBox_Papers.Items[i].Value);

                    //    foreach (string id in myArray)
                    //    {
                    //        int categoryId = int.Parse(id);
                    //        if (categoryId == iCatId)
                    //        {
                    //            ListBox_Papers.Items[i].Selected = true;
                    //        }
                    //    }
                    //}
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
        var company = ddl_Company.SelectedIndex != 0 ? ddl_Company.SelectedValue : "";
        var category = ddlCategory.SelectedIndex != 0 ? ddlCategory.SelectedValue : "";
        fn_BindPapers(company, category);
    }

    public void fn_BindPapers(string company = "", string category = "")
    {
        try
        {
            string strQuery = "Select * From edu_Papers";
            bool blnflag = false;

            if (!string.IsNullOrEmpty(company))
            {
                strQuery += "  WHERE paper_company like '%" + ddl_Company.SelectedValue + "%'";
                blnflag = true;
            }

            if (!string.IsNullOrEmpty(category))
            {
                if (blnflag)
                    strQuery += "  AND paper_category like '%" + category + "%'";
                else
                    strQuery += "  WHERE paper_category like '%" + category + "%'";
            }

            var objJobs = new PaperClass();
            CoreWebList<PaperClass> objJobsList = objJobs.fn_GetPaperByQuery(strQuery);
            if (objJobsList.Count > 0)
            {
                ListBox_Papers.DataSource = objJobsList;
                ListBox_Papers.DataTextField = "strTitle";
                ListBox_Papers.DataValueField = "iID";
                ListBox_Papers.DataBind();
            }
            else
            {
                ListBox_Papers.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (!IsRefresh)
            {
                var objPage = new PaperGeneratorClass
                {
                    iID = int.Parse(Request.QueryString["PaperId"]),
                    strFileName = txtQuery.Text,
                    strPageTitle = txtPageTitle.Text,
                    strType = "Papers",
                    strCategory = ddlCategory.SelectedValue
                };

                if (ddl_Company.Enabled)
                {
                    objPage.strCompany = ddl_Company.SelectedItem.Text;
                }

                string strIdentity = "";

                for (int i = 0; i < ListBox_Papers.Items.Count; i++)
                {
                    if (ListBox_Papers.Items[i].Selected)
                    {
                        strIdentity += ListBox_Papers.Items[i].Value + ",";
                    }
                }

                strIdentity = strIdentity.TrimEnd(',');

                objPage.strIdentities = strIdentity;

                objPage.strH3 = txtH3.Value;
                objPage.strMetaTitle = txtPageTitle.Text.Trim() + " Palcement Papers in " + txtPageTitle.Text.Trim();
                objPage.strMetaDescription = txtPageTitle.Text.Trim() + " Palcement Papers in " + txtPageTitle.Text.Trim();
                objPage.strKeywords = txtPageTitle.Text.Trim() + " Palcement Papers in " + txtPageTitle.Text.Trim();

                string strResponse = objPage.fn_EditPaper();

                if (strResponse.StartsWith("SUCCESS"))
                {
                    ((Label)info.FindControl("mssg")).Text = strResponse;
                    info.Visible = true;
                }
                else
                {
                    ((Label)info.FindControl("mssg")).Text = strResponse;
                    info.Visible = true;
                }
                txtPageTitle.Text = "";
                txtH3.Value = "";
                txtQuery.Text = "";
                ddlCategory.SelectedIndex = 0;
                ddl_Company.SelectedIndex = 0;
            }
        }

        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void ddl_Company_SelectedIndexChanged(object sender, EventArgs e)
    {
        var company = ddl_Company.SelectedIndex != 0 ? ddl_Company.SelectedValue : "";
        var category = ddlCategory.SelectedIndex != 0 ? ddlCategory.SelectedValue : "";
        fn_BindPapers(company, category);
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        var company = ddl_Company.SelectedIndex != 0 ? ddl_Company.SelectedValue : "";
        var category = ddlCategory.SelectedIndex != 0 ? ddlCategory.SelectedValue : "";
        fn_BindPapers(company, category);
    }
}