<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true" CodeFile="DistanceLearningDownloads.aspx.cs" Inherits="admin_DistanceLearningDownloads" %>

<%@ Register TagName="errorMssg" src="~/admin/errorUserControl.ascx" TagPrefix="yo"%>
<%@ Register TagName="infoMssg" src="~/admin/infoUserControl.ascx" TagPrefix="yo"%>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" Runat="Server">
<yo:errorMssg ID="error" runat="server" Visible="false" />
<yo:infoMssg ID="info" runat="server" Visible="false" />
<br />
<table width="90%" align="center">
    <tr>
        <td align="left">
          <asp:Label id="Label3" CssClass="font_title_text" runat="server" Text="D I S T A N C E&nbsp;&nbsp;&nbsp;&nbsp;L E A R N I N G&nbsp;&nbsp;&nbsp;&nbsp;D O W N L O A D S&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
            <br />
            <hr />
        </td>
    </tr>
    <tr>
        <td align="center">
        <asp:GridView ID="grd_Downloads" runat="server" Width="100%" GridLines="None" 
                AllowPaging="True" AllowSorting="True" 
             AutoGenerateColumns="False" EmptyDataText="No Records Found" EmptyDataRowStyle-ForeColor="red" 
             EmptyDataRowStyle-HorizontalAlign="Center" 
                AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4"
              DataKeyNames="iID" PageSize="10" 
                onpageindexchanging="grd_Downloads_PageIndexChanging" 
                onrowdeleting="grd_Downloads_RowDeleting" 
                onselectedindexchanged="grd_Downloads_SelectedIndexChanged" 
                onsorting="grd_Downloads_Sorting" >
                <HeaderStyle HorizontalAlign="Center" />
                <Columns>
                   <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                      <ItemStyle HorizontalAlign="Center" Width="5%" />
                      <ItemTemplate>
                      <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                      </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="strTitle" HeaderText="Title" SortExpression="strTitle">
                        <ItemStyle Width="20%" HorizontalAlign="center"/>
                   </asp:BoundField>    
                   
                   <asp:TemplateField HeaderText="File Name">
                      <ItemStyle HorizontalAlign="Center" Width="30%" />
                      <ItemTemplate>
                      <asp:Label runat="server" ID="lblFileName" Text='<%# Eval("strFileName").ToString().Substring(19) %>'></asp:Label>
                      </ItemTemplate>
                   </asp:TemplateField> 
                  
                                                      
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
<table width="90%" align="center">   
    <tr>
        <td>
           <asp:Label id="Label1" CssClass="font_title_text" runat="server" Text="D I S T A N C E&nbsp;&nbsp;&nbsp;&nbsp;L E A R N I N G&nbsp;&nbsp;&nbsp;&nbsp;D O W N L O A D S&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
            <br />
            <hr />
            <br />
            <asp:ValidationSummary id="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:"></asp:ValidationSummary> 
            <br />
            <asp:DetailsView ID="dv_Downloads" runat="server" AutoGenerateRows="False" 
                DataKeyNames="iID" Width="50%" GridLines="None" 
                oniteminserting="dv_Downloads_ItemInserting" 
                onmodechanging="dv_Downloads_ModeChanging" >
               <Fields>
                   <asp:BoundField DataField="iID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                   <asp:TemplateField HeaderText="Title">
                        <EditItemTemplate>
                          <asp:TextBox ID="txtFileTitle" runat="server" Text='<%# Bind("strTitle") %>'></asp:TextBox><asp:RequiredFieldValidator ID="rfvFileTitle" runat="server" ControlToValidate="txtFileTitle" Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                           <asp:TextBox ID="txtFileTitle" runat="server" Text='<%# Bind("strTitle") %>'></asp:TextBox><asp:RequiredFieldValidator ID="rfvFileTitle" runat="server" ControlToValidate="txtFileTitle" Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("strTitle") %>'></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField>   
                    
                   
                                         
                     <asp:TemplateField HeaderText="Upload&nbsp;File" >  
                            <InsertItemTemplate>
                                <asp:FileUpload ID="fuFile" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvFile" runat="server" ControlToValidate="fuFile" Display="Dynamic" ErrorMessage="File" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>  
                            <EditItemTemplate>
                                <asp:FileUpload ID="fuFile" runat="server" />                
                            </EditItemTemplate>                          
                        </asp:TemplateField>                                                                                                                                                                                   
                   <asp:CommandField ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
           </tr>
        </table>
</asp:Content>

