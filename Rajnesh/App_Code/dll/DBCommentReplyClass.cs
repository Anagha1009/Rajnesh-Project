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
/// Summary description for DBCommentReplyClass
/// </summary>
public class DBCommentReplyClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveCommentReply(CommentReplyClass objCommentReply)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_CommentReply (CommentReply_CommentID, CommentReply_Name, CommentReply_Email, CommentReply_Phone, CommentReply_Reply, CommentReply_Date, CommentReply_Active) VALUES (@CommentReply_CommentID, @CommentReply_Name, @CommentReply_Email, @CommentReply_Phone, @CommentReply_Reply, @CommentReply_Date, @CommentReply_Active)",objConnection) ;
			objCommand.Parameters.AddWithValue("@CommentReply_CommentID", objCommentReply.iCommentID);
			objCommand.Parameters.AddWithValue("@CommentReply_Name", objCommentReply.strName);
			objCommand.Parameters.AddWithValue("@CommentReply_Email", objCommentReply.strEmail);
			objCommand.Parameters.AddWithValue("@CommentReply_Phone", objCommentReply.strPhone);
			objCommand.Parameters.AddWithValue("@CommentReply_Reply", objCommentReply.strReply);
			objCommand.Parameters.AddWithValue("@CommentReply_Date", objCommentReply.dtDate);
			objCommand.Parameters.AddWithValue("@CommentReply_Active", objCommentReply.bActive);

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

	public string fn_editCommentReply(CommentReplyClass objCommentReply)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_CommentReply SET CommentReply_CommentID=@CommentReply_CommentID, CommentReply_Name=@CommentReply_Name, CommentReply_Email=@CommentReply_Email, CommentReply_Phone=@CommentReply_Phone, CommentReply_Reply=@CommentReply_Reply, CommentReply_Date=@CommentReply_Date, CommentReply_Active=@CommentReply_Active WHERE CommentReply_ID=@CommentReply_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CommentReply_ID", objCommentReply.iID);
			objCommand.Parameters.AddWithValue("@CommentReply_CommentID", objCommentReply.iCommentID);
			objCommand.Parameters.AddWithValue("@CommentReply_Name", objCommentReply.strName);
			objCommand.Parameters.AddWithValue("@CommentReply_Email", objCommentReply.strEmail);
			objCommand.Parameters.AddWithValue("@CommentReply_Phone", objCommentReply.strPhone);
			objCommand.Parameters.AddWithValue("@CommentReply_Reply", objCommentReply.strReply);
			objCommand.Parameters.AddWithValue("@CommentReply_Date", objCommentReply.dtDate);
			objCommand.Parameters.AddWithValue("@CommentReply_Active", objCommentReply.bActive);

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

	public string fn_deleteCommentReply(int iCommentReplyID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_CommentReply WHERE CommentReply_ID=@CommentReply_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CommentReply_ID", iCommentReplyID);

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

	public CoreWebList<CommentReplyClass> fn_getCommentReplyList()
	{
		CoreWebList<CommentReplyClass> objCommentReplyList = null;
		CommentReplyClass objCommentReply = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CommentReply", objConnection);
			objReader = objCommand.ExecuteReader();
			objCommentReplyList = new CoreWebList<CommentReplyClass>();
			while (objReader.Read())
			{
				objCommentReply = new CommentReplyClass();
				objCommentReply.iID = int.Parse(objReader["CommentReply_ID"].ToString());
				objCommentReply.iCommentID = int.Parse(objReader["CommentReply_CommentID"].ToString());
				objCommentReply.strName = objReader["CommentReply_Name"].ToString();
				objCommentReply.strEmail = objReader["CommentReply_Email"].ToString();
				objCommentReply.strPhone = objReader["CommentReply_Phone"].ToString();
				objCommentReply.strReply = objReader["CommentReply_Reply"].ToString();
				objCommentReply.dtDate = DateTime.Parse(objReader["CommentReply_Date"].ToString());
				objCommentReply.bActive = bool.Parse(objReader["CommentReply_Active"].ToString());
				objCommentReplyList.Add(objCommentReply);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCommentReplyList;
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

	public CoreWebList<CommentReplyClass> fn_getCommentReplyByID(int iCommentReplyID)
	{
		CoreWebList<CommentReplyClass> objCommentReplyList = null;
		CommentReplyClass objCommentReply = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CommentReply WHERE CommentReply_ID=@CommentReply_ID", objConnection);
			objCommand.Parameters.AddWithValue("@CommentReply_ID", iCommentReplyID);
			objReader = objCommand.ExecuteReader();
			objCommentReplyList = new CoreWebList<CommentReplyClass>();
			if (objReader.Read())
			{
				objCommentReply = new CommentReplyClass();
				objCommentReply.iID = int.Parse(objReader["CommentReply_ID"].ToString());
				objCommentReply.iCommentID = int.Parse(objReader["CommentReply_CommentID"].ToString());
				objCommentReply.strName = objReader["CommentReply_Name"].ToString();
				objCommentReply.strEmail = objReader["CommentReply_Email"].ToString();
				objCommentReply.strPhone = objReader["CommentReply_Phone"].ToString();
				objCommentReply.strReply = objReader["CommentReply_Reply"].ToString();
				objCommentReply.dtDate = DateTime.Parse(objReader["CommentReply_Date"].ToString());
				objCommentReply.bActive = bool.Parse(objReader["CommentReply_Active"].ToString());
				objCommentReplyList.Add(objCommentReply);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCommentReplyList;
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

	public CoreWebList<CommentReplyClass> fn_getCommentReplyByName(string strCommentReplyName)
	{
		CoreWebList<CommentReplyClass> objCommentReplyList = null;
		CommentReplyClass objCommentReply = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CommentReply WHERE CommentReply_Name=@CommentReply_Name", objConnection);
			objCommand.Parameters.AddWithValue("@CommentReply_Name", strCommentReplyName);
			objReader = objCommand.ExecuteReader();
			objCommentReplyList = new CoreWebList<CommentReplyClass>();
			if (objReader.Read())
			{
				objCommentReply = new CommentReplyClass();
				objCommentReply.iID = int.Parse(objReader["CommentReply_ID"].ToString());
				objCommentReply.iCommentID = int.Parse(objReader["CommentReply_CommentID"].ToString());
				objCommentReply.strName = objReader["CommentReply_Name"].ToString();
				objCommentReply.strEmail = objReader["CommentReply_Email"].ToString();
				objCommentReply.strPhone = objReader["CommentReply_Phone"].ToString();
				objCommentReply.strReply = objReader["CommentReply_Reply"].ToString();
				objCommentReply.dtDate = DateTime.Parse(objReader["CommentReply_Date"].ToString());
				objCommentReply.bActive = bool.Parse(objReader["CommentReply_Active"].ToString());
				objCommentReplyList.Add(objCommentReply);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCommentReplyList;
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

	public CoreWebList<CommentReplyClass> fn_getCommentReplyByKeys(string strCommentReplyName)
	{
		CoreWebList<CommentReplyClass> objCommentReplyList = null;
		CommentReplyClass objCommentReply = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CommentReply WHERE CommentReply_Name like '%' + @CommentReply_Name + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@CommentReply_Name", strCommentReplyName);
			objReader = objCommand.ExecuteReader();
			objCommentReplyList = new CoreWebList<CommentReplyClass>();
			while (objReader.Read())
			{
				objCommentReply = new CommentReplyClass();
				objCommentReply.iID = int.Parse(objReader["CommentReply_ID"].ToString());
				objCommentReply.iCommentID = int.Parse(objReader["CommentReply_CommentID"].ToString());
				objCommentReply.strName = objReader["CommentReply_Name"].ToString();
				objCommentReply.strEmail = objReader["CommentReply_Email"].ToString();
				objCommentReply.strPhone = objReader["CommentReply_Phone"].ToString();
				objCommentReply.strReply = objReader["CommentReply_Reply"].ToString();
				objCommentReply.dtDate = DateTime.Parse(objReader["CommentReply_Date"].ToString());
				objCommentReply.bActive = bool.Parse(objReader["CommentReply_Active"].ToString());
				objCommentReplyList.Add(objCommentReply);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCommentReplyList;
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

	public CoreWebList<CommentReplyClass> fn_getCommentReplyByCommentID(int iCommentID)
	{
		CoreWebList<CommentReplyClass> objCommentReplyList = null;
		CommentReplyClass objCommentReply = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_CommentReply WHERE CommentReply_CommentID=@CommentReply_CommentID ORDER BY CommentReply_Date DESC", objConnection);
			objCommand.Parameters.AddWithValue("@CommentReply_CommentID", iCommentID);
			objReader = objCommand.ExecuteReader();
			objCommentReplyList = new CoreWebList<CommentReplyClass>();
			while (objReader.Read())
			{
				objCommentReply = new CommentReplyClass();
				objCommentReply.iID = int.Parse(objReader["CommentReply_ID"].ToString());
				objCommentReply.iCommentID = int.Parse(objReader["CommentReply_CommentID"].ToString());
				objCommentReply.strName = objReader["CommentReply_Name"].ToString();
				objCommentReply.strEmail = objReader["CommentReply_Email"].ToString();
				objCommentReply.strPhone = objReader["CommentReply_Phone"].ToString();
				objCommentReply.strReply = objReader["CommentReply_Reply"].ToString();
				objCommentReply.dtDate = DateTime.Parse(objReader["CommentReply_Date"].ToString());
				objCommentReply.bActive = bool.Parse(objReader["CommentReply_Active"].ToString());
				objCommentReplyList.Add(objCommentReply);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCommentReplyList;
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

    public CoreWebList<CommentReplyClass> fn_getTopCommentReplyByCommentID(int iCommentID)
    {
        CoreWebList<CommentReplyClass> objCommentReplyList = null;
        CommentReplyClass objCommentReply = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT Top 2 * FROM tbl_CommentReply WHERE CommentReply_CommentID=@CommentReply_CommentID ORDER BY CommentReply_Date DESC", objConnection);
            objCommand.Parameters.AddWithValue("@CommentReply_CommentID", iCommentID);
            objReader = objCommand.ExecuteReader();
            objCommentReplyList = new CoreWebList<CommentReplyClass>();
            while (objReader.Read())
            {
                objCommentReply = new CommentReplyClass();
                objCommentReply.iID = int.Parse(objReader["CommentReply_ID"].ToString());
                objCommentReply.iCommentID = int.Parse(objReader["CommentReply_CommentID"].ToString());
                objCommentReply.strName = objReader["CommentReply_Name"].ToString();
                objCommentReply.strEmail = objReader["CommentReply_Email"].ToString();
                objCommentReply.strPhone = objReader["CommentReply_Phone"].ToString();
                objCommentReply.strReply = objReader["CommentReply_Reply"].ToString();
                objCommentReply.dtDate = DateTime.Parse(objReader["CommentReply_Date"].ToString());
                objCommentReply.bActive = bool.Parse(objReader["CommentReply_Active"].ToString());
                objCommentReplyList.Add(objCommentReply);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCommentReplyList;
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

	public string fn_ChangeCommentReplyActiveStatus(CommentReplyClass objCommentReply)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_CommentReply SET CommentReply_Active=@CommentReply_Active WHERE CommentReply_ID=@CommentReply_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("CommentReply_ID", objCommentReply.iID);
			objCommand.Parameters.AddWithValue("CommentReply_Active", objCommentReply.bActive);

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
