<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="SchoolDetails.aspx.cs"  Inherits="School_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="UserControls/Schools.ascx" TagName="Schools" TagPrefix="asp" %>
<%@ Register Src="CustomControls/Schools.ascx" TagName="Schools" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
    <link href="https://www.eduvidya.com/Google_Code/screen.css" rel="stylesheet" type="text/css" />
    <script src="https://www.eduvidya.com/JW_Player/jwplayer.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" valign="top" class="bestplace_head">
                <ul class="tabs">
                    <li>
                        <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></li>
                    <li><a href="#admissions">Admissions</a></li>
                    <li><a href="#facilities">Facilities</a></li>
                    <li><a href="#address">Address</a></li>
                    <li><a href="#map">Map</a></li>
                    <li><a href="#photos">Photos</a></li>
                    <li><a href="#videos">Videos</a></li>
                </ul>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" class="best_border">
                <div class="album">
                    <img id="img_Photo" runat="server" />
                </div>
                <div>
                    <div itemscope itemtype="https://data-vocabulary.org/Review-aggregate">
                        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </asp:ToolkitScriptManager>
                        <div style="float: left">
                            <span itemprop="itemreviewed">
                                <asp:Literal ID="ltlTitle" runat="server"></asp:Literal></span>
                        </div>
                        <div style="float:right">
                            <div class="EducationHelp">
                                <a href="https://www.eduvidya.com/Education-Help.aspx" target="_blank">Need Admission
                                    Help?</a>
                            </div>
                            <div style="clear: both">
                                &nbsp;</div>
                            <a href="https://www.eduvidya.com/Eduvidya-Reviews.aspx" class="RateReview" target="_blank">
                                Rate this School</a>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div>
                            <div class="Ratingleft">
                                <asp:Rating ID="rt_Rate" runat="server" StarCssClass="StarCss" FilledStarCssClass="FilledStarCss"
                                    EmptyStarCssClass="EmptyStarCss" WaitingStarCssClass="WaitingStarCss" AutoPostBack="true"
                                    OnChanged="rt_Rate_Changed" MaxRating="5">
                                </asp:Rating>
                            </div>
                            <div class="RatingBox">
                                <asp:Literal ID="ltl_RatingBox" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Literal ID="ltl_Details" runat="server"></asp:Literal>
                <div style="clear: both; height: 7px">
                    &nbsp;</div>
                <h2>
                    Description</h2>
                <br />
                <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
                <br />
                <a id="admissions" name="admissions"></a>
                <h2>
                    <asp:Literal ID="ltl_AdmTitle" runat="server"></asp:Literal></h2>
                <br />
                <asp:Literal ID="ltl_Admissions" runat="server"></asp:Literal>
                <br />
                <a id="facilities" name="facilities"></a>
                <h2>
                    Facilities</h2>
                <br />
                <asp:Literal ID="ltl_Facilities" runat="server"></asp:Literal>
                <br />
                <a id="address" name="address"></a>
                <h2>
                    <asp:Literal ID="ltl_SchAddrs" runat="server"></asp:Literal></h2>
                <br />
                <asp:Literal ID="ltl_ContactDetails" runat="server"></asp:Literal>
                <br />
                <div style="margin-left: -5px">
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
                <br />
                <a id="map" name="map"></a>
                <h2>
                    Maps</h2>
                <br />
                <div class="GoogleCode">
                    <div class="full">
                        <asp:HiddenField ID="hf_ContactDetails" runat="server" Value="" />
                    </div>
                </div>
                <br />
                <div style="clear: both; height: 7px">
                    &nbsp;</div>
                <a id="photos" name="photos"></a>
                <h2>
                    Photos</h2>
                <br />
                <asp:DataList ID="dl_Photos" runat="server" RepeatColumns="4" Width="100%">
                    <ItemStyle Width="25%" HorizontalAlign="Left" VerticalAlign="Top" />
                    <ItemTemplate>
                        <div class="portfolio">
                            <img src='<%# "https://www.eduvidya.com/admin/Upload/Schools/" + Eval("strPhoto") %>'
                                alt='<%# Eval("strTitle") %>' />
                            <div style="padding-top: 5px">
                                <%# Eval("strTitle") %>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <br />
                <div style="clear: both; height: 7px">
                    &nbsp;</div>
                <a id="videos" name="videos"></a>
                <h2>
                    Videos</h2>
                <br />
                <asp:DataList ID="dl_Videos" runat="server" RepeatColumns="5" CellPadding="5" CellSpacing="5"
                    Width="100%">
                    <ItemTemplate>
                        <div>
                            <div id='<%# Container.ItemIndex + 1 %>'>
                                This text will be replaced</div>
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
                    </ItemTemplate>
                </asp:DataList>
                <br />
                <div style="padding: 10px 0px; float: left">
                    <script type="text/javascript">                        var switchTo5x = true;</script>
                    <script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>
                    <script type="text/javascript">                        stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                    <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                        displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'>
                    </span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'>
                    </span>
                </div>
                <div class="EducationLoan">
                    <a href="https://www.eduvidya.com/Education-Help.aspx" target="_blank">Need Education
                        Loan?</a></div>
                <br />
                <asp:Schools ID="Schools1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="bottom">
                &nbsp;
            </td>
        </tr>
    </table>
    <script src="https://maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
    <script src="https://www.eduvidya.com/Google_Code/jquery.auto-geocoder.js" type="text/javascript"></script>
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
<asp:Content ID="Content3" ContentPlaceHolderID="cp_rightBottom" runat="Server">
    <uc1:Schools ID="Schools2" runat="server" />
</asp:Content>
