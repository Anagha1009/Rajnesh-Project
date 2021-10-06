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

public partial class admin_ControlPanel : System.Web.UI.Page
{    

    #region "view state methods for checking the user refresh here"

    private bool _refreshState;
    private bool _isRefresh;

    public bool IsRefresh
    {
        get
        {
            return _isRefresh;
        }
    }

    protected override void LoadViewState(object savedState)
    {
        object[] allStates = (object[])savedState;
        base.LoadViewState(allStates[0]);
        _refreshState = (bool)allStates[1];
        if (Session["__ISREFRESH"] != null)
        {
            _isRefresh = _refreshState == (bool)Session["__ISREFRESH"];
        }
        else
        {
            // Response.Redirect("Category.aspx");
        }
    }

    protected override object SaveViewState()
    {
        Session["__ISREFRESH"] = _refreshState;
        object[] allStates = new object[2];
        allStates[0] = base.SaveViewState();
        allStates[1] = !_refreshState;
        return allStates;
    }
    #endregion   

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
                if (Request.QueryString["SchoolID"] != null)
                {
                    fn_BindSchoolCategory();

                    SchoolCategoryListClass objSchoolCategory = new SchoolCategoryListClass();
                    objSchoolCategory.iSchoolID = int.Parse(Request.QueryString["SchoolID"].ToString());
                    CoreWebList<SchoolCategoryListClass> objSchoolCategoryList = objSchoolCategory.fn_getSchoolCategoryListBySchoolID();
                    if (objSchoolCategoryList.Count > 0)
                    {
                        ArrayList arrayList = new ArrayList();
                        for (int i = 0; i < objSchoolCategoryList.Count; i++)
                        {
                            arrayList.Add(objSchoolCategoryList[i].iCategoryID);
                        }

                        for (int i = 0; i < ListBox_Category.Items.Count; i++)
                        {
                            int iCatID = int.Parse(ListBox_Category.Items[i].Value);
                            if (arrayList.Contains(iCatID))
                            {
                                ListBox_Category.Items[i].Selected = true;
                            }
                        }                                         
                    }

                    SchoolClass objSchool = new SchoolClass();
                    objSchool.iID = int.Parse(Request.QueryString["SchoolID"].ToString());
                    CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolByID();
                    if (objSchoolList.Count > 0)
                    {
                        lbl_Title.Text = objSchoolList[0].strTitle;
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

    private void fn_BindSchoolCategory()
    {
        SchoolCategoryClass objSchoolCategory = new SchoolCategoryClass();
        ListBox_Category.DataSource = objSchoolCategory.fn_getSchoolCategoryList();
        ListBox_Category.DataTextField = "strTitle";
        ListBox_Category.DataValueField = "iID";
        ListBox_Category.DataBind();      
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strResponse = "";
            SchoolCategoryListClass objSchoolCategory = new SchoolCategoryListClass();
            objSchoolCategory.iSchoolID = int.Parse(Request.QueryString["SchoolID"].ToString());

            strResponse = objSchoolCategory.fn_deleteSchoolCategoryBySchoolID();

            for (int i = 0; i < ListBox_Category.Items.Count; i++)
            {
                if (ListBox_Category.Items[i].Selected == true)
                {
                    objSchoolCategory.iCategoryID = int.Parse(ListBox_Category.Items[i].Value.ToString());
                    strResponse = objSchoolCategory.fn_saveSchoolCategoryList();
                }
            }

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
