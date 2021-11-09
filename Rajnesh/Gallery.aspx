<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Gallery.aspx.cs" Inherits="Gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_MetaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_MetaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_MetaKeys" runat="server"></asp:Literal>
    <link href="/css/gallery.css" rel="stylesheet" type="text/css"/>
    <%--<link href="https://www.eduvidya.com/Gallery.css" rel="stylesheet" type="text/css" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scrManager" runat="server">
    </asp:ScriptManager>
    <div class="Banner_Box" id="Banner_Box" runat="server">
        <table width="100%" cellpadding="2px" cellspacing="2px" border="0px">
            <tr>
                <td align="left" colspan="3" class="_mainTitle">
                    <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td align="center" width="40px" valign="middle">
                    <a id="hyp_Previous" runat="server">
                        <img src="https://www.eduvidya.com/img/arrow_left.gif" /></a>
                </td>
                <td align="center" valign="middle">
                    <div class="title">
                        <asp:Literal ID="ltl_Rank" runat="server"></asp:Literal>
                    </div>
                    <div class="clr">
                    </div>
                    <div>
                        <img src="" id="img_BannerPhoto" runat="server" />
                    </div>
                    <div class="clr">
                    </div>
                    <div>
                        <asp:HyperLink ID="hyp_link" runat="server" CssClass="_bannerlinks" Target="_blank">
                        </asp:HyperLink>
                    </div>
                </td>
                <td align="center" width="40px" valign="middle">
                    <a id="hyp_Next" runat="server">
                        <img src="https://www.eduvidya.com/img/arrow_right.gif" /></a>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
