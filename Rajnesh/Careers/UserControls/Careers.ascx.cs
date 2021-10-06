using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class Careers_UserControls_Careers : UserControl
{
    public string FileName { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                var objJobs = new JobGeneratorClass {strFileName = Path.GetFileName(FileName)};
                CoreWebList<JobGeneratorClass> objJobsList = objJobs.fn_GetJobByFileName();
                if (objJobsList.Count > 0)
                {
                    fn_BindRating();
                    // fn_BindLinks();

                    /*********/
                    hlTitle.Text = objJobsList[0].strPageTitle;
                    //ltl_header2.Text = "<h2>" + objJobsList[0].strH2 + "</h2>";
                    ltl_Updated.Text = objJobsList[0].dtCreatedDate.ToLongDateString() + " " +
                                       objJobsList[0].dtCreatedDate.ToLongTimeString();
                    ltDescription.Text = objJobsList[0].strH3;

                    /*********/

                    string strIDs = objJobsList[0].strIdentities;

                    if (strIDs != "")
                    {
                        string strQuery = "SELECT * FROM edu_Jobs WHERE Job_id IN(" + strIDs + ") ORDER BY Job_PostedOn DESC";
                        ViewState["Query"] = strQuery;

                        var objJob = new JobClass();
                        CoreWebList<JobClass> objJobList = objJob.fn_get_JobListByQuery(strQuery);
                        grd_Jobs.DataSource = objJobList.Count > 0 ? objJobList : null;
                        grd_Jobs.DataBind();
                    }

                    var objJobCompany = new JobCompanyClass {iID = objJobsList[0].iComapny};
                    CoreWebList<JobCompanyClass> objJobCompanyList = objJobCompany.fn_GetJobCompanyByID();
                    if (objJobCompanyList.Count > 0)
                    {
                        if (objJobCompanyList[0].strJobCompanyName != "")
                        {
                            ltl_CompanyTitle.Text = objJobCompanyList[0].strJobCompanyName;
                        }
                        else
                        {
                            td_CompanyName.Visible = false;
                        }

                        if (objJobCompanyList[0].strContactDetails != "")
                        {
                            ltl_CompanyAddrs.Text = objJobCompanyList[0].strContactDetails.Replace("<p>", "").Replace("</p>", "").Replace("<br>", "").Replace("<br />", "").Replace("<br/>", "");
                        }
                        else
                        {
                            td_Address.Visible = false;
                        }

                        if (objJobCompanyList[0].strLogo != "")
                        {
                            img_Logos.Src = "/Logos/" + objJobCompanyList[0].strLogo;
                            img_Logos.Alt = objJobCompanyList[0].strJobCompanyName + " logo";
                        }
                        else
                        {
                            td_Logo.Visible = false;
                        }

                        var objJobCategory = new JobCategoryClass {iID = objJobCompanyList[0].iCategoryID};
                        CoreWebList<JobCategoryClass> objJobCategorylist = objJobCategory.fn_GetJobCategoryByID();
                        if (objJobCategorylist.Count > 0)
                        {
                            ltl_CompanyIndustry.Text = objJobCategorylist[0].strJobCategoryName;
                        }
                        else
                        {
                            td_Industry.Visible = false;
                        }
                    }
                    else
                    {
                        tr_Company.Visible = false;
                    }
                }

                //fn_BindCategory();
                //fn_BindCity();
                //fn_BindCompany();
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
            var objJob = new JobClass();
            grd_Jobs.PageIndex = e.NewPageIndex;
            grd_Jobs.DataSource = objJob.fn_get_JobListByQuery(ViewState["Query"].ToString());
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
                var hfCompanyId = (HiddenField) e.Row.FindControl("hfCompanyID");
                var hfCityId = (HiddenField) e.Row.FindControl("hfCityId");
                var hfCategory = (HiddenField) e.Row.FindControl("hfCategory");
                var hfSubCategory = (HiddenField) e.Row.FindControl("hfSubCategory");

                var lblCompany = (Label) e.Row.FindControl("lblCompany");
                var lblCategory = (Label) e.Row.FindControl("lblCategory");
                var lblSubCategory = (Label) e.Row.FindControl("lblSubCategory");

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

    protected void rt_Rate_Changed(object sender, EventArgs e)
    {
        try
        {
            fn_StarRating();
            Response.Redirect(Request.Url.ToString());
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_StarRating()
    {
        try
        {
            var objRate = new RatingClass {strType = Path.GetFileName(Request.PhysicalPath), iTypeID = 1};
            CoreWebList<RatingClass> objRateList = objRate.fn_getRatingByTypeID();
            if (objRateList.Count > 0)
            {
                objRate.iID = objRateList[0].iID;
                objRate.fCount = rt_Rate.CurrentRating + objRateList[0].fCount;
                objRate.iClicks = objRateList[0].iClicks + 1;

                objRate.fn_EditRating();
            }
            else
            {
                objRate.fCount = rt_Rate.CurrentRating;
                objRate.iClicks = 1;

                objRate.fn_SaveRating();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindRating()
    {
        try
        {
            var objRate = new RatingClass {strType = Path.GetFileName(Request.PhysicalPath), iTypeID = 1};
            CoreWebList<RatingClass> objRateList = objRate.fn_getRatingByTypeID();
            if (objRateList.Count > 0)
            {
                double dRate = Math.Round(objRateList[0].fCount/objRateList[0].iClicks);
                rt_Rate.CurrentRating = (int)dRate;
                ltl_RatingBox.Text = "(<span itemprop=\"rating\" itemscope itemtype=\"http://data-vocabulary.org/Rating\"><span itemprop=\"average\">" + dRate + "</span> out of <span itemprop=\"best\">5</span> </span>based on <span itemprop=\"count\">" + objRateList[0].iClicks + "</span> Ratings)";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindLinks()
    {
        try
        {
            var objLinks = new LinkClass {strTargetUrl = Request.Url.ToString()};
            CoreWebList<LinkClass> objLinkList = objLinks.fn_getLinkByTargetUrl();
            if (objLinkList.Count > 0)
            {
                dl_JobLinks.DataSource = objLinkList;
                dl_JobLinks.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
    
    #region Search Functionality

    //protected void fn_BindCategory()
    //{
    //    try
    //    {
    //        var objCm = new JobCategoryClass();
    //        ddlCategory.DataSource = objCm.fn_GetJobCategoryList();
    //        ddlCategory.DataTextField = "strJobCategoryName";
    //        ddlCategory.DataValueField = "iID";
    //        ddlCategory.DataBind();
    //        ddlCategory.Items.Insert(0, new ListItem("All", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write("ERROR : " + ex.Message);
    //    }
    //}

    //protected void fn_BindCity()
    //{
    //    try
    //    {
    //        var objCm = new CityMasterClass();
    //        ddlCity.DataSource = objCm.fn_getCityList();
    //        ddlCity.DataTextField = "strCityName";
    //        ddlCity.DataValueField = "iID";
    //        ddlCity.DataBind();
    //        ddlCity.Items.Insert(0, new ListItem("All", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write("ERROR : " + ex.Message);
    //    }
    //}

    //protected void fn_BindCompany()
    //{
    //    try
    //    {
    //        var objCm = new JobCompanyClass();
    //        ddlCompany.DataSource = objCm.fn_GetJobCompanyList();
    //        ddlCompany.DataTextField = "strJobCompanyName";
    //        ddlCompany.DataValueField = "iID";
    //        ddlCompany.DataBind();
    //        ddlCompany.Items.Insert(0, new ListItem("All", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write("ERROR : " + ex.Message);
    //    }
    //}

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string strCategory =
    //            ddlCategory.SelectedItem.Text.Replace(" ", "-")
    //                .Replace("&", "-")
    //                .Replace(":", "-")
    //                .Replace("?", "-")
    //                .Replace(",", "-")
    //                .Replace("%", "-")
    //                .Replace("/", "-")
    //                .Replace("---", "-")
    //                .Replace("--", "-");
    //        int iCategory = int.Parse(ddlCategory.SelectedValue);

    //        string strCompany =
    //            ddlCompany.SelectedItem.Text.Replace(" ", "-")
    //                .Replace("&", "-")
    //                .Replace(":", "-")
    //                .Replace("?", "-")
    //                .Replace(",", "-")
    //                .Replace("%", "-")
    //                .Replace("/", "-")
    //                .Replace("---", "-")
    //                .Replace("--", "-");
    //        int iCompany = int.Parse(ddlCompany.SelectedValue);

    //        string strLocation =
    //            ddlCity.SelectedItem.Text.Replace(" ", "-")
    //                .Replace("&", "-")
    //                .Replace(":", "-")
    //                .Replace("?", "-")
    //                .Replace(",", "-")
    //                .Replace("%", "-")
    //                .Replace("/", "-")
    //                .Replace("---", "-")
    //                .Replace("--", "-");
    //        int iLocation = int.Parse(ddlCity.SelectedValue);

    //        Response.Redirect("Job-Search.aspx?Category=" + strCategory + "&Company=" +
    //                          strCompany + "&City=" + strLocation + "&Ca=" + iCategory + "&Co=" + iCompany + "&Lo=" +
    //                          iLocation);
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write("ERROR : " + ex.Message);
    //    }
    //}

    #endregion
}