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
/// Summary description for DBCommentKeysClass
/// </summary>
public class DBCommentKeysClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    public string fn_saveCommentKeys(CommentKeysClass oCommentKey)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO tbl_CommentKeys (Title) VALUES (@Title)", objConnection);

            objCommand.Parameters.AddWithValue("@Title", oCommentKey.strTitle);

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

    public string fn_editCommentKeys(CommentKeysClass oCommentKey)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE tbl_CommentKeys SET Title=@Title WHERE ID = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", oCommentKey.iID);
            objCommand.Parameters.AddWithValue("@Title", oCommentKey.strTitle);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been updated";
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

    public string fn_deleteCommentKeys(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM tbl_CommentKeys WHERE ID = @ID", objConnection);
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

    public CoreWebList<CommentKeysClass> fn_getCommentKeysList()
    {
        CoreWebList<CommentKeysClass> objCommentKeyList = null;
        CommentKeysClass objCommentKey = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM tbl_CommentKeys", objConnection);

            objReader = objCommand.ExecuteReader();

            objCommentKeyList = new CoreWebList<CommentKeysClass>();

            while (objReader.Read())
            {
                objCommentKey = new CommentKeysClass();

                objCommentKey.iID = int.Parse(objReader["ID"].ToString());
                objCommentKey.strTitle = objReader["Title"].ToString();

                objCommentKeyList.Add(objCommentKey);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objCommentKeyList;
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

    public CoreWebList<CommentKeysClass> fn_getCommentKeyByID(int iID)
    {
        CoreWebList<CommentKeysClass> objCommentKeyList = null;
        CommentKeysClass objCommentKey = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM tbl_CommentKeys WHERE ID = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objCommentKeyList = new CoreWebList<CommentKeysClass>();

            if (objReader.Read())
            {
                objCommentKey = new CommentKeysClass();

                objCommentKey.iID = int.Parse(objReader["ID"].ToString());
                objCommentKey.strTitle = objReader["Title"].ToString();

                objCommentKeyList.Add(objCommentKey);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objCommentKeyList;
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

    public CoreWebList<CommentKeysClass> fn_getCommentKeyByKeys(string strkeys)
    {
        CoreWebList<CommentKeysClass> objCommentKeyList = null;
        CommentKeysClass objCommentKey = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM tbl_CommentKeys WHERE Title like '%" + strkeys + "%'", objConnection);

            objReader = objCommand.ExecuteReader();

            objCommentKeyList = new CoreWebList<CommentKeysClass>();

            while (objReader.Read())
            {
                objCommentKey = new CommentKeysClass();

                objCommentKey.iID = int.Parse(objReader["ID"].ToString());
                objCommentKey.strTitle = objReader["Title"].ToString();

                objCommentKeyList.Add(objCommentKey);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objCommentKeyList;
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
