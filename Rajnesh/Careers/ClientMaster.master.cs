using System;
using yo_lib;

public partial class ClientMaster : System.Web.UI.MasterPage
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

    protected void lnkLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["userId"] != null)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("");
            }
            else
            {
                Response.Redirect("Login.aspx?LoginType=Fresher");
            }
        }
        catch (Exception ex)
        {
            Response.Write("ERROR : " + ex.Message);
        }
    }

    protected void lnkEmployer_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["userId"] != null)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("");
            }
            else
            {
                Response.Redirect("Login.aspx?LoginType=Employer");
            }
        }
        catch (Exception ex)
        {
            Response.Write("ERROR : " + ex.Message);
        }
    }

    protected void lnkCampus_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["userId"] != null)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("");
            }
            else
            {
                Response.Redirect("Login.aspx?LoginType=Campus");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}