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
/// Summary description for DBNoticClass
/// </summary>
public class DBNoticClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveNotification(NoticClass objNotification)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO edu_UniversityNotifications (UniversityNotification_UniversityID, UniversityNotification_Title, UniversityNotification_Url, UniversityNotification_Desc) VALUES (@UniversityNotification_UniversityID, @UniversityNotification_Title, @UniversityNotification_Url, @UniversityNotification_Desc)", objConnection);

            objCommand.Parameters.AddWithValue("@UniversityNotification_UniversityID", objNotification.iUniversityID);
            objCommand.Parameters.AddWithValue("@UniversityNotification_Title", objNotification.strTitle);
            objCommand.Parameters.AddWithValue("@UniversityNotification_Url", objNotification.strUrl);
            objCommand.Parameters.AddWithValue("@UniversityNotification_Desc", objNotification.strDesc);

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

	public string fn_editNotification(NoticClass objNotification)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("UPDATE edu_UniversityNotifications SET UniversityNotification_Title=@UniversityNotification_Title, UniversityNotification_Url=@UniversityNotification_Url, UniversityNotification_Desc=@UniversityNotification_Desc WHERE UniversityNotification_ID=@UniversityNotification_ID", objConnection);

            objCommand.Parameters.AddWithValue("@UniversityNotification_ID", objNotification.iID);
            objCommand.Parameters.AddWithValue("@UniversityNotification_Title", objNotification.strTitle);
            objCommand.Parameters.AddWithValue("@UniversityNotification_Url", objNotification.strUrl);
            objCommand.Parameters.AddWithValue("@UniversityNotification_Desc", objNotification.strDesc);

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

	public string fn_deleteNotification(int iNotificationID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM edu_UniversityNotifications WHERE UniversityNotification_ID=@UniversityNotification_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@UniversityNotification_ID", iNotificationID);

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

	public CoreWebList<NoticClass> fn_getNotificationList()
	{
		CoreWebList<NoticClass> objNotificationList = null;
		NoticClass objNotification = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM edu_UniversityNotifications", objConnection);
			objReader = objCommand.ExecuteReader();
			objNotificationList = new CoreWebList<NoticClass>();
			while (objReader.Read())
			{
				objNotification = new NoticClass();
				objNotification.iID = int.Parse(objReader["UniversityNotification_ID"].ToString());
				objNotification.iUniversityID = int.Parse(objReader["UniversityNotification_UniversityID"].ToString());
				objNotification.strTitle = objReader["UniversityNotification_Title"].ToString();
                objNotification.strUrl = objReader["UniversityNotification_Url"].ToString();
				objNotification.strDesc = objReader["UniversityNotification_Desc"].ToString();
				objNotificationList.Add(objNotification);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objNotificationList;
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

	public CoreWebList<NoticClass> fn_getNotificationByID(int iNotificationID)
	{
		CoreWebList<NoticClass> objNotificationList = null;
		NoticClass objNotification = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM edu_UniversityNotifications WHERE UniversityNotification_ID=@UniversityNotification_ID", objConnection);
			objCommand.Parameters.AddWithValue("@UniversityNotification_ID", iNotificationID);
			objReader = objCommand.ExecuteReader();
			objNotificationList = new CoreWebList<NoticClass>();
			if (objReader.Read())
			{
                objNotification = new NoticClass();
                objNotification.iID = int.Parse(objReader["UniversityNotification_ID"].ToString());
                objNotification.iUniversityID = int.Parse(objReader["UniversityNotification_UniversityID"].ToString());
                objNotification.strTitle = objReader["UniversityNotification_Title"].ToString();
                objNotification.strUrl = objReader["UniversityNotification_Url"].ToString();
                objNotification.strDesc = objReader["UniversityNotification_Desc"].ToString();
                objNotificationList.Add(objNotification);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objNotificationList;
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

	public CoreWebList<NoticClass> fn_getNotificationByName(string strNotificationTitle)
	{
		CoreWebList<NoticClass> objNotificationList = null;
		NoticClass objNotification = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM edu_UniversityNotifications WHERE UniversityNotification_Title=@UniversityNotification_Title", objConnection);
			objCommand.Parameters.AddWithValue("@UniversityNotification_Title", strNotificationTitle);
			objReader = objCommand.ExecuteReader();
			objNotificationList = new CoreWebList<NoticClass>();
			if (objReader.Read())
			{
                objNotification = new NoticClass();
                objNotification.iID = int.Parse(objReader["UniversityNotification_ID"].ToString());
                objNotification.iUniversityID = int.Parse(objReader["UniversityNotification_UniversityID"].ToString());
                objNotification.strTitle = objReader["UniversityNotification_Title"].ToString();
                objNotification.strUrl = objReader["UniversityNotification_Url"].ToString();
                objNotification.strDesc = objReader["UniversityNotification_Desc"].ToString();
                objNotificationList.Add(objNotification);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objNotificationList;
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

	public CoreWebList<NoticClass> fn_getNotificationByKeys(string strNotificationTitle)
	{
		CoreWebList<NoticClass> objNotificationList = null;
		NoticClass objNotification = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM edu_UniversityNotifications WHERE UniversityNotification_Title like '%' + @UniversityNotification_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@UniversityNotification_Title", strNotificationTitle);
			objReader = objCommand.ExecuteReader();
			objNotificationList = new CoreWebList<NoticClass>();
			while (objReader.Read())
			{
                objNotification = new NoticClass();
                objNotification.iID = int.Parse(objReader["UniversityNotification_ID"].ToString());
                objNotification.iUniversityID = int.Parse(objReader["UniversityNotification_UniversityID"].ToString());
                objNotification.strTitle = objReader["UniversityNotification_Title"].ToString();
                objNotification.strUrl = objReader["UniversityNotification_Url"].ToString();
                objNotification.strDesc = objReader["UniversityNotification_Desc"].ToString();
                objNotificationList.Add(objNotification);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objNotificationList;
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

	public CoreWebList<NoticClass> fn_getNotificationByUniversityID(int iUniversityID)
	{
		CoreWebList<NoticClass> objNotificationList = null;
		NoticClass objNotification = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM edu_UniversityNotifications WHERE UniversityNotification_UniversityID=@UniversityNotification_UniversityID", objConnection);
			objCommand.Parameters.AddWithValue("@UniversityNotification_UniversityID", iUniversityID);
			objReader = objCommand.ExecuteReader();
			objNotificationList = new CoreWebList<NoticClass>();
			while (objReader.Read())
			{
                objNotification = new NoticClass();
                objNotification.iID = int.Parse(objReader["UniversityNotification_ID"].ToString());
                objNotification.iUniversityID = int.Parse(objReader["UniversityNotification_UniversityID"].ToString());
                objNotification.strTitle = objReader["UniversityNotification_Title"].ToString();
                objNotification.strUrl = objReader["UniversityNotification_Url"].ToString();
                objNotification.strDesc = objReader["UniversityNotification_Desc"].ToString();
                objNotificationList.Add(objNotification);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objNotificationList;
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
