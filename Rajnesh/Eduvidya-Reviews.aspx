<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Eduvidya-Reviews.aspx.cs"
    Inherits="Education_Reviews" ValidateRequest="false" %>

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
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/responsive.css" rel="stylesheet" />
    <link href="/css/menu.css" rel="stylesheet" />
    <link href="/css/jquery.raty.css" rel="stylesheet" />
    
    <link href="css/reveal.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript"  src="js/ckeditor.js"></script>

    <%--<link href="https://www.eduvidya.com/CommentBox/css/reveal.css" rel="stylesheet" type="text/css" />--%>
    <%--<script src="https://www.eduvidya.com/ckeditor/ckeditor.js" type="text/javascript"></script>--%>
    <%--<script type="text/javascript" src="https://cdn.ckeditor.com/4.4.7/standard/ckeditor.js"></script>--%>

    <%-- <script type="text/javascript" src="https://www.eduvidya.com/Star_Rating/js/jquery.min.js?v=1.4.2"></script>
    <script type="text/javascript" src="https://www.eduvidya.com/Star_Rating/js/jquery-ui.custom.min.js?v=1.8"></script>
    <script type="text/javascript" src="https://www.eduvidya.com/Star_Rating/js/jquery.ui.stars.js?v=3.0.0b38"></script>
    <link rel="stylesheet" type="text/css" href="https://www.eduvidya.com/Star_Rating/css/jquery.ui.stars.css?v=3.0.0b38" />--%>
    <%--<style>.ddlbox
        {
            border: 1px solid #ccc;
            background-color: #fff;
            height: 25px;
            min-width: 101px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
        }
        
        .ddlbox:focus
        {
            border: 1px solid #ccc;
            background-color: #efefef;
            height: 25px;
            min-width: 101px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
        }</style>--%>
    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>--%>
    <script type="text/javascript" src="js/jquery-3.6.0.min.js"></script>
    <script type="text/javascript" src="/js/jquery.bxslider.js"></script>
    <script type="text/javascript" src="/js/menu.js"></script>
    <script type="text/javascript" src="/js/jquery.raty.js"></script>
    <script type="text/javascript" src="/js/jquery.responsiveTabs.js"></script>
    <script type="text/javascript" src="/js/labs.js"></script>
    <script type="text/javascript" src="js/jquery.reveal.js"></script>
    <%--<script src="https://www.eduvidya.com/CommentBox/js/jquery.reveal.js" type="text/javascript"></script>--%>
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
    <script type="text/javascript">
        $.fn.raty.defaults.path = 'images';
        $(function () {
            $('#score').raty({ score: 4 });
            $('#score-commentbox').raty({ score: 0 });
            $('#campus').raty({ score: 0 });
            $('#classrooms').raty({ score: 0 });
            $('#hostel').raty({ score: 0 });
            $('#labs').raty({ score: 0 });
            $('#library').raty({ score: 0 });
            $('#approchability').raty({ score: 0 });
            $('#qualification').raty({ score: 0 });
            $('#teaching-style').raty({ score: 0 });
            $('#salary').raty({ score: 0 });
            $('#students-placed').raty({ score: 0 });
            CKEDITOR.replace('editor1');
        });


    </script>
    <script type="text/javascript">
        $(function () {
            $(".RateIt").children().hide();
            $('[id=ddl_FactorValues]').hide();
            $(".RateIt")
				.stars({
				    inputType: "select",
				    cancelValue: 0,
				    cancelShow: false
				})
        });
    </script>

    <script type="text/javascript">
        function fn_getPopup() {
            $('#Review_Box').reveal($(this).data());
        }

        function fn_ShowMessage() {
            $('#Review_MessageBox').reveal($(this).data());
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div id="container">
            <div class="wrapper inner-page" id="special-page">
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
                                    <img src="/images/google-plus-icon-24.png" alt="google plus" style="height: 23px; width: 23px;" /></a>
                            </li>
                            <li>
                                <a href="https://www.facebook.com/pages/Eduvidyacom/521045274616088" target="_blank" rel="nofollow">
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
                                <input type="submit" name="sa" value="Search" class="btnSubmit bg-red" />
                            </div>
                            <input name="siteurl" type="hidden" value="www.eduvidya.com/"><input name="ref" type="hidden" value="" /><input name="ss" type="hidden" value="" />
                        </form>
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
                        <li><a href="#">Home</a></li>
                        <li class="active">Reviews</li>
                    </ul>
                </div>
                <div id="content">
                    <div class="left-side">
                        <div class="reviews-logo">
                            <a href="https://www.eduvidya.com">
                                <img src="images/EducationHelp.png" alt="Education-help" width="110px"><span>EduVidya.com</span></a>
                            <span class="tagline">Reviews!</span>
                        </div>
                    </div>
                    <div class="right-side">
                        <div class="box">
                            <div class="heading">
                                <p>Review Details</p>
                            </div>
                            <div class="box-content" id="tbl_EduCationReviews" runat="server">
                                <p>
                                    <asp:Literal ID="ltl_InstitutionName" runat="server"></asp:Literal>
                                </p>
                                <div>
                                    <asp:Info ID="info1" runat="server" />
                                    <asp:Error ID="error1" runat="server" />
                                </div>

                                <div>
                                    <asp:ValidationSummary ID="vs_EducationHelp" ValidationGroup="vgEduvidyaReviews"
                                        runat="server" HeaderText="Please fill following details to complete the registration process." />
                                </div>
                                <div class="review-details">

                                    <span>You are:</span>
                                    <span>
                                        <asp:RadioButtonList ID="rd_StudentType" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Student" Value="Student" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text=" Alumnus" Value="Alumnus"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </span>
                                </div>
                                <div class="height-10"></div>
                                <div class="review-details">
                                    <span>Review Title:</span>
                                    <span>
                                        <asp:TextBox ID="txtTitle" runat="server" CssClass="txtbox" Width="301px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvTitle" ValidationGroup="vgEduvidyaReviews" runat="server"
                                            ErrorMessage="Title" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtTitle">&nbsp;</asp:RequiredFieldValidator>
                                    </span>
                                </div>
                                <div class="height-10"></div>
                                <div class="ckeditor">
                                    <asp:TextBox ID="editor1" runat="server" TextMode="MultiLine" name="editor1"></asp:TextBox>

                                </div>
                                <div class="height-10"></div>
                                <div class="rating">
                                    <div class="sub-heading">Ratings</div>
                                    <div class="rating-inner-dv">
                                        <asp:Repeater ID="rpt_ReviewFactors" runat="server" OnItemDataBound="rpt_ReviewFactors_ItemDataBound">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hf_FactorID" runat="server" Value='<%# Eval("iID") %>' />
                                                <p class="sub-title">
                                                    <%# Eval("strTitle") %>
                                                </p>

                                                <asp:Repeater ID="rpt_Ratings" runat="server">
                                                    <ItemTemplate>

                                                        <div class="col-1"><%# Eval("strTitle") %></div>
                                                        <asp:HiddenField ID="hf_ReviewFactorID" runat="server" Value='<%# Eval("iID") %>' />
                                                        <div id='<%# Eval("strTitle").ToString().Trim().Replace(' ','-').ToLower() %>' class="col-2 ">
                                                            <asp:DropDownList ID="ddl_FactorValues" runat="server" CssClass="RateIt">
                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>


                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>
                                    <div class="height-10"></div>
                                    <div class="sub-heading">Security Checking</div>
                                    <div class="captcha-code">
                                        <p>Verification Code</p>
                                        <div>
                                            <asp:Image ID="imgVerificationCode" runat="server" ImageUrl="RandomImage.aspx" Width="161"
                                                Height="49" EnableViewState="false" /><br />
                                            Can't see?
                                                    <asp:LinkButton ID="lbRefresh" CssClass="Company" runat="server" CausesValidation="False"
                                                        OnClick="lbRefresh_Click" ValidationGroup="vgEduvidyaReviews">Refresh!</asp:LinkButton><br />
                                            <asp:TextBox ID="txtSecurityCode" runat="server" ValidationGroup="vgEduvidyaReviews"
                                                CssClass="txtbox" Width="140px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvSecurityCode" runat="server" ControlToValidate="txtSecurityCode"
                                                ValidationGroup="vgEduvidyaReviews" ErrorMessage="Verification Code" Display="Dynamic">&nbsp; </asp:RequiredFieldValidator><br />

                                        </div>
                                    </div>
                                    <div class="height-10"></div>
                                    <div class="post-review">
                                        <asp:Button ID="btn_Submit" runat="server" Text="Post Review" CssClass="btnSubmit"
                                            OnClick="btn_Submit_Click" ValidationGroup="vgEduvidyaReviews"></asp:Button>

                                    </div>
                                </div>
                                <div class="height-10"></div>
                            </div>
                            <div id="Review_Box" class="reveal-modal xlarge">
                                <asp:Literal ID="ltl_MessageBox" runat="server"></asp:Literal>
                                <table width="541px" cellpadding="4" cellspacing="4" border="0" id="tbl_UserDetails"
                                    runat="server" align="center">
                                    <tr>
                                        <td align="left" colspan="4" style="padding-left: 5px">
                                            <asp:ValidationSummary ID="vs_UserReviews" ValidationGroup="vg_EduUserReview" runat="server"
                                                HeaderText="Please fill following details to complete the Review." />
                                            <br />
                                            <h1>Please Provide more details about you to complete the Review</h1>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="170px" align="left">
                                            <b>Name</b>
                                        </td>
                                        <td width="10px">:
                                        </td>
                                        <td align="left" width="170px">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="txtbox"></asp:TextBox>
                                        </td>
                                        <td align="left" width="25px">
                                            <asp:RequiredFieldValidator ID="rfvName" ValidationGroup="vg_EduUserReview" runat="server"
                                                ErrorMessage="Name" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtName">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="170px" align="left">
                                            <b>Email</b>
                                        </td>
                                        <td width="10px">:
                                        </td>
                                        <td align="left" width="210px">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txtbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvEmail" ValidationGroup="vg_EduUserReview" runat="server"
                                                ErrorMessage="Email" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtEmail">&nbsp;</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                    ID="revEmail" runat="server" ErrorMessage="Invalid E-mail ID" ControlToValidate="txtEmail"
                                                    Display="Dynamic" SetFocusOnError="true" ValidationGroup="vg_EduUserReview" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="170px" align="left">
                                            <b>Phone</b>
                                        </td>
                                        <td width="10px">:
                                        </td>
                                        <td align="left" width="210px">
                                            <asp:TextBox ID="txtPhone" runat="server" CssClass="txtbox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvPhone" ValidationGroup="vg_EduUserReview" runat="server"
                                                ErrorMessage="Phone" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtPhone">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="left">
                                            <asp:LinkButton ID="btn_UserDetails" runat="server" Text="Submit" CssClass="btnSubmit"
                                                OnClick="btn_UserDetails_Click" ValidationGroup="vg_EduUserReview"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                                <a class="close-reveal-modal">&#215;</a>
                            </div>
                            <div id="Review_MessageBox" class="reveal-modal xlarge">
                                <asp:Literal ID="ltl_ReviewMessageBox" runat="server"></asp:Literal>
                                <a class="close-reveal-modal">&#215;</a>
                            </div>
                        </div>
                    </div>
                    <div class="height-10"></div>
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

            </div>
        </div>
    </form>
</body>
</html>
