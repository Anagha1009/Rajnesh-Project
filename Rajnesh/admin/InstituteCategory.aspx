<%@ Page Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true"
    CodeFile="InstituteCategory.aspx.cs" Inherits="admin_InstituteCategory" Title="Admin :: Institute Category"
    ValidateRequest="false" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <br />
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <br />
    <table width="90%" align="center">
        <tr>
            <td align="left">
                <asp:Label ID="Label3" CssClass="font_title_text" runat="server" Text="C A T E G O R Y&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="grd_InstCategory" runat="server" Width="100%" GridLines="None"
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    PageSize="10" OnRowDeleting="grd_InstCategory_RowDeleting" OnSelectedIndexChanged="grd_InstCategory_SelectedIndexChanged"
                    OnSorting="grd_InstCategory_Sorting" OnPageIndexChanging="grd_InstCategory_PageIndexChanging">
                    <HeaderStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strCategoryTitle" HeaderText="Title" SortExpression="strCategoryTitle">
                            <ItemStyle Width="20%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Image" SortExpression="iID">
                            <ItemTemplate>
                                <asp:Image ID="imgProduct" Width="100px" Height="70px" runat="server" ImageUrl='<%#"~/admin/Upload/InstituteCategory/" +Eval("strImage")%>'>
                                </asp:Image>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblOrder" Text='<%# Eval("iOrder") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Add/View Pages">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='<%# "Page.aspx?CategoryID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" class="Icons" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ButtonType="Image" HeaderText="Edit" SelectImageUrl="~/Admin/images/edit.jpg"
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
                <asp:Label ID="Label1" CssClass="font_title_text" runat="server" Text="C A T E G O R Y&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
                <br />
                <hr />
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dv_InstCategory" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                    Width="50%" GridLines="None" OnItemInserting="dv_InstCategory_ItemInserting"
                    OnItemUpdating="dv_InstCategory_ItemUpdating" OnModeChanging="dv_InstCategory_ModeChanging"
                    OnDataBound="dv_InstCategory_DataBound">
                    <Fields>
                        <asp:BoundField DataField="iID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Title">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCategoryTitle" runat="server" Text='<%# Bind("strCategoryTitle") %>'></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfvCategoryTitle" runat="server" ControlToValidate="txtCategoryTitle" Display="Dynamic"
                                    ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtCategoryTitle" runat="server" Text='<%# Bind("strCategoryTitle") %>'></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfvCategoryTitle" runat="server" ControlToValidate="txtCategoryTitle" Display="Dynamic"
                                    ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCategoryName" runat="server" Text='<%# Bind("strCategoryTitle") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <%--<asp:TextBox ID="txtCategoryDesc" runat="server" Text='<%# Bind("strCategoryDesc") %>' TextMode="MultiLine"></asp:TextBox><asp:RequiredFieldValidator ID="rfvCategoryDesc" runat="server" ControlToValidate="txtCategoryDesc" Display="Dynamic" ErrorMessage="Description" SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                <FCKeditorV2:FCKeditor ID="fckDesc" runat="server" BasePath="~/FCKeditor/" Height="400px"
                                    Width="600px" Value='<%# Eval("strCategoryDesc") %>'>
                                </FCKeditorV2:FCKeditor>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <%--<asp:TextBox ID="txtCategoryDesc" runat="server" Text='<%# Bind("strCategoryDesc") %>' TextMode="MultiLine"></asp:TextBox><asp:RequiredFieldValidator ID="rfvCategoryDesc" runat="server" ControlToValidate="txtCategoryDesc" Display="Dynamic" ErrorMessage="Description" SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                <FCKeditorV2:FCKeditor ID="fckDesc" runat="server" BasePath="~/FCKeditor/" Height="400px"
                                    Width="600px" Value='<%# Eval("strCategoryDesc") %>'>
                                </FCKeditorV2:FCKeditor>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCategoryDesc" runat="server" Text='<%# Bind("strCategoryDesc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-VerticalAlign="Top" HeaderText="Current&nbsp;Image">
                            <EditItemTemplate>
                                <asp:Image ID="sectionimg" ImageUrl='<%#"~/admin/Upload/InstituteCategory/" +Eval("strImage")%>'
                                    ToolTip='<%# Bind("strImage") %>' runat="server" Width="100px" Height="80px" />
                                <asp:HiddenField ID="hid_imgfile" Value='<%# Eval("strImage") %>' runat="server" />
                                <asp:HiddenField runat="server" ID="hfId" Value='<%# Eval("iID") %>' />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:Image ID="sectionimg" ImageUrl="~/admin/images/noimage.jpg" runat="server" Width="100px"
                                    Height="80px" />
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="sectionimg1" ImageUrl='<%#"~/admin/Upload/InstituteCategory/" +Eval("strImage")%>'
                                    runat="server" Width="100px" Height="80px" />
                                <asp:HiddenField runat="server" ID="hfId" Value='<%# Eval("iID") %>' />
                                <asp:Label runat="server" ID="lblImageName"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Upload&nbsp;Image">
                            <InsertItemTemplate>
                                <asp:FileUpload ID="fuCategoryImage" runat="server" CssClass="btn_input" />
                                <asp:RequiredFieldValidator ID="rfvImage" runat="server" ControlToValidate="fuCategoryImage"
                                    Display="Dynamic" ErrorMessage="Image" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <EditItemTemplate>
                                <asp:FileUpload ID="fuCategoryImage" runat="server" CssClass="btn_input" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order">
                            <EditItemTemplate>
                                <asp:DropDownList runat="server" ID="ddl_Order">
                                </asp:DropDownList>
                                <asp:HiddenField runat="server" ID="hfOrder" Value='<%# Eval("iOrder") %>' />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbl_Order" Text='<%# Eval("iOrder") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
