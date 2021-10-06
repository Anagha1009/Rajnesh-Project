<%@ Page Language="C#" MasterPageFile="~/Papers/ClientMaster.master" AutoEventWireup="true"
    CodeFile="File.aspx.cs" Inherits="Paper_files" EnableEventValidation="false"  %>

<%@ Register Src="UserControls/Papers.ascx" TagName="Papers" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title id="meta_title" runat="server"></title>
    <meta name="Description" content="" id="meta_Description" runat="server" />
    <meta name="Keywords" content="" id="meta_Keywords" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <br />
    <table width="100%" cellpadding="4px" cellspacing="4px" border="0" style="border: 1px solid #ccc">
        <tr>
            <td align="left" class="_title" colspan="2">Similar Papers
            </td>
        </tr>
        <asp:Repeater ID="rpt_Papers" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="left" width="25px">
                        <img src="/img/bullet-red.png" />
                    </td>
                    <td valign="top" align="left">
                        <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# "/Placement-Paper-Details.aspx?Paper=" + Eval("strPageTitle").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-") + "&PaperID=" + Eval("iID") %>'
                            CssClass="jobs" CausesValidation="false" Text='<%# Eval("strPageTitle") %>'></asp:HyperLink>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <br />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cp_main" runat="Server">
    <asp:Papers ID="Papers1" runat="server" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cp_right" runat="Server">
</asp:Content>

