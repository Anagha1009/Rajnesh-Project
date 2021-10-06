using System;
using System.IO;
using System.Web.UI;
using yo_lib;

public partial class Paper_files : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Page.RouteData.Values["Paper"] != null)
            {
                string fileName = Page.RouteData.Values["Paper"].ToString();
                Papers1.FileName = fileName;
                try
                {
                    var objPaper = new PaperGeneratorClass {strFileName = Path.GetFileName(Request.PhysicalPath)};
                    CoreWebList<PaperGeneratorClass> objPaperList = objPaper.fn_GetPaperListByFileName();
                    if (objPaperList.Count > 0)
                    {
                        meta_title.Attributes.Add("content", objPaperList[0].strMetaTitle);
                        meta_Description.Attributes.Add("content", objPaperList[0].strMetaDescription);
                        meta_Keywords.Attributes.Add("content", objPaperList[0].strKeywords);

                        PaperGeneratorClass objQuery = new PaperGeneratorClass { strCategory = objPaperList[0].strCategory };
                        CoreWebList<PaperGeneratorClass> objQueryList = objQuery.fn_GetRandomPapersByCategory();
                        if (objQueryList.Count > 0)
                        {
                            rpt_Papers.DataSource = objQueryList;
                            rpt_Papers.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message + ex.StackTrace);
                }
            }
        }
    }
}