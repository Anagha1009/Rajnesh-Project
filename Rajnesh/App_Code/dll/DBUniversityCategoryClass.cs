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
/// Summary description for DBUniversityCategoryClass
/// </summary>
public class DBUniversityCategoryClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    public string fn_saveCategory(string strCategoryTitle, string strCategoryDesc)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_UniversityCategory(universityCategory_title,universityCategory_desc) VALUES (@CategoryTitle,@CategoryDesc)", objConnection);
            objCommand.Parameters.AddWithValue("@CategoryTitle", strCategoryTitle);
            objCommand.Parameters.AddWithValue("@CategoryDesc", strCategoryDesc);

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

    public string fn_editCategory(int iID, string strCategoryTitle, string strCategoryDesc)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_UniversityCategory SET universityCategory_title = @CategoryTitle, universityCategory_desc=@CategoryDesc  WHERE universityCategory_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@CategoryTitle", strCategoryTitle);
            objCommand.Parameters.AddWithValue("@CategoryDesc", strCategoryDesc);

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

    public string fn_deleteCategory(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_UniversityCategory WHERE universityCategory_id = @ID", objConnection);
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

    public CoreWebList<UniversityCategoryClass> fn_getCategoryList()
    {
        CoreWebList<UniversityCategoryClass> objCategoryList = null;
        UniversityCategoryClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT universityCategory_id,universityCategory_title,universityCategory_desc FROM edu_UniversityCategory", objConnection);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<UniversityCategoryClass>();

            while (objReader.Read())
            {
                objCategory = new UniversityCategoryClass();
                objCategory.iID = int.Parse(objReader["universityCategory_id"].ToString());
                objCategory.strCategoryTitle = objReader["universityCategory_title"].ToString();
                objCategory.strCategoryDesc = objReader["universityCategory_desc"].ToString();
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

    public CoreWebList<UniversityCategoryClass> fn_getCategoryByID(int iID)
    {
        CoreWebList<UniversityCategoryClass> objCategoryList = null;
        UniversityCategoryClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT universityCategory_id,universityCategory_title,universityCategory_desc FROM edu_UniversityCategory WHERE universityCategory_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<UniversityCategoryClass>();

            if (objReader.Read())
            {
                objCategory = new UniversityCategoryClass();
                objCategory.iID = int.Parse(objReader["universityCategory_id"].ToString());
                objCategory.strCategoryTitle = objReader["universityCategory_title"].ToString();
                objCategory.strCategoryDesc = objReader["universityCategory_desc"].ToString();
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
