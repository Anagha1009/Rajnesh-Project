<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="Job-Search.aspx.cs" Inherits="Category_Jobs" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title id="PageTitle" runat="server"></title>
    <meta runat="server" id="MetaDesc" name="Description" content="" />
    <meta runat="server" id="MetaKeywords" name="Keywords" content="" />
</asp:Content>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
</asp:Content>--%>

<asp:Content ID="Content3" ContentPlaceHolderID="cp_left" runat="Server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="box">
        <div class="heading">
            <asp:Label ID="ltl_Title" runat="server"></asp:Label>
        </div>
    </div>
    <br />

    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:GridView ID="grd_Jobs" runat="server" Width="98%" GridLines="None" AllowPaging="True"
                                AllowSorting="false" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                                EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                                PageSize="20" CellPadding="0" CellSpacing="0" PagerSettings-Position="TopAndBottom"
                                PagerSettings-PageButtonCount="10" PagerStyle-BorderWidth="0" PagerStyle-HorizontalAlign="Right"
                                PagerStyle-CssClass="pagelinks" PagerStyle-BorderColor="White" PagerSettings-Mode="NumericFirstLast"
                                OnPageIndexChanging="grd_Jobs_PageIndexChanging" OnRowDataBound="grd_Jobs_RowDataBound">
                                <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast"></PagerSettings>
                                <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                                <Columns>
                                    <asp:TemplateField ShowHeader="false">
                                        <ItemStyle HorizontalAlign="Left" Width="1%" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfldID" runat="server" Value='<%#Eval("iID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="true" HeaderText="Jobs&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Company Name"
                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="GridClass">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="GridClass"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="97%" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <table border="0" width="100%" cellpadding="2px" cellspacing="2px" class="formtable">
                                                <tr>
                                                    <td align="center" style="width: 6%;">
                                                        <img src="images/course_bullet.png" alt="" />
                                                    </td>
                                                    <td style="width: 50%;" align="left" height="25">
                                                        <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# "Job-Details.aspx?Job=" + Eval("strTitle").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-") + "&JobID=" + Eval("iID") %>'
                                                            CssClass="jobs" CausesValidation="false" Text='<%# Eval("strTitle") %>'></asp:HyperLink>
                                                    </td>
                                                    <td style="width: 50%;" align="right">
                                                        <span class="course_city">
                                                            <asp:HiddenField ID="hfCompanyID" runat="server" Value='<%# Eval("iCompanyID") %>' />
                                                            <asp:HiddenField ID="hfCityId" runat="server" Value='<%# Eval("iLocationID") %>' />
                                                            <asp:Label ID="lblCompany" runat="server" Font-Size="12px"></asp:Label></span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" BorderColor="White" BorderWidth="0px" CssClass="pagelinks"></PagerStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="right">
                            <div id="Bottom" runat="server">
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp_rightBottom" runat="Server">
</asp:Content>
