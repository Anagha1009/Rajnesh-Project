<%@ Page Title="Job Generator" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="JobGenerator.aspx.cs" Inherits="admin_InstituteRequire" %>
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
                <asp:Label ID="Label2" CssClass="font_title_text" runat="server" Text="J O B&nbsp;&nbsp;&nbsp;&nbsp;G E N E R A T O R"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <b>Select Category/SubCategory $ City </b>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table width="100%">
                    <tr>
                        <td width="90px">
                            &nbsp;
                        </td>
                        <td>
                            <asp:RadioButton ID="rb_Institutes" runat="server" Text="Jobs" GroupName="infi" AutoPostBack="True"
                                OnCheckedChanged="rb_Institutes_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rb_Company" runat="server" Text="Company" GroupName="infi" AutoPostBack="True"
                                OnCheckedChanged="rb_Company_CheckedChanged" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
        </tr>
        <tr>
            <td width="100px" valign="top">
                <asp:Label ID="lblCategory" runat="server" Text="Select"></asp:Label>
            </td>
            <td valign="top">
                :
            </td>
            <td>
                <table cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td id="td_Category" runat="server">
                            <asp:DropDownList runat="server" ID="ddl_Category" AutoPostBack="true" Width="265px"
                                OnSelectedIndexChanged="ddl_Category_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align="right" id="td_City3" runat="server" style="padding-left: 20px;">
                            <asp:DropDownList runat="server" ID="ddl_Subcategory" AutoPostBack="true" Width="265px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_City" AutoPostBack="true" Width="265px">
                            </asp:DropDownList>
                        </td>
                        <td style="padding-left: 20px;">
                            <asp:DropDownList runat="server" ID="ddl_Company" AutoPostBack="true" Width="265px"
                                OnSelectedIndexChanged="ddl_Company_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="padding-left: 10px">
                            <span style="background-image: url('images/arrow-turn.png'); background-repeat: no-repeat;
                                background-position: right;">
                                <asp:LinkButton ID="lnk_proceed" runat="server" OnClick="lnk_proceed_Click">Go&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    </asp:LinkButton></span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 100px">
                <asp:Label ID="lblSelectCourses" runat="server" Text="Select Jobs"></asp:Label>
            </td>
            <td valign="top">
                :
            </td>
            <td align="left">
                <asp:ListBox runat="server" ID="ListBox_Institute" Width="650px" Height="500px" SelectionMode="Multiple">
                </asp:ListBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Page Name eg. Java Programmer
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtQuery" runat="server" Width="400px" TextMode="MultiLine" Height="81px"
                    BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px"
                    Font-Size="12px" Font-Names="verdana"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Job Title
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtPageTitle" runat="server" Width="400px" TextMode="MultiLine"
                    Height="81px" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px"
                    Font-Size="12px" Font-Names="verdana"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                H1
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtH1" runat="server" Width="400px" TextMode="MultiLine" Height="81px"
                    BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px"
                    Font-Size="12px" Font-Names="verdana"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                H2
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtH2" runat="server" Width="400px" TextMode="MultiLine" Height="81px"
                    BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px"
                    Font-Size="12px" Font-Names="verdana"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                H3
            </td>
            <td>
                :
            </td>
            <td>
                <FCKeditorV2:FCKeditor ID="txtH3" runat="server" BasePath="~/FCKeditor/" Height="500px"
                    Width="650px">
                </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td>
                H4
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtH4" runat="server" Width="400px" TextMode="MultiLine" Height="81px"
                    BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px"
                    Font-Size="12px" Font-Names="verdana"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Meta Title
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtMetaTitle" runat="server" Width="400px" TextMode="MultiLine"
                    Height="81px" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px"
                    Font-Size="12px" Font-Names="verdana"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Meta Description
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtMetaDesc" runat="server" Width="400px" TextMode="MultiLine" Height="81px"
                    BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px"
                    Font-Size="12px" Font-Names="verdana"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Meta Keywords
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtMetaKeys" runat="server" Width="400px" TextMode="MultiLine" Height="81px"
                    BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px"
                    Font-Size="12px" Font-Names="verdana"></asp:TextBox>
            </td>
        </tr>
        
        
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Place link on main page
            </td>
            <td>
                :
            </td>
            <td valign="middle">
                <asp:RadioButton ID="rd_yes" runat="server" Text="Yes" Checked="true" GroupName="grp_link"/>&nbsp;&nbsp;
                <asp:RadioButton ID="rd_no" runat="server" Text="No" GroupName="grp_link"/>
            </td>
        </tr>

        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Target Page Url
            </td>
            <td>
                :
            </td>
            <td valign="middle">
                <asp:TextBox ID="txtTargetUrl" runat="server" Width="240px"></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Jobs by Company
            </td>
            <td>
                :
            </td>
            <td valign="middle">
                <asp:CheckBox ID="chkCompany" runat="server"/>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Jobs by Category
            </td>
            <td>
                :
            </td>
            <td valign="middle">
                <asp:CheckBox ID="chkCategory" runat="server"/>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Jobs by Location
            </td>
            <td>
                :
            </td>
            <td valign="middle">
                <asp:CheckBox ID="chkLocation" runat="server"/>
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
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
