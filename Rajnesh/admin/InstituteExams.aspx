<%@ Page Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true"
    CodeFile="InstituteExams.aspx.cs" Inherits="admin_ControlPanel" Title="Control Panel | InstituteExam" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <table width="80%" align="center">
        <tr>
            <td align="left" class="font_title_text">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:ListBox runat="server" ID="ListBox_Records" Font-Size="Small" Width="550px"
                    Height="500px" SelectionMode="Multiple"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn" />
            </td>
        </tr>
    </table>
</asp:Content>
