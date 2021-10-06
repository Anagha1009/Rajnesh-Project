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
            info.Visible = false;
            error.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                if (Request.QueryString["InstituteID"] != null)
                {
                    fn_getEntranceExamList();
                    fn_BindRecords();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void fn_BindRecords()
	{
		try
		{
			InstituteExamClass objInstituteExam = new InstituteExamClass();
			objInstituteExam.iInstituteID = int.Parse(Request.QueryString["InstituteID"].ToString());
			CoreWebList<InstituteExamClass> objInstituteExamList = objInstituteExam.fn_getInstituteExamByInstituteID();
			if (objInstituteExamList.Count > 0)
			{
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i < objInstituteExamList.Count; i++)
				{
					arrayList.Add(objInstituteExamList[i].iExamID);
				}
				for (int i = 0; i < ListBox_Records.Items.Count; i++)
				{
					int iRecordId = int.Parse(ListBox_Records.Items[i].Value);
					if (arrayList.Contains(iRecordId))
					{
						ListBox_Records.Items[i].Selected = true;
					}
				}
			}
			InstituteClass objInstitute = new InstituteClass();
			objInstitute.iID = int.Parse(Request.QueryString["InstituteID"].ToString());
			CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByID();
			if (objInstituteList.Count > 0)
			{
				ltl_Title.Text = objInstituteList[0].strTitle;
			}
		}
		catch (Exception ex)
		{
			((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
			error.Visible = true;
		}
	}

	protected void fn_getEntranceExamList()
	{
		try
		{
			EntranceExamClass objEntranceExam = new EntranceExamClass();
			ListBox_Records.DataSource = objEntranceExam.fn_getEntranceExamList();
			ListBox_Records.DataTextField = "strTitle";
			ListBox_Records.DataValueField = "iID";
			ListBox_Records.DataBind();
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
			string strResponse = "";
			InstituteExamClass objInstituteExam = new InstituteExamClass();
			objInstituteExam.iInstituteID = int.Parse(Request.QueryString["InstituteID"].ToString());
			strResponse = objInstituteExam.fn_deleteInstituteExamByInstituteID();
			for (int i = 0; i < ListBox_Records.Items.Count; i++)
			{
				if (ListBox_Records.Items[i].Selected == true)
				{
					objInstituteExam.iExamID = int.Parse(ListBox_Records.Items[i].Value.ToString());
					strResponse = objInstituteExam.fn_saveInstituteExam();
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
