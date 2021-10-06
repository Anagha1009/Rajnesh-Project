<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="ArticleDetails.aspx.cs" Inherits="SearchDetails" %>

<asp:Content ID="MetaContent" runat="server" ContentPlaceHolderID="head">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cp_left" runat="Server">
    <%-- <table width="100%" cellpadding="0px" cellspacing="0px" border="0px" align="left">
        <tr>
            <td align="left" class="bestplace_head">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="justify" class="best_border">
                <img id="img_Pages" runat="server" class="_Photo_frame" />
                <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="bottom">
                &nbsp;
            </td>
        </tr>
    </table>--%>
    <div class="box">
        <div class="heading">
            <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
        </div>
        <div class="box-content">
            <div class="list">
                <p>
                    <img id="img_Pages" runat="server" class="_Photo_frame" />
                    <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
