<%@ Page Title="Control Panel | CategoryRank" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="CategoryRank.aspx.cs" Inherits="admin_CategoryRank"
    MaintainScrollPositionOnPostback="true" ValidateRequest="false" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <table width="95%" border="0" align="center">
        <tr>
            <td align="left">
                <asp:GridView ID="grd_Records" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    CssClass="tableMain" CellPadding="1" CellSpacing="1" DataKeyNames="iID" OnRowDeleting="grd_Records_RowDeleting"
                    OnSelectedIndexChanged="grd_Records_SelectedIndexChanged" OnSorting="grd_Records_Sorting"
                    OnPageIndexChanging="grd_Records_PageIndexChanging" PageSize="25">
                    <HeaderStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strInstitute" HeaderText="Institute" SortExpression="strInstitute">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strCategory" HeaderText="Category" SortExpression="strCategory">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="iRank" HeaderText="iRank" SortExpression="iRank">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Image" HeaderText="Edit" CausesValidation="false" SelectImageUrl="~/admin/images/edit_1.png"
                            ControlStyle-CssClass="_edit" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
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
    <br />
    <yo:infoMssg ID="info_dv" runat="server" Visible="false" />
    <yo:errorMssg ID="error_dv" runat="server" Visible="false" />
    <br />
    <table width="95%" align="center">
        <tr>
            <td align="left" class="font_title_text">
                CategoryRank Details
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
                    Width="95%" GridLines="None" CellPadding="3" CellSpacing="3" OnItemInserting="dv_Records_ItemInserting"
                    OnItemUpdating="dv_Records_ItemUpdating" OnModeChanging="dv_Records_ModeChanging"
                    OnDataBound="dv_Records_DataBound">
                    <Fields>
                        <asp:TemplateField ShowHeader="false">
                            <InsertItemTemplate>
                                <table width="100%" cellpadding="3px" cellspacing="3px" border="0px">
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Category
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="ddlbox">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Rank
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRank" runat="server" CssClass="txtbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </InsertItemTemplate>
                            <EditItemTemplate>
                                <table width="100%" cellpadding="3px" cellspacing="3px" border="0px">
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Category
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="ddlbox">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Rank
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRank" runat="server" CssClass="txtbox" Text='<%# Eval("iRank") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <table width="100%" cellpadding="3px" cellspacing="3px" border="0px">
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Category
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="ddlbox">
                                            </asp:DropDownList>
                                        </td>
                                        <tr>
                                            <td align="left" class="subTitle">
                                                Rank
                                            </td>
                                            <td align="left">
                                                <%# Eval("iRank") %>
                                            </td>
                                        </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" ControlStyle-CssClass="btn" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
