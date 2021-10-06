<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="University.aspx.cs" Inherits="Universities" %>

<%@ Register Src="UserControls/Competition.ascx" TagName="Competition" TagPrefix="asp" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="Pager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Top Universities in India 2021|List of best ranking Indian University|</title>
    <meta name="Description" content="Get List of Top Universities in India 2021. Also get best ranking Indian university list." />
    <meta name="Keywords" content="Top Universities in India" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <div class="box">
        <div class="heading"><a href="#">Top Universities in India</a></div>
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
                <script type="text/javascript">  var switchTo5x = true;</script>
                <script type="text/javascript" src="js/button.js"></script>
                <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                <script type="text/javascript">   stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                    displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
            </div>
            <div class="height-10"></div>
            <div class="list">
                <p>
                    Given below is the list of top Universities in India 2021 according to the best ranking Indian universities survey. Our country's system of higher education seems incomplete without the mention of universities and institutes for higher learning. Universities of India, public, private or deemed form the backbone of our scheme of higher learning. India's university system is appreciated the world over for its strong central institutions and emerging private entities that have improved college education in recent years. The proof of this being, the consistent ranking of IIT's colleges of India and some other indian universities in global rankings. Recognized by various professional councils and accredited by NAAC, these institutions are approved by the University Grants Commission (UGC). Valuing your need for admission to a good university, Eduvidya.com presents you with this most complete and definitive list of Universities in India 2021. Find all the information you may want to know about these varsities right from admission to placements.
                </p>
                <br />
                <ul>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/UGC-Recognized-Universities-in-India">UGC Recognised Universities in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Central-Universities-in-India">Central Universities in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Open-Universities-in-India">Open Universities in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Private-Universities-in-India">Private Universities in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Deemed-Universities-in-India">Deemed Universities in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Government-Universities-in-India">Government Universities in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-10-Universities-in-India">Top 10 Universities in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Agricultural-Universities-in-India">Top Agricultural Universities in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/State-Universities-in-India">State Universities in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Veterinary-Universities-in-India">Top Veterinary Universities in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-10-Deemed-Universities-in-India">Top 10 Deemed Universities in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Deemed-Universities-in-India-for-Engineering">Top Deemed Universities in India for Engineering</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Central-Universities-in-India">Top Deemed Universities in India for Medical</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Deemed-Universities-in-India-for-Medical">Top Deemed Universities in India for MBA</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/NAAC-A-Grade-Universities-in-India">NAAC A Grade Universities in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Medical-Universities-in-India">Top Medical Universities in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Universities-in-UP">Universities in UP</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Universities-in-Maharashtra">Universities in Maharashtra</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Universities-in-Karnataka">Universities in Karnataka</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Universities-in-Tamilnadu">Universities in Tamilnadu</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Universities-in-AP">Universities in AP</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Universities-in-Delhi">Universities in Delhi</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Universities-in-West-Bengal">Universities in West Bengal</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Universities-in-Gujarat">Universities in Gujarat</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Universities-in-MP">Universities in MP</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Universities-in-Kerala">Universities in Kerala</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Universities-in-Punjab">Universities in Punjab</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Universities-in-Rajasthan">Universities in Rajasthan</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Universities-in-Assam">Universities in Assam</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Universities-in-Himachal-Pradesh">Universities in Himachal Pradesh</a></li>
                </ul>
            </div>
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
                                <asp:Repeater ID="grd_Records" runat="server">
                                    <ItemTemplate>
                                        <li>
                                          <div class="imgblock">
                                                <img src='<%# "https://www.eduvidya.com/admin/Upload/University/" + Eval("strImage") %>'
                                                    alt='<%# Eval("strTitle") %>' />
                                            </div>
                                            <div class="contentblock">
                                                <a href='<%# VirtualPathUtility.ToAbsolute("~/University/" + Eval("strTitle").ToString().Replace(" ","-").Replace(".","_")) %>'>
                                                    <%# Eval("strTitle") %></a><br />
                                                <%# ((bool)(Eval("strDesc").ToString().Length > 210)) == true ? Eval("strDesc").ToString().Substring(0, 210) + " ..."+ "</p>" : Eval("strDesc")%>
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
            <%--<div class="google-ad">
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
<asp:Content ID="Content3" ContentPlaceHolderID="cp_rightBottom" runat="Server">
</asp:Content>
<%--        <asp:ListView ID="grd_Records" runat="server" GroupPlaceholderID="groupPlaceHolder1"
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
                                                <img src='<%# "https://www.eduvidya.com/admin/Upload/University/" + Eval("strImage") %>'
                                                    alt='<%# Eval("strTitle") %>' />
                                            </div>
                                            <div class="contentblock">
                                                <a href='<%# VirtualPathUtility.ToAbsolute("~/University/" + Eval("strTitle").ToString().Replace(" ","-").Replace(".","_")) %>' class="rec_links">
                                                    <%# Eval("strTitle") %></a><br />
                                                <%# ((bool)(Eval("strDesc").ToString().Length > 210)) == true ? Eval("strDesc").ToString().Substring(0, 210) + " ..."+ "</p>" : Eval("strDesc")%>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView> --%>
