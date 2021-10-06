<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="StudyabroadDetails.aspx.cs" Inherits="SearchDetails" %>

<asp:Content ID="MetaContent" runat="server" ContentPlaceHolderID="head">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scManager" runat="server">
    </asp:ScriptManager>
    <div class="box">
        <div class="heading">
            <a href="#">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></a>
        </div>
        <div class="box-content">
            <div class="list">
                <img id="img_Pages" runat="server" class="_Photo_frame" />
                <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>

                 <br />
                     <div class="google-ad" style="border: none; margin-top: 30px; text-align: left;">
                    <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
                    <!-- Eduvidya Responsive Link Unit -->
                    <ins class="adsbygoogle"
                        style="display: block"
                        data-ad-client="ca-pub-4037987430386783"
                        data-ad-slot="1159495717"
                        data-ad-format="link"></ins>
                    <script>
                        (adsbygoogle = window.adsbygoogle || []).push({});
                    </script>

                         </div>
                    <br />
                <div class="aticleBox">
                    <asp:Repeater ID="rpt_Articles" runat="server">
                        <ItemTemplate>
                            <div>
                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Studyabroad/" + RouteData.Values["Country"].ToString() + "/" + Eval("strTitle").ToString().Replace(" ","-"))%>'>
                                    <%# Eval("strTitle") %></a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="filter-result">
                <div class="detail-list">                  

                    <asp:UpdatePanel ID="pnllist" runat="server">
                        <ContentTemplate>
                            <div class="pagination">
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="btnMoreUpPrv" runat="server" Text="..." OnClick="lnkPrevPageNumber_Click" Visible="false" /></li>
                                    <asp:Repeater ID="rptPagesUp" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <asp:LinkButton ID="btnPage" pageno="<%# Container.DataItem %>" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server"><%# Container.DataItem %> </asp:LinkButton>
                                            </li>
                                        </ItemTemplate>

                                    </asp:Repeater>
                                    <li>
                                        <asp:LinkButton ID="btnMoreUpNxt" runat="server" Text="..." OnClick="lnkMorePageNumber_Click" Visible="false" /></li>
                                </ul>
                            </div>
                            <div class="detail-list">
                                <ul>
                                    <asp:Repeater ID="grd_Records" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <div class="imgblock">
                                                    <img src='<%# "https://www.eduvidya.com/files/University/" + Eval("strLogo") %>' alt='<%# Eval("strTitle") %>' />
                                                </div>
                                                <div class="contentblock">
                                                    <a href='<%# VirtualPathUtility.ToAbsolute("~/Studyabroad/" + RouteData.Values["Country"].ToString() + "/University/" + Eval("strTitle").ToString().Replace(" ","-"))%>'><%# Eval("strTitle") %></a><br />
                                                    <span><%# ((bool)(Eval("strDetails").ToString().Length > 210)) == true ? Eval("strDetails").ToString().Substring(0, 210) + " ..." + "</p>": Eval("strDetails")%>
                                                    </span>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <div class="pagination">
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="btnMoreDwnPrv" runat="server" Text="..." OnClick="lnkPrevPageNumber_Click" Visible="false" /></li>
                                    <asp:Repeater ID="rptPagesDwn" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <asp:LinkButton ID="btnPage" pageno="<%# Container.DataItem %>" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server"><%# Container.DataItem %> </asp:LinkButton>
                                            </li>
                                        </ItemTemplate>

                                    </asp:Repeater>
                                    <li>
                                        <asp:LinkButton ID="btnMoreDwnNxt" runat="server" Text="..." OnClick="lnkMorePageNumber_Click" Visible="false" /></li>
                                </ul>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>


            </div>
            <div class="height-10"></div>
            <div class="google-ad linkunitads">
                <script type="text/javascript"><!--
    google_ad_client = "ca-pub-4037987430386783";
    /* Eduvidya-Link-728&#42;15 */
    google_ad_slot = "4438952914";
    google_ad_width = 728;
    google_ad_height = 15;
    //-->
                </script>
                <script type="text/javascript" src="https://pagead2.googlesyndication.com/pagead/show_ads.js">
                </script>
            </div>
            <div class="height-10"></div>
            <div class="need-edu-loan"><a target="_blank" href="https://www.eduvidya.com/Education-Help.aspx">Need Education Loan?</a></div>
            <div class="height-10"></div>
            
        </div>
    </div>
</asp:Content>
<%--               <asp:ListView ID="grd_Records" runat="server" GroupPlaceholderID="groupPlaceHolder1"
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
                                                <img src='<%# "https://www.eduvidya.com/files/University/" + Eval("strLogo") %>' alt='<%# Eval("strTitle") %>' />
                                            </div>
                                            <div class="contentblock">
                                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Studyabroad/" + RouteData.Values["Country"].ToString() + "/University/" + Eval("strTitle").ToString().Replace(" ","-"))%>'><%# Eval("strTitle") %></a><br />
                                                <span><%# ((bool)(Eval("strDetails").ToString().Length > 210)) == true ? Eval("strDetails").ToString().Substring(0, 210) + " ..." + "</p>": Eval("strDetails")%>
                                                </span>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView>--%>
