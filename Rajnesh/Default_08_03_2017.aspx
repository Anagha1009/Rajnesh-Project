<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="https://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="google-site-verification" content="JmA_tiqkXXQao8ccUtzg4hIk7Lgo-5CPEYirGG5lYXo" />
    <meta name="msvalidate.01" content="029BE21C3059AD7069834F952EDA60E8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Colleges|Schools|Universities|Exams|Courses|Distance Education|India|Eduvidya.com|
    </title>
    <meta name="Description" content="Search Universities,Colleges, Schools, Distance Education Courses and Exams in India for MBA, Engineering, Medical and Law" />
    <meta name="Keywords" content="universities, colleges, schools, distance education, entrance exams, mba, engineering, medical" />
    <%-- <link href="/css/Index.css" rel="stylesheet" type="text/css" />--%>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/responsive.css" rel="stylesheet" />
    <link href="/css/jquery.bxslider.css" rel="stylesheet" />
    <link href="/css/owl.carousel.css" rel="stylesheet" />
    <link href="/css/menu.css" rel="stylesheet" />

    <%-- <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-37028065-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'https://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

    </script>--%>
</head>
<body>

    <div id="container">
        <div class="wrapper">
            <div id="header">
                <div class="logo">
                    <h1><a href="https://www.eduvidya.com/"><span class="red">Edu</span>Vidya.com</a></h1>
                </div>
                <div class="social-icon">
                    <ul>
                        <li>
                            <div id="___plusone_0">
                                <iframe frameborder="0" hspace="0" marginheight="0" marginwidth="0" scrolling="no" tabindex="0" vspace="0" width="100%" id="I0_1426224307936" name="I0_1426224307936" src="https://apis.google.com/u/0/se/0/_/+1/fastbutton?usegapi=1&amp;size=medium&amp;origin=http%3A%2F%2Fwww.eduvidya.com&amp;url=http%3A%2F%2Fwww.eduvidya.com%2F&amp;gsrc=3p&amp;ic=1&amp;jsh=m%3B%2F_%2Fscs%2Fapps-static%2F_%2Fjs%2Fk%3Doz.gapi.en.jrg_qkTQnT4.O%2Fm%3D__features__%2Fam%3DAQ%2Frt%3Dj%2Fd%3D1%2Ft%3Dzcms%2Frs%3DAGLTcCNVkSIHJztg1koqoxSbgxxAOT0jQg#_methods=onPlusOne%2C_ready%2C_close%2C_open%2C_resizeMe%2C_renderstart%2Concircled%2Cdrefresh%2Cerefresh&amp;id=I0_1426224307936&amp;parent=http%3A%2F%2Fwww.eduvidya.com&amp;pfname=&amp;rpctoken=12595016" data-gapiattached="true" title="+1"></iframe>
                            </div>
                        </li>
                        <li>
                            <a href="https://plus.google.com/105985700899528723215/posts" target="_blank" rel="nofollow"
                                style="text-decoration: none;">
                                <img src="/images/google-plus-icon-24.png" alt="google plus" style="border: 0; width: 23px; height: 23px;" /></a>
                        </li>
                        <li>
                            <a href="https://www.facebook.com/pages/Eduvidyacom/521045274616088" target="_blank"
                                rel="nofollow">
                                <img src="/images/facebook-icon-24.png" style="height: 23px; width: 23px;" alt="facebook" />
                            </a>
                        </li>
                        <li>
                            <a href="https://twitter.com/eduvidya" target="_blank" rel="nofollow">
                                <img src="/images/twitter-icon-24.png" style="height: 23px; width: 23px;" alt="twitter" />
                            </a>
                        </li>
                        <li>
                            <a href="https://eduvidya.blogspot.in/" target="_blank" rel="nofollow">
                                <img src="/images/blogger-icon-24.png" style="height: 23px; width: 23px;" alt="blogspot" />
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="google-search right">
                    <form action="https://www.google.co.in" id="cse-search-box" target="_blank">
                        <div>
                            <input type="hidden" name="cx" value="partner-pub-4037987430386783:2143340918" />
                            <input type="hidden" name="ie" value="UTF-8" />
                            <input type="text" name="q" size="31" class="txtbox" />
                            <input type="submit" name="sa" value="Search" class="btnSubmit" />
                        </div>
                    </form>
                    <script type="text/javascript" src="https://www.google.co.in/coop/cse/brand?form=cse-search-box&amp;lang=en"></script>

                </div>
            </div>
            <div id='cssmenu'>
                <ul>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/") %>'>Home</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Colleges-in-India.aspx") %>'>Colleges</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Courses-in-India.aspx") %>'>Courses</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Schools-in-India.aspx") %>'>Schools</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exams.aspx") %>'>Exams</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/University.aspx") %>'>Universities</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Distance-University.aspx") %>'>Distance Education</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Studyabroad.aspx") %>'>Study Abroad</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Query-List.aspx") %>'>Queries</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Blogs.aspx") %>'>Blogs</a></li>
                 <%--   <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Jobs-in-India-for-Freshers.aspx") %>'>Jobs</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Placement-Papers.aspx") %>'>Papers</a></li>--%>
                    <li id="last"><a href='<%= VirtualPathUtility.ToAbsolute("~/Search.aspx") %>'>Search</a></li>

                </ul>
            </div>
            <div class="google-ad">
                <%-- <div style="float: left; width: 160px">

                    <script type="text/javascript"><!--
    google_ad_client = "ca-pub-4037987430386783";
    /* Eduvidya-Link-160&#42;90 */
    google_ad_slot = "7392419313";
    google_ad_width = 160;
    google_ad_height = 90;
    //-->
                    </script>
                    <script type="text/javascript" src="https://pagead2.googlesyndication.com/pagead/show_ads.js">
                    </script>
                </div>--%>
                <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
                <!-- Eduvidya-Responsive -->
                <ins class="adsbygoogle"
                    style="display: block"
                    data-ad-client="ca-pub-4037987430386783"
                    data-ad-slot="9747444518"
                    data-ad-format="auto"></ins>
                <script>
                    (adsbygoogle = window.adsbygoogle || []).push({});
                </script>
            </div>

            <form id="Form1" runat="server">
                <div id="content">
                    <div class="slider">
                        <div class="owl-carousel">
                            <asp:Repeater ID="rpt_Banner" runat="server">

                                <ItemTemplate>
                                    <div class="item">
                                        <img alt='<%# Eval("strTitle") %>'
                                            src='<%# VirtualPathUtility.ToAbsolute("~/admin/Upload/Category/") + Eval("strBigImage")%>' title=' <%# Eval("strTitle") %>' />

                                    <%# Eval("strShortDesc") %>
                                </div>
                                </ItemTemplate>

                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="news box">
                        <div class="heading">
                            <a href="News.aspx">News</a>
                        </div>
                        <ul>
                            <asp:Repeater ID="rpt_News" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <img src='<%# VirtualPathUtility.ToAbsolute("~/admin/Upload/News/") + Eval("strPhoto")%>'
                                            alt='<%# Eval("strTitle") %>'><a href='<%# VirtualPathUtility.ToAbsolute("~/News/" + Eval("strTitle").ToString().Replace(" ","-")) %>'><%# Eval("strTitle") %></a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>

                    <asp:Repeater ID="dl_Category" runat="server" OnItemDataBound="dl_Category_ItemDataBound">
                        <ItemTemplate>
                            <div class="row clr"></div>
                            <div class='<%# Eval("strTitle").ToString().Replace(' ','-') +" box" %>'>
                                <div class="heading">
                                    <img src='<%# VirtualPathUtility.ToAbsolute("~/admin/Upload/Category/") + Eval("strSmallImage")%>' alt='<%# Eval("strTitle") %>' height="20px" width="20px" />
                                    <a href='<%# Eval("strUrl") %>'><%# Eval("strTitle") %></a>
                                </div>
                                <div class="content">
                                    <p>
                                        <img src='<%# VirtualPathUtility.ToAbsolute("~/admin/Upload/Category/") + Eval("strMediumImage")%>' title='<%# Eval("strTitle") %>' height="45" width="60" alt='<%# Eval("strTitle") %>' />
                                        <%# Eval("strLongDesc") %>
                                    </p>
                                    <asp:HiddenField ID="hf_CategoryID" runat="server" Value='<%# Eval("iID") %>' />
                                    <ul>
                                        <asp:Repeater ID="rpt_Links" runat="server">
                                            <ItemTemplate>
                                                <li class="round-arrow-bullet">
                                                    <a href='<%# Eval("strUrl") %>'><%# Eval("strTitle") %></a>
                                                </li>
                                            </ItemTemplate>

                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </ItemTemplate>
                        <AlternatingItemTemplate>

                            <div class='<%# Eval("strTitle").ToString().Replace(' ','-') +" box" %>'>
                                <div class="heading">
                                    <img src='<%# VirtualPathUtility.ToAbsolute("~/admin/Upload/Category/") + Eval("strSmallImage")%>' alt='<%# Eval("strTitle") %>' height="20px" width="20px" />
                                    <a href='<%# Eval("strUrl") %>'><%# Eval("strTitle") %></a>
                                </div>
                                <div class="content">
                                    <p>
                                        <img src='<%# VirtualPathUtility.ToAbsolute("~/admin/Upload/Category/") + Eval("strMediumImage")%>' title='<%# Eval("strTitle") %>' height="45" width="60" alt='<%# Eval("strTitle") %>' />
                                        <%# Eval("strLongDesc") %>
                                    </p>
                                    <asp:HiddenField ID="hf_CategoryID" runat="server" Value='<%# Eval("iID") %>' />
                                    <ul>
                                        <asp:Repeater ID="rpt_Links" runat="server">
                                            <ItemTemplate>
                                                <li class="round-arrow-bullet">
                                                    <a href='<%# Eval("strUrl") %>'><%# Eval("strTitle") %></a>
                                                </li>
                                            </ItemTemplate>

                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </AlternatingItemTemplate>

                    </asp:Repeater>

                    <div class="row clr"></div>
                    <div class="universities carousel">
                        <h2>Universities</h2>
                        <ul>
                            <asp:Repeater ID="rpt_University" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="image-dv">
                                            <div class="image-dv-inner">
                                                <img src='<%# "https://www.eduvidya.com/admin/Upload/University/" + Eval("strImage")%>'
                                                    alt='<%# Eval("strTitle") %>' />
                                            </div>
                                        </div>
                                        <a href='<%# VirtualPathUtility.ToAbsolute("~/University/" + Eval("strTitle").ToString().Replace(" ","-")) %>'>
                                            <%# Eval("strTitle") %></a>
                                    </li>
                                </ItemTemplate>

                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="row clr"></div>
                    <div class="institutes carousel">
                        <h2>Institutes</h2>
                        <ul>
                            <asp:Repeater ID="rpt_HomeFeaturedInstitutes" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="image-dv">
                                            <div class="image-dv-inner">
                                                <img src='<%# "https://www.eduvidya.com/admin/Upload/Institutes/" + Eval("strPhoto")%>'
                                                    alt='<%# Eval("strTitle") %>' />
                                            </div>
                                        </div>
                                        <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strTitle").ToString().Replace(" ","-")) %>'>
                                            <%# Eval("strTitle") %></a> </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="row clr"></div>
                    <div class="schools carousel">
                        <h2>Schools</h2>
                        <ul>
                            <asp:Repeater ID="rpt_Schools" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="image-dv">
                                            <div class="image-dv-inner">
                                                <img src='<%# "https://www.eduvidya.com/admin/Upload/Schools/" + Eval("strPhoto")%>'
                                                    alt='<%# Eval("strTitle") %>' />
                                            </div>
                                        </div>
                                        <a href='<%# VirtualPathUtility.ToAbsolute("~/Schools/" + Eval("strTitle").ToString().Replace(" ","-")) %>'>
                                            <%# Eval("strTitle") %></a> </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="row clr"></div>
                    <div class="most-search-queries">
                        <h2>Most Searched Queries</h2>
                        <ul>
                            <asp:Repeater ID="rpt_QueryList" runat="server">
                                <ItemTemplate>
                                    <li><a href='<%# VirtualPathUtility.ToAbsolute("~/" + Eval("strTitle").ToString().Replace(" ","-")) %>'><%# Eval("strTitle") %></a></li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <li><a href="Query-List.aspx">more...</a></li>
                                </FooterTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </form>
            <div id="footer">
                <div class="google-ad">
                    <p>
                        <%-- <script type="text/javascript"><!--
    google_ad_client = "ca-pub-4037987430386783";
    /* Eduvidya-Link-160&#42;90 */
    google_ad_slot = "7392419313";
    google_ad_width = 160;
    google_ad_height = 90;
    //-->
                        </script>
                        <script type="text/javascript" src="https://pagead2.googlesyndication.com/pagead/show_ads.js">
                        </script>--%>

                        <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
                        <!-- Eduvidya-Responsive -->
                        <ins class="adsbygoogle"
                            style="display: block"
                            data-ad-client="ca-pub-4037987430386783"
                            data-ad-slot="9747444518"
                            data-ad-format="auto"></ins>
                        <script>
                            (adsbygoogle = window.adsbygoogle || []).push({});
                        </script>
                    </p>
                </div>
                <div class="footer-divider">
                    <img src="images/fotter_top.jpg" width="960" height="19" alt="">
                </div>
                <div class="footer-menu">
                    <ul>
                        <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Content/About-Us")%>'>About us</a></li>
                        <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Our-Team.aspx")%>'>Our Team</a></li>
                        <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Content/Contact-Us")%>'>Contact us</a></li>
                        <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Content/Advertise-With-Us")%>'>Advertise
                                                                            With Us</a></li>
                        <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Content/Privacy-Policy")%>'>Privacy
                                                                            policy</a></li>
                        <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Content/Terms-and-Conditions")%>'>Terms & Conditions</a></li>
                        <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Sitemap.aspx")%>'>Sitemap</a></li>
                    </ul>
                </div>
                <div class="copyright-text">
                    <span>Copyright © 2013-2016-17. www.eduvidya.com</span>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.bxslider.js"></script>
    <script type="text/javascript" src="js/owl.carousel.min.js"></script>
    <script type="text/javascript" src="js/menu.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.owl-carousel').owlCarousel({
                loop:true,
                items : 1,
                margin:0,
                nav:false,
                dots: true,
                autoplay: true     
            })
        });
    </script>
