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
/// Summary description for DBSchoolPhotoClass
/// </summary>
public class DBSchoolPhotoClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveSchoolPhoto(SchoolPhotoClass objSchoolPhoto)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_SchoolPhotos (SchoolPhoto_SchoolID, SchoolPhoto_Title, SchoolPhoto_Photo) VALUES (@SchoolPhoto_SchoolID, @SchoolPhoto_Title, @SchoolPhoto_Photo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@SchoolPhoto_SchoolID", objSchoolPhoto.iSchoolID);
			objCommand.Parameters.AddWithValue("@SchoolPhoto_Title", objSchoolPhoto.strTitle);
			objCommand.Parameters.AddWithValue("@SchoolPhoto_Photo", objSchoolPhoto.strPhoto);

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

	public string fn_editSchoolPhoto(SchoolPhotoClass objSchoolPhoto)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_SchoolPhotos SET SchoolPhoto_SchoolID=@SchoolPhoto_SchoolID, SchoolPhoto_Title=@SchoolPhoto_Title, SchoolPhoto_Photo=@SchoolPhoto_Photo WHERE SchoolPhoto_ID=@SchoolPhoto_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@SchoolPhoto_ID", objSchoolPhoto.iID);
			objCommand.Parameters.AddWithValue("@SchoolPhoto_SchoolID", objSchoolPhoto.iSchoolID);
			objCommand.Parameters.AddWithValue("@SchoolPhoto_Title", objSchoolPhoto.strTitle);
			objCommand.Parameters.AddWithValue("@SchoolPhoto_Photo", objSchoolPhoto.strPhoto);

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

	public string fn_deleteSchoolPhoto(int iSchoolPhotoID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_SchoolPhotos WHERE SchoolPhoto_ID=@SchoolPhoto_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@SchoolPhoto_ID", iSchoolPhotoID);

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

	public CoreWebList<SchoolPhotoClass> fn_getSchoolPhotoList()
	{
		CoreWebList<SchoolPhotoClass> objSchoolPhotoList = null;
		SchoolPhotoClass objSchoolPhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolPhotos", objConnection);
			objReader = objCommand.ExecuteReader();
			objSchoolPhotoList = new CoreWebList<SchoolPhotoClass>();
			while (objReader.Read())
			{
				objSchoolPhoto = new SchoolPhotoClass();
				objSchoolPhoto.iID = int.Parse(objReader["SchoolPhoto_ID"].ToString());
				objSchoolPhoto.iSchoolID = int.Parse(objReader["SchoolPhoto_SchoolID"].ToString());
				objSchoolPhoto.strTitle = objReader["SchoolPhoto_Title"].ToString();
				objSchoolPhoto.strPhoto = objReader["SchoolPhoto_Photo"].ToString();
				objSchoolPhotoList.Add(objSchoolPhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolPhotoList;
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

	public CoreWebList<SchoolPhotoClass> fn_getSchoolPhotoByID(int iSchoolPhotoID)
	{
		CoreWebList<SchoolPhotoClass> objSchoolPhotoList = null;
		SchoolPhotoClass objSchoolPhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolPhotos WHERE SchoolPhoto_ID=@SchoolPhoto_ID", objConnection);
			objCommand.Parameters.AddWithValue("@SchoolPhoto_ID", iSchoolPhotoID);
			objReader = objCommand.ExecuteReader();
			objSchoolPhotoList = new CoreWebList<SchoolPhotoClass>();
			if (objReader.Read())
			{
				objSchoolPhoto = new SchoolPhotoClass();
				objSchoolPhoto.iID = int.Parse(objReader["SchoolPhoto_ID"].ToString());
				objSchoolPhoto.iSchoolID = int.Parse(objReader["SchoolPhoto_SchoolID"].ToString());
				objSchoolPhoto.strTitle = objReader["SchoolPhoto_Title"].ToString();
				objSchoolPhoto.strPhoto = objReader["SchoolPhoto_Photo"].ToString();
				objSchoolPhotoList.Add(objSchoolPhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolPhotoList;
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

	public CoreWebList<SchoolPhotoClass> fn_getSchoolPhotoByName(string strSchoolPhotoTitle)
	{
		CoreWebList<SchoolPhotoClass> objSchoolPhotoList = null;
		SchoolPhotoClass objSchoolPhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolPhotos WHERE SchoolPhoto_Title=@SchoolPhoto_Title", objConnection);
			objCommand.Parameters.AddWithValue("@SchoolPhoto_Title", strSchoolPhotoTitle);
			objReader = objCommand.ExecuteReader();
			objSchoolPhotoList = new CoreWebList<SchoolPhotoClass>();
			if (objReader.Read())
			{
				objSchoolPhoto = new SchoolPhotoClass();
				objSchoolPhoto.iID = int.Parse(objReader["SchoolPhoto_ID"].ToString());
				objSchoolPhoto.iSchoolID = int.Parse(objReader["SchoolPhoto_SchoolID"].ToString());
				objSchoolPhoto.strTitle = objReader["SchoolPhoto_Title"].ToString();
				objSchoolPhoto.strPhoto = objReader["SchoolPhoto_Photo"].ToString();
				objSchoolPhotoList.Add(objSchoolPhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolPhotoList;
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

	public CoreWebList<SchoolPhotoClass> fn_getSchoolPhotoByKeys(string strSchoolPhotoTitle)
	{
		CoreWebList<SchoolPhotoClass> objSchoolPhotoList = null;
		SchoolPhotoClass objSchoolPhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolPhotos WHERE SchoolPhoto_Title like '%' + @SchoolPhoto_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@SchoolPhoto_Title", strSchoolPhotoTitle);
			objReader = objCommand.ExecuteReader();
			objSchoolPhotoList = new CoreWebList<SchoolPhotoClass>();
			while (objReader.Read())
			{
				objSchoolPhoto = new SchoolPhotoClass();
				objSchoolPhoto.iID = int.Parse(objReader["SchoolPhoto_ID"].ToString());
				objSchoolPhoto.iSchoolID = int.Parse(objReader["SchoolPhoto_SchoolID"].ToString());
				objSchoolPhoto.strTitle = objReader["SchoolPhoto_Title"].ToString();
				objSchoolPhoto.strPhoto = objReader["SchoolPhoto_Photo"].ToString();
				objSchoolPhotoList.Add(objSchoolPhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolPhotoList;
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

	public CoreWebList<SchoolPhotoClass> fn_getSchoolPhotoBySchoolID(int iSchoolID)
	{
		CoreWebList<SchoolPhotoClass> objSchoolPhotoList = null;
		SchoolPhotoClass objSchoolPhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolPhotos WHERE SchoolPhoto_SchoolID=@SchoolPhoto_SchoolID", objConnection);
			objCommand.Parameters.AddWithValue("@SchoolPhoto_SchoolID", iSchoolID);
			objReader = objCommand.ExecuteReader();
			objSchoolPhotoList = new CoreWebList<SchoolPhotoClass>();
			while (objReader.Read())
			{
				objSchoolPhoto = new SchoolPhotoClass();
				objSchoolPhoto.iID = int.Parse(objReader["SchoolPhoto_ID"].ToString());
				objSchoolPhoto.iSchoolID = int.Parse(objReader["SchoolPhoto_SchoolID"].ToString());
				objSchoolPhoto.strTitle = objReader["SchoolPhoto_Title"].ToString();
				objSchoolPhoto.strPhoto = objReader["SchoolPhoto_Photo"].ToString();
				objSchoolPhotoList.Add(objSchoolPhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolPhotoList;
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
