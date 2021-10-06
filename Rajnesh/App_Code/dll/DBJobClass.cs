using System;
using System.Data.SqlClient;
using System.Configuration;
using yo_lib;

/// <summary>
/// Summary description for DBJobClass
/// </summary>
public class DBJobClass
{
	private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string fn_SaveJob(string strTitle, string strDescription, int iCategoryID, int iSubCategoryID, int iLocationID, int iCompanyID, int iPostedBy, bool bActive, DateTime dtExpirationDate)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_Jobs(Job_title, Job_Description, Job_CategoryID,Job_SubCategoryID, Job_LocationID, Job_CompanyID, Job_PostedBy, Job_PostedOn, Job_Active, Job_ExpirationDate) VALUES (@Job_title, @Job_Description, @Job_CategoryID, @Job_SubCategoryID, @Job_LocationID, @Job_CompanyID, @Job_PostedBy, @Job_PostedOn, @Job_Active, @Job_ExpirationDate)", objConnection);

            objCommand.Parameters.AddWithValue("@Job_title", strTitle);
            objCommand.Parameters.AddWithValue("@Job_Description", strDescription);
            objCommand.Parameters.AddWithValue("@Job_CategoryID", iCategoryID);
            objCommand.Parameters.AddWithValue("@Job_SubCategoryID", iSubCategoryID);
            objCommand.Parameters.AddWithValue("@Job_LocationID", iLocationID);
            objCommand.Parameters.AddWithValue("@Job_CompanyID", iCompanyID);
            objCommand.Parameters.AddWithValue("@Job_PostedBy", iPostedBy);
            objCommand.Parameters.AddWithValue("@Job_PostedOn", DateTime.Now);
            objCommand.Parameters.AddWithValue("@Job_Active", bActive);
            objCommand.Parameters.AddWithValue("@Job_ExpirationDate", dtExpirationDate);
            
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

    public string fn_editJob(int iID, string strTitle, string strDescription, int iCategoryID, int iSubCategoryID, int iLocationID, int iCompanyID, DateTime dtExpirationDate)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_Jobs SET Job_title = @Job_title, Job_Description = @Job_Description, Job_CategoryID = @Job_CategoryID, Job_SubCategoryID = @Job_SubCategoryID, Job_LocationID = @Job_LocationID, Job_CompanyID = @Job_CompanyID, Job_ExpirationDate=@Job_ExpirationDate WHERE Job_id = @Job_id", objConnection);

            objCommand.Parameters.AddWithValue("@Job_id", iID);
            objCommand.Parameters.AddWithValue("@Job_title", strTitle);
            objCommand.Parameters.AddWithValue("@Job_Description", strDescription);
            objCommand.Parameters.AddWithValue("@Job_CategoryID", iCategoryID);
            objCommand.Parameters.AddWithValue("@Job_SubCategoryID", iSubCategoryID);
            objCommand.Parameters.AddWithValue("@Job_LocationID", iLocationID);
            objCommand.Parameters.AddWithValue("@Job_CompanyID", iCompanyID);
            objCommand.Parameters.AddWithValue("@Job_ExpirationDate", dtExpirationDate);
            

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

    public string fn_ChangeGovernmentStatus(int iID, bool bGovernment)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_Jobs SET Job_Government=@Job_Government WHERE Job_id=@Job_id", objConnection);
            objCommand.Parameters.AddWithValue("@Job_id", iID);
            objCommand.Parameters.AddWithValue("@Job_Government", bGovernment);

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

    public string fn_ChangeJobStatus(int iID, bool bActive)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_Jobs SET Job_Active = @Job_Active WHERE Job_id = @Job_id", objConnection);

            objCommand.Parameters.AddWithValue("@Job_id", iID);
            objCommand.Parameters.AddWithValue("@Job_Active", bActive);

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

