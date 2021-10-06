<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Ask-Questions.aspx.cs" Inherits="AskNow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Resume Tips</title>
    <meta name="Description" content="Resume Tips" />
    <meta name="Keywords" content="Resume Tips" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <table width="100%" cellpadding="0px" cellspacing="0px" border="0px" class="theBox">
        <tr>
            <td class="rec_Title">
                Ask Questions
            </td>
        </tr>
        <tr>
            <td class="" valign="top" colspan="3">
                <div class="rec_Desc">
                    Welcome to REcruitmentExam.com, Here you are free to ask any Exam, Recruitment or
                    Admission related queries.
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Rec:Info ID="Info1" runat="server" />
                <Rec:Error ID="Error1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%" border="5px" cellpadding="5px" cellspacing="0">
                    <tr>
                        <td align="center" width="75px">
                            <b>Type</b>
                        </td>
                        <td width="10px" align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_Type" runat="server" CssClass="dropBox">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Admission" Value="Admission"></asp:ListItem>
                                <asp:ListItem Text="Exam" Value="Exam"></asp:ListItem>
                                <asp:ListItem Text="Recruitment" Value="Recruitment"></asp:ListItem>
                            </asp:DropDownList>
                            *<asp:RequiredFieldValidator ID="rfvType"  ValidationGroup="vg_Ask" runat="server"
                                    ErrorMessage="Type" SetFocusOnError="true" Display="Dynamic" ControlToValidate="ddl_Type"
                                    InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="75px">
                            <b>Question</b>
                        </td>
                        <td width="10px" align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" CssClass="txtarea"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td align="left" style="padding-left: 6px">
                            <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/images/submit.png" OnClick="btnAdd_Click"
                                Height="45px" ValidationGroup="vg_Ask"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>


