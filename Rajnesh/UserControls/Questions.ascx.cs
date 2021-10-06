using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class UserControls_Questions : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                QuestionMasterClass objQuestion = new QuestionMasterClass();
                CoreWebList<QuestionMasterClass> objQuestionList = null;

                string strQuestionType = "";
                if (Request.Url.ToString().ToLower().Contains("admission"))
                {
                    strQuestionType = "Admission";
                }
                else if (Request.Url.ToString().ToLower().Contains("exams"))
                {
                    strQuestionType = "Exam";
                }
                else if (Request.Url.ToString().ToLower().Contains("recruitments"))
                {
                    strQuestionType = "Recruitment";
                }

                if (strQuestionType != "")
                {
                    objQuestion.strType = strQuestionType;
                    objQuestionList = objQuestion.fn_getRandomQuestionListByType(5);
                }
                else
                {
                    objQuestionList = objQuestion.fn_getRandomQuestionList(5);
                }
                
                if (objQuestionList.Count > 0)
                {
                    rpt_Questions.DataSource = objQuestionList;
                }
                else
                {
                    rpt_Questions.DataSource = null;
                }
                rpt_Questions.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + ex.StackTrace);
            }
        }
    }


    protected void rpt_Questions_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfUserID = (HiddenField)e.Item.FindControl("hfUserID");
                Literal ltl_user = (Literal)e.Item.FindControl("ltl_user");

                UserClass objuser = new UserClass();
                objuser.iID = int.Parse(hfUserID.Value);
                CoreWebList<UserClass> objuserList = objuser.fn_getUserByID();
                if (objuserList.Count > 0)
                {
                    ltl_user.Text = "Posted by : " + objuserList[0].strName;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}