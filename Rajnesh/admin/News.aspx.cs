using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Drawing;

public partial class admin_News : System.Web.UI.Page
{
    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
            {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }

            return (SortDirection)ViewState["sortDirection"];
        }
        set
        {
            ViewState["sortDirection"] = value;
        }
    }

    private CoreWebList<NewsClass> chNewsList
    {
        get
        {
            if (Cache["chNewsList"] != null)
                return (CoreWebList<NewsClass>)Cache["chNewsList"];
            return null;
        }
        set
        {
            Cache["chNewsList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Check login session 
            //If not logged in redirect to admin login page
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx?flag=1", false);
            }

            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;

            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class=link href=default.aspx>Home</a>&nbsp;>&nbsp;News";


            if (!IsPostBack)
            {

                // Bind Data To grid
                NewsClass objNews = new NewsClass();
                chNewsList = objNews.fn_getNewsList();

                if (chNewsList.Count > 0)
                {
                    grd_News.DataSource = chNewsList;
                }
                else
                {
                    grd_News.DataSource = null;
                }
                grd_News.DataBind();

                if (grd_News.SelectedIndex < 0)
                {
                    dv_News.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_News_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_News.PageIndex = e.NewPageIndex;
            grd_News.DataSource = chNewsList;
            grd_News.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_News_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            NewsClass objNews = new NewsClass();
            objNews.iID = int.Parse(grd_News.DataKeys[e.RowIndex].Value.ToString());
            CoreWebList<NewsClass> objNewsList = objNews.fn_getNewsByID();
            if (objNewsList.Count > 0)
            {
                if (File.Exists(MapPath("~/admin/Upload/News/" + objNewsList[0].strPhoto)))
                {
                    File.Delete((MapPath("~/admin/Upload/News/" + objNewsList[0].strPhoto)));
                }
            }

            string strResponse = objNews.fn_deleteNews();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info.FindControl("mssg")).Text = strResponse;
                info.Visible = true;
            }
            else
            {
                ((Label)error.FindControl("mssg")).Text = strResponse;
                error.Visible = true;
            }

            chNewsList = objNews.fn_getNewsList();
            grd_News.DataSource = chNewsList;
            grd_News.DataBind();

            dv_News.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_News_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_News.SelectedIndex < 0)
            {
                // Insert Mode
                dv_News.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_News.ChangeMode(DetailsViewMode.Edit);

                NewsClass objNews = new NewsClass();
                objNews.iID = int.Parse(grd_News.SelectedDataKey.Value.ToString());

                dv_News.DataSource = objNews.fn_getNewsByID();
                dv_News.DataBind();

                #region "Scroll to Details"
                StringBuilder sb = new StringBuilder();
                sb.Append("$('html,body').animate({ scrollTop: $('#ScrollHere').offset().top }, 2000);");
                ClientScript.RegisterStartupScript(this.GetType(), "Scroll", sb.ToString(), true);
                #endregion
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_News_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            NewsClass objNews = new NewsClass();

            DataTable dt = (DataTable)chNewsList;
            DataView dv = new DataView(dt);

            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                dv.Sort = e.SortExpression + " DESC";
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                dv.Sort = e.SortExpression + " ASC";
            }

            grd_News.DataSource = dv;
            grd_News.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_News_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            string strRanFileName = "";
            string strDocPath = "";

            TextBox txtTitle = (TextBox)dv_News.FindControl("txtTitle");
            TextBox txtDesc = (TextBox)dv_News.FindControl("txtDesc");
            FileUpload fu_Image = (FileUpload)dv_News.FindControl("fu_Image");

            NewsClass objNews = new NewsClass();
            objNews.strTitle = txtTitle.Text;
            objNews.strDesc = txtDesc.Text;

            if (fu_Image.HasFile)
            {
                cls_common objCFC = new cls_common();
                strRanFileName = objCFC.file_name(fu_Image.FileName);
                strDocPath = Server.MapPath("~/admin/Upload/News/" + strRanFileName);
                fu_Image.SaveAs(strDocPath);
                objNews.strPhoto = strRanFileName;
            }

            string strResponse = objNews.fn_saveNews();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info_dv.FindControl("mssg")).Text = strResponse;
                info_dv.Visible = true;
            }
            else
            {
                ((Label)error_dv.FindControl("mssg")).Text = strResponse;
                error_dv.Visible = true;
            }

            // Bind Data To grid
            chNewsList = objNews.fn_getNewsList();
            grd_News.DataSource = chNewsList;
            grd_News.DataBind();

            // reset fields
            txtTitle.Text = "";
            txtDesc.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_News_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            string strResponse = "";
            string strRanFileName = "";
            string strDocPath = "";

            TextBox txtTitle = (TextBox)dv_News.FindControl("txtTitle");
            TextBox txtDesc = (TextBox)dv_News.FindControl("txtDesc");

            FileUpload fu_Image = (FileUpload)dv_News.FindControl("fu_Image");
            HiddenField hfImage = (HiddenField)dv_News.FindControl("hfImage");

            NewsClass objNews = new NewsClass();
            int iWebsiteID = int.Parse(dv_News.DataKey.Value.ToString());
            objNews.iID = iWebsiteID;
            objNews.strTitle = txtTitle.Text;
            objNews.strDesc = txtDesc.Text;

            if (fu_Image.HasFile)
            {
                CoreWebList<NewsClass> objNewsList = objNews.fn_getNewsByID();
                if (objNewsList.Count > 0)
                {
                    if (File.Exists(MapPath("~/admin/Upload/News/" + objNewsList[0].strPhoto)))
                    {
                        File.Delete((MapPath("~/admin/Upload/News/" + objNewsList[0].strPhoto)));
                    }
                }

                cls_common objCFC = new cls_common();
                strRanFileName = objCFC.file_name(fu_Image.FileName);
                strDocPath = Server.MapPath("~/admin/Upload/News/" + strRanFileName);
                fu_Image.SaveAs(strDocPath);
                objNews.strPhoto = strRanFileName;
            }
            else
            {
                objNews.strPhoto = hfImage.Value;
                strRanFileName = hfImage.Value;
            }

            strResponse = objNews.fn_editNews();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info_dv.FindControl("mssg")).Text = strResponse;
                info_dv.Visible = true;
            }
            else
            {
                ((Label)error_dv.FindControl("mssg")).Text = strResponse;
                error_dv.Visible = true;
            }

            dv_News.ChangeMode(DetailsViewMode.ReadOnly);

            objNews.iID = int.Parse(grd_News.SelectedDataKey.Value.ToString());

            dv_News.DataSource = objNews.fn_getNewsByID();
            dv_News.DataBind();

            // Bind Data To grid    
            chNewsList = objNews.fn_getNewsList();
            grd_News.DataSource = chNewsList;
            grd_News.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_News_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_News.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_News.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_News.ChangeMode(e.NewMode);

                if (grd_News.SelectedIndex >= 0)
                {
                    NewsClass objNews = new NewsClass();
                    objNews.iID = int.Parse(grd_News.SelectedDataKey.Value.ToString());

                    dv_News.DataSource = objNews.fn_getNewsByID();
                    dv_News.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (txtSearch.Text != "")
            {
                NewsClass objNews = new NewsClass();
                objNews.strTitle = txtSearch.Text.Trim();
                chNewsList = objNews.fn_getNewsByKeys();
                if (chNewsList.Count > 0)
                {
                    grd_News.DataSource = chNewsList;
                }
                else
                {
                    grd_News.DataSource = null;
                }
                grd_News.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}