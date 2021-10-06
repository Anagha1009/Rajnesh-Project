using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;
using System.Text.RegularExpressions;

public partial class Institute_Reviews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (RouteData.Values["InstituteType"] != null && RouteData.Values["Institute"] != null)
                {
                    string strCollegeType = RouteData.Values["InstituteType"].ToString();
                    string strInstitute = "";
                    string strInstitutionType = "";
                    int InstitutionTypeId = 0;
                    string strPageUrl = "";
                    string strPageTitle = "";

                    if (strCollegeType == "Colleges")
                    {
                        InstituteClass objInstitute = new InstituteClass();
                        objInstitute.strTitle = RouteData.Values["Institute"].ToString().Replace("-", " ").Replace("_", ".");
                        CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByName();
                        if (objInstituteList.Count > 0)
                        {
                            strInstitutionType = "Institute";
                            strInstitute = objInstituteList[0].strTitle;
                            InstitutionTypeId = objInstituteList[0].iID;

                            strPageUrl = VirtualPathUtility.ToAbsolute("~/Colleges-in-India.aspx");
                            strPageTitle = "Colleges in India";
                        }
                    }

                    else if (strCollegeType == "Universities")
                    {
                        UniversityListClass objUniversity = new UniversityListClass();
                        objUniversity.strTitle = RouteData.Values["Institute"].ToString().Replace("-", " ").Replace("_", ".");
                        CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_getUniversityByTitle();
                        if (objUniversityList.Count > 0)
                        {
                            strInstitutionType = "University";
                            strInstitute = objUniversityList[0].strTitle;
                            InstitutionTypeId = objUniversityList[0].iID;

                            strPageUrl = VirtualPathUtility.ToAbsolute("~/Indian-Universities.aspx");
                            strPageTitle = "Universities in India";
                        }
                    }

                    else if (strCollegeType == "Schools")
                    {
                        SchoolClass objSchool = new SchoolClass();
                        objSchool.strTitle = RouteData.Values["Institute"].ToString().Replace("-", " ").Replace("_", ".");
                        CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolByName();
                        if (objSchoolList.Count > 0)
                        {
                            strInstitutionType = "School";
                            strInstitute = objSchoolList[0].strTitle;
                            InstitutionTypeId = objSchoolList[0].iID;

                            strPageUrl = VirtualPathUtility.ToAbsolute("~/Schools-in-India.aspx");
                            strPageTitle = "Schools in India";
                        }
                    }

                    else if (strCollegeType == "University" || strCollegeType == "Distance-Colleges")
                    {
                        string strDistance = RouteData.Values["Institute"].ToString().Replace("-", " ");

                        DistanceLearningClass objDistance = new DistanceLearningClass();
                        objDistance.strName = strDistance;
                        CoreWebList<DistanceLearningClass> objDistanceList = objDistance.fn_GetDistanceLearningListByName();
                        if (objDistanceList.Count > 0)
                        {
                            if (objDistanceList[0].strType == "University")
                            {
                                strInstitutionType = "DistanceUniversity";

                                strPageUrl = VirtualPathUtility.ToAbsolute("~/Universities.aspx");
                                strPageTitle = "Distance Universities";
                            }

                            if (objDistanceList[0].strType == "Institute")
                            {
                                strInstitutionType = "DistanceCollege";

                                strPageUrl = VirtualPathUtility.ToAbsolute("~/Distance-Colleges.aspx");
                                strPageTitle = "Distance Colleges";
                            }

                            strInstitute = objDistanceList[0].strName;
                            InstitutionTypeId = objDistanceList[0].iID;
                        }
                    }

                    fn_BindReviews(strInstitutionType, InstitutionTypeId);

                    ltl_Title.Text = strInstitute + " Reviews";

                    string strMetaTitle = strInstitute + " Reviews";
                    string strMetaDesc = strInstitute + " Reviews";
                    string strMetaKeys = strInstitute + " Reviews";

                    ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                    ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                    ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                    string strUrl = VirtualPathUtility.ToAbsolute("~/" + RouteData.Values["InstituteType"].ToString() + "/" + RouteData.Values["Institute"].ToString()); 

                    Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                    ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a>&nbsp;>&nbsp;<a href='" + strPageUrl + "'>" + strPageTitle + "</a>&nbsp;>&nbsp;<a href='" + strUrl + "'>" + strInstitute + "</a>&nbsp;>&nbsp;Reviews";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void fn_BindReviews(string strInstitutionType, int iInstituteID)
    {
        try
        {
            EduReviewClass objEduReview = new EduReviewClass();
            objEduReview.strInstitutionType = strInstitutionType;
            objEduReview.iInstitutionID = iInstituteID;
            CoreWebList<EduReviewClass> objEduReviewList = objEduReview.fn_getEduReviewByType();
            if (objEduReviewList.Count > 0)
            {
                rpt_Review.DataSource = objEduReviewList;
                rpt_Review.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    public static string fn_ShortDetails(string strText)
    {
        strText = Regex.Replace(strText, "<.*?>", string.Empty);

        if (strText.Length > 210)
        {
            strText = strText.Substring(0, 210);
        }

        return strText;

    }
}