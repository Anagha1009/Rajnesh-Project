<%@ Page Title="" Language="C#" MasterPageFile="~/ClientDetailsMaster.master" AutoEventWireup="true"
    CodeFile="StudyabroadUniversityDetails.aspx.cs" Inherits="Studyabroad" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_bottomHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <%-- <script type="text/javascript">
         $(document).ready(function () {
             $('.slideshow').cycle({
                 fx: 'zoom',
                 sync: false,
                 delay: -2000
             });
         });
    </script>--%>
    <div class="box">
        <div class="heading">
            <a href="#">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></a>
        </div>
        <div class="box-content">
            <ul class="info">
                <li class="college-logo">
                    <asp:Image ID="imgUniversity" runat="server" />

                </li>
                <li class="college-detail">
                    <p>
                        <strong>Established In : </strong>
                        <asp:Literal ID="ltl_EstablishedIn" runat="server"></asp:Literal>
                    </p>
                    <p>
                        <strong>Affiliated To : </strong>
                        <asp:Literal ID="ltl_AffiliatedTo" runat="server"></asp:Literal>
                    </p>
                    <p>
                        <strong>Email : </strong>
                        <asp:Literal ID="ltl_Email" runat="server" Text='<%# Eval("strEmail") %>'></asp:Literal>
                    </p>
                    <p><strong>Website : </strong><a id="hlnk_Website" target="_blank" runat="server" rel="nofollow"></a></p>
                    <p></p>
                    <div class="social-share">
                        <script type="text/javascript">   var switchTo5x = true;</script>
                        <script type="text/javascript" src="js/button.js"></script>
                        <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                        <script type="text/javascript">   stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                        <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                            displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                                displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
                    </div>
                </li>
                <li class="college-image">
                    <%-- place image here--%>
                    <div class="slideshow">
                         <ul class="inner-bx-slider">
                        <asp:Repeater ID="rpt_Photos" runat="server">
                            <ItemTemplate>
                              <li>   <img src='<%# VirtualPathUtility.ToAbsolute("~/files/UniversityPhoto/" + Eval("strPhoto")) %>'
                                    alt='<%# Eval("strTitle") %>' /></li>
                            </ItemTemplate>
                        </asp:Repeater>
                             </ul>
                    </div>
                </li>
            </ul>
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
            <div class="height-10"></div>
            <div class="details-page-tab">

                <ul class="tab-section">
                    <li><a href="#about" title="about">About</a></li>
                    <li><a href="#admissions" title="admissions">Admissions</a></li>
                    <li><a href="#infrastructure" title="infrastructure">Infrastructure</a></li>
                    <li><a href="#placements" title="placements">Placements</a></li>
                    <li><a href="#courses" title="courses">Courses</a></li>
                    <li><a href="#ranking" title="ranking">Ranking</a></li>
                    <li><a href="#contact-details" title="contact-details">Contact Details</a></li>
                    <li><a href="#images" title="images">Images</a></li>
                    <li><a href="#videos" title="videos">Videos</a></li>
                </ul>
                 <div class="tab-section-inner-wrapper">
                    <div id="about" class="tab-content-inner" >
                         <a name="about"></a>
                        <p>
                            <asp:Literal ID="ltl_Details" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div id="admissions" class="tab-content-inner">
                        <a name="admissions"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_Admission" runat="server"></asp:Literal>
                                :</strong>
                        </p>
                   <br />
                        <p>
                            <asp:Literal ID="ltl_AdmissionDetails" runat="server"></asp:Literal>
                        </p>

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
                    </div>
                    <div id="infrastructure" class="tab-content-inner">
                           <a name="infrastructure"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_Infrastructure" runat="server"></asp:Literal></strong>
                        </p>
                        <br />
                        <p>
                            <asp:Literal ID="ltl_InfrastructureDetails" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div id="placements" class="tab-content-inner">
                        <a name="placements"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_Placements" runat="server"></asp:Literal></strong>
                        </p>
                        <br />
                        <p>
                            <asp:Literal ID="ltl_PlacementDetails" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div id="courses" class="tab-content-inner">
                             <a name="courses"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_Courses" runat="server"></asp:Literal></strong>
                        </p>
                        <ul>
                            <asp:DataList ID="rptr_UniversityCourses" runat="server" RepeatColumns="1" ItemStyle-Width="50%"
                                ItemStyle-VerticalAlign="Top" Width="100%">
                                <ItemTemplate>
                                    <li>
                                        <img src='<%# VirtualPathUtility.ToAbsolute("~/images/bullet_disk.png") %>' alt='<%# Eval("strTitle") %>'
                                            width="12" height="12" />

                                        <asp:HyperLink ID="hyp_Courses" runat="server" Font-Bold="true" Text='<%# Eval("strTitle") %>'
                                            NavigateUrl='<%# VirtualPathUtility.ToAbsolute("~/Studyabroad/" + RouteData.Values["Country"].ToString() + "/" + RouteData.Values["Name"].ToString() +  "/" + Eval("strTitle").ToString().Replace(" ","-")) %>'></asp:HyperLink>
                                    </li>
                                </ItemTemplate>
                            </asp:DataList>
                        </ul>
                    </div>
                    <div id="ranking" class="tab-content-inner">
                         <a name="ranking"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_Ranking" runat="server"></asp:Literal></strong>
                        </p>
                        <br />
                        <p>
                            <asp:Literal ID="ltl_RankingDetails" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div id="contact-details" class="tab-content-inner">
                          <a name="contact-details"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_Contact" runat="server"></asp:Literal></strong>
                        </p>
                        <br />
                        <address>
                            <p>
                                <asp:Literal ID="ltl_ContactDetails" runat="server"></asp:Literal>
                            </p>
                        </address>
                    </div>
                    <div id="images" class="tab-content-inner">
                           <a name="images"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_Images" runat="server"></asp:Literal></strong>
                        </p>
                        <br />
                        <ul>
                            <asp:DataList Width="100%" ID="dl_Images" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Table" RepeatColumns="5">
                                <ItemTemplate>
                                    <li>
                                        <a href='<%# VirtualPathUtility.ToAbsolute("~/files/UniversityPhoto/" + Eval("strPhoto")) %>'
                                            rel="prettyPhoto" target="_blank">
                                            <asp:Image runat="server" ID="imgSpecialImage" Height="80px" Width="80px" ImageUrl='<%# VirtualPathUtility.ToAbsolute("~/files/UniversityPhoto/" + Eval("strPhoto")) %>'
                                                AlternateText="Thumb" /></a>

                                        <asp:Label ID="lblImgTitle" runat="server" Text='<%# Eval("strTitle") %>'></asp:Label>
                                    </li>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                        </ul>
                    </div>
                    <div id="videos" class="tab-content-inner">
                        <a name="videos"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_Videos" runat="server"></asp:Literal></strong>
                        </p>
                        <br />
                        <ul>
                            <asp:DataList ID="dl_CollegeVideos" runat="server" RepeatColumns="2" Width="100%">
                                <ItemTemplate>
                                    <li>
                                        <div id='<%# Container.ItemIndex + 1 %>'>
                                            This text will be replaced
                                        </div>
                                        <script type='text/javascript'>
                                            jwplayer('<%# Container.ItemIndex + 1 %>').setup({
                                                'flashplayer': 'https://www.topmbaindia.com/JW_Player/player.swf',
                                                'file': '<%# Eval("strUrl") %>',
                                                'controlbar': 'bottom',
                                                'width': '325',
                                                'height': '270',
                                                'skin': 'https://www.topmbaindia.com/JW_Player/skewd.zip'
                                            });
                                        </script>
                                    </li>
                                </ItemTemplate>
                            </asp:DataList>
                        </ul>
                    </div>
                </div>

                <div id="ReviewsBox">
                </div>
            </div>
            <%-- <div class="google-ad"></div>
            <div class="height-10"></div>
            <div class="need-edu-loan"></div>
            <div class="height-10"></div>
            <div class="related-dv"></div>--%>
        </div>
    </div>

</asp:Content>
