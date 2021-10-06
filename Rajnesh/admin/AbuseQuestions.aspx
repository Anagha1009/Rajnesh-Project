<%@ Page Title="Admin :: AbuseQuestions" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="AbuseQuestions.aspx.cs" Inherits="admin_AbuseQuestions"
    MaintainScrollPositionOnPostback="true" ValidateRequest="false" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <table width="95%" border="0" align="center">
        <tr>
            <td align="left" colspan="3" class="_heading">
                <asp:Label ID="Label2" CssClass="font_title_text" runat="server" Text="Search"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <yo:errorMssg ID="error" runat="server" Visible="false" />
                <yo:infoMssg ID="info" runat="server" Visible="false" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="grd_Questions" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    OnRowDeleting="grd_Questions_RowDeleting" OnSorting="grd_Questions_Sorting" OnPageIndexChanging="grd_Questions_PageIndexChanging"
                    PageSize="10" OnRowCommand="grd_Questions_RowCommand" OnRowDataBound="grd_Questions_RowDataBound">
                    <HeaderStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Posted By">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:HiddenField ID="hfUser" runat="server" Value='<%# Eval("iUserID") %>' />
                                <asp:HyperLink ID="hypUser" runat="server" NavigateUrl='<%# "UserDetails.aspx?userId=" + Eval("iUserID") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Abused By">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:HiddenField ID="hf_User" runat="server" Value='<%# Eval("iAbuseUserID") %>' />
                                <asp:HyperLink ID="hyp_User" runat="server" NavigateUrl='<%# "UserDetails.aspx?userId=" + Eval("iUserID") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strQuestion" HeaderText="Question" SortExpression="strQuestion">
                            <ItemStyle Width="45%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dtDate" HeaderText="Date" SortExpression="dtDate">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Remove From Abuse & Approve">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="btnApprove" CommandName="Approve" CommandArgument='<%# Eval("iID") %>'
                                    CausesValidation="false" BackColor="Transparent" />
                                <asp:HiddenField runat="server" ID="hfApprove" Value='<%# Eval("bAbuse") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
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
