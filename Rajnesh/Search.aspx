<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="Search_list" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="Pager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Most Searched Queries on Eduvidya.com</title>
    <meta name="Description" content="Most Searched Queries on Eduvidya.com" />
    <meta name="Keywords" content="Most Searched Queries on Eduvidya.com" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <div class="box">
        <div class="heading">
            <a href="#">Search</a>
        </div>
        <div class="box-content">

            <div class="rating">
                <div id="score" style="cursor: pointer;">
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
                    <div class="Ratingleft">
                        <asp:Rating ID="rt_Rate" runat="server" StarCssClass="StarCss" FilledStarCssClass="FilledStarCss"
                            EmptyStarCssClass="EmptyStarCss" WaitingStarCssClass="WaitingStarCss" AutoPostBack="true"
                            OnChanged="rt_Rate_Changed" MaxRating="5">
                        </asp:Rating>
                    </div>
                </div>
                <div class="rating-text">
                    <asp:Literal ID="ltl_RatingBox" runat="server"></asp:Literal>
                </div>
            </div>

            <div class="social-share">
                <script type="text/javascript">                                var switchTo5x = true;</script>
                <script type="text/javascript" src="js/button.js"></script>
                <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                <script type="text/javascript">                                stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                    displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
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
                                                    <img src='<%# "https://www.eduvidya.com/files/PageGenerator/" + Eval("strPhoto") %>'
                                                        alt='<%# Eval("strTitle") %>' />
                                                </div>
                                                <div class="contentblock">
                                                    <a href='<%# VirtualPathUtility.ToAbsolute("~/Search/" + Eval("strTitle").ToString().Replace(" ","-").Replace(".","_")) %>'>
                                                        <%# Eval("strTitle") %></a><br />
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
         <%--   <div class="google-ad">
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
            </div>--%>
        </div>

    </div>
</asp:Content>
<%--      <asp:ListView ID="grd_Records" runat="server" GroupPlaceholderID="groupPlaceHolder1"
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
                                                <img src='<%# "https://www.eduvidya.com/files/PageGenerator/" + Eval("strPhoto") %>'
                                                    alt='<%# Eval("strTitle") %>' />
                                            </div>
                                            <div class="contentblock">
                                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Search/" + Eval("strTitle").ToString().Replace(" ","-").Replace(".","_")) %>'>
                                                    <%# Eval("strTitle") %></a><br />
                                                <span><%# ((bool)(Eval("strDetails").ToString().Length > 210)) == true ? Eval("strDetails").ToString().Substring(0, 210) + " ..." + "</p>": Eval("strDetails")%>
                                                </span>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView> --%>
