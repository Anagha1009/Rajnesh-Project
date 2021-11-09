<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Eduvidya-Competitions.aspx.cs"
    Inherits="Competition" %>

<%@ Register Src="UserControls/info.ascx" TagName="Info" TagPrefix="asp" %>
<%@ Register Src="UserControls/error.ascx" TagName="Error" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="https://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Eduvidya.com Initiative for Online Education Help</title>
    <%--<script src="https://www.eduvidya.com/CommentBox/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="https://www.eduvidya.com/CommentBox/css/reveal.css" rel="stylesheet" type="text/css" />
    <script src="https://www.eduvidya.com/CommentBox/js/jquery.reveal.js" type="text/javascript"></script>--%>

    <script type="text/javascript" src="/js/jquery-3.6.0.min.js"></script>
    <link href="/css/reveal.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="/js/jquery.reveal.js"></script>
    <link href='https://fonts.googleapis.com/css?family=Joti+One' rel='stylesheet' type='text/css' />
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 40 && charCode != 41 && charCode != 43 && charCode != 45 && charCode > 32 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function fn_getPopup() {
            $('#Competition_Box').reveal($(this).data());
        }

        function fn_ShowPopup() {
            $('#Competition_MessageBox').reveal($(this).data());
        }


    </script>
    <style type="text/css">
        body
        {
            background-color: #efefef;
            color: #222;
            margin: 0px;
            padding: 0px;
            font-family: Trebuchet MS;
            font-size: 13px;
            background-image: url('img/back.jpg');
        }
        
        .topPatti
        {
            background-color: #6B0006;
            height: 15px;
            width: 100%;
        }
        
        .footer
        {
            background-color: #cc0000;
            height: 15px;
            padding: 5px;
            width: 100%;
            text-align: center;
            color: #fff;
        }
        
        .logo
        {
            background-image: url('img/logo_back.jpg');
            font-family: 'Joti One' , cursive;
            width: 270px;
            height: 217px;
            background-color: #cc0000;
            color: #efefef;
            font-size: 35px;
            float: left;
            text-align: center;
            font-style: italic;
            display: table-cell;
            vertical-align: middle;
            padding: 0px 10px 25px 10px;
            -webkit-border-bottom-right-radius: 10px;
            -webkit-border-bottom-left-radius: 10px;
            -moz-border-radius-bottomright: 10px;
            -moz-border-radius-bottomleft: 10px;
            border-bottom-right-radius: 10px;
            border-bottom-left-radius: 10px;
        }
        
        .logo a
        {
            color: #fff;
            text-decoration: none;
        }
        
        .logo a:hover
        {
            color: #fff;
            text-decoration: none;
        }
        
        .left_content
        {
            width: 701px;
        }
        
        h1
        {
            padding: 0px;
            margin: 0px;
        }
        
        h3
        {
            font-size: 17px;
            color: #fff;
            background-color: #444;
            padding: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            font-style: italic;
        }
        
        ._CompeteDetails
        {
            background-color: #fff;
            padding: 5px;
            margin-top: -5px;
            -webkit-border-bottom-right-radius: 5px;
            -webkit-border-bottom-left-radius: 5px;
            -moz-border-radius-bottomright: 5px;
            -moz-border-radius-bottomleft: 5px;
            border-bottom-right-radius: 5px;
            border-bottom-left-radius: 5px;
        }
        
        .btnSubmit
        {
            -moz-transition: all 0.25s linear 0s;
            background-color: #2162A4;
            background-image: -moz-linear-gradient(#2162A4, #2974AE);
            background-repeat: repeat-x;
            border: 0 none;
            border-radius: 0.25em 0.25em 0.25em 0.25em;
            box-shadow: 0 2px 0 0 rgba(0, 0, 0, 0.1), 0 -2px 0 0 rgba(0, 0, 0, 0.2) inset;
            color: #FFFFFF;
            cursor: pointer;
            display: inline-block;
            font-family: 'Open Sans' ,sans-serif;
            font-size: 14px;
            padding: 10px 35px;
            text-decoration: none;
            text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
        }
        
        .btnSubmit:hover
        {
            color: #fff;
        }
        
        
        .tagline
        {
            font-family: Trebuchet MS;
            font-size: 25px;
            color: #fff;
        }
        
        ._CompeteHead
        {
            background-color: #ccc;
            font-family: Trebuchet MS;
            font-size: 17px;
            color: #444;
            font-style: italic;
            height: 40px;
            padding: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
        }
        
        ._CompeteHead div
        {
            float: left;
        }
        
        ._CompeteHead img
        {
            width: 60px;
        }
        
        ._CompeteOption
        {
            float: left;
        }
        
        #rd_CompeteOptions input
        {
            float: left;
        }
        ._CompeteOption img
        {
            width: 71px;
        }
        
        ._txtCompete
        {
            font-family: Trebuchet MS;
            font-size: 13px;
            border: 1px solid #ccc;
            height: 21px;
            padding: 2px;
            width: 210px;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
        }
        
        ._ddlCompete
        {
            border: 1px solid #ccc;
            height: 28px;
            padding: 2px;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
        }
        
        
        ._CompetitionTitle
        {
            font-size: 17px;
            font-family: Trebuchet MS;
            color: #fff;
            font-style: italic;
        }
        
        ._CompeteImage
        {
            float: left;
            margin-right: 10px;
            width: 71px;
        }
        
        ._CompeteImage img
        {
            max-width: 71px;
        }
        .CompetitionDetailsBox
        {
            color: #fff;
            padding: 7px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 7px;
        }
        
        ._messageBox
        {
            font-family: Trebuchet MS;
            font-size: 17px;
            font-style: italic;
            font-weight: bold;
        }
        
        .Message_Info
        {
            float: left;
            padding-right: 15px;
        }
        
        .CompeteLink
        {
            color:#444;
            font-size:15px;
            font-family:Trebuchet MS;
            font-style:italic;
        }
        
        .CompeteLink:hover
        {
            color:#444;
            font-size:15px;
            font-family:Trebuchet MS;
            font-style:italic;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" cellpadding="0px" cellspacing="0px" border="0px" align="center">
        <tr>
            <td align="left" class="topPatti">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="990px" cellpadding="0px" cellspacing="0px" border="0px" align="center">
                    <tr>
                        <td align="left" class="header">
                            <table width="100%" cellpadding="0px" cellspacing="0px" border="0px" align="center">
                                <tr>
                                    <td align="left" valign="top" width="270px">
                                        <div class="logo">
                                            <a href="https://www.eduvidya.com">
                                                <img src="img/EducationHelp.png" alt="Education-help" width="110px" />
                                                EduVidya.com</a> <span class="tagline">Competitions!</span>
                                        </div>
                                    </td>
                                    <td align="left" valign="top" style="padding: 5px 25px">
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0" id="CompetitionDetailsBox"
                                            runat="server" class="CompetitionDetailsBox">
                                            <tr>
                                                <td align="left" class="_CompetitionTitle">
                                                    <asp:Literal ID="ltl_CompetitionTitle" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <div class="_CompeteImage">
                                                        <img id="imgCompetition" runat="server" />
                                                    </div>
                                                    <asp:Literal ID="ltl_CompetitionDetails" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="_CompetitionTitle">
                                                    Prizes
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Literal ID="ltl_Prizes" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2" style="padding: 20px 25px 5px 0px">
                                        <asp:Info ID="info1" runat="server" />
                                        <asp:Error ID="error1" runat="server" />
                                        <asp:HiddenField ID="hf_QuizId" runat="server" />
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0" id="tbl_Competion"
                                            runat="server" align="center" class="mainContent">
                                            <tr>
                                                <td align="left" colspan="4" style="padding-left: 5px">
                                                    <asp:ValidationSummary ID="vs_Competition" ValidationGroup="vgCompetition" runat="server"
                                                        HeaderText="Please fill following details to complete the Competition process." />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <div class="_CompeteHead">
                                                        <div>
                                                            <img id="img_Icon" runat="server" align="middle" />
                                                        </div>
                                                        <div style="padding-top: 10px">
                                                            <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
                                                        </div>
                                                    </div>
                                                    <asp:Literal ID="ltl_Details" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr id="tr_Multimedia" runat="server">
                                                <td align="left">
                                                    <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                                        <tr>
                                                            <td align="left" colspan="3">
                                                                <b>File 1</b>
                                                            </td>
                                                            <td align="left" width="70px">
                                                                <asp:TextBox ID="txt_Title1" runat="server" placeholder="Title of File" CssClass="_txtCompete"></asp:TextBox>
                                                            </td>
                                                            <td width="10px">
                                                            </td>
                                                            <td align="left">
                                                                <asp:FileUpload ID="fp_File1" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="3">
                                                                <b>File 2</b>
                                                            </td>
                                                            <td align="left" width="70px">
                                                                <asp:TextBox ID="txt_Title2" runat="server" placeholder="Title of File" CssClass="_txtCompete"></asp:TextBox>
                                                            </td>
                                                            <td width="10px">
                                                            </td>
                                                            <td align="left">
                                                                <asp:FileUpload ID="fp_File2" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="3">
                                                                <b>File 3</b>
                                                            </td>
                                                            <td align="left" width="70px">
                                                                <asp:TextBox ID="txt_Title3" runat="server" placeholder="Title of File" CssClass="_txtCompete"></asp:TextBox>
                                                            </td>
                                                            <td width="10px">
                                                            </td>
                                                            <td align="left">
                                                                <asp:FileUpload ID="fp_File3" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="3">
                                                                <b>File 4</b>
                                                            </td>
                                                            <td align="left" width="70px">
                                                                <asp:TextBox ID="txt_Title4" runat="server" placeholder="Title of File" CssClass="_txtCompete"></asp:TextBox>
                                                            </td>
                                                            <td width="10px">
                                                            </td>
                                                            <td align="left">
                                                                <asp:FileUpload ID="fp_File4" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="3">
                                                                <b>File 5</b>
                                                            </td>
                                                            <td align="left" width="70px">
                                                                <asp:TextBox ID="txt_Title5" runat="server" placeholder="Title of File" CssClass="_txtCompete"></asp:TextBox>
                                                            </td>
                                                            <td width="10px">
                                                            </td>
                                                            <td align="left">
                                                                <asp:FileUpload ID="fp_File5" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div style="clear: both">
                                                        &nbsp;</div>
                                                    Note : Only bmp, gif, png, jpg, jpeg, flv, avi, mov, mp4, mpg, wmv, 3gp, swf files
                                                    ara allowed
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="tr_Quiz" runat="server">
                                                <td align="left">
                                                    <asp:RadioButtonList ID="rd_CompeteOptions" runat="server" Width="100%">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr id="tr_button" runat="server">
                                                <td align="left">
                                                    <asp:Button ID="btn_Compete" runat="server" Text="Submit" ValidationGroup="Compete"
                                                        CssClass="btnSubmit" OnClick="btn_Compete_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div id="Competition_Box" class="reveal-modal xlarge">
                                <asp:Literal ID="ltl_MessageBox" runat="server"></asp:Literal>
                                <asp:Repeater ID="rpt_OtherCompetition" runat="server" 
                                    onitemcommand="rpt_OtherCompetition_ItemCommand">
                                    <HeaderTemplate>
                                    <div style="clear:both; height:25px">&nbsp;</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_Competition" runat="server" Text='<%# Eval("strTitle") %>'
                                            CommandName="Compete" CommandArgument='<%# Eval("iID") %>' CssClass="CompeteLink"></asp:LinkButton>
                                            <div style="clear:both">&nbsp;</div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <table width="541px" cellpadding="4" cellspacing="4" border="0" id="tbl_CompetitionUserDetails"
                                    runat="server" align="center">
                                    <tr>
                                        <td align="left" colspan="4" style="padding-left: 5px">
                                            <asp:ValidationSummary ID="vs_EducationHelp" ValidationGroup="vg_EduCompete" runat="server"
                                                HeaderText="Please fill following details to complete the Competition." />
                                            <br />
                                            <h1>
                                                Please Provide more details about you to complete the Competition</h1>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="170px" align="left">
                                            <b>Name</b>
                                        </td>
                                        <td width="10px">
                                            :
                                        </td>
                                        <td align="left" width="170px">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="_txtCompete"></asp:TextBox>
                                        </td>
                                        <td align="left" width="25px">
                                            <asp:RequiredFieldValidator ID="rfvName" ValidationGroup="vg_EduCompete" runat="server"
                                                ErrorMessage="Name" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtName">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="170px" align="left">
                                            <b>Email</b>
                                        </td>
                                        <td width="10px">
                                            :
                                        </td>
                                        <td align="left" width="210px">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="_txtCompete" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvEmail" ValidationGroup="vg_EduCompete" runat="server"
                                                ErrorMessage="Email" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtEmail">&nbsp;</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                    ID="revEmail" runat="server" ErrorMessage="Invalid E-mail ID" ControlToValidate="txtEmail"
                                                    Display="Dynamic" SetFocusOnError="true" ValidationGroup="vg_EduCompete" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="170px" align="left">
                                            <b>City</b>
                                        </td>
                                        <td width="10px">
                                            :
                                        </td>
                                        <td align="left" width="210px">
                                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="_ddlCompete" Width="155px">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvCity" ValidationGroup="vg_EduCompete" runat="server"
                                                ErrorMessage="City" SetFocusOnError="true" Display="Dynamic" ControlToValidate="ddlCity"
                                                InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="170px" align="left">
                                            <b>Current Qualification</b>
                                        </td>
                                        <td width="10px">
                                            :
                                        </td>
                                        <td align="left" width="210px">
                                            <asp:DropDownList ID="ddlQualification" runat="server" CssClass="_ddlCompete" Width="155px">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvQualification" ValidationGroup="vg_EduCompete"
                                                runat="server" ErrorMessage="Current Qualification" SetFocusOnError="true" Display="Dynamic"
                                                ControlToValidate="ddlQualification" InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="170px" align="left">
                                            <b>Date of Birth</b>
                                        </td>
                                        <td width="10px">
                                            :
                                        </td>
                                        <td align="left" colspan="2">
                                            <table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
                                                <tr>
                                                    <td width="80px" align="left">
                                                        <asp:DropDownList ID="ddl_Day" runat="server" Width="80px" CssClass="_ddlCompete">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="5px" align="center">
                                                        <asp:RequiredFieldValidator ID="rfvDay" ValidationGroup="vg_EduCompete" runat="server"
                                                            ErrorMessage="Day" SetFocusOnError="true" Display="Dynamic" ControlToValidate="ddl_Day"
                                                            InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:DropDownList ID="ddl_Month" runat="server" Width="80px" CssClass="_ddlCompete">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="5px" align="center">
                                                        <asp:RequiredFieldValidator ID="rfvMonth" ValidationGroup="vg_EduCompete" runat="server"
                                                            ErrorMessage="Month" SetFocusOnError="true" Display="Dynamic" ControlToValidate="ddl_Month"
                                                            InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:DropDownList ID="ddl_Year" runat="server" Width="80px" CssClass="_ddlCompete">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="5px" align="left">
                                                        <asp:RequiredFieldValidator ID="rfvYear" ValidationGroup="vg_EduCompete" runat="server"
                                                            ErrorMessage="Year" SetFocusOnError="true" Display="Dynamic" ControlToValidate="ddl_Year"
                                                            InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="170px" align="left">
                                            <b>Gender</b>
                                        </td>
                                        <td width="10px">
                                            :
                                        </td>
                                        <td align="left" width="210px">
                                            <asp:RadioButtonList ID="rd_Gender" runat="server">
                                                <asp:ListItem Text="Male" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Female" Value="0"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="170px" align="left">
                                            <b>Phone</b>
                                        </td>
                                        <td width="10px">
                                            :
                                        </td>
                                        <td align="left" width="210px">
                                            <asp:TextBox ID="txtPhone" runat="server" CssClass="_txtCompete" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvPhone" ValidationGroup="vg_EduCompete" runat="server"
                                                ErrorMessage="Phone" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtPhone">&nbsp;</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="170px" align="left">
                                            <b>Address</b>
                                        </td>
                                        <td width="10px">
                                            :
                                        </td>
                                        <td align="left" width="210px">
                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="_txtCompete" TextMode="MultiLine"
                                                Height="40px"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="left">
                                            <asp:LinkButton ID="btn_Submit" runat="server" Text="Submit" CssClass="btnSubmit"
                                                OnClick="btn_Submit_Click" ValidationGroup="vg_EduCompete"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                                <a class="close-reveal-modal">&#215;</a>
                            </div>
                            <div id="Competition_MessageBox" class="reveal-modal xlarge">
                                <asp:Literal ID="ltl_CompetitionMessageBox" runat="server"></asp:Literal>
                                <a class="close-reveal-modal">&#215;</a>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" class="footer">
                &copy;&nbsp;Copyrights | 2013 - 2014 | www.EduVidya.com
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
