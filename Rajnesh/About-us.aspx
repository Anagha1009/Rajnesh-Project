<%@ Page Title="" Language="C#" MasterPageFile="~/Client_Master.master" AutoEventWireup="true"
    CodeFile="About-us.aspx.cs" Inherits="Admissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>About us</title>
    <meta name="Description" content="About us" />
    <meta name="Keywords" content="About us" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <%--<table width="100%" cellpadding="0px" cellspacing="0px" border="0px" class="theBox">
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
    <div class="box">
        <div class="heading">
            <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
        </div>
        <div class="box-content">
            <div class="list">
                <p>
                    <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
