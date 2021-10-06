using System;
using System.Web.UI.WebControls;
using yo_lib;

public partial class Jobs_in_India : System.Web.UI.Page
{
    private CoreWebList<JobClass> ChJobList
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
        if (!IsPostBack)
        {
            try
            {
                var objJobs = new JobGeneratorClass();
                CoreWebList<JobGeneratorClass> objJobsList = objJobs.fn_Get_JobList();
                if (objJobsList.Count > 0)
                {
                    CPager.DataSource = objJobsList;
                    CPager.BindToControl = dl_Jobs;
                    CPager.SecondPageHolderId = PagerDiv.UniqueID;
                    CPager.DataBind();
                    dl_Jobs.DataSource = CPager.DataSourcePaged;
                    dl_Jobs.DataBind();
                }
                
                var objJob = new JobClass();
                ChJobList = objJob.fn_get_JobListByRandom();
                grd_Jobs.DataSource = ChJobList.Count > 0 ? ChJobList : null;
                grd_Jobs.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + ex.StackTrace);
            }
        }
    }

    protected void grd_Jobs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Jobs.PageIndex = e.NewPageIndex;
            grd_Jobs.DataSource = ChJobList;
            grd_Jobs.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void grd_Jobs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var hfCompanyId = (HiddenField)e.Row.FindControl("hfCompanyID");
                var hfCityId = (HiddenField)e.Row.FindControl("hfCityId");
                var hfCategory = (HiddenField)e.Row.FindControl("hfCategory");
                var hfSubCategory = (HiddenField)e.Row.FindControl("hfSubCategory");

                var lblCompany = (Label)e.Row.FindControl("lblCompany");
                var lblCategory = (Label)e.Row.FindControl("lblCategory");
                var lblSubCategory = (Label)e.Row.FindControl("lblSubCategory");

                var objCompany = new JobCompanyClass {iID = int.Parse(hfCompanyId.Value)};
                CoreWebList<JobCompanyClass> objCompanyList = objCompany.fn_GetJobCompanyByID();
                if (objCompanyList.Count > 0)
                {
                    lblCompany.Text = objCompanyList[0].strJobCompanyName;
                }

                var objCity = new CityMasterClass {iID = int.Parse(hfCityId.Value)};
                CoreWebList<CityMasterClass> objCityList = objCity.fn_getCityListByID();
                if (objCityList.Count > 0)
                {
                    lblCompany.Text += ", " + objCityList[0].strCityName;
                }

                var objCategory = new JobCategoryClass {iID = int.Parse(hfCategory.Value)};
                CoreWebList<JobCategoryClass> objCategoryList = objCategory.fn_GetJobCategoryByID();
                if (objCategoryList.Count > 0)
                {
                    lblCategory.Text = objCategoryList[0].strJobCategoryName;
                }

                var objSubCategory = new JobSubCategoryClass {iID = int.Parse(hfSubCategory.Value)};
                CoreWebList<JobSubCategoryClass> objSubCategoryList = objSubCategory.fn_GetJobSubCategoryByID();
                if (objSubCategoryList.Count > 0)
                {
                    lblSubCategory.Text = objSubCategoryList[0].strJobSubCategoryName;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}
