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
/// Summary description for DBPageGeneratorClass
/// </summary>
public class DBPageGeneratorClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_savePageGenerator(PageGeneratorClass objPageGenerator)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_PageGenerator (PageGenerator_Title, PageGenerator_Details, PageGenerator_MetaTitle, PageGenerator_MetaDesc, PageGenerator_MetaKeys, PageGenerator_Photo, PageGenerator_CreatedDate) VALUES (@PageGenerator_Title, @PageGenerator_Details, @PageGenerator_MetaTitle, @PageGenerator_MetaDesc, @PageGenerator_MetaKeys, @PageGenerator_Photo, @PageGenerator_CreatedDate)",objConnection) ;
			objCommand.Parameters.AddWithValue("@PageGenerator_Title", objPageGenerator.strTitle);
			objCommand.Parameters.AddWithValue("@PageGenerator_Details", objPageGenerator.strDetails);
			objCommand.Parameters.AddWithValue("@PageGenerator_MetaTitle", objPageGenerator.strMetaTitle);
			objCommand.Parameters.AddWithValue("@PageGenerator_MetaDesc", objPageGenerator.strMetaDesc);
			objCommand.Parameters.AddWithValue("@PageGenerator_MetaKeys", objPageGenerator.strMetaKeys);
			objCommand.Parameters.AddWithValue("@PageGenerator_Photo", objPageGenerator.strPhoto);
			objCommand.Parameters.AddWithValue("@PageGenerator_CreatedDate", objPageGenerator.dtCreatedDate);

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

	public string fn_editPageGenerator(PageGeneratorClass objPageGenerator)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_PageGenerator SET PageGenerator_Title=@PageGenerator_Title, PageGenerator_Details=@PageGenerator_Details, PageGenerator_MetaTitle=@PageGenerator_MetaTitle, PageGenerator_MetaDesc=@PageGenerator_MetaDesc, PageGenerator_MetaKeys=@PageGenerator_MetaKeys, PageGenerator_Photo=@PageGenerator_Photo, PageGenerator_CreatedDate=@PageGenerator_CreatedDate WHERE PageGenerator_ID=@PageGenerator_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@PageGenerator_ID", objPageGenerator.iID);
			objCommand.Parameters.AddWithValue("@PageGenerator_Title", objPageGenerator.strTitle);
			objCommand.Parameters.AddWithValue("@PageGenerator_Details", objPageGenerator.strDetails);
			objCommand.Parameters.AddWithValue("@PageGenerator_MetaTitle", objPageGenerator.strMetaTitle);
			objCommand.Parameters.AddWithValue("@PageGenerator_MetaDesc", objPageGenerator.strMetaDesc);
			objCommand.Parameters.AddWithValue("@PageGenerator_MetaKeys", objPageGenerator.strMetaKeys);
			objCommand.Parameters.AddWithValue("@PageGenerator_Photo", objPageGenerator.strPhoto);
			objCommand.Parameters.AddWithValue("@PageGenerator_CreatedDate", objPageGenerator.dtCreatedDate);

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

	public string fn_deletePageGenerator(int iPageGeneratorID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_PageGenerator WHERE PageGenerator_ID=@PageGenerator_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@PageGenerator_ID", iPageGeneratorID);

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

	public CoreWebList<PageGeneratorClass> fn_getPageGeneratorList()
	{
		CoreWebList<PageGeneratorClass> objPageGeneratorList = null;
		PageGeneratorClass objPageGenerator = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_PageGenerator", objConnection);
			objReader = objCommand.ExecuteReader();
			objPageGeneratorList = new CoreWebList<PageGeneratorClass>();
			while (objReader.Read())
			{
				objPageGenerator = new PageGeneratorClass();
				objPageGenerator.iID = int.Parse(objReader["PageGenerator_ID"].ToString());
				objPageGenerator.strTitle = objReader["PageGenerator_Title"].ToString();
				objPageGenerator.strDetails = objReader["PageGenerator_Details"].ToString();
				objPageGenerator.strMetaTitle = objReader["PageGenerator_MetaTitle"].ToString();
				objPageGenerator.strMetaDesc = objReader["PageGenerator_MetaDesc"].ToString();
				objPageGenerator.strMetaKeys = objReader["PageGenerator_MetaKeys"].ToString();
				objPageGenerator.strPhoto = objReader["PageGenerator_Photo"].ToString();
				objPageGenerator.dtCreatedDate = DateTime.Parse(objReader["PageGenerator_CreatedDate"].ToString());
				objPageGeneratorList.Add(objPageGenerator);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objPageGeneratorList;
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

	public CoreWebList<PageGeneratorClass> fn_getPageGeneratorByID(int iPageGeneratorID)
	{
		CoreWebList<PageGeneratorClass> objPageGeneratorList = null;
		PageGeneratorClass objPageGenerator = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_PageGenerator WHERE PageGenerator_ID=@PageGenerator_ID", objConnection);
			objCommand.Parameters.AddWithValue("@PageGenerator_ID", iPageGeneratorID);
			objReader = objCommand.ExecuteReader();
			objPageGeneratorList = new CoreWebList<PageGeneratorClass>();
			if (objReader.Read())
			{
				objPageGenerator = new PageGeneratorClass();
				objPageGenerator.iID = int.Parse(objReader["PageGenerator_ID"].ToString());
				objPageGenerator.strTitle = objReader["PageGenerator_Title"].ToString();
				objPageGenerator.strDetails = objReader["PageGenerator_Details"].ToString();
				objPageGenerator.strMetaTitle = objReader["PageGenerator_MetaTitle"].ToString();
				objPageGenerator.strMetaDesc = objReader["PageGenerator_MetaDesc"].ToString();
				objPageGenerator.strMetaKeys = objReader["PageGenerator_MetaKeys"].ToString();
				objPageGenerator.strPhoto = objReader["PageGenerator_Photo"].ToString();
				objPageGenerator.dtCreatedDate = DateTime.Parse(objReader["PageGenerator_CreatedDate"].ToString());
				objPageGeneratorList.Add(objPageGenerator);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objPageGeneratorList;
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

	public CoreWebList<PageGeneratorClass> fn_getPageGeneratorByName(string strPageGeneratorTitle)
	{
		CoreWebList<PageGeneratorClass> objPageGeneratorList = null;
		PageGeneratorClass objPageGenerator = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_PageGenerator WHERE PageGenerator_Title=@PageGenerator_Title", objConnection);
			objCommand.Parameters.AddWithValue("@PageGenerator_Title", strPageGeneratorTitle);
			objReader = objCommand.ExecuteReader();
			objPageGeneratorList = new CoreWebList<PageGeneratorClass>();
			if (objReader.Read())
			{
				objPageGenerator = new PageGeneratorClass();
				objPageGenerator.iID = int.Parse(objReader["PageGenerator_ID"].ToString());
				objPageGenerator.strTitle = objReader["PageGenerator_Title"].ToString();
				objPageGenerator.strDetails = objReader["PageGenerator_Details"].ToString();
				objPageGenerator.strMetaTitle = objReader["PageGenerator_MetaTitle"].ToString();
				objPageGenerator.strMetaDesc = objReader["PageGenerator_MetaDesc"].ToString();
				objPageGenerator.strMetaKeys = objReader["PageGenerator_MetaKeys"].ToString();
				objPageGenerator.strPhoto = objReader["PageGenerator_Photo"].ToString();
				objPageGenerator.dtCreatedDate = DateTime.Parse(objReader["PageGenerator_CreatedDate"].ToString());
				objPageGeneratorList.Add(objPageGenerator);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objPageGeneratorList;
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

	public CoreWebList<PageGeneratorClass> fn_getPageGeneratorByKeys(string strPageGeneratorTitle)
	{
		CoreWebList<PageGeneratorClass> objPageGeneratorList = null;
		PageGeneratorClass objPageGenerator = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_PageGenerator WHERE PageGenerator_Title like '%' + @PageGenerator_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@PageGenerator_Title", strPageGeneratorTitle);
			objReader = objCommand.ExecuteReader();
			objPageGeneratorList = new CoreWebList<PageGeneratorClass>();
			while (objReader.Read())
			{
				objPageGenerator = new PageGeneratorClass();
				objPageGenerator.iID = int.Parse(objReader["PageGenerator_ID"].ToString());
				objPageGenerator.strTitle = objReader["PageGenerator_Title"].ToString();
				objPageGenerator.strDetails = objReader["PageGenerator_Details"].ToString();
				objPageGenerator.strMetaTitle = objReader["PageGenerator_MetaTitle"].ToString();
				objPageGenerator.strMetaDesc = objReader["PageGenerator_MetaDesc"].ToString();
				objPageGenerator.strMetaKeys = objReader["PageGenerator_MetaKeys"].ToString();
				objPageGenerator.strPhoto = objReader["PageGenerator_Photo"].ToString();
				objPageGenerator.dtCreatedDate = DateTime.Parse(objReader["PageGenerator_CreatedDate"].ToString());
				objPageGeneratorList.Add(objPageGenerator);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objPageGeneratorList;
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
