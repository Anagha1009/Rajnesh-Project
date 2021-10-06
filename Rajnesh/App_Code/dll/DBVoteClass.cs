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
/// Summary description for DBVoteClass
/// </summary>
public class DBVoteClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveVote(VoteClass objVote)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_Votes (Vote_Title, Vote_Url, Vote_Icon) VALUES (@Vote_Title, @Vote_Url, @Vote_Icon)", objConnection);
			objCommand.Parameters.AddWithValue("@Vote_Title", objVote.strTitle);
            objCommand.Parameters.AddWithValue("@Vote_Url", objVote.strUrl);
            objCommand.Parameters.AddWithValue("@Vote_Icon", objVote.strIcon);

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

	public string fn_editVote(VoteClass objVote)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_Votes SET Vote_Title=@Vote_Title, Vote_Url=@Vote_Url, Vote_Icon=@Vote_Icon WHERE Vote_ID=@Vote_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Vote_ID", objVote.iID);
			objCommand.Parameters.AddWithValue("@Vote_Title", objVote.strTitle);
            objCommand.Parameters.AddWithValue("@Vote_Url", objVote.strUrl);
            objCommand.Parameters.AddWithValue("@Vote_Icon", objVote.strIcon);

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

	public string fn_deleteVote(int iVoteID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Votes WHERE Vote_ID=@Vote_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Vote_ID", iVoteID);

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

	public CoreWebList<VoteClass> fn_getVoteList()
	{
		CoreWebList<VoteClass> objVoteList = null;
		VoteClass objVote = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT *, (SELECT ISNULL(SUM(VoteDetail_Rate),0) FROM tbl_VoteDetails vd WHERE v.Vote_ID=vd.VoteDetail_VoteID)Vote_Counts FROM tbl_Votes v", objConnection);
			objReader = objCommand.ExecuteReader();
			objVoteList = new CoreWebList<VoteClass>();
			while (objReader.Read())
			{
				objVote = new VoteClass();
				objVote.iID = int.Parse(objReader["Vote_ID"].ToString());
				objVote.strTitle = objReader["Vote_Title"].ToString();
                objVote.strUrl = objReader["Vote_Url"].ToString();
                objVote.strIcon = objReader["Vote_Icon"].ToString();
				objVote.bActive = bool.Parse(objReader["Vote_Active"].ToString());
				objVote.dtDate = DateTime.Parse(objReader["Vote_Date"].ToString());
                objVote.iVoteCounts = int.Parse(objReader["Vote_Counts"].ToString());
				objVoteList.Add(objVote);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objVoteList;
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

    public CoreWebList<VoteClass> fn_getTopEntry(int CurrentId)
    {
        CoreWebList<VoteClass> objVoteList = null;
        VoteClass objVote = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 2 * FROM tbl_Votes WHERE Vote_ID > @Vote_ID ORDER BY Vote_ID ASC", objConnection);
            objCommand.Parameters.AddWithValue("@Vote_ID", CurrentId);
            objReader = objCommand.ExecuteReader();
            objVoteList = new CoreWebList<VoteClass>();
            while (objReader.Read())
            {
                objVote = new VoteClass();
                objVote.iID = int.Parse(objReader["Vote_ID"].ToString());
                objVote.strTitle = objReader["Vote_Title"].ToString();
                objVote.strUrl = objReader["Vote_Url"].ToString();
                objVote.strIcon = objReader["Vote_Icon"].ToString();
                objVote.bActive = bool.Parse(objReader["Vote_Active"].ToString());
                objVote.dtDate = DateTime.Parse(objReader["Vote_Date"].ToString());
                objVoteList.Add(objVote);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objVoteList;
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

	public CoreWebList<VoteClass> fn_getVoteByID(int iVoteID)
	{
		CoreWebList<VoteClass> objVoteList = null;
		VoteClass objVote = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Votes WHERE Vote_ID=@Vote_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Vote_ID", iVoteID);
			objReader = objCommand.ExecuteReader();
			objVoteList = new CoreWebList<VoteClass>();
			if (objReader.Read())
			{
				objVote = new VoteClass();
				objVote.iID = int.Parse(objReader["Vote_ID"].ToString());
				objVote.strTitle = objReader["Vote_Title"].ToString();
                objVote.strUrl = objReader["Vote_Url"].ToString();
                objVote.strIcon = objReader["Vote_Icon"].ToString();
				objVote.bActive = bool.Parse(objReader["Vote_Active"].ToString());
				objVote.dtDate = DateTime.Parse(objReader["Vote_Date"].ToString());
				objVoteList.Add(objVote);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objVoteList;
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

	public CoreWebList<VoteClass> fn_getVoteByName(string strVoteTitle)
	{
		CoreWebList<VoteClass> objVoteList = null;
		VoteClass objVote = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Votes WHERE Vote_Title=@Vote_Title", objConnection);
			objCommand.Parameters.AddWithValue("@Vote_Title", strVoteTitle);
			objReader = objCommand.ExecuteReader();
			objVoteList = new CoreWebList<VoteClass>();
			if (objReader.Read())
			{
				objVote = new VoteClass();
				objVote.iID = int.Parse(objReader["Vote_ID"].ToString());
				objVote.strTitle = objReader["Vote_Title"].ToString();
                objVote.strUrl = objReader["Vote_Url"].ToString();
                objVote.strIcon = objReader["Vote_Icon"].ToString();
				objVote.bActive = bool.Parse(objReader["Vote_Active"].ToString());
				objVote.dtDate = DateTime.Parse(objReader["Vote_Date"].ToString());
				objVoteList.Add(objVote);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objVoteList;
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

	public CoreWebList<VoteClass> fn_getVoteByKeys(string strVoteTitle)
	{
		CoreWebList<VoteClass> objVoteList = null;
		VoteClass objVote = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Votes WHERE Vote_Title like '%' + @Vote_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Vote_Title", strVoteTitle);
			objReader = objCommand.ExecuteReader();
			objVoteList = new CoreWebList<VoteClass>();
			while (objReader.Read())
			{
				objVote = new VoteClass();
				objVote.iID = int.Parse(objReader["Vote_ID"].ToString());
				objVote.strTitle = objReader["Vote_Title"].ToString();
                objVote.strUrl = objReader["Vote_Url"].ToString();
                objVote.strIcon = objReader["Vote_Icon"].ToString();
				objVote.bActive = bool.Parse(objReader["Vote_Active"].ToString());
				objVote.dtDate = DateTime.Parse(objReader["Vote_Date"].ToString());
				objVoteList.Add(objVote);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objVoteList;
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

	public string fn_ChangeVoteActiveStatus(VoteClass objVote)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Votes SET Vote_Active=@Vote_Active WHERE Vote_ID=@Vote_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("Vote_ID", objVote.iID);
			objCommand.Parameters.AddWithValue("Vote_Active", objVote.bActive);

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

}
