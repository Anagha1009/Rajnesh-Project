<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="ContentDetails.aspx.cs" Inherits="Admissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="src" runat="server">
    </asp:ScriptManager>

    <div class="box">
        <div class="heading">
            <h3>
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></h3>
        </div>
        <div class="box-content">
            <div class="list">
                <p>
                    <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
                </p>
            </div>
        </div>
    </div>
    <%-- <table width="100%" cellpadding="0px" cellspacing="0px" border="0px" class="theBox">
        <tr>
            <td align="left" class="rec_Title">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left" class="rec_Desc">
               <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>--%>
</asp:Content>
