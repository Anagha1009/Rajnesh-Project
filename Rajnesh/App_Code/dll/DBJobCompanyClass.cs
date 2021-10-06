using System;
using System.Configuration;
using System.Data.SqlClient;
using yo_lib;

/// <summary>
///     Summary description for DBJobCompanyClass
/// </summary>
public class DBJobCompanyClass
{
    private SqlCommand _objCommand;
    private SqlConnection _objConnection;
    private SqlDataReader _objReader;

    public string fn_SaveJobCompany(int iCategoryId, string strTitle, string strDescription, string strContacts, string strEmail, bool bFeatured, string strLogo)
    {
        try
        {
            _objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            _objConnection.Open();

            _objCommand = new SqlCommand( "INSERT INTO edu_JobsCompany(JobCompany_CategoryID, JobCompany_title, JobCompany_Description, JobCompany_Contacts, JobCompany_Email, JobCompany_Featured, JobCompany_Logo) VALUES (@JobCompany_CategoryID, @strTitle, @strDescription, @JobCompany_Contacts, @JobCompany_Email, @JobCompany_Featured, @JobCompany_Logo)",_objConnection);

            _objCommand.Parameters.AddWithValue("@JobCompany_CategoryID", iCategoryId);
            _objCommand.Parameters.AddWithValue("@strTitle", strTitle);
            _objCommand.Parameters.AddWithValue("@strDescription", strDescription);
            _objCommand.Parameters.AddWithValue("@JobCompany_Contacts", strContacts);
            _objCommand.Parameters.AddWithValue("@JobCompany_Email", strEmail);
            _objCommand.Parameters.AddWithValue("@JobCompany_Featured", bFeatured);
            _objCommand.Parameters.AddWithValue("@JobCompany_Logo", strLogo);

            if (_objCommand.ExecuteNonQuery() > 0)
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
            if (_objConnection != null)
            {
                _objConnection.Close();
            }
        }
    }

    public string fn_EditJobCompany(int iId, int iCategoryId, string strTitle, string strDescription, string strContacts, string strEmail, bool bFeatured, string strLogo)
    {
        try
        {
            _objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            _objConnection.Open();

            _objCommand = new SqlCommand( "UPDATE edu_JobsCompany SET JobCompany_CategoryID=@JobCompany_CategoryID, JobCompany_title = @strTitle, JobCompany_Description = @strDescription, JobCompany_Contacts = @JobCompany_Contacts, JobCompany_Email = @JobCompany_Email, JobCompany_Featured = @JobCompany_Featured, JobCompany_Logo=@JobCompany_Logo WHERE JobCompany_id = @ID", _objConnection);

            _objCommand.Parameters.AddWithValue("@ID", iId);
            _objCommand.Parameters.AddWithValue("@JobCompany_CategoryID", iCategoryId);
            _objCommand.Parameters.AddWithValue("@strTitle", strTitle);
            _objCommand.Parameters.AddWithValue("@strDescription", strDescription);
            _objCommand.Parameters.AddWithValue("@JobCompany_Contacts", strContacts);
            _objCommand.Parameters.AddWithValue("@JobCompany_Email", strEmail);
            _objCommand.Parameters.AddWithValue("@JobCompany_Featured", bFeatured);
            _objCommand.Parameters.AddWithValue("@JobCompany_Logo", strLogo);

            if (_objCommand.ExecuteNonQuery() > 0)
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
            if (_objConnection != null)
            {
                _objConnection.Close();
            }
        }
    }

    public string fn_DeleteJobCompany(int iId)
    {
        try
        {
            _objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            _objConnection.Open();

            _objCommand = new SqlCommand("DELETE FROM edu_JobsCompany WHERE JobCompany_id = @ID", _objConnection);

            _objCommand.Parameters.AddWithValue("@ID", iId);

            if (_objCommand.ExecuteNonQuery() > 0)
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
            if (_objConnection != null)
            {
                _objConnection.Close();
            }
        }
    }

    public CoreWebList<JobCompanyClass> fn_GetJobCompanyList()
    {
        try
        {
            _objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            _objConnection.Open();

            _objCommand = new SqlCommand("SELECT * FROM edu_JobsCompany ORDER BY JobCompany_title ASC", _objConnection);

            _objReader = _objCommand.ExecuteReader();

            var objJobCompanyList = new CoreWebList<JobCompanyClass>();

            while (_objReader.Read())
            {
                var objJobCompany = new JobCompanyClass
                {
                    iID = int.Parse(_objReader["JobCompany_id"].ToString()),
                    iCategoryID = int.Parse(_objReader["JobCompany_CategoryID"].ToString()),
                    strJobCompanyName = _objReader["JobCompany_title"].ToString(),
                    strJobCompanyDesc = _objReader["JobCompany_Description"].ToString(),
                    strContactDetails = _objReader["JobCompany_Contacts"].ToString(),
                    strEmail = _objReader["JobCompany_Email"].ToString(),
                    bFeatured = bool.Parse(_objReader["JobCompany_Featured"].ToString()),
                    strLogo = _objReader["JobCompany_Logo"].ToString()
                };

                objJobCompanyList.Add(objJobCompany);
            }

            if (_objReader != null)
            {
                _objReader.Close();
            }

            return objJobCompanyList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (_objReader != null)
            {
                _objReader.Close();
            }

            if (_objConnection != null)
            {
                _objConnection.Close();
            }
        }
    }

