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
/// Summary description for DBEducationInterestClass
/// </summary>
public class DBEducationInterestClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveEducationInterest(EducationInterestClass objEducationInterest)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_EducationInterest (EducationInterest_Title) VALUES (@EducationInterest_Title)",objConnection) ;
			objCommand.Parameters.AddWithValue("@EducationInterest_Title", objEducationInterest.strTitle);

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

	public string fn_editEducationInterest(EducationInterestClass objEducationInterest)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_EducationInterest SET EducationInterest_Title=@EducationInterest_Title WHERE EducationInterest_ID=@EducationInterest_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@EducationInterest_ID", objEducationInterest.iID);
			objCommand.Parameters.AddWithValue("@EducationInterest_Title", objEducationInterest.strTitle);

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

	public string fn_deleteEducationInterest(int iEducationInterestID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_EducationInterest WHERE EducationInterest_ID=@EducationInterest_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@EducationInterest_ID", iEducationInterestID);

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

	public CoreWebList<EducationInterestClass> fn_getEducationInterestList()
	{
		CoreWebList<EducationInterestClass> objEducationInterestList = null;
		EducationInterestClass objEducationInterest = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_EducationInterest ORDER BY EducationInterest_Title ASC", objConnection);
			objReader = objCommand.ExecuteReader();
			objEducationInterestList = new CoreWebList<EducationInterestClass>();
			while (objReader.Read())
			{
				objEducationInterest = new EducationInterestClass();
				objEducationInterest.iID = int.Parse(objReader["EducationInterest_ID"].ToString());
				objEducationInterest.strTitle = objReader["EducationInterest_Title"].ToString();
				objEducationInterestList.Add(objEducationInterest);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEducationInterestList;
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

	public CoreWebList<EducationInterestClass> fn_getEducationInterestByID(int iEducationInterestID)
	{
		CoreWebList<EducationInterestClass> objEducationInterestList = null;
		EducationInterestClass objEducationInterest = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EducationInterest WHERE EducationInterest_ID=@EducationInterest_ID", objConnection);
			objCommand.Parameters.AddWithValue("@EducationInterest_ID", iEducationInterestID);
			objReader = objCommand.ExecuteReader();
			objEducationInterestList = new CoreWebList<EducationInterestClass>();
			if (objReader.Read())
			{
				objEducationInterest = new EducationInterestClass();
				objEducationInterest.iID = int.Parse(objReader["EducationInterest_ID"].ToString());
				objEducationInterest.strTitle = objReader["EducationInterest_Title"].ToString();
				objEducationInterestList.Add(objEducationInterest);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEducationInterestList;
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

	public CoreWebList<EducationInterestClass> fn_getEducationInterestByName(string strEducationInterestTitle)
	{
		CoreWebList<EducationInterestClass> objEducationInterestList = null;
		EducationInterestClass objEducationInterest = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EducationInterest WHERE EducationInterest_Title=@EducationInterest_Title", objConnection);
			objCommand.Parameters.AddWithValue("@EducationInterest_Title", strEducationInterestTitle);
			objReader = objCommand.ExecuteReader();
			objEducationInterestList = new CoreWebList<EducationInterestClass>();
			if (objReader.Read())
			{
				objEducationInterest = new EducationInterestClass();
				objEducationInterest.iID = int.Parse(objReader["EducationInterest_ID"].ToString());
				objEducationInterest.strTitle = objReader["EducationInterest_Title"].ToString();
				objEducationInterestList.Add(objEducationInterest);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEducationInterestList;
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

	public CoreWebList<EducationInterestClass> fn_getEducationInterestByKeys(string strEducationInterestTitle)
	{
		CoreWebList<EducationInterestClass> objEducationInterestList = null;
		EducationInterestClass objEducationInterest = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EducationInterest WHERE EducationInterest_Title like '%' + @EducationInterest_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@EducationInterest_Title", strEducationInterestTitle);
			objReader = objCommand.ExecuteReader();
			objEducationInterestList = new CoreWebList<EducationInterestClass>();
			while (objReader.Read())
			{
				objEducationInterest = new EducationInterestClass();
				objEducationInterest.iID = int.Parse(objReader["EducationInterest_ID"].ToString());
				objEducationInterest.strTitle = objReader["EducationInterest_Title"].ToString();
				objEducationInterestList.Add(objEducationInterest);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEducationInterestList;
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
