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
using yo_lib;

public partial class admin_AskQuestions : System.Web.UI.Page
{
    private CoreWebList<QuestionMasterClass> chQuestionList
    {
        get
        {
            if (Cache["chQuestionList"] != null)
                return (CoreWebList<QuestionMasterClass>)Cache["chQuestionList"];
            return null;
        }
        set
        {
            Cache["chQuestionList"] = value;
        }
    }
    

    protected void fillData()
    {
        try
        {
            QuestionMasterClass objQuestion = new QuestionMasterClass();
            chQuestionList = objQuestion.fn_getQuestionList();
            grdUserMaster.DataSource = chQuestionList;
            grdUserMaster.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillData();
        }
    }

    protected void grdUserMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdUserMaster.PageIndex = e.NewPageIndex;
            grdUserMaster.DataSource = chQuestionList;
            grdUserMaster.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grdUserMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            QuestionMasterClass objQuestion = new QuestionMasterClass();
            objQuestion.iID = int.Parse(grdUserMaster.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objQuestion.fn_deleteQuestion();

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
            
            fillData();

        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grdUserMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //HiddenField hfUserID = (HiddenField)e.Row.FindControl("hfUserID");
            //HyperLink hlnk_UserName = (HyperLink)e.Row.FindControl("hlnk_UserName");

            //if (hlnk_UserName != null && hfUserID != null)
            //{
            //    if (hfUserID.Value == "0")
            //    {
                    
            //        hlnk_UserName.NavigateUrl = "#";
            //    }
            //}
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtSearch.Text != "")
            {
                QuestionMasterClass objQuestion = new QuestionMasterClass();
                chQuestionList = objQuestion.fn_getQuestionByKey(txtSearch.Text.Trim());
                grdUserMaster.DataSource = chQuestionList;
                grdUserMaster.DataBind();
            }
            else
            {
                ((Label)error.FindControl("mssg")).Text = "Please Enter Some Keyword";
                error.Visible = true;
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}
