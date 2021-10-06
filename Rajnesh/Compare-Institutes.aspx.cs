using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using yo_lib;
using System.Text.RegularExpressions;

public partial class CompareInstitute : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strTitle = "";

            string strInstitute1 = "";
            string strInstitute2 = "";
            string strInstitute3 = "";

            int iInstituteID1 = 0;
            int iInstituteID2 = 0;
            int iInstituteID3 = 0;

            
            if (Request.QueryString["Institute1"] != null && Request.QueryString["Institute2"] != null && Request.QueryString["InstituteID1"] != null && Request.QueryString["InstituteID2"] != null)
            {
                iInstituteID1 = int.Parse(Request.QueryString["InstituteID1"].ToString());
                iInstituteID2 = int.Parse(Request.QueryString["InstituteID2"].ToString());

                strInstitute1 = fn_GetInstituteName(iInstituteID1);
                strInstitute2 = fn_GetInstituteName(iInstituteID2);

                fn_BindInstitutes(iInstituteID1, hyp_Institute1, img_Institute1, ltl_EstablishedIn1, ltl_AffiliatedTo1, ltl_Facilities1, ltl_Placements1);
                fn_BindInstitutes(iInstituteID2, hyp_Institute2, img_Institute2, ltl_EstablishedIn2, ltl_AffiliatedTo2, ltl_Facilities2, ltl_Placements2);

                fn_BindInstituteCourses(rpt_Courses1, iInstituteID1);
                fn_BindInstituteCourses(rpt_Courses2, iInstituteID2);

                fn_BindInstituteExams(ltl_ExamAccepted1, iInstituteID1);
                fn_BindInstituteExams(ltl_ExamAccepted2, iInstituteID2);

                fn_BindReviews(rpt_Review1, iInstituteID1);
                fn_BindReviews(rpt_Review2, iInstituteID2);

                strTitle = "Compare " + strInstitute1 + " With " + strInstitute2;
            }

            if (Request.QueryString["Institute3"] != null && Request.QueryString["InstituteID3"] != null)
            {
                strInstitute3 = Request.QueryString["Institute3"].ToString();
                iInstituteID3 = int.Parse(Request.QueryString["InstituteID3"].ToString());

                strInstitute3 = fn_GetInstituteName(iInstituteID3);
                strTitle += strInstitute3;

                fn_BindInstitutes(iInstituteID3, hyp_Institute3, img_Institute3, ltl_EstablishedIn3, ltl_AffiliatedTo3, ltl_Facilities3, ltl_Placements3);
                fn_BindInstituteCourses(rpt_Courses3, iInstituteID3);
                fn_BindInstituteExams(ltl_ExamAccepted3, iInstituteID3);
                fn_BindReviews(rpt_Review3, iInstituteID3);
            }

            ltl_Title.Text = strTitle;

            string strMetaTitle = strTitle;
            string strMetaDesc = strTitle;
            string strMetaKeys = strTitle;

            ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
            ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
            ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";
            

            
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindInstitutes(int iInstituteID, HyperLink hyp_Institute, HtmlImage img_Institute, Literal ltl_EstablishedIn, Literal ltl_AffiliatedTo, Literal ltl_Facilities, Literal ltl_Placements)
    {
        try
        {
            InstituteClass objInstitute = new InstituteClass();
            objInstitute.iID = iInstituteID;
            CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByID();
            if (objInstituteList.Count > 0)
            {
                hyp_Institute.Text = objInstituteList[0].strTitle;
                hyp_Institute.NavigateUrl = VirtualPathUtility.ToAbsolute("~/Colleges/" + objInstituteList[0].strTitle.Replace(" ", "-").Replace(".", "_"));

                img_Institute.Src = "https://www.eduvidya.com/admin/Upload/Institutes/" + objInstituteList[0].strPhoto;
                img_Institute.Alt = objInstituteList[0].strTitle;

                ltl_EstablishedIn.Text = objInstituteList[0].strEstablishedIn;
                ltl_AffiliatedTo.Text = objInstituteList[0].strAffiliatedTo;
                ltl_Facilities.Text = objInstituteList[0].strFacilities;
                ltl_Placements.Text = objInstituteList[0].strPlacements;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    public string fn_lastCompareBox()
    {
        try
        {
            string strLastExists = "hidden";

            if (Request.QueryString["Institute3"] != null && Request.QueryString["InstituteID3"] != null)
            {
                strLastExists = "visible";
            }
            else
            {
                strLastExists = "hidden";
            }

            return strLastExists;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected string fn_GetInstituteName(int iInstituteID)
    {
        try
        {
            string strInstitute = "";
            InstituteClass objInstitute = new InstituteClass();
            objInstitute.iID = iInstituteID;
            CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByID();
            if (objInstituteList.Count > 0)
            {
                strInstitute = objInstituteList[0].strTitle;
            }

            return strInstitute;
        }
        catch (Exception ex)
        {
            throw ex;
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

    protected void fn_BindInstituteCourses(Repeater rpt_Courses, int iInstituteID)
    {
        try
        {
            InstituteCourseClass objCourse = new InstituteCourseClass();
            objCourse.iInstituteID = iInstituteID;
            CoreWebList<InstituteCourseClass> objCourseList = objCourse.fn_getInstituteCourseByInstituteID();
            if (objCourseList.Count > 0)
            {
                rpt_Courses.DataSource = objCourseList;
                rpt_Courses.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindInstituteExams(Literal ltl_ExamAccepted, int iInstituteID)
    {
        try
        {
            InstituteExamClass objInstituteExam = new InstituteExamClass();
            objInstituteExam.iInstituteID = iInstituteID;
            CoreWebList<InstituteExamClass> objInstituteExamList = objInstituteExam.fn_getInstituteExamByInstituteID();
            if (objInstituteExamList.Count > 0)
            {
                string strLinks = "";
                for (int i = 0; i < objInstituteExamList.Count; i++)
                {
                    strLinks += "<a href='" + VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + objInstituteExamList[i].strTitle.Replace(" ", "-")) + "' class'rec_links'>" + objInstituteExamList[i].strTitle + "</a>,&nbsp;&nbsp;";
                }

                ltl_ExamAccepted.Text = strLinks.TrimEnd(",&nbsp;&nbsp;".ToCharArray());
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    private void fn_BindReviews(Repeater rpt_Review, int iInstituteID)
    {
        try
        {
            EduReviewClass objEduReview = new EduReviewClass();
            objEduReview.iInstitutionID = iInstituteID;
            CoreWebList<EduReviewClass> objEduReviewList = objEduReview.fn_getInstituteReviewById();
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
}
