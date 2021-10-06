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
/// Summary description for DBLikeClass
/// </summary>
public class DBLikeClass
{
	private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string fn_SaveLike(string strType, int iTypeID, int iLike, int iDislike)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_Like(Type, TypeID, Like_Count, dislike_Count) VALUES (@Type, @TypeID, @Like_Count, @dislike_Count)", objConnection);

            objCommand.Parameters.AddWithValue("@Type", strType);
            objCommand.Parameters.AddWithValue("@TypeID", iTypeID);
            objCommand.Parameters.AddWithValue("@Like_Count", iLike);
            objCommand.Parameters.AddWithValue("@dislike_Count", iDislike);
            
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

    public string fn_IncLike(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_Like SET Like_Count=Like_Count + 1 WHERE ID = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
            
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

    public string fn_IncDisLike(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_Like SET dislike_Count=dislike_Count + 1 WHERE ID = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);

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

    internal CoreWebList<LikeClass> fn_getLikeByTypeID(int iTypeID, string strType)
    {
        CoreWebList<LikeClass> objRatingList = null;
        LikeClass objRating = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Like Where Type=@Type AND TypeID=@TypeID", objConnection);
            objCommand.Parameters.AddWithValue("@Type", strType);
            objCommand.Parameters.AddWithValue("@TypeID", iTypeID);

            objReader = objCommand.ExecuteReader();

            objRatingList = new CoreWebList<LikeClass>();

            if (objReader.Read())
            {
                objRating = new LikeClass();
                objRating.iID = int.Parse(objReader["ID"].ToString());
                objRating.strType = objReader["Type"].ToString();
                objRating.iTypeID = int.Parse(objReader["TypeID"].ToString());
                objRating.iLikeCount = int.Parse(objReader["Like_Count"].ToString());
                objRating.iDisLikeCount = int.Parse(objReader["dislike_Count"].ToString());
                objRatingList.Add(objRating);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objRatingList;
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