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
/// Summary description for DBUniversityPhotoClass
/// </summary>
public class DBUniversityPhotoClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveUniversityPhoto(UniversityPhotoClass objUniversityPhoto)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_UniversityPhotos (UniversityPhoto_UniversityID, UniversityPhoto_Title, UniversityPhoto_Photo) VALUES (@UniversityPhoto_UniversityID, @UniversityPhoto_Title, @UniversityPhoto_Photo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@UniversityPhoto_UniversityID", objUniversityPhoto.iUniversityID);
			objCommand.Parameters.AddWithValue("@UniversityPhoto_Title", objUniversityPhoto.strTitle);
			objCommand.Parameters.AddWithValue("@UniversityPhoto_Photo", objUniversityPhoto.strPhoto);

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

	public string fn_editUniversityPhoto(UniversityPhotoClass objUniversityPhoto)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_UniversityPhotos SET UniversityPhoto_Title=@UniversityPhoto_Title, UniversityPhoto_Photo=@UniversityPhoto_Photo WHERE UniversityPhoto_ID=@UniversityPhoto_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@UniversityPhoto_ID", objUniversityPhoto.iID);
            objCommand.Parameters.AddWithValue("@UniversityPhoto_Title", objUniversityPhoto.strTitle);
            objCommand.Parameters.AddWithValue("@UniversityPhoto_Photo", objUniversityPhoto.strPhoto);

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

	public string fn_deleteUniversityPhoto(int iUniversityPhotoID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_UniversityPhotos WHERE UniversityPhoto_ID=@UniversityPhoto_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@UniversityPhoto_ID", iUniversityPhotoID);

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

	public CoreWebList<UniversityPhotoClass> fn_getUniversityPhotoList()
	{
		CoreWebList<UniversityPhotoClass> objUniversityPhotoList = null;
		UniversityPhotoClass objUniversityPhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_UniversityPhotos", objConnection);
			objReader = objCommand.ExecuteReader();
			objUniversityPhotoList = new CoreWebList<UniversityPhotoClass>();
			while (objReader.Read())
			{
				objUniversityPhoto = new UniversityPhotoClass();
				objUniversityPhoto.iID = int.Parse(objReader["UniversityPhoto_ID"].ToString());
				objUniversityPhoto.iUniversityID = int.Parse(objReader["UniversityPhoto_UniversityID"].ToString());
				objUniversityPhoto.strTitle = objReader["UniversityPhoto_Title"].ToString();
				objUniversityPhoto.strPhoto = objReader["UniversityPhoto_Photo"].ToString();
				objUniversityPhotoList.Add(objUniversityPhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objUniversityPhotoList;
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

	public CoreWebList<UniversityPhotoClass> fn_getUniversityPhotoByID(int iUniversityPhotoID)
	{
		CoreWebList<UniversityPhotoClass> objUniversityPhotoList = null;
		UniversityPhotoClass objUniversityPhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_UniversityPhotos WHERE UniversityPhoto_ID=@UniversityPhoto_ID", objConnection);
			objCommand.Parameters.AddWithValue("@UniversityPhoto_ID", iUniversityPhotoID);
			objReader = objCommand.ExecuteReader();
			objUniversityPhotoList = new CoreWebList<UniversityPhotoClass>();
			if (objReader.Read())
			{
				objUniversityPhoto = new UniversityPhotoClass();
				objUniversityPhoto.iID = int.Parse(objReader["UniversityPhoto_ID"].ToString());
				objUniversityPhoto.iUniversityID = int.Parse(objReader["UniversityPhoto_UniversityID"].ToString());
				objUniversityPhoto.strTitle = objReader["UniversityPhoto_Title"].ToString();
				objUniversityPhoto.strPhoto = objReader["UniversityPhoto_Photo"].ToString();
				objUniversityPhotoList.Add(objUniversityPhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objUniversityPhotoList;
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

	public CoreWebList<UniversityPhotoClass> fn_getUniversityPhotoByName(string strUniversityPhotoTitle)
	{
		CoreWebList<UniversityPhotoClass> objUniversityPhotoList = null;
		UniversityPhotoClass objUniversityPhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_UniversityPhotos WHERE UniversityPhoto_Title=@UniversityPhoto_Title", objConnection);
			objCommand.Parameters.AddWithValue("@UniversityPhoto_Title", strUniversityPhotoTitle);
			objReader = objCommand.ExecuteReader();
			objUniversityPhotoList = new CoreWebList<UniversityPhotoClass>();
			if (objReader.Read())
			{
				objUniversityPhoto = new UniversityPhotoClass();
				objUniversityPhoto.iID = int.Parse(objReader["UniversityPhoto_ID"].ToString());
				objUniversityPhoto.iUniversityID = int.Parse(objReader["UniversityPhoto_UniversityID"].ToString());
				objUniversityPhoto.strTitle = objReader["UniversityPhoto_Title"].ToString();
				objUniversityPhoto.strPhoto = objReader["UniversityPhoto_Photo"].ToString();
				objUniversityPhotoList.Add(objUniversityPhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objUniversityPhotoList;
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

	public CoreWebList<UniversityPhotoClass> fn_getUniversityPhotoByKeys(string strUniversityPhotoTitle)
	{
		CoreWebList<UniversityPhotoClass> objUniversityPhotoList = null;
		UniversityPhotoClass objUniversityPhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_UniversityPhotos WHERE UniversityPhoto_Title like '%' + @UniversityPhoto_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@UniversityPhoto_Title", strUniversityPhotoTitle);
			objReader = objCommand.ExecuteReader();
			objUniversityPhotoList = new CoreWebList<UniversityPhotoClass>();
			while (objReader.Read())
			{
				objUniversityPhoto = new UniversityPhotoClass();
				objUniversityPhoto.iID = int.Parse(objReader["UniversityPhoto_ID"].ToString());
				objUniversityPhoto.iUniversityID = int.Parse(objReader["UniversityPhoto_UniversityID"].ToString());
				objUniversityPhoto.strTitle = objReader["UniversityPhoto_Title"].ToString();
				objUniversityPhoto.strPhoto = objReader["UniversityPhoto_Photo"].ToString();
				objUniversityPhotoList.Add(objUniversityPhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objUniversityPhotoList;
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

	public CoreWebList<UniversityPhotoClass> fn_getUniversityPhotoByUniversityID(int iUniversityID)
	{
		CoreWebList<UniversityPhotoClass> objUniversityPhotoList = null;
		UniversityPhotoClass objUniversityPhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_UniversityPhotos WHERE UniversityPhoto_UniversityID=@UniversityPhoto_UniversityID", objConnection);
			objCommand.Parameters.AddWithValue("@UniversityPhoto_UniversityID", iUniversityID);
			objReader = objCommand.ExecuteReader();
			objUniversityPhotoList = new CoreWebList<UniversityPhotoClass>();
			while (objReader.Read())
			{
				objUniversityPhoto = new UniversityPhotoClass();
				objUniversityPhoto.iID = int.Parse(objReader["UniversityPhoto_ID"].ToString());
				objUniversityPhoto.iUniversityID = int.Parse(objReader["UniversityPhoto_UniversityID"].ToString());
				objUniversityPhoto.strTitle = objReader["UniversityPhoto_Title"].ToString();
				objUniversityPhoto.strPhoto = objReader["UniversityPhoto_Photo"].ToString();
				objUniversityPhotoList.Add(objUniversityPhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objUniversityPhotoList;
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
