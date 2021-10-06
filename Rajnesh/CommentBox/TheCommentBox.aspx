<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TheCommentBox.aspx.cs" Inherits="JQuery_tabs_TheCommentBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CSS3 & jQuery folder tabs - demo</title>
    <script src="http://www.eduvidya.com/CommentBox/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://www.eduvidya.com/CommentBox/Star_Rating/js/jquery-ui.custom.min.js?v=1.8"></script>
    <script type="text/javascript" src="http://www.eduvidya.com/CommentBox/Star_Rating/js/jquery.ui.stars.js?v=3.0.0b38"></script>
    <link rel="stylesheet" type="text/css" href="http://www.eduvidya.com/CommentBox/Star_Rating/css/jquery.ui.stars.css?v=3.0.0b38" />
    <link href="http://www.eduvidya.com/CommentBox/css/reveal.css" rel="stylesheet"
        type="text/css" />
    <link href="http://www.eduvidya.com/CommentBox/css/style.css" rel="stylesheet" type="text/css" />
    <script src="http://www.eduvidya.com/CommentBox/js/jquery.reveal.js" type="text/javascript"></script>
    <script type="text/javascript">
        function fn_getPopup() {
            $('#InfoBox').reveal($(this).data());
        }

        $(function () {
            $(".RateIt").children().hide();
            $(".RateIt")
				.stars({
				    inputType: "select",
				    cancelValue: 0,
				    cancelShow: false
				})
        });

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 40 && charCode != 41 && charCode != 43 && charCode != 45 && charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        $(document).ready(function () {
            $("#content div._tabbox").hide(); // Initially hide all content
            $("#tabs li:first").attr("id", "current"); // Activate first tab
            $("#content div:first").fadeIn(); // Show first tab content

            $('#tabs a').click(function (e) {
                e.preventDefault();
                if ($(this).closest("li").attr("id") == "current") { //detection for current tab
                    return
                }
                else {
                    $("#content div._tabbox").hide(); //Hide all content
                    $("#tabs li").attr("id", ""); //Reset id's
                    $(this).parent().attr("id", "current"); // Activate this
                    $('#' + $(this).attr('name')).fadeIn(); // Show content for current tab
                }
            });

            $(".ui-stars-star").live("click", function () {
                $("#hf_Rate").val($("input[name=ddl_Rating]").val());
            });

        });

        $(window).load(function () {
            $(document).ready(function () {
                $(".hyp_Reply").click(function () {
                    var target = $(this).parent().children(".ReplyBox");
                    $(target).slideToggle();
                });
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="theCommentBox">
        <ul id="tabs">
            <li><a href="#" name="tab1">Comments</a></li>
            <li><a href="#" name="tab2">Reviews</a></li>
            <li><a href="#" name="tab3">Questions</a></li>
        </ul>
        <div id="content">
            <div id="tab1" class="_tabbox">
                <asp:ValidationSummary ID="vs_Comments" ValidationGroup="vg_Comments" runat="server"
                    HeaderText="Please fill following details to Post Comment" />
                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                    <tr>
                        <td align="left" width="50%" valign="top">
                            <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                <tr>
                                    <td align="left" class="_titlebox">
                                        Name
                                    </td>
                                    <td width="5px" align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCommentName" runat="server" CssClass="txtBox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvName" ValidationGroup="vg_Comments" runat="server"
                                            ErrorMessage="Name" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtCommentName">&nbsp;</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="_titlebox">
                                        Email
                                    </td>
                                    <td width="5px" align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCommentEmail" runat="server" CssClass="txtBox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvEmail" ValidationGroup="vg_Comments" runat="server"
                                            ErrorMessage="Email" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtCommentEmail">&nbsp;</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Invalid E-mail ID"
                                            ControlToValidate="txtCommentEmail" Display="Dynamic" SetFocusOnError="true"
                                            ValidationGroup="vg_Comments" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="_titlebox">
                                        Mobile
                                    </td>
                                    <td width="5px" align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCommentMobile" runat="server" CssClass="txtBox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvMobile" ValidationGroup="vg_Comments" runat="server"
                                            ErrorMessage="Mobile" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtCommentMobile">&nbsp;</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                <tr>
                                    <td align="left" class="_titlebox">
                                        Comments :
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" CssClass="txtArea"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvComment" ValidationGroup="vg_Comments" runat="server"
                                            ErrorMessage="Comment" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtComment">&nbsp;</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Button ID="btn_Submit01" runat="server" Text="Submit" CssClass="btn_Submit"
                                            OnClick="btn_Submit_01_Click" ValidationGroup="vg_Comments" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Repeater ID="rpt_Comments" runat="server" OnItemCommand="rpt_Comments_ItemCommand"
                                OnItemDataBound="rpt_Comments_ItemDataBound">
                                <ItemTemplate>
                                    <div>
                                        <div style="float: left">
                                            <img src="http://www.eduvidya.com/CommentBox/img/Comment_03.png" width="50px" />
                                        </div>
                                        <div>
                                            <%# Eval("strDesc") %>
                                        </div>
                                    </div>
                                    <div style="clear: both;">
                                    </div>
                                    <div>
                                        <div style="float: left">
                                            <%# "<b>Posted By : </b>" + Eval("strName") %>
                                        </div>
                                        <div style="text-align: right">
                                            <%# "<b>Posted On : </b>" + Eval("dtDate", "{0:dddd MMMM yyyy}")%>
                                        </div>
                                    </div>
                                    <div style="padding: 20px 0px 20px 50px">
                                        <asp:HiddenField ID="hf_CommentID" runat="server" Value='<%# Eval("iID") %>' />
                                        <asp:HiddenField ID="hf_Type" runat="server" Value="Comment" />
                                        <asp:Repeater ID="rpt_Reply" runat="server">
                                            <ItemTemplate>
                                                <div>
                                                    <div style="float: left; padding-right: 5px">
                                                        <img src="http://www.eduvidya.com/CommentBox/img/Reply_01.png" width="25px" />
                                                    </div>
                                                    <div style="padding-top: 6px">
                                                        <%# Eval("strReply") %>
                                                    </div>
                                                </div>
                                                <div style="clear: both;">
                                                </div>
                                                <div style="padding-left: 30px">
                                                    <div style="float: left">
                                                        <%# "<b>Posted By : </b>" + Eval("strName") %>
                                                    </div>
                                                    <div style="text-align: right">
                                                        <%# "<b>Posted On : </b>" + Eval("dtDate", "{0:dddd MMMM yyyy}")%>
                                                    </div>
                                                </div>
                                                <div style="clear: both; height: 10px">
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div id="Contain9ner">
                                        <div class="hyp_Reply">
                                            Reply to this Comment</div>
                                        <div class="ReplyBox">
                                            <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                                <tr>
                                                    <td align="left" width="50%" valign="top">
                                                        <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                                            <tr>
                                                                <td align="left" class="_titlebox">
                                                                    Name
                                                                </td>
                                                                <td width="5px" align="center">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCommentReplyName" runat="server" CssClass="txtBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="_titlebox">
                                                                    Email
                                                                </td>
                                                                <td width="5px" align="center">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCommentReplyEmail" runat="server" CssClass="txtBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="_titlebox">
                                                                    Mobile
                                                                </td>
                                                                <td width="5px" align="center">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCommentReplyMobile" runat="server" CssClass="txtBox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                                            <tr>
                                                                <td align="left" class="_titlebox">
                                                                    Comments :
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtCommentReply" runat="server" TextMode="MultiLine" CssClass="txtArea"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="btn_Reply" runat="server" Text="Reply" CssClass="btn_Submit" CommandName="CommentReply"
                                                                        CommandArgument='<%# Eval("iID") %>' />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div style="clear: both; height: 20px">
                                        &nbsp;</div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="tab2" class="_tabbox">
                <asp:ValidationSummary ID="vs_Review" ValidationGroup="vg_Reviews" runat="server"
                    HeaderText="Please fill following details to Post Review" />
                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                    <tr>
                        <td align="left" width="50%" valign="top">
                            <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                <tr>
                                    <td align="left" class="_titlebox">
                                        Name
                                    </td>
                                    <td width="5px" align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReviewName" runat="server" CssClass="txtBox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvReviewName" ValidationGroup="vg_Reviews" runat="server"
                                            ErrorMessage="Name" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtReviewName">&nbsp;</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="_titlebox">
                                        Email
                                    </td>
                                    <td width="5px" align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReviewEmail" runat="server" CssClass="txtBox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvReviewEmail" ValidationGroup="vg_Reviews" runat="server"
                                            ErrorMessage="Email" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtReviewEmail">&nbsp;</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revReviewEmail" runat="server" ErrorMessage="Invalid E-mail ID"
                                            ControlToValidate="txtReviewEmail" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vg_Reviews"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="_titlebox">
                                        Mobile
                                    </td>
                                    <td width="5px" align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReviewMobile" runat="server" CssClass="txtBox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvReviewMobile" ValidationGroup="vg_Reviews" runat="server"
                                            ErrorMessage="Mobile" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtReviewMobile">&nbsp;</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <div id="Reviews_Box">
                                <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                    <tr>
                                        <td align="left">
                                            <asp:TextBox ID="txtReviewTitle" runat="server" CssClass="_txtBox" Text="Review Title"
                                                onFocus="if (value == 'Review Title') {value=''}"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvReviewTitle" ValidationGroup="vg_Reviews" runat="server"
                                                InitialValue="Review Title" ErrorMessage="Review Title" SetFocusOnError="true"
                                                Display="Dynamic" ControlToValidate="txtReviewTitle">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <div class="RateIt">
                                                <asp:DropDownList ID="ddl_Rating" runat="server" CssClass="ddlBox" EnableViewState="true">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hf_Rate" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:TextBox ID="txtReviewsDesc" runat="server" TextMode="MultiLine" CssClass="txtArea"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvReviewDetails" ValidationGroup="vg_Reviews" runat="server"
                                                ErrorMessage="Review Details" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtReviewsDesc">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Button ID="btn_Submit02" runat="server" Text="Submit" CssClass="btn_Submit"
                                                OnClick="btn_Submit_02_Click" ValidationGroup="vg_Reviews" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Repeater ID="rpt_Reviews" runat="server" OnItemCommand="rpt_Comments_ItemCommand"
                                OnItemDataBound="rpt_Comments_ItemDataBound">
                                <ItemTemplate>
                                    <div>
                                        <div style="float: left">
                                            <img src="http://www.eduvidya.com/CommentBox/img/Review_01.png" width="50px" />
                                        </div>
                                        <div>
                                            <%# Eval("strDesc") %>
                                        </div>
                                    </div>
                                    <div style="clear: both;">
                                    </div>
                                    <div>
                                        <div style="float: left">
                                            <%# "<b>Posted By : </b>" + Eval("strName") %>
                                        </div>
                                        <div style="text-align: right">
                                            <%# "<b>Posted On : </b>" + Eval("dtDate", "{0:dddd MMMM yyyy}")%>
                                        </div>
                                    </div>
                                    <div style="padding: 20px 0px 20px 50px">
                                        <asp:HiddenField ID="hf_CommentID" runat="server" Value='<%# Eval("iID") %>' />
                                        <asp:HiddenField ID="hf_Type" runat="server" Value="Comment" />
                                        <asp:Repeater ID="rpt_Reply" runat="server">
                                            <ItemTemplate>
                                                <div>
                                                    <div style="float: left; padding-right: 5px">
                                                        <img src="http://www.eduvidya.com/CommentBox/img/Reply_01.png" width="25px" />
                                                    </div>
                                                    <div style="padding-top: 6px">
                                                        <%# Eval("strReply") %>
                                                    </div>
                                                </div>
                                                <div style="clear: both;">
                                                </div>
                                                <div style="padding-left: 30px">
                                                    <div style="float: left">
                                                        <%# "<b>Posted By : </b>" + Eval("strName") %>
                                                    </div>
                                                    <div style="text-align: right">
                                                        <%# "<b>Posted On : </b>" + Eval("dtDate", "{0:dddd MMMM yyyy}")%>
                                                    </div>
                                                </div>
                                                <div style="clear: both; height: 10px">
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div id="Contain9ner">
                                        <div class="hyp_Reply">
                                            Reply to this Review</div>
                                        <div class="ReplyBox">
                                            <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                                <tr>
                                                    <td align="left" width="50%" valign="top">
                                                        <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                                            <tr>
                                                                <td align="left" class="_titlebox">
                                                                    Name
                                                                </td>
                                                                <td width="5px" align="center">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCommentReplyName" runat="server" CssClass="txtBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="_titlebox">
                                                                    Email
                                                                </td>
                                                                <td width="5px" align="center">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCommentReplyEmail" runat="server" CssClass="txtBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="_titlebox">
                                                                    Mobile
                                                                </td>
                                                                <td width="5px" align="center">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCommentReplyMobile" runat="server" CssClass="txtBox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                                            <tr>
                                                                <td align="left" class="_titlebox">
                                                                    Comments :
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtCommentReply" runat="server" TextMode="MultiLine" CssClass="txtArea"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="btn_Reply" runat="server" Text="Reply" CssClass="btn_Submit" CommandName="CommentReply"
                                                                        CommandArgument='<%# Eval("iID") %>' />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div style="clear: both; height: 20px">
                                        &nbsp;</div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="tab3" class="_tabbox">
                <asp:ValidationSummary ID="vs_Question" ValidationGroup="vg_Question" runat="server"
                    HeaderText="Please fill following details to Post Question" />
                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                    <tr>
                        <td align="left" width="50%" valign="top">
                            <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                <tr>
                                    <td align="left" class="_titlebox">
                                        Name
                                    </td>
                                    <td width="5px" align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtQuestName" runat="server" CssClass="txtBox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvQuestName" ValidationGroup="vg_Question" runat="server"
                                            ErrorMessage="Name" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtQuestName">&nbsp;</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="_titlebox">
                                        Email
                                    </td>
                                    <td width="5px" align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtQuestEmail" runat="server" CssClass="txtBox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvQuestEmail" ValidationGroup="vg_Question" runat="server"
                                            ErrorMessage="Email" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtQuestEmail">&nbsp;</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revQuestEmail" runat="server" ErrorMessage="Invalid E-mail ID"
                                            ControlToValidate="txtQuestEmail" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vg_Question"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="_titlebox">
                                        Mobile
                                    </td>
                                    <td width="5px" align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtQuestMobile" runat="server" CssClass="txtBox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvQuestMobile" ValidationGroup="vg_Question" runat="server"
                                            ErrorMessage="Mobile" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtQuestMobile">&nbsp;</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <div id="Question_Box">
                                <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                    <tr>
                                        <td align="left">
                                            <asp:TextBox ID="txtQuestTitle" runat="server" CssClass="_txtBox" Text="Question Title"
                                                onFocus="if (value == 'Question Title') {value=''}"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvQuestTitle" ValidationGroup="vg_Question" runat="server"
                                                InitialValue="Question Title" ErrorMessage="Question Title" SetFocusOnError="true"
                                                Display="Dynamic" ControlToValidate="txtQuestTitle">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" CssClass="txtArea"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvQuestion" ValidationGroup="vg_Question" runat="server"
                                                ErrorMessage="Question" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtQuestion">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Button ID="btn_Submit03" runat="server" Text="Submit" CssClass="btn_Submit"
                                                OnClick="btn_Submit_03_Click" ValidationGroup="vg_Question" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Repeater ID="rpt_Questions" runat="server" OnItemCommand="rpt_Comments_ItemCommand"
                                OnItemDataBound="rpt_Comments_ItemDataBound">
                                <ItemTemplate>
                                    <div>
                                        <div style="float: left">
                                            <img src="http://www.eduvidya.com/CommentBox/img/Quest_02.png" width="50px" />
                                        </div>
                                        <div>
                                            <%# Eval("strDesc") %>
                                        </div>
                                    </div>
                                    <div style="clear: both;">
                                    </div>
                                    <div>
                                        <div style="float: left">
                                            <%# "<b>Posted By : </b>" + Eval("strName") %>
                                        </div>
                                        <div style="text-align: right">
                                            <%# "<b>Posted On : </b>" + Eval("dtDate", "{0:dddd MMMM yyyy}")%>
                                        </div>
                                    </div>
                                    <div style="padding: 20px 0px 20px 50px">
                                        <asp:HiddenField ID="hf_CommentID" runat="server" Value='<%# Eval("iID") %>' />
                                        <asp:HiddenField ID="hf_Type" runat="server" Value="Comment" />
                                        <asp:Repeater ID="rpt_Reply" runat="server">
                                            <ItemTemplate>
                                                <div>
                                                    <div style="float: left; padding-right: 5px">
                                                        <img src="http://www.eduvidya.com/CommentBox/img/Reply_01.png" width="25px" />
                                                    </div>
                                                    <div style="padding-top: 6px">
                                                        <%# Eval("strReply") %>
                                                    </div>
                                                </div>
                                                <div style="clear: both;">
                                                </div>
                                                <div style="padding-left: 30px">
                                                    <div style="float: left">
                                                        <%# "<b>Posted By : </b>" + Eval("strName") %>
                                                    </div>
                                                    <div style="text-align: right">
                                                        <%# "<b>Posted On : </b>" + Eval("dtDate", "{0:dddd MMMM yyyy}")%>
                                                    </div>
                                                </div>
                                                <div style="clear: both; height: 10px">
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div id="Contain9ner">
                                        <div class="hyp_Reply">
                                            Reply to this Question</div>
                                        <div class="ReplyBox">
                                            <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                                <tr>
                                                    <td align="left" width="50%" valign="top">
                                                        <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                                            <tr>
                                                                <td align="left" class="_titlebox">
                                                                    Name
                                                                </td>
                                                                <td width="5px" align="center">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCommentReplyName" runat="server" CssClass="txtBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="_titlebox">
                                                                    Email
                                                                </td>
                                                                <td width="5px" align="center">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCommentReplyEmail" runat="server" CssClass="txtBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="_titlebox">
                                                                    Mobile
                                                                </td>
                                                                <td width="5px" align="center">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCommentReplyMobile" runat="server" CssClass="txtBox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                                            <tr>
                                                                <td align="left" class="_titlebox">
                                                                    Comments :
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtCommentReply" runat="server" TextMode="MultiLine" CssClass="txtArea"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Button ID="btn_Reply" runat="server" Text="Reply" CssClass="btn_Submit" CommandName="CommentReply"
                                                                        CommandArgument='<%# Eval("iID") %>' />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div style="clear: both; height: 20px">
                                        &nbsp;</div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="InfoBox" class="reveal-modal xlarge">
        <h1>
            <asp:Literal ID="ltl_InfoTitle" runat="server"></asp:Literal></h1>
        <div style="clear: both; height: 10px">
        </div>
        <asp:Literal ID="ltl_Info" runat="server"></asp:Literal>
        <a class="close-reveal-modal">&#215;</a>
    </div>
    </form>
</body>
</html>
