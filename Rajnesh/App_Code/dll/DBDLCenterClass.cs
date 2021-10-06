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
/// Summary description for DBDLCenterClass
/// </summary>
public class DBDLCenterClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    internal string fn_SaveDLCentre(int iDLInstituteID, string strCity, string strAddress)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_DLCenter(dlCenter_DLInstituteID, dlCenter_City, dlCenter_Address) VALUES (@iDLInstituteID, @strCity, @strAddress)", objConnection);

            objCommand.Parameters.AddWithValue("@iDLInstituteID", iDLInstituteID);
            objCommand.Parameters.AddWithValue("@strCity", strCity);
            objCommand.Parameters.AddWithValue("@strAddress", strAddress);

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

    internal string fn_EditDLCentre(int iID, int iDLInstituteID, string strCity, string strAddress)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_DLCenter SET dlCenter_DLInstituteID = @iDLInstituteID, dlCenter_City = @strCity, dlCenter_Address = @strAddress WHERE dlCenter_ID = @iID", objConnection);

            objCommand.Parameters.AddWithValue("@iID", iID);
            objCommand.Parameters.AddWithValue("@iDLInstituteID", iDLInstituteID);
            objCommand.Parameters.AddWithValue("@strCity", strCity);
            objCommand.Parameters.AddWithValue("@strAddress", strAddress);

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

    internal string fn_DeleteDLCentre(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_DLCenter WHERE dlCenter_ID = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);

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

    internal yo_lib.CoreWebList<DLCenterClass> fn_GetDLCentreByID(int iID)
    {
        CoreWebList<DLCenterClass> objCategoryList = null;
        DLCenterClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_DLCenter WHERE dlCenter_ID = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<DLCenterClass>();

            if (objReader.Read())
            {
                objCategory = new DLCenterClass();
                objCategory.iID = int.Parse(objReader["dlCenter_ID"].ToString());
                objCategory.iDLInstituteID = int.Parse(objReader["dlCenter_DLInstituteID"].ToString());
                objCategory.strCity = objReader["dlCenter_City"].ToString();
                objCategory.strAddress = objReader["dlCenter_Address"].ToString();
                objCategoryList.Add(objCategory);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objCategoryList;
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

    internal yo_lib.CoreWebList<DLCenterClass> fn_GetDLCentreList()
    {
        CoreWebList<DLCenterClass> objCategoryList = null;
        DLCenterClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_DLCenter", objConnection);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<DLCenterClass>();

            while (objReader.Read())
            {
                objCategory = new DLCenterClass();

                objCategory.iID = int.Parse(objReader["dlCenter_ID"].ToString());
                objCategory.iDLInstituteID = int.Parse(objReader["dlCenter_DLInstituteID"].ToString());
                objCategory.strCity = objReader["dlCenter_City"].ToString();
                objCategory.strAddress = objReader["dlCenter_Address"].ToString();
                objCategoryList.Add(objCategory);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objCategoryList;
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

    internal yo_lib.CoreWebList<DLCenterClass> fn_get_DLCentreListByInstituteID(int iDLInstituteID)
    {
        CoreWebList<DLCenterClass> objCategoryList = null;
        DLCenterClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("Select *  FROM edu_DLCenter WHERE dlCenter_DLInstituteID = @iDLInstituteID", objConnection);

            objCommand.Parameters.AddWithValue("@iDLInstituteID", iDLInstituteID);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<DLCenterClass>();

            while (objReader.Read())
            {
                objCategory = new DLCenterClass();
                objCategory.iID = int.Parse(objReader["dlCenter_ID"].ToString());
                objCategory.iDLInstituteID = int.Parse(objReader["dlCenter_DLInstituteID"].ToString());
                objCategory.strCity = objReader["dlCenter_City"].ToString();
                objCategory.strAddress = objReader["dlCenter_Address"].ToString();
                objCategoryList.Add(objCategory);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objCategoryList;
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

    internal yo_lib.CoreWebList<DLCenterClass> fn_get_CitiesByInstituteID(int iDLInstituteID)
    {
        CoreWebList<DLCenterClass> objCategoryList = null;
        DLCenterClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("Select DISTINCT dlCenter_City FROM edu_DLCenter WHERE dlCenter_DLInstituteID = @iDLInstituteID", objConnection);

            objCommand.Parameters.AddWithValue("@iDLInstituteID", iDLInstituteID);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<DLCenterClass>();

            while (objReader.Read())
            {
                objCategory = new DLCenterClass();
                //objCategory.iID = int.Parse(objReader["dlCenter_ID"].ToString());
                //objCategory.iDLInstituteID = int.Parse(objReader["dlCenter_DLInstituteID"].ToString());
                objCategory.strCity = objReader["dlCenter_City"].ToString();
                //objCategory.strAddress = objReader["dlCenter_Address"].ToString();
                objCategoryList.Add(objCategory);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objCategoryList;
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

    internal yo_lib.CoreWebList<DLCenterClass> fn_get_DLCentreListByCityName(string strCity, int iDLInstituteID)
    {
        CoreWebList<DLCenterClass> objCategoryList = null;
        DLCenterClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("Select * FROM edu_DLCenter WHERE dlCenter_City ='" + strCity + "' AND dlCenter_DLInstituteID = @iDLInstituteID ", objConnection);

            objCommand.Parameters.AddWithValue("@iDLInstituteID", iDLInstituteID);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<DLCenterClass>();

            while (objReader.Read())
            {
                objCategory = new DLCenterClass();
                objCategory.iID = int.Parse(objReader["dlCenter_ID"].ToString());
                objCategory.iDLInstituteID = int.Parse(objReader["dlCenter_DLInstituteID"].ToString());
                objCategory.strCity = objReader["dlCenter_City"].ToString();
                objCategory.strAddress = objReader["dlCenter_Address"].ToString();
                objCategoryList.Add(objCategory);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objCategoryList;
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
