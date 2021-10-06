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
/// Summary description for DBDLFeatureClass
/// </summary>
public class DBDLFeatureClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    internal string fn_saveDLFeature(int iCourseID, int iDistanceID, string strName, string strDescription)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_DLFeature(DLFeature_DLCourseID,DLFeature_DLID,DLFeature_Title,DLFeature_Description) VALUES (@iCourseID,@iDistanceID,@strName,@strDescription)", objConnection);

            objCommand.Parameters.AddWithValue("@iCourseID", iCourseID);
            objCommand.Parameters.AddWithValue("@iDistanceID", iDistanceID);
            objCommand.Parameters.AddWithValue("@strName", strName);
            objCommand.Parameters.AddWithValue("@strDescription", strDescription);


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

    internal string fn_editDLFeature(int iID, int iCourseID, int iDistanceID, string strName, string strDescription)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();
            objCommand = new SqlCommand("UPDATE edu_DLFeature SET DLFeature_DLCourseID = @iCourseID,DLFeature_DLID = @iDistanceID,DLFeature_Title = @strName,DLFeature_Description = @strDescription WHERE DLFeature_ID = @iID", objConnection);
            objCommand.Parameters.AddWithValue("@iID", iID);
            objCommand.Parameters.AddWithValue("@iCourseID", iCourseID);
            objCommand.Parameters.AddWithValue("@iDistanceID", iDistanceID);
            objCommand.Parameters.AddWithValue("@strName", strName);
            objCommand.Parameters.AddWithValue("@strDescription", strDescription);

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

    internal string fn_deleteDLFeature(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_DLFeature WHERE DLFeature_ID = @iID", objConnection);
            objCommand.Parameters.AddWithValue("@iID", iID);
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

    internal CoreWebList<DLFeatureClass> fn_getDLFeatureByID(int iID)
    {
        CoreWebList<DLFeatureClass> objCategoryList = null;
        DLFeatureClass objCategory = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM edu_DLFeature WHERE DLFeature_ID = @iID", objConnection);
            objCommand.Parameters.AddWithValue("@iID", iID);
            objReader = objCommand.ExecuteReader();
            objCategoryList = new CoreWebList<DLFeatureClass>();
            if (objReader.Read())
            {
                objCategory = new DLFeatureClass();
                objCategory.iID = int.Parse(objReader["DLFeature_ID"].ToString());
                objCategory.iCourseID = int.Parse(objReader["DLFeature_DLCourseID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLFeature_DLID"].ToString());
                objCategory.strName = objReader["DLFeature_Title"].ToString();
                objCategory.strDescription = objReader["DLFeature_Description"].ToString();                
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

    internal yo_lib.CoreWebList<DLFeatureClass> fn_getDLFeatureByCourseID(int iCourseID)
    {
        CoreWebList<DLFeatureClass> objCategoryList = null;
        DLFeatureClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM edu_DLFeature WHERE DLFeature_DLCourseID = @iCourseID", objConnection);
            objCommand.Parameters.AddWithValue("@iCourseID", iCourseID);
            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<DLFeatureClass>();

            while (objReader.Read())
            {
                objCategory = new DLFeatureClass();
                objCategory.iID = int.Parse(objReader["DLFeature_ID"].ToString());
                objCategory.iCourseID = int.Parse(objReader["DLFeature_DLCourseID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLFeature_DLID"].ToString());
                objCategory.strName = objReader["DLFeature_Title"].ToString();
                objCategory.strDescription = objReader["DLFeature_Description"].ToString();                
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

    internal CoreWebList<DLFeatureClass> fn_getDLFeatureList()
    {
        CoreWebList<DLFeatureClass> objCategoryList = null;
        DLFeatureClass objCategory = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM edu_DLFeature", objConnection);            
            objReader = objCommand.ExecuteReader();
            objCategoryList = new CoreWebList<DLFeatureClass>();
            while (objReader.Read())
            {
                objCategory = new DLFeatureClass();
                objCategory.iID = int.Parse(objReader["DLFeature_ID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLFeature_DLCourseID"].ToString());
                objCategory.iCourseID = int.Parse(objReader["DLFeature_DLCourseID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLFeature_DLID"].ToString());
                objCategory.strName = objReader["DLFeature_Title"].ToString();
                objCategory.strDescription = objReader["DLFeature_Description"].ToString();                
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
