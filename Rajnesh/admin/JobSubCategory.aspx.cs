using System;
using System.Data;
using FredCK.FCKeditorV2;
using System.Web.UI.WebControls;
using yo_lib;

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

            if (!IsPostBack)
            {
                JobSubCategoryClass objIC = new JobSubCategoryClass();
                objIC.iCategoryID = int.Parse(Request.QueryString["CategoryID"].ToString());
                CoreWebList<JobSubCategoryClass> objICList = objIC.fn_GetJobSubCategoryByCategoryID();

                if (objICList.Count > 0)
                {
                    DataTable dtIC = (DataTable)objICList;
                    grdCategory.DataSource = dtIC;
                }
                else
                {
                    grdCategory.DataSource = null;
                }
                 
                grdCategory.DataBind();
                
                if (grdCategory.SelectedIndex < 0)
                {
                    dvCategory.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + "Line :" + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            JobSubCategoryClass objAC = new JobSubCategoryClass();
            objAC.iCategoryID = int.Parse(Request.QueryString["CategoryID"].ToString());
            grdCategory.PageIndex = e.NewPageIndex;
            grdCategory.DataSource = objAC.fn_GetJobSubCategoryByCategoryID();
            grdCategory.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grdCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            JobSubCategoryClass objIC = new JobSubCategoryClass();
            objIC.iID = int.Parse(grdCategory.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objIC.fn_DeleteJobSubCategory();

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


            JobSubCategoryClass objJobSubCat = new JobSubCategoryClass();
            objJobSubCat.iCategoryID = int.Parse(Request.QueryString["CategoryID"].ToString());
            grdCategory.DataSource = objJobSubCat.fn_GetJobSubCategoryByCategoryID();
            grdCategory.DataBind();

            dvCategory.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grdCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grdCategory.SelectedIndex < 0)
            {
                // Insert Mode
                dvCategory.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dvCategory.ChangeMode(DetailsViewMode.Edit);

                JobSubCategoryClass objIC = new JobSubCategoryClass();
                objIC.iID = int.Parse(grdCategory.SelectedDataKey.Value.ToString());
                
                dvCategory.DataSource = objIC.fn_GetJobSubCategoryByID();
                dvCategory.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }


    protected void dvCategory_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dvCategory.FindControl("txtTitle");
            FCKeditor fckDesc = (FCKeditor)dvCategory.FindControl("fckDesc");
            
            JobSubCategoryClass objIC = new JobSubCategoryClass();

            objIC.iCategoryID = int.Parse(Request.QueryString["CategoryID"].ToString());
            objIC.strJobSubCategoryName = txtTitle.Text;
            objIC.strJobSubCategoryDesc = fckDesc.Value;

            string strResponse = objIC.fn_SaveJobSubCategory();

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
            grdCategory.DataSource = objIC.fn_GetJobSubCategoryByCategoryID();
            grdCategory.DataBind();

            // reset fields
            txtTitle.Text = "";
            fckDesc.Value = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dvCategory_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dvCategory.FindControl("txtTitle");
            FCKeditor fckDesc = (FCKeditor)dvCategory.FindControl("fckDesc");

            JobSubCategoryClass objIC = new JobSubCategoryClass();
            objIC.iCategoryID = int.Parse(Request.QueryString["CategoryID"].ToString());
            objIC.strJobSubCategoryName = txtTitle.Text;
            objIC.strJobSubCategoryDesc = fckDesc.Value;
            
            objIC.iID = int.Parse(dvCategory.DataKey.Value.ToString());

            string strResponse = objIC.fn_EditJobSubCategory();

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

            dvCategory.ChangeMode(DetailsViewMode.ReadOnly);

            objIC.iID = int.Parse(grdCategory.SelectedDataKey.Value.ToString());

            dvCategory.DataSource = objIC.fn_GetJobSubCategoryByID();
            dvCategory.DataBind();

            // Bind Data To grid            
            grdCategory.DataSource = objIC.fn_GetJobSubCategoryByCategoryID();
            grdCategory.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dvCategory_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dvCategory.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dvCategory.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dvCategory.ChangeMode(e.NewMode);

                if (grdCategory.SelectedIndex >= 0)
                {
                    JobSubCategoryClass objIC = new JobSubCategoryClass();
                    objIC.iID = int.Parse(grdCategory.SelectedDataKey.Value.ToString());

                    dvCategory.DataSource = objIC.fn_GetJobSubCategoryByID();
                    dvCategory.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
  
}