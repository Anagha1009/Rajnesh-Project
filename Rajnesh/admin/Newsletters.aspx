<%@ Page Title="Control Panel | NewsLetters" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="Newsletters.aspx.cs" Inherits="admin_NewsLetters"
    MaintainScrollPositionOnPostback="true" ValidateRequest="false" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <style type="text/css">
        body
        {
            padding:0px;
            margin:0px;
        }
        ._title
        {
            font-family: Trebuchet MS;
            font-size: 19px;
            font-weight: bold;
            font-style: italic;
            color: #444;
        }
        
        .LeadBox div
        {
            float: left;
            padding-right: 10px;
        }
        
        .EmailBox
        {
            background-color:#efefef;
            border:1px solid #ccc;
            -webkit-border-radius: 5px;
-moz-border-radius: 5px;
border-radius: 5px;
        }
    </style>
    <asp:ScriptManager ID="scrManager" runat="server">
    </asp:ScriptManager>
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <table width="100%" border="0" align="center">
        <tr>
            <td align="left" class="_title">
                NewsLetter
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:UpdatePanel ID="pnl_Filter" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="2px" cellspacing="2px" border="0px">
                            <tr>
                                <td align="left" width="170px">
                                    Comment Users
                                </td>
                                <td>
                                    :
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chk_Comments" runat="server" OnCheckedChanged="chk_Newsletters_CheckedChanged"
                                        AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Competition Users
                                </td>
                                <td>
                                    :
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chk_Competitions" runat="server" OnCheckedChanged="chk_Newsletters_CheckedChanged"
                                        AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Education Lead Users
                                </td>
                                <td>
                                    :
                                </td>
                                <td align="left" class="LeadBox">
                                    <div>
                                        <asp:CheckBox ID="chk_EduCationLeads" runat="server" OnCheckedChanged="chk_EduCationLeads_CheckedChanged"
                                            AutoPostBack="true" />
                                    </div>
                                    <div>
                                        <asp:DropDownList ID="ddl_EduCationLeads" runat="server" OnSelectedIndexChanged="ddl_EduCationLeads_SelectedIndexChanged"
                                            AutoPostBack="true">
                                            <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                            <asp:ListItem Text="Institute" Value="Institute"></asp:ListItem>
                                            <asp:ListItem Text="Schools" Value="Schools"></asp:ListItem>
                                            <asp:ListItem Text="University" Value="University"></asp:ListItem>
                                            <asp:ListItem Text="DistanceUniversity" Value="DistanceUniversity"></asp:ListItem>
                                            <asp:ListItem Text="DistanceCollege" Value="DistanceCollege"></asp:ListItem>
                                            <asp:ListItem Text="InstitueCourses" Value="InstitueCourses"></asp:ListItem>
                                            <asp:ListItem Text="UniversityCourses" Value="UniversityCourses"></asp:ListItem>
                                            <asp:ListItem Text="DistanceUniversityCourses" Value="DistanceUniversityCourses"></asp:ListItem>
                                            <asp:ListItem Text="Exam" Value="Exam"></asp:ListItem>
                                            <asp:ListItem Text="Links" Value="Links"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div>
                                        <asp:CheckBox ID="chk_EducationLoan" runat="server" Text="Loan Users" OnCheckedChanged="chk_EduCationLeads_CheckedChanged"
                                            AutoPostBack="true" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <table width="100%" cellpadding="2px" cellspacing="2px" border="0px">
                    <tr>
                        <td align="left" width="170px">
                            Subject
                        </td>
                        <td>
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txt_Subject" runat="server" CssClass="txtBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_Body" runat="server" CssClass="ckeditor" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Button ID="btn_Send" runat="server" Text="Send Now" 
                                onclick="btn_Send_Click" CssClass="btn"/>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top" width="310px">
                <asp:UpdatePanel ID="pnl_EducationLeads" runat="server">
                    <ContentTemplate>
                        <asp:Repeater ID="rpt_Users" runat="server">
                            <HeaderTemplate>
                                <table width="100%" cellpadding="2px" cellspacing="2px" border="0px" class="EmailBox">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td align="left">
                                        <%# Eval("strEmail") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
