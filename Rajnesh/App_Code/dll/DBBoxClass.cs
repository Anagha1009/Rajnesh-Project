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
/// Summary description for DBBoxClass
/// </summary>
public class DBBoxClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveBox(BoxClass objBox)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_Boxes (Box_PageID, Box_Title, Box_Details, Box_Logo) VALUES (@Box_PageID, @Box_Title, @Box_Details, @Box_Logo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Box_PageID", objBox.iPageID);
			objCommand.Parameters.AddWithValue("@Box_Title", objBox.strTitle);
			objCommand.Parameters.AddWithValue("@Box_Details", objBox.strDetails);
			objCommand.Parameters.AddWithValue("@Box_Logo", objBox.strLogo);

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

	public string fn_editBox(BoxClass objBox)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Boxes SET Box_Title=@Box_Title, Box_Details=@Box_Details, Box_Logo=@Box_Logo WHERE Box_ID=@Box_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Box_ID", objBox.iID);
            objCommand.Parameters.AddWithValue("@Box_Title", objBox.strTitle);
            objCommand.Parameters.AddWithValue("@Box_Details", objBox.strDetails);
            objCommand.Parameters.AddWithValue("@Box_Logo", objBox.strLogo);

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

	public string fn_deleteBox(int iBoxID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Boxes WHERE Box_ID=@Box_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Box_ID", iBoxID);

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

	public CoreWebList<BoxClass> fn_getBoxList()
	{
		CoreWebList<BoxClass> objBoxList = null;
		BoxClass objBox = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Boxes", objConnection);
			objReader = objCommand.ExecuteReader();
			objBoxList = new CoreWebList<BoxClass>();
			while (objReader.Read())
			{
				objBox = new BoxClass();
				objBox.iID = int.Parse(objReader["Box_ID"].ToString());
				objBox.iPageID = int.Parse(objReader["Box_PageID"].ToString());
				objBox.strTitle = objReader["Box_Title"].ToString();
				objBox.strDetails = objReader["Box_Details"].ToString();
				objBox.strLogo = objReader["Box_Logo"].ToString();
				objBoxList.Add(objBox);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBoxList;
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

	public CoreWebList<BoxClass> fn_getBoxByID(int iBoxID)
	{
		CoreWebList<BoxClass> objBoxList = null;
		BoxClass objBox = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Boxes WHERE Box_ID=@Box_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Box_ID", iBoxID);
			objReader = objCommand.ExecuteReader();
			objBoxList = new CoreWebList<BoxClass>();
			if (objReader.Read())
			{
				objBox = new BoxClass();
				objBox.iID = int.Parse(objReader["Box_ID"].ToString());
				objBox.iPageID = int.Parse(objReader["Box_PageID"].ToString());
				objBox.strTitle = objReader["Box_Title"].ToString();
				objBox.strDetails = objReader["Box_Details"].ToString();
				objBox.strLogo = objReader["Box_Logo"].ToString();
				objBoxList.Add(objBox);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBoxList;
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

	public CoreWebList<BoxClass> fn_getBoxByName(string strBoxTitle)
	{
		CoreWebList<BoxClass> objBoxList = null;
		BoxClass objBox = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Boxes WHERE Box_Title=@Box_Title", objConnection);
			objCommand.Parameters.AddWithValue("@Box_Title", strBoxTitle);
			objReader = objCommand.ExecuteReader();
			objBoxList = new CoreWebList<BoxClass>();
			if (objReader.Read())
			{
				objBox = new BoxClass();
				objBox.iID = int.Parse(objReader["Box_ID"].ToString());
				objBox.iPageID = int.Parse(objReader["Box_PageID"].ToString());
				objBox.strTitle = objReader["Box_Title"].ToString();
				objBox.strDetails = objReader["Box_Details"].ToString();
				objBox.strLogo = objReader["Box_Logo"].ToString();
				objBoxList.Add(objBox);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBoxList;
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

	public CoreWebList<BoxClass> fn_getBoxByKeys(string strBoxTitle)
	{
		CoreWebList<BoxClass> objBoxList = null;
		BoxClass objBox = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Boxes WHERE Box_Title like '%' + @Box_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Box_Title", strBoxTitle);
			objReader = objCommand.ExecuteReader();
			objBoxList = new CoreWebList<BoxClass>();
			while (objReader.Read())
			{
				objBox = new BoxClass();
				objBox.iID = int.Parse(objReader["Box_ID"].ToString());
				objBox.iPageID = int.Parse(objReader["Box_PageID"].ToString());
				objBox.strTitle = objReader["Box_Title"].ToString();
				objBox.strDetails = objReader["Box_Details"].ToString();
				objBox.strLogo = objReader["Box_Logo"].ToString();
				objBoxList.Add(objBox);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBoxList;
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

	public CoreWebList<BoxClass> fn_getBoxByPageID(int iPageID)
	{
		CoreWebList<BoxClass> objBoxList = null;
		BoxClass objBox = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Boxes WHERE Box_PageID=@Box_PageID", objConnection);
			objCommand.Parameters.AddWithValue("@Box_PageID", iPageID);
			objReader = objCommand.ExecuteReader();
			objBoxList = new CoreWebList<BoxClass>();
			while (objReader.Read())
			{
				objBox = new BoxClass();
				objBox.iID = int.Parse(objReader["Box_ID"].ToString());
				objBox.iPageID = int.Parse(objReader["Box_PageID"].ToString());
				objBox.strTitle = objReader["Box_Title"].ToString();
				objBox.strDetails = objReader["Box_Details"].ToString();
				objBox.strLogo = objReader["Box_Logo"].ToString();
				objBoxList.Add(objBox);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBoxList;
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
