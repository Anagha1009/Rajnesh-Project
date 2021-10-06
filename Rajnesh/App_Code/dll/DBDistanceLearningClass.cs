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
/// Summary description for DBDistanceLearningClass
/// </summary>
public class DBDistanceLearningClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    public string fn_SaveDistanceLearning(string strType, string strName, string strCity, string strEmail, 
        string strWebsite, string strImage, string strDesc, string strExamDetails, string strContactInfo, bool bIsFeatured, string strAdmissions, string strResults)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_distancelearning(distancelearning_type, distancelearning_name, distancelearning_city, distancelearning_email, distancelearning_website, distancelearning_logo, distancelearning_desc, distancelearning_examdetails, distancelearning_contactinfo, distancelearning_featured, distancelearning_admissions, distancelearning_results) VALUES (@distancelearning_type, @distancelearning_name, @distancelearning_city, @distancelearning_email, @distancelearning_website, @distancelearning_logo, @distancelearning_desc, @distancelearning_examdetails, @distancelearning_contactinfo, @distancelearning_featured, @distancelearning_admissions, @distancelearning_results)", objConnection);

            objCommand.Parameters.AddWithValue("@distancelearning_type", strType);
            objCommand.Parameters.AddWithValue("@distancelearning_name", strName);
            objCommand.Parameters.AddWithValue("@distancelearning_city", strCity);
            objCommand.Parameters.AddWithValue("@distancelearning_email", strEmail);
            objCommand.Parameters.AddWithValue("@distancelearning_website", strWebsite);
            objCommand.Parameters.AddWithValue("@distancelearning_logo", strImage);
            objCommand.Parameters.AddWithValue("@distancelearning_desc", strDesc);
            objCommand.Parameters.AddWithValue("@distancelearning_examdetails", strExamDetails);
            objCommand.Parameters.AddWithValue("@distancelearning_contactinfo", strContactInfo);
            objCommand.Parameters.AddWithValue("@distancelearning_featured", bIsFeatured);
            objCommand.Parameters.AddWithValue("@distancelearning_admissions", strAdmissions);
            objCommand.Parameters.AddWithValue("@distancelearning_results", strResults);
            
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

    public string fn_EditDistanceLearning(int iID, string strType, string strName, string strCity, string strEmail,
        string strWebsite, string strImage, string strDesc, string strExamDetails, string strContactInfo, bool bIsFeatured, string strAdmissions, string strResults)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_distancelearning SET distancelearning_type = @distancelearning_type, distancelearning_name = @distancelearning_name, distancelearning_city = @distancelearning_city, distancelearning_email = @distancelearning_email, distancelearning_website = @distancelearning_website, distancelearning_logo = @distancelearning_logo, distancelearning_desc = @distancelearning_desc, distancelearning_examdetails = @distancelearning_examdetails, distancelearning_contactinfo = @distancelearning_contactinfo, distancelearning_featured = @distancelearning_featured, distancelearning_admissions=@distancelearning_admissions, distancelearning_results=@distancelearning_results WHERE distancelearning_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@distancelearning_type", strType);
            objCommand.Parameters.AddWithValue("@distancelearning_name", strName);
            objCommand.Parameters.AddWithValue("@distancelearning_city", strCity);
            objCommand.Parameters.AddWithValue("@distancelearning_email", strEmail);
            objCommand.Parameters.AddWithValue("@distancelearning_website", strWebsite);
            objCommand.Parameters.AddWithValue("@distancelearning_logo", strImage);
            objCommand.Parameters.AddWithValue("@distancelearning_desc", strDesc);
            objCommand.Parameters.AddWithValue("@distancelearning_examdetails", strExamDetails);
            objCommand.Parameters.AddWithValue("@distancelearning_contactinfo", strContactInfo);
            objCommand.Parameters.AddWithValue("@distancelearning_featured", bIsFeatured);
            objCommand.Parameters.AddWithValue("@distancelearning_admissions", strAdmissions);
            objCommand.Parameters.AddWithValue("@distancelearning_results", strResults);

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

    public string fn_DeleteDistanceLearning(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_distancelearning WHERE distancelearning_id = @ID", 
                objConnection);

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

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningList()
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_distancelearning ORDER BY distancelearning_name", objConnection);

            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strType = objReader["distancelearning_type"].ToString();
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["distancelearning_city"].ToString();
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strDesc = objReader["distancelearning_desc"].ToString();
                objDL.strExamDetails = objReader["distancelearning_examdetails"].ToString();
                objDL.strContactInfo = objReader["distancelearning_contactinfo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());

                objDL.strAdmissions = objReader["distancelearning_admissions"].ToString();
                objDL.strResults = objReader["distancelearning_results"].ToString();

                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningListByType(string strType)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_distancelearning WHERE distancelearning_type=@distancelearning_type ORDER BY distancelearning_name ASC", objConnection);
            objCommand.Parameters.AddWithValue("@distancelearning_type", strType);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strType = objReader["distancelearning_type"].ToString();
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["distancelearning_city"].ToString();
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strDesc = objReader["distancelearning_desc"].ToString();
                objDL.strExamDetails = objReader["distancelearning_examdetails"].ToString();
                objDL.strContactInfo = objReader["distancelearning_contactinfo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.strAdmissions = objReader["distancelearning_admissions"].ToString();
                objDL.strResults = objReader["distancelearning_results"].ToString();

                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningListByName(string strName)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_distancelearning WHERE distancelearning_name=@distancelearning_name ORDER BY distancelearning_name ASC", objConnection);
            objCommand.Parameters.AddWithValue("@distancelearning_name", strName);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strType = objReader["distancelearning_type"].ToString();
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["distancelearning_city"].ToString();
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strDesc = objReader["distancelearning_desc"].ToString();
                objDL.strExamDetails = objReader["distancelearning_examdetails"].ToString();
                objDL.strContactInfo = objReader["distancelearning_contactinfo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.strAdmissions = objReader["distancelearning_admissions"].ToString();
                objDL.strResults = objReader["distancelearning_results"].ToString();

                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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

    public CoreWebList<DistanceLearningClass> fn_GetRandomDistanceLearningListByType(string strType)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 5 * FROM edu_distancelearning WHERE distancelearning_type=@distancelearning_type ORDER BY NEWID()", objConnection);
            objCommand.Parameters.AddWithValue("@distancelearning_type", strType);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strType = objReader["distancelearning_type"].ToString();
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["distancelearning_city"].ToString();
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strDesc = objReader["distancelearning_desc"].ToString();
                objDL.strExamDetails = objReader["distancelearning_examdetails"].ToString();
                objDL.strContactInfo = objReader["distancelearning_contactinfo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.strAdmissions = objReader["distancelearning_admissions"].ToString();
                objDL.strResults = objReader["distancelearning_results"].ToString();

                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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

    public CoreWebList<DistanceLearningClass> fn_GetRandom_DistanceLearningListByType(string strType)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 6 * FROM edu_distancelearning WHERE distancelearning_type=@distancelearning_type ORDER BY NEWID()", objConnection);
            objCommand.Parameters.AddWithValue("@distancelearning_type", strType);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strType = objReader["distancelearning_type"].ToString();
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["distancelearning_city"].ToString();
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strDesc = objReader["distancelearning_desc"].ToString();
                objDL.strExamDetails = objReader["distancelearning_examdetails"].ToString();
                objDL.strContactInfo = objReader["distancelearning_contactinfo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.strAdmissions = objReader["distancelearning_admissions"].ToString();
                objDL.strResults = objReader["distancelearning_results"].ToString();

                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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

    public CoreWebList<DistanceLearningClass> fn_GetRandomDistanceLearning()
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 5 * FROM edu_distancelearning ORDER BY NEWID()", objConnection);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strType = objReader["distancelearning_type"].ToString();
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["distancelearning_city"].ToString();
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strDesc = objReader["distancelearning_desc"].ToString();
                objDL.strExamDetails = objReader["distancelearning_examdetails"].ToString();
                objDL.strContactInfo = objReader["distancelearning_contactinfo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.strAdmissions = objReader["distancelearning_admissions"].ToString();
                objDL.strResults = objReader["distancelearning_results"].ToString();

                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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

    public CoreWebList<DistanceLearningClass> fn_Get_Random_DistanceLearningListByType(string strType)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 5 * FROM edu_distancelearning WHERE distancelearning_type=@distancelearning_type ORDER BY NEWID()", objConnection);
            objCommand.Parameters.AddWithValue("@distancelearning_type", strType);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strType = objReader["distancelearning_type"].ToString();
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["distancelearning_city"].ToString();
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strDesc = objReader["distancelearning_desc"].ToString();
                objDL.strExamDetails = objReader["distancelearning_examdetails"].ToString();
                objDL.strContactInfo = objReader["distancelearning_contactinfo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.strAdmissions = objReader["distancelearning_admissions"].ToString();
                objDL.strResults = objReader["distancelearning_results"].ToString();

                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningByID(int iID)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_distancelearning WHERE distancelearning_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            if (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strType = objReader["distancelearning_type"].ToString();
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["distancelearning_city"].ToString();
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strDesc = objReader["distancelearning_desc"].ToString();
                objDL.strExamDetails = objReader["distancelearning_examdetails"].ToString();
                objDL.strContactInfo = objReader["distancelearning_contactinfo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.strAdmissions = objReader["distancelearning_admissions"].ToString();
                objDL.strResults = objReader["distancelearning_results"].ToString();

                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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


    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningByIdentities(string strIDs)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_distancelearning WHERE distancelearning_id IN (" +strIDs + ")", objConnection);

            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strType = objReader["distancelearning_type"].ToString();
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["distancelearning_city"].ToString();
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strDesc = objReader["distancelearning_desc"].ToString();
                objDL.strExamDetails = objReader["distancelearning_examdetails"].ToString();
                objDL.strContactInfo = objReader["distancelearning_contactinfo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.strAdmissions = objReader["distancelearning_admissions"].ToString();
                objDL.strResults = objReader["distancelearning_results"].ToString();

                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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


    public bool fn_GetFeaturedStatusByID(int iID)
    {
        DistanceLearningClass objIM = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT distancelearning_featured FROM edu_distancelearning WHERE distancelearning_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            while (objReader.Read())
            {
                objIM = new DistanceLearningClass();

                objIM.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
            }

            return objIM.bIsFeatured;
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

    public string fn_ChangeFeaturedStatus(int iID, bool bIsFeatured)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_distancelearning SET distancelearning_featured=@distancelearning_featured WHERE distancelearning_id = @ID ", objConnection);

            objCommand.Parameters.AddWithValue("@distancelearning_featured", bIsFeatured);
            objCommand.Parameters.AddWithValue("@ID", iID);

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

    public CoreWebList<DistanceLearningClass> fn_SearchDistanceLearningList(string strSearchQuery)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand(strSearchQuery, objConnection);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());

                objDLList.Add(objDL);
            }
            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    //Code for Client Side rotating div
    public CoreWebList<DistanceLearningClass> fn_GetFeaturedDistanceLearning(int iStartRow, int iEndRow)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("Select * from (select I.distancelearning_id,I.distancelearning_logo,I.distancelearning_name,I.distancelearning_city ,row_number() OVER (order by  distancelearning_name) as TR  from edu_distancelearning as I  with(nolock) where I.distancelearning_featured = '1' ) As TR Where TR between  @StartRow and @EndRow", objConnection);

            objCommand.Parameters.AddWithValue("@StartRow", iStartRow);
            objCommand.Parameters.AddWithValue("@EndRow", iEndRow);

            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strCity = objReader["distancelearning_city"].ToString();
                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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

    public string fn_EditDistanceLearningWithoutImage(int iID, string strType, string strName, string strCity,
        string strEmail, string strWebsite, string strDesc, string strExamDetails, string strContactInfo, bool bIsFeatured, string strAdmissions, string strResults)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_distancelearning SET distancelearning_type = @distancelearning_type, distancelearning_name = @distancelearning_name, distancelearning_city = @distancelearning_city, distancelearning_email = @distancelearning_email, distancelearning_website = @distancelearning_website, distancelearning_desc = @distancelearning_desc, distancelearning_examdetails=@distancelearning_examdetails, distancelearning_contactinfo = @distancelearning_contactinfo, distancelearning_featured = @distancelearning_featured, distancelearning_admissions=@distancelearning_admissions, distancelearning_results=@distancelearning_results WHERE distancelearning_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@distancelearning_type", strType);
            objCommand.Parameters.AddWithValue("@distancelearning_name", strName);
            objCommand.Parameters.AddWithValue("@distancelearning_city", strCity);
            objCommand.Parameters.AddWithValue("@distancelearning_email", strEmail);
            objCommand.Parameters.AddWithValue("@distancelearning_website", strWebsite);
            objCommand.Parameters.AddWithValue("@distancelearning_desc", strDesc);
            objCommand.Parameters.AddWithValue("@distancelearning_examdetails", strExamDetails);
            objCommand.Parameters.AddWithValue("@distancelearning_contactinfo", strContactInfo);
            objCommand.Parameters.AddWithValue("@distancelearning_featured", bIsFeatured);
            objCommand.Parameters.AddWithValue("@distancelearning_admissions", strAdmissions);
            objCommand.Parameters.AddWithValue("@distancelearning_results", strResults);

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

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningByCategoryID(int iCategoryID)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT DL.* FROM edu_DLCategoryList AS CL INNER JOIN edu_DistanceLearning AS DL on DL.distancelearning_id = CL.DLCategoryList_DLID WHERE CL.DLCategoryList_CatID = @iCategoryID ORDER BY DL.distancelearning_featured desc, DL.distancelearning_name", objConnection);

            objCommand.Parameters.AddWithValue("@iCategoryID", iCategoryID);

            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            if (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strType = objReader["distancelearning_type"].ToString();
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["distancelearning_city"].ToString();
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strDesc = objReader["distancelearning_desc"].ToString();
                objDL.strContactInfo = objReader["distancelearning_contactinfo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());

                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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


    /* -----Created on 13/8/2010------ */

    public CoreWebList<DistanceLearningClass> fn_GetDLByCategoryID(int iCategoryID)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 5 DL.* FROM edu_DLCategoryList AS CL INNER JOIN edu_DistanceLearning AS DL on DL.distancelearning_id = CL.DLCategoryList_DLID WHERE CL.DLCategoryList_CatID = @iCategoryID ORDER BY DL.distancelearning_featured desc, DL.distancelearning_name", objConnection);

            objCommand.Parameters.AddWithValue("@iCategoryID", iCategoryID);

            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strType = objReader["distancelearning_type"].ToString();
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["distancelearning_city"].ToString();
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strDesc = objReader["distancelearning_desc"].ToString();
                objDL.strContactInfo = objReader["distancelearning_contactinfo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());

                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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




    internal CoreWebList<DistanceLearningClass> fn_GetDistanceLearningListGroupedByCENTERID()
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT   I.distancelearning_id, I.distancelearning_logo, I.distancelearning_name, I.distancelearning_featured, (CAST(I.distancelearning_desc as varchar(8000))) as detail, IC.dlCenter_City, COUNT(IC.dlCenter_ID) AS IDCOUNT   FROM   edu_DLCenter IC RIGHT JOIN edu_DistanceLearning I ON IC.dlCenter_DLInstituteID = I.distancelearning_id GROUP BY I.distancelearning_id, I.distancelearning_name, (CAST(I.distancelearning_desc as varchar(8000))) , I.distancelearning_logo, I.distancelearning_featured, IC.dlCenter_City ORDER BY I.distancelearning_featured DESC, I.distancelearning_name ASC", objConnection);

            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["dlCenter_City"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.iCenterCount = int.Parse(objReader["IDCOUNT"].ToString());
                objDL.strDesc = objReader["detail"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();

                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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

    internal CoreWebList<DistanceLearningClass> fn_SearchDLInst_ForClient(string strQuery)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            
            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["dlCenter_City"].ToString();
                //objDL.strEmail = objReader["testpreparation_email"].ToString();
                //objDL.strWebsite = objReader["testpreparation_website"].ToString();
                if(strQuery.Contains("distancelearning_logo"))
                    objDL.strImage = objReader["distancelearning_logo"].ToString();
                if (strQuery.Contains("distancelearning_desc"))
                    objDL.strDesc = objReader["distancelearning_desc"].ToString();
                //objDL.strContactInfo = objReader["testpreparation_contactinfo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.iCenterCount = int.Parse(objReader["IDCOUNT"].ToString());

                ///objDL.strType = objReader["testPreparationCourses_type"].ToString();

                objDLList.Add(objDL);
            }
            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    /*----20-Aug-2010----*/

    internal CoreWebList<DistanceLearningClass> fn_SearchDistanceLearningInstitutes(string strQuery)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["dlCenter_City"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strDesc = objReader["Detail"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.iCenterCount = int.Parse(objReader["IDCOUNT"].ToString());

                objDLList.Add(objDL);
            }
            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    /*-------------------*/


    internal CoreWebList<DistanceLearningClass> fn_SearchDLInst_ForClient(int iCategoryID, string strCity, string strName)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            bool blnflag = false;

            string strQuery = "SELECT     I.distancelearning_id,I.distancelearning_logo, I.distancelearning_name, I.distancelearning_desc, (CAST(I.distancelearning_desc as varchar(8000))) as detail,		    I.distancelearning_featured, IC.dlCenter_City, COUNT(IC.dlCenter_ID) AS IDCOUNT FROM         edu_DLCenter IC RIGHT JOIN edu_DistanceLearning I ON IC.dlCenter_DLInstituteID = I.distancelearning_id ";

            //if (strCity != "" || strCity != "All")
            //{
            //if (blnflag)
            //{
            //strQuery += " AND  IC.dlCenter_City LIKE '%" + strCity + "%' ";
            //}
            //else
            //{
            strQuery += " WHERE  distancelearning_name LIKE '%" + strName + "%' ";
            //}
            //blnflag = true;
            //}

            if (strCity != "")
            {
                //if (blnflag)
                //{
                strQuery += " AND  IC.dlCenter_City = '" + strCity + "' ";
                //}
                //else
                //{
                //strQuery += " WHERE  distancelearning_name LIKE '%" + strName + "%' ";
                //}
                //blnflag = true;
            }


            if (iCategoryID != 0)
            {
                //if (blnflag)
                //{
                strQuery += " AND I.distancelearning_id IN(SELECT DISTINCT(DLCategoryList_DLID) FROM edu_DLCategoryList WHERE DLCategoryList_CatID = " + iCategoryID + " GROUP BY DLCategoryList_CatID, DLCategoryList_DLID) ";
                //}
                //else
                //{
                //    strQuery += " WHERE I.distancelearning_id IN(SELECT DISTINCT(DLCategoryList_DLID) FROM edu_DLCategoryList WHERE DLCategoryList_CatID = " + iCategoryID + " GROUP BY DLCategoryList_CatID, DLCategoryList_DLID)";
                //}
                //blnflag = true;
            }

            strQuery += "GROUP BY I.distancelearning_id, I.distancelearning_logo, I.distancelearning_name,I.distancelearning_desc, (CAST(I.distancelearning_desc as varchar(8000))) , I.distancelearning_featured, IC.dlCenter_City ORDER BY I.distancelearning_featured DESC, I.distancelearning_name ASC";

            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["dlCenter_City"].ToString();
                //objDL.strEmail = objReader["testpreparation_email"].ToString();
                //objDL.strWebsite = objReader["testpreparation_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strDesc = objReader["distancelearning_desc"].ToString();
                //objDL.strContactInfo = objReader["testpreparation_contactinfo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.iCenterCount = int.Parse(objReader["IDCOUNT"].ToString());

                ///objDL.strType = objReader["testPreparationCourses_type"].ToString();

                objDLList.Add(objDL);
            }
            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    internal CoreWebList<DistanceLearningClass> fn_GetDistanceLearningInstitutesByCatID(int iCategoryID)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();


            string strQuery = "SELECT     I.distancelearning_id,I.distancelearning_name, 		    I.distancelearning_featured, IC.dlCenter_City, COUNT(IC.dlCenter_ID) AS IDCOUNT FROM edu_DLCenter IC RIGHT JOIN edu_DistanceLearning I ON IC.dlCenter_DLInstituteID = I.distancelearning_id Inner join edu_DLCourses DC on I.distancelearning_id = DC.DLCourses_DLID where I.distancelearning_id IN(SELECT DISTINCT(DLCategoryList_DLID) FROM edu_DLCategoryList WHERE DLCategoryList_CatID =" + iCategoryID + " GROUP BY DLCategoryList_CatID, DLCategoryList_DLID)  GROUP BY I.distancelearning_id, I.distancelearning_name, I.distancelearning_featured, IC.dlCenter_City ORDER BY I.distancelearning_featured DESC, I.distancelearning_name ASC";
            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["dlCenter_City"].ToString();               
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.iCenterCount = int.Parse(objReader["IDCOUNT"].ToString());

                objDLList.Add(objDL);
            }
            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    internal CoreWebList<DistanceLearningClass> fn_GetDistanceLearningInstitutesByCity(string strCity)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();


            string strQuery = "   SELECT I.distancelearning_logo, I.distancelearning_id,I.distancelearning_website,I.distancelearning_email, I.distancelearning_name, I.distancelearning_featured, IC.dlCenter_City, COUNT(IC.dlCenter_ID) AS IDCOUNT FROM edu_DLCenter IC RIGHT JOIN edu_DistanceLearning I ON IC.dlCenter_DLInstituteID = I.distancelearning_id WHERE  IC.dlCenter_City like '%" + strCity + "%' GROUP BY I.distancelearning_id, I.distancelearning_name,I.distancelearning_website,I.distancelearning_email, I.distancelearning_featured,I.distancelearning_logo, IC.dlCenter_City ORDER BY I.distancelearning_featured DESC, I.distancelearning_name ASC";
            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["dlCenter_City"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.iCenterCount = int.Parse(objReader["IDCOUNT"].ToString());
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDLList.Add(objDL);
            }
            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    internal CoreWebList<DistanceLearningClass> fn_GetDistanceUniversityByCity(string strCity)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            string strQuery = "SELECT I.distancelearning_logo, I.distancelearning_id,I.distancelearning_website,I.distancelearning_email, I.distancelearning_name, I.distancelearning_featured, IC.dlCenter_City, COUNT(IC.dlCenter_ID) AS IDCOUNT FROM edu_DLCenter IC RIGHT JOIN edu_DistanceLearning I ON IC.dlCenter_DLInstituteID = I.distancelearning_id WHERE  IC.dlCenter_City like '%' + @City + '%' AND distancelearning_type='University' GROUP BY I.distancelearning_id, I.distancelearning_name,I.distancelearning_website,I.distancelearning_email, I.distancelearning_featured,I.distancelearning_logo, IC.dlCenter_City ORDER BY I.distancelearning_featured DESC, I.distancelearning_name ASC";
            objCommand = new SqlCommand(strQuery, objConnection);
            objCommand.Parameters.AddWithValue("@City", strCity);
            objReader = objCommand.ExecuteReader();
            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["dlCenter_City"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.iCenterCount = int.Parse(objReader["IDCOUNT"].ToString());
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDLList.Add(objDL);
            }
            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    internal CoreWebList<DistanceLearningClass> fn_GetDistanceCollegesByCity(string strCity)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            string strQuery = "   SELECT I.distancelearning_logo, I.distancelearning_id,I.distancelearning_website,I.distancelearning_email, I.distancelearning_name, I.distancelearning_featured, IC.dlCenter_City, COUNT(IC.dlCenter_ID) AS IDCOUNT FROM edu_DLCenter IC RIGHT JOIN edu_DistanceLearning I ON IC.dlCenter_DLInstituteID = I.distancelearning_id WHERE  IC.dlCenter_City like '%' + @City + '%' AND distancelearning_type='Institute' GROUP BY I.distancelearning_id, I.distancelearning_name,I.distancelearning_website,I.distancelearning_email, I.distancelearning_featured,I.distancelearning_logo, IC.dlCenter_City ORDER BY I.distancelearning_featured DESC, I.distancelearning_name ASC";
            objCommand.Parameters.AddWithValue("@City", strCity);
            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();
            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["dlCenter_City"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.iCenterCount = int.Parse(objReader["IDCOUNT"].ToString());
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDLList.Add(objDL);
            }
            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    internal CoreWebList<DistanceLearningClass> fn_GetDistanceLearningInstitutesByInstName(string strInst)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();


            string strQuery = "SELECT I.distancelearning_logo, I.distancelearning_id,I.distancelearning_website,I.distancelearning_email, I.distancelearning_name, I.distancelearning_featured, IC.dlCenter_City, COUNT(IC.dlCenter_ID) AS IDCOUNT FROM edu_DLCenter IC RIGHT JOIN edu_DistanceLearning I ON IC.dlCenter_DLInstituteID = I.distancelearning_id WHERE  I.distancelearning_name like '%" + strInst + "%' GROUP BY I.distancelearning_id, I.distancelearning_name,I.distancelearning_website,I.distancelearning_email, I.distancelearning_featured,I.distancelearning_logo, IC.dlCenter_City ORDER BY I.distancelearning_featured DESC, I.distancelearning_name ASC";
            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["dlCenter_City"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.iCenterCount = int.Parse(objReader["IDCOUNT"].ToString());
                objDL.strEmail = objReader["distancelearning_email"].ToString();
                objDL.strWebsite = objReader["distancelearning_website"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDLList.Add(objDL);
            }
            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }


    internal CoreWebList<DistanceLearningClass> fn_GetDistanceLearningInstitutesByKeyword(string strQuery)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();


            //string strQuery = "SELECT     I.distancelearning_id,I.distancelearning_name, 		    I.distancelearning_featured, IC.dlCenter_City, COUNT(IC.dlCenter_ID) AS IDCOUNT FROM edu_DLCenter IC RIGHT JOIN edu_DistanceLearning I ON IC.dlCenter_DLInstituteID = I.distancelearning_id Inner join edu_DLCourses DC on I.distancelearning_id = DC.DLCourses_DLID where I.distancelearning_id IN(SELECT DISTINCT(DLCategoryList_DLID) FROM edu_DLCategoryList WHERE DLCategoryList_CatID =" + iCategoryID + " GROUP BY DLCategoryList_CatID, DLCategoryList_DLID)  GROUP BY I.distancelearning_id, I.distancelearning_name, I.distancelearning_featured, IC.dlCenter_City ORDER BY I.distancelearning_featured DESC, I.distancelearning_name ASC";
            
            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["dlCenter_City"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.iCenterCount = int.Parse(objReader["IDCOUNT"].ToString());

                objDLList.Add(objDL);
            }
            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    public CoreWebList<DistanceLearningClass> fn_SearchDistanceLearningListClient(string strSearchQuery)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand(strSearchQuery, objConnection);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strCity = objReader["dlCenter_City"].ToString();
                //objDL.strEmail = objReader["distancelearning_email"].ToString();
                //objDL.strWebsite = objReader["distancelearning_website"].ToString();
                //objDL.strImage = objReader["distancelearning_logo"].ToString();
                //objDL.strDesc = objReader["distancelearning_desc"].ToString();
                //objDL.strContactInfo = objReader["distancelearning_contactinfo"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());

                objDLList.Add(objDL);
            }
            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

   

    public CoreWebList<DistanceLearningClass> fn_GetFeaturedInstitutes(int startRow, int endRow)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("Select * from (select I.distancelearning_id,I.distancelearning_logo,I.distancelearning_name,I.distancelearning_featured,I.distancelearning_city,row_number() OVER (order by distancelearning_name) as TR  from edu_DistanceLearning as I  with(nolock) where I.distancelearning_featured = '1' ) As TR Where TR between  @startRow and @endRow", objConnection);

            objCommand.Parameters.AddWithValue("@startRow", startRow);
            objCommand.Parameters.AddWithValue("@endRow", endRow);

            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strCity = objReader["distancelearning_city"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                
                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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

    public CoreWebList<DistanceLearningClass> fn_Get_FeaturedInstitutesbyLocationAndCatID(string strQuery)
    {
        CoreWebList<DistanceLearningClass> objDLList = null;
        DistanceLearningClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand(strQuery, objConnection);
            

            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DistanceLearningClass>();

            while (objReader.Read())
            {
                objDL = new DistanceLearningClass();
                objDL.iID = int.Parse(objReader["distancelearning_id"].ToString());
                objDL.strName = objReader["distancelearning_name"].ToString();
                objDL.strImage = objReader["distancelearning_logo"].ToString();
                objDL.strCity = objReader["distancelearning_city"].ToString();
                objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());

                objDLList.Add(objDL);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
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
