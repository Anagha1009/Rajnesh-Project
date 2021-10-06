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
/// Summary description for DBEntranceCategoryClass
/// </summary>
public class DBEntranceCategoryClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveEntranceCategory(EntranceCategoryClass objEntranceCategory)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_EntranceCategory (EntranceCategory_Title, EntranceCategory_Desc) VALUES (@EntranceCategory_Title, @EntranceCategory_Desc)",objConnection) ;
			objCommand.Parameters.AddWithValue("@EntranceCategory_Title", objEntranceCategory.strTitle);
			objCommand.Parameters.AddWithValue("@EntranceCategory_Desc", objEntranceCategory.strDesc);

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

	public string fn_editEntranceCategory(EntranceCategoryClass objEntranceCategory)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_EntranceCategory SET EntranceCategory_Title=@EntranceCategory_Title, EntranceCategory_Desc=@EntranceCategory_Desc WHERE EntranceCategory_ID=@EntranceCategory_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@EntranceCategory_ID", objEntranceCategory.iID);
			objCommand.Parameters.AddWithValue("@EntranceCategory_Title", objEntranceCategory.strTitle);
			objCommand.Parameters.AddWithValue("@EntranceCategory_Desc", objEntranceCategory.strDesc);

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

	public string fn_deleteEntranceCategory(int iEntranceCategoryID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_EntranceCategory WHERE EntranceCategory_ID=@EntranceCategory_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@EntranceCategory_ID", iEntranceCategoryID);

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

	public CoreWebList<EntranceCategoryClass> fn_getEntranceCategoryList()
	{
		CoreWebList<EntranceCategoryClass> objEntranceCategoryList = null;
		EntranceCategoryClass objEntranceCategory = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EntranceCategory", objConnection);
			objReader = objCommand.ExecuteReader();
			objEntranceCategoryList = new CoreWebList<EntranceCategoryClass>();
			while (objReader.Read())
			{
				objEntranceCategory = new EntranceCategoryClass();
				objEntranceCategory.iID = int.Parse(objReader["EntranceCategory_ID"].ToString());
				objEntranceCategory.strTitle = objReader["EntranceCategory_Title"].ToString();
				objEntranceCategory.strDesc = objReader["EntranceCategory_Desc"].ToString();
				objEntranceCategoryList.Add(objEntranceCategory);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEntranceCategoryList;
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

	public CoreWebList<EntranceCategoryClass> fn_getEntranceCategoryByID(int iEntranceCategoryID)
	{
		CoreWebList<EntranceCategoryClass> objEntranceCategoryList = null;
		EntranceCategoryClass objEntranceCategory = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EntranceCategory WHERE EntranceCategory_ID=@EntranceCategory_ID", objConnection);
			objCommand.Parameters.AddWithValue("@EntranceCategory_ID", iEntranceCategoryID);
			objReader = objCommand.ExecuteReader();
			objEntranceCategoryList = new CoreWebList<EntranceCategoryClass>();
			if (objReader.Read())
			{
				objEntranceCategory = new EntranceCategoryClass();
				objEntranceCategory.iID = int.Parse(objReader["EntranceCategory_ID"].ToString());
				objEntranceCategory.strTitle = objReader["EntranceCategory_Title"].ToString();
				objEntranceCategory.strDesc = objReader["EntranceCategory_Desc"].ToString();
				objEntranceCategoryList.Add(objEntranceCategory);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEntranceCategoryList;
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

	public CoreWebList<EntranceCategoryClass> fn_getEntranceCategoryByName(string strEntranceCategoryTitle)
	{
		CoreWebList<EntranceCategoryClass> objEntranceCategoryList = null;
		EntranceCategoryClass objEntranceCategory = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EntranceCategory WHERE EntranceCategory_Title=@EntranceCategory_Title", objConnection);
			objCommand.Parameters.AddWithValue("@EntranceCategory_Title", strEntranceCategoryTitle);
			objReader = objCommand.ExecuteReader();
			objEntranceCategoryList = new CoreWebList<EntranceCategoryClass>();
			if (objReader.Read())
			{
				objEntranceCategory = new EntranceCategoryClass();
				objEntranceCategory.iID = int.Parse(objReader["EntranceCategory_ID"].ToString());
				objEntranceCategory.strTitle = objReader["EntranceCategory_Title"].ToString();
				objEntranceCategory.strDesc = objReader["EntranceCategory_Desc"].ToString();
				objEntranceCategoryList.Add(objEntranceCategory);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEntranceCategoryList;
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

	public CoreWebList<EntranceCategoryClass> fn_getEntranceCategoryByKeys(string strEntranceCategoryTitle)
	{
		CoreWebList<EntranceCategoryClass> objEntranceCategoryList = null;
		EntranceCategoryClass objEntranceCategory = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EntranceCategory WHERE EntranceCategory_Title like '%' + @EntranceCategory_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@EntranceCategory_Title", strEntranceCategoryTitle);
			objReader = objCommand.ExecuteReader();
			objEntranceCategoryList = new CoreWebList<EntranceCategoryClass>();
			while (objReader.Read())
			{
				objEntranceCategory = new EntranceCategoryClass();
				objEntranceCategory.iID = int.Parse(objReader["EntranceCategory_ID"].ToString());
				objEntranceCategory.strTitle = objReader["EntranceCategory_Title"].ToString();
				objEntranceCategory.strDesc = objReader["EntranceCategory_Desc"].ToString();
				objEntranceCategoryList.Add(objEntranceCategory);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEntranceCategoryList;
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
