using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Xml;
using System.Data;
using System.Text.RegularExpressions;
using yo_lib;

public partial class Sitemap_Generator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            tr_Sitemap.Visible = false;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            fn_GenerateXMLSitemaps();

            if (Directory.Exists(Server.MapPath("~/Sitemaps")))
            {
                string strSourcePath = Server.MapPath("~/Sitemaps");
                string strDestPath = Server.MapPath("~/Sitemaps_files/Sitemap_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year);

                string strDateStamp = DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year;

                string strRouteUrl = "~/Sitemaps_files/Sitemap_" + strDateStamp;

                if (Directory.Exists(Server.MapPath(strRouteUrl)))
                {
                    Directory.Delete(Server.MapPath(strRouteUrl), true);
                }

                if (File.Exists(Server.MapPath(strRouteUrl + "zip")))
                {
                    File.Delete(Server.MapPath(strRouteUrl + "zip"));
                }

                if (strSourcePath != strDestPath)
                {
                    CopyFolder(strSourcePath, strDestPath);
                }

                fn_ZipFolder(strRouteUrl);

                hyp_Sitemap.HRef = "https://www.eduvidya.com/Sitemaps_files/Sitemap_" + strDateStamp + ".zip";
                tr_Sitemap.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_GenerateXMLSitemaps()
    {
        try
        {
            
            //fn_GenerateUniversitySitemap();
            //fn_GenerateDistanceUniversitySitemap();
            //fn_GenerateDistanceCollegesSitemap();
            //fn_GenerateDistanceUniversityCoursesSitemap();
            //fn_GenerateUniversityCoursesSitemap();

            fn_GenerateInstituteSitemap();
            fn_GenerateInstituteCoursesSitemap();
            fn_GenerateEntranceExamSitemap();
            fn_GenerateStudyabroadSitemap();
            fn_GenerateQuerySitemap();
            fn_GenerateSearchSitemap();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_GenerateInstituteSitemap()
    {
        try
        {
            string strSitemap = "Sitemap1.xml";

            if (File.Exists(MapPath("~/Sitemaps/" + strSitemap)))
            {
                File.Delete((MapPath("~/Sitemaps/" + strSitemap)));
            }

            File.Copy(Server.MapPath("~/Sitemaps_files/DemoSitemap.xml"), Server.MapPath("~/Sitemaps/" + strSitemap));
            string SiteMapFile = @"~/Sitemaps/" + strSitemap;
            string xmlFile = Server.MapPath(SiteMapFile);

            XmlTextWriter writer = new XmlTextWriter(xmlFile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns:xsi", "https://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "https://www.sitemaps.org/schemas/sitemap/0.9 https://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            writer.WriteAttributeString("xmlns", "https://www.sitemaps.org/schemas/sitemap/0.9");

            InstituteClass objInstitute = new InstituteClass();
            CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteList();
            if (objInstituteList.Count > 0)
            {
                for (int i = 0; i < objInstituteList.Count; i++)
                {
                    string strUrl = "https://www.eduvidya.com/Colleges/" + objInstituteList[i].strTitle.Replace(" ", "-").Replace(".", "_");

                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", strUrl);
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", "0.7");
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_GenerateUniversitySitemap()
    {
        try
        {
            string strSitemap = "Sitemap2.xml";

            if (File.Exists(MapPath("~/Sitemaps/" + strSitemap)))
            {
                File.Delete((MapPath("~/Sitemaps/" + strSitemap)));
            }

            File.Copy(Server.MapPath("~/Sitemaps_files/DemoSitemap.xml"), Server.MapPath("~/Sitemaps/" + strSitemap));
            string SiteMapFile = @"~/Sitemaps/" + strSitemap;
            string xmlFile = Server.MapPath(SiteMapFile);

            XmlTextWriter writer = new XmlTextWriter(xmlFile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns:xsi", "https://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "https://www.sitemaps.org/schemas/sitemap/0.9 https://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            writer.WriteAttributeString("xmlns", "https://www.sitemaps.org/schemas/sitemap/0.9");

            UniversityListClass objUniversity = new UniversityListClass();
            CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_getUniversityList();
            if (objUniversityList.Count > 0)
            {
                for (int i = 0; i < objUniversityList.Count; i++)
                {
                    string strUrl = "https://www.eduvidya.com/Universities/" + objUniversityList[i].strTitle.Replace(" ", "-").Replace(".", "_");

                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", strUrl);
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", "0.7");
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_GenerateDistanceUniversitySitemap()
    {
        try
        {
            string strSitemap = "Sitemap3.xml";

            if (File.Exists(MapPath("~/Sitemaps/" + strSitemap)))
            {
                File.Delete((MapPath("~/Sitemaps/" + strSitemap)));
            }

            File.Copy(Server.MapPath("~/Sitemaps_files/DemoSitemap.xml"), Server.MapPath("~/Sitemaps/" + strSitemap));
            string SiteMapFile = @"~/Sitemaps/" + strSitemap;
            string xmlFile = Server.MapPath(SiteMapFile);

            XmlTextWriter writer = new XmlTextWriter(xmlFile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns:xsi", "https://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "https://www.sitemaps.org/schemas/sitemap/0.9 https://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            writer.WriteAttributeString("xmlns", "https://www.sitemaps.org/schemas/sitemap/0.9");

            DistanceLearningClass objDistance = new DistanceLearningClass();
            objDistance.strType = "University";
            CoreWebList<DistanceLearningClass> objDistanceList = objDistance.fn_GetDistanceLearningListByType();
            if (objDistanceList.Count > 0)
            {
                for (int i = 0; i < objDistanceList.Count; i++)
                {
                    string strUrl = "https://www.eduvidya.com/University/" + objDistanceList[i].strName.Replace(" ", "-");

                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", strUrl);
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", "0.7");
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_GenerateDistanceCollegesSitemap()
    {
        try
        {
            string strSitemap = "Sitemap4.xml";

            if (File.Exists(MapPath("~/Sitemaps/" + strSitemap)))
            {
                File.Delete((MapPath("~/Sitemaps/" + strSitemap)));
            }

            File.Copy(Server.MapPath("~/Sitemaps_files/DemoSitemap.xml"), Server.MapPath("~/Sitemaps/" + strSitemap));
            string SiteMapFile = @"~/Sitemaps/" + strSitemap;
            string xmlFile = Server.MapPath(SiteMapFile);

            XmlTextWriter writer = new XmlTextWriter(xmlFile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns:xsi", "https://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "https://www.sitemaps.org/schemas/sitemap/0.9 https://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            writer.WriteAttributeString("xmlns", "https://www.sitemaps.org/schemas/sitemap/0.9");

            DistanceLearningClass objDistance = new DistanceLearningClass();
            objDistance.strType = "Institute";
            CoreWebList<DistanceLearningClass> objDistanceList = objDistance.fn_GetDistanceLearningListByType();
            if (objDistanceList.Count > 0)
            {
                for (int i = 0; i < objDistanceList.Count; i++)
                {
                    string strUrl = "https://www.eduvidya.com/Distance-Colleges/" + objDistanceList[i].strName.Replace(" ", "-");

                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", strUrl);
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", "0.7");
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_GenerateInstituteCoursesSitemap()
    {
        try
        {
            string strSitemap = "Sitemap2.xml";

            if (File.Exists(MapPath("~/Sitemaps/" + strSitemap)))
            {
                File.Delete((MapPath("~/Sitemaps/" + strSitemap)));
            }

            File.Copy(Server.MapPath("~/Sitemaps_files/DemoSitemap.xml"), Server.MapPath("~/Sitemaps/" + strSitemap));
            string SiteMapFile = @"~/Sitemaps/" + strSitemap;
            string xmlFile = Server.MapPath(SiteMapFile);

            XmlTextWriter writer = new XmlTextWriter(xmlFile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns:xsi", "https://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "https://www.sitemaps.org/schemas/sitemap/0.9 https://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            writer.WriteAttributeString("xmlns", "https://www.sitemaps.org/schemas/sitemap/0.9");

            InstituteCourseClass objCourse = new InstituteCourseClass();
            CoreWebList<InstituteCourseClass> objCourseList = objCourse.fn_getInstituteCourseList();
            if (objCourseList.Count > 0)
            {
                for (int i = 0; i < objCourseList.Count; i++)
                {
                    string strUrl = "https://www.eduvidya.com/Colleges/" + objCourseList[i].strInstitute.Replace(" ", "-").Replace(".", "_") + "/Courses/" + objCourseList[i].strTitle.Replace(" ", "-");

                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", strUrl);
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", "0.7");
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_GenerateUniversityCoursesSitemap()
    {
        try
        {
            string strSitemap = "Sitemap6.xml";

            if (File.Exists(MapPath("~/Sitemaps/" + strSitemap)))
            {
                File.Delete((MapPath("~/Sitemaps/" + strSitemap)));
            }

            File.Copy(Server.MapPath("~/Sitemaps_files/DemoSitemap.xml"), Server.MapPath("~/Sitemaps/" + strSitemap));
            string SiteMapFile = @"~/Sitemaps/" + strSitemap;
            string xmlFile = Server.MapPath(SiteMapFile);

            XmlTextWriter writer = new XmlTextWriter(xmlFile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns:xsi", "https://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "https://www.sitemaps.org/schemas/sitemap/0.9 https://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            writer.WriteAttributeString("xmlns", "https://www.sitemaps.org/schemas/sitemap/0.9");

            UniversityListClass objUniversityCourses = new UniversityListClass();
            CoreWebList<UniversityListClass> objUniversityCoursesList = objUniversityCourses.fn_GetUniversityCourseList();
            if (objUniversityCoursesList.Count > 0)
            {
                for (int i = 0; i < objUniversityCoursesList.Count; i++)
                {
                    string strUrl = "https://www.eduvidya.com/Universities/" + objUniversityCoursesList[i].strTitle.Replace(" ", "-") + "/Courses/" + objUniversityCoursesList[i].strCourseName.Replace(" ", "-");

                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", strUrl);
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", "0.7");
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_GenerateDistanceUniversityCoursesSitemap()
    {
        try
        {
            string strSitemap = "Sitemap7.xml";

            if (File.Exists(MapPath("~/Sitemaps/" + strSitemap)))
            {
                File.Delete((MapPath("~/Sitemaps/" + strSitemap)));
            }

            File.Copy(Server.MapPath("~/Sitemaps_files/DemoSitemap.xml"), Server.MapPath("~/Sitemaps/" + strSitemap));
            string SiteMapFile = @"~/Sitemaps/" + strSitemap;
            string xmlFile = Server.MapPath(SiteMapFile);

            XmlTextWriter writer = new XmlTextWriter(xmlFile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns:xsi", "https://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "https://www.sitemaps.org/schemas/sitemap/0.9 https://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            writer.WriteAttributeString("xmlns", "https://www.sitemaps.org/schemas/sitemap/0.9");

            DLCoursesClass objCourse = new DLCoursesClass();
            CoreWebList<DLCoursesClass> objCourseList = objCourse.fn_getCoursesList();
            if (objCourseList.Count > 0)
            {
                for (int i = 0; i < objCourseList.Count; i++)
                {
                    string strUrl = "https://www.eduvidya.com/" + objCourseList[i].strType + "/" + objCourseList[i].strInstitute.Replace(" ", "-").Replace("&", "-").Replace(":", "-").Replace(".", "-").Replace("?", "-").Replace(",", "-").Replace("%", "-").Replace("/", "-").Replace("---", "-").Replace("--", "-") + "/Course/" + objCourseList[i].strName.Replace(" ", "-").Replace("&", "-").Replace(":", "-").Replace("?", "-").Replace(",", "-").Replace(".", "-").Replace("%", "-").Replace("/", "-").Replace("---", "-").Replace("--", "-") + "/" + objCourseList[i].iID;

                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", strUrl);
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", "0.7");
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_GenerateEntranceExamSitemap()
    {
        try
        {
            string strSitemap = "Sitemap3.xml";

            if (File.Exists(MapPath("~/Sitemaps/" + strSitemap)))
            {
                File.Delete((MapPath("~/Sitemaps/" + strSitemap)));
            }

            File.Copy(Server.MapPath("~/Sitemaps_files/DemoSitemap.xml"), Server.MapPath("~/Sitemaps/" + strSitemap));
            string SiteMapFile = @"~/Sitemaps/" + strSitemap;
            string xmlFile = Server.MapPath(SiteMapFile);

            XmlTextWriter writer = new XmlTextWriter(xmlFile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns:xsi", "https://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "https://www.sitemaps.org/schemas/sitemap/0.9 https://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            writer.WriteAttributeString("xmlns", "https://www.sitemaps.org/schemas/sitemap/0.9");

            EntranceExamClass objEntrance = new EntranceExamClass();
            CoreWebList<EntranceExamClass> objEntranceList = objEntrance.fn_getEntranceExamList();
            if (objEntranceList.Count > 0)
            {
                for (int i = 0; i < objEntranceList.Count; i++)
                {
                    string strUrl = "https://www.eduvidya.com/Entrance-Exam/" + objEntranceList[i].strTitle.Replace(" ", "-");

                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", strUrl);
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", "0.7");
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_GenerateStudyabroadSitemap()
    {
        try
        {
            string strSitemap = "Sitemap4.xml";

            if (File.Exists(MapPath("~/Sitemaps/" + strSitemap)))
            {
                File.Delete((MapPath("~/Sitemaps/" + strSitemap)));
            }

            File.Copy(Server.MapPath("~/Sitemaps_files/DemoSitemap.xml"), Server.MapPath("~/Sitemaps/" + strSitemap));
            string SiteMapFile = @"~/Sitemaps/" + strSitemap;
            string xmlFile = Server.MapPath(SiteMapFile);

            XmlTextWriter writer = new XmlTextWriter(xmlFile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns:xsi", "https://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "https://www.sitemaps.org/schemas/sitemap/0.9 https://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            writer.WriteAttributeString("xmlns", "https://www.sitemaps.org/schemas/sitemap/0.9");

            CountryClass objStudy = new CountryClass();
            CoreWebList<CountryClass> objStudyList = objStudy.fn_getCountryList();
            if (objStudyList.Count > 0)
            {
                for (int i = 0; i < objStudyList.Count; i++)
                {
                    string strUrl = "https://www.eduvidya.com/Studyabroad/" + objStudyList[i].strTitle.Replace(" ", "-").Replace(".", "_");

                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", strUrl);
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", "0.7");
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_GenerateQuerySitemap()
    {
        try
        {
            string strSitemap = "Sitemap5.xml";

            if (File.Exists(MapPath("~/Sitemaps/" + strSitemap)))
            {
                File.Delete((MapPath("~/Sitemaps/" + strSitemap)));
            }

            File.Copy(Server.MapPath("~/Sitemaps_files/DemoSitemap.xml"), Server.MapPath("~/Sitemaps/" + strSitemap));
            string SiteMapFile = @"~/Sitemaps/" + strSitemap;
            string xmlFile = Server.MapPath(SiteMapFile);

            XmlTextWriter writer = new XmlTextWriter(xmlFile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns:xsi", "https://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "https://www.sitemaps.org/schemas/sitemap/0.9 https://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            writer.WriteAttributeString("xmlns", "https://www.sitemaps.org/schemas/sitemap/0.9");

            QueryGeneratorClass objQuery = new QueryGeneratorClass();
            CoreWebList<QueryGeneratorClass> objQueryList = objQuery.fn_getQueryGeneratorList();
            if (objQueryList.Count > 0)
            {
                for (int i = 0; i < objQueryList.Count; i++)
                {
                    string strUrl = "https://www.eduvidya.com/" + objQueryList[i].strTitle.ToString().Replace(" ", "-");

                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", strUrl);
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", "0.7");
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_GenerateSearchSitemap()
    {
        try
        {
            string strSitemap = "Sitemap6.xml";

            if (File.Exists(MapPath("~/Sitemaps/" + strSitemap)))
            {
                File.Delete((MapPath("~/Sitemaps/" + strSitemap)));
            }

            File.Copy(Server.MapPath("~/Sitemaps_files/DemoSitemap.xml"), Server.MapPath("~/Sitemaps/" + strSitemap));
            string SiteMapFile = @"~/Sitemaps/" + strSitemap;
            string xmlFile = Server.MapPath(SiteMapFile);

            XmlTextWriter writer = new XmlTextWriter(xmlFile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns:xsi", "https://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "https://www.sitemaps.org/schemas/sitemap/0.9 https://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            writer.WriteAttributeString("xmlns", "https://www.sitemaps.org/schemas/sitemap/0.9");

            PageGeneratorClass objPage = new PageGeneratorClass();
            CoreWebList<PageGeneratorClass> objPageList = objPage.fn_getPageGeneratorList();
            if (objPageList.Count > 0)
            {
                for (int i = 0; i < objPageList.Count; i++)
                {
                    string strUrl = "https://www.eduvidya.com/Search/" + objPageList[i].strTitle.ToString().Replace(" ", "-").Replace(".", "_");

                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", strUrl);
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", "0.7");
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void CopyFolder(string sourceFolder, string destFolder)
    {
        try
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_ZipFolder(string strRouteUrl)
    {
        try
        {
            string strDirectory = Server.MapPath(strRouteUrl);

            ICSharpCode.SharpZipLib.Zip.FastZip z = new ICSharpCode.SharpZipLib.Zip.FastZip();
            z.CreateEmptyDirectories = true;
            z.CreateZip(strDirectory + ".zip", strDirectory, true, "");

            if (File.Exists(strDirectory + ".zip"))
            {
                if (System.IO.Directory.Exists(strDirectory))
                {
                    System.IO.Directory.Delete(strDirectory, true);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}