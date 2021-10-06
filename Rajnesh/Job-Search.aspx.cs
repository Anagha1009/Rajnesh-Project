using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class Category_Jobs : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["Category"] != null && Request.QueryString["CategoryID"] != null)
                {
                    int iCategoryID = int.Parse(Request.QueryString["CategoryID"]);

                    var objCategory = new JobCategoryClass();
                    objCategory.iID = iCategoryID;
                    CoreWebList<JobCategoryClass> objCategoryList = objCategory.fn_GetJobCategoryByID();
                    if (objCategoryList.Count > 0)
                    {
                        var objJob = new JobClass();
                        objJob.iCategoryID = iCategoryID;
                        CoreWebList<JobClass> objJobList = objJob.fn_getJobByCategoryID();
                        if (objJobList.Count > 0)
                        {
                            var dtJobs = (DataTable) objJobList;
                            ViewState["dt_Jobs"] = dtJobs;
                            grd_Jobs.DataSource = objJobList;
                        }
                        else
                        {
                            grd_Jobs.DataSource = null;
                        }
                        grd_Jobs.DataBind();

                        string strMetaTitle = objCategoryList[0].strJobCategoryName +
                                              " Jobs in India, Latest Vacancies for Freshers 2013";
                        string strMetaKeys = objCategoryList[0].strJobCategoryName + " Jobs in India";
                        string strMetaDesc = "Get List of Latest " + objCategoryList[0].strJobCategoryName +
                                             " Jobs in India for Freshers 2013. View Openings and Vacancies in " +
                                             objCategoryList[0].strJobCategoryName + " for Entry Level and Experienced.";

                        ltl_Title.Text = objCategoryList[0].strJobCategoryName + " Jobs in India";

                        PageTitle.Attributes.Add("content", strMetaTitle);
                        MetaKeywords.Attributes.Add("content", strMetaKeys);
                        MetaDesc.Attributes.Add("content", strMetaDesc);
                    }
                }
                else
                {
                    Response.Redirect(VirtualPathUtility.ToAbsolute("~/Jobs-in-India-for-Freshers.aspx"));
                }
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
            var dtJobs = (DataTable) ViewState["dt_Jobs"];
            grd_Jobs.PageIndex = e.NewPageIndex;
            grd_Jobs.DataSource = dtJobs;
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
                var hfCompanyID = (HiddenField) e.Row.FindControl("hfCompanyID");
                var hfCityId = (HiddenField) e.Row.FindControl("hfCityId");
                var lblCompany = (Label) e.Row.FindControl("lblCompany");

                var objCompany = new JobCompanyClass();
                objCompany.iID = int.Parse(hfCompanyID.Value);
                CoreWebList<JobCompanyClass> objCompanyList = objCompany.fn_GetJobCompanyByID();
                if (objCompanyList.Count > 0)
                {
                    lblCompany.Text = objCompanyList[0].strJobCompanyName;
                }


                var objCity = new CityMasterClass();
                objCity.iID = int.Parse(hfCityId.Value);
                CoreWebList<CityMasterClass> objCityList = objCity.fn_getCityListByID();
                if (objCityList.Count > 0)
                {
                    lblCompany.Text += ", " + objCityList[0].strCityName;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}