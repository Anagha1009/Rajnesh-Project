<%@ Page Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true" CodeFile="UniversitySubCategory.aspx.cs" Inherits="admin_UniversitySubCategory" Title="Admin :: University SubCategory" ValidateRequest="false" %>
<%@ Register TagName="errorMssg" src="~/admin/errorUserControl.ascx" TagPrefix="yo"%>
<%@ Register TagName="infoMssg" src="~/admin/infoUserControl.ascx" TagPrefix="yo"%>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" Runat="Server">
<br />
<yo:errorMssg ID="error" runat="server" Visible="false" />
<yo:infoMssg ID="info" runat="server" Visible="false" />
<br />

<table width="80%" align="center">
    <tr>
        <td align="left">
        <asp:Label ID="Label2" ForeColor="#ff6633" runat="server" Font-Bold="true" Text="Category Name : "></asp:Label>          
          <asp:Label ID="lbl_Title" runat="server" Font-Bold="true" ForeColor="#ff6633"></asp:Label><br /><br />
          <asp:Label id="Label3" CssClass="font_title_text" runat="server" Text="U N I V E R S I T Y&nbsp;&nbsp;&nbsp;&nbsp;S U B C A T E G O R Y&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
            <br />
            <hr />
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:GridView ID="grd_UniversitySubCategory" runat="server" Width="100%" GridLines="None" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found" EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center" AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID" PageSize="10" OnRowDeleting="grd_UniversitySubCategory_RowDeleting" OnSelectedIndexChanged="grd_UniversitySubCategory_SelectedIndexChanged" OnSorting="grd_UniversitySubCategory_Sorting" OnPageIndexChanging="grd_UniversitySubCategory_PageIndexChanging">
                <HeaderStyle HorizontalAlign="Center" />
                <Columns>
                   <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                      <ItemStyle HorizontalAlign="Center" Width="10%" />
                      <ItemTemplate>
                      <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                      </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="strSubCategoryTitle" HeaderText="Title" SortExpression="strSubCategoryTitle">
                        <ItemStyle Width="30%" HorizontalAlign="center"/>
                   </asp:BoundField>    
                   <%--<asp:BoundField DataField="strSubCategoryDesc" HeaderText="Description" SortExpression="strSubCategoryDesc">
                        <ItemStyle Width="40%" HorizontalAlign="center"/>
                   </asp:BoundField>--%>
                   <asp:TemplateField HeaderText="Description">
                      <ItemStyle HorizontalAlign="Center" Width="10%" />
                      <ItemTemplate>
                      <asp:Literal runat="server" ID="literal_desc" Text='<%# Bind("strSubCategoryDesc") %>'></asp:Literal>
                      </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Universities">
                    <ItemStyle Width="20%" HorizontalAlign="center"/>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hylink_Universities" NavigateUrl='<%# "University_List.aspx?SubCatID=" + Eval("iID") + "&CatID=" + Request.QueryString["CatID"] %>' Text="Add/View"></asp:HyperLink>
                        </ItemTemplate>
                   </asp:TemplateField>                         
                   <asp:CommandField ButtonType="Image" HeaderText="Edit" SelectImageUrl="~/Admin/images/edit.jpg"
                            ShowSelectButton="True">
                      <ItemStyle HorizontalAlign="Center" Width="10%" />
                   </asp:CommandField>
                   <asp:TemplateField HeaderText="Delete">
                      <ItemStyle HorizontalAlign="Center" Width="10%" />
                      <ItemTemplate>
                      <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/Admin/images/cross.gif" OnClientClick='return confirm("Are you sure you want to delete this entry?");' />
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

<table width="80%" align="center">   
    <tr>
        <td>
           <asp:Label id="Label1" CssClass="font_title_text" runat="server" Text="U N I V E R S I T Y&nbsp;&nbsp;&nbsp;&nbsp;S U B C A T E G O R Y&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
            <br />
            <hr />
            <br />
            <asp:ValidationSummary id="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:"></asp:ValidationSummary> 
            <br />
            <asp:DetailsView ID="dv_UniversitySubCategory" runat="server" AutoGenerateRows="False" DataKeyNames="iID" Width="50%" GridLines="None" OnItemInserting="dv_UniversitySubCategory_ItemInserting" OnItemUpdating="dv_UniversitySubCategory_ItemUpdating" OnModeChanging="dv_UniversitySubCategory_ModeChanging">
               <Fields>
                   <asp:BoundField DataField="iID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                   <asp:TemplateField HeaderText="Title">
                        <EditItemTemplate>
                          <asp:TextBox ID="txtSubCategoryTitle" runat="server" Text='<%# Bind("strSubCategoryTitle") %>'></asp:TextBox><asp:RequiredFieldValidator ID="rfvSubCategoryTitle" runat="server" ControlToValidate="txtSubCategoryTitle" Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                           <asp:TextBox ID="txtSubCategoryTitle" runat="server" Text='<%# Bind("strSubCategoryTitle") %>'></asp:TextBox><asp:RequiredFieldValidator ID="rfvSubCategoryTitle" runat="server" ControlToValidate="txtSubCategoryTitle" Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSubCategoryName" runat="server" Text='<%# Bind("strSubCategoryTitle") %>'></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField>   
                    <asp:TemplateField HeaderText="Description">
                        <EditItemTemplate>
                          <FCKeditorV2:FCKeditor ID="fckDesc" runat="server" BasePath="~/FCKeditor/"
                                Height="400px" width="600px" Value='<%# Eval("strSubCategoryDesc") %>'>
                            </FCKeditorV2:FCKeditor>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                           <FCKeditorV2:FCKeditor ID="fckDesc" runat="server" BasePath="~/FCKeditor/"
                                Height="400px" width="600px" Value='<%# Eval("strSubCategoryDesc") %>'>
                            </FCKeditorV2:FCKeditor>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSubCategoryDesc" runat="server" Text='<%# Bind("strSubCategoryDesc") %>'></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField>                 
                   <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
           </tr>
        </table>
</asp:Content>

