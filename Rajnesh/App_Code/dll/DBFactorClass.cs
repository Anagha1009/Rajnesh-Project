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
/// Summary description for DBFactorClass
/// </summary>
public class DBFactorClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveFactor(FactorClass objFactor)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_Factors (Factor_HeadingID, Factor_Title) VALUES (@Factor_HeadingID, @Factor_Title)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Factor_HeadingID", objFactor.iHeadingID);
			objCommand.Parameters.AddWithValue("@Factor_Title", objFactor.strTitle);

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

	public string fn_editFactor(FactorClass objFactor)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Factors SET Factor_Title=@Factor_Title WHERE Factor_ID=@Factor_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Factor_ID", objFactor.iID);
            objCommand.Parameters.AddWithValue("@Factor_Title", objFactor.strTitle);

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

	public string fn_deleteFactor(int iFactorID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Factors WHERE Factor_ID=@Factor_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Factor_ID", iFactorID);

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

	public CoreWebList<FactorClass> fn_getFactorList()
	{
		CoreWebList<FactorClass> objFactorList = null;
		FactorClass objFactor = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Factors", objConnection);
			objReader = objCommand.ExecuteReader();
			objFactorList = new CoreWebList<FactorClass>();
			while (objReader.Read())
			{
				objFactor = new FactorClass();
				objFactor.iID = int.Parse(objReader["Factor_ID"].ToString());
				objFactor.iHeadingID = int.Parse(objReader["Factor_HeadingID"].ToString());
				objFactor.strTitle = objReader["Factor_Title"].ToString();
				objFactorList.Add(objFactor);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objFactorList;
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

	public CoreWebList<FactorClass> fn_getFactorByID(int iFactorID)
	{
		CoreWebList<FactorClass> objFactorList = null;
		FactorClass objFactor = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Factors WHERE Factor_ID=@Factor_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Factor_ID", iFactorID);
			objReader = objCommand.ExecuteReader();
			objFactorList = new CoreWebList<FactorClass>();
			if (objReader.Read())
			{
				objFactor = new FactorClass();
				objFactor.iID = int.Parse(objReader["Factor_ID"].ToString());
				objFactor.iHeadingID = int.Parse(objReader["Factor_HeadingID"].ToString());
				objFactor.strTitle = objReader["Factor_Title"].ToString();
				objFactorList.Add(objFactor);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objFactorList;
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

	public CoreWebList<FactorClass> fn_getFactorByName(string strFactorTitle)
	{
		CoreWebList<FactorClass> objFactorList = null;
		FactorClass objFactor = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Factors WHERE Factor_Title=@Factor_Title", objConnection);
			objCommand.Parameters.AddWithValue("@Factor_Title", strFactorTitle);
			objReader = objCommand.ExecuteReader();
			objFactorList = new CoreWebList<FactorClass>();
			if (objReader.Read())
			{
				objFactor = new FactorClass();
				objFactor.iID = int.Parse(objReader["Factor_ID"].ToString());
				objFactor.iHeadingID = int.Parse(objReader["Factor_HeadingID"].ToString());
				objFactor.strTitle = objReader["Factor_Title"].ToString();
				objFactorList.Add(objFactor);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objFactorList;
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

	public CoreWebList<FactorClass> fn_getFactorByKeys(string strFactorTitle)
	{
		CoreWebList<FactorClass> objFactorList = null;
		FactorClass objFactor = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Factors WHERE Factor_Title like '%' + @Factor_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Factor_Title", strFactorTitle);
			objReader = objCommand.ExecuteReader();
			objFactorList = new CoreWebList<FactorClass>();
			while (objReader.Read())
			{
				objFactor = new FactorClass();
				objFactor.iID = int.Parse(objReader["Factor_ID"].ToString());
				objFactor.iHeadingID = int.Parse(objReader["Factor_HeadingID"].ToString());
				objFactor.strTitle = objReader["Factor_Title"].ToString();
				objFactorList.Add(objFactor);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objFactorList;
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

	public CoreWebList<FactorClass> fn_getFactorByHeadingID(int iHeadingID)
	{
		CoreWebList<FactorClass> objFactorList = null;
		FactorClass objFactor = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Factors WHERE Factor_HeadingID=@Factor_HeadingID ORDER BY Factor_Title ASC", objConnection);
			objCommand.Parameters.AddWithValue("@Factor_HeadingID", iHeadingID);
			objReader = objCommand.ExecuteReader();
			objFactorList = new CoreWebList<FactorClass>();
			while (objReader.Read())
			{
				objFactor = new FactorClass();
				objFactor.iID = int.Parse(objReader["Factor_ID"].ToString());
				objFactor.iHeadingID = int.Parse(objReader["Factor_HeadingID"].ToString());
				objFactor.strTitle = objReader["Factor_Title"].ToString();
				objFactorList.Add(objFactor);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objFactorList;
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
