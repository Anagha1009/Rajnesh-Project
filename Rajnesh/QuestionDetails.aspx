<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="QuestionDetails.aspx.cs" Inherits="Resume_tips" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title id="meta_title" runat="server"></title>
    <meta name="Description" content="" id="meta_Description" runat="server" />
    <meta name="Keywords" content="" id="meta_Keywords" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_left" runat="Server">
    <div id="Info">
        <Rec:Error ID="Error1" runat="server" />
        <Rec:Info ID="Info1" runat="server" />
    </div>
    <table width="100%" cellpadding="0px" cellspacing="0px" border="0px" class="theBox">
        <tr>
            <td class="rec_Title">
                Questions Details
            </td>
        </tr>
        <tr>
            <td class="" valign="top" colspan="3">
                <div class="rec_Desc" style="float: left">
                    <b>
                        <asp:Literal ID="ltl_Question" runat="server"></asp:Literal></b>
                </div>
                <div style="text-align: right; padding-right: 5px">
                    <asp:LinkButton ID="btn_ReportAbuse" runat="server" Text="Report Abuse" OnClick="btn_ReportAbuse_Click"></asp:LinkButton>&nbsp;&nbsp;<img
                        src="https://www.recruitmentexam.com/images/ReportAbuse.png" alt="Report Abuse" /></div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:GridView ID="grd_Answer" runat="server" BorderStyle="None" Width="100%" GridLines="None"
                    AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False" EmptyDataText="No Answers"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    DataKeyNames="iID" PageSize="10" PagerStyle-CssClass="pagelinks" CellPadding="0"
                    CellSpacing="0" PagerSettings-Position="TopAndBottom" 
                    PagerStyle-HorizontalAlign="Right" onrowdatabound="grd_Answer_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemStyle VerticalAlign="Top" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td align="left" style="font-size: 12px; width: 6%;" valign="top">
                                            <b>Ans.</b>&nbsp;
                                        </td>
                                        <td align="left" style="font-size: 12px; width: 94%;">
                                            <span style="color: #4493E7;">
                                                <%# Eval("strReply")%>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr style="height: 5px;">
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="font-size: 12px;" valign="top" colspan="2">
                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                <tr>
                                                    <td align="left" style="font-size: 12px; width: 6%;">
                                                    </td>
                                                    <td align="left" style="font-size: 12px; width: 94%;">
                                                    <asp:HiddenField ID="hfUserID" Value='<%# bind("iUserID") %>' runat="server" />
                                                        <asp:Literal ID="ltl_user" runat="server"></asp:Literal>&nbsp;on&nbsp;<%# Eval("dtDate") %></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="height: 15px;">
                                        <td colspan="2" valign="middle" style="border-bottom: 1px dotted #D0D0D0;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="rec_Title">
                Your Answer
            </td>
        </tr>
        <tr id="tr_Answer" runat="server">
            <td class="" valign="top" colspan="3">
                <div class="Content">
                    <asp:TextBox ID="txtAnswer" runat="server" TextMode="MultiLine" CssClass="txtarea">
                    </asp:TextBox>
                    <br />
                    <br />
                    <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/images/submit.png" ValidationGroup="EmplRegistration"
                        OnClick="btnSubmit_Click" Height="45px" />
                </div>
            </td>
        </tr>
        <tr id="tr_Question" runat="server">
            <td class="" valign="top" colspan="3">
                <div class="Content">
                    <center>
                        <blink>
                    <asp:HyperLink ID="hyp" Text="Answer Now" Font-Bold="false" Font-Size="21px" CssClass="jobs" runat="server"></asp:HyperLink>
                    </blink>
                    </center>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
