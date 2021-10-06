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
/// Summary description for DBTeamMemberClass
/// </summary>
public class DBTeamMemberClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveTeamMember(TeamMemberClass objTeamMember)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_TeamMembers (TeamMember_Name, TeamMember_Designation, TeamMember_Details, TeamMember_Facebook, TeamMember_Twitter, TeamMember_LinkedIn, TeamMember_GooglePlus, TeamMember_Photo) VALUES (@TeamMember_Name, @TeamMember_Designation, @TeamMember_Details, @TeamMember_Facebook, @TeamMember_Twitter, @TeamMember_LinkedIn, @TeamMember_GooglePlus, @TeamMember_Photo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@TeamMember_Name", objTeamMember.strName);
			objCommand.Parameters.AddWithValue("@TeamMember_Designation", objTeamMember.strDesignation);
			objCommand.Parameters.AddWithValue("@TeamMember_Details", objTeamMember.strDetails);
			objCommand.Parameters.AddWithValue("@TeamMember_Facebook", objTeamMember.strFacebook);
			objCommand.Parameters.AddWithValue("@TeamMember_Twitter", objTeamMember.strTwitter);
			objCommand.Parameters.AddWithValue("@TeamMember_LinkedIn", objTeamMember.strLinkedIn);
			objCommand.Parameters.AddWithValue("@TeamMember_GooglePlus", objTeamMember.strGooglePlus);
			objCommand.Parameters.AddWithValue("@TeamMember_Photo", objTeamMember.strPhoto);

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

	public string fn_editTeamMember(TeamMemberClass objTeamMember)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_TeamMembers SET TeamMember_Name=@TeamMember_Name, TeamMember_Designation=@TeamMember_Designation, TeamMember_Details=@TeamMember_Details, TeamMember_Facebook=@TeamMember_Facebook, TeamMember_Twitter=@TeamMember_Twitter, TeamMember_LinkedIn=@TeamMember_LinkedIn, TeamMember_GooglePlus=@TeamMember_GooglePlus, TeamMember_Photo=@TeamMember_Photo WHERE TeamMember_ID=@TeamMember_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@TeamMember_ID", objTeamMember.iID);
			objCommand.Parameters.AddWithValue("@TeamMember_Name", objTeamMember.strName);
			objCommand.Parameters.AddWithValue("@TeamMember_Designation", objTeamMember.strDesignation);
			objCommand.Parameters.AddWithValue("@TeamMember_Details", objTeamMember.strDetails);
			objCommand.Parameters.AddWithValue("@TeamMember_Facebook", objTeamMember.strFacebook);
			objCommand.Parameters.AddWithValue("@TeamMember_Twitter", objTeamMember.strTwitter);
			objCommand.Parameters.AddWithValue("@TeamMember_LinkedIn", objTeamMember.strLinkedIn);
			objCommand.Parameters.AddWithValue("@TeamMember_GooglePlus", objTeamMember.strGooglePlus);
			objCommand.Parameters.AddWithValue("@TeamMember_Photo", objTeamMember.strPhoto);

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

	public string fn_deleteTeamMember(int iTeamMemberID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_TeamMembers WHERE TeamMember_ID=@TeamMember_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@TeamMember_ID", iTeamMemberID);

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

	public CoreWebList<TeamMemberClass> fn_getTeamMemberList()
	{
		CoreWebList<TeamMemberClass> objTeamMemberList = null;
		TeamMemberClass objTeamMember = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_TeamMembers", objConnection);
			objReader = objCommand.ExecuteReader();
			objTeamMemberList = new CoreWebList<TeamMemberClass>();
			while (objReader.Read())
			{
				objTeamMember = new TeamMemberClass();
				objTeamMember.iID = int.Parse(objReader["TeamMember_ID"].ToString());
				objTeamMember.strName = objReader["TeamMember_Name"].ToString();
				objTeamMember.strDesignation = objReader["TeamMember_Designation"].ToString();
				objTeamMember.strDetails = objReader["TeamMember_Details"].ToString();
				objTeamMember.strFacebook = objReader["TeamMember_Facebook"].ToString();
				objTeamMember.strTwitter = objReader["TeamMember_Twitter"].ToString();
				objTeamMember.strLinkedIn = objReader["TeamMember_LinkedIn"].ToString();
				objTeamMember.strGooglePlus = objReader["TeamMember_GooglePlus"].ToString();
				objTeamMember.strPhoto = objReader["TeamMember_Photo"].ToString();
				objTeamMemberList.Add(objTeamMember);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objTeamMemberList;
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

	public CoreWebList<TeamMemberClass> fn_getTeamMemberByID(int iTeamMemberID)
	{
		CoreWebList<TeamMemberClass> objTeamMemberList = null;
		TeamMemberClass objTeamMember = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_TeamMembers WHERE TeamMember_ID=@TeamMember_ID", objConnection);
			objCommand.Parameters.AddWithValue("@TeamMember_ID", iTeamMemberID);
			objReader = objCommand.ExecuteReader();
			objTeamMemberList = new CoreWebList<TeamMemberClass>();
			if (objReader.Read())
			{
				objTeamMember = new TeamMemberClass();
				objTeamMember.iID = int.Parse(objReader["TeamMember_ID"].ToString());
				objTeamMember.strName = objReader["TeamMember_Name"].ToString();
				objTeamMember.strDesignation = objReader["TeamMember_Designation"].ToString();
				objTeamMember.strDetails = objReader["TeamMember_Details"].ToString();
				objTeamMember.strFacebook = objReader["TeamMember_Facebook"].ToString();
				objTeamMember.strTwitter = objReader["TeamMember_Twitter"].ToString();
				objTeamMember.strLinkedIn = objReader["TeamMember_LinkedIn"].ToString();
				objTeamMember.strGooglePlus = objReader["TeamMember_GooglePlus"].ToString();
				objTeamMember.strPhoto = objReader["TeamMember_Photo"].ToString();
				objTeamMemberList.Add(objTeamMember);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objTeamMemberList;
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

	public CoreWebList<TeamMemberClass> fn_getTeamMemberByName(string strTeamMemberName)
	{
		CoreWebList<TeamMemberClass> objTeamMemberList = null;
		TeamMemberClass objTeamMember = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_TeamMembers WHERE TeamMember_Name=@TeamMember_Name", objConnection);
			objCommand.Parameters.AddWithValue("@TeamMember_Name", strTeamMemberName);
			objReader = objCommand.ExecuteReader();
			objTeamMemberList = new CoreWebList<TeamMemberClass>();
			if (objReader.Read())
			{
				objTeamMember = new TeamMemberClass();
				objTeamMember.iID = int.Parse(objReader["TeamMember_ID"].ToString());
				objTeamMember.strName = objReader["TeamMember_Name"].ToString();
				objTeamMember.strDesignation = objReader["TeamMember_Designation"].ToString();
				objTeamMember.strDetails = objReader["TeamMember_Details"].ToString();
				objTeamMember.strFacebook = objReader["TeamMember_Facebook"].ToString();
				objTeamMember.strTwitter = objReader["TeamMember_Twitter"].ToString();
				objTeamMember.strLinkedIn = objReader["TeamMember_LinkedIn"].ToString();
				objTeamMember.strGooglePlus = objReader["TeamMember_GooglePlus"].ToString();
				objTeamMember.strPhoto = objReader["TeamMember_Photo"].ToString();
				objTeamMemberList.Add(objTeamMember);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objTeamMemberList;
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

	public CoreWebList<TeamMemberClass> fn_getTeamMemberByKeys(string strTeamMemberName)
	{
		CoreWebList<TeamMemberClass> objTeamMemberList = null;
		TeamMemberClass objTeamMember = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_TeamMembers WHERE TeamMember_Name like '%' + @TeamMember_Name + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@TeamMember_Name", strTeamMemberName);
			objReader = objCommand.ExecuteReader();
			objTeamMemberList = new CoreWebList<TeamMemberClass>();
			while (objReader.Read())
			{
				objTeamMember = new TeamMemberClass();
				objTeamMember.iID = int.Parse(objReader["TeamMember_ID"].ToString());
				objTeamMember.strName = objReader["TeamMember_Name"].ToString();
				objTeamMember.strDesignation = objReader["TeamMember_Designation"].ToString();
				objTeamMember.strDetails = objReader["TeamMember_Details"].ToString();
				objTeamMember.strFacebook = objReader["TeamMember_Facebook"].ToString();
				objTeamMember.strTwitter = objReader["TeamMember_Twitter"].ToString();
				objTeamMember.strLinkedIn = objReader["TeamMember_LinkedIn"].ToString();
				objTeamMember.strGooglePlus = objReader["TeamMember_GooglePlus"].ToString();
				objTeamMember.strPhoto = objReader["TeamMember_Photo"].ToString();
				objTeamMemberList.Add(objTeamMember);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objTeamMemberList;
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