    public CoreWebList<JobCompanyClass> fn_Get_JobCompanyList()
    {
        try
        {
            _objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            _objConnection.Open();

            _objCommand = new SqlCommand("SELECT * FROM edu_JobsCompany ORDER BY JobCompany_id DESC", _objConnection);

            _objReader = _objCommand.ExecuteReader();

            var objJobCompanyList = new CoreWebList<JobCompanyClass>();

            while (_objReader.Read())
            {
                var objJobCompany = new JobCompanyClass
                {
                    iID = int.Parse(_objReader["JobCompany_id"].ToString()),
                    iCategoryID = int.Parse(_objReader["JobCompany_CategoryID"].ToString()),
                    strJobCompanyName = _objReader["JobCompany_title"].ToString(),
                    strJobCompanyDesc = _objReader["JobCompany_Description"].ToString(),
                    strContactDetails = _objReader["JobCompany_Contacts"].ToString(),
                    strEmail = _objReader["JobCompany_Email"].ToString(),
                    bFeatured = bool.Parse(_objReader["JobCompany_Featured"].ToString()),
                    strLogo = _objReader["JobCompany_Logo"].ToString()
                };

                objJobCompanyList.Add(objJobCompany);
            }

            if (_objReader != null)
            {
                _objReader.Close();
            }

            return objJobCompanyList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (_objReader != null)
            {
                _objReader.Close();
            }

            if (_objConnection != null)
            {
                _objConnection.Close();
            }
        }
    }

    public CoreWebList<JobCompanyClass> fn_GetJobCompanyByID(int iId)
    {
        try
        {
            _objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            _objConnection.Open();

            _objCommand = new SqlCommand("SELECT * FROM edu_JobsCompany WHERE JobCompany_id = @ID", _objConnection);

            _objCommand.Parameters.AddWithValue("@ID", iId);

            _objReader = _objCommand.ExecuteReader();

            var objJobCompanyList = new CoreWebList<JobCompanyClass>();

            if (_objReader.Read())
            {
                var objJobCompany = new JobCompanyClass
                {
                    iID = int.Parse(_objReader["JobCompany_id"].ToString()),
                    iCategoryID = int.Parse(_objReader["JobCompany_CategoryID"].ToString()),
                    strJobCompanyName = _objReader["JobCompany_title"].ToString(),
                    strJobCompanyDesc = _objReader["JobCompany_Description"].ToString(),
                    strContactDetails = _objReader["JobCompany_Contacts"].ToString(),
                    strEmail = _objReader["JobCompany_Email"].ToString(),
                    bFeatured = bool.Parse(_objReader["JobCompany_Featured"].ToString()),
                    strLogo = _objReader["JobCompany_Logo"].ToString()
                };

                objJobCompanyList.Add(objJobCompany);
            }

            if (_objReader != null)
            {
                _objReader.Close();
            }

            return objJobCompanyList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (_objReader != null)
            {
                _objReader.Close();
            }

            if (_objConnection != null)
            {
                _objConnection.Close();
            }
        }
    }

    public CoreWebList<JobCompanyClass> fn_GetFeturedJobCompanyByID(int iId)
    {
        try
        {
            _objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            _objConnection.Open();

            _objCommand = new SqlCommand("SELECT Top 5 * FROM edu_JobsCompany WHERE JobCompany_id = @ID", _objConnection);

            _objCommand.Parameters.AddWithValue("@ID", iId);

            _objReader = _objCommand.ExecuteReader();

            var objJobCompanyList = new CoreWebList<JobCompanyClass>();

            if (_objReader.Read())
            {
                var objJobCompany = new JobCompanyClass
                {
                    iID = int.Parse(_objReader["JobCompany_id"].ToString()),
                    iCategoryID = int.Parse(_objReader["JobCompany_CategoryID"].ToString()),
                    strJobCompanyName = _objReader["JobCompany_title"].ToString(),
                    strJobCompanyDesc = _objReader["JobCompany_Description"].ToString(),
                    strContactDetails = _objReader["JobCompany_Contacts"].ToString(),
                    strEmail = _objReader["JobCompany_Email"].ToString(),
                    bFeatured = bool.Parse(_objReader["JobCompany_Featured"].ToString()),
                    strLogo = _objReader["JobCompany_Logo"].ToString()
                };

                objJobCompanyList.Add(objJobCompany);
            }

            if (_objReader != null)
            {
                _objReader.Close();
            }

            return objJobCompanyList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (_objReader != null)
            {
                _objReader.Close();
            }

            if (_objConnection != null)
            {
                _objConnection.Close();
            }
        }
    }

