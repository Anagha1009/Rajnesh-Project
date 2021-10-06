<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="InstituteReviews.aspx.cs" Inherits="Institute_Reviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scManager" runat="server">
    </asp:ScriptManager>
    <table width="100%" cellpadding="0px" cellspacing="0px" border="0px" class="theBox">
        <tr>
            <td align="left" class="rec_Title">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left" class="rec_Desc">
                <asp:Repeater ID="rpt_Review" runat="server">
                    <ItemTemplate>
                        <div class="ListReview">
                            <div>
                                <a href='<%# VirtualPathUtility.ToAbsolute("~/" + RouteData.Values["InstituteType"].ToString() + "/" + RouteData.Values["Institute"].ToString() + "/Reviews/" + Eval("strTitle").ToString().Replace(" ", "-") + "/" + Eval("iID"))%>'
                                    class="rec_links">
                                    <%# Eval("strTitle") %></a>
                            </div>
                            <div class="clr_box">
                            </div>
                            <div>
                                <%# fn_ShortDetails(Eval("strDetails").ToString())%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <div style="padding: 10px 0px">
                    <script type="text/javascript">                        var switchTo5x = true;</script>
                    <script type="text/javascript" src="js/button.js"></script>
                    <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                    <script type="text/javascript">                        stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                    <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                        displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'>
                    </span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'>
                    </span>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
