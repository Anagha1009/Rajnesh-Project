<%@ Page Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true"
    CodeFile="EntranceExamColleges.aspx.cs" Inherits="admin_ControlPanel" Title="Admin :: Control Panel" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <br />
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <br />
    <table width="80%" align="center">
        <tr>
            <td colspan="3" style="height: 67px">
                <asp:Label ID="Label1" ForeColor="#ff6633" runat="server" Font-Bold="true" Text="Entrance Exam Name : "></asp:Label>
                <asp:Label ID="lbl_Title" ForeColor="#ff6633" runat="server" Font-Bold="true"></asp:Label><br />
                <br />
                <asp:Label ID="Label2" CssClass="font_title_text" runat="server" Text="Entrance Exam List"></asp:Label>
                <br />
                <hr />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 20%">
                Select Institute
            </td>
            <td>
                :
            </td>
            <td align="left">
                <asp:ListBox runat="server" ID="ListBox_Institute" Font-Size="Small" Width="550px"
                    Height="500px" SelectionMode="Multiple"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
