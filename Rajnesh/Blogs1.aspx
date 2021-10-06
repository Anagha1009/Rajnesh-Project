<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Blogs.aspx.cs" Inherits="Blogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Blogs on Education - Eduvidya.com</title>
    <meta name="description" content="Blogs on Education - Eduvidya.com" />
    <meta name="Keywords" content="Blogs on Education" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            jQuery('#grd_Blogs > tbody > tr:first').empty();
        });
    </script>
    <asp:ScriptManager ID="scrManager" runat="server">
    </asp:ScriptManager>
    <div class="box">
        <div class="heading">
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
            <a href="#">Blogs</a>
        </div>
        <div class="box-content">
            <div class="list">
                <p>Welcome to Eduvidya Blog Section</p>
            </div>
            <div class="height-10"></div>
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
                                <asp:Repeater ID="grd_Blogs" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="imgblock">
                                                <img src='<%# "https://www.eduvidya.com/files/Blog/" + Eval("strImage") %>' alt='<%# Eval("strTitle") %>' />
                                            </div>
                                            <div class="contentblock">
                                                <asp:HyperLink ID="hypLink" NavigateUrl='<%# "https://www.eduvidya.com/Blogs/" + Eval("strTitle").ToString().Replace(" ","-")%>'
                                                    runat="server" Text='<%# Bind("strTitle") %>'></asp:HyperLink></a><br />
                                                <span><%# fn_stripHtml(Eval("strDescription").ToString())%></span>
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
                <div class="google-ad">
                    <p>Google Ads Here</p>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<%--                  <asp:ListView ID="grd_Blogs" runat="server" GroupPlaceholderID="groupPlaceHolder1"
                                    ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
                                    <LayoutTemplate>

                                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="grd_Blogs" PageSize="15" class="pagination">
                                            <Fields>
                                                <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                                            </Fields>
                                        </asp:DataPager>
                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                        <asp:DataPager ID="DataPager2" runat="server" PagedControlID="grd_Blogs" PageSize="15" class="pagination">
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
                                                <img src='<%# "https://www.eduvidya.com/files/Blog/" + Eval("strImage") %>' alt='<%# Eval("strTitle") %>' />
                                            </div>
                                            <div class="contentblock">
                                                <asp:HyperLink ID="hypLink" NavigateUrl='<%# "https://www.eduvidya.com/Blogs/" + Eval("strTitle").ToString().Replace(" ","-")%>'
                                                    runat="server" Text='<%# Bind("strTitle") %>'></asp:HyperLink></a><br />
                                                <span><%# fn_stripHtml(Eval("strDescription").ToString())%></span>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView> --%>
