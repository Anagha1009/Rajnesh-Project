<%@ Page MasterPageFile="~/ClientMaster.master" Language="C#" AutoEventWireup="true"
    CodeFile="Comparisions.aspx.cs" Inherits="Compare" %>

<%@ Register Src="UserControls/CompareBox.ascx" TagName="CompareBox" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Comparisions</title>
    <meta name="Description" content="Comparisions" />
    <meta name="Keywords" content="Comparisions" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="server">

    <div class="box">
        <div class="heading">
          
            <a href="#">Comparisions</a>
        </div>

        <div class="box-content">
            <asp:ScriptManager ID="scrManager" runat="server">
            </asp:ScriptManager>
            <asp:CompareBox ID="CompareBox1" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="cp_rightBottom" runat="server">
</asp:Content>
