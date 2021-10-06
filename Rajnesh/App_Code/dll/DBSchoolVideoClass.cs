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
/// Summary description for DBSchoolVideoClass
/// </summary>
public class DBSchoolVideoClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveSchoolVideo(SchoolVideoClass objSchoolVideo)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_SchoolVideos (SchoolVideo_SchoolID, SchoolVideo_Title, SchoolVideo_Url) VALUES (@SchoolVideo_SchoolID, @SchoolVideo_Title, @SchoolVideo_Url)",objConnection) ;
			objCommand.Parameters.AddWithValue("@SchoolVideo_SchoolID", objSchoolVideo.iSchoolID);
			objCommand.Parameters.AddWithValue("@SchoolVideo_Title", objSchoolVideo.strTitle);
			objCommand.Parameters.AddWithValue("@SchoolVideo_Url", objSchoolVideo.strUrl);

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

	public string fn_editSchoolVideo(SchoolVideoClass objSchoolVideo)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_SchoolVideos SET SchoolVideo_SchoolID=@SchoolVideo_SchoolID, SchoolVideo_Title=@SchoolVideo_Title, SchoolVideo_Url=@SchoolVideo_Url WHERE SchoolVideo_ID=@SchoolVideo_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@SchoolVideo_ID", objSchoolVideo.iID);
			objCommand.Parameters.AddWithValue("@SchoolVideo_SchoolID", objSchoolVideo.iSchoolID);
			objCommand.Parameters.AddWithValue("@SchoolVideo_Title", objSchoolVideo.strTitle);
			objCommand.Parameters.AddWithValue("@SchoolVideo_Url", objSchoolVideo.strUrl);

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

	public string fn_deleteSchoolVideo(int iSchoolVideoID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_SchoolVideos WHERE SchoolVideo_ID=@SchoolVideo_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@SchoolVideo_ID", iSchoolVideoID);

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

	public CoreWebList<SchoolVideoClass> fn_getSchoolVideoList()
	{
		CoreWebList<SchoolVideoClass> objSchoolVideoList = null;
		SchoolVideoClass objSchoolVideo = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolVideos", objConnection);
			objReader = objCommand.ExecuteReader();
			objSchoolVideoList = new CoreWebList<SchoolVideoClass>();
			while (objReader.Read())
			{
				objSchoolVideo = new SchoolVideoClass();
				objSchoolVideo.iID = int.Parse(objReader["SchoolVideo_ID"].ToString());
				objSchoolVideo.iSchoolID = int.Parse(objReader["SchoolVideo_SchoolID"].ToString());
				objSchoolVideo.strTitle = objReader["SchoolVideo_Title"].ToString();
				objSchoolVideo.strUrl = objReader["SchoolVideo_Url"].ToString();
				objSchoolVideoList.Add(objSchoolVideo);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolVideoList;
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

	public CoreWebList<SchoolVideoClass> fn_getSchoolVideoByID(int iSchoolVideoID)
	{
		CoreWebList<SchoolVideoClass> objSchoolVideoList = null;
		SchoolVideoClass objSchoolVideo = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolVideos WHERE SchoolVideo_ID=@SchoolVideo_ID", objConnection);
			objCommand.Parameters.AddWithValue("@SchoolVideo_ID", iSchoolVideoID);
			objReader = objCommand.ExecuteReader();
			objSchoolVideoList = new CoreWebList<SchoolVideoClass>();
			if (objReader.Read())
			{
				objSchoolVideo = new SchoolVideoClass();
				objSchoolVideo.iID = int.Parse(objReader["SchoolVideo_ID"].ToString());
				objSchoolVideo.iSchoolID = int.Parse(objReader["SchoolVideo_SchoolID"].ToString());
				objSchoolVideo.strTitle = objReader["SchoolVideo_Title"].ToString();
				objSchoolVideo.strUrl = objReader["SchoolVideo_Url"].ToString();
				objSchoolVideoList.Add(objSchoolVideo);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolVideoList;
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

	public CoreWebList<SchoolVideoClass> fn_getSchoolVideoByName(string strSchoolVideoTitle)
	{
		CoreWebList<SchoolVideoClass> objSchoolVideoList = null;
		SchoolVideoClass objSchoolVideo = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolVideos WHERE SchoolVideo_Title=@SchoolVideo_Title", objConnection);
			objCommand.Parameters.AddWithValue("@SchoolVideo_Title", strSchoolVideoTitle);
			objReader = objCommand.ExecuteReader();
			objSchoolVideoList = new CoreWebList<SchoolVideoClass>();
			if (objReader.Read())
			{
				objSchoolVideo = new SchoolVideoClass();
				objSchoolVideo.iID = int.Parse(objReader["SchoolVideo_ID"].ToString());
				objSchoolVideo.iSchoolID = int.Parse(objReader["SchoolVideo_SchoolID"].ToString());
				objSchoolVideo.strTitle = objReader["SchoolVideo_Title"].ToString();
				objSchoolVideo.strUrl = objReader["SchoolVideo_Url"].ToString();
				objSchoolVideoList.Add(objSchoolVideo);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolVideoList;
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

	public CoreWebList<SchoolVideoClass> fn_getSchoolVideoByKeys(string strSchoolVideoTitle)
	{
		CoreWebList<SchoolVideoClass> objSchoolVideoList = null;
		SchoolVideoClass objSchoolVideo = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolVideos WHERE SchoolVideo_Title like '%' + @SchoolVideo_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@SchoolVideo_Title", strSchoolVideoTitle);
			objReader = objCommand.ExecuteReader();
			objSchoolVideoList = new CoreWebList<SchoolVideoClass>();
			while (objReader.Read())
			{
				objSchoolVideo = new SchoolVideoClass();
				objSchoolVideo.iID = int.Parse(objReader["SchoolVideo_ID"].ToString());
				objSchoolVideo.iSchoolID = int.Parse(objReader["SchoolVideo_SchoolID"].ToString());
				objSchoolVideo.strTitle = objReader["SchoolVideo_Title"].ToString();
				objSchoolVideo.strUrl = objReader["SchoolVideo_Url"].ToString();
				objSchoolVideoList.Add(objSchoolVideo);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolVideoList;
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

	public CoreWebList<SchoolVideoClass> fn_getSchoolVideoBySchoolID(int iSchoolID)
	{
		CoreWebList<SchoolVideoClass> objSchoolVideoList = null;
		SchoolVideoClass objSchoolVideo = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolVideos WHERE SchoolVideo_SchoolID=@SchoolVideo_SchoolID", objConnection);
			objCommand.Parameters.AddWithValue("@SchoolVideo_SchoolID", iSchoolID);
			objReader = objCommand.ExecuteReader();
			objSchoolVideoList = new CoreWebList<SchoolVideoClass>();
			while (objReader.Read())
			{
				objSchoolVideo = new SchoolVideoClass();
				objSchoolVideo.iID = int.Parse(objReader["SchoolVideo_ID"].ToString());
				objSchoolVideo.iSchoolID = int.Parse(objReader["SchoolVideo_SchoolID"].ToString());
				objSchoolVideo.strTitle = objReader["SchoolVideo_Title"].ToString();
				objSchoolVideo.strUrl = objReader["SchoolVideo_Url"].ToString();
				objSchoolVideoList.Add(objSchoolVideo);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolVideoList;
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
