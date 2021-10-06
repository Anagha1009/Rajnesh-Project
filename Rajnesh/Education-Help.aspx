<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Education-Help.aspx.cs" Inherits="Education_Help" %>

<%@ Register Src="UserControls/info.ascx" TagName="Info" TagPrefix="asp" %>
<%@ Register Src="UserControls/error.ascx" TagName="Error" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="https://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Eduvidya.com Initiative for Online Education Help</title>
    <link href='https://fonts.googleapis.com/css?family=Joti+One' rel='stylesheet' type='text/css' />
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 40 && charCode != 41 && charCode != 43 && charCode != 45 && charCode > 32 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>

    <link href="css/style.css" rel="stylesheet" />
    <link href="css/responsive.css" rel="stylesheet" />
    <link href="css/menu.css" rel="stylesheet" />
    <link href="css/jquery.raty.css" rel="stylesheet" />
    <script type="text/javascript"  src="js/ckeditor.js"></script>
    <script type="text/javascript" src="js/jquery-3.6.0.min.js"></script>
    <%--<script type="text/javascript" src="https://cdn.ckeditor.com/4.4.7/standard/ckeditor.js"></script>--%>
    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>--%>
    <script type="text/javascript" src="js/jquery.bxslider.js"></script>
    <script type="text/javascript" src="js/menu.js"></script>
    <%--<script type="text/javascript" src="js/jquery.raty.js"></script>--%>
    <script type="text/javascript" src="js/jquery.responsiveTabs.js"></script>
    <script type="text/javascript" src="js/labs.js"></script>



    <script type="text/javascript">
        $(document).ready(function () {
            $('.bxslider').bxSlider({
                controls: false,
                pager: false,
                slideWidth: 483,
                captions: true,
                auto: true,
                adaptiveHeight: false,
                speed: 1000,
            });
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#horizontalTab').responsiveTabs({
                rotate: false,
                startCollapsed: 'accordion',
                collapsible: 'accordion',
                disabled: [],

            });
        });
    </script>
    <script type="text/javascript">var switchTo5x = true;</script>
    <script type="text/javascript" src="js/button.js"></script>
    <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
    <script type="text/javascript">stLight.options({ publisher: "00d73c38-2d89-490c-996c-49ed57221ea3", doNotHash: false, doNotCopy: false, hashAddressBar: false });</script>
    <%-- <script>
        $.fn.raty.defaults.path = 'images';
        $(function () {
            $('#score').raty({ score: 4 });
            $('#score-commentbox').raty({ score: 0 });
        });
    </script>--%>
