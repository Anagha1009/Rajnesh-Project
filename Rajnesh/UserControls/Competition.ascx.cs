using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using yo_lib;

public partial class UserControls_Register : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                fn_BindCompetition();
                tbl_Competition.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindCompetition()
    {
        try
        {
            CompetitionClass objCompetition = new CompetitionClass();
            CoreWebList<CompetitionClass> objCompetitionList = objCompetition.fn_getRandomCompetitionList();
            if (objCompetitionList.Count > 0)
            {
                Session["CompetitionId"] = objCompetitionList[0].iID;
                ltl_Title.Text = objCompetitionList[0].strTitle;
                ltl_ShortDetails.Text = objCompetitionList[0].strShortDetails;
                img_Compete.Src = VirtualPathUtility.ToAbsolute("~/files/Competition/" + objCompetitionList[0].strPhoto);
                img_Compete.Alt = objCompetitionList[0].strTitle;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                int iCompetitionUserID = 0;

                CompetitionUserClass objCompetitionUser = new CompetitionUserClass();
                objCompetitionUser.strName = txtName.Text.Trim();
                objCompetitionUser.strEmail = txtEmail.Text.Trim();
                objCompetitionUser.strIpAddrs = HttpContext.Current.Request.UserHostAddress;

                CompetitionUserClass objCompeteUser = new CompetitionUserClass();
                objCompeteUser.strEmail = txtEmail.Text.Trim();
                CoreWebList<CompetitionUserClass> objCompeteUserList = objCompeteUser.fn_getCompetitionUserByEmail();
                if (objCompeteUserList.Count == 0)
                {
                    iCompetitionUserID = objCompetitionUser.fn_saveCompetitionUser();
                }
                else
                {
                    iCompetitionUserID = objCompeteUserList[0].iID;
                }

                if (iCompetitionUserID > 0)
                {
                    Session["CompetitionUser"] = iCompetitionUserID;
                }

                Response.Redirect(VirtualPathUtility.ToAbsolute("~/Eduvidya-Competitions.aspx"), false);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }


    protected void btn_EmailConnect_Click(object sender, EventArgs e)
    {
        try
        {
            tbl_Competition.Visible = true;
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "PopUp", "setTimeout('fn_getPopup()',900);", true);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void btn_FacebookConnect_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect(VirtualPathUtility.ToAbsolute("~/Fakebook/"), false);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}