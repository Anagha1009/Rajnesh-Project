using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using yo_lib;

public partial class City_AuthorDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (RouteData.Values["Author"] != null && RouteData.Values["AuthorID"] != null)
                {
                    AuthorClass objAuthor = new AuthorClass();
                    objAuthor.iID = int.Parse(RouteData.Values["AuthorID"].ToString());
                    CoreWebList<AuthorClass> objAuthorList = objAuthor.fn_getAuthorByID();
                    if (objAuthorList.Count > 0)
                    {
                        string strTitle = objAuthorList[0].strName;

                        ltl_Title.Text = strTitle;
                        ltl_Details.Text = objAuthorList[0].strDetails;

                        ltl_Email.Text = "<b>Email : </b>" + objAuthorList[0].strEmail;
                        ltl_Connect.Text = "<b><img src='https://www.eduvidya.com/images/Google_plus.png' alt='Google Plus' align='middle'  style='height: auto !important;   width: auto !important; border:none;'> </b><a href='" + objAuthorList[0].strConnectUrl + "' target='_blank' rel='nofollow'>" + objAuthorList[0].strConnectUrl + "</a>";

                        img_Photo.Src = "https://www.eduvidya.com/files/Author/" + objAuthorList[0].strPhoto;
                        img_Photo.Alt = strTitle;

                        string strMetaTitle = strTitle + " - Author of Eduvidya.com ";
                        string strMetaDesc = strTitle + " - Author of Eduvidya.com ";
                        string strMetaKeys = strTitle + " - Author of Eduvidya.com ";

                        ltl_metaTitle.Text = "<title>" + strMetaTitle.ToUpper() + "</title>";
                        ltl_metaDesc.Text = "<meta name=\"Description\" content=\"" + strMetaDesc + "\" />";
                        ltl_metaKeys.Text = "<meta name=\"keywords\" content=\"" + strMetaKeys + "\" />";

                        Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
                        ltl_bredcrumbs.Text = "<a href='https://www.eduvidya.com/'>Home</a><a href='https://www.eduvidya.com/Authors.aspx'>Authors</a>" + strTitle;


                        HtmlControl dynamicid = (HtmlControl)Master.FindControl("dynamicid");
                        dynamicid.ID = "inner-list-page";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + ex.StackTrace);
            }
        }
    }
}