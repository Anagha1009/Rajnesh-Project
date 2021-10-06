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
/// Summary description for DBEbookClass
/// </summary>
public class DBEbookClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveEbook(EbookClass objEbook)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_Ebooks (Ebook_Title, Ebook_Details, Ebook_File, Ebook_Date) VALUES (@Ebook_Title, @Ebook_Details, @Ebook_File, @Ebook_Date)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Ebook_Title", objEbook.strTitle);
			objCommand.Parameters.AddWithValue("@Ebook_Details", objEbook.strDetails);
			objCommand.Parameters.AddWithValue("@Ebook_File", objEbook.strFile);
			objCommand.Parameters.AddWithValue("@Ebook_Date", objEbook.dtDate);

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

	public string fn_editEbook(EbookClass objEbook)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Ebooks SET Ebook_Title=@Ebook_Title, Ebook_Details=@Ebook_Details, Ebook_File=@Ebook_File, Ebook_Date=@Ebook_Date WHERE Ebook_ID=@Ebook_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Ebook_ID", objEbook.iID);
			objCommand.Parameters.AddWithValue("@Ebook_Title", objEbook.strTitle);
			objCommand.Parameters.AddWithValue("@Ebook_Details", objEbook.strDetails);
			objCommand.Parameters.AddWithValue("@Ebook_File", objEbook.strFile);
			objCommand.Parameters.AddWithValue("@Ebook_Date", objEbook.dtDate);

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

	public string fn_deleteEbook(int iEbookID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Ebooks WHERE Ebook_ID=@Ebook_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Ebook_ID", iEbookID);

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

	public CoreWebList<EbookClass> fn_getEbookList()
	{
		CoreWebList<EbookClass> objEbookList = null;
		EbookClass objEbook = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Ebooks", objConnection);
			objReader = objCommand.ExecuteReader();
			objEbookList = new CoreWebList<EbookClass>();
			while (objReader.Read())
			{
				objEbook = new EbookClass();
				objEbook.iID = int.Parse(objReader["Ebook_ID"].ToString());
				objEbook.strTitle = objReader["Ebook_Title"].ToString();
				objEbook.strDetails = objReader["Ebook_Details"].ToString();
				objEbook.strFile = objReader["Ebook_File"].ToString();
				objEbook.dtDate = DateTime.Parse(objReader["Ebook_Date"].ToString());
				objEbookList.Add(objEbook);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEbookList;
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

	public CoreWebList<EbookClass> fn_getEbookByID(int iEbookID)
	{
		CoreWebList<EbookClass> objEbookList = null;
		EbookClass objEbook = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Ebooks WHERE Ebook_ID=@Ebook_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Ebook_ID", iEbookID);
			objReader = objCommand.ExecuteReader();
			objEbookList = new CoreWebList<EbookClass>();
			if (objReader.Read())
			{
				objEbook = new EbookClass();
				objEbook.iID = int.Parse(objReader["Ebook_ID"].ToString());
				objEbook.strTitle = objReader["Ebook_Title"].ToString();
				objEbook.strDetails = objReader["Ebook_Details"].ToString();
				objEbook.strFile = objReader["Ebook_File"].ToString();
				objEbook.dtDate = DateTime.Parse(objReader["Ebook_Date"].ToString());
				objEbookList.Add(objEbook);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEbookList;
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

	public CoreWebList<EbookClass> fn_getEbookByName(string strEbookTitle)
	{
		CoreWebList<EbookClass> objEbookList = null;
		EbookClass objEbook = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Ebooks WHERE Ebook_Title=@Ebook_Title", objConnection);
			objCommand.Parameters.AddWithValue("@Ebook_Title", strEbookTitle);
			objReader = objCommand.ExecuteReader();
			objEbookList = new CoreWebList<EbookClass>();
			if (objReader.Read())
			{
				objEbook = new EbookClass();
				objEbook.iID = int.Parse(objReader["Ebook_ID"].ToString());
				objEbook.strTitle = objReader["Ebook_Title"].ToString();
				objEbook.strDetails = objReader["Ebook_Details"].ToString();
				objEbook.strFile = objReader["Ebook_File"].ToString();
				objEbook.dtDate = DateTime.Parse(objReader["Ebook_Date"].ToString());
				objEbookList.Add(objEbook);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEbookList;
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

	public CoreWebList<EbookClass> fn_getEbookByKeys(string strEbookTitle)
	{
		CoreWebList<EbookClass> objEbookList = null;
		EbookClass objEbook = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Ebooks WHERE Ebook_Title like '%' + @Ebook_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Ebook_Title", strEbookTitle);
			objReader = objCommand.ExecuteReader();
			objEbookList = new CoreWebList<EbookClass>();
			while (objReader.Read())
			{
				objEbook = new EbookClass();
				objEbook.iID = int.Parse(objReader["Ebook_ID"].ToString());
				objEbook.strTitle = objReader["Ebook_Title"].ToString();
				objEbook.strDetails = objReader["Ebook_Details"].ToString();
				objEbook.strFile = objReader["Ebook_File"].ToString();
				objEbook.dtDate = DateTime.Parse(objReader["Ebook_Date"].ToString());
				objEbookList.Add(objEbook);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEbookList;
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
