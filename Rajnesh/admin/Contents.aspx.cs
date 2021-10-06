using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using yo_lib;
using System.Data;

public partial class admin_ContentManagement : System.Web.UI.Page
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

    }
    protected void lbtnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            ContentMasterClass objCM = new ContentMasterClass();
            objCM.strContentType = ddlContentSection.SelectedValue;
            objCM.strContentText = txtContent.Text;
            string strResponse = string.Empty;
            if (!IsRefresh)
            {
                CoreWebList<ContentMasterClass> objList = objCM.fn_getContent();
                if (objList.Count == 0)
                {
                    strResponse = objCM.fn_saveContent();
                }
                else if (objList.Count == 1)
                {
                    strResponse = objCM.fn_editContent();
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
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
    protected void ddlContentSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        ContentMasterClass objCM = new ContentMasterClass();
        objCM.strContentType = ddlContentSection.SelectedValue;
        if (ddlContentSection.SelectedIndex > 0)
        {           
            CoreWebList<ContentMasterClass> objList = objCM.fn_getContent();
            DataTable dt = null;
            if (objList.Count == 1)
            {
                dt = (DataTable)objList;
                txtContent.Text = dt.Rows[0]["strContentText"].ToString();
            }
            else if (objList.Count == 0)
            {
                txtContent.Text = string.Empty;
            }
        }
        else if (ddlContentSection.SelectedIndex == 0)
        {
            txtContent.Text = string.Empty;
        }
    }
}
