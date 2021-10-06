<%@ Page Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true"
    CodeFile="Jobs.aspx.cs" Inherits="admin_Jobs" Title="Admin :: JOBS" ValidateRequest="false"
    MaintainScrollPositionOnPostback="true" %>

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
                <asp:Label ID="lbl" CssClass="font_title_text" runat="server" Text="J O B&nbsp;&nbsp;&nbsp;&nbsp;L I S T"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td>
                            Job :
                        </td>
                        <td>
                            <asp:TextBox ID="txtJob" runat="server" Width="270px"></asp:TextBox>
                        </td>
                        <td>
                            Category :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_Cat" runat="server"  Width="270px">
                            </asp:DropDownList>
                        </td>
                        <td rowspan="2"><asp:Button ID="btnSearch" runat="server" Text="Send" Width="99px"
                             Height="40px" OnClick="btnSearch_Click" ValidationGroup="vg_Search"/></td>
                    </tr>
                    <tr>
                    <td>
                            Location :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_Loc" runat="server"  Width="270px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Company :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_Comp" runat="server"  Width="270px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="grd_Jobs" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="4" CellSpacing="4" DataKeyNames="iID"
                    PageSize="20" PagerSettings-PageButtonCount="100" OnRowDeleting="grd_Jobs_RowDeleting"
                    OnSelectedIndexChanged="grd_Jobs_SelectedIndexChanged" OnPageIndexChanging="grd_Jobs_PageIndexChanging"
                    OnRowDataBound="grd_Jobs_RowDataBound" onrowcommand="grd_Jobs_RowCommand">
                    <HeaderStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strTitle" HeaderText="Job">
                            <ItemStyle Width="20%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Category">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:HiddenField ID="hfField" runat="server" Value='<%# Eval("iID") %>' />
                                <asp:Label runat="server" ID="lbl_Category"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Location">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblLocation"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCompany"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Enable/Disable">
                    <ItemTemplate >
                        <asp:ImageButton runat="server" ID="btnEnable" CommandName="job" 
                        CommandArgument='<%# Eval("iID") %>' CausesValidation="false"/>
                        <asp:HiddenField runat="server" ID="hfjob" Value='<%# Eval("bActive") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Government">
                    <ItemTemplate >
                        <asp:ImageButton runat="server" ID="btnGovernment" CommandName="Government" 
                        CommandArgument='<%# Eval("iID") %>' CausesValidation="false"/>
                        <asp:HiddenField runat="server" ID="hfGovernment" Value='<%# Eval("bGovernment") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Posted Date">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <%# Eval("dtPostedDate", "{0:MMMM dd, yyyy}")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Expiration Date">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <%# Eval("dtExpirationDate", "{0:MMMM dd, yyyy}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:CommandField ButtonType="Image" CausesValidation="false" HeaderText="Edit" SelectImageUrl="~/Admin/images/edit.jpg"
                            ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
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
                <asp:Label ID="Label1" CssClass="font_title_text" runat="server" Text="I N S T I T U T E&nbsp;&nbsp;&nbsp;&nbsp;D E T A I L S"></asp:Label>
                <br />
                <hr />
                <br />
                <%--<asp:ValidationSummary ID="vs_Institute" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>--%>
                <br />
                <asp:DetailsView ID="dv_Jobs" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                    Width="50%" GridLines="None" OnItemInserting="dv_Jobs_ItemInserting" OnItemUpdating="dv_Jobs_ItemUpdating"
                    OnModeChanging="dv_Jobs_ModeChanging" OnDataBound="dv_Jobs_DataBound">
                    <Fields>
                        <asp:BoundField DataField="iID" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Job Title">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtInstituteTitle" runat="server" Text='<%# Bind("strTitle") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtInstituteTitle" runat="server" Text='<%# Bind("strTitle") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblInstituteName" runat="server" Text='<%# Bind("strTitle") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_Category" Width="180px" runat="server" OnSelectedIndexChanged="ddl_Category_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="ddl_Category" Width="180px" runat="server" OnSelectedIndexChanged="ddl_Category_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCategory" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SubCategory">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_SubCategory" Width="180px" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="ddl_SubCategory" Width="180px" runat="server">
                                </asp:DropDownList>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSubCategory" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Location">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_Location" Width="180px" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="ddl_Location" Width="180px" runat="server">
                                </asp:DropDownList>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblLocation" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_Company" Width="180px" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="ddl_Company" Width="180px" runat="server">
                                </asp:DropDownList>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCompany" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <FCKeditorV2:FCKeditor ID="txtInstituteDesc" runat="server" BasePath="~/FCKeditor/"
                                    Height="400px" Width="600px" Value='<%# Eval("strDescription") %>'>
                                </FCKeditorV2:FCKeditor>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <FCKeditorV2:FCKeditor ID="txtInstituteDesc" runat="server" BasePath="~/FCKeditor/"
                                    Height="400px" Width="600px" Value='<%# Eval("strDescription") %>'>
                                </FCKeditorV2:FCKeditor>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblInstituteDesc" runat="server" Text='<%# Bind("strDescription") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Expiration Date" HeaderStyle-VerticalAlign="Top">
                            <EditItemTemplate>
                                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                    <tr>
                                        <td width="85px" align="left">
                                            <asp:DropDownList ID="ddl_Day" runat="server" Width="80px" CssClass="ddlbox">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10px" align="center">
                                            <asp:RequiredFieldValidator ID="rfvDay" runat="server" ErrorMessage="Day" SetFocusOnError="true"
                                                Display="Dynamic" ControlToValidate="ddl_Day" InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                        <td width="85px" align="left">
                                            <asp:DropDownList ID="ddl_Month" runat="server" Width="80px" CssClass="ddlbox">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10px" align="center">
                                            <asp:RequiredFieldValidator ID="rfvMonth" runat="server" ErrorMessage="Month" SetFocusOnError="true"
                                                Display="Dynamic" ControlToValidate="ddl_Month" InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                        <td width="85px" align="left">
                                            <asp:DropDownList ID="ddl_Year" runat="server" Width="80px" CssClass="ddlbox">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10px" align="left">
                                            <asp:RequiredFieldValidator ID="rfvYear" runat="server" ErrorMessage="Year" SetFocusOnError="true"
                                                Display="Dynamic" ControlToValidate="ddl_Year" InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                    <tr>
                                        <td width="85px" align="left">
                                            <asp:DropDownList ID="ddl_Day" runat="server" Width="80px" CssClass="ddlbox">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10px" align="center">
                                            <asp:RequiredFieldValidator ID="rfvDay" runat="server" ErrorMessage="Day" SetFocusOnError="true"
                                                Display="Dynamic" ControlToValidate="ddl_Day" InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                        <td width="85px" align="left">
                                            <asp:DropDownList ID="ddl_Month" runat="server" Width="80px" CssClass="ddlbox">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10px" align="center">
                                            <asp:RequiredFieldValidator ID="rfvMonth" runat="server" ErrorMessage="Month" SetFocusOnError="true"
                                                Display="Dynamic" ControlToValidate="ddl_Month" InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                        <td width="85px" align="left">
                                            <asp:DropDownList ID="ddl_Year" runat="server" Width="80px" CssClass="ddlbox">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10px" align="left">
                                            <asp:RequiredFieldValidator ID="rfvYear" runat="server" ErrorMessage="Year" SetFocusOnError="true"
                                                Display="Dynamic" ControlToValidate="ddl_Year" InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <%# Eval("dtExpirationDate", "{0:MMMM dd, yyyy}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
