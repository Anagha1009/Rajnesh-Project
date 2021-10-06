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
/// Summary description for DBCompetitionEntryClass
/// </summary>
public class DBCompetitionEntryClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveCompetitionEntry(CompetitionEntryClass objCompetitionEntry)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_CompetitionEntry (CompetitionEntry_UserID, CompetitionEntry_OptionID) VALUES (@CompetitionEntry_UserID, @CompetitionEntry_OptionID)",objConnection) ;
			objCommand.Parameters.AddWithValue("@CompetitionEntry_UserID", objCompetitionEntry.iUserID);
			objCommand.Parameters.AddWithValue("@CompetitionEntry_OptionID", objCompetitionEntry.iOptionID);

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

	public string fn_editCompetitionEntry(CompetitionEntryClass objCompetitionEntry)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_CompetitionEntry SET CompetitionEntry_UserID=@CompetitionEntry_UserID, CompetitionEntry_OptionID=@CompetitionEntry_OptionID WHERE CompetitionEntry_ID=@CompetitionEntry_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CompetitionEntry_ID", objCompetitionEntry.iID);
			objCommand.Parameters.AddWithValue("@CompetitionEntry_OptionID", objCompetitionEntry.iOptionID);

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

	public string fn_deleteCompetitionEntry(int iCompetitionEntryID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_CompetitionEntry WHERE CompetitionEntry_ID=@CompetitionEntry_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CompetitionEntry_ID", iCompetitionEntryID);

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

	public string fn_deleteCompetitionEntryByUserID(int iUserID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_CompetitionEntry WHERE CompetitionEntry_UserID=@CompetitionEntry_UserID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CompetitionEntry_UserID", iUserID);

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

	public CoreWebList<CompetitionEntryClass> fn_getCompetitionEntryList()
	{
		CoreWebList<CompetitionEntryClass> objCompetitionEntryList = null;
		CompetitionEntryClass objCompetitionEntry = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionEntry", objConnection);
			objReader = objCommand.ExecuteReader();
			objCompetitionEntryList = new CoreWebList<CompetitionEntryClass>();
			while (objReader.Read())
			{
				objCompetitionEntry = new CompetitionEntryClass();
				objCompetitionEntry.iID = int.Parse(objReader["CompetitionEntry_ID"].ToString());
				objCompetitionEntry.iUserID = int.Parse(objReader["CompetitionEntry_UserID"].ToString());
				objCompetitionEntry.iOptionID = int.Parse(objReader["CompetitionEntry_OptionID"].ToString());
				objCompetitionEntryList.Add(objCompetitionEntry);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionEntryList;
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

	public CoreWebList<CompetitionEntryClass> fn_getCompetitionEntryByID(int iCompetitionEntryID)
	{
		CoreWebList<CompetitionEntryClass> objCompetitionEntryList = null;
		CompetitionEntryClass objCompetitionEntry = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionEntry WHERE CompetitionEntry_ID=@CompetitionEntry_ID", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionEntry_ID", iCompetitionEntryID);
			objReader = objCommand.ExecuteReader();
			objCompetitionEntryList = new CoreWebList<CompetitionEntryClass>();
			if (objReader.Read())
			{
				objCompetitionEntry = new CompetitionEntryClass();
				objCompetitionEntry.iID = int.Parse(objReader["CompetitionEntry_ID"].ToString());
				objCompetitionEntry.iUserID = int.Parse(objReader["CompetitionEntry_UserID"].ToString());
				objCompetitionEntry.iOptionID = int.Parse(objReader["CompetitionEntry_OptionID"].ToString());
				objCompetitionEntryList.Add(objCompetitionEntry);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionEntryList;
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

	public CoreWebList<CompetitionEntryClass> fn_getCompetitionEntryByOptionID(int iOptionID)
	{
		CoreWebList<CompetitionEntryClass> objCompetitionEntryList = null;
		CompetitionEntryClass objCompetitionEntry = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionEntry WHERE CompetitionEntry_OptionID=@CompetitionEntry_OptionID", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionEntry_OptionID", iOptionID);
			objReader = objCommand.ExecuteReader();
			objCompetitionEntryList = new CoreWebList<CompetitionEntryClass>();
			while (objReader.Read())
			{
				objCompetitionEntry = new CompetitionEntryClass();
				objCompetitionEntry.iID = int.Parse(objReader["CompetitionEntry_ID"].ToString());
				objCompetitionEntry.iUserID = int.Parse(objReader["CompetitionEntry_UserID"].ToString());
				objCompetitionEntry.iOptionID = int.Parse(objReader["CompetitionEntry_OptionID"].ToString());
				objCompetitionEntryList.Add(objCompetitionEntry);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionEntryList;
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

	public CoreWebList<CompetitionEntryClass> fn_getCompetitionEntryByUserID(int iUserID)
	{
		CoreWebList<CompetitionEntryClass> objCompetitionEntryList = null;
		CompetitionEntryClass objCompetitionEntry = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionEntry WHERE CompetitionEntry_UserID=@CompetitionEntry_UserID", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionEntry_UserID", iUserID);
			objReader = objCommand.ExecuteReader();
			objCompetitionEntryList = new CoreWebList<CompetitionEntryClass>();
			while (objReader.Read())
			{
				objCompetitionEntry = new CompetitionEntryClass();
				objCompetitionEntry.iID = int.Parse(objReader["CompetitionEntry_ID"].ToString());
				objCompetitionEntry.iUserID = int.Parse(objReader["CompetitionEntry_UserID"].ToString());
				objCompetitionEntry.iOptionID = int.Parse(objReader["CompetitionEntry_OptionID"].ToString());
				objCompetitionEntryList.Add(objCompetitionEntry);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionEntryList;
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

    public CoreWebList<CompetitionEntryClass> fn_getCheckCompetitionEntryByUserID(int iCompetionID, int iUserID)
    {
        CoreWebList<CompetitionEntryClass> objCompetitionEntryList = null;
        CompetitionEntryClass objCompetitionEntry = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Competitions comp join tbl_CompetitionQuiz Qz on comp.Competition_ID=Qz.CompetitionQuiz_CompetitionID join tbl_CompetitionQuizOptions QzOp on Qz.CompetitionQuiz_ID=QzOp.CompetitionQuizOption_QuizID join tbl_CompetitionEntry Entr on QzOp.CompetitionQuizOption_ID=Entr.CompetitionEntry_OptionID WHERE Entr.CompetitionEntry_UserID=@CompetitionEntry_UserID AND comp.Competition_ID=@Competition_ID", objConnection);
            objCommand.Parameters.AddWithValue("@Competition_ID", iCompetionID);
            objCommand.Parameters.AddWithValue("@CompetitionEntry_UserID", iUserID);
            objReader = objCommand.ExecuteReader();
            objCompetitionEntryList = new CoreWebList<CompetitionEntryClass>();
            while (objReader.Read())
            {
                objCompetitionEntry = new CompetitionEntryClass();
                objCompetitionEntry.iID = int.Parse(objReader["CompetitionEntry_ID"].ToString());
                objCompetitionEntry.iUserID = int.Parse(objReader["CompetitionEntry_UserID"].ToString());
                objCompetitionEntry.iOptionID = int.Parse(objReader["CompetitionEntry_OptionID"].ToString());
                objCompetitionEntryList.Add(objCompetitionEntry);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCompetitionEntryList;
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
