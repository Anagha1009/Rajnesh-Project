<%@ Page Language="C#" MasterPageFile="~/Client_Master.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Login</title>
    <meta name="Keywords" content="Login" />
    <meta name="Description" content="Login" />
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_left" runat="Server">
      <asp:ScriptManager ID="srm" runat="server">
    </asp:ScriptManager>
    <div id="Info">
        <Rec:Info ID="info1" runat="server" />
        <Rec:Error ID="error1" runat="server" />
    </div>
    <div style="padding: 5px">
        <table width="100%" cellpadding="0" cellspacing="0" class="theBox" border="0" id="tbl_Reg" runat="server">
            <tr>
                <td colspan="4" style="padding-left: 5px">
                    <asp:ValidationSummary ID="vs_Login" ValidationGroup="vgLogin" runat="server" HeaderText="Please fill following details to login into the system." />
                </td>
            </tr>
            <tr>
                <td colspan="4" class="rec_Title">Login Information
                </td>
            </tr>
            <tr>
                <td width="170px" align="left">Email
                </td>
                <td width="10px">:
                </td>
                <td align="left" width="210px">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txtBox"></asp:TextBox>
                </td>
                <td>*<asp:RequiredFieldValidator ID="rfvEmail" ValidationGroup="vgLogin" runat="server"
                    ErrorMessage="Email" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtEmail">&nbsp;</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                        ID="revEmail" runat="server" ErrorMessage="Invalid E-mail ID" ControlToValidate="txtEmail"
                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgLogin" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td width="170px" align="left">Password
                </td>
                <td width="10px">:
                </td>
                <td align="left" width="210px">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="txtBox"></asp:TextBox>
                </td>
                <td>*<asp:RequiredFieldValidator ID="rfvPassword" ValidationGroup="vgLogin" runat="server"
                    ErrorMessage="Password" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtPassword">&nbsp;</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="170px" align="left"></td>
                <td width="10px"></td>
                <td align="left" width="210px">
                    <a href="https://www.recruitmentexam.com/Register.aspx">Register Now!</a>
                </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/images/submit.png" Width="110px"
                        ValidationGroup="vgLogin" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
