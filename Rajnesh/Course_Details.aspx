<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Course_Details.aspx.cs" Inherits="Universities_in_India" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_bottomHead" runat="Server">

    <link href="https://www.eduvidya.com/css/jquery.rating.css" rel="stylesheet" type="text/css" />
    <%--<script src="https://www.eduvidya.com/js/star/jquery.js" type="text/javascript"></script>--%>
     <script src="https://www.eduvidya.com/js/star/jquery.MetaData.js" type="text/javascript"></script>  
    <%--<script src="https://www.eduvidya.com/js/star/jquery.rating.js" type="text/javascript"></script>--%>
    <%--<script src="https://www.eduvidya.com/js/star/star_rating_Univ.js" type="text/javascript"></script>--%>


    <script src="/js/star/jquery.js" type="text/javascript"></script>
    <script src="/js/star/jquery.rating.js" type="text/javascript"></script>
    <script src="/js/star/star_rating_Univ.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <div itemscope itemtype="https://data-vocabulary.org/Review-aggregate">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="theBox">
            <tr>
                <td class="rec_Title">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-collapse: collapse">
                        <tr>
                            <td align="left">
                                <span itemprop="itemreviewed" class="title">
                                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                </span>
                            </td>
                            <td align="right" class="SubTitle">
                                <asp:Label ID="lblUniversity" runat="server" Font-Size="15px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td align="left" valign="top">
                                <div>
                                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                    </asp:ToolkitScriptManager>
                                    <div>
                                        <div class="Ratingleft" style="padding-left: 35px">
                                            <asp:Rating ID="rt_Rate" runat="server" StarCssClass="StarCss" FilledStarCssClass="FilledStarCss"
                                                EmptyStarCssClass="EmptyStarCss" WaitingStarCssClass="WaitingStarCss" AutoPostBack="true"
                                                OnChanged="rt_Rate_Changed" MaxRating="5">
                                            </asp:Rating>
                                        </div>
                                        <div style="clear: both; height: 1px">
                                        </div>
                                        <div class="RatingBox">
                                            <asp:Literal ID="ltl_RatingBox" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                            </td>
                            <td valign="top">
                                <div class="EducationHelp">
                                    <a href="https://www.eduvidya.com/Education-Help.aspx" target="_blank">Need Admission
                                        Help?</a>
                                </div>
                            </td>
                            <td align="right" valign="top">
                                <script type="text/javascript" src="https://cdn.socialtwist.com/2009103028555-1/script.js"
                                    __designer:mapid="13ea"></script>
                                <a class="st-taf" href="https://tellafriend.socialtwist.com:80" onclick="return false;"
                                    style="border: 0; padding: 0; margin: 0;">
                                    <img alt="SocialTwist Tell-a-Friend" style="border: 0; padding: 0; margin: 0;" src="https://images.socialtwist.com/2009103028555-1/button.png"
                                        onmouseout="STTAFFUNC.hideHoverMap(this)" onmouseover="STTAFFUNC.showHoverMap(this, '2009103028555-1', window.location, document.title)"
                                        onclick="STTAFFUNC.cw(this, {id:'2009103028555-1', link: window.location, title: document.title });" /></a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="container" align="left">
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                    <div style="clear: both">
                        &nbsp;</div>
                    <a id="hyp_InstitutionLink" runat="server" class="CollegeLink"></a>
                    <div style="clear: both">
                        &nbsp;</div>
                    <asp:Literal ID="ltl_InstitutionDetails" runat="server"></asp:Literal>
                    <div style="clear: both">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="tit" align="left">
                    <asp:Label ID="lblother" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" class="container">
                    <asp:Repeater ID="rptOther" runat="server">
                        <HeaderTemplate>
                            <table width="100%">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td valign="top" width="16px">
                                    <img src="../images/bullet_disk.png" />
                                </td>
                                <td align="left" valign="top">
                                    <asp:HyperLink ID="hyp_Courses" runat="server" Font-Bold="true" Text='<%# Eval("strCourseName") %>'
                                        CssClass="mylinks" NavigateUrl='<%# VirtualPathUtility.ToAbsolute("~/Universities/" + Eval("strInstitute").ToString().Replace(" ","-") + "/Courses/" + Eval("strCourseName").ToString().Replace(" ","-")) %>'></asp:HyperLink>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div style="clear: both">
                    </div>
                    <div class="EducationLoan">
                        <a href="https://www.eduvidya.com/Education-Help.aspx" target="_blank">Need Education
                            Loan?</a></div>
                    <div style="clear: both">
                        &nbsp;
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
