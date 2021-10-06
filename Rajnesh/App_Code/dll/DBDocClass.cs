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
/// Summary description for DBDocClass
/// </summary>
public class DBDocClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveDoc(DocClass objDoc)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_Docs (Doc_File) VALUES (@Doc_File)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Doc_File", objDoc.strFile);

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

	public string fn_editDoc(DocClass objDoc)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Docs SET Doc_File=@Doc_File WHERE Doc_ID=@Doc_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Doc_ID", objDoc.iID);
			objCommand.Parameters.AddWithValue("@Doc_File", objDoc.strFile);

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

	public string fn_deleteDoc(int iDocID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Docs WHERE Doc_ID=@Doc_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Doc_ID", iDocID);

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

	public CoreWebList<DocClass> fn_getDocList()
	{
		CoreWebList<DocClass> objDocList = null;
		DocClass objDoc = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Docs", objConnection);
			objReader = objCommand.ExecuteReader();
			objDocList = new CoreWebList<DocClass>();
			while (objReader.Read())
			{
				objDoc = new DocClass();
				objDoc.iID = int.Parse(objReader["Doc_ID"].ToString());
				objDoc.strFile = objReader["Doc_File"].ToString();
				objDocList.Add(objDoc);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objDocList;
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

	public CoreWebList<DocClass> fn_getDocByID(int iDocID)
	{
		CoreWebList<DocClass> objDocList = null;
		DocClass objDoc = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Docs WHERE Doc_ID=@Doc_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Doc_ID", iDocID);
			objReader = objCommand.ExecuteReader();
			objDocList = new CoreWebList<DocClass>();
			if (objReader.Read())
			{
				objDoc = new DocClass();
				objDoc.iID = int.Parse(objReader["Doc_ID"].ToString());
				objDoc.strFile = objReader["Doc_File"].ToString();
				objDocList.Add(objDoc);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objDocList;
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

    public CoreWebList<DocClass> fn_getDocByKeys(string strFile)
    {
        CoreWebList<DocClass> objDocList = null;
        DocClass objDoc = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Docs WHERE Doc_File like '%' + @Doc_File + '%'", objConnection);
            objCommand.Parameters.AddWithValue("@Doc_File", strFile);
            objReader = objCommand.ExecuteReader();
            objDocList = new CoreWebList<DocClass>();
            while (objReader.Read())
            {
                objDoc = new DocClass();
                objDoc.iID = int.Parse(objReader["Doc_ID"].ToString());
                objDoc.strFile = objReader["Doc_File"].ToString();
                objDocList.Add(objDoc);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objDocList;
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
