<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Schools.ascx.cs" Inherits="UserControls_Controls" %>
<asp:Repeater ID="rpt_Schools" runat="server">
    <HeaderTemplate>
        <table cellpadding="2px" cellspacing="2px" width="100%" border="0" class="tbl_links">
            <tr>
                <td align="left" class="similarTitle">
                    Similar Schools
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td valign="top" align="left">
                <a href='<%# VirtualPathUtility.ToAbsolute("~/Schools/" + Eval("strTitle").ToString().Replace(" ","-")) %>' class="_rec_links">
                    <%# Eval("strTitle") %></a>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
