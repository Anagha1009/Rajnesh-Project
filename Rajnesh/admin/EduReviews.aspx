<%@ Page Title="Control Panel | EduReview" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="EduReviews.aspx.cs" Inherits="admin_EduReview"
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
                    OnPageIndexChanging="grd_Records_PageIndexChanging" PageSize="25" OnRowCommand="grd_Records_RowCommand"
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
                        <asp:BoundField DataField="strInstitutionType" HeaderText="Type" SortExpression="strInstitutionType">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Institution Name">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# fn_GetInstitutionName(Eval("strInstitutionType").ToString(), int.Parse(Eval("iInstitutionID").ToString()))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strTitle" HeaderText="Title" SortExpression="strTitle">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strName" HeaderText="Name" SortExpression="strName">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strEmail" HeaderText="Email" SortExpression="strEmail">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strMobileNo" HeaderText="Mobile" SortExpression="strMobileNo">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbl_Date" Text='<%# Eval("dtDate","{0:MMMM dd, yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Image" HeaderText="Details" CausesValidation="false"
                            SelectImageUrl="~/admin/images/Search.png" ControlStyle-CssClass="_edit" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="Enable">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="btnEnable" CommandName="Enable" CommandArgument='<%# Eval("iID") %>'
                                    CausesValidation="false" />
                                <asp:HiddenField runat="server" ID="hfEnable" Value='<%# Eval("bActive") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
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
        <tr id="tr_details" runat="server">
            <td align="left">
                <div id="ScrollHere">
                </div>
                <table width="100%" cellpadding="2px" cellspacing="2px" border="0px">
                    <tr>
                        <td align="left" colspan="3">
                            <h3>
                                Review Details</h3>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="170px">
                            <b>Title</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="170px">
                            <b>Details</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_Details" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="170px">
                            <b>User Type</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_UserType" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="170px">
                            <b>Institute</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_Institute" runat="server"></asp:Literal>
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
                            <b>Date</b>
                        </td>
                        <td width="10px">
                            :
                        </td>
                        <td align="left">
                            <asp:Literal ID="ltl_Date" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:HiddenField ID="hf_ReviewID" runat="server" />
                            <asp:Repeater ID="rpt_ReviewFactors" runat="server" OnItemDataBound="rpt_ReviewFactors_ItemDataBound">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hf_FactorID" runat="server" Value='<%# Eval("iID") %>' />
                                    <div class="_heading">
                                        <%# Eval("strTitle") %>
                                    </div>
                                    <div style="clear: both">
                                    </div>
                                    <asp:Repeater ID="rpt_Ratings" runat="server">
                                        <ItemTemplate>
                                            <div>
                                                <div class="_factor">
                                                    <%# Eval("strFactor")%>
                                                </div>
                                                <div>
                                                    <%# Eval("iFactorValue")%>
                                                </div>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <style type="text/css">
        ._factor
        {
            float: left;
            width: 170px;
            font-weight: bold;
            padding: 5px;
        }
    </style>
</asp:Content>
