<%@ Page Title="Admin :: Entrance Exams" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="EntranceExams.aspx.cs" Inherits="admin_Entrance"
    MaintainScrollPositionOnPostback="true" ValidateRequest="false" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <table width="95%" border="0" align="center">
        <tr>
            <td align="left" class="arial-black">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td>
                            Keyword
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="290px">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="txtBox" Height="18px">
                            </asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:ImageButton ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                CausesValidation="false" ImageUrl="~/admin/images/Search.png" BackColor="White" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:GridView ID="grd_Schools" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    CellPadding="1" CellSpacing="1" DataKeyNames="iID" CssClass="tableMain" OnRowDeleting="grd_Schools_RowDeleting"
                    OnSelectedIndexChanged="grd_Schools_SelectedIndexChanged" OnSorting="grd_Schools_Sorting"
                    OnPageIndexChanging="grd_Schools_PageIndexChanging" PageSize="25">
                    <HeaderStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strTitle" HeaderText="Exam" SortExpression="strTitle">
                            <ItemStyle Width="40%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Institutes">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                                <a href='<%# "EntranceExamColleges.aspx?ExamID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" style="border: 0px" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Image" HeaderText="Edit" CausesValidation="false" SelectImageUrl="~/Admin/images/edit_1.png"
                            ControlStyle-CssClass="_edit" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    ImageUrl="~/Admin/images/delete.png" BackColor="Transparent" OnClientClick='return confirm("Are you sure you want to delete this entry?");' />
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
    <table width="95%" align="center">
        <tr>
            <td class="_heading">
                <asp:Label ID="Label1" CssClass="font_title_text" runat="server" Text="Entrance Exams Details"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <div id="ScrollHere">
                </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dv_Schools" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                    Width="85%" GridLines="None" CellPadding="3" CellSpacing="3" OnItemInserting="dv_Schools_ItemInserting"
                    OnItemUpdating="dv_Schools_ItemUpdating" OnModeChanging="dv_Schools_ModeChanging"
                    OnDataBound="dv_Schools_DataBound">
                    <Fields>
                        <asp:BoundField DataField="iID" HeaderText="ID" Visible="False" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Category">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_Category" runat="server" CssClass="ddlBox">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddl_Category"
                                    Display="Dynamic" ErrorMessage="Category" SetFocusOnError="True" InitialValue="0">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="ddl_Category" runat="server" CssClass="ddlBox">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddl_Category"
                                    Display="Dynamic" ErrorMessage="Category" SetFocusOnError="True" InitialValue="0">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCategory" runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Title">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Eval("strTitle") %>' CssClass="txtBox">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Eval("strTitle") %>' CssClass="txtBox">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("strTitle") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strDesc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strDesc") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strDesc") %>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Registration" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtAdmissions" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strAdmissions") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtAdmissions" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strAdmissions") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strAdmissions")%>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dates" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDates" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strDates") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtDates" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strDates") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strDates")%>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Syllabus" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSyllabus" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strSyllabus") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtSyllabus" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strSyllabus") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strSyllabus")%>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Paper Pattern" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPaperPattern" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strPaperPatterns") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtPaperPattern" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strPaperPatterns") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strPaperPatterns")%>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Preparation" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPreparation" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strPreparation") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtPreparation" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strPreparation") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strPreparation")%>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Notifications" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNotifications" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strNotifications") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtNotifications" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strNotifications") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strNotifications")%>
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
