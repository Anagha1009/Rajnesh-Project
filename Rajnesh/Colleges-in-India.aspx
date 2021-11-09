<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Colleges-in-India.aspx.cs" Inherits="City_Places" %>

<%@ Register Src="UserControls/Competition.ascx" TagName="Competition" TagPrefix="asp" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="Pager" %>
<%@ Register Src="UserControls/CompareBox.ascx" TagName="CompareBox" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Top Colleges in India 2021 list for MBA, Engineering, Medical, Law</title>
    <meta name="Description" content="Get List of Top Colleges in India 2021 for MBA, Engineering, Medical, Commerce and Law" />
    <meta name="Keywords" content="Top Colleges in India" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <div class="box">
        <div class="heading"><a href="#">List of Top Colleges in India</a></div>
        <div class="box-content">
            <div class="search">
                <div class="course-type">
                    <asp:DropDownList ID="ddl_Category" runat="server"
                        CssClass="dropbox">
                    </asp:DropDownList>
                </div>
                <div class="college-location">
                    <asp:DropDownList ID="ddl_City" runat="server"
                        CssClass="dropbox">
                    </asp:DropDownList>
                </div>
                <div class="search-btn">
                    <asp:Button ID="btnSearch" runat="server"
                        ValidationGroup="vg_search" Text="Search"
                        CssClass="btnSubmit" OnClick="btnSearch_Click" />
                </div>
            </div>
            <div class="height-10"></div>
            <div class="rating">
                <div id="score" style="cursor: pointer;">
                    <asp:ToolkitScriptManager
                        ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
                    <div class="Ratingleft">
                        <asp:Rating ID="rt_Rate" href="rt_Rate_Changed" runat="server" StarCssClass="StarCss" FilledStarCssClass="FilledStarCss" EmptyStarCssClass="EmptyStarCss"
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
                <script src="/js/button.js" type="text/javascript"></script>
               <%-- <script type="text/javascript"
                    src="https://w.sharethis.com/button/buttons.js"></script>--%>
                <script type="text/javascript">

                    stLight.options({
                        publisher: "48258661-ca69-42d4-831c-4dc41b9328a1"

                    });</script>
                <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large' displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large' displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
            </div>
            <div class="height-10"></div>
            <div class="list">
                <p>
                    Given below is the list of all the Top Colleges in India 

2021 providing MBA, Engineering, Medical, law and other courses. India is home 

to one of the largest student communities in the world. It is no surprise that 

it also has a huge number of colleges. These colleges offer a wide range of 

courses to millions of students. Whether you want to pursue a diploma or degree 

or post graduate course, there is a college for everyone and everything.
                </p>
                <br />
                <p>
                    Colleges offering these courses are either run by private 

educational trusts or by the government. While most of the colleges follow a 

common norm for admissions, some have their own processes just like IIMs. The 

number of colleges in India is increasing every year to comply with the demands 

of increasing number of student enrollments.
                </p>
                <br />
                <ul>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Engineering-Colleges-in-India">Top Engineering Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-MBA-Colleges-in-India">Top MBA Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Medical-Colleges-in-India">Top Medical Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Architecture-Colleges-in-India">Top Architecture Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-MCA-Colleges-in-India">Top MCA Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Law-Colleges-in-India">Top Law Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Hotel-Management-Colleges-in-India">Top Hotel Management Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-MTech-Colleges-in-India">Top MTech Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Arts-Colleges-in-India">Top Arts Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Commerce-Colleges-in-India">Top Commerce Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Science-Colleges-in-India">Top Science Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Merchant-Navy-Institutes-in-India">Top Merchant Navy Institutes in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Fashion-Designing-Colleges-in-India">Top Fashion Designing Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Dental-Colleges-in-India">Top Dental Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-BBA-Colleges-in-India">Top BBA Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-BCA-Colleges-in-India">Top BCA Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-Pharmacy-Colleges-in-India">Top Pharmacy Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-100-Engineering-Colleges-in-India">Top 100 Engineering Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-100-MBA-Colleges-in-India">Top 100 MBA Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Top-100-Medical-Colleges-in-India">Top 100 Medical Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Private-Engineering-Colleges-in-India">Private Engineering Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Government-Engineering-Colleges-India">Government Engineering Colleges India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Private-Medical-Colleges-in-India">Private Medical Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Government-Medical-Colleges-in-India">Government Medical Colleges in India</a></li>
                </ul>
            </div>
            <div class="height-10"></div>
            <div class="college-compare">
                <asp:CompareBox ID="CompareI" runat="server" />
            </div>
              <br />
                <div class="google-ad" style="border: none; margin-top: 30px; text-align: left;">
                    <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
                    <!-- Eduvidya Responsive Link Unit -->
                    <ins class="adsbygoogle"
                        style="display: block"
                        data-ad-client="ca-pub-4037987430386783"
                        data-ad-slot="1159495717"
                        data-ad-format="link"></ins>
                    <script>
                        (adsbygoogle = window.adsbygoogle || []).push({});
                    </script>
                </div>
                <br />
            <div class="height-10"></div>
            <div class="filter-result">
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
                                                <div class="imgblock-inner">
                                                    <img src='<%#"https://www.eduvidya.com/admin/Upload/Institutes/" + Eval("strPhoto") %>' alt='<%# Eval("strTitle") %>' />
                                                </div>
                                            </div>
                                            <div class="contentblock">
                                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strTitle").ToString().Replace(" ","-").Replace(".","_")) %>'>
                                                    <%# Eval("strTitle") %></a><br />
                                                <span>
                                                    <%# ((bool)(Eval("strDesc").ToString().Length > 210)) == true ? Eval("strDesc").ToString().Substring(0, 210) + " ..." + "</p>" : Eval("strDesc")%>
                                                </span>
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

                <%--    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="grd_Records" PageSize="15" class="pagination">
                    <Fields>
                        <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                    </Fields>
                </asp:DataPager>
                <div class="detail-list">
                    <asp:UpdatePanel ID="pnllist" runat="server">
                        <ContentTemplate>
                            <ul>
                                <asp:ListView ID="grd_Records" runat="server" GroupPlaceholderID="groupPlaceHolder1"
                                    ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
                                    <LayoutTemplate>


                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>


                                    </LayoutTemplate>
                                    <GroupTemplate>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                    </GroupTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <div class="imgblock">
                                                <img src='<%#"https://www.eduvidya.com/admin/Upload/Institutes/" + Eval("strPhoto") %>' alt='<%# Eval("strTitle") %>' />
                                            </div>
                                            <div class="contentblock">
                                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strTitle").ToString().Replace(" ","-").Replace(".","_")) %>'>
                                                    <%# Eval("strTitle") %></a><br />
                                                <span>
                                                    <%# ((bool)(Eval("strDesc").ToString().Length > 210)) == true ? Eval("strDesc").ToString().Substring(0, 210) + " ..." + "</p>" : Eval("strDesc")%>
                                                </span>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView>
                            </ul>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:DataPager ID="DataPager2" runat="server" PagedControlID="grd_Records" PageSize="15" class="pagination">
                    <Fields>
                        <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                    </Fields>
                </asp:DataPager>--%>
            </div>
         <%--   <div class="desktop-ad google-ad  linkunitads">
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

            </div>--%>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_rightBottom" runat="Server">
</asp:Content>

