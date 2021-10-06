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
/// Summary description for DBLevelofStudyClass
/// </summary>
public class DBLevelofStudyClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveLevelofStudy(LevelofStudyClass objLevelofStudy)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_LevelofStudy (LevelofStudy_Title) VALUES (@LevelofStudy_Title)",objConnection) ;
			objCommand.Parameters.AddWithValue("@LevelofStudy_Title", objLevelofStudy.strTitle);

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

	public string fn_editLevelofStudy(LevelofStudyClass objLevelofStudy)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_LevelofStudy SET LevelofStudy_Title=@LevelofStudy_Title WHERE LevelofStudy_ID=@LevelofStudy_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@LevelofStudy_ID", objLevelofStudy.iID);
			objCommand.Parameters.AddWithValue("@LevelofStudy_Title", objLevelofStudy.strTitle);

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

	public string fn_deleteLevelofStudy(int iLevelofStudyID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_LevelofStudy WHERE LevelofStudy_ID=@LevelofStudy_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@LevelofStudy_ID", iLevelofStudyID);

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

	public CoreWebList<LevelofStudyClass> fn_getLevelofStudyList()
	{
		CoreWebList<LevelofStudyClass> objLevelofStudyList = null;
		LevelofStudyClass objLevelofStudy = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_LevelofStudy", objConnection);
			objReader = objCommand.ExecuteReader();
			objLevelofStudyList = new CoreWebList<LevelofStudyClass>();
			while (objReader.Read())
			{
				objLevelofStudy = new LevelofStudyClass();
				objLevelofStudy.iID = int.Parse(objReader["LevelofStudy_ID"].ToString());
				objLevelofStudy.strTitle = objReader["LevelofStudy_Title"].ToString();
				objLevelofStudyList.Add(objLevelofStudy);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objLevelofStudyList;
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

	public CoreWebList<LevelofStudyClass> fn_getLevelofStudyByID(int iLevelofStudyID)
	{
		CoreWebList<LevelofStudyClass> objLevelofStudyList = null;
		LevelofStudyClass objLevelofStudy = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_LevelofStudy WHERE LevelofStudy_ID=@LevelofStudy_ID", objConnection);
			objCommand.Parameters.AddWithValue("@LevelofStudy_ID", iLevelofStudyID);
			objReader = objCommand.ExecuteReader();
			objLevelofStudyList = new CoreWebList<LevelofStudyClass>();
			if (objReader.Read())
			{
				objLevelofStudy = new LevelofStudyClass();
				objLevelofStudy.iID = int.Parse(objReader["LevelofStudy_ID"].ToString());
				objLevelofStudy.strTitle = objReader["LevelofStudy_Title"].ToString();
				objLevelofStudyList.Add(objLevelofStudy);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objLevelofStudyList;
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

	public CoreWebList<LevelofStudyClass> fn_getLevelofStudyByName(string strLevelofStudyTitle)
	{
		CoreWebList<LevelofStudyClass> objLevelofStudyList = null;
		LevelofStudyClass objLevelofStudy = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_LevelofStudy WHERE LevelofStudy_Title=@LevelofStudy_Title", objConnection);
			objCommand.Parameters.AddWithValue("@LevelofStudy_Title", strLevelofStudyTitle);
			objReader = objCommand.ExecuteReader();
			objLevelofStudyList = new CoreWebList<LevelofStudyClass>();
			if (objReader.Read())
			{
				objLevelofStudy = new LevelofStudyClass();
				objLevelofStudy.iID = int.Parse(objReader["LevelofStudy_ID"].ToString());
				objLevelofStudy.strTitle = objReader["LevelofStudy_Title"].ToString();
				objLevelofStudyList.Add(objLevelofStudy);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objLevelofStudyList;
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

	public CoreWebList<LevelofStudyClass> fn_getLevelofStudyByKeys(string strLevelofStudyTitle)
	{
		CoreWebList<LevelofStudyClass> objLevelofStudyList = null;
		LevelofStudyClass objLevelofStudy = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_LevelofStudy WHERE LevelofStudy_Title like '%' + @LevelofStudy_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@LevelofStudy_Title", strLevelofStudyTitle);
			objReader = objCommand.ExecuteReader();
			objLevelofStudyList = new CoreWebList<LevelofStudyClass>();
			while (objReader.Read())
			{
				objLevelofStudy = new LevelofStudyClass();
				objLevelofStudy.iID = int.Parse(objReader["LevelofStudy_ID"].ToString());
				objLevelofStudy.strTitle = objReader["LevelofStudy_Title"].ToString();
				objLevelofStudyList.Add(objLevelofStudy);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objLevelofStudyList;
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
