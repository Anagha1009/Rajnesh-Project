using System;
using System.Data.SqlClient;
using System.Configuration;
using yo_lib;

/// <summary>
/// Summary description for DBPaperClass
/// </summary>
public class DBPaperClass
{
	private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string fn_SavePaper(string strTile, string strCompany, string strDescription, string strCategory)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_papers(paper_title, paper_company, paper_desc, paper_date, paper_category) VALUES (@paper_title, @paper_company, @paper_desc, @paper_date, @paper_category)", objConnection);

            objCommand.Parameters.AddWithValue("@paper_title", strTile);
            objCommand.Parameters.AddWithValue("@paper_company", strCompany);
            objCommand.Parameters.AddWithValue("@paper_desc", strDescription);
            objCommand.Parameters.AddWithValue("@paper_date", DateTime.Now);
            objCommand.Parameters.AddWithValue("@paper_category", strCategory);
            
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

    public string fn_EditPaper(int iID, string strTile, string strCompany, string strDescription, string strCategory)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_papers SET paper_title = @paper_title, paper_company = @paper_company, paper_desc = @paper_desc, paper_category = @paper_category WHERE paper_Id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@paper_title", strTile);
            objCommand.Parameters.AddWithValue("@paper_company", strCompany);
            objCommand.Parameters.AddWithValue("@paper_desc", strDescription);
            objCommand.Parameters.AddWithValue("@paper_category", strCategory);
            
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

            objCommand = new SqlCommand("DELETE FROM edu_papers WHERE paper_Id = @ID", objConnection);

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
    
    public CoreWebList<PaperClass> fn_GetPaperList()
    {
        CoreWebList<PaperClass> objPaperList = null;
        PaperClass objPaper = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_papers", objConnection);

            objReader = objCommand.ExecuteReader();

            objPaperList = new CoreWebList<PaperClass>();

            while (objReader.Read())
            {
                objPaper = new PaperClass();

                objPaper.iID = int.Parse(objReader["paper_Id"].ToString());
                objPaper.strTitle = objReader["paper_title"].ToString();
                objPaper.strCompany = objReader["paper_company"].ToString();
                objPaper.strDescription = objReader["paper_desc"].ToString();
                objPaper.dtDate = Convert.ToDateTime(objReader["paper_date"].ToString());
                
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

    public CoreWebList<PaperClass> fn_GetPaperListByPageTitle(string strTitle)
    {
        CoreWebList<PaperClass> objPaperList = null;
        PaperClass objPaper = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_papers WHERE paper_title like '%" + strTitle + "%'", objConnection);

            objReader = objCommand.ExecuteReader();

            objPaperList = new CoreWebList<PaperClass>();

            while (objReader.Read())
            {
                objPaper = new PaperClass();

                objPaper.iID = int.Parse(objReader["paper_Id"].ToString());
                objPaper.strTitle = objReader["paper_title"].ToString();
                objPaper.strCompany = objReader["paper_company"].ToString();
                objPaper.strDescription = objReader["paper_desc"].ToString();
                objPaper.dtDate = Convert.ToDateTime(objReader["paper_date"].ToString());

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

    public CoreWebList<PaperClass> fn_GetPaperByID(int iID)
    {
        CoreWebList<PaperClass> objPaperList = null;
        PaperClass objPaper = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_papers WHERE Paper_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objPaperList = new CoreWebList<PaperClass>();

            if (objReader.Read())
            {
                objPaper = new PaperClass();

                objPaper.iID = int.Parse(objReader["paper_Id"].ToString());
                objPaper.strTitle = objReader["paper_title"].ToString();
                objPaper.strCompany = objReader["paper_company"].ToString();
                objPaper.strCategory = objReader["paper_category"].ToString();
                objPaper.strDescription = objReader["paper_desc"].ToString();
                objPaper.dtDate = Convert.ToDateTime(objReader["paper_date"].ToString());

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

    public CoreWebList<PaperClass> fn_GetPaperByQuery(string strQuery)
    {
        CoreWebList<PaperClass> objPaperList = null;
        PaperClass objPaper = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand(strQuery, objConnection);
            
            objReader = objCommand.ExecuteReader();

            objPaperList = new CoreWebList<PaperClass>();

            while (objReader.Read())
            {
                objPaper = new PaperClass();

                objPaper.iID = int.Parse(objReader["paper_Id"].ToString());
                objPaper.strTitle = objReader["paper_title"].ToString();
                objPaper.strCompany = objReader["paper_company"].ToString();
                objPaper.strDescription = objReader["paper_desc"].ToString();
                objPaper.dtDate = Convert.ToDateTime(objReader["paper_date"].ToString());

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