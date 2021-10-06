<%@ Page Title="Admin :: University Courses" Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true" CodeFile="UniversityCourses.aspx.cs" Inherits="admin_UniversityCourses" %>
<%@ Register TagName="errorMssg" src="~/admin/errorUserControl.ascx" TagPrefix="yo"%>
<%@ Register TagName="infoMssg" src="~/admin/infoUserControl.ascx" TagPrefix="yo"%>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" Runat="Server">
<br />
<yo:errorMssg ID="error" runat="server" Visible="false" />
<yo:infoMssg ID="info" runat="server" Visible="false" />
<br />
<table width="90%" align="center">
    <tr>
        <td colspan="3">
            <asp:Label id="Label3" CssClass="font_title_text" runat="server" Text="U N I V E R S I T Y&nbsp;&nbsp;&nbsp;&nbsp;C O U R S E&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
            <hr />
        </td>
   </tr>
    <tr>
        <td align="center" colspan="3">
            <asp:GridView ID="grd_CourseList" runat="server" Width="100%" GridLines="None" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            EmptyDataText="No Records Found" EmptyDataRowStyle-ForeColor="red" 
            EmptyDataRowStyle-HorizontalAlign="Center" AlternatingRowStyle-BackColor="#F7F7F7" 
            CellPadding="4" CellSpacing="4" DataKeyNames="iCourseID" PageSize="10" 
            OnSelectedIndexChanged="grd_CourseList_SelectedIndexChanged"
            OnRowDeleting="grd_CourseList_RowDeleting"
            OnSorting="grd_InstFeature_Sorting"
            OnPageIndexChanging="grd_InstFeature_PageIndexChanging">
                <HeaderStyle HorizontalAlign="Center" />
                <Columns>
                   <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                      <ItemStyle HorizontalAlign="Center" Width="10%" />
                      <ItemTemplate>
                      <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'>
                      </asp:Label>
                      </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Title" SortExpression="strCourseName">
                      <ItemStyle HorizontalAlign="Center" Width="20%" />
                      <ItemTemplate>
                      <%# ((int)Eval("strCourseName").ToString().Length) > 25 ? Eval("strCourseName").ToString().Substring(0, 25) + "..." : Eval("strCourseName")%>
                      </ItemTemplate>
                   </asp:TemplateField>
                
                   <asp:CommandField ButtonType="Image" HeaderText="Edit" 
                   SelectImageUrl="~/Admin/images/edit.jpg" ShowSelectButton="True">
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
<table width="90%" align="center">   
    <tr>
        <td>
           <asp:Label id="Label1" CssClass="font_title_text" runat="server" Text="U N I V E R S I T Y&nbsp;&nbsp;&nbsp;&nbsp;C O U R S E&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
            <hr />
            <asp:ValidationSummary id="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:"></asp:ValidationSummary> 
            <br />
            <asp:DetailsView ID="dv_CourseList" runat="server" AutoGenerateRows="False" 
            DataKeyNames="iCourseID" Width="80%" GridLines="None" CellPadding="2"
            OnItemInserting="dv_CourseList_ItemInserting"
            OnModeChanging="dv_CourseList_ModeChanging"
            OnItemUpdating="dv_CourseList_ItemUpdating">
               <Fields>
                   <asp:BoundField DataField="iCourseID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                   <asp:TemplateField HeaderText="Course Name">
                        <EditItemTemplate>
                          <asp:TextBox ID="txtCourseTitle" runat="server" Text='<%# Bind("strCourseName") %>'>
                          </asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvCourseTitle" runat="server" 
                          ControlToValidate="txtCourseTitle" Display="Dynamic" 
                          ErrorMessage="Course Name" SetFocusOnError="True">*
                          </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                           <asp:TextBox ID="txtCourseTitle" runat="server" Text='<%# Bind("strCourseName") %>'></asp:TextBox><asp:RequiredFieldValidator ID="rfvCourseTitle" runat="server" ControlToValidate="txtCourseTitle" Display="Dynamic" ErrorMessage="Course Name" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCourseTitle" runat="server" Text='<%# Bind("strCourseName") %>'></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="FileName">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFileName" Width="180px" runat="server" Text='<%# Bind("strFileName") %>'></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfvFileName" runat="server" ControlToValidate="txtFileName"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator><asp:HiddenField ID="hfFile" runat="server" Value='<%# Eval("strFileName") %>' />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtFileName" Width="180px" runat="server" Text='<%# Bind("strFileName") %>'></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfvFileName" runat="server" ControlToValidate="txtFileName"
                                    Display="Dynamic" ErrorMessage="FileName" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("strFileName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField> 
                    
                   <asp:TemplateField HeaderText="Course Details" HeaderStyle-VerticalAlign="Top">
                        <EditItemTemplate>
                            <FCKeditorV2:FCKeditor ID="FckCourseDetails" runat="server" BasePath="~/FCKeditor/"
                                Height="400px" width="600px" Value='<%# Eval("strCourseDetails") %>'>
                            </FCKeditorV2:FCKeditor>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <FCKeditorV2:FCKeditor ID="FckCourseDetails" runat="server" BasePath="~/FCKeditor/"
                                Height="400px" width="600px" Value='<%# Eval("strCourseDetails") %>'>
                            </FCKeditorV2:FCKeditor>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCourseDetails" runat="server" 
                            Text='<%# Eval("strCourseDetails") %>'></asp:Label>
                        </ItemTemplate>
                   </asp:TemplateField>
                   
                   <%--*****--%>
                        
                        
                        <asp:TemplateField HeaderText="Header1">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtheader1" Height="81px" 
           runat="server" Width="400px" TextMode="MultiLine" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="verdana" Text='<%# Bind("strHeader1") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtheader1" Height="81px" 
           runat="server" Width="400px" TextMode="MultiLine" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="verdana" Text='<%# Bind("strHeader1") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblHeader1" runat="server" Text='<%# Bind("strHeader1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Header2">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtheader2" Height="81px" 
           runat="server" Width="400px" TextMode="MultiLine" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="verdana" Text='<%# Bind("strHeader2") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtheader2" Height="81px" 
           runat="server" Width="400px" TextMode="MultiLine" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="verdana" Text='<%# Bind("strHeader2") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblHeader2" runat="server" Text='<%# Bind("strHeader2") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Header3">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtheader3" Height="81px" 
           runat="server" Width="400px" TextMode="MultiLine" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="verdana" Text='<%# Bind("strHeader3") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtheader3" Height="81px" 
           runat="server" Width="400px" TextMode="MultiLine" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="verdana" Text='<%# Bind("strHeader3") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblHeader3" runat="server" Text='<%# Bind("strHeader3") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        
                        <asp:TemplateField HeaderText="Meta Title">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMetaTitle" Height="81px" 
           runat="server" Width="400px" TextMode="MultiLine" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="verdana" Text='<%# Bind("strMetaTitle") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtMetaTitle" Height="81px" 
           runat="server" Width="400px" TextMode="MultiLine" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="verdana" Text='<%# Bind("strMetaTitle") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblMetaTitle" runat="server" Text='<%# Bind("strMetaTitle") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Meta Description">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMetaDesc" Height="81px" 
           runat="server" Width="400px" TextMode="MultiLine" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="verdana" Text='<%# Bind("strMetaDesc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtMetaDesc" Height="81px" 
           runat="server" Width="400px" TextMode="MultiLine" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="verdana" Text='<%# Bind("strMetaDesc") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblMetaDesc" runat="server" Text='<%# Bind("strMetaDesc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Meta Keywords">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMetaKeys" Height="81px" 
           runat="server" Width="400px" TextMode="MultiLine" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="verdana" Text='<%# Bind("strMetaKeywords") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtMetaKeys" Height="81px" 
           runat="server" Width="400px" TextMode="MultiLine" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="verdana" Text='<%# Bind("strMetaKeywords") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblMetaKeys" runat="server" Text='<%# Bind("strMetaKeywords") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Serach Keywords">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSearch" Height="81px" 
           runat="server" Width="400px" TextMode="MultiLine" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="verdana" Text='<%# Bind("strKeywords") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtSearch" Height="81px" 
           runat="server" Width="400px" TextMode="MultiLine" BackColor="#EFEFFF" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="verdana" Text='<%# Bind("strKeywords") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSearch" runat="server" Text='<%# Bind("strKeywords") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        
                        <%--*****--%>
                   
                   
                   <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
           </tr>
        </table>
</asp:Content>