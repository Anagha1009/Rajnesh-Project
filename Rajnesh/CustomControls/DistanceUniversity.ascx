<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DistanceUniversity.ascx.cs" Inherits="UserControls_Controls" %>
<asp:Repeater ID="rpt_DistanceUniversity" runat="server">
    <HeaderTemplate>
        <table cellpadding="2px" cellspacing="2px" width="100%" border="0" class="tbl_links">
            <tr>
                <td align="left" class="similarTitle">
                    Similar Distance Universities
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
                <a href='<%# "https://www.eduvidya.com/University/" + Eval("strName").ToString().Replace(" ","-") %>' class="_rec_links">
                    <%# Eval("strName")%></a>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