</body>
</html>
<%--    <asp:DataList ID="dl_Category" runat="server" RepeatColumns="2" OnItemDataBound="dl_Category_ItemDataBound"
                        Width="100%" CellPadding="4" CellSpacing="4" RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <div class='<%# Eval("strTitle").ToString().Replace(' ','-') +" box" %>'>
                                <div class="heading">
                                    <img src='<%# VirtualPathUtility.ToAbsolute("~/admin/Upload/Category/") + Eval("strSmallImage")%>' alt='<%# Eval("strTitle") %>' height="20px" width="20px" />
                                    <a href='<%# Eval("strUrl") %>'><%# Eval("strTitle") %></a>
                                </div>
                                <div class="content">
                                    <p>
                                        <img src='<%# VirtualPathUtility.ToAbsolute("~/admin/Upload/Category/") + Eval("strMediumImage")%>' title='<%# Eval("strTitle") %>' height="45" width="60" alt='<%# Eval("strTitle") %>' />
                                        <%# Eval("strLongDesc") %>
                                    </p>
                                    <asp:HiddenField ID="hf_CategoryID" runat="server" Value='<%# Eval("iID") %>' />
                                    <ul>
                                        <asp:Repeater ID="rpt_Links" runat="server">
                                            <ItemTemplate>
                                                <li class="round-arrow-bullet">
                                                    <a href='<%# Eval("strUrl") %>'><%# Eval("strTitle") %></a>
                                                </li>
                                            </ItemTemplate>

                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList> --%>
