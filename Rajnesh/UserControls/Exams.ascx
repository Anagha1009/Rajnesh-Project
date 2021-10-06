<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Exams.ascx.cs" Inherits="UserControls_Schools" %>
<div class="related-dv">
    <div class="heading">
        <p>Similar Exams</p>
    </div>

    <ul>

        <asp:Repeater ID="rpt_Exams" runat="server">

            <ItemTemplate>
                <li><a href='<%# VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + Eval("strTitle").ToString().Replace(" ","-")) %>'
                    class="_rec_links">
                    <%# Eval("strTitle") %></a>
                <li>
            </ItemTemplate>

        </asp:Repeater>
    </ul>
</div>


