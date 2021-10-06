<%@ Page Language="C#" MasterPageFile="~/ClientDetailsMaster.master" AutoEventWireup="true"
    CodeFile="CollegeCourseDetails.aspx.cs" Inherits="CollegeCourses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
    <%--DomTab Starts--%>
    <style type="text/css">
        @import "https://www.eduvidya.com/domtab/domtab.css";
    </style>
    <!--[if gt IE 6]>
	<style type="text/css">
		html>body ul.domtabs a:link,
		html>body ul.domtabs a:visited,
		html>body ul.domtabs a:active,
		html>body ul.domtabs a:hover{
			height:3em;
		}
	</style>
<![endif]-->
    <script type="text/javascript" src="https://www.eduvidya.com/domtab/domtab.js"></script>
    <%--DomTab End--%>
    <script src="https://www.eduvidya.com/JW_Player/jwplayer.js" type="text/javascript"></script>
    <%--    <script>
        $(document).ready(function () {
            $("#Reviews").click(function () {
                //$(this).animate(function(){
                $('html, body').animate({
                    scrollTop: $("#ReviewsBox").offset().top
                }, 2000);
                //});
            });
        });
</script>--%>
    <script src="https://www.eduvidya.com/js/jquery.cycle.all.latest.js" type="text/javascript"></script>
    <script src="https://www.eduvidya.com/js/jquery.prettyPhoto.js" type="text/javascript"
        charset="utf-8"></script>
    <script type="text/javascript" charset="utf-8">
        $(document).ready(function () {
            $("a[rel^='prettyPhoto']").prettyPhoto();
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('.slideshow').cycle({
                fx: 'zoom',
                sync: false,
                delay: -2000
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scrManager" runat="server">
    </asp:ScriptManager>
    <div class="box">
        <div class="box-content">
            <div class="details-page-tab">
                <ul class="tab-section">
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Colleges/" + RouteData.Values["College"].ToString())%>'>Description</a></li>
                    <li><a href='#'>Courses</a></li>
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
            <div class="filter-result">
                <br />
                <div class="detail-list">
                    <ul>
                        <li>
                            <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
                        </li>
                        <li>
                            <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
                            <asp:Literal ID="ltl_Fees" runat="server"></asp:Literal></li>
                        <li>
                            <h4>Syllabus</h4>
                            <asp:Literal ID="ltl_Syllabus" runat="server"></asp:Literal></li>
                        <li>
                            <h4>Eligibility</h4>
                            <asp:Literal ID="ltl_Eligibility" runat="server"></asp:Literal></li>
                        <li><a id="hyp_CollegeLink" runat="server"></a>

                            <asp:Literal ID="ltl_CollegeDetails" runat="server"></asp:Literal></li>
                    </ul>

                </div>
                <div>
                    <script type="text/javascript">                        var switchTo5x = true;</script>
                    <script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>
                    <script type="text/javascript">                        stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                    <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                        displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                            displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
                </div>

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
            <div class="related-dv">
                <div class="heading">
                    <p style="margin: 0px;">Similar Courses</p>
                </div>
                <ul>
                    <asp:Repeater ID="rpt_Courses" runat="server">

                        <ItemTemplate>
                            <li><a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-").Replace(".","_") + "/Courses/" + Eval("strTitle").ToString().Replace(" ","-"))%>'>
                                <%# Eval("strTitle") %></a>
                            </li>
                        </ItemTemplate>

                    </asp:Repeater>
                </ul>
            </div>

        </div>
    </div>

</asp:Content>
