<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="College-Search.aspx.cs" Inherits="City_Colleges" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="Pager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Search Colleges</title>
    <meta name="Description" content="Search Colleges" />
    <meta name="Keywords" content="Search Colleges" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scManager" runat="server">
    </asp:ScriptManager>
    <div class="box">
        <div class="heading">
            <a href="#">Search Colleges in India</a>
        </div>
        <div class="box-content">
            <div class="filter-result">
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
                                <asp:Repeater ID="grd_Records" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="imgblock">
                                                <img src='<%# "https://www.eduvidya.com/admin/Upload/Institutes/" + Eval("strPhoto") %>'
                                                    alt='<%# Eval("strTitle") %>' />
                                            </div>
                                            <div class="contentblock">
                                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strTitle").ToString().Replace(" ","-")) %>'>
                                                    <%# Eval("strTitle") %></a><br />
                                                <span><%# ((bool)(Eval("strDesc").ToString().Length > 210)) == true ? Eval("strDesc").ToString().Substring(0, 210) + " ..." + "</p>": Eval("strDesc")%></span>
                                            </div>
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
    <%--  <table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" valign="top" class="bestplace_head">
                <h1>
                    Search Colleges in India</h1>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" class="best_border">
                                          <asp:ListView ID="grd_Records" runat="server" GroupPlaceholderID="groupPlaceHolder1"
                                    ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
                                    <LayoutTemplate>

                                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="grd_Records" PageSize="15" class="pagination">
                                            <Fields>
                                                <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                                            </Fields>
                                        </asp:DataPager>
                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                        <asp:DataPager ID="DataPager2" runat="server" PagedControlID="grd_Records" PageSize="15" class="pagination">
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
                                            <div class="imgblock">
                                                <img src='<%# "https://www.eduvidya.com/admin/Upload/Institutes/" + Eval("strPhoto") %>'
                                                    alt='<%# Eval("strTitle") %>' />
                                            </div>
                                            <div class="contentblock">
                                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strTitle").ToString().Replace(" ","-")) %>'>
                                                    <%# Eval("strTitle") %></a><br />
                                                <span><%# ((bool)(Eval("strDesc").ToString().Length > 210)) == true ? Eval("strDesc").ToString().Substring(0, 210) + " ..." + "</p>": Eval("strDesc")%></span>
                                            </div>
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
