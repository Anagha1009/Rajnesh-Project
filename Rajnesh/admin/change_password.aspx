<%@ Page Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true"
    CodeFile="change_password.aspx.cs" Inherits="admin_change_password" Title="Change Password" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <br />
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <br />
    <table align="center" width="70%">
        <tr>
            <td align="left" colspan="3">
                <asp:Label ID="Label3" CssClass="font_title_text" runat="server" Text="C H A N G E&nbsp;&nbsp;&nbsp;&nbsp;P A S S W O R D"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left">
                <br />
                <asp:ValidationSummary ID="valSum" runat="server" HeaderText="You must enter a valid value in the following fields"
                    DisplayMode="BulletList" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="60%" border="0">
                    <tr>
                        <td align="left" style="width: 40%;">
                            Old Password
                        </td>
                        <td style="width: 15%;">
                            &nbsp;:&nbsp;
                        </td>
                        <td style="width: 40%;">
                            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                        <td style="width: 5%;">
                            <asp:RequiredFieldValidator ID="vRequiredFieldValidatorOldPassword" runat="server"
                                ControlToValidate="txtOldPassword" ErrorMessage="Old Password" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            New Password
                        </td>
                        <td>
                            &nbsp;:&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="vRequiredFieldValidatorNewPassword" runat="server"
                                ControlToValidate="txtNewPassword" ErrorMessage="New Password" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Confirm Password
                        </td>
                        <td>
                            &nbsp;:&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="vRequiredFieldValidatorConfirmPassword" runat="server"
                                ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password" Display="Dynamic">*</asp:RequiredFieldValidator><asp:CompareValidator
                                    ID="vComparePassword" runat="server" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword"
                                    ErrorMessage="Password Mismatch" Display="Dynamic">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <br />
                            <br />
                            <asp:Button ID="submit" runat="server" Text="Submit" CssClass="input_login" OnClick="submit_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
