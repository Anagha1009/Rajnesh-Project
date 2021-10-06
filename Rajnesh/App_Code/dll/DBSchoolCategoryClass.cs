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
/// Summary description for DBSchoolCategoryClass
/// </summary>
public class DBSchoolCategoryClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveSchoolCategory(SchoolCategoryClass objSchoolCategory)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_SchoolCategory (SchoolCategory_Title, SchoolCategory_Desc, SchoolCategory_Photo) VALUES (@SchoolCategory_Title, @SchoolCategory_Desc, @SchoolCategory_Photo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@SchoolCategory_Title", objSchoolCategory.strTitle);
			objCommand.Parameters.AddWithValue("@SchoolCategory_Desc", objSchoolCategory.strDesc);
			objCommand.Parameters.AddWithValue("@SchoolCategory_Photo", objSchoolCategory.strPhoto);

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

	public string fn_editSchoolCategory(SchoolCategoryClass objSchoolCategory)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_SchoolCategory SET SchoolCategory_Title=@SchoolCategory_Title, SchoolCategory_Desc=@SchoolCategory_Desc, SchoolCategory_Photo=@SchoolCategory_Photo WHERE SchoolCategory_ID=@SchoolCategory_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@SchoolCategory_ID", objSchoolCategory.iID);
			objCommand.Parameters.AddWithValue("@SchoolCategory_Title", objSchoolCategory.strTitle);
			objCommand.Parameters.AddWithValue("@SchoolCategory_Desc", objSchoolCategory.strDesc);
			objCommand.Parameters.AddWithValue("@SchoolCategory_Photo", objSchoolCategory.strPhoto);

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

	public string fn_deleteSchoolCategory(int iSchoolCategoryID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_SchoolCategory WHERE SchoolCategory_ID=@SchoolCategory_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@SchoolCategory_ID", iSchoolCategoryID);

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

	public CoreWebList<SchoolCategoryClass> fn_getSchoolCategoryList()
	{
		CoreWebList<SchoolCategoryClass> objSchoolCategoryList = null;
		SchoolCategoryClass objSchoolCategory = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_SchoolCategory ORDER BY SchoolCategory_Title ASC", objConnection);
			objReader = objCommand.ExecuteReader();
			objSchoolCategoryList = new CoreWebList<SchoolCategoryClass>();
			while (objReader.Read())
			{
				objSchoolCategory = new SchoolCategoryClass();
				objSchoolCategory.iID = int.Parse(objReader["SchoolCategory_ID"].ToString());
				objSchoolCategory.strTitle = objReader["SchoolCategory_Title"].ToString();
				objSchoolCategory.strDesc = objReader["SchoolCategory_Desc"].ToString();
				objSchoolCategory.strPhoto = objReader["SchoolCategory_Photo"].ToString();
				objSchoolCategoryList.Add(objSchoolCategory);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolCategoryList;
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

	public CoreWebList<SchoolCategoryClass> fn_getSchoolCategoryByID(int iSchoolCategoryID)
	{
		CoreWebList<SchoolCategoryClass> objSchoolCategoryList = null;
		SchoolCategoryClass objSchoolCategory = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolCategory WHERE SchoolCategory_ID=@SchoolCategory_ID", objConnection);
			objCommand.Parameters.AddWithValue("@SchoolCategory_ID", iSchoolCategoryID);
			objReader = objCommand.ExecuteReader();
			objSchoolCategoryList = new CoreWebList<SchoolCategoryClass>();
			if (objReader.Read())
			{
				objSchoolCategory = new SchoolCategoryClass();
				objSchoolCategory.iID = int.Parse(objReader["SchoolCategory_ID"].ToString());
				objSchoolCategory.strTitle = objReader["SchoolCategory_Title"].ToString();
				objSchoolCategory.strDesc = objReader["SchoolCategory_Desc"].ToString();
				objSchoolCategory.strPhoto = objReader["SchoolCategory_Photo"].ToString();
				objSchoolCategoryList.Add(objSchoolCategory);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolCategoryList;
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

	public CoreWebList<SchoolCategoryClass> fn_getSchoolCategoryByName(string strSchoolCategoryTitle)
	{
		CoreWebList<SchoolCategoryClass> objSchoolCategoryList = null;
		SchoolCategoryClass objSchoolCategory = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolCategory WHERE SchoolCategory_Title=@SchoolCategory_Title", objConnection);
			objCommand.Parameters.AddWithValue("@SchoolCategory_Title", strSchoolCategoryTitle);
			objReader = objCommand.ExecuteReader();
			objSchoolCategoryList = new CoreWebList<SchoolCategoryClass>();
			if (objReader.Read())
			{
				objSchoolCategory = new SchoolCategoryClass();
				objSchoolCategory.iID = int.Parse(objReader["SchoolCategory_ID"].ToString());
				objSchoolCategory.strTitle = objReader["SchoolCategory_Title"].ToString();
				objSchoolCategory.strDesc = objReader["SchoolCategory_Desc"].ToString();
				objSchoolCategory.strPhoto = objReader["SchoolCategory_Photo"].ToString();
				objSchoolCategoryList.Add(objSchoolCategory);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolCategoryList;
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

	public CoreWebList<SchoolCategoryClass> fn_getSchoolCategoryByKeys(string strSchoolCategoryTitle)
	{
		CoreWebList<SchoolCategoryClass> objSchoolCategoryList = null;
		SchoolCategoryClass objSchoolCategory = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolCategory WHERE SchoolCategory_Title like '%' + @SchoolCategory_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@SchoolCategory_Title", strSchoolCategoryTitle);
			objReader = objCommand.ExecuteReader();
			objSchoolCategoryList = new CoreWebList<SchoolCategoryClass>();
			while (objReader.Read())
			{
				objSchoolCategory = new SchoolCategoryClass();
				objSchoolCategory.iID = int.Parse(objReader["SchoolCategory_ID"].ToString());
				objSchoolCategory.strTitle = objReader["SchoolCategory_Title"].ToString();
				objSchoolCategory.strDesc = objReader["SchoolCategory_Desc"].ToString();
				objSchoolCategory.strPhoto = objReader["SchoolCategory_Photo"].ToString();
				objSchoolCategoryList.Add(objSchoolCategory);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolCategoryList;
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
