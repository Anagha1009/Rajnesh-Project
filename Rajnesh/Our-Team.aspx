<%@ Page Title="STUDY IN INDIA" Language="C#" MasterPageFile="~/ClientMaster.master"
    AutoEventWireup="true" CodeFile="Our-Team.aspx.cs" Inherits="Our_team" %>

<asp:Content ID="MetaContent" runat="server" ContentPlaceHolderID="head">
    <title>Our Team</title>
    <meta name="Description" content="Our Team" />
    <meta name="Keywords" content="Our Team" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cp_left" runat="Server">
    <table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
        <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
        <div class="box">
            <div class="heading"><a href="#">Our Team</a></div>
            <div class="box-content">
                <div class="filter-result">
                    <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>

                </div>
                <div class="detail-list">
                    <ul>
                        <asp:Repeater ID="rpt_TeamMembers" runat="server">
                            <ItemTemplate>
                                <li>
                                    <div class="imgblock">
                                        <img src='<%# ((bool)(Eval("strPhoto").ToString().Length > 0)) == true ? "https://www.eduvidya.com/files/TeamMember/" + Eval("strPhoto") : "https://www.eduvidya.com/images/Avatar.jpeg"%>' />
                                    </div>
                                    <div class="contentblock">
                                        <b>
                                            <%# Eval("strName")%></b><br />
                                        <%# Eval("strDesignation")%><br />
                                        <%# Eval("strDetails")%><br />
                                        <div>
                                            <a href='<%# Eval("strFacebook")%>' target="_blank">
                                                <img src="images/f.gif" alt="facebook" style="height: 40px !important; width: 40px !important; border: none;" /></a>
                                            <a href='<%# Eval("strTwitter")%>' target="_blank" />
                                            <img src="images/t.gif" alt="twitter" style="height: 40px !important; width: 40px !important; border: none;" /></a>
                                           <a href='<%# Eval("strLinkedIn")%>' target="_blank" />
                                            <img src="images/in.gif" alt="linkedin" style="height: 40px !important; width: 40px !important; border: none;" /></a>
                                          <a href='<%# Eval("strGooglePlus")%>' target="_blank" />
                                            <img src="images/google.png" alt="google+" style="height: 40px !important; width: 40px !important; border: none;" /></a>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>

                        </asp:Repeater>
                    </ul>
                </div>

            </div>
        </div>
</asp:Content>
