using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Data;
using System.Collections;

public partial class City_Places : System.Web.UI.Page
{
    static ArrayList pages = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            fn_BindNews();

            Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
            ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a>News";
        }
    }

    protected void fn_BindNews()
    {
        try
        {
            NewsClass objNews = new NewsClass();
            CoreWebList<NewsClass> objNewsList = objNews.fn_getNewsList();
            if (objNewsList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objNewsList);
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
                rpt_News.DataSource = pgitems;
            }
            else
            {
                rpt_News.DataSource = null;
            }
            rpt_News.DataBind();

            //InstituteClass objPlaces = new InstituteClass();
            //CoreWebList<InstituteClass> objPlacesList = objPlaces.fn_getInstituteList();
            //if (objPlacesList.Count > 0)
            //{
            //    grd_Records.DataSource = objPlacesList;
            //}
            //else
            //{
            //    grd_Records.DataSource = null;
            //}
            //grd_Records.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindNewsWithoutPagging()
    {
        try
        {
            NewsClass objNews = new NewsClass();
            CoreWebList<NewsClass> objNewsList = objNews.fn_getNewsList();
            if (objNewsList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objNewsList);
                pgitems.DataSource = dv;
                pgitems.AllowPaging = true;
                pgitems.PageSize = 15;
                pgitems.CurrentPageIndex = PageNumber;
                rpt_News.DataSource = pgitems;
            }
            else
            {
                rpt_News.DataSource = null;
            }
            rpt_News.DataBind();

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
    //protected void rpt_News_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        rpt_News.PageIndex = e.NewPageIndex;
    //        fn_BindNews();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message + ex.StackTrace);
    //    }
    //}

    //protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    //{
    //    (rpt_News.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
    //    (rpt_News.FindControl("DataPager2") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
    //    this.fn_BindNews();
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
        fn_BindNewsWithoutPagging();
        ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "resetClass('" + Convert.ToInt32(e.CommandArgument) + "');", true);
    }

    protected void lnkMorePageNumber_Click(object sender, EventArgs e)
    {
        if (pages.Count > 0)
        {
            ViewState["NavPageNumber"] = pages[Convert.ToInt32(pages.Count - 1)];
            ViewState["PageNumber"] = pages[Convert.ToInt32(pages.Count - 1)];
            fn_BindNews();
        }
    }


    protected void lnkPrevPageNumber_Click(object sender, EventArgs e)
    {
        if (pages.Count > 0)
        {
            ViewState["NavPageNumber"] = Convert.ToInt32(pages[0]) - 11;
            ViewState["PageNumber"] = Convert.ToInt32(pages[0]) - 11;
            fn_BindNews();
        }
    }

    #endregion pagination
}