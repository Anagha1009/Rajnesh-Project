<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="UniversityNotifications.aspx.cs" Inherits="CollegeCourses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <%--  <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>--%>
    <div class="box">
        <div class="box-content">
            <div class="details-page-tab">
                <ul class="tab-section">
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString())%>'>Description</a></li>
                    <li><a class="active" href='#'>Courses</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString() + "#address") %>'>Address</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString() + "#map") %>'>Map</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString() + "#admissions") %>'>Admissions</a></li>
                </ul>
            </div>
            <br />
            <div class="filter-result">
                <p>
                    <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
                </p>
                <ul>
                    <asp:Repeater ID="rpt_Notifications" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href='<%# Eval("strUrl") %>'><%# Eval("strTitle")%></a>
                                <%# Eval("strDesc")%>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>

                <div>
                    <script type="text/javascript">                        var switchTo5x = true;</script>
                    <script type="text/javascript" src="js/button.js"></script>
                    <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                    <script type="text/javascript">                        stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                    <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                        displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                            displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
                </div>

            </div>



        </div>
    </div>
    <%--<table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" valign="top" class="bestplace_head">
                <ul class="tabs">
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString())%>'>Description</a></li>
                    <li>Courses</li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString() + "#address") %>'>Address</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString() + "#map") %>'>Map</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University/" + RouteData.Values["University"].ToString() + "#admissions") %>'>Admissions</a></li>
                </ul>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" class="best_border">
            <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
            <div style="clear:both">&nbsp;</div>
                <asp:Repeater ID="rpt_Notifications" runat="server">
                    <ItemTemplate>
                        <div class="StudyCenters">
                            <a href='<%# Eval("strUrl") %>'><%# Eval("strTitle")%></a>
                            <br />
                            <%# Eval("strDesc")%>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div style="clear: both">
                    &nbsp;</div>
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
