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
/// Summary description for DBExamClass
/// </summary>
public class DBExamClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

	public string fn_saveExam(ExamClass objExam)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO edu_Exams (Exam_UniversityID, Exam_Title, Exam_Desc) VALUES (@Exam_UniversityID, @Exam_Title, @Exam_Desc)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Exam_UniversityID", objExam.iUniversityID);
			objCommand.Parameters.AddWithValue("@Exam_Title", objExam.strExamTitle);
			objCommand.Parameters.AddWithValue("@Exam_Desc", objExam.strExamDesc);

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

	public string fn_editExam(ExamClass objExam)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE edu_Exams SET Exam_UniversityID=@Exam_UniversityID, Exam_Title=@Exam_Title, Exam_Desc=@Exam_Desc WHERE Exam_ID=@Exam_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Exam_ID", objExam.iID);
			objCommand.Parameters.AddWithValue("@Exam_UniversityID", objExam.iUniversityID);
			objCommand.Parameters.AddWithValue("@Exam_Title", objExam.strExamTitle);
			objCommand.Parameters.AddWithValue("@Exam_Desc", objExam.strExamDesc);

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

	public string fn_deleteExam(int iExamID)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM edu_Exams WHERE Exam_ID=@Exam_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Exam_ID", iExamID);

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

	public CoreWebList<ExamClass> fn_getExamList()
	{
		CoreWebList<ExamClass> objExamList = null;
		ExamClass objExam = null;
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM edu_Exams", objConnection);
			objReader = objCommand.ExecuteReader();
			objExamList = new CoreWebList<ExamClass>();
			while (objReader.Read())
			{
				objExam = new ExamClass();
				objExam.iID = int.Parse(objReader["Exam_ID"].ToString());
				objExam.iUniversityID = int.Parse(objReader["Exam_UniversityID"].ToString());
				objExam.strExamTitle = objReader["Exam_Title"].ToString();
				objExam.strExamDesc = objReader["Exam_Desc"].ToString();
				objExamList.Add(objExam);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objExamList;
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

	public CoreWebList<ExamClass> fn_getExamByID(int iExamID)
	{
		CoreWebList<ExamClass> objExamList = null;
		ExamClass objExam = null;
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=Exam_UniversityID) StudyCenter_UniversityName, * FROM edu_Exams WHERE Exam_ID=@Exam_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Exam_ID", iExamID);
			objReader = objCommand.ExecuteReader();
			objExamList = new CoreWebList<ExamClass>();
			if (objReader.Read())
			{
				objExam = new ExamClass();
				objExam.iID = int.Parse(objReader["Exam_ID"].ToString());
				objExam.iUniversityID = int.Parse(objReader["Exam_UniversityID"].ToString());
                objExam.strUniversityName = objReader["StudyCenter_UniversityName"].ToString();
				objExam.strExamTitle = objReader["Exam_Title"].ToString();
				objExam.strExamDesc = objReader["Exam_Desc"].ToString();
				objExamList.Add(objExam);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objExamList;
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

    public CoreWebList<ExamClass> fn_getExamByTitle(string strTitle)
    {
        CoreWebList<ExamClass> objExamList = null;
        ExamClass objExam = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=Exam_UniversityID) StudyCenter_UniversityName, * FROM edu_Exams WHERE Exam_Title=@Exam_Title", objConnection);
            objCommand.Parameters.AddWithValue("@Exam_Title", strTitle);
            objReader = objCommand.ExecuteReader();
            objExamList = new CoreWebList<ExamClass>();
            if (objReader.Read())
            {
                objExam = new ExamClass();
                objExam.iID = int.Parse(objReader["Exam_ID"].ToString());
                objExam.iUniversityID = int.Parse(objReader["Exam_UniversityID"].ToString());
                objExam.strUniversityName = objReader["StudyCenter_UniversityName"].ToString();
                objExam.strExamTitle = objReader["Exam_Title"].ToString();
                objExam.strExamDesc = objReader["Exam_Desc"].ToString();
                objExamList.Add(objExam);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objExamList;
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

    public CoreWebList<ExamClass> fn_getExamByUniversityID(int iUniversityID)
    {
        CoreWebList<ExamClass> objExamList = null;
        ExamClass objExam = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=Exam_UniversityID) StudyCenter_UniversityName, * FROM edu_Exams WHERE Exam_UniversityID=@Exam_UniversityID", objConnection);
            objCommand.Parameters.AddWithValue("@Exam_UniversityID", iUniversityID);
            objReader = objCommand.ExecuteReader();
            objExamList = new CoreWebList<ExamClass>();
            while (objReader.Read())
            {
                objExam = new ExamClass();
                objExam.iID = int.Parse(objReader["Exam_ID"].ToString());
                objExam.iUniversityID = int.Parse(objReader["Exam_UniversityID"].ToString());
                objExam.strUniversityName = objReader["StudyCenter_UniversityName"].ToString();
                objExam.strExamTitle = objReader["Exam_Title"].ToString();
                objExam.strExamDesc = objReader["Exam_Desc"].ToString();
                objExamList.Add(objExam);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objExamList;
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

    public CoreWebList<ExamClass> fn_getExamByKeys(string strKeys)
    {
        CoreWebList<ExamClass> objExamList = null;
        ExamClass objExam = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM edu_Exams WHERE Exam_Title like '%' + @Exam_Title + '%'", objConnection);
            objCommand.Parameters.AddWithValue("@Exam_Title", strKeys);
            objReader = objCommand.ExecuteReader();
            objExamList = new CoreWebList<ExamClass>();
            while (objReader.Read())
            {
                objExam = new ExamClass();
                objExam.iID = int.Parse(objReader["Exam_ID"].ToString());
                objExam.iUniversityID = int.Parse(objReader["Exam_UniversityID"].ToString());
                objExam.strExamTitle = objReader["Exam_Title"].ToString();
                objExam.strExamDesc = objReader["Exam_Desc"].ToString();
                objExamList.Add(objExam);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objExamList;
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
