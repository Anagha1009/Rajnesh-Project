using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Text;
using System.IO;

public partial class admin_ControlPanel : System.Web.UI.Page
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

    int iStateID = 0;
    
    private CoreWebList<CityClass> chCityList
    {
        get
        {
            if (Cache["chCityList"] != null)
                return (CoreWebList<CityClass>)Cache["chCityList"];
            return null;
        }
        set
        {
            Cache["chCityList"] = value;
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
                Response.Redirect("Login.aspx?flag=1");
            }

            if (Request.QueryString["StateID"] != null)
            {
                iStateID = int.Parse(Request.QueryString["StateID"].ToString());
            }
            else
            {
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/admin/States.aspx"));
            }

            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;

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
            CityClass objCity = new CityClass();
            objCity.iStateID = iStateID;
            chCityList = objCity.fn_getCityByStateID();
            if (chCityList.Count > 0)
            {
                grd_Records.DataSource = chCityList;
            }
            else
            {
                grd_Records.DataSource = null;
            }
            grd_Records.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void grd_Records_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Records.PageIndex = e.NewPageIndex;
            grd_Records.DataSource = chCityList;
            grd_Records.DataBind();
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
            CityClass objCity = new CityClass();
            objCity.iID = int.Parse(grd_Records.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objCity.fn_deleteCity();

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
                // Insert Mode
                dv_Records.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_Records.ChangeMode(DetailsViewMode.Edit);

                CityClass objCity = new CityClass();
                objCity.iID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());
                
                dv_Records.DataSource = objCity.fn_getCityByID();
                dv_Records.DataBind();

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
            // Bind Data To grid            
            CityClass objCity = new CityClass();

            DataTable dt = (DataTable)chCityList;
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

            grd_Records.DataSource = dv;
            grd_Records.DataBind();
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
            TextBox txtDesc = (TextBox)dv_Records.FindControl("txtDesc");
            FileUpload fu_Photo = (FileUpload)dv_Records.FindControl("fu_Photo");
            
            CityClass objCity = new CityClass();
            objCity.iStateID = iStateID;
            objCity.strTitle = txtTitle.Text;
            objCity.strDesc = txtDesc.Text;

            if (fu_Photo.HasFile)
            {
                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fu_Photo.FileName);
                string strDocPath = Server.MapPath("~/admin/Upload/City_photos/" + strRanFileName);
                fu_Photo.SaveAs(strDocPath);
                objCity.strPhoto = strRanFileName;
            }

            string strResponse = objCity.fn_saveCity();

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
            fn_BindRecords();

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

    protected void dv_Records_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_Records.FindControl("txtTitle");
            TextBox txtDesc = (TextBox)dv_Records.FindControl("txtDesc");
            FileUpload fu_Photo = (FileUpload)dv_Records.FindControl("fu_Photo");

            CityClass objCity = new CityClass();
            objCity.iID = int.Parse(dv_Records.DataKey.Value.ToString());
            objCity.iStateID = iStateID;
            objCity.strTitle = txtTitle.Text;
            objCity.strDesc = txtDesc.Text;
            
            CityClass oCity = new CityClass();
            oCity.iID = int.Parse(dv_Records.DataKey.Value.ToString());
            CoreWebList<CityClass> oCityList = oCity.fn_getCityByID();
            if (oCityList.Count > 0)
            {
                if (fu_Photo.HasFile)
                {
                    if (File.Exists(MapPath("~/admin/Upload/City_photos/" + oCityList[0].strPhoto)))
                    {
                        File.Delete((MapPath("~/admin/Upload/City_photos/" + oCityList[0].strPhoto)));
                    }

                    cls_common objCFC = new cls_common();
                    string strRanFileName = objCFC.file_name(fu_Photo.FileName);
                    string strDocPath = Server.MapPath("~/admin/Upload/City_photos/" + strRanFileName);
                    fu_Photo.SaveAs(strDocPath);
                    objCity.strPhoto = strRanFileName;
                }
                else
                {
                    objCity.strPhoto = oCityList[0].strPhoto;
                }
            }
            
            string strResponse = objCity.fn_editCity();

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

            dv_Records.ChangeMode(DetailsViewMode.ReadOnly);

            objCity.iID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());

            dv_Records.DataSource = objCity.fn_getCityByID();
            dv_Records.DataBind();

            // Bind Data To grid            
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
                    CityClass objCity = new CityClass();
                    objCity.iID = int.Parse(grd_Records.SelectedDataKey.Value.ToString());

                    dv_Records.DataSource = objCity.fn_getCityByID();
                    dv_Records.DataBind();
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
            CityClass objCity = new CityClass();
            objCity.strTitle = txtSearch.Text;
            chCityList = objCity.fn_getCityByKeys();

            if (chCityList.Count > 0)
            {
                grd_Records.DataSource = chCityList;
                grd_Records.DataBind();
            }
            else
            {
                grd_Records.DataSource = null;
                grd_Records.DataBind();
            }

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}