<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="View-Questions.aspx.cs" Inherits="viewQuestions" %>

<%@ Register Src="UserControls/Info.ascx" TagName="Info" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>View Questions</title>
    <meta name="Description" content="View Questions" />
    <meta name="Keywords" content="View Questions" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="srm" runat="server">
    </asp:ScriptManager>
    <div class="box">
        <div class="heading"><a href="#">Ask Questions</a></div>
        <div class="box-content">
            <div class="height-10"></div>
            <div class="list">
                <p>
                    Welcome to Questions Section of Recruitment Exam.
                </p>
                <br />
            </div>
            <div class="filter-result">

                <div class="detail-list">
                    <uc1:Info ID="Info1" runat="server" />
                    <asp:UpdatePanel ID="pnllist" runat="server">
                        <ContentTemplate>
                            <div class="pagination">
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="btnMoreUpPrv" runat="server" Text="..." OnClick="lnkPrevPageNumber_Click" Visible="false" /></li>
                                    <asp:Repeater ID="rptPagesUp" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <asp:LinkButton ID="btnPage" pageno="<%# Container.DataItem %>" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server"><%# Container.DataItem %> </asp:LinkButton>
                                            </li>
                                        </ItemTemplate>

                                    </asp:Repeater>
                                    <li>
                                        <asp:LinkButton ID="btnMoreUpNxt" runat="server" Text="..." OnClick="lnkMorePageNumber_Click" Visible="false" /></li>
                                </ul>
                            </div>
                            <div class="detail-list">
                                <ul>
                                    <asp:Repeater ID="grdQuest" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                    <tr>
                                                        <td valign="top" align="left">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0" style="font-size: 12px;">
                                                                <tr>
                                                                    <td valign="top" align="left">
                                                                        <a href='<%# "https://www.recruitmentexam.com/Question/" + Eval("strQuestion").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-").Replace("'","") + "/"+ Eval("iID") %>'
                                                                            class="jobs" style="font-size: small; font-weight: bold;">
                                                                            <%# Eval("strQuestion") %></a>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Literal ID="ltl_user" runat="server"></asp:Literal>&nbsp;on&nbsp;<%# Eval("dtDate") %><asp:HiddenField ID="hfID" Value='<%# bind("iID") %>' runat="server" />
                                                                        <asp:HiddenField ID="hfUserID" Value='<%# Eval("iUserID") %>' runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <a href='<%# "https://www.recruitmentexam.com/Question/" + Eval("strQuestion").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-").Replace("'","") + "/"+ Eval("iID") %>'
                                                                            class="breadcrums">
                                                                            <asp:Literal ID="ltl_Count" runat="server" Text=""></asp:Literal></a>&nbsp;|&nbsp;<a
                                                                                href='<%# "https://www.recruitmentexam.com/Question/" + Eval("strQuestion").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-").Replace("'","") + "/"+ Eval("iID") %>' class="breadcrums">Answer Now</a></td>
                                                                </tr>
                                                                <tr style="height: 5px;">
                                                                    <td style="border-bottom: 1px dotted #EFB263; padding: 10px 10px 10px 0;" colspan="3"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <div class="pagination">
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="btnMoreDwnPrv" runat="server" Text="..." OnClick="lnkPrevPageNumber_Click" Visible="false" /></li>
                                    <asp:Repeater ID="rptPagesDwn" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <asp:LinkButton ID="btnPage" pageno="<%# Container.DataItem %>" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server"><%# Container.DataItem %> </asp:LinkButton>
                                            </li>
                                        </ItemTemplate>

                                    </asp:Repeater>
                                    <li>
                                        <asp:LinkButton ID="btnMoreDwnNxt" runat="server" Text="..." OnClick="lnkMorePageNumber_Click" Visible="false" /></li>
                                </ul>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

    </div>
    <%--  <table width="100%" cellpadding="0px" cellspacing="0px" border="0px" class="theBox">
        <tr>
            <td class="rec_Title">
                Ask Questions
            </td>
        </tr>
        <tr>
            <td class="" valign="top" colspan="3">
                <div class="rec_Desc">
                    Welcome to Questions Section of Recruitment Exam.
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
                <uc1:Info ID="Info1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" align="left" width="100%" style="padding-left: 8px">
                                       <asp:ListView ID="grdQuest" runat="server" GroupPlaceholderID="groupPlaceHolder1"
                                    ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
                                    <LayoutTemplate>

                                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="grdQuest" PageSize="15" class="pagination">
                                            <Fields>
                                                <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                                            </Fields>
                                        </asp:DataPager>
                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                        <asp:DataPager ID="DataPager2" runat="server" PagedControlID="grdQuest" PageSize="15" class="pagination">
                                            <Fields>
                                                <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                                            </Fields>
                                        </asp:DataPager>

                                    </LayoutTemplate>
                                    <GroupTemplate>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                    </GroupTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="left">
                                                    <table cellpadding="0" cellspacing="0" width="100%" border="0" style="font-size: 12px;">
                                                        <tr>
                                                            <td valign="top" align="left">
                                                                <a href='<%# "https://www.recruitmentexam.com/Question/" + Eval("strQuestion").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-").Replace("'","") + "/"+ Eval("iID") %>'
                                                                    class="jobs" style="font-size: small; font-weight: bold;">
                                                                    <%# Eval("strQuestion") %></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_user" runat="server"></asp:Literal>&nbsp;on&nbsp;<%# Eval("dtDate") %><asp:HiddenField ID="hfID" Value='<%# bind("iID") %>' runat="server" />
                                                                <asp:HiddenField ID="hfUserID" Value='<%# Eval("iUserID") %>' runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <a href='<%# "https://www.recruitmentexam.com/Question/" + Eval("strQuestion").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-").Replace("'","") + "/"+ Eval("iID") %>'
                                                                    class="breadcrums">
                                                                    <asp:Literal ID="ltl_Count" runat="server" Text=""></asp:Literal></a>&nbsp;|&nbsp;<a
                                                                        href='<%# "https://www.recruitmentexam.com/Question/" + Eval("strQuestion").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-").Replace("'","") + "/"+ Eval("iID") %>' class="breadcrums">Answer Now</a></td>
                                                        </tr>
                                                        <tr style="height: 5px;">
                                                            <td style="border-bottom: 1px dotted #EFB263; padding: 10px 10px 10px 0;" colspan="3"></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                        </table>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>--%>
</asp:Content>
