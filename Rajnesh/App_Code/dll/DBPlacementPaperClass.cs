using System;
using System.Data.SqlClient;
using System.Configuration;
using yo_lib;

/// <summary>
/// Summary description for DBPlacementPaperClass
/// </summary>
public class DBPlacementPaperClass
{
	private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string fn_SavePaper(string strCompanyName, string strDescription, string strSubmittedBy, string strSubmittedByEmail)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_PlacementPapers(Paper_CompanyName, Paper_Description, Paper_SubmittedBy, Paper_SubmittedByEmail, Paper_SubmittedOn) VALUES (@Paper_CompanyName, @Paper_Description, @Paper_SubmittedBy, @Paper_SubmittedByEmail, @Paper_SubmittedOn)", objConnection);

            objCommand.Parameters.AddWithValue("@Paper_CompanyName", strCompanyName);
            objCommand.Parameters.AddWithValue("@Paper_Description", strDescription);
            objCommand.Parameters.AddWithValue("@Paper_SubmittedBy", strSubmittedBy);
            objCommand.Parameters.AddWithValue("@Paper_SubmittedByEmail", strSubmittedByEmail);
            objCommand.Parameters.AddWithValue("@Paper_SubmittedOn", DateTime.Now);
            
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

    public string fn_EditPaper(int iID, string strCompanyName, string strDescription)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_PlacementPapers SET Paper_CompanyName = @Paper_CompanyName, Paper_Description = @Paper_Description WHERE Paper_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@Paper_CompanyName", strCompanyName);
            objCommand.Parameters.AddWithValue("@Paper_Description", strDescription);
            
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

    public string fn_Deletepaper(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_PlacementPapers WHERE Paper_id = @ID", objConnection);

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
    
    public CoreWebList<PlacementPaperClass> fn_GetPaperList()
    {
        CoreWebList<PlacementPaperClass> objPaperList = null;
        PlacementPaperClass objPaper = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_PlacementPapers", objConnection);

            objReader = objCommand.ExecuteReader();

            objPaperList = new CoreWebList<PlacementPaperClass>();

            while (objReader.Read())
            {
                objPaper = new PlacementPaperClass();

                objPaper.iID = int.Parse(objReader["Paper_id"].ToString());
                objPaper.strCompanyName = objReader["Paper_CompanyName"].ToString();
                objPaper.strDescription = objReader["Paper_Description"].ToString();
                objPaper.strSubmittedBy = objReader["Paper_SubmittedBy"].ToString();
                objPaper.strSubmittedByEmail = objReader["Paper_SubmittedByEmail"].ToString();
                objPaper.dtSubmittedDate = Convert.ToDateTime(objReader["Paper_SubmittedOn"].ToString());
                
                objPaperList.Add(objPaper);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objPaperList;
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

    public CoreWebList<PlacementPaperClass> fn_GetPaperByID(int iID)
    {
        CoreWebList<PlacementPaperClass> objPaperList = null;
        PlacementPaperClass objPaper = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_PlacementPapers WHERE Paper_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objPaperList = new CoreWebList<PlacementPaperClass>();

            if (objReader.Read())
            {
                objPaper = new PlacementPaperClass();

                objPaper.iID = int.Parse(objReader["Paper_id"].ToString());
                objPaper.strCompanyName = objReader["Paper_CompanyName"].ToString();
                objPaper.strDescription = objReader["Paper_Description"].ToString();
                objPaper.strSubmittedBy = objReader["Paper_SubmittedBy"].ToString();
                objPaper.strSubmittedByEmail = objReader["Paper_SubmittedByEmail"].ToString();
                objPaper.dtSubmittedDate = Convert.ToDateTime(objReader["Paper_SubmittedOn"].ToString());

                objPaperList.Add(objPaper);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objPaperList;
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