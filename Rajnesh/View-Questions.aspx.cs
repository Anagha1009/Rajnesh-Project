using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class viewQuestions : System.Web.UI.Page
{
    static ArrayList pages = new ArrayList();

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

        if (!IsPostBack)
        {
            try
            {
                fn_BindViewQuestion();
                
            }
            catch (Exception ex)
            {
                ((Label)Info1.FindControl("lblInfo")).Text = "Error : " + ex.StackTrace + ex.Message;
                Info1.Visible = true;
            }
        }
    }

    protected void fn_BindViewQuestion()
    {
        QuestionMasterClass objQuestion = new QuestionMasterClass();
        CoreWebList<QuestionMasterClass> objQAList = objQuestion.fn_getQuestionList();

        if (objQAList.Count > 0)
        {
            PagedDataSource pgitems = new PagedDataSource();
            DataView dv = new DataView((DataTable)objQAList);
            pgitems.DataSource = dv;
            pgitems.AllowPaging = true;
            pgitems.PageSize = 15;
            pgitems.CurrentPageIndex = PageNumber;
            if (pgitems.PageCount >= 1)
            {
                int pno = Convert.ToInt32(ViewState["NavPageNumber"]);
                if (pno == 0)
                {
                    btnMoreUpPrv.Visible = false;
                    btnMoreDwnPrv.Visible = false;
                }
                else
                {
                    btnMoreUpPrv.Visible = true;
                    btnMoreDwnPrv.Visible = true;
                }
                rptPagesUp.Visible = true;
                rptPagesDwn.Visible = true;
                pages.Clear();
                if (pno + 10 >= pgitems.PageCount)// for last grup of pagecounts
                {
                    for (int i = pno; i < pgitems.PageCount; i++)
                        pages.Add((i + 1).ToString());
                    btnMoreUpNxt.Visible = false;
                    btnMoreDwnNxt.Visible = false;
                }
                else
                {

                    for (int i = pno; i < pno + 10; i++)
                        pages.Add((i + 1).ToString());
                    btnMoreUpNxt.Visible = true;
                    btnMoreDwnNxt.Visible = true;

                }

                rptPagesUp.DataSource = pages;
                rptPagesUp.DataBind();
                rptPagesDwn.DataSource = pages;
                rptPagesDwn.DataBind();
                ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "resetClass('" + (pno + 1) + "');", true);
            }
            else
            {
                rptPagesUp.Visible = false;
                rptPagesDwn.Visible = false;
            }
            grdQuest.DataSource = pgitems;
        }
        else
        {
            grdQuest.DataSource = null;
        }
        grdQuest.DataBind();

    }

    protected void fn_BindViewQuestionWithoutPagging()
    {
        QuestionMasterClass objQuestion = new QuestionMasterClass();
        CoreWebList<QuestionMasterClass> objQAList = objQuestion.fn_getQuestionList();

        if (objQAList.Count > 0)
        {
            PagedDataSource pgitems = new PagedDataSource();
            DataView dv = new DataView((DataTable)objQAList);
            pgitems.DataSource = dv;
            pgitems.AllowPaging = true;
            pgitems.PageSize = 15;
            pgitems.CurrentPageIndex = PageNumber;
            grdQuest.DataSource = pgitems;
        }
        else
        {
            grdQuest.DataSource = null;
        }
        grdQuest.DataBind();
    }

    protected void grdQuest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hfID = (HiddenField)e.Row.FindControl("hfID");
                HiddenField hfUserID = (HiddenField)e.Row.FindControl("hfUserID");
                Literal ltl_Count = (Literal)e.Row.FindControl("ltl_Count");
                Literal ltl_user = (Literal)e.Row.FindControl("ltl_user");

                AnswerMasterClass objAns = new AnswerMasterClass();
                objAns.iQuestionID = int.Parse(hfID.Value);

                CoreWebList<AnswerMasterClass> cwAns = objAns.fn_getAnswerListByQuestionID();

                if (cwAns.Count > 0)
                {
                    ltl_Count.Text = cwAns.Count.ToString() + " Answer(s)";
                }
                else
                {
                    ltl_Count.Text = "No Answer";
                }

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
            ((Label)Info1.FindControl("mssg")).Text = "Error : " + ex.StackTrace + ex.Message;
            Info1.Visible = true;
        }
    }
    
    //protected void grdQuest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        QuestionMasterClass objQuestion = new QuestionMasterClass();
    //        grdQuest.PageIndex = e.NewPageIndex;
    //        grdQuest.DataSource = objQuestion.fn_getQuestionList();
    //        grdQuest.DataBind();

    //    }
    //    catch (Exception ex)
    //    {
    //        ((Label)Info1.FindControl("mssg")).Text = "Error : " + ex.StackTrace + ex.Message;
    //        Info1.Visible = true;
    //    }
    //}

    //protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    //{
    //    (grdQuest.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
    //    (grdQuest.FindControl("DataPager2") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
    //    QuestionMasterClass objQuestion = new QuestionMasterClass();
    //    CoreWebList<QuestionMasterClass> objQAList = objQuestion.fn_getQuestionList();

    //    if (objQAList.Count > 0)
    //    {
    //        grdQuest.DataSource = objQAList;
    //    }
    //    else
    //    {
    //        grdQuest.DataSource = null;
    //    }
    //    grdQuest.DataBind();
    //}


    #region pagination

    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
                return Convert.ToInt32(ViewState["PageNumber"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNumber"] = value;
        }
    }

    public int NavPageNumber
    {
        get
        {
            if (ViewState["NavPageNumber"] != null)
                return Convert.ToInt32(ViewState["NavPageNumber"]);
            else
                return 0;
        }
        set
        {
            ViewState["NavPageNumber"] = value;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        rptPagesUp.ItemCommand +=
           new RepeaterCommandEventHandler(rptPages_ItemCommand);
        rptPagesDwn.ItemCommand +=
          new RepeaterCommandEventHandler(rptPages_ItemCommand);
    }

    void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToLower().Equals("page")) { PageNumber = Convert.ToInt32(e.CommandArgument) - 1; }
        fn_BindViewQuestionWithoutPagging();
        ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "resetClass('" + Convert.ToInt32(e.CommandArgument) + "');", true);
    }

    protected void lnkMorePageNumber_Click(object sender, EventArgs e)
    {
        if (pages.Count > 0)
        {
            ViewState["NavPageNumber"] = pages[Convert.ToInt32(pages.Count - 1)];
            ViewState["PageNumber"] = pages[Convert.ToInt32(pages.Count - 1)];
            fn_BindViewQuestion();
        }
    }


    protected void lnkPrevPageNumber_Click(object sender, EventArgs e)
    {
        if (pages.Count > 0)
        {
            ViewState["NavPageNumber"] = Convert.ToInt32(pages[0]) - 11;
            ViewState["PageNumber"] = Convert.ToInt32(pages[0]) - 11;
            fn_BindViewQuestion();
        }
    }

    #endregion pagination
}
