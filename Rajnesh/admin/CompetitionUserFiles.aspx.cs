using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Text;
using System.IO;

public partial class admin_CompetitionUserFiles : System.Web.UI.Page
{
    int iCompetitionID = 0;
    int iUserID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["CompetitionId"] != null && Request.QueryString["UserId"] != null)
            {
                iCompetitionID = int.Parse(Request.QueryString["CompetitionId"].ToString());
                iUserID = int.Parse(Request.QueryString["UserId"].ToString());

                fn_BindPhotos();

                CompetitionUserClass objCompeteUser = new CompetitionUserClass();
                objCompeteUser.iID = iUserID;
                CoreWebList<CompetitionUserClass> objCompeteUserlist = objCompeteUser.fn_getCompetitionUserByID();
                if (objCompeteUserlist.Count > 0)
                {
                    ltl_User.Text = "Enrty By : " + objCompeteUserlist[0].strName + " | " + objCompeteUserlist[0].strEmail + " | " + objCompeteUserlist[0].strMobile;
                }
            }
            else
            {
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/admin/User.aspx"), true);
            }

            HtmlGenericControl BredCrumbs = (HtmlGenericControl)Master.FindControl("BredCrumbs");
            BredCrumbs.InnerHtml = "<a class='link' href='" + VirtualPathUtility.ToAbsolute("~/admin/") + "'>Home</a> &nbsp; > &nbsp; &nbsp;Competition User Files";
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindPhotos()
    {
        try
        {
            CompetitionFileClass objCompetitonFile = new CompetitionFileClass();
            objCompetitonFile.iCompetitionID = iCompetitionID;
            objCompetitonFile.iUserID = iUserID;
            CoreWebList<CompetitionFileClass> objCompetitonFileList = objCompetitonFile.fn_getCompetitionFileByCompetitionIDUserID();
            if (objCompetitonFileList.Count > 0)
            {
                StringBuilder sbFiles = new StringBuilder();
                


                for (int i = 0; i < objCompetitonFileList.Count; i++)
                {
                    string strFile = VirtualPathUtility.ToAbsolute("~/files/CompetitionFile/" + objCompetitonFileList[i].strFile);
                    
                    string strExtension = Path.GetExtension(objCompetitonFileList[i].strFile).Replace(".", "");
                    if (strExtension == "bmp" || strExtension == "gif" || strExtension == "png" || strExtension == "jpg" || strExtension == "jpeg")
                    {
                        sbFiles.Append("<div class=\"CompeteImageBox\"><a class=\"fancybox\" href='" + strFile + "' data-fancybox-group=\"gallery\" title='" + objCompetitonFileList[i].strTitle + "'><img src='" + strFile + "' alt='" + objCompetitonFileList[i].strTitle + "' /></a></div><div class='clear'></div>");
                    }
                    else
                    {
                        string strPlayer = "Player_" + i;
                        sbFiles.Append("<div id=\"" + strPlayer + "\"></div><div class='clear'></div>");
                        sbFiles.Append("<script type='text/javascript'>");
                        sbFiles.Append("jwplayer(" + strPlayer + ").setup({");
                        sbFiles.Append("'flashplayer': 'http://www.eduvidya.com/JW_Player/player.swf',");
                        sbFiles.Append("'file': '" + strFile + "',");
                        sbFiles.Append("'controlbar': 'bottom',");
                        sbFiles.Append("'width': '571',");
                        sbFiles.Append("'height': '410',");
                        sbFiles.Append("'skin': 'http://www.eduvidya.com/JW_Player/skewd.zip'");
                        sbFiles.Append("});");
                        sbFiles.Append("</script>");
                    }
                }

                ltl_Files.Text = sbFiles.ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}