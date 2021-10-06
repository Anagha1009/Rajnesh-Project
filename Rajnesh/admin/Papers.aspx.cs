using System;
using FredCK.FCKeditorV2;
using System.Web.UI.WebControls;
using yo_lib;

public partial class admin_Placement : System.Web.UI.Page
{
    private CoreWebList<PaperClass> ChPaperslist
    {
        get
        {
            if (Cache["ch_Paperslist"] != null)
                return (CoreWebList<PaperClass>)Cache["ch_Paperslist"];
            return null;
        }
        set
        {
            Cache["ch_Paperslist"] = value;
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
                // Bind Data To grid
                var objPaper = new PaperClass();

                ChPaperslist = objPaper.fn_GetPaperList();

                grdPapers.DataSource = ChPaperslist.Count > 0 ? ChPaperslist : null;
                grdPapers.DataBind();

                if (grdPapers.SelectedIndex < 0)
                {
                    dvPapers.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grdPapers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
           grdPapers.PageIndex = e.NewPageIndex;
                grdPapers.DataSource = ChPaperslist;
                grdPapers.DataBind();
           
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grdPapers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            var objIc = new PaperClass();
            var dataKey = grdPapers.DataKeys[e.RowIndex];
            if (dataKey != null)
                objIc.iID = int.Parse(dataKey.Value.ToString());

            string strResponse = objIc.fn_Deletepaper();

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

            grdPapers.DataSource = objIc.fn_GetPaperList();
            grdPapers.DataBind();

            dvPapers.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grdPapers_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grdPapers.SelectedIndex < 0)
            {
                // Insert Mode
                dvPapers.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dvPapers.ChangeMode(DetailsViewMode.Edit);

                var objIc = new PaperClass();
                if (grdPapers.SelectedDataKey != null)
                    objIc.iID = int.Parse(grdPapers.SelectedDataKey.Value.ToString());
                dvPapers.DataSource = objIc.fn_GetPaperByID();
                dvPapers.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dvPapers_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            var txtTitle = (TextBox)dvPapers.FindControl("txtTitle");
            var ddlCompany = (DropDownList)dvPapers.FindControl("ddlCompany");
            var ddlCategory = (DropDownList)dvPapers.FindControl("ddlCategory");
            var fckDesc = (FCKeditor)dvPapers.FindControl("fckDesc");
            
            var objPapers = new PaperClass
            {
                strTitle = txtTitle.Text,
                strCompany = ddlCompany.SelectedItem.Text,
                strDescription = fckDesc.Value,
                strCategory = ddlCategory.SelectedValue
            };

            string strResponse = objPapers.fn_SavePaper();

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
            grdPapers.DataSource = objPapers.fn_GetPaperList();
            grdPapers.DataBind();

            // reset fields
            txtTitle.Text = "";
            ddlCompany.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;
            fckDesc.Value = "";
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dvPapers_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            var txtTitle = (TextBox)dvPapers.FindControl("txtTitle");
            var ddlCompany = (DropDownList)dvPapers.FindControl("ddlCompany");
            var fckDesc = (FCKeditor)dvPapers.FindControl("fckDesc");
            var ddlCategory = (DropDownList)dvPapers.FindControl("ddlCategory");

            var objpapers = new PaperClass
            {
                strTitle = txtTitle.Text,
                strCompany = ddlCompany.SelectedItem.Text,
                strDescription = fckDesc.Value,
                strCategory = ddlCategory.SelectedValue,
                iID = int.Parse(dvPapers.DataKey.Value.ToString())
            };

            string strResponse = objpapers.fn_EditPaper();

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

            dvPapers.ChangeMode(DetailsViewMode.ReadOnly);

            if (grdPapers.SelectedDataKey != null)
                objpapers.iID = int.Parse(grdPapers.SelectedDataKey.Value.ToString());

            dvPapers.DataSource = objpapers.fn_GetPaperByID();
            dvPapers.DataBind();

            // Bind Data To grid            
            grdPapers.DataSource = objpapers.fn_GetPaperList();
            grdPapers.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dvPapers_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dvPapers.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dvPapers.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dvPapers.ChangeMode(e.NewMode);

                if (grdPapers.SelectedIndex >= 0)
                {
                    if (grdPapers.SelectedDataKey != null)
                    {
                        var objIc = new PaperClass {iID = int.Parse(grdPapers.SelectedDataKey.Value.ToString())};

                        dvPapers.DataSource = objIc.fn_GetPaperByID();
                    }
                    dvPapers.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dvPapers_DataBound(object sender, EventArgs e)
    {
        try
        {
            var ddlCompany = (DropDownList)dvPapers.FindControl("ddlCompany");
            var ddlCategory = (DropDownList)dvPapers.FindControl("ddlCategory");
            var objPaper = new PaperClass();

            if (dvPapers.CurrentMode == DetailsViewMode.Insert)
            {
                fn_BindCompanyDDL();
                fn_BindCategory();
            }

            if (dvPapers.CurrentMode == DetailsViewMode.Edit)
            {
                if (grdPapers.SelectedDataKey != null)
                    objPaper.iID = int.Parse(grdPapers.SelectedDataKey.Value.ToString());
                CoreWebList<PaperClass> objList = objPaper.fn_GetPaperByID();
                if (objList.Count > 0)
                {
                    fn_BindCompanyDDL();
                    fn_BindCategory();
                    ddlCompany.SelectedValue = objList[0].strCompany;
                    ddlCategory.SelectedValue = objList[0].strCategory;
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void fn_BindCompanyDDL()
    {
        try
        {
            var ddlCompany = (DropDownList)dvPapers.FindControl("ddlCompany");
            if (ddlCompany != null)
            {
                var objCm = new JobCompanyClass();
                ddlCompany.DataSource = objCm.fn_GetJobCompanyList();
                ddlCompany.DataTextField = "strJobCompanyName";
                ddlCompany.DataValueField = "strJobCompanyName";
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void fn_BindCategory()
    {
        try
        {
            var ddlCategory = (DropDownList)dvPapers.FindControl("ddlCategory");
            if (ddlCategory != null)
            {
                var objCm = new JobCategoryClass();
                ddlCategory.DataSource = objCm.fn_GetJobCategoryList();
                ddlCategory.DataTextField = "strJobCategoryName";
                ddlCategory.DataValueField = "iID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("All", "0"));
            }
        }
        catch (Exception ex)
        {
            Response.Write("ERROR : " + ex.Message);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            var objPaper = new PaperClass {strTitle = txtSearch.Text};
            ChPaperslist = objPaper.fn_GetPaperListByPageTitle();
            grdPapers.DataSource = ChPaperslist.Count > 0 ? ChPaperslist : null;
            grdPapers.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
}