using System;
using System.Linq;
using yo_lib;

public partial class Career_files : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Page.RouteData.Values["Job"] != null)
            {
                string fileName = Page.RouteData.Values["Job"].ToString();
                Careers1.FileName = fileName;
                var obj_Query = new JobGeneratorClass();
                try
                {
                    var objJobs = new JobGeneratorClass { strFileName = fileName };
                    CoreWebList<JobGeneratorClass> objJobsList = objJobs.fn_GetJobByFileName();
                    if (objJobsList.Count > 0)
                    {
                        // meta_title.InnerHtml = objJobsList[0].strMetaTitle;
                        meta_Description.Attributes.Add("content", objJobsList[0].strMetaDescription);
                        meta_Keywords.Attributes.Add("content", objJobsList[0].strKeywords);
                    
                        var objQuery = new JobGeneratorClass { iCategory = objJobsList[0].iCategory };
                        CoreWebList<JobGeneratorClass> objQueryList = objQuery.fn_GetRandomJobByCategoryID();
                        if (objQueryList.Count > 0)
                        {
                            rpt_Query.DataSource = objQueryList;
                            rpt_Query.DataBind();
                        }

                        var objJobCompany = new JobCompanyClass { iID = objJobsList[0].iComapny };
                        CoreWebList<JobCompanyClass> objJobCompanyList = objJobCompany.fn_GetFeturedJobCompanyByID();
                        if (objJobCompanyList.Count > 0)
                        {
                            int iCompanyCategoryId = objJobCompanyList[0].iCategoryID;
                            obj_Query.iCategory = iCompanyCategoryId;
                            CoreWebList<JobGeneratorClass> obQueryList = obj_Query.fn_GetRandomJobBy_CategoryID();
                            if (obQueryList.Count > 0)
                            {
                                rpt_Other.DataSource = obQueryList;
                                rpt_Other.DataBind();

                                string strIdentity = obQueryList.Where(t => t.strIdentities != "").Aggregate("", (current, t) => current + (t.strIdentities + ","));

                                strIdentity = strIdentity.TrimEnd(',');

                                if (strIdentity != "")
                                {
                                    var oJobs = new JobClass { strIdentity = strIdentity };
                                    CoreWebList<JobClass> oJobsList = oJobs.fn_getRandomJobByIdentity();
                                    if (oJobsList.Count > 0)
                                    {
                                        rpt_Jobs.DataSource = oJobsList;
                                        rpt_Jobs.DataBind();
                                    }
                                    else
                                    {
                                        fn_BindJobs();
                                    }
                                }
                                else
                                {
                                    fn_BindJobs();
                                }
                            }
                        }
                        else
                        {
                            fn_BindJobs();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message + ex.StackTrace);
                }
            }
        }
    }

    protected void fn_BindJobs()
    {
        try
        {
            var objJobs = new JobGeneratorClass { strFileName = System.IO.Path.GetFileName(Request.PhysicalPath) };
            CoreWebList<JobGeneratorClass> objJobsList = objJobs.fn_GetJobByFileName();
            if (objJobsList.Count > 0)
            {
                int iCategoryId = objJobsList[0].iCategory;
                int iCityId = 0;

                var objCity = new CityMasterClass();
                CoreWebList<CityMasterClass> objCityList = objCity.fn_getCityByName();
                if (objCityList.Count > 0)
                {
                    iCityId = objCityList[0].iCityID;
                }

                var oJobs = new JobClass { iCategoryID = iCategoryId, iLocationID = iCityId };
                CoreWebList<JobClass> oJobsList = oJobs.fn_getRandomJobs();
                if (oJobsList.Count > 0)
                {
                    rpt_Jobs.DataSource = oJobsList;
                    rpt_Jobs.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}
