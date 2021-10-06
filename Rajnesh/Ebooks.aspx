<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Ebooks.aspx.cs" Inherits="Ebooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Ebooks</title>
    <meta name="description" content="Ebooks" />
    <meta name="Keywords" content="Ebooks" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scrManager" runat="server">
    </asp:ScriptManager>
    <div class="box">
        <div class="heading">
            <a href="#">
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                Ebooks</a>
        </div>
        <div class="box-content">
            <div class="filter-result">
                <div class="list">
                    <p>
                        <strong>Welcome to Ebooks Section</strong>
                    </p>
                </div>
                <div class="detail-list">
                         <asp:UpdatePanel ID="pnllist" runat="server">
                        <ContentTemplate>
                             <div class="pagination">
                            <ul>
                                <li>
                                    <asp:LinkButton ID="btnMoreUpPrv" runat="server" Text="..." OnClick="lnkPrevPageNumber_Click" Visible="false"/></li>
                                <asp:Repeater ID="rptPagesUp" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <asp:LinkButton ID="btnPage" pageno="<%# Container.DataItem %>" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server"><%# Container.DataItem %> </asp:LinkButton>
                                        </li>
                                    </ItemTemplate>

                                </asp:Repeater>
                                <li>
                                    <asp:LinkButton ID="btnMoreUpNxt" runat="server" Text="..." OnClick="lnkMorePageNumber_Click" Visible="false"/></li>
                            </ul>
                        </div>
                        <div class="detail-list">
                            <ul>
                                <asp:Repeater ID="grd_Ebooks" runat="server">
                                    <ItemTemplate>
                                        <li>
                                             <a href='<%# VirtualPathUtility.ToAbsolute("~/Ebooks/" + Eval("strTitle").ToString().Replace(" ", "-"))%>'>
                                                <%# Eval("strTitle") %></a>
                                            <br />
                                            <%# fn_stripHtml(Eval("strDetails").ToString())%>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="pagination">
                            <ul>
                                <li>
                                    <asp:LinkButton ID="btnMoreDwnPrv" runat="server" Text="..." OnClick="lnkPrevPageNumber_Click" Visible="false"/></li>
                                <asp:Repeater ID="rptPagesDwn" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <asp:LinkButton ID="btnPage" pageno="<%# Container.DataItem %>" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server"><%# Container.DataItem %> </asp:LinkButton>
                                        </li>
                                    </ItemTemplate>

                                </asp:Repeater>
                                <li>
                                    <asp:LinkButton ID="btnMoreDwnNxt" runat="server" Text="..." OnClick="lnkMorePageNumber_Click" Visible="false"/></li>
                            </ul>
                        </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>
        </div>
    </div>
    <%--  <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="bestplace_head">
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                <h1>
                    Ebooks</h1>
            </td>
        </tr>
        <tr>
            <td class="best_border">
                <div class="GridBox">
                    Welcome to Ebooks Section
                </div>
                               <asp:ListView ID="grd_Ebooks" runat="server" GroupPlaceholderID="groupPlaceHolder1"
                                    ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
                                    <LayoutTemplate>

                                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="grd_Ebooks" PageSize="15" class="pagination">
                                            <Fields>
                                                <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                                            </Fields>
                                        </asp:DataPager>
                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                        <asp:DataPager ID="DataPager2" runat="server" PagedControlID="grd_Ebooks" PageSize="15" class="pagination">
                                            <Fields>
                                                <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                                            </Fields>
                                        </asp:DataPager>

                                    </LayoutTemplate>
                                    <GroupTemplate>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                    </GroupTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <a href='<%# VirtualPathUtility.ToAbsolute("~/Ebooks/" + Eval("strTitle").ToString().Replace(" ", "-"))%>'>
                                                <%# Eval("strTitle") %></a>
                                            <br />
                                            <%# fn_stripHtml(Eval("strDetails").ToString())%>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView>
            </td>
        </tr>
        <tr>
            <td class="bottom">
                &nbsp;
            </td>
        </tr>
    </table>--%>
</asp:Content>
