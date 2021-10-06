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

public partial class Schools : System.Web.UI.Page
{
    static ArrayList pages = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fn_BindSchools();

            Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
            ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a>Search Schools";
        }
    }

    protected void fn_BindSchools()
    {
        try
        {
            string strQuery = "SELECT * FROM tbl_Schools";


            bool bStatus = false;

            if (Request.QueryString["Category"] != null && Request.QueryString["CategoryID"] != null)
            {
                int iCategoryID = int.Parse(Request.QueryString["CategoryID"].ToString());

                bStatus = true;
                strQuery += " WHERE School_ID IN(SELECT SchoolCategoryList_SchoolID FROM tbl_SchoolCategoryList WHERE SchoolCategoryList_CategoryID=" + iCategoryID + ")";
            }

            if (Request.QueryString["City"] != null && Request.QueryString["CityID"] != null)
            {
                int iCityID = int.Parse(Request.QueryString["CityID"].ToString());

                if (bStatus == true)
                {
                    strQuery += " AND School_CityID=" + iCityID;
                }
                else
                {
                    strQuery += " WHERE School_CityID=" + iCityID;
                }
            }

            strQuery += " ORDER BY School_Title ASC";

            SchoolClass objSchool = new SchoolClass();
            CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolListByQuery(strQuery);
            if (objSchoolList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objSchoolList);
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

    protected void fn_BindSchoolsWithoutPagging()
    {
        try
        {
            string strQuery = "SELECT * FROM tbl_Schools";


            bool bStatus = false;

            if (Request.QueryString["Category"] != null && Request.QueryString["CategoryID"] != null)
            {
                int iCategoryID = int.Parse(Request.QueryString["CategoryID"].ToString());

                bStatus = true;
                strQuery += " WHERE School_ID IN(SELECT SchoolCategoryList_SchoolID FROM tbl_SchoolCategoryList WHERE SchoolCategoryList_CategoryID=" + iCategoryID + ")";
            }

            if (Request.QueryString["City"] != null && Request.QueryString["CityID"] != null)
            {
                int iCityID = int.Parse(Request.QueryString["CityID"].ToString());

                if (bStatus == true)
                {
                    strQuery += " AND School_CityID=" + iCityID;
                }
                else
                {
                    strQuery += " WHERE School_CityID=" + iCityID;
                }
            }

            strQuery += " ORDER BY School_Title ASC";

            SchoolClass objSchool = new SchoolClass();
            CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolListByQuery(strQuery);
            if (objSchoolList.Count > 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView((DataTable)objSchoolList);
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
    //        fn_BindSchools();
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
    //    this.fn_BindSchools();
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
        fn_BindSchoolsWithoutPagging();
        ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "resetClass('" + Convert.ToInt32(e.CommandArgument) + "');", true);
    }

    protected void lnkMorePageNumber_Click(object sender, EventArgs e)
    {
        if (pages.Count > 0)
        {
            ViewState["NavPageNumber"] = pages[Convert.ToInt32(pages.Count - 1)];
            ViewState["PageNumber"] = pages[Convert.ToInt32(pages.Count - 1)];
            fn_BindSchools();
        }
    }


    protected void lnkPrevPageNumber_Click(object sender, EventArgs e)
    {
        if (pages.Count > 0)
        {
            ViewState["NavPageNumber"] = Convert.ToInt32(pages[0]) - 11;
            ViewState["PageNumber"] = Convert.ToInt32(pages[0]) - 11;
            fn_BindSchools();
        }
    }

    #endregion pagination
}