<%@ Page Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true"
    CodeFile="UniversityCity.aspx.cs" Inherits="Admin_Machine" Title="Admin :: City Master" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <center>
        <br />
        <yo:errorMssg ID="error" runat="server" Visible="false" />
        <yo:infoMssg ID="info" runat="server" Visible="false" />
        <br />
        <table align="center" width="85%" border="0">
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="Label3" ForeColor="#ff6633" runat="server" Font-Bold="true" Text="Country Name : "></asp:Label>
                    <asp:Label ID="lblCountry" ForeColor="#ff6633" runat="server" Font-Bold="true"></asp:Label><br /><br />
                    <asp:Label ID="Label2" CssClass="font_title_text" runat="server" Text="C I T Y&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
                    <br />
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="grdCityList" runat="server" CssClass="GridViewStyle" Width="100%"
                        GridLines="None" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        EmptyDataText="No Records Found" EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                        AlternatingRowStyle-BackColor="#F7F7F7" DataKeyNames="iID" PageSize="25" PagerSettings-PageButtonCount="50" OnRowDeleting="grdCityList_RowDeleting"
                        OnSelectedIndexChanged="grdCityList_SelectedIndexChanged" OnPageIndexChanging="grdCityList_PageIndexChanging"
                        OnSorting="grdCityList_Sorting" CellPadding="4" CellSpacing="4">
                        <HeaderStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr No.">
                                <ItemTemplate>
                                    <asp:Label ID="sno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="strCityName" HeaderText="City" SortExpression="strCityName">
                                <ItemStyle Width="30%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:CommandField ButtonType="Image" HeaderText="Edit" SelectImageUrl="~/Admin/images/edit.jpg"
                                ShowSelectButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                        ImageUrl="~/Admin/images/cross.gif" OnClientClick='return confirm("Are you sure you want to delete this entry?");' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="RowStyle" />
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <EditRowStyle CssClass="EditRowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
        <yo:infoMssg ID="info_dv" runat="server" Visible="false" />
        <yo:errorMssg ID="error_dv" runat="server" Visible="false" />
        <br />
        <table width="85%" border="0">
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="Label1" CssClass="font_title_text" runat="server" Text="C I T Y&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
                    <br />
                    <hr />
                    <asp:ValidationSummary ID="vsCity" runat="server" HeaderText="You must enter a valid value in the following fields:">
                    </asp:ValidationSummary>                    
                    <asp:DetailsView ID="dvCity" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                        Width="60%" GridLines="None" OnItemInserting="dvCity_ItemInserting" OnModeChanging="dvCity_ModeChanging" OnItemUpdating="dvCity_ItemUpdating" CellPadding="4">
                        <Fields>
                            <asp:TemplateField  HeaderText="City Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtName" Width="200" runat="server" Text='<%# Bind("strCityName") %>'></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="City Name" SetFocusOnError="True">  *</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtName" Width="200" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" 
                                    ErrorMessage="City Name" SetFocusOnError="True">  *</asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("strCityName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ControlStyle-CssClass="comlink" ShowEditButton="True" ShowInsertButton="True" />
                        </Fields>
                    </asp:DetailsView>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
