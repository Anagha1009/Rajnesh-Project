<%@ Page Title="Control Panel | University" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="University.aspx.cs" Inherits="admin_University"
    MaintainScrollPositionOnPostback="true" ValidateRequest="false" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <table width="95%" border="0" align="center">
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
                <asp:GridView ID="grd_Records" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    CssClass="tableMain" CellPadding="1" CellSpacing="1" DataKeyNames="iID" OnRowDeleting="grd_Records_RowDeleting"
                    OnSelectedIndexChanged="grd_Records_SelectedIndexChanged" OnSorting="grd_Records_Sorting"
                    OnPageIndexChanging="grd_Records_PageIndexChanging" PageSize="25">
                    <HeaderStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Photo">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <img src='<%# "../files/University/" + Eval("strLogo") %>' alt="" class="photo" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strTitle" HeaderText="Title" SortExpression="strTitle">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Courses">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='<%# "Courses.aspx?UniversityID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" class="Icons" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Photos">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='<%# "UniversityPhotos.aspx?UniversityID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" class="Icons" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Videos">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='<%# "UniversityVideos.aspx?UniversityID=" + Eval("iID") %>'>
                                    <img src="images/add.png" alt="" class="Icons" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Image" HeaderText="Edit" CausesValidation="false" SelectImageUrl="~/admin/images/edit_1.png"
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
            <td align="left" class="font_title_text">
                University Details
            </td>
        </tr>
        <tr>
            <td>
                <div id="ScrollHere">
                </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dv_Records" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                    Width="95%" GridLines="None" CellPadding="3" CellSpacing="3" OnItemInserting="dv_Records_ItemInserting"
                    OnItemUpdating="dv_Records_ItemUpdating" OnModeChanging="dv_Records_ModeChanging">
                    <Fields>
                        <asp:TemplateField ShowHeader="false">
                            <InsertItemTemplate>
                                <table width="100%" cellpadding="3px" cellspacing="3px" border="0px">
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Title
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtTitle" runat="server" CssClass="txtbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Details
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            EstablishedIn
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtEstablishedIn" runat="server" CssClass="txtbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            AffiliatedTo
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtAffiliatedTo" runat="server" CssClass="txtbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Admissions
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtAdmissions" runat="server" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Infraucture
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtInfraucture" runat="server" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Placements
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPlacements" runat="server" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Ranking
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRanking" runat="server" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            ContactDetails
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtContactDetails" runat="server" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Email
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txtbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Website
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtWebsite" runat="server" CssClass="txtbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Logo
                                        </td>
                                        <td align="left">
                                            <asp:FileUpload ID="fu_Logo" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </InsertItemTemplate>
                            <EditItemTemplate>
                                <table width="100%" cellpadding="3px" cellspacing="3px" border="0px">
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Title
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtTitle" runat="server" CssClass="txtbox" Text='<%# Eval("strTitle") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Details
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" CssClass="ckeditor"
                                                Text='<%# Eval("strDetails") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            EstablishedIn
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtEstablishedIn" runat="server" CssClass="txtbox" Text='<%# Eval("strEstablishedIn") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            AffiliatedTo
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtAffiliatedTo" runat="server" CssClass="txtbox" Text='<%# Eval("strAffiliatedTo") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Admissions
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtAdmissions" runat="server" TextMode="MultiLine" CssClass="ckeditor"
                                                Text='<%# Eval("strAdmissions") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Infraucture
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtInfraucture" runat="server" TextMode="MultiLine" CssClass="ckeditor"
                                                Text='<%# Eval("strInfrastructure") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Placements
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPlacements" runat="server" TextMode="MultiLine" CssClass="ckeditor"
                                                Text='<%# Eval("strPlacements") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Ranking
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRanking" runat="server" TextMode="MultiLine" CssClass="ckeditor"
                                                Text='<%# Eval("strRanking") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            ContactDetails
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtContactDetails" runat="server" TextMode="MultiLine" CssClass="ckeditor"
                                                Text='<%# Eval("strContactDetails") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Email
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txtbox" Text='<%# Eval("strEmail") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Website
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtWebsite" runat="server" CssClass="txtbox" Text='<%# Eval("strWebsite") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" class="subTitle">
                                            Logo
                                        </td>
                                        <td align="left" valign="top">
                                            <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                                <tr>
                                                    <td align="left" valign="top" class="_photo_box">
                                                        <img src='<%# VirtualPathUtility.ToAbsolute("~/files/University/" + Eval("strLogo"))%>'
                                                            alt="" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:FileUpload ID="fu_Logo" runat="server" />
                                                        <asp:HiddenField ID="hf_Logo" runat="server" Value='<%# Eval("strLogo") %>' />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <table width="100%" cellpadding="3px" cellspacing="3px" border="0px">
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Title
                                        </td>
                                        <td align="left">
                                            <%# Eval("strTitle") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Details
                                        </td>
                                        <td align="left">
                                            <%# Eval("strDetails") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            EstablishedIn
                                        </td>
                                        <td align="left">
                                            <%# Eval("strEstablishedIn") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            AffiliatedTo
                                        </td>
                                        <td align="left">
                                            <%# Eval("strAffiliatedTo") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Admissions
                                        </td>
                                        <td align="left">
                                            <%# Eval("strAdmissions") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Infraucture
                                        </td>
                                        <td align="left">
                                            <%# Eval("strInfrastructure") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Placements
                                        </td>
                                        <td align="left">
                                            <%# Eval("strPlacements") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Ranking
                                        </td>
                                        <td align="left">
                                            <%# Eval("strRanking") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            ContactDetails
                                        </td>
                                        <td align="left">
                                            <%# Eval("strContactDetails") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Email
                                        </td>
                                        <td align="left">
                                            <%# Eval("strEmail") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="subTitle">
                                            Website
                                        </td>
                                        <td align="left">
                                            <%# Eval("strWebsite") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" class="subTitle">
                                            Logo
                                        </td>
                                        <td align="left" valign="top">
                                            <div class="_photo_box">
                                                <img src='<%# VirtualPathUtility.ToAbsolute("~/files/University/" + Eval("strLogo"))%>'
                                                    alt="" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" ControlStyle-CssClass="btn" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
