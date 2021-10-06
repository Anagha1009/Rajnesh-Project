<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EducationLeads.ascx.cs"
    Inherits="UserControls_EducationLeads" %>
<link href='https://fonts.googleapis.com/css?family=Joti+One' rel='stylesheet' type='text/css' />
<style type="text/css">
    #container-helpdesk
    {
        background-image: url('https://www.eduvidya.com/back/back_4.jpg');
        padding: 1px;
        -webkit-border-radius: 5px;
        -moz-border-radius: 5px;
        border-radius: 5px;
    }*/
    
    ._edulink
    {
        color: #fff;
        text-decoration: none;
    }
    
    ._edulink:hover
    {
        color: #fff !important;
        text-decoration: none;
    }
    
    .ilogo
    {
        font-family: 'Joti One' , cursive;
        color: #efefef;
        font-size: 21px;
        float: left;
        text-align: center;
        font-style: italic;
        display: table-cell;
        vertical-align: middle;
        width: 160px;
        padding: 5px;
    }
    
    .ilogo a
    {
        color: #fff;
        text-decoration: none;
        border: 0px;
    }
    
    .ilogo a:hover
    {
        color: #fff;
        text-decoration: none;
        border: 0px;
    }
    
    .tagline
    {
        font-size: 15px;
        font-family: Trebuchet MS;
    }
    
    #main_part
    {
        width: 160px;
        color: #fff;
        font-family: Trebuchet MS;
        font-size: 13px;
        -webkit-border-top-left-radius: 5px;
        -webkit-border-top-right-radius: 5px;
        -moz-border-radius-topleft: 5px;
        -moz-border-radius-topright: 5px;
        border-top-left-radius: 5px;
        border-top-right-radius: 5px;
    }
    
    .areYou
    {
        font-size: 15px;
    }
    .clickHere
    {
        font-size: 15px;
        text-decoration: underline;
    }
</style>
<%--<script type="text/javascript">
    $(document).ready(function () {
        var images = ['logo_back.jpg', 'back_1.jpg', 'back_2.jpg', 'back_3.jpg', 'back_4.jpg'];
        var i = 0;
        setInterval(function () {
            $("#container").fadeOut('slow', function () {
                $("#container").css('background-image', function () { if (i >= images.length) { i = 0; } return 'url(' + 'https://www.eduvidya.com/back/' + images[i++] + ')'; }).fadeIn('slow');
            });
        }, 9000);
    });
</script>--%>
<table id="main_part" cellpadding="0px" cellspacing="0px" border="0px">
    <tr>
        <td align="left" id="container-helpdesk">
            <a href="https://www.eduvidya.com/Education-Help.aspx" id="hyp_Link" runat="server"
                class="_edulink" target="_blank">
                <div class="upper_part">
                    <span class="areYou">
                        <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></span>
                    <div style="clear: both">
                        &nbsp;</div>
                    Get Free Guidance on Admissions, Education Loan, Career, Entrance Exam, Studyabroad
                    from EduVidya.com.
                    <div style="clear: both; height: 10px">
                    </div>
                    <center>
                        <span class="clickHere">Click here</span></center>
                </div>
                <div class="ilogo">
                    <img src="https://www.eduvidya.com/img/EducationHelp.png" alt="Education-help" width="110px" />
                    EduVidya.com<br /><span class="tagline">HelpDesk!</span>
                </div>
            </a>
        </td>
    </tr>
</table>