</head>
<body>

    <div id="container">
        <div id="special-page" class="wrapper inner-page">
            <div id="header">
                <div class="logo">
                    <h1><span class="red">Edu</span>Vidya.com</h1>
                </div>
                <div class="social-icon">
                    <ul>
                        <li>
                            <!-- Place this tag where you want the +1 button to render -->
                            <g:plusone size="medium"></g:plusone>
                            <!-- Place this tag after the last plusone tag -->
                            <script type="text/javascript">
                                (function () {
                                    var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
                                    po.src = 'https://apis.google.com/js/plusone.js';
                                    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
                                })();
                            </script>
                        </li>
                        <li>
                            <a href="https://plus.google.com/105985700899528723215/posts" target="_blank" rel="nofollow">
                                <img src="https://ssl.gstatic.com/images/icons/gplus-16.png" alt="google plus" style="height: 23px; width: 23px;" /></a>
                        </li>
                        <li>
                            <a href="https://www.facebook.com/pages/Eduvidyacom/521045274616088" target="_blank" rel="nofollow">
                                <img src="https://www.eduvidya.com/img/f.gif" style="height: 23px; width: 23px;" alt="facebook" />
                            </a>
                        </li>
                        <li>
                            <a href="https://twitter.com/eduvidya" target="_blank" rel="nofollow">
                                <img src="https://www.eduvidya.com/img/t.gif" style="height: 23px; width: 23px;" alt="twitter" />
                            </a>
                        </li>
                        <li>
                            <a href="https://eduvidya.blogspot.in/" target="_blank" rel="nofollow">
                                <img src="https://www.eduvidya.com/img/b.gif" style="height: 23px; width: 23px;" alt="blogspot" />
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
            <div id="cssmenu">

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
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Jobs-in-India-for-Freshers.aspx") %>'>Jobs</a></li>
                    <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Placement-Papers.aspx") %>'>Papers</a></li>
                    <li id="last"><a href='<%= VirtualPathUtility.ToAbsolute("~/Search.aspx") %>'>Search</a></li>
                </ul>

            </div>
            <div class="bread-cumb">
                <ul>
                    <li>

                        <asp:Literal ID="ltl_bredcrumbs" runat="server"></asp:Literal>
                    </li>

                </ul>
            </div>

            <form id="Form1" runat="server">
                <div id="content">
                    <div class="left-side">
                        <div class="reviews-logo">
                            <a href="https://www.eduvidya.com">
                                <img src="img/EducationHelp.png" alt="Education-help" width="110px" />
                                <span>EduVidya.com</span>

                            </a><span class="tagline">HelpDesk!</span>
                        </div>
                        <div class="height-10"></div>
                        <ul class="Tips">
                            <li>Free Career guidance from our Experts</li>
                            <li>Free Admission guidance</li>
                            <li>Free Admission & Exam Updates</li>
                            <li>Free Loan & Scholarship guidance</li>
                            <li>Read Articles and Blogs on Education</li>
                            <li>Get latest news on Education</li>
                        </ul>
                    </div>

                    <div class="right-side">
                        <div class="box">
                            <div class="heading">
                                <p>Register Below for Admission and Career Guidance</p>
                            </div>
                            <div class="box-content">
                                <asp:Info ID="info1" runat="server" />
                                <asp:Error ID="error1" runat="server" />
                                <div id="tbl_EduCationHelp" runat="server">
                                    <div>
                                        <asp:ValidationSummary ID="vs_EducationHelp" ValidationGroup="vgEducationHelp" runat="server"
                                            HeaderText="Please fill following details to complete the registration process." />
                                    </div>
                                    <div class="sub-heading">Personal Information</div>
                                    <div class="personal-details">
                                        <div class="col-1">First Name</div>
                                        <div class="col-2">
                                            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvFirstName" ValidationGroup="vgEducationHelp" runat="server"
                                                ErrorMessage="First Name" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtFirstName">&nbsp;</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="height-10"></div>
                                        <div class="col-1">Last Name</div>
                                        <div class="col-2">
                                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvLastName" ValidationGroup="vgEducationHelp" runat="server"
                                                ErrorMessage="Last Name" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtLastName">&nbsp;</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="height-10"></div>
                                        <div class="col-1">Email</div>
                                        <div class="col-2">
                                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvEmail" ValidationGroup="vgEducationHelp" runat="server"
                                                ErrorMessage="Email" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtEmail">&nbsp;</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                    ID="revEmail" runat="server" ErrorMessage="Invalid E-mail ID" ControlToValidate="txtEmail"
                                                    Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgEducationHelp" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
                                        </div>
                                        <div class="height-10"></div>
                                        <div class="col-1">Date of Birth</div>
                                        <div class="col-2">
                                            <div class="day">
                                                <asp:DropDownList ID="ddl_Day" runat="server" Width="80px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvDay" ValidationGroup="vgEducationHelp" runat="server"
                                                    ErrorMessage="Day" SetFocusOnError="true" Display="Dynamic" ControlToValidate="ddl_Day"
                                                    InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="month">
                                                <asp:DropDownList ID="ddl_Month" runat="server" Width="80px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvMonth" ValidationGroup="vgEducationHelp" runat="server"
                                                    ErrorMessage="Month" SetFocusOnError="true" Display="Dynamic" ControlToValidate="ddl_Month"
                                                    InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="year">
                                                <asp:DropDownList ID="ddl_Year" runat="server" Width="80px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvYear" ValidationGroup="vgEducationHelp" runat="server"
                                                    ErrorMessage="Year" SetFocusOnError="true" Display="Dynamic" ControlToValidate="ddl_Year"
                                                    InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                            </div>


                                        </div>
                                        <div class="height-10"></div>
                                        <div class="col-1">Phone</div>
                                        <div class="col-2">
                                            <asp:TextBox ID="txtPhone" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPhone" ValidationGroup="vgEducationHelp" runat="server"
                                                ErrorMessage="Phone" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtPhone">&nbsp;</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="height-10"></div>
                                        <div class="col-1">Current Qualification</div>
                                        <div class="col-2">
                                            <asp:DropDownList ID="ddlQualification" runat="server" Width="155px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvQualification" ValidationGroup="vgEducationHelp"
                                                runat="server" ErrorMessage="Current Qualification" SetFocusOnError="true" Display="Dynamic"
                                                ControlToValidate="ddlQualification" InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="height-10"></div>
                                        <div class="col-1">Education Interest</div>
                                        <div class="col-2">
                                            <asp:DropDownList ID="ddlEducationInterest" runat="server" Width="155px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvEducationInterest" ValidationGroup="vgEducationHelp"
                                                runat="server" ErrorMessage="Education Interest" SetFocusOnError="true" Display="Dynamic"
                                                ControlToValidate="ddlEducationInterest" InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="height-10"></div>
                                        <div class="col-1">City</div>
                                        <div class="col-2">
                                            <asp:DropDownList ID="ddlCity" runat="server" Width="155px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvCity" ValidationGroup="vgEducationHelp"
                                                runat="server" ErrorMessage="City" SetFocusOnError="true" Display="Dynamic"
                                                ControlToValidate="ddlCity" InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                        </div>

                                    </div>
                                    <div class="height-10"></div>
                                    <div class="sub-heading">Do you require Education Loan?</div>
                                    <div class="req-edu-loan">
                                        <p>
                                            <asp:CheckBox ID="chk_EducationLoan" runat="server" Text="" />
                                        </p>
                                        <asp:Label ID="lbl_EducationLoan" runat="server" Text="Yes, Please help me getting Education Loan for my Studies"
                                            AssociatedControlID="chk_EducationLoan"></asp:Label>
                                    </div>
                                    <div class="height-10"></div>

                                    <div class="sub-heading">Comment / Query</div>
                                    <div class="comment-dv">
                                        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" CssClass="txtarea"></asp:TextBox>
                                    </div>
                                    <div class="height-10"></div>
                                    <div class="sub-heading">Security Checking</div>
                                    <div class="captcha-code">
                                        <p>Verification Code</p>
                                        <asp:Image ID="imgVerificationCode" runat="server" ImageUrl="RandomImage.aspx" Width="161"
                                            Height="49" EnableViewState="false" /><br />
                                        <br />
                                        Can't see?
                                                    <asp:LinkButton ID="lbRefresh" CssClass="Company" runat="server" CausesValidation="False"
                                                        OnClick="lbRefresh_Click" ValidationGroup="vgEducationHelp">Refresh!</asp:LinkButton>
                                        <br />
                                        Enter the above code
                                      <asp:TextBox ID="txtSecurityCode" runat="server" ValidationGroup="vgEducationHelp"
                                          Width="140px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvSecurityCode" runat="server" ControlToValidate="txtSecurityCode"
                                            ValidationGroup="vgEducationHelp" ErrorMessage="Verification Code" Display="Dynamic">&nbsp; </asp:RequiredFieldValidator><br />

                                    </div>
                                    <div class="height-10"></div>
                                    <div class="post-review">
                                        <asp:Button ID="btn_Submit" runat="server" Text="Register" CssClass="btnSubmit"
                                            OnClick="btn_Submit_Click" ValidationGroup="vgEducationHelp"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="footer">

                    <marquee scrollamount="2"><asp:Literal ID="ltlContainer3" runat="server"></asp:Literal></marquee>
                    <div class="footer-divider">
                        <img src="https://www.eduvidya.com/InfiniteTrips/images/fotter_top.jpg" width="960"
                            height="19" alt="" />
                    </div>
                    <div class="footer-menu">
                        <ul>
                            <li><a href='<%= VirtualPathUtility.ToAbsolute("~/Content/About-Us")%>'>About us</a></li>
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
                        <span>Copyright © 2014-15 www.eduvidya.com
                        </span>
                    </div>
                </div>
            </form>

        </div>
    </div>

</body>
</html>
