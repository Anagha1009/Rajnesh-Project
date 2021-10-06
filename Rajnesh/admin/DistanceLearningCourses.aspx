<%@ Page Title="Admin :: Distance Learning Courses" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="DistanceLearningCourses.aspx.cs" Inherits="admin_DistanceLearningCourses" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <br />
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <br />
    <table width="100%" align="center">       
        <tr>
            <td align="left">
                <asp:Label ID="Label2" ForeColor="#ff6633" runat="server" Font-Bold="true" Text="Distance Learning Title : "></asp:Label>
                <asp:Label ID="lbl_Title" ForeColor="#ff6633" runat="server" Font-Bold="true"></asp:Label><br />
                <br />
                <asp:Label ID="Label3" CssClass="font_title_text" runat="server" Text="D I S T A N C E&nbsp;&nbsp;&nbsp;&nbsp;L E A R N I N G&nbsp;&nbsp;&nbsp;&nbsp;C O U R S E S"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="grd_DLearningCourses" runat="server" Width="100%" GridLines="None"
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    PageSize="10" OnRowDeleting="grd_DLearningCourses_RowDeleting" OnSelectedIndexChanged="grd_DLearningCourses_SelectedIndexChanged"
                    OnSorting="grd_DLearningCourses_Sorting" OnPageIndexChanging="grd_DLearningCourses_PageIndexChanging">
                    <HeaderStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strType" HeaderText="Type" SortExpression="strType">
                            <ItemStyle Width="30%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strName" HeaderText="Title" SortExpression="strName">
                            <ItemStyle Width="30%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Features">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hylink_Feature" NavigateUrl='<%# "DistanceLearningFeatures.aspx?ID="+Eval("iDistanceID") + "&CourseID=" + Eval("iID") %>'
                                    Text="Add/View"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Test Papers">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <a href='<%# "Testpapers.aspx?CourseID=" + Eval("iID") %>'>Add/View</a>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Exam Results">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <a href='<%# "ExamResults.aspx?CourseID=" + Eval("iID") %>'>Add/View</a>
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
    <table width="100%" align="center">
        <tr>
            <td>
                <asp:Label ID="Label1" CssClass="font_title_text" runat="server" Text="D I S T A N C E&nbsp;&nbsp;&nbsp;&nbsp;L E A R N I N G&nbsp;&nbsp;&nbsp;&nbsp;C O U R S E S&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
                <br />
                <hr />
                <br />
                <asp:ValidationSummary ID="vs_CareerIndustry" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dv_DLearningCourses" runat="server" AutoGenerateRows="False"
                    DataKeyNames="iID" Width="50%" GridLines="None" OnItemInserting="dv_DLearningCourses_ItemInserting"
                    OnItemUpdating="dv_DLearningCourses_ItemUpdating" OnModeChanging="dv_DLearningCourses_ModeChanging"
                    OnDataBound="dv_DLearningCourses_DataBound">
                    <Fields>
                        <asp:BoundField DataField="iID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Type">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlType" Width="180px" runat="server">
                                </asp:DropDownList>
                                <asp:CompareValidator runat="server" ID="cvType" ControlToValidate="ddlType" ValueToCompare="0"
                                    Operator="NotEqual" SetFocusOnError="true" Type="string" ErrorMessage="Type"
                                    Text="*"></asp:CompareValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="ddlType" Width="180px" runat="server">
                                </asp:DropDownList>
                                <asp:CompareValidator runat="server" ID="cvType" ControlToValidate="ddlType" ValueToCompare="0"
                                    Operator="NotEqual" SetFocusOnError="true" Type="string" ErrorMessage="Type"
                                    Text="*"></asp:CompareValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblType" runat="server" Text='<% #Eval("strType") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
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
