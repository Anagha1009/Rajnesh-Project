using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Collections;


public partial class SearchDetails : System.Web.UI.Page
{
    int iCountryId = 0;
    static ArrayList pages = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                if (RouteData.Values["Country"] != null)
                {
                    CountryClass objCountry = new CountryClass();
                    objCountry.strTitle = RouteData.Values["Country"].ToString().Replace("-", " ");
                    CoreWebList<CountryClass> objCountryList = objCountry.fn_getCountryByName();
                    if (objCountryList.Count > 0)
                    {
                        ltl_Title.Text = objCountryList[0].strTitle;

                        img_Pages.Src = "https://www.eduvidya.com/files/Country/" + objCountryList[0].strPhoto;
                        img_Pages.Alt = objCountryList[0].strTitle;

                        ltl_Desc.Text = objCountryList[0].strDetails;

                        iCountryId = objCountryList[0].iID;

                        ViewState["CountryId"] = iCountryId;

                        fn_BindArticles();
                        fn_BindUniversity();

                        string strMetaTitle = " Study in " + objCountryList[0].strTitle + " ,Top Universities in " + objCountryList[0].strTitle + " 2021 ";
                        string strMetaDesc = "Study in " + objCountryList[0].strTitle + " for Indian students "+ " - Get list of Top Universities in " + objCountryList[0].strTitle + " 2021 for Masters, MS, MBA, Phd and Engineering courses";
                        string strMetaKeys = objCountryList[0].strTitle;

                        ltl_metaTitle.Text = "<title>" + strMetaTitle + "</title>";
                        ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                        ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                        Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                        ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='" + VirtualPathUtility.ToAbsolute("~/Studyabroad.aspx") + "'>Studyabroad</a>" + objCountryList[0].strTitle;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindUniversity()
    {
        try
        {
            UniversityClass objUniversity = new UniversityClass();
            objUniversity.iCountryID = int.Parse(ViewState["CountryId"].ToString());
            CoreWebList<UniversityClass> objUniversityList = objUniversity.fn_getUniversityByCountryID();
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
                }
                else
                {
                    rptPagesUp.Visible = false;
                    rptPagesDwn.Visible = false;
                }
                grd_Records.DataSource = pgitems;
            }
            else
            {
                grd_Records.DataSource = null;
            }
            grd_Records.DataBind();
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
            UniversityClass objUniversity = new UniversityClass();
            objUniversity.iCountryID = int.Parse(ViewState["CountryId"].ToString());
            CoreWebList<UniversityClass> objUniversityList = objUniversity.fn_getUniversityByCountryID();
            if (objUniversityList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objUniversityList);
                pgitems.DataSource = dv;
                pgitems.AllowPaging = true;
                pgitems.PageSize = 15;
                pgitems.CurrentPageIndex = PageNumber;
                grd_Records.DataSource = pgitems;
            }
            else
            {
                grd_Records.DataSource = null;
            }
            grd_Records.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindArticles()
    {
        try
        {
            ArticleClass objArticle = new ArticleClass();
            objArticle.iCountryID = int.Parse(ViewState["CountryId"].ToString());
            CoreWebList<ArticleClass> objArticleList = objArticle.fn_getArticleByCountryID();
            if (objArticleList.Count > 0)
            {
                rpt_Articles.DataSource = objArticleList;
                rpt_Articles.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    //protected void grd_Records_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        grd_Records.PageIndex = e.NewPageIndex;
    //        fn_BindUniversity();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message + ex.StackTrace);
    //    }
    //}

    //protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    //{
    //    (grd_Records.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
    //    (grd_Records.FindControl("DataPager2") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
    //    this.fn_BindUniversity();
    //}

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
        fn_BindUniversityWithoutPagging();
        ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "resetClass('" + Convert.ToInt32(e.CommandArgument) + "');", true);
    }

    protected void lnkMorePageNumber_Click(object sender, EventArgs e)
    {
        if (pages.Count > 0)
        {
            ViewState["NavPageNumber"] = pages[Convert.ToInt32(pages.Count - 1)];
            ViewState["PageNumber"] = pages[Convert.ToInt32(pages.Count - 1)];
            fn_BindUniversity();
        }
    }


    protected void lnkPrevPageNumber_Click(object sender, EventArgs e)
    {
        if (pages.Count > 0)
        {
            ViewState["NavPageNumber"] = Convert.ToInt32(pages[0]) - 11;
            ViewState["PageNumber"] = Convert.ToInt32(pages[0]) - 11;
            fn_BindUniversity();
        }
    }

    #endregion pagination
}
