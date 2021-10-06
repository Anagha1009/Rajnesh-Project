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
/// Summary description for DBQualificationClass
/// </summary>
public class DBQualificationClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveQualification(QualificationClass objQualification)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_Qualifications (Qualification_Title) VALUES (@Qualification_Title)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Qualification_Title", objQualification.strTitle);

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

	public string fn_editQualification(QualificationClass objQualification)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Qualifications SET Qualification_Title=@Qualification_Title WHERE Qualification_ID=@Qualification_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Qualification_ID", objQualification.iID);
			objCommand.Parameters.AddWithValue("@Qualification_Title", objQualification.strTitle);

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

	public string fn_deleteQualification(int iQualificationID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Qualifications WHERE Qualification_ID=@Qualification_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Qualification_ID", iQualificationID);

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

	public CoreWebList<QualificationClass> fn_getQualificationList()
	{
		CoreWebList<QualificationClass> objQualificationList = null;
		QualificationClass objQualification = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Qualifications", objConnection);
			objReader = objCommand.ExecuteReader();
			objQualificationList = new CoreWebList<QualificationClass>();
			while (objReader.Read())
			{
				objQualification = new QualificationClass();
				objQualification.iID = int.Parse(objReader["Qualification_ID"].ToString());
				objQualification.strTitle = objReader["Qualification_Title"].ToString();
				objQualificationList.Add(objQualification);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objQualificationList;
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

	public CoreWebList<QualificationClass> fn_getQualificationByID(int iQualificationID)
	{
		CoreWebList<QualificationClass> objQualificationList = null;
		QualificationClass objQualification = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Qualifications WHERE Qualification_ID=@Qualification_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Qualification_ID", iQualificationID);
			objReader = objCommand.ExecuteReader();
			objQualificationList = new CoreWebList<QualificationClass>();
			if (objReader.Read())
			{
				objQualification = new QualificationClass();
				objQualification.iID = int.Parse(objReader["Qualification_ID"].ToString());
				objQualification.strTitle = objReader["Qualification_Title"].ToString();
				objQualificationList.Add(objQualification);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objQualificationList;
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

	public CoreWebList<QualificationClass> fn_getQualificationByName(string strQualificationTitle)
	{
		CoreWebList<QualificationClass> objQualificationList = null;
		QualificationClass objQualification = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Qualifications WHERE Qualification_Title=@Qualification_Title", objConnection);
			objCommand.Parameters.AddWithValue("@Qualification_Title", strQualificationTitle);
			objReader = objCommand.ExecuteReader();
			objQualificationList = new CoreWebList<QualificationClass>();
			if (objReader.Read())
			{
				objQualification = new QualificationClass();
				objQualification.iID = int.Parse(objReader["Qualification_ID"].ToString());
				objQualification.strTitle = objReader["Qualification_Title"].ToString();
				objQualificationList.Add(objQualification);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objQualificationList;
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

	public CoreWebList<QualificationClass> fn_getQualificationByKeys(string strQualificationTitle)
	{
		CoreWebList<QualificationClass> objQualificationList = null;
		QualificationClass objQualification = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Qualifications WHERE Qualification_Title like '%' + @Qualification_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Qualification_Title", strQualificationTitle);
			objReader = objCommand.ExecuteReader();
			objQualificationList = new CoreWebList<QualificationClass>();
			while (objReader.Read())
			{
				objQualification = new QualificationClass();
				objQualification.iID = int.Parse(objReader["Qualification_ID"].ToString());
				objQualification.strTitle = objReader["Qualification_Title"].ToString();
				objQualificationList.Add(objQualification);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objQualificationList;
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
