using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class UserControls_VoteMachine : System.Web.UI.UserControl
{
    string strUrl = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                fn_BindVotingMeter(0);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    private void fn_BindVotingMeter(int CurrentId)
    {
        try
        {
            infoBox.Visible = false;
            ProgressBar.Visible = false;
            rd_Options.Items.Clear();

            VoteClass objVote = new VoteClass();
            CoreWebList<VoteClass> objVoteList = objVote.fn_getTopEntry(CurrentId);
            if (objVoteList.Count > 0)
            {
                int iVoteID = objVoteList[0].iID;
                ViewState["VoteId"] = iVoteID;
                ltl_Title.Text = objVoteList[0].strTitle;
                img_VoteIcon.Src = VirtualPathUtility.ToAbsolute("~/files/Votes/" + objVoteList[0].strIcon);
                img_VoteIcon.Alt = objVoteList[0].strTitle;

                VoteDetailClass objVoteDetails = new VoteDetailClass();
                objVoteDetails.iVoteID = iVoteID;
                CoreWebList<VoteDetailClass> objVoteDetaillist = objVoteDetails.fn_getVoteDetailByVoteID();
                if (objVoteDetaillist.Count > 0)
                {
                    ListItem lst;

                    for (int i = 0; i < objVoteDetaillist.Count; i++)
                    {
                        lst = new ListItem();

                        if (objVoteDetaillist[i].strPhoto != "")
                        {
                            //lst.Text = "<div class='_option'><img src='" + VirtualPathUtility.ToAbsolute("~/files/Options/" + objVoteDetaillist[i].strPhoto) + "' /></div>" + objVoteDetaillist[i].strTitle;
                            lst.Text = "<img src='" + VirtualPathUtility.ToAbsolute("~/files/Options/" + objVoteDetaillist[i].strPhoto) + "' />" + objVoteDetaillist[i].strTitle;
                        }
                        else
                        {
                            lst.Text = objVoteDetaillist[i].strTitle;
                        }

                        lst.Value = objVoteDetaillist[i].iID.ToString();

                        rd_Options.Items.Add(lst);
                    }
                }
                else
                {
                    votingMeter.Visible = false;
                }

                if (objVoteList.Count == 1)
                {
                    nextBox.Visible = false;
                }
                else
                {
                    ltl_VoteNext.Text = "<b>Next Vote : </b>" + objVoteList[1].strTitle;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void btn_Vote_Click(object sender, EventArgs e)
    {
        try
        {
            if (rd_Options.SelectedValue != null && rd_Options.SelectedValue != "")
            {
                VoteDetailClass objVoteDetail = new VoteDetailClass();
                objVoteDetail.iID = int.Parse(rd_Options.SelectedValue.ToString());
                objVoteDetail.iVoteID = int.Parse(ViewState["VoteId"].ToString());

                string strResponse = objVoteDetail.fn_AddVotes();

                if (strResponse.Contains("SUCCESS"))
                {
                    infoBox.Visible = true;
                    ProgressBar.Visible = true;
                    voteBox.Visible = false;

                    ltl_Info.Text = "Thankyou for Giving your valuable vote!";

                    CoreWebList<VoteDetailClass> objVoteDetailList = objVoteDetail.fn_getVotePercentage();
                    if (objVoteDetailList.Count > 0)
                    {
                        rpt_ProgressBar.DataSource = objVoteDetailList;
                        rpt_ProgressBar.DataBind();

                        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "ProgressBar", "fn_ProgressBar();", true);
                    }
                }
                else
                {
                    infoBox.Visible = true;
                    ltl_Info.Text = strResponse;
                }
            }
        }
        catch (Exception ex)
        {
            infoBox.Visible = true;
            ltl_Info.Text = ex.Message + ex.StackTrace;
        }
    }

    protected void btn_Next_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["VoteId"] != null)
            {
                infoBox.Visible = false;
                ProgressBar.Visible = false;
                voteBox.Visible = true;

                int CurrentId = int.Parse(ViewState["VoteId"].ToString());
                fn_BindVotingMeter(CurrentId);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}