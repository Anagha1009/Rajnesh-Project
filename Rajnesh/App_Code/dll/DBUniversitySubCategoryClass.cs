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
/// Summary description for DBUniversitySubCategoryClass
/// </summary>
public class DBUniversitySubCategoryClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    public string fn_saveSubCategory(int iCatID, string strSubCategoryTitle, string strSubCategoryDesc)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_UniversitySubCategory(universitySubCategory_catID,universitySubCategory_title,universitySubCategory_desc) VALUES (@CatID,@SubCategoryTitle,@SubCategoryDesc)", objConnection);
            objCommand.Parameters.AddWithValue("@CatID", iCatID);
            objCommand.Parameters.AddWithValue("@SubCategoryTitle", strSubCategoryTitle);
            objCommand.Parameters.AddWithValue("@SubCategoryDesc", strSubCategoryDesc);

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

    public string fn_editSubCategory(int iID, int iCatID, string strSubCategoryTitle, string strSubCategoryDesc)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_UniversitySubCategory SET universitySubCategory_catID = @CatID, universitySubCategory_title = @SubCategoryTitle, universitySubCategory_desc=@SubCategoryDesc  WHERE universitySubCategory_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@CatID", iCatID);
            objCommand.Parameters.AddWithValue("@SubCategoryTitle", strSubCategoryTitle);
            objCommand.Parameters.AddWithValue("@SubCategoryDesc", strSubCategoryDesc);

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

    public string fn_deleteSubCategory(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_UniversitySubCategory WHERE universitySubCategory_id = @ID", objConnection);
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

    public CoreWebList<UniversitySubCategoryClass> fn_getSubCategoryList()
    {
        CoreWebList<UniversitySubCategoryClass> objSubCategoryList = null;
        UniversitySubCategoryClass objSubCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversitySubCategory", objConnection);

            objReader = objCommand.ExecuteReader();

            objSubCategoryList = new CoreWebList<UniversitySubCategoryClass>();

            while (objReader.Read())
            {
                objSubCategory = new UniversitySubCategoryClass();
                objSubCategory.iID = int.Parse(objReader["universitySubCategory_id"].ToString());
                objSubCategory.iCatID = int.Parse(objReader["universitySubCategory_catID"].ToString());
                objSubCategory.strSubCategoryTitle = objReader["universitySubCategory_title"].ToString();
                objSubCategory.strSubCategoryDesc = objReader["universitySubCategory_desc"].ToString();
                objSubCategoryList.Add(objSubCategory);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objSubCategoryList;
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

    public CoreWebList<UniversitySubCategoryClass> fn_getSubCategoryByID(int iID)
    {
        CoreWebList<UniversitySubCategoryClass> objSubCategoryList = null;
        UniversitySubCategoryClass objSubCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversitySubCategory WHERE universitySubCategory_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objSubCategoryList = new CoreWebList<UniversitySubCategoryClass>();

            if (objReader.Read())
            {
                objSubCategory = new UniversitySubCategoryClass();
                objSubCategory.iID = int.Parse(objReader["universitySubCategory_id"].ToString());
                objSubCategory.iCatID = int.Parse(objReader["universitySubCategory_catID"].ToString());
                objSubCategory.strSubCategoryTitle = objReader["universitySubCategory_title"].ToString();
                objSubCategory.strSubCategoryDesc = objReader["universitySubCategory_desc"].ToString();
                objSubCategoryList.Add(objSubCategory);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objSubCategoryList;
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

    public CoreWebList<UniversitySubCategoryClass> fn_getSubCategoryByCatID(int iCatID)
    {
        CoreWebList<UniversitySubCategoryClass> objSubCategoryList = null;
        UniversitySubCategoryClass objSubCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversitySubCategory WHERE universitySubCategory_catID = @CatID", objConnection);
            objCommand.Parameters.AddWithValue("@CatID", iCatID);

            objReader = objCommand.ExecuteReader();

            objSubCategoryList = new CoreWebList<UniversitySubCategoryClass>();

            while (objReader.Read())
            {
                objSubCategory = new UniversitySubCategoryClass();
                objSubCategory.iID = int.Parse(objReader["universitySubCategory_id"].ToString());
                objSubCategory.iCatID = int.Parse(objReader["universitySubCategory_catID"].ToString());
                objSubCategory.strSubCategoryTitle = objReader["universitySubCategory_title"].ToString();
                objSubCategory.strSubCategoryDesc = objReader["universitySubCategory_desc"].ToString();
                objSubCategoryList.Add(objSubCategory);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objSubCategoryList;
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
