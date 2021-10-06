<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="VideoDetails.aspx.cs" Inherits="BlogDetails" %>

<asp:Content ID="MetaContent" runat="server" ContentPlaceHolderID="head">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scrManager" runat="server">
    </asp:ScriptManager>
    <div class="box">
        <div class="heading"><a href="#">
            <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></a></div>
        <div class="box-content">
            <div>
                <iframe width="540" height="315" id="YoutubeFrame" runat="server" frameborder="0" allowfullscreen></iframe>
            </div>
        </div>
    </div>
  <%--  <table width="100%" cellpadding="0px" cellspacing="0px" border="0px" align="left">
        <tr>
            <td align="left" class="bestplace_head"></td>
        </tr>
        <tr>
            <td align="justify" class="best_border"></td>
        </tr>
        <tr>
            <td class="bottom">&nbsp;
            </td>
        </tr>
    </table>--%>
</asp:Content>
