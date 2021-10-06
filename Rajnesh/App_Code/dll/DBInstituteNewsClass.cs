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
/// Summary description for DBInstituteNewsClass
/// </summary>
public class DBInstituteNewsClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveInstituteNews(InstituteNewsClass objInstituteNews)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_InstituteNews (InstituteNews_InstituteID, InstituteNews_Title, InstituteNews_Desc, InstituteNews_Photo, InstituteNews_Date) VALUES (@InstituteNews_InstituteID, @InstituteNews_Title, @InstituteNews_Desc, @InstituteNews_Photo, @InstituteNews_Date)",objConnection) ;
			objCommand.Parameters.AddWithValue("@InstituteNews_InstituteID", objInstituteNews.iInstituteID);
			objCommand.Parameters.AddWithValue("@InstituteNews_Title", objInstituteNews.strTitle);
			objCommand.Parameters.AddWithValue("@InstituteNews_Desc", objInstituteNews.strDesc);
			objCommand.Parameters.AddWithValue("@InstituteNews_Photo", objInstituteNews.strPhoto);
			objCommand.Parameters.AddWithValue("@InstituteNews_Date", objInstituteNews.dtDate);

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

	public string fn_editInstituteNews(InstituteNewsClass objInstituteNews)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_InstituteNews SET InstituteNews_InstituteID=@InstituteNews_InstituteID, InstituteNews_Title=@InstituteNews_Title, InstituteNews_Desc=@InstituteNews_Desc, InstituteNews_Photo=@InstituteNews_Photo, InstituteNews_Date=@InstituteNews_Date WHERE InstituteNews_ID=@InstituteNews_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@InstituteNews_ID", objInstituteNews.iID);
			objCommand.Parameters.AddWithValue("@InstituteNews_InstituteID", objInstituteNews.iInstituteID);
			objCommand.Parameters.AddWithValue("@InstituteNews_Title", objInstituteNews.strTitle);
			objCommand.Parameters.AddWithValue("@InstituteNews_Desc", objInstituteNews.strDesc);
			objCommand.Parameters.AddWithValue("@InstituteNews_Photo", objInstituteNews.strPhoto);
			objCommand.Parameters.AddWithValue("@InstituteNews_Date", objInstituteNews.dtDate);

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

	public string fn_deleteInstituteNews(int iInstituteNewsID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_InstituteNews WHERE InstituteNews_ID=@InstituteNews_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@InstituteNews_ID", iInstituteNewsID);

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

	public CoreWebList<InstituteNewsClass> fn_getInstituteNewsList()
	{
		CoreWebList<InstituteNewsClass> objInstituteNewsList = null;
		InstituteNewsClass objInstituteNews = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteNews", objConnection);
			objReader = objCommand.ExecuteReader();
			objInstituteNewsList = new CoreWebList<InstituteNewsClass>();
			while (objReader.Read())
			{
				objInstituteNews = new InstituteNewsClass();
				objInstituteNews.iID = int.Parse(objReader["InstituteNews_ID"].ToString());
				objInstituteNews.iInstituteID = int.Parse(objReader["InstituteNews_InstituteID"].ToString());
				objInstituteNews.strTitle = objReader["InstituteNews_Title"].ToString();
				objInstituteNews.strDesc = objReader["InstituteNews_Desc"].ToString();
				objInstituteNews.strPhoto = objReader["InstituteNews_Photo"].ToString();
				objInstituteNews.dtDate = DateTime.Parse(objReader["InstituteNews_Date"].ToString());
				objInstituteNewsList.Add(objInstituteNews);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteNewsList;
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

	public CoreWebList<InstituteNewsClass> fn_getInstituteNewsByID(int iInstituteNewsID)
	{
		CoreWebList<InstituteNewsClass> objInstituteNewsList = null;
		InstituteNewsClass objInstituteNews = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteNews WHERE InstituteNews_ID=@InstituteNews_ID", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteNews_ID", iInstituteNewsID);
			objReader = objCommand.ExecuteReader();
			objInstituteNewsList = new CoreWebList<InstituteNewsClass>();
			if (objReader.Read())
			{
				objInstituteNews = new InstituteNewsClass();
				objInstituteNews.iID = int.Parse(objReader["InstituteNews_ID"].ToString());
				objInstituteNews.iInstituteID = int.Parse(objReader["InstituteNews_InstituteID"].ToString());
				objInstituteNews.strTitle = objReader["InstituteNews_Title"].ToString();
				objInstituteNews.strDesc = objReader["InstituteNews_Desc"].ToString();
				objInstituteNews.strPhoto = objReader["InstituteNews_Photo"].ToString();
				objInstituteNews.dtDate = DateTime.Parse(objReader["InstituteNews_Date"].ToString());
				objInstituteNewsList.Add(objInstituteNews);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteNewsList;
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

	public CoreWebList<InstituteNewsClass> fn_getInstituteNewsByName(string strInstituteNewsTitle)
	{
		CoreWebList<InstituteNewsClass> objInstituteNewsList = null;
		InstituteNewsClass objInstituteNews = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteNews WHERE InstituteNews_Title=@InstituteNews_Title", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteNews_Title", strInstituteNewsTitle);
			objReader = objCommand.ExecuteReader();
			objInstituteNewsList = new CoreWebList<InstituteNewsClass>();
			if (objReader.Read())
			{
				objInstituteNews = new InstituteNewsClass();
				objInstituteNews.iID = int.Parse(objReader["InstituteNews_ID"].ToString());
				objInstituteNews.iInstituteID = int.Parse(objReader["InstituteNews_InstituteID"].ToString());
				objInstituteNews.strTitle = objReader["InstituteNews_Title"].ToString();
				objInstituteNews.strDesc = objReader["InstituteNews_Desc"].ToString();
				objInstituteNews.strPhoto = objReader["InstituteNews_Photo"].ToString();
				objInstituteNews.dtDate = DateTime.Parse(objReader["InstituteNews_Date"].ToString());
				objInstituteNewsList.Add(objInstituteNews);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteNewsList;
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

	public CoreWebList<InstituteNewsClass> fn_getInstituteNewsByKeys(string strInstituteNewsTitle)
	{
		CoreWebList<InstituteNewsClass> objInstituteNewsList = null;
		InstituteNewsClass objInstituteNews = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteNews WHERE InstituteNews_Title like '%' + @InstituteNews_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteNews_Title", strInstituteNewsTitle);
			objReader = objCommand.ExecuteReader();
			objInstituteNewsList = new CoreWebList<InstituteNewsClass>();
			while (objReader.Read())
			{
				objInstituteNews = new InstituteNewsClass();
				objInstituteNews.iID = int.Parse(objReader["InstituteNews_ID"].ToString());
				objInstituteNews.iInstituteID = int.Parse(objReader["InstituteNews_InstituteID"].ToString());
				objInstituteNews.strTitle = objReader["InstituteNews_Title"].ToString();
				objInstituteNews.strDesc = objReader["InstituteNews_Desc"].ToString();
				objInstituteNews.strPhoto = objReader["InstituteNews_Photo"].ToString();
				objInstituteNews.dtDate = DateTime.Parse(objReader["InstituteNews_Date"].ToString());
				objInstituteNewsList.Add(objInstituteNews);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteNewsList;
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

	public CoreWebList<InstituteNewsClass> fn_getInstituteNewsByInstituteID(int iInstituteID)
	{
		CoreWebList<InstituteNewsClass> objInstituteNewsList = null;
		InstituteNewsClass objInstituteNews = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteNews WHERE InstituteNews_InstituteID=@InstituteNews_InstituteID", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteNews_InstituteID", iInstituteID);
			objReader = objCommand.ExecuteReader();
			objInstituteNewsList = new CoreWebList<InstituteNewsClass>();
			while (objReader.Read())
			{
				objInstituteNews = new InstituteNewsClass();
				objInstituteNews.iID = int.Parse(objReader["InstituteNews_ID"].ToString());
				objInstituteNews.iInstituteID = int.Parse(objReader["InstituteNews_InstituteID"].ToString());
				objInstituteNews.strTitle = objReader["InstituteNews_Title"].ToString();
				objInstituteNews.strDesc = objReader["InstituteNews_Desc"].ToString();
				objInstituteNews.strPhoto = objReader["InstituteNews_Photo"].ToString();
				objInstituteNews.dtDate = DateTime.Parse(objReader["InstituteNews_Date"].ToString());
				objInstituteNewsList.Add(objInstituteNews);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteNewsList;
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
