<%@ Page Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true" CodeFile="InstituteCategoryList.aspx.cs" Inherits="admin_InstituteCategoryList" Title="Admin :: Institute Category" %>
<%@ Register TagName="errorMssg" src="~/admin/errorUserControl.ascx" TagPrefix="yo"%>
<%@ Register TagName="infoMssg" src="~/admin/infoUserControl.ascx" TagPrefix="yo"%>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" Runat="Server">
<br />
<yo:errorMssg ID="error" runat="server" Visible="false" />
<yo:infoMssg ID="info" runat="server" Visible="false" />
<br />
<table width="80%" align="center">   
    <tr>
        <td colspan="3" style="height: 67px">
        <asp:Label ID="Label1" ForeColor="#ff6633" runat="server" Font-Bold="true" Text="Institute Name : "></asp:Label>
            <asp:Label ID="lbl_Title" ForeColor="#ff6633" runat="server" Font-Bold="true"></asp:Label><br /><br />
           <asp:Label id="Label2" CssClass="font_title_text" runat="server" Text="I N S T I T U T E&nbsp;&nbsp;&nbsp;&nbsp;C A T E G O R Y&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
            <br />
            <hr />
            <br />
        </td>
   </tr>
   <tr>
       <td style="width:20%"><asp:Label id="lblSelectCategory" runat="server" Text="Select Category"></asp:Label></td> 
       <td>:</td>
       <td align="left">
       <asp:ListBox runat="server" ID="ListBox_Category" Font-Size="Small" Width="550px" Height="500px" SelectionMode="Multiple" ></asp:ListBox>
       </td>
   </tr>
   
   <tr><td colspan="3">
   <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn_input" />   
   </td></tr>   
</table>

</asp:Content>

