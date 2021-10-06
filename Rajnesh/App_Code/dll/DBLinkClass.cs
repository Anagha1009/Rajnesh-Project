using System;
using System.Data.SqlClient;
using System.Configuration;
using yo_lib;

/// <summary>
/// Summary description for DBLinkClass
/// </summary>
public class DBLinkClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString;

	public string fn_saveLink(LinkClass objLink)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_Links (Link_Title, Link_Url, Link_TargetUrl) VALUES (@Link_Title, @Link_Url, @Link_TargetUrl)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Link_Title", objLink.strTitle);
			objCommand.Parameters.AddWithValue("@Link_Url", objLink.strUrl);
			objCommand.Parameters.AddWithValue("@Link_TargetUrl", objLink.strTargetUrl);

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

	public string fn_editLink(LinkClass objLink)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Links SET Link_Title=@Link_Title, Link_Url=@Link_Url, Link_TargetUrl=@Link_TargetUrl WHERE Link_ID=@Link_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Link_ID", objLink.iID);
			objCommand.Parameters.AddWithValue("@Link_Title", objLink.strTitle);
			objCommand.Parameters.AddWithValue("@Link_Url", objLink.strUrl);
			objCommand.Parameters.AddWithValue("@Link_TargetUrl", objLink.strTargetUrl);

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

	public string fn_deleteLink(int iLinkID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Links WHERE Link_ID=@Link_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Link_ID", iLinkID);

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

	public CoreWebList<LinkClass> fn_getLinkList()
	{
		CoreWebList<LinkClass> objLinkList = null;
		LinkClass objLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Links", objConnection);
			objReader = objCommand.ExecuteReader();
			objLinkList = new CoreWebList<LinkClass>();
			while (objReader.Read())
			{
				objLink = new LinkClass();
				objLink.iID = int.Parse(objReader["Link_ID"].ToString());
				objLink.strTitle = objReader["Link_Title"].ToString();
				objLink.strUrl = objReader["Link_Url"].ToString();
				objLink.strTargetUrl = objReader["Link_TargetUrl"].ToString();
				objLinkList.Add(objLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objLinkList;
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

	public CoreWebList<LinkClass> fn_getLinkByID(int iLinkID)
	{
		CoreWebList<LinkClass> objLinkList = null;
		LinkClass objLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Links WHERE Link_ID=@Link_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Link_ID", iLinkID);
			objReader = objCommand.ExecuteReader();
			objLinkList = new CoreWebList<LinkClass>();
			if (objReader.Read())
			{
				objLink = new LinkClass();
				objLink.iID = int.Parse(objReader["Link_ID"].ToString());
				objLink.strTitle = objReader["Link_Title"].ToString();
				objLink.strUrl = objReader["Link_Url"].ToString();
				objLink.strTargetUrl = objReader["Link_TargetUrl"].ToString();
				objLinkList.Add(objLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objLinkList;
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

	public CoreWebList<LinkClass> fn_getLinkByName(string strLinkTitle)
	{
		CoreWebList<LinkClass> objLinkList = null;
		LinkClass objLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Links WHERE Link_Title=@Link_Title", objConnection);
			objCommand.Parameters.AddWithValue("@Link_Title", strLinkTitle);
			objReader = objCommand.ExecuteReader();
			objLinkList = new CoreWebList<LinkClass>();
			if (objReader.Read())
			{
				objLink = new LinkClass();
				objLink.iID = int.Parse(objReader["Link_ID"].ToString());
				objLink.strTitle = objReader["Link_Title"].ToString();
				objLink.strUrl = objReader["Link_Url"].ToString();
				objLink.strTargetUrl = objReader["Link_TargetUrl"].ToString();
				objLinkList.Add(objLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objLinkList;
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

    public CoreWebList<LinkClass> fn_getLinkByTargetUrl(string strLinkTargetUrl)
    {
        CoreWebList<LinkClass> objLinkList = null;
        LinkClass objLink = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Links WHERE Link_TargetUrl=@Link_TargetUrl", objConnection);
            objCommand.Parameters.AddWithValue("@Link_TargetUrl", strLinkTargetUrl);
            objReader = objCommand.ExecuteReader();
            objLinkList = new CoreWebList<LinkClass>();
            while (objReader.Read())
            {
                objLink = new LinkClass();
                objLink.iID = int.Parse(objReader["Link_ID"].ToString());
                objLink.strTitle = objReader["Link_Title"].ToString();
                objLink.strUrl = objReader["Link_Url"].ToString();
                objLink.strTargetUrl = objReader["Link_TargetUrl"].ToString();
                objLinkList.Add(objLink);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objLinkList;
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

	public CoreWebList<LinkClass> fn_getLinkByKeys(string strLinkTitle)
	{
		CoreWebList<LinkClass> objLinkList = null;
		LinkClass objLink = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Links WHERE Link_Title like '%' + @Link_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Link_Title", strLinkTitle);
			objReader = objCommand.ExecuteReader();
			objLinkList = new CoreWebList<LinkClass>();
			while (objReader.Read())
			{
				objLink = new LinkClass();
				objLink.iID = int.Parse(objReader["Link_ID"].ToString());
				objLink.strTitle = objReader["Link_Title"].ToString();
				objLink.strUrl = objReader["Link_Url"].ToString();
				objLink.strTargetUrl = objReader["Link_TargetUrl"].ToString();
				objLinkList.Add(objLink);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objLinkList;
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
