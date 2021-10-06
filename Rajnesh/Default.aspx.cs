using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using yo_lib;
using System.Text;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                fn_BindBoxes();
                fn_BindNews();
                fn_BindQuery();
                fn_BindFeaturedInstitutes();
                fn_BindFeaturedSchools();
                fn_BindFeaturedUniversity();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindBoxes()
    {
        try
        {
            CategoryClass objCategory = new CategoryClass();
            CoreWebList<CategoryClass> objCategoryList = objCategory.fn_getHomeCategoryList();
            if (objCategoryList.Count > 0)
            {
                rpt_Banner.DataSource = objCategoryList;
                rpt_Banner.DataBind();

                dl_Category.DataSource = objCategoryList;
                dl_Category.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }



    protected void fn_BindNews()
    {
        try
        {
           NewsClass objNews = new NewsClass();
           CoreWebList<NewsClass> objNewsList = objNews.fn_getTopNewsList();
            if (objNewsList.Count > 0)
            {
                rpt_News.DataSource = objNewsList;
                rpt_News.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindFeaturedUniversity()
    {
        try
        {
            UniversityListClass objUniversity = new UniversityListClass();
            CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_get_Random_UniversityList();
            if (objUniversityList.Count > 0)
            {
                rpt_University.DataSource = objUniversityList;
                rpt_University.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindFeaturedInstitutes()
    {
        try
        {
            InstituteClass objInstitute = new InstituteClass();
            CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getRandomInstituteList();
            if (objInstituteList.Count > 0)
            {
                rpt_HomeFeaturedInstitutes.DataSource = objInstituteList;
                rpt_HomeFeaturedInstitutes.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindFeaturedSchools()
    {
        try
        {
            SchoolClass objSchools = new SchoolClass();
            CoreWebList<SchoolClass> objSchoolList = objSchools.fn_getRandomSchoolList();
            if (objSchoolList.Count > 0)
            {
                rpt_Schools.DataSource = objSchoolList;
                rpt_Schools.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
    
    protected void dl_Category_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hf_CategoryID = (HiddenField)e.Item.FindControl("hf_CategoryID");
                Repeater rpt_Links = (Repeater)e.Item.FindControl("rpt_Links");

                if (hf_CategoryID != null && rpt_Links != null)
                {
                    CategoryLinkClass objCategory = new CategoryLinkClass();
                    objCategory.iCategoryID = int.Parse(hf_CategoryID.Value);
                    CoreWebList<CategoryLinkClass> objCategoryList = objCategory.fn_getCategoryLinkByCategoryID();
                    if (objCategoryList.Count > 0)
                    {
                        rpt_Links.DataSource = objCategoryList;
                        rpt_Links.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindQuery()
    {
        try
        {
            QueryGeneratorClass objQuery = new QueryGeneratorClass();
            CoreWebList<QueryGeneratorClass> objQueryList = objQuery.fn_getRandomQueryGeneratorList();
            if (objQueryList.Count > 0)
            {
                rpt_QueryList.DataSource = objQueryList;
                rpt_QueryList.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}