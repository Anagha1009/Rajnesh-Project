<%@ Page Title="" Language="C#" MasterPageFile="~/ClientDetailsMaster.master" AutoEventWireup="true"
    CodeFile="SchoolDetails.aspx.cs" Inherits="School_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="UserControls/Schools.ascx" TagName="Schools" TagPrefix="asp" %>
<%@ Register Src="CustomControls/Schools.ascx" TagName="Schools" TagPrefix="uc1" %>
<%@ Register Src="UserControls/VoteMachine.ascx" TagName="VoteMachine" TagPrefix="asp" %>
<%@ Register Src="UserControls/Competition.ascx" TagName="Competition" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
    <%--<link href="https://www.eduvidya.com/Google_Code/screen.css" rel="stylesheet" type="text/css" />
    <script src="https://www.eduvidya.com/JW_Player/jwplayer.js" type="text/javascript"></script>--%>
    <link href="css/screen.css" rel="stylesheet" />
    <script src="JW_Player/jwplayer.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_bottomHead" runat="Server">
    <%--DomTab Starts--%>
    <link href="css/domtab.css" rel="stylesheet" />
   <%-- <style type="text/css">
        @import "https://www.eduvidya.com/domtab/domtab.css";
    </style>--%>
    <%--DomTab End--%>
    <script src="JW_Player/jwplayer.js" type="text/javascript"></script>
   <%-- <script src="https://www.eduvidya.com/JW_Player/jwplayer.js" type="text/javascript"></script>--%>
    <%--    <script>
        $(document).ready(function () {
            $("#Reviews").click(function () {
                //$(this).animate(function(){
                $('html, body').animate({
                    scrollTop: $("#ReviewsBox").offset().top
                }, 2000);
                //});
            });
        });
