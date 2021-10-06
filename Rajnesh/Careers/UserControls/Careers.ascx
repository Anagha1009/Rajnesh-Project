<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Careers.ascx.cs" Inherits="Careers_UserControls_Careers" %>

<asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
<div class="height-10"></div>
<div itemscope itemtype="http://data-vocabulary.org/Review-aggregate">
    <div class="height-10"></div>
    <div class="box">
        <div class="heading">
            <asp:HyperLink ID="hlTitle" runat="server" Text="" NavigateUrl="#"></asp:HyperLink>
        </div>
        <div class="box-content">
            <asp:Literal ID="ltDescription" runat="server"></asp:Literal>

            <%--<div class="search">
                <div class="course-type">
                    <asp:DropDownList ID="ddlCategory" runat="server"
                        CssClass="dropbox">
                    </asp:DropDownList>
                </div>
                <div class="course-type">
                    <asp:DropDownList ID="ddlCompany" runat="server"
                        CssClass="dropbox">
                    </asp:DropDownList>
                </div>
                <div class="college-location">
                    <asp:DropDownList ID="ddlCity" runat="server"
                        CssClass="dropbox">
                    </asp:DropDownList>
                </div>
                <div class="search-btn">
                      <asp:Button ID="btnSearch" runat="server"
                        ValidationGroup="vg_search" Text="Search"
                        CssClass="btnSubmit" OnClick="btnSearch_Click" />
                </div>
            </div>--%>
            <div class="height-10"></div>
            <div class="rating">
                <div id="score" style="cursor: pointer;">
                    <%--  <asp:ToolkitScriptManager
                        ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>--%>
                    <div class="Ratingleft">
                        <asp:Rating ID="rt_Rate" runat="server" StarCssClass="StarCss" FilledStarCssClass="FilledStarCss" EmptyStarCssClass="EmptyStarCss"
                            WaitingStarCssClass="WaitingStarCss" AutoPostBack="true"
                            OnChanged="rt_Rate_Changed" MaxRating="5">
                        </asp:Rating>
                    </div>
                </div>
                <div class="rating-text">
                    <asp:Literal ID="ltl_RatingBox" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="social-share">
                <script type="text/javascript">

                    var switchTo5x = true;</script>
                <script type="text/javascript"
                    src="http://w.sharethis.com/button/buttons.js"></script>
                <script type="text/javascript">

                    stLight.options({
                        publisher: "48258661-ca69-42d4-831c-4dc41b9328a1"

                    });</script>
                <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large' displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large' displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
            </div>
            <div class="height-10"></div>
            <div class="height-10"></div>
            <div class="list">
                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                    <tr id="tr_Company" runat="server">
                        <td width="101px" align="center" valign="top" style="padding-top: 4px" id="td_Logo"
                            runat="server">
                            <img id="img_Logos" runat="server" style="max-height: 90px; max-width: 80px; width: 90px" />
                        </td>
                        <td align="left" valign="top">
                            <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                <tr id="td_CompanyName" runat="server">
                                    <td align="left" valign="top" width="120px">
                                        <b>Company Name :</b>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltl_CompanyTitle" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr id="td_Industry" runat="server">
                                    <td align="left" valign="top" width="120px">
                                        <b>Industry :</b>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltl_CompanyIndustry" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr id="td_Address" runat="server">
                                    <td align="left" valign="top" width="120px">
                                        <b>Address :</b>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltl_CompanyAddrs" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="120px">
                            <b>Updated On :</b>
                        </td>
                        <td>
                            <asp:Literal ID="ltl_Updated" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:DataList ID="dl_JobLinks" runat="server" RepeatColumns="4" Width="100%">
                    <ItemTemplate>
                        <table width="100%" cellpadding="2" cellspacing="2" border="0">
                            <tr>
                                <td valign="top" style="width: 2%;" align="left">
                                    <img src="../images/List.png" height="12px" />&nbsp;
                                </td>
                                <td valign="top" align="left" style="width: 93%;">
                                    <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# Eval("strUrl").ToString() %>'
                                        CssClass="jobs" CausesValidation="false" Text='<%# Eval("strTitle") %>'></asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <br />
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
                        <asp:TemplateField ShowHeader="true">
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
                                <table border="0" width="100%" cellpadding="2px" cellspacing="2px" class="formtable">
                                    <tr>
                                        <td align="center" style="width: 6%;">
                                            <img src="../images/course_bullet.png" alt="" />
                                        </td>
                                        <td style="width: 65%;" align="left" height="25">
                                            <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# "/Job-Details.aspx?Job=" + Eval("strTitle").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-") + "&JobID=" + Eval("iID") %>'
                                                CssClass="jobs" CausesValidation="false" Text='<%# Eval("strTitle") %>'></asp:HyperLink>
                                        </td>
                                        <td style="width: 35%;" align="right">
                                            <span class="course_city">
                                                <asp:HiddenField ID="hfCompanyID" runat="server" Value='<%# Eval("iCompanyID") %>' />
                                                <asp:HiddenField ID="hfCityId" runat="server" Value='<%# Eval("iLocationID") %>' />
                                                <asp:HiddenField ID="hfCategory" runat="server" Value='<%# Eval("iCategoryID") %>' />
                                                <asp:HiddenField ID="hfSubCategory" runat="server" Value='<%# Eval("iSubCategoryID") %>' />
                                                <asp:Label ID="lblCompany" runat="server" Font-Size="13px"></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="width: 6%;"></td>
                                        <td style="font-size: 12px; color: Gray">Category :
                                            <asp:Label ID="lblCategory" runat="server" CssClass="" Font-Underline="false"> </asp:Label>
                                        </td>
                                        <td style="width: 35%;" style="font-size: 12px; color: Gray" align="right">SubCategory : 
                                            <asp:Label ID="lblSubCategory" runat="server" CssClass="" Font-Underline="false"> </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" BorderColor="White" BorderWidth="0px" CssClass="pagelinks"></PagerStyle>
                </asp:GridView>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="padding: 10px 0px">
                            <br />
                            <div class="desktop-ad">
                                <script type="text/javascript"><!--
    google_ad_client = "pub-4037987430386783";
    /* jobs for freshers-home-336x280 */
    google_ad_slot = "9287764418";
    google_ad_width = 336;
    google_ad_height = 280;//-->

                                </script>
                                <script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
                                </script>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

    </div>
</div>
