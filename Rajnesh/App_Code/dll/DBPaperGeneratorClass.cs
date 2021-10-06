using System;
using System.Data.SqlClient;
using System.Configuration;
using yo_lib;

/// <summary>
/// Summary description for DBPaperGeneratorClass
/// </summary>

public class DBPaperGeneratorClass
{
	private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string fn_SavePaperGenerator(string strFileName, string strPageTitle, string strType, string strIdentities, string strH1, string strH2, string strH3, string strH4, string strMetaTitle, string strMetaDescription, string strKeywords, string strCompany, bool bPaper, bool bQuestion, string strCategory)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_PaperGenerator(FileName, PageTitle, Type, Identities, Header1, Header2, Header3, Header4, Meta_Title, Meta_description, Meta_Keywords, Company, bPaper, bQuestion, Category) VALUES (@strQuery, @PageTitle, @strType, @stridentities, @strH1, @strH2, @strH3, @strH4, @strMetaTitle, @strMetaDescription, @strKeywords, @Company, @bPaper, @bQuestion, @Category)", objConnection);

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
            objCommand.Parameters.AddWithValue("@Company", strCompany);
            objCommand.Parameters.AddWithValue("@bPaper", bPaper);
            objCommand.Parameters.AddWithValue("@bQuestion", bQuestion);
            objCommand.Parameters.AddWithValue("@Category", strCategory);

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

    public string fn_EditPaper(int iID, string strFileName, string strPageTitle, string strType, string strIdentities, string strH1, string strH2, string strH3, string strH4, string strMetaTitle, string strMetaDescription, string strKeywords, string Company, string category, bool bPaper, bool bQuestion)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_PaperGenerator SET FileName = @Query, PageTitle = @PageTitle, Type = @Type, Identities = @Identities, Header1 = @Header1, Header2 = @Header2, Header3 = @Header3, Header4 = @Header4, Meta_Title = @Meta_Title, Meta_description = @Meta_description, Meta_Keywords = @Meta_Keywords, Company = @Company, Category = @Category, bPaper=@bPaper, bQuestion=@bQuestion WHERE Id = @ID", objConnection);

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
            objCommand.Parameters.AddWithValue("@Company", Company);
            objCommand.Parameters.AddWithValue("@Category", category);
            objCommand.Parameters.AddWithValue("@bPaper", bPaper);
            objCommand.Parameters.AddWithValue("@bQuestion", bQuestion);

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

