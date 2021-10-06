<%@ Page Title="" Language="C#" MasterPageFile="~/ClientDetailsMaster.master" AutoEventWireup="true"
    CodeFile="InstituteDetails.aspx.cs" Inherits="Institute_Details" %>

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
    <script type="text/javascript" src="js/latest.js"></script>
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
                                        <img src='<%# "https://www.eduvidya.com/admin/Upload/Institutes/" + Eval("strPhoto") %>'
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
                    <li><a href="https://www.eduvidya.com/Eduvidya-Reviews.aspx" target="_blank">Rate this College</a></li>
                    <li><a href="https://www.eduvidya.com/Education-Help.aspx" target="_blank">Need Admission Help?</a></li>
                </ul>
            </div>
            <div class="height-10"></div>
            <div class="details-page-tab">

                <ul class="tab-section">
                    <li><a href="#about" title="about">About</a></li>
                    <li><a href="#admissions" title="admissions">Admissions</a></li>
                    <li><a href="#facilities" title="facilities">Facilities</a></li>
                    <li><a href="#courses" title="courses">Courses</a></li>
                    <li><a href="#exams" title="exams">Exams</a></li>
                    <li><a href="#placements" title="placements">Placements</a></li>
                    <li><a href="#address" title="address">Address</a></li>
                    <li><a href="#map" title="map">Map</a></li>
                    <li><a href="#photos" title="photos">Photos</a></li>
                    <li><a href="#videos" title="videos">Videos</a></li>
                    <li id="lnkReviews" runat="server"><a href="#tabreviews" title="tabreviews">Reviews</a></li>
                    <li class="college-compare-tab"><a target="_blank" href="https://www.eduvidya.com/Comparisions.aspx">Compare Colleges</a></li>

                </ul>
                <div class="tab-section-inner-wrapper">
                    <div id="about" class="tab-content-inner ">
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
                    <div id="facilities" class="tab-content-inner">
                        <a name="facilities"></a>
                        <p>
                            <strong>Facilities:</strong>
                        </p>
                        <br />
                        <p>
                            <asp:Literal ID="ltl_Facilities" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div id="courses" class="tab-content-inner">
                        <a name="courses"></a>
                        <p><strong>Courses: </strong></p>
                        <p>
                            <a href='<%= VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString() + "/Courses")%>'>
                                <asp:Literal ID="ltl_CoursesOffered" runat="server"></asp:Literal></a>

                            <asp:Literal ID="ltl_Courses" runat="server"></asp:Literal>
                        </p>
                        <ul>
                            <asp:Repeater ID="rpt_Courses" runat="server">
                                <ItemTemplate>
                                    <li><a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString() + "/Courses/" + Eval("strTitle").ToString().Replace(" ","-"))%>'>
                                        <%# Eval("strTitle") %></a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div id="exams" class="tab-content-inner">
                        <a name="exams"></a>
                        <p>
                            <strong>Exams Accepted:</strong>
                        </p>
                        <br />
                        <p>
                            <asp:Literal ID="ltl_ExamAccepted" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div id="placements" class="tab-content-inner">
                        <a name="placements"></a>
                        <p>
                            <strong>Placements:</strong>
                        </p>
                        <br />
                        <address>
                            <p>
                                <asp:Literal ID="ltl_Placements" runat="server"></asp:Literal>
                            </p>
                        </address>
                    </div>
                    <div id="address" class="tab-content-inner">
                        <a name="address"></a>
                        <p>
                            <strong>Address:</strong>
                        </p>
                        <br />
                        <address>
                            <p>
                                <asp:Literal ID="ltl_ContactDetails" runat="server"></asp:Literal>
                            </p>
                        </address>
                    </div>
                    <div id="photos" class="tab-content-inner">
                        <a name="photos"></a>
                        <ul>
                            <asp:DataList ID="dl_Photos" runat="server" RepeatColumns="4" Width="100%">
                                <HeaderTemplate>Photos</HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <div class="imgblock">
                                            <img src='<%# "https://www.eduvidya.com/admin/Upload/Institutes/" + Eval("strPhoto") %>'
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
                        <ul>
                            <asp:DataList ID="dl_Videos" runat="server" RepeatColumns="5" CellPadding="5" CellSpacing="5"
                                Width="100%">
                                <HeaderTemplate>Videos</HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <div>
                                            <iframe width="340" height="240" src='<%# "https://www.youtube.com/embed/" + fn_GetUrl(Eval("strUrl").ToString())%>'
                                                frameborder="0" allowfullscreen></iframe>
                                            <div style="padding-top: 5px">
                                                <%# Eval("strTitle") %>
                                            </div>
                                        </div>
                                    </li>

                                </ItemTemplate>
                            </asp:DataList>
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
                    <div id="tabreviews" class="tab-content-inner">
                        <a name="tabreviews"></a>
                        <p>
                            <strong>Review:</strong>
                        </p>
                        <div id="ReviewBox" runat="server">

                            <p>
                                <a href='<%= VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString() + "/Reviews")%>'>Reviews</a>
                            </p>
                            <ul>

                                <asp:Repeater ID="rpt_Review" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="contentblock">
                                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString() + "/Reviews/" + Eval("strTitle").ToString().Replace(" ","-") + "/" + Eval("iID"))%>'
                                                    class="rec_links">
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
                <%-- <script type="text/javascript"><!--
    google_ad_client = "ca-pub-4037987430386783";
    /* Eduvidya-336&#42;280 */
    google_ad_slot = "7532020116";
    google_ad_width = 336;
    google_ad_height = 280;
    //-->
                </script>
                <script type="text/javascript" src="https://pagead2.googlesyndication.com/pagead/show_ads.js">
                </script>--%>
            </div>
            <div class="height-10"></div>
            <div class="need-edu-loan"><a target="_blank" href="https://www.eduvidya.com/Education-Help.aspx">Need Education Loan?</a></div>
            <div class="height-10"></div>
            <div class="related-dv">
                <div class="heading">
                    <p>Other Colleges in Same City</p>
                </div>
                <ul>
                    <asp:Repeater ID="rpt_Institutes" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strTitle").ToString().Replace(" ","-")) %>'>
                                    <%# Eval("strTitle") %></a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>

    <script src="https://maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
    <script  type="text/javascript" src="js/auto-geocoder.js"></script>
    <%--<script src="https://www.eduvidya.com/Google_Code/jquery.auto-geocoder.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        $(function () {
            //$(".redirect").click(function () {
            //    window.location = "https://www.eduvidya.com/Comparisions.aspx";
            //});

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
<%--<asp:Content ID="Content5" ContentPlaceHolderID="cp_Bottom" runat="Server">
    <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
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
            <td align="left" valign="top" class="map"></td>
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
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp_rightBottom" runat="Server">
    <uc1:Institutes ID="Institutes1" runat="server" />
</asp:Content>--%>
