using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class admin_Articles : Page
{
    private CoreWebList<PaperGeneratorClass> ChPaperLists
    {
        get
        {
            if (Cache["ch_paper_Lists"] != null)
                return (CoreWebList<PaperGeneratorClass>) Cache["ch_paper_Lists"];
            return null;
        }
        set { Cache["ch_paper_Lists"] = value; }
    }

    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
            {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }

            return (SortDirection) ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Check login session 
            //If not logged in redirect to admin login page

            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx?flag=1");
            }

            info.Visible = false;
            error.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                // Bind Data To grid
                var objPage = new PaperGeneratorClass();
                ChPaperLists = objPage.fn_Get_PaperList();
                grd_Query.DataSource = ChPaperLists.Count > 0 ? ChPaperLists : null;
                grd_Query.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label) error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaperGenerator.aspx");
    }

    protected void grd_Query_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var hfHome = (HiddenField) e.Row.FindControl("hfHome");
                var btnHome = (ImageButton) e.Row.FindControl("btnHome");

                if (hfHome != null && btnHome != null)
                {
                    var objPaper = new PaperGeneratorClass {iID = int.Parse(hfHome.Value)};
                    CoreWebList<PaperGeneratorClass> objPaperList = objPaper.fn_GetPaperById();
                    if (objPaperList.Count > 0)
                    {
                        btnHome.ImageUrl = objPaperList[0].bHome ? "~/admin/images/Tick.gif" : "~/admin/images/cross.gif";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ((Label) error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Query_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Query.PageIndex = e.NewPageIndex;
            grd_Query.DataSource = ChPaperLists;
            grd_Query.DataBind();
        }
        catch (Exception ex)
        {
            ((Label) error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Query_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            var objPage = new PaperGeneratorClass();
            var dataKey = grd_Query.DataKeys[e.RowIndex];
            if (dataKey != null)
                objPage.iID = int.Parse(dataKey.Value.ToString());

            CoreWebList<PaperGeneratorClass> objPageGList = objPage.fn_GetPaperById();
            if (objPageGList.Count > 0)
            {
                if (File.Exists(Server.MapPath("~/Papers/" + objPageGList[0].strFileName)))
                {
                    File.Delete(Server.MapPath("~/Papers/" + objPageGList[0].strFileName));
                    File.Delete(Server.MapPath("~/Papers/" + objPageGList[0].strFileName + ".cs"));
                }
            }

            string strResponse = objPage.fn_DeletePaper();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label) info.FindControl("mssg")).Text = strResponse;
                info.Visible = true;
            }
            else
            {
                ((Label) error.FindControl("mssg")).Text = strResponse;
                error.Visible = true;
            }

            grd_Query.DataSource = objPage.fn_Get_PaperList();
            grd_Query.DataBind();
        }
        catch (Exception ex)
        {
            ((Label) error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Query_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "showHome")
            {
                int iId = Convert.ToInt32(e.CommandArgument);

                var btnHome = (ImageButton) e.CommandSource;
                var objPaper = new PaperGeneratorClass {iID = iId};
                CoreWebList<PaperGeneratorClass> objPaperList = objPaper.fn_GetPaperById();
                if (objPaperList.Count > 0)
                {
                    if (objPaperList[0].bHome)
                    {
                        btnHome.ImageUrl = "~/admin/images/cross.gif";
                        objPaper.bHome = false;
                    }
                    else
                    {
                        btnHome.ImageUrl = "~/admin/images/Tick.gif";
                        objPaper.bHome = true;
                    }
                    objPaper.fn_ChangePaperStatus();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label) error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            var objPage = new PaperGeneratorClass {strPageTitle = txtSearch.Text};
            ChPaperLists = objPage.fn_GetPaperListByPageTitle();
            grd_Query.DataSource = ChPaperLists.Count > 0 ? ChPaperLists : null;

            grd_Query.DataBind();
        }
        catch (Exception ex)
        {
            ((Label) error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}