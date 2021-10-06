using System;
using System.Web.UI;
using yo_lib;

public partial class ClientMaster : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                fn_BindQuery();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindQuery()
    {
        try
        {
            var objQuery = new QueryGeneratorClass();
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