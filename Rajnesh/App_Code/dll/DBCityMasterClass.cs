using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using yo_lib;

/// <summary>
/// Summary description for DBCityMasterClass
/// </summary>
public class DBCityMasterClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    public string fn_saveCity(string strCityName, int iCountryID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_City (city_title,city_countryID) VALUES (@name,@iCountryID)", objConnection);
            objCommand.Parameters.AddWithValue("@name", strCityName);
            objCommand.Parameters.AddWithValue("@iCountryID", iCountryID);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been inserted";
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

    public string fn_editCity(int iCityID, string strCityName, int iCountryID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_City SET city_title = @name,city_countryID = @iCountryID WHERE city_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@name", strCityName);
            objCommand.Parameters.AddWithValue("@iCountryID", iCountryID);
            objCommand.Parameters.AddWithValue("@ID", iCityID);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been updated";
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
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_City WHERE city_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iCityID);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been deleted";
            }
            else
            {
                return "ERROR : SQL Exception";
            }
        }
        catch (Exception ex)
        {
            //ErrorClass objError = new ErrorClass();
            //objError.fn_LogError(ex.Message, ex.StackTrace, 1);

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


    public CoreWebList<CityMasterClass> fn_getCityList()
    {
        CoreWebList<CityMasterClass> objCityList = null;
        CityMasterClass objCity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strQuery = "SELECT edu_City.city_id , edu_City.city_title , edu_City.city_countryID ,edu_Country.country_title FROM edu_City INNER JOIN edu_Country ON edu_City.city_countryID = edu_Country.country_id ORDER BY city_title";

            objCommand = new SqlCommand(strQuery, objConnection);

            objReader = objCommand.ExecuteReader();

            objCityList = new CoreWebList<CityMasterClass>();

            while (objReader.Read())
            {
                objCity = new CityMasterClass();
                objCity.iID = int.Parse(objReader["city_id"].ToString());
                objCity.strCityName = objReader["city_title"].ToString();
                objCity.iCountryID = int.Parse(objReader["city_countryID"].ToString());
                objCity.strCountryName = objReader["country_title"].ToString();
                
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

    public CoreWebList<CityMasterClass> fn_getJobCityList()
    {
        CoreWebList<CityMasterClass> objCityList = null;
        CityMasterClass objCity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strQuery = "SELECT * FROM edu_City WHERE city_id IN(Select DISTINCT(Job_LocationID) FROM edu_Jobs) ORDER BY city_title";

            objCommand = new SqlCommand(strQuery, objConnection);

            objReader = objCommand.ExecuteReader();

            objCityList = new CoreWebList<CityMasterClass>();

            while (objReader.Read())
            {
                objCity = new CityMasterClass();
                objCity.iID = int.Parse(objReader["city_id"].ToString());
                objCity.strCityName = objReader["city_title"].ToString();

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

    public CoreWebList<CityMasterClass> fn_getCityListByID(int iCityID)
    {
        CoreWebList<CityMasterClass> objCityList = null;
        CityMasterClass objCity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strQuery = "SELECT edu_City.city_id , edu_City.city_title , edu_City.city_countryID ,edu_City.city_countryID ,edu_Country.country_title FROM edu_City INNER JOIN edu_Country ON edu_City.city_countryID = edu_Country.country_id WHERE edu_City.city_id = @iCityID";

            objCommand = new SqlCommand(strQuery, objConnection);

            objCommand.Parameters.AddWithValue("@iCityID", iCityID);

            objReader = objCommand.ExecuteReader();

            objCityList = new CoreWebList<CityMasterClass>();

            while (objReader.Read())
            {
                objCity = new CityMasterClass();
                objCity.iID = int.Parse(objReader["city_id"].ToString());
                objCity.strCityName = objReader["city_title"].ToString();
                objCity.iCountryID = int.Parse(objReader["city_countryID"].ToString());
                objCity.strCountryName = objReader["country_title"].ToString();

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

    public CoreWebList<CityMasterClass> fn_getCityByName(string strCity)
    {
        CoreWebList<CityMasterClass> objCityList = null;
        CityMasterClass objCity = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);
            objConnection.Open();
            string strQuery = "SELECT * FROM edu_City WHERE city_title like '%' + @city_title + '%'";
            objCommand = new SqlCommand(strQuery, objConnection);
            objCommand.Parameters.AddWithValue("@city_title", strCity);
            objReader = objCommand.ExecuteReader();
            objCityList = new CoreWebList<CityMasterClass>();
            while (objReader.Read())
            {
                objCity = new CityMasterClass();
                objCity.iID = int.Parse(objReader["city_id"].ToString());
                objCity.iCountryID = int.Parse(objReader["city_countryID"].ToString());
                objCity.strCityName = objReader["city_title"].ToString();

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

    public string fn_getOtherCityID()
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT city_id FROM edu_City WHERE city_title = 'Other'", objConnection);

            string strResponse = objCommand.ExecuteScalar().ToString();

            return strResponse;
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

    public CoreWebList<CityMasterClass> fn_getCityListByCountryID(int iCountryID)
    {
        CoreWebList<CityMasterClass> objCityList = null;
        CityMasterClass objCity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strQuery = "SELECT edu_City.city_id , edu_City.city_title , edu_City.city_countryID ,edu_Country.country_title FROM edu_City INNER JOIN edu_Country ON edu_City.city_countryID = edu_Country.country_id WHERE edu_City.city_countryID = @iCountryID ORDER BY city_title";

            objCommand = new SqlCommand(strQuery, objConnection);

            objCommand.Parameters.AddWithValue("@iCountryID", iCountryID);

            objReader = objCommand.ExecuteReader();

            objCityList = new CoreWebList<CityMasterClass>();

            while (objReader.Read())
            {
                objCity = new CityMasterClass();

                objCity.iID = int.Parse(objReader["city_id"].ToString());
                objCity.strCityName = objReader["city_title"].ToString();
                objCity.iCountryID = int.Parse(objReader["city_countryID"].ToString());
                objCity.strCountryName = objReader["country_title"].ToString();

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

    internal CoreWebList<CityMasterClass> fn_getCityListByCityID_And_CountryID(int iCityID, 
        int iCountryID)
    {
        CoreWebList<CityMasterClass> objCityList = null;
        CityMasterClass objCity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strQuery = "SELECT edu_City.city_id , edu_City.city_title , edu_City.city_countryID ,edu_City.city_countryID ,edu_Country.country_title, FROM edu_City INNER JOIN edu_Country ON edu_City.city_countryID = edu_Country.country_id WHERE edu_City.city_city_id = @iCityID AND edu_City.city_countryID = @iCountryID ORDER BY city_title";

            objCommand = new SqlCommand(strQuery, objConnection);

            objCommand.Parameters.AddWithValue("@iCityID", iCityID);
            objCommand.Parameters.AddWithValue("@iCountryID", iCountryID);

            objReader = objCommand.ExecuteReader();

            objCityList = new CoreWebList<CityMasterClass>();

            while (objReader.Read())
            {
                objCity = new CityMasterClass();
                objCity.iID = int.Parse(objReader["city_id"].ToString());
                objCity.strCityName = objReader["city_title"].ToString();
                objCity.iCountryID = int.Parse(objReader["city_countryID"].ToString());
                objCity.strCountryName = objReader["country_title"].ToString();

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

    internal CoreWebList<CityMasterClass> fn_getCityListByCountryName(string strCountryName)
    {
        CoreWebList<CityMasterClass> objCityList = null;
        CityMasterClass objCity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strQuery = "SELECT edu_City.city_id , edu_City.city_title , edu_City.city_countryID ,edu_Country.country_title FROM edu_City INNER JOIN edu_Country ON edu_City.city_countryID = edu_Country.country_id WHERE edu_Country.country_title LIKE '@CountryName' ORDER BY city_title";

            objCommand = new SqlCommand(strQuery, objConnection);

            objCommand.Parameters.AddWithValue("@CountryName", strCountryName);

            objReader = objCommand.ExecuteReader();

            objCityList = new CoreWebList<CityMasterClass>();

            while (objReader.Read())
            {
                objCity = new CityMasterClass();

                objCity.iID = int.Parse(objReader["city_id"].ToString());
                objCity.strCityName = objReader["city_title"].ToString();
                objCity.iCountryID = int.Parse(objReader["city_countryID"].ToString());
                objCity.strCountryName = objReader["country_title"].ToString();

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

    internal CoreWebList<CityMasterClass> fn_getCityListForIndia()
    {
        CoreWebList<CityMasterClass> objCityList = null;
        CityMasterClass objCity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strQuery = "SELECT edu_City.city_id , edu_City.city_title , edu_City.city_countryID ,edu_Country.country_title FROM edu_City INNER JOIN edu_Country ON edu_City.city_countryID = edu_Country.country_id WHERE edu_Country.country_title LIKE 'India' ORDER BY city_title";

            objCommand = new SqlCommand(strQuery, objConnection);

            objReader = objCommand.ExecuteReader();

            objCityList = new CoreWebList<CityMasterClass>();

            while (objReader.Read())
            {
                objCity = new CityMasterClass();

                objCity.iID = int.Parse(objReader["city_id"].ToString());
                objCity.strCityName = objReader["city_title"].ToString();
                objCity.iCountryID = int.Parse(objReader["city_countryID"].ToString());
                objCity.strCountryName = objReader["country_title"].ToString();

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