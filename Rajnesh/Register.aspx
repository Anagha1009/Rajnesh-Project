<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>REGISTER FOR FREE</title>
    <meta name="Keywords" content="Register For Free" />
    <meta name="Description" content="Register For Free" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_left" runat="Server">

    <div id="Info">
        <Rec:Info ID="info1" runat="server" />
        <Rec:Error ID="error1" runat="server" />
    </div>
    <div style="padding: 5px" class="theBox">
        <table width="100%" cellpadding="0" cellspacing="0" class="theBox" border="0" id="tbl_Reg" runat="server">
            <tr>
                <td colspan="4" style="padding-left: 5px">
                    <asp:ValidationSummary ID="vs_Registration" ValidationGroup="vgRegister" runat="server"
                        HeaderText="Please fill following details to complete the registration process." />
                </td>
            </tr>
            <tr>
                <td align="left" class="rec_Title" colspan="4">
                    Login Information
                </td>
            </tr>
            <tr>
                <td width="170px" align="left">
                    Email
                </td>
                <td width="10px">
                    :
                </td>
                <td align="left" width="210px">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txtBox"></asp:TextBox>
                </td>
                <td align="right">
                    *<asp:RequiredFieldValidator ID="rfvEmail" ValidationGroup="vgRegister" runat="server"
                        ErrorMessage="Email" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtEmail">&nbsp;</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                            ID="revEmail" runat="server" ErrorMessage="Invalid E-mail ID" ControlToValidate="txtEmail"
                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgRegister" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr id="tr_Pass" runat="server">
                <td width="170px" align="left">
                    Password
                </td>
                <td width="10px">
                    :
                </td>
                <td align="left" width="210px">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="txtBox"></asp:TextBox>
                </td>
                <td align="right">
                    *<asp:RequiredFieldValidator ID="rfvPassword" ValidationGroup="vgRegister" runat="server"
                        ErrorMessage="Password" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtPassword">&nbsp;</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="tr_RePass" runat="server">
                <td width="170px" align="left">
                    Re-Type Password
                </td>
                <td width="10px">
                    :
                </td>
                <td align="left" width="210px">
                    <asp:TextBox ID="txtRePass" runat="server" TextMode="Password" CssClass="txtBox"></asp:TextBox>
                </td>
                <td align="right">
                    *<asp:RequiredFieldValidator ID="rfvRePass" ValidationGroup="vgRegister" runat="server"
                        ErrorMessage="Re-Type Password" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtRePass">&nbsp;</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cmpRePass" ValidationGroup="vgRegister" runat="server"
                        ErrorMessage="Re-Type Password" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtRePass"
                        ControlToCompare="txtPassword">&nbsp;</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="left" class="rec_Title" colspan="4">
                    Personal Information
                </td>
            </tr>
            <tr>
                <td width="170px" align="left">
                    Name
                </td>
                <td width="10px">
                    :
                </td>
                <td align="left" width="210px">
                    <asp:TextBox ID="txtName" runat="server" CssClass="txtBox"></asp:TextBox>
                </td>
                <td align="right">
                    *<asp:RequiredFieldValidator ID="rfvName" ValidationGroup="vgRegister" runat="server"
                        ErrorMessage="Name" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtName">&nbsp;</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="170px" align="left">
                    Date of Birth
                </td>
                <td width="10px">
                    :
                </td>
                <td align="left" colspan="2">
                    <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                        <tr>
                            <td width="75px" align="left">
                                <asp:DropDownList ID="ddl_Day" runat="server" Width="70px" CssClass="dropBox">
                                </asp:DropDownList>
                            </td>
                            <td width="10px" align="center">
                                *<asp:RequiredFieldValidator ID="rfvDay" ValidationGroup="vgRegister" runat="server"
                                    ErrorMessage="Day" SetFocusOnError="true" Display="Dynamic" ControlToValidate="ddl_Day"
                                    InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                            </td>
                            <td width="75px" align="left">
                                <asp:DropDownList ID="ddl_Month" runat="server" Width="70px" CssClass="dropBox">
                                </asp:DropDownList>
                            </td>
                            <td width="10px" align="center">
                                *<asp:RequiredFieldValidator ID="rfvMonth" ValidationGroup="vgRegister" runat="server"
                                    ErrorMessage="Month" SetFocusOnError="true" Display="Dynamic" ControlToValidate="ddl_Month"
                                    InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                            </td>
                            <td width="75px" align="left">
                                <asp:DropDownList ID="ddl_Year" runat="server" Width="70px" CssClass="dropBox">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td width="10px" align="right">
                                *<asp:RequiredFieldValidator ID="rfvYear" ValidationGroup="vgRegister" runat="server"
                                    ErrorMessage="Year" SetFocusOnError="true" Display="Dynamic" ControlToValidate="ddl_Year"
                                    InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="170px" align="left">
                    Gender
                </td>
                <td width="10px">
                    :
                </td>
                <td align="left" width="210px">
                    <asp:RadioButton ID="rb_male" runat="server" GroupName="grp_Gender" Text="Male" Checked="true" />&nbsp;&nbsp;<asp:RadioButton
                        ID="rb_female" runat="server" GroupName="grp_Gender" Text="Female" />
                </td>
                <td align="right">
                    *
                </td>
            </tr>
            <tr>
                <td width="170px" align="left">
                    Phone
                </td>
                <td width="10px">
                    :
                </td>
                <td align="left" width="210px">
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="txtBox"></asp:TextBox>
                </td>
                <td align="right">
                    *<asp:RequiredFieldValidator ID="rfvPhone" ValidationGroup="vgRegister" runat="server"
                        ErrorMessage="Phone" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtPhone">&nbsp;</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="170px" align="left">
                    City
                </td>
                <td width="10px">
                    :
                </td>
                <td width="210px">
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="dropBox">
                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    *<asp:RequiredFieldValidator ID="rfvCity" ValidationGroup="vgRegister" runat="server"
                        ErrorMessage="City" SetFocusOnError="true" Display="Dynamic" ControlToValidate="ddlCity"
                        InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="170px" align="left">
                    Upload Your Photo
                </td>
                <td width="10px">
                    :
                </td>
                <td width="210px" valign="middle">
                    <img src="" id="img_userPhoto" runat="server" />
                    <asp:HiddenField ID="hf_Photo" runat="server" />
                    <asp:FileUpload ID="fp_upload" runat="server" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr id="tr_Verification" runat="server">
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" class="rec_Title" colspan="4" id="tr_Verification_001" runat="server">
                    Security Checking
                </td>
            </tr>
            <tr id="tr_Verification_002" runat="server">
                <td colspan="4">
                    <table width="100%" cellpadding="2px" cellspacing="2px" border="0px">
                        <tr>
                            <td width="170px" align="left" valign="top">
                                Verification Code
                            </td>
                            <td width="10px" valign="top">
                                :
                            </td>
                            <td align="left" colspan="2">
                                <asp:Image ID="imgVerificationCode" runat="server" ImageUrl="RandomImage.aspx" Width="161"
                                    Height="49" EnableViewState="false" /><br />
                                <br />
                                Can't see?
                                <asp:LinkButton ID="lbRefresh" CssClass="Company" runat="server" CausesValidation="False"
                                    OnClick="lbRefresh_Click" ValidationGroup="vgRegister">Refresh!</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Enter the above code
                            </td>
                            <td width="10px">
                                :
                            </td>
                            <td align="left" width="210px">
                                <asp:TextBox ID="txtSecurityCode" runat="server" ValidationGroup="vgRegister" CssClass="txtBox"></asp:TextBox>
                            </td>
                            <td align="right">
                                *<asp:RequiredFieldValidator ID="rfvSecurityCode" runat="server" ControlToValidate="txtSecurityCode"
                                    ValidationGroup="vgRegister" ErrorMessage="Verification Code" Display="Dynamic">&nbsp; </asp:RequiredFieldValidator><br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="tr_License" runat="server">
                    &nbsp;
                </td>
            </tr>
            <tr id="tr_License_001" runat="server">
                <td align="left" class="rec_Title" colspan="4">
                    License Agreement>
                </td>
            </tr>
            <tr id="tr_License_002" runat="server">
                <td align="left" colspan="4">
                    <div style="float: left">
                        <asp:CheckBox ID="chk_agree" runat="server" Text="" /></div>
                    <asp:Label ID="ltlAgree" runat="server" Text="I agree to the Terms and Conditions and Privacy Policy"
                        AssociatedControlID="chk_agree"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/images/submit.png" Width="110px"
                        ValidationGroup="vgRegister" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
