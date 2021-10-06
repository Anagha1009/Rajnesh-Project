using System;
using System.Web.UI.HtmlControls;
using System.Text;
using yo_lib;

public partial class Jobs_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString["JobID"] != null)
        //{
        //    Comment1.iType = int.Parse(Request.QueryString["JobID"]);
        //    Comment1.strUrl = System.IO.Path.GetFileName(Request.PhysicalPath);
        //    Comment1.strType = "Jobs";
        //}

        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["JobID"] != null)
                {
                    var objJobs = new JobClass {iID = int.Parse(Request.QueryString["JobID"])};
                    CoreWebList<JobClass> objJobsList = objJobs.fn_get_JobByID();
                    if (objJobsList.Count > 0)
                    {
                        lblTitle.Text = objJobsList[0].strTitle;
                        lblDescription.Text = objJobsList[0].strDescription;
                        int iCompanyId = objJobsList[0].iCompanyID;

                        var objCategory = new JobCategoryClass {iID = objJobsList[0].iCategoryID};
                        CoreWebList<JobCategoryClass> objCategoryList = objCategory.fn_GetJobCategoryByID();
                        if (objCategoryList.Count > 0)
                        {
                            lblCategory.Text = objCategoryList[0].strJobCategoryName;

                            int iCategoryId = objCategoryList[0].iID;
                            ltl_CategoryTitle.Text = "Similar " + objCategoryList[0].strJobCategoryName + " Jobs";

                            var objCategoryJobs = new JobClass {iCategoryID = iCategoryId};
                            CoreWebList<JobClass> objCategoryJobsList = objCategoryJobs.fn_getRandomJobByCategoryID();
                            if (objCategoryJobsList.Count > 0)
                            {
                                rpt_Jobs.DataSource = objCategoryJobsList;
                                rpt_Jobs.DataBind();
                            }

                            var objCompanyJobs = new JobClass {iCompanyID = iCompanyId};
                            CoreWebList<JobClass> objCompanyJobsList = objCompanyJobs.fn_getRandomJobByCompanyID();
                            if (objCompanyJobsList.Count > 0)
                            {
                                rpt_CompanyJobs.DataSource = objCompanyJobsList;
                                rpt_CompanyJobs.DataBind();
                            }
                        }

                        if (objJobsList[0].iSubCategoryID != 0)
                        {
                            var objSubCategory = new JobSubCategoryClass {iID = objJobsList[0].iSubCategoryID};
                            CoreWebList<JobSubCategoryClass> objSubCategoryList = objSubCategory.fn_GetJobSubCategoryByID();
                            if (objSubCategoryList.Count > 0)
                            {
                                lblSubCategory.Text = objSubCategoryList[0].strJobSubCategoryName;

                                string strUrl = "Job-Search.aspx?Category=" + objCategoryList[0].strJobCategoryName.Replace("&", "-").Replace("?", "-").Replace(" ", "-").Replace(",", "-").Replace("---", "-").Replace("--", "-") + "&CategoryID=" + objCategoryList[0].iID;

                                if ((objJobsList[0].dtExpirationDate - DateTime.Now).TotalDays <= 0)
                                    ltl_CategoryJob.Text =
                                        "This Job has Expired! Click Here to View Other <blink><a href='" + strUrl +
                                        "' class='jobs'>" + objCategoryList[0].strJobCategoryName + " Jobs</a></blink>";
                                else
                                    tr_JobAlerts.Visible = false;

                            }
                        }
                        else
                        {
                            lblSubCategory.Text = "General(All)";
                        }

                        var objCity = new CityMasterClass {iID = objJobsList[0].iLocationID};
                        CoreWebList<CityMasterClass> objCityList = objCity.fn_getCityListByID();
                        if (objCityList.Count > 0)
                        {
                            lblLoc.Text = objCityList[0].strCityName;
                        }

                        lblPostedOn.Text = objJobsList[0].dtPostedDate.ToLongDateString();
                        lblExpirationDate.Text = objJobsList[0].dtExpirationDate.ToLongDateString();

                        if (objJobsList[0].strSubCategory.ToLower() == "placement papers")
                        {
                            //td_ex1.Visible = false;
                            //td_ex2.Visible = false;
                            ////  td_ex3.Visible = false;get_Item
                            //td_ex4.Visible = false;


                            tr_JobAlerts.Visible = false;
                        }
                        else
                        {
                            DateTime dt1 = objJobsList[0].dtExpirationDate;
                            DateTime dt2 = DateTime.Now;

                            int iResult = DateTime.Compare(dt1, dt2);

                            if (iResult < 0)
                            {


                                #region "Fade in to Alerts"
                                var sb = new StringBuilder();
                                sb.Append("$('#Job_alerts').delay(2000).fadeIn('slow');");
                                ClientScript.RegisterStartupScript(GetType(), "FadeIn", sb.ToString(), true);
                                #endregion
                            }
                        }

                        if (objJobsList[0].iPostedBy == 0)
                        {
                            var objCompany = new JobCompanyClass {iID = objJobsList[0].iCompanyID};
                            CoreWebList<JobCompanyClass> objCompanyList = objCompany.fn_GetJobCompanyByID();
                            if (objCompanyList.Count > 0)
                            {
                                //ltDescription.Text = objCompanyList[0].strJobCompanyDesc;
                                lblCompany.Text = objCompanyList[0].strJobCompanyName;
                                td_Contact.InnerHtml = objCompanyList[0].strContactDetails;
                                ltl_CompanyTitle.Text = "Other Jobs by " + objCompanyList[0].strJobCompanyName;
                            }
                        }
                        else
                        {
                            var objEmp = new EmployerClass {iID = objJobsList[0].iPostedBy};
                            CoreWebList<EmployerClass> objEmpList = objEmp.fn_getEmployerByID();
                            if (objEmpList.Count > 0)
                            {
                                lblCompany.Text = objEmpList[0].strCompany;
                                //ltDescription.Text = objEmpList[0].strCompanyDetails;
                                td_Contact.InnerHtml = objEmpList[0].strWebsite + "<br/>" + objEmpList[0].strCity + "<br/>" + objEmpList[0].strCountry;
                            }
                        }
                    }

                    lblContactDetails.Text = "Contact Details/ Address of " + lblCompany.Text;

                    /*********/

                    string strMetaTitle = objJobsList[0].strTitle + " Job, Careers, Vacancies, Openings, Jobs in " + lblCompany.Text;
                    string strMetaDesc = "Get details on " + objJobsList[0].strTitle + " Job, Careers 2016, Vacancies, Openings and Jobs in " + lblCompany.Text;
                    string strMetaKeys = objJobsList[0].strTitle + " Job, Careers, Vacancies, Openings, Jobs in " + lblCompany.Text;

                    meta_title.Attributes.Add("content", strMetaTitle);
                    meta_Description.Attributes.Add("content", strMetaDesc);
                    meta_Keywords.Attributes.Add("content", strMetaKeys);

                    /*********/
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + ex.StackTrace);
            }
        }
    }
}

                        
