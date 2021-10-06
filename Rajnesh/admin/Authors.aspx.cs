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

public partial class admin_Author : System.Web.UI.Page
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
            BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;Authors";

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
            AuthorClass objAuthor = new AuthorClass();
			CoreWebList<AuthorClass> objAuthorList = objAuthor.fn_getAuthorList();
			if (objAuthorList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objAuthorList;
				grd_Records.DataSource = objAuthorList;
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
            AuthorClass objAuthor = new AuthorClass();
			objAuthor.iID = iRecordID;
			CoreWebList<AuthorClass> objAuthorList = objAuthor.fn_getAuthorByID();
			if (objAuthorList.Count > 0)
			{
				dv_Records.DataSource = objAuthorList;
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
            AuthorClass objAuthor = new AuthorClass();
			objAuthor.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());
			CoreWebList<AuthorClass> objAuthorList = objAuthor.fn_getAuthorByID();
			if (objAuthorList.Count > 0)
			{
				if (File.Exists(MapPath("~/files/Author/" + objAuthorList[0].strPhoto)))
				{
					File.Delete((MapPath("~/files/Author/" + objAuthorList[0].strPhoto)));
				}
			}

			string strResponse = objAuthor.fn_deleteAuthor();

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
			TextBox txtName = (TextBox)dv_Records.FindControl("txtName");
			TextBox txtEmail = (TextBox)dv_Records.FindControl("txtEmail");
			TextBox txtConnectUrl = (TextBox)dv_Records.FindControl("txtConnectUrl");
			TextBox txtDetails = (TextBox)dv_Records.FindControl("txtDetails");
			FileUpload fu_Photo = (FileUpload)dv_Records.FindControl("fu_Photo");

			AuthorClass objAuthor = new AuthorClass();
			objAuthor.strName = txtName.Text;
			objAuthor.strEmail = txtEmail.Text;
			objAuthor.strConnectUrl = txtConnectUrl.Text;
			objAuthor.strDetails = txtDetails.Text;

			if (fu_Photo.HasFile)
			{
				cls_common objCFC = new cls_common();
				string strRanFileName = objCFC.file_name(fu_Photo.FileName);
				string strDocPath = Server.MapPath("~/files/Author/" + strRanFileName);
				fu_Photo.SaveAs(strDocPath);
				objAuthor.strPhoto = strRanFileName;
			}

			string strResponse = objAuthor.fn_saveAuthor();

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

			txtName.Text = "";
			txtEmail.Text = "";
			txtConnectUrl.Text = "";
			txtDetails.Text = "";

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
			TextBox txtName = (TextBox)dv_Records.FindControl("txtName");
			TextBox txtEmail = (TextBox)dv_Records.FindControl("txtEmail");
			TextBox txtConnectUrl = (TextBox)dv_Records.FindControl("txtConnectUrl");
			TextBox txtDetails = (TextBox)dv_Records.FindControl("txtDetails");
			FileUpload fu_Photo = (FileUpload)dv_Records.FindControl("fu_Photo");
			HiddenField hf_Photo = (HiddenField)dv_Records.FindControl("hf_Photo");

			AuthorClass objAuthor = new AuthorClass();
			objAuthor.iID = int.Parse(dv_Records.DataKey.Value.ToString());
			objAuthor.strName = txtName.Text;
			objAuthor.strEmail = txtEmail.Text;
			objAuthor.strConnectUrl = txtConnectUrl.Text;
			objAuthor.strDetails = txtDetails.Text;

			if (fu_Photo.HasFile)
			{
				AuthorClass oAuthor = new AuthorClass();
				oAuthor.iID = int.Parse(dv_Records.DataKey.Value.ToString());
				CoreWebList<AuthorClass> oAuthorList = oAuthor.fn_getAuthorByID();
				if (oAuthorList.Count > 0)
				{
					if (File.Exists(MapPath("~/files/Author/" + oAuthorList[0].strPhoto)))
					{
						File.Delete((MapPath("~/files/Author/" + oAuthorList[0].strPhoto)));
					}
					cls_common objCFC = new cls_common();
					string strRanFileName = objCFC.file_name(fu_Photo.FileName);
					string strDocPath = Server.MapPath("~/files/Author/" + strRanFileName);
					fu_Photo.SaveAs(strDocPath);
					objAuthor.strPhoto = strRanFileName;
				}	
			}
			else
			{
				objAuthor.strPhoto = hf_Photo.Value;
			}

			string strResponse = objAuthor.fn_editAuthor();

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
            AuthorClass objAuthor = new AuthorClass();
			objAuthor.strName = txtSearch.Text.Trim();
			CoreWebList<AuthorClass> objAuthorList = objAuthor.fn_getAuthorByKeys();
			if (objAuthorList.Count > 0)
			{
				ViewState["dtRecords"] = (DataTable)objAuthorList;
				grd_Records.DataSource = objAuthorList;
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