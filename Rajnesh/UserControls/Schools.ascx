<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Schools.ascx.cs" Inherits="UserControls_Schools" %>
<div class="related-dv">
    <div class="heading">
        <p>Similar Schools</p>
    </div>

    <ul>
        <asp:Repeater ID="rpt_Schools" runat="server">

            <ItemTemplate>
                <li>
                    <a href='<%# VirtualPathUtility.ToAbsolute("~/Schools/" + Eval("strTitle").ToString().Replace(" ","-")) %>'>
                        <%# Eval("strTitle") %></a>
                </li>
            </ItemTemplate>

        </asp:Repeater>
    </ul>
</div>
