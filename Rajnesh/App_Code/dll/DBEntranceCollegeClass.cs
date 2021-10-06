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
/// Summary description for DBEntranceCollegeClass
/// </summary>
public class DBEntranceCollegeClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveEntranceCollege(EntranceCollegeClass objEntranceCollege)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_EntranceColleges (EntranceColleges_ExamID, EntranceColleges_CollegeID) VALUES (@EntranceColleges_ExamID, @EntranceColleges_CollegeID)", objConnection);
			objCommand.Parameters.AddWithValue("@EntranceColleges_ExamID", objEntranceCollege.iExamID);
            objCommand.Parameters.AddWithValue("@EntranceColleges_CollegeID", objEntranceCollege.iCollegeID);

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

	public string fn_editEntranceCollege(EntranceCollegeClass objEntranceCollege)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_EntranceColleges SET EntranceColleges_ExamID=@EntranceColleges_ExamID, EntranceColleges_CollegeID=@EntranceColleges_CollegeID WHERE EntranceCollege_ID=@EntranceCollege_ID", objConnection);
			objCommand.Parameters.AddWithValue("@EntranceCollege_ID", objEntranceCollege.iID);
			objCommand.Parameters.AddWithValue("@EntranceColleges_ExamID", objEntranceCollege.iExamID);
            objCommand.Parameters.AddWithValue("@EntranceColleges_CollegeID", objEntranceCollege.iCollegeID);

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

	public string fn_deleteEntranceCollege(int iEntranceiCollegeID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_EntranceColleges WHERE EntranceCollege_ID=@EntranceCollege_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@EntranceCollege_ID", iEntranceiCollegeID);

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

    public string fn_deleteEntranceCollegeByExamID(int iExamID)
    {
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("DELETE FROM tbl_EntranceColleges WHERE EntranceColleges_ExamID=@EntranceColleges_ExamID", objConnection);
            objCommand.Parameters.AddWithValue("@EntranceColleges_ExamID", iExamID);

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

	public CoreWebList<EntranceCollegeClass> fn_getEntranceCollegeList()
	{
		CoreWebList<EntranceCollegeClass> objEntranceCollegeList = null;
		EntranceCollegeClass objEntranceCollege = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EntranceColleges", objConnection);
			objReader = objCommand.ExecuteReader();
			objEntranceCollegeList = new CoreWebList<EntranceCollegeClass>();
			while (objReader.Read())
			{
				objEntranceCollege = new EntranceCollegeClass();
				objEntranceCollege.iID = int.Parse(objReader["EntranceCollege_ID"].ToString());
				objEntranceCollege.iExamID = int.Parse(objReader["EntranceColleges_ExamID"].ToString());
                objEntranceCollege.iCollegeID = int.Parse(objReader["EntranceColleges_CollegeID"].ToString());
				objEntranceCollegeList.Add(objEntranceCollege);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEntranceCollegeList;
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

	public CoreWebList<EntranceCollegeClass> fn_getEntranceCollegeByID(int iEntranceiCollegeID)
	{
		CoreWebList<EntranceCollegeClass> objEntranceCollegeList = null;
		EntranceCollegeClass objEntranceCollege = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EntranceColleges WHERE EntranceCollege_ID=@EntranceCollege_ID", objConnection);
			objCommand.Parameters.AddWithValue("@EntranceCollege_ID", iEntranceiCollegeID);
			objReader = objCommand.ExecuteReader();
			objEntranceCollegeList = new CoreWebList<EntranceCollegeClass>();
			if (objReader.Read())
			{
				objEntranceCollege = new EntranceCollegeClass();
				objEntranceCollege.iID = int.Parse(objReader["EntranceCollege_ID"].ToString());
				objEntranceCollege.iExamID = int.Parse(objReader["EntranceColleges_ExamID"].ToString());
                objEntranceCollege.iCollegeID = int.Parse(objReader["EntranceColleges_CollegeID"].ToString());
				objEntranceCollegeList.Add(objEntranceCollege);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEntranceCollegeList;
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

    public CoreWebList<EntranceCollegeClass> fn_getEntranceCollegeByExamID(int iExamID)
	{
		CoreWebList<EntranceCollegeClass> objEntranceCollegeList = null;
		EntranceCollegeClass objEntranceCollege = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EntranceColleges WHERE EntranceColleges_ExamID=@EntranceColleges_ExamID", objConnection);
			objCommand.Parameters.AddWithValue("@EntranceColleges_ExamID", iExamID);
			objReader = objCommand.ExecuteReader();
			objEntranceCollegeList = new CoreWebList<EntranceCollegeClass>();
			while (objReader.Read())
			{
				objEntranceCollege = new EntranceCollegeClass();
				objEntranceCollege.iID = int.Parse(objReader["EntranceCollege_ID"].ToString());
				objEntranceCollege.iExamID = int.Parse(objReader["EntranceColleges_ExamID"].ToString());
                objEntranceCollege.iCollegeID = int.Parse(objReader["EntranceColleges_CollegeID"].ToString());
				objEntranceCollegeList.Add(objEntranceCollege);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEntranceCollegeList;
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

	public CoreWebList<EntranceCollegeClass> fn_getEntranceCollegeByCollegeID(int iCollegeID)
	{
		CoreWebList<EntranceCollegeClass> objEntranceCollegeList = null;
		EntranceCollegeClass objEntranceCollege = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_EntranceColleges WHERE EntranceColleges_CollegeID=@EntranceColleges_CollegeID", objConnection);
			objCommand.Parameters.AddWithValue("@CollegeID", iCollegeID);
			objReader = objCommand.ExecuteReader();
			objEntranceCollegeList = new CoreWebList<EntranceCollegeClass>();
			while (objReader.Read())
			{
				objEntranceCollege = new EntranceCollegeClass();
				objEntranceCollege.iID = int.Parse(objReader["EntranceCollege_ID"].ToString());
				objEntranceCollege.iExamID = int.Parse(objReader["EntranceColleges_ExamID"].ToString());
                objEntranceCollege.iCollegeID = int.Parse(objReader["EntranceColleges_CollegeID"].ToString());
				objEntranceCollegeList.Add(objEntranceCollege);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEntranceCollegeList;
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
