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
/// Summary description for DBPagePhotoClass
/// </summary>
public class DBPagePhotoClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_savePagePhoto(PagePhotoClass objPagePhoto)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_PagePhotos (PagePhoto_PageID, PagePhoto_Title, PagePhoto_Photo) VALUES (@PagePhoto_PageID, @PagePhoto_Title, @PagePhoto_Photo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@PagePhoto_PageID", objPagePhoto.iPageID);
			objCommand.Parameters.AddWithValue("@PagePhoto_Title", objPagePhoto.strTitle);
			objCommand.Parameters.AddWithValue("@PagePhoto_Photo", objPagePhoto.strPhoto);

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

	public string fn_editPagePhoto(PagePhotoClass objPagePhoto)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_PagePhotos SET PagePhoto_PageID=@PagePhoto_PageID, PagePhoto_Title=@PagePhoto_Title, PagePhoto_Photo=@PagePhoto_Photo WHERE PagePhoto_ID=@PagePhoto_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@PagePhoto_ID", objPagePhoto.iID);

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

	public string fn_deletePagePhoto(int iPagePhotoID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_PagePhotos WHERE PagePhoto_ID=@PagePhoto_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@PagePhoto_ID", iPagePhotoID);

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

	public CoreWebList<PagePhotoClass> fn_getPagePhotoList()
	{
		CoreWebList<PagePhotoClass> objPagePhotoList = null;
		PagePhotoClass objPagePhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_PagePhotos", objConnection);
			objReader = objCommand.ExecuteReader();
			objPagePhotoList = new CoreWebList<PagePhotoClass>();
			while (objReader.Read())
			{
				objPagePhoto = new PagePhotoClass();
				objPagePhoto.iID = int.Parse(objReader["PagePhoto_ID"].ToString());
				objPagePhoto.iPageID = int.Parse(objReader["PagePhoto_PageID"].ToString());
				objPagePhoto.strTitle = objReader["PagePhoto_Title"].ToString();
				objPagePhoto.strPhoto = objReader["PagePhoto_Photo"].ToString();
				objPagePhotoList.Add(objPagePhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objPagePhotoList;
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

	public CoreWebList<PagePhotoClass> fn_getPagePhotoByID(int iPagePhotoID)
	{
		CoreWebList<PagePhotoClass> objPagePhotoList = null;
		PagePhotoClass objPagePhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_PagePhotos WHERE PagePhoto_ID=@PagePhoto_ID", objConnection);
			objCommand.Parameters.AddWithValue("@PagePhoto_ID", iPagePhotoID);
			objReader = objCommand.ExecuteReader();
			objPagePhotoList = new CoreWebList<PagePhotoClass>();
			if (objReader.Read())
			{
				objPagePhoto = new PagePhotoClass();
				objPagePhoto.iID = int.Parse(objReader["PagePhoto_ID"].ToString());
				objPagePhoto.iPageID = int.Parse(objReader["PagePhoto_PageID"].ToString());
				objPagePhoto.strTitle = objReader["PagePhoto_Title"].ToString();
				objPagePhoto.strPhoto = objReader["PagePhoto_Photo"].ToString();
				objPagePhotoList.Add(objPagePhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objPagePhotoList;
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

	public CoreWebList<PagePhotoClass> fn_getPagePhotoByName(string strPagePhotoTitle)
	{
		CoreWebList<PagePhotoClass> objPagePhotoList = null;
		PagePhotoClass objPagePhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_PagePhotos WHERE PagePhoto_Title=@PagePhoto_Title", objConnection);
			objCommand.Parameters.AddWithValue("@PagePhoto_Title", strPagePhotoTitle);
			objReader = objCommand.ExecuteReader();
			objPagePhotoList = new CoreWebList<PagePhotoClass>();
			if (objReader.Read())
			{
				objPagePhoto = new PagePhotoClass();
				objPagePhoto.iID = int.Parse(objReader["PagePhoto_ID"].ToString());
				objPagePhoto.iPageID = int.Parse(objReader["PagePhoto_PageID"].ToString());
				objPagePhoto.strTitle = objReader["PagePhoto_Title"].ToString();
				objPagePhoto.strPhoto = objReader["PagePhoto_Photo"].ToString();
				objPagePhotoList.Add(objPagePhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objPagePhotoList;
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

	public CoreWebList<PagePhotoClass> fn_getPagePhotoByKeys(string strPagePhotoTitle)
	{
		CoreWebList<PagePhotoClass> objPagePhotoList = null;
		PagePhotoClass objPagePhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_PagePhotos WHERE PagePhoto_Title like '%' + @PagePhoto_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@PagePhoto_Title", strPagePhotoTitle);
			objReader = objCommand.ExecuteReader();
			objPagePhotoList = new CoreWebList<PagePhotoClass>();
			while (objReader.Read())
			{
				objPagePhoto = new PagePhotoClass();
				objPagePhoto.iID = int.Parse(objReader["PagePhoto_ID"].ToString());
				objPagePhoto.iPageID = int.Parse(objReader["PagePhoto_PageID"].ToString());
				objPagePhoto.strTitle = objReader["PagePhoto_Title"].ToString();
				objPagePhoto.strPhoto = objReader["PagePhoto_Photo"].ToString();
				objPagePhotoList.Add(objPagePhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objPagePhotoList;
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

	public CoreWebList<PagePhotoClass> fn_getPagePhotoByPageID(int iPageID)
	{
		CoreWebList<PagePhotoClass> objPagePhotoList = null;
		PagePhotoClass objPagePhoto = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_PagePhotos WHERE PagePhoto_PageID=@PagePhoto_PageID", objConnection);
			objCommand.Parameters.AddWithValue("@PagePhoto_PageID", iPageID);
			objReader = objCommand.ExecuteReader();
			objPagePhotoList = new CoreWebList<PagePhotoClass>();
			while (objReader.Read())
			{
				objPagePhoto = new PagePhotoClass();
				objPagePhoto.iID = int.Parse(objReader["PagePhoto_ID"].ToString());
				objPagePhoto.iPageID = int.Parse(objReader["PagePhoto_PageID"].ToString());
				objPagePhoto.strTitle = objReader["PagePhoto_Title"].ToString();
				objPagePhoto.strPhoto = objReader["PagePhoto_Photo"].ToString();
				objPagePhotoList.Add(objPagePhoto);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objPagePhotoList;
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
