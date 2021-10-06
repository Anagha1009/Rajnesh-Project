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
/// Summary description for DBVoteDetailClass
/// </summary>
public class DBVoteDetailClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveVoteDetail(VoteDetailClass objVoteDetail)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_VoteDetails (VoteDetail_VoteID, VoteDetail_Title, VoteDetail_Photo) VALUES (@VoteDetail_VoteID, @VoteDetail_Title, @VoteDetail_Photo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@VoteDetail_VoteID", objVoteDetail.iVoteID);
			objCommand.Parameters.AddWithValue("@VoteDetail_Title", objVoteDetail.strTitle);
			objCommand.Parameters.AddWithValue("@VoteDetail_Photo", objVoteDetail.strPhoto);

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

	public string fn_editVoteDetail(VoteDetailClass objVoteDetail)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_VoteDetails SET VoteDetail_Title=@VoteDetail_Title, VoteDetail_Photo=@VoteDetail_Photo WHERE VoteDetail_ID=@VoteDetail_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@VoteDetail_ID", objVoteDetail.iID);
            objCommand.Parameters.AddWithValue("@VoteDetail_Title", objVoteDetail.strTitle);
            objCommand.Parameters.AddWithValue("@VoteDetail_Photo", objVoteDetail.strPhoto);

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

    public string fn_AddVotes(int iID)
    {
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_VoteDetails SET VoteDetail_Rate=VoteDetail_Rate + 1 WHERE VoteDetail_ID=@VoteDetail_ID", objConnection);
            objCommand.Parameters.AddWithValue("@VoteDetail_ID", iID);

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

	public string fn_deleteVoteDetail(int iVoteDetailID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_VoteDetails WHERE VoteDetail_ID=@VoteDetail_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@VoteDetail_ID", iVoteDetailID);

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

	public CoreWebList<VoteDetailClass> fn_getVoteDetailList()
	{
		CoreWebList<VoteDetailClass> objVoteDetailList = null;
		VoteDetailClass objVoteDetail = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_VoteDetails", objConnection);
			objReader = objCommand.ExecuteReader();
			objVoteDetailList = new CoreWebList<VoteDetailClass>();
			while (objReader.Read())
			{
				objVoteDetail = new VoteDetailClass();
				objVoteDetail.iID = int.Parse(objReader["VoteDetail_ID"].ToString());
				objVoteDetail.iVoteID = int.Parse(objReader["VoteDetail_VoteID"].ToString());
				objVoteDetail.strTitle = objReader["VoteDetail_Title"].ToString();
				objVoteDetail.strPhoto = objReader["VoteDetail_Photo"].ToString();
				objVoteDetail.iRate = int.Parse(objReader["VoteDetail_Rate"].ToString());
				objVoteDetailList.Add(objVoteDetail);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objVoteDetailList;
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

    public CoreWebList<VoteDetailClass> fn_getVotePercentage(int iVoteId)
    {
        CoreWebList<VoteDetailClass> objVoteDetailList = null;
        VoteDetailClass objVoteDetail = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT VoteDetail_ID, VoteDetail_VoteID, VoteDetail_Title, VoteDetail_Photo, (VoteDetail_Rate  * 100) / (SELECT SUM(VoteDetail_Rate) FROM tbl_VoteDetails WHERE VoteDetail_VoteID=@VoteDetail_VoteID) AS Percentage FROM tbl_VoteDetails WHERE VoteDetail_VoteID=@VoteDetail_VoteID", objConnection);
            objCommand.Parameters.AddWithValue("@VoteDetail_VoteID", iVoteId);
            objReader = objCommand.ExecuteReader();
            objVoteDetailList = new CoreWebList<VoteDetailClass>();
            while (objReader.Read())
            {
                objVoteDetail = new VoteDetailClass();
                objVoteDetail.iID = int.Parse(objReader["VoteDetail_ID"].ToString());
                objVoteDetail.iVoteID = int.Parse(objReader["VoteDetail_VoteID"].ToString());
                objVoteDetail.strTitle = objReader["VoteDetail_Title"].ToString();
                objVoteDetail.strPhoto = objReader["VoteDetail_Photo"].ToString();
                objVoteDetail.fPercentage = float.Parse(objReader["Percentage"].ToString());
                objVoteDetailList.Add(objVoteDetail);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objVoteDetailList;
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

	public CoreWebList<VoteDetailClass> fn_getVoteDetailByID(int iVoteDetailID)
	{
		CoreWebList<VoteDetailClass> objVoteDetailList = null;
		VoteDetailClass objVoteDetail = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_VoteDetails WHERE VoteDetail_ID=@VoteDetail_ID", objConnection);
			objCommand.Parameters.AddWithValue("@VoteDetail_ID", iVoteDetailID);
			objReader = objCommand.ExecuteReader();
			objVoteDetailList = new CoreWebList<VoteDetailClass>();
			if (objReader.Read())
			{
				objVoteDetail = new VoteDetailClass();
				objVoteDetail.iID = int.Parse(objReader["VoteDetail_ID"].ToString());
				objVoteDetail.iVoteID = int.Parse(objReader["VoteDetail_VoteID"].ToString());
				objVoteDetail.strTitle = objReader["VoteDetail_Title"].ToString();
				objVoteDetail.strPhoto = objReader["VoteDetail_Photo"].ToString();
				objVoteDetail.iRate = int.Parse(objReader["VoteDetail_Rate"].ToString());
				objVoteDetailList.Add(objVoteDetail);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objVoteDetailList;
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

	public CoreWebList<VoteDetailClass> fn_getVoteDetailByName(string strVoteDetailTitle)
	{
		CoreWebList<VoteDetailClass> objVoteDetailList = null;
		VoteDetailClass objVoteDetail = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_VoteDetails WHERE VoteDetail_Title=@VoteDetail_Title", objConnection);
			objCommand.Parameters.AddWithValue("@VoteDetail_Title", strVoteDetailTitle);
			objReader = objCommand.ExecuteReader();
			objVoteDetailList = new CoreWebList<VoteDetailClass>();
			if (objReader.Read())
			{
				objVoteDetail = new VoteDetailClass();
				objVoteDetail.iID = int.Parse(objReader["VoteDetail_ID"].ToString());
				objVoteDetail.iVoteID = int.Parse(objReader["VoteDetail_VoteID"].ToString());
				objVoteDetail.strTitle = objReader["VoteDetail_Title"].ToString();
				objVoteDetail.strPhoto = objReader["VoteDetail_Photo"].ToString();
				objVoteDetail.iRate = int.Parse(objReader["VoteDetail_Rate"].ToString());
				objVoteDetailList.Add(objVoteDetail);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objVoteDetailList;
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

	public CoreWebList<VoteDetailClass> fn_getVoteDetailByKeys(string strVoteDetailTitle)
	{
		CoreWebList<VoteDetailClass> objVoteDetailList = null;
		VoteDetailClass objVoteDetail = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_VoteDetails WHERE VoteDetail_Title like '%' + @VoteDetail_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@VoteDetail_Title", strVoteDetailTitle);
			objReader = objCommand.ExecuteReader();
			objVoteDetailList = new CoreWebList<VoteDetailClass>();
			while (objReader.Read())
			{
				objVoteDetail = new VoteDetailClass();
				objVoteDetail.iID = int.Parse(objReader["VoteDetail_ID"].ToString());
				objVoteDetail.iVoteID = int.Parse(objReader["VoteDetail_VoteID"].ToString());
				objVoteDetail.strTitle = objReader["VoteDetail_Title"].ToString();
				objVoteDetail.strPhoto = objReader["VoteDetail_Photo"].ToString();
				objVoteDetail.iRate = int.Parse(objReader["VoteDetail_Rate"].ToString());
				objVoteDetailList.Add(objVoteDetail);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objVoteDetailList;
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

	public CoreWebList<VoteDetailClass> fn_getVoteDetailByVoteID(int iVoteID)
	{
		CoreWebList<VoteDetailClass> objVoteDetailList = null;
		VoteDetailClass objVoteDetail = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_VoteDetails WHERE VoteDetail_VoteID=@VoteDetail_VoteID", objConnection);
			objCommand.Parameters.AddWithValue("@VoteDetail_VoteID", iVoteID);
			objReader = objCommand.ExecuteReader();
			objVoteDetailList = new CoreWebList<VoteDetailClass>();
			while (objReader.Read())
			{
				objVoteDetail = new VoteDetailClass();
				objVoteDetail.iID = int.Parse(objReader["VoteDetail_ID"].ToString());
				objVoteDetail.iVoteID = int.Parse(objReader["VoteDetail_VoteID"].ToString());
				objVoteDetail.strTitle = objReader["VoteDetail_Title"].ToString();
				objVoteDetail.strPhoto = objReader["VoteDetail_Photo"].ToString();
				objVoteDetail.iRate = int.Parse(objReader["VoteDetail_Rate"].ToString());
				objVoteDetailList.Add(objVoteDetail);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objVoteDetailList;
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

    public CoreWebList<VoteDetailClass> fn_getVoteDetailByUrl(string strUrl)
    {
        CoreWebList<VoteDetailClass> objVoteDetailList = null;
        VoteDetailClass objVoteDetail = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT vot.Vote_Title, det.* FROM dbo.tbl_VoteDetails det join dbo.tbl_Votes vot on det.VoteDetail_VoteID=vot.Vote_ID WHERE vot.Vote_Url=@Vote_Url AND vot.Vote_Active='true'", objConnection);
            objCommand.Parameters.AddWithValue("@Vote_Url", strUrl);
            objReader = objCommand.ExecuteReader();
            objVoteDetailList = new CoreWebList<VoteDetailClass>();
            while (objReader.Read())
            {
                objVoteDetail = new VoteDetailClass();
                objVoteDetail.iID = int.Parse(objReader["VoteDetail_ID"].ToString());
                objVoteDetail.iVoteID = int.Parse(objReader["VoteDetail_VoteID"].ToString());
                objVoteDetail.strTitle = objReader["VoteDetail_Title"].ToString();
                objVoteDetail.strPhoto = objReader["VoteDetail_Photo"].ToString();
                objVoteDetail.iRate = int.Parse(objReader["VoteDetail_Rate"].ToString());
                objVoteDetailList.Add(objVoteDetail);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objVoteDetailList;
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

    public CoreWebList<VoteDetailClass> fn_getRandomVotes()
    {
        CoreWebList<VoteDetailClass> objVoteDetailList = null;
        VoteDetailClass objVoteDetail = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("select * from tbl_VoteDetails WHERE VoteDetail_VoteID = (select TOP 1 Vote_ID FROM tbl_Votes WHERE Vote_Active='true' ORDER BY NEWID())", objConnection);
            objReader = objCommand.ExecuteReader();
            objVoteDetailList = new CoreWebList<VoteDetailClass>();
            while (objReader.Read())
            {
                objVoteDetail = new VoteDetailClass();
                objVoteDetail.iID = int.Parse(objReader["VoteDetail_ID"].ToString());
                objVoteDetail.iVoteID = int.Parse(objReader["VoteDetail_VoteID"].ToString());
                objVoteDetail.strTitle = objReader["VoteDetail_Title"].ToString();
                objVoteDetail.strPhoto = objReader["VoteDetail_Photo"].ToString();
                objVoteDetail.iRate = int.Parse(objReader["VoteDetail_Rate"].ToString());
                objVoteDetailList.Add(objVoteDetail);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objVoteDetailList;
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