    public string fn_DeletePaper(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_PaperGenerator WHERE Id = @ID", objConnection);

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

    public CoreWebList<PaperGeneratorClass> fn_GetPaperList()
    {
        CoreWebList<PaperGeneratorClass> objPageList = null;
        PaperGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_PaperGenerator order by FileName", objConnection);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<PaperGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new PaperGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());

                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.bPaper = bool.Parse(objReader["bPaper"].ToString());
                objPage.bQuestion = bool.Parse(objReader["bQuestion"].ToString());
                objPage.bHome = bool.Parse(objReader["bHome"].ToString());
                objPage.strCategory = objReader["Category"].ToString();

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

    public CoreWebList<PaperGeneratorClass> fn_GetPaperListByPageTitle(string strTitle)
    {
        CoreWebList<PaperGeneratorClass> objPageList = null;
        PaperGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_PaperGenerator WHERE PageTitle like '%" + strTitle + "%'", objConnection);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<PaperGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new PaperGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());

                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.bPaper = bool.Parse(objReader["bPaper"].ToString());
                objPage.bQuestion = bool.Parse(objReader["bQuestion"].ToString());
                objPage.bHome = bool.Parse(objReader["bHome"].ToString());
                objPage.strCategory = objReader["Category"].ToString();

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

    public CoreWebList<PaperGeneratorClass> fn_Get_Placement_Paper_List()
    {
        CoreWebList<PaperGeneratorClass> objPageList = null;
        PaperGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_PaperGenerator order by FileName", objConnection);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<PaperGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new PaperGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());

                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.bPaper = bool.Parse(objReader["bPaper"].ToString());
                objPage.bQuestion = bool.Parse(objReader["bQuestion"].ToString());
                objPage.bHome = bool.Parse(objReader["bHome"].ToString());
                objPage.strCategory = objReader["Category"].ToString();

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

    public CoreWebList<PaperGeneratorClass> fn_GetRandomPapersByRowCount(int iRow)
    {
        CoreWebList<PaperGeneratorClass> objPageList = null;
        PaperGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP " + iRow + " * FROM edu_PaperGenerator ORDER BY NEWID()", objConnection);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<PaperGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new PaperGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());

                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.bPaper = bool.Parse(objReader["bPaper"].ToString());
                objPage.bQuestion = bool.Parse(objReader["bQuestion"].ToString());
                objPage.strCategory = objReader["Category"].ToString();

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

    public CoreWebList<PaperGeneratorClass> fn_GetPaperListByFileName(string strFileName)
    {
        CoreWebList<PaperGeneratorClass> objPageList = null;
        PaperGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_PaperGenerator WHERE FileName like '%" + strFileName + "%' order by FileName", objConnection);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<PaperGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new PaperGeneratorClass();

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
                objPage.strCompany = objReader["Company"].ToString();
                objPage.bPaper = bool.Parse(objReader["bPaper"].ToString());
                objPage.bQuestion = bool.Parse(objReader["bQuestion"].ToString());
                objPage.strCategory = objReader["Category"].ToString();

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

    public CoreWebList<PaperGeneratorClass> fn_GetPaperById(int ID)
    {
        CoreWebList<PaperGeneratorClass> objPageList = null;
        PaperGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_PaperGenerator WHERE Id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", ID);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<PaperGeneratorClass>();

            if (objReader.Read())
            {
                objPage= new PaperGeneratorClass();

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
                objPage.strCompany = objReader["Company"].ToString();
                objPage.bPaper = bool.Parse(objReader["bPaper"].ToString());
                objPage.bQuestion = bool.Parse(objReader["bQuestion"].ToString());
                objPage.bHome = bool.Parse(objReader["bHome"].ToString());
                objPage.strCategory = objReader["Category"].ToString();

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

    public CoreWebList<PaperGeneratorClass> fn_GetPaperByFileName(string strFileName)
    {
        CoreWebList<PaperGeneratorClass> objPageList = null;
        PaperGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_PaperGenerator WHERE FileName = @FileName", objConnection);

            objCommand.Parameters.AddWithValue("@FileName", strFileName);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<PaperGeneratorClass>();

            if (objReader.Read())
            {
                objPage = new PaperGeneratorClass();

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
                objPage.strCompany = objReader["Company"].ToString();
                objPage.bPaper = bool.Parse(objReader["bPaper"].ToString());
                objPage.bQuestion = bool.Parse(objReader["bQuestion"].ToString());
                objPage.bHome = bool.Parse(objReader["bHome"].ToString());
                objPage.strCategory = objReader["Category"].ToString();

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

    public CoreWebList<PaperGeneratorClass> fn_GetPaperByQuery(string strQuery)
    {
        CoreWebList<PaperGeneratorClass> objPageList = null;
        PaperGeneratorClass objPage = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand(strQuery, objConnection);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<PaperGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new PaperGeneratorClass();

                objPage.iID = int.Parse(objReader["Id"].ToString());

                objPage.strFileName = objReader["FileName"].ToString();
                objPage.strType = objReader["Type"].ToString();
                objPage.strMetaTitle = objReader["Meta_Title"].ToString();
                objPage.strPageTitle = objReader["PageTitle"].ToString();
                objPage.bPaper = bool.Parse(objReader["bPaper"].ToString());
                objPage.bQuestion = bool.Parse(objReader["bQuestion"].ToString());
                objPage.strCategory = objReader["Category"].ToString();

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

    public CoreWebList<PaperGeneratorClass> fn_GetRandomPapersByCategoryID(string strCategory)
    {
        CoreWebList<PaperGeneratorClass> objPageList = null;
        PaperGeneratorClass objPage = null;

        try
        {
            var query = "SELECT TOP 5 * FROM edu_PaperGenerator";
            if (!string.IsNullOrEmpty(strCategory) || strCategory != "0")
                query += " WHERE Category='" + strCategory + "'";
            query += " ORDER BY NEWID()";

            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand(query, objConnection);

            objReader = objCommand.ExecuteReader();

            objPageList = new CoreWebList<PaperGeneratorClass>();

            while (objReader.Read())
            {
                objPage = new PaperGeneratorClass
                {
                    iID = int.Parse(objReader["Id"].ToString()),
                    strFileName = objReader["FileName"].ToString(),
                    strPageTitle = objReader["PageTitle"].ToString(),
                    strType = objReader["Type"].ToString(),
                    strIdentities = objReader["Identities"].ToString(),
                    strH1 = objReader["Header1"].ToString(),
                    strH2 = objReader["Header2"].ToString(),
                    strH3 = objReader["Header3"].ToString(),
                    strH4 = objReader["Header4"].ToString(),
                    strMetaTitle = objReader["Meta_Title"].ToString(),
                    strMetaDescription = objReader["Meta_description"].ToString(),
                    strKeywords = objReader["Meta_Keywords"].ToString(),
                    strCompany = objReader["Company"].ToString(),
                    bPaper = bool.Parse(objReader["bPaper"].ToString()),
                    bQuestion = bool.Parse(objReader["bQuestion"].ToString()),
                    bHome = bool.Parse(objReader["bHome"].ToString()),
                    strCategory = objReader["Category"].ToString()
                };

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

    public string fn_ChangePaperStatus(int iID, bool bHome)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_PaperGenerator SET bHome = @bHome WHERE Id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@bHome", bHome);

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


}