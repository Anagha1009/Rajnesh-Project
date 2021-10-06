<%@ Page Title="Control Panel | CompetitionEntry" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="CompetitionFiles.aspx.cs" Inherits="admin_CompetitionFiles"
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
                    AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="1" CellSpacing="1" DataKeyNames="iID"
                    OnRowDeleting="grd_Records_RowDeleting" OnSorting="grd_Records_Sorting" OnPageIndexChanging="grd_Records_PageIndexChanging"
                    OnSelectedIndexChanged="grd_Records_SelectedIndexChanged" PageSize="25">
                    <HeaderStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strName" HeaderText="Name" SortExpression="strName">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strEmail" HeaderText="Email" SortExpression="strEmail">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strMobile" HeaderText="MobileNo" SortExpression="strMobile">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dtDate" HeaderText="Date" SortExpression="dtDate">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Uploads">
                            <ItemTemplate>
                                <a href='<%# VirtualPathUtility.ToAbsolute("~/admin/CompetitionUserFiles.aspx?CompetitionId=" + Request.QueryString["CompetitionID"].ToString() + "&UserId=" + Eval("iID"))%>'>
                                    <img src="images/uploads.png" width="45px" /></a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Image" HeaderText="Details" CausesValidation="false"
                            SelectImageUrl="~/img/details.png" ControlStyle-CssClass="_edit" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
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
        <tr id="tr_details" runat="server">
            <td align="left">
                <div id="ScrollHere">
                </div>
                <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                    <tr>
                        <td align="left" colspan="3">
                            <h3>
                                Competition User Details</h3>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="170px">
                            <b>Name</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_Name" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="170px">
                            <b>Email</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_Email" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="170px">
                            <b>Date of Birth</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_DoB" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="170px">
                            <b>Gender</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_Gender" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="170px">
                            <b>Current Qualification</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_Qualification" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="170px">
                            <b>Mobile No</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_MobileNo" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="170px">
                            <b>City</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_City" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="170px">
                            <b>Address</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_Address" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="170px">
                            <b>Ip Address</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_IpAddress" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="170px">
                            <b>Date</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_Date" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
