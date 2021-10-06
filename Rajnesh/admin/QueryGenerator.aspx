<%@ Page Title="Admin :: Query Generatory" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="QueryGenerator.aspx.cs" Inherits="admin_QueryGenerator"
    MaintainScrollPositionOnPostback="true" ValidateRequest="false" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Cp_Head" ContentPlaceHolderID="cp_head" runat="server">
    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>
    <style type="text/css">
        .myCSS
        {
            border: 1px solid #ccc;
            background-color: #efefef;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <br />
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <br />
    <table width="95%" border="0" align="center">
        <tr>
            <td align="left">
                <asp:Label ID="Label3" CssClass="font_title_text" runat="server" Text="Query Generatory List"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td width="90px">
                            Keywords :
                        </td>
                        <td width="290px">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="txtBox">
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
                <asp:GridView ID="grd_Query" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    PageSize="50" OnRowDeleting="grd_Query_RowDeleting" OnSelectedIndexChanged="grd_Query_SelectedIndexChanged"
                    OnPageIndexChanging="grd_Query_PageIndexChanging">
                    <HeaderStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strType" HeaderText="Type" SortExpression="strType">
                            <ItemStyle Width="25%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strTitle" HeaderText="Title" SortExpression="strTitle">
                            <ItemStyle Width="25%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Links">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='<%# "QueryLink.aspx?QueryID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" class="Icons" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Image" HeaderText="Edit" CausesValidation="false" SelectImageUrl="~/Admin/images/edit.jpg"
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
            <td>
                <asp:Label ID="Label1" CssClass="font_title_text" runat="server" Text="Query Generatory Details"></asp:Label>
                <br />
                <hr />
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dv_Query" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                    Width="95%" GridLines="None" CellPadding="3" CellSpacing="3" OnItemInserting="dv_Query_ItemInserting"
                    OnItemUpdating="dv_Query_ItemUpdating" OnModeChanging="dv_Query_ModeChanging"
                    OnDataBound="dv_Query_DataBound">
                    <Fields>
                        <asp:TemplateField HeaderText="Select" HeaderStyle-HorizontalAlign="Left">
                            <InsertItemTemplate>
                                <div style="padding-bottom: 5px">
                                    <asp:RadioButton ID="rd_University" runat="server" Text="University" GroupName="Query"
                                        AutoPostBack="True" OnCheckedChanged="rd_University_CheckedChanged" Checked="true" />&nbsp;&nbsp;
                                    <asp:RadioButton ID="rd_Institute" runat="server" Text="Colleges" GroupName="Query"
                                        AutoPostBack="True" OnCheckedChanged="rd_Institute_CheckedChanged" />&nbsp;&nbsp;
                                    <asp:RadioButton ID="rd_Schools" runat="server" Text="Schools" GroupName="Query"
                                        AutoPostBack="True" OnCheckedChanged="rd_Schools_CheckedChanged" />
                                    <asp:RadioButton ID="rd_Courses" runat="server" Text="Courses" GroupName="Query"
                                        AutoPostBack="True" OnCheckedChanged="rd_Courses_CheckedChanged" />
                                </div>
                                <div style="padding-bottom: 5px">
                                    <asp:DropDownList ID="ddl_Category" runat="server" OnSelectedIndexChanged="ddl_Category_SelectedIndexChanged"
                                        AutoPostBack="true" Visible="false">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <asp:DropDownList ID="ddl_City" runat="server" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </InsertItemTemplate>
                            <EditItemTemplate>
                                <div style="padding-bottom: 5px">
                                    <asp:RadioButton ID="rd_University" runat="server" Text="University" GroupName="Query"
                                        AutoPostBack="True" OnCheckedChanged="rd_University_CheckedChanged" />&nbsp;&nbsp;
                                    <asp:RadioButton ID="rd_Institute" runat="server" Text="Colleges" GroupName="Query"
                                        AutoPostBack="True" OnCheckedChanged="rd_Institute_CheckedChanged" />&nbsp;&nbsp;
                                    <asp:RadioButton ID="rd_Schools" runat="server" Text="Schools" GroupName="Query"
                                        AutoPostBack="True" OnCheckedChanged="rd_Schools_CheckedChanged" />
                                    <asp:RadioButton ID="rd_Courses" runat="server" Text="Courses" GroupName="Query"
                                        AutoPostBack="True" OnCheckedChanged="rd_Courses_CheckedChanged" />
                                </div>
                                <div style="padding-bottom: 5px">
                                    <asp:DropDownList ID="ddl_Category" runat="server" OnSelectedIndexChanged="ddl_Category_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <asp:DropDownList ID="ddl_City" runat="server" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblType" runat="server" Text='<%# Eval("strType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Title">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("strTitle") %>' CssClass="txtBox">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("strTitle") %>' CssClass="txtBox">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strTitle") %>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Youtube Title">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtYoutubeTitle" runat="server" Text='<%# Bind("strYoutubeTitle") %>' CssClass="txtBox">
                                </asp:TextBox>
                                
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtYoutubeTitle" runat="server" Text='<%# Bind("strYoutubeTitle") %>' CssClass="txtBox">
                                </asp:TextBox>
                                
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strYoutubeTitle")%>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField HeaderText="Youtube">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtYoutube" runat="server" Text='<%# Bind("strYoutube") %>' CssClass="txtBox">
                                </asp:TextBox>
                                
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtYoutube" runat="server" Text='<%# Bind("strYoutube") %>' CssClass="txtBox">
                                </asp:TextBox>
                                
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strYoutube")%>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Selection List">
                            <EditItemTemplate>
                                <asp:ListBox runat="server" ID="ListBox_Institute" Width="570px" Height="500px" SelectionMode="Multiple">
                                </asp:ListBox>
                                <asp:RequiredFieldValidator ID="rfvListBox" runat="server" ControlToValidate="ListBox_Institute"
                                    Display="Dynamic" ErrorMessage="Selection" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:ListBox runat="server" ID="ListBox_Institute" Width="570px" Height="500px" SelectionMode="Multiple">
                                </asp:ListBox>
                                <asp:RequiredFieldValidator ID="rfvListBox" runat="server" ControlToValidate="ListBox_Institute"
                                    Display="Dynamic" ErrorMessage="Selection" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="ckeditor" Text='<%# Bind("strDesc") %>'
                                    TextMode="MultiLine"></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="ckeditor" Text='<%# Bind("strDesc") %>'
                                    TextMode="MultiLine"></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strDesc")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Meta Title">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMetaTitle" runat="server" Text='<%# Bind("strMetaTitle") %>'
                                    Width="400px" TextMode="MultiLine" CssClass="txtArea">
                                </asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtMetaTitle" runat="server" Text='<%# Bind("strMetaTitle") %>'
                                    Width="400px" TextMode="MultiLine" CssClass="txtArea">
                                </asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strMetaTitle") %>'>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Meta Description">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMetaDesc" runat="server" Text='<%# Bind("strMetaDesc") %>' Width="400px"
                                    TextMode="MultiLine" CssClass="txtArea">
                                </asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtMetaDesc" runat="server" Text='<%# Bind("strMetaDesc") %>' Width="400px"
                                    TextMode="MultiLine" CssClass="txtArea">
                                </asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strMetaDesc") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Meta Keywords">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMetaKeys" runat="server" Text='<%# Bind("strMetakeys") %>' Width="400px"
                                    TextMode="MultiLine" CssClass="txtArea">
                                </asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtMetaKeys" runat="server" Text='<%# Bind("strMetakeys") %>' Width="400px"
                                    TextMode="MultiLine" CssClass="txtArea">
                                </asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strMetakeys")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
