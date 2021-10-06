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
/// Summary description for DBInstituteVideoClass
/// </summary>
public class DBInstituteVideoClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveInstituteVideo(InstituteVideoClass objInstituteVideo)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_InstituteVideos (InstituteVideo_InstituteID, InstituteVideo_Title, InstituteVideo_Url) VALUES (@InstituteVideo_InstituteID, @InstituteVideo_Title, @InstituteVideo_Url)",objConnection) ;
			objCommand.Parameters.AddWithValue("@InstituteVideo_InstituteID", objInstituteVideo.iInstituteID);
			objCommand.Parameters.AddWithValue("@InstituteVideo_Title", objInstituteVideo.strTitle);
			objCommand.Parameters.AddWithValue("@InstituteVideo_Url", objInstituteVideo.strUrl);

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

	public string fn_editInstituteVideo(InstituteVideoClass objInstituteVideo)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_InstituteVideos SET InstituteVideo_InstituteID=@InstituteVideo_InstituteID, InstituteVideo_Title=@InstituteVideo_Title, InstituteVideo_Url=@InstituteVideo_Url WHERE InstituteVideo_ID=@InstituteVideo_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@InstituteVideo_ID", objInstituteVideo.iID);
			objCommand.Parameters.AddWithValue("@InstituteVideo_InstituteID", objInstituteVideo.iInstituteID);
			objCommand.Parameters.AddWithValue("@InstituteVideo_Title", objInstituteVideo.strTitle);
			objCommand.Parameters.AddWithValue("@InstituteVideo_Url", objInstituteVideo.strUrl);

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

	public string fn_deleteInstituteVideo(int iInstituteVideoID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_InstituteVideos WHERE InstituteVideo_ID=@InstituteVideo_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@InstituteVideo_ID", iInstituteVideoID);

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

	public CoreWebList<InstituteVideoClass> fn_getInstituteVideoList()
	{
		CoreWebList<InstituteVideoClass> objInstituteVideoList = null;
		InstituteVideoClass objInstituteVideo = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteVideos", objConnection);
			objReader = objCommand.ExecuteReader();
			objInstituteVideoList = new CoreWebList<InstituteVideoClass>();
			while (objReader.Read())
			{
				objInstituteVideo = new InstituteVideoClass();
				objInstituteVideo.iID = int.Parse(objReader["InstituteVideo_ID"].ToString());
				objInstituteVideo.iInstituteID = int.Parse(objReader["InstituteVideo_InstituteID"].ToString());
				objInstituteVideo.strTitle = objReader["InstituteVideo_Title"].ToString();
				objInstituteVideo.strUrl = objReader["InstituteVideo_Url"].ToString();
				objInstituteVideoList.Add(objInstituteVideo);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteVideoList;
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

	public CoreWebList<InstituteVideoClass> fn_getInstituteVideoByID(int iInstituteVideoID)
	{
		CoreWebList<InstituteVideoClass> objInstituteVideoList = null;
		InstituteVideoClass objInstituteVideo = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteVideos WHERE InstituteVideo_ID=@InstituteVideo_ID", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteVideo_ID", iInstituteVideoID);
			objReader = objCommand.ExecuteReader();
			objInstituteVideoList = new CoreWebList<InstituteVideoClass>();
			if (objReader.Read())
			{
				objInstituteVideo = new InstituteVideoClass();
				objInstituteVideo.iID = int.Parse(objReader["InstituteVideo_ID"].ToString());
				objInstituteVideo.iInstituteID = int.Parse(objReader["InstituteVideo_InstituteID"].ToString());
				objInstituteVideo.strTitle = objReader["InstituteVideo_Title"].ToString();
				objInstituteVideo.strUrl = objReader["InstituteVideo_Url"].ToString();
				objInstituteVideoList.Add(objInstituteVideo);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteVideoList;
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

    public CoreWebList<InstituteVideoClass> fn_getInstituteVideoByInstituteID(int iInstituteID)
    {
        CoreWebList<InstituteVideoClass> objInstituteVideoList = null;
        InstituteVideoClass objInstituteVideo = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_InstituteVideos WHERE InstituteVideo_InstituteID=@InstituteVideo_InstituteID", objConnection);
            objCommand.Parameters.AddWithValue("@InstituteVideo_InstituteID", iInstituteID);
            objReader = objCommand.ExecuteReader();
            objInstituteVideoList = new CoreWebList<InstituteVideoClass>();
            while (objReader.Read())
            {
                objInstituteVideo = new InstituteVideoClass();
                objInstituteVideo.iID = int.Parse(objReader["InstituteVideo_ID"].ToString());
                objInstituteVideo.iInstituteID = int.Parse(objReader["InstituteVideo_InstituteID"].ToString());
                objInstituteVideo.strTitle = objReader["InstituteVideo_Title"].ToString();
                objInstituteVideo.strUrl = objReader["InstituteVideo_Url"].ToString();
                objInstituteVideoList.Add(objInstituteVideo);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteVideoList;
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

	public CoreWebList<InstituteVideoClass> fn_getInstituteVideoByName(string strInstituteVideoTitle)
	{
		CoreWebList<InstituteVideoClass> objInstituteVideoList = null;
		InstituteVideoClass objInstituteVideo = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteVideos WHERE InstituteVideo_Title=@InstituteVideo_Title", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteVideo_Title", strInstituteVideoTitle);
			objReader = objCommand.ExecuteReader();
			objInstituteVideoList = new CoreWebList<InstituteVideoClass>();
			if (objReader.Read())
			{
				objInstituteVideo = new InstituteVideoClass();
				objInstituteVideo.iID = int.Parse(objReader["InstituteVideo_ID"].ToString());
				objInstituteVideo.iInstituteID = int.Parse(objReader["InstituteVideo_InstituteID"].ToString());
				objInstituteVideo.strTitle = objReader["InstituteVideo_Title"].ToString();
				objInstituteVideo.strUrl = objReader["InstituteVideo_Url"].ToString();
				objInstituteVideoList.Add(objInstituteVideo);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteVideoList;
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

	public CoreWebList<InstituteVideoClass> fn_getInstituteVideoByKeys(string strInstituteVideoTitle)
	{
		CoreWebList<InstituteVideoClass> objInstituteVideoList = null;
		InstituteVideoClass objInstituteVideo = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteVideos WHERE InstituteVideo_Title like '%' + @InstituteVideo_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteVideo_Title", strInstituteVideoTitle);
			objReader = objCommand.ExecuteReader();
			objInstituteVideoList = new CoreWebList<InstituteVideoClass>();
			while (objReader.Read())
			{
				objInstituteVideo = new InstituteVideoClass();
				objInstituteVideo.iID = int.Parse(objReader["InstituteVideo_ID"].ToString());
				objInstituteVideo.iInstituteID = int.Parse(objReader["InstituteVideo_InstituteID"].ToString());
				objInstituteVideo.strTitle = objReader["InstituteVideo_Title"].ToString();
				objInstituteVideo.strUrl = objReader["InstituteVideo_Url"].ToString();
				objInstituteVideoList.Add(objInstituteVideo);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteVideoList;
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
