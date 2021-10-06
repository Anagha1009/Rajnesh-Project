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
/// Summary description for DBCommentClass
/// </summary>
public class DBCommentClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveComment(CommentClass objComment)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_Comments (Comment_Type, Comment_Url, Comment_Name, Comment_Email, Comment_Phone, Comment_Title, Comment_Desc, Comment_Rate, Comment_IpAddrs, Comment_Date, Comment_Active) VALUES (@Comment_Type, @Comment_Url, @Comment_Name, @Comment_Email, @Comment_Phone, @Comment_Title, @Comment_Desc, @Comment_Rate, @Comment_IpAddrs, @Comment_Date, @Comment_Active)", objConnection);
			objCommand.Parameters.AddWithValue("@Comment_Type", objComment.strType);
            objCommand.Parameters.AddWithValue("@Comment_Url", objComment.strUrl);
			objCommand.Parameters.AddWithValue("@Comment_Name", objComment.strName);
			objCommand.Parameters.AddWithValue("@Comment_Email", objComment.strEmail);
			objCommand.Parameters.AddWithValue("@Comment_Phone", objComment.strPhone);
			objCommand.Parameters.AddWithValue("@Comment_Title", objComment.strTitle);
			objCommand.Parameters.AddWithValue("@Comment_Desc", objComment.strDesc);
			objCommand.Parameters.AddWithValue("@Comment_Rate", objComment.iRate);
            objCommand.Parameters.AddWithValue("@Comment_IpAddrs", objComment.strIpAddrs);
			objCommand.Parameters.AddWithValue("@Comment_Date", objComment.dtDate);
			objCommand.Parameters.AddWithValue("@Comment_Active", objComment.bActive);

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

	public string fn_editComment(CommentClass objComment)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_Comments SET Comment_Type=@Comment_Type, Comment_Url=@Comment_Url, Comment_Name=@Comment_Name, Comment_Email=@Comment_Email, Comment_Phone=@Comment_Phone, Comment_Title=@Comment_Title, Comment_Desc=@Comment_Desc, Comment_Rate=@Comment_Rate, Comment_Date=@Comment_Date, Comment_Active=@Comment_Active WHERE Comment_ID=@Comment_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Comment_ID", objComment.iID);
			objCommand.Parameters.AddWithValue("@Comment_Type", objComment.strType);
            objCommand.Parameters.AddWithValue("@Comment_Url", objComment.strUrl);
			objCommand.Parameters.AddWithValue("@Comment_Name", objComment.strName);
			objCommand.Parameters.AddWithValue("@Comment_Email", objComment.strEmail);
			objCommand.Parameters.AddWithValue("@Comment_Phone", objComment.strPhone);
			objCommand.Parameters.AddWithValue("@Comment_Title", objComment.strTitle);
			objCommand.Parameters.AddWithValue("@Comment_Desc", objComment.strDesc);
			objCommand.Parameters.AddWithValue("@Comment_Rate", objComment.iRate);
			objCommand.Parameters.AddWithValue("@Comment_Date", objComment.dtDate);
			objCommand.Parameters.AddWithValue("@Comment_Active", objComment.bActive);

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

	public string fn_deleteComment(int iCommentID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Comments WHERE Comment_ID=@Comment_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Comment_ID", iCommentID);

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

	public CoreWebList<CommentClass> fn_getCommentList()
	{
		CoreWebList<CommentClass> objCommentList = null;
		CommentClass objComment = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Comments ORDER BY Comment_Date DESC", objConnection);
			objReader = objCommand.ExecuteReader();
			objCommentList = new CoreWebList<CommentClass>();
			while (objReader.Read())
			{
				objComment = new CommentClass();
				objComment.iID = int.Parse(objReader["Comment_ID"].ToString());
				objComment.strType = objReader["Comment_Type"].ToString();
                objComment.strUrl = objReader["Comment_Url"].ToString();
				objComment.strName = objReader["Comment_Name"].ToString();
				objComment.strEmail = objReader["Comment_Email"].ToString();
				objComment.strPhone = objReader["Comment_Phone"].ToString();
				objComment.strTitle = objReader["Comment_Title"].ToString();
				objComment.strDesc = objReader["Comment_Desc"].ToString();
				objComment.iRate = int.Parse(objReader["Comment_Rate"].ToString());
                objComment.strIpAddrs = objReader["Comment_IpAddrs"].ToString();
				objComment.dtDate = DateTime.Parse(objReader["Comment_Date"].ToString());
				objComment.bActive = bool.Parse(objReader["Comment_Active"].ToString());
                objComment.bAbuse = bool.Parse(objReader["Comment_Abuse"].ToString());
				objCommentList.Add(objComment);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCommentList;
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

    public CoreWebList<CommentClass> fn_getReportedCommentList()
    {
        CoreWebList<CommentClass> objCommentList = null;
        CommentClass objComment = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Comments WHERE Comment_Abuse='true' ORDER BY Comment_Date DESC", objConnection);
            objReader = objCommand.ExecuteReader();
            objCommentList = new CoreWebList<CommentClass>();
            while (objReader.Read())
            {
                objComment = new CommentClass();
                objComment.iID = int.Parse(objReader["Comment_ID"].ToString());
                objComment.strType = objReader["Comment_Type"].ToString();
                objComment.strUrl = objReader["Comment_Url"].ToString();
                objComment.strName = objReader["Comment_Name"].ToString();
                objComment.strEmail = objReader["Comment_Email"].ToString();
                objComment.strPhone = objReader["Comment_Phone"].ToString();
                objComment.strTitle = objReader["Comment_Title"].ToString();
                objComment.strDesc = objReader["Comment_Desc"].ToString();
                objComment.iRate = int.Parse(objReader["Comment_Rate"].ToString());
                objComment.strIpAddrs = objReader["Comment_IpAddrs"].ToString();
                objComment.dtDate = DateTime.Parse(objReader["Comment_Date"].ToString());
                objComment.bActive = bool.Parse(objReader["Comment_Active"].ToString());
                objComment.bAbuse = bool.Parse(objReader["Comment_Abuse"].ToString());
                objCommentList.Add(objComment);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCommentList;
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

	public CoreWebList<CommentClass> fn_getCommentByID(int iCommentID)
	{
		CoreWebList<CommentClass> objCommentList = null;
		CommentClass objComment = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Comments WHERE Comment_ID=@Comment_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Comment_ID", iCommentID);
			objReader = objCommand.ExecuteReader();
			objCommentList = new CoreWebList<CommentClass>();
			if (objReader.Read())
			{
				objComment = new CommentClass();
				objComment.iID = int.Parse(objReader["Comment_ID"].ToString());
				objComment.strType = objReader["Comment_Type"].ToString();
                objComment.strUrl = objReader["Comment_Url"].ToString();
				objComment.strName = objReader["Comment_Name"].ToString();
				objComment.strEmail = objReader["Comment_Email"].ToString();
				objComment.strPhone = objReader["Comment_Phone"].ToString();
				objComment.strTitle = objReader["Comment_Title"].ToString();
				objComment.strDesc = objReader["Comment_Desc"].ToString();
				objComment.iRate = int.Parse(objReader["Comment_Rate"].ToString());
                objComment.strIpAddrs = objReader["Comment_IpAddrs"].ToString();
				objComment.dtDate = DateTime.Parse(objReader["Comment_Date"].ToString());
				objComment.bActive = bool.Parse(objReader["Comment_Active"].ToString());
                objComment.bAbuse = bool.Parse(objReader["Comment_Abuse"].ToString());
				objCommentList.Add(objComment);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCommentList;
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

    public CoreWebList<CommentClass> fn_getCommentByUrl(string strType, string strUrl)
    {
        CoreWebList<CommentClass> objCommentList = null;
        CommentClass objComment = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Comments WHERE Comment_Type=@Comment_Type AND Comment_Url=@Comment_Url AND Comment_Active='true' ORDER BY Comment_Date DESC", objConnection);
            objCommand.Parameters.AddWithValue("@Comment_Type", strType);
            objCommand.Parameters.AddWithValue("@Comment_Url", strUrl);
            objReader = objCommand.ExecuteReader();
            objCommentList = new CoreWebList<CommentClass>();
            while (objReader.Read())
            {
                objComment = new CommentClass();
                objComment.iID = int.Parse(objReader["Comment_ID"].ToString());
                objComment.strType = objReader["Comment_Type"].ToString();
                objComment.strUrl = objReader["Comment_Url"].ToString();
                objComment.strName = objReader["Comment_Name"].ToString();
                objComment.strEmail = objReader["Comment_Email"].ToString();
                objComment.strPhone = objReader["Comment_Phone"].ToString();
                objComment.strTitle = objReader["Comment_Title"].ToString();
                objComment.strDesc = objReader["Comment_Desc"].ToString();
                objComment.iRate = int.Parse(objReader["Comment_Rate"].ToString());
                objComment.strIpAddrs = objReader["Comment_IpAddrs"].ToString();
                objComment.dtDate = DateTime.Parse(objReader["Comment_Date"].ToString());
                objComment.bActive = bool.Parse(objReader["Comment_Active"].ToString());
                objComment.bAbuse = bool.Parse(objReader["Comment_Abuse"].ToString());
                objCommentList.Add(objComment);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCommentList;
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

    public CoreWebList<CommentClass> fn_getSearchComment(string strKeys)
    {
        CoreWebList<CommentClass> objCommentList = null;
        CommentClass objComment = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Comments WHERE ((Comment_Name like '%' + @CommentKey + '%') OR (Comment_Email like '%' + @CommentKey + '%') OR (Comment_Phone like '%' + @CommentKey + '%') OR (Comment_Title like '%' + @CommentKey + '%') OR (Comment_Url like '%' + @CommentKey + '%') OR (Comment_Desc like '%' + @CommentKey + '%')) ORDER BY Comment_Date DESC", objConnection);
            objCommand.Parameters.AddWithValue("@CommentKey", strKeys);
            objReader = objCommand.ExecuteReader();
            objCommentList = new CoreWebList<CommentClass>();
            while (objReader.Read())
            {
                objComment = new CommentClass();
                objComment.iID = int.Parse(objReader["Comment_ID"].ToString());
                objComment.strType = objReader["Comment_Type"].ToString();
                objComment.strUrl = objReader["Comment_Url"].ToString();
                objComment.strName = objReader["Comment_Name"].ToString();
                objComment.strEmail = objReader["Comment_Email"].ToString();
                objComment.strPhone = objReader["Comment_Phone"].ToString();
                objComment.strTitle = objReader["Comment_Title"].ToString();
                objComment.strDesc = objReader["Comment_Desc"].ToString();
                objComment.iRate = int.Parse(objReader["Comment_Rate"].ToString());
                objComment.strIpAddrs = objReader["Comment_IpAddrs"].ToString();
                objComment.dtDate = DateTime.Parse(objReader["Comment_Date"].ToString());
                objComment.bActive = bool.Parse(objReader["Comment_Active"].ToString());
                objComment.bAbuse = bool.Parse(objReader["Comment_Abuse"].ToString());
                objCommentList.Add(objComment);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCommentList;
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

    public CoreWebList<CommentClass> fn_getSearchAbusedComment(string strKeys)
    {
        CoreWebList<CommentClass> objCommentList = null;
        CommentClass objComment = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Comments WHERE ((Comment_Name like '%' + @CommentKey + '%') OR (Comment_Email like '%' + @CommentKey + '%') OR (Comment_Phone like '%' + @CommentKey + '%') OR (Comment_Title like '%' + @CommentKey + '%') OR (Comment_Url like '%' + @CommentKey + '%') OR (Comment_Desc like '%' + @CommentKey + '%')) AND Comment_Abuse='true' ORDER BY Comment_Date DESC", objConnection);
            objCommand.Parameters.AddWithValue("@CommentKey", strKeys);
            objReader = objCommand.ExecuteReader();
            objCommentList = new CoreWebList<CommentClass>();
            while (objReader.Read())
            {
                objComment = new CommentClass();
                objComment.iID = int.Parse(objReader["Comment_ID"].ToString());
                objComment.strType = objReader["Comment_Type"].ToString();
                objComment.strUrl = objReader["Comment_Url"].ToString();
                objComment.strName = objReader["Comment_Name"].ToString();
                objComment.strEmail = objReader["Comment_Email"].ToString();
                objComment.strPhone = objReader["Comment_Phone"].ToString();
                objComment.strTitle = objReader["Comment_Title"].ToString();
                objComment.strDesc = objReader["Comment_Desc"].ToString();
                objComment.iRate = int.Parse(objReader["Comment_Rate"].ToString());
                objComment.strIpAddrs = objReader["Comment_IpAddrs"].ToString();
                objComment.dtDate = DateTime.Parse(objReader["Comment_Date"].ToString());
                objComment.bActive = bool.Parse(objReader["Comment_Active"].ToString());
                objComment.bAbuse = bool.Parse(objReader["Comment_Abuse"].ToString());
                objCommentList.Add(objComment);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCommentList;
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

	public string fn_ChangeCommentActiveStatus(CommentClass objComment)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Comments SET Comment_Active=@Comment_Active WHERE Comment_ID=@Comment_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("Comment_ID", objComment.iID);
			objCommand.Parameters.AddWithValue("Comment_Active", objComment.bActive);

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

    public string fn_ChangeCommentAbuseStatus(CommentClass objComment)
    {
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_Comments SET Comment_Abuse=@Comment_Abuse WHERE Comment_ID=@Comment_ID", objConnection);
            objCommand.Parameters.AddWithValue("Comment_ID", objComment.iID);
            objCommand.Parameters.AddWithValue("Comment_Abuse", objComment.bAbuse);

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
