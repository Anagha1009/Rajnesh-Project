using System;
using System.Linq;
using System.Web.UI;
using yo_lib;

public partial class Jobs_in_India : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["PaperID"] != null)
                {
                    var objPaper = new PaperClass {iID = int.Parse(Request.QueryString["PaperID"])};
                    CoreWebList<PaperClass> objPaperList = objPaper.fn_GetPaperByID();
                    if (objPaperList.Count > 0)
                    {
                        lblTitle.Text =  objPaperList[0].strTitle;
                        lblDescription.Text = objPaperList[0].strDescription;
                        lblCompany.Text = objPaperList[0].strCompany;
                        lblPostedOn.Text = objPaperList[0].dtDate.ToLongDateString();

                        var objCategory = new JobCategoryClass {iID = Convert.ToInt32(objPaperList[0].strCategory)};
                        var categoryDetails = objCategory.fn_GetJobCategoryByID();
                        if (categoryDetails.Any())
                        {
                            ltl_JobsTitle.Text = "Placement Papers Published By " + categoryDetails[0].strJobCategoryName;

                            var query = "SELECT TOP 5 * FROM edu_papers WHERE paper_category = " + objPaperList[0].strCategory;
                            CoreWebList<PaperClass> objJobsList = objPaper.fn_GetPaperByQuery(query);
                            if (objJobsList.Count > 0)
                            {
                                rpt_Jobs.DataSource = objJobsList;
                                rpt_Jobs.DataBind();
                            }
                        }

                        var objCompany = new JobCompanyClass {strJobCompanyName = objPaperList[0].strCompany};
                        CoreWebList<JobCompanyClass> objCompanyList = objCompany.fn_GetJobCompanyByName();
                        if (objCompanyList.Count > 0)
                        {
                            ltDescription.Text = objCompanyList[0].strJobCompanyDesc;
                        }

                        /*********/
                        var metatitle = objPaperList[0].strTitle + " - Latest Placement Papers 2016, 2015 With Answers, Solutions, Free Downloads";
                        meta_title.Attributes.Add("content", metatitle);
                        meta_Description.Attributes.Add("content", metatitle);
                        meta_Keywords.Attributes.Add("content", metatitle);

                        /*********/
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