using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using yo_lib;

/// <summary>
/// Summary description for DBQueryGeneratorClass
/// </summary>
public class DBQueryGeneratorClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveQueryGenerator(QueryGeneratorClass objQueryGenerator)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_QueryGenerator (QueryGenerator_CityID, QueryGenerator_CategoryID, QueryGenerator_Type, QueryGenerator_Title, QueryGenerator_Desc, QueryGenerator_Identity, QueryGenerator_MetaTitle, QueryGenerator_MetaDesc, QueryGenerator_Metakeys, QueryGenerator_YoutubeTitle, QueryGenerator_Youtube) VALUES (@QueryGenerator_CityID, @QueryGenerator_CategoryID, @QueryGenerator_Type, @QueryGenerator_Title, @QueryGenerator_Desc, @QueryGenerator_Identity, @QueryGenerator_MetaTitle, @QueryGenerator_MetaDesc, @QueryGenerator_Metakeys, @QueryGenerator_YoutubeTitle, @QueryGenerator_Youtube)", objConnection);
			objCommand.Parameters.AddWithValue("@QueryGenerator_CityID", objQueryGenerator.iCityID);
			objCommand.Parameters.AddWithValue("@QueryGenerator_CategoryID", objQueryGenerator.iCategoryID);
			objCommand.Parameters.AddWithValue("@QueryGenerator_Type", objQueryGenerator.strType);
			objCommand.Parameters.AddWithValue("@QueryGenerator_Title", objQueryGenerator.strTitle);
			objCommand.Parameters.AddWithValue("@QueryGenerator_Desc", objQueryGenerator.strDesc);
			objCommand.Parameters.AddWithValue("@QueryGenerator_Identity", objQueryGenerator.strIdentity);
			objCommand.Parameters.AddWithValue("@QueryGenerator_MetaTitle", objQueryGenerator.strMetaTitle);
			objCommand.Parameters.AddWithValue("@QueryGenerator_MetaDesc", objQueryGenerator.strMetaDesc);
			objCommand.Parameters.AddWithValue("@QueryGenerator_Metakeys", objQueryGenerator.strMetakeys);
            objCommand.Parameters.AddWithValue("@QueryGenerator_YoutubeTitle", objQueryGenerator.strYoutubeTitle);
            objCommand.Parameters.AddWithValue("@QueryGenerator_Youtube", objQueryGenerator.strYoutube);

			if (objCommand.ExecuteNonQuery() > 0)
			{
				return "SUCCESS : Record has been inserted successfully!";
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

	public string fn_editQueryGenerator(QueryGeneratorClass objQueryGenerator)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_QueryGenerator SET QueryGenerator_CityID=@QueryGenerator_CityID, QueryGenerator_CategoryID=@QueryGenerator_CategoryID, QueryGenerator_Type=@QueryGenerator_Type, QueryGenerator_Title=@QueryGenerator_Title, QueryGenerator_Desc=@QueryGenerator_Desc, QueryGenerator_Identity=@QueryGenerator_Identity, QueryGenerator_MetaTitle=@QueryGenerator_MetaTitle, QueryGenerator_MetaDesc=@QueryGenerator_MetaDesc, QueryGenerator_Metakeys=@QueryGenerator_Metakeys, QueryGenerator_YoutubeTitle=@QueryGenerator_YoutubeTitle, QueryGenerator_Youtube=@QueryGenerator_Youtube WHERE QueryGenerator_ID=@QueryGenerator_ID", objConnection);
			objCommand.Parameters.AddWithValue("@QueryGenerator_ID", objQueryGenerator.iID);
			objCommand.Parameters.AddWithValue("@QueryGenerator_CityID", objQueryGenerator.iCityID);
			objCommand.Parameters.AddWithValue("@QueryGenerator_CategoryID", objQueryGenerator.iCategoryID);
			objCommand.Parameters.AddWithValue("@QueryGenerator_Type", objQueryGenerator.strType);
			objCommand.Parameters.AddWithValue("@QueryGenerator_Title", objQueryGenerator.strTitle);
			objCommand.Parameters.AddWithValue("@QueryGenerator_Desc", objQueryGenerator.strDesc);
			objCommand.Parameters.AddWithValue("@QueryGenerator_Identity", objQueryGenerator.strIdentity);
			objCommand.Parameters.AddWithValue("@QueryGenerator_MetaTitle", objQueryGenerator.strMetaTitle);
			objCommand.Parameters.AddWithValue("@QueryGenerator_MetaDesc", objQueryGenerator.strMetaDesc);
			objCommand.Parameters.AddWithValue("@QueryGenerator_Metakeys", objQueryGenerator.strMetakeys);
            objCommand.Parameters.AddWithValue("@QueryGenerator_YoutubeTitle", objQueryGenerator.strYoutubeTitle);
            objCommand.Parameters.AddWithValue("@QueryGenerator_Youtube", objQueryGenerator.strYoutube);

			if (objCommand.ExecuteNonQuery() > 0)
			{
				return "SUCCESS : Record has been updated successfully!";
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

	public string fn_deleteQueryGenerator(int iQueryGeneratorID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_QueryGenerator WHERE QueryGenerator_ID=@QueryGenerator_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@QueryGenerator_ID", iQueryGeneratorID);

			if (objCommand.ExecuteNonQuery() > 0)
			{
				return "SUCCESS : Record has been deleted successfully!";
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

	public CoreWebList<QueryGeneratorClass> fn_getQueryGeneratorList()
	{
		CoreWebList<QueryGeneratorClass> objQueryGeneratorList = null;
		QueryGeneratorClass objQueryGenerator = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_QueryGenerator", objConnection);
			objReader = objCommand.ExecuteReader();
			objQueryGeneratorList = new CoreWebList<QueryGeneratorClass>();
			while (objReader.Read())
			{
				objQueryGenerator = new QueryGeneratorClass();
				objQueryGenerator.iID = int.Parse(objReader["QueryGenerator_ID"].ToString());
				objQueryGenerator.iCityID = int.Parse(objReader["QueryGenerator_CityID"].ToString());
				objQueryGenerator.iCategoryID = int.Parse(objReader["QueryGenerator_CategoryID"].ToString());
				objQueryGenerator.strType = objReader["QueryGenerator_Type"].ToString();
				objQueryGenerator.strTitle = objReader["QueryGenerator_Title"].ToString();
				objQueryGenerator.strDesc = objReader["QueryGenerator_Desc"].ToString();
				objQueryGenerator.strIdentity = objReader["QueryGenerator_Identity"].ToString();
				objQueryGenerator.strMetaTitle = objReader["QueryGenerator_MetaTitle"].ToString();
				objQueryGenerator.strMetaDesc = objReader["QueryGenerator_MetaDesc"].ToString();
				objQueryGenerator.strMetakeys = objReader["QueryGenerator_Metakeys"].ToString();
                objQueryGenerator.strYoutubeTitle = objReader["QueryGenerator_YoutubeTitle"].ToString();
                objQueryGenerator.strYoutube = objReader["QueryGenerator_Youtube"].ToString();
				objQueryGeneratorList.Add(objQueryGenerator);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objQueryGeneratorList;
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

    public CoreWebList<QueryGeneratorClass> fn_getRandomQueryGeneratorList()
    {
        CoreWebList<QueryGeneratorClass> objQueryGeneratorList = null;
        QueryGeneratorClass objQueryGenerator = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 10 * FROM tbl_QueryGenerator ORDER BY NEWID()", objConnection);
            objReader = objCommand.ExecuteReader();
            objQueryGeneratorList = new CoreWebList<QueryGeneratorClass>();
            while (objReader.Read())
            {
                objQueryGenerator = new QueryGeneratorClass();
                objQueryGenerator.iID = int.Parse(objReader["QueryGenerator_ID"].ToString());
                objQueryGenerator.iCityID = int.Parse(objReader["QueryGenerator_CityID"].ToString());
                objQueryGenerator.iCategoryID = int.Parse(objReader["QueryGenerator_CategoryID"].ToString());
                objQueryGenerator.strType = objReader["QueryGenerator_Type"].ToString();
                objQueryGenerator.strTitle = objReader["QueryGenerator_Title"].ToString();
                objQueryGenerator.strDesc = objReader["QueryGenerator_Desc"].ToString();
                objQueryGenerator.strIdentity = objReader["QueryGenerator_Identity"].ToString();
                objQueryGenerator.strMetaTitle = objReader["QueryGenerator_MetaTitle"].ToString();
                objQueryGenerator.strMetaDesc = objReader["QueryGenerator_MetaDesc"].ToString();
                objQueryGenerator.strMetakeys = objReader["QueryGenerator_Metakeys"].ToString();
                objQueryGenerator.strYoutubeTitle = objReader["QueryGenerator_YoutubeTitle"].ToString();
                objQueryGenerator.strYoutube = objReader["QueryGenerator_Youtube"].ToString();
                objQueryGeneratorList.Add(objQueryGenerator);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objQueryGeneratorList;
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

	public CoreWebList<QueryGeneratorClass> fn_getQueryGeneratorByID(int iQueryGeneratorID)
	{
		CoreWebList<QueryGeneratorClass> objQueryGeneratorList = null;
		QueryGeneratorClass objQueryGenerator = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_QueryGenerator WHERE QueryGenerator_ID=@QueryGenerator_ID", objConnection);
			objCommand.Parameters.AddWithValue("@QueryGenerator_ID", iQueryGeneratorID);
			objReader = objCommand.ExecuteReader();
			objQueryGeneratorList = new CoreWebList<QueryGeneratorClass>();
			if (objReader.Read())
			{
				objQueryGenerator = new QueryGeneratorClass();
				objQueryGenerator.iID = int.Parse(objReader["QueryGenerator_ID"].ToString());
				objQueryGenerator.iCityID = int.Parse(objReader["QueryGenerator_CityID"].ToString());
				objQueryGenerator.iCategoryID = int.Parse(objReader["QueryGenerator_CategoryID"].ToString());
				objQueryGenerator.strType = objReader["QueryGenerator_Type"].ToString();
				objQueryGenerator.strTitle = objReader["QueryGenerator_Title"].ToString();
				objQueryGenerator.strDesc = objReader["QueryGenerator_Desc"].ToString();
				objQueryGenerator.strIdentity = objReader["QueryGenerator_Identity"].ToString();
				objQueryGenerator.strMetaTitle = objReader["QueryGenerator_MetaTitle"].ToString();
				objQueryGenerator.strMetaDesc = objReader["QueryGenerator_MetaDesc"].ToString();
				objQueryGenerator.strMetakeys = objReader["QueryGenerator_Metakeys"].ToString();
                objQueryGenerator.strYoutubeTitle = objReader["QueryGenerator_YoutubeTitle"].ToString();
                objQueryGenerator.strYoutube = objReader["QueryGenerator_Youtube"].ToString();
				objQueryGeneratorList.Add(objQueryGenerator);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objQueryGeneratorList;
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

	public CoreWebList<QueryGeneratorClass> fn_getQueryGeneratorByName(string strQueryGeneratorTitle)
	{
		CoreWebList<QueryGeneratorClass> objQueryGeneratorList = null;
		QueryGeneratorClass objQueryGenerator = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_QueryGenerator WHERE QueryGenerator_Title=@QueryGenerator_Title", objConnection);
			objCommand.Parameters.AddWithValue("@QueryGenerator_Title", strQueryGeneratorTitle);
			objReader = objCommand.ExecuteReader();
			objQueryGeneratorList = new CoreWebList<QueryGeneratorClass>();
			if (objReader.Read())
			{
				objQueryGenerator = new QueryGeneratorClass();
				objQueryGenerator.iID = int.Parse(objReader["QueryGenerator_ID"].ToString());
				objQueryGenerator.iCityID = int.Parse(objReader["QueryGenerator_CityID"].ToString());
				objQueryGenerator.iCategoryID = int.Parse(objReader["QueryGenerator_CategoryID"].ToString());
				objQueryGenerator.strType = objReader["QueryGenerator_Type"].ToString();
				objQueryGenerator.strTitle = objReader["QueryGenerator_Title"].ToString();
				objQueryGenerator.strDesc = objReader["QueryGenerator_Desc"].ToString();
				objQueryGenerator.strIdentity = objReader["QueryGenerator_Identity"].ToString();
				objQueryGenerator.strMetaTitle = objReader["QueryGenerator_MetaTitle"].ToString();
				objQueryGenerator.strMetaDesc = objReader["QueryGenerator_MetaDesc"].ToString();
				objQueryGenerator.strMetakeys = objReader["QueryGenerator_Metakeys"].ToString();
                objQueryGenerator.strYoutubeTitle = objReader["QueryGenerator_YoutubeTitle"].ToString();
                objQueryGenerator.strYoutube = objReader["QueryGenerator_Youtube"].ToString();
				objQueryGeneratorList.Add(objQueryGenerator);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objQueryGeneratorList;
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

	public CoreWebList<QueryGeneratorClass> fn_getQueryGeneratorByKeys(string strQueryGeneratorTitle)
	{
		CoreWebList<QueryGeneratorClass> objQueryGeneratorList = null;
		QueryGeneratorClass objQueryGenerator = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_QueryGenerator WHERE QueryGenerator_Title like '%' + @QueryGenerator_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@QueryGenerator_Title", strQueryGeneratorTitle);
			objReader = objCommand.ExecuteReader();
			objQueryGeneratorList = new CoreWebList<QueryGeneratorClass>();
			while (objReader.Read())
			{
				objQueryGenerator = new QueryGeneratorClass();
				objQueryGenerator.iID = int.Parse(objReader["QueryGenerator_ID"].ToString());
				objQueryGenerator.iCityID = int.Parse(objReader["QueryGenerator_CityID"].ToString());
				objQueryGenerator.iCategoryID = int.Parse(objReader["QueryGenerator_CategoryID"].ToString());
				objQueryGenerator.strType = objReader["QueryGenerator_Type"].ToString();
				objQueryGenerator.strTitle = objReader["QueryGenerator_Title"].ToString();
				objQueryGenerator.strDesc = objReader["QueryGenerator_Desc"].ToString();
				objQueryGenerator.strIdentity = objReader["QueryGenerator_Identity"].ToString();
				objQueryGenerator.strMetaTitle = objReader["QueryGenerator_MetaTitle"].ToString();
				objQueryGenerator.strMetaDesc = objReader["QueryGenerator_MetaDesc"].ToString();
				objQueryGenerator.strMetakeys = objReader["QueryGenerator_Metakeys"].ToString();
                objQueryGenerator.strYoutubeTitle = objReader["QueryGenerator_YoutubeTitle"].ToString();
                objQueryGenerator.strYoutube = objReader["QueryGenerator_Youtube"].ToString();
				objQueryGeneratorList.Add(objQueryGenerator);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objQueryGeneratorList;
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
