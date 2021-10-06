<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="Jobs-in-India-for-Freshers.aspx.cs" Inherits="Jobs_in_India" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="Pager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>JOBS FOR FRESHERS IN INDIA 2016|FRESHER JOBS|</title>
    <meta name="Description" content="Jobs for Freshers in India 2016- Find Latest Freshers Jobs in India for MBA, IT, Engineering and MCA" />
    <meta name="Keywords" content="jobs for freshers, fresher jobs in india, jobs for freshers mba, jobs for freshers it, jobs for freshers engineering, software testing jobs for freshers, government jobs for freshers, jobs for freshers in delhi, jobs for freshers in mumbai, jobs for freshers in bangalore" />
</asp:Content>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
</asp:Content>--%>


<asp:Content ID="Content3" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="box">
        <div class="heading">
            <asp:Label ID="lblTitle" runat="server">Jobs in India for Freshers</asp:Label>
        </div>
        <div class="height-10"></div>
        <div class="Content" style="padding-left: 10px;">
            Here we have provided you with the list of latest jobs at the top companies and organizations in India 2016 with different category and courses. You may find jobs available for MBA, Engineering, MCA, IT, Fresher, Graduates and Experienced. 
        </div>
        <div class="height-10"></div>
        <div class="height-10"></div>
        <div style="padding-left: 10px;">
            <h4>Jobs in Top Companies</h4>
        </div>
        <div style="padding-left: 10px;" class="modify_table">
            <asp:DataList ID="dl_Jobs" runat="server" Width="100%" RepeatColumns="3">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <%--   <table width="100%" cellpadding="2px" cellspacing="2px">
                        <tr>
                            <td width="15px" valign="top" align="left">
                            </td>
                            <td valign="top" align="left">
                                <asp:HyperLink ID="Jobs" runat="server" CssClass="jobs" CausesValidation="false" Text='<%# Eval("strPageTitle") %>'
                                    NavigateUrl='<%# System.Web.Routing.RouteTable.Routes.GetVirtualPath(null, "JobGenaratorList", new System.Web.Routing.RouteValueDictionary { { "Job", Eval("strFileName") } }).VirtualPath%>'></asp:HyperLink>
                            </td>
                        </tr>
                    </table>--%>
                        
                            <asp:HyperLink ID="Jobs" runat="server" CssClass="jobs" CausesValidation="false" Text='<%# Eval("strPageTitle") %>'
                                NavigateUrl='<%# System.Web.Routing.RouteTable.Routes.GetVirtualPath(null, "JobGenaratorList", new System.Web.Routing.RouteValueDictionary { { "Job", Eval("strFileName") } }).VirtualPath%>'></asp:HyperLink>
                        
                </ItemTemplate>
            </asp:DataList>
            <br />
            <Pager:CollectionPager ID="CPager" runat="server" BackNextDisplay="HyperLinks" PageSize="1990"
                BackNextLocation="Split" BackText="Prev" PageNumbersSeparator="&amp;nbsp;" ShowFirstLast="False"
                ResultsLocation="Bottom" PagingMode="QueryString" SliderSize="20" UseSlider="True"
                LabelText="" NextText="Next" ResultsFormat="" MaxPages="10000" LabelStyle=""
                QueryStringKey="TrxnPage" BackNextButtonStyle="" BackNextLinkSeparator="·" BackNextStyle=""
                ControlCssClass="" ControlStyle="" FirstPageHolderId="" FirstText="First" HideOnSinglePage="True"
                IgnoreQueryString="False" LastText="Last" PageNumbersDisplay="Numbers" PageNumbersStyle=""
                PageNumberStyle="" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;FONT-WEIGHT: bold;"
                SecondPageHolderId="" SectionPadding="10" ShowLabel="True" ShowPageNumbers="True">
            </Pager:CollectionPager>
            <div id="PagerDiv" runat="server" class="PageNo">
            </div>
        </div>
        <div class="height-10"></div>
        <div style="padding-left: 10px;">
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
                    <asp:TemplateField ShowHeader="true" >
                        <HeaderStyle HorizontalAlign="Left" CssClass="heading"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Left" Width="97%" VerticalAlign="Top" />
                         <HeaderTemplate>
                            <div>
                               <ul>
                                   <li>
                                       Jobs
                                   </li>
                                   <li>
                                       Company Name
                                   </li>
                               </ul>
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:HiddenField ID="hfldID" runat="server" Value='<%# Eval("iID") %>' />
                            <%--  <table border="0" width="100%" cellpadding="2px" cellspacing="2px" class="formtable">
                                    <tr>
                                        <td align="center">
                                            <img src="../images/course_bullet.png" alt="" />
                                        </td>
                                        <td align="left" height="25">
                                            <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# "Job-Details.aspx?Job=" + Eval("strTitle").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-") + "&JobID=" + Eval("iID") %>'
                                                CssClass="jobs" CausesValidation="false" Text='<%# Eval("strTitle") %>'></asp:HyperLink>
                                        </td>
                                        <td align="right">
                                            <span class="course_city">
                                                <asp:HiddenField ID="hfCompanyID" runat="server" Value='<%# Eval("iCompanyID") %>' />
                                                <asp:HiddenField ID="hfCityId" runat="server" Value='<%# Eval("iLocationID") %>' />
                                                <asp:HiddenField ID="hfCategory" runat="server" Value='<%# Eval("iCategoryID") %>' />
                                                <asp:HiddenField ID="hfSubCategory" runat="server" Value='<%# Eval("iSubCategoryID") %>' />
                                                <asp:Label ID="lblCompany" runat="server" Font-Size="13px"></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center"></td>
                                        <td style="font-size: 12px; color: Gray">Category :
                                            <asp:Label ID="lblCategory" runat="server" CssClass="" Font-Underline="false"> </asp:Label>
                                        </td>
                                        <td style="font-size: 12px; color: Gray" align="right">SubCategory : 
                                            <asp:Label ID="lblSubCategory" runat="server" CssClass="" Font-Underline="false"> </asp:Label>
                                        </td>
                                    </tr>
                                </table>--%>
                            <ul style="float: left;">
                                <li>
                                    <img src="../images/course_bullet.png" alt="" />
                                    <div class="jobs_info">
                                        <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# "Job-Details.aspx?Job=" + Eval("strTitle").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-") + "&JobID=" + Eval("iID") %>'
                                            CssClass="jobs" CausesValidation="false" Text='<%# Eval("strTitle") %>'></asp:HyperLink><br>

                                        <asp:Label ID="lblCategory" runat="server" CssClass="" Font-Underline="false"> </asp:Label>
                                    </div>
                                </li>
                                <li>
                                    <div class="jobs_location">
                                        <span class="course_city">
                                            <asp:HiddenField ID="hfCompanyID" runat="server" Value='<%# Eval("iCompanyID") %>' />
                                            <asp:HiddenField ID="hfCityId" runat="server" Value='<%# Eval("iLocationID") %>' />
                                            <asp:HiddenField ID="hfCategory" runat="server" Value='<%# Eval("iCategoryID") %>' />
                                            <asp:HiddenField ID="hfSubCategory" runat="server" Value='<%# Eval("iSubCategoryID") %>' />
                                            <asp:Label ID="lblCompany" runat="server" Font-Size="13px"></asp:Label>
                                        </span>

                                            <asp:Label ID="lblSubCategory" runat="server" CssClass="" Font-Underline="false"> </asp:Label>
                                    </div>
                                </li>
                                    
                            </ul>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle HorizontalAlign="Right" BorderColor="White" BorderWidth="0px" CssClass="pagelinks"></PagerStyle>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cp_rightBottom" runat="Server">
</asp:Content>
