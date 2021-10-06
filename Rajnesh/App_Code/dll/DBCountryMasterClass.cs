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
/// Summary description for DBCountryMasterClass
/// </summary>
public class DBCountryMasterClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    public string fn_saveCountry(string strCountryName)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_Country (country_title) VALUES (@name)", objConnection);
            objCommand.Parameters.AddWithValue("@name", strCountryName);

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

    public string fn_editCountry(int iCountryID, string strCountryName)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_Country SET country_title = @name WHERE country_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@name", strCountryName);
            objCommand.Parameters.AddWithValue("@ID", iCountryID);

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

    public string fn_deleteCountry(int iCountryID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_Country WHERE country_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iCountryID);

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
    
    public CoreWebList<CountryMasterClass> fn_getCountryList()
    {
        CoreWebList<CountryMasterClass> objCountryList = null;
        CountryMasterClass objCountry = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Country", objConnection);

            objReader = objCommand.ExecuteReader();

            objCountryList = new CoreWebList<CountryMasterClass>();

            while (objReader.Read())
            {
                objCountry = new CountryMasterClass();
                objCountry.iID = int.Parse(objReader["country_id"].ToString());
                objCountry.strCountryName = objReader["country_title"].ToString();
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
            HttpContext.Current.Response.Write(ex.Message + ex.StackTrace);
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

    public CoreWebList<CountryMasterClass> fn_getCountryByID(int iCountryID)
    {
        CoreWebList<CountryMasterClass> objCountryList = null;
        CountryMasterClass objCountry = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Country WHERE country_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iCountryID);

            objReader = objCommand.ExecuteReader();

            objCountryList = new CoreWebList<CountryMasterClass>();

            if (objReader.Read())
            {
                objCountry = new CountryMasterClass();
                objCountry.iID = int.Parse(objReader["country_id"].ToString());
                objCountry.strCountryName = objReader["country_title"].ToString();
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

    internal CoreWebList<CountryMasterClass> fn_getCountryByCoutryName(string strCountryName)
    {
        CoreWebList<CountryMasterClass> objCountryList = null;
        CountryMasterClass objCountry = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Country WHERE country_title = @title", objConnection);
            objCommand.Parameters.AddWithValue("@title", strCountryName);

            objReader = objCommand.ExecuteReader();

            objCountryList = new CoreWebList<CountryMasterClass>();

            if (objReader.Read())
            {
                objCountry = new CountryMasterClass();
                objCountry.iID = int.Parse(objReader["country_id"].ToString());
                objCountry.strCountryName = objReader["country_title"].ToString();
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
