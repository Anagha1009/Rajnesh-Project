<%@ Control Language="C#" AutoEventWireup="true" CodeFile="error.ascx.cs"
    Inherits="errorUserControl" %>
<center>
    <table width="455px" class="infobox" align="center">
        <tr>
            <td style="padding-bottom:25px" align="center">
                <table>
                    <tr>
                        <td width="48px" align="left">
                            <asp:Image ID="imgError" BorderStyle="None" ImageUrl="~/admin/Images/error.png" runat="server" />
                        </td>
                        <td align="left">
                            <asp:Label CssClass="font_error" ID="mssg" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</center>
