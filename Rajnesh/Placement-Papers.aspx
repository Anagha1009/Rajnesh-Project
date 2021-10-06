<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="Placement-Papers.aspx.cs" Inherits="Jobs_in_India" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="Pager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>PLACEMENT PAPERS 2016|WITH ANSWERS|SOLUTIONS|</title>
    <meta name="Description" content="Placement Papers 2016- Find Latest Placement Papers with Answers and Solutions." />
    <meta name="Keywords" content="placement papers 2016, placement papers with answers, placement papers with solutions" />
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
</asp:Content>--%>

<asp:Content ID="Content3" ContentPlaceHolderID="cp_left" runat="Server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="box">
        <div class="heading">
            <asp:Label ID="lblTitle" runat="server">Placement Papers for Freshers</asp:Label>
        </div>
        <div class="height-10"></div>
        <div class="Content" style="padding-left: 10px;">
            Here you may find the list of latest placement papers 2016 along with the solutions of well known IT companies and other organizations of India. These papers would help the candidate to prepare themselves for written exam conducted by the companies before the job interview.
        </div>
        <div class="height-10"></div>
        <div class="height-10"></div>
        <div style="padding-left: 10px;">
            <h4>Placement Papers of Top Companies in India</h4>
        </div>
        <div style="padding-left: 10px;">
            <asp:DataList ID="dl_Papers" runat="server" Width="100%" RepeatColumns="3">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <table width="100%" cellpadding="2px" cellspacing="2px">
                        <tr>
                            <td valign="top" align="left">
                                <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# System.Web.Routing.RouteTable.Routes.GetVirtualPath(null, "PaperGenaratorList", new System.Web.Routing.RouteValueDictionary { { "Paper", Eval("strFileName") } }).VirtualPath%>'
                                    CssClass="jobs" CausesValidation="false" Text='<%# Eval("strPageTitle") %>'></asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <br />
            <Pager:CollectionPager ID="CPager" runat="server" BackNextDisplay="HyperLinks" PageSize="1900"
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
            <asp:GridView ID="grd_papers" runat="server" Width="98%" GridLines="None" AllowPaging="True"
                AllowSorting="false" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                PageSize="20" CellPadding="0" CellSpacing="0" PagerSettings-Position="TopAndBottom"
                PagerSettings-PageButtonCount="10" PagerStyle-BorderWidth="0" PagerStyle-HorizontalAlign="Right"
                PagerStyle-CssClass="pagelinks" PagerStyle-BorderColor="White" PagerSettings-Mode="NumericFirstLast"
                OnPageIndexChanging="grd_papers_PageIndexChanging">
                <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast"></PagerSettings>
                <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                <Columns>
                    <asp:TemplateField ShowHeader="true">
                        <HeaderStyle HorizontalAlign="Left" CssClass="heading"></HeaderStyle>
                         <HeaderTemplate>
                            <div>
                               <ul>
                                   <li>
                                       Placement Papers
                                   </li>
                                   <li>
                                       Company Name
                                   </li>
                               </ul>
                            </div>
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="97%" VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:HiddenField ID="hfldID" runat="server" Value='<%# Eval("iID") %>' />
                            <ul style="float: left;">
                                <li>
                                        <img src="images/course_bullet.png" alt="" />
                                    <div class="jobs_info">
                                        <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# "Placement-Paper-Details.aspx?Paper=" + Eval("strTitle").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-") + "&PaperID=" + Eval("iID") %>'
                                            CssClass="jobs" CausesValidation="false" Text='<%# Eval("strTitle") %>'></asp:HyperLink>
                                    </div>
                                    </li>
                                    <li>
                                        <span class="">
                                            <asp:Label ID="lblCompany" runat="server" Font-Size="12px" Text='<%# Eval("strCompany") %>'></asp:Label></span>
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
