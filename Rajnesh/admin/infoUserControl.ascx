<%@ Control Language="C#" AutoEventWireup="true" CodeFile="infoUserControl.ascx.cs"
    Inherits="infoUserControl" %>
<center>
    <table width="455px" class="info">
        <tr align="center">
            <td>
                <table width="100%">
                    <tr align="center">
                        <td style="width: 20%">
                            <asp:Image ID="Image1" BorderStyle="None" ImageUrl="~/Admin/Images/info.png" runat="server" />
                        </td>
                        <td style="width: 80%">
                            <asp:Label CssClass="font_info" ID="mssg" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</center>
