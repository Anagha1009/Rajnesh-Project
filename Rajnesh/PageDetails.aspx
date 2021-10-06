<%@ Page MasterPageFile="~/ClientMaster.master" Language="C#" AutoEventWireup="true"
    CodeFile="PageDetails.aspx.cs" Inherits="Page_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title></title>
    <link href="https://www.eduvidya.com/css/Page_Style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scrManager" runat="server">
    </asp:ScriptManager>
    <div class="box">
        <div class="heading">
            <a href="#">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></a>
        </div>
        <div class="box-content">
            <div class="filter-result">
                <asp:Literal ID="ltl_Details" runat="server"></asp:Literal>
            </div>
            <div class="detail-list">
                <ul>
                    <asp:Repeater ID="rpt_Boxes" runat="server" OnItemDataBound="rpt_Boxes_ItemDataBound">
                        <ItemTemplate>
                            <li>
                                <div class="imgblock">
                                    <img src='<%# VirtualPathUtility.ToAbsolute("~/files/Box/" + Eval("strLogo")) %>'
                                        alt='<%# Eval("strTitle") %>' />
                                </div>
                                <div class="contentblock">
                                    <%# Eval("strTitle") %>
                                    <br />
                                    <%# Eval("strDetails")%>
                                    <asp:HiddenField ID="hf_BoxID" runat="server" Value='<%# Eval("iID") %>' />
                                    <br />
                                    <asp:Repeater ID="rpt_Links" runat="server">
                                        <HeaderTemplate>
                                            <ul class="links">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li><a href='<%# Eval("strUrl") %>'>
                                                <%# Eval("strTitle") %></a></li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div>
                <img src="images/PageNotFound.jpg" alt="Page Not Found" />
                <a href="https://www.eduvidya.com/">Please visit our home page</a>
            </div>
        </div>
    </div>
    <%-- <table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" valign="top" class="bestplace_head" itemprop="itemreviewed">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left" class="best_border">
            <asp:Literal ID="ltl_Details" runat="server"></asp:Literal>
                <div style="clear: both">
                    &nbsp;</div>
                <asp:Repeater ID="rpt_Boxes" runat="server" OnItemDataBound="rpt_Boxes_ItemDataBound">
                    <ItemTemplate>
                        <table width="100%" cellpadding="0px" cellspacing="0px" border="0px" class='<%# "Box_" + ((Container.ItemIndex + 1) % 10)%>'>
                            <tr>
                                <td align="left" valign="top">
                                    <div class="Title_Box">
                                        <img src='<%# VirtualPathUtility.ToAbsolute("~/files/Box/" + Eval("strLogo")) %>'
                                            alt='<%# Eval("strTitle") %>' />
                                        <%# Eval("strTitle") %>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" class="Details_Box">
                                    <%# Eval("strDetails")%>
                                    <asp:HiddenField ID="hf_BoxID" runat="server" Value='<%# Eval("iID") %>' />
                                    <div class="clr">
                                    </div>
                                    <asp:Repeater ID="rpt_Links" runat="server">
                                        <HeaderTemplate>
                                            <ul class="links">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li><a href='<%# Eval("strUrl") %>'>
                                                <%# Eval("strTitle") %></a></li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul></FooterTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td class="bottom">
                &nbsp;
            </td>
        </tr>
    </table>--%>
</asp:Content>
