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
/// Summary description for DBInstituteExamClass
/// </summary>
public class DBInstituteExamClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveInstituteExam(InstituteExamClass objInstituteExam)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_InstituteExams (InstituteExam_InstituteID, InstituteExam_ExamID) VALUES (@InstituteExam_InstituteID, @InstituteExam_ExamID)",objConnection) ;
			objCommand.Parameters.AddWithValue("@InstituteExam_InstituteID", objInstituteExam.iInstituteID);
			objCommand.Parameters.AddWithValue("@InstituteExam_ExamID", objInstituteExam.iExamID);

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

	public string fn_editInstituteExam(InstituteExamClass objInstituteExam)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_InstituteExams SET InstituteExam_InstituteID=@InstituteExam_InstituteID, InstituteExam_ExamID=@InstituteExam_ExamID WHERE InstituteExam_ID=@InstituteExam_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@InstituteExam_ID", objInstituteExam.iID);
			objCommand.Parameters.AddWithValue("@InstituteExam_ExamID", objInstituteExam.iExamID);

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

	public string fn_deleteInstituteExam(int iInstituteExamID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_InstituteExams WHERE InstituteExam_ID=@InstituteExam_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@InstituteExam_ID", iInstituteExamID);

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

	public string fn_deleteInstituteExamByInstituteID(int iInstituteID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_InstituteExams WHERE InstituteExam_InstituteID=@InstituteExam_InstituteID",objConnection) ;
			objCommand.Parameters.AddWithValue("@InstituteExam_InstituteID", iInstituteID);

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

	public CoreWebList<InstituteExamClass> fn_getInstituteExamList()
	{
		CoreWebList<InstituteExamClass> objInstituteExamList = null;
		InstituteExamClass objInstituteExam = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteExams", objConnection);
			objReader = objCommand.ExecuteReader();
			objInstituteExamList = new CoreWebList<InstituteExamClass>();
			while (objReader.Read())
			{
				objInstituteExam = new InstituteExamClass();
				objInstituteExam.iID = int.Parse(objReader["InstituteExam_ID"].ToString());
				objInstituteExam.iInstituteID = int.Parse(objReader["InstituteExam_InstituteID"].ToString());
				objInstituteExam.iExamID = int.Parse(objReader["InstituteExam_ExamID"].ToString());
				objInstituteExamList.Add(objInstituteExam);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteExamList;
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

	public CoreWebList<InstituteExamClass> fn_getInstituteExamByID(int iInstituteExamID)
	{
		CoreWebList<InstituteExamClass> objInstituteExamList = null;
		InstituteExamClass objInstituteExam = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteExams WHERE InstituteExam_ID=@InstituteExam_ID", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteExam_ID", iInstituteExamID);
			objReader = objCommand.ExecuteReader();
			objInstituteExamList = new CoreWebList<InstituteExamClass>();
			if (objReader.Read())
			{
				objInstituteExam = new InstituteExamClass();
				objInstituteExam.iID = int.Parse(objReader["InstituteExam_ID"].ToString());
				objInstituteExam.iInstituteID = int.Parse(objReader["InstituteExam_InstituteID"].ToString());
				objInstituteExam.iExamID = int.Parse(objReader["InstituteExam_ExamID"].ToString());
				objInstituteExamList.Add(objInstituteExam);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteExamList;
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

	public CoreWebList<InstituteExamClass> fn_getInstituteExamByExamID(int iExamID)
	{
		CoreWebList<InstituteExamClass> objInstituteExamList = null;
		InstituteExamClass objInstituteExam = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteExams WHERE InstituteExam_ExamID=@InstituteExam_ExamID", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteExam_ExamID", iExamID);
			objReader = objCommand.ExecuteReader();
			objInstituteExamList = new CoreWebList<InstituteExamClass>();
			while (objReader.Read())
			{
				objInstituteExam = new InstituteExamClass();
				objInstituteExam.iID = int.Parse(objReader["InstituteExam_ID"].ToString());
				objInstituteExam.iInstituteID = int.Parse(objReader["InstituteExam_InstituteID"].ToString());
				objInstituteExam.iExamID = int.Parse(objReader["InstituteExam_ExamID"].ToString());
				objInstituteExamList.Add(objInstituteExam);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteExamList;
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

	public CoreWebList<InstituteExamClass> fn_getInstituteExamByInstituteID(int iInstituteID)
	{
		CoreWebList<InstituteExamClass> objInstituteExamList = null;
		InstituteExamClass objInstituteExam = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT Exam.EntranceExam_Title, * FROM tbl_InstituteExams InstExam join tbl_EntranceExams Exam on InstExam.InstituteExam_ExamID=Exam.EntranceExam_ID WHERE InstituteExam_InstituteID=@InstituteExam_InstituteID", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteExam_InstituteID", iInstituteID);
			objReader = objCommand.ExecuteReader();
			objInstituteExamList = new CoreWebList<InstituteExamClass>();
			while (objReader.Read())
			{
				objInstituteExam = new InstituteExamClass();
				objInstituteExam.iID = int.Parse(objReader["InstituteExam_ID"].ToString());
				objInstituteExam.iInstituteID = int.Parse(objReader["InstituteExam_InstituteID"].ToString());
				objInstituteExam.iExamID = int.Parse(objReader["InstituteExam_ExamID"].ToString());
                objInstituteExam.strTitle = objReader["EntranceExam_Title"].ToString();
				objInstituteExamList.Add(objInstituteExam);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteExamList;
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
