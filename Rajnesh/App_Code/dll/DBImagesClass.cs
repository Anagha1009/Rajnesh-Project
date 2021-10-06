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
/// Summary description for DBImagesClass
/// </summary>
public class DBImagesClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    internal string fn_saveImage(string strTitle,int iTypeID,string strType, string strThumbnail,string strBigImage)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_Images(images_title,images_typeid,images_type,images_thumbnail,images_bigimage) VALUES (@Title,@TypeId,@Type,@Thumbnail,@BigImage)", objConnection);

            objCommand.Parameters.AddWithValue("@Title", strTitle);
            objCommand.Parameters.AddWithValue("@TypeId", iTypeID);
            objCommand.Parameters.AddWithValue("@Type", strType);
            objCommand.Parameters.AddWithValue("@Thumbnail", strThumbnail);
            objCommand.Parameters.AddWithValue("@BigImage", strBigImage);

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

    internal string fn_deleteImage(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_Images WHERE images_id = @ID", objConnection);
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

    internal yo_lib.CoreWebList<ImagesClass> fn_getImageByID(int iID)
    {
        CoreWebList<ImagesClass> objImagesList = null;
        ImagesClass objImages = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Images WHERE images_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objImagesList = new CoreWebList<ImagesClass>();

            while (objReader.Read())
            {
                objImages = new ImagesClass();
                objImages.iID = int.Parse(objReader["images_id"].ToString());
                objImages.strTitle = objReader["images_title"].ToString();
                objImages.iTypeID = int.Parse(objReader["images_typeid"].ToString());
                objImages.strType = objReader["images_type"].ToString();
                objImages.strThumbnail = objReader["images_thumbnail"].ToString();
                objImages.strBigImage=objReader["images_bigimage"].ToString();       
                objImagesList.Add(objImages);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objImagesList;
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

    internal yo_lib.CoreWebList<ImagesClass> fn_getImagesList()
    {
        CoreWebList<ImagesClass> objImagesList = null;
        ImagesClass objImages = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Images order By images_type desc", objConnection);

            objReader = objCommand.ExecuteReader();

            objImagesList = new CoreWebList<ImagesClass>();

            while (objReader.Read())
            {

                objImages = new ImagesClass();
                objImages.iID = int.Parse(objReader["images_id"].ToString());
                objImages.strTitle = objReader["images_title"].ToString();
                objImages.iTypeID = int.Parse(objReader["images_typeid"].ToString());
                objImages.strType = objReader["images_type"].ToString();
                objImages.strThumbnail = objReader["images_thumbnail"].ToString();
                objImages.strBigImage = objReader["images_bigimage"].ToString();
                objImagesList.Add(objImages);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objImagesList;
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

    internal yo_lib.CoreWebList<ImagesClass> fn_getImageByType(string strType)
    {
        CoreWebList<ImagesClass> objImagesList = null;
        ImagesClass objImages = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Images WHERE images_type = @Type", objConnection);
            objCommand.Parameters.AddWithValue("@Type", strType);

            objReader = objCommand.ExecuteReader();

            objImagesList = new CoreWebList<ImagesClass>();

            while (objReader.Read())
            {
                objImages = new ImagesClass();
                objImages.iID = int.Parse(objReader["images_id"].ToString());
                objImages.strTitle = objReader["images_title"].ToString();
                objImages.iTypeID = int.Parse(objReader["images_typeid"].ToString());
                objImages.strType = objReader["images_type"].ToString();
                objImages.strThumbnail = objReader["images_thumbnail"].ToString();
                objImages.strBigImage = objReader["images_bigimage"].ToString();
                objImagesList.Add(objImages);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objImagesList;
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


    internal yo_lib.CoreWebList<ImagesClass> fn_getImageByTypeAndTypeID(string strType,int iTypeID)
    {
        CoreWebList<ImagesClass> objImagesList = null;
        ImagesClass objImages = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Images WHERE images_type = @Type AND images_typeid=@TypeID", objConnection);
            objCommand.Parameters.AddWithValue("@Type", strType);
            objCommand.Parameters.AddWithValue("@TypeID", iTypeID);
            objReader = objCommand.ExecuteReader();

            objImagesList = new CoreWebList<ImagesClass>();

            while (objReader.Read())
            {
                objImages = new ImagesClass();
                objImages.iID = int.Parse(objReader["images_id"].ToString());
                objImages.strTitle = objReader["images_title"].ToString();
                objImages.iTypeID = int.Parse(objReader["images_typeid"].ToString());
                objImages.strType = objReader["images_type"].ToString();
                objImages.strThumbnail = objReader["images_thumbnail"].ToString();
                objImages.strBigImage = objReader["images_bigimage"].ToString();
                objImagesList.Add(objImages);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objImagesList;
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

	public DBImagesClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
