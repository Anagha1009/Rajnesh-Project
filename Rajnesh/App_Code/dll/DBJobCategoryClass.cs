using System;
using System.Data.SqlClient;
using System.Configuration;
using yo_lib;

/// <summary>
/// Summary description for DBJobCategoryClass
/// </summary>
public class DBJobCategoryClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string fn_SaveJobCategory(string strTitle, string strDescription)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_JobsCategory(JobCategory_title, JobCategory_Description) VALUES (@strTitle, @strDescription)", objConnection);

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

    public string fn_EditJobCategory(int iID, string strTitle, string strDescription)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_JobsCategory SET JobCategory_title = @strTitle, JobCategory_Description = @strDescription WHERE JobCategory_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
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

    public string fn_DeleteJobCategory(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_JobsCategory WHERE JobCategory_id = @ID", objConnection);

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

    public CoreWebList<JobCategoryClass> fn_GetJobCategoryList()
    {
        CoreWebList<JobCategoryClass> objJobCategoryList = null;
        JobCategoryClass objJobCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_JobsCategory ORDER BY JobCategory_title", objConnection);

            objReader = objCommand.ExecuteReader();

            objJobCategoryList = new CoreWebList<JobCategoryClass>();

            while (objReader.Read())
            {
                objJobCategory = new JobCategoryClass();

                objJobCategory.iID = int.Parse(objReader["JobCategory_id"].ToString());
                objJobCategory.strJobCategoryName = objReader["JobCategory_title"].ToString();
                objJobCategory.strJobCategoryDesc = objReader["JobCategory_Description"].ToString();

                objJobCategoryList.Add(objJobCategory);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobCategoryList;
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

    public CoreWebList<JobCategoryClass> fn_GetJobCategoryByID(int iID)
    {
        CoreWebList<JobCategoryClass> objJobCategoryList = null;
        JobCategoryClass objJobCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_JobsCategory WHERE JobCategory_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objJobCategoryList = new CoreWebList<JobCategoryClass>();

            if (objReader.Read())
            {
                objJobCategory = new JobCategoryClass();

                objJobCategory.iID = int.Parse(objReader["JobCategory_id"].ToString());
                objJobCategory.strJobCategoryName = objReader["JobCategory_title"].ToString();
                objJobCategory.strJobCategoryDesc = objReader["JobCategory_Description"].ToString();

                objJobCategoryList.Add(objJobCategory);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobCategoryList;
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