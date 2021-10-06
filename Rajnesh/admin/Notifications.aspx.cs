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

public partial class admin_Notifications : System.Web.UI.Page
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
    
    private CoreWebList<NotificationClass> chNotificationList
    {
        get
        {
            if (Cache["chNotificationList"] != null)
                return (CoreWebList<NotificationClass>)Cache["chNotificationList"];
            return null;
        }
        set
        {
            Cache["chNotificationList"] = value;
        }
    }

    int UniversityID = 0;

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

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;
            
            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='default.aspx'>Home</a> &nbsp; > &nbsp;Notifications";

            if (Request.QueryString["UniversityID"] != null)
            {
                UniversityID=int.Parse(Request.QueryString["UniversityID"].ToString());
            }

            if (!IsPostBack)
            {
                // Bind Data To grid
                NotificationClass objNotification = new NotificationClass();
                objNotification.iUniversityID = UniversityID;
                chNotificationList = objNotification.fn_getNotificationByUniversityID();

                if (chNotificationList.Count > 0)
                {
                    grd_Notifications.DataSource = chNotificationList;
                }
                else
                {
                    grd_Notifications.DataSource = null;
                }
                grd_Notifications.DataBind();

                if (grd_Notifications.SelectedIndex < 0)
                {
                    dv_Notifications.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Notifications_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Notifications.PageIndex = e.NewPageIndex;
            grd_Notifications.DataSource = chNotificationList;
            grd_Notifications.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Notifications_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            NotificationClass objNotification = new NotificationClass();
            objNotification.iID = int.Parse(grd_Notifications.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objNotification.fn_deleteNotification();

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
            objNotification.iUniversityID = UniversityID;
            chNotificationList = objNotification.fn_getNotificationByUniversityID();
            grd_Notifications.DataSource = chNotificationList;
            grd_Notifications.DataBind();

            dv_Notifications.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Notifications_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Notifications.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Notifications.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_Notifications.ChangeMode(DetailsViewMode.Edit);

                NotificationClass objNotification = new NotificationClass();
                objNotification.iID = int.Parse(grd_Notifications.SelectedDataKey.Value.ToString());
                
                dv_Notifications.DataSource = objNotification.fn_getNotificationByID();
                dv_Notifications.DataBind();

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

    protected void grd_Notifications_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            // Bind Data To grid            
            NotificationClass objNotification = new NotificationClass();

            DataTable dt = (DataTable)chNotificationList;
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

            grd_Notifications.DataSource = dv;
            grd_Notifications.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Notifications_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_Notifications.FindControl("txtTitle");
            TextBox txtDescription = (TextBox)dv_Notifications.FindControl("txtDescription");
            TextBox txtUrl = (TextBox)dv_Notifications.FindControl("txtUrl");
            
            NotificationClass objNotification = new NotificationClass();
            objNotification.iUniversityID = UniversityID;
            objNotification.strNotificationTitle = txtTitle.Text;
            objNotification.strNotificationDesc = txtDescription.Text;
            objNotification.strUrl = txtUrl.Text;

            string strResponse = objNotification.fn_saveNotification();

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
            objNotification.iUniversityID = UniversityID;
            chNotificationList = objNotification.fn_getNotificationByUniversityID();
            grd_Notifications.DataSource = chNotificationList;
            grd_Notifications.DataBind();

            // reset fields
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtUrl.Text = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Notifications_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            string strResponse = "";

            TextBox txtTitle = (TextBox)dv_Notifications.FindControl("txtTitle");
            TextBox txtDescription = (TextBox)dv_Notifications.FindControl("txtDescription");
            TextBox txtUrl = (TextBox)dv_Notifications.FindControl("txtUrl");

            NotificationClass objNotification = new NotificationClass();
            objNotification.iID = int.Parse(dv_Notifications.DataKey.Value.ToString());
            objNotification.iUniversityID = UniversityID;
            objNotification.strNotificationTitle = txtTitle.Text;
            objNotification.strNotificationDesc = txtDescription.Text;
            objNotification.strUrl = txtUrl.Text;

            strResponse = objNotification.fn_editNotification();

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

            dv_Notifications.ChangeMode(DetailsViewMode.ReadOnly);

            objNotification.iID = int.Parse(grd_Notifications.SelectedDataKey.Value.ToString());

            dv_Notifications.DataSource = objNotification.fn_getNotificationByID();
            dv_Notifications.DataBind();

            // Bind Data To grid           
            objNotification.iUniversityID = UniversityID;
            chNotificationList = objNotification.fn_getNotificationByUniversityID();
            grd_Notifications.DataSource = chNotificationList;
            grd_Notifications.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Notifications_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Notifications.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Notifications.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Notifications.ChangeMode(e.NewMode);

                if (grd_Notifications.SelectedIndex >= 0)
                {
                    NotificationClass objNotification = new NotificationClass();
                    objNotification.iID = int.Parse(grd_Notifications.SelectedDataKey.Value.ToString());

                    dv_Notifications.DataSource = objNotification.fn_getNotificationByID();
                    dv_Notifications.DataBind();
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
            NotificationClass objNotification = new NotificationClass();
            chNotificationList = objNotification.fn_getNotificationByKeys(txtSearch.Text.Trim());

            if (chNotificationList.Count > 0)
            {
                grd_Notifications.DataSource = chNotificationList;
                grd_Notifications.DataBind();
            }
            else
            {
                grd_Notifications.DataSource = null;
                grd_Notifications.DataBind();
            }

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}