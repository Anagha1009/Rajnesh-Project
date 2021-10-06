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
using FredCK.FCKeditorV2;
using System.IO;
using System.Globalization;

public partial class admin_Jobs : System.Web.UI.Page
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

    private CoreWebList<JobClass> chJobList
    {
        get
        {
            if (Cache["chJobList"] != null)
                return (CoreWebList<JobClass>)Cache["chJobList"];
            return null;
        }
        set
        {
            Cache["chJobList"] = value;
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
                JobClass objIM = new JobClass ();
                chJobList = objIM.fn_get_JobList();

                if (chJobList.Count > 0)
                {
                    grd_Jobs.DataSource = chJobList;
                }
                else
                {
                    grd_Jobs.DataSource = null;
                }
                grd_Jobs.DataBind();

                fn_BindCatDDL();
                fn_BindLocDDL();
                fn_BindCompDDL();

                fn_BindCategoryDropDownList();
                fn_BindCompanyDropDownList();
                fn_BindLocationDropDownList();
                fn_BindSubCategoryDropDownList();

                if (grd_Jobs.SelectedIndex < 0)
                {
                    dv_Jobs.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void fn_BindCategoryDropDownList()
    {
        try
        {
            DropDownList ddl_Category = (DropDownList)dv_Jobs.FindControl("ddl_Category");
            if (ddl_Category != null)
            {
                JobCategoryClass objCM = new JobCategoryClass();
                ddl_Category.DataSource = objCM.fn_GetJobCategoryList();
                ddl_Category.DataTextField = "strJobCategoryName";
                ddl_Category.DataValueField = "iID";
                ddl_Category.DataBind();
                ddl_Category.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void fn_BindSubCategoryDropDownList()
    {
        try
        {
            DropDownList ddl_SubCategory = (DropDownList)dv_Jobs.FindControl("ddl_SubCategory");
            if (ddl_SubCategory != null)
            {
                JobSubCategoryClass objCM = new JobSubCategoryClass();
                ddl_SubCategory.DataSource = objCM.fn_GetJobSubCategoryList();
                ddl_SubCategory.DataTextField = "strJobSubCategoryName";
                ddl_SubCategory.DataValueField = "iID";
                ddl_SubCategory.DataBind();
                ddl_SubCategory.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void fn_BindLocationDropDownList()
    {
        try
        {
            DropDownList ddl_Location = (DropDownList)dv_Jobs.FindControl("ddl_Location");
            if (ddl_Location != null)
            {
                CityMasterClass objCM = new CityMasterClass();
                ddl_Location.DataSource = objCM.fn_getCityList();
                ddl_Location.DataTextField = "strCityName";
                ddl_Location.DataValueField = "iID";
                ddl_Location.DataBind();
                ddl_Location.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
    protected void fn_BindCompanyDropDownList()
    {
        try
        {
            DropDownList ddl_Company = (DropDownList)dv_Jobs.FindControl("ddl_Company");
            if (ddl_Company != null)
            {
                JobCompanyClass objCM = new JobCompanyClass();
                ddl_Company.DataSource = objCM.fn_GetJobCompanyList();
                ddl_Company.DataTextField = "strJobCompanyName";
                ddl_Company.DataValueField = "iID";
                ddl_Company.DataBind();
                ddl_Company.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Jobs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Jobs.PageIndex = e.NewPageIndex;
            grd_Jobs.DataSource = chJobList;
            grd_Jobs.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
  
    protected void grd_Jobs_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            JobClass  objIM = new JobClass ();
            objIM.iID = int.Parse(grd_Jobs.DataKeys[e.RowIndex].Value.ToString());

            DataTable dtPro = (DataTable)objIM.fn_get_JobByID();

            string strResponse = objIM.fn_deleteJob();

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

            JobClass  objJobs = new JobClass ();
            grd_Jobs.DataSource = objJobs.fn_get_JobList();
            grd_Jobs.DataBind();
            

            dv_Jobs.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Jobs_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Jobs.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Jobs.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_Jobs.ChangeMode(DetailsViewMode.Edit);

                JobClass  objIM = new JobClass ();
                objIM.iID = int.Parse(grd_Jobs.SelectedDataKey.Value.ToString());
                DataTable dtData = (DataTable)objIM.fn_get_JobByID();
                if (dtData != null)
                {
                    dv_Jobs.DataSource = dtData;
                    dv_Jobs.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
   
    protected void dv_Jobs_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtInstituteTitle = (TextBox)dv_Jobs.FindControl("txtInstituteTitle");
            FCKeditor txtInstituteDesc = (FCKeditor)dv_Jobs.FindControl("txtInstituteDesc");
            DropDownList ddl_Category = (DropDownList)dv_Jobs.FindControl("ddl_Category");
            DropDownList ddl_SubCategory = (DropDownList)dv_Jobs.FindControl("ddl_SubCategory");
            DropDownList ddl_Location = (DropDownList)dv_Jobs.FindControl("ddl_Location");
            DropDownList ddl_Company = (DropDownList)dv_Jobs.FindControl("ddl_Company");

            DropDownList ddl_Day = (DropDownList)dv_Jobs.FindControl("ddl_Day");
            DropDownList ddl_Month = (DropDownList)dv_Jobs.FindControl("ddl_Month");
            DropDownList ddl_Year = (DropDownList)dv_Jobs.FindControl("ddl_Year");

            if (txtInstituteTitle != null && txtInstituteDesc != null && ddl_Category != null && ddl_SubCategory != null && ddl_Location != null && ddl_Company != null && ddl_Day != null && ddl_Month != null && ddl_Year != null)
            {
                JobClass  objIM = new JobClass ();

                objIM.strTitle = txtInstituteTitle.Text;
                objIM.strDescription = txtInstituteDesc.Value;
                objIM.iCategoryID = int.Parse(ddl_Category.SelectedValue.ToString());
                objIM.iSubCategoryID = int.Parse(ddl_SubCategory.SelectedValue.ToString());
                objIM.iLocationID = int.Parse(ddl_Location.SelectedValue.ToString());
                objIM.iCompanyID = int.Parse(ddl_Company.SelectedValue.ToString());
                objIM.iPostedBy = 0;
                objIM.bActive = true;

                int Year = int.Parse(ddl_Year.SelectedValue);
                int Month = int.Parse(ddl_Month.SelectedValue);
                int Day = int.Parse(ddl_Day.SelectedValue);

                DateTime dt_Date = new DateTime(Year, Month, Day, 00, 00, 00);
                objIM.dtExpirationDate = dt_Date;
                

                if (!IsRefresh)
                {
                    string strResponse = objIM.fn_SaveJob();

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

                grd_Jobs.DataSource = objIM.fn_get_JobList();
                grd_Jobs.DataBind();

                CoreWebList<JobClass > objList = objIM.fn_get_JobList();
                if (objList.Count > 0)
                {
                    DataTable dtInst = (DataTable)objList;
                    //ViewState["grid"] = dtInst;
                    grd_Jobs.DataSource = dtInst;
                    grd_Jobs.DataBind();
                }

                // reset fields
                txtInstituteTitle.Text = "";
                txtInstituteDesc.Value = "";

                ddl_Category.SelectedIndex = 0;
                ddl_Company.SelectedIndex = 0;
                ddl_Location.SelectedIndex = 0;
                ddl_SubCategory.SelectedIndex = 0;

                ddl_Day.SelectedIndex = 0;
                ddl_Month.SelectedIndex = 0;
                ddl_Year.SelectedIndex = 0;
            }
            
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void dv_Jobs_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtInstituteTitle = (TextBox)dv_Jobs.FindControl("txtInstituteTitle");
            FCKeditor txtInstituteDesc = (FCKeditor)dv_Jobs.FindControl("txtInstituteDesc");
            DropDownList ddl_Category = (DropDownList)dv_Jobs.FindControl("ddl_Category");
            DropDownList ddl_SubCategory = (DropDownList)dv_Jobs.FindControl("ddl_SubCategory");
            DropDownList ddl_Location = (DropDownList)dv_Jobs.FindControl("ddl_Location");
            DropDownList ddl_Company = (DropDownList)dv_Jobs.FindControl("ddl_Company");

            DropDownList ddl_Day = (DropDownList)dv_Jobs.FindControl("ddl_Day");
            DropDownList ddl_Month = (DropDownList)dv_Jobs.FindControl("ddl_Month");
            DropDownList ddl_Year = (DropDownList)dv_Jobs.FindControl("ddl_Year");

            TextBox txtRank = (TextBox)dv_Jobs.FindControl("txtRank");

            JobClass  objIM = new JobClass ();

            objIM.iID = int.Parse(dv_Jobs.DataKey.Value.ToString());
            objIM.strTitle = txtInstituteTitle.Text;
            objIM.strDescription = txtInstituteDesc.Value;
            objIM.iCategoryID = int.Parse(ddl_Category.SelectedValue.ToString());
            objIM.iSubCategoryID = int.Parse(ddl_SubCategory.SelectedValue.ToString());
            objIM.iLocationID = int.Parse(ddl_Location.SelectedValue.ToString());
            objIM.iCompanyID = int.Parse(ddl_Company.SelectedValue.ToString());
            objIM.iPostedBy = 0;

            int Year = int.Parse(ddl_Year.SelectedValue);
            int Month = int.Parse(ddl_Month.SelectedValue);
            int Day = int.Parse(ddl_Day.SelectedValue);

            DateTime dt_Date = new DateTime(Year, Month, Day, 00, 00, 00);
            objIM.dtExpirationDate = dt_Date;

            string strResponse = objIM.fn_editJob();

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

            dv_Jobs.ChangeMode(DetailsViewMode.ReadOnly);
            objIM.iID = int.Parse(grd_Jobs.SelectedDataKey.Value.ToString());
            dv_Jobs.DataSource = objIM.fn_get_JobByID();
            dv_Jobs.DataBind();

            JobClass  objJobs = new JobClass ();
            grd_Jobs.DataSource = objJobs.fn_get_JobList();
            grd_Jobs.DataBind();
            
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void dv_Jobs_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Jobs.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Jobs.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Jobs.ChangeMode(e.NewMode);
                if (grd_Jobs.SelectedIndex >= 0)
                {
                    JobClass  objIM = new JobClass ();
                    objIM.iID = int.Parse(grd_Jobs.SelectedDataKey.Value.ToString());
                    dv_Jobs.DataSource = objIM.fn_get_JobByID();
                    dv_Jobs.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + " " + ex.StackTrace);
        }
    }  
   
    protected void dv_Jobs_DataBound(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddl_Category = (DropDownList)dv_Jobs.FindControl("ddl_Category");
            DropDownList ddl_SubCategory = (DropDownList)dv_Jobs.FindControl("ddl_SubCategory");
            DropDownList ddl_Location = (DropDownList)dv_Jobs.FindControl("ddl_Location");
            DropDownList ddl_Company = (DropDownList)dv_Jobs.FindControl("ddl_Company");

            DropDownList ddl_Day = (DropDownList)dv_Jobs.FindControl("ddl_Day");
            DropDownList ddl_Month = (DropDownList)dv_Jobs.FindControl("ddl_Month");
            DropDownList ddl_Year = (DropDownList)dv_Jobs.FindControl("ddl_Year");

            Label lblCategory = (Label)dv_Jobs.FindControl("lblCategory");
            Label lblSubCategory = (Label)dv_Jobs.FindControl("lblSubCategory");
            Label lblLocation = (Label)dv_Jobs.FindControl("lblLocation");
            Label lblCompany = (Label)dv_Jobs.FindControl("lblCompany");

            JobClass  objCM = new JobClass ();

            if (dv_Jobs.CurrentMode == DetailsViewMode.Insert)
            {
                fn_BindCategoryDropDownList();
                fn_BindCompanyDropDownList();
                fn_BindLocationDropDownList();
                fn_BindSubCategoryDropDownList();

                fn_BindDaysDropDownList();
                fn_BindMonthDropDownList();
                fn_BindYearDropDownList();
            }

            if (dv_Jobs.CurrentMode == DetailsViewMode.Edit)
            {
                objCM.iID = int.Parse(grd_Jobs.SelectedDataKey.Value.ToString());
                CoreWebList<JobClass > objList = objCM.fn_get_JobByID();
                if (objList.Count > 0)
                {
                    fn_BindCategoryDropDownList();
                    fn_BindCompanyDropDownList();
                    fn_BindLocationDropDownList();

                    fn_BindDaysDropDownList();
                    fn_BindMonthDropDownList();
                    fn_BindYearDropDownList();

                    string str = objList[0].dtExpirationDate.ToShortDateString();

                    string[] strDate = str.Split('/');
                    int Month = int.Parse(strDate[0]);
                    int Day = int.Parse(strDate[1]);
                    int Year = int.Parse(strDate[2]);

                    ddl_Day.SelectedValue = Day.ToString();
                    ddl_Month.SelectedValue = Month.ToString();
                    ddl_Year.SelectedValue = Year.ToString();

                    JobSubCategoryClass objSubCategory = new JobSubCategoryClass();
                    objSubCategory.iCategoryID = int.Parse(objList[0].iCategoryID.ToString());
                    ddl_SubCategory.DataSource = objSubCategory.fn_GetJobSubCategoryByCategoryID();
                    ddl_SubCategory.DataTextField = "strJobSubCategoryName";
                    ddl_SubCategory.DataValueField = "iID";
                    ddl_SubCategory.DataBind();
                    ddl_SubCategory.Items.Insert(0, new ListItem("Select", "0"));

                    ddl_Category.SelectedValue = objList[0].iCategoryID.ToString();
                    ddl_Company.SelectedValue = objList[0].iCompanyID.ToString();
                    ddl_Location.SelectedValue = objList[0].iLocationID.ToString();
                    ddl_SubCategory.SelectedValue = objList[0].iSubCategoryID.ToString();
                    
                }
            }

            if (dv_Jobs.CurrentMode == DetailsViewMode.ReadOnly)
            {
                objCM.iID = int.Parse(grd_Jobs.SelectedDataKey.Value.ToString());
                CoreWebList<JobClass > objCMList = objCM.fn_get_JobByID();
                if (objCMList.Count > 0)
                {
                    JobCategoryClass objCategory = new JobCategoryClass();
                    objCategory.iID = objCMList[0].iCategoryID;
                    CoreWebList<JobCategoryClass> objCategoryList = objCategory.fn_GetJobCategoryByID();
                    if (objCategoryList.Count > 0)
                    {
                        lblCategory.Text = objCategoryList[0].strJobCategoryName;
                    }

                    JobSubCategoryClass objSubCategory = new JobSubCategoryClass();
                    objSubCategory.iID = objCMList[0].iSubCategoryID;
                    CoreWebList<JobSubCategoryClass> objSubCategoryList = objSubCategory.fn_GetJobSubCategoryByID();
                    if (objSubCategoryList.Count > 0)
                    {
                        lblSubCategory.Text = objSubCategoryList[0].strJobSubCategoryName;
                    }

                    CityMasterClass objCity = new CityMasterClass();
                    objCity.iID = objCMList[0].iLocationID;
                    CoreWebList<CityMasterClass> objCityList = objCity.fn_getCityListByID();
                    if (objCityList.Count > 0)
                    {
                        lblLocation.Text = objCityList[0].strCityName;
                    }

                    JobCompanyClass objJobCompany = new JobCompanyClass();
                    objJobCompany.iID = objCMList[0].iCompanyID;
                    CoreWebList<JobCompanyClass> objJobCompanyList = objJobCompany.fn_GetJobCompanyByID();
                    if (objJobCompanyList.Count > 0)
                    {
                        lblLocation.Text = objJobCompanyList[0].strJobCompanyName;
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

    protected void grd_Jobs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                JobClass objIM = new JobClass();

                HiddenField hfField = (HiddenField)e.Row.FindControl("hfField");
                Label lbl_Category = (Label)e.Row.FindControl("lbl_Category");
                Label lblLocation = (Label)e.Row.FindControl("lblLocation");
                Label lblCompany = (Label)e.Row.FindControl("lblCompany");

                HiddenField hfjob = (HiddenField)e.Row.FindControl("hfjob");
                ImageButton btnEnable = (ImageButton)e.Row.FindControl("btnEnable");

                HiddenField hfGovernment = (HiddenField)e.Row.FindControl("hfGovernment");
                ImageButton btnGovernment = (ImageButton)e.Row.FindControl("btnGovernment");

                if (hfjob != null)
                {
                    if (bool.Parse(hfjob.Value) == true)
                    {
                        btnEnable.ImageUrl = "~/admin/images/Tick.gif";
                    }
                    else
                    {
                        btnEnable.ImageUrl = "~/admin/images/cross.gif";
                    }
                }

                if (hfGovernment != null)
                {
                    if (bool.Parse(hfGovernment.Value) == true)
                    {
                        btnGovernment.ImageUrl = "~/admin/images/Tick.gif";
                    }
                    else
                    {
                        btnGovernment.ImageUrl = "~/admin/images/cross.gif";
                    }
                }

                JobClass objJob = new JobClass();
                objJob.iID = int.Parse(hfField.Value.ToString());
                CoreWebList<JobClass> objJobList = objJob.fn_get_JobByID();
                if (objJobList.Count > 0)
                {
                    JobCategoryClass objCategory = new JobCategoryClass();
                    objCategory.iID = objJobList[0].iCategoryID;
                    CoreWebList<JobCategoryClass> objCategoryList = objCategory.fn_GetJobCategoryByID();
                    if (objCategoryList.Count > 0)
                    {
                        lbl_Category.Text = objCategoryList[0].strJobCategoryName;
                    }


                    CityMasterClass objCity = new CityMasterClass();
                    objCity.iID = objJobList[0].iLocationID;
                    CoreWebList<CityMasterClass> objCityList = objCity.fn_getCityListByID();
                    if (objCityList.Count > 0)
                    {
                        lblLocation.Text = objCityList[0].strCityName;
                    }


                    JobCompanyClass objCompany = new JobCompanyClass();
                    objCompany.iID = objJobList[0].iCompanyID;
                    CoreWebList<JobCompanyClass> objCompanyList = objCompany.fn_GetJobCompanyByID();
                    if (objCompanyList.Count > 0)
                    {
                        lblCompany.Text = objCompanyList[0].strJobCompanyName;
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }


    protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddl_Category = (DropDownList)dv_Jobs.FindControl("ddl_Category");
            DropDownList ddl_SubCategory = (DropDownList)dv_Jobs.FindControl("ddl_SubCategory");

            ddl_SubCategory.Items.Clear();
            JobSubCategoryClass objSubCategory = new JobSubCategoryClass();
            objSubCategory.iCategoryID = int.Parse(ddl_Category.SelectedValue.ToString());
            
            ddl_SubCategory.DataSource = objSubCategory.fn_GetJobSubCategoryByCategoryID();
            ddl_SubCategory.DataTextField = "strJobSubCategoryName";
            ddl_SubCategory.DataValueField = "iID";
            ddl_SubCategory.DataBind();
            ddl_SubCategory.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }


    protected void fn_BindCatDDL()
    {
        try
        {
            JobCategoryClass objCM = new JobCategoryClass();
            ddl_Cat.DataSource = objCM.fn_GetJobCategoryList();
            ddl_Cat.DataTextField = "strJobCategoryName";
            ddl_Cat.DataValueField = "iID";
            ddl_Cat.DataBind();
            ddl_Cat.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
   
    protected void fn_BindLocDDL()
    {
        try
        { 
            CityMasterClass objCM = new CityMasterClass();
            ddl_Loc.DataSource = objCM.fn_getCityList();
            ddl_Loc.DataTextField = "strCityName";
            ddl_Loc.DataValueField = "iID";
            ddl_Loc.DataBind();
            ddl_Loc.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void fn_BindCompDDL()
    {
        try
        {
            JobCompanyClass objCM = new JobCompanyClass();
            ddl_Comp.DataSource = objCM.fn_GetJobCompanyList();
            ddl_Comp.DataTextField = "strJobCompanyName";
            ddl_Comp.DataValueField = "iID";
            ddl_Comp.DataBind();
            ddl_Comp.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strQuery = "SELECT * from edu_Jobs";

        bool Status = false;

        if (txtJob.Text != "")
        {
            strQuery += " WHERE Job_title like '%" + txtJob.Text.Trim() + "%'";
            Status = true;
        }

        if (ddl_Cat.SelectedItem.Text != "All")
        {
            if (Status == true)
            {
                strQuery += " AND Job_CategoryID = " + ddl_Cat.SelectedValue;
            }
            else
            {
                strQuery += " WHERE Job_CategoryID = " + ddl_Cat.SelectedValue;
                Status = true;
            }
        }

        if (ddl_Loc.SelectedItem.Text != "All")
        {
            if (Status == true)
            {
                strQuery += " AND Job_LocationID = " + ddl_Loc.SelectedValue;
            }
            else
            {
                strQuery += " WHERE Job_LocationID = " + ddl_Loc.SelectedValue;
                Status = true;
            }
        }

        if (ddl_Comp.SelectedItem.Text != "All")
        {
            if (Status == true)
            {
                strQuery += " AND Job_CompanyID = " + ddl_Comp.SelectedValue;
            }
            else
            {
                strQuery += " WHERE Job_CompanyID = " + ddl_Comp.SelectedValue;
            }
        }

        JobClass objJob = new JobClass();
        chJobList = objJob.fn_get_JobByQuery(strQuery);
        if (chJobList.Count > 0)
        {
            grd_Jobs.DataSource = chJobList;
        }
        else
        {
            grd_Jobs.DataSource = null;
        }
        grd_Jobs.DataBind();

    }

    protected void grd_Jobs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string strResponse = "";

            if (e.CommandName == "job")
            {
                int iId = Convert.ToInt32(e.CommandArgument);
                JobClass objJobs = new JobClass();
                ImageButton btnEnable = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnEnable.Parent.Parent;
                objJobs.iID = iId;
                CoreWebList<JobClass> objJobsList = objJobs.fn_get_JobByID();
                if (objJobsList.Count > 0)
                {
                    if (objJobsList[0].bActive == true)
                    {
                        btnEnable.ImageUrl = "~/admin/images/cross.gif";
                        objJobs.bActive = false;
                    }
                    else
                    {
                        btnEnable.ImageUrl = "~/admin/images/Tick.gif";
                        objJobs.bActive = true;
                    }

                    strResponse = objJobs.fn_ChangeJobStatus();
                }
            }

            if (e.CommandName == "Government")
            {
                int iId = Convert.ToInt32(e.CommandArgument);
                JobClass objJobs = new JobClass();
                ImageButton btnGovernment = (ImageButton)e.CommandSource;
                GridViewRow objSelectedRow = (GridViewRow)btnGovernment.Parent.Parent;
                objJobs.iID = iId;
                CoreWebList<JobClass> objJobsList = objJobs.fn_get_JobByID();
                if (objJobsList.Count > 0)
                {
                    if (objJobsList[0].bGovernment == true)
                    {
                        btnGovernment.ImageUrl = "~/admin/images/cross.gif";
                        objJobs.bGovernment = false;
                    }
                    else
                    {
                        btnGovernment.ImageUrl = "~/admin/images/Tick.gif";
                        objJobs.bGovernment = true;
                    }

                    strResponse = objJobs.fn_ChangeGovernmentStatus();
                }
            }

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
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void fn_BindDaysDropDownList()
    {
        try
        {
            DropDownList ddl_Day = (DropDownList)dv_Jobs.FindControl("ddl_Day");
            if (ddl_Day != null)
            {
                ListItem lst;
                for (int i = 1; i <= 31; i++)
                {
                    lst = new ListItem();
                    lst.Text = i.ToString();
                    lst.Value = i.ToString();
                    ddl_Day.Items.Add(lst);
                }
                ddl_Day.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void fn_BindMonthDropDownList()
    {
        try
        {
            DropDownList ddl_Month = (DropDownList)dv_Jobs.FindControl("ddl_Month");
            if (ddl_Month != null)
            {
                ListItem lst;
                int iMonth = 0;
                foreach (string item in DateTimeFormatInfo.CurrentInfo.MonthNames)
                {
                    iMonth = iMonth + 1;
                    lst = new ListItem();
                    lst.Text = item;
                    lst.Value = iMonth.ToString();
                    ddl_Month.Items.Add(lst);
                }
                ddl_Month.Items.Insert(0, new ListItem("Select", "0"));

                lst = new ListItem();
                lst.Text = "";
                lst.Value = "13";

                ddl_Month.Items.Remove(lst);
            }

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void fn_BindYearDropDownList()
    {
        try
        {
            DropDownList ddl_Year = (DropDownList)dv_Jobs.FindControl("ddl_Year");
            if (ddl_Year != null)
            {
                ListItem lst;
                for (int i = 2012; i <= 2020; i++)
                {
                    lst = new ListItem();
                    lst.Text = i.ToString();
                    lst.Value = i.ToString();
                    ddl_Year.Items.Add(lst);
                }
                ddl_Year.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
}