</script>--%>
    <%--<script src="https://www.eduvidya.com/js/jquery.cycle.all.latest.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="JW_Player/jwplayer.js"></script>
    <%--  <script src="https://www.eduvidya.com/js/jquery.prettyPhoto.js" type="text/javascript"
        charset="utf-8"></script>
    <script type="text/javascript" charset="utf-8">
        $(document).ready(function () {
            $("a[rel^='prettyPhoto']").prettyPhoto();
        });
    </script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.slideshow').cycle({
                fx: 'zoom',
                sync: false,
                delay: -2000
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <div class="box">
        <div class="heading">
            <a href="#">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
                <asp:Literal ID="ltl_City" runat="server"></asp:Literal>
            </a>
        </div>
        <div class="box-content">
            <ul class="info">
                <li class="college-logo">
                    <img id="img_Photo" runat="server" />

                </li>
                <li class="college-detail">
                    <p>
                        <asp:Literal ID="ltl_Details" runat="server"></asp:Literal>
                    </p>

                    <div class="social-share">
                        <script type="text/javascript">                                    var switchTo5x = true;</script>
                        <script type="text/javascript" src="js/button.js"></script>
                        <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                        <script type="text/javascript">                                    stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                        <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                            displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                                displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
                    </div>
                </li>
                <li class="college-image">
                    <div class="slideshow">
                        <ul class="inner-bx-slider">
                            <asp:Repeater ID="rpt_Photos" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <img src='<%# "https://www.eduvidya.com/admin/Upload/Schools/" + Eval("strPhoto") %>'
                                            alt='<%# Eval("strTitle") %>' /></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </li>
            </ul>


            <div class="height-10"></div>
            <div class="rating">
                <ul>
                    <li>
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
                    </li>

                </ul>
            </div>
            <div class="height-10"></div>
            <div class="details-page-tab">

                <ul class="tab-section">
                    <li><a href="#about" title="about">About</a></li>
                    <li><a href="#admissions" title="admissions">Admissions</a></li>
                    <li><a href="#facilities" title="facilities">Facilities</a></li>
                    <li><a href="#address" title="address">Address</a></li>
                    <li><a href="#map" title="map">Map</a></li>
                    <li><a href="#photos" title="photos">Photos</a></li>
                    <li><a href="#videos" title="videos">Videos</a></li>
                    <li id="lnkReviews" runat="server"><a href="#tabreviews" title="tabreviews">Reviews</a></li>
                </ul>
                <div class="tab-section-inner-wrapper">
                    <div id="about" class="tab-content-inner">
                        <a name="about"></a>
                        <p>
                            <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div id="admissions" class="tab-content-inner">
                        <a name="admissions"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_AdmTitle" runat="server"></asp:Literal></strong>
                        </p>
                        <br />
                        <p>
                            <asp:Literal ID="ltl_Admissions" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <br />
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

                        </p>
                    </div>
                    <div id="facilities" class="tab-content-inner">
                        <a name="facilities"></a>
                        <p>
                            <strong>Facilities</strong>
                        </p>
                        <br />
                        <p>
                            <asp:Literal ID="ltl_Facilities" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div id="address" class="tab-content-inner">
                        <a name="address"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_SchAddrs" runat="server"></asp:Literal><br />
                            </strong>
                        </p>
                        <br />

                        <p>

                            <asp:Literal ID="ltl_ContactDetails" runat="server"></asp:Literal>
                        </p>

                    </div>
                    <div id="map" class="tab-content-inner">
                        <a name="map"></a>
                        <p>
                            <strong>Map:</strong>
                        </p>
                        <br />
                        <div class="GoogleCode">
                            <div class="full">
                                <asp:HiddenField ID="hf_ContactDetails" runat="server" Value="" />
                            </div>
                        </div>
                    </div>
                    <div id="photos" class="tab-content-inner">
                        <a name="photos"></a>
                        <p>
                            <strong>Photos<br />
                            </strong>
                        </p>
                        <ul>
                            <asp:DataList ID="dl_Photos" runat="server" RepeatColumns="4" Width="100%">
                                <ItemTemplate>
                                    <li>
                                        <div class="imgblock">
                                            <img src='<%# "https://www.eduvidya.com/admin/Upload/Schools/" + Eval("strPhoto") %>'
                                                alt='<%# Eval("strTitle") %>' />
                                        </div>
                                        <div class="contentblock">
                                            <%# Eval("strTitle") %>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:DataList>
                        </ul>

                    </div>
                    <div id="videos" class="tab-content-inner">
                        <a name="videos"></a>
                        <p>
                            <strong>Videos<br />
                            </strong>
                        </p>
                        <ul>
                            <asp:DataList ID="dl_Videos" runat="server" RepeatColumns="4" Width="100%">
                                <ItemTemplate>
                                    <li>
                                        <div>
                                            <div id='<%# Container.ItemIndex + 1 %>'>
                                                This text will be replaced
                                            </div>
                                            <script type='text/javascript'>
                                                jwplayer('<%# Container.ItemIndex + 1 %>').setup({
                                                    'flashplayer': 'https://www.eduvidya.com/JW_Player/player.swf',
                                                    'file': '<%# Eval("strUrl") %>',
                                                    'controlbar': 'bottom',
                                                    'width': '240',
                                                    'height': '170',
                                                    'skin': 'https://www.eduvidya.com/JW_Player/skewd.zip'
                                                });
                                            </script>
                                            <div style="padding-top: 5px">
                                                <%# Eval("strTitle") %>
                                            </div>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:DataList>
                        </ul>

                    </div>
                    <div id="tabreviews" class="tab-content-inner">
                        <a name="tabreviews"></a>
                        <div id="ReviewBox" runat="server">
                            <p><a href='<%= VirtualPathUtility.ToAbsolute("~/Schools/" + RouteData.Values["School"].ToString() + "/Reviews")%>'>Reviews</a></p>
                            <ul>
                                <asp:Repeater ID="rpt_Review" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="contentblock">
                                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Schools/" + RouteData.Values["School"].ToString() + "/Reviews/" + Eval("strTitle").ToString().Replace(" ","-") + "/" + Eval("iID"))%>'>
                                                    <%# Eval("strTitle") %></a>
                                                <br />
                                                <%# fn_ShortDetails(Eval("strDetails").ToString())%>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="height-10"></div>
            <div class="google-ad linkunitads">
                <script type="text/javascript">
                    google_ad_client = "ca-pub-4037987430386783";
                    /* Eduvidya-Link-728&#42;15 */
                    google_ad_slot = "4438952914";
                    google_ad_width = 728;
                    google_ad_height = 15;

                </script>
                <script type="text/javascript" src="https://pagead2.googlesyndication.com/pagead/show_ads.js">
                </script>
            </div>
            <div class="height-10"></div>
            <div class="need-edu-loan"><a target="_blank" href="https://www.eduvidya.com/Education-Help.aspx">Need Education Loan?</a></div>
            <div class="height-10"></div>
            <div class="related-dv">
                <asp:Schools ID="Schools1" runat="server" />
                <%--<uc1:Schools ID="Schools2" runat="server" />--%>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cp_Bottom" runat="Server">
    <%-- <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
        <tr>
            <td width="350px" align="left" valign="top">
                <script type="text/javascript"><!--
    google_ad_client = "ca-pub-4037987430386783";
    /* Eduvidya-336&#42;280 */
    google_ad_slot = "7532020116";
    google_ad_width = 336;
    google_ad_height = 280;
    //-->
                </script>
                <script type="text/javascript" src="https://pagead2.googlesyndication.com/pagead/show_ads.js">
                </script>
            </td>
            <td align="left" valign="top" class="map">
                <a name="map" id="map"></a>
                <h2>Map</h2>
                <div class="GoogleCode">
                    <div class="full">
                        <asp:HiddenField ID="hf_ContactDetails" runat="server" Value="" />
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                    <tr>
                        <td width="49%" align="left" valign="middle">
                            <asp:VoteMachine ID="Vote1" runat="server" />
                        </td>
                        <td width="25px"></td>
                        <td width="49%" align="left" valign="middle" style="padding-right: 25px">
                            <asp:Competition ID="Compete1" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>--%>
    <script src="https://maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
    <%--<script src="https://www.eduvidya.com/Google_Code/jquery.auto-geocoder.js" type="text/javascript"></script>--%>
    <script src="js/auto-geocoder.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#hf_ContactDetails')

            .bind("auto-geocoder.onGeocodeSuccess", function () {
                Success("Geocode success. (Single Element) #hf_ContactDetails");
            })

            .autoGeocoder();
        });

        function Success(text) {
        }

        function Failure(text) {
            $('#tr_google_Core').remove();
        }
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp_rightBottom" runat="Server">
    <%-- <div class="related-dv">
        <uc1:Schools ID="Schools2" runat="server" />
    </div>--%>
</asp:Content>
