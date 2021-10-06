<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <link href="http://www.mehanedusolutions.com/admin/login/login.css" rel="stylesheet" type="text/css" />
</head>
<body class="bodie">
    <form id="frm" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" style="padding-top: 140px">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center" valign="bottom">
                            <table width="450px" class="info" id="error" runat="server">
                                <tr align="center">
                                    <td>
                                        <table width="100%">
                                            <tr align="center">
                                                <td style="width: 20%">
                                                    <asp:Image ID="imgError" BorderStyle="None" ImageUrl="http://www.mehanedusolutions.com/admin/login/Images/error.png" runat="server" />
                                                </td>
                                                <td style="width: 80%">
                                                    <asp:Label CssClass="font_info" ID="lbl_Error" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table width="450px" class="info" id="info" runat="server">
                                <tr align="center">
                                    <td>
                                        <table width="100%">
                                            <tr align="center">
                                                <td style="width: 20%">
                                                    <asp:Image ID="Image1" BorderStyle="None" ImageUrl="http://www.mehanedusolutions.com/admin/login/Images/info.png" runat="server" />
                                                </td>
                                                <td style="width: 80%">
                                                    <asp:Label CssClass="font_error" ID="lbl_Info" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table width="449" class="loginbox" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="middle" class="loginheader">
                                        Log in to<br />
                                        Control Pannel
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    Enter the login name into &quot;Login&quot; and password into the &quot;Password&quot;
                                                    fields respectively. Then click &quot;Log In&quot;.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ValidationSummary ID="vsLogin" runat="server" HeaderText="You must enter a valid value in the following fields:" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="8">
                                                        <tr>
                                                            <td width="35%">
                                                                Login
                                                            </td>
                                                            <td width="40%" align="left">
                                                                <asp:TextBox ID="txtLogin" runat="server" CssClass="input"></asp:TextBox>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ControlToValidate="txtLogin"
                                                                    ErrorMessage="Login" SetFocusOnError="True" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Password
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input"></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                                                    ErrorMessage="Password" SetFocusOnError="True" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 5px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td colspan="2" align="left">
                                                                <asp:Button ID="btnLogIn" runat="server" CssClass="buttons" Text="Log in" OnClick="btnLogIn_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
