<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sitemap_Generator.aspx.cs"
    Inherits="Sitemap_Generator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="https://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sitemap Generator</title>
    <style type="text/css">
        .title
        {
            font-size: 16px;
            font-weight: bold;
        }
        
        .link
        {
            color: #3D569C;
            font-size: 16px;
            text-decoration: none;
        }
        
        .link:hover
        {
            color: #cc0000;
            font-size: 16px;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
        <tr>
            <td class="title" align="left">
                Sitemap Generator
            </td>
        </tr>
        <tr id="tr_Sitemap" runat="server">
            <td align="left">
                <a href="" id="hyp_Sitemap" runat="server" class="link">Downlaod Sitemap</a>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Button ID="btn_Generate" runat="server" Text="Generate" OnClick="btn_Generate_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
