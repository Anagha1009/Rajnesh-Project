using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;
using System.Data;


public partial class UserControls_CommentsForListing : System.Web.UI.UserControl
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
        Confirmation.Visible = false;
        if (!IsPostBack)
        {
            fn_BindCommentsRepeater();
        }
    }

    public void fn_BindCommentsRepeater()
    {
        try
        {
            CommentsMasterClass objComment = new CommentsMasterClass();
            objComment.strUrl = Request.Url.ToString();
            CoreWebList<CommentsMasterClass> objList = objComment.fn_getCommentByUrl();
            if (objList.Count > 0)
            {
                rptrComments.DataSource = objList;
                rptrComments.DataBind();
                tr_Comments3.Visible = true;
                myTab.Visible = true;
                tr_Confirmation.Visible = true;
                tr3.Visible = true;
            }
            else
            {
                tr_Confirmation.Visible = false;
                tr3.Visible = false;
                tr_Comments3.Visible = false;
                rptrComments.DataSource = null;
                rptrComments.DataBind();
                myTab.Visible = false;
            }
        }
        catch (Exception ex)
        {
            fn_ShowInfoMessage(ex);
        }
    }

    protected void rptrComments_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (e.CommandName == "Abuse")
            {
                if (Session["UserID"] != null)
                {
                    CommentsMasterClass objComment = new CommentsMasterClass();
                    objComment.iUserID = int.Parse(Session["UserID"].ToString());
                    objComment.iID = int.Parse(e.CommandArgument.ToString());
                    objComment.bAbuse = true;
                    string strResponse = objComment.fn_ChangeAbusedCommentStatus();

                    if (strResponse.StartsWith("SUCCESS"))
                    {
                        Confirmation.Visible = true;
                        lbl_Confirmation.Text = "Reported Abuse";
                        tr_Confirmation.Visible = true;
                        lbl_Confirmation.Visible = true;
                    }
                    else
                    {
                        Confirmation.Visible = true;
                        lbl_Confirmation.Text = strResponse.ToString();
                        tr_Confirmation.Visible = true;
                        lbl_Confirmation.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx?ReturnUrl=" + Request.Url.ToString());
                }
            }
        }
    }

    protected void fn_ShowInfoMessage(Exception ex)
    {
        Confirmation.Visible = true;
        lbl_Confirmation.Text = ex.Message + ex.StackTrace;
        lbl_Confirmation.Visible = true;
    }

    protected bool fn_ValidateComment(string strInput)
    {
        bool bStatus = false;
        string strComment = strInput.ToLower();

        CommentKeysClass objComments = new CommentKeysClass();
        CoreWebList<CommentKeysClass> objCommentList = objComments.fn_getCommentKeysList();
        if (objCommentList.Count > 0)
        {
            for (int i = 0; i < objCommentList.Count; i++)
            {
                string strCommentKey = objCommentList[i].strTitle.ToLower();

                if (strComment.Contains(strCommentKey))
                {
                    bStatus = true;
                }
            }
        }
        return bStatus;
    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!IsRefresh)
            {
                bool bComment = fn_ValidateComment(txtComment.Text);
                if (bComment == false)
                {
                    bool bName = fn_ValidateComment(txtName.Text);
                    if (bName == false)
                    {
                        bool bEmail = fn_ValidateComment(txtEmail.Text);
                        if (bEmail == false)
                        {
                            bool bPhone = fn_ValidateComment(txtMobile.Text);
                            if (bPhone == false)
                            {
                                CommentsMasterClass objComment = new CommentsMasterClass();
                                objComment.strName = txtName.Text;
                                objComment.strComment = txtComment.Text;
                                objComment.strEmail = txtEmail.Text;
                                objComment.strPhone = txtMobile.Text;
                                objComment.strUrl = Request.Url.ToString();
                                objComment.bActive = false;

                                if (Request.Url.ToString().ToLower().Contains("admission"))
                                {
                                    objComment.strType = "Admission";
                                }
                                else if (Request.Url.ToString().ToLower().Contains("exams"))
                                {
                                    objComment.strType = "Exam";
                                }
                                else if (Request.Url.ToString().ToLower().Contains("recruitments"))
                                {
                                    objComment.strType = "Recruitment";
                                }
                                else
                                {
                                    objComment.strType = "";
                                }

                                if (!IsRefresh)
                                {
                                    string strResponse = objComment.fn_saveComment();
                                    if (strResponse.StartsWith("SUCCESS"))
                                    {

                                        Confirmation.Visible = true;
                                        lbl_Confirmation.Text = "Thank you for posting your Comments. Your Comment is gone for admin approval<br/>&nbsp;";

                                        txtComment.Text = "";
                                        txtEmail.Text = "";
                                        txtMobile.Text = "";
                                        txtName.Text = "";
                                        lbl_Confirmation.Visible = true;
                                        tr_Confirmation.Visible = true;
                                    }
                                    else
                                    {
                                        Confirmation.Visible = true;
                                        lbl_Confirmation.Text = "Please try Again";
                                        lbl_Confirmation.Visible = true;
                                        tr_Confirmation.Visible = true;
                                    }
                                }
                            }
                            else
                            {
                                Confirmation.Visible = true;
                                lbl_Confirmation.Text = "Sorry, Your Mobile Number is not valid";
                                lbl_Confirmation.Visible = true;
                                tr_Confirmation.Visible = true;
                            }
                        }
                        else
                        {
                            Confirmation.Visible = true;
                            lbl_Confirmation.Text = "Sorry, Your Email is not valid";
                            lbl_Confirmation.Visible = true;
                            tr_Confirmation.Visible = true;
                        }
                    }
                    else
                    {
                        Confirmation.Visible = true;
                        lbl_Confirmation.Text = "Sorry, Your Name is not valid";
                        lbl_Confirmation.Visible = true;
                        tr_Confirmation.Visible = true;
                    }
                }
                else
                {
                    Confirmation.Visible = true;
                    lbl_Confirmation.Text = "Your Comment is not valid";
                    lbl_Confirmation.Visible = true;
                    tr_Confirmation.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            fn_ShowInfoMessage(ex);
        }
    }
}
