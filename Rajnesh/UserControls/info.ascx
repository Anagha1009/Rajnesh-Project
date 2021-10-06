<%@ Control Language="C#" AutoEventWireup="true" CodeFile="info.ascx.cs"
    Inherits="infoUserControl" %>
<center>
    <table width="455px" class="infobox" align="center">
        <tr>
            <td style="padding-bottom:25px" align="center">
                <table>
                    <tr>
                        <td width="48px" align="left">
                            <asp:Image ID="Image1" BorderStyle="None" ImageUrl="~/admin/Images/info.png" runat="server" />
                        </td>
                        <td  align="left">
                            <asp:Label CssClass="font_info" ID="mssg" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</center>
