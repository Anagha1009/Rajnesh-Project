<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Questions.ascx.cs" Inherits="UserControls_Questions" %>
<asp:Repeater ID="rpt_Questions" runat="server" OnItemDataBound="rpt_Questions_ItemDataBound">
    <HeaderTemplate>
        <table cellpadding="0" cellspacing="0" width="100%" border="0" style="font-size: 12px;">
            <tr>
                <td align="left" class="rec_Title">
                    Related Questions
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
                <a href='<%# "https://www.recruitmentexam.com/Question/" + Eval("strQuestion").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-").Replace("'","") + "/"+ Eval("iID") %>'
                    class="jobs" style="font-size: small; font-weight: bold;">
                    <%# Eval("strQuestion") %></a>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Literal ID="ltl_user" runat="server"></asp:Literal>&nbsp;on&nbsp;<%# Eval("dtDate") %><asp:HiddenField
                    ID="hfID" Value='<%# bind("iID") %>' runat="server" />
                <asp:HiddenField ID="hfUserID" Value='<%# bind("iUserID") %>' runat="server" />
            </td>
        </tr>
        <tr style="height: 5px;">
            <td style="border-bottom: 1px dotted #EFB263; padding: 10px 10px 10px 0;" colspan="3">
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        <tr>
            <td valign="top" align="right" style="padding-top:10px">
                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                <tr><td align="left">
                <a href="https://www.recruitmentexam.com/Ask-Questions.aspx" class="jobs" style="font-size: small;
                    font-weight: bold;">Ask Us Now</a>
                </td>
                <td align="right">
                <a href="https://www.recruitmentexam.com/View-Questions.aspx" class="jobs" style="font-size: small;
                    font-weight: bold;">View All Questions</a>
                </td>
                </tr>
                </table>
                
                
            </td>
        </tr>
        </table>
    </FooterTemplate>
</asp:Repeater>
