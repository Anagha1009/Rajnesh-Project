using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class AskNow : System.Web.UI.Page
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
        Info1.Visible = false;
        Error1.Visible = false;

        if (Session["userId"] == null)
        {
            Response.Redirect("Login.aspx?ReturnUrl=" + Request.Url.ToString());
        }
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!IsRefresh)
            {
                if (Session["userId"] != null)
                {
                    QuestionMasterClass objQuestion = new QuestionMasterClass();
                    objQuestion.strQuestion = txtQuestion.Text;
                    objQuestion.strType = ddl_Type.SelectedValue;
                    objQuestion.iUserID = int.Parse(Session["userId"].ToString());

                    string strResponse = objQuestion.fn_saveQuestion();

                    if (strResponse.StartsWith("SUCCESS"))
                    {
                        ((Label)Info1.FindControl("mssg")).Text = "Info : your Question has been posted successfully";
                        Info1.Visible = true;

                        txtQuestion.Text = "";
                        ddl_Type.SelectedIndex = 0;
                    }
                    else
                    {
                        ((Label)Error1.FindControl("mssg")).Text = "Error : " + strResponse;
                        Error1.Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)Error1.FindControl("mssg")).Text = "Error : " + ex.StackTrace + ex.Message;
            Error1.Visible = true;
        }
    }
}
