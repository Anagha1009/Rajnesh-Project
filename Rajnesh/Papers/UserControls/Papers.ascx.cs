using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class Papers_UserControls_Papers : UserControl
{
    public string FileName { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                var objPaper = new PaperGeneratorClass {strFileName = Path.GetFileName(FileName)};
                CoreWebList<PaperGeneratorClass> objPaperList = objPaper.fn_GetPaperListByFileName();
                if (objPaperList.Count > 0)
                {
                    /*********/
                    hlTitle.Text = objPaperList[0].strPageTitle;
                    lblDescription.Text = objPaperList[0].strH3;
                    /*********/

                    string strIDs = objPaperList[0].strIdentities;

                    if (strIDs != "")
                    {
                        string strQuery = "SELECT * FROM edu_papers WHERE Paper_id IN(" + strIDs + ")";

                        ViewState["Query"] = strQuery;

                        var obj = new PaperClass();
                        CoreWebList<PaperClass> objList = obj.fn_GetPaperByQuery(strQuery);
                        grd_papers.DataSource = objList.Count > 0 ? objList : null;
                        grd_papers.DataBind();
                    }
                }

                fn_BindCategory();
                fn_BindCity();
                fn_BindCompany();
                fn_BindRating();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + ex.StackTrace);
            }
        }
    }

    protected void grd_papers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            var objPaper = new PaperClass();
            CoreWebList<PaperClass> objPaperList = objPaper.fn_GetPaperByQuery(ViewState["Query"].ToString());
            grd_papers.PageIndex = e.NewPageIndex;
            grd_papers.DataSource = objPaperList;
            grd_papers.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void rt_Rate_Changed(object sender, EventArgs e)
    {
        try
        {
            fn_StarRating();
            Response.Redirect(Request.Url.ToString());
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
            var objRate = new RatingClass {strType = Path.GetFileName(Request.PhysicalPath), iTypeID = 1};
            CoreWebList<RatingClass> objRateList = objRate.fn_getRatingByTypeID();
            if (objRateList.Count > 0)
            {
                objRate.iID = objRateList[0].iID;
                objRate.fCount = rt_Rate.CurrentRating + objRateList[0].fCount;
                objRate.iClicks = objRateList[0].iClicks + 1;

                objRate.fn_EditRating();
            }
            else
            {
                objRate.fCount = rt_Rate.CurrentRating;
                objRate.iClicks = 1;

                objRate.fn_SaveRating();
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
            var objRate = new RatingClass {strType = Path.GetFileName(Request.PhysicalPath), iTypeID = 1};
            CoreWebList<RatingClass> objRateList = objRate.fn_getRatingByTypeID();
            if (objRateList.Count > 0)
            {
                double dRate = Math.Round(objRateList[0].fCount / objRateList[0].iClicks);
                rt_Rate.CurrentRating = (int)dRate;
                ltl_RatingBox.Text = "(<span itemprop=\"rating\" itemscope itemtype=\"http://data-vocabulary.org/Rating\"><span itemprop=\"average\">" + dRate + "</span> out of <span itemprop=\"best\">5</span> </span>based on <span itemprop=\"count\">" + objRateList[0].iClicks + "</span> Ratings)";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    #region Search Functionality

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string strCategory =
    //            ddlCategory.SelectedItem.Text.Replace(" ", "-")
    //                .Replace("&", "-")
    //                .Replace(":", "-")
    //                .Replace("?", "-")
    //                .Replace(",", "-")
    //                .Replace("%", "-")
    //                .Replace("/", "-")
    //                .Replace("---", "-")
    //                .Replace("--", "-");
    //        int iCategory = int.Parse(ddlCategory.SelectedValue);

    //        string strCompany =
    //            ddlCompany.SelectedItem.Text.Replace(" ", "-")
    //                .Replace("&", "-")
    //                .Replace(":", "-")
    //                .Replace("?", "-")
    //                .Replace(",", "-")
    //                .Replace("%", "-")
    //                .Replace("/", "-")
    //                .Replace("---", "-")
    //                .Replace("--", "-");
    //        int iCompany = int.Parse(ddlCompany.SelectedValue);

    //        string strLocation =
    //            ddlCity.SelectedItem.Text.Replace(" ", "-")
    //                .Replace("&", "-")
    //                .Replace(":", "-")
    //                .Replace("?", "-")
    //                .Replace(",", "-")
    //                .Replace("%", "-")
    //                .Replace("/", "-")
    //                .Replace("---", "-")
    //                .Replace("--", "-");
    //        int iLocation = int.Parse(ddlCity.SelectedValue);

    //        Response.Redirect("Job-Search.aspx?Category=" + strCategory + "&Company=" +
    //                          strCompany + "&City=" + strLocation + "&Ca=" + iCategory + "&Co=" + iCompany + "&Lo=" +
    //                          iLocation);
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write("ERROR : " + ex.Message);
    //    }
    //}

    protected void fn_BindCategory()
    {
        try
        {
            //var objCm = new JobCategoryClass();
            //ddlCategory.DataSource = objCm.fn_GetJobCategoryList();
            //ddlCategory.DataTextField = "strJobCategoryName";
            //ddlCategory.DataValueField = "iID";
            //ddlCategory.DataBind();
            //ddlCategory.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception ex)
        {
            Response.Write("ERROR : " + ex.Message);
        }
    }

    protected void fn_BindCity()
    {
        try
        {
            //var objCm = new CityMasterClass();
            //ddlCity.DataSource = objCm.fn_getCityList();
            //ddlCity.DataTextField = "strCityName";
            //ddlCity.DataValueField = "iID";
            //ddlCity.DataBind();
            //ddlCity.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception ex)
        {
            Response.Write("ERROR : " + ex.Message);
        }
    }

    protected void fn_BindCompany()
    {
        try
        {
            //var objCm = new JobCompanyClass();
            //ddlCompany.DataSource = objCm.fn_GetJobCompanyList();
            //ddlCompany.DataTextField = "strJobCompanyName";
            //ddlCompany.DataValueField = "iID";
            //ddlCompany.DataBind();
            //ddlCompany.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception ex)
        {
            Response.Write("ERROR : " + ex.Message);
        }
    }

    #endregion
}