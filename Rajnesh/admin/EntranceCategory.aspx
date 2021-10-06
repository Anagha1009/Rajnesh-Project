<%@ Page Title="Admin :: Control Panel" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="EntranceCategory.aspx.cs" Inherits="admin_ControlPanel"
    MaintainScrollPositionOnPostback="true" ValidateRequest="false" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <table width="95%" border="0" align="center">
        <tr>
            <td align="left" class="_heading">
                <asp:Label ID="Label2" CssClass="font_title_text" runat="server" Text="Search"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" class="arial-black">
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
            <td align="left">
                <asp:GridView ID="grd_Records" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="1" CellSpacing="1" DataKeyNames="iID"
                    OnRowDeleting="grd_Records_RowDeleting" OnSelectedIndexChanged="grd_Records_SelectedIndexChanged"
                    OnSorting="grd_Records_Sorting" OnPageIndexChanging="grd_Records_PageIndexChanging"
                    PageSize="25">
                    <HeaderStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="strTitle" HeaderText="Title" SortExpression="strTitle">
                            <ItemStyle Width="40%" HorizontalAlign="center" />
                        </asp:BoundField>

                        <asp:CommandField ButtonType="Image" HeaderText="Edit" CausesValidation="false" SelectImageUrl="~/Admin/images/edit.png"
                            ControlStyle-CssClass="_edit" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    ImageUrl="~/Admin/images/cross.gif" BackColor="Transparent" OnClientClick='return confirm("Are you sure you want to delete this entry?");' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BackColor="#F7F7F7"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <yo:infoMssg ID="info_dv" runat="server" Visible="false" />
    <yo:errorMssg ID="error_dv" runat="server" Visible="false" />
    <br />
    <table width="95%" align="center">
        <tr>
            <td class="_heading">
                <asp:Label ID="Label1" CssClass="font_title_text" runat="server" Text="School Category Details"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <div id="ScrollHere">
                </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dv_Records" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                    Width="100%" GridLines="None" CellPadding="3" CellSpacing="3" OnItemInserting="dv_Records_ItemInserting"
                    OnItemUpdating="dv_Records_ItemUpdating" OnModeChanging="dv_Records_ModeChanging">
                    <Fields>
                        <asp:BoundField DataField="iID" HeaderText="ID" Visible="False" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Title">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Eval("strTitle") %>' CssClass="txtBox">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Eval("strTitle") %>' CssClass="txtBox">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strTitle") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Description" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strDesc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strDesc") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strDesc") %>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                        
                        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" ControlStyle-CssClass="btn" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
