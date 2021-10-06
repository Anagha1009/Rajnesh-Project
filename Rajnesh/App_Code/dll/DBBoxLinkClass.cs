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
/// Summary description for DBBoxLinkClass
/// </summary>
public class DBBoxLinkClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveBoxLink(BoxLinkClass objBoxLink)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_BoxLinks (BoxLink_BoxID, BoxLink_Title, BoxLink_Url) VALUES (@BoxLink_BoxID, @BoxLink_Title, @BoxLink_Url)",objConnection) ;
			objCommand.Parameters.AddWithValue("@BoxLink_BoxID", objBoxLink.iBoxID);
			objCommand.Parameters.AddWithValue("@BoxLink_Title", objBoxLink.strTitle);
			objCommand.Parameters.AddWithValue("@BoxLink_Url", objBoxLink.strUrl);

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

	public string fn_editBoxLink(BoxLinkClass objBoxLink)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_BoxLinks SET BoxLink_Title=@BoxLink_Title, BoxLink_Url=@BoxLink_Url WHERE BoxLink_ID=@BoxLink_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@BoxLink_ID", objBoxLink.iID);
            objCommand.Parameters.AddWithValue("@BoxLink_Title", objBoxLink.strTitle);
            objCommand.Parameters.AddWithValue("@BoxLink_Url", objBoxLink.strUrl);

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

	public string fn_deleteBoxLink(int iBoxLinkID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_BoxLinks WHERE BoxLink_ID=@BoxLink_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@BoxLink_ID", iBoxLinkID);

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

	public CoreWebList<BoxLinkClass> fn_getBoxLinkList()
	{
		CoreWebList<BoxLinkClass> objBoxLinkList = null;
		BoxLinkClass objBoxLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_BoxLinks", objConnection);
			objReader = objCommand.ExecuteReader();
			objBoxLinkList = new CoreWebList<BoxLinkClass>();
			while (objReader.Read())
			{
				objBoxLink = new BoxLinkClass();
				objBoxLink.iID = int.Parse(objReader["BoxLink_ID"].ToString());
				objBoxLink.iBoxID = int.Parse(objReader["BoxLink_BoxID"].ToString());
				objBoxLink.strTitle = objReader["BoxLink_Title"].ToString();
				objBoxLink.strUrl = objReader["BoxLink_Url"].ToString();
				objBoxLinkList.Add(objBoxLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBoxLinkList;
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

	public CoreWebList<BoxLinkClass> fn_getBoxLinkByID(int iBoxLinkID)
	{
		CoreWebList<BoxLinkClass> objBoxLinkList = null;
		BoxLinkClass objBoxLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_BoxLinks WHERE BoxLink_ID=@BoxLink_ID", objConnection);
			objCommand.Parameters.AddWithValue("@BoxLink_ID", iBoxLinkID);
			objReader = objCommand.ExecuteReader();
			objBoxLinkList = new CoreWebList<BoxLinkClass>();
			if (objReader.Read())
			{
				objBoxLink = new BoxLinkClass();
				objBoxLink.iID = int.Parse(objReader["BoxLink_ID"].ToString());
				objBoxLink.iBoxID = int.Parse(objReader["BoxLink_BoxID"].ToString());
				objBoxLink.strTitle = objReader["BoxLink_Title"].ToString();
				objBoxLink.strUrl = objReader["BoxLink_Url"].ToString();
				objBoxLinkList.Add(objBoxLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBoxLinkList;
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

	public CoreWebList<BoxLinkClass> fn_getBoxLinkByName(string strBoxLinkTitle)
	{
		CoreWebList<BoxLinkClass> objBoxLinkList = null;
		BoxLinkClass objBoxLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_BoxLinks WHERE BoxLink_Title=@BoxLink_Title", objConnection);
			objCommand.Parameters.AddWithValue("@BoxLink_Title", strBoxLinkTitle);
			objReader = objCommand.ExecuteReader();
			objBoxLinkList = new CoreWebList<BoxLinkClass>();
			if (objReader.Read())
			{
				objBoxLink = new BoxLinkClass();
				objBoxLink.iID = int.Parse(objReader["BoxLink_ID"].ToString());
				objBoxLink.iBoxID = int.Parse(objReader["BoxLink_BoxID"].ToString());
				objBoxLink.strTitle = objReader["BoxLink_Title"].ToString();
				objBoxLink.strUrl = objReader["BoxLink_Url"].ToString();
				objBoxLinkList.Add(objBoxLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBoxLinkList;
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

	public CoreWebList<BoxLinkClass> fn_getBoxLinkByKeys(string strBoxLinkTitle)
	{
		CoreWebList<BoxLinkClass> objBoxLinkList = null;
		BoxLinkClass objBoxLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_BoxLinks WHERE BoxLink_Title like '%' + @BoxLink_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@BoxLink_Title", strBoxLinkTitle);
			objReader = objCommand.ExecuteReader();
			objBoxLinkList = new CoreWebList<BoxLinkClass>();
			while (objReader.Read())
			{
				objBoxLink = new BoxLinkClass();
				objBoxLink.iID = int.Parse(objReader["BoxLink_ID"].ToString());
				objBoxLink.iBoxID = int.Parse(objReader["BoxLink_BoxID"].ToString());
				objBoxLink.strTitle = objReader["BoxLink_Title"].ToString();
				objBoxLink.strUrl = objReader["BoxLink_Url"].ToString();
				objBoxLinkList.Add(objBoxLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBoxLinkList;
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

	public CoreWebList<BoxLinkClass> fn_getBoxLinkByBoxID(int iBoxID)
	{
		CoreWebList<BoxLinkClass> objBoxLinkList = null;
		BoxLinkClass objBoxLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_BoxLinks WHERE BoxLink_BoxID=@BoxLink_BoxID", objConnection);
			objCommand.Parameters.AddWithValue("@BoxLink_BoxID", iBoxID);
			objReader = objCommand.ExecuteReader();
			objBoxLinkList = new CoreWebList<BoxLinkClass>();
			while (objReader.Read())
			{
				objBoxLink = new BoxLinkClass();
				objBoxLink.iID = int.Parse(objReader["BoxLink_ID"].ToString());
				objBoxLink.iBoxID = int.Parse(objReader["BoxLink_BoxID"].ToString());
				objBoxLink.strTitle = objReader["BoxLink_Title"].ToString();
				objBoxLink.strUrl = objReader["BoxLink_Url"].ToString();
				objBoxLinkList.Add(objBoxLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBoxLinkList;
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
