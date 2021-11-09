<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="CollegeCourses.aspx.cs" Inherits="CollegeCourses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
    <div class="box">
        <div class="box-content">
            <div class="details-page-tab">
                <ul class="tab-section">
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString())%>'>Description</a></li>
                    <li><a class="active" href='#'>Courses</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString() + "#address") %>'>Address</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString() + "#map") %>'>Map</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString() + "#placements") %>'>Placements</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString() + "#admissions") %>'>Admissions</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString() + "#facilities") %>'>Facilities</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString() + "#photos") %>'>Photos</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString() + "#videos") %>'>Videos</a></li>
                    <li class="college-compare-tab"><a target="_blank" href="https://www.eduvidya.com/Education-Help.aspx">Need Admission Help?</a></li>
                </ul>

            </div>
            <br />
            <div class="filter-result">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>

                <ul>
                    <asp:Repeater ID="rpt_Courses" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString() + "/Courses/" + Eval("strTitle").ToString().Replace(" ","-"))%>'>
                                    <%# Eval("strTitle") %></a>
                                <br />
                                <%# ((bool)(Eval("strDesc").ToString().Length > 210)) == true ? Eval("strDesc").ToString().Replace("<p>", "").Replace("</p>", "").Substring(0, 210) + " ..." : Eval("strDesc")%>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <br />
                <a id="hyp_CollegeLink" runat="server"></a>
                <br />
                <asp:Literal ID="ltl_CollegeDetails" runat="server"></asp:Literal>
                <div>
                    <script type="text/javascript">                        var switchTo5x = true;</script>
                    <script type="text/javascript" src="/js/button.js"></script>
                    <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                    <script type="text/javascript">                        stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                    <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                        displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                            displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
                </div>
                <br />
            </div>

            <div class="height-10"></div>
            <div class="google-ad linkunitads">
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
            <div class="height-10"></div>
            <div class="need-edu-loan"><a target="_blank" href="https://www.eduvidya.com/Education-Help.aspx">Need Education Loan?</a></div>
            <div class="height-10"></div>

        </div>
    </div>

</asp:Content>
