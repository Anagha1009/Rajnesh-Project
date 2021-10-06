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
/// Summary description for DBDownloadsClass
/// </summary>
public class DBDownloadsClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    internal string fn_saveFile(string strTitle, int iTypeID, string strType, string strFileName)
    {

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_File(file_title,file_typeid,file_type,file_filename) VALUES (@Title,@TypeId,@Type,@Filename)", objConnection);

            objCommand.Parameters.AddWithValue("@Title", strTitle);
            objCommand.Parameters.AddWithValue("@TypeId", iTypeID);
            objCommand.Parameters.AddWithValue("@Type", strType);
            objCommand.Parameters.AddWithValue("@Filename", strFileName);
            

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

    internal string fn_deleteFile(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_File WHERE file_id = @ID", objConnection);
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

    internal yo_lib.CoreWebList<DownloadsClass> fn_getFileByID(int iID)
    {
        CoreWebList<DownloadsClass> objFileList = null;
        DownloadsClass objFiles = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_File WHERE file_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objFileList = new CoreWebList<DownloadsClass>();

            while (objReader.Read())
            {
                objFiles = new DownloadsClass();
                objFiles.iID = int.Parse(objReader["file_id"].ToString());
                objFiles.strTitle = objReader["file_title"].ToString();
                objFiles.iTypeID = int.Parse(objReader["file_typeid"].ToString());
                objFiles.strType = objReader["file_type"].ToString();
                objFiles.strFileName = objReader["file_filename"].ToString();
                objFileList.Add(objFiles);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objFileList;
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

    internal yo_lib.CoreWebList<DownloadsClass> fn_getFileList()
    {
        CoreWebList<DownloadsClass> objFileList = null;
        DownloadsClass objFiles = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_File order By file_type desc", objConnection);

            objReader = objCommand.ExecuteReader();

            objFileList = new CoreWebList<DownloadsClass>();

            while (objReader.Read())
            {

                objFiles = new DownloadsClass();
                objFiles.iID = int.Parse(objReader["file_id"].ToString());
                objFiles.strTitle = objReader["file_title"].ToString();
                objFiles.iTypeID = int.Parse(objReader["file_typeid"].ToString());
                objFiles.strType = objReader["file_type"].ToString();
                objFiles.strFileName = objReader["file_filename"].ToString();
                objFileList.Add(objFiles);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objFileList;
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

    internal yo_lib.CoreWebList<DownloadsClass> fn_getFileByType(string strType)
    {
        CoreWebList<DownloadsClass> objFileList = null;
        DownloadsClass objFiles = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_File WHERE file_type = @Type", objConnection);
            objCommand.Parameters.AddWithValue("@Type", strType);

            objReader = objCommand.ExecuteReader();

            objFileList = new CoreWebList<DownloadsClass>();

            while (objReader.Read())
            {
                objFiles = new DownloadsClass();
                objFiles.iID = int.Parse(objReader["file_id"].ToString());
                objFiles.strTitle = objReader["file_title"].ToString();
                objFiles.iTypeID = int.Parse(objReader["file_typeid"].ToString());
                objFiles.strType = objReader["file_type"].ToString();
                objFiles.strFileName = objReader["file_filename"].ToString();
                objFileList.Add(objFiles);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objFileList;
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

    internal yo_lib.CoreWebList<DownloadsClass> fn_getFileByTypeAndTypeID(string strType, int iTypeID)
    {
        CoreWebList<DownloadsClass> objFileList = null;
        DownloadsClass objFiles = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_File WHERE file_type = @Type AND file_typeid = @TypeID", objConnection);
            objCommand.Parameters.AddWithValue("@Type", strType);
            objCommand.Parameters.AddWithValue("@TypeID", iTypeID);

            objReader = objCommand.ExecuteReader();

            objFileList = new CoreWebList<DownloadsClass>();

            while (objReader.Read())
            {
                objFiles = new DownloadsClass();
                objFiles.iID = int.Parse(objReader["file_id"].ToString());
                objFiles.strTitle = objReader["file_title"].ToString();
                objFiles.iTypeID = int.Parse(objReader["file_typeid"].ToString());
                objFiles.strType = objReader["file_type"].ToString();
                objFiles.strFileName = objReader["file_filename"].ToString();
                objFileList.Add(objFiles);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objFileList;
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

	public DBDownloadsClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
