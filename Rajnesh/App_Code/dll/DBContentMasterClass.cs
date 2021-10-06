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
/// Summary description for DBOverviewClass
/// </summary>
public class DBContentMasterClass
{

    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    
    public string fn_saveContent(string strContentText,string strContentType)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand =new SqlCommand("INSERT INTO tbl_Content (content_Text,content_Type) VALUES (@text,@type)",objConnection) ;
          
            objCommand.Parameters.AddWithValue("@text", strContentText);
            objCommand.Parameters.AddWithValue("@type", strContentType);

            if (objReader != null)
            {
                objReader.Close();
            }


            if (objCommand.ExecuteNonQuery() > 0)
            {
                // load here
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
            if (objReader != null)
            {
                objReader.Close();
            }
        }
    }

    public string fn_editContent(string strContentText,string strContentType)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_Content SET content_Text = @text WHERE content_Type =@type", objConnection);
            objCommand.Parameters.AddWithValue("@text", strContentText);
            objCommand.Parameters.AddWithValue("@type", strContentType);
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
            return "ERROR : " + ex.StackTrace;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    public CoreWebList<ContentMasterClass> fn_getContent(string strContentType)
    {
        CoreWebList<ContentMasterClass> objContentList = null;
        ContentMasterClass objContent = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Content WHERE content_Type=@ContentType", objConnection);
            objCommand.Parameters.AddWithValue("@ContentType", strContentType);
            objReader = objCommand.ExecuteReader();
            objContentList = new CoreWebList<ContentMasterClass>();
            if (objReader.Read())
            {
                objContent = new ContentMasterClass();
                objContent.strContentType = objReader["content_Type"].ToString();
                objContent.strContentText = objReader["content_Text"].ToString();  
                objContentList.Add(objContent);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objContentList;
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
