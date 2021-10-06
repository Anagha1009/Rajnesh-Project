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

public partial class Client_Master : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                fn_BindQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

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
