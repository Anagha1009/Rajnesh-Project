<%@ Page Title="Admin :: Institutes" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="Institutes.aspx.cs" Inherits="admin_Institutes"
    MaintainScrollPositionOnPostback="true" ValidateRequest="false" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="cpHead" ContentPlaceHolderID="cp_head" runat="Server">
    <link href="css/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="js/jquery.autocomplete.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtSearch").autocomplete("SearchBox.ashx", {
                width: 200,
                formatItem: function (data, i, n, value) {
                    return "<img style = 'width:50px;height:50px' src='../admin/Upload/Institutes/"
            + value.split("-")[2] + "'/> " + value.split("-")[1];
                },
                formatResult: function (data, value) {
                    return value.split("-")[1];
                }
            });
        });
    </script>
</asp:Content>
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
                <asp:GridView ID="grd_Institutes" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    CellPadding="1" CellSpacing="1" DataKeyNames="iID" CssClass="tableMain" OnRowDeleting="grd_Institutes_RowDeleting"
                    OnSelectedIndexChanged="grd_Institutes_SelectedIndexChanged" OnSorting="grd_Institutes_Sorting"
                    OnPageIndexChanging="grd_Institutes_PageIndexChanging" PageSize="10" OnRowCommand="grd_Records_RowCommand"
                    OnRowDataBound="grd_Records_RowDataBound">
                    <HeaderStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <img src='<%# "Upload/Institutes/" + Eval("strPhoto") %>' class="photo" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strTitle" HeaderText="Institute" SortExpression="strTitle">
                            <ItemStyle Width="40%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Category">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hylink_Category" NavigateUrl='<%# "InstituteCategoryList.aspx?InstID=" + Eval("iID") %>'
                                    Text="Add/View"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Courses">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='<%# "InstituteCourses.aspx?InstituteID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" style="border: 0px" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Photos">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='<%# "InstitutePhotos.aspx?InstituteID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" style="border: 0px" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Videos">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='<%# "InstituteVideos.aspx?InstituteID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" style="border: 0px" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="News">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='<%# "InstituteNews.aspx?InstituteID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" style="border: 0px" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ranks">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='<%# "CategoryRank.aspx?InstituteID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" style="border: 0px" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Exams">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='<%# "InstituteExams.aspx?InstituteID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" style="border: 0px" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reviews">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='<%# "Edu-Reviews.aspx?Type=Institute&TypeID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" style="border: 0px" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Featured">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="btnFeatured" CommandName="Featured" CommandArgument='<%# Eval("iID") %>'
                                    CausesValidation="false" />
                                <asp:HiddenField runat="server" ID="hfFeatured" Value='<%# Eval("bFeatured") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="HomeFeatured">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="btnHomeFeatured" CommandName="HomeFeatured" CommandArgument='<%# Eval("iID") %>'
                                    CausesValidation="false" />
                                <asp:HiddenField runat="server" ID="hfHomeFeatured" Value='<%# Eval("bHomeFeatured") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
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
                <asp:Label ID="Label1" CssClass="font_title_text" runat="server" Text="Hotel Details"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <div id="ScrollHere">
                </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dv_Institutes" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                    Width="100%" GridLines="None" CellPadding="3" CellSpacing="3" OnItemInserting="dv_Institutes_ItemInserting"
                    OnItemUpdating="dv_Institutes_ItemUpdating" OnModeChanging="dv_Institutes_ModeChanging"
                    OnDataBound="dv_Institutes_DataBound">
                    <Fields>
                        <asp:BoundField DataField="iID" HeaderText="ID" Visible="False" ReadOnly="True" />
                        <asp:TemplateField HeaderText="City">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_City" runat="server" CssClass="ddlBox">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddl_City"
                                    Display="Dynamic" ErrorMessage="City" SetFocusOnError="True" InitialValue="0">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="ddl_City" runat="server" CssClass="ddlBox">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddl_City"
                                    Display="Dynamic" ErrorMessage="City" SetFocusOnError="True" InitialValue="0">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCity" runat="server">
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
                        <asp:TemplateField HeaderText="Established In">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEstablishedIn" runat="server" Text='<%# Eval("strEstablishedIn") %>'
                                    CssClass="txtBox">
                                </asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtEstablishedIn" runat="server" Text='<%# Eval("strEstablishedIn") %>'
                                    CssClass="txtBox">
                                </asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strEstablishedIn")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Affiliated To">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtAffiliatedTo" runat="server" Text='<%# Eval("strAffiliatedTo") %>'
                                    CssClass="txtBox">
                                </asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtAffiliatedTo" runat="server" Text='<%# Eval("strAffiliatedTo") %>'
                                    CssClass="txtBox">
                                </asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strAffiliatedTo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Website">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtWebsite" runat="server" Text='<%# Eval("strWebsite") %>' CssClass="txtBox">
                                </asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtWebsite" runat="server" Text='<%# Eval("strWebsite") %>' CssClass="txtBox">
                                </asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strWebsite") %>
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
                        <asp:TemplateField HeaderText="Placements" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPlacements" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strPlacements") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtPlacements" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strPlacements") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strPlacements")%>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Facilities" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFacility" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strFacilities") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtFacility" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strFacilities") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strFacilities")%>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Admissions" HeaderStyle-VerticalAlign="Top">
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
                        <asp:TemplateField HeaderText="Contact Details" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtContactDetails" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strContactDetails") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtContactDetails" runat="server" CssClass="ckeditor" TextMode="MultiLine"
                                    Text='<%# Eval("strContactDetails") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("strContactDetails")%>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Upload Image" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                    <tr>
                                        <td width="50px" align="left" valign="top" style="padding-top: 15px">
                                            <asp:Image ID="img_Image" runat="server" ImageUrl='<%# "Upload/Institutes/" + Eval("strPhoto") %>'
                                                Height="40px" BorderWidth="0px" />
                                        </td>
                                        <td>
                                            <div class="_Browse">
                                                <asp:FileUpload ID="fu_Image" runat="server" CssClass="_file" /><div class="_upload">
                                                </div>
                                                <asp:HiddenField ID="hfImage" runat="server" Value='<%# Eval("strPhoto") %>' />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <div class="_Browse">
                                    <asp:FileUpload ID="fu_Image" runat="server" CssClass="_file" /><div class="_upload">
                                    </div>
                                </div>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="img_Image" runat="server" ImageUrl='<%# "Upload/Institutes/" + Eval("strPhoto") %>'
                                    Height="70px" BorderWidth="0px" />
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