    public string fn_deleteJob(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_Jobs WHERE Job_id = @Job_id", objConnection);

            objCommand.Parameters.AddWithValue("@Job_id", iID);


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


    public CoreWebList<JobClass> fn_get_JobList()
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Jobs ORDER BY Job_PostedBy ASC, job_title", objConnection);

            objReader = objCommand.ExecuteReader();

            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID= int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.bGovernment = bool.Parse(objReader["Job_Government"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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

    public CoreWebList<JobClass> fn_getLatest_JobList()
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Jobs ORDER BY Job_PostedOn DESC, job_title", objConnection);

            objReader = objCommand.ExecuteReader();

            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.bGovernment = bool.Parse(objReader["Job_Government"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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


    public CoreWebList<JobClass> fn_get_JobByQuery(string strQuery)
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand(strQuery, objConnection);

            objReader = objCommand.ExecuteReader();

            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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



    public CoreWebList<JobClass> fn_get_JobListByRandom()
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Jobs ORDER BY NEWID()", objConnection);

            objReader = objCommand.ExecuteReader();

            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.bGovernment = bool.Parse(objReader["Job_Government"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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


    public CoreWebList<JobClass> fn_get_JobListinRangeByRandom()
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 5 * FROM edu_Jobs ORDER BY NEWID()", objConnection);

            objReader = objCommand.ExecuteReader();

            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.bGovernment = bool.Parse(objReader["Job_Government"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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


    public CoreWebList<JobClass> fn_get_JobByID(int iID)
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT (SELECT JobCategory_title FROM edu_JobsCategory cat WHERE cat.JobCategory_id=job.Job_CategoryID)Job_Category, (SELECT JobSubCategory_title FROM edu_JobsSubCategory subcat WHERE subcat.JobSubCategory_id=job.Job_SubCategoryID)Job_SubCategory, * FROM edu_Jobs job WHERE job.Job_id = @Job_id", objConnection);

            objCommand.Parameters.AddWithValue("@Job_id", iID);

            objReader = objCommand.ExecuteReader();

            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strCategory = objReader["Job_Category"].ToString();
                objJob.strSubCategory = objReader["Job_SubCategory"].ToString();
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.bGovernment = bool.Parse(objReader["Job_Government"].ToString());
                objJob.bGovernment = bool.Parse(objReader["Job_Government"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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

    public CoreWebList<JobClass> fn_getJobByCompanyID(int iCompanyID)
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT (SELECT JobCategory_title FROM edu_JobsCategory cat WHERE cat.JobCategory_id=job.Job_CategoryID)Job_Category, (SELECT JobSubCategory_title FROM edu_JobsSubCategory subcat WHERE subcat.JobSubCategory_id=job.Job_SubCategoryID)Job_SubCategory, * FROM edu_Jobs job WHERE job.Job_CompanyID=@Job_CompanyID", objConnection);
            objCommand.Parameters.AddWithValue("@Job_CompanyID", iCompanyID);
            objReader = objCommand.ExecuteReader();
            objJobList = new CoreWebList<JobClass>();
            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strCategory = objReader["Job_Category"].ToString();
                objJob.strSubCategory = objReader["Job_SubCategory"].ToString();
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.bGovernment = bool.Parse(objReader["Job_Government"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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

    public CoreWebList<JobClass> fn_get_JobByUserID(int iUserID)
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Jobs WHERE Job_PostedBy = @Job_PostedBy ORDER BY Job_title ASC", objConnection);

            objCommand.Parameters.AddWithValue("@Job_PostedBy", iUserID);

            objReader = objCommand.ExecuteReader();

            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.bGovernment = bool.Parse(objReader["Job_Government"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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


    public CoreWebList<JobClass> fn_get_RandomJobByCategoryID(int iCategoryId)
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 10 * FROM edu_Jobs WHERE Job_CategoryID = @Job_CategoryID ORDER BY NEWID()", objConnection);

            objCommand.Parameters.AddWithValue("@Job_CategoryID", iCategoryId);

            objReader = objCommand.ExecuteReader();

            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.bGovernment = bool.Parse(objReader["Job_Government"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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

    public CoreWebList<JobClass> fn_getRandomGovernmentJobs()
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 8 * FROM edu_Jobs WHERE Job_Government='true' ORDER BY NEWID()", objConnection);
            objReader = objCommand.ExecuteReader();
            objJobList = new CoreWebList<JobClass>();
            
            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.bGovernment = bool.Parse(objReader["Job_Government"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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

    public CoreWebList<JobClass> fn_getLatestJobs()
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 8 * FROM edu_Jobs ORDER BY Job_PostedOn DESC", objConnection);
            objReader = objCommand.ExecuteReader();
            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.bGovernment = bool.Parse(objReader["Job_Government"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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

    public CoreWebList<JobClass> fn_getRandomJobByCategoryID(int iCategoryId)
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 5 * FROM edu_Jobs WHERE Job_CategoryID = @Job_CategoryID ORDER BY Job_PostedOn DESC", objConnection);
            objCommand.Parameters.AddWithValue("@Job_CategoryID", iCategoryId);
            objReader = objCommand.ExecuteReader();
            objJobList = new CoreWebList<JobClass>();
            
            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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

    public CoreWebList<JobClass> fn_getRandomJobByCompanyID(int iCompanyId)
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 5 * FROM edu_Jobs WHERE Job_CompanyID=@Job_CompanyID ORDER BY Job_PostedOn DESC", objConnection);
            objCommand.Parameters.AddWithValue("@Job_CompanyID", iCompanyId);
            objReader = objCommand.ExecuteReader();
            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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

    public CoreWebList<JobClass> fn_getRandomJobBy_CompanyID(int iCompanyId)
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 5 * FROM edu_Jobs WHERE Job_CompanyID=@Job_CompanyID ORDER BY NEWID()", objConnection);
            objCommand.Parameters.AddWithValue("@Job_CompanyID", iCompanyId);
            objReader = objCommand.ExecuteReader();
            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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

    public CoreWebList<JobClass> fn_getJobByCategoryID(int iCategoryId)
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 100 * FROM edu_Jobs WHERE Job_CategoryID=@Job_CategoryID ORDER BY Job_PostedOn DESC", objConnection);
            objCommand.Parameters.AddWithValue("@Job_CategoryID", iCategoryId);
            objReader = objCommand.ExecuteReader();
            objJobList = new CoreWebList<JobClass>();
            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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

    public CoreWebList<JobClass> fn_get_RandomJobByCompanyID(int iCompanyID)
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 10 * FROM edu_Jobs WHERE Job_CompanyID=@Job_CompanyID ORDER BY NEWID()", objConnection);

            objCommand.Parameters.AddWithValue("@Job_CompanyID", iCompanyID);

            objReader = objCommand.ExecuteReader();

            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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

    public CoreWebList<JobClass> fn_get_JobListByQuery(string strQuery)
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand(strQuery, objConnection);

            objReader = objCommand.ExecuteReader();

            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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

    public CoreWebList<JobClass> fn_get_JobByIdentity(string strIdentities)
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Jobs WHERE Job_id IN ("+ strIdentities +")", objConnection);

            objReader = objCommand.ExecuteReader();

            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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

    public CoreWebList<JobClass> fn_getRandomJobByIdentity(string strIdentity)
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT Top 5 * FROM edu_Jobs WHERE Job_id IN (" + strIdentity + ") ORDER BY NEWID()", objConnection);

            objReader = objCommand.ExecuteReader();

            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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

    public CoreWebList<JobClass> fn_getRandomJobs(int iCategoryId, int iCityID)
    {
        CoreWebList<JobClass> objJobList = null;
        JobClass objJob = null;

        try
        {
            string strQuery = "SELECT TOP 5 * FROM edu_Jobs";

            if (iCategoryId != 0 && iCityID != 0)
            {
                strQuery += " WHERE Job_CategoryID=@Job_CategoryID AND Job_LocationID=@Job_LocationID";
            }
            else if (iCategoryId != 0)
            {
                strQuery += " WHERE Job_CategoryID=@Job_CategoryID";
            }
            else if (iCityID != 0)
            {
                strQuery += " WHERE Job_LocationID=@Job_LocationID";
            }

            strQuery += " ORDER BY NEWID()";


            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand(strQuery, objConnection);
            objCommand.Parameters.AddWithValue("@Job_CategoryID", iCategoryId);
            objCommand.Parameters.AddWithValue("@Job_LocationID", iCityID);
            objReader = objCommand.ExecuteReader();
            objJobList = new CoreWebList<JobClass>();

            while (objReader.Read())
            {
                objJob = new JobClass();
                objJob.iID = int.Parse(objReader["Job_id"].ToString());
                objJob.strTitle = objReader["Job_title"].ToString();
                objJob.strDescription = objReader["Job_Description"].ToString();
                objJob.iCategoryID = int.Parse(objReader["Job_CategoryID"].ToString());
                objJob.iSubCategoryID = int.Parse(objReader["Job_SubCategoryID"].ToString());
                objJob.iLocationID = int.Parse(objReader["Job_LocationID"].ToString());
                objJob.iCompanyID = int.Parse(objReader["Job_CompanyID"].ToString());
                objJob.iPostedBy = int.Parse(objReader["Job_PostedBy"].ToString());
                objJob.dtPostedDate = DateTime.Parse(objReader["Job_PostedOn"].ToString());
                objJob.bActive = bool.Parse(objReader["Job_Active"].ToString());
                objJob.dtExpirationDate = DateTime.Parse(objReader["Job_ExpirationDate"].ToString());

                objJobList.Add(objJob);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objJobList;
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