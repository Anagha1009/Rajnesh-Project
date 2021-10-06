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
/// Summary description for DBBlogClass
/// </summary>
public class DBBlogClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveBlog(BlogClass objBlog)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_Blogs (Blog_Title, Blog_Description, Blog_Image, Blog_CreatedOn) VALUES (@Blog_Title, @Blog_Description, @Blog_Image, @Blog_CreatedOn)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Blog_Title", objBlog.strTitle);
			objCommand.Parameters.AddWithValue("@Blog_Description", objBlog.strDescription);
			objCommand.Parameters.AddWithValue("@Blog_Image", objBlog.strImage);
			objCommand.Parameters.AddWithValue("@Blog_CreatedOn", objBlog.dtCreatedOn);

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

	public string fn_editBlog(BlogClass objBlog)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Blogs SET Blog_Title=@Blog_Title, Blog_Description=@Blog_Description, Blog_Image=@Blog_Image, Blog_CreatedOn=@Blog_CreatedOn WHERE Blog_ID=@Blog_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Blog_ID", objBlog.iID);
			objCommand.Parameters.AddWithValue("@Blog_Title", objBlog.strTitle);
			objCommand.Parameters.AddWithValue("@Blog_Description", objBlog.strDescription);
			objCommand.Parameters.AddWithValue("@Blog_Image", objBlog.strImage);
			objCommand.Parameters.AddWithValue("@Blog_CreatedOn", objBlog.dtCreatedOn);

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

	public string fn_deleteBlog(int iBlogID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Blogs WHERE Blog_ID=@Blog_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Blog_ID", iBlogID);

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

	public CoreWebList<BlogClass> fn_getBlogList()
	{
		CoreWebList<BlogClass> objBlogList = null;
		BlogClass objBlog = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Blogs", objConnection);
			objReader = objCommand.ExecuteReader();
			objBlogList = new CoreWebList<BlogClass>();
			while (objReader.Read())
			{
				objBlog = new BlogClass();
				objBlog.iID = int.Parse(objReader["Blog_ID"].ToString());
				objBlog.strTitle = objReader["Blog_Title"].ToString();
				objBlog.strDescription = objReader["Blog_Description"].ToString();
				objBlog.strImage = objReader["Blog_Image"].ToString();
				objBlog.dtCreatedOn = DateTime.Parse(objReader["Blog_CreatedOn"].ToString());
				objBlogList.Add(objBlog);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBlogList;
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

	public CoreWebList<BlogClass> fn_getBlogByID(int iBlogID)
	{
		CoreWebList<BlogClass> objBlogList = null;
		BlogClass objBlog = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Blogs WHERE Blog_ID=@Blog_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Blog_ID", iBlogID);
			objReader = objCommand.ExecuteReader();
			objBlogList = new CoreWebList<BlogClass>();
			if (objReader.Read())
			{
				objBlog = new BlogClass();
				objBlog.iID = int.Parse(objReader["Blog_ID"].ToString());
				objBlog.strTitle = objReader["Blog_Title"].ToString();
				objBlog.strDescription = objReader["Blog_Description"].ToString();
				objBlog.strImage = objReader["Blog_Image"].ToString();
				objBlog.dtCreatedOn = DateTime.Parse(objReader["Blog_CreatedOn"].ToString());
				objBlogList.Add(objBlog);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBlogList;
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

	public CoreWebList<BlogClass> fn_getBlogByTitle(string strBlogTitle)
	{
		CoreWebList<BlogClass> objBlogList = null;
		BlogClass objBlog = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Blogs WHERE Blog_Title=@Blog_Title", objConnection);
			objCommand.Parameters.AddWithValue("@Blog_Title", strBlogTitle);
			objReader = objCommand.ExecuteReader();
			objBlogList = new CoreWebList<BlogClass>();
			if (objReader.Read())
			{
				objBlog = new BlogClass();
				objBlog.iID = int.Parse(objReader["Blog_ID"].ToString());
				objBlog.strTitle = objReader["Blog_Title"].ToString();
				objBlog.strDescription = objReader["Blog_Description"].ToString();
				objBlog.strImage = objReader["Blog_Image"].ToString();
				objBlog.dtCreatedOn = DateTime.Parse(objReader["Blog_CreatedOn"].ToString());
				objBlogList.Add(objBlog);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBlogList;
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

	public CoreWebList<BlogClass> fn_getBlogByKeys(string strBlogTitle)
	{
		CoreWebList<BlogClass> objBlogList = null;
		BlogClass objBlog = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Blogs WHERE Blog_Title like '%' + @Blog_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Blog_Title", strBlogTitle);
			objReader = objCommand.ExecuteReader();
			objBlogList = new CoreWebList<BlogClass>();
			while (objReader.Read())
			{
				objBlog = new BlogClass();
				objBlog.iID = int.Parse(objReader["Blog_ID"].ToString());
				objBlog.strTitle = objReader["Blog_Title"].ToString();
				objBlog.strDescription = objReader["Blog_Description"].ToString();
				objBlog.strImage = objReader["Blog_Image"].ToString();
				objBlog.dtCreatedOn = DateTime.Parse(objReader["Blog_CreatedOn"].ToString());
				objBlogList.Add(objBlog);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBlogList;
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
