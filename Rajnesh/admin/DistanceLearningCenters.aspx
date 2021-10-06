<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true" CodeFile="DistanceLearningCenters.aspx.cs" Inherits="admin_DistanceLearningCenters" %>
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
             <asp:Label ID="Label2" ForeColor="#ff6633" runat="server" Font-Bold="true" Text="D L Institute Name : "></asp:Label><asp:Label ID="lbl_TestPrepare" ForeColor="#ff6633" runat="server" Font-Bold="true"></asp:Label>
             <br /><br />
          <asp:Label id="Label3" CssClass="font_title_text" runat="server" Text="D I S T A N C E&nbsp;&nbsp;&nbsp;&nbsp;L E A R N I N G&nbsp;&nbsp;&nbsp;&nbsp;C E N T E R&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
            <br />
            <hr />
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:GridView ID="grd_DLCentres" runat="server" Width="100%" GridLines="None" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found" EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center" AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID" PageSize="10" OnRowDeleting="grd_DLCentres_RowDeleting" OnSelectedIndexChanged="grd_DLCentres_SelectedIndexChanged" OnSorting="grd_DLCentres_Sorting" OnPageIndexChanging="grd_DLCentres_PageIndexChanging">
                <HeaderStyle HorizontalAlign="Center" />
                <Columns>
                   <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                      <ItemStyle HorizontalAlign="Center" Width="10%" />
                      <ItemTemplate>
                      <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                      </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="strCity" HeaderText="City" SortExpression="strCity">
                        <ItemStyle Width="20%" HorizontalAlign="center"/>
                   </asp:BoundField>                       
                   <asp:TemplateField HeaderText="Address">
                    <ItemStyle Width="50%" HorizontalAlign="center"/>
                        <ItemTemplate>
                            <asp:Literal runat="server" ID="lbl_Address" Text='<%# Eval("strAddress") %>'>
                            </asp:Literal>
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
           <asp:Label id="Label1" CssClass="font_title_text" runat="server" Text="D I S T A N C E&nbsp;&nbsp;&nbsp;&nbsp;L E A R N I N G&nbsp;&nbsp;&nbsp;&nbsp;C E N T E R&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
            <br />
            <hr />
            <br />
            <asp:ValidationSummary id="vs_TestCategory" runat="server" HeaderText="You must enter a valid value in the following fields:"></asp:ValidationSummary> 
            <br />
            <asp:DetailsView ID="dv_DLCentres" runat="server" AutoGenerateRows="False" 
                DataKeyNames="iID" Width="50%" GridLines="None" 
                OnItemInserting="dv_DLCentres_ItemInserting" 
                OnItemUpdating="dv_DLCentres_ItemUpdating" 
                OnModeChanging="dv_DLCentres_ModeChanging" 
                ondatabound="dv_DLCentres_DataBound">
               <Fields>
                   <asp:BoundField DataField="iID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                   <asp:TemplateField HeaderText="City">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlCity" Width="150px" runat="server"> 
                            </asp:DropDownList><asp:CompareValidator runat="server" ID="cvCity" ControlToValidate="ddlCity" ValueToCompare="0" Operator="NotEqual" SetFocusOnError="true" Type="string" ErrorMessage="City" Text="*"></asp:CompareValidator>  
                        </EditItemTemplate>
                        <InsertItemTemplate>
                           <asp:DropDownList ID="ddlCity" Width="150px" runat="server">                           
                           </asp:DropDownList><asp:CompareValidator runat="server" ID="cvCity" ControlToValidate="ddlCity" ValueToCompare="0" Operator="NotEqual" SetFocusOnError="true" Type="string" ErrorMessage="City" Text="*"></asp:CompareValidator>       
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCity" runat="server" Text='<%# Eval("strCity") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="Address" HeaderStyle-VerticalAlign="Top">
                        <EditItemTemplate>                          
                          <FCKeditorV2:FCKeditor ID="fckAddress" runat="server" BasePath="~/FCKeditor/"
                                Height="400px" width="550px" Value='<%# Eval("strAddress") %>'>
                            </FCKeditorV2:FCKeditor>
                        </EditItemTemplate>
                        <InsertItemTemplate>                          
                           <FCKeditorV2:FCKeditor ID="fckAddress" runat="server" BasePath="~/FCKeditor/"
                                Height="400px" width="550px" Value='<%# Eval("strAddress") %>'>
                            </FCKeditorV2:FCKeditor>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Literal ID="lblAddress" runat="server" Text='<%# Bind("strAddress") %>'>
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

