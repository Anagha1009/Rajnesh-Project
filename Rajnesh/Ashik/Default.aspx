<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Colleges|Schools|Universities|Exams|Courses|Distance Education|India|Eduvidya.com|
    </title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.1/css/all.css"
        integrity="sha384-gfdkjb5BdAXd+lj+gudLWI+BXq4IuLW5IT+brZEZsLFm++aCMlF1V92rMkPaX4PP"
        crossorigin="anonymous" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link href="css/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <header>
        <div class="container">
            <div class="logo" style="font-family: Ubuntu;">
                <h1>
                    <a href="https://www.eduvidya.com/"><img src="images/logo.jpg" alt="logo"/></a></h1>
            </div>
        </div>
    </header>
    <nav class="navbar navbar-default ">
        <div class="container">
            <div class="navbar-header visible-xs">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                    <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar">
                    </span>
                </button>
            </div>
            <div class="collapse navbar-collapse navbar-left" id="myNavbar">
                <ul class="nav navbar-nav">
                    <li><a href="/"><i class="fa fa-home"></i></a></li>
                    <li><a href="/Colleges-in-India.aspx">Colleges</a></li>
                    <li><a href="/Courses-in-India.aspx">Courses</a></li>
                    <li><a href="/Schools-in-India.aspx">Schools</a></li>
                    <li><a href="/Entrance-Exams.aspx">Exams</a></li>
                    <li><a href="/University.aspx">Universities</a></li>
                    <li><a href="/Distance-University.aspx">Distance Education</a></li>
                    <li><a href="/Studyabroad.aspx">Study Abroad</a></li>
                    <li><a href="/Query-List.aspx">Queries</a></li>
                    <li><a href="/Blogs.aspx">Blogs</a></li>
                    <li><a href="http://amp.eduvidya.com/Jobs/Jobs-In-India-For-Freshers">Jobs</a></li>
                    <li><a href="http://amp.eduvidya.com/PlacementPapers/Placement-Papers">Papers</a></li>
                    <li id="last"><a href="/Search.aspx">Search</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="jumbotron text-center">
        <%--<div class="container">
           <div class="google-ad">
                
                <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
                <!-- Eduvidya-Responsive -->
                <ins class="adsbygoogle"
                    style="display: block"
                    data-ad-client="ca-pub-4037987430386783"
                    data-ad-slot="9747444518"
                    data-ad-format="auto"></ins>
                <script>
                    (adsbygoogle = window.adsbygoogle || []).push({});
                </script>
            </div>

      </div>--%>
        <div class="container">
            <div class="row align-items-center">
                <div class="col-12 col-md-5 col-lg-6 order-md-2">
                    <!-- Image -->
                    <img src="https://www.eduvidya.com/admin/Upload/Category/636239843304656644_Colleges in India.jpg"
                        class="img-fluid mw-md-150 mw-lg-130 mb-6 mb-md-0 aos-init aos-animate" alt="..."
                        data-aos="fade-up" data-aos-delay="100">
                </div>
                <div class="col-12 col-md-7 col-lg-6 order-md-1 text-left" data-aos="fade-up">
                    <h3>
                        <a href="#" class="text-white">News</a></h3>
                    <div class="row bnr_row">
                        <div class="col-xs-4">
                            <img src="images/637618665875270690_NTA.jpg" />
                        </div>
                        <div class="col-xs-8">
                            <a href="/News/NEET-UG-2021-Registration-Open">NEET UG 2021 Registration Open</a>
                        </div>
                    </div>
                    <div class="row bnr_row">
                        <div class="col-xs-4">
                            <img src="images/637618665875270690_NTA.jpg" />
                        </div>
                        <div class="col-xs-8">
                            <a href="/News/NEET-UG-2021-Registration-Open">NEET UG 2021 Registration Open</a>
                        </div>
                    </div>
                    <div class="row bnr_row">
                        <div class="col-xs-4">
                            <img src="images/637618665875270690_NTA.jpg" />
                        </div>
                        <div class="col-xs-8">
                            <a href="/News/NEET-UG-2021-Registration-Open">NEET UG 2021 Registration Open</a>
                        </div>
                    </div>
                    <div class="row bnr_row">
                        <div class="col-xs-4">
                            <img src="images/637618665875270690_NTA.jpg" />
                        </div>
                        <div class="col-xs-8">
                            <a href="/News/NEET-UG-2021-Registration-Open">NEET UG 2021 Registration Open</a>
                        </div>
                    </div>
                </div>
            </div>
            <!-- / .row -->
        </div>
    </div>
    <div class="container">
        <div class="Main-section row">
            <div class="col-sm-6">
                <div class="panel panel-danger link_panel">
                    <div class="panel-heading">
                        <h3>
                            <a href="#"><i class="fa fa-graduation-cap"></i>Colleges in India</a></h3>
                    </div>
                    <div class="panel-body">
                        <img src="https://www.eduvidya.com/admin/Upload/Category/634902217038436760_College 2.jpg"
                            title="Schools in India" alt="Schools in India" width="60" height="45">
                        <p>
                            College education continues be the top most priority for students in the country.
                            The education system epitomizes excellence and colleges have been the front runners
                            of this distinction. Institutions of learning covering the length and the breadth
                            of the country have been able to cater to the individual needs and aspirations of
                            students. Collectively these institutions have also been able to play a crucial
                            role in developing and promoting higher education in the country through a number
                            of study options.</p>
                        <ul class="list-group">
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Engineering-Colleges-in-India">
                                Top Engineering Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-MBA-Colleges-in-India">
                                Top MBA Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Medical-Colleges-in-India">
                                Top Medical Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Architecture-Colleges-in-India">
                                Top Architecture Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Hotel-Management-Colleges-in-India">
                                Top Hotel Management Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Journalism-Colleges-in-India">
                                Top Journalism Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-MCA-Colleges-in-India">
                                Top MCA Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Law-Colleges-in-India">
                                Top Law Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/IIM-Colleges-in-India">
                                Top IIM Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/NIT-Colleges-in-India">
                                Top NIT Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-100-Engineering-Colleges-in-India">
                                Top 100 Engineering Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-100-MBA-Colleges-in-India">
                                Top 100 MBA Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-100-Medical-Colleges-in-India">
                                Top 100 Medical Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-BBA-Colleges-in-India">
                                Top BBA Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-BCA-Colleges-in-India">
                                Top BCA Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Fashion-Designing-Colleges-in-India">
                                Top Fashion Designing Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Arts-Colleges-in-India">
                                Top Arts Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Commerce-Colleges-in-India">
                                Top Commerce Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Science-Colleges-in-India">
                                Top Science Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Dental-Colleges-in-India">
                                Top Dental Colleges in India</a> </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="panel panel-danger link_panel">
                    <div class="panel-heading">
                        <h3>
                            <a href="#"><i class="fa fa-address-book"></i>Courses in India</a></h3>
                    </div>
                    <div class="panel-body">
                        <img src="https://www.eduvidya.com/admin/Upload/Category/634902218000958451_Courses 2.jpg"
                            title="Courses in India" alt="Courses in India" width="60" height="45">
                        <p>
                            Academic courses and programs form an important part of the education system. In
                            this aspect Courses in India have been able to cater the various needs of aspirants,
                            these include the professional and academic needs. There are many courses offered
                            in India prominent among them include graduate and post graduate courses, diploma
                            courses, certification courses, professional and fellowship degrees.</p>
                        <ul class="list-group">
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Engineering-Colleges-in-India">
                                Top Engineering Colleges in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/MBA-Courses-in-India">
                                MBA Courses in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/MCA-Courses-in-India">
                                MCA Courses in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/B-Tech-Courses-in-India">
                                B Tech Courses in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/BCA-Courses-in-India">
                                BCA Courses in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Courses-after-12th">Courses
                                after 12th</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Courses-after-Graduation">
                                Courses after Graduation</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Courses-after-12th-Commerce">
                                Courses after 12th Commerce</a> </li>
                            <li class="list-group-item"><a href="http://www.eduvidya.com/Courses-after-12th-Science">
                                Courses after 12th Science</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Courses-after-12th-Arts">
                                Courses after 12th Arts</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Courses-after-Graduation-in-Commerce">
                                Courses after Graduation in Commerce</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Courses-after-Graduation-in-Science">
                                Courses after Graduation in Science</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Courses-after-Graduation-in-Arts">
                                Courses after Graduation in Arts</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Courses-after-10th">Courses
                                after 10th</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/PhD-in-India">PhD in India</a>
                            </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Courses-after-Engineering">
                                Courses after Engineering</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/B-Com-Courses-in-India">
                                BCom Courses in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Medical-Courses-in-India">
                                Medical Courses in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Courses-after-BCom">Courses
                                after BCom</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Certificate-Courses-in-India">
                                Certificate courses in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Diploma-Courses-in-India">
                                Diploma courses in India</a> </li>
                            <li class="list-group-item"><a href="http://www.eduvidya.com/Finance-Courses-in-India">
                                Finance courses in India</a> </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="panel panel-danger link_panel">
                    <div class="panel-heading">
                        <h3>
                            <a href="#"><i class="fa fa-building"></i>Schools in India</a></h3>
                    </div>
                    <div class="panel-body">
                        <img src="https://www.eduvidya.com/admin/Upload/Category/634902220817075397_Schools 2.jpg"
                            title="Schools in India" alt="Schools in India" width="60" height="45">
                        <p>
                            Schools in India are the foundation stones of the country’s education system. Apart
                            from providing a base for formal education, they provide totality that is coupled
                            with both academic excellence and knowledge about various other factors. Schools
                            continue to be the first and the most definitive step and therefore making the right
                            choice is laying the foundation of child’s academic prospects.</p>
                        <ul class="list-group">
                            <li class="list-group-item"><a href="https://www.eduvidya.com/CBSE-Schools-in-India">
                                CBSE Schools in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/ICSE-Schools-in-India">
                                ICSE Schools in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/CBSE-Schools-in-New-Delhi">
                                CBSE Schools in New Delhi</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/CBSE-Schools-in-Mumbai">
                                CBSE Schools in Mumbai</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/CBSE-Schools-in-Bangalore">
                                CBSE Schools in Bangalore</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/CBSE-Schools-in-Hyderabad">
                                CBSE Schools in Hyderabad</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/CBSE-Schools-in-Chennai">
                                CBSE Schools in Chennai</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/CBSE-Schools-in-Pune">
                                CBSE Schools in Pune</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/ICSE-Schools-in-New-Delhi">
                                ICSE Schools in New Delhi</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/ICSE-Schools-in-Bangalore">
                                ICSE Schools in Bangalore</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/ICSE-Schools-in-Mumbai">
                                ICSE Schools in Mumbai</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/ICSE-Schools-in-Hyderabad">
                                ICSE Schools in Hyderabad</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/ICSE-Schools-in-Pune">
                                ICSE Schools in Pune</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/ICSE-Schools-in-Ahmedabad">
                                ICSE Schools in Ahmedabad</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Boarding-Schools-in-India">
                                Top Boarding Schools in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-IB-Schools-in-India">
                                Top IB Schools in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Play-Schools-in-India">
                                Top Play Schools in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Play-Schools-in-Mumbai">
                                Play Schools in Mumbai</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Play-Schools-in-Chennai">
                                Play Schools in Chennai</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Play-Schools-in-Bangalore">
                                Play Schools in Bangalore</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Play-Schools-in-Hyderabad">
                                Play Schools in Hyderabad</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Kendriya-Vidyalayas-in-Mumbai">
                                Kendriya Vidyalayas in Mumbai</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Kendriya-Vidyalayas-in-Pune">
                                Kendriya Vidyalayas in Pune</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Kendriya-Vidyalayas-in-Chennai">
                                Kendriya Vidyalayas in Chennai</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Kendriya-Vidyalayas-in-Bangalore">
                                Kendriya Vidyalayas in Bangalore</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Kendriya-Vidyalayas-in-Hyderabad">
                                Kendriya Vidyalayas in Hyderabad</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Kendriya-Vidyalayas-in-Kolkata">
                                Kendriya Vidyalayas in Kolkata</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Kendriya-Vidyalayas-in-Delhi">
                                Kendriya Vidyalayas in Delhi</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Kendriya-Vidyalayas-in-India">
                                Top Kendriya Vidyalayas in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-10-Kendriya-Vidyalayas-in-India">
                                Top 10 Kendriya Vidyalayas in India</a> </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="panel panel-danger link_panel">
                    <div class="panel-heading">
                        <h3>
                            <a href="#"><i class="fa fa-pen-fancy"></i>Exams in India</a></h3>
                    </div>
                    <div class="panel-body">
                        <img src="https://www.eduvidya.com/admin/Upload/Category/634902222591422513_Exams 2.jpg"
                            title="Exams in India" alt="Exams in India" width="60" height="45">
                        <p>
                            Exams continue to be the source and the summit of the Indian education system. This
                            is asserted by the objectivity and the competitive level of various tests that are
                            conducted in the country both for academic and professionals prospects. Entrance
                            and Professional tests are as important as the course itself and the level of standard
                            and application continues to increase by every passing year.</p>
                        <ul class="list-group">
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/CAT">CAT
                                2020</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/JEE-MAIN">
                                JEE Main 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/GATE">GATE
                                2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/IAS">IAS
                                2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/IPS">IPS
                                2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/JEE-ADVANCED">
                                JEE Advanced 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/MAT">MAT
                                2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/CMAT">CMAT
                                2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/NEET-PG">
                                NEET PG 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/CLAT">CLAT
                                2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/NATA">NATA
                                2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/MHT-CET">
                                MHT CET 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/IBPS">IBPS
                                Exam 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/NDA">NDA
                                2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/AIIMS-MBBS">
                                AIIMS MBBS 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/NEET-UG">
                                NEET UG 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/IFS">IFS
                                2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/GPAT">GPAT
                                2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/NMAT">NMAT
                                2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/IES">IES
                                2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/MPSC">MPSC
                                2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/HSC-Arts-Time-Table">HSC
                                Arts Time Table 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/HSC-Commerce-Time-Table">
                                HSC Commerce Time Table 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/HSC-Science-Time-Table">
                                HSC Science Time Table 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Entrance-Exam/SSC-Exam">
                                SSC Time Table 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/CBSE-10th-Time-Table">
                                CBSE 10th Time Table 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/CBSE-12th-Time-Table">
                                CBSE 12th Time Table 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/ICSE-Time-Table">ICSE
                                Time Table 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/ISC-Time-Table">ISC Time
                                Table 2021</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/UP-Board-12th-Time-Table">
                                UP Board 12th Time Table </a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="panel panel-danger link_panel">
                    <div class="panel-heading">
                        <h3>
                            <a href="#"><i class="fa fa-user-graduate"></i>Universities in India</a></h3>
                    </div>
                    <div class="panel-body">
                        <img src="https://www.eduvidya.com/admin/Upload/Category/635948542251032307_Delhi University Photo.jpg"
                            title="Universities in India" alt="Universities in India" width="60" height="45">
                        <p>
                            There are many Universities in India under different categories. We have Central
                            Universities, Private univerisites, Open Universities and Distance education universities.</p>
                        <ul class="list-group">
                            <li class="list-group-item"><a href="https://www.eduvidya.com/UGC-Recognized-Universities-in-India">
                                UGC Recognized Universities in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Open-Universities-in-India">
                                Open Universities in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Central-Universities-in-India">
                                Central Universities in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Deemed-Universities-in-India">
                                Deemed Universities in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Private-Universities-in-India">
                                Private Universities in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Government-Universities-in-India">
                                Government Universities in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/DEC-approved-Universities-in-India">
                                DEC approved Universities in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Medical-Universities-in-India">
                                Top Medical Universities in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-10-Distance-Education-Universities-in-India">
                                Top 10 Distance Education Universities in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-10-Deemed-Universities-in-India">
                                Top 10 Deemed Universities in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-100-Universities-in-India">
                                Top 100 Universities in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-National-Law-Universities-in-India">
                                Top National Law Universities in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-10-Universities-in-India">
                                Top 10 Universities in India </a></li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Agricultural-Universities-in-India">
                                Top Agricultural Universities in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Veterinary-Universities-in-India">
                                Top Veterinary Universities in India</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Deemed-Universities-in-India-for-Engineering">
                                Top Deemed Universities in India for Engineering</a> </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="panel panel-danger link_panel">
                    <div class="panel-heading">
                        <h3>
                            <a href="#"><i class="fa fa-plane"></i>Study Abroad</a></h3>
                    </div>
                    <div class="panel-body">
                        <img src="https://www.eduvidya.com/admin/Upload/Category/635948545660574295_Study Abroad Image 2.jpg"
                            title="Study Abroad" alt="Study Abroad" width="60" height="45">
                        <p>
                            Studying Abroad has catched up in India in last 5 years with globalization and becasue
                            all the top 100 universities in the World are outside India.</p>
                        <br />
                        <ul class="list-group">
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Universities-in-Australia">
                                Top Universities in Australia </a></li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Universities-in-USA">
                                Top Universities in USA</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Universities-in-Canada">
                                Top Universities in Canada</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Universities-in-UK">
                                Top Universities in UK</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Universities-in-Germany">
                                Top Universities in Germany</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Universities-in-New-Zealand">
                                Top Universities in New Zealand</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Universities-in-Singapore">
                                Top Universities in Singapore</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Top-Universities-in-France">
                                Top Universities in France</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Studyabroad/Australia">
                                Study in Australia</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Studyabroad/USA">Study
                                in USA</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Studyabroad/Canada">Study
                                in Canada</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Studyabroad/UK">Study
                                in UK</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Studyabroad/Germany">Study
                                in Germany</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Studyabroad/New-Zealand">
                                Study in New Zealand</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Studyabroad/Singapore">
                                Study in Singapore</a> </li>
                            <li class="list-group-item"><a href="https://www.eduvidya.com/Studyabroad/France">Study
                                in France</a> </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="panel panel-danger link_panel">
                    <div class="panel-heading">
                        <h3>
                            <a href="#"><i class="fa fa-book-reader"></i>Universities</a></h3>
                    </div>
                    <div class="panel-body">
                        <ul class="list-hirzntl ">
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/University/634169846229188233_UT 2.jpg"
                                            alt="Uttarakhand Technical University, Dehradun">
                                    </div>
                                </div>
                                <a href="/University/Uttarakhand-Technical-University,-Dehradun">Uttarakhand Technical
                                    University, Dehradun</a> </li>
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/University/636251778545331229_West Bengal State University.jpg"
                                            alt="West Bengal State University">
                                    </div>
                                </div>
                                <a href="/University/West-Bengal-State-University">West Bengal State University</a>
                            </li>
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/University/634170482945242566_SIU Pune.jpg"
                                            alt="Symbiosis International University">
                                    </div>
                                </div>
                                <a href="/University/Symbiosis-International-University">Symbiosis International University</a>
                            </li>
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/University/634178451603965664_NIT Trichi.jpg"
                                            alt="National Institute of Technology NIT Trichy">
                                    </div>
                                </div>
                                <a href="/University/National-Institute-of-Technology-NIT-Trichy">National Institute
                                    of Technology NIT Trichy</a> </li>
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/University/633843908687389636_589.jpeg"
                                            alt="Rabindra Bharati University">
                                    </div>
                                </div>
                                <a href="/University/Rabindra-Bharati-University">Rabindra Bharati University</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="panel panel-danger link_panel">
                    <div class="panel-heading">
                        <h3>
                            <a href="#"><i class="fa fa-book-reader"></i>Institutes</a></h3>
                    </div>
                    <div class="panel-body">
                        <ul class="list-hirzntl">
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/Institutes/634937795082843850_jwahar.jpg"
                                            alt="Jawaharlal Nehru Architecture and Fine Arts University">
                                    </div>
                                </div>
                                <a href="/Colleges/Jawaharlal-Nehru-Architecture-and-Fine-Arts-University">Jawaharlal
                                    Nehru Architecture and Fine Arts University</a> </li>
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/Institutes/636433251695920370_Indian Institute of Management, Jammu.png"
                                            alt="Indian Institute of Management, Jammu (IIM Jammu)">
                                    </div>
                                </div>
                                <a href="/Colleges/Indian-Institute-of-Management,-Jammu-(IIM-Jammu)">Indian Institute
                                    of Management, Jammu (IIM Jammu)</a> </li>
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/Institutes/635284265482725564_Jeppiaar Engineering College.jpeg"
                                            alt="Jeppiaar Engineering College">
                                    </div>
                                </div>
                                <a href="/Colleges/Jeppiaar-Engineering-College">Jeppiaar Engineering College</a>
                            </li>
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/Institutes/636511905782018354_Shri Labhubhai Trivedi Institute of Engineering &amp; Technology.png"
                                            alt="Shri Labhubhai Trivedi Institute of Engineering &amp; Technology">
                                    </div>
                                </div>
                                <a href="/Colleges/Shri-Labhubhai-Trivedi-Institute-of-Engineering-&amp;-Technology">
                                    Shri Labhubhai Trivedi Institute of Engineering &amp; Technology</a> </li>
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/Institutes/637206518099554685_No Image.png"
                                            alt="Rajiv Gandhi Degree College">
                                    </div>
                                </div>
                                <a href="/Colleges/Rajiv-Gandhi-Degree-College">Rajiv Gandhi Degree College</a>
                            </li>
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/Institutes/637027041070845138_Maharana Institute of Professional Studies (MIPS).jpg"
                                            alt="Maharana Institute of Professional Studies (MIPS)">
                                    </div>
                                </div>
                                <a href="/Colleges/Maharana-Institute-of-Professional-Studies-(MIPS)">Maharana Institute
                                    of Professional Studies (MIPS)</a> </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="panel panel-danger link_panel">
                    <div class="panel-heading">
                        <h3>
                            <a href="#"><i class="fa fa-book-reader"></i>Schools</a></h3>
                    </div>
                    <div class="panel-body">
                        <ul class="list-hirzntl">
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/Schools/635053572885238312_st john.gif"
                                            alt="Saint Johns High School">
                                    </div>
                                </div>
                                <a href="/Schools/Saint-Johns-High-School">Saint Johns High School</a> </li>
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/Schools/634912726159378151_no image available.jpg"
                                            alt="Bright Foundation Nursery School">
                                    </div>
                                </div>
                                <a href="/Schools/Bright-Foundation-Nursery-School">Bright Foundation Nursery School</a>
                            </li>
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/Schools/636245054915714617_Delhi Public School, Bhiwani.jpg"
                                            alt="Delhi Public School, Bhiwani">
                                    </div>
                                </div>
                                <a href="/Schools/Delhi-Public-School,-Bhiwani">Delhi Public School, Bhiwani</a>
                            </li>
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/Schools/635854375932187603_Lourdes Public School and Junior College.png"
                                            alt="Lourdes Public School and Junior College">
                                    </div>
                                </div>
                                <a href="/Schools/Lourdes-Public-School-and-Junior-College">Lourdes Public School and
                                    Junior College</a> </li>
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/Schools/635951984070458065_Kendriya Vidyalaya, Manmad.jpg"
                                            alt="Kendriya Vidyalaya, Manmad">
                                    </div>
                                </div>
                                <a href="/Schools/Kendriya-Vidyalaya,-Manmad">Kendriya Vidyalaya, Manmad</a>
                            </li>
                            <li>
                                <div class="image-dv">
                                    <div class="image-dv-inner">
                                        <img src="https://www.eduvidya.com/admin/Upload/Schools/636245720304440472_Delhi Public School Jamnagar.jpg"
                                            alt="Delhi Public School Jamnagar">
                                    </div>
                                </div>
                                <a href="/Schools/Delhi-Public-School-Jamnagar">Delhi Public School Jamnagar</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="panel panel-danger link_panel">
                    <div class="panel-heading">
                        <h3>
                            <a href="#">Most Searched Queries</a>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <ul class="link-list">
                            <li><a href="/Top-ECE-Engineering-Colleges-in-Tamilnadu">Top ECE Engineering Colleges
                                in Tamilnadu</a></li>
                            <li><a href="/BCA-Colleges-in-Hyderabad">BCA Colleges in Hyderabad</a></li>
                            <li><a href="/Top-Law-Colleges-in-Pune">Top Law Colleges in Pune</a></li>
                            <li><a href="/Top-Dental-Colleges-in-Nagpur">Top Dental Colleges in Nagpur</a></li>
                            <li><a href="/Top-COMEDK-Colleges">Top COMEDK Colleges</a></li>
                            <li><a href="/Top-CBSE-Schools-in-Port-Blair">Top CBSE Schools in Port Blair</a></li>
                            <li><a href="/Top-Engineering-Colleges-in-AP">Top Engineering Colleges in AP</a></li>
                            <li><a href="/Top-Kendriya-Vidyalayas-in-Odisha">Top Kendriya Vidyalayas in Odisha</a></li>
                            <li><a href="/UPSEE-Admit-Card">UPSEE Admit Card</a></li>
                            <li><a href="/Top-Kendriya-Vidyalayas-in-India">Top Kendriya Vidyalayas in India</a></li>
                            <li><a href="Query-List.aspx">more...</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <footer class="section footer-classic context-dark bg-image" style="background: #2d3246;">
        <div class="container">
            <div class="row ">
                <div class="col-xl-12">
                    <p>
                        <a href="/Content/About-Us">About us</a> | <a href="/Our-Team.aspx">Our Team</a>
                        | <a href="/Content/Contact-Us">Contact us</a> | <a href="/Content/Advertise-With-Us">
                            Advertise With Us</a> | <a href="/Content/Privacy-Policy">Privacy policy</a>
                        | <a href="/Content/Terms-and-Conditions">Terms &amp; Conditions</a> | <a href="/Sitemap.aspx">
                            Sitemap</a> |
                    </p>
                </div>
                <div class="col-xl-12">
                    <span>Copyright © 2013-2016-17. www.eduvidya.com</span>
                </div>
            </div>
        </div>
    </footer>
    </form>
</body>
</html>
