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
/// Summary description for DBExamTimeTableClass
/// </summary>
public class DBExamTimeTableClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveExamTimeTable(ExamTimeTableClass objExamTimeTable)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_ExamTimeTable (ExamTimeTable_UniversityID, ExamTimeTable_Title, ExamTimeTable_Desc) VALUES (@ExamTimeTable_UniversityID, @ExamTimeTable_Title, @ExamTimeTable_Desc)",objConnection) ;
			objCommand.Parameters.AddWithValue("@ExamTimeTable_UniversityID", objExamTimeTable.iUniversityID);
			objCommand.Parameters.AddWithValue("@ExamTimeTable_Title", objExamTimeTable.strTitle);
			objCommand.Parameters.AddWithValue("@ExamTimeTable_Desc", objExamTimeTable.strDesc);

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

	public string fn_editExamTimeTable(ExamTimeTableClass objExamTimeTable)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_ExamTimeTable SET ExamTimeTable_Title=@ExamTimeTable_Title, ExamTimeTable_Desc=@ExamTimeTable_Desc WHERE ExamTimeTable_ID=@ExamTimeTable_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@ExamTimeTable_ID", objExamTimeTable.iID);
            objCommand.Parameters.AddWithValue("@ExamTimeTable_Title", objExamTimeTable.strTitle);
            objCommand.Parameters.AddWithValue("@ExamTimeTable_Desc", objExamTimeTable.strDesc);

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

	public string fn_deleteExamTimeTable(int iExamTimeTableID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_ExamTimeTable WHERE ExamTimeTable_ID=@ExamTimeTable_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@ExamTimeTable_ID", iExamTimeTableID);

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

	public CoreWebList<ExamTimeTableClass> fn_getExamTimeTableList()
	{
		CoreWebList<ExamTimeTableClass> objExamTimeTableList = null;
		ExamTimeTableClass objExamTimeTable = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_ExamTimeTable", objConnection);
			objReader = objCommand.ExecuteReader();
			objExamTimeTableList = new CoreWebList<ExamTimeTableClass>();
			while (objReader.Read())
			{
				objExamTimeTable = new ExamTimeTableClass();
				objExamTimeTable.iID = int.Parse(objReader["ExamTimeTable_ID"].ToString());
				objExamTimeTable.iUniversityID = int.Parse(objReader["ExamTimeTable_UniversityID"].ToString());
				objExamTimeTable.strTitle = objReader["ExamTimeTable_Title"].ToString();
				objExamTimeTable.strDesc = objReader["ExamTimeTable_Desc"].ToString();
				objExamTimeTableList.Add(objExamTimeTable);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objExamTimeTableList;
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

	public CoreWebList<ExamTimeTableClass> fn_getExamTimeTableByID(int iExamTimeTableID)
	{
		CoreWebList<ExamTimeTableClass> objExamTimeTableList = null;
		ExamTimeTableClass objExamTimeTable = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_ExamTimeTable WHERE ExamTimeTable_ID=@ExamTimeTable_ID", objConnection);
			objCommand.Parameters.AddWithValue("@ExamTimeTable_ID", iExamTimeTableID);
			objReader = objCommand.ExecuteReader();
			objExamTimeTableList = new CoreWebList<ExamTimeTableClass>();
			if (objReader.Read())
			{
				objExamTimeTable = new ExamTimeTableClass();
				objExamTimeTable.iID = int.Parse(objReader["ExamTimeTable_ID"].ToString());
				objExamTimeTable.iUniversityID = int.Parse(objReader["ExamTimeTable_UniversityID"].ToString());
				objExamTimeTable.strTitle = objReader["ExamTimeTable_Title"].ToString();
				objExamTimeTable.strDesc = objReader["ExamTimeTable_Desc"].ToString();
				objExamTimeTableList.Add(objExamTimeTable);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objExamTimeTableList;
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

	public CoreWebList<ExamTimeTableClass> fn_getExamTimeTableByName(string strExamTimeTableTitle)
	{
		CoreWebList<ExamTimeTableClass> objExamTimeTableList = null;
		ExamTimeTableClass objExamTimeTable = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_ExamTimeTable WHERE ExamTimeTable_Title=@ExamTimeTable_Title", objConnection);
			objCommand.Parameters.AddWithValue("@ExamTimeTable_Title", strExamTimeTableTitle);
			objReader = objCommand.ExecuteReader();
			objExamTimeTableList = new CoreWebList<ExamTimeTableClass>();
			if (objReader.Read())
			{
				objExamTimeTable = new ExamTimeTableClass();
				objExamTimeTable.iID = int.Parse(objReader["ExamTimeTable_ID"].ToString());
				objExamTimeTable.iUniversityID = int.Parse(objReader["ExamTimeTable_UniversityID"].ToString());
				objExamTimeTable.strTitle = objReader["ExamTimeTable_Title"].ToString();
				objExamTimeTable.strDesc = objReader["ExamTimeTable_Desc"].ToString();
				objExamTimeTableList.Add(objExamTimeTable);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objExamTimeTableList;
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

	public CoreWebList<ExamTimeTableClass> fn_getExamTimeTableByKeys(string strExamTimeTableTitle)
	{
		CoreWebList<ExamTimeTableClass> objExamTimeTableList = null;
		ExamTimeTableClass objExamTimeTable = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_ExamTimeTable WHERE ExamTimeTable_Title like '%' + @ExamTimeTable_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@ExamTimeTable_Title", strExamTimeTableTitle);
			objReader = objCommand.ExecuteReader();
			objExamTimeTableList = new CoreWebList<ExamTimeTableClass>();
			while (objReader.Read())
			{
				objExamTimeTable = new ExamTimeTableClass();
				objExamTimeTable.iID = int.Parse(objReader["ExamTimeTable_ID"].ToString());
				objExamTimeTable.iUniversityID = int.Parse(objReader["ExamTimeTable_UniversityID"].ToString());
				objExamTimeTable.strTitle = objReader["ExamTimeTable_Title"].ToString();
				objExamTimeTable.strDesc = objReader["ExamTimeTable_Desc"].ToString();
				objExamTimeTableList.Add(objExamTimeTable);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objExamTimeTableList;
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

	public CoreWebList<ExamTimeTableClass> fn_getExamTimeTableByUniversityID(int iUniversityID)
	{
		CoreWebList<ExamTimeTableClass> objExamTimeTableList = null;
		ExamTimeTableClass objExamTimeTable = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_ExamTimeTable WHERE ExamTimeTable_UniversityID=@ExamTimeTable_UniversityID", objConnection);
			objCommand.Parameters.AddWithValue("@ExamTimeTable_UniversityID", iUniversityID);
			objReader = objCommand.ExecuteReader();
			objExamTimeTableList = new CoreWebList<ExamTimeTableClass>();
			while (objReader.Read())
			{
				objExamTimeTable = new ExamTimeTableClass();
				objExamTimeTable.iID = int.Parse(objReader["ExamTimeTable_ID"].ToString());
				objExamTimeTable.iUniversityID = int.Parse(objReader["ExamTimeTable_UniversityID"].ToString());
				objExamTimeTable.strTitle = objReader["ExamTimeTable_Title"].ToString();
				objExamTimeTable.strDesc = objReader["ExamTimeTable_Desc"].ToString();
				objExamTimeTableList.Add(objExamTimeTable);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objExamTimeTableList;
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
