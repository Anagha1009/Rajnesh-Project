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
/// Summary description for DBratingClass
/// </summary>
public class DBratingClass
{
	private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string fn_SaveRating(string strType, int iTypeID, float fCount, int iClicks)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO Rating(Rating_Type, Rating_TypeID, Rating_Count, Rating_Clicks) VALUES (@Rating_Type, @Rating_TypeID, @Rating_Count, @Rating_Clicks)", objConnection);

            objCommand.Parameters.AddWithValue("@Rating_Type", strType);
            objCommand.Parameters.AddWithValue("@Rating_TypeID", iTypeID);
            objCommand.Parameters.AddWithValue("@Rating_Count", fCount);
            objCommand.Parameters.AddWithValue("@Rating_Clicks", iClicks);
            
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

    public string fn_EditRating(int iID, float fCount, float iClicks)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE Rating SET Rating_Count=@Rating_Count, Rating_Clicks=@Rating_Clicks WHERE Rating_ID = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@Rating_Count", fCount);
            objCommand.Parameters.AddWithValue("@Rating_Clicks", iClicks);
            
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

    internal CoreWebList<RatingClass> fn_getRatingByTypeID(int iTypeID, string strType)
    {
        CoreWebList<RatingClass> objRatingList = null;
        RatingClass objRating = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM Rating Where Rating_Type=@Rating_Type AND Rating_TypeID=@Rating_TypeID", objConnection);
            objCommand.Parameters.AddWithValue("@Rating_Type", strType);
            objCommand.Parameters.AddWithValue("@Rating_TypeID", iTypeID);

            objReader = objCommand.ExecuteReader();

            objRatingList = new CoreWebList<RatingClass>();

            if (objReader.Read())
            {
                objRating = new RatingClass();
                objRating.iID = int.Parse(objReader["Rating_ID"].ToString());
                objRating.strType = objReader["Rating_Type"].ToString();
                objRating.iTypeID = int.Parse(objReader["Rating_TypeID"].ToString());
                objRating.fCount = float.Parse(objReader["Rating_Count"].ToString());
                objRating.iClicks = int.Parse(objReader["Rating_Clicks"].ToString());
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