using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Collections;
using System.Data;

public partial class Search_list : System.Web.UI.Page
{
    static ArrayList pages = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fn_BindPages();
            fn_BindRating();

            Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
            ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a>Search";

            HtmlControl dynamicid = (HtmlControl)Master.FindControl("dynamicid");
            dynamicid.ID = "search-page";
        }
    }

    protected void fn_BindPages()
    {
        try
        {
            PageGeneratorClass objPage = new PageGeneratorClass();
            CoreWebList<PageGeneratorClass> objPageList = objPage.fn_getPageGeneratorList();
            if (objPageList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objPageList);
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

    protected void fn_BindPagesWithoutPagging()
    {
        try
        {
            PageGeneratorClass objPage = new PageGeneratorClass();
            CoreWebList<PageGeneratorClass> objPageList = objPage.fn_getPageGeneratorList();
            if (objPageList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objPageList);
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
   
    //protected void grd_Records_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        grd_Records.PageIndex = e.NewPageIndex;
    //        fn_BindPages();
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

    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (grd_Records.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        (grd_Records.FindControl("DataPager2") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.fn_BindPages();
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
        fn_BindPagesWithoutPagging();
        ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "resetClass('" + Convert.ToInt32(e.CommandArgument) + "');", true);
    }

    protected void lnkMorePageNumber_Click(object sender, EventArgs e)
    {
        if (pages.Count > 0)
        {
            ViewState["NavPageNumber"] = pages[Convert.ToInt32(pages.Count - 1)];
            ViewState["PageNumber"] = pages[Convert.ToInt32(pages.Count - 1)];
            fn_BindPages();
        }
    }


    protected void lnkPrevPageNumber_Click(object sender, EventArgs e)
    {
        if (pages.Count > 0)
        {
            ViewState["NavPageNumber"] = Convert.ToInt32(pages[0]) - 11;
            ViewState["PageNumber"] = Convert.ToInt32(pages[0]) - 11;
            fn_BindPages();
        }
    }

    #endregion pagination
}