<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="QueryDetails.aspx.cs" Inherits="College_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="Pager" %>
<%@ Register Src="UserControls/Banner.ascx" TagName="Banner" TagPrefix="uc1" %>
<%@ Register Src="UserControls/VoteMachine.ascx" TagName="VoteMachine" TagPrefix="asp" %>
<%@ Register Src="UserControls/Competition.ascx" TagName="Competition" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <div class="box">
        <div class="heading">
            <a href="#">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></a>
        </div>
        <div class="box-content">
            <div class="height-10"></div>
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
                <script type="text/javascript">                            var switchTo5x = true;</script>
                <script type="text/javascript" src="/js/button.js"></script>
                <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                <script type="text/javascript">                            stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                    displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
            </div>
            <div class="height-10"></div>
            <div class="list">
                <p>
                    <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
                </p>
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
                <p>
                    <a href="" id="hyp_Banner" runat="server" target="_blank"></a>
                </p>

            </div>
            <div class="height-10"></div>

            <div class="filter-result">
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

                            <asp:Repeater ID="grd_University" runat="server">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <div class='<%#((bool)Eval("bFeatured")) == true ? "cls_featured" : "none"%>'>

                                            <div class="imgblock">
                                                <img src='<%# "https://www.eduvidya.com/admin/Upload/University/" + Eval("strImage") %>'
                                                    alt='<%# Eval("strTitle") %>' />
                                            </div>
                                            <div class="contentblock">
                                                <div style="float: left">
                                                    <a href='<%# VirtualPathUtility.ToAbsolute("~/University/" + Eval("strTitle").ToString().Replace(" ","-").Replace(".","_")) %>'>
                                                        <%# Eval("strTitle")%></a> :
                                                        <br />
                                                </div>
                                                <div style="float: right">
                                                    <%# Eval("strCity")%>
                                                </div>
                                                <br />
                                                <%# eduCommon.fn_GetShortText(Eval("strDesc").ToString())%>
                                                <br />
                                                <%# "<b>Address : </b>" + eduCommon.fn_TrimHtmlContent(Eval("strAddress").ToString())%>
                                            </div>
                                        </div>

                                    </li>
                                </ItemTemplate>
                                <FooterTemplate></ul></FooterTemplate>
                            </asp:Repeater>



                            <asp:Repeater ID="grd_Institute" runat="server">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <div class='<%#((bool)Eval("bFeatured")) == true ? "cls_featured" : "none"%>'>
                                            <div class="imgblock">
                                                <img src='<%# "https://www.eduvidya.com/admin/Upload/Institutes/" + Eval("strPhoto") %>'
                                                    alt='<%# Eval("strTitle") %>' />
                                            </div>
                                            <div class="contentblock">
                                                <div style="float: left">
                                                    <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strTitle").ToString().Replace(" ","-").Replace(".","_")) %>'>
                                                        <%# Eval("strTitle") %></a>
                                                </div>
                                                <div style="float: right">
                                                    <%# Eval("strCity")%>
                                                </div>
                                                <br />
                                                <%# eduCommon.fn_GetShortText(Eval("strDesc").ToString())%><br />
                                                <br />
                                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strTitle").ToString().Replace(" ","-").Replace(".","_") + "/Courses") %>'>
                                                    <%# Eval("strTitle") + " Courses Offered"%></a>
                                                <br />
                                                <br />
                                                <%# "<b>Address : </b>" + eduCommon.fn_TrimHtmlContent(Eval("strContactDetails").ToString())%>
                                            </div>

                                        </div>

                                    </li>
                                </ItemTemplate>
                                <FooterTemplate></ul></FooterTemplate>
                            </asp:Repeater>

                            <asp:Repeater ID="grd_Schools" runat="server">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <div class='<%#((bool)Eval("bFeatured")) == true ? "cls_featured" : "none"%>'>
                                            <div class="imgblock">
                                                <img src='<%# "https://www.eduvidya.com/admin/Upload/Schools/" + Eval("strPhoto") %>'
                                                    alt='<%# Eval("strTitle") %>' />
                                            </div>
                                            <div class="contentblock">
                                                <div style="float: left">
                                                    <a href='<%# VirtualPathUtility.ToAbsolute("~/Schools/" + Eval("strTitle").ToString().Replace(" ","-").Replace(".","_")) %>'>
                                                        <%# Eval("strTitle") %></a>
                                                </div>
                                                <div style="float: right">
                                                    <%# Eval("strCity") %>
                                                </div>
                                                <br />
                                                <%# eduCommon.fn_GetShortText(Eval("strDesc").ToString())%><br />
                                                <br />
                                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Schools/" + Eval("strTitle").ToString().Replace(" ","-").Replace(".","_") + "#admissions") %>'>
                                                    <%# Eval("strTitle") + " Admission Procedure"%></a><br />
                                                <br />
                                                <%# "<b>Address : </b>" + eduCommon.fn_TrimHtmlContent(Eval("strContactDetails").ToString())%>
                                            </div>
                                        </div>

                                    </li>
                                </ItemTemplate>
                                <FooterTemplate></ul></FooterTemplate>
                            </asp:Repeater>

                            <asp:Repeater ID="grd_Courses" runat="server">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <div style="float: left">
                                            <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-") + "/Courses/" + Eval("strTitle").ToString().Replace(" ","-"))%>'>
                                                <%# Eval("strTitle") %></a>
                                        </div>
                                        <div style="float: right">
                                            <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-"))%>'>
                                                <%# Eval("strInstitute")%></a>
                                        </div>
                                        <br />
                                        <%# eduCommon.fn_GetShortText(Eval("strDesc").ToString())%>
                                           
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate></ul></FooterTemplate>
                            </asp:Repeater>

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
         
            <div class="related-dv">

                <asp:Repeater ID="rpt_Links" runat="server">
                    <HeaderTemplate>
                        <div class="heading">
                            <p>Search By City</p>
                        </div>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <a href='<%# Eval("strLink") %>'>
                                <%# Eval("strTitle") %></a></li>
                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                </asp:Repeater>

            </div>
            <div class="google-ad " id="divyoutubeframe" runat="server" visible="false">

                

                <iframe width="340" height="280" id="YoutubeFrame" runat="server" frameborder="0"
                    allowfullscreen></iframe>

            </div>

        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_rightBottom" runat="Server">
</asp:Content>

