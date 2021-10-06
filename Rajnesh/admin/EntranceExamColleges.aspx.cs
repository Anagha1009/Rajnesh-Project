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
                if (Request.QueryString["ExamID"] != null)
                {
                    fn_BindInstitutes();

                    EntranceCollegeClass objEntrance = new EntranceCollegeClass();
                    objEntrance.iExamID = int.Parse(Request.QueryString["ExamID"].ToString());
                    CoreWebList<EntranceCollegeClass> objEntranceList = objEntrance.fn_getEntranceCollegeByExamID();
                    if (objEntranceList.Count > 0)
                    {
                        ArrayList arrayList = new ArrayList();
                        for (int i = 0; i < objEntranceList.Count; i++)
                        {
                            arrayList.Add(objEntranceList[i].iCollegeID);
                        }

                        for (int i = 0; i < ListBox_Institute.Items.Count; i++)
                        {
                            int iCatID = int.Parse(ListBox_Institute.Items[i].Value);
                            if (arrayList.Contains(iCatID))
                            {
                                ListBox_Institute.Items[i].Selected = true;
                            }
                        }                                         
                    }

                    EntranceExamClass objExam = new EntranceExamClass();
                    objExam.iID = int.Parse(Request.QueryString["ExamID"].ToString());
                    CoreWebList<EntranceExamClass> objExamList = objExam.fn_getEntranceExamByID();
                    if (objExamList.Count > 0)
                    {
                        lbl_Title.Text = objExamList[0].strTitle;
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

    private void fn_BindInstitutes()
    {
        try
        {
            InstituteClass objInstitute = new InstituteClass();
            ListBox_Institute.DataSource = objInstitute.fn_getInstituteList();
            ListBox_Institute.DataTextField = "strTitle";
            ListBox_Institute.DataValueField = "iID";
            ListBox_Institute.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strResponse = "";
            EntranceCollegeClass objHotel = new EntranceCollegeClass();
            objHotel.iExamID = int.Parse(Request.QueryString["ExamID"].ToString());

            strResponse = objHotel.fn_deleteEntranceCollegeByExamID();

            for (int i = 0; i < ListBox_Institute.Items.Count; i++)
            {
                if (ListBox_Institute.Items[i].Selected == true)
                {
                    objHotel.iCollegeID = int.Parse(ListBox_Institute.Items[i].Value.ToString());
                    strResponse = objHotel.fn_saveEntranceCollege();
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
