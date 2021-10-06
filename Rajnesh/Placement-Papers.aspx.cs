using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class Jobs_in_India : Page
{
    private CoreWebList<PaperClass> ChPaperList
    {
        get
        {
            if (Cache["chPaperList"] != null)
                return (CoreWebList<PaperClass>) Cache["chPaperList"];
            return null;
        }
        set { Cache["chPaperList"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                var objpapers = new PaperGeneratorClass();
                CoreWebList<PaperGeneratorClass> objpaperList = objpapers.fn_Get_Placement_Paper_List();
                if (objpaperList.Count > 0)
                {
                    CPager.DataSource = objpaperList;
                    CPager.BindToControl = dl_Papers;
                    CPager.SecondPageHolderId = PagerDiv.UniqueID;
                    CPager.DataBind();
                    dl_Papers.DataSource = CPager.DataSourcePaged;
                    dl_Papers.DataBind();
                }

                var objJob = new PaperClass();
                ChPaperList = objJob.fn_GetPaperList();
                grd_papers.DataSource = ChPaperList.Count > 0 ? ChPaperList : null;
                grd_papers.DataBind();
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
            grd_papers.PageIndex = e.NewPageIndex;
            grd_papers.DataSource = ChPaperList;
            grd_papers.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}