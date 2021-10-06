<%@ Page Title="Admin :: DL Course Features" Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true" CodeFile="DistanceLearningFeatures.aspx.cs" Inherits="admin_DistanceLearningFeatures" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" Runat="Server">
<br />
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <br />
    <table width="90%" align="center">       
        <tr>
            <td align="left">
            <asp:Label ID="Label4" ForeColor="#ff6633" runat="server" Font-Bold="true" Text="Distance Learning Title : "></asp:Label>
                <asp:Label ID="lbl_DistanceLearningTitle" ForeColor="#ff6633" runat="server" Font-Bold="true">
                </asp:Label><br />
                <br />
                <asp:Label ID="Label2" ForeColor="#ff6633" runat="server" Font-Bold="true" Text="Course Title : "></asp:Label>
                <asp:Label ID="lbl_Title" ForeColor="#ff6633" runat="server" Font-Bold="true"></asp:Label><br />
                <br />
                <asp:Label ID="Label3" CssClass="font_title_text" runat="server" Text="C O U R S E S&nbsp;&nbsp;&nbsp;&nbsp;F E A T U R E S&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="grd_DLearningFeatures" runat="server" Width="100%" GridLines="None"
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found" EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    PageSize="10" OnRowDeleting="grd_DLearningFeatures_RowDeleting" OnSelectedIndexChanged="grd_DLearningFeatures_SelectedIndexChanged"
                    OnSorting="grd_DLearningFeatures_Sorting" OnPageIndexChanging="grd_DLearningFeatures_PageIndexChanging">
                    <HeaderStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:BoundField DataField="strName" HeaderText="Title" SortExpression="strName">
                            <ItemStyle Width="30%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemStyle HorizontalAlign="Center" Width="35%" />
                            <ItemTemplate>
                                <asp:Literal runat="server" ID="lblLiteral" Text='<%# Eval("strDescription") %>'></asp:Literal>
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
                    <AlternatingRowStyle BackColor="#F7F7F7"></AlternatingRowStyle>
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
                <asp:Label ID="Label1" CssClass="font_title_text" runat="server" Text="C O U R S E S&nbsp;&nbsp;&nbsp;&nbsp;F E A T U R E S&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
                <br />
                <hr />
                <br />
                <asp:ValidationSummary ID="vs_CareerIndustry" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dv_DLearningFeatures" runat="server" AutoGenerateRows="False"
                    DataKeyNames="iID" Width="50%" GridLines="None" OnItemInserting="dv_DLearningFeatures_ItemInserting"
                    OnItemUpdating="dv_DLearningFeatures_ItemUpdating" OnModeChanging="dv_DLearningFeatures_ModeChanging">
                    <Fields>
                        <asp:BoundField DataField="iID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("strName") %>'></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("strName") %>'></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Title"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("strName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <FCKeditorV2:FCKeditor ID="FCKDesc" BasePath="~/FCKeditor/" Value='<%# Bind("strDescription") %>'
                                    Height="400" runat="server" Width="550" />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <FCKeditorV2:FCKeditor ID="FCKDesc" BasePath="~/FCKeditor/" Value='<%# Bind("strDescription") %>'
                                    Height="400" runat="server" Width="550" />
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Literal ID="lblDescription" runat="server" Text='<%# Bind("strDescription") %>'>
                                </asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>

