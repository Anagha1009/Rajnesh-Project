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
/// Summary description for DBStateClass
/// </summary>
public class DBStateClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveState(StateClass objState)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_States (State_Title, State_Desc) VALUES (@State_Title, @State_Desc)",objConnection) ;
			objCommand.Parameters.AddWithValue("@State_Title", objState.strTitle);
			objCommand.Parameters.AddWithValue("@State_Desc", objState.strDesc);

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

	public string fn_editState(StateClass objState)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_States SET State_Title=@State_Title, State_Desc=@State_Desc WHERE State_ID=@State_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@State_ID", objState.iID);
			objCommand.Parameters.AddWithValue("@State_Title", objState.strTitle);
			objCommand.Parameters.AddWithValue("@State_Desc", objState.strDesc);

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

	public string fn_deleteState(int iStateID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_States WHERE State_ID=@State_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@State_ID", iStateID);

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

	public CoreWebList<StateClass> fn_getStateList()
	{
		CoreWebList<StateClass> objStateList = null;
		StateClass objState = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_States", objConnection);
			objReader = objCommand.ExecuteReader();
			objStateList = new CoreWebList<StateClass>();
			while (objReader.Read())
			{
				objState = new StateClass();
				objState.iID = int.Parse(objReader["State_ID"].ToString());
				objState.strTitle = objReader["State_Title"].ToString();
				objState.strDesc = objReader["State_Desc"].ToString();
				objStateList.Add(objState);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objStateList;
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

	public CoreWebList<StateClass> fn_getStateByID(int iStateID)
	{
		CoreWebList<StateClass> objStateList = null;
		StateClass objState = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_States WHERE State_ID=@State_ID", objConnection);
			objCommand.Parameters.AddWithValue("@State_ID", iStateID);
			objReader = objCommand.ExecuteReader();
			objStateList = new CoreWebList<StateClass>();
			if (objReader.Read())
			{
				objState = new StateClass();
				objState.iID = int.Parse(objReader["State_ID"].ToString());
				objState.strTitle = objReader["State_Title"].ToString();
				objState.strDesc = objReader["State_Desc"].ToString();
				objStateList.Add(objState);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objStateList;
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

	public CoreWebList<StateClass> fn_getStateByName(string strStateTitle)
	{
		CoreWebList<StateClass> objStateList = null;
		StateClass objState = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_States WHERE State_Title=@State_Title", objConnection);
			objCommand.Parameters.AddWithValue("@State_Title", strStateTitle);
			objReader = objCommand.ExecuteReader();
			objStateList = new CoreWebList<StateClass>();
			if (objReader.Read())
			{
				objState = new StateClass();
				objState.iID = int.Parse(objReader["State_ID"].ToString());
				objState.strTitle = objReader["State_Title"].ToString();
				objState.strDesc = objReader["State_Desc"].ToString();
				objStateList.Add(objState);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objStateList;
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

	public CoreWebList<StateClass> fn_getStateByKeys(string strStateTitle)
	{
		CoreWebList<StateClass> objStateList = null;
		StateClass objState = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_States WHERE State_Title like '%' + @State_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@State_Title", strStateTitle);
			objReader = objCommand.ExecuteReader();
			objStateList = new CoreWebList<StateClass>();
			while (objReader.Read())
			{
				objState = new StateClass();
				objState.iID = int.Parse(objReader["State_ID"].ToString());
				objState.strTitle = objReader["State_Title"].ToString();
				objState.strDesc = objReader["State_Desc"].ToString();
				objStateList.Add(objState);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objStateList;
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
