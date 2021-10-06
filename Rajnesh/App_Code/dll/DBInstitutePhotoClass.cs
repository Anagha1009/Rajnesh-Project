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
/// Summary description for DBInstitutePhotoClass
/// </summary>
public class DBInstitutePhotoClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveInstitutePhoto(InstitutePhotoClass objInstitutePhoto)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_InstitutePhotos (InstitutePhoto_InstituteID, InstitutePhoto_Title, InstitutePhoto_Photo) VALUES (@InstitutePhoto_InstituteID, @InstitutePhoto_Title, @InstitutePhoto_Photo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@InstitutePhoto_InstituteID", objInstitutePhoto.iInstituteID);
			objCommand.Parameters.AddWithValue("@InstitutePhoto_Title", objInstitutePhoto.strTitle);
			objCommand.Parameters.AddWithValue("@InstitutePhoto_Photo", objInstitutePhoto.strPhoto);

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

	public string fn_editInstitutePhoto(InstitutePhotoClass objInstitutePhoto)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_InstitutePhotos SET InstitutePhoto_InstituteID=@InstitutePhoto_InstituteID, InstitutePhoto_Title=@InstitutePhoto_Title, InstitutePhoto_Photo=@InstitutePhoto_Photo WHERE InstitutePhoto_ID=@InstitutePhoto_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@InstitutePhoto_ID", objInstitutePhoto.iID);
			objCommand.Parameters.AddWithValue("@InstitutePhoto_InstituteID", objInstitutePhoto.iInstituteID);
			objCommand.Parameters.AddWithValue("@InstitutePhoto_Title", objInstitutePhoto.strTitle);
			objCommand.Parameters.AddWithValue("@InstitutePhoto_Photo", objInstitutePhoto.strPhoto);

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

	public string fn_deleteInstitutePhoto(int iInstitutePhotoID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_InstitutePhotos WHERE InstitutePhoto_ID=@InstitutePhoto_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@InstitutePhoto_ID", iInstitutePhotoID);

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

	public CoreWebList<InstitutePhotoClass> fn_getInstitutePhotoList()
	{
		CoreWebList<InstitutePhotoClass> objInstitutePhotoList = null;
		InstitutePhotoClass objInstitutePhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstitutePhotos", objConnection);
			objReader = objCommand.ExecuteReader();
			objInstitutePhotoList = new CoreWebList<InstitutePhotoClass>();
			while (objReader.Read())
			{
				objInstitutePhoto = new InstitutePhotoClass();
				objInstitutePhoto.iID = int.Parse(objReader["InstitutePhoto_ID"].ToString());
				objInstitutePhoto.iInstituteID = int.Parse(objReader["InstitutePhoto_InstituteID"].ToString());
				objInstitutePhoto.strTitle = objReader["InstitutePhoto_Title"].ToString();
				objInstitutePhoto.strPhoto = objReader["InstitutePhoto_Photo"].ToString();
				objInstitutePhotoList.Add(objInstitutePhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstitutePhotoList;
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

	public CoreWebList<InstitutePhotoClass> fn_getInstitutePhotoByID(int iInstitutePhotoID)
	{
		CoreWebList<InstitutePhotoClass> objInstitutePhotoList = null;
		InstitutePhotoClass objInstitutePhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstitutePhotos WHERE InstitutePhoto_ID=@InstitutePhoto_ID", objConnection);
			objCommand.Parameters.AddWithValue("@InstitutePhoto_ID", iInstitutePhotoID);
			objReader = objCommand.ExecuteReader();
			objInstitutePhotoList = new CoreWebList<InstitutePhotoClass>();
			if (objReader.Read())
			{
				objInstitutePhoto = new InstitutePhotoClass();
				objInstitutePhoto.iID = int.Parse(objReader["InstitutePhoto_ID"].ToString());
				objInstitutePhoto.iInstituteID = int.Parse(objReader["InstitutePhoto_InstituteID"].ToString());
				objInstitutePhoto.strTitle = objReader["InstitutePhoto_Title"].ToString();
				objInstitutePhoto.strPhoto = objReader["InstitutePhoto_Photo"].ToString();
				objInstitutePhotoList.Add(objInstitutePhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstitutePhotoList;
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

	public CoreWebList<InstitutePhotoClass> fn_getInstitutePhotoByName(string strInstitutePhotoTitle)
	{
		CoreWebList<InstitutePhotoClass> objInstitutePhotoList = null;
		InstitutePhotoClass objInstitutePhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstitutePhotos WHERE InstitutePhoto_Title=@InstitutePhoto_Title", objConnection);
			objCommand.Parameters.AddWithValue("@InstitutePhoto_Title", strInstitutePhotoTitle);
			objReader = objCommand.ExecuteReader();
			objInstitutePhotoList = new CoreWebList<InstitutePhotoClass>();
			if (objReader.Read())
			{
				objInstitutePhoto = new InstitutePhotoClass();
				objInstitutePhoto.iID = int.Parse(objReader["InstitutePhoto_ID"].ToString());
				objInstitutePhoto.iInstituteID = int.Parse(objReader["InstitutePhoto_InstituteID"].ToString());
				objInstitutePhoto.strTitle = objReader["InstitutePhoto_Title"].ToString();
				objInstitutePhoto.strPhoto = objReader["InstitutePhoto_Photo"].ToString();
				objInstitutePhotoList.Add(objInstitutePhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstitutePhotoList;
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

	public CoreWebList<InstitutePhotoClass> fn_getInstitutePhotoByKeys(string strInstitutePhotoTitle)
	{
		CoreWebList<InstitutePhotoClass> objInstitutePhotoList = null;
		InstitutePhotoClass objInstitutePhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstitutePhotos WHERE InstitutePhoto_Title like '%' + @InstitutePhoto_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@InstitutePhoto_Title", strInstitutePhotoTitle);
			objReader = objCommand.ExecuteReader();
			objInstitutePhotoList = new CoreWebList<InstitutePhotoClass>();
			while (objReader.Read())
			{
				objInstitutePhoto = new InstitutePhotoClass();
				objInstitutePhoto.iID = int.Parse(objReader["InstitutePhoto_ID"].ToString());
				objInstitutePhoto.iInstituteID = int.Parse(objReader["InstitutePhoto_InstituteID"].ToString());
				objInstitutePhoto.strTitle = objReader["InstitutePhoto_Title"].ToString();
				objInstitutePhoto.strPhoto = objReader["InstitutePhoto_Photo"].ToString();
				objInstitutePhotoList.Add(objInstitutePhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstitutePhotoList;
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

	public CoreWebList<InstitutePhotoClass> fn_getInstitutePhotoByInstituteID(int iInstituteID)
	{
		CoreWebList<InstitutePhotoClass> objInstitutePhotoList = null;
		InstitutePhotoClass objInstitutePhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstitutePhotos WHERE InstitutePhoto_InstituteID=@InstitutePhoto_InstituteID", objConnection);
			objCommand.Parameters.AddWithValue("@InstitutePhoto_InstituteID", iInstituteID);
			objReader = objCommand.ExecuteReader();
			objInstitutePhotoList = new CoreWebList<InstitutePhotoClass>();
			while (objReader.Read())
			{
				objInstitutePhoto = new InstitutePhotoClass();
				objInstitutePhoto.iID = int.Parse(objReader["InstitutePhoto_ID"].ToString());
				objInstitutePhoto.iInstituteID = int.Parse(objReader["InstitutePhoto_InstituteID"].ToString());
				objInstitutePhoto.strTitle = objReader["InstitutePhoto_Title"].ToString();
				objInstitutePhoto.strPhoto = objReader["InstitutePhoto_Photo"].ToString();
				objInstitutePhotoList.Add(objInstitutePhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstitutePhotoList;
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
