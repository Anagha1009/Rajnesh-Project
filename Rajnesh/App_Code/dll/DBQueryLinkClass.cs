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
/// Summary description for DBQueryLinkClass
/// </summary>
public class DBQueryLinkClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveQueryLink(QueryLinkClass objQueryLink)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_QueryLinks (QueryLink_QueryID, QueryLink_Title, QueryLink_Link) VALUES (@QueryLink_QueryID, @QueryLink_Title, @QueryLink_Link)",objConnection) ;
			objCommand.Parameters.AddWithValue("@QueryLink_QueryID", objQueryLink.iQueryID);
			objCommand.Parameters.AddWithValue("@QueryLink_Title", objQueryLink.strTitle);
			objCommand.Parameters.AddWithValue("@QueryLink_Link", objQueryLink.strLink);

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

	public string fn_editQueryLink(QueryLinkClass objQueryLink)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_QueryLinks SET QueryLink_Title=@QueryLink_Title, QueryLink_Link=@QueryLink_Link WHERE QueryLink_ID=@QueryLink_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@QueryLink_ID", objQueryLink.iID);
            objCommand.Parameters.AddWithValue("@QueryLink_Title", objQueryLink.strTitle);
            objCommand.Parameters.AddWithValue("@QueryLink_Link", objQueryLink.strLink);

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

	public string fn_deleteQueryLink(int iQueryLinkID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_QueryLinks WHERE QueryLink_ID=@QueryLink_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@QueryLink_ID", iQueryLinkID);

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

	public CoreWebList<QueryLinkClass> fn_getQueryLinkList()
	{
		CoreWebList<QueryLinkClass> objQueryLinkList = null;
		QueryLinkClass objQueryLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_QueryLinks", objConnection);
			objReader = objCommand.ExecuteReader();
			objQueryLinkList = new CoreWebList<QueryLinkClass>();
			while (objReader.Read())
			{
				objQueryLink = new QueryLinkClass();
				objQueryLink.iID = int.Parse(objReader["QueryLink_ID"].ToString());
				objQueryLink.iQueryID = int.Parse(objReader["QueryLink_QueryID"].ToString());
				objQueryLink.strTitle = objReader["QueryLink_Title"].ToString();
				objQueryLink.strLink = objReader["QueryLink_Link"].ToString();
				objQueryLinkList.Add(objQueryLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objQueryLinkList;
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

	public CoreWebList<QueryLinkClass> fn_getQueryLinkByID(int iQueryLinkID)
	{
		CoreWebList<QueryLinkClass> objQueryLinkList = null;
		QueryLinkClass objQueryLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_QueryLinks WHERE QueryLink_ID=@QueryLink_ID", objConnection);
			objCommand.Parameters.AddWithValue("@QueryLink_ID", iQueryLinkID);
			objReader = objCommand.ExecuteReader();
			objQueryLinkList = new CoreWebList<QueryLinkClass>();
			if (objReader.Read())
			{
				objQueryLink = new QueryLinkClass();
				objQueryLink.iID = int.Parse(objReader["QueryLink_ID"].ToString());
				objQueryLink.iQueryID = int.Parse(objReader["QueryLink_QueryID"].ToString());
				objQueryLink.strTitle = objReader["QueryLink_Title"].ToString();
				objQueryLink.strLink = objReader["QueryLink_Link"].ToString();
				objQueryLinkList.Add(objQueryLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objQueryLinkList;
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

	public CoreWebList<QueryLinkClass> fn_getQueryLinkByName(string strQueryLinkTitle)
	{
		CoreWebList<QueryLinkClass> objQueryLinkList = null;
		QueryLinkClass objQueryLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_QueryLinks WHERE QueryLink_Title=@QueryLink_Title", objConnection);
			objCommand.Parameters.AddWithValue("@QueryLink_Title", strQueryLinkTitle);
			objReader = objCommand.ExecuteReader();
			objQueryLinkList = new CoreWebList<QueryLinkClass>();
			if (objReader.Read())
			{
				objQueryLink = new QueryLinkClass();
				objQueryLink.iID = int.Parse(objReader["QueryLink_ID"].ToString());
				objQueryLink.iQueryID = int.Parse(objReader["QueryLink_QueryID"].ToString());
				objQueryLink.strTitle = objReader["QueryLink_Title"].ToString();
				objQueryLink.strLink = objReader["QueryLink_Link"].ToString();
				objQueryLinkList.Add(objQueryLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objQueryLinkList;
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

	public CoreWebList<QueryLinkClass> fn_getQueryLinkByKeys(string strQueryLinkTitle)
	{
		CoreWebList<QueryLinkClass> objQueryLinkList = null;
		QueryLinkClass objQueryLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_QueryLinks WHERE QueryLink_Title like '%' + @QueryLink_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@QueryLink_Title", strQueryLinkTitle);
			objReader = objCommand.ExecuteReader();
			objQueryLinkList = new CoreWebList<QueryLinkClass>();
			while (objReader.Read())
			{
				objQueryLink = new QueryLinkClass();
				objQueryLink.iID = int.Parse(objReader["QueryLink_ID"].ToString());
				objQueryLink.iQueryID = int.Parse(objReader["QueryLink_QueryID"].ToString());
				objQueryLink.strTitle = objReader["QueryLink_Title"].ToString();
				objQueryLink.strLink = objReader["QueryLink_Link"].ToString();
				objQueryLinkList.Add(objQueryLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objQueryLinkList;
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

	public CoreWebList<QueryLinkClass> fn_getQueryLinkByQueryID(int iQueryID)
	{
		CoreWebList<QueryLinkClass> objQueryLinkList = null;
		QueryLinkClass objQueryLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_QueryLinks WHERE QueryLink_QueryID=@QueryLink_QueryID", objConnection);
			objCommand.Parameters.AddWithValue("@QueryLink_QueryID", iQueryID);
			objReader = objCommand.ExecuteReader();
			objQueryLinkList = new CoreWebList<QueryLinkClass>();
			while (objReader.Read())
			{
				objQueryLink = new QueryLinkClass();
				objQueryLink.iID = int.Parse(objReader["QueryLink_ID"].ToString());
				objQueryLink.iQueryID = int.Parse(objReader["QueryLink_QueryID"].ToString());
				objQueryLink.strTitle = objReader["QueryLink_Title"].ToString();
				objQueryLink.strLink = objReader["QueryLink_Link"].ToString();
				objQueryLinkList.Add(objQueryLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objQueryLinkList;
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
