<%@ Page Language="C#" MasterPageFile="~/ClientDetailsMaster.master" AutoEventWireup="true"
    CodeFile="Compare-Institutes.aspx.cs" Inherits="CompareInstitute" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
    <div class="box">
        <div class="heading">
            <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
        </div>
        <div class="box-content">
            <div class="college-compare-result-dv">
                <ul>
                    <li class="first-row">
                        <div class="first fourth-cols">
                            <p>&nbsp;</p>
                        </div>
                        <div class="second fourth-cols">
                            <img id="img_Institute1" runat="server" class="photoframe" />
                            <asp:HyperLink ID="hyp_Institute1" runat="server"></asp:HyperLink>
                        </div>
                        <div class="third fourth-cols">
                            <img id="img_Institute2" runat="server" class="photoframe" />
                            <br />
                            <asp:HyperLink ID="hyp_Institute2" runat="server"></asp:HyperLink>
                        </div>
                        <div class="fourth  fourth-cols">
                            <img id="img_Institute3" runat="server" class="photoframe" />
                            <br />
                            <asp:HyperLink ID="hyp_Institute3" runat="server"></asp:HyperLink>
                        </div>
                    </li>
                    <li class="second-row">
                        <div class="first fourth-cols">
                            <p>Established In</p>
                        </div>
                        <div class="second fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_EstablishedIn1" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="third fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_EstablishedIn2" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="fourth fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_EstablishedIn3" runat="server"></asp:Literal>
                            </p>
                        </div>
                    </li>
                    <li class="third-row">
                        <div class="first fourth-cols">
                            <p>Affiliated To</p>
                        </div>
                        <div class="second fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_AffiliatedTo1" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="third fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_AffiliatedTo2" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="fourth fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_AffiliatedTo3" runat="server"></asp:Literal>
                            </p>
                        </div>
                    </li>
                    <li class="fourth-row">
                        <div class="first fourth-cols">
                            <p>Courses Offered</p>
                        </div>
                        <div class="second fourth-cols">
                            <ul>
                                <asp:Repeater ID="rpt_Courses1" runat="server">
                                    <ItemTemplate>
                                        <li><a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-").Replace(".","_") + "/Courses/" + Eval("strTitle").ToString().Replace(" ","-"))%>'>
                                            <%# Eval("strTitle") %></a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="third fourth-cols">
                            <ul>
                                <asp:Repeater ID="rpt_Courses2" runat="server">
                                    <ItemTemplate>
                                        <li><a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-").Replace(".","_") + "/Courses/" + Eval("strTitle").ToString().Replace(" ","-"))%>'>
                                            <%# Eval("strTitle") %></a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="fourth fourth-cols">
                            <ul>
                                <asp:Repeater ID="rpt_Courses3" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-").Replace(".","_") + "/Courses/" + Eval("strTitle").ToString().Replace(" ","-"))%>'>
                                                <%# Eval("strTitle") %></a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </li>
                    <li class="fifth-row">
                        <div class="first fourth-cols">
                            <p>Exam Accepted</p>
                        </div>
                        <div class="second fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_ExamAccepted1" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="third fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_ExamAccepted2" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="fourth fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_ExamAccepted3" runat="server"></asp:Literal>
                            </p>
                        </div>
                    </li>
                    <li class="sixth-row">
                        <div class="first fourth-cols">
                            <p>Facilities</p>
                        </div>
                        <div class="second fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_Facilities1" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="third fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_Facilities2" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="fourth fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_Facilities3" runat="server"></asp:Literal>
                            </p>
                        </div>
                    </li>
                    <li class="seventh-row">
                        <div class="first fourth-cols">
                            <p>Placements</p>
                        </div>
                        <div class="second fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_Placements1" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="third fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_Placements2" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="fourth fourth-cols">
                            <p>
                                <asp:Literal ID="ltl_Placements3" runat="server"></asp:Literal>
                            </p>
                        </div>
                    </li>
                    <li class="eight-row">
                        <div class="first fourth-cols">
                            <p>Reviews</p>
                        </div>
                        <div class="second fourth-cols">
                            <ul>
                                <asp:Repeater ID="rpt_Review1" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-").Replace(".","_") + "/Reviews/" + Eval("strTitle").ToString().Replace(" ","-") + "/" + Eval("iID"))%>'>
                                                <%# Eval("strTitle") %></a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="third fourth-cols">
                            <ul>
                                <asp:Repeater ID="rpt_Review2" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-").Replace(".","_") + "/Reviews/" + Eval("strTitle").ToString().Replace(" ","-") + "/" + Eval("iID"))%>'>
                                                <%# Eval("strTitle") %></a>
                                            <br />

                                            <%# fn_ShortDetails(Eval("strDetails").ToString())%>
                                        </li>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="fourth fourth-cols">
                            <ul>
                                <asp:Repeater ID="rpt_Review3" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-").Replace(".","_") + "/Reviews/" + Eval("strTitle").ToString().Replace(" ","-") + "/" + Eval("iID"))%>'>
                                                <%# Eval("strTitle") %></a>
                                            <br />

                                            <%# fn_ShortDetails(Eval("strDetails").ToString())%>
                                        </li>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <%--  <table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" valign="top" class="bestplace_head">
                <h1>
                    <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></h1>
            </td>
        </tr>
        <tr>
            <td align="left" class="best_border">
                <table width="100%" cellpadding="2" cellspacing="2" class="Compare_Box">
                    <tr class="AlternateBox">
                        <td width="125px">&nbsp;
                        </td>
                        <td align="center" width="210px">
                            <div class="photos">
                                <img id="img_Institute1" runat="server" class="photoframe" />
                            </div>
                            <div class="clr_box">
                            </div>
                            <asp:HyperLink ID="hyp_Institute1" runat="server"></asp:HyperLink>
                        </td>
                        <td align="center" width="210px">
                            <div class="photos">
                                <img id="img_Institute2" runat="server" class="photoframe" />
                            </div>
                            <div class="clr_box">
                            </div>
                            <asp:HyperLink ID="hyp_Institute2" runat="server"></asp:HyperLink>
                        </td>
                        <td align="center" width="210px" class='<%= fn_lastCompareBox() %>'>
                            <div class="photos">
                                <img id="img_Institute3" runat="server" class="photoframe" />
                            </div>
                            <div class="clr_box">
                            </div>
                            <asp:HyperLink ID="hyp_Institute3" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <b>Established In</b>
                        </td>
                        <td align="center" valign="top">
                            <asp:Literal ID="ltl_EstablishedIn1" runat="server"></asp:Literal>
                        </td>
                        <td align="center" valign="top">
                            <asp:Literal ID="ltl_EstablishedIn2" runat="server"></asp:Literal>
                        </td>
                        <td align="center" valign="top" class='<%= fn_lastCompareBox() %>'>
                            <asp:Literal ID="ltl_EstablishedIn3" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr class="AlternateBox">
                        <td align="left" valign="top">
                            <b>Affiliated To</b>
                        </td>
                        <td align="center" valign="top">
                            <asp:Literal ID="ltl_AffiliatedTo1" runat="server"></asp:Literal>
                        </td>
                        <td align="center" valign="top">
                            <asp:Literal ID="ltl_AffiliatedTo2" runat="server"></asp:Literal>
                        </td>
                        <td align="center" valign="top" class='<%= fn_lastCompareBox() %>'>
                            <asp:Literal ID="ltl_AffiliatedTo3" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <b>Courses Offered</b>
                        </td>
                        <td align="left" valign="top">
                            <asp:Repeater ID="rpt_Courses1" runat="server">
                                <ItemTemplate>
                                    <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-").Replace(".","_") + "/Courses/" + Eval("strTitle").ToString().Replace(" ","-"))%>'>
                                        <%# Eval("strTitle") %></a>
                                    <div style="clear: both; height: 5px">
                                        &nbsp;
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                        <td align="left" valign="top">
                            <asp:Repeater ID="rpt_Courses2" runat="server">
                                <ItemTemplate>
                                    <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-").Replace(".","_") + "/Courses/" + Eval("strTitle").ToString().Replace(" ","-"))%>'>
                                        <%# Eval("strTitle") %></a>
                                    <div style="clear: both; height: 5px">
                                        &nbsp;
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                        <td align="left" valign="top" class='<%= fn_lastCompareBox() %>'>
                            <asp:Repeater ID="rpt_Courses3" runat="server">
                                <ItemTemplate>
                                    <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-").Replace(".","_") + "/Courses/" + Eval("strTitle").ToString().Replace(" ","-"))%>'>
                                        <%# Eval("strTitle") %></a>
                                    <div style="clear: both; height: 5px">
                                        &nbsp;
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr class="AlternateBox">
                        <td align="left" valign="top">
                            <b>Exam Accepted</b>
                        </td>
                        <td align="center" valign="top">
                            <asp:Literal ID="ltl_ExamAccepted1" runat="server"></asp:Literal>
                        </td>
                        <td align="center" valign="top">
                            <asp:Literal ID="ltl_ExamAccepted2" runat="server"></asp:Literal>
                        </td>
                        <td align="center" valign="top" class='<%= fn_lastCompareBox() %>'>
                            <asp:Literal ID="ltl_ExamAccepted3" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <b>Facilities</b>
                        </td>
                        <td align="left" valign="top">
                            <asp:Literal ID="ltl_Facilities1" runat="server"></asp:Literal>
                        </td>
                        <td align="left" valign="top">
                            <asp:Literal ID="ltl_Facilities2" runat="server"></asp:Literal>
                        </td>
                        <td align="left" valign="top" class='<%= fn_lastCompareBox() %>'>
                            <asp:Literal ID="ltl_Facilities3" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr class="AlternateBox">
                        <td align="left" valign="top">
                            <b>Placements</b>
                        </td>
                        <td align="left" valign="top">
                            <asp:Literal ID="ltl_Placements1" runat="server"></asp:Literal>
                        </td>
                        <td align="left" valign="top">
                            <asp:Literal ID="ltl_Placements2" runat="server"></asp:Literal>
                        </td>
                        <td align="left" valign="top" class='<%= fn_lastCompareBox() %>'>
                            <asp:Literal ID="ltl_Placements3" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <b>Reviews</b>
                        </td>
                        <td align="left" valign="top">
                            <asp:Repeater ID="rpt_Review1" runat="server">
                                <ItemTemplate>
                                    <div class="ListReview">
                                        <div>
                                            <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-").Replace(".","_") + "/Reviews/" + Eval("strTitle").ToString().Replace(" ","-") + "/" + Eval("iID"))%>'
                                                class="rec_links">
                                                <%# Eval("strTitle") %></a>
                                        </div>
                                        <div class="clr_box">
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                        <td align="left" valign="top">
                            <asp:Repeater ID="rpt_Review2" runat="server">
                                <ItemTemplate>
                                    <div class="ListReview">
                                        <div>
                                            <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-").Replace(".","_") + "/Reviews/" + Eval("strTitle").ToString().Replace(" ","-") + "/" + Eval("iID"))%>'
                                                class="rec_links">
                                                <%# Eval("strTitle") %></a>
                                        </div>
                                        <div class="clr_box">
                                        </div>
                                        <div>
                                            <%# fn_ShortDetails(Eval("strDetails").ToString())%>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                        <td align="left" valign="top" class='<%= fn_lastCompareBox() %>'>
                            <asp:Repeater ID="rpt_Review3" runat="server">
                                <ItemTemplate>
                                    <div class="ListReview">
                                        <div>
                                            <a href='<%# VirtualPathUtility.ToAbsolute("~/Colleges/" + Eval("strInstitute").ToString().Replace(" ","-").Replace(".","_") + "/Reviews/" + Eval("strTitle").ToString().Replace(" ","-") + "/" + Eval("iID"))%>'
                                                class="rec_links">
                                                <%# Eval("strTitle") %></a>
                                        </div>
                                        <div class="clr_box">
                                        </div>
                                        <div>
                                            <%# fn_ShortDetails(Eval("strDetails").ToString())%>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="bottom">&nbsp;
            </td>
        </tr>
    </table> --%>
</asp:Content>
