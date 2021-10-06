using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class JQuery_tabs_TheCommentBox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                fn_BindComment("Comment", rpt_Comments);
                fn_BindComment("Review", rpt_Reviews);
                fn_BindComment("Question", rpt_Questions);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void btn_Submit_01_Click(object sender, EventArgs e)
    {
        try
        {
            int iRate = 0;
            string strType = "Comment";
            string strName = txtCommentName.Text;
            string strEmail = txtCommentEmail.Text;
            string strMobile = txtCommentMobile.Text;
            string strTitle = "";
            string strDesc = txtComment.Text;

            fn_PostComment(iRate, strType, strName, strEmail, strMobile, strTitle, strDesc);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void btn_Submit_02_Click(object sender, EventArgs e)
    {
        try
        {
            int iRate = int.Parse(hf_Rate.Value);
            string strType = "Review";
            string strName = txtReviewName.Text;
            string strEmail = txtReviewEmail.Text;
            string strMobile = txtReviewMobile.Text;
            string strTitle = txtReviewTitle.Text;
            string strDesc = txtReviewsDesc.Text;

            fn_PostComment(iRate, strType, strName, strEmail, strMobile, strTitle, strDesc);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void btn_Submit_03_Click(object sender, EventArgs e)
    {
        try
        {
            int iRate = 0;
            string strType = "Question";
            string strName = txtQuestName.Text;
            string strEmail = txtQuestEmail.Text;
            string strMobile = txtQuestMobile.Text;
            string strTitle = txtQuestTitle.Text;
            string strDesc = txtQuestion.Text;

            fn_PostComment(iRate, strType, strName, strEmail, strMobile, strTitle, strDesc);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_PostComment(int iRate, string strType, string strName, string strEmail, string strMobile, string strTitle, string strDesc)
    {
        try
        {
            CommentClass objComment = new CommentClass();
            objComment.strType = strType;
            objComment.strUrl = Request.Url.ToString();
            objComment.iRate = iRate;
            objComment.strName = strName;
            objComment.strEmail = strEmail;
            objComment.strPhone = strMobile;
            objComment.strTitle= strTitle;
            objComment.strDesc = strDesc;
            objComment.strIpAddrs = HttpContext.Current.Request.UserHostAddress;

            string strResponse = objComment.fn_saveComment();
            
            if(strResponse.StartsWith("SUCCESS"))
            {
                ltl_InfoTitle.Text = "Posting " + strType + "!";
                ltl_Info.Text = "Hi " + strName + ", <br/>Thank you for posting Your " + strType + ". Your " + strType + " has been posted successfully & It has gone for admin approvals!";
                ClientScript.RegisterStartupScript(this.GetType(), "PopUp", "setTimeout('fn_getPopup()',900);", true);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindComment( string strType, Repeater rpt_CommentBox)
    {
        try
        {
            CommentClass objComment = new CommentClass();
            objComment.strType = strType;
            objComment.strUrl = Request.Url.ToString();
            CoreWebList<CommentClass> objCommentlist = objComment.fn_getCommentByUrl();
            if (objCommentlist.Count > 0)
            {
                rpt_CommentBox.DataSource = objCommentlist;
                rpt_CommentBox.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void rpt_Comments_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "CommentReply")
            {
                HiddenField hf_Type = (HiddenField)e.Item.FindControl("hf_Type");
                TextBox txtCommentReplyName = (TextBox)e.Item.FindControl("txtCommentReplyName");
                TextBox txtCommentReplyEmail = (TextBox)e.Item.FindControl("txtCommentReplyEmail");
                TextBox txtCommentReplyMobile = (TextBox)e.Item.FindControl("txtCommentReplyMobile");
                TextBox txtCommentReply = (TextBox)e.Item.FindControl("txtCommentReply");

                if (txtCommentReplyName != null && txtCommentReplyEmail != null && txtCommentReplyMobile != null && txtCommentReply != null)
                {
                    if (txtCommentReplyName.Text != "" && txtCommentReplyEmail.Text != "" && txtCommentReplyMobile.Text != "" && txtCommentReply.Text != "")
                    {
                        CommentReplyClass objReply = new CommentReplyClass();
                        objReply.iCommentID = int.Parse(e.CommandArgument.ToString());
                        objReply.strName = txtCommentReplyName.Text.Trim();
                        objReply.strEmail = txtCommentReplyEmail.Text;
                        objReply.strPhone = txtCommentReplyMobile.Text;
                        objReply.strReply = txtCommentReply.Text;

                        string strResponse = objReply.fn_saveCommentReply();

                        if (strResponse.StartsWith("SUCCESS"))
                        {
                            if (hf_Type != null)
                            {
                                string strCommentType = hf_Type.Value;
                                if (strCommentType == "Comment")
                                {
                                    fn_BindComment(strCommentType, rpt_Comments);
                                }
                                else if (strCommentType == "Review")
                                {
                                    fn_BindComment(strCommentType, rpt_Reviews);
                                }
                                else if (strCommentType == "Question")
                                {
                                    fn_BindComment(strCommentType, rpt_Questions);
                                }
                            }

                            ltl_InfoTitle.Text = "Posting Reply!";
                            ltl_Info.Text = "Hi " + txtCommentName.Text.Trim() + ", <br/>Thank you for posting Your Reply!";
                            ClientScript.RegisterStartupScript(this.GetType(), "PopUp", "setTimeout('fn_getPopup()',900);", true);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void rpt_Comments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hf_CommentID = (HiddenField)e.Item.FindControl("hf_CommentID");
                Repeater rpt_Reply = (Repeater)e.Item.FindControl("rpt_Reply");

                if (hf_CommentID != null && rpt_Reply != null)
                {
                    CommentReplyClass objReply = new CommentReplyClass();
                    objReply.iCommentID = int.Parse(hf_CommentID.Value);
                    CoreWebList<CommentReplyClass> objReplyList = objReply.fn_getCommentReplyByCommentID();
                    if (objReplyList.Count > 0)
                    {
                        rpt_Reply.DataSource = objReplyList;
                        rpt_Reply.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}