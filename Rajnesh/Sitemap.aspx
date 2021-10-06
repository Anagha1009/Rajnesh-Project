<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Sitemap.aspx.cs" Inherits="AuthorBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Sitemap : Eduvidya.com</title>
    <meta name="Descripton" content="Sitemap : Eduvidya.com" />
    <meta name="Keywords" content="Sitemap : Eduvidya.com" />
    <%-- <style type="text/css">
        .Sitemap ul {
            list-style: none;
            padding: 0px;
            margin: 0px;
        }

            .Sitemap ul li {
                background-image: url(img/arrow-grey.png);
                background-repeat: no-repeat;
                background-position: left center;
                padding: 7px 5px 7px 30px;
            }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="src" runat="server">
                    </asp:ScriptManager>
    <div class="box">
        <div class="heading"><a href="#">Sitemaps</a></div>
        <div class="box-content">
            <div class="list">
                <ul>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/">Home</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Colleges-in-India.aspx">Colleges in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Courses-in-India.aspx">Courses in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Schools-in-India.aspx">Schools in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Entrance-Exams.aspx">Entrance Exams</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Studyabroad.aspx">Studyabroad</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Query-List.aspx">Query List</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Blogs.aspx">Blogs</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Search.aspx">Search</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Content/About-Us">About Us</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Content/Contact-Us">Contact Us</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Content/Advertise-With-Us">Advertise With Us</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Content/Privacy-Policy">Privacy Policy</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Content/Terms-and-Conditions">Terms and Conditions</a></li>
                </ul>
            </div>
        </div>

    </div>
    <%--<table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" valign="top" class="bestplace_head" itemprop="itemreviewed">
                <h1>
                    Sitemaps</h1>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" class="best_border">
                <div class="Sitemap">
                    <ul>
                        <li><a href="https://www.eduvidya.com/">Home</a></li>
                        <li><a href="https://www.eduvidya.com/Colleges-in-India.aspx">Colleges in India</a></li>
                        <li><a href="https://www.eduvidya.com/Courses-in-India.aspx">Courses in India</a></li>
                        <li><a href="https://www.eduvidya.com/Schools-in-India.aspx">Schools in India</a></li>
                        <li><a href="https://www.eduvidya.com/Entrance-Exams.aspx">Entrance Exams</a></li>
                        <li><a href="https://www.eduvidya.com/Studyabroad.aspx">Studyabroad</a></li>
                        <li><a href="https://www.eduvidya.com/Query-List.aspx">Query List</a></li>
                        <li><a href="https://www.eduvidya.com/Blogs.aspx">Blogs</a></li>
                        <li><a href="https://www.eduvidya.com/Search.aspx">Search</a></li>
                        <li><a href="https://www.eduvidya.com/Content/About-Us">About Us</a></li>
                        <li><a href="https://www.eduvidya.com/Content/Contact-Us">Contact Us</a></li>
                        <li><a href="https://www.eduvidya.com/Content/Advertise-With-Us">Advertise With Us</a></li>
                        <li><a href="https://www.eduvidya.com/Content/Privacy-Policy">Privacy Policy</a></li>
                        <li><a href="https://www.eduvidya.com/Content/Terms-and-Conditions">Terms and Conditions</a></li>
                    </ul>
                </div>
            </td>
        </tr>
        <tr>
            <td class="bottom">
                &nbsp;
            </td>
        </tr>
    </table>--%>
</asp:Content>
