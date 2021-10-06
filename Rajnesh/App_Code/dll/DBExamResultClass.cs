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
/// Summary description for DBExamResultClass
/// </summary>
public class DBExamResultClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

	public string fn_saveExamResult(ExamResultClass objExamResult)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO edu_ExamResults (ExamResult_CourseID, ExamResult_Title, ExamResult_Desc) VALUES (@ExamResult_CourseID, @ExamResult_Title, @ExamResult_Desc)",objConnection) ;
			objCommand.Parameters.AddWithValue("@ExamResult_CourseID", objExamResult.iCourseID);
			objCommand.Parameters.AddWithValue("@ExamResult_Title", objExamResult.strExamResultTitle);
			objCommand.Parameters.AddWithValue("@ExamResult_Desc", objExamResult.strExamResultDesc);

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

	public string fn_editExamResult(ExamResultClass objExamResult)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE edu_ExamResults SET ExamResult_CourseID=@ExamResult_CourseID, ExamResult_Title=@ExamResult_Title, ExamResult_Desc=@ExamResult_Desc WHERE ExamResult_ID=@ExamResult_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@ExamResult_ID", objExamResult.iID);
			objCommand.Parameters.AddWithValue("@ExamResult_CourseID", objExamResult.iCourseID);
			objCommand.Parameters.AddWithValue("@ExamResult_Title", objExamResult.strExamResultTitle);
			objCommand.Parameters.AddWithValue("@ExamResult_Desc", objExamResult.strExamResultDesc);

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

	public string fn_deleteExamResult(int iExamResultID)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM edu_ExamResults WHERE ExamResult_ID=@ExamResult_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@ExamResult_ID", iExamResultID);

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

	public CoreWebList<ExamResultClass> fn_getExamResultList()
	{
		CoreWebList<ExamResultClass> objExamResultList = null;
		ExamResultClass objExamResult = null;
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM edu_ExamResults", objConnection);
			objReader = objCommand.ExecuteReader();
			objExamResultList = new CoreWebList<ExamResultClass>();
			while (objReader.Read())
			{
				objExamResult = new ExamResultClass();
				objExamResult.iID = int.Parse(objReader["ExamResult_ID"].ToString());
				objExamResult.iCourseID = int.Parse(objReader["ExamResult_CourseID"].ToString());
				objExamResult.strExamResultTitle = objReader["ExamResult_Title"].ToString();
				objExamResult.strExamResultDesc = objReader["ExamResult_Desc"].ToString();
				objExamResultList.Add(objExamResult);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objExamResultList;
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

	public CoreWebList<ExamResultClass> fn_getExamResultByID(int iExamResultID)
	{
		CoreWebList<ExamResultClass> objExamResultList = null;
		ExamResultClass objExamResult = null;
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM edu_ExamResults WHERE ExamResult_ID=@ExamResult_ID", objConnection);
			objCommand.Parameters.AddWithValue("@ExamResult_ID", iExamResultID);
			objReader = objCommand.ExecuteReader();
			objExamResultList = new CoreWebList<ExamResultClass>();
			if (objReader.Read())
			{
				objExamResult = new ExamResultClass();
				objExamResult.iID = int.Parse(objReader["ExamResult_ID"].ToString());
				objExamResult.iCourseID = int.Parse(objReader["ExamResult_CourseID"].ToString());
				objExamResult.strExamResultTitle = objReader["ExamResult_Title"].ToString();
				objExamResult.strExamResultDesc = objReader["ExamResult_Desc"].ToString();
				objExamResultList.Add(objExamResult);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objExamResultList;
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

    public CoreWebList<ExamResultClass> fn_getExamResultByCourseID(int iCourseID)
    {
        CoreWebList<ExamResultClass> objExamResultList = null;
        ExamResultClass objExamResult = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT DLCourses_Name FROM edu_DLCourses WHERE DLCourses_ID=ExamResult_CourseID)ExamResult_CourseName, * FROM edu_ExamResults WHERE ExamResult_CourseID=@ExamResult_CourseID", objConnection);
            objCommand.Parameters.AddWithValue("@ExamResult_CourseID", iCourseID);
            objReader = objCommand.ExecuteReader();
            objExamResultList = new CoreWebList<ExamResultClass>();
            while (objReader.Read())
            {
                objExamResult = new ExamResultClass();
                objExamResult.iID = int.Parse(objReader["ExamResult_ID"].ToString());
                objExamResult.iCourseID = int.Parse(objReader["ExamResult_CourseID"].ToString());
                objExamResult.strCourseName = objReader["ExamResult_CourseName"].ToString();
                objExamResult.strExamResultTitle = objReader["ExamResult_Title"].ToString();
                objExamResult.strExamResultDesc = objReader["ExamResult_Desc"].ToString();
                objExamResultList.Add(objExamResult);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objExamResultList;
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

    public CoreWebList<ExamResultClass> fn_getExamResultByName(string strName)
    {
        CoreWebList<ExamResultClass> objExamResultList = null;
        ExamResultClass objExamResult = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT DLCourses_Name FROM edu_DLCourses WHERE DLCourses_ID=ExamResult_CourseID)ExamResult_CourseName, * FROM edu_ExamResults WHERE ExamResult_Title=@ExamResult_Title", objConnection);
            objCommand.Parameters.AddWithValue("@ExamResult_Title", strName);
            objReader = objCommand.ExecuteReader();
            objExamResultList = new CoreWebList<ExamResultClass>();
            while (objReader.Read())
            {
                objExamResult = new ExamResultClass();
                objExamResult.iID = int.Parse(objReader["ExamResult_ID"].ToString());
                objExamResult.iCourseID = int.Parse(objReader["ExamResult_CourseID"].ToString());
                objExamResult.strCourseName = objReader["ExamResult_CourseName"].ToString();
                objExamResult.strExamResultTitle = objReader["ExamResult_Title"].ToString();
                objExamResult.strExamResultDesc = objReader["ExamResult_Desc"].ToString();
                objExamResultList.Add(objExamResult);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objExamResultList;
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

    public CoreWebList<ExamResultClass> fn_getExamResultByKeys(string strKeys)
    {
        CoreWebList<ExamResultClass> objExamResultList = null;
        ExamResultClass objExamResult = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM edu_ExamResults WHERE ExamResult_Title like '%' + @ExamResult_Title + '%'", objConnection);
            objCommand.Parameters.AddWithValue("@ExamResult_Title", strKeys);
            objReader = objCommand.ExecuteReader();
            objExamResultList = new CoreWebList<ExamResultClass>();
            while (objReader.Read())
            {
                objExamResult = new ExamResultClass();
                objExamResult.iID = int.Parse(objReader["ExamResult_ID"].ToString());
                objExamResult.iCourseID = int.Parse(objReader["ExamResult_CourseID"].ToString());
                objExamResult.strExamResultTitle = objReader["ExamResult_Title"].ToString();
                objExamResult.strExamResultDesc = objReader["ExamResult_Desc"].ToString();
                objExamResultList.Add(objExamResult);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objExamResultList;
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
