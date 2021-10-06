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
/// Summary description for DBCityClass
/// </summary>
public class DBCityClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveCity(CityClass objCity)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_City (City_StateID, City_Title, City_Desc, City_Photo) VALUES (@City_StateID, @City_Title, @City_Desc, @City_Photo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@City_StateID", objCity.iStateID);
			objCommand.Parameters.AddWithValue("@City_Title", objCity.strTitle);
			objCommand.Parameters.AddWithValue("@City_Desc", objCity.strDesc);
			objCommand.Parameters.AddWithValue("@City_Photo", objCity.strPhoto);

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

	public string fn_editCity(CityClass objCity)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_City SET City_StateID=@City_StateID, City_Title=@City_Title, City_Desc=@City_Desc, City_Photo=@City_Photo WHERE City_ID=@City_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@City_ID", objCity.iID);
			objCommand.Parameters.AddWithValue("@City_StateID", objCity.iStateID);
			objCommand.Parameters.AddWithValue("@City_Title", objCity.strTitle);
			objCommand.Parameters.AddWithValue("@City_Desc", objCity.strDesc);
			objCommand.Parameters.AddWithValue("@City_Photo", objCity.strPhoto);

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

	public string fn_deleteCity(int iCityID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_City WHERE City_ID=@City_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@City_ID", iCityID);

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

	public CoreWebList<CityClass> fn_getCityList()
	{
		CoreWebList<CityClass> objCityList = null;
		CityClass objCity = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_City ORDER BY City_Title ASC", objConnection);
			objReader = objCommand.ExecuteReader();
			objCityList = new CoreWebList<CityClass>();
			while (objReader.Read())
			{
				objCity = new CityClass();
				objCity.iID = int.Parse(objReader["City_ID"].ToString());
				objCity.iStateID = int.Parse(objReader["City_StateID"].ToString());
				objCity.strTitle = objReader["City_Title"].ToString();
				objCity.strDesc = objReader["City_Desc"].ToString();
				objCity.strPhoto = objReader["City_Photo"].ToString();
				objCityList.Add(objCity);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCityList;
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

	public CoreWebList<CityClass> fn_getCityByID(int iCityID)
	{
		CoreWebList<CityClass> objCityList = null;
		CityClass objCity = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_City WHERE City_ID=@City_ID", objConnection);
			objCommand.Parameters.AddWithValue("@City_ID", iCityID);
			objReader = objCommand.ExecuteReader();
			objCityList = new CoreWebList<CityClass>();
			if (objReader.Read())
			{
				objCity = new CityClass();
				objCity.iID = int.Parse(objReader["City_ID"].ToString());
				objCity.iStateID = int.Parse(objReader["City_StateID"].ToString());
				objCity.strTitle = objReader["City_Title"].ToString();
				objCity.strDesc = objReader["City_Desc"].ToString();
				objCity.strPhoto = objReader["City_Photo"].ToString();
				objCityList.Add(objCity);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCityList;
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

	public CoreWebList<CityClass> fn_getCityByName(string strCityTitle)
	{
		CoreWebList<CityClass> objCityList = null;
		CityClass objCity = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_City WHERE City_Title=@City_Title", objConnection);
			objCommand.Parameters.AddWithValue("@City_Title", strCityTitle);
			objReader = objCommand.ExecuteReader();
			objCityList = new CoreWebList<CityClass>();
			if (objReader.Read())
			{
				objCity = new CityClass();
				objCity.iID = int.Parse(objReader["City_ID"].ToString());
				objCity.iStateID = int.Parse(objReader["City_StateID"].ToString());
				objCity.strTitle = objReader["City_Title"].ToString();
				objCity.strDesc = objReader["City_Desc"].ToString();
				objCity.strPhoto = objReader["City_Photo"].ToString();
				objCityList.Add(objCity);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCityList;
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

	public CoreWebList<CityClass> fn_getCityByKeys(string strCityTitle)
	{
		CoreWebList<CityClass> objCityList = null;
		CityClass objCity = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_City WHERE City_Title like '%' + @City_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@City_Title", strCityTitle);
			objReader = objCommand.ExecuteReader();
			objCityList = new CoreWebList<CityClass>();
			while (objReader.Read())
			{
				objCity = new CityClass();
				objCity.iID = int.Parse(objReader["City_ID"].ToString());
				objCity.iStateID = int.Parse(objReader["City_StateID"].ToString());
				objCity.strTitle = objReader["City_Title"].ToString();
				objCity.strDesc = objReader["City_Desc"].ToString();
				objCity.strPhoto = objReader["City_Photo"].ToString();
				objCityList.Add(objCity);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCityList;
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

	public CoreWebList<CityClass> fn_getCityByStateID(int iStateID)
	{
		CoreWebList<CityClass> objCityList = null;
		CityClass objCity = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_City WHERE City_StateID=@City_StateID", objConnection);
			objCommand.Parameters.AddWithValue("@City_StateID", iStateID);
			objReader = objCommand.ExecuteReader();
			objCityList = new CoreWebList<CityClass>();
			while (objReader.Read())
			{
				objCity = new CityClass();
				objCity.iID = int.Parse(objReader["City_ID"].ToString());
				objCity.iStateID = int.Parse(objReader["City_StateID"].ToString());
				objCity.strTitle = objReader["City_Title"].ToString();
				objCity.strDesc = objReader["City_Desc"].ToString();
				objCity.strPhoto = objReader["City_Photo"].ToString();
				objCityList.Add(objCity);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCityList;
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
