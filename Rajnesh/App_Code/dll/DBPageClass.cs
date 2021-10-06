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
/// Summary description for DBPageClass
/// </summary>
public class DBPageClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_savePage(PageClass objPage)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_Pages (Page_CategoryID, Page_Title, Page_Details) VALUES (@Page_CategoryID, @Page_Title, @Page_Details)", objConnection);
			objCommand.Parameters.AddWithValue("@Page_CategoryID", objPage.iCategoryID);
			objCommand.Parameters.AddWithValue("@Page_Title", objPage.strTitle);
            objCommand.Parameters.AddWithValue("@Page_Details", objPage.strDetails);

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

	public string fn_editPage(PageClass objPage)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_Pages SET Page_Title=@Page_Title, Page_Details=@Page_Details WHERE Page_ID=@Page_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Page_ID", objPage.iID);
            objCommand.Parameters.AddWithValue("@Page_Title", objPage.strTitle);
            objCommand.Parameters.AddWithValue("@Page_Details", objPage.strDetails);

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

	public string fn_deletePage(int iPageID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Pages WHERE Page_ID=@Page_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Page_ID", iPageID);

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

	public CoreWebList<PageClass> fn_getPageList()
	{
		CoreWebList<PageClass> objPageList = null;
		PageClass objPage = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Pages", objConnection);
			objReader = objCommand.ExecuteReader();
			objPageList = new CoreWebList<PageClass>();
			while (objReader.Read())
			{
				objPage = new PageClass();
				objPage.iID = int.Parse(objReader["Page_ID"].ToString());
				objPage.iCategoryID = int.Parse(objReader["Page_CategoryID"].ToString());
				objPage.strTitle = objReader["Page_Title"].ToString();
                objPage.strDetails = objReader["Page_Details"].ToString();
				objPageList.Add(objPage);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objPageList;
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

	public CoreWebList<PageClass> fn_getPageByID(int iPageID)
	{
		CoreWebList<PageClass> objPageList = null;
		PageClass objPage = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Pages WHERE Page_ID=@Page_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Page_ID", iPageID);
			objReader = objCommand.ExecuteReader();
			objPageList = new CoreWebList<PageClass>();
			if (objReader.Read())
			{
				objPage = new PageClass();
				objPage.iID = int.Parse(objReader["Page_ID"].ToString());
				objPage.iCategoryID = int.Parse(objReader["Page_CategoryID"].ToString());
				objPage.strTitle = objReader["Page_Title"].ToString();
                objPage.strDetails = objReader["Page_Details"].ToString();
				objPageList.Add(objPage);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objPageList;
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

	public CoreWebList<PageClass> fn_getPageByName(string strPageTitle)
	{
		CoreWebList<PageClass> objPageList = null;
		PageClass objPage = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Pages WHERE Page_Title=@Page_Title", objConnection);
			objCommand.Parameters.AddWithValue("@Page_Title", strPageTitle);
			objReader = objCommand.ExecuteReader();
			objPageList = new CoreWebList<PageClass>();
			if (objReader.Read())
			{
				objPage = new PageClass();
				objPage.iID = int.Parse(objReader["Page_ID"].ToString());
				objPage.iCategoryID = int.Parse(objReader["Page_CategoryID"].ToString());
				objPage.strTitle = objReader["Page_Title"].ToString();
                objPage.strDetails = objReader["Page_Details"].ToString();
				objPageList.Add(objPage);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objPageList;
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

	public CoreWebList<PageClass> fn_getPageByKeys(string strPageTitle)
	{
		CoreWebList<PageClass> objPageList = null;
		PageClass objPage = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Pages WHERE Page_Title like '%' + @Page_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Page_Title", strPageTitle);
			objReader = objCommand.ExecuteReader();
			objPageList = new CoreWebList<PageClass>();
			while (objReader.Read())
			{
				objPage = new PageClass();
				objPage.iID = int.Parse(objReader["Page_ID"].ToString());
				objPage.iCategoryID = int.Parse(objReader["Page_CategoryID"].ToString());
				objPage.strTitle = objReader["Page_Title"].ToString();
                objPage.strDetails = objReader["Page_Details"].ToString();
				objPageList.Add(objPage);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objPageList;
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

	public CoreWebList<PageClass> fn_getPageByCategoryID(int iCategoryID)
	{
		CoreWebList<PageClass> objPageList = null;
		PageClass objPage = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Pages WHERE Page_CategoryID=@Page_CategoryID", objConnection);
			objCommand.Parameters.AddWithValue("@Page_CategoryID", iCategoryID);
			objReader = objCommand.ExecuteReader();
			objPageList = new CoreWebList<PageClass>();
			while (objReader.Read())
			{
				objPage = new PageClass();
				objPage.iID = int.Parse(objReader["Page_ID"].ToString());
				objPage.iCategoryID = int.Parse(objReader["Page_CategoryID"].ToString());
				objPage.strTitle = objReader["Page_Title"].ToString();
                objPage.strDetails = objReader["Page_Details"].ToString();
				objPageList.Add(objPage);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objPageList;
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
