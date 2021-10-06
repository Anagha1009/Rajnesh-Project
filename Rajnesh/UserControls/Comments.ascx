<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Comments.ascx.cs" Inherits="UserControls_CommentsForListing" %>
<script type="text/javascript">
    $(document).ready(function () {
        $('#txtComment').bind('keyup', function () {
            var maxchar = 700;
            var cnt = $(this).val().length;
            var remainingchar = maxchar - cnt;
            if (remainingchar < 0) {
                $('#CommentCount').html('0');
                $(this).val($(this).val().slice(0, 700));
            } else {
                $('#CommentCount').html("Remaining Characters : " + remainingchar);
            }
        });
    });
</script>
<table cellpadding="0" cellspacing="0" border="0">
    <tr runat="server" id="tr_Confirmation">
        <td align="center" valign="top" class="myDiv0">
            <div class="orange-bg" id="Confirmation" runat="server">
                <center>
                    <asp:Label ID="lbl_Confirmation" runat="server" Visible="false" Text="" Font-Bold="true"
                        ForeColor="Green"></asp:Label></center>
            </div>
        </td>
    </tr>
    <tr>
        <td style="width: 100%">
            <table width="100%" id="myTab" runat="server">
                <tr runat="server" id="tr_Comments3">
                    <td>
                        <asp:Repeater ID="rptrComments" runat="server" OnItemCommand="rptrComments_ItemCommand">
                            <ItemTemplate>
                                <table width="100%" border="0" cellspacing="5px" cellpadding="5px" class="myComment">
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbl_CommentBy" runat="server" Text='<%# Eval("strComment") %>' CssClass="arial-black"
                                                Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: 10px">
                                            <span class="graycolor" style="font-size: 6">Posted By : </span>
                                            <asp:Label runat="server" Font-Size="10px" Text='<%# Eval("strName") %>' ID="lbl_AskedBy"></asp:Label>,
                                            on
                                            <%# Eval("dtDate", "{0:dd/MM/yyyy}") %>&nbsp;
                                            <table border="0" width="22%" align="right" cellpadding="0" cellspacing="0" runat="server">
                                                <tr>
                                                    <td style="width: 22%; padding-top: 4px" align="left" valign="top">
                                                        <img src="https://www.reviewseditor.com/images/ReportAbuse.png" width="14" height="14" />
                                                    </td>
                                                    <td style="width: 78%" align="left" valign="top">
                                                        <asp:LinkButton CommandName="Abuse" CommandArgument='<%# Eval("iID") %>' ID="lnkReportAbuse"
                                                            runat="server" CausesValidation="false" Text="Report Abuse" CssClass="normalmenu"
                                                            Font-Size="12px"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <div style="height: 10px">
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr runat="server" id="tr3">
        <td height="10" align="left" valign="top">
            &nbsp;
        </td>
    </tr>
    <tr runat="server" id="tr_PostYourComment">
        <td align="left" valign="top" style="font-weight: bold;">
            Post Your Reviews / Comments / Queries
        </td>
    </tr>
    <tr runat="server" id="tr5">
        <td height="10" align="left" valign="top">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="left">
            <table width="100%" cellpadding="5px" cellspacing="5px" border="0px" class="myComment">
                <tr>
                    <td>
                    </td>
                </tr>
                <tr runat="server" id="tr1">
                    <td height="10" align="left" valign="top">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="Panel_Post" runat="server">
                            <table>
                                <tr>
                                    <td valign="top">
                                        Name
                                    </td>
                                    <td valign="top">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="txtBox" runat="server" ID="txtName"></asp:TextBox><asp:RequiredFieldValidator
                                            ID="rfvName" ValidationGroup="Comment" runat="server" ErrorMessage="Name" SetFocusOnError="true"
                                            Display="Dynamic" Text="&nbsp;&nbsp;&nbsp;*" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr runat="server" id="tr2">
                                    <td height="10" align="left" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="left">
                                        Email
                                    </td>
                                    <td valign="top">
                                        :
                                    </td>
                                    <td valign="top">
                                        <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 34%">
                                                    <asp:TextBox CssClass="txtBox" ID="txtEmail" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                                        ID="rfvEmail" ValidationGroup="Comment" runat="server" ErrorMessage="Email" SetFocusOnError="true"
                                                        Display="Dynamic" Text="&nbsp;&nbsp;&nbsp;*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                            ID="revEmail" runat="server" ErrorMessage="Invalid E-mail ID" ControlToValidate="txtEmail"
                                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="Comment" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                </td>
                                                <td align="left" style="width: 66%; padding-left: 5px">
                                                    Mobile :
                                                    <asp:TextBox CssClass="txtBox" ID="txtMobile" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                                        ID="rfvMobile" ValidationGroup="Comment" runat="server" ErrorMessage="Mobile"
                                                        SetFocusOnError="true" Display="Dynamic" Text="&nbsp;&nbsp;&nbsp;*" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 5px;" colspan="2">
                                                    <span style="font-size: small;">(Your Email and Mobile will not be shared with anyone.
                                                        It is just for replying to your comments / queries / questions. Your Queries will
                                                        be answered by recruitmentexam.com experts.)</span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" align="left" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        Please Post your Reviews / Comments / Queries
                                    </td>
                                    <td valign="top">
                                        :
                                    </td>
                                    <td>
                                        <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                            <tr>
                                                <td align="left">
                                                    <asp:TextBox TextMode="MultiLine" CssClass="txtarea" runat="server" ID="txtComment"
                                                        Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Comment"
                                                            runat="server" ErrorMessage="Comment" SetFocusOnError="true" Display="Dynamic"
                                                            Text="&nbsp;&nbsp;&nbsp;*" ControlToValidate="txtComment"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <div class="counter" id="CommentCount">
                                                        (Max 700 Characters allowed)</div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                    <td style="padding-top: 10px;">
                                        <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="https://www.recruitmentexam.com/images/submit.png"
                                            Width="110px" ValidationGroup="Comment" OnClick="btnSubmit_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
