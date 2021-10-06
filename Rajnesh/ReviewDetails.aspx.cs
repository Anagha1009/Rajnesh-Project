using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Collections;


public partial class Review_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                if (RouteData.Values["InstituteType"] != null && RouteData.Values["Institute"] != null && RouteData.Values["Review"] != null && RouteData.Values["ReviewID"] != null)
                {
                    int iReviewID = int.Parse(RouteData.Values["ReviewID"].ToString());
                    fn_BindDetails(iReviewID);
                    fn_BindReviewFactors();

                    string strPageUrl = "";
                    string strPageTitle = "";

                    string strInstituteType = RouteData.Values["InstituteType"].ToString();
                    
                    if (strInstituteType == "Colleges")
                    {
                        strPageUrl = VirtualPathUtility.ToAbsolute("~/Colleges-in-India.aspx");
                        strPageTitle = "Colleges in India";
                    }

                    else if (strInstituteType == "Universities")
                    {
                        strPageUrl = VirtualPathUtility.ToAbsolute("~/Indian-Universities.aspx");
                        strPageTitle = "Universities in India";
                    }

                    else if (strInstituteType == "Schools")
                    {
                        strPageUrl = VirtualPathUtility.ToAbsolute("~/Schools-in-India.aspx");
                        strPageTitle = "Schools in India";
                    }

                    else if (strInstituteType == "University")
                    {
                        strPageUrl = VirtualPathUtility.ToAbsolute("~/Universities.aspx");
                        strPageTitle = "Distance Universities";
                    }

                    else if (strInstituteType == "Distance-Colleges")
                    {
                        strPageUrl = VirtualPathUtility.ToAbsolute("~/Distance-Colleges.aspx");
                        strPageTitle = "Distance Colleges";
                    }

                    string strUrl = VirtualPathUtility.ToAbsolute("~/" + RouteData.Values["InstituteType"].ToString() + "/" + RouteData.Values["Institute"].ToString());
                    string strReviewUrl = VirtualPathUtility.ToAbsolute("~/" + RouteData.Values["InstituteType"].ToString() + "/" + RouteData.Values["Institute"].ToString() + "/Reviews");
                    Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                    ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a>&nbsp;>&nbsp;<a href='" + strPageUrl + "'>" + strPageTitle + "</a>&nbsp;>&nbsp;<a href='" + strUrl + "'>" + RouteData.Values["Institute"].ToString().Replace("-", " ") + "</a>&nbsp;>&nbsp;<a href='" + strReviewUrl + "'>" + RouteData.Values["Institute"].ToString().Replace("-", " ") + " Reviews</a>&nbsp;>&nbsp;" + RouteData.Values["Review"].ToString().Replace("-"," ");
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindDetails(int iReviewID)
    {
        try
        {
            EduReviewClass objEduReview = new EduReviewClass();
            objEduReview.iID = iReviewID;
            CoreWebList<EduReviewClass> objEduReviewList = objEduReview.fn_getEduReviewByID();
            if (objEduReviewList.Count > 0)
            {
                int InstitutionID = objEduReviewList[0].iInstitutionID;
                string strInstitute = "";
                string strInstitutionType = "";
                hf_ReviewID.Value = iReviewID.ToString();
                
                ltl_Title.Text = objEduReviewList[0].strTitle;
                ltl_Details.Text = objEduReviewList[0].strDetails;

                ltl_PostedBy.Text = "<b>Posted By : </b>" + objEduReviewList[0].strName + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Posted On : </b>" + objEduReviewList[0].dtDate.ToLongDateString();

                ltl_metaTitle.Text = "<title>" + objEduReviewList[0].strTitle + "</title>";
                ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + objEduReviewList[0].strTitle + "\" />";
                ltl_metaKeys.Text = "<meta name=\"Keywords\" content=\"" + objEduReviewList[0].strTitle + "\" />";

                strInstitutionType = objEduReviewList[0].strInstitutionType;

                if (strInstitutionType == "Institute")
                {
                    InstituteClass objInstitute = new InstituteClass();
                    objInstitute.iID = InstitutionID;
                    CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByID();
                    if (objInstituteList.Count > 0)
                    {
                        strInstitute = objInstituteList[0].strTitle;
                    }
                }

                else if (strInstitutionType == "University")
                {
                    UniversityListClass objUniversity = new UniversityListClass();
                    objUniversity.iID = InstitutionID;
                    CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_getUniversityByID();
                    if (objUniversityList.Count > 0)
                    {
                        strInstitute = objUniversityList[0].strTitle;
                    }
                }

                else if (strInstitutionType == "School")
                {
                    SchoolClass objSchool = new SchoolClass();
                    objSchool.iID = InstitutionID;
                    CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolByID();
                    if (objSchoolList.Count > 0)
                    {
                        strInstitute = objSchoolList[0].strTitle;
                    }
                }

                else if (strInstitutionType == "DistanceUniversity" || strInstitutionType == "DistanceCollege")
                {
                    DistanceLearningClass objDistance = new DistanceLearningClass();
                    objDistance.iID = InstitutionID;
                    CoreWebList<DistanceLearningClass> objDistanceList = objDistance.fn_GetDistanceLearningByID();
                    if (objDistanceList.Count > 0)
                    {
                        strInstitute = objDistanceList[0].strName;
                    }
                }

                ltl_Institute.Text = strInstitute;

            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindReviewFactors()
    {
        try
        {
            FactorHeadingClass objFactor = new FactorHeadingClass();
            CoreWebList<FactorHeadingClass> objFactorList = objFactor.fn_getFactorHeadingList();
            if (objFactorList.Count > 0)
            {
                rpt_ReviewFactors.DataSource = objFactorList;
                rpt_ReviewFactors.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void rpt_ReviewFactors_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hf_FactorID = (HiddenField)e.Item.FindControl("hf_FactorID");
                Repeater rpt_Ratings = (Repeater)e.Item.FindControl("rpt_Ratings");
                int ReviewID = int.Parse(hf_ReviewID.Value);

                if (hf_FactorID != null && rpt_Ratings != null)
                {
                    EduReviewDetailClass objReviewDetail = new EduReviewDetailClass();
                    objReviewDetail.iReviewID = ReviewID;
                    objReviewDetail.iFactorID = int.Parse(hf_FactorID.Value);
                    CoreWebList<EduReviewDetailClass> objReviewDetailList = objReviewDetail.fn_getEduReviewDetailByFactorHeadingID();
                    if (objReviewDetailList.Count > 0)
                    {
                        rpt_Ratings.DataSource = objReviewDetailList;
                        rpt_Ratings.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}
