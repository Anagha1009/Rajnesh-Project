<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VoteMachine.ascx.cs" Inherits="UserControls_VoteMachine" %>
<div id="votingMeter" runat="server">
    <asp:UpdatePanel ID="pnlVotingMachine" runat="server">
        <ContentTemplate>
            <script type="text/javascript" src="https://www.eduvidya.com/ProgressBar/progressbar.js"></script>
            <link rel="stylesheet" type="text/css" href="https://www.eduvidya.com/ProgressBar/skins/round-pink/progressbar.css">

            <%--      
         <div class="heading">

                <h2>
                    <img title="Cricket" alt="Cricket" src="https://www.eduvidya.com/images/info.png">
                  
                    <asp:Literal ID="ltl_Info" runat="server"></asp:Literal>
                </h2>
            </div>
          
            <div class="select-option">
              
                <ul>
                    <asp:Repeater ID="rpt_ProgressBar" runat="server">
                        <ItemTemplate>
                            <li>
                                <label>
                                    <input type="radio" name="next-captain" value="26">
                                    <div class="progressBar round-pink" rank='<%# Eval("fPercentage") %>'></div>
                                    <%# Eval("strTitle") + "(" + Eval("fPercentage") + "%)"%>
                                </label>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

  <asp:RadioButtonList ID="rd_Options" runat="server" Width="100%">
            </asp:RadioButtonList>
               <asp:Button ID="btn_Vote" runat="server" Text="Submit" ValidationGroup="votes" OnClick="btn_Vote_Click"
                                CssClass="btnSubmit" />
                </ul>
            </div>
            <div class="next-vote">
                <p>
                    <strong>Next Vote:</strong>
                    <asp:Literal ID="ltl_VoteNext" runat="server"></asp:Literal>
                </p>
                <asp:Button ID="btn_Next" runat="server" Text="Vote Next" CssClass="btnSubmit" OnClick="btn_Next_Click" />
            </div>--%>

            <%--<table width="100%" align="center" class="_voteBox">--%>
            <div id="infoBox" runat="server">

                <div class="info">
                    <img src="https://www.eduvidya.com/images/info.png" />
                </div>
                <asp:Literal ID="ltl_Info" runat="server"></asp:Literal>
                <div class="_clr">
                </div>

            </div>
            <div id="voteBox" runat="server">
                <div class="heading">
                    <h2>
                        <img id="img_VoteIcon" runat="server" align="middle" />
                        <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
                    </h2>
                </div>

                <div class="select-option">
                    <asp:RadioButtonList ID="rd_Options" runat="server" Width="100%">
                    </asp:RadioButtonList>
                    <asp:Button ID="btn_Vote" runat="server" Text="Submit" ValidationGroup="votes" OnClick="btn_Vote_Click"
                        CssClass="btnSubmit" />
                </div>

            </div>
            <div id="ProgressBar" runat="server">
                <asp:Repeater ID="rpt_ProgressBar" runat="server">
                    <ItemTemplate>
                        <div class="progressBar round-pink" rank='<%# Eval("fPercentage") %>'>
                            <div style="float: left">
                            </div>
                            &nbsp;
                                    <%#  "(" + Eval("fPercentage") + "%)"%>
                            <%--<%# Eval("sdivTitle") + "(" + Eval("fPercentage") + "%)"%>--%>
                        </div>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <div id="nextBox" runat="server" class="next-vote">
                <p>
                    <strong>
                        <asp:Literal ID="ltl_VoteNext" runat="server"></asp:Literal>
                    </strong>
                </p>

                <asp:Button ID="btn_Next" runat="server" Text="Vote Next" CssClass="btnSubmit" OnClick="btn_Next_Click" />


            </div>
            <%--</table>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function fn_ProgressBar() {

            $(".progressBar").each(function () {
                var rank = $(this).attr("rank");
                progressBar(rank, $(this));
            });
        }
    </script>
</div>
