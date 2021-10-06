<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true"
    CodeFile="Contents.aspx.cs" Inherits="admin_ContentManagement" ValidateRequest="false" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>
    <br />
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <br />
    <table width="90%" align="center" border="0">
        <tr>
            <td align="left" colspan="2">
                <asp:Label ID="Label3" CssClass="font_title_text" runat="server" Text="Content Management"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                Section :
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlContentSection" AutoPostBack="true" OnSelectedIndexChanged="ddlContentSection_SelectedIndexChanged">
                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                    <asp:ListItem Text="About Us" Value="About Us"></asp:ListItem>
                    <asp:ListItem Text="Advertise with Us" Value="Advertise With Us"></asp:ListItem>
                    <asp:ListItem Text="Privacy Policy" Value="Privacy Policy"></asp:ListItem>
                    <asp:ListItem Text="Terms and Conditions" Value="Terms and Conditions"></asp:ListItem>
                    <asp:ListItem Text="Contact Us" Value="Contact Us"></asp:ListItem>
                </asp:DropDownList>
                <asp:CompareValidator runat="server" ID="cvSection" ControlToValidate="ddlContentSection"
                    ValueToCompare="0" Operator="NotEqual" SetFocusOnError="true" Type="string" ErrorMessage="Select Section"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td valign="top">
                Description :
            </td>
            <td>
                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td>
                <asp:LinkButton runat="server" ID="lbtnInsert" Text="Save" OnClick="lbtnInsert_Click"></asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
