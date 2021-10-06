<%@ Page Title="Admin :: Paper Generator" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="PaperGenerator.aspx.cs" Inherits="admin_Papers" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
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
                <asp:Label ID="Label2" CssClass="font_title_text" runat="server" Text="P A P E R&nbsp;&nbsp;&nbsp;&nbsp;G E N E R A T O R"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="3"></td>
        </tr>
        <tr>
            <td colspan="3">
                <table>
                    <tr>
                        <td width="100px" valign="top">
                            <asp:Label ID="lblCompany" runat="server" Text="Company"></asp:Label>
                        </td>
                        <td valign="top">:
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_Company" AutoPostBack="true" Width="215px" OnSelectedIndexChanged="ddl_Company_SelectedIndexChanged">
                            </asp:DropDownList>&nbsp;&nbsp;&nbsp;
                        </td>
                        <td width="100px" valign="top">
                            <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
                        </td>
                        <td valign="top">:
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlCategory" AutoPostBack="true" Width="215px" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                            </asp:DropDownList>&nbsp;&nbsp;&nbsp;
                 <span style="background-image: url('images/arrow-turn.png'); background-repeat: no-repeat; background-position: right;">
                     <asp:LinkButton ID="lnk_proceed" runat="server" OnClick="lnk_proceed_Click">Go&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    </asp:LinkButton></span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 100px">
                <asp:Label ID="lblSelectCourses" runat="server" Text="Select Paper"></asp:Label>
            </td>
            <td valign="top">:
            </td>
            <td align="left">
                <asp:ListBox runat="server" ID="ListBox_Papers" Width="650px" Height="500px" SelectionMode="Multiple"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>Page Name
            </td>
            <td>:
            </td>
            <td>
                <asp:TextBox ID="txtQuery" runat="server" Width="400px" TextMode="MultiLine" Height="81px"
                    BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px"
                    Font-Size="12px" Font-Names="verdana"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Paper Title
            </td>
            <td>:
            </td>
            <td>
                <asp:TextBox ID="txtPageTitle" runat="server" Width="400px" TextMode="MultiLine"
                    Height="81px" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px"
                    Font-Size="12px" Font-Names="verdana"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Description
            </td>
            <td>:
            </td>
            <td>
                <FCKeditorV2:FCKeditor ID="txtH3" runat="server" BasePath="~/FCKeditor/" Height="500px"
                    Width="650px">
                </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="1">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="88px" />
            </td>
            <td colspan="2">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="88px" OnClick="btnUpdate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
