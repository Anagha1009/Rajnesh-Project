<%@ Page Language="C#" MasterPageFile="~/Client_Master.master" AutoEventWireup="true"
    CodeFile="Contact-us.aspx.cs" Inherits="Admissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Contact us</title>
    <meta name="Description" content="Contact us" />
    <meta name="Keywords" content="Contact us" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <div class="box">
        <div class="heading">
            <a href="#">  <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></a>
        </div>
        <div class="box-content"><div class="list"><p>  <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal></p></div></div>
    </div>
    <%--<table width="100%" cellpadding="0px" cellspacing="0px" border="0px" class="theBox">
        <tr>
            <td align="left" class="rec_Title">
              
            </td>
        </tr>
        <tr>
            <td align="left" class="rec_Desc">
              
            </td>
        </tr>
    </table>--%>
</asp:Content>
