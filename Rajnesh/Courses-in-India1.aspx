<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Courses-in-India.aspx.cs" Inherits="CollegeCourses" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="Pager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Best Courses in India after 12th, Graduation, arts, commerce, science</title>
    <meta name="Description" content="List of Best Courses in India after 12th and Graduation for Arts, Commerce and Science students" />
    <meta name="Keywords" content="Courses in India" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">

    <div class="box">
        <div class="heading"><a href="#">Best Courses in India</a></div>
        <div class="box-content">
            <div class="search">
                <div class="course-type">
                    <asp:DropDownList ID="ddl_Category" runat="server">
                    </asp:DropDownList>
                </div>

                <div class="search-btn">
                    <asp:Button ID="btnSearch" runat="server" ValidationGroup="vg_search"
                        Text="Search" CssClass="btnSubmit" OnClick="btnSearch_Click" />
                </div>
            </div>
            <div class="height-10"></div>
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
                <script type="text/javascript">                                var switchTo5x = true;</script>
                <script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>
                <script type="text/javascript">                                stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                    displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
            </div>
            <div class="height-10"></div>
            <div class="list">
                <p>
                    Given below is the list of best Courses in India after 12th, Graduation, MBA and Engineering. Whether you are an aspiring graduate or an experienced professional, India offers you a wide range of courses that can enhance or jet set your career on the right track. These courses span across various fields such as engineering, medicine, hospitality, architecture and media to name a few. 
                </p>

                <p>
                    Some of the most popular degree courses include the likes of B.Tech, MBBS and BBA. These courses are offered by institutes that are either private or government run. Diploma courses too are in demand and have found new popularity among students. For those who want to pursue higher studies have options such as MBA, MDS, Ph.D.
                </p>
                <div class="height-10"></div>
                <ul>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/MBA-Courses-in-India">MBA Courses in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/BTech-Courses-in-India">BTech Courses in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/MCA-Courses-in-India">MCA Courses in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/M-Com-Courses-in-India">M Com Courses in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Architecture-Courses-in-India">Architecture Courses in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Medical-Courses-in-India">Medical Courses in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Animation-Courses-in-India">Animation Courses in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-after-12th">Courses after 12th</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-after-Graduation">Courses after Graduation</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-after-12th-Science">Courses after 12th Science</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-after-12th-Commerce">Courses after 12th Commerce</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-after-12th-Arts">Courses after 12th Arts</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-after-Graduation-in-Commerce">Courses after Graduation in Commerce</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-after-Graduation-in-Science">Courses after Graduation in Science</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-after-Graduation-in-Arts">Courses after Graduation in Arts</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-after-Graduation-in-Engineering">Courses after Graduation in Engineering</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-after-BCom">Courses after BCom</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-after-BSc">Courses after BSc</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-after-BA">Courses after BA</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-after-BBA">Courses after BBA</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-after-BCA">Courses after BCA</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Diploma-courses-after-10th">Diploma courses after 10th</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Diploma-Courses-after-12th">Diploma Courses after 12th</a></li>
                </ul>
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
                                <asp:Repeater ID="grd_Records" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-") + "/Courses/" + Eval("strTitle").ToString().Replace(" ","-"))%>' >
                                                <%# Eval("strTitle") %></a>
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
                <div class="google-ad">
                     <script type="text/javascript"><!--
    google_ad_client = "ca-pub-4037987430386783";
    /* Eduvidya-Link-728&#42;15 */
    google_ad_slot = "4438952914";
    google_ad_width = 728;
    google_ad_height = 15;
    //-->
                </script>
                <script type="text/javascript" src="https://pagead2.googlesyndication.com/pagead/show_ads.js">
                </script>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<%--                 <asp:ListView ID="grd_Records" runat="server" GroupPlaceholderID="groupPlaceHolder1"
                                    ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
                                    <LayoutTemplate>

                                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="grd_Records" PageSize="15" class="pagination">
                                            <Fields>
                                                <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                                            </Fields>
                                        </asp:DataPager>
                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                        <asp:DataPager ID="DataPager2" runat="server" PagedControlID="grd_Records" PageSize="15" class="pagination">
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
                                            <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-") + "/Courses/" + Eval("strTitle").ToString().Replace(" ","-"))%>' >
                                                <%# Eval("strTitle") %></a>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView> --%>
