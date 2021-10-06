<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Schools-in-India.aspx.cs" Inherits="Schools" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="Pager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Best Schools in India 2016, List, Top Ranking CBSE, ICSE, IB schools</title>
    <meta name="Description" content="Get List of Best Schools in India 2016 with Ranking. Also find CBSE, ICSE, IB and IGCSE Schools in India" />
    <meta name="Keywords" content="Schools in India" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <div class="box">
        <div class="heading"><a href="#">Best Schools in India 2016</a></div>
        <div class="box-content">
            <div class="search">
                <div class="course-type">
                    <asp:DropDownList ID="ddl_Category" runat="server" CssClass="dropbox">
                    </asp:DropDownList>
                </div>
                <div class="college-location">
                    <asp:DropDownList ID="ddl_City" runat="server" CssClass="dropbox">
                    </asp:DropDownList>
                </div>
                <div class="search-btn">
                    <asp:Button ID="btnSearch" runat="server" ValidationGroup="vg_search" Text="Search"
                        CssClass="btnSubmit" OnClick="btnSearch_Click" />
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
                <script type="text/javascript"> var switchTo5x = true;</script>
                <script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>
                <script type="text/javascript"> stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                    displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
            </div>
            <div class="height-10"></div>
            <div class="list">
                <p>
                    Given below is the list of all the best Schools in India 2016 under different boards like CBSE, ICSE, IB, IGCSE and State Boards. Indian schools offer an all inclusive educational experience from state board to CBSE to ICSE, you name it and these schools offer it. These schools impart education starting from playgroup to 12th standard. These schools are run and managed by government as well as private trusts. 
                </p>
                <br />
                <p>
                    The modern Indian schools have upped their levels and are imparting world class education along with equally good infrastructure. Joining them are the globally renowned international schools that have opened up their schools in India to offer global education methods. At one hand while the privately run schools are expensive, on the other hand government is offering free education for a lot of backward class students. 
                </p>
                <br />
                <ul>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/CBSE-Schools-in-India">CBSE Schools in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/ICSE-Schools-in-India">ICSE Schools in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/ICSE-Schools-in-Ahmedabad">ICSE Schools in Ahmedabad</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/ICSE-Schools-in-New-Delhi">ICSE Schools in New Delhi</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/ICSE-Schools-in-Mumbai">ICSE Schools in Mumbai</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/ICSE-Schools-in-Bangalore">ICSE Schools in Bangalore</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/ICSE-Schools-in-Hyderabad">ICSE Schools in Hyderabad</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/ICSE-Schools-in-Pune">ICSE Schools in Pune</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/CBSE-Schools-in-Mumbai">CBSE Schools in Mumbai</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/CBSE-Schools-in-New-Delhi">CBSE Schools in New Delhi</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/CBSE-Schools-in-Pune">CBSE Schools in Pune</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/CBSE-Schools-in-Hyderabad">CBSE Schools in Hyderabad</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/CBSE-Schools-in-Bangalore">CBSE Schools in Bangalore</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/CBSE-Schools-in-Chennai">CBSE Schools in Chennai</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-CBSE-Schools-in-Kolkata">CBSE Schools in Kolkata</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-CBSE-Schools-in-Chandigarh">CBSE Schools in Chandigarh</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-ICSE-Schools-in-Kolkata">ICSE Schools in Kolkata</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/CBSE-Schools-in-Noida">CBSE Schools in Noida</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/CBSE-Schools-in-Gurgaon">CBSE Schools in Gurgaon</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Boarding-Schools-in-India">Top Boarding Schools in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Play-Schools-in-Mumbai">Play Schools in Mumbai</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Play-Schools-in-Pune">Play Schools in Pune</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Play-Schools-in-Chennai">Play Schools in Chennai</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Play-Schools-in-Hyderabad">Play Schools in Hyderabad</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Play-Schools-in-Bangalore">Play Schools in Bangalore</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/IGCSE-Schools-in-Mumbai">IGCSE Schools in Mumbai</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/IGCSE-Schools-in-Pune">IGCSE Schools in Pune</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/IGCSE-Schools-in-Bangalore">IGCSE Schools in Bangalore</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/IGCSE-Schools-in-Hyderabad">IGCSE Schools in Hyderabad</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/IGCSE-Schools-in-Kolkata">IGCSE Schools in Kolkata</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/IGCSE-Schools-in-Chennai">IGCSE Schools in Chennai</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-IB-Schools-in-Mumbai">Top IB Schools in Mumbai</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-IB-Schools-in-Pune">Top IB Schools in Pune</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-IB-Schools-in-Bangalore">Top IB Schools in Bangalore</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-IB-Schools-in-Kolkata">Top IB Schools in Kolkata</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-IB-Schools-in-Hyderabad">Top IB Schools in Hyderabad</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-IB-Schools-in-Chennai">Top IB Schools in Chennai</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-IB-Schools-in-India">Top IB Schools in India</a></li>
                </ul>
            </div>
            <%--<div class="height-10"></div>
            <div class="college-compare">
                <asp:CompareBox ID="CompareI" runat="server" />
            </div>--%>
            <div class="height-10"></div>
            <div class="filter-result">

                <div class="detail-list">
                    <asp:UpdatePanel ID="pnllist" runat="server">
                        <ContentTemplate>
                            <div class="pagination">
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="btnMoreUpPrv" runat="server" Text="..." OnClick="lnkPrevPageNumber_Click" Visible="false" /></li>
                                    <asp:Repeater ID="rptPagesUp" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <asp:LinkButton ID="btnPage" pageno="<%# Container.DataItem %>" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server"><%# Container.DataItem %> </asp:LinkButton>
                                            </li>
                                        </ItemTemplate>

                                    </asp:Repeater>
                                    <li>
                                        <asp:LinkButton ID="btnMoreUpNxt" runat="server" Text="..." OnClick="lnkMorePageNumber_Click" Visible="false" /></li>
                                </ul>
                            </div>
                            <div class="detail-list">
                                <ul>
                                    <asp:Repeater ID="grd_Records" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <div class="imgblock">
                                                    <img src='<%# "https://www.eduvidya.com/admin/Upload/Schools/" + Eval("strPhoto") %>'
                                                        alt='<%# Eval("strTitle") %>' />
                                                </div>
                                                <div class="contentblock">
                                                    <a href='<%# VirtualPathUtility.ToAbsolute("~/Schools/" + Eval("strTitle").ToString().Replace(" ","-").Replace(".","_")) %>'
                                                        >
                                                        <%# Eval("strTitle") %></a><br />
                                                    <%# ((bool)(Eval("strDesc").ToString().Length > 210)) == true ? Eval("strDesc").ToString().Substring(0, 210) + " ..." + "</p>": Eval("strDesc")%>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <div class="pagination">
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="btnMoreDwnPrv" runat="server" Text="..." OnClick="lnkPrevPageNumber_Click" Visible="false" /></li>
                                    <asp:Repeater ID="rptPagesDwn" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <asp:LinkButton ID="btnPage" pageno="<%# Container.DataItem %>" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server"><%# Container.DataItem %> </asp:LinkButton>
                                            </li>
                                        </ItemTemplate>

                                    </asp:Repeater>
                                    <li>
                                        <asp:LinkButton ID="btnMoreDwnNxt" runat="server" Text="..." OnClick="lnkMorePageNumber_Click" Visible="false" /></li>
                                </ul>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
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
</asp:Content>
<%--           <asp:ListView ID="grd_Records" runat="server" GroupPlaceholderID="groupPlaceHolder1"
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
                                           <div class="imgblock">
                                                <img src='<%# "https://www.eduvidya.com/admin/Upload/Schools/" + Eval("strPhoto") %>'
                                                    alt='<%# Eval("strTitle") %>' />
                                            </div>
                                            <div class="contentblock">
                                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Schools/" + Eval("strTitle").ToString().Replace(" ","-").Replace(".","_")) %>'
                                                    class="rec_links">
                                                    <%# Eval("strTitle") %></a><br />
                                                <%# ((bool)(Eval("strDesc").ToString().Length > 210)) == true ? Eval("strDesc").ToString().Substring(0, 210) + " ..." + "</p>": Eval("strDesc")%>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView> --%>
