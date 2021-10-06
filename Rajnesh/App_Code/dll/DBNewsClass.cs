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
/// Summary description for DBNewsClass
/// </summary>
public class DBNewsClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveNews(NewsClass objNews)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_News (News_Title, News_Desc, News_Photo, News_Date) VALUES (@News_Title, @News_Desc, @News_Photo, @News_Date)",objConnection) ;
			objCommand.Parameters.AddWithValue("@News_Title", objNews.strTitle);
			objCommand.Parameters.AddWithValue("@News_Desc", objNews.strDesc);
			objCommand.Parameters.AddWithValue("@News_Photo", objNews.strPhoto);
			objCommand.Parameters.AddWithValue("@News_Date", objNews.dtDate);

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

	public string fn_editNews(NewsClass objNews)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_News SET News_Title=@News_Title, News_Desc=@News_Desc, News_Photo=@News_Photo, News_Date=@News_Date WHERE News_ID=@News_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@News_ID", objNews.iID);
			objCommand.Parameters.AddWithValue("@News_Title", objNews.strTitle);
			objCommand.Parameters.AddWithValue("@News_Desc", objNews.strDesc);
			objCommand.Parameters.AddWithValue("@News_Photo", objNews.strPhoto);
			objCommand.Parameters.AddWithValue("@News_Date", objNews.dtDate);

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

	public string fn_deleteNews(int iNewsID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_News WHERE News_ID=@News_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@News_ID", iNewsID);

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

	public CoreWebList<NewsClass> fn_getNewsList()
	{
		CoreWebList<NewsClass> objNewsList = null;
		NewsClass objNews = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_News ORDER BY News_Date DESC", objConnection);
			objReader = objCommand.ExecuteReader();
			objNewsList = new CoreWebList<NewsClass>();
			while (objReader.Read())
			{
				objNews = new NewsClass();
				objNews.iID = int.Parse(objReader["News_ID"].ToString());
                objNews.strTitle = objReader["News_Title"].ToString();
				objNews.strDesc = objReader["News_Desc"].ToString();
				objNews.strPhoto = objReader["News_Photo"].ToString();
				objNews.dtDate = DateTime.Parse(objReader["News_Date"].ToString());
				objNewsList.Add(objNews);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objNewsList;
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

    public CoreWebList<NewsClass> fn_getTopNewsList()
    {
        CoreWebList<NewsClass> objNewsList = null;
        NewsClass objNews = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT Top 4 * FROM tbl_News ORDER BY News_Date DESC", objConnection);
            objReader = objCommand.ExecuteReader();
            objNewsList = new CoreWebList<NewsClass>();
            while (objReader.Read())
            {
                objNews = new NewsClass();
                objNews.iID = int.Parse(objReader["News_ID"].ToString());
                objNews.strTitle = objReader["News_Title"].ToString();
                objNews.strDesc = objReader["News_Desc"].ToString();
                objNews.strPhoto = objReader["News_Photo"].ToString();
                objNews.dtDate = DateTime.Parse(objReader["News_Date"].ToString());
                objNewsList.Add(objNews);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objNewsList;
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

	public CoreWebList<NewsClass> fn_getNewsByID(int iNewsID)
	{
		CoreWebList<NewsClass> objNewsList = null;
		NewsClass objNews = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_News WHERE News_ID=@News_ID", objConnection);
			objCommand.Parameters.AddWithValue("@News_ID", iNewsID);
			objReader = objCommand.ExecuteReader();
			objNewsList = new CoreWebList<NewsClass>();
			if (objReader.Read())
			{
				objNews = new NewsClass();
				objNews.iID = int.Parse(objReader["News_ID"].ToString());
				objNews.strTitle = objReader["News_Title"].ToString();
				objNews.strDesc = objReader["News_Desc"].ToString();
				objNews.strPhoto = objReader["News_Photo"].ToString();
				objNews.dtDate = DateTime.Parse(objReader["News_Date"].ToString());
				objNewsList.Add(objNews);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objNewsList;
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

	public CoreWebList<NewsClass> fn_getNewsByName(string strNewsTitle)
	{
		CoreWebList<NewsClass> objNewsList = null;
		NewsClass objNews = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_News WHERE News_Title=@News_Title", objConnection);
			objCommand.Parameters.AddWithValue("@News_Title", strNewsTitle);
			objReader = objCommand.ExecuteReader();
			objNewsList = new CoreWebList<NewsClass>();
			if (objReader.Read())
			{
				objNews = new NewsClass();
				objNews.iID = int.Parse(objReader["News_ID"].ToString());
				objNews.strTitle = objReader["News_Title"].ToString();
				objNews.strDesc = objReader["News_Desc"].ToString();
				objNews.strPhoto = objReader["News_Photo"].ToString();
				objNews.dtDate = DateTime.Parse(objReader["News_Date"].ToString());
				objNewsList.Add(objNews);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objNewsList;
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

	public CoreWebList<NewsClass> fn_getNewsByKeys(string strNewsTitle)
	{
		CoreWebList<NewsClass> objNewsList = null;
		NewsClass objNews = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_News WHERE News_Title like '%' + @News_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@News_Title", strNewsTitle);
			objReader = objCommand.ExecuteReader();
			objNewsList = new CoreWebList<NewsClass>();
			while (objReader.Read())
			{
				objNews = new NewsClass();
				objNews.iID = int.Parse(objReader["News_ID"].ToString());
				objNews.strTitle = objReader["News_Title"].ToString();
				objNews.strDesc = objReader["News_Desc"].ToString();
				objNews.strPhoto = objReader["News_Photo"].ToString();
				objNews.dtDate = DateTime.Parse(objReader["News_Date"].ToString());
				objNewsList.Add(objNews);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objNewsList;
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
