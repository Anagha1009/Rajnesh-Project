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
/// Summary description for DBModeofStudyClass
/// </summary>
public class DBModeofStudyClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveModeofStudy(ModeofStudyClass objModeofStudy)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_ModeofStudy (ModeofStudy_Title) VALUES (@ModeofStudy_Title)",objConnection) ;
			objCommand.Parameters.AddWithValue("@ModeofStudy_Title", objModeofStudy.strTitle);

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

	public string fn_editModeofStudy(ModeofStudyClass objModeofStudy)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_ModeofStudy SET ModeofStudy_Title=@ModeofStudy_Title WHERE ModeofStudy_ID=@ModeofStudy_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@ModeofStudy_ID", objModeofStudy.iID);
			objCommand.Parameters.AddWithValue("@ModeofStudy_Title", objModeofStudy.strTitle);

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

	public string fn_deleteModeofStudy(int iModeofStudyID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_ModeofStudy WHERE ModeofStudy_ID=@ModeofStudy_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@ModeofStudy_ID", iModeofStudyID);

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

	public CoreWebList<ModeofStudyClass> fn_getModeofStudyList()
	{
		CoreWebList<ModeofStudyClass> objModeofStudyList = null;
		ModeofStudyClass objModeofStudy = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_ModeofStudy", objConnection);
			objReader = objCommand.ExecuteReader();
			objModeofStudyList = new CoreWebList<ModeofStudyClass>();
			while (objReader.Read())
			{
				objModeofStudy = new ModeofStudyClass();
				objModeofStudy.iID = int.Parse(objReader["ModeofStudy_ID"].ToString());
				objModeofStudy.strTitle = objReader["ModeofStudy_Title"].ToString();
				objModeofStudyList.Add(objModeofStudy);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objModeofStudyList;
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

	public CoreWebList<ModeofStudyClass> fn_getModeofStudyByID(int iModeofStudyID)
	{
		CoreWebList<ModeofStudyClass> objModeofStudyList = null;
		ModeofStudyClass objModeofStudy = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_ModeofStudy WHERE ModeofStudy_ID=@ModeofStudy_ID", objConnection);
			objCommand.Parameters.AddWithValue("@ModeofStudy_ID", iModeofStudyID);
			objReader = objCommand.ExecuteReader();
			objModeofStudyList = new CoreWebList<ModeofStudyClass>();
			if (objReader.Read())
			{
				objModeofStudy = new ModeofStudyClass();
				objModeofStudy.iID = int.Parse(objReader["ModeofStudy_ID"].ToString());
				objModeofStudy.strTitle = objReader["ModeofStudy_Title"].ToString();
				objModeofStudyList.Add(objModeofStudy);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objModeofStudyList;
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

	public CoreWebList<ModeofStudyClass> fn_getModeofStudyByName(string strModeofStudyTitle)
	{
		CoreWebList<ModeofStudyClass> objModeofStudyList = null;
		ModeofStudyClass objModeofStudy = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_ModeofStudy WHERE ModeofStudy_Title=@ModeofStudy_Title", objConnection);
			objCommand.Parameters.AddWithValue("@ModeofStudy_Title", strModeofStudyTitle);
			objReader = objCommand.ExecuteReader();
			objModeofStudyList = new CoreWebList<ModeofStudyClass>();
			if (objReader.Read())
			{
				objModeofStudy = new ModeofStudyClass();
				objModeofStudy.iID = int.Parse(objReader["ModeofStudy_ID"].ToString());
				objModeofStudy.strTitle = objReader["ModeofStudy_Title"].ToString();
				objModeofStudyList.Add(objModeofStudy);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objModeofStudyList;
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

	public CoreWebList<ModeofStudyClass> fn_getModeofStudyByKeys(string strModeofStudyTitle)
	{
		CoreWebList<ModeofStudyClass> objModeofStudyList = null;
		ModeofStudyClass objModeofStudy = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_ModeofStudy WHERE ModeofStudy_Title like '%' + @ModeofStudy_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@ModeofStudy_Title", strModeofStudyTitle);
			objReader = objCommand.ExecuteReader();
			objModeofStudyList = new CoreWebList<ModeofStudyClass>();
			while (objReader.Read())
			{
				objModeofStudy = new ModeofStudyClass();
				objModeofStudy.iID = int.Parse(objReader["ModeofStudy_ID"].ToString());
				objModeofStudy.strTitle = objReader["ModeofStudy_Title"].ToString();
				objModeofStudyList.Add(objModeofStudy);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objModeofStudyList;
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
