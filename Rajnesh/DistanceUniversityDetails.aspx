<%@ Page Title="" Language="C#" MasterPageFile="~/ClientDetailsMaster.master" AutoEventWireup="true"
    CodeFile="DistanceUniversityDetails.aspx.cs" Inherits="University_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="CustomControls/Institutes.ascx" TagName="Institutes" TagPrefix="uc1" %>
<%@ Register Src="UserControls/Colleges.ascx" TagName="Colleges" TagPrefix="asp" %>
<%@ Register Src="UserControls/VoteMachine.ascx" TagName="VoteMachine" TagPrefix="asp" %>
<%@ Register Src="UserControls/Competition.ascx" TagName="Competition" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_bottomHead" runat="Server">
    <script type="text/javascript" src="/js/latest.js"></script>
    <%--<script src="https://www.eduvidya.com/js/jquery.cycle.all.latest.js" type="text/javascript"></script>--%>
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
                        <script type="text/javascript" src="/js/button.js"></script>
                        <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                        <script type="text/javascript">                                    stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                        <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                            displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                                displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
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
                    <li><a href="#courses" title="courses">Courses</a></li>
                    <li><a href="#address" title="address">Address</a></li>
                    <li><a href="#map" title="map">Map</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Distance-University/" + RouteData.Values["University"].ToString().Replace(" ","-").Replace(".","_") + "/StudyCenters")%>'>Study Centers</a></li>
                    <li><a href="#notifications" title="notifications">Notifications</a></li>

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
                            <strong>Admissions:</strong>
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
                    <div id="courses" class="tab-content-inner">
                        <a name="courses"></a>
                        <p>
                            <a href='<%= VirtualPathUtility.ToAbsolute("~/Distance-University/" + RouteData.Values["University"].ToString().Replace(" ","-").Replace(".","_") + "/Courses")%>'>
                                <asp:Literal ID="ltl_CoursesOffered" runat="server"></asp:Literal></a>

                            <%--<asp:Literal ID="ltl_Courses" runat="server"></asp:Literal>--%>
                        </p>
                        <ul>
                            <asp:Repeater ID="rpt_Courses" runat="server">
                                <ItemTemplate>
                                    <li><a href='<%# VirtualPathUtility.ToAbsolute("~/Distance-University/" + Eval("strInstitute").ToString().Replace(" ","-").Replace(".","_") + "/Courses/" + Eval("strName").ToString().Replace(" ","-").Replace(".","_"))%>'>
                                        <%# Eval("strName")%></a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div id="address" class="tab-content-inner">
                        <a name="address"></a>
                        <p>
                            <strong>Address:</strong>
                        </p>
                        <br />
                        <address>
                            <p>
                                <asp:Literal ID="ltl_ContactDetails" runat="server"></asp:Literal><br />
                                <h2>Results</h2>
                                <asp:Literal ID="ltl_Results" runat="server"></asp:Literal>
                            </p>
                        </address>
                    </div>
                    <div id="notifications" class="tab-content-inner">
                        <a name="notifications"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_NotificationTitle" runat="server"></asp:Literal></strong>
                        </p>
                        <br />
                        <ul>
                            <asp:Repeater ID="rpt_Notifications" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="contentblock">
                                            <a href='<%# Eval("strUrl") %>'>
                                                <%# Eval("strNotificationTitle")%></a>
                                            <br />
                                            <%# Eval("strNotificationDesc")%>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
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
            <div class="related-dv">
                <div class="heading">
                    <p>Other Universities</p>
                </div>
                <ul>
                    <asp:Repeater ID="rpt_University" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Distance-University/" + Eval("strName").ToString().Replace(" ","-")) %>'>
                                    <%# Eval("strName")%></a>
                            </li>
                        </ItemTemplate>

                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <script src="https://maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
    <script type="text/javascript" src="/js/auto-geocoder.js"></script>
    <%--<script src="https://www.eduvidya.com/Google_Code/jquery.auto-geocoder.js" type="text/javascript"></script>--%>
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
                    
                </div>
            </td>
        </tr>
    </table>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp_rightBottom" runat="Server">
</asp:Content>
