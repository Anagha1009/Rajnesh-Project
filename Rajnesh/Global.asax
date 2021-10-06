<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }

    private void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        //RouteTable.Routes.RouteExistingFiles = true;
        routes.Ignore("{resource}.axd/{*pathInfo}");

        routes.MapPageRoute("QueryDetails", "{Query}", "~/QueryDetails.aspx");
        
        
        routes.MapPageRoute("College_Details", "Colleges/{College}", "~/InstituteDetails.aspx");
        routes.MapPageRoute("School_Details", "Schools/{School}", "~/SchoolDetails.aspx");
        routes.MapPageRoute("Content", "Content/{Content}", "~/ContentDetails.aspx");
        routes.MapPageRoute("EntranceExamDetails", "Entrance-Exam/{Exam}", "~/EntranceExamDetails.aspx");
        routes.MapPageRoute("NewsDetails", "News/{News}", "~/NewsDetails.aspx");
        routes.MapPageRoute("Blogs", "Blogs/{Blog}", "~/BlogDetails.aspx");
        routes.MapPageRoute("Search", "Search/{Title}", "~/SearchDetails.aspx");
        routes.MapPageRoute("Studyabroad", "Studyabroad/{Country}", "~/StudyabroadDetails.aspx");

        routes.MapPageRoute("PageDetails.aspx", "Pages/{Page}", "~/PageDetails.aspx");
        
        routes.MapPageRoute("Articles", "Studyabroad/{Country}/{Article}", "~/ArticleDetails.aspx");
        routes.MapPageRoute("GalleryDetails", "Banners/{Banner}", "~/Gallery.aspx");
        routes.MapPageRoute("EbookDetails", "Ebooks/{Ebook}", "~/EbookDetails.aspx");
        routes.MapPageRoute("UniversityDetails", "University/{University}", "~/UniversityDetails.aspx");
        routes.MapPageRoute("DistanceUniversityDetails", "Distance-University/{University}", "~/DistanceUniversityDetails.aspx");

        routes.MapPageRoute("CollegeCourses", "Colleges/{College}/Courses", "~/CollegeCourses.aspx");
        routes.MapPageRoute("Testpapers", "Test-Papers/{CourseName}/{CourseID}", "~/Testpapers.aspx");
        routes.MapPageRoute("EntranceExamColleges", "Entrance-Exam/{Exam}/Colleges", "~/EntranceExamColleges.aspx");

        routes.MapPageRoute("UniversityCourses", "University/{University}/Courses", "~/UniversityCourses.aspx");
        routes.MapPageRoute("UniversityNotifications", "University/{University}/Notifications", "~/UniversityNotifications.aspx");
        routes.MapPageRoute("DistanceUniversityCourses", "Distance-University/{University}/Courses", "~/DistanceUniversityCourses.aspx");
        routes.MapPageRoute("DistanceUniversityStudyCenters", "Distance-University/{University}/StudyCenters", "~/DistanceUniversityStudyCenters.aspx");
        routes.MapPageRoute("DistanceUniversityNotifications", "Distance-University/{University}/Notifications", "~/DistanceUniversityNotifications.aspx");
        
        
        routes.MapPageRoute("Testpaper", "{CourseName}/Test-Paper/{TestPaperName}", "~/TestPaperDetails.aspx");

        routes.MapPageRoute("ExamResults", "Exam-Results/{CourseName}/{CourseID}", "~/ExamResults.aspx");
        routes.MapPageRoute("ExamResult", "{CourseName}/Exam-Result/{ExamResultName}", "~/ExamResultDetails.aspx");
        

        routes.MapPageRoute("CollegeCourseDetails", "Colleges/{College}/Courses/{Course}", "~/CollegeCourseDetails.aspx");
        routes.MapPageRoute("UniversityCourseDetails", "University/{University}/Courses/{Course}", "~/UniversityCourseDetails.aspx");
        routes.MapPageRoute("DistanceUniversityCourseDetails", "Distance-University/{University}/Courses/{Course}", "~/DistanceUniversityCourseDetails.aspx");

        routes.MapPageRoute("StudyabroadUniversityDetails", "Studyabroad/{Country}/University/{Name}", "~/StudyabroadUniversityDetails.aspx");

        routes.MapPageRoute("StudyabroadUniversityCourseDetails", "Studyabroad/{Country}/{University}/{Course}", "~/StudyabroadUniversityCourseDetails.aspx");

        routes.MapPageRoute("AuthorDetails", "Authors/{Author}/{AuthorID}", "~/AuthorDetails.aspx");

        routes.MapPageRoute("InstituteReviews", "{InstituteType}/{Institute}/Reviews", "~/InstituteReviews.aspx");
        routes.MapPageRoute("InstituteReviewDetails", "{InstituteType}/{Institute}/Reviews/{Review}/{ReviewID}", "~/ReviewDetails.aspx");

        routes.MapPageRoute("GalleryPhotoDetails", "Banners/{Banner}/{PhotoID}", "~/Gallery.aspx");

        routes.MapPageRoute("JobGenaratorList", "Careers/{Job}", "~/Careers/File.aspx");
        routes.MapPageRoute("PaperGenaratorList", "Papers/{Paper}", "~/Papers/File.aspx");
        //routes.MapPageRoute("Welcome", "Eduvidya-Competitions", "~/Eduvidya-Competitions.aspx");
        

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
