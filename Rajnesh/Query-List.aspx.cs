using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Text.RegularExpressions;

public partial class QueryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fn_BindQueryList();
            fn_BindRating();

            Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
            ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a>Query List";

            HtmlControl dynamicid = (HtmlControl)Master.FindControl("dynamicid");
            dynamicid.ID = "query-list";
        }
    }

    protected void fn_BindQueryList()
    {
        try
        {
            QueryGeneratorClass objQuery = new QueryGeneratorClass();
            CoreWebList<QueryGeneratorClass> objQueryList = objQuery.fn_getQueryGeneratorList();
            if (objQueryList.Count > 0)
            {
                CPager.DataSource = objQueryList;
                CPager.BindToControl = rpt_QueryList;
                CPager.SecondPageHolderId = PagerDiv.UniqueID;
                CPager.DataBind();
                rpt_QueryList.DataSource = CPager.DataSourcePaged;
                rpt_QueryList.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

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