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
/// Summary description for DBCompetitionQuizOptionClass
/// </summary>
public class DBCompetitionQuizOptionClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveCompetitionQuizOption(CompetitionQuizOptionClass objCompetitionQuizOption)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_CompetitionQuizOptions (CompetitionQuizOption_QuizID, CompetitionQuizOption_Title, CompetitionQuizOption_Logo) VALUES (@CompetitionQuizOption_QuizID, @CompetitionQuizOption_Title, @CompetitionQuizOption_Logo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@CompetitionQuizOption_QuizID", objCompetitionQuizOption.iQuizID);
			objCommand.Parameters.AddWithValue("@CompetitionQuizOption_Title", objCompetitionQuizOption.strTitle);
			objCommand.Parameters.AddWithValue("@CompetitionQuizOption_Logo", objCompetitionQuizOption.strLogo);

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

	public string fn_editCompetitionQuizOption(CompetitionQuizOptionClass objCompetitionQuizOption)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_CompetitionQuizOptions SET CompetitionQuizOption_Title=@CompetitionQuizOption_Title, CompetitionQuizOption_Logo=@CompetitionQuizOption_Logo WHERE CompetitionQuizOption_ID=@CompetitionQuizOption_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CompetitionQuizOption_ID", objCompetitionQuizOption.iID);
            objCommand.Parameters.AddWithValue("@CompetitionQuizOption_Title", objCompetitionQuizOption.strTitle);
            objCommand.Parameters.AddWithValue("@CompetitionQuizOption_Logo", objCompetitionQuizOption.strLogo);

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

	public string fn_deleteCompetitionQuizOption(int iCompetitionQuizOptionID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_CompetitionQuizOptions WHERE CompetitionQuizOption_ID=@CompetitionQuizOption_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CompetitionQuizOption_ID", iCompetitionQuizOptionID);

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

	public CoreWebList<CompetitionQuizOptionClass> fn_getCompetitionQuizOptionList()
	{
		CoreWebList<CompetitionQuizOptionClass> objCompetitionQuizOptionList = null;
		CompetitionQuizOptionClass objCompetitionQuizOption = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionQuizOptions", objConnection);
			objReader = objCommand.ExecuteReader();
			objCompetitionQuizOptionList = new CoreWebList<CompetitionQuizOptionClass>();
			while (objReader.Read())
			{
				objCompetitionQuizOption = new CompetitionQuizOptionClass();
				objCompetitionQuizOption.iID = int.Parse(objReader["CompetitionQuizOption_ID"].ToString());
				objCompetitionQuizOption.iQuizID = int.Parse(objReader["CompetitionQuizOption_QuizID"].ToString());
				objCompetitionQuizOption.strTitle = objReader["CompetitionQuizOption_Title"].ToString();
				objCompetitionQuizOption.strLogo = objReader["CompetitionQuizOption_Logo"].ToString();
				objCompetitionQuizOption.bAnswer = bool.Parse(objReader["CompetitionQuizOption_Answer"].ToString());
				objCompetitionQuizOptionList.Add(objCompetitionQuizOption);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionQuizOptionList;
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

	public CoreWebList<CompetitionQuizOptionClass> fn_getCompetitionQuizOptionByID(int iCompetitionQuizOptionID)
	{
		CoreWebList<CompetitionQuizOptionClass> objCompetitionQuizOptionList = null;
		CompetitionQuizOptionClass objCompetitionQuizOption = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionQuizOptions WHERE CompetitionQuizOption_ID=@CompetitionQuizOption_ID", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionQuizOption_ID", iCompetitionQuizOptionID);
			objReader = objCommand.ExecuteReader();
			objCompetitionQuizOptionList = new CoreWebList<CompetitionQuizOptionClass>();
			if (objReader.Read())
			{
				objCompetitionQuizOption = new CompetitionQuizOptionClass();
				objCompetitionQuizOption.iID = int.Parse(objReader["CompetitionQuizOption_ID"].ToString());
				objCompetitionQuizOption.iQuizID = int.Parse(objReader["CompetitionQuizOption_QuizID"].ToString());
				objCompetitionQuizOption.strTitle = objReader["CompetitionQuizOption_Title"].ToString();
				objCompetitionQuizOption.strLogo = objReader["CompetitionQuizOption_Logo"].ToString();
				objCompetitionQuizOption.bAnswer = bool.Parse(objReader["CompetitionQuizOption_Answer"].ToString());
				objCompetitionQuizOptionList.Add(objCompetitionQuizOption);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionQuizOptionList;
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

	public CoreWebList<CompetitionQuizOptionClass> fn_getCompetitionQuizOptionByName(string strCompetitionQuizOptionTitle)
	{
		CoreWebList<CompetitionQuizOptionClass> objCompetitionQuizOptionList = null;
		CompetitionQuizOptionClass objCompetitionQuizOption = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionQuizOptions WHERE CompetitionQuizOption_Title=@CompetitionQuizOption_Title", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionQuizOption_Title", strCompetitionQuizOptionTitle);
			objReader = objCommand.ExecuteReader();
			objCompetitionQuizOptionList = new CoreWebList<CompetitionQuizOptionClass>();
			if (objReader.Read())
			{
				objCompetitionQuizOption = new CompetitionQuizOptionClass();
				objCompetitionQuizOption.iID = int.Parse(objReader["CompetitionQuizOption_ID"].ToString());
				objCompetitionQuizOption.iQuizID = int.Parse(objReader["CompetitionQuizOption_QuizID"].ToString());
				objCompetitionQuizOption.strTitle = objReader["CompetitionQuizOption_Title"].ToString();
				objCompetitionQuizOption.strLogo = objReader["CompetitionQuizOption_Logo"].ToString();
				objCompetitionQuizOption.bAnswer = bool.Parse(objReader["CompetitionQuizOption_Answer"].ToString());
				objCompetitionQuizOptionList.Add(objCompetitionQuizOption);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionQuizOptionList;
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

	public CoreWebList<CompetitionQuizOptionClass> fn_getCompetitionQuizOptionByKeys(string strCompetitionQuizOptionTitle)
	{
		CoreWebList<CompetitionQuizOptionClass> objCompetitionQuizOptionList = null;
		CompetitionQuizOptionClass objCompetitionQuizOption = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionQuizOptions WHERE CompetitionQuizOption_Title like '%' + @CompetitionQuizOption_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionQuizOption_Title", strCompetitionQuizOptionTitle);
			objReader = objCommand.ExecuteReader();
			objCompetitionQuizOptionList = new CoreWebList<CompetitionQuizOptionClass>();
			while (objReader.Read())
			{
				objCompetitionQuizOption = new CompetitionQuizOptionClass();
				objCompetitionQuizOption.iID = int.Parse(objReader["CompetitionQuizOption_ID"].ToString());
				objCompetitionQuizOption.iQuizID = int.Parse(objReader["CompetitionQuizOption_QuizID"].ToString());
				objCompetitionQuizOption.strTitle = objReader["CompetitionQuizOption_Title"].ToString();
				objCompetitionQuizOption.strLogo = objReader["CompetitionQuizOption_Logo"].ToString();
				objCompetitionQuizOption.bAnswer = bool.Parse(objReader["CompetitionQuizOption_Answer"].ToString());
				objCompetitionQuizOptionList.Add(objCompetitionQuizOption);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionQuizOptionList;
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

	public CoreWebList<CompetitionQuizOptionClass> fn_getCompetitionQuizOptionByQuizID(int iQuizID)
	{
		CoreWebList<CompetitionQuizOptionClass> objCompetitionQuizOptionList = null;
		CompetitionQuizOptionClass objCompetitionQuizOption = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionQuizOptions WHERE CompetitionQuizOption_QuizID=@CompetitionQuizOption_QuizID", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionQuizOption_QuizID", iQuizID);
			objReader = objCommand.ExecuteReader();
			objCompetitionQuizOptionList = new CoreWebList<CompetitionQuizOptionClass>();
			while (objReader.Read())
			{
				objCompetitionQuizOption = new CompetitionQuizOptionClass();
				objCompetitionQuizOption.iID = int.Parse(objReader["CompetitionQuizOption_ID"].ToString());
				objCompetitionQuizOption.iQuizID = int.Parse(objReader["CompetitionQuizOption_QuizID"].ToString());
				objCompetitionQuizOption.strTitle = objReader["CompetitionQuizOption_Title"].ToString();
				objCompetitionQuizOption.strLogo = objReader["CompetitionQuizOption_Logo"].ToString();
				objCompetitionQuizOption.bAnswer = bool.Parse(objReader["CompetitionQuizOption_Answer"].ToString());
				objCompetitionQuizOptionList.Add(objCompetitionQuizOption);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionQuizOptionList;
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

	public string fn_ChangeCompetitionQuizOptionAnswerStatus(CompetitionQuizOptionClass objCompetitionQuizOption)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_CompetitionQuizOptions SET CompetitionQuizOption_Answer=@CompetitionQuizOption_Answer WHERE CompetitionQuizOption_ID=@CompetitionQuizOption_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("CompetitionQuizOption_ID", objCompetitionQuizOption.iID);
			objCommand.Parameters.AddWithValue("CompetitionQuizOption_Answer", objCompetitionQuizOption.bAnswer);

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

}
