<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="EntranceExamColleges.aspx.cs" Inherits="College_Details" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="Pager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
    <%--<link href="https://www.eduvidya.com/Google_Code/screen.css" rel="stylesheet" type="text/css" />
    <script src="https://www.eduvidya.com/JW_Player/jwplayer.js" type="text/javascript"></script>--%>
    <link href="/css/screen.css" rel="stylesheet" />
    <script src="/JW_Player/jwplayer.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scrManager" runat="server">
    </asp:ScriptManager>
    <div class="box">
        <div class="heading">
            <a href="#">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></a>
        </div>
        <div class="box-content">

            <div class="details-page-tab">
                <ul class="tab-section">
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString()) %>'>Description</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString() + "#admissions")%>'>Admission Proceducre</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString() + "#dates")%>'>Exam Dates</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString() + "#syllabus")%>'>Syllabus</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString() + "#paperpattern")%>'>Paper Pattern</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString() + "#preparation")%>'>Preparation</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString() + "#notification")%>'>Notification</a></li>
                    <li><a class="active" href="#">Colleges</a></li>

                </ul>



                <div class="filter-result">
                    <p>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </p>
                    <div class="detail-list">
                        <ul>
                            <asp:Repeater ID="rpt_Institutes" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="imgblock">
                                            <img src='<%# "https://www.eduvidya.com/admin/Upload/Institutes/" + Eval("strPhoto") %>'
                                                alt='<%# Eval("strTitle") %>' />
                                        </div>
                                        <div class="contentblock">
                                            <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strTitle").ToString().Replace(" ","-")) %>'>
                                                <%# Eval("strTitle") %></a><br />
                                            <%# ((bool)(Eval("strDesc").ToString().Length > 210)) == true ? Eval("strDesc").ToString().Replace("<p>", "").Replace("</p>", "").Substring(0, 210) + " ..." : Eval("strDesc")%>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                            <Pager:CollectionPager ID="CPager" runat="server" BackNextDisplay="HyperLinks" PageSize="25"
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
                        </ul>
                    </div>
                </div>
                <div id="ReviewsBox">
                </div>
            </div>
            <div>
                <script type="text/javascript">                        var switchTo5x = true;</script>
                <script type="text/javascript" src="/js/button.js"></script>
                <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                <script type="text/javascript">                        stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                    displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
            </div>
        </div>
    </div>
    <%--<table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" valign="top" class="bestplace_head">
                <ul class="tabs">
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString()) %>'>Description</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString() + "#admissions")%>'>Admission Proceducre</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString() + "#dates")%>'>Exam Dates</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString() + "#syllabus")%>'>Syllabus</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString() + "#paperpattern")%>'>Paper Pattern</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString() + "#preparation")%>'>Preparation</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString() + "#notification")%>'>Notification</a></li>
                    <li>Colleges</li>
                </ul>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" class="best_border">
                <h2>
                    <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></h2>
                <br />

                 <asp:Repeater ID="rpt_Institutes" runat="server">
                    <ItemTemplate>
                        <div>
                            <div class="photo">
                                <img src='<%# "https://www.eduvidya.com/admin/Upload/Institutes/" + Eval("strPhoto") %>'
                                    alt='<%# Eval("strTitle") %>' />
                            </div>
                            <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strTitle").ToString().Replace(" ","-")) %>'>
                                <%# Eval("strTitle") %></a><br />
                            <%# ((bool)(Eval("strDesc").ToString().Length > 210)) == true ? Eval("strDesc").ToString().Replace("<p>", "").Replace("</p>", "").Substring(0, 210) + " ..." : Eval("strDesc")%>
                        </div>
                        <div style="clear: both; height: 5px">
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <Pager:CollectionPager ID="CPager" runat="server" BackNextDisplay="HyperLinks" PageSize="25"
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
                <br />
                <div style="padding: 10px 0px">
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
