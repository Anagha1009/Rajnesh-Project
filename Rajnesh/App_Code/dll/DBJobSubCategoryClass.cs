using System;
using System.Data.SqlClient;
using System.Configuration;
using yo_lib;

/// <summary>
/// Summary description for DBJobSubCategoryClass
/// </summary>
public class DBJobSubCategoryClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string fn_SaveJobSubCategory(int iCategoryId, string strTitle, string strDescription)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_JobsSubCategory(JobSubCategory_CategoryId, JobSubCategory_title, JobSubCategory_Description) VALUES (@CategoryId, @strTitle, @strDescription)", objConnection);

            objCommand.Parameters.AddWithValue("@CategoryId", iCategoryId);
            objCommand.Parameters.AddWithValue("@strTitle", strTitle);
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

    public string fn_EditJobSubCategory(int iID, int iCategoryId, string strTitle, string strDescription)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_JobsSubCategory SET JobSubCategory_CategoryId = @JobSubCategory_CategoryId, JobSubCategory_title = @strTitle, JobSubCategory_Description = @strDescription WHERE JobSubCategory_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@JobSubCategory_CategoryId", iCategoryId);
            objCommand.Parameters.AddWithValue("@strTitle", strTitle);
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

    public string fn_DeleteJobSubCategory(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_JobsSubCategory WHERE JobSubCategory_id = @ID", objConnection);

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

    public CoreWebList<JobSubCategoryClass> fn_GetJobSubCategoryList()
    {
        CoreWebList<JobSubCategoryClass> objJobSubCategoryList = null;
        JobSubCategoryClass objJobSubCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_JobsSubCategory", objConnection);

            objReader = objCommand.ExecuteReader();

            objJobSubCategoryList = new CoreWebList<JobSubCategoryClass>();

            while (objReader.Read())
            {
                objJobSubCategory = new JobSubCategoryClass();

                objJobSubCategory.iID = int.Parse(objReader["JobSubCategory_id"].ToString());
                objJobSubCategory.iCategoryID = int.Parse(objReader["JobSubCategory_CategoryId"].ToString());
                objJobSubCategory.strJobSubCategoryName = objReader["JobSubCategory_title"].ToString();
                objJobSubCategory.strJobSubCategoryDesc = objReader["JobSubCategory_Description"].ToString();

                objJobSubCategoryList.Add(objJobSubCategory);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobSubCategoryList;
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

    public CoreWebList<JobSubCategoryClass> fn_GetJobSubCategoryByID(int iID)
    {
        CoreWebList<JobSubCategoryClass> objJobSubCategoryList = null;
        JobSubCategoryClass objJobSubCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_JobsSubCategory WHERE JobSubCategory_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objJobSubCategoryList = new CoreWebList<JobSubCategoryClass>();

            if (objReader.Read())
            {
                objJobSubCategory = new JobSubCategoryClass();

                objJobSubCategory.iID = int.Parse(objReader["JobSubCategory_id"].ToString());
                objJobSubCategory.iCategoryID = int.Parse(objReader["JobSubCategory_CategoryId"].ToString());
                objJobSubCategory.strJobSubCategoryName = objReader["JobSubCategory_title"].ToString();
                objJobSubCategory.strJobSubCategoryDesc = objReader["JobSubCategory_Description"].ToString();

                objJobSubCategoryList.Add(objJobSubCategory);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobSubCategoryList;
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


    public CoreWebList<JobSubCategoryClass> fn_GetJobSubCategoryByCategoryID(int iCategoryID)
    {
        CoreWebList<JobSubCategoryClass> objJobSubCategoryList = null;
        JobSubCategoryClass objJobSubCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_JobsSubCategory WHERE JobSubCategory_CategoryId = @JobSubCategory_CategoryId", objConnection);

            objCommand.Parameters.AddWithValue("@JobSubCategory_CategoryId", iCategoryID);

            objReader = objCommand.ExecuteReader();

            objJobSubCategoryList = new CoreWebList<JobSubCategoryClass>();

            while (objReader.Read())
            {
                objJobSubCategory = new JobSubCategoryClass();

                objJobSubCategory.iID = int.Parse(objReader["JobSubCategory_id"].ToString());
                objJobSubCategory.iCategoryID = int.Parse(objReader["JobSubCategory_CategoryId"].ToString());
                objJobSubCategory.strJobSubCategoryName = objReader["JobSubCategory_title"].ToString();
                objJobSubCategory.strJobSubCategoryDesc = objReader["JobSubCategory_Description"].ToString();

                objJobSubCategoryList.Add(objJobSubCategory);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobSubCategoryList;
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