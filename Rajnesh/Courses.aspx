<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Courses.aspx.cs" Inherits="Courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Distance Education Courses|Learning|Correspondence|</title>
    <meta name="Description" content="Distance Education Courses, Distance Learning, Degree, Diploma, PG Diploma, Correspondence Courses in India" />
    <meta name="Keywords" content="distance education courses, distance learning courses, correspondence courses, distance education degree courses, distance education diploma courses, distance education pg diploma courses" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <div class="box">
        <div class="heading"><a href="#">Courses List</a></div>
        <div class="box-content">

            <div class="rating">
                <div id="score" style="cursor: pointer;">
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
                    <div class="Ratingleft">
                        <asp:Rating ID="rt_Rate" runat="server" StarCssClass="StarCss" FilledStarCssClass="FilledStarCss"
                            EmptyStarCssClass="EmptyStarCss" WaitingStarCssClass="WaitingStarCss" AutoPostBack="true"
                            OnChanged="rt_Rate_Changed" MaxRating="5">
                        </asp:Rating>
                    </div>

                </div>
                <div class="rating-text">
                    <asp:Literal ID="ltl_RatingBox" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="social-share">
                <script type="text/javascript">   var switchTo5x = true;</script>
                <script type="text/javascript" src="/js/button.js"></script>
                <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                <script type="text/javascript">   stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                    displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
            </div>
            <div class="height-10"></div>
            <div class="list">
                <p>
                    Given Below is the list of Distance Education Courses in India.   In the Courses Details you will Get Information on Distance Learning, Degree, Diploma, PG Diploma, Correspondence Courses offered, Study Centres, Exam Notifications, Time Table & Results. 
                </p>

            </div>

            <div class="height-10"></div>
            <div class="filter-result">

                <div class="detail-list">
                   <asp:UpdatePanel ID="pnllist" runat="server">
                        <ContentTemplate>
                          <div class="pagination">
                            <ul>
                                <li>
                                    <asp:LinkButton ID="btnMoreUpPrv" runat="server" Text="..." OnClick="lnkPrevPageNumber_Click" Visible="false"/></li>
                                <asp:Repeater ID="rptPagesUp" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <asp:LinkButton ID="btnPage" pageno="<%# Container.DataItem %>" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server"><%# Container.DataItem %> </asp:LinkButton>
                                        </li>
                                    </ItemTemplate>

                                </asp:Repeater>
                                <li>
                                    <asp:LinkButton ID="btnMoreUpNxt" runat="server" Text="..." OnClick="lnkMorePageNumber_Click" Visible="false"/></li>
                            </ul>
                        </div>
                        <div class="detail-list">
                            <ul>
                                <asp:Repeater ID="grd_dlCourses" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="contentblock">
                                                <a href='<%# "https://www.eduvidya.com/" + Eval("strType") + "/" + Eval("strInstitute").ToString().Replace(" ", "-").Replace("&", "-").Replace(":", "-").Replace(".", "-").Replace("?", "-").Replace(",", "-").Replace("%", "-").Replace("/", "-").Replace("---", "-").Replace("--", "-") + "/Course/" + Eval("strName").ToString().Replace(" ", "-").Replace("&", "-").Replace(":", "-").Replace("?", "-").Replace(",", "-").Replace(".", "-").Replace("%", "-").Replace("/", "-").Replace("---", "-").Replace("--", "-") + "/" + Eval("iID") %>'>
                                                    <%# Eval("strName")%></a>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="pagination">
                            <ul>
                                <li>
                                    <asp:LinkButton ID="btnMoreDwnPrv" runat="server" Text="..." OnClick="lnkPrevPageNumber_Click" Visible="false"/></li>
                                <asp:Repeater ID="rptPagesDwn" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <asp:LinkButton ID="btnPage" pageno="<%# Container.DataItem %>" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server"><%# Container.DataItem %> </asp:LinkButton>
                                        </li>
                                    </ItemTemplate>

                                </asp:Repeater>
                                <li>
                                    <asp:LinkButton ID="btnMoreDwnNxt" runat="server" Text="..." OnClick="lnkMorePageNumber_Click" Visible="false"/></li>
                            </ul>
                        </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>
        </div>
    </div>
    <%--<table width="100%" cellpadding="0px" cellspacing="0px" border="0px" class="theBox">
        <tr>
            <td align="left" class="rec_Title">
                Courses List
            </td>
        </tr>
        <tr>
            <td align="left" class="rec_Desc">
            <div class="leftbox">
                        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </asp:ToolkitScriptManager>
                        <div>
                            <div class="Ratingleft">
                                <asp:Rating ID="rt_Rate" runat="server" StarCssClass="StarCss" FilledStarCssClass="FilledStarCss"
                                    EmptyStarCssClass="EmptyStarCss" WaitingStarCssClass="WaitingStarCss" AutoPostBack="true"
                                    OnChanged="rt_Rate_Changed" MaxRating="5">
                                </asp:Rating>
                            </div>
                            <div class="RatingBox">
                                <asp:Literal ID="ltl_RatingBox" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    <br />
                Given Below is the list of Distance Education Courses in India.   In the Courses Details you will Get Information on Distance Learning, Degree, Diploma, PG Diploma, Correspondence Courses offered, Study Centres, Exam Notifications, Time Table & Results.
            </td>
        </tr>
        <tr>
            <td align="left">
                              
                                <asp:ListView ID="grd_dlCourses" runat="server" GroupPlaceholderID="groupPlaceHolder1"
                                    ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
                                    <LayoutTemplate>

                                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="grd_dlCourses" PageSize="15" class="pagination">
                                            <Fields>
                                                <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                                            </Fields>
                                        </asp:DataPager>
                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                        <asp:DataPager ID="DataPager2" runat="server" PagedControlID="grd_dlCourses" PageSize="15" class="pagination">
                                            <Fields>
                                                <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                                            </Fields>
                                        </asp:DataPager>

                                    </LayoutTemplate>
                                    <GroupTemplate>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                    </GroupTemplate>
                                    <ItemTemplate>
                                        <li>
                                             <div class="contentblock">
                                                <a href='<%# "https://www.eduvidya.com/" + Eval("strType") + "/" + Eval("strInstitute").ToString().Replace(" ", "-").Replace("&", "-").Replace(":", "-").Replace(".", "-").Replace("?", "-").Replace(",", "-").Replace("%", "-").Replace("/", "-").Replace("---", "-").Replace("--", "-") + "/Course/" + Eval("strName").ToString().Replace(" ", "-").Replace("&", "-").Replace(":", "-").Replace("?", "-").Replace(",", "-").Replace(".", "-").Replace("%", "-").Replace("/", "-").Replace("---", "-").Replace("--", "-") + "/" + Eval("iID") %>'>
                                                    <%# Eval("strName")%></a>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView>
                            
                <br />
                <div style="padding: 10px 0px">
                    <script type="text/javascript">                        var switchTo5x = true;</script>
                    <script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>
                    <script type="text/javascript">                        stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                    <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                        displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'>
                    </span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'>
                    </span>
                </div>
            </td>
        </tr>
    </table>--%>
</asp:Content>
