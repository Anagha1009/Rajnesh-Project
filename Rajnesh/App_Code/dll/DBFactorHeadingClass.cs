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
/// Summary description for DBFactorHeadingClass
/// </summary>
public class DBFactorHeadingClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveFactorHeading(FactorHeadingClass objFactorHeading)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_FactorHeadings (FactorHeading_Title, FactorHeading_Icon) VALUES (@FactorHeading_Title, @FactorHeading_Icon)",objConnection) ;
			objCommand.Parameters.AddWithValue("@FactorHeading_Title", objFactorHeading.strTitle);
			objCommand.Parameters.AddWithValue("@FactorHeading_Icon", objFactorHeading.strIcon);

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

	public string fn_editFactorHeading(FactorHeadingClass objFactorHeading)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_FactorHeadings SET FactorHeading_Title=@FactorHeading_Title, FactorHeading_Icon=@FactorHeading_Icon WHERE FactorHeading_ID=@FactorHeading_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@FactorHeading_ID", objFactorHeading.iID);
			objCommand.Parameters.AddWithValue("@FactorHeading_Title", objFactorHeading.strTitle);
			objCommand.Parameters.AddWithValue("@FactorHeading_Icon", objFactorHeading.strIcon);

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

	public string fn_deleteFactorHeading(int iFactorHeadingID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_FactorHeadings WHERE FactorHeading_ID=@FactorHeading_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@FactorHeading_ID", iFactorHeadingID);

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

	public CoreWebList<FactorHeadingClass> fn_getFactorHeadingList()
	{
		CoreWebList<FactorHeadingClass> objFactorHeadingList = null;
		FactorHeadingClass objFactorHeading = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_FactorHeadings", objConnection);
			objReader = objCommand.ExecuteReader();
			objFactorHeadingList = new CoreWebList<FactorHeadingClass>();
			while (objReader.Read())
			{
				objFactorHeading = new FactorHeadingClass();
				objFactorHeading.iID = int.Parse(objReader["FactorHeading_ID"].ToString());
				objFactorHeading.strTitle = objReader["FactorHeading_Title"].ToString();
				objFactorHeading.strIcon = objReader["FactorHeading_Icon"].ToString();
				objFactorHeadingList.Add(objFactorHeading);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objFactorHeadingList;
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

	public CoreWebList<FactorHeadingClass> fn_getFactorHeadingByID(int iFactorHeadingID)
	{
		CoreWebList<FactorHeadingClass> objFactorHeadingList = null;
		FactorHeadingClass objFactorHeading = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_FactorHeadings WHERE FactorHeading_ID=@FactorHeading_ID", objConnection);
			objCommand.Parameters.AddWithValue("@FactorHeading_ID", iFactorHeadingID);
			objReader = objCommand.ExecuteReader();
			objFactorHeadingList = new CoreWebList<FactorHeadingClass>();
			if (objReader.Read())
			{
				objFactorHeading = new FactorHeadingClass();
				objFactorHeading.iID = int.Parse(objReader["FactorHeading_ID"].ToString());
				objFactorHeading.strTitle = objReader["FactorHeading_Title"].ToString();
				objFactorHeading.strIcon = objReader["FactorHeading_Icon"].ToString();
				objFactorHeadingList.Add(objFactorHeading);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objFactorHeadingList;
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

	public CoreWebList<FactorHeadingClass> fn_getFactorHeadingByName(string strFactorHeadingTitle)
	{
		CoreWebList<FactorHeadingClass> objFactorHeadingList = null;
		FactorHeadingClass objFactorHeading = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_FactorHeadings WHERE FactorHeading_Title=@FactorHeading_Title", objConnection);
			objCommand.Parameters.AddWithValue("@FactorHeading_Title", strFactorHeadingTitle);
			objReader = objCommand.ExecuteReader();
			objFactorHeadingList = new CoreWebList<FactorHeadingClass>();
			if (objReader.Read())
			{
				objFactorHeading = new FactorHeadingClass();
				objFactorHeading.iID = int.Parse(objReader["FactorHeading_ID"].ToString());
				objFactorHeading.strTitle = objReader["FactorHeading_Title"].ToString();
				objFactorHeading.strIcon = objReader["FactorHeading_Icon"].ToString();
				objFactorHeadingList.Add(objFactorHeading);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objFactorHeadingList;
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

	public CoreWebList<FactorHeadingClass> fn_getFactorHeadingByKeys(string strFactorHeadingTitle)
	{
		CoreWebList<FactorHeadingClass> objFactorHeadingList = null;
		FactorHeadingClass objFactorHeading = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_FactorHeadings WHERE FactorHeading_Title like '%' + @FactorHeading_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@FactorHeading_Title", strFactorHeadingTitle);
			objReader = objCommand.ExecuteReader();
			objFactorHeadingList = new CoreWebList<FactorHeadingClass>();
			while (objReader.Read())
			{
				objFactorHeading = new FactorHeadingClass();
				objFactorHeading.iID = int.Parse(objReader["FactorHeading_ID"].ToString());
				objFactorHeading.strTitle = objReader["FactorHeading_Title"].ToString();
				objFactorHeading.strIcon = objReader["FactorHeading_Icon"].ToString();
				objFactorHeadingList.Add(objFactorHeading);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objFactorHeadingList;
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
