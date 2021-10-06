using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class UserControls_Schools : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string strUrl = Request.Url.ToString().ToLower();
                if (strUrl.Contains("/entrance-exam/"))
                {
                    if (this.Page.RouteData.Values["Exam"] != null)
                    {
                        EntranceExamClass objExam = new EntranceExamClass();
                        objExam.strTitle = this.Page.RouteData.Values["Exam"].ToString().Replace("-", " ");
                        CoreWebList<EntranceExamClass> objExamList = objExam.fn_getEntranceExamByName();
                        if (objExamList.Count > 0)
                        {
                            EntranceExamClass obj_Exam = new EntranceExamClass();
                            obj_Exam.iCategoryID = objExamList[0].iCategoryID;
                            CoreWebList<EntranceExamClass> obj_ExamList = obj_Exam.fn_getRandomEntranceExamByCategoryID();
                            if (obj_ExamList.Count > 0)
                            {
                                rpt_Exams.DataSource = obj_ExamList;
                                rpt_Exams.DataBind();
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
    }
}