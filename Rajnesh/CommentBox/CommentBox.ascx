<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommentBox.ascx.cs" Inherits="CommentBox_CommentBox" %>


                
<div id="horizontalTab" class="r-tabs">
    <ul class="r-tabs-nav">
        <li class="r-tabs-tab r-tabs-state-active"><a href="#comments" class="r-tabs-anchor">Comments</a></li>
        <li class="r-tabs-state-default r-tabs-tab"><a href="#reviews" class="r-tabs-anchor">Reviews</a></li>
        <li class="r-tabs-state-default r-tabs-tab"><a href="#questions" class="r-tabs-anchor">Questions</a></li>
    </ul>
    <div id="comments" class="r-tabs-panel r-tabs-state-active" style="display: block;">
        <asp:ValidationSummary ID="vs_Comments" ValidationGroup="vg_Comments" runat="server"
            HeaderText="Please fill following details to Post Comment" />
        <ul class="col-1">
            <li>
                <label>Name:</label>
                <asp:TextBox ID="txtCommentName" runat="server" CssClass="xtBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" ValidationGroup="vg_Comments" runat="server"
                    ErrorMessage="Name" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtCommentName">&nbsp;</asp:RequiredFieldValidator>

            </li>
            <li>
                <label>Email:</label>
                <asp:TextBox ID="txtCommentEmail" runat="server" CssClass="xtBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" ValidationGroup="vg_Comments" runat="server"
                    ErrorMessage="Email" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtCommentEmail">&nbsp;</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Invalid E-mail ID"
                    ControlToValidate="txtCommentEmail" Display="Dynamic" SetFocusOnError="true"
                    ValidationGroup="vg_Comments" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
            </li>
            <li>
                <label>Mobile:</label>
                <asp:TextBox ID="txtCommentMobile" runat="server" CssClass="xtBox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMobile" ValidationGroup="vg_Comments" runat="server"
                    ErrorMessage="Mobile" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtCommentMobile">&nbsp;</asp:RequiredFieldValidator>
            </li>
        </ul>
        <ul class="col-2">
            <li>
                <label>Comments:</label>
                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" CssClass="xtBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvComment" ValidationGroup="vg_Comments" runat="server"
                    ErrorMessage="Comment" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtComment">&nbsp;</asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Button ID="btn_Submit01" runat="server" Text="Submit" CssClass="btnSubmit"
                    OnClick="btn_Submit_01_Click" ValidationGroup="vg_Comments" />
            </li>
        </ul>

        <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">


            <tr>
                <td align="left" colspan="2">
                    <div class="_tabTitle">
                        <asp:Literal ID="ltl_CommentTitle" runat="server"></asp:Literal>
                    </div>
                    <asp:Repeater ID="rpt_Comments" runat="server" OnItemCommand="rpt_Comments_ItemCommand"
                        OnItemDataBound="rpt_Comments_ItemDataBound">
                        <ItemTemplate>
                            <div>
                                <div style="float: left">
                                    <img src="https://www.eduvidya.com/CommentBox/img/Comment_03.png" width="50px" />
                                </div>
                                <div>
                                    <%# Eval("strDesc") %>
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div>
                                <div style="float: left; padding-left: 50px">
                                    <%# "<b>Posted By : </b>" + Eval("strName") %>
                                </div>
                                <div style="text-align: right">
                                    <%# "<b>Posted On : </b>" + Eval("dtDate", "{0:dd MMMM yyyy}")%>
                                </div>
                            </div>
                            <div style="padding: 20px 0px 20px 50px">
                                <asp:HiddenField ID="hf_CommentID" runat="server" Value='<%# Eval("iID") %>' />
                                <asp:HiddenField ID="hf_Type" runat="server" Value="Comment" />
                                <asp:Repeater ID="rpt_Reply" runat="server">
                                    <HeaderTemplate>
                                        <div class="_tabTitle">
                                            Replies to this Comment
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div>
                                            <div style="float: left; padding-right: 5px">
                                                <img src="https://www.eduvidya.com/CommentBox/img/Reply_01.png" width="25px" />
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
                                                <%# "<b>Posted On : </b>" + Eval("dtDate", "{0:dd MMMM yyyy}")%>
                                            </div>
                                        </div>
                                        <div style="clear: both; height: 10px">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div id="Contain9ner">
                                <div class="hyp_Reply">
                                    Reply to this Comment
                                </div>
                                <div style="float: right;">
                                    <asp:LinkButton ID="btn_ReportAbuse" runat="server" Text="Report Abuse" CommandName="ReportAbuse"
                                        CommandArgument='<%# Eval("iID") %>'></asp:LinkButton>
                                </div>
                                <div style="clear: both; height: 5px">
                                </div>
                                <div class="ReplyBox">
                                    <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                        <tr>
                                            <td align="left" width="50%" valign="top">
                                                <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                                    <tr>
                                                        <td align="left" class="_titlebox">Name
                                                        </td>
                                                        <td width="5px" align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCommentReplyName" runat="server" CssClass="xtBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="_titlebox">Email
                                                        </td>
                                                        <td width="5px" align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCommentReplyEmail" runat="server" CssClass="xtBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="_titlebox">Mobile
                                                        </td>
                                                        <td width="5px" align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCommentReplyMobile" runat="server" CssClass="xtBox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="left" valign="top">
                                                <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                                    <tr>
                                                        <td align="left" class="_titlebox">Comments :
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCommentReply" runat="server" TextMode="MultiLine" CssClass="xtBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Button ID="btn_Reply" runat="server" Text="Reply" CssClass="btnSubmit" CommandName="CommentReply"
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
                                &nbsp;
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </div>
    <div id="reviews" class="r-tabs-panel r-tabs-state-default" style="display: none;">
        <asp:ValidationSummary ID="vs_Review" ValidationGroup="vg_Reviews" runat="server"
            HeaderText="Please fill following details to Post Review" />
        <ul class="col-1">
            <li>
                <label>Name:</label>
                <asp:TextBox ID="txtReviewName" runat="server" CssClass="xtBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReviewName" ValidationGroup="vg_Reviews" runat="server"
                    ErrorMessage="Name" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtReviewName">&nbsp;</asp:RequiredFieldValidator>

            </li>
            <li>
                <label>Email:</label>
                <asp:TextBox ID="txtReviewEmail" runat="server" CssClass="xtBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReviewEmail" ValidationGroup="vg_Reviews" runat="server"
                    ErrorMessage="Email" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtReviewEmail">&nbsp;</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revReviewEmail" runat="server" ErrorMessage="Invalid E-mail ID"
                    ControlToValidate="txtReviewEmail" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vg_Reviews"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>

            </li>
            <li>
                <label>Mobile:</label>
                <asp:TextBox ID="txtReviewMobile" runat="server" CssClass="xtBox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReviewMobile" ValidationGroup="vg_Reviews" runat="server"
                    ErrorMessage="Mobile" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtReviewMobile">&nbsp;</asp:RequiredFieldValidator>

            </li>
        </ul>
        <ul class="col-2">
            <li>
                <asp:TextBox ID="txtReviewTitle" runat="server" CssClass="xtBox" Text="Review Title"
                    onFocus="if (value == 'Review Title') {value=''}"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReviewTitle" ValidationGroup="vg_Reviews" runat="server"
                    InitialValue="Review Title" ErrorMessage="Review Title" SetFocusOnError="true"
                    Display="Dynamic" ControlToValidate="txtReviewTitle">&nbsp;</asp:RequiredFieldValidator>
            </li>
            <li>
                <div class="RateIt">
                    <asp:DropDownList ID="ddl_Rating" runat="server" CssClass="ddlBox ratingsBox" ClientIDMode="Static">
                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="hf_Rate" runat="server" />
                </div>
            </li>
            <li>
                <asp:TextBox ID="txtReviewsDesc" runat="server" TextMode="MultiLine" CssClass="xtBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReviewDetails" ValidationGroup="vg_Reviews" runat="server"
                    ErrorMessage="Review Details" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtReviewsDesc">&nbsp;</asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Button ID="btn_Submit02" runat="server" Text="Submit" CssClass="btnSubmit"
                    OnClick="btn_Submit_02_Click" ValidationGroup="vg_Reviews" />
            </li>
        </ul>

        <div class="_tabTitle">
            <asp:Literal ID="ltl_ReviewTitle" runat="server"></asp:Literal>
        </div>
        <asp:Repeater ID="rpt_Reviews" runat="server" OnItemCommand="rpt_Comments_ItemCommand"
            OnItemDataBound="rpt_Comments_ItemDataBound">
            <ItemTemplate>
                <div>
                    <div style="float: left; padding-right: 10px">
                        <img src="https://www.eduvidya.com/CommentBox/img/Review_01.png" width="50px" />
                    </div>
                    <div>
                        <table width="100%" cellpadding="0px" cellspacing="0px" border="0px" class="_RatingBox">
                            <tr>
                                <td align="left" colspan="6" style="color: #87B52E; font-family: Trebuchet MS">
                                    <%# Eval("strTitle") %>
                                </td>
                            </tr>
                            <tr>
                                <td width="20px">
                                    <img src='<%# ((bool)(((int)Eval("iRate")) > 0)) == true ? "https://www.eduvidya.com/Star_Rating/images/Star_02.png" : "https://www.eduvidya.com/Star_Rating/images/Star_01.png" %>'
                                        alt="" width="24px" />
                                </td>
                                <td width="20px">
                                    <img src='<%# ((bool)(((int)Eval("iRate")) > 1)) == true ? "https://www.eduvidya.com/Star_Rating/images/Star_02.png" : "https://www.eduvidya.com/Star_Rating/images/Star_01.png" %>'
                                        alt="" width="24px" />
                                </td>
                                <td width="20px">
                                    <img src='<%# ((bool)(((int)Eval("iRate")) > 2)) == true ? "https://www.eduvidya.com/Star_Rating/images/Star_02.png" : "https://www.eduvidya.com/Star_Rating/images/Star_01.png" %>'
                                        alt="" width="24px" />
                                </td>
                                <td width="20px">
                                    <img src='<%# ((bool)(((int)Eval("iRate")) > 3)) == true ? "https://www.eduvidya.com/Star_Rating/images/Star_02.png" : "https://www.eduvidya.com/Star_Rating/images/Star_01.png" %>'
                                        alt="" width="24px" />
                                </td>
                                <td width="20px">
                                    <img src='<%# ((bool)(((int)Eval("iRate")) > 4)) == true ? "https://www.eduvidya.com/Star_Rating/images/Star_02.png" : "https://www.eduvidya.com/Star_Rating/images/Star_01.png" %>'
                                        alt="" width="24px" />
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                        </table>
                        <%# Eval("strDesc")%>
                    </div>
                </div>
                <div style="clear: both; height: 7px">
                </div>
                <div>
                    <div style="float: left; padding-left: 57px">
                        <%# "<b>Posted By : </b>" + Eval("strName") %>
                    </div>
                    <div style="text-align: right">
                        <%# "<b>Posted On : </b>" + Eval("dtDate", "{0:dd MMMM yyyy}")%>
                    </div>
                </div>
                <div style="padding: 20px 0px 20px 57px">
                    <asp:HiddenField ID="hf_CommentID" runat="server" Value='<%# Eval("iID") %>' />
                    <asp:HiddenField ID="hf_Type" runat="server" Value="Review" />
                    <asp:Repeater ID="rpt_Reply" runat="server">
                        <HeaderTemplate>
                            <div class="_tabTitle">
                                Replies to this Review
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div>
                                <div style="float: left; padding-right: 5px">
                                    <img src="https://www.eduvidya.com/CommentBox/img/Reply_01.png" width="25px" />
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
                                    <%# "<b>Posted On : </b>" + Eval("dtDate", "{0:dd MMMM yyyy}")%>
                                </div>
                            </div>
                            <div style="clear: both; height: 10px">
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="Contain9ner">
                    <div class="hyp_Reply">
                        Reply to this Review
                    </div>
                    <div style="float: right;">
                        <asp:LinkButton ID="btn_ReportAbuse" runat="server" Text="Report Abuse" CommandName="ReportAbuse"
                            CommandArgument='<%# Eval("iID") %>'></asp:LinkButton>
                    </div>
                    <div style="clear: both; height: 5px">
                    </div>
                    <div class="ReplyBox">
                        <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                            <tr>
                                <td align="left" width="50%" valign="top">
                                    <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                        <tr>
                                            <td align="left" class="_titlebox">Name
                                            </td>
                                            <td width="5px" align="center">:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCommentReplyName" runat="server" CssClass="xtBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="_titlebox">Email
                                            </td>
                                            <td width="5px" align="center">:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCommentReplyEmail" runat="server" CssClass="xtBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="_titlebox">Mobile
                                            </td>
                                            <td width="5px" align="center">:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCommentReplyMobile" runat="server" onkeypress="return isNumberKey(event)" CssClass="xtBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left" valign="top">
                                    <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                        <tr>
                                            <td align="left" class="_titlebox">Comments :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:TextBox ID="txtCommentReply" runat="server" TextMode="MultiLine" CssClass="xtBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Button ID="btn_Reply" runat="server" Text="Reply" CssClass="btnSubmit" CommandName="CommentReply"
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
                    &nbsp;
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div id="questions" class="r-tabs-panel r-tabs-state-default" style="display: none;">
        <asp:ValidationSummary ID="vs_Question" ValidationGroup="vg_Question" runat="server"
            HeaderText="Please fill following details to Post Question" />
        <ul class="col-1">
            <li>
                <label>Name:</label>
                <asp:TextBox ID="txtQuestName" runat="server" CssClass="xtBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQuestName" ValidationGroup="vg_Question" runat="server"
                    ErrorMessage="Name" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtQuestName">&nbsp;</asp:RequiredFieldValidator>
            </li>
            <li>
                <label>Email:</label>
                <asp:TextBox ID="txtQuestEmail" runat="server" CssClass="xtBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQuestEmail" ValidationGroup="vg_Question" runat="server"
                    ErrorMessage="Email" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtQuestEmail">&nbsp;</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revQuestEmail" runat="server" ErrorMessage="Invalid E-mail ID"
                    ControlToValidate="txtQuestEmail" Display="Dynamic" SetFocusOnError="true" ValidationGroup="vg_Question"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
            </li>
            <li>
                <label>Mobile:</label>
                <asp:TextBox ID="txtQuestMobile" runat="server" CssClass="xtBox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQuestMobile" ValidationGroup="vg_Question" runat="server"
                    ErrorMessage="Mobile" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtQuestMobile">&nbsp;</asp:RequiredFieldValidator>
            </li>
        </ul>
        <ul class="col-2">
            <li>
                <asp:TextBox ID="txtQuestTitle" runat="server" CssClass="xtBox" Text="Question Title"
                    onFocus="if (value == 'Question Title') {value=''}"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQuestTitle" ValidationGroup="vg_Question" runat="server"
                    InitialValue="Question Title" ErrorMessage="Question Title" SetFocusOnError="true"
                    Display="Dynamic" ControlToValidate="txtQuestTitle">&nbsp;</asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" CssClass="xtBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQuestion" ValidationGroup="vg_Question" runat="server"
                    ErrorMessage="Question" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtQuestion">&nbsp;</asp:RequiredFieldValidator>
            </li>

            <li>
                <asp:Button ID="btn_Submit03" runat="server" Text="Submit" CssClass="btnSubmit"
                    OnClick="btn_Submit_03_Click" ValidationGroup="vg_Question" /></li>
        </ul>

        <div class="_tabTitle">
            <asp:Literal ID="ltl_QuestionTitle" runat="server"></asp:Literal>
        </div>
        <asp:Repeater ID="rpt_Questions" runat="server" OnItemCommand="rpt_Comments_ItemCommand"
            OnItemDataBound="rpt_Comments_ItemDataBound">
            <ItemTemplate>
                <div>
                    <div style="float: left">
                        <img src="https://www.eduvidya.com/CommentBox/img/Quest_02.png" width="50px" />
                    </div>
                    <div>
                        <%# Eval("strTitle") %><br />
                        <%# Eval("strDesc") %>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
                <div>
                    <div style="float: left; padding-left: 50px">
                        <%# "<b>Posted By : </b>" + Eval("strName") %>
                    </div>
                    <div style="text-align: right">
                        <%# "<b>Posted On : </b>" + Eval("dtDate", "{0:dd MMMM yyyy}")%>
                    </div>
                </div>
                <div style="padding: 20px 0px 20px 50px">
                    <asp:HiddenField ID="hf_CommentID" runat="server" Value='<%# Eval("iID") %>' />
                    <asp:HiddenField ID="hf_Type" runat="server" Value="Question" />
                    <asp:Repeater ID="rpt_Reply" runat="server">
                        <HeaderTemplate>
                            <div class="_tabTitle">
                                Replies to this Question
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div>
                                <div style="float: left; padding-right: 5px">
                                    <img src="https://www.eduvidya.com/CommentBox/img/Reply_01.png" width="25px" />
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
                                    <%# "<b>Posted On : </b>" + Eval("dtDate", "{0:dd MMMM yyyy}")%>
                                </div>
                            </div>
                            <div style="clear: both; height: 10px">
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="Contain9ner">
                    <div class="hyp_Reply">
                        Reply to this Question
                    </div>
                    <div style="float: right;">
                        <asp:LinkButton ID="btn_ReportAbuse" runat="server" Text="Report Abuse" CommandName="ReportAbuse"
                            CommandArgument='<%# Eval("iID") %>'></asp:LinkButton>
                    </div>
                    <div style="clear: both; height: 5px">
                    </div>
                    <div class="ReplyBox">
                        <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                            <tr>
                                <td align="left" width="50%" valign="top">
                                    <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                        <tr>
                                            <td align="left" class="_titlebox">Name
                                            </td>
                                            <td width="5px" align="center">:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCommentReplyName" runat="server" CssClass="xtBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="_titlebox">Email
                                            </td>
                                            <td width="5px" align="center">:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCommentReplyEmail" runat="server" CssClass="xtBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="_titlebox">Mobile
                                            </td>
                                            <td width="5px" align="center">:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCommentReplyMobile" runat="server" CssClass="xtBox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left" valign="top">
                                    <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                        <tr>
                                            <td align="left" class="_titlebox">Comments :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:TextBox ID="txtCommentReply" runat="server" TextMode="MultiLine" CssClass="xtBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Button ID="btn_Reply" runat="server" Text="Reply" CssClass="btnSubmit" CommandName="CommentReply"
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
                    &nbsp;
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</div>
<div id="InfoBox" class="reveal-modal xlarge">
    <h1>
        <asp:Literal ID="ltl_InfoTitle" runat="server"></asp:Literal></h1>
    <%--<div style="clear: both; height: 10px">
    </div>--%>
    <asp:Literal ID="ltl_Info" runat="server"></asp:Literal>
    <%--<a class="close-reveal-modal">&#215;</a>--%>

</div>
