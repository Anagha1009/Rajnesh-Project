<%@ Page Title="Admin :: Job Company" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="JobCompany.aspx.cs" Inherits="admin_Articles" %>

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
                <asp:Label ID="Label3" CssClass="font_title_text" runat="server" Text="J O B &nbsp;&nbsp;&nbsp;C O M P A N Y&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="3" style="padding-top: 10px; padding-bottom: 10px">
                <asp:TextBox ID="txtSearch" runat="server" Width="210px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" 
                    onclick="btnSearch_Click" ValidationGroup="y"/>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="grdCompany" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    PageSize="10" OnRowDeleting="grdCompany_RowDeleting" OnSelectedIndexChanged="grdCompany_SelectedIndexChanged"
                    OnPageIndexChanging="grdCompany_PageIndexChanging" OnRowCommand="grdCompany_RowCommand"
                    OnRowDataBound="grdCompany_RowDataBound">
                    <HeaderStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Logo">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <img src='<%# "../Logos/" + Eval("strlogo") %>' style="border:0px; height:80px; width:100px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strJobCompanyName" HeaderText="Title" SortExpression="strArticleTitle">
                            <ItemStyle Width="40%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strContactDetails" HeaderText="Contact Details" SortExpression="strArticleTitle">
                            <ItemStyle Width="40%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Featured">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="btnFeatured" CommandName="Featured" CommandArgument='<%# Eval("iID") %>'
                                    CausesValidation="false" />
                                <asp:HiddenField runat="server" ID="hfFeatured" Value='<%# Eval("bFeatured") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
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
                <asp:Label ID="Label1" CssClass="font_title_text" runat="server" Text="J O B &nbsp;&nbsp;&nbsp;C O M P A N Y&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
                <br />
                <hr />
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dvCompany" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                    Width="50%" GridLines="None" CellPadding="3" CellSpacing="3" OnItemInserting="dvCompany_ItemInserting"
                    OnItemUpdating="dvCompany_ItemUpdating" OnModeChanging="dvCompany_ModeChanging"
                    OnDataBound="dvCompany_DataBound">
                    <Fields>
                        <asp:BoundField DataField="iID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                        
                         <asp:TemplateField HeaderText="Category">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="ddlBox">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory"
                                    Display="Dynamic" ErrorMessage="Category" SetFocusOnError="True" InitialValue="0">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="ddlBox">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory"
                                    Display="Dynamic" ErrorMessage="Category" SetFocusOnError="True" InitialValue="0">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCategory" runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Title">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("strJobCompanyName") %>'>
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSubCategoryTitle" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("strJobCompanyName") %>'>
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSubCategoryTitle" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("strJobCompanyName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckDesc" runat="server" BasePath="~/FCKeditor/" Height="400px"
                                    Width="600px" Value='<%# Eval("strJobCompanyDesc") %>'>
                                </FCKeditorV2:FCKeditor>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckDesc" runat="server" BasePath="~/FCKeditor/" Height="400px"
                                    Width="600px" Value='<%# Eval("strJobCompanyDesc") %>'>
                                </FCKeditorV2:FCKeditor>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDesc" runat="server" Text='<%# Bind("strJobCompanyDesc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contact Details" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckContacts" runat="server" BasePath="~/FCKeditor/" Height="400px"
                                    Width="600px" Value='<%# Eval("strContactDetails") %>'>
                                </FCKeditorV2:FCKeditor>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckContacts" runat="server" BasePath="~/FCKeditor/" Height="400px"
                                    Width="600px" Value='<%# Eval("strContactDetails") %>'>
                                </FCKeditorV2:FCKeditor>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblContacts" runat="server" Text='<%# Bind("strContactDetails") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("strEmail") %>'>
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("strEmail") %>'>
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtWebsite" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("strEmail") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Featured">
                            <EditItemTemplate>
                                <asp:HiddenField ID="hfFeatured" runat="server" Value='<%# Eval("bFeatured")%>' />
                                <asp:CheckBox ID="chkFeatured" runat="server" />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:CheckBox ID="chkFeatured" runat="server" />
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="hfFeatured" runat="server" Value='<%# Eval("bFeatured")%>' />
                                <asp:Label ID="lblFeatured" runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Upload Logo" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                    <tr>
                                        <td width="50px" align="left" valign="top" style="padding-top: 15px">
                                            <asp:Image ID="img_Image" runat="server" ImageUrl='<%# "~/Logos/" + Eval("strLogo") %>'
                                                Height="40px" BorderWidth="0px" />
                                        </td>
                                        <td>
                                            <div class="_Browse">
                                                <asp:FileUpload ID="fu_Image" runat="server" CssClass="_file" /><div class="_upload">
                                                </div><asp:HiddenField ID="hfImage" runat="server" Value='<%# Eval("strLogo") %>'/>
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
                                <asp:Image ID="img_Image" runat="server" ImageUrl='<%# "~/Logos/" + Eval("strLogo") %>'
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
