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
/// Summary description for DBCompetitionFileClass
/// </summary>
public class DBCompetitionFileClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveCompetitionFile(CompetitionFileClass objCompetitionFile)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_CompetitionFiles (CompetitionFile_UserID, CompetitionFile_CompetitionID, CompetitionFile_Title, CompetitionFile_File) VALUES (@CompetitionFile_UserID, @CompetitionFile_CompetitionID, @CompetitionFile_Title, @CompetitionFile_File)",objConnection) ;
			objCommand.Parameters.AddWithValue("@CompetitionFile_UserID", objCompetitionFile.iUserID);
			objCommand.Parameters.AddWithValue("@CompetitionFile_CompetitionID", objCompetitionFile.iCompetitionID);
			objCommand.Parameters.AddWithValue("@CompetitionFile_Title", objCompetitionFile.strTitle);
			objCommand.Parameters.AddWithValue("@CompetitionFile_File", objCompetitionFile.strFile);

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

	public string fn_editCompetitionFile(CompetitionFileClass objCompetitionFile)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_CompetitionFiles SET CompetitionFile_UserID=@CompetitionFile_UserID, CompetitionFile_CompetitionID=@CompetitionFile_CompetitionID, CompetitionFile_Title=@CompetitionFile_Title, CompetitionFile_File=@CompetitionFile_File WHERE CompetitionFile_ID=@CompetitionFile_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CompetitionFile_ID", objCompetitionFile.iID);
			objCommand.Parameters.AddWithValue("@CompetitionFile_CompetitionID", objCompetitionFile.iCompetitionID);
			objCommand.Parameters.AddWithValue("@CompetitionFile_Title", objCompetitionFile.strTitle);
			objCommand.Parameters.AddWithValue("@CompetitionFile_File", objCompetitionFile.strFile);

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

	public string fn_deleteCompetitionFile(int iCompetitionFileID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_CompetitionFiles WHERE CompetitionFile_ID=@CompetitionFile_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CompetitionFile_ID", iCompetitionFileID);

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

	public CoreWebList<CompetitionFileClass> fn_getCompetitionFileList()
	{
		CoreWebList<CompetitionFileClass> objCompetitionFileList = null;
		CompetitionFileClass objCompetitionFile = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionFiles", objConnection);
			objReader = objCommand.ExecuteReader();
			objCompetitionFileList = new CoreWebList<CompetitionFileClass>();
			while (objReader.Read())
			{
				objCompetitionFile = new CompetitionFileClass();
				objCompetitionFile.iID = int.Parse(objReader["CompetitionFile_ID"].ToString());
				objCompetitionFile.iUserID = int.Parse(objReader["CompetitionFile_UserID"].ToString());
				objCompetitionFile.iCompetitionID = int.Parse(objReader["CompetitionFile_CompetitionID"].ToString());
				objCompetitionFile.strTitle = objReader["CompetitionFile_Title"].ToString();
				objCompetitionFile.strFile = objReader["CompetitionFile_File"].ToString();
				objCompetitionFileList.Add(objCompetitionFile);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionFileList;
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

	public CoreWebList<CompetitionFileClass> fn_getCompetitionFileByID(int iCompetitionFileID)
	{
		CoreWebList<CompetitionFileClass> objCompetitionFileList = null;
		CompetitionFileClass objCompetitionFile = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionFiles WHERE CompetitionFile_ID=@CompetitionFile_ID", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionFile_ID", iCompetitionFileID);
			objReader = objCommand.ExecuteReader();
			objCompetitionFileList = new CoreWebList<CompetitionFileClass>();
			if (objReader.Read())
			{
				objCompetitionFile = new CompetitionFileClass();
				objCompetitionFile.iID = int.Parse(objReader["CompetitionFile_ID"].ToString());
				objCompetitionFile.iUserID = int.Parse(objReader["CompetitionFile_UserID"].ToString());
				objCompetitionFile.iCompetitionID = int.Parse(objReader["CompetitionFile_CompetitionID"].ToString());
				objCompetitionFile.strTitle = objReader["CompetitionFile_Title"].ToString();
				objCompetitionFile.strFile = objReader["CompetitionFile_File"].ToString();
				objCompetitionFileList.Add(objCompetitionFile);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionFileList;
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

	public CoreWebList<CompetitionFileClass> fn_getCompetitionFileByName(string strCompetitionFileTitle)
	{
		CoreWebList<CompetitionFileClass> objCompetitionFileList = null;
		CompetitionFileClass objCompetitionFile = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionFiles WHERE CompetitionFile_Title=@CompetitionFile_Title", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionFile_Title", strCompetitionFileTitle);
			objReader = objCommand.ExecuteReader();
			objCompetitionFileList = new CoreWebList<CompetitionFileClass>();
			if (objReader.Read())
			{
				objCompetitionFile = new CompetitionFileClass();
				objCompetitionFile.iID = int.Parse(objReader["CompetitionFile_ID"].ToString());
				objCompetitionFile.iUserID = int.Parse(objReader["CompetitionFile_UserID"].ToString());
				objCompetitionFile.iCompetitionID = int.Parse(objReader["CompetitionFile_CompetitionID"].ToString());
				objCompetitionFile.strTitle = objReader["CompetitionFile_Title"].ToString();
				objCompetitionFile.strFile = objReader["CompetitionFile_File"].ToString();
				objCompetitionFileList.Add(objCompetitionFile);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionFileList;
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

	public CoreWebList<CompetitionFileClass> fn_getCompetitionFileByKeys(string strCompetitionFileTitle)
	{
		CoreWebList<CompetitionFileClass> objCompetitionFileList = null;
		CompetitionFileClass objCompetitionFile = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionFiles WHERE CompetitionFile_Title like '%' + @CompetitionFile_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionFile_Title", strCompetitionFileTitle);
			objReader = objCommand.ExecuteReader();
			objCompetitionFileList = new CoreWebList<CompetitionFileClass>();
			while (objReader.Read())
			{
				objCompetitionFile = new CompetitionFileClass();
				objCompetitionFile.iID = int.Parse(objReader["CompetitionFile_ID"].ToString());
				objCompetitionFile.iUserID = int.Parse(objReader["CompetitionFile_UserID"].ToString());
				objCompetitionFile.iCompetitionID = int.Parse(objReader["CompetitionFile_CompetitionID"].ToString());
				objCompetitionFile.strTitle = objReader["CompetitionFile_Title"].ToString();
				objCompetitionFile.strFile = objReader["CompetitionFile_File"].ToString();
				objCompetitionFileList.Add(objCompetitionFile);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionFileList;
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

	public CoreWebList<CompetitionFileClass> fn_getCompetitionFileByCompetitionID(int iCompetitionID)
	{
		CoreWebList<CompetitionFileClass> objCompetitionFileList = null;
		CompetitionFileClass objCompetitionFile = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionFiles WHERE CompetitionFile_CompetitionID=@CompetitionFile_CompetitionID", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionFile_CompetitionID", iCompetitionID);
			objReader = objCommand.ExecuteReader();
			objCompetitionFileList = new CoreWebList<CompetitionFileClass>();
			while (objReader.Read())
			{
				objCompetitionFile = new CompetitionFileClass();
				objCompetitionFile.iID = int.Parse(objReader["CompetitionFile_ID"].ToString());
				objCompetitionFile.iUserID = int.Parse(objReader["CompetitionFile_UserID"].ToString());
				objCompetitionFile.iCompetitionID = int.Parse(objReader["CompetitionFile_CompetitionID"].ToString());
				objCompetitionFile.strTitle = objReader["CompetitionFile_Title"].ToString();
				objCompetitionFile.strFile = objReader["CompetitionFile_File"].ToString();
				objCompetitionFileList.Add(objCompetitionFile);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionFileList;
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

    public CoreWebList<CompetitionFileClass> fn_getCompetitionFileByCompetitionIDUserID(int iCompetitionID, int iUserID)
	{
		CoreWebList<CompetitionFileClass> objCompetitionFileList = null;
		CompetitionFileClass objCompetitionFile = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionFiles WHERE CompetitionFile_CompetitionID=@CompetitionFile_CompetitionID AND CompetitionFile_UserID=@CompetitionFile_UserID", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionFile_CompetitionID", iCompetitionID);
            objCommand.Parameters.AddWithValue("@CompetitionFile_UserID", iUserID);
			objReader = objCommand.ExecuteReader();
			objCompetitionFileList = new CoreWebList<CompetitionFileClass>();
			while (objReader.Read())
			{
				objCompetitionFile = new CompetitionFileClass();
				objCompetitionFile.iID = int.Parse(objReader["CompetitionFile_ID"].ToString());
				objCompetitionFile.iUserID = int.Parse(objReader["CompetitionFile_UserID"].ToString());
				objCompetitionFile.iCompetitionID = int.Parse(objReader["CompetitionFile_CompetitionID"].ToString());
				objCompetitionFile.strTitle = objReader["CompetitionFile_Title"].ToString();
				objCompetitionFile.strFile = objReader["CompetitionFile_File"].ToString();
				objCompetitionFileList.Add(objCompetitionFile);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionFileList;
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

	public CoreWebList<CompetitionFileClass> fn_getCompetitionFileByUserID(int iUserID)
	{
		CoreWebList<CompetitionFileClass> objCompetitionFileList = null;
		CompetitionFileClass objCompetitionFile = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionFiles WHERE CompetitionFile_UserID=@CompetitionFile_UserID", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionFile_UserID", iUserID);
			objReader = objCommand.ExecuteReader();
			objCompetitionFileList = new CoreWebList<CompetitionFileClass>();
			while (objReader.Read())
			{
				objCompetitionFile = new CompetitionFileClass();
				objCompetitionFile.iID = int.Parse(objReader["CompetitionFile_ID"].ToString());
				objCompetitionFile.iUserID = int.Parse(objReader["CompetitionFile_UserID"].ToString());
				objCompetitionFile.iCompetitionID = int.Parse(objReader["CompetitionFile_CompetitionID"].ToString());
				objCompetitionFile.strTitle = objReader["CompetitionFile_Title"].ToString();
				objCompetitionFile.strFile = objReader["CompetitionFile_File"].ToString();
				objCompetitionFileList.Add(objCompetitionFile);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionFileList;
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

    public CoreWebList<CompetitionFileClass> fn_getCheckUserParticipation(int iCompetitionID, int iUserID)
    {
        CoreWebList<CompetitionFileClass> objCompetitionFileList = null;
        CompetitionFileClass objCompetitionFile = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionFiles WHERE CompetitionFile_CompetitionID=@CompetitionFile_CompetitionID AND CompetitionFile_UserID=@CompetitionFile_UserID", objConnection);
            objCommand.Parameters.AddWithValue("@CompetitionFile_CompetitionID", iCompetitionID);
            objCommand.Parameters.AddWithValue("@CompetitionFile_UserID", iUserID);
            objReader = objCommand.ExecuteReader();
            objCompetitionFileList = new CoreWebList<CompetitionFileClass>();
            while (objReader.Read())
            {
                objCompetitionFile = new CompetitionFileClass();
                objCompetitionFile.iID = int.Parse(objReader["CompetitionFile_ID"].ToString());
                objCompetitionFile.iUserID = int.Parse(objReader["CompetitionFile_UserID"].ToString());
                objCompetitionFile.iCompetitionID = int.Parse(objReader["CompetitionFile_CompetitionID"].ToString());
                objCompetitionFile.strTitle = objReader["CompetitionFile_Title"].ToString();
                objCompetitionFile.strFile = objReader["CompetitionFile_File"].ToString();
                objCompetitionFileList.Add(objCompetitionFile);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCompetitionFileList;
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
