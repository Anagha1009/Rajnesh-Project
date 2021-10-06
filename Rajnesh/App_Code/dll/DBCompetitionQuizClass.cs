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
/// Summary description for DBCompetitionQuizClass
/// </summary>
public class DBCompetitionQuizClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveCompetitionQuiz(CompetitionQuizClass objCompetitionQuiz)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_CompetitionQuiz (CompetitionQuiz_CompetitionID, CompetitionQuiz_Title, CompetitionQuiz_Icon) VALUES (@CompetitionQuiz_CompetitionID, @CompetitionQuiz_Title, @CompetitionQuiz_Icon)",objConnection) ;
			objCommand.Parameters.AddWithValue("@CompetitionQuiz_CompetitionID", objCompetitionQuiz.iCompetitionID);
			objCommand.Parameters.AddWithValue("@CompetitionQuiz_Title", objCompetitionQuiz.strTitle);
			objCommand.Parameters.AddWithValue("@CompetitionQuiz_Icon", objCompetitionQuiz.strIcon);

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

	public string fn_editCompetitionQuiz(CompetitionQuizClass objCompetitionQuiz)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_CompetitionQuiz SET CompetitionQuiz_Title=@CompetitionQuiz_Title, CompetitionQuiz_Icon=@CompetitionQuiz_Icon WHERE CompetitionQuiz_ID=@CompetitionQuiz_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CompetitionQuiz_ID", objCompetitionQuiz.iID);
            objCommand.Parameters.AddWithValue("@CompetitionQuiz_Title", objCompetitionQuiz.strTitle);
            objCommand.Parameters.AddWithValue("@CompetitionQuiz_Icon", objCompetitionQuiz.strIcon);

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

	public string fn_deleteCompetitionQuiz(int iCompetitionQuizID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_CompetitionQuiz WHERE CompetitionQuiz_ID=@CompetitionQuiz_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CompetitionQuiz_ID", iCompetitionQuizID);

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

	public CoreWebList<CompetitionQuizClass> fn_getCompetitionQuizList()
	{
		CoreWebList<CompetitionQuizClass> objCompetitionQuizList = null;
		CompetitionQuizClass objCompetitionQuiz = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionQuiz", objConnection);
			objReader = objCommand.ExecuteReader();
			objCompetitionQuizList = new CoreWebList<CompetitionQuizClass>();
			while (objReader.Read())
			{
				objCompetitionQuiz = new CompetitionQuizClass();
				objCompetitionQuiz.iID = int.Parse(objReader["CompetitionQuiz_ID"].ToString());
				objCompetitionQuiz.iCompetitionID = int.Parse(objReader["CompetitionQuiz_CompetitionID"].ToString());
				objCompetitionQuiz.strTitle = objReader["CompetitionQuiz_Title"].ToString();
				objCompetitionQuiz.strIcon = objReader["CompetitionQuiz_Icon"].ToString();
				objCompetitionQuizList.Add(objCompetitionQuiz);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionQuizList;
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

	public CoreWebList<CompetitionQuizClass> fn_getCompetitionQuizByID(int iCompetitionQuizID)
	{
		CoreWebList<CompetitionQuizClass> objCompetitionQuizList = null;
		CompetitionQuizClass objCompetitionQuiz = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionQuiz WHERE CompetitionQuiz_ID=@CompetitionQuiz_ID", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionQuiz_ID", iCompetitionQuizID);
			objReader = objCommand.ExecuteReader();
			objCompetitionQuizList = new CoreWebList<CompetitionQuizClass>();
			if (objReader.Read())
			{
				objCompetitionQuiz = new CompetitionQuizClass();
				objCompetitionQuiz.iID = int.Parse(objReader["CompetitionQuiz_ID"].ToString());
				objCompetitionQuiz.iCompetitionID = int.Parse(objReader["CompetitionQuiz_CompetitionID"].ToString());
				objCompetitionQuiz.strTitle = objReader["CompetitionQuiz_Title"].ToString();
				objCompetitionQuiz.strIcon = objReader["CompetitionQuiz_Icon"].ToString();
				objCompetitionQuizList.Add(objCompetitionQuiz);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionQuizList;
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

	public CoreWebList<CompetitionQuizClass> fn_getCompetitionQuizByName(string strCompetitionQuizTitle)
	{
		CoreWebList<CompetitionQuizClass> objCompetitionQuizList = null;
		CompetitionQuizClass objCompetitionQuiz = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionQuiz WHERE CompetitionQuiz_Title=@CompetitionQuiz_Title", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionQuiz_Title", strCompetitionQuizTitle);
			objReader = objCommand.ExecuteReader();
			objCompetitionQuizList = new CoreWebList<CompetitionQuizClass>();
			if (objReader.Read())
			{
				objCompetitionQuiz = new CompetitionQuizClass();
				objCompetitionQuiz.iID = int.Parse(objReader["CompetitionQuiz_ID"].ToString());
				objCompetitionQuiz.iCompetitionID = int.Parse(objReader["CompetitionQuiz_CompetitionID"].ToString());
				objCompetitionQuiz.strTitle = objReader["CompetitionQuiz_Title"].ToString();
				objCompetitionQuiz.strIcon = objReader["CompetitionQuiz_Icon"].ToString();
				objCompetitionQuizList.Add(objCompetitionQuiz);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionQuizList;
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

	public CoreWebList<CompetitionQuizClass> fn_getCompetitionQuizByKeys(string strCompetitionQuizTitle)
	{
		CoreWebList<CompetitionQuizClass> objCompetitionQuizList = null;
		CompetitionQuizClass objCompetitionQuiz = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionQuiz WHERE CompetitionQuiz_Title like '%' + @CompetitionQuiz_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionQuiz_Title", strCompetitionQuizTitle);
			objReader = objCommand.ExecuteReader();
			objCompetitionQuizList = new CoreWebList<CompetitionQuizClass>();
			while (objReader.Read())
			{
				objCompetitionQuiz = new CompetitionQuizClass();
				objCompetitionQuiz.iID = int.Parse(objReader["CompetitionQuiz_ID"].ToString());
				objCompetitionQuiz.iCompetitionID = int.Parse(objReader["CompetitionQuiz_CompetitionID"].ToString());
				objCompetitionQuiz.strTitle = objReader["CompetitionQuiz_Title"].ToString();
				objCompetitionQuiz.strIcon = objReader["CompetitionQuiz_Icon"].ToString();
				objCompetitionQuizList.Add(objCompetitionQuiz);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionQuizList;
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

	public CoreWebList<CompetitionQuizClass> fn_getCompetitionQuizByCompetitionID(int iCompetitionID)
	{
		CoreWebList<CompetitionQuizClass> objCompetitionQuizList = null;
		CompetitionQuizClass objCompetitionQuiz = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionQuiz WHERE CompetitionQuiz_CompetitionID=@CompetitionQuiz_CompetitionID", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionQuiz_CompetitionID", iCompetitionID);
			objReader = objCommand.ExecuteReader();
			objCompetitionQuizList = new CoreWebList<CompetitionQuizClass>();
			while (objReader.Read())
			{
				objCompetitionQuiz = new CompetitionQuizClass();
				objCompetitionQuiz.iID = int.Parse(objReader["CompetitionQuiz_ID"].ToString());
				objCompetitionQuiz.iCompetitionID = int.Parse(objReader["CompetitionQuiz_CompetitionID"].ToString());
				objCompetitionQuiz.strTitle = objReader["CompetitionQuiz_Title"].ToString();
				objCompetitionQuiz.strIcon = objReader["CompetitionQuiz_Icon"].ToString();
				objCompetitionQuizList.Add(objCompetitionQuiz);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionQuizList;
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

    public CoreWebList<CompetitionQuizClass> fn_getNextCompetitionQuiz(int iCompetitionId, int iID)
    {
        CoreWebList<CompetitionQuizClass> objCompetitionQuizList = null;
        CompetitionQuizClass objCompetitionQuiz = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 1 * FROM tbl_CompetitionQuiz WHERE CompetitionQuiz_ID > @CompetitionQuiz_ID AND CompetitionQuiz_CompetitionID=@CompetitionQuiz_CompetitionID ORDER BY CompetitionQuiz_ID ASC", objConnection);
            objCommand.Parameters.AddWithValue("@CompetitionQuiz_ID", iID);
            objCommand.Parameters.AddWithValue("@CompetitionQuiz_CompetitionID", iCompetitionId);
            objReader = objCommand.ExecuteReader();
            objCompetitionQuizList = new CoreWebList<CompetitionQuizClass>();
            while (objReader.Read())
            {
                objCompetitionQuiz = new CompetitionQuizClass();
                objCompetitionQuiz.iID = int.Parse(objReader["CompetitionQuiz_ID"].ToString());
                objCompetitionQuiz.iCompetitionID = int.Parse(objReader["CompetitionQuiz_CompetitionID"].ToString());
                objCompetitionQuiz.strTitle = objReader["CompetitionQuiz_Title"].ToString();
                objCompetitionQuiz.strIcon = objReader["CompetitionQuiz_Icon"].ToString();
                objCompetitionQuizList.Add(objCompetitionQuiz);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCompetitionQuizList;
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
