<%@ Page Title="Admin :: Job Company" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="JobCategory.aspx.cs" Inherits="admin_Articles" EnableEventValidation="false" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <br />
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <br />
    <table width="90%" border="0" align="center">
        <tr>
            <td align="left" colspan="3">
                <asp:Label ID="Label3" CssClass="font_title_text" runat="server" Text="J O B &nbsp;&nbsp;&nbsp;C A T E G O R Y&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="grdCategory" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    PageSize="10" OnRowDeleting="grdCategory_RowDeleting" OnSelectedIndexChanged="grdCategory_SelectedIndexChanged"
                    OnPageIndexChanging="grdCategory_PageIndexChanging" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strJobCategoryName" HeaderText="Title" SortExpression="strArticleTitle">
                            <ItemStyle Width="70%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="SubCetgory">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hylink_Category" NavigateUrl='<%# "JobSubCategory.aspx?CategoryID=" + Eval("iID") %>' Text="Add/View"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Image" HeaderText="Edit" CausesValidation="false" SelectImageUrl="~/Admin/images/edit.jpg"
                            ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
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
    <br />
    <yo:infoMssg ID="info_dv" runat="server" Visible="false" />
    <yo:errorMssg ID="error_dv" runat="server" Visible="false" />
    <br />
    <table width="90%" align="center">
        <tr>
            <td>
                <asp:Label ID="Label1" CssClass="font_title_text" runat="server" Text="J O B &nbsp;&nbsp;&nbsp;C A T E G O R Y&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
                <br />
                <hr />
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dvCategory" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                    Width="50%" GridLines="None" CellPadding="3" CellSpacing="3" OnItemInserting="dvCategory_ItemInserting"
                    OnItemUpdating="dvCategory_ItemUpdating" OnModeChanging="dvCategory_ModeChanging">
                    <Fields>
                        <asp:BoundField DataField="iID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Title">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("strJobCategoryName") %>'>
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSubCategoryTitle" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("strJobCategoryName") %>'>
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSubCategoryTitle" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("strJobCategoryName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckDesc" runat="server" BasePath="~/FCKeditor/" Height="400px"
                                    Width="600px" Value='<%# Eval("strJobCategoryDesc") %>'>
                                </FCKeditorV2:FCKeditor>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckDesc" runat="server" BasePath="~/FCKeditor/" Height="400px"
                                    Width="600px" Value='<%# Eval("strJobCategoryDesc") %>'>
                                </FCKeditorV2:FCKeditor>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSubCategoryDesc" runat="server" Text='<%# Bind("strJobCategoryDesc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
