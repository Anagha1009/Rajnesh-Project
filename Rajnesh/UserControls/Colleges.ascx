<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Colleges.ascx.cs" Inherits="UserControls_Schools" %>
<div class="related-dv">
    <div class="heading">
        <p>Similar Colleges </p>
    </div>
    <ul>
        <asp:Repeater ID="rpt_Institutes" runat="server">

            <ItemTemplate>
                <li>
                    <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strTitle").ToString().Replace(" ","-")) %>' class="_rec_links">
                        <%# Eval("strTitle") %></a>
                </li>
            </ItemTemplate>

        </asp:Repeater>
    </ul>
</div>