    public CoreWebList<JobCompanyClass> fn_GetFeaturedCompany()
    {
        try
        {
            _objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            _objConnection.Open();

            _objCommand = new SqlCommand("SELECT TOP 5 * FROM edu_JobsCompany WHERE JobCompany_Featured = 'true'", _objConnection);

            _objReader = _objCommand.ExecuteReader();

            var objJobCompanyList = new CoreWebList<JobCompanyClass>();

            while (_objReader.Read())
            {
                var objJobCompany = new JobCompanyClass
                {
                    iID = int.Parse(_objReader["JobCompany_id"].ToString()),
                    iCategoryID = int.Parse(_objReader["JobCompany_CategoryID"].ToString()),
                    strJobCompanyName = _objReader["JobCompany_title"].ToString(),
                    strJobCompanyDesc = _objReader["JobCompany_Description"].ToString(),
                    strContactDetails = _objReader["JobCompany_Contacts"].ToString(),
                    strEmail = _objReader["JobCompany_Email"].ToString(),
                    bFeatured = bool.Parse(_objReader["JobCompany_Featured"].ToString()),
                    strLogo = _objReader["JobCompany_Logo"].ToString()
                };

                objJobCompanyList.Add(objJobCompany);
            }

            if (_objReader != null)
            {
                _objReader.Close();
            }

            return objJobCompanyList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (_objReader != null)
            {
                _objReader.Close();
            }

            if (_objConnection != null)
            {
                _objConnection.Close();
            }
        }
    }

    public CoreWebList<JobCompanyClass> fn_GetJobCompanyByName(string strCompany)
    {
        try
        {
            _objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            _objConnection.Open();

            _objCommand = new SqlCommand("SELECT * FROM edu_JobsCompany WHERE JobCompany_title like '%" + strCompany + "%'", _objConnection);

            _objReader = _objCommand.ExecuteReader();

            var objJobCompanyList = new CoreWebList<JobCompanyClass>();

            if (_objReader.Read())
            {
                var objJobCompany = new JobCompanyClass
                {
                    iID = int.Parse(_objReader["JobCompany_id"].ToString()),
                    iCategoryID = int.Parse(_objReader["JobCompany_CategoryID"].ToString()),
                    strJobCompanyName = _objReader["JobCompany_title"].ToString(),
                    strJobCompanyDesc = _objReader["JobCompany_Description"].ToString(),
                    strContactDetails = _objReader["JobCompany_Contacts"].ToString(),
                    strEmail = _objReader["JobCompany_Email"].ToString(),
                    bFeatured = bool.Parse(_objReader["JobCompany_Featured"].ToString()),
                    strLogo = _objReader["JobCompany_Logo"].ToString()
                };

                objJobCompanyList.Add(objJobCompany);
            }

            if (_objReader != null)
            {
                _objReader.Close();
            }

            return objJobCompanyList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (_objReader != null)
            {
                _objReader.Close();
            }

            if (_objConnection != null)
            {
                _objConnection.Close();
            }
        }
    }

    public CoreWebList<JobCompanyClass> fn_SearchJobCompanyByName(string strCompany)
    {
        try
        {
            _objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            _objConnection.Open();

            _objCommand = new SqlCommand("SELECT * FROM edu_JobsCompany WHERE JobCompany_title like '%" + strCompany + "%'", _objConnection);

            _objReader = _objCommand.ExecuteReader();

            var objJobCompanyList = new CoreWebList<JobCompanyClass>();

            while (_objReader.Read())
            {
                var objJobCompany = new JobCompanyClass
                {
                    iID = int.Parse(_objReader["JobCompany_id"].ToString()),
                    iCategoryID = int.Parse(_objReader["JobCompany_CategoryID"].ToString()),
                    strJobCompanyName = _objReader["JobCompany_title"].ToString(),
                    strJobCompanyDesc = _objReader["JobCompany_Description"].ToString(),
                    strContactDetails = _objReader["JobCompany_Contacts"].ToString(),
                    strEmail = _objReader["JobCompany_Email"].ToString(),
                    bFeatured = bool.Parse(_objReader["JobCompany_Featured"].ToString()),
                    strLogo = _objReader["JobCompany_Logo"].ToString()
                };

                objJobCompanyList.Add(objJobCompany);
            }

            if (_objReader != null)
            {
                _objReader.Close();
            }

            return objJobCompanyList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (_objReader != null)
            {
                _objReader.Close();
            }

            if (_objConnection != null)
            {
                _objConnection.Close();
            }
        }
    }

    public string fn_EditFeatured(int iId, bool bFeatured)
    {
        try
        {
            _objConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            _objConnection.Open();

            _objCommand =
                new SqlCommand(
                    "UPDATE edu_JobsCompany SET JobCompany_Featured = @JobCompany_Featured WHERE JobCompany_id = @ID",
                    _objConnection);

            _objCommand.Parameters.AddWithValue("@ID", iId);
            _objCommand.Parameters.AddWithValue("@JobCompany_Featured", bFeatured);

            if (_objCommand.ExecuteNonQuery() > 0)
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
            if (_objConnection != null)
            {
                _objConnection.Close();
            }
        }
    }
}