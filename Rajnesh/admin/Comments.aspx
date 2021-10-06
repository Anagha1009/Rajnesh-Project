<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true"
    CodeFile="Comments.aspx.cs" Inherits="admin_Comments" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <br />
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <br />
    <table width="90%" align="center">
        <tr>
            <td align="left" colspan="3" class="_heading">
                <asp:Label ID="Label3" CssClass="font_title_text" runat="server" Text="Comments"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td width="90px">
                            Keywords :
                        </td>
                        <td width="290px">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="txtBox">
                            </asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:ImageButton ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                CausesValidation="false" ImageUrl="~/admin/images/Search.png" BackColor="White" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="grd_Comment" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    PageSize="10" OnRowDeleting="grd_Comment_RowDeleting" OnSorting="grd_Comment_Sorting"
                    OnPageIndexChanging="grd_Comment_PageIndexChanging" OnRowCommand="grd_Comment_RowCommand"
                    OnRowDataBound="grd_Comment_RowDataBound">
                    <HeaderStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strType" HeaderText="Type" SortExpression="strType">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Url">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a href='<%# Eval("strUrl") %>' target="_blank">
                                    <%# Eval("strUrl") %></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strName" HeaderText="Name" SortExpression="strName">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strEmail" HeaderText="Email" SortExpression="strEmail">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strPhone" HeaderText="Phone" SortExpression="strPhone">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strTitle" HeaderText="Title" SortExpression="strTitle">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strDesc" HeaderText="Comment" SortExpression="strDesc">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Enable">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="btnEnable" CommandName="Enable" CommandArgument='<%# Eval("iID") %>'
                                    CausesValidation="false" />
                                <asp:HiddenField runat="server" ID="hfEnable" Value='<%# Eval("bActive") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbl_Date" Text='<%# Eval("dtDate","{0:MMMM dd, yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    ImageUrl="~/Admin/images/delete.png" BackColor="Transparent" OnClientClick='return confirm("Are you sure you want to delete this entry?");' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BackColor="#F7F7F7"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
