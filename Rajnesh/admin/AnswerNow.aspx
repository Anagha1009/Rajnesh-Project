<%@ Page Title="Admin :: Answer Now" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="AnswerNow.aspx.cs" Inherits="admin_Articles" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <table>
        <tr>
            <td colspan="2">
            <br/><br/>
                <yo:infoMssg ID="info" runat="server" Visible="false" />
    <yo:errorMssg ID="error" runat="server" Visible="false" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
                Question:
            </td>
            <td style="width: 90%">
                <asp:Label ID="lblQuestion" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
                Answer:
            </td>
            <td style="width: 90%">
                <FCKeditorV2:FCKeditor ID="fckDesc" runat="server" BasePath="~/FCKeditor/" Height="400px"
                    Width="600px">
                </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
            </td>
            <td style="width: 90%">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CausesValidation="false"
                    OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
