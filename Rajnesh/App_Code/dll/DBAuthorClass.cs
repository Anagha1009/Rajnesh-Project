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
/// Summary description for DBAuthorClass
/// </summary>
public class DBAuthorClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveAuthor(AuthorClass objAuthor)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_Authors (Author_Name, Author_Email, Author_ConnectUrl, Author_Details, Author_Photo) VALUES (@Author_Name, @Author_Email, @Author_ConnectUrl, @Author_Details, @Author_Photo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Author_Name", objAuthor.strName);
			objCommand.Parameters.AddWithValue("@Author_Email", objAuthor.strEmail);
			objCommand.Parameters.AddWithValue("@Author_ConnectUrl", objAuthor.strConnectUrl);
			objCommand.Parameters.AddWithValue("@Author_Details", objAuthor.strDetails);
			objCommand.Parameters.AddWithValue("@Author_Photo", objAuthor.strPhoto);

			if (objCommand.ExecuteNonQuery() > 0)
			{
				return "SUCCESS : Record has been inserted successfully!";
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

	public string fn_editAuthor(AuthorClass objAuthor)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Authors SET Author_Name=@Author_Name, Author_Email=@Author_Email, Author_ConnectUrl=@Author_ConnectUrl, Author_Details=@Author_Details, Author_Photo=@Author_Photo WHERE Author_ID=@Author_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Author_ID", objAuthor.iID);
			objCommand.Parameters.AddWithValue("@Author_Name", objAuthor.strName);
			objCommand.Parameters.AddWithValue("@Author_Email", objAuthor.strEmail);
			objCommand.Parameters.AddWithValue("@Author_ConnectUrl", objAuthor.strConnectUrl);
			objCommand.Parameters.AddWithValue("@Author_Details", objAuthor.strDetails);
			objCommand.Parameters.AddWithValue("@Author_Photo", objAuthor.strPhoto);

			if (objCommand.ExecuteNonQuery() > 0)
			{
				return "SUCCESS : Record has been updated successfully!";
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

	public string fn_deleteAuthor(int iAuthorID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Authors WHERE Author_ID=@Author_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Author_ID", iAuthorID);

			if (objCommand.ExecuteNonQuery() > 0)
			{
				return "SUCCESS : Record has been deleted successfully!";
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

	public CoreWebList<AuthorClass> fn_getAuthorList()
	{
		CoreWebList<AuthorClass> objAuthorList = null;
		AuthorClass objAuthor = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Authors", objConnection);
			objReader = objCommand.ExecuteReader();
			objAuthorList = new CoreWebList<AuthorClass>();
			while (objReader.Read())
			{
				objAuthor = new AuthorClass();
				objAuthor.iID = int.Parse(objReader["Author_ID"].ToString());
				objAuthor.strName = objReader["Author_Name"].ToString();
				objAuthor.strEmail = objReader["Author_Email"].ToString();
				objAuthor.strConnectUrl = objReader["Author_ConnectUrl"].ToString();
				objAuthor.strDetails = objReader["Author_Details"].ToString();
				objAuthor.strPhoto = objReader["Author_Photo"].ToString();
				objAuthorList.Add(objAuthor);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objAuthorList;
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

	public CoreWebList<AuthorClass> fn_getAuthorByID(int iAuthorID)
	{
		CoreWebList<AuthorClass> objAuthorList = null;
		AuthorClass objAuthor = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Authors WHERE Author_ID=@Author_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Author_ID", iAuthorID);
			objReader = objCommand.ExecuteReader();
			objAuthorList = new CoreWebList<AuthorClass>();
			if (objReader.Read())
			{
				objAuthor = new AuthorClass();
				objAuthor.iID = int.Parse(objReader["Author_ID"].ToString());
				objAuthor.strName = objReader["Author_Name"].ToString();
				objAuthor.strEmail = objReader["Author_Email"].ToString();
				objAuthor.strConnectUrl = objReader["Author_ConnectUrl"].ToString();
				objAuthor.strDetails = objReader["Author_Details"].ToString();
				objAuthor.strPhoto = objReader["Author_Photo"].ToString();
				objAuthorList.Add(objAuthor);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objAuthorList;
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

	public CoreWebList<AuthorClass> fn_getAuthorByName(string strAuthorName)
	{
		CoreWebList<AuthorClass> objAuthorList = null;
		AuthorClass objAuthor = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Authors WHERE Author_Name=@Author_Name", objConnection);
			objCommand.Parameters.AddWithValue("@Author_Name", strAuthorName);
			objReader = objCommand.ExecuteReader();
			objAuthorList = new CoreWebList<AuthorClass>();
			if (objReader.Read())
			{
				objAuthor = new AuthorClass();
				objAuthor.iID = int.Parse(objReader["Author_ID"].ToString());
				objAuthor.strName = objReader["Author_Name"].ToString();
				objAuthor.strEmail = objReader["Author_Email"].ToString();
				objAuthor.strConnectUrl = objReader["Author_ConnectUrl"].ToString();
				objAuthor.strDetails = objReader["Author_Details"].ToString();
				objAuthor.strPhoto = objReader["Author_Photo"].ToString();
				objAuthorList.Add(objAuthor);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objAuthorList;
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

	public CoreWebList<AuthorClass> fn_getAuthorByKeys(string strAuthorName)
	{
		CoreWebList<AuthorClass> objAuthorList = null;
		AuthorClass objAuthor = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Authors WHERE Author_Name like '%' + @Author_Name + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Author_Name", strAuthorName);
			objReader = objCommand.ExecuteReader();
			objAuthorList = new CoreWebList<AuthorClass>();
			while (objReader.Read())
			{
				objAuthor = new AuthorClass();
				objAuthor.iID = int.Parse(objReader["Author_ID"].ToString());
				objAuthor.strName = objReader["Author_Name"].ToString();
				objAuthor.strEmail = objReader["Author_Email"].ToString();
				objAuthor.strConnectUrl = objReader["Author_ConnectUrl"].ToString();
				objAuthor.strDetails = objReader["Author_Details"].ToString();
				objAuthor.strPhoto = objReader["Author_Photo"].ToString();
				objAuthorList.Add(objAuthor);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objAuthorList;
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


    public CoreWebList<AuthorClass> fn_getTopAuthorList()
    {
        CoreWebList<AuthorClass> objAuthorList = null;
        AuthorClass objAuthor = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 1 * FROM tbl_Authors ORDER BY Author_ID ASC", objConnection);
            objReader = objCommand.ExecuteReader();
            objAuthorList = new CoreWebList<AuthorClass>();
            while (objReader.Read())
            {
                objAuthor = new AuthorClass();
                objAuthor.iID = int.Parse(objReader["Author_ID"].ToString());
                objAuthor.strName = objReader["Author_Name"].ToString();
                objAuthor.strEmail = objReader["Author_Email"].ToString();
                objAuthor.strConnectUrl = objReader["Author_ConnectUrl"].ToString();
                objAuthor.strDetails = objReader["Author_Details"].ToString();
                objAuthor.strPhoto = objReader["Author_Photo"].ToString();
                objAuthorList.Add(objAuthor);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objAuthorList;
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
