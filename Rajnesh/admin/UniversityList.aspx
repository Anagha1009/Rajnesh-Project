<%@ Page Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true"
    CodeFile="UniversityList.aspx.cs" Inherits="admin_UniversityList" Title="University List"
    ValidateRequest="false" %>

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
                <asp:Label ID="Label3" CssClass="font_title_text" runat="server" Text="U N I V E R S I T Y&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3">
                <asp:Repeater ID="rprAlphanumeric" runat="server" OnItemCommand="rprAlphanumeric_ItemCommand">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbLetter" runat="server" CausesValidation="false" CommandName="Filter"
                            CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Letter")%>' Text='<%# DataBinder.Eval(Container, "DataItem.Letter") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td align="left" width="15%">
                University Title
            </td>
            <td align="left" width="5%">
                :
            </td>
            <td align="left" width="70%">
                <asp:TextBox ID="txtUniversityTitle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" width="15%">
                City
            </td>
            <td align="left" width="5%">
                :
            </td>
            <td align="left" width="70%">
                <asp:DropDownList ID="ddlCity" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" width="15%">
                Type
            </td>
            <td align="left" width="5%">
                :
            </td>
            <td align="left" width="70%">
                <asp:DropDownList ID="ddlType" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                    CausesValidation="false" CssClass="btn_input" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="grd_UniversityList" runat="server" Width="100%" GridLines="None"
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    PageSize="2" OnSelectedIndexChanged="grd_UniversityList_SelectedIndexChanged"
                    OnRowDeleting="grd_UniversityList_RowDeleting" OnSorting="grd_UniversityList_Sorting"
                    OnPageIndexChanging="grd_UniversityList_PageIndexChanging" OnRowCommand="grd_UniversityList_RowCommand"
                    OnRowDataBound="grd_UniversityList_RowDataBound">
                    <HeaderStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strTitle" HeaderText="Name" SortExpression="strTitle">
                            <ItemStyle Width="20%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Address" SortExpression="strAddress">
                            <ItemStyle HorizontalAlign="Center" Width="40%" />
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# ((int)Eval("strAddress").ToString().Length) > 45 ? Eval("strAddress").ToString().Substring(0,45) + "..." : Eval("strAddress")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strCity" HeaderText="City" SortExpression="strCity">
                            <ItemStyle Width="15%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Image" SortExpression="iID">
                            <ItemTemplate>
                                <asp:Image ID="imgProduct" Width="100px" Height="70px" runat="server" ImageUrl='<%#"~/admin/Upload/University/" +Eval("strImage")%>'>
                                </asp:Image>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Featured">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="btnFeatured" CommandName="Featured" CommandArgument='<%#Bind("iId") %>'
                                    CausesValidation="false" />
                                <asp:HiddenField runat="server" ID="hfFeatured" Value='<%#Bind("bFeatured") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
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
                <asp:Label ID="Label_Title" Visible="false" CssClass="font_title_text" runat="server"
                    Text="U N I V E R S I T Y&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
                <br />
                <hr visible="false" id="Horz_Line" runat="server" />
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dv_UniversityList" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                    Width="50%" GridLines="None" OnItemUpdating="dv_UniversityList_ItemUpdating"
                    OnModeChanging="dv_UniversityList_ModeChanging" OnItemCreated="dv_UniversityList_ItemCreated"
                    OnDataBound="dv_UniversityList_DataBound" CellPadding="4" CellSpacing="4">
                    <Fields>
                        <asp:BoundField DataField="iID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Title">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtUniversityTitle" Width="180px" runat="server" Text='<%# Bind("strTitle") %>'></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfvUniversityTitle" runat="server" ControlToValidate="txtUniversityTitle"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtUniversityTitle" Width="180px" runat="server" Text='<%# Bind("strTitle") %>'></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfvUniversityTitle" runat="server" ControlToValidate="txtUniversityTitle"
                                    Display="Dynamic" ErrorMessage="Title" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUniversityTitle" runat="server" Text='<%# Bind("strTitle") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlUniversityType" Width="180px" runat="server">
                                </asp:DropDownList>
                                <asp:CompareValidator runat="server" ID="cvCategory" ControlToValidate="ddlUniversityType"
                                    ValueToCompare="0" Operator="NotEqual" SetFocusOnError="true" Type="string" ErrorMessage="Type"
                                    Text="*"></asp:CompareValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="ddlUniversityType" Width="180px" runat="server">
                                </asp:DropDownList>
                                <asp:CompareValidator runat="server" ID="cvCategory" ControlToValidate="ddlUniversityType"
                                    ValueToCompare="0" Operator="NotEqual" SetFocusOnError="true" Type="string" ErrorMessage="Type"
                                    Text="*"></asp:CompareValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUniversityType" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Established In">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEstablishedIn" runat="server" Text='<%# Bind("strEstablishedIn") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtEstablishedIn" runat="server" Text='<%# Bind("strEstablishedIn") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEstablishedIn" runat="server" Text='<%# Bind("strEstablishedIn") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Affiliated To">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtAffiliatedTo" runat="server" Text='<%# Bind("strAffiliatedTo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtAffiliatedTo" runat="server" Text='<%# Bind("strAffiliatedTo") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAffiliatedTo" runat="server" Text='<%# Bind("strAffiliatedTo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <EditItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckDescription" runat="server" BasePath="~/FCKeditor/"
                                    Height="400px" Width="600px" Value='<%# Eval("strDesc") %>'>
                                </FCKeditorV2:FCKeditor>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckDescription" runat="server" BasePath="~/FCKeditor/"
                                    Height="400px" Width="600px" Value='<%# Eval("strDesc") %>'>
                                </FCKeditorV2:FCKeditor>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("strDesc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <EditItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckAddress" runat="server" BasePath="~/FCKeditor/" Height="400px"
                                    Width="600px" Value='<%# Eval("strAddress") %>'>
                                </FCKeditorV2:FCKeditor>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckAddress" runat="server" BasePath="~/FCKeditor/" Height="400px"
                                    Width="600px" Value='<%# Eval("strAddress") %>'>
                                </FCKeditorV2:FCKeditor>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("strAddress") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Admissions">
                            <EditItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckAdmissions" runat="server" BasePath="~/FCKeditor/"
                                    Height="400px" Width="600px" Value='<%# Eval("strAdmissions") %>'>
                                </FCKeditorV2:FCKeditor>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckAdmissions" runat="server" BasePath="~/FCKeditor/"
                                    Height="400px" Width="600px" Value='<%# Eval("strAdmissions") %>'>
                                </FCKeditorV2:FCKeditor>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAdmissions" runat="server" Text='<%# Bind("strAdmissions") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Infrastructure">
                            <EditItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckInfrastructure" runat="server" BasePath="~/FCKeditor/"
                                    Height="400px" Width="600px" Value='<%# Eval("strInfrastructure") %>'>
                                </FCKeditorV2:FCKeditor>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckInfrastructure" runat="server" BasePath="~/FCKeditor/"
                                    Height="400px" Width="600px" Value='<%# Eval("strInfrastructure") %>'>
                                </FCKeditorV2:FCKeditor>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblInfrastructure" runat="server" Text='<%# Bind("strInfrastructure") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Results">
                            <EditItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckResults" runat="server" BasePath="~/FCKeditor/" Height="400px"
                                    Width="600px" Value='<%# Eval("strResults") %>'>
                                </FCKeditorV2:FCKeditor>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <FCKeditorV2:FCKeditor ID="fckResults" runat="server" BasePath="~/FCKeditor/" Height="400px"
                                    Width="600px" Value='<%# Eval("strResults") %>'>
                                </FCKeditorV2:FCKeditor>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblResults" runat="server" Text='<%# Bind("strResults") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="City">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlCity" Width="180px" runat="server">
                                </asp:DropDownList>
                                <asp:CompareValidator runat="server" ID="cvCity" ControlToValidate="ddlCity" ValueToCompare="0"
                                    Operator="NotEqual" SetFocusOnError="true" Type="string" ErrorMessage="City"
                                    Text="*"></asp:CompareValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="ddlCity" Width="180px" runat="server">
                                </asp:DropDownList>
                                <asp:CompareValidator runat="server" ID="cvCity" ControlToValidate="ddlCity" ValueToCompare="0"
                                    Operator="NotEqual" SetFocusOnError="true" Type="string" ErrorMessage="City"
                                    Text="*"></asp:CompareValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCity" runat="server" Text='<%# Eval("strCity") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEmail" Width="180px" runat="server" Text='<%# Bind("strEmail") %>'></asp:TextBox><asp:RegularExpressionValidator
                                    ID="revEmail" runat="server" ErrorMessage="Invalid E-mail ID" ControlToValidate="txtEmail"
                                    Display="Dynamic" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*
                                </asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtEmail" Width="180px" runat="server" Text='<%# Bind("strEmail") %>'></asp:TextBox><asp:RegularExpressionValidator
                                    ID="revEmail" runat="server" ErrorMessage="Invalid E-mail ID" ControlToValidate="txtEmail"
                                    Display="Dynamic" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*
                                </asp:RegularExpressionValidator>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("strEmail") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Website">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtWebsite" Width="180px" runat="server" Text='<%# Bind("strWebsite") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtWebsite" Width="180px" runat="server"></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblWebsite" runat="server" Text='<%# Bind("strWebsite") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-VerticalAlign="Top" HeaderText="Current&nbsp;Image">
                            <EditItemTemplate>
                                <asp:Image ID="sectionimg" ImageUrl='<%#"~/admin/Upload/University/" +Eval("strImage")%>'
                                    ToolTip='<%# Bind("strImage") %>' runat="server" Width="100px" Height="80px" />
                                <asp:HiddenField ID="hid_imgfile" Value='<%# Eval("strImage") %>' runat="server" />
                                <asp:HiddenField runat="server" ID="hfId" Value='<%# Eval("iID") %>' />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:Image ID="sectionimg2" ImageUrl="~/admin/images/noimage.jpg" runat="server"
                                    Width="100px" Height="80px" />
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="sectionimg1" ImageUrl='<%#"~/admin/Upload/University/" +Eval("strImage")%>'
                                    runat="server" Width="100px" Height="80px" />
                                <asp:HiddenField runat="server" ID="hfId" Value='<%# Eval("iID") %>' />
                                <asp:Label runat="server" ID="lblImageName"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Upload&nbsp;Image">
                            <InsertItemTemplate>
                                <asp:FileUpload ID="fuUniversityImage" runat="server" CssClass="btn_input" />
                            </InsertItemTemplate>
                            <EditItemTemplate>
                                <asp:FileUpload ID="fuUniversityImage" runat="server" CssClass="btn_input" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Featured">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkBox_Featured" runat="server" />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:CheckBox ID="chkBox_Featured" runat="server" />
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Featured" runat="server"></asp:Label>
                                <asp:HiddenField ID="hf_Featured" runat="server" Value='<%# Bind("bFeatured") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
