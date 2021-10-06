<%@ Page Title="Admin :: Category" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="admin_Category"
    MaintainScrollPositionOnPostback="true" ValidateRequest="false" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_head" runat="Server">
    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <table width="95%" border="0" align="center">
        <tr>
            <td align="left" colspan="3" class="_heading">
                <asp:Label ID="Label2" CssClass="font_title_text" runat="server" Text="Search"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" class="arial-black">
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
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="grd_Category" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    OnRowDeleting="grd_Category_RowDeleting" OnSelectedIndexChanged="grd_Category_SelectedIndexChanged"
                    OnSorting="grd_Category_Sorting" OnPageIndexChanging="grd_Category_PageIndexChanging"
                    PageSize="10" OnRowCommand="grd_Category_RowCommand" OnRowDataBound="grd_Category_RowDataBound">
                    <HeaderStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="OrderNo">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <%# Eval("iOrderNo") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Small Image">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <img src='<%# "Upload/Category/" + Eval("strSmallImage") %>' Title="" class="photo" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="medium Image">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <img src='<%# "Upload/Category/" + Eval("strMediumImage") %>' Title="" class="photo" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Big Image">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <img src='<%# "Upload/Category/" + Eval("strBigImage") %>' Title="" class="photo" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="strTitle" HeaderText="Category" SortExpression="strTitle">
                            <ItemStyle Width="40%" HorizontalAlign="center" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Add/View Links">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='<%# "CategoryLinks.aspx?CategoryID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" style="border: 0px" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Show Home">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="btnFeatured" CommandName="Featured" CommandArgument='<%# Eval("iID") %>'
                                    CausesValidation="false" />
                                <asp:HiddenField runat="server" ID="hfFeatured" Value='<%# Eval("bShowHome") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Image" HeaderText="Edit" CausesValidation="false" SelectImageUrl="~/Admin/images/edit.png"
                            ControlStyle-CssClass="_edit" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    ImageUrl="~/Admin/images/cross.gif" BackColor="Transparent" OnClientClick='return confirm("Are you sure you want to delete this entry?");' />
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
                <asp:Label ID="Label1" CssClass="font_title_text" runat="server" Text="Category Details"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <div id="ScrollHere">
                </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dv_Category" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                    Width="95%" GridLines="None" CellPadding="3" CellSpacing="3" OnItemInserting="dv_Category_ItemInserting"
                    OnItemUpdating="dv_Category_ItemUpdating" OnModeChanging="dv_Category_ModeChanging">
                    <Fields>
                        <asp:BoundField DataField="iID" HeaderText="ID" Visible="False" ReadOnly="True" />
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
                                <%# Eval("strTitle") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Url">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtUrl" runat="server" Text='<%# Eval("strUrl") %>' CssClass="txtBox">
                                </asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtUrl" runat="server" Text='<%# Eval("strUrl") %>' CssClass="txtBox">
                                </asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strUrl")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Order No">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtOrderNo" runat="server" Text='<%# Eval("iOrderNo") %>' CssClass="txtBox">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvOrderNo" runat="server" ControlToValidate="txtOrderNo"
                                    Display="Dynamic" ErrorMessage="Order No" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtOrderNo" runat="server" Text='<%# Eval("iOrderNo") %>' CssClass="txtBox">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvOrderNo" runat="server" ControlToValidate="txtOrderNo"
                                    Display="Dynamic" ErrorMessage="Order No" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("iOrderNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Title Color Code">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTitleColor" runat="server" Text='<%# Eval("strTitleColorCode") %>' CssClass="txtBox">
                                </asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtTitleColor" runat="server" Text='<%# Eval("strTitleColorCode") %>' CssClass="txtBox">
                                </asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strTitleColorCode") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Box Color Code">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtBoxColor" runat="server" Text='<%# Eval("strContentColorCode") %>' CssClass="txtBox">
                                </asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtBoxColor" runat="server" Text='<%# Eval("strContentColorCode") %>' CssClass="txtBox">
                                </asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strContentColorCode") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Short Description" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtShortDesc" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strShortDesc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtShortDesc" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strShortDesc") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strShortDesc") %>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Long Description" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtLongDesc" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strLongDesc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtLongDesc" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strLongDesc") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strLongDesc") %>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Small Image" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                    <tr>
                                        <td width="50px" align="left" valign="top" style="padding-top: 15px">
                                            <asp:Image ID="img_SmallImage" runat="server" ImageUrl='<%# "Upload/Category/" + Eval("strSmallImage") %>'
                                                Height="40px" BorderWidth="0px" />
                                        </td>
                                        <td align="left">
                                            <asp:FileUpload ID="fu_SmallImage" runat="server"/>
                                        </td>
                                    </tr>
                                </table>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:FileUpload ID="fu_SmallImage" runat="server"/>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="img_SmallImage" runat="server" ImageUrl='<%# "Upload/Category/" + Eval("strSmallImage") %>'
                                    Height="70px" BorderWidth="0px" />
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Medium Image" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                    <tr>
                                        <td width="50px" align="left" valign="top" style="padding-top: 15px">
                                            <asp:Image ID="img_MediumImage" runat="server" ImageUrl='<%# "Upload/Category/" + Eval("strMediumImage") %>'
                                                Height="40px" BorderWidth="0px" />
                                        </td>
                                        <td align="left">
                                            <asp:FileUpload ID="fu_MediumImage" runat="server"/>
                                        </td>
                                    </tr>
                                </table>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:FileUpload ID="fu_MediumImage" runat="server"/>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="img_MediumImage" runat="server" ImageUrl='<%# "Upload/Category/" + Eval("strMediumImage") %>'
                                    Height="70px" BorderWidth="0px" />
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Big Image" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                    <tr>
                                        <td width="50px" align="left" valign="top" style="padding-top: 15px">
                                            <asp:Image ID="img_BigImage" runat="server" ImageUrl='<%# "Upload/Category/" + Eval("strBigImage") %>'
                                                Height="40px" BorderWidth="0px" />
                                        </td>
                                        <td align="left">
                                            <asp:FileUpload ID="fu_BigImage" runat="server"/>
                                        </td>
                                    </tr>
                                </table>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:FileUpload ID="fu_BigImage" runat="server"/>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="img_BigImage" runat="server" ImageUrl='<%# "Upload/Category/" + Eval("strBigImage") %>'
                                    Height="70px" BorderWidth="0px" />
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" ControlStyle-CssClass="btn" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
