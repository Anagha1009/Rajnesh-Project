<%@ Page Title="Admin :: Distance Learning" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="DistanceUniversity.aspx.cs" Inherits="admin_DistanceLearning_university" %>

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
            <td align="left" colspan="3">
                <asp:Label ID="Label3" CssClass="font_title_text" runat="server" Text="D I S T A N C E&nbsp;&nbsp;&nbsp;&nbsp;L E A R N I N G&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left" width="15%">
                Institute Title
            </td>
            <td align="left" width="5%">
                :
            </td>
            <td align="left" width="70%">
                <asp:TextBox ID="txtInstituteTitle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" width="15%">
                Category
            </td>
            <td align="left" width="5%">
                :
            </td>
            <td align="left" width="70%">
                <asp:DropDownList ID="ddlCategory" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" width="15%">
                Location
            </td>
            <td align="left" width="5%">
                :
            </td>
            <td align="left" width="70%">
                <asp:DropDownList ID="ddl_City" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                    CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="grd_DLearning" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    PageSize="10" OnRowDeleting="grd_DLearning_RowDeleting" OnSelectedIndexChanged="grd_DLearning_SelectedIndexChanged"
                    OnSorting="grd_DLearning_Sorting" OnPageIndexChanging="grd_DLearning_PageIndexChanging"
                    OnRowCommand="grd_DLearning_RowCommand" OnRowDataBound="grd_DLearning_RowDataBound">
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
                            <ItemStyle Width="20%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Image" SortExpression="iID">
                            <ItemTemplate>
                                <asp:Image ID="imgProduct" Width="100px" Height="70px" runat="server" ImageUrl='<%#"~/admin/Upload/DistanceLearning/" +Eval("strImage")%>'>
                                </asp:Image>
                                <asp:HiddenField runat="server" ID="hf_ImageName" Value='<% #Eval("strImage") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Courses">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hylink_Courses" NavigateUrl='<%# "DistanceLearningCourses.aspx?ID="+Eval("iID") %>'
                                    Text="Add/View"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hylink_Category" NavigateUrl='<%# "DistanceLearningCategory.aspx?ID="+Eval("iID") %>'
                                    Text="Add/View"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Centers">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hylink_Centers" NavigateUrl='<%# "DistanceLearningCenters.aspx?DLID="+Eval("iID") %>'
                                    Text="Add/View"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Images">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hylink_Images" NavigateUrl='<%# "DistanceLearningImages.aspx?DLID="+Eval("iID") %>'
                                    Text="Add/View"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Downloads">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hylink_Downloads" NavigateUrl='<%# "DistanceLearningDownloads.aspx?DLID="+Eval("iID") %>'
                                    Text="Add/View"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reviews">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='<%# "Edu-Reviews.aspx?Type=DistanceUniversity&TypeID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" style="border: 0px" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Featured">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="btnFeatured" CommandName="Featured" CommandArgument='<%# Bind("iId") %>'
                                    CausesValidation="false" />
                                <asp:HiddenField runat="server" ID="hfFeatured" Value='<%#Bind("bIsFeatured") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="StudyCenters">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <a href='<%# "StudyCenters.aspx?UniversityID=" + Eval("iID") %>'>Add/View</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Notifications">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <a href='<%# "Notifications.aspx?UniversityID=" + Eval("iID") %>'>Add/View</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Exams">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <a href='<%# "Exams.aspx?UniversityID=" + Eval("iID") %>'>Add/View</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Faculty">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <a href='<%# "Faculty.aspx?UniversityID=" + Eval("iID") %>'>Add/View</a>
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
                <asp:Label ID="Label1" CssClass="font_title_text" runat="server" Text="D I S T A N C E&nbsp;&nbsp;&nbsp;&nbsp;L E A R N I N G&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
                <br />
                <hr />
                <br />
                <asp:ValidationSummary ID="vs_CareerIndustry" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dv_DLearning" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                    Width="50%" GridLines="None" OnItemInserting="dv_DLearning_ItemInserting" OnItemUpdating="dv_DLearning_ItemUpdating"
                    OnModeChanging="dv_DLearning_ModeChanging" OnDataBound="dv_DLearning_DataBound">
                    <Fields>
                        <asp:BoundField DataField="iID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Title">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("strName") %>'></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Title"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
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
                                <FCKeditorV2:FCKeditor ID="FCKDesc" BasePath="~/FCKeditor/" Value='<%# Bind("strDesc") %>'
                                    Height="400" runat="server" Width="550" />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <FCKeditorV2:FCKeditor ID="FCKDesc" BasePath="~/FCKeditor/" Value='<%# Bind("strDesc") %>'
                                    Height="400" runat="server" Width="550" />
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Literal ID="lblDescription" runat="server" Text='<%# Bind("strDesc") %>'>
                                </asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Admissions" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <FCKeditorV2:FCKeditor ID="FCKAdmissions" BasePath="~/FCKeditor/" Value='<%# Bind("strAdmissions") %>'
                                    Height="400" runat="server" Width="550" />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <FCKeditorV2:FCKeditor ID="FCKAdmissions" BasePath="~/FCKeditor/" Value='<%# Bind("strAdmissions") %>'
                                    Height="400" runat="server" Width="550" />
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Literal ID="lblAdmissions" runat="server" Text='<%# Bind("strAdmissions") %>'>
                                </asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Exams" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <FCKeditorV2:FCKeditor ID="FCKExams" BasePath="~/FCKeditor/" Value='<%# Bind("strExamDetails") %>'
                                    Height="400" runat="server" Width="550" />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <FCKeditorV2:FCKeditor ID="FCKExams" BasePath="~/FCKeditor/" Value='<%# Bind("strExamDetails") %>'
                                    Height="400" runat="server" Width="550" />
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strExamDetails") %>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Results" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <FCKeditorV2:FCKeditor ID="FCKResults" BasePath="~/FCKeditor/" Value='<%# Bind("strResults") %>'
                                    Height="400" runat="server" Width="550" />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <FCKeditorV2:FCKeditor ID="FCKResults" BasePath="~/FCKeditor/" Value='<%# Bind("strResults") %>'
                                    Height="400" runat="server" Width="550" />
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Literal ID="lblResults" runat="server" Text='<%# Bind("strResults") %>'>
                                </asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Current&nbsp;Image" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:Image runat="server" ID="imgLogo" ImageUrl='<%#"~/admin/Upload/DistanceLearning/" +Eval("strImage")%>'
                                    Width="100px" Height="80px" />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:Image runat="server" ID="imgLogo" ImageUrl="~/admin/images/noImage.jpg" Width="100px"
                                    Height="80px" />
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Image runat="server" ID="imgLogo" ImageUrl='<%#"~/admin/Upload/DistanceLearning/" +Eval("strImage")%>'
                                    Width="100px" Height="80px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Logo">
                            <EditItemTemplate>
                                <asp:FileUpload runat="server" ID="fu_Logo" />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:FileUpload runat="server" ID="fu_Logo" />
                            </InsertItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("strEmail") %>'></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                        ID="revEmail" runat="server" ErrorMessage="Invalid E-mail ID" ControlToValidate="txtEmail"
                                        Display="Dynamic" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("strEmail") %>'></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Invalid E-mail ID"
                                    ControlToValidate="txtEmail" Display="Dynamic" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("strEmail") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Website">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtWebsite" runat="server" Text='<%# Bind("strWebsite") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtWebsite" runat="server" Text='<%# Bind("strWebsite") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblWebsite" runat="server" Text='<%# Bind("strWebsite") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Featured" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkFeatured" runat="server" Checked='<% #Eval("bIsFeatured") %>' />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:CheckBox ID="chkFeatured" runat="server" />
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblFeatured" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
