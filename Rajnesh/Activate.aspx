<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Activate.aspx.cs" Inherits="Activate" %>

<asp:Content ID="MetaContent" runat="server" ContentPlaceHolderID="head">
    <title>Account Activation Page </title>
    <meta name="Description" content="Activation Page" />
    <meta name="Keywords" content="Activation Page" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <div id="Info">
        <Rec:Info ID="Info1" runat="server" />
        <Rec:Error ID="Error1" runat="server" />
    </div>
</asp:Content>
