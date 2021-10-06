<%@ Page Title="Admin :: Abused Comments" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="AbusedComments.aspx.cs" Inherits="admin_Comments" %>
<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <br />
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <br />
    <table width="90%" align="center">
        <tr>
            <td align="left">
                <asp:Label ID="Label3" CssClass="font_title_text" runat="server" Text="Abused Comments"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:GridView ID="grd_Comments" runat="server" Width="100%" GridLines="None"
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    PageSize="20" OnRowDeleting="grd_Comments_RowDeleting" PagerSettings-PageButtonCount="50" OnSorting="grd_Comments_Sorting"
                    OnPageIndexChanging="grd_Comments_PageIndexChanging" OnRowCommand="grd_Comments_RowCommand"
                    OnRowDataBound="grd_Comments_RowDataBound">
                    <HeaderStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="strName" HeaderText="Name" SortExpression="strName">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="strEmail" HeaderText="Email" SortExpression="strEmail">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="strPhone" HeaderText="Phone" SortExpression="strPhone">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="strComment" HeaderText="Comment" SortExpression="strComment">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="strUrl" HeaderText="Url" SortExpression="strUrl">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="dtDate" HeaderText="Date" SortExpression="dtDate">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="strIp" HeaderText="Ip" SortExpression="strIp">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Abuse">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="btnAbuse" CommandName="Abuse" CommandArgument='<%# Eval("iID") %>'
                                    CausesValidation="false" />
                                <asp:HiddenField runat="server" ID="hfAbuse" Value='<%# Eval("bAbuse") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Enable">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="btnEnable" CommandName="Enable" CommandArgument='<%# Eval("iID") %>'
                                    CausesValidation="false" />
                                <asp:HiddenField runat="server" ID="hfEnable" Value='<%# Eval("bActive") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    ImageUrl="~/Admin/images/cross.gif" OnClientClick='return confirm("Are you sure you want to delete this entry?");' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
