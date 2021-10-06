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

public partial class admin_InstituteCategoryList : System.Web.UI.Page
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
                if (Request.QueryString["InstID"] != null)
                {
                    fn_getInstituteCategory();
                    InstituteCategoryListClass objCM = new InstituteCategoryListClass();
                    objCM.iInstID = int.Parse(Request.QueryString["InstID"].ToString());
                    CoreWebList<InstituteCategoryListClass> objList = objCM.fn_getInstCategoryListByInstID();                    if (objList.Count > 0)
                    {                                        
                        ArrayList arrayList = objCM.fn_getInstCategoryListBy_InstID();
                        for (int i = 0; i < ListBox_Category.Items.Count; i++)
                        {
                            int iCatID = int.Parse(ListBox_Category.Items[i].Value);
                            if (arrayList.Contains(iCatID))
                            {
                                ListBox_Category.Items[i].Selected = true;
                            }
                        }                                         
                    }
                    InstituteClass objIMC = new InstituteClass();
                    objIMC.iID = int.Parse(Request.QueryString["InstID"].ToString());
                    CoreWebList<InstituteClass> objIMCList = objIMC.fn_getInstituteByID();
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

    private void fn_getInstituteCategory()
    {
        InstituteCategoryClass objCLC = new InstituteCategoryClass();
        ListBox_Category.DataSource = objCLC.fn_getCategoryList();
        ListBox_Category.DataTextField = "strCategoryTitle";
        ListBox_Category.DataValueField = "iID";
        ListBox_Category.DataBind();      
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int j = 0;
            int[] ListBoxChkArray = new int[100];
            for (int i = 0; i < ListBox_Category.Items.Count; i++)
            {
                if (ListBox_Category.Items[i].Selected == true)
                {
                    ListBoxChkArray[j] = int.Parse(ListBox_Category.Items[i].Value.ToString());
                    j++;
                }
            }
            InstituteCategoryListClass objICTL = new InstituteCategoryListClass();
            objICTL.iCatIDArray = ListBoxChkArray;
            objICTL.iInstID = int.Parse(Request.QueryString["InstID"].ToString());
            string strResponse = objICTL.fn_saveInstCategoryList();
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
