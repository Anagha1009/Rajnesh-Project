using System;
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
/// Summary description for DBUniversityTypeClass
/// </summary>
public class DBUniversityTypeClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    public string fn_saveType(string strTypeTitle, string strTypeDesc)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_UniversityType(universityType_title,universityType_desc) VALUES (@TypeTitle,@TypeDesc)", objConnection);
            objCommand.Parameters.AddWithValue("@TypeTitle", strTypeTitle);
            objCommand.Parameters.AddWithValue("@TypeDesc", strTypeDesc);

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

    public string fn_editType(int iID, string strTypeTitle, string strTypeDesc)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_UniversityType SET universityType_title = @TypeTitle, universityType_desc=@TypeDesc  WHERE universityType_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@TypeTitle", strTypeTitle);
            objCommand.Parameters.AddWithValue("@TypeDesc", strTypeDesc);

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

    public string fn_deleteType(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_UniversityType WHERE universityType_id = @ID", objConnection);
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

    public CoreWebList<UniversityTypeClass> fn_getTypeList()
    {
        CoreWebList<UniversityTypeClass> objTypeList = null;
        UniversityTypeClass objType = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityType ORDER BY universityType_title ASC", objConnection);

            objReader = objCommand.ExecuteReader();

            objTypeList = new CoreWebList<UniversityTypeClass>();

            while (objReader.Read())
            {
                objType = new UniversityTypeClass();
                objType.iID = int.Parse(objReader["universityType_id"].ToString());
                objType.strTypeTitle = objReader["universityType_title"].ToString();
                objType.strTypeDesc = objReader["universityType_desc"].ToString();
                objTypeList.Add(objType);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objTypeList;
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

    public CoreWebList<UniversityTypeClass> fn_getTypeByID(int iID)
    {
        CoreWebList<UniversityTypeClass> objTypeList = null;
        UniversityTypeClass objType = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityType WHERE universityType_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objTypeList = new CoreWebList<UniversityTypeClass>();

            if (objReader.Read())
            {
                objType = new UniversityTypeClass();
                objType.iID = int.Parse(objReader["universityType_id"].ToString());
                objType.strTypeTitle = objReader["universityType_title"].ToString();
                objType.strTypeDesc = objReader["universityType_desc"].ToString();
                objTypeList.Add(objType);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objTypeList;
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
