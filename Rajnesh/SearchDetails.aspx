<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="SearchDetails.aspx.cs" Inherits="SearchDetails" %>

<asp:Content ID="MetaContent" runat="server" ContentPlaceHolderID="head">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cp_bottomHead">
    <%--<script type="text/javascript" src="https://www.eduvidya.com/lib/jquery-1.10.1.min.js"></script>--%>

   <%-- <script type="text/javascript" src="js/jquery-3.6.0.min.js"></script>--%>
    <script type="text/javascript" src="https://www.eduvidya.com/fancybox/lib/jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="https://www.eduvidya.com/fancybox/source/jquery.fancybox.js?v=2.1.5"></script>
    <link rel="stylesheet" type="text/css" href="https://www.eduvidya.com/fancybox/source/jquery.fancybox.css?v=2.1.5"
        media="screen" />
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('.fancybox').fancybox();

            $(".fancybox-effects-c").fancybox({
                wrapCSS: 'fancybox-custom',
                closeClick: true,

                openEffect: 'none',

                helpers: {
                    title: {
                        type: 'inside'
                    },
                    overlay: {
                        css: {
                            'background': 'rgba(238,238,238,0.85)'
                        }
                    }
                }
            });
        });
    </script>
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

            <div class="height-10"></div>
            <div class="rating">
                <div id="score" style="cursor: pointer;">
                    <%--   <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>--%>
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
                <script type="text/javascript">                        var switchTo5x = true;</script>
                <script type="text/javascript" src="/js/button.js"></script>
                <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                <script type="text/javascript">                        stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                    displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
            </div>
            <div class="height-10"></div>
            <div class="filter-result">
                <div class="detail-list">
                    <ul>
                        <li>
                            <div class="imgblock">
                                <img id="img_Pages" runat="server" />
                            </div>
                            <div class="contentblock">
                                <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
                            </div>
                        </li>
                    </ul>

                    <ul>
                        <li>
                            <asp:DataList ID="dl_Photos" runat="server" RepeatColumns="4" Width="100%">
                                <HeaderTemplate>
                                    <h3>Photos</h3>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="portfolio">
                                        <a class="fancybox-effects-c" href='<%# "https://www.eduvidya.com/files/PagePhoto/" + Eval("strPhoto") %>'
                                            data-fancybox-group="gallery" title='<%# Eval("strTitle") %>'>
                                            <img src='<%# "https://www.eduvidya.com/files/PagePhoto/" + Eval("strPhoto") %>' alt='<%# Eval("strTitle") %>' /></a>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>

                        </li>
                    </ul>
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
    <%--<table width="100%" cellpadding="0px" cellspacing="0px" border="0px" align="left">
        <tr>
            <td align="left" class="bestplace_head">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="justify" class="best_border">
                <img id="img_Pages" runat="server" class="_Photo_frame" />
                <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
                <div style="clear: both">
                    &nbsp;</div>
                <asp:DataList ID="dl_Photos" runat="server" RepeatColumns="4" Width="100%">
                    <ItemStyle Width="25%" HorizontalAlign="Left" VerticalAlign="Top" />
                    <HeaderTemplate>
                        <h2>
                            Photos</h2>
                        <br />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="portfolio">
                            <a class="fancybox-effects-c" href='<%# "https://www.eduvidya.com/files/PagePhoto/" + Eval("strPhoto") %>'
                                data-fancybox-group="gallery" title='<%# Eval("strTitle") %>'>
                                <img src='<%# "https://www.eduvidya.com/files/PagePhoto/" + Eval("strPhoto") %>' alt='<%# Eval("strTitle") %>' /></a>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td align="left">
                <div class="leftbox" style="float:left">
                    <div class="Ratingleft">
                        <asp:Rating ID="rt_Rate" runat="server" StarCssClass="StarCss" FilledStarCssClass="FilledStarCss"
                            EmptyStarCssClass="EmptyStarCss" WaitingStarCssClass="WaitingStarCss" AutoPostBack="true"
                            OnChanged="rt_Rate_Changed" MaxRating="5">
                        </asp:Rating>
                    </div>
                    <div style="clear:both"></div>
                    <div class="RatingBox">
                        <asp:Literal ID="ltl_RatingBox" runat="server"></asp:Literal>
                    </div>
                </div>
                <div style="float: left">
                    <script type="text/javascript">                        var switchTo5x = true;</script>
                    <script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>
                    <script type="text/javascript">                        stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                    <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                        displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'>
                    </span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'>
                    </span>
                </div>
            </td>
        </tr>
        <tr>
            <td class="bottom">
                &nbsp;
            </td>
        </tr>
    </table>--%>
</asp:Content>
