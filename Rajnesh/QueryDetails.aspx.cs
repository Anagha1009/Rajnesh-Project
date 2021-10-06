using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data;

public partial class College_Details : System.Web.UI.Page
{
    static string strIdentity = "";
    int iCategoryId = 0;
    static ArrayList pages = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        grd_University.Visible = false;
        grd_Institute.Visible = false;
        grd_Schools.Visible = false;
        grd_Courses.Visible = false;

        try
        {
            if (!IsPostBack)
            {
                if (RouteData.Values["Query"] != null)
                    {
                
                    fn_BindRating();


                    QueryGeneratorClass objQuery = new QueryGeneratorClass();
                    objQuery.strTitle = RouteData.Values["Query"].ToString().Replace("-", " ");
                    CoreWebList<QueryGeneratorClass> objQueryList = objQuery.fn_getQueryGeneratorByName();
                    if (objQueryList.Count > 0)
                    {
                        //iCategoryId = objQueryList[0].iCategoryID;
                        //strIdentity = objQueryList[0].strIdentity;
                        //string strTitle = objQueryList[0].strTitle;

                        strIdentity = objQueryList[0].strIdentity;

                        string strTitle = objQueryList[0].strTitle;
                        iCategoryId = objQueryList[0].iCategoryID;

                        fn_Bind();



                        ltl_Title.Text = strTitle;
                        ltl_Desc.Text = objQueryList[0].strDesc;

                        QueryLinkClass objLinks = new QueryLinkClass();
                        objLinks.iQueryID = objQueryList[0].iID;
                        CoreWebList<QueryLinkClass> objLinkList = objLinks.fn_getQueryLinkByQueryID();
                        if (objLinkList.Count > 0)
                        {
                            rpt_Links.DataSource = objLinkList;
                            rpt_Links.DataBind();
                        }

                        if (objQueryList[0].strYoutube != "")
                        {
                            divyoutubeframe.Attributes.Add("src", "https://www.youtube.com/embed/" + fn_GetUrl(objQueryList[0].strYoutube));
                        }

                        else
                        {
                            YoutubeFrame.Attributes.Add("style", "display:none");
                        }

                        BannerClass objBanner = new BannerClass();
                        objBanner.strTargetUrl = Request.Url.ToString();
                        CoreWebList<BannerClass> objBannerList = objBanner.fn_getBannerByTargetUrl();
                        if (objBannerList.Count > 0)
                        {
                            hyp_Banner.HRef = VirtualPathUtility.ToAbsolute("~/Banners/" + objBannerList[0].strTitle.Replace(" ", "-"));
                            hyp_Banner.InnerText = objBannerList[0].strTitle;
                        }
                        else
                        {
                            hyp_Banner.Visible = false;
                        }

                        string strMetaTitle = objQueryList[0].strMetaTitle;
                        string strMetaDesc = objQueryList[0].strMetaDesc;
                        string strMetaKeys = objQueryList[0].strMetakeys;

                        ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                        ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                        ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                        Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                        ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a>" + strTitle;

                        HtmlControl dynamicid = (HtmlControl)Master.FindControl("dynamicid");
                        dynamicid.ID = "details-list";
                    }
                    else
                    {
                        Response.Status = "404 Not Found";
                        Response.StatusCode = 404;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_Bind()
    {
        QueryGeneratorClass objQuery = new QueryGeneratorClass();
        objQuery.strTitle = RouteData.Values["Query"].ToString().Replace("-", " ");
        CoreWebList<QueryGeneratorClass> objQueryList = objQuery.fn_getQueryGeneratorByName();
        if (objQueryList.Count > 0)
        {

            if (objQueryList[0].strType == "University")
            {
                fn_BindUniversity();
                grd_University.Visible = true;
            }
            else if (objQueryList[0].strType == "Institute")
            {
                fn_BindInstitutes();
                grd_Institute.Visible = true;
            }
            else if (objQueryList[0].strType == "School")
            {
                fn_BindSchools();
                grd_Schools.Visible = true;
            }
            else if (objQueryList[0].strType == "Courses")
            {
                fn_BindCourses();
                grd_Courses.Visible = true;
            }
        }
    }

    protected void fn_BindWithoutPagging()
    {
        QueryGeneratorClass objQuery = new QueryGeneratorClass();
        objQuery.strTitle = RouteData.Values["Query"].ToString().Replace("-", " ");
        CoreWebList<QueryGeneratorClass> objQueryList = objQuery.fn_getQueryGeneratorByName();
        if (objQueryList.Count > 0)
        {
            if (objQueryList[0].strType == "University")
            {
                fn_BindUniversityWithoutPagging();
                grd_University.Visible = true;
            }
            else if (objQueryList[0].strType == "Institute")
            {
                fn_BindInstitutesWithoutPagging();
                grd_Institute.Visible = true;
            }
            else if (objQueryList[0].strType == "School")
            {
                fn_BindSchoolsWithoutPagging();
                grd_Schools.Visible = true;
            }
            else if (objQueryList[0].strType == "Courses")
            {
                fn_BindCoursesWithoutPagging();
                grd_Courses.Visible = true;
            }
        }
    }


    protected void fn_BindUniversity()
    {
        try
        {
            UniversityListClass objUniversity = new UniversityListClass();
            CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_getUniversityByIdentities(strIdentity);
            if (objUniversityList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objUniversityList);
                pgitems.DataSource = dv;
                pgitems.AllowPaging = true;
                pgitems.PageSize = 15;
                pgitems.CurrentPageIndex = PageNumber;
                if (pgitems.PageCount >= 1)
                {
                    int pno = Convert.ToInt32(ViewState["NavPageNumber"]);
                    if (pno == 0)
                    {
                        btnMoreUpPrv.Visible = false;
                        btnMoreDwnPrv.Visible = false;
                    }
                    else
                    {
                        btnMoreUpPrv.Visible = true;
                        btnMoreDwnPrv.Visible = true;
                    }
                    rptPagesUp.Visible = true;
                    rptPagesDwn.Visible = true;
                    pages.Clear();
                    if (pno + 10 >= pgitems.PageCount)// for last grup of pagecounts
                    {
                        for (int i = pno; i < pgitems.PageCount; i++)
                            pages.Add((i + 1).ToString());
                        btnMoreUpNxt.Visible = false;
                        btnMoreDwnNxt.Visible = false;
                    }
                    else
                    {

                        for (int i = pno; i < pno + 10; i++)
                            pages.Add((i + 1).ToString());
                        btnMoreUpNxt.Visible = true;
                        btnMoreDwnNxt.Visible = true;

                    }

                    rptPagesUp.DataSource = pages;
                    rptPagesUp.DataBind();
                    rptPagesDwn.DataSource = pages;
                    rptPagesDwn.DataBind();
                    ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "resetClass('" + (pno + 1) + "');", true);
                    grd_University.DataSource = pgitems;
                }
            }
            else
            {
                grd_University.DataSource = null;
            }
            grd_University.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindInstitutes()
    {
        try
        {
            InstituteClass objInstitute = new InstituteClass();
            objInstitute.iCategoryID = iCategoryId;
            CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByIdentity(strIdentity);
            if (objInstituteList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objInstituteList);
                pgitems.DataSource = dv;
                pgitems.AllowPaging = true;
                pgitems.PageSize = 15;
                pgitems.CurrentPageIndex = PageNumber;
                if (pgitems.PageCount >= 1)
                {
                    int pno = Convert.ToInt32(ViewState["NavPageNumber"]);
                    if (pno == 0)
                    {
                        btnMoreUpPrv.Visible = false;
                        btnMoreDwnPrv.Visible = false;
                    }
                    else
                    {
                        btnMoreUpPrv.Visible = true;
                        btnMoreDwnPrv.Visible = true;
                    }
                    rptPagesUp.Visible = true;
                    rptPagesDwn.Visible = true;
                    pages.Clear();
                    if (pno + 10 >= pgitems.PageCount)// for last grup of pagecounts
                    {
                        for (int i = pno; i < pgitems.PageCount; i++)
                            pages.Add((i + 1).ToString());
                        btnMoreUpNxt.Visible = false;
                        btnMoreDwnNxt.Visible = false;
                    }
                    else
                    {

                        for (int i = pno; i < pno + 10; i++)
                            pages.Add((i + 1).ToString());
                        btnMoreUpNxt.Visible = true;
                        btnMoreDwnNxt.Visible = true;

                    }

                    rptPagesUp.DataSource = pages;
                    rptPagesUp.DataBind();
                    rptPagesDwn.DataSource = pages;
                    rptPagesDwn.DataBind();
                    ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "resetClass('" + (pno + 1) + "');", true);
                }
                else
                {
                    rptPagesUp.Visible = false;
                    rptPagesDwn.Visible = false;
                }
                grd_Institute.DataSource = pgitems;
            }
            else
            {
                grd_Institute.DataSource = null;
            }
            grd_Institute.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindSchools()
    {
        try
        {
            SchoolClass objSchools = new SchoolClass();
            CoreWebList<SchoolClass> objSchoolsList = objSchools.fn_getSchoolByIdentity(strIdentity);
            if (objSchoolsList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objSchoolsList);
                pgitems.DataSource = dv;
                pgitems.AllowPaging = true;
                pgitems.PageSize = 15;
                pgitems.CurrentPageIndex = PageNumber;
                if (pgitems.PageCount >= 1)
                {
                    int pno = Convert.ToInt32(ViewState["NavPageNumber"]);
                    if (pno == 0)
                    {
                        btnMoreUpPrv.Visible = false;
                        btnMoreDwnPrv.Visible = false;
                    }
                    else
                    {
                        btnMoreUpPrv.Visible = true;
                        btnMoreDwnPrv.Visible = true;
                    }
                    rptPagesUp.Visible = true;
                    rptPagesDwn.Visible = true;
                    pages.Clear();
                    if (pno + 10 >= pgitems.PageCount)// for last grup of pagecounts
                    {
                        for (int i = pno; i < pgitems.PageCount; i++)
                            pages.Add((i + 1).ToString());
                        btnMoreUpNxt.Visible = false;
                        btnMoreDwnNxt.Visible = false;
                    }
                    else
                    {

                        for (int i = pno; i < pno + 10; i++)
                            pages.Add((i + 1).ToString());
                        btnMoreUpNxt.Visible = true;
                        btnMoreDwnNxt.Visible = true;

                    }

                    rptPagesUp.DataSource = pages;
                    rptPagesUp.DataBind();
                    rptPagesDwn.DataSource = pages;
                    rptPagesDwn.DataBind();
                    ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "resetClass('" + (pno + 1) + "');", true);
                }
                else
                {
                    rptPagesUp.Visible = false;
                    rptPagesDwn.Visible = false;
                }
                grd_Schools.DataSource = pgitems;
            }
            else
            {
                grd_Schools.DataSource = null;
            }
            grd_Schools.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindCourses()
    {
        try
        {
            InstituteCourseClass objCourses = new InstituteCourseClass();
            CoreWebList<InstituteCourseClass> objCoursesList = objCourses.fn_getInstituteCourseByIdentity(strIdentity);
            if (objCoursesList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objCoursesList);
                pgitems.DataSource = dv;
                pgitems.AllowPaging = true;
                pgitems.PageSize = 15;
                pgitems.CurrentPageIndex = PageNumber;
                if (pgitems.PageCount >= 1)
                {
                    int pno = Convert.ToInt32(ViewState["NavPageNumber"]);
                    if (pno == 0)
                    {
                        btnMoreUpPrv.Visible = false;
                        btnMoreDwnPrv.Visible = false;
                    }
                    else
                    {
                        btnMoreUpPrv.Visible = true;
                        btnMoreDwnPrv.Visible = true;
                    }
                    rptPagesUp.Visible = true;
                    rptPagesDwn.Visible = true;
                    pages.Clear();
                    if (pno + 10 >= pgitems.PageCount)// for last grup of pagecounts
                    {
                        for (int i = pno; i < pgitems.PageCount; i++)
                            pages.Add((i + 1).ToString());
                        btnMoreUpNxt.Visible = false;
                        btnMoreDwnNxt.Visible = false;
                    }
                    else
                    {

                        for (int i = pno; i < pno + 10; i++)
                            pages.Add((i + 1).ToString());
                        btnMoreUpNxt.Visible = true;
                        btnMoreDwnNxt.Visible = true;

                    }

                    rptPagesUp.DataSource = pages;
                    rptPagesUp.DataBind();
                    rptPagesDwn.DataSource = pages;
                    rptPagesDwn.DataBind();
                    ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "resetClass('" + (pno + 1) + "');", true);
                }
                else
                {
                    rptPagesUp.Visible = false;
                    rptPagesDwn.Visible = false;
                }
                grd_Courses.DataSource = pgitems;
            }
            else
            {
                grd_Courses.DataSource = null;
            }
            grd_Courses.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }


    protected void fn_BindUniversityWithoutPagging()
    {
        try
        {
            UniversityListClass objUniversity = new UniversityListClass();
            CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_getUniversityByIdentities(strIdentity);
            if (objUniversityList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objUniversityList);
                pgitems.DataSource = dv;
                pgitems.AllowPaging = true;
                pgitems.PageSize = 15;
                pgitems.CurrentPageIndex = PageNumber;
                grd_University.DataSource = pgitems;
            }
            else
            {
                grd_University.DataSource = null;
            }
            grd_University.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindInstitutesWithoutPagging()
    {
        try
        {
            InstituteClass objInstitute = new InstituteClass();
            objInstitute.iCategoryID = iCategoryId;
            CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByIdentity(strIdentity);
            if (objInstituteList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objInstituteList);
                pgitems.DataSource = dv;
                pgitems.AllowPaging = true;
                pgitems.PageSize = 15;
                pgitems.CurrentPageIndex = PageNumber;
                grd_Institute.DataSource = pgitems;
            }
            else
            {
                grd_Institute.DataSource = null;
            }
            grd_Institute.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindSchoolsWithoutPagging()
    {
        try
        {
            SchoolClass objSchools = new SchoolClass();
            CoreWebList<SchoolClass> objSchoolsList = objSchools.fn_getSchoolByIdentity(strIdentity);
            if (objSchoolsList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objSchoolsList);
                pgitems.DataSource = dv;
                pgitems.AllowPaging = true;
                pgitems.PageSize = 15;
                pgitems.CurrentPageIndex = PageNumber;
                grd_Schools.DataSource = pgitems;
            }
            else
            {
                grd_Schools.DataSource = null;
            }
            grd_Schools.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindCoursesWithoutPagging()
    {
        try
        {
            InstituteCourseClass objCourses = new InstituteCourseClass();
            CoreWebList<InstituteCourseClass> objCoursesList = objCourses.fn_getInstituteCourseByIdentity(strIdentity);
            if (objCoursesList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objCoursesList);
                pgitems.DataSource = dv;
                pgitems.AllowPaging = true;
                pgitems.PageSize = 15;
                pgitems.CurrentPageIndex = PageNumber;
                grd_Courses.DataSource = pgitems;
            }
            else
            {
                grd_Courses.DataSource = null;
            }
            grd_Courses.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    //protected void grd_University_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        grd_University.PageIndex = e.NewPageIndex;
    //        fn_BindUniversity();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message + ex.StackTrace);
    //    }
    //}

    //protected void grd_Institute_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        grd_Institute.PageIndex = e.NewPageIndex;
    //        fn_BindInstitutes();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message + ex.StackTrace);
    //    }
    //}

    //protected void grd_Schools_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        grd_Schools.PageIndex = e.NewPageIndex;
    //        fn_BindSchools();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message + ex.StackTrace);
    //    }
    //}

    //protected void grd_Courses_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        grd_Courses.PageIndex = e.NewPageIndex;
    //        fn_BindCourses();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message + ex.StackTrace);
    //    }
    //}

    protected void rt_Rate_Changed(object sender, EventArgs e)
    {
        try
        {
            fn_StarRating();
            fn_BindRating();
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
            string strResponse = "";

            RatingClass objRate = new RatingClass();
            objRate.strType = Request.Url.ToString();
            objRate.iTypeID = 1;
            CoreWebList<RatingClass> objRateList = objRate.fn_getRatingByTypeID();
            if (objRateList.Count > 0)
            {
                objRate.iID = objRateList[0].iID;
                objRate.fCount = rt_Rate.CurrentRating + objRateList[0].fCount;
                objRate.iClicks = objRateList[0].iClicks + 1;

                strResponse = objRate.fn_EditRating();
            }
            else
            {
                objRate.fCount = rt_Rate.CurrentRating;
                objRate.iClicks = 1;

                strResponse = objRate.fn_SaveRating();
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
            RatingClass objRate = new RatingClass();
            objRate.strType = Request.Url.ToString();
            objRate.iTypeID = 1;
            CoreWebList<RatingClass> objRateList = objRate.fn_getRatingByTypeID();
            if (objRateList.Count > 0)
            {
                double dRate = Math.Round(objRateList[0].fCount / objRateList[0].iClicks);
                rt_Rate.CurrentRating = (int)dRate;

                ltl_RatingBox.Text = "(<span itemprop=\"rating\" itemscope itemtype=\"https://data-vocabulary.org/Rating\"><span itemprop=\"average\">" + dRate.ToString() + "</span> out of <span itemprop=\"best\">5</span> </span>based on <span itemprop=\"count\">" + objRateList[0].iClicks + "</span> Ratings)";
            }
            else
            {
                ltl_RatingBox.Text = "(Become first to Rate this!)";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected string fn_GetUrl(string strRawUrl)
    {
        try
        {
            Uri tempUri = new Uri(strRawUrl);
            string sQuery = tempUri.Query;
            string sUrl = HttpUtility.ParseQueryString(sQuery).Get("v");
            return sUrl;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region pagination

    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
                return Convert.ToInt32(ViewState["PageNumber"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNumber"] = value;
        }
    }

    public int NavPageNumber
    {
        get
        {
            if (ViewState["NavPageNumber"] != null)
                return Convert.ToInt32(ViewState["NavPageNumber"]);
            else
                return 0;
        }
        set
        {
            ViewState["NavPageNumber"] = value;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        rptPagesUp.ItemCommand +=
           new RepeaterCommandEventHandler(rptPages_ItemCommand);
        rptPagesDwn.ItemCommand +=
          new RepeaterCommandEventHandler(rptPages_ItemCommand);
    }

    void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToLower().Equals("page")) { PageNumber = Convert.ToInt32(e.CommandArgument) - 1; }
        fn_BindWithoutPagging();
        ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "resetClass('" + Convert.ToInt32(e.CommandArgument) + "');", true);
    }

    protected void lnkMorePageNumber_Click(object sender, EventArgs e)
    {
        if (pages.Count > 0)
        {
            ViewState["NavPageNumber"] = pages[Convert.ToInt32(pages.Count - 1)];
            ViewState["PageNumber"] = pages[Convert.ToInt32(pages.Count - 1)];
            fn_Bind();
        }
    }


    protected void lnkPrevPageNumber_Click(object sender, EventArgs e)
    {
        if (pages.Count > 0)
        {
            ViewState["NavPageNumber"] = Convert.ToInt32(pages[0]) - 11;
            ViewState["PageNumber"] = Convert.ToInt32(pages[0]) - 11;
            fn_Bind();
        }
    }

    #endregion pagination
}