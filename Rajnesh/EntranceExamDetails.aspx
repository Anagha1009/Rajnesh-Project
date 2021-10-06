<%@ Page Language="C#" MasterPageFile="~/ClientDetailsMaster.master" AutoEventWireup="true"
    CodeFile="EntranceExamDetails.aspx.cs" Inherits="College_Details" %>

<%@ Register Src="UserControls/Exams.ascx" TagName="Exams" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <div class="box">
        <div class="heading">
            <a href="#">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </a>
        </div>
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
            <div class="height-10"></div>
            <div class="social-share">
                <script type="text/javascript">   var switchTo5x = true;</script>
                <script type="text/javascript" src="js/button.js"></script>
                <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                <script type="text/javascript">   stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                    displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
            </div>
            <div class="height-10"></div>

            <div class="details-page-tab">

                <ul class="tab-section">
                    <li><a href="#description" title="description">Description</a></li>
                    <li><a href="#registration" title="registration">Registration</a></li>
                    <li><a href="#dates" title="dates">Exam Dates</a></li>
                    <li><a href="#syllabus" title="syllabus">Syllabus</a></li>
                    <li><a href="#paperpattern" title="paperpattern">Paper Pattern</a></li>
                    <li><a href="#preparation" title="preparation">Preparation</a></li>
                    <li><a href="#notification" title="notification">Notification</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + RouteData.Values["Exam"].ToString() + "/Colleges") %>'>Colleges</a></li>
                    <li class="college-compare-tab"><a target="_blank" href="https://www.eduvidya.com/Education-Help.aspx">Need Admission Help?</a></li>

                </ul>
                <div class="tab-section-inner-wrapper">
                    <div id="description" class="tab-content-inner">
                        <a name="description"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_Title" runat="server" Visible="false"></asp:Literal></strong>
                            <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div id="registration" class="tab-content-inner">
                        <a name="registration"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_RegistraionTitle" runat="server"></asp:Literal></strong>
                            <asp:Literal ID="ltl_Admissions" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div id="dates" class="tab-content-inner">
                        <a name="dates"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_ExamTitle" runat="server"></asp:Literal></strong>
                            <asp:Literal ID="ltl_ExamDates" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <br />
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

                        </p>
                    </div>
                    <div id="syllabus" class="tab-content-inner">
                        <a name="syllabus"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_SyllabusTitle" runat="server"></asp:Literal></strong>
                            <asp:Literal ID="ltl_Syllabus" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div id="paperpattern" class="tab-content-inner">
                        <a name="paperpattern"></a>
                        <p>
                            <strong>Paper Pattern</strong>
                            <asp:Literal ID="ltl_PaperPattern" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div id="preparation" class="tab-content-inner">
                        <a name="preparation"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_PreparationTitle" runat="server"></asp:Literal></strong>
                            <asp:Literal ID="ltl_Preparation" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div id="notification" class="tab-content-inner">
                        <a name="notification"></a>
                        <p>
                            <strong>
                                <asp:Literal ID="ltl_NotificationTitle" runat="server"></asp:Literal></strong>
                            <asp:Literal ID="ltl_Notification" runat="server"></asp:Literal>
                        </p>
                    </div>

                </div>
            </div>

            <div class="height-10"></div>
            <div class="google-ad linkunitads">
                <script type="text/javascript">
                    google_ad_client = "ca-pub-4037987430386783";
                    /* Eduvidya-Link-728&#42;15 */
                    google_ad_slot = "4438952914";
                    google_ad_width = 728;
                    google_ad_height = 15;

                </script>
                <script type="text/javascript" src="https://pagead2.googlesyndication.com/pagead/show_ads.js">
                </script>
            </div>
            <div class="height-10"></div>


            <div class="need-edu-loan"><a target="_blank" href="https://www.eduvidya.com/Education-Help.aspx">Need Education Loan?</a></div>
            <div class="height-10"></div>
            <div class="related-dv">
                <asp:Exams ID="Exams1" runat="server" />
            </div>

        </div>
    </div>
</asp:Content>
