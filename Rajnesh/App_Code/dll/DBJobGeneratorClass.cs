using System;
using System.Data.SqlClient;
using System.Configuration;
using yo_lib;

/// <summary>
/// Summary description for DBJobGeneratorClass
/// </summary>

public class DBJobGeneratorClass
{
	private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string fn_SaveJobGenerator(string strFileName, string strPageTitle, string strType, string strIdentities, string strH1, string strH2, string strH3, string strH4, string strMetaTitle, string strMetaDescription, string strKeywords, int Category, int iSubCategory, string strCity, int iCompany, bool bCompany, bool bCategory, bool bLocation, bool bLinkStatus, string strTargetUrl)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_JobGenerator(FileName, PageTitle, Type, Identities, Header1, Header2, Header3, Header4, Meta_Title, Meta_description, Meta_Keywords, Category, SubCategory, City, Company, bCompany, bCategory, bLocation, bLinkStatus, TargetUrl) VALUES (@strQuery, @PageTitle, @strType, @stridentities, @strH1, @strH2, @strH3, @strH4, @strMetaTitle, @strMetaDescription, @strKeywords, @Category, @SubCategory, @strCity, @Company, @bCompany, @bCategory, @bLocation, @bLinkStatus, @TargetUrl)", objConnection);

            objCommand.Parameters.AddWithValue("@strQuery", strFileName);
            objCommand.Parameters.AddWithValue("@PageTitle", strPageTitle);
            objCommand.Parameters.AddWithValue("@strType", strType);
            objCommand.Parameters.AddWithValue("@stridentities", strIdentities);
            objCommand.Parameters.AddWithValue("@strH1", strH1);
            objCommand.Parameters.AddWithValue("@strH2", strH2);
            objCommand.Parameters.AddWithValue("@strH3", strH3);
            objCommand.Parameters.AddWithValue("@strH4", strH4);
            objCommand.Parameters.AddWithValue("@strMetaTitle", strMetaTitle);
            objCommand.Parameters.AddWithValue("@strMetaDescription", strMetaDescription);
            objCommand.Parameters.AddWithValue("@strKeywords", strKeywords);
            objCommand.Parameters.AddWithValue("@Category", Category);
            objCommand.Parameters.AddWithValue("@SubCategory", iSubCategory);
            objCommand.Parameters.AddWithValue("@strCity", strCity);
            objCommand.Parameters.AddWithValue("@Company", iCompany);
            objCommand.Parameters.AddWithValue("@bCompany", bCompany);
            objCommand.Parameters.AddWithValue("@bCategory", bCategory);
            objCommand.Parameters.AddWithValue("@bLocation", bLocation);
            objCommand.Parameters.AddWithValue("@bLinkStatus", bLinkStatus);
            objCommand.Parameters.AddWithValue("@TargetUrl", strTargetUrl);
            
            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been inserted";
            }
            else
            {
                return "ERROR : SQL Exception";
            }
        }
        catch (Exception ex)
        {
            return "ERROR : " + ex.Message;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    public string fn_EditJob(int iID, string strFileName, string strPageTitle, string strType, string strIdentities, string strH1, string strH2, string strH3, string strH4, string strMetaTitle, string strMetaDescription, string strKeywords, int Category, int iSubCategory, string strCity, int Company, bool bCompany, bool bCategory, bool bLocation, bool bLinkStatus, string strTargetUrl)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_JobGenerator SET FileName = @Query, PageTitle = @PageTitle, Type = @Type, Identities = @Identities, Header1 = @Header1, Header2 = @Header2, Header3 = @Header3, Header4 = @Header4, Meta_Title = @Meta_Title, Meta_description = @Meta_description, Meta_Keywords = @Meta_Keywords, Category = @Category, SubCategory = @SubCategory, City = @City, Company = @Company, bCompany = @bCompany, bCategory = @bCategory, bLocation = @bLocation, bLinkStatus = @bLinkStatus, TargetUrl = @TargetUrl, CreatedDate=@CreatedDate WHERE Id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@Query", strFileName);
            objCommand.Parameters.AddWithValue("@PageTitle", strPageTitle);
            objCommand.Parameters.AddWithValue("@Type", strType);
            objCommand.Parameters.AddWithValue("@Identities", strIdentities);
            objCommand.Parameters.AddWithValue("@Header1", strH1);
            objCommand.Parameters.AddWithValue("@Header2", strH2);
            objCommand.Parameters.AddWithValue("@Header3", strH3);
            objCommand.Parameters.AddWithValue("@Header4", strH4);
            objCommand.Parameters.AddWithValue("@Meta_Title", strMetaTitle);
            objCommand.Parameters.AddWithValue("@Meta_description", strMetaDescription);
            objCommand.Parameters.AddWithValue("@Meta_Keywords", strKeywords);
            objCommand.Parameters.AddWithValue("@Category", Category);
            objCommand.Parameters.AddWithValue("@SubCategory", iSubCategory);
            objCommand.Parameters.AddWithValue("@City", strCity);
            objCommand.Parameters.AddWithValue("@Company", Company);
            objCommand.Parameters.AddWithValue("@bCompany", bCompany);
            objCommand.Parameters.AddWithValue("@bCategory", bCategory);
            objCommand.Parameters.AddWithValue("@bLocation", bLocation);
            objCommand.Parameters.AddWithValue("@bLinkStatus", bLinkStatus);
            objCommand.Parameters.AddWithValue("@TargetUrl", strTargetUrl);
            objCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been updated";
            }
            else
            {
                return "ERROR : SQL Exception";
            }
        }
        catch (Exception ex)
        {
            return "ERROR : " + ex.Message;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    public string fn_DeleteJob(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_JobGenerator WHERE Id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been deleted";
            }
            else
            {
                return "ERROR : SQL Exception";
            }
        }
        catch (Exception ex)
        {
            return "ERROR : " + ex.Message;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }


    public CoreWebList<JobGeneratorClass> fn_GetJobList()
    {
        CoreWebList<JobGeneratorClass> objPageList = null;
        JobGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_JobGenerator order by FileName", objConnection);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<JobGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new JobGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());

                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.bCompany = bool.Parse(objReader["bCompany"].ToString());
                objPage.bCategory = bool.Parse(objReader["bCategory"].ToString());
                objPage.bLocation = bool.Parse(objReader["bLocation"].ToString());
                objPage.bLinkStatus = bool.Parse(objReader["bLinkStatus"].ToString());
                objPage.strTargetUrl = objReader["TargetUrl"].ToString();
                objPage.dtCreatedDate = DateTime.Parse(objReader["CreatedDate"].ToString());

                objPageList.Add(objPage);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objPageList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }
    
    
    
    public CoreWebList<JobGeneratorClass> fn_Get_JobList()
    {
        CoreWebList<JobGeneratorClass> objPageList = null;
        JobGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_JobGenerator order by FileName", objConnection);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<JobGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new JobGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());

                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.bCompany = bool.Parse(objReader["bCompany"].ToString());
                objPage.bCategory = bool.Parse(objReader["bCategory"].ToString());
                objPage.bLocation = bool.Parse(objReader["bLocation"].ToString());
                objPage.bLinkStatus = bool.Parse(objReader["bLinkStatus"].ToString());
                objPage.strTargetUrl = objReader["TargetUrl"].ToString();
                objPage.dtCreatedDate = DateTime.Parse(objReader["CreatedDate"].ToString());

                objPageList.Add(objPage);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objPageList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    public CoreWebList<JobGeneratorClass> fn_Get_JobListByLinkStatus()
    {
        CoreWebList<JobGeneratorClass> objPageList = null;
        JobGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_JobGenerator WHERE bLinkStatus = 'true' order by FileName", objConnection);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<JobGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new JobGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());
                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.bCompany = bool.Parse(objReader["bCompany"].ToString());
                objPage.bCategory = bool.Parse(objReader["bCategory"].ToString());
                objPage.bLocation = bool.Parse(objReader["bLocation"].ToString());
                objPage.bLinkStatus = bool.Parse(objReader["bLinkStatus"].ToString());
                objPage.strTargetUrl = objReader["TargetUrl"].ToString();
                objPage.dtCreatedDate = DateTime.Parse(objReader["CreatedDate"].ToString());

                objPageList.Add(objPage);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objPageList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    public CoreWebList<JobGeneratorClass> fn_Get_JobListforCustomPager(int PageIndex, int PageSize)
    {
        CoreWebList<JobGeneratorClass> objPageList = null;
        JobGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("Select * From (SELECT *, row_number() OVER (order by  FileName) as TR FROM edu_JobGenerator) As TR Where TR between  @StartRow and @EndRow ORDER BY newid()", objConnection);

            objCommand.Parameters.AddWithValue("@StartRow", (PageIndex - 1) * PageSize + 1);
            objCommand.Parameters.AddWithValue("@EndRow", (((PageIndex -1) * PageSize + 1) + PageSize) - 1);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<JobGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new JobGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());

                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.bCompany = bool.Parse(objReader["bCompany"].ToString());
                objPage.bCategory = bool.Parse(objReader["bCategory"].ToString());
                objPage.bLocation = bool.Parse(objReader["bLocation"].ToString());
                objPage.bLinkStatus = bool.Parse(objReader["bLinkStatus"].ToString());
                objPage.strTargetUrl = objReader["TargetUrl"].ToString();

                objPageList.Add(objPage);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objPageList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    public CoreWebList<JobGeneratorClass> fn_GetJobById(int ID)
    {
        CoreWebList<JobGeneratorClass> objPageList = null;
        JobGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_JobGenerator WHERE Id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", ID);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<JobGeneratorClass>();

            if (objReader.Read())
            {
                objPage= new JobGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());
                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strIdentities = objReader["Identities"].ToString();
                objPage.strH1 = objReader["Header1"].ToString();
                objPage.strH2 = objReader["Header2"].ToString();
                objPage.strH3 = objReader["Header3"].ToString();
                objPage.strH4 = objReader["Header4"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strMetaDescription = objReader["Meta_description"].ToString();
                objPage.strKeywords = objReader["Meta_Keywords"].ToString();
                objPage.iCategory = int.Parse(objReader["Category"].ToString());
                objPage.iSubCategory = int.Parse(objReader["SubCategory"].ToString());
                objPage.strCity = objReader["City"].ToString();
                objPage.iComapny = int.Parse(objReader["Company"].ToString());
                objPage.bCompany = bool.Parse(objReader["bCompany"].ToString());
                objPage.bCategory = bool.Parse(objReader["bCategory"].ToString());
                objPage.bLocation = bool.Parse(objReader["bLocation"].ToString());
                objPage.bLinkStatus = bool.Parse(objReader["bLinkStatus"].ToString());
                objPage.strTargetUrl = objReader["TargetUrl"].ToString();
                objPage.dtCreatedDate = DateTime.Parse(objReader["CreatedDate"].ToString());

                objPageList.Add(objPage);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objPageList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    public CoreWebList<JobGeneratorClass> fn_GetJobByFileName(string strFileName)
    {
        CoreWebList<JobGeneratorClass> objPageList = null;
        JobGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_JobGenerator WHERE FileName = @FileName", objConnection);

            objCommand.Parameters.AddWithValue("@FileName", strFileName);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<JobGeneratorClass>();

            if (objReader.Read())
            {
                objPage = new JobGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());
                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strIdentities = objReader["Identities"].ToString();
                objPage.strH1 = objReader["Header1"].ToString();
                objPage.strH2 = objReader["Header2"].ToString();
                objPage.strH3 = objReader["Header3"].ToString();
                objPage.strH4 = objReader["Header4"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strMetaDescription = objReader["Meta_description"].ToString();
                objPage.strKeywords = objReader["Meta_Keywords"].ToString();
                objPage.iCategory = int.Parse(objReader["Category"].ToString());
                objPage.iSubCategory = int.Parse(objReader["SubCategory"].ToString());
                objPage.strCity = objReader["City"].ToString();
                objPage.iComapny = int.Parse(objReader["Company"].ToString());
                objPage.bCompany = bool.Parse(objReader["bCompany"].ToString());
                objPage.bCategory = bool.Parse(objReader["bCategory"].ToString());
                objPage.bLocation = bool.Parse(objReader["bLocation"].ToString());
                objPage.bLinkStatus = bool.Parse(objReader["bLinkStatus"].ToString());
                objPage.strTargetUrl = objReader["TargetUrl"].ToString();
                objPage.dtCreatedDate = DateTime.Parse(objReader["CreatedDate"].ToString());

                objPageList.Add(objPage);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objPageList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    public CoreWebList<JobGeneratorClass> fn_GetRandomJobByCategoryID(int iCategoryID)
    {
        CoreWebList<JobGeneratorClass> objPageList = null;
        JobGeneratorClass objPage = null;
        try
        {
            var query = "SELECT TOP 5 * FROM edu_JobGenerator";
            if (iCategoryID > 0)
                query += " WHERE Category='" + iCategoryID + "'";
            query += " ORDER BY NEWID()";

            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand(query, objConnection);
            objReader = objCommand.ExecuteReader();
            objPageList = new CoreWebList<JobGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new JobGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());
                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strIdentities = objReader["Identities"].ToString();
                objPage.strH1 = objReader["Header1"].ToString();
                objPage.strH2 = objReader["Header2"].ToString();
                objPage.strH3 = objReader["Header3"].ToString();
                objPage.strH4 = objReader["Header4"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strMetaDescription = objReader["Meta_description"].ToString();
                objPage.strKeywords = objReader["Meta_Keywords"].ToString();
                objPage.iCategory = int.Parse(objReader["Category"].ToString());
                objPage.iSubCategory = int.Parse(objReader["SubCategory"].ToString());
                objPage.strCity = objReader["City"].ToString();
                objPage.iComapny = int.Parse(objReader["Company"].ToString());
                objPage.bCompany = bool.Parse(objReader["bCompany"].ToString());
                objPage.bCategory = bool.Parse(objReader["bCategory"].ToString());
                objPage.bLocation = bool.Parse(objReader["bLocation"].ToString());
                objPage.bLinkStatus = bool.Parse(objReader["bLinkStatus"].ToString());
                objPage.strTargetUrl = objReader["TargetUrl"].ToString();
                objPage.dtCreatedDate = DateTime.Parse(objReader["CreatedDate"].ToString());

                objPageList.Add(objPage);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objPageList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    public CoreWebList<JobGeneratorClass> fn_GetRandomJobBy_CategoryID(int iCategoryID)
    {
        CoreWebList<JobGeneratorClass> objPageList = null;
        JobGeneratorClass objPage = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 5 * FROM edu_JobGenerator WHERE Company IN (SELECT JobCompany_id FROM edu_JobsCompany WHERE JobCompany_CategoryID=@JobCompany_CategoryID) ORDER BY NEWID()", objConnection);
            objCommand.Parameters.AddWithValue("@JobCompany_CategoryID", iCategoryID);
            objReader = objCommand.ExecuteReader();
            objPageList = new CoreWebList<JobGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new JobGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());
                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strIdentities = objReader["Identities"].ToString();
                objPage.strH1 = objReader["Header1"].ToString();
                objPage.strH2 = objReader["Header2"].ToString();
                objPage.strH3 = objReader["Header3"].ToString();
                objPage.strH4 = objReader["Header4"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strMetaDescription = objReader["Meta_description"].ToString();
                objPage.strKeywords = objReader["Meta_Keywords"].ToString();
                objPage.iCategory = int.Parse(objReader["Category"].ToString());
                objPage.iSubCategory = int.Parse(objReader["SubCategory"].ToString());
                objPage.strCity = objReader["City"].ToString();
                objPage.iComapny = int.Parse(objReader["Company"].ToString());
                objPage.bCompany = bool.Parse(objReader["bCompany"].ToString());
                objPage.bCategory = bool.Parse(objReader["bCategory"].ToString());
                objPage.bLocation = bool.Parse(objReader["bLocation"].ToString());
                objPage.bLinkStatus = bool.Parse(objReader["bLinkStatus"].ToString());
                objPage.strTargetUrl = objReader["TargetUrl"].ToString();
                objPage.dtCreatedDate = DateTime.Parse(objReader["CreatedDate"].ToString());

                objPageList.Add(objPage);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objPageList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    public CoreWebList<JobGeneratorClass> fn_GetJobBypageTitle(string strpageTitle)
    {
        CoreWebList<JobGeneratorClass> objPageList = null;
        JobGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_JobGenerator WHERE PageTitle like '%" + strpageTitle + "%'", objConnection);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<JobGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new JobGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());
                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strIdentities = objReader["Identities"].ToString();
                objPage.strH1 = objReader["Header1"].ToString();
                objPage.strH2 = objReader["Header2"].ToString();
                objPage.strH3 = objReader["Header3"].ToString();
                objPage.strH4 = objReader["Header4"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strMetaDescription = objReader["Meta_description"].ToString();
                objPage.strKeywords = objReader["Meta_Keywords"].ToString();
                objPage.iCategory = int.Parse(objReader["Category"].ToString());
                objPage.iSubCategory = int.Parse(objReader["SubCategory"].ToString());
                objPage.strCity = objReader["City"].ToString();
                objPage.iComapny = int.Parse(objReader["Company"].ToString());
                objPage.bCompany = bool.Parse(objReader["bCompany"].ToString());
                objPage.bCategory = bool.Parse(objReader["bCategory"].ToString());
                objPage.bLocation = bool.Parse(objReader["bLocation"].ToString());
                objPage.bLinkStatus = bool.Parse(objReader["bLinkStatus"].ToString());
                objPage.strTargetUrl = objReader["TargetUrl"].ToString();
                objPage.dtCreatedDate = DateTime.Parse(objReader["CreatedDate"].ToString());

                objPageList.Add(objPage);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objPageList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    public CoreWebList<JobGeneratorClass> fn_GetJobByTargetUrl(string strTargetUrl)
    {
        CoreWebList<JobGeneratorClass> objPageList = null;
        JobGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_JobGenerator WHERE TargetUrl like '%" + strTargetUrl + "%'", objConnection);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<JobGeneratorClass>();

            if (objReader.Read())
            {
                objPage = new JobGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());
                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strIdentities = objReader["Identities"].ToString();
                objPage.strH1 = objReader["Header1"].ToString();
                objPage.strH2 = objReader["Header2"].ToString();
                objPage.strH3 = objReader["Header3"].ToString();
                objPage.strH4 = objReader["Header4"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strMetaDescription = objReader["Meta_description"].ToString();
                objPage.strKeywords = objReader["Meta_Keywords"].ToString();
                objPage.iCategory = int.Parse(objReader["Category"].ToString());
                objPage.iSubCategory = int.Parse(objReader["SubCategory"].ToString());
                objPage.strCity = objReader["City"].ToString();
                objPage.iComapny = int.Parse(objReader["Company"].ToString());
                objPage.bCompany = bool.Parse(objReader["bCompany"].ToString());
                objPage.bCategory = bool.Parse(objReader["bCategory"].ToString());
                objPage.bLocation = bool.Parse(objReader["bLocation"].ToString());
                objPage.bLinkStatus = bool.Parse(objReader["bLinkStatus"].ToString());
                objPage.strTargetUrl = objReader["TargetUrl"].ToString();
                objPage.dtCreatedDate = DateTime.Parse(objReader["CreatedDate"].ToString());

                objPageList.Add(objPage);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objPageList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }


    public CoreWebList<JobGeneratorClass> fn_Get_JobByQuery(string strQuery)
    {
        CoreWebList<JobGeneratorClass> objPageList = null;
        JobGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand(strQuery, objConnection);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<JobGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new JobGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());
                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strIdentities = objReader["Identities"].ToString();
                objPage.strH1 = objReader["Header1"].ToString();
                objPage.strH2 = objReader["Header2"].ToString();
                objPage.strH3 = objReader["Header3"].ToString();
                objPage.strH4 = objReader["Header4"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strMetaDescription = objReader["Meta_description"].ToString();
                objPage.strKeywords = objReader["Meta_Keywords"].ToString();
                objPage.iCategory = int.Parse(objReader["Category"].ToString());
                objPage.iSubCategory = int.Parse(objReader["SubCategory"].ToString());
                objPage.strCity = objReader["City"].ToString();
                objPage.iComapny = int.Parse(objReader["Company"].ToString());
                objPage.bCompany = bool.Parse(objReader["bCompany"].ToString());
                objPage.bCategory = bool.Parse(objReader["bCategory"].ToString());
                objPage.bLocation = bool.Parse(objReader["bLocation"].ToString());
                objPage.bLinkStatus = bool.Parse(objReader["bLinkStatus"].ToString());
                objPage.strTargetUrl = objReader["TargetUrl"].ToString();
                objPage.dtCreatedDate = DateTime.Parse(objReader["CreatedDate"].ToString());

                objPageList.Add(objPage);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objPageList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

}