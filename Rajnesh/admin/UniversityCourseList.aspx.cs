using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using yo_lib;

public partial class admin_UniversityCourseList : System.Web.UI.Page
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
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                // Bind Data To ListBox                
                if (Request.QueryString["UniversityID"] != null)
                {
                    fn_BindListBox();
                    
                    UniversityListClass objUL = new UniversityListClass();
                    objUL.iID = int.Parse(Request.QueryString["UniversityID"].ToString());

                    CoreWebList<UniversityListClass> objList = objUL.fn_GetUniversityCourseListByUniversityID();                    
                    if (objList.Count > 0)
                    {
                        ArrayList arrayList = objUL.fn_ArrayListGetUniversityCourseListByUniversityID();

                        for (int i = 0; i < lstCourses.Items.Count; i++)
                        {
                            int iCatID = int.Parse(lstCourses.Items[i].Value);

                            if (arrayList.Contains(iCatID))
                            {
                                lstCourses.Items[i].Selected = true;
                            }
                        }
                    }

                    CoreWebList<UniversityListClass> objIMCList = objUL.fn_getUniversityByID();

                    DataTable dt = null;

                    if (objIMCList.Count > 0)
                    {
                        dt = (DataTable)objIMCList;

                        lbl_Title.Text = dt.Rows[0]["strTitle"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    private void fn_BindListBox()
    {
        try
        {
            UniversityListClass objUL = new UniversityListClass();

            lstCourses.DataSource = objUL.fn_GetUniversityCourseList();

            lstCourses.DataTextField = "strCourseName";
            lstCourses.DataValueField = "iCourseID";

            lstCourses.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int j = 0;

            int[] ListBoxChkArray = new int[100];

            for (int i = 0; i < lstCourses.Items.Count; i++)
            {
                if (lstCourses.Items[i].Selected == true)
                {
                    ListBoxChkArray[j] = int.Parse(lstCourses.Items[i].Value.ToString());

                    j++;
                }
            }

            UniversityListClass objICTL = new UniversityListClass();
            objICTL.iID = int.Parse(Request.QueryString["UniversityID"].ToString());
            objICTL.iCourseIDArray = ListBoxChkArray;

            string strResponse = objICTL.fn_SaveUniversityCourseList();

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
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }
}