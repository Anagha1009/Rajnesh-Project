using System;
using System.Collections.Generic;
using System.Data;
using FredCK.FCKeditorV2;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class admin_Placement : System.Web.UI.Page
{

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
                PlacementPaperClass objPaper = new PlacementPaperClass();

                CoreWebList<PlacementPaperClass> objPaperList = objPaper.fn_GetPaperList();

                if (objPaperList.Count > 0)
                {
                    grdPapers.DataSource = objPaperList;
                    grdPapers.DataBind();
                }

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
            PlacementPaperClass objPaper = new PlacementPaperClass();
            CoreWebList<PlacementPaperClass> objPaperList = objPaper.fn_GetPaperList();

            if (objPaperList.Count > 0)
            {
                grdPapers.PageIndex = e.NewPageIndex;
                grdPapers.DataSource = objPaperList;
                grdPapers.DataBind();
            }
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
            PlacementPaperClass objIC = new PlacementPaperClass();
            objIC.iID = int.Parse(grdPapers.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objIC.fn_Deletepaper();

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

            grdPapers.DataSource = objIC.fn_GetPaperList();
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

                PlacementPaperClass objIC = new PlacementPaperClass();
                objIC.iID = int.Parse(grdPapers.SelectedDataKey.Value.ToString());
                
                dvPapers.DataSource = objIC.fn_GetPaperByID();
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
            TextBox txtCompanyName = (TextBox)dvPapers.FindControl("txtCompanyName");
            FCKeditor fckDesc = (FCKeditor)dvPapers.FindControl("fckDesc");
            
            PlacementPaperClass objPapers = new PlacementPaperClass();

            objPapers.strCompanyName = txtCompanyName.Text;
            objPapers.strDescription = fckDesc.Value;
            objPapers.strSubmittedBy = "InfiniteCourses Admin";

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
            txtCompanyName.Text = "";
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
            TextBox txtCompanyName = (TextBox)dvPapers.FindControl("txtCompanyName");
            FCKeditor fckDesc = (FCKeditor)dvPapers.FindControl("fckDesc");

            PlacementPaperClass objpapers = new PlacementPaperClass();
            objpapers.strCompanyName = txtCompanyName.Text;
            objpapers.strDescription = fckDesc.Value;
            objpapers.iID = int.Parse(dvPapers.DataKey.Value.ToString());

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
                    PlacementPaperClass objIC = new PlacementPaperClass();
                    objIC.iID = int.Parse(grdPapers.SelectedDataKey.Value.ToString());

                    dvPapers.DataSource = objIC.fn_GetPaperByID();
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
}