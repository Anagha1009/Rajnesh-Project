<%@ Page Language="C#" MasterPageFile="~/admin/Master.master" AutoEventWireup="true"
    CodeFile="CompetitionUserFiles.aspx.cs" Inherits="admin_CompetitionUserFiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cp_head" runat="Server">
<script src="http://www.eduvidya.com/JW_Player/jwplayer.js" type="text/javascript"></script>
    <!-- Add mousewheel plugin (this is optional) -->
    <script type="text/javascript" src="http://eduvidya.com/fancybox/lib/jquery.mousewheel-3.0.6.pack.js"></script>
    <!-- Add fancyBox main JS and CSS files -->
    <script type="text/javascript" src="http://eduvidya.com/fancybox/source/jquery.fancybox.js?v=2.1.5"></script>
    <link rel="stylesheet" type="text/css" href="http://eduvidya.com/fancybox/source/jquery.fancybox.css?v=2.1.5"
        media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('.fancybox').fancybox();
        });
	</script>
    <style type="text/css">
        .fancybox-custom .fancybox-skin
        {
            box-shadow: 0 0 50px #222;
        }
        .CompeteImageBox
        {
            border: 1px solid #ccc;
            padding: 2px;
            display: table-cell;
            vertical-align: middle;
            text-align: center;
            float: left;
            margin-right: 7px;
        }
        
        .CompeteImageBox img
        {
            max-width: 561px;
            padding: 2px;
        }
        
        ._CompeteTitle
        {
            font-family: Trebuchet MS;
            font-size: 17px;
            font-style: italic;
            font-weight: bold;
            color: #444;
        }
        
        .clear
        {
            clear:both;
            height:25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <div class="_CompeteTitle">
        <asp:Literal ID="ltl_User" runat="server"></asp:Literal></div>
    <div style="clear: both">
        &nbsp;</div>
    <asp:Literal ID="ltl_Files" runat="server"></asp:Literal>
</asp:Content>
