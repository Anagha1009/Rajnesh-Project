<%@ Page Title="" Language="C#" MasterPageFile="~/Careers/ClientMaster.master" AutoEventWireup="true"
     CodeFile="File.aspx.cs" Inherits="Career_files" EnableEventValidation="false" %>

<%@ Register Src="UserControls/Careers.ascx" TagName="Careers" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title id="meta_title" runat="server"></title>
    <meta name="Description" content="" id="meta_Description" runat="server" />
    <meta name="Keywords" content="" id="meta_Keywords" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <br />
    <table width="100%" cellpadding="4px" cellspacing="4px" border="0" style="border: 1px solid #ccc">
        <tr>
            <td align="left" class="_title" colspan="2">Similar Jobs
            </td>
        </tr>
        <asp:Repeater ID="rpt_Jobs" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="left" width="25px">
                        <img src="/img/bullet-red.png" />
                    </td>
                    <td valign="top" align="left">
                        <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# "/Job-Details.aspx?Job=" + Eval("strTitle").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-") + "&JobID=" + Eval("iID") %>'
                            CssClass="jobs" CausesValidation="false" Text='<%# Eval("strTitle") %>'></asp:HyperLink>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <br />
    <table width="100%" cellpadding="4px" cellspacing="4px" border="0" style="border: 1px solid #ccc">
        <tr>
            <td align="left" class="_title" colspan="2">Similar Category Jobs
            </td>
        </tr>
        <asp:Repeater ID="rpt_Query" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="left" width="25px">
                        <img src="/img/bullet-red.png" />
                    </td>
                    <td valign="top" align="left">
                        <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# System.Web.Routing.RouteTable.Routes.GetVirtualPath(null, "JobGenaratorList", new System.Web.Routing.RouteValueDictionary { { "Job", Eval("strFileName") } }).VirtualPath%>'
                            CssClass="jobs" CausesValidation="false" Text='<%# Eval("strPageTitle") %>'></asp:HyperLink>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <br />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cp_main" runat="Server">
    <asp:Careers ID="Careers1" runat="server" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cp_right" runat="Server">
    <br />
    <table width="100%" cellpadding="4px" cellspacing="4px" border="0" style="border: 1px solid #ccc">
        <tr>
            <td align="left" class="_title" colspan="2">Similar Company Jobs
            </td>
        </tr>
        <asp:Repeater ID="rpt_Other" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="left" width="25px">
                        <img src="/img/bullet-red.png" />
                    </td>
                    <td valign="top" align="left">
                        <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# "/Careers/File.aspx?Jobs=" + Eval("strFileName").ToString() %>'
                            CssClass="jobs" CausesValidation="false" Text='<%# Eval("strPageTitle") %>'></asp:HyperLink>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
