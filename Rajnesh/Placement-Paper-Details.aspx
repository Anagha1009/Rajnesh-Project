<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="Placement-Paper-Details.aspx.cs" Inherits="Jobs_in_India" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title id="meta_title" runat="server"></title>
    <meta name="Description" content="" id="meta_Description" runat="server" />
    <meta name="Keywords" content="" id="meta_Keywords" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cp_rightBottom" runat="Server">
    <style>
        #content {
            padding: 0px;
            border-top-right-radius: 13px;
            border-top-left-radius: 13px;
        }
    </style>
    <table width="100%" cellpadding="4px" cellspacing="4px" border="0" style="border: 1px solid #ccc; margin-left: 10px !important;">
        <tr>
            <td align="left" class="_title" colspan="2">
                <asp:Literal ID="ltl_JobsTitle" runat="server"></asp:Literal>
            </td>
        </tr>
        <asp:Repeater ID="rpt_Jobs" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="left" width="25px">
                        <img src="img/bullet-red.png" />
                    </td>
                    <td valign="top" align="left">
                        <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# "Job-Details.aspx?Job=" + Eval("strTitle").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-") + "&JobID=" + Eval("iID") %>'
                            CssClass="jobs" CausesValidation="false" Text='<%# Eval("strTitle") %>'></asp:HyperLink>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cp_left" runat="Server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="box">
        <div class="heading">
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </div>
    </div>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 10px !important;">
        <tr>
            <td class="Content">
                <table width="100%" cellpadding="4px" cellspacing="4px">
                    <tr>
                        <td width="15px" valign="top">
                            <img src="images/company.png" alt="category" />
                        </td>
                        <td width="60px" align="left" valign="top">
                            <strong>Company:</strong>
                        </td>
                        <td align="left" valign="top">
                            <asp:Label ID="lblCompany" runat="server" CssClass="" Font-Underline="false"> </asp:Label>
                        </td>
                        <td width="15px" valign="top">
                            <img src="images/date.png" alt="category" />
                        </td>
                        <td width="90px" align="right" valign="top">
                            <strong>Posted date:</strong>
                        </td>
                        <td width="170px" align="right" valign="top">
                            <asp:Label ID="lblPostedOn" runat="server" CssClass="" Font-Underline="false"> </asp:Label>
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
            <td class="heading">Paper Description
            </td>
        </tr>
        <tr>
            <td class="Content" valign="top" colspan="3">
                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                <br/>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="heading">Company Details
            </td>
        </tr>
        <tr>
            <td colspan="4" class="Content">
                <asp:Literal ID="ltDescription" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <%--<edu:Comment ID="Comment1" runat="server" />--%>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

<%--<asp:Content ID="Content4" ContentPlaceHolderID="cp_rightBottom" runat="Server">
</asp:Content>--%>
