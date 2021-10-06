<%@ Page Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true" CodeFile="CountryMaster.aspx.cs" Inherits="admin_CountryMaster" Title="Admin :: Country Master" %>
<%@ Register TagName="errorMssg" src="~/admin/errorUserControl.ascx" TagPrefix="yo"%>
<%@ Register TagName="infoMssg" src="~/admin/infoUserControl.ascx" TagPrefix="yo"%>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" Runat="Server">
<br />
<yo:errorMssg ID="error" runat="server" Visible="false" />
<yo:infoMssg ID="info" runat="server" Visible="false" />
<br />
<table align="center" width="90%">
    <tr>
        <td >
          <asp:Label id="Label3" CssClass="font_title_text" runat="server" Text="C O U N T R Y&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
            <br />
            <hr />
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:GridView ID="grdCountryList" runat="server" Width="90%" GridLines="None" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found" EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center" AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID" PageSize="10" OnRowDeleting="grdCountryList_RowDeleting" OnSelectedIndexChanged="grdCountryList_SelectedIndexChanged" OnSorting="grdCountryList_Sorting" OnPageIndexChanging="grdCountryList_PageIndexChanging">
                <HeaderStyle HorizontalAlign="Center" />
                <Columns>
                  <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                      <ItemStyle HorizontalAlign="Center" Width="10%" />
                      <ItemTemplate>
                      <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                      </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="strCountryName" HeaderText="Name" SortExpression="strCountryName">
                        <ItemStyle HorizontalAlign="Center" Width="70%" />
                   </asp:BoundField>
                   <asp:TemplateField HeaderText="City">
                    <ItemStyle Width="20%" HorizontalAlign="center"/>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hylink_State" 
                            NavigateUrl='<%# "City.aspx?CountryID=" + Eval("iID") %>' 
                            Text="Add/View"></asp:HyperLink>
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
 <table align="center" width="90%">   
    <tr>
        <td >
           <asp:Label id="Label1" CssClass="font_title_text" runat="server" Text="C O U N T R Y&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
            <br />
            <hr />
            <br />
            <asp:ValidationSummary id="vsCountry" runat="server" HeaderText="You must enter a valid value in the following fields:"></asp:ValidationSummary> 
            <br />
            <asp:DetailsView ID="dvCountry" runat="server" AutoGenerateRows="False" DataKeyNames="iID" Width="50%" GridLines="None" OnItemInserting="dvCountry_ItemInserting" OnItemUpdating="dvCountry_ItemUpdating" OnModeChanging="dvCountry_ModeChanging" CellPadding="4" >
               <Fields>
                   <asp:BoundField DataField="iID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                   <asp:TemplateField HeaderText="Country Name">
                        <EditItemTemplate>
                          <asp:TextBox ID="txtCountryName" runat="server" Text='<%# Bind("strCountryName") %>'></asp:TextBox><asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ControlToValidate="txtCountryName" Display="Dynamic" ErrorMessage="Country Name" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                           <asp:TextBox ID="txtCountryName" runat="server" Text='<%# Bind("strCountryName") %>'></asp:TextBox><asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ControlToValidate="txtCountryName" Display="Dynamic" ErrorMessage="Country Name" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCountryName" runat="server" Text='<%# Bind("strCountryName") %>'></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField>
                    
                   <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
           </tr>
        </table>    
</asp:Content>

