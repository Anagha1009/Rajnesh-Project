using System;
using System.Collections.Generic;
using System.Data;
using FredCK.FCKeditorV2;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;
using System.IO;

public partial class admin_Articles : System.Web.UI.Page
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

    private CoreWebList<JobGeneratorClass> ch_jobs_Lists
    {
        get
        {
            if (Cache["ch_jobs_Lists"] != null)
                return (CoreWebList<JobGeneratorClass>)Cache["ch_jobs_Lists"];
            return null;
        }
        set
        {
            Cache["ch_jobs_Lists"] = value;
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

            info.Visible = false;
            error.Visible = false;

          
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
               
                // Bind Data To grid
                JobGeneratorClass objPage = new JobGeneratorClass();
                ch_jobs_Lists = objPage.fn_GetJobList();
                if (ch_jobs_Lists.Count > 0)
                {
                    grd_Query.DataSource = ch_jobs_Lists;
                }
                else
                {
                    grd_Query.DataSource = null;
                }
                grd_Query.DataBind();
               }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("JobGenerator.aspx");
    }

    protected void grd_Query_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Query_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
           grd_Query.PageIndex = e.NewPageIndex;
           grd_Query.DataSource = ch_jobs_Lists;
           grd_Query.DataBind();
           
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Query_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            JobGeneratorClass objPage = new JobGeneratorClass();
            objPage.iID = int.Parse(grd_Query.DataKeys[e.RowIndex].Value.ToString());

            CoreWebList<JobGeneratorClass> objPageList = objPage.fn_GetJobById();
            if (objPageList.Count > 0)
            {
                if (File.Exists(Server.MapPath("~/Careers/" + objPageList[0].strFileName)))
                {
                    File.Delete(Server.MapPath("~/Careers/" + objPageList[0].strFileName));
                    File.Delete(Server.MapPath("~/Careers/" + objPageList[0].strFileName + ".cs"));
                }
            }

            string strResponse = objPage.fn_DeleteJob();

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

            grd_Query.DataSource = objPage.fn_GetJobList();
            grd_Query.DataBind();

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            JobGeneratorClass objPage = new JobGeneratorClass();
            objPage.strPageTitle = txtSearch.Text;
            ch_jobs_Lists = objPage.fn_GetJobBypageTitle();
            if (ch_jobs_Lists.Count > 0)
            {
                grd_Query.DataSource = ch_jobs_Lists;
            }
            else
            {
                grd_Query.DataSource = null;
            }
            grd_Query.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}