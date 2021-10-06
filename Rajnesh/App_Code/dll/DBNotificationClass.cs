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
/// Summary description for DBNotificationClass
/// </summary>
public class DBNotificationClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

	public string fn_saveNotification(NotificationClass objNotification)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO edu_Notifications (Notification_UniversityID, Notification_Title, Notification_Desc, Notification_Url) VALUES (@Notification_UniversityID, @Notification_Title, @Notification_Desc, @Notification_Url)", objConnection);
			objCommand.Parameters.AddWithValue("@Notification_UniversityID", objNotification.iUniversityID);
			objCommand.Parameters.AddWithValue("@Notification_Title", objNotification.strNotificationTitle);
			objCommand.Parameters.AddWithValue("@Notification_Desc", objNotification.strNotificationDesc);
            objCommand.Parameters.AddWithValue("@Notification_Url", objNotification.strUrl);

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

	public string fn_editNotification(NotificationClass objNotification)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("UPDATE edu_Notifications SET Notification_UniversityID=@Notification_UniversityID, Notification_Title=@Notification_Title, Notification_Desc=@Notification_Desc, Notification_Url=@Notification_Url WHERE Notification_ID=@Notification_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Notification_ID", objNotification.iID);
			objCommand.Parameters.AddWithValue("@Notification_UniversityID", objNotification.iUniversityID);
			objCommand.Parameters.AddWithValue("@Notification_Title", objNotification.strNotificationTitle);
			objCommand.Parameters.AddWithValue("@Notification_Desc", objNotification.strNotificationDesc);
            objCommand.Parameters.AddWithValue("@Notification_Url", objNotification.strUrl);

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
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM edu_Notifications WHERE Notification_ID=@Notification_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Notification_ID", iNotificationID);

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

	public CoreWebList<NotificationClass> fn_getNotificationList()
	{
		CoreWebList<NotificationClass> objNotificationList = null;
		NotificationClass objNotification = null;
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM edu_Notifications", objConnection);
			objReader = objCommand.ExecuteReader();
			objNotificationList = new CoreWebList<NotificationClass>();
			while (objReader.Read())
			{
				objNotification = new NotificationClass();
				objNotification.iID = int.Parse(objReader["Notification_ID"].ToString());
				objNotification.iUniversityID = int.Parse(objReader["Notification_UniversityID"].ToString());
				objNotification.strNotificationTitle = objReader["Notification_Title"].ToString();
				objNotification.strNotificationDesc = objReader["Notification_Desc"].ToString();
                objNotification.strUrl = objReader["Notification_Url"].ToString();
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

	public CoreWebList<NotificationClass> fn_getNotificationByID(int iNotificationID)
	{
		CoreWebList<NotificationClass> objNotificationList = null;
		NotificationClass objNotification = null;
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=Notification_UniversityID) StudyCenter_UniversityName, * FROM edu_Notifications WHERE Notification_ID=@Notification_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Notification_ID", iNotificationID);
			objReader = objCommand.ExecuteReader();
			objNotificationList = new CoreWebList<NotificationClass>();
			if (objReader.Read())
			{
				objNotification = new NotificationClass();
				objNotification.iID = int.Parse(objReader["Notification_ID"].ToString());
				objNotification.iUniversityID = int.Parse(objReader["Notification_UniversityID"].ToString());
                objNotification.strUniversityName = objReader["StudyCenter_UniversityName"].ToString();
				objNotification.strNotificationTitle = objReader["Notification_Title"].ToString();
				objNotification.strNotificationDesc = objReader["Notification_Desc"].ToString();
                objNotification.strUrl = objReader["Notification_Url"].ToString();
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

    public CoreWebList<NotificationClass> fn_getNotificationByName(string strNotificationTitle)
    {
        CoreWebList<NotificationClass> objNotificationList = null;
        NotificationClass objNotification = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=Notification_UniversityID) StudyCenter_UniversityName, * FROM edu_Notifications WHERE Notification_Title=@Notification_Title", objConnection);
            objCommand.Parameters.AddWithValue("@Notification_Title", strNotificationTitle);
            objReader = objCommand.ExecuteReader();
            objNotificationList = new CoreWebList<NotificationClass>();
            if (objReader.Read())
            {
                objNotification = new NotificationClass();
                objNotification.iID = int.Parse(objReader["Notification_ID"].ToString());
                objNotification.iUniversityID = int.Parse(objReader["Notification_UniversityID"].ToString());
                objNotification.strUniversityName = objReader["StudyCenter_UniversityName"].ToString();
                objNotification.strNotificationTitle = objReader["Notification_Title"].ToString();
                objNotification.strNotificationDesc = objReader["Notification_Desc"].ToString();
                objNotification.strUrl = objReader["Notification_Url"].ToString();
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

    public CoreWebList<NotificationClass> fn_getNotificationByUniversityID(int iUniversityID)
    {
        CoreWebList<NotificationClass> objNotificationList = null;
        NotificationClass objNotification = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=Notification_UniversityID) StudyCenter_UniversityName, * FROM edu_Notifications WHERE Notification_UniversityID=@Notification_UniversityID", objConnection);
            objCommand.Parameters.AddWithValue("@Notification_UniversityID", iUniversityID);
            objReader = objCommand.ExecuteReader();
            objNotificationList = new CoreWebList<NotificationClass>();
            while (objReader.Read())
            {
                objNotification = new NotificationClass();
                objNotification.iID = int.Parse(objReader["Notification_ID"].ToString());
                objNotification.iUniversityID = int.Parse(objReader["Notification_UniversityID"].ToString());
                objNotification.strUniversityName = objReader["StudyCenter_UniversityName"].ToString();
                objNotification.strNotificationTitle = objReader["Notification_Title"].ToString();
                objNotification.strNotificationDesc = objReader["Notification_Desc"].ToString();
                objNotification.strUrl = objReader["Notification_Url"].ToString();
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

    public CoreWebList<NotificationClass> fn_getNotificationByKeys(string strNotification)
    {
        CoreWebList<NotificationClass> objNotificationList = null;
        NotificationClass objNotification = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM edu_Notifications WHERE Notification_Title like '%' + @Notification_Title + '%'", objConnection);
            objCommand.Parameters.AddWithValue("@Notification_Title", strNotification);
            objReader = objCommand.ExecuteReader();
            objNotificationList = new CoreWebList<NotificationClass>();
            while (objReader.Read())
            {
                objNotification = new NotificationClass();
                objNotification.iID = int.Parse(objReader["Notification_ID"].ToString());
                objNotification.iUniversityID = int.Parse(objReader["Notification_UniversityID"].ToString());
                objNotification.strNotificationTitle = objReader["Notification_Title"].ToString();
                objNotification.strNotificationDesc = objReader["Notification_Desc"].ToString();
                objNotification.strUrl = objReader["Notification_Url"].ToString();
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
