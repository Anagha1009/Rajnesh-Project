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

public partial class admin_Blogs : System.Web.UI.Page
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
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;
            
            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;Blogs";

            if (!IsPostBack)
            {
                fn_BindRecords();

                if (grd_Records.SelectedIndex < 0)
                {
                    dv_Records.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void fn_BindRecords()
    {
        try
        {
            BlogClass objBlog = new BlogClass();
			CoreWebList<BlogClass> objBlogList = objBlog.fn_getBlogList();
			if (objBlogList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objBlogList;
				grd_Records.DataSource = objBlogList;
			}
			else
			{
				grd_Records.DataSource = null;
			}
			grd_Records.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void fn_BindDetails(int iRecordID)
    {
        try
        {
            BlogClass objBlog = new BlogClass();
			objBlog.iID = iRecordID;
			CoreWebList<BlogClass> objBlogList = objBlog.fn_getBlogByID();
			if (objBlogList.Count > 0)
			{
				dv_Records.DataSource = objBlogList;
				dv_Records.DataBind();
			}
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Records_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (ViewState["dtRecords"] != null)
            {
                DataTable dtRecords = (DataTable)ViewState["dtRecords"];
                grd_Records.PageIndex = e.NewPageIndex;
                grd_Records.DataSource = dtRecords;
                grd_Records.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Records_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            BlogClass objBlog = new BlogClass();
			objBlog.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());
			CoreWebList<BlogClass> objBlogList = objBlog.fn_getBlogByID();
			if (objBlogList.Count > 0)
			{
				if (File.Exists(MapPath("~/files/Blog/" + objBlogList[0].strImage)))
				{
					File.Delete((MapPath("~/files/Blog/" + objBlogList[0].strImage)));
				}
			}

			string strResponse = objBlog.fn_deleteBlog();

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

			fn_BindRecords();
			dv_Records.ChangeMode(DetailsViewMode.Insert);

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Records_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Records.SelectedIndex < 0)
            {
                dv_Records.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Records.ChangeMode(DetailsViewMode.Edit);
                int iRecordID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                fn_BindDetails(iRecordID);

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

    protected void grd_Records_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (ViewState["dtRecords"] != null)
            {
                DataTable dtRecords = (DataTable)ViewState["dtRecords"];
                DataView dv = new DataView(dtRecords);

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

                grd_Records.DataSource = dv;
                grd_Records.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Records_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
			TextBox txtTitle = (TextBox)dv_Records.FindControl("txtTitle");
			TextBox txtDescription = (TextBox)dv_Records.FindControl("txtDescription");
			FileUpload fu_Image = (FileUpload)dv_Records.FindControl("fu_Image");

			BlogClass objBlog = new BlogClass();
			objBlog.strTitle = txtTitle.Text;
			objBlog.strDescription = txtDescription.Text;

			if (fu_Image.HasFile)
			{
				cls_common objCFC = new cls_common();
				string strRanFileName = objCFC.file_name(fu_Image.FileName);
				string strDocPath = Server.MapPath("~/files/Blog/" + strRanFileName);
				fu_Image.SaveAs(strDocPath);
				objBlog.strImage = strRanFileName;
			}

			string strResponse = objBlog.fn_saveBlog();

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

			fn_BindRecords();

			txtTitle.Text = "";
			txtDescription.Text = "";

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Records_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
			TextBox txtTitle = (TextBox)dv_Records.FindControl("txtTitle");
			TextBox txtDescription = (TextBox)dv_Records.FindControl("txtDescription");
			FileUpload fu_Image = (FileUpload)dv_Records.FindControl("fu_Image");
			HiddenField hf_Image = (HiddenField)dv_Records.FindControl("hf_Image");

			BlogClass objBlog = new BlogClass();
			objBlog.iID = int.Parse(dv_Records.DataKey.Value.ToString());
			objBlog.strTitle = txtTitle.Text;
			objBlog.strDescription = txtDescription.Text;

			if (fu_Image.HasFile)
			{
				BlogClass oBlog = new BlogClass();
				oBlog.iID = int.Parse(dv_Records.DataKey.Value.ToString());
				CoreWebList<BlogClass> oBlogList = oBlog.fn_getBlogByID();
				if (oBlogList.Count > 0)
				{
					if (File.Exists(MapPath("~/files/Blog/" + oBlogList[0].strImage)))
					{
						File.Delete((MapPath("~/files/Blog/" + oBlogList[0].strImage)));
					}
					cls_common objCFC = new cls_common();
					string strRanFileName = objCFC.file_name(fu_Image.FileName);
					string strDocPath = Server.MapPath("~/files/Blog/" + strRanFileName);
					fu_Image.SaveAs(strDocPath);
					objBlog.strImage = strRanFileName;
				}	
			}
			else
			{
				objBlog.strImage = hf_Image.Value;
			}

			string strResponse = objBlog.fn_editBlog();

			if (strResponse.StartsWith("SUCCESS"))
			{				((Label)info.FindControl("mssg")).Text = strResponse;
				info.Visible = true;
			}
			else
			{
				((Label)error.FindControl("mssg")).Text = strResponse;
				error.Visible = true;
			}

			dv_Records.ChangeMode(DetailsViewMode.ReadOnly);
			int iRecordID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
			fn_BindDetails(iRecordID);
			fn_BindRecords();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Records_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Records.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Records.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Records.ChangeMode(e.NewMode);

                if (grd_Records.SelectedIndex >= 0)
                {
                    int iRecordID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                    fn_BindDetails(iRecordID);
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
            BlogClass objBlog = new BlogClass();
			objBlog.strTitle = txtSearch.Text.Trim();
			CoreWebList<BlogClass> objBlogList = objBlog.fn_getBlogByKeys();
			if (objBlogList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objBlogList;
				grd_Records.DataSource = objBlogList;
			}
			else
			{
				grd_Records.DataSource = null;
			}
			grd_Records.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    
}