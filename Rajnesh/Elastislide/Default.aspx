<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Laboratory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="https://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Laboratory</title>
    <script src="https://code.jquery.com/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8">
        $(document).ready(function () {
            $(".box").hide();
            $(".Iconbox").click(function () {
                var myelement = $(this).attr("id").replace("hyp_", "#");
                $(myelement).slideToggle('slow');
                $(".box:visible").not(myelement).hide();
            });
        });
                 
    </script>
    <style type="text/css">
        body
        {
            color: #444;
            font-size: 15px;
            font-family: Trebuchet MS;
        }
        .Iconbox
        {
            cursor: pointer;
            float: left;
            padding: 10px;
            font-size: 17px;
        }
        
        .box
        {
            border: 1px solid #ccc;
            padding: 25px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 7px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="Iconbox" id="hyp_About">
            About</div>
        <div class="Iconbox" id="hyp_Portfolio">
            Portfolio</div>
        <div class="Iconbox" id="hyp_Contact">
            Contact</div>
    </div>
    <div style="clear: both">
        &nbsp;</div>
    <div>
        <div class="box" id="About">
            Hi Guys, I am Ashik Ali Shah. I am working in Webwerks India Pvt ltd as a Software
            Programmer. Lets check the work done from my end. InfiniteCourses.com | Studyabroaduniversities.com
            | TopMBAIndia.com
        </div>
        <div class="box" id="Portfolio">
            <div class="container demo-1">
                <link rel="stylesheet" type="text/css" href="css/demo.css" />
                <link rel="stylesheet" type="text/css" href="css/elastislide.css" />
                <link rel="stylesheet" type="text/css" href="css/custom.css" />
                <script src="js/modernizr.custom.17475.js"></script>
                <div class="main">
                    <ul id="carousel" class="elastislide-list">
                        <li><a href="#">
                            <img src="images/small/1.jpg" alt="image01" /></a></li>
                        <li><a href="#">
                            <img src="images/small/2.jpg" alt="image02" /></a></li>
                        <li><a href="#">
                            <img src="images/small/3.jpg" alt="image03" /></a></li>
                        <li><a href="#">
                            <img src="images/small/4.jpg" alt="image04" /></a></li>
                        <li><a href="#">
                            <img src="images/small/5.jpg" alt="image05" /></a></li>
                        <li><a href="#">
                            <img src="images/small/6.jpg" alt="image06" /></a></li>
                        <li><a href="#">
                            <img src="images/small/7.jpg" alt="image07" /></a></li>
                        <li><a href="#">
                            <img src="images/small/8.jpg" alt="image08" /></a></li>
                        <li><a href="#">
                            <img src="images/small/9.jpg" alt="image09" /></a></li>
                        <li><a href="#">
                            <img src="images/small/10.jpg" alt="image10" /></a></li>
                        <li><a href="#">
                            <img src="images/small/11.jpg" alt="image11" /></a></li>
                        <li><a href="#">
                            <img src="images/small/12.jpg" alt="image12" /></a></li>
                        <li><a href="#">
                            <img src="images/small/13.jpg" alt="image13" /></a></li>
                        <li><a href="#">
                            <img src="images/small/14.jpg" alt="image14" /></a></li>
                        <li><a href="#">
                            <img src="images/small/15.jpg" alt="image15" /></a></li>
                        <li><a href="#">
                            <img src="images/small/16.jpg" alt="image16" /></a></li>
                        <li><a href="#">
                            <img src="images/small/17.jpg" alt="image17" /></a></li>
                        <li><a href="#">
                            <img src="images/small/18.jpg" alt="image18" /></a></li>
                        <li><a href="#">
                            <img src="images/small/19.jpg" alt="image19" /></a></li>
                        <li><a href="#">
                            <img src="images/small/20.jpg" alt="image20" /></a></li>
                    </ul>
                </div>
            </div>
            <script type="text/javascript" src="js/jquerypp.custom.js"></script>
            <script type="text/javascript" src="js/jquery.elastislide.js"></script>
            <script type="text/javascript">

                $('#carousel').elastislide();
               
			
            </script>
        </div>
        <div class="box" id="Contact">
            Feel free to Contact me at ashik@wwindia.com
        </div>
    </div>
    </form>
</body>
</html>
