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
/// Summary description for DBEntranceExamClass
/// </summary>
public class DBEntranceExamClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveEntranceExam(EntranceExamClass objEntranceExam)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_EntranceExams (EntranceExam_CategoryID, EntranceExam_Title, EntranceExam_Desc, EntranceExam_Admissions, EntranceExam_Dates, EntranceExam_Syllabus, EntranceExam_PaperPatterns, EntranceExam_Preparation, EntranceExam_Notifications) VALUES (@EntranceExam_CategoryID, @EntranceExam_Title, @EntranceExam_Desc, @EntranceExam_Admissions, @EntranceExam_Dates, @EntranceExam_Syllabus, @EntranceExam_PaperPatterns, @EntranceExam_Preparation, @EntranceExam_Notifications)", objConnection);
			objCommand.Parameters.AddWithValue("@EntranceExam_CategoryID", objEntranceExam.iCategoryID);
			objCommand.Parameters.AddWithValue("@EntranceExam_Title", objEntranceExam.strTitle);
			objCommand.Parameters.AddWithValue("@EntranceExam_Desc", objEntranceExam.strDesc);
			objCommand.Parameters.AddWithValue("@EntranceExam_Admissions", objEntranceExam.strAdmissions);
			objCommand.Parameters.AddWithValue("@EntranceExam_Dates", objEntranceExam.strDates);
			objCommand.Parameters.AddWithValue("@EntranceExam_Syllabus", objEntranceExam.strSyllabus);
			objCommand.Parameters.AddWithValue("@EntranceExam_PaperPatterns", objEntranceExam.strPaperPatterns);
			objCommand.Parameters.AddWithValue("@EntranceExam_Preparation", objEntranceExam.strPreparation);
            objCommand.Parameters.AddWithValue("@EntranceExam_Notifications", objEntranceExam.strNotifications);

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

	public string fn_editEntranceExam(EntranceExamClass objEntranceExam)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_EntranceExams SET EntranceExam_CategoryID=@EntranceExam_CategoryID, EntranceExam_Title=@EntranceExam_Title, EntranceExam_Desc=@EntranceExam_Desc, EntranceExam_Admissions=@EntranceExam_Admissions, EntranceExam_Dates=@EntranceExam_Dates, EntranceExam_Syllabus=@EntranceExam_Syllabus, EntranceExam_PaperPatterns=@EntranceExam_PaperPatterns, EntranceExam_Preparation=@EntranceExam_Preparation, EntranceExam_Notifications=@EntranceExam_Notifications WHERE EntranceExam_ID=@EntranceExam_ID", objConnection);
			objCommand.Parameters.AddWithValue("@EntranceExam_ID", objEntranceExam.iID);
			objCommand.Parameters.AddWithValue("@EntranceExam_CategoryID", objEntranceExam.iCategoryID);
			objCommand.Parameters.AddWithValue("@EntranceExam_Title", objEntranceExam.strTitle);
			objCommand.Parameters.AddWithValue("@EntranceExam_Desc", objEntranceExam.strDesc);
			objCommand.Parameters.AddWithValue("@EntranceExam_Admissions", objEntranceExam.strAdmissions);
			objCommand.Parameters.AddWithValue("@EntranceExam_Dates", objEntranceExam.strDates);
			objCommand.Parameters.AddWithValue("@EntranceExam_Syllabus", objEntranceExam.strSyllabus);
			objCommand.Parameters.AddWithValue("@EntranceExam_PaperPatterns", objEntranceExam.strPaperPatterns);
			objCommand.Parameters.AddWithValue("@EntranceExam_Preparation", objEntranceExam.strPreparation);
            objCommand.Parameters.AddWithValue("@EntranceExam_Notifications", objEntranceExam.strNotifications);

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

	public string fn_deleteEntranceExam(int iEntranceExamID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_EntranceExams WHERE EntranceExam_ID=@EntranceExam_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@EntranceExam_ID", iEntranceExamID);

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

	public CoreWebList<EntranceExamClass> fn_getEntranceExamList()
	{
		CoreWebList<EntranceExamClass> objEntranceExamList = null;
		EntranceExamClass objEntranceExam = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_EntranceExams ORDER BY EntranceExam_Title ASC", objConnection);
			objReader = objCommand.ExecuteReader();
			objEntranceExamList = new CoreWebList<EntranceExamClass>();
			while (objReader.Read())
			{
				objEntranceExam = new EntranceExamClass();
				objEntranceExam.iID = int.Parse(objReader["EntranceExam_ID"].ToString());
				objEntranceExam.iCategoryID = int.Parse(objReader["EntranceExam_CategoryID"].ToString());
				objEntranceExam.strTitle = objReader["EntranceExam_Title"].ToString();
				objEntranceExam.strDesc = objReader["EntranceExam_Desc"].ToString();
				objEntranceExam.strAdmissions = objReader["EntranceExam_Admissions"].ToString();
				objEntranceExam.strDates = objReader["EntranceExam_Dates"].ToString();
				objEntranceExam.strSyllabus = objReader["EntranceExam_Syllabus"].ToString();
				objEntranceExam.strPaperPatterns = objReader["EntranceExam_PaperPatterns"].ToString();
				objEntranceExam.strPreparation = objReader["EntranceExam_Preparation"].ToString();
                objEntranceExam.strNotifications = objReader["EntranceExam_Notifications"].ToString();
				objEntranceExamList.Add(objEntranceExam);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEntranceExamList;
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

	public CoreWebList<EntranceExamClass> fn_getEntranceExamByID(int iEntranceExamID)
	{
		CoreWebList<EntranceExamClass> objEntranceExamList = null;
		EntranceExamClass objEntranceExam = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EntranceExams WHERE EntranceExam_ID=@EntranceExam_ID", objConnection);
			objCommand.Parameters.AddWithValue("@EntranceExam_ID", iEntranceExamID);
			objReader = objCommand.ExecuteReader();
			objEntranceExamList = new CoreWebList<EntranceExamClass>();
			if (objReader.Read())
			{
				objEntranceExam = new EntranceExamClass();
				objEntranceExam.iID = int.Parse(objReader["EntranceExam_ID"].ToString());
				objEntranceExam.iCategoryID = int.Parse(objReader["EntranceExam_CategoryID"].ToString());
				objEntranceExam.strTitle = objReader["EntranceExam_Title"].ToString();
				objEntranceExam.strDesc = objReader["EntranceExam_Desc"].ToString();
				objEntranceExam.strAdmissions = objReader["EntranceExam_Admissions"].ToString();
				objEntranceExam.strDates = objReader["EntranceExam_Dates"].ToString();
				objEntranceExam.strSyllabus = objReader["EntranceExam_Syllabus"].ToString();
				objEntranceExam.strPaperPatterns = objReader["EntranceExam_PaperPatterns"].ToString();
				objEntranceExam.strPreparation = objReader["EntranceExam_Preparation"].ToString();
                objEntranceExam.strNotifications = objReader["EntranceExam_Notifications"].ToString();
				objEntranceExamList.Add(objEntranceExam);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEntranceExamList;
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

	public CoreWebList<EntranceExamClass> fn_getEntranceExamByName(string strEntranceExamTitle)
	{
		CoreWebList<EntranceExamClass> objEntranceExamList = null;
		EntranceExamClass objEntranceExam = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EntranceExams WHERE EntranceExam_Title=@EntranceExam_Title", objConnection);
			objCommand.Parameters.AddWithValue("@EntranceExam_Title", strEntranceExamTitle);
			objReader = objCommand.ExecuteReader();
			objEntranceExamList = new CoreWebList<EntranceExamClass>();
			if (objReader.Read())
			{
				objEntranceExam = new EntranceExamClass();
				objEntranceExam.iID = int.Parse(objReader["EntranceExam_ID"].ToString());
				objEntranceExam.iCategoryID = int.Parse(objReader["EntranceExam_CategoryID"].ToString());
				objEntranceExam.strTitle = objReader["EntranceExam_Title"].ToString();
				objEntranceExam.strDesc = objReader["EntranceExam_Desc"].ToString();
				objEntranceExam.strAdmissions = objReader["EntranceExam_Admissions"].ToString();
				objEntranceExam.strDates = objReader["EntranceExam_Dates"].ToString();
				objEntranceExam.strSyllabus = objReader["EntranceExam_Syllabus"].ToString();
				objEntranceExam.strPaperPatterns = objReader["EntranceExam_PaperPatterns"].ToString();
				objEntranceExam.strPreparation = objReader["EntranceExam_Preparation"].ToString();
                objEntranceExam.strNotifications = objReader["EntranceExam_Notifications"].ToString();
				objEntranceExamList.Add(objEntranceExam);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEntranceExamList;
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

	public CoreWebList<EntranceExamClass> fn_getEntranceExamByKeys(string strEntranceExamTitle)
	{
		CoreWebList<EntranceExamClass> objEntranceExamList = null;
		EntranceExamClass objEntranceExam = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EntranceExams WHERE EntranceExam_Title like '%' + @EntranceExam_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@EntranceExam_Title", strEntranceExamTitle);
			objReader = objCommand.ExecuteReader();
			objEntranceExamList = new CoreWebList<EntranceExamClass>();
			while (objReader.Read())
			{
				objEntranceExam = new EntranceExamClass();
				objEntranceExam.iID = int.Parse(objReader["EntranceExam_ID"].ToString());
				objEntranceExam.iCategoryID = int.Parse(objReader["EntranceExam_CategoryID"].ToString());
				objEntranceExam.strTitle = objReader["EntranceExam_Title"].ToString();
				objEntranceExam.strDesc = objReader["EntranceExam_Desc"].ToString();
				objEntranceExam.strAdmissions = objReader["EntranceExam_Admissions"].ToString();
				objEntranceExam.strDates = objReader["EntranceExam_Dates"].ToString();
				objEntranceExam.strSyllabus = objReader["EntranceExam_Syllabus"].ToString();
				objEntranceExam.strPaperPatterns = objReader["EntranceExam_PaperPatterns"].ToString();
				objEntranceExam.strPreparation = objReader["EntranceExam_Preparation"].ToString();
                objEntranceExam.strNotifications = objReader["EntranceExam_Notifications"].ToString();
				objEntranceExamList.Add(objEntranceExam);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEntranceExamList;
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

	public CoreWebList<EntranceExamClass> fn_getEntranceExamByCategoryID(int iCategoryID)
	{
		CoreWebList<EntranceExamClass> objEntranceExamList = null;
		EntranceExamClass objEntranceExam = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EntranceExams WHERE EntranceExam_CategoryID=@EntranceExam_CategoryID", objConnection);
			objCommand.Parameters.AddWithValue("@EntranceExam_CategoryID", iCategoryID);
			objReader = objCommand.ExecuteReader();
			objEntranceExamList = new CoreWebList<EntranceExamClass>();
			while (objReader.Read())
			{
				objEntranceExam = new EntranceExamClass();
				objEntranceExam.iID = int.Parse(objReader["EntranceExam_ID"].ToString());
				objEntranceExam.iCategoryID = int.Parse(objReader["EntranceExam_CategoryID"].ToString());
				objEntranceExam.strTitle = objReader["EntranceExam_Title"].ToString();
				objEntranceExam.strDesc = objReader["EntranceExam_Desc"].ToString();
				objEntranceExam.strAdmissions = objReader["EntranceExam_Admissions"].ToString();
				objEntranceExam.strDates = objReader["EntranceExam_Dates"].ToString();
				objEntranceExam.strSyllabus = objReader["EntranceExam_Syllabus"].ToString();
				objEntranceExam.strPaperPatterns = objReader["EntranceExam_PaperPatterns"].ToString();
				objEntranceExam.strPreparation = objReader["EntranceExam_Preparation"].ToString();
                objEntranceExam.strNotifications = objReader["EntranceExam_Notifications"].ToString();
				objEntranceExamList.Add(objEntranceExam);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEntranceExamList;
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

    public CoreWebList<EntranceExamClass> fn_getRandomEntranceExamByCategoryID(int iCategoryID)
    {
        CoreWebList<EntranceExamClass> objEntranceExamList = null;
        EntranceExamClass objEntranceExam = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 5 * FROM tbl_EntranceExams WHERE EntranceExam_CategoryID=@EntranceExam_CategoryID ORDER BY NEWID()", objConnection);
            objCommand.Parameters.AddWithValue("@EntranceExam_CategoryID", iCategoryID);
            objReader = objCommand.ExecuteReader();
            objEntranceExamList = new CoreWebList<EntranceExamClass>();
            while (objReader.Read())
            {
                objEntranceExam = new EntranceExamClass();
                objEntranceExam.iID = int.Parse(objReader["EntranceExam_ID"].ToString());
                objEntranceExam.iCategoryID = int.Parse(objReader["EntranceExam_CategoryID"].ToString());
                objEntranceExam.strTitle = objReader["EntranceExam_Title"].ToString();
                objEntranceExam.strDesc = objReader["EntranceExam_Desc"].ToString();
                objEntranceExam.strAdmissions = objReader["EntranceExam_Admissions"].ToString();
                objEntranceExam.strDates = objReader["EntranceExam_Dates"].ToString();
                objEntranceExam.strSyllabus = objReader["EntranceExam_Syllabus"].ToString();
                objEntranceExam.strPaperPatterns = objReader["EntranceExam_PaperPatterns"].ToString();
                objEntranceExam.strPreparation = objReader["EntranceExam_Preparation"].ToString();
                objEntranceExam.strNotifications = objReader["EntranceExam_Notifications"].ToString();
                objEntranceExamList.Add(objEntranceExam);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objEntranceExamList;
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
