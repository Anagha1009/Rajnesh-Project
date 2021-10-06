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
/// Summary description for DBArticleClass
/// </summary>
public class DBArticleClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveArticle(ArticleClass objArticle)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_Articles (Article_CountryID, Article_Title, Article_Details, Article_Photo) VALUES (@Article_CountryID, @Article_Title, @Article_Details, @Article_Photo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Article_CountryID", objArticle.iCountryID);
			objCommand.Parameters.AddWithValue("@Article_Title", objArticle.strTitle);
			objCommand.Parameters.AddWithValue("@Article_Details", objArticle.strDetails);
			objCommand.Parameters.AddWithValue("@Article_Photo", objArticle.strPhoto);

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

	public string fn_editArticle(ArticleClass objArticle)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Articles SET Article_Title=@Article_Title, Article_Details=@Article_Details, Article_Photo=@Article_Photo WHERE Article_ID=@Article_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Article_ID", objArticle.iID);
            objCommand.Parameters.AddWithValue("@Article_Title", objArticle.strTitle);
            objCommand.Parameters.AddWithValue("@Article_Details", objArticle.strDetails);
            objCommand.Parameters.AddWithValue("@Article_Photo", objArticle.strPhoto);

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

	public string fn_deleteArticle(int iArticleID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Articles WHERE Article_ID=@Article_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Article_ID", iArticleID);

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

	public CoreWebList<ArticleClass> fn_getArticleList()
	{
		CoreWebList<ArticleClass> objArticleList = null;
		ArticleClass objArticle = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Articles", objConnection);
			objReader = objCommand.ExecuteReader();
			objArticleList = new CoreWebList<ArticleClass>();
			while (objReader.Read())
			{
				objArticle = new ArticleClass();
				objArticle.iID = int.Parse(objReader["Article_ID"].ToString());
				objArticle.iCountryID = int.Parse(objReader["Article_CountryID"].ToString());
				objArticle.strTitle = objReader["Article_Title"].ToString();
				objArticle.strDetails = objReader["Article_Details"].ToString();
				objArticle.strPhoto = objReader["Article_Photo"].ToString();
				objArticleList.Add(objArticle);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objArticleList;
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

	public CoreWebList<ArticleClass> fn_getArticleByID(int iArticleID)
	{
		CoreWebList<ArticleClass> objArticleList = null;
		ArticleClass objArticle = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Articles WHERE Article_ID=@Article_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Article_ID", iArticleID);
			objReader = objCommand.ExecuteReader();
			objArticleList = new CoreWebList<ArticleClass>();
			if (objReader.Read())
			{
				objArticle = new ArticleClass();
				objArticle.iID = int.Parse(objReader["Article_ID"].ToString());
				objArticle.iCountryID = int.Parse(objReader["Article_CountryID"].ToString());
				objArticle.strTitle = objReader["Article_Title"].ToString();
				objArticle.strDetails = objReader["Article_Details"].ToString();
				objArticle.strPhoto = objReader["Article_Photo"].ToString();
				objArticleList.Add(objArticle);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objArticleList;
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

	public CoreWebList<ArticleClass> fn_getArticleByName(string strArticleTitle)
	{
		CoreWebList<ArticleClass> objArticleList = null;
		ArticleClass objArticle = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Articles WHERE Article_Title=@Article_Title", objConnection);
			objCommand.Parameters.AddWithValue("@Article_Title", strArticleTitle);
			objReader = objCommand.ExecuteReader();
			objArticleList = new CoreWebList<ArticleClass>();
			if (objReader.Read())
			{
				objArticle = new ArticleClass();
				objArticle.iID = int.Parse(objReader["Article_ID"].ToString());
				objArticle.iCountryID = int.Parse(objReader["Article_CountryID"].ToString());
				objArticle.strTitle = objReader["Article_Title"].ToString();
				objArticle.strDetails = objReader["Article_Details"].ToString();
				objArticle.strPhoto = objReader["Article_Photo"].ToString();
				objArticleList.Add(objArticle);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objArticleList;
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

	public CoreWebList<ArticleClass> fn_getArticleByKeys(string strArticleTitle)
	{
		CoreWebList<ArticleClass> objArticleList = null;
		ArticleClass objArticle = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Articles WHERE Article_Title like '%' + @Article_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Article_Title", strArticleTitle);
			objReader = objCommand.ExecuteReader();
			objArticleList = new CoreWebList<ArticleClass>();
			while (objReader.Read())
			{
				objArticle = new ArticleClass();
				objArticle.iID = int.Parse(objReader["Article_ID"].ToString());
				objArticle.iCountryID = int.Parse(objReader["Article_CountryID"].ToString());
				objArticle.strTitle = objReader["Article_Title"].ToString();
				objArticle.strDetails = objReader["Article_Details"].ToString();
				objArticle.strPhoto = objReader["Article_Photo"].ToString();
				objArticleList.Add(objArticle);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objArticleList;
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

	public CoreWebList<ArticleClass> fn_getArticleByCountryID(int iCountryID)
	{
		CoreWebList<ArticleClass> objArticleList = null;
		ArticleClass objArticle = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Articles WHERE Article_CountryID=@Article_CountryID", objConnection);
			objCommand.Parameters.AddWithValue("@Article_CountryID", iCountryID);
			objReader = objCommand.ExecuteReader();
			objArticleList = new CoreWebList<ArticleClass>();
			while (objReader.Read())
			{
				objArticle = new ArticleClass();
				objArticle.iID = int.Parse(objReader["Article_ID"].ToString());
				objArticle.iCountryID = int.Parse(objReader["Article_CountryID"].ToString());
				objArticle.strTitle = objReader["Article_Title"].ToString();
				objArticle.strDetails = objReader["Article_Details"].ToString();
				objArticle.strPhoto = objReader["Article_Photo"].ToString();
				objArticleList.Add(objArticle);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objArticleList;
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
