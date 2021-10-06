<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Query-List.aspx.cs" Inherits="QueryList" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="Pager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Queries on Education, Colleges, Courses, Schools, Universities</title>
    <meta name="Description" content="Get Queries on Education, Colleges, Courses, Schools, Universities" />
    <meta name="Keywords" content="Queries on Education" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <div class="box">
        <div class="heading"><a href="#">Queries on Education</a></div>
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
                <script type="text/javascript"> var switchTo5x = true;</script>
                <script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>
                <script type="text/javascript"> stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                    displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
            </div>
            <div class="height-10"></div>
            <div class="list">
                <p>
                    Given below are the most searched queries on education on our site.
                </p>
            </div>

            <div class="filter-result">

                <div class="detail-list">
                    <ul>

                        <asp:Repeater ID="rpt_QueryList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <a href='<%# VirtualPathUtility.ToAbsolute("~/" + Eval("strTitle").ToString().Replace(" ","-")) %>'>
                                        <%# Eval("strTitle") %></a><br />
                                    <span><%# fn_ShortDetails(Eval("strDesc").ToString())%></span>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <Pager:CollectionPager ID="CPager" runat="server" BackNextDisplay="HyperLinks" PageSize="9999"
                        BackNextLocation="Split" BackText="Prev" PageNumbersSeparator="&amp;nbsp;" ShowFirstLast="False"
                        ResultsLocation="Bottom" PagingMode="QueryString" SliderSize="20" UseSlider="True"
                        LabelText="" NextText="Next" ResultsFormat="" MaxPages="10000" LabelStyle=""
                        QueryStringKey="Page" BackNextButtonStyle="" BackNextLinkSeparator="·" BackNextStyle=""
                        ControlCssClass="" ControlStyle="" FirstPageHolderId="" FirstText="First" HideOnSinglePage="True"
                        IgnoreQueryString="False" LastText="Last" PageNumbersDisplay="Numbers" PageNumbersStyle=""
                        PageNumberStyle="" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;FONT-WEIGHT: bold;"
                        SecondPageHolderId="" SectionPadding="10" ShowLabel="True" ShowPageNumbers="True">
                    </Pager:CollectionPager>
                    <div id="PagerDiv" runat="server" class="PageNo">
                    </div>


                </div>
            </div>
            <div class="google-ad">
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
        </div>

    </div>
</asp:Content>
