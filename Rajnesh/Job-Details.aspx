<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="Job-Details.aspx.cs" Inherits="Jobs_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title id="meta_title" runat="server"></title>
    <meta name="Description" content="" id="meta_Description" runat="server" />
    <meta name="Keywords" content="" id="meta_Keywords" runat="server" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cp_left" runat="Server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <style>
        #content {
            padding: 0px;
            border-top-right-radius: 13px;
            border-top-left-radius: 13px;
        }
    </style>
    <div class="box">
        <div class="heading">
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </div>
    </div>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 10px !important;">
        <tr>
            <td class="Content job_information">
                <ul>
                    <li>
                        <img src="images/category.png" alt="category" />
                        <strong>Category</strong>
                        <asp:Label ID="lblCategory" runat="server" CssClass="" Font-Underline="false"> </asp:Label>
                    </li>
                    <li>
                        <img src="images/subcat.png" alt="category" />
                        <strong>SubCategory</strong>
                        <asp:Label ID="lblSubCategory" runat="server" CssClass="" Font-Underline="false"> </asp:Label>
                    </li>
                    <li>
                        <img src="images/company.png" alt="category" />
                        <strong>Company</strong><asp:Label ID="lblCompany" runat="server" CssClass="" Font-Underline="false"> </asp:Label>
                    </li>
                    <li>
                        <img src="images/loc.png" alt="category" /><strong>Location</strong><asp:Label ID="lblLoc" runat="server" CssClass="" Font-Underline="false"> </asp:Label>
                    </li>
                    <li>
                        <img src="images/date.png" alt="category" />
                        <strong>Posted date on our Website</strong>
                        <asp:Label ID="lblPostedOn" runat="server" CssClass="" Font-Underline="false"> </asp:Label>
                    </li>
                    <li>
                        <img src="images/date.png" alt="category" />
                        <strong>Expiration</strong>
                        <asp:Label ID="lblExpirationDate" runat="server" CssClass="" Font-Underline="false"> </asp:Label>
                    </li>
                </ul>
            </td>
        </tr>
        <tr>
            <td style="height: 5px"></td>
        </tr>
        <tr id="tr_JobAlerts" runat="server">
            <td align="center" valign="top" colspan="4">
                <div id="Job_alerts" class="alertbox">
                    <img src="images/alerts.png" alt="alert" /><div>
                        <asp:Literal ID="ltl_CategoryJob" runat="server"></asp:Literal>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 5px"></td>
        </tr>
        <tr>
            <td class="heading">Job Description
            </td>
        </tr>
        <tr>
            <td class="Content" valign="top">
                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                <br />
                <div class="desktop-ad" style="float: left; padding-right: 10px">
                    <script type="text/javascript"><!--
    google_ad_client = "pub-4037987430386783";
    /* jobs for freshers-home-336x280 */
    google_ad_slot = "9287764418";
    google_ad_width = 336;
    google_ad_height = 280;
    //-->

                    </script>
                    <script type="text/javascript" src="https://pagead2.googlesyndication.com/pagead/show_ads.js">
                    </script>
                </div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="heading">
                <asp:Label ID="lblContactDetails" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td id="td_Contact" runat="server" class="Content"></td>
        </tr>
        <tr>
            <td>
                <div style="text-align: justify; padding: 10px 0px; width: 100%">
                    <i>(Disclaimer : This Job has been sourced from various sources like printmedia, Job
                        consultants, our users and/ or Company website. The posted date above means the
                        date on which the Job was posted on our site and not on the company site. Users
                        are advised to check with the company for latest requirements before applying for
                        the job. We have no relation with the company and are not responsible for the accuracy
                        of the data.)</i>
                </div>
            </td>
        </tr>
        <%--  <tr>
            <td>
                <edu:Comment ID="Comment1" runat="server" />
            </td>
        </tr>--%>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cp_rightBottom" runat="Server">
    <table width="100%" cellpadding="4px" cellspacing="4px" border="0" style="border: 1px solid #ccc">
        <tr>
            <td align="left" class="_title" colspan="2">
                <asp:Literal ID="ltl_CategoryTitle" runat="server"></asp:Literal>
            </td>
        </tr>
        <asp:Repeater ID="rpt_Jobs" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="left" width="25px">
                        <img src="img/bullet-red.png" />
                    </td>
                    <td valign="top" align="left">
                        <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# "Job-Details.aspx?Job=" + Eval("strTitle").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-") + "&JobID=" + Eval("iID") %>'
                            CssClass="jobs" CausesValidation="false" Text='<%# Eval("strTitle") %>'></asp:HyperLink>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <br />


    <br />
    <table width="100%" cellpadding="4px" cellspacing="4px" border="0" style="border: 1px solid #ccc">
        <tr>
            <td align="left" class="_title" colspan="2">
                <asp:Literal ID="ltl_CompanyTitle" runat="server"></asp:Literal>
            </td>
        </tr>
        <asp:Repeater ID="rpt_CompanyJobs" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="left" width="25px">
                        <img src="img/bullet-red.png" />
                    </td>
                    <td valign="top" align="left">
                        <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# "Job-Details.aspx?Job=" + Eval("strTitle").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-") + "&JobID=" + Eval("iID") %>'
                            CssClass="jobs" CausesValidation="false" Text='<%# Eval("strTitle") %>'></asp:HyperLink>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <br />
</asp:Content>
