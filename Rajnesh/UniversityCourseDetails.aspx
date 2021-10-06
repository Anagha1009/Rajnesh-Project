<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="UniversityCourseDetails.aspx.cs" Inherits="CollegeCourses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scrManager" runat="server">
    </asp:ScriptManager>
    <div class="box">
        <div class="box-content">
            <div class="details-page-tab">
                  <ul class="tab-section">
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString())%>'>Description</a></li>
                    <li><a class="active" href="#">Courses</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString() + "#address") %>'>Address</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString() + "#map") %>'>Map</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString() + "#admissions") %>'>Admissions</a></li>
                </ul>
            </div>
            <ul class="info">
                <li class="college-detail">
                    <p>
                        <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
                    </p>
                    <p>
                        <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
                    </p>
                    <p><a id="hyp_UniversityLink" runat="server"></a></p>
                    <p>
                        <asp:Literal ID="ltl_UniversityDetails" runat="server"></asp:Literal>
                    </p>
                    <div class="social-share">
                        <script type="text/javascript">                        var switchTo5x = true;</script>
                        <script type="text/javascript" src="js/button.js"></script>
                        <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                        <script type="text/javascript">                        stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                        <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                            displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                                displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <%--  <table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" valign="top" class="bestplace_head">
                <ul class="tabs">
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString())%>'>
                        Description</a></li>
                    <li>Courses</li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString() + "#address") %>'>
                        Address</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString() + "#map") %>'>
                        Map</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString() + "#admissions") %>'>
                        Admissions</a></li>
                </ul>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" class="best_border">
                <div style="float: left">
                    <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
                </div>
                <div style="clear: both; height: 10px">
                </div>
                <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
                <br />
                <a id="hyp_UniversityLink" runat="server" class="CollegeLink"></a>
                <br />
                <asp:Literal ID="ltl_UniversityDetails" runat="server"></asp:Literal>
                <div style="clear: both">
                    &nbsp;</div>
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
            </td>
        </tr>
        <tr>
            <td class="bottom">
                &nbsp;
            </td>
        </tr>
    </table>--%>
</asp:Content>
