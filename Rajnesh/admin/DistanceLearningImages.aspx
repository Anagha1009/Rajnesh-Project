<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true" CodeFile="DistanceLearningImages.aspx.cs" Inherits="admin_DistanceLearningImages" %>

<%@ Register TagName="errorMssg" src="~/admin/errorUserControl.ascx" TagPrefix="yo"%>
<%@ Register TagName="infoMssg" src="~/admin/infoUserControl.ascx" TagPrefix="yo"%>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" Runat="Server">
<yo:errorMssg ID="error" runat="server" Visible="false" />
<yo:infoMssg ID="info" runat="server" Visible="false" />
<br />
<table width="90%" align="center">
    <tr>
        <td align="left">
          <asp:Label id="Label3" CssClass="font_title_text" runat="server" Text="D I S T A N C E&nbsp;&nbsp;&nbsp;&nbsp;L E A R N I N G&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
            <br />
            <hr />
        </td>
    </tr>
    <tr>
        <td align="center">
        <asp:GridView ID="grd_Images" runat="server" Width="100%" GridLines="None" 
                AllowPaging="True" AllowSorting="True" 
             AutoGenerateColumns="False" EmptyDataText="No Records Found" EmptyDataRowStyle-ForeColor="red" 
             EmptyDataRowStyle-HorizontalAlign="Center" 
                AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4"
              DataKeyNames="iID" PageSize="10" 
                onpageindexchanging="grd_Images_PageIndexChanging" 
                onrowdeleting="grd_Images_RowDeleting" 
                onselectedindexchanged="grd_Images_SelectedIndexChanged" 
                onsorting="grd_Images_Sorting" >
                <HeaderStyle HorizontalAlign="Center" />
                <Columns>
                   <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                      <ItemStyle HorizontalAlign="Center" Width="10%" />
                      <ItemTemplate>
                      <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                      </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="strTitle" HeaderText="Title" SortExpression="strTitle">
                        <ItemStyle Width="20%" HorizontalAlign="center"/>
                   </asp:BoundField>    
                  
                   <asp:TemplateField HeaderText="Image" SortExpression="iID">
                            <ItemTemplate>
                            <asp:Image ID="imgProduct" Width="100px" Height="70px" runat="server" 
                            ImageUrl='<%#"~/admin/RelatedImages/DistanceLearning/" +Eval("strThumbnail")%>' ></asp:Image>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="center" />
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
           <asp:Label id="Label1" CssClass="font_title_text" runat="server" Text="D I S T A N C E&nbsp;&nbsp;&nbsp;&nbsp;L E A R N I N G&nbsp;&nbsp;&nbsp;&nbsp;I M A G E&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
            <br />
            <hr />
            <br />
            <asp:ValidationSummary id="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:"></asp:ValidationSummary> 
            <br />
            <asp:DetailsView ID="dv_Images" runat="server" AutoGenerateRows="False" 
                DataKeyNames="iID" Width="50%" GridLines="None" 
                oniteminserting="dv_Images_ItemInserting" 
                onmodechanging="dv_Images_ModeChanging">
               <Fields>
                   <asp:BoundField DataField="iID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                   <asp:TemplateField HeaderText="Title">
                        <EditItemTemplate>
                          <asp:TextBox ID="txtImageTitle" runat="server" Text='<%# Bind("strTitle") %>'></asp:TextBox><asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtImageTitle" Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                           <asp:TextBox ID="txtImageTitle" runat="server" Text='<%# Bind("strTitle") %>'></asp:TextBox><asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtImageTitle" Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCategoryName" runat="server" Text='<%# Bind("strTitle") %>'></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField>   
                    
                    <asp:TemplateField HeaderStyle-VerticalAlign="Top" HeaderText="Thumbnail">
                        <EditItemTemplate>
                            <asp:Image id ="imgThumbnail" ImageUrl='<%#"~/admin/RelatedImages/DistanceLearning/" +Eval("strThumbnail")%>' ToolTip='<%# Bind("strThumbnail") %>' runat="server" Width="100px" Height="80px" />
                            <asp:HiddenField ID="hid_imgfile" Value='<%# Eval("strThumbnail") %>' runat="server" />
                            <asp:HiddenField runat="server" ID="hfId" Value='<%# Eval("iID") %>' />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Image id ="imgThumbnail" ImageUrl="~/admin/images/noimage.jpg" runat="server" Width="100px" Height="80px" />
                        </InsertItemTemplate>
                        <ItemTemplate>                        
                             <asp:Image id ="imgThumbnail" ImageUrl='<%#"~/admin/RelatedImages/DistanceLearning/" +Eval("strThumbnail")%>' runat="server" Width="100px" Height="80px" />
                             <asp:HiddenField runat="server" ID="hfId" Value='<%# Eval("iID") %>' />
                            <asp:Label runat="server" ID="lblImageName"></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField>    
                                         
                     <asp:TemplateField HeaderText="Upload&nbsp;Image" >  
                            <InsertItemTemplate>
                                <asp:FileUpload ID="fuThumbnailImage" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvThumbnailImage" runat="server" ControlToValidate="fuThumbnailImage" Display="Dynamic" ErrorMessage="Thumbnail Image" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>  
                            <EditItemTemplate>
                                <asp:FileUpload ID="fuThumbnailImage" runat="server" />                
                            </EditItemTemplate>                          
                        </asp:TemplateField>   
                        
                        <asp:TemplateField HeaderStyle-VerticalAlign="Top" HeaderText="Big Image">
                        <EditItemTemplate>
                            <asp:Image id ="imgBigImage" ImageUrl='<%#"~/admin/RelatedImages/DistanceLearning/" +Eval("strBigImage")%>' ToolTip='<%# Bind("strBigImage") %>' runat="server" Width="100px" Height="80px" />
                            <asp:HiddenField ID="hid_imgfile" Value='<%# Eval("strBigImage") %>' runat="server" />
                            <asp:HiddenField runat="server" ID="hfId" Value='<%# Eval("iID") %>' />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Image id ="imgBigImage" ImageUrl="~/admin/images/noimage.jpg" runat="server" Width="100px" Height="80px" />
                        </InsertItemTemplate>
                        <ItemTemplate>                        
                             <asp:Image id ="imgBigImage" ImageUrl='<%#"~/admin/RelatedImages/DistanceLearning/" +Eval("strBigImage")%>' runat="server" Width="100px" Height="80px" />
                             <asp:HiddenField runat="server" ID="hfId" Value='<%# Eval("iID") %>' />
                            <asp:Label runat="server" ID="lblImageName"></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField>   
                    
                     <asp:TemplateField HeaderText="Upload&nbsp;Image" >  
                            <InsertItemTemplate>
                                <asp:FileUpload ID="fuBigImage" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvBigImage" runat="server" ControlToValidate="fuBigImage" Display="Dynamic" ErrorMessage="Big Image" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>  
                            <EditItemTemplate>
                                <asp:FileUpload ID="fuBigImage" runat="server" />                
                            </EditItemTemplate>                          
                        </asp:TemplateField>   
                        
                                               
                    
                   <asp:CommandField ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
           </tr>
        </table>

</asp:Content>

