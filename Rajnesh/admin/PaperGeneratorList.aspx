<%@ Page Title="Admin :: Paper Generator List" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="PaperGeneratorList.aspx.cs" Inherits="admin_Articles" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <br />
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <br />
    <table width="90%" border="0" align="center">
        <tr>
            <td align="left">
                <asp:Label ID="Label3" CssClass="font_title_text" runat="server" Text="P A P E R&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
          <tr>
            <td style="padding:10px">
               <asp:TextBox ID="txtSearch" runat="server" Width="270px"></asp:TextBox> &nbsp;&nbsp;<asp:Button 
                    ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" ValidationGroup="myGroup"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add New" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="grd_Query" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    OnRowDeleting="grd_Query_RowDeleting" OnPageIndexChanging="grd_Query_PageIndexChanging"
                    OnRowDataBound="grd_Query_RowDataBound" 
                    onrowcommand="grd_Query_RowCommand">
                    <HeaderStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strFileName" HeaderText="FileName">
                            <ItemStyle Width="20%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strType" HeaderText="Type">
                            <ItemStyle Width="20%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strMetaTitle" HeaderText="Meta Title" />
                        <asp:TemplateField HeaderText="View" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <a href='<%# System.Web.Routing.RouteTable.Routes.GetVirtualPath(null, "PaperGenaratorList", new System.Web.Routing.RouteValueDictionary { { "Paper", Eval("strFileName") } }).VirtualPath%>'
                                    target="_blank">View</a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <a href='<%# "PaperGenerator.aspx?Mode=Update&PaperId=" + Eval("iID")  %>'>
                                    <asp:Image ID="img" runat="server" ImageUrl="~/Admin/images/edit.jpg" ImageAlign="AbsMiddle" /></a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Show on Home">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="btnHome" CommandName="showHome" CommandArgument='<%# Eval("iID") %>'
                                    CausesValidation="false" />
                                <asp:HiddenField runat="server" ID="hfHome" Value='<%# Eval("iID") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    ImageUrl="~/Admin/images/cross.gif" OnClientClick='return confirm("Are you sure you want to delete this entry?");' />
                                <asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("iID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BackColor="#F7F7F7"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
