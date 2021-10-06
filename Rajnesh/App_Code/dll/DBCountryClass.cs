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
/// Summary description for DBCountryClass
/// </summary>
public class DBCountryClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveCountry(CountryClass objCountry)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_Country (Country_Title, Country_Details, Country_Photo) VALUES (@Country_Title, @Country_Details, @Country_Photo)", objConnection);
			objCommand.Parameters.AddWithValue("@Country_Title", objCountry.strTitle);
            objCommand.Parameters.AddWithValue("@Country_Details", objCountry.strDetails);
			objCommand.Parameters.AddWithValue("@Country_Photo", objCountry.strPhoto);

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

	public string fn_editCountry(CountryClass objCountry)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_Country SET Country_Title=@Country_Title, Country_Details=@Country_Details, Country_Photo=@Country_Photo WHERE Country_ID=@Country_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Country_ID", objCountry.iID);
			objCommand.Parameters.AddWithValue("@Country_Title", objCountry.strTitle);
            objCommand.Parameters.AddWithValue("@Country_Details", objCountry.strDetails);
			objCommand.Parameters.AddWithValue("@Country_Photo", objCountry.strPhoto);

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

	public string fn_deleteCountry(int iCountryID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Country WHERE Country_ID=@Country_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Country_ID", iCountryID);

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

	public CoreWebList<CountryClass> fn_getCountryList()
	{
		CoreWebList<CountryClass> objCountryList = null;
		CountryClass objCountry = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Country", objConnection);
			objReader = objCommand.ExecuteReader();
			objCountryList = new CoreWebList<CountryClass>();
			while (objReader.Read())
			{
				objCountry = new CountryClass();
				objCountry.iID = int.Parse(objReader["Country_ID"].ToString());
				objCountry.strTitle = objReader["Country_Title"].ToString();
                objCountry.strDetails = objReader["Country_Details"].ToString();
				objCountry.strPhoto = objReader["Country_Photo"].ToString();
				objCountryList.Add(objCountry);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCountryList;
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

	public CoreWebList<CountryClass> fn_getCountryByID(int iCountryID)
	{
		CoreWebList<CountryClass> objCountryList = null;
		CountryClass objCountry = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Country WHERE Country_ID=@Country_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Country_ID", iCountryID);
			objReader = objCommand.ExecuteReader();
			objCountryList = new CoreWebList<CountryClass>();
			if (objReader.Read())
			{
				objCountry = new CountryClass();
				objCountry.iID = int.Parse(objReader["Country_ID"].ToString());
				objCountry.strTitle = objReader["Country_Title"].ToString();
                objCountry.strDetails = objReader["Country_Details"].ToString();
				objCountry.strPhoto = objReader["Country_Photo"].ToString();
				objCountryList.Add(objCountry);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCountryList;
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

	public CoreWebList<CountryClass> fn_getCountryByName(string strCountryTitle)
	{
		CoreWebList<CountryClass> objCountryList = null;
		CountryClass objCountry = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Country WHERE Country_Title=@Country_Title", objConnection);
			objCommand.Parameters.AddWithValue("@Country_Title", strCountryTitle);
			objReader = objCommand.ExecuteReader();
			objCountryList = new CoreWebList<CountryClass>();
			if (objReader.Read())
			{
				objCountry = new CountryClass();
				objCountry.iID = int.Parse(objReader["Country_ID"].ToString());
				objCountry.strTitle = objReader["Country_Title"].ToString();
                objCountry.strDetails = objReader["Country_Details"].ToString();
				objCountry.strPhoto = objReader["Country_Photo"].ToString();
				objCountryList.Add(objCountry);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCountryList;
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

	public CoreWebList<CountryClass> fn_getCountryByKeys(string strCountryTitle)
	{
		CoreWebList<CountryClass> objCountryList = null;
		CountryClass objCountry = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Country WHERE Country_Title like '%' + @Country_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Country_Title", strCountryTitle);
			objReader = objCommand.ExecuteReader();
			objCountryList = new CoreWebList<CountryClass>();
			while (objReader.Read())
			{
				objCountry = new CountryClass();
				objCountry.iID = int.Parse(objReader["Country_ID"].ToString());
				objCountry.strTitle = objReader["Country_Title"].ToString();
                objCountry.strDetails = objReader["Country_Details"].ToString();
				objCountry.strPhoto = objReader["Country_Photo"].ToString();
				objCountryList.Add(objCountry);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCountryList;
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
