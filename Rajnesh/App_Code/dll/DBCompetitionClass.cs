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
/// Summary description for DBCompetitionClass
/// </summary>
public class DBCompetitionClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveCompetition(CompetitionClass objCompetition)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_Competitions (Competition_Type, Competition_Title, Competition_ShortDetails, Competition_Details, Competition_PrizeDetails, Competition_BgColor, Competition_Photo, Competition_Date, Competition_Active) VALUES (@Competition_Type, @Competition_Title, @Competition_ShortDetails, @Competition_Details, @Competition_PrizeDetails, @Competition_BgColor, @Competition_Photo, @Competition_Date, @Competition_Active)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Competition_Type", objCompetition.strType);
			objCommand.Parameters.AddWithValue("@Competition_Title", objCompetition.strTitle);
			objCommand.Parameters.AddWithValue("@Competition_ShortDetails", objCompetition.strShortDetails);
			objCommand.Parameters.AddWithValue("@Competition_Details", objCompetition.strDetails);
			objCommand.Parameters.AddWithValue("@Competition_PrizeDetails", objCompetition.strPrizeDetails);
			objCommand.Parameters.AddWithValue("@Competition_BgColor", objCompetition.strBgColor);
			objCommand.Parameters.AddWithValue("@Competition_Photo", objCompetition.strPhoto);
			objCommand.Parameters.AddWithValue("@Competition_Date", objCompetition.dtDate);
			objCommand.Parameters.AddWithValue("@Competition_Active", objCompetition.bActive);

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

	public string fn_editCompetition(CompetitionClass objCompetition)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Competitions SET Competition_Type=@Competition_Type, Competition_Title=@Competition_Title, Competition_ShortDetails=@Competition_ShortDetails, Competition_Details=@Competition_Details, Competition_PrizeDetails=@Competition_PrizeDetails, Competition_BgColor=@Competition_BgColor, Competition_Photo=@Competition_Photo, Competition_Date=@Competition_Date, Competition_Active=@Competition_Active WHERE Competition_ID=@Competition_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Competition_ID", objCompetition.iID);
			objCommand.Parameters.AddWithValue("@Competition_Type", objCompetition.strType);
			objCommand.Parameters.AddWithValue("@Competition_Title", objCompetition.strTitle);
			objCommand.Parameters.AddWithValue("@Competition_ShortDetails", objCompetition.strShortDetails);
			objCommand.Parameters.AddWithValue("@Competition_Details", objCompetition.strDetails);
			objCommand.Parameters.AddWithValue("@Competition_PrizeDetails", objCompetition.strPrizeDetails);
			objCommand.Parameters.AddWithValue("@Competition_BgColor", objCompetition.strBgColor);
			objCommand.Parameters.AddWithValue("@Competition_Photo", objCompetition.strPhoto);
			objCommand.Parameters.AddWithValue("@Competition_Date", objCompetition.dtDate);
			objCommand.Parameters.AddWithValue("@Competition_Active", objCompetition.bActive);

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

	public string fn_deleteCompetition(int iCompetitionID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Competitions WHERE Competition_ID=@Competition_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Competition_ID", iCompetitionID);

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

	public CoreWebList<CompetitionClass> fn_getCompetitionList()
	{
		CoreWebList<CompetitionClass> objCompetitionList = null;
		CompetitionClass objCompetition = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Competitions", objConnection);
			objReader = objCommand.ExecuteReader();
			objCompetitionList = new CoreWebList<CompetitionClass>();
			while (objReader.Read())
			{
				objCompetition = new CompetitionClass();
				objCompetition.iID = int.Parse(objReader["Competition_ID"].ToString());
				objCompetition.strType = objReader["Competition_Type"].ToString();
				objCompetition.strTitle = objReader["Competition_Title"].ToString();
				objCompetition.strShortDetails = objReader["Competition_ShortDetails"].ToString();
				objCompetition.strDetails = objReader["Competition_Details"].ToString();
				objCompetition.strPrizeDetails = objReader["Competition_PrizeDetails"].ToString();
				objCompetition.strBgColor = objReader["Competition_BgColor"].ToString();
				objCompetition.strPhoto = objReader["Competition_Photo"].ToString();
				objCompetition.dtDate = DateTime.Parse(objReader["Competition_Date"].ToString());
				objCompetition.bActive = bool.Parse(objReader["Competition_Active"].ToString());
				objCompetitionList.Add(objCompetition);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionList;
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

    public CoreWebList<CompetitionClass> fn_getRandomCompetitionList()
    {
        CoreWebList<CompetitionClass> objCompetitionList = null;
        CompetitionClass objCompetition = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 1 * FROM tbl_Competitions WHERE Competition_Active='true' ORDER BY NEWID()", objConnection);
            objReader = objCommand.ExecuteReader();
            objCompetitionList = new CoreWebList<CompetitionClass>();
            while (objReader.Read())
            {
                objCompetition = new CompetitionClass();
                objCompetition.iID = int.Parse(objReader["Competition_ID"].ToString());
                objCompetition.strType = objReader["Competition_Type"].ToString();
                objCompetition.strTitle = objReader["Competition_Title"].ToString();
                objCompetition.strShortDetails = objReader["Competition_ShortDetails"].ToString();
                objCompetition.strDetails = objReader["Competition_Details"].ToString();
                objCompetition.strPrizeDetails = objReader["Competition_PrizeDetails"].ToString();
                objCompetition.strBgColor = objReader["Competition_BgColor"].ToString();
                objCompetition.strPhoto = objReader["Competition_Photo"].ToString();
                objCompetition.dtDate = DateTime.Parse(objReader["Competition_Date"].ToString());
                objCompetition.bActive = bool.Parse(objReader["Competition_Active"].ToString());
                objCompetitionList.Add(objCompetition);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCompetitionList;
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

	public CoreWebList<CompetitionClass> fn_getCompetitionByID(int iCompetitionID)
	{
		CoreWebList<CompetitionClass> objCompetitionList = null;
		CompetitionClass objCompetition = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Competitions WHERE Competition_ID=@Competition_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Competition_ID", iCompetitionID);
			objReader = objCommand.ExecuteReader();
			objCompetitionList = new CoreWebList<CompetitionClass>();
			if (objReader.Read())
			{
				objCompetition = new CompetitionClass();
				objCompetition.iID = int.Parse(objReader["Competition_ID"].ToString());
				objCompetition.strType = objReader["Competition_Type"].ToString();
				objCompetition.strTitle = objReader["Competition_Title"].ToString();
				objCompetition.strShortDetails = objReader["Competition_ShortDetails"].ToString();
				objCompetition.strDetails = objReader["Competition_Details"].ToString();
				objCompetition.strPrizeDetails = objReader["Competition_PrizeDetails"].ToString();
				objCompetition.strBgColor = objReader["Competition_BgColor"].ToString();
				objCompetition.strPhoto = objReader["Competition_Photo"].ToString();
				objCompetition.dtDate = DateTime.Parse(objReader["Competition_Date"].ToString());
				objCompetition.bActive = bool.Parse(objReader["Competition_Active"].ToString());
				objCompetitionList.Add(objCompetition);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionList;
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

    public CoreWebList<CompetitionClass> fn_getOtherCompetitionByID(int iCompetitionID)
    {
        CoreWebList<CompetitionClass> objCompetitionList = null;
        CompetitionClass objCompetition = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Competitions WHERE Competition_ID != @Competition_ID", objConnection);
            objCommand.Parameters.AddWithValue("@Competition_ID", iCompetitionID);
            objReader = objCommand.ExecuteReader();
            objCompetitionList = new CoreWebList<CompetitionClass>();
            while (objReader.Read())
            {
                objCompetition = new CompetitionClass();
                objCompetition.iID = int.Parse(objReader["Competition_ID"].ToString());
                objCompetition.strType = objReader["Competition_Type"].ToString();
                objCompetition.strTitle = objReader["Competition_Title"].ToString();
                objCompetition.strShortDetails = objReader["Competition_ShortDetails"].ToString();
                objCompetition.strDetails = objReader["Competition_Details"].ToString();
                objCompetition.strPrizeDetails = objReader["Competition_PrizeDetails"].ToString();
                objCompetition.strBgColor = objReader["Competition_BgColor"].ToString();
                objCompetition.strPhoto = objReader["Competition_Photo"].ToString();
                objCompetition.dtDate = DateTime.Parse(objReader["Competition_Date"].ToString());
                objCompetition.bActive = bool.Parse(objReader["Competition_Active"].ToString());
                objCompetitionList.Add(objCompetition);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCompetitionList;
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

	public CoreWebList<CompetitionClass> fn_getCompetitionByName(string strCompetitionTitle)
	{
		CoreWebList<CompetitionClass> objCompetitionList = null;
		CompetitionClass objCompetition = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Competitions WHERE Competition_Title=@Competition_Title", objConnection);
			objCommand.Parameters.AddWithValue("@Competition_Title", strCompetitionTitle);
			objReader = objCommand.ExecuteReader();
			objCompetitionList = new CoreWebList<CompetitionClass>();
			if (objReader.Read())
			{
				objCompetition = new CompetitionClass();
				objCompetition.iID = int.Parse(objReader["Competition_ID"].ToString());
				objCompetition.strType = objReader["Competition_Type"].ToString();
				objCompetition.strTitle = objReader["Competition_Title"].ToString();
				objCompetition.strShortDetails = objReader["Competition_ShortDetails"].ToString();
				objCompetition.strDetails = objReader["Competition_Details"].ToString();
				objCompetition.strPrizeDetails = objReader["Competition_PrizeDetails"].ToString();
				objCompetition.strBgColor = objReader["Competition_BgColor"].ToString();
				objCompetition.strPhoto = objReader["Competition_Photo"].ToString();
				objCompetition.dtDate = DateTime.Parse(objReader["Competition_Date"].ToString());
				objCompetition.bActive = bool.Parse(objReader["Competition_Active"].ToString());
				objCompetitionList.Add(objCompetition);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionList;
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

	public CoreWebList<CompetitionClass> fn_getCompetitionByKeys(string strCompetitionTitle)
	{
		CoreWebList<CompetitionClass> objCompetitionList = null;
		CompetitionClass objCompetition = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Competitions WHERE Competition_Title like '%' + @Competition_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Competition_Title", strCompetitionTitle);
			objReader = objCommand.ExecuteReader();
			objCompetitionList = new CoreWebList<CompetitionClass>();
			while (objReader.Read())
			{
				objCompetition = new CompetitionClass();
				objCompetition.iID = int.Parse(objReader["Competition_ID"].ToString());
				objCompetition.strType = objReader["Competition_Type"].ToString();
				objCompetition.strTitle = objReader["Competition_Title"].ToString();
				objCompetition.strShortDetails = objReader["Competition_ShortDetails"].ToString();
				objCompetition.strDetails = objReader["Competition_Details"].ToString();
				objCompetition.strPrizeDetails = objReader["Competition_PrizeDetails"].ToString();
				objCompetition.strBgColor = objReader["Competition_BgColor"].ToString();
				objCompetition.strPhoto = objReader["Competition_Photo"].ToString();
				objCompetition.dtDate = DateTime.Parse(objReader["Competition_Date"].ToString());
				objCompetition.bActive = bool.Parse(objReader["Competition_Active"].ToString());
				objCompetitionList.Add(objCompetition);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionList;
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

	public string fn_ChangeCompetitionActiveStatus(CompetitionClass objCompetition)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Competitions SET Competition_Active=@Competition_Active WHERE Competition_ID=@Competition_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("Competition_ID", objCompetition.iID);
			objCommand.Parameters.AddWithValue("Competition_Active", objCompetition.bActive);

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
