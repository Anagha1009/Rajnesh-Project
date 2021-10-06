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
/// Summary description for DBCategoryLinkClass
/// </summary>
public class DBCategoryLinkClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveCategoryLink(CategoryLinkClass objCategoryLink)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_CategoryLinks (CategoryLink_CategoryID, CategoryLink_Title, CategoryLink_Url) VALUES (@CategoryLink_CategoryID, @CategoryLink_Title, @CategoryLink_Url)",objConnection) ;
			objCommand.Parameters.AddWithValue("@CategoryLink_CategoryID", objCategoryLink.iCategoryID);
			objCommand.Parameters.AddWithValue("@CategoryLink_Title", objCategoryLink.strTitle);
			objCommand.Parameters.AddWithValue("@CategoryLink_Url", objCategoryLink.strUrl);

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

	public string fn_editCategoryLink(CategoryLinkClass objCategoryLink)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_CategoryLinks SET CategoryLink_CategoryID=@CategoryLink_CategoryID, CategoryLink_Title=@CategoryLink_Title, CategoryLink_Url=@CategoryLink_Url WHERE CategoryLink_ID=@CategoryLink_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CategoryLink_ID", objCategoryLink.iID);
			objCommand.Parameters.AddWithValue("@CategoryLink_CategoryID", objCategoryLink.iCategoryID);
			objCommand.Parameters.AddWithValue("@CategoryLink_Title", objCategoryLink.strTitle);
			objCommand.Parameters.AddWithValue("@CategoryLink_Url", objCategoryLink.strUrl);

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

	public string fn_deleteCategoryLink(int iCategoryLinkID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_CategoryLinks WHERE CategoryLink_ID=@CategoryLink_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CategoryLink_ID", iCategoryLinkID);

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

	public CoreWebList<CategoryLinkClass> fn_getCategoryLinkList()
	{
		CoreWebList<CategoryLinkClass> objCategoryLinkList = null;
		CategoryLinkClass objCategoryLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CategoryLinks", objConnection);
			objReader = objCommand.ExecuteReader();
			objCategoryLinkList = new CoreWebList<CategoryLinkClass>();
			while (objReader.Read())
			{
				objCategoryLink = new CategoryLinkClass();
				objCategoryLink.iID = int.Parse(objReader["CategoryLink_ID"].ToString());
				objCategoryLink.iCategoryID = int.Parse(objReader["CategoryLink_CategoryID"].ToString());
				objCategoryLink.strTitle = objReader["CategoryLink_Title"].ToString();
				objCategoryLink.strUrl = objReader["CategoryLink_Url"].ToString();
				objCategoryLinkList.Add(objCategoryLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCategoryLinkList;
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

	public CoreWebList<CategoryLinkClass> fn_getCategoryLinkByID(int iCategoryLinkID)
	{
		CoreWebList<CategoryLinkClass> objCategoryLinkList = null;
		CategoryLinkClass objCategoryLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CategoryLinks WHERE CategoryLink_ID=@CategoryLink_ID", objConnection);
			objCommand.Parameters.AddWithValue("@CategoryLink_ID", iCategoryLinkID);
			objReader = objCommand.ExecuteReader();
			objCategoryLinkList = new CoreWebList<CategoryLinkClass>();
			if (objReader.Read())
			{
				objCategoryLink = new CategoryLinkClass();
				objCategoryLink.iID = int.Parse(objReader["CategoryLink_ID"].ToString());
				objCategoryLink.iCategoryID = int.Parse(objReader["CategoryLink_CategoryID"].ToString());
				objCategoryLink.strTitle = objReader["CategoryLink_Title"].ToString();
				objCategoryLink.strUrl = objReader["CategoryLink_Url"].ToString();
				objCategoryLinkList.Add(objCategoryLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCategoryLinkList;
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

	public CoreWebList<CategoryLinkClass> fn_getCategoryLinkByName(string strCategoryLinkTitle)
	{
		CoreWebList<CategoryLinkClass> objCategoryLinkList = null;
		CategoryLinkClass objCategoryLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CategoryLinks WHERE CategoryLink_Title=@CategoryLink_Title", objConnection);
			objCommand.Parameters.AddWithValue("@CategoryLink_Title", strCategoryLinkTitle);
			objReader = objCommand.ExecuteReader();
			objCategoryLinkList = new CoreWebList<CategoryLinkClass>();
			if (objReader.Read())
			{
				objCategoryLink = new CategoryLinkClass();
				objCategoryLink.iID = int.Parse(objReader["CategoryLink_ID"].ToString());
				objCategoryLink.iCategoryID = int.Parse(objReader["CategoryLink_CategoryID"].ToString());
				objCategoryLink.strTitle = objReader["CategoryLink_Title"].ToString();
				objCategoryLink.strUrl = objReader["CategoryLink_Url"].ToString();
				objCategoryLinkList.Add(objCategoryLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCategoryLinkList;
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

	public CoreWebList<CategoryLinkClass> fn_getCategoryLinkByKeys(string strCategoryLinkTitle)
	{
		CoreWebList<CategoryLinkClass> objCategoryLinkList = null;
		CategoryLinkClass objCategoryLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CategoryLinks WHERE CategoryLink_Title like '%' + @CategoryLink_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@CategoryLink_Title", strCategoryLinkTitle);
			objReader = objCommand.ExecuteReader();
			objCategoryLinkList = new CoreWebList<CategoryLinkClass>();
			while (objReader.Read())
			{
				objCategoryLink = new CategoryLinkClass();
				objCategoryLink.iID = int.Parse(objReader["CategoryLink_ID"].ToString());
				objCategoryLink.iCategoryID = int.Parse(objReader["CategoryLink_CategoryID"].ToString());
				objCategoryLink.strTitle = objReader["CategoryLink_Title"].ToString();
				objCategoryLink.strUrl = objReader["CategoryLink_Url"].ToString();
				objCategoryLinkList.Add(objCategoryLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCategoryLinkList;
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

	public CoreWebList<CategoryLinkClass> fn_getCategoryLinkByCategoryID(int iCategoryID)
	{
		CoreWebList<CategoryLinkClass> objCategoryLinkList = null;
		CategoryLinkClass objCategoryLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CategoryLinks WHERE CategoryLink_CategoryID=@CategoryLink_CategoryID", objConnection);
			objCommand.Parameters.AddWithValue("@CategoryLink_CategoryID", iCategoryID);
			objReader = objCommand.ExecuteReader();
			objCategoryLinkList = new CoreWebList<CategoryLinkClass>();
			while (objReader.Read())
			{
				objCategoryLink = new CategoryLinkClass();
				objCategoryLink.iID = int.Parse(objReader["CategoryLink_ID"].ToString());
				objCategoryLink.iCategoryID = int.Parse(objReader["CategoryLink_CategoryID"].ToString());
				objCategoryLink.strTitle = objReader["CategoryLink_Title"].ToString();
				objCategoryLink.strUrl = objReader["CategoryLink_Url"].ToString();
				objCategoryLinkList.Add(objCategoryLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCategoryLinkList;
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
