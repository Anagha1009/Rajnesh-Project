<%@ Page Title="Admin :: Faculty" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="Faculty.aspx.cs" Inherits="admin_Faculty" MaintainScrollPositionOnPostback="true"
    ValidateRequest="false" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
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
            <td align="left" colspan="3" class="arial-black">
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
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="grd_Faculty" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    OnRowDeleting="grd_Faculty_RowDeleting" OnSelectedIndexChanged="grd_Faculty_SelectedIndexChanged"
                    OnSorting="grd_Faculty_Sorting" OnPageIndexChanging="grd_Faculty_PageIndexChanging"
                    PageSize="10">
                    <HeaderStyle HorizontalAlign="Center" Width="25%" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <img src='<%# "Upload/Faculty/" + Eval("strFacultyPhoto") %>' alt="" class="photo" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="strFacultyName" HeaderText="Faculty Name" SortExpression="strFacultyName">
                            <ItemStyle Width="60%" HorizontalAlign="center" />
                        </asp:BoundField>
                        
                        <asp:CommandField ButtonType="Image" HeaderText="Edit" CausesValidation="false" SelectImageUrl="~/Admin/images/edit_1.png"
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
            <td class="_heading">
                <asp:Label ID="Label1" CssClass="font_title_text" runat="server" Text="Faculty Details"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <div id="ScrollHere">
                </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dv_Faculty" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                    Width="95%" GridLines="None" CellPadding="3" CellSpacing="3" OnItemInserting="dv_Faculty_ItemInserting"
                    OnItemUpdating="dv_Faculty_ItemUpdating" OnModeChanging="dv_Faculty_ModeChanging">
                    <Fields>
                        <asp:BoundField DataField="iID" HeaderText="ID" Visible="False" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("strFacultyName") %>' CssClass="txtBox">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="Name" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("strFacultyName") %>' CssClass="txtBox">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="Name" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("strFacultyName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Department">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDepartment" runat="server" Text='<%# Eval("strFacultyDept") %>' CssClass="txtBox">
                                </asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtDepartment" runat="server" Text='<%# Eval("strFacultyDept") %>' CssClass="txtBox">
                                </asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("strFacultyDept") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Designation">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDesignation" runat="server" Text='<%# Eval("strFacultyDesignation") %>' CssClass="txtBox">
                                </asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtDesignation" runat="server" Text='<%# Eval("strFacultyDesignation") %>' CssClass="txtBox">
                                </asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("strFacultyDesignation") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Profile" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtProfile" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strFacultyProfile") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtProfile" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strFacultyProfile") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblProfile" runat="server" Text='<%# Eval("strFacultyProfile") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Upload Image" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                    <tr>
                                        <td width="50px" align="left" valign="top" style="padding-top: 15px">
                                            <asp:Image ID="img_Image" runat="server" ImageUrl='<%# "Upload/Faculty/" + Eval("strFacultyPhoto") %>'
                                                Height="40px" BorderWidth="0px" />
                                        </td>
                                        <td>
                                            <div class="_Browse">
                                                <asp:FileUpload ID="fu_Image" runat="server" CssClass="_file" /><div class="_upload">
                                                </div>
                                                <asp:HiddenField ID="hfImage" runat="server" Value='<%# Eval("strFacultyPhoto") %>' />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <div class="_Browse">
                                    <asp:FileUpload ID="fu_Image" runat="server" CssClass="_file" /><div class="_upload">
                                    </div>
                                </div>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="img_Image" runat="server" ImageUrl='<%# "Upload/Faculty/" + Eval("strFacultyPhoto") %>'
                                    Height="70px" BorderWidth="0px" />
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
