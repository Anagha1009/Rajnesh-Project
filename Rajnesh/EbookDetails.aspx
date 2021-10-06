<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="EbookDetails.aspx.cs" Inherits="EbookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
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
            <div class="list">
                <p>
                    <asp:Literal ID="ltl_Details" runat="server"></asp:Literal><br />
                    <img src="https://www.eduvidya.com/img/pdf.png" alt="pdf" align="middle" /><a href="" id="hyp_Ebook" runat="server"></a>
                </p>
            </div>
        </div>
    </div>
    <%--  <table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" valign="top" class="bestplace_head">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" class="best_border">
                <asp:Literal ID="ltl_Details" runat="server"></asp:Literal><br />
                <img src="https://www.eduvidya.com/img/pdf.png" alt="pdf" align="middle"/><a href="" id="hyp_Ebook" runat="server"></a>
            </td>
        </tr>
        <tr>
            <td class="bottom">
                &nbsp;
            </td>
        </tr>
    </table>--%>
</asp:Content>
