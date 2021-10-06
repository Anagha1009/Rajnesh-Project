using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using yo_lib;

public partial class ClientDetails_Master : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //fn_BindAuthorProfile();
                fn_BindQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //protected void fn_BindAuthorProfile()
    //{
    //    try
    //    {
    //        AuthorClass objAuthor = new AuthorClass();
    //        CoreWebList<AuthorClass> objAuthorList = objAuthor.fn_getTopAuthorList();
    //        if (objAuthorList.Count > 0)
    //        {

    //            string strUrl = "https://www.eduvidya.com/Authors/" + objAuthorList[0].strName.Replace(" ", "-") + "/" + objAuthorList[0].iID;

    //            ltl_PostedBy.Text = "<b>Posted by : </b><a href='" + strUrl + "' class='jobs' rel=\"Author\" target='_blank'>" + objAuthorList[0].strName + "</a>. Check out <a href='" + objAuthorList[0].strConnectUrl + "' rel=\"Author\" target='_blank' class='jobs'>" + objAuthorList[0].strName + " Google+ Profile</a>";
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message + ex.StackTrace);
    //    }
    //}

    protected void fn_BindQuery()
    {
        try
        {
            QueryGeneratorClass objQuery = new QueryGeneratorClass();
            CoreWebList<QueryGeneratorClass> objQueryList = objQuery.fn_getRandomQueryGeneratorList();
            if (objQueryList.Count > 0)
            {
                rpt_QueryList.DataSource = objQueryList;
                rpt_QueryList.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}
