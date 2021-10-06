using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImpactWorks.FBGraph.Connector;
using ImpactWorks.FBGraph.Core;
using FacebookWebAPI;
using Facebook;
using System.Configuration;
using yo_lib;

public partial class Facebook_Default : System.Web.UI.Page
{
    string strAppKey = "";
    string strSecretKey = "";
    string strCallBackUrl = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        fn_FaceBookConnect();
    }

    protected void fn_FaceBookConnect()
    {
        try
        {
            strAppKey = ConfigurationManager.AppSettings["AppKey"].ToString();
            strSecretKey = ConfigurationManager.AppSettings["SecretKey"].ToString();
            strCallBackUrl = ConfigurationManager.AppSettings["RouteUrl"].ToString();

            //Setting up the facebook object
            ImpactWorks.FBGraph.Connector.Facebook facebook = new ImpactWorks.FBGraph.Connector.Facebook();
            facebook.AppID = strAppKey;
            facebook.CallBackURL = strCallBackUrl; //Please update port number as per your configuration
            facebook.Secret = strSecretKey;

            //Setting up the permissions
            List<FBPermissions> permissions = new List<FBPermissions>() {
 
            FBPermissions.email, //To get user's email address
            FBPermissions.user_about_me, // to read about me
            FBPermissions.user_birthday, // Get DOB
            FBPermissions.user_education_history, //get education
            FBPermissions.user_location, //Location of user
            FBPermissions.user_relationships,//relationship status of user
            FBPermissions.user_work_history,//Workhistory of user
            FBPermissions.user_website,//website entered in fb Profilr
            FBPermissions.user_status,
            FBPermissions.user_events,
            FBPermissions.create_event,
            FBPermissions.read_stream,
            FBPermissions.friends_birthday,
            FBPermissions.friends_photos,
            FBPermissions.friends_about_me,
            FBPermissions.friends_events,
            FBPermissions.offline_access ,
            FBPermissions.publish_stream,
            FBPermissions.read_friendlists
};

            //Pass the permissions object to facebook instance
            facebook.Permissions = permissions;

            if (String.IsNullOrEmpty(Request.QueryString["code"]))
            {
                String authLink = facebook.GetAuthorizationLink();
                Response.Redirect(authLink, false);
            }
            else
            {
                fn_SignUp(facebook);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_SignUp(ImpactWorks.FBGraph.Connector.Facebook facebook)
    {
        try
        {
            //Get the code returned by facebook
            string Code = Request.QueryString["code"];

            //process code for auth token
            facebook.GetAccessToken(Code);

            FBUser currentUser = facebook.GetLoggedInUserInfo();
            if (currentUser != null)
            {
                int iCompetitionUserID = 0;

                CompetitionUserClass objCompeteUser = new CompetitionUserClass();
                objCompeteUser.strEmail = currentUser.email;
                CoreWebList<CompetitionUserClass> objCompeteUserList = objCompeteUser.fn_getCompetitionUserByEmail();
                if (objCompeteUserList.Count == 0)
                {
                    objCompeteUser.strFacebookID = currentUser.id.ToString();
                    objCompeteUser.strName = currentUser.name;
                    objCompeteUser.strEmail = currentUser.email;
                    objCompeteUser.dtDoB = DateTime.Parse(currentUser.birthday.ToString());
                    objCompeteUser.strIpAddrs = HttpContext.Current.Request.UserHostAddress;

                    if (currentUser.gender.ToLower() == "male")
                    {
                        objCompeteUser.bGender = true;
                    }
                    else
                    {
                        objCompeteUser.bGender = false;
                    }

                    iCompetitionUserID = objCompeteUser.fn_save_CompetitionUser();
                }
                else
                {
                    iCompetitionUserID = objCompeteUserList[0].iID;
                }

                if (iCompetitionUserID > 0)
                {
                    Session["CompetitionUser"]= iCompetitionUserID;
                }

                Response.Redirect(VirtualPathUtility.ToAbsolute("~/Eduvidya-Competitions.aspx"), false);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}