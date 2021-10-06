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
/// Summary description for DBCommentMasterClass
/// </summary>
public class DBCommentMasterClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;
    
    public string fn_saveComment(CommentsMasterClass objComment)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO tbl_Comments(Comment_UserId, Comment_Name, Comment_Email, Comment_Phone, Comment_Comments, Comment_Url, Comment_Ip, Comment_Type) VALUES (@Comment_UserId, @Comment_Name, @Comment_Email, @Comment_Phone, @Comment_Comments, @Comment_Url, @Comment_Ip, @Comment_Type)", objConnection);

            objCommand.Parameters.AddWithValue("@Comment_UserId", objComment.iUserID);
            objCommand.Parameters.AddWithValue("@Comment_Name", objComment.strName);
            objCommand.Parameters.AddWithValue("@Comment_Email", objComment.strEmail);
            objCommand.Parameters.AddWithValue("@Comment_Phone", objComment.strPhone);
            objCommand.Parameters.AddWithValue("@Comment_Comments", objComment.strComment);
            objCommand.Parameters.AddWithValue("@Comment_Url", objComment.strUrl);
            objCommand.Parameters.AddWithValue("@Comment_Ip", HttpContext.Current.Request.UserHostAddress);
            objCommand.Parameters.AddWithValue("@Comment_Type", objComment.strType);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been inserted";
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

    public string fn_deleteComment(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM tbl_Comments WHERE Comment_Id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been deleted";
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

    public CoreWebList<CommentsMasterClass> fn_getCommentList()
    {
        CoreWebList<CommentsMasterClass> objCommentList = null;
        CommentsMasterClass objComment = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Comments ORDER BY comment_date DESC", objConnection);
            objReader = objCommand.ExecuteReader();
            objCommentList = new CoreWebList<CommentsMasterClass>();

            while (objReader.Read())
            {
                objComment = new CommentsMasterClass();

                objComment.iID = int.Parse(objReader["Comment_Id"].ToString());
                objComment.iUserID = int.Parse(objReader["Comment_UserId"].ToString());
                objComment.strName = objReader["Comment_Name"].ToString();
                objComment.strEmail = objReader["Comment_Email"].ToString();
                objComment.strPhone = objReader["Comment_Phone"].ToString();
                objComment.strComment = objReader["Comment_Comments"].ToString();
                objComment.strUrl = objReader["Comment_Url"].ToString();
                objComment.dtDate = DateTime.Parse(objReader["Comment_Date"].ToString());
                objComment.strIp = objReader["Comment_Ip"].ToString();
                objComment.strType = objReader["Comment_Type"].ToString();
                objComment.bAbuse = bool.Parse(objReader["Comment_Abuse"].ToString());
                objComment.iAbuseUserID = int.Parse(objReader["Comment_AbuseUser"].ToString());
                objComment.bActive = bool.Parse(objReader["Comment_Active"].ToString());
                objComment.bQuest = bool.Parse(objReader["Comment_Quest"].ToString());

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

    public CoreWebList<CommentsMasterClass> fn_get_CommentList()
    {
        CoreWebList<CommentsMasterClass> objCommentList = null;
        CommentsMasterClass objComment = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Comments ORDER BY Comment_Abuse, Comment_Active, comment_date DESC", objConnection);
            objReader = objCommand.ExecuteReader();
            objCommentList = new CoreWebList<CommentsMasterClass>();

            while (objReader.Read())
            {
                objComment = new CommentsMasterClass();

                objComment.iID = int.Parse(objReader["Comment_Id"].ToString());
                objComment.iUserID = int.Parse(objReader["Comment_UserId"].ToString());
                objComment.strName = objReader["Comment_Name"].ToString();
                objComment.strEmail = objReader["Comment_Email"].ToString();
                objComment.strPhone = objReader["Comment_Phone"].ToString();
                objComment.strComment = objReader["Comment_Comments"].ToString();
                objComment.strUrl = objReader["Comment_Url"].ToString();
                objComment.dtDate = DateTime.Parse(objReader["Comment_Date"].ToString());
                objComment.strIp = objReader["Comment_Ip"].ToString();
                objComment.strType = objReader["Comment_Type"].ToString();
                objComment.bAbuse = bool.Parse(objReader["Comment_Abuse"].ToString());
                objComment.iAbuseUserID = int.Parse(objReader["Comment_AbuseUser"].ToString());
                objComment.bActive = bool.Parse(objReader["Comment_Active"].ToString());
                objComment.bQuest = bool.Parse(objReader["Comment_Quest"].ToString());

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

    public CoreWebList<CommentsMasterClass> fn_getCommentByID(int iID)
    {
        CoreWebList<CommentsMasterClass> objCommentList = null;
        CommentsMasterClass objComment = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM tbl_Comments WHERE Comment_Id = @ID ", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objCommentList = new CoreWebList<CommentsMasterClass>();

            while (objReader.Read())
            {
                objComment = new CommentsMasterClass();

                objComment.iID = int.Parse(objReader["Comment_Id"].ToString());
                objComment.iUserID = int.Parse(objReader["Comment_UserId"].ToString());
                objComment.strName = objReader["Comment_Name"].ToString();
                objComment.strEmail = objReader["Comment_Email"].ToString();
                objComment.strPhone = objReader["Comment_Phone"].ToString();
                objComment.strComment = objReader["Comment_Comments"].ToString();
                objComment.strUrl = objReader["Comment_Url"].ToString();
                objComment.dtDate = DateTime.Parse(objReader["Comment_Date"].ToString());
                objComment.strIp = objReader["Comment_Ip"].ToString();
                objComment.strType = objReader["Comment_Type"].ToString();
                objComment.bAbuse = bool.Parse(objReader["Comment_Abuse"].ToString());
                objComment.iAbuseUserID = int.Parse(objReader["Comment_AbuseUser"].ToString());
                objComment.bActive = bool.Parse(objReader["Comment_Active"].ToString());
                objComment.bQuest = bool.Parse(objReader["Comment_Quest"].ToString());

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

    public CoreWebList<CommentsMasterClass> fn_getCommentByUrl(string strUrl)
    {
        CoreWebList<CommentsMasterClass> objCommentList = null;
        CommentsMasterClass objComment = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM tbl_Comments WHERE Comment_Url Like @Comment_Url AND Comment_Active='true'", objConnection);
            objCommand.Parameters.AddWithValue("@Comment_Url", strUrl);

            objReader = objCommand.ExecuteReader();

            objCommentList = new CoreWebList<CommentsMasterClass>();

            while (objReader.Read())
            {
                objComment = new CommentsMasterClass();

                objComment.iID = int.Parse(objReader["Comment_Id"].ToString());
                objComment.iUserID = int.Parse(objReader["Comment_UserId"].ToString());
                objComment.strName = objReader["Comment_Name"].ToString();
                objComment.strEmail = objReader["Comment_Email"].ToString();
                objComment.strPhone = objReader["Comment_Phone"].ToString();
                objComment.strComment = objReader["Comment_Comments"].ToString();
                objComment.strUrl = objReader["Comment_Url"].ToString();
                objComment.dtDate = DateTime.Parse(objReader["Comment_Date"].ToString());
                objComment.strIp = objReader["Comment_Ip"].ToString();
                objComment.strType = objReader["Comment_Type"].ToString();
                objComment.bAbuse = bool.Parse(objReader["Comment_Abuse"].ToString());
                objComment.iAbuseUserID = int.Parse(objReader["Comment_AbuseUser"].ToString());
                objComment.bActive = bool.Parse(objReader["Comment_Active"].ToString());
                objComment.bQuest = bool.Parse(objReader["Comment_Quest"].ToString());

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

    public CoreWebList<CommentsMasterClass> fn_getAbusedComments()
    {
        CoreWebList<CommentsMasterClass> objCommentList = null;
        CommentsMasterClass objComment = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM tbl_Comments WHERE Comment_Abuse = 'true'", objConnection);

            objReader = objCommand.ExecuteReader();

            objCommentList = new CoreWebList<CommentsMasterClass>();

            while (objReader.Read())
            {
                objComment = new CommentsMasterClass();

                objComment.iID = int.Parse(objReader["Comment_Id"].ToString());
                objComment.iUserID = int.Parse(objReader["Comment_UserId"].ToString());
                objComment.strName = objReader["Comment_Name"].ToString();
                objComment.strEmail = objReader["Comment_Email"].ToString();
                objComment.strPhone = objReader["Comment_Phone"].ToString();
                objComment.strComment = objReader["Comment_Comments"].ToString();
                objComment.strUrl = objReader["Comment_Url"].ToString();
                objComment.dtDate = DateTime.Parse(objReader["Comment_Date"].ToString());
                objComment.strIp = objReader["Comment_Ip"].ToString();
                objComment.strType = objReader["Comment_Type"].ToString();
                objComment.bAbuse = bool.Parse(objReader["Comment_Abuse"].ToString());
                objComment.iAbuseUserID = int.Parse(objReader["Comment_AbuseUser"].ToString());
                objComment.bActive = bool.Parse(objReader["Comment_Active"].ToString());
                objComment.bQuest = bool.Parse(objReader["Comment_Quest"].ToString());

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

    public CoreWebList<CommentsMasterClass> fn_getActiveCommentByUrl(string strUrl)
    {
        CoreWebList<CommentsMasterClass> objCommentList = null;
        CommentsMasterClass objComment = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM tbl_Comments WHERE Comment_Active ='true' AND Comment_Url=@Comment_Url", objConnection);
            objCommand.Parameters.AddWithValue("@Comment_Url", strUrl);
            objReader = objCommand.ExecuteReader();

            objCommentList = new CoreWebList<CommentsMasterClass>();

            while (objReader.Read())
            {
                objComment = new CommentsMasterClass();

                objComment.iID = int.Parse(objReader["Comment_Id"].ToString());
                objComment.iUserID = int.Parse(objReader["Comment_UserId"].ToString());
                objComment.strName = objReader["Comment_Name"].ToString();
                objComment.strEmail = objReader["Comment_Email"].ToString();
                objComment.strPhone = objReader["Comment_Phone"].ToString();
                objComment.strComment = objReader["Comment_Comments"].ToString();
                objComment.strUrl = objReader["Comment_Url"].ToString();
                objComment.dtDate = DateTime.Parse(objReader["Comment_Date"].ToString());
                objComment.strIp = objReader["Comment_Ip"].ToString();
                objComment.strType = objReader["Comment_Type"].ToString();
                objComment.bAbuse = bool.Parse(objReader["Comment_Abuse"].ToString());
                objComment.iAbuseUserID = int.Parse(objReader["Comment_AbuseUser"].ToString());
                objComment.bActive = bool.Parse(objReader["Comment_Active"].ToString());
                objComment.bQuest = bool.Parse(objReader["Comment_Quest"].ToString());

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

    public string fn_ChangeCommentStatus(CommentsMasterClass objComment)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE tbl_Comments SET Comment_Active=@Comment_Active WHERE Comment_Id=@Comment_Id", objConnection);

            objCommand.Parameters.AddWithValue("@Comment_Id", objComment.iID);
            objCommand.Parameters.AddWithValue("@Comment_Active", objComment.bActive);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been inserted";
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

    public string fn_ChangeCommentQuestStatus(CommentsMasterClass objComment)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE tbl_Comments SET Comment_Quest=@Comment_Quest WHERE Comment_Id=@Comment_Id", objConnection);

            objCommand.Parameters.AddWithValue("@Comment_Id", objComment.iID);
            objCommand.Parameters.AddWithValue("@Comment_Quest", objComment.bQuest);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been inserted";
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

    public string fn_ChangeAbusedCommentStatus(CommentsMasterClass objComment)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE tbl_Comments SET Comment_Abuse=@Comment_Abuse, Comment_AbuseUser=@Comment_AbuseUser WHERE Comment_Id=@Comment_Id", objConnection);

            objCommand.Parameters.AddWithValue("@Comment_Id", objComment.iID);
            objCommand.Parameters.AddWithValue("@Comment_Abuse", objComment.bAbuse);
            objCommand.Parameters.AddWithValue("@Comment_AbuseUser", objComment.iAbuseUserID);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been inserted";
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