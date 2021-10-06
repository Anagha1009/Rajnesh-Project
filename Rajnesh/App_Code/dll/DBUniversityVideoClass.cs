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
/// Summary description for DBUniversityVideoClass
/// </summary>
public class DBUniversityVideoClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveUniversityVideo(UniversityVideoClass objUniversityVideo)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_UniversityVideos (UniversityVideo_UniversityID, UniversityVideo_Title, UniversityVideo_Url) VALUES (@UniversityVideo_UniversityID, @UniversityVideo_Title, @UniversityVideo_Url)",objConnection) ;
			objCommand.Parameters.AddWithValue("@UniversityVideo_UniversityID", objUniversityVideo.iUniversityID);
			objCommand.Parameters.AddWithValue("@UniversityVideo_Title", objUniversityVideo.strTitle);
			objCommand.Parameters.AddWithValue("@UniversityVideo_Url", objUniversityVideo.strUrl);

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

	public string fn_editUniversityVideo(UniversityVideoClass objUniversityVideo)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_UniversityVideos SET UniversityVideo_Title=@UniversityVideo_Title, UniversityVideo_Url=@UniversityVideo_Url WHERE UniversityVideo_ID=@UniversityVideo_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@UniversityVideo_ID", objUniversityVideo.iID);
            objCommand.Parameters.AddWithValue("@UniversityVideo_Title", objUniversityVideo.strTitle);
            objCommand.Parameters.AddWithValue("@UniversityVideo_Url", objUniversityVideo.strUrl);

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

	public string fn_deleteUniversityVideo(int iUniversityVideoID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_UniversityVideos WHERE UniversityVideo_ID=@UniversityVideo_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@UniversityVideo_ID", iUniversityVideoID);

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

	public CoreWebList<UniversityVideoClass> fn_getUniversityVideoList()
	{
		CoreWebList<UniversityVideoClass> objUniversityVideoList = null;
		UniversityVideoClass objUniversityVideo = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_UniversityVideos", objConnection);
			objReader = objCommand.ExecuteReader();
			objUniversityVideoList = new CoreWebList<UniversityVideoClass>();
			while (objReader.Read())
			{
				objUniversityVideo = new UniversityVideoClass();
				objUniversityVideo.iID = int.Parse(objReader["UniversityVideo_ID"].ToString());
				objUniversityVideo.iUniversityID = int.Parse(objReader["UniversityVideo_UniversityID"].ToString());
				objUniversityVideo.strTitle = objReader["UniversityVideo_Title"].ToString();
				objUniversityVideo.strUrl = objReader["UniversityVideo_Url"].ToString();
				objUniversityVideoList.Add(objUniversityVideo);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objUniversityVideoList;
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

	public CoreWebList<UniversityVideoClass> fn_getUniversityVideoByID(int iUniversityVideoID)
	{
		CoreWebList<UniversityVideoClass> objUniversityVideoList = null;
		UniversityVideoClass objUniversityVideo = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_UniversityVideos WHERE UniversityVideo_ID=@UniversityVideo_ID", objConnection);
			objCommand.Parameters.AddWithValue("@UniversityVideo_ID", iUniversityVideoID);
			objReader = objCommand.ExecuteReader();
			objUniversityVideoList = new CoreWebList<UniversityVideoClass>();
			if (objReader.Read())
			{
				objUniversityVideo = new UniversityVideoClass();
				objUniversityVideo.iID = int.Parse(objReader["UniversityVideo_ID"].ToString());
				objUniversityVideo.iUniversityID = int.Parse(objReader["UniversityVideo_UniversityID"].ToString());
				objUniversityVideo.strTitle = objReader["UniversityVideo_Title"].ToString();
				objUniversityVideo.strUrl = objReader["UniversityVideo_Url"].ToString();
				objUniversityVideoList.Add(objUniversityVideo);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objUniversityVideoList;
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

	public CoreWebList<UniversityVideoClass> fn_getUniversityVideoByName(string strUniversityVideoTitle)
	{
		CoreWebList<UniversityVideoClass> objUniversityVideoList = null;
		UniversityVideoClass objUniversityVideo = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_UniversityVideos WHERE UniversityVideo_Title=@UniversityVideo_Title", objConnection);
			objCommand.Parameters.AddWithValue("@UniversityVideo_Title", strUniversityVideoTitle);
			objReader = objCommand.ExecuteReader();
			objUniversityVideoList = new CoreWebList<UniversityVideoClass>();
			if (objReader.Read())
			{
				objUniversityVideo = new UniversityVideoClass();
				objUniversityVideo.iID = int.Parse(objReader["UniversityVideo_ID"].ToString());
				objUniversityVideo.iUniversityID = int.Parse(objReader["UniversityVideo_UniversityID"].ToString());
				objUniversityVideo.strTitle = objReader["UniversityVideo_Title"].ToString();
				objUniversityVideo.strUrl = objReader["UniversityVideo_Url"].ToString();
				objUniversityVideoList.Add(objUniversityVideo);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objUniversityVideoList;
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

	public CoreWebList<UniversityVideoClass> fn_getUniversityVideoByKeys(string strUniversityVideoTitle)
	{
		CoreWebList<UniversityVideoClass> objUniversityVideoList = null;
		UniversityVideoClass objUniversityVideo = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_UniversityVideos WHERE UniversityVideo_Title like '%' + @UniversityVideo_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@UniversityVideo_Title", strUniversityVideoTitle);
			objReader = objCommand.ExecuteReader();
			objUniversityVideoList = new CoreWebList<UniversityVideoClass>();
			while (objReader.Read())
			{
				objUniversityVideo = new UniversityVideoClass();
				objUniversityVideo.iID = int.Parse(objReader["UniversityVideo_ID"].ToString());
				objUniversityVideo.iUniversityID = int.Parse(objReader["UniversityVideo_UniversityID"].ToString());
				objUniversityVideo.strTitle = objReader["UniversityVideo_Title"].ToString();
				objUniversityVideo.strUrl = objReader["UniversityVideo_Url"].ToString();
				objUniversityVideoList.Add(objUniversityVideo);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objUniversityVideoList;
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

	public CoreWebList<UniversityVideoClass> fn_getUniversityVideoByUniversityID(int iUniversityID)
	{
		CoreWebList<UniversityVideoClass> objUniversityVideoList = null;
		UniversityVideoClass objUniversityVideo = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_UniversityVideos WHERE UniversityVideo_UniversityID=@UniversityVideo_UniversityID", objConnection);
			objCommand.Parameters.AddWithValue("@UniversityVideo_UniversityID", iUniversityID);
			objReader = objCommand.ExecuteReader();
			objUniversityVideoList = new CoreWebList<UniversityVideoClass>();
			while (objReader.Read())
			{
				objUniversityVideo = new UniversityVideoClass();
				objUniversityVideo.iID = int.Parse(objReader["UniversityVideo_ID"].ToString());
				objUniversityVideo.iUniversityID = int.Parse(objReader["UniversityVideo_UniversityID"].ToString());
				objUniversityVideo.strTitle = objReader["UniversityVideo_Title"].ToString();
				objUniversityVideo.strUrl = objReader["UniversityVideo_Url"].ToString();
				objUniversityVideoList.Add(objUniversityVideo);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objUniversityVideoList;
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
