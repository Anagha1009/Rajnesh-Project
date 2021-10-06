<%@ Page Title="Admin :: University Courses" Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true" CodeFile="UniversityCourseList.aspx.cs" Inherits="admin_UniversityCourseList" %>
<%@ Register TagName="errorMssg" src="~/admin/errorUserControl.ascx" TagPrefix="yo"%>
<%@ Register TagName="infoMssg" src="~/admin/infoUserControl.ascx" TagPrefix="yo"%>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" Runat="Server">
<br />
<yo:errorMssg ID="error" runat="server" Visible="false" />
<yo:infoMssg ID="info" runat="server" Visible="false" />
<br />
<table width="100%" align="center" border="0">   
    <tr>
        <td style="height: 67px">
            <asp:Label ID="Label1" ForeColor="#ff6633" runat="server" 
            Font-Bold="true" Text="Institute Name : "></asp:Label>
            <asp:Label ID="lbl_Title" ForeColor="#ff6633" runat="server" 
            Font-Bold="true"></asp:Label><br /><br />
           <asp:Label id="Label2" CssClass="font_title_text" runat="server" 
        Text="U N I V E R S I T Y&nbsp;&nbsp;&nbsp;&nbsp;C O U R S E&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S">
        </asp:Label>
            <hr />
        </td>
   </tr>
   <tr><td style="width:20%">
        <asp:Label id="Label3" runat="server" Text="Select Courses">
        </asp:Label>
       </td> 
   </tr>
   <tr>
       <td align="left">
           <asp:ListBox runat="server" ID="lstCourses" Font-Size="Small" Width="770px" 
           Height="430px" SelectionMode="Multiple" ></asp:ListBox>
       </td>
   </tr>
   <tr>
    <td>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn_input"/>   
   </td>
   </tr>   
</table>
</asp:Content>