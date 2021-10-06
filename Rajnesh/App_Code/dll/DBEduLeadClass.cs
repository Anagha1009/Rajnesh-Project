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
/// Summary description for DBEduLeadClass
/// </summary>
public class DBEduLeadClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveEduLead(EduLeadClass objEduLead)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_EducationLeads (EduLead_CurrentQualificationID, EduLead_EducationInterestID, EduLead_CityID, EduLead_Type, EduLead_TypeId, EduLead_FirstName, EduLead_LastName, EduLead_Email, EduLead_DoB, EduLead_MobileNo, EduLead_Comment, EduLead_EducationLoan, EduLead_IpAddrs, EduLead_RegDate) VALUES (@EduLead_CurrentQualificationID, @EduLead_EducationInterestID, @EduLead_CityID, @EduLead_Type, @EduLead_TypeId, @EduLead_FirstName, @EduLead_LastName, @EduLead_Email, @EduLead_DoB, @EduLead_MobileNo, @EduLead_Comment, @EduLead_EducationLoan, @EduLead_IpAddrs, @EduLead_RegDate)", objConnection);
			objCommand.Parameters.AddWithValue("@EduLead_CurrentQualificationID", objEduLead.iCurrentQualificationID);
			objCommand.Parameters.AddWithValue("@EduLead_EducationInterestID", objEduLead.iEducationInterestID);
            objCommand.Parameters.AddWithValue("@EduLead_CityID", objEduLead.iCityID);
			objCommand.Parameters.AddWithValue("@EduLead_Type", objEduLead.strType);
			objCommand.Parameters.AddWithValue("@EduLead_TypeId", objEduLead.iTypeId);
			objCommand.Parameters.AddWithValue("@EduLead_FirstName", objEduLead.strFirstName);
			objCommand.Parameters.AddWithValue("@EduLead_LastName", objEduLead.strLastName);
			objCommand.Parameters.AddWithValue("@EduLead_Email", objEduLead.strEmail);
			objCommand.Parameters.AddWithValue("@EduLead_DoB", objEduLead.dtDoB);
			objCommand.Parameters.AddWithValue("@EduLead_MobileNo", objEduLead.strMobileNo);
			objCommand.Parameters.AddWithValue("@EduLead_Comment", objEduLead.strComment);
			objCommand.Parameters.AddWithValue("@EduLead_EducationLoan", objEduLead.bEducationLoan);
			objCommand.Parameters.AddWithValue("@EduLead_IpAddrs", objEduLead.strIpAddrs);
			objCommand.Parameters.AddWithValue("@EduLead_RegDate", objEduLead.dtRegDate);

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

	public string fn_deleteEduLead(int iEduLeadID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_EducationLeads WHERE EduLead_ID=@EduLead_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@EduLead_ID", iEduLeadID);

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

	public CoreWebList<EduLeadClass> fn_getEduLeadList()
	{
		CoreWebList<EduLeadClass> objEduLeadList = null;
		EduLeadClass objEduLead = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("usp_GetEducationLeadList", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;
			objReader = objCommand.ExecuteReader();
			objEduLeadList = new CoreWebList<EduLeadClass>();
			while (objReader.Read())
			{
                objEduLead = new EduLeadClass();
                objEduLead.iID = int.Parse(objReader["EduLead_ID"].ToString());
                objEduLead.iCurrentQualificationID = int.Parse(objReader["EduLead_CurrentQualificationID"].ToString());
                objEduLead.iEducationInterestID = int.Parse(objReader["EduLead_EducationInterestID"].ToString());
                objEduLead.strCurrentQualification = objReader["Qualification_Title"].ToString();
                objEduLead.strEducationInterest = objReader["EducationInterest_Title"].ToString();
                objEduLead.strCity = objReader["City_Title"].ToString();
                objEduLead.strType = objReader["EduLead_Type"].ToString();
                objEduLead.strInstitutionName = objReader["Institution_Name"].ToString();
                objEduLead.iTypeId = int.Parse(objReader["EduLead_TypeId"].ToString());
                objEduLead.strFirstName = objReader["EduLead_FirstName"].ToString();
                objEduLead.strLastName = objReader["EduLead_LastName"].ToString();
                objEduLead.strFullName = objReader["EduLead_FirstName"].ToString() + " " + objReader["EduLead_LastName"].ToString();
                objEduLead.strEmail = objReader["EduLead_Email"].ToString();
                objEduLead.dtDoB = DateTime.Parse(objReader["EduLead_DoB"].ToString());
                objEduLead.strMobileNo = objReader["EduLead_MobileNo"].ToString();
                objEduLead.strComment = objReader["EduLead_Comment"].ToString();
                objEduLead.bEducationLoan = bool.Parse(objReader["EduLead_EducationLoan"].ToString());
                objEduLead.strIpAddrs = objReader["EduLead_IpAddrs"].ToString();
                objEduLead.dtRegDate = DateTime.Parse(objReader["EduLead_RegDate"].ToString());
                objEduLeadList.Add(objEduLead);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEduLeadList;
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

    public CoreWebList<EduLeadClass> fn_getEduLeadLinks()
    {
        CoreWebList<EduLeadClass> objEduLeadList = null;
        EduLeadClass objEduLead = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_EducationLeads WHERE EduLead_Type like '%eduvidya.com%' AND EduLead_TypeId=0 ORDER BY EduLead_RegDate DESC", objConnection);
            objReader = objCommand.ExecuteReader();
            objEduLeadList = new CoreWebList<EduLeadClass>();
            while (objReader.Read())
            {
                objEduLead = new EduLeadClass();
                objEduLead.iID = int.Parse(objReader["EduLead_ID"].ToString());
                objEduLead.strType = objReader["EduLead_Type"].ToString();
                objEduLeadList.Add(objEduLead);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objEduLeadList;
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

	public CoreWebList<EduLeadClass> fn_getEduLeadByID(int iEduLeadID)
	{
		CoreWebList<EduLeadClass> objEduLeadList = null;
		EduLeadClass objEduLead = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("usp_GetEducationLeadById", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@EducationLeadId", iEduLeadID);
			objReader = objCommand.ExecuteReader();
			objEduLeadList = new CoreWebList<EduLeadClass>();
			if (objReader.Read())
			{
				objEduLead = new EduLeadClass();
				objEduLead.iID = int.Parse(objReader["EduLead_ID"].ToString());
				objEduLead.iCurrentQualificationID = int.Parse(objReader["EduLead_CurrentQualificationID"].ToString());
				objEduLead.iEducationInterestID = int.Parse(objReader["EduLead_EducationInterestID"].ToString());
                objEduLead.strCurrentQualification = objReader["Qualification_Title"].ToString();
                objEduLead.strEducationInterest = objReader["EducationInterest_Title"].ToString();
                objEduLead.strCity = objReader["City_Title"].ToString();
                objEduLead.strType = objReader["EduLead_Type"].ToString();
                objEduLead.strInstitutionName = objReader["Institution_Name"].ToString();
				objEduLead.iTypeId = int.Parse(objReader["EduLead_TypeId"].ToString());
				objEduLead.strFirstName = objReader["EduLead_FirstName"].ToString();
				objEduLead.strLastName = objReader["EduLead_LastName"].ToString();
				objEduLead.strEmail = objReader["EduLead_Email"].ToString();
				objEduLead.dtDoB = DateTime.Parse(objReader["EduLead_DoB"].ToString());
				objEduLead.strMobileNo = objReader["EduLead_MobileNo"].ToString();
				objEduLead.strComment = objReader["EduLead_Comment"].ToString();
				objEduLead.bEducationLoan = bool.Parse(objReader["EduLead_EducationLoan"].ToString());
				objEduLead.strIpAddrs = objReader["EduLead_IpAddrs"].ToString();
				objEduLead.dtRegDate = DateTime.Parse(objReader["EduLead_RegDate"].ToString());
				objEduLeadList.Add(objEduLead);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEduLeadList;
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

    public CoreWebList<EduLeadClass> fn_SearchEducationLeads(EduLeadClass objLeads)
    {
        CoreWebList<EduLeadClass> objEduLeadList = null;
        EduLeadClass objEduLead = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("usp_SearchEducationLeads", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Type", objLeads.strType);
            objCommand.Parameters.AddWithValue("@TypeId", objLeads.iTypeId);
            objCommand.Parameters.AddWithValue("@EducationInterestId", objLeads.iEducationInterestID);
            objCommand.Parameters.AddWithValue("@CityId", objLeads.iCityID);
            objCommand.Parameters.AddWithValue("@FromDate", objLeads.strFromDate);
            objCommand.Parameters.AddWithValue("@ToDate", objLeads.strToDate);
            objCommand.Parameters.AddWithValue("@Keys", objLeads.strKeys);
            objReader = objCommand.ExecuteReader();
            objEduLeadList = new CoreWebList<EduLeadClass>();
            while (objReader.Read())
            {
                objEduLead = new EduLeadClass();
                objEduLead.iID = int.Parse(objReader["EduLead_ID"].ToString());
                objEduLead.iCurrentQualificationID = int.Parse(objReader["EduLead_CurrentQualificationID"].ToString());
                objEduLead.iEducationInterestID = int.Parse(objReader["EduLead_EducationInterestID"].ToString());
                objEduLead.strCurrentQualification = objReader["Qualification_Title"].ToString();
                objEduLead.strEducationInterest = objReader["EducationInterest_Title"].ToString();
                objEduLead.strCity = objReader["City_Title"].ToString();
                objEduLead.strType = objReader["EduLead_Type"].ToString();
                objEduLead.strInstitutionName = objReader["Institution_Name"].ToString();
                objEduLead.iTypeId = int.Parse(objReader["EduLead_TypeId"].ToString());
                objEduLead.strFirstName = objReader["EduLead_FirstName"].ToString();
                objEduLead.strLastName = objReader["EduLead_LastName"].ToString();
                objEduLead.strFullName = objReader["EduLead_FirstName"].ToString() + " " + objReader["EduLead_LastName"].ToString();
                objEduLead.strEmail = objReader["EduLead_Email"].ToString();
                objEduLead.dtDoB = DateTime.Parse(objReader["EduLead_DoB"].ToString());
                objEduLead.strMobileNo = objReader["EduLead_MobileNo"].ToString();
                objEduLead.strComment = objReader["EduLead_Comment"].ToString();
                objEduLead.bEducationLoan = bool.Parse(objReader["EduLead_EducationLoan"].ToString());
                objEduLead.strIpAddrs = objReader["EduLead_IpAddrs"].ToString();
                objEduLead.dtRegDate = DateTime.Parse(objReader["EduLead_RegDate"].ToString());
                objEduLeadList.Add(objEduLead);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objEduLeadList;
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

	public CoreWebList<EduLeadClass> fn_getEduLeadByName(string strEduLeadFirstName)
	{
		CoreWebList<EduLeadClass> objEduLeadList = null;
		EduLeadClass objEduLead = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EducationLeads WHERE EduLead_FirstName=@EduLead_FirstName", objConnection);
			objCommand.Parameters.AddWithValue("@EduLead_FirstName", strEduLeadFirstName);
			objReader = objCommand.ExecuteReader();
			objEduLeadList = new CoreWebList<EduLeadClass>();
			if (objReader.Read())
			{
				objEduLead = new EduLeadClass();
				objEduLead.iID = int.Parse(objReader["EduLead_ID"].ToString());
				objEduLead.iCurrentQualificationID = int.Parse(objReader["EduLead_CurrentQualificationID"].ToString());
				objEduLead.iEducationInterestID = int.Parse(objReader["EduLead_EducationInterestID"].ToString());
				objEduLead.strType = objReader["EduLead_Type"].ToString();
				objEduLead.iTypeId = int.Parse(objReader["EduLead_TypeId"].ToString());
				objEduLead.strFirstName = objReader["EduLead_FirstName"].ToString();
				objEduLead.strLastName = objReader["EduLead_LastName"].ToString();
				objEduLead.strEmail = objReader["EduLead_Email"].ToString();
				objEduLead.dtDoB = DateTime.Parse(objReader["EduLead_DoB"].ToString());
				objEduLead.strMobileNo = objReader["EduLead_MobileNo"].ToString();
				objEduLead.strComment = objReader["EduLead_Comment"].ToString();
				objEduLead.bEducationLoan = bool.Parse(objReader["EduLead_EducationLoan"].ToString());
				objEduLead.strIpAddrs = objReader["EduLead_IpAddrs"].ToString();
				objEduLead.dtRegDate = DateTime.Parse(objReader["EduLead_RegDate"].ToString());
				objEduLeadList.Add(objEduLead);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEduLeadList;
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

	public CoreWebList<EduLeadClass> fn_getEduLeadByKeys(string strEduLeadFirstName)
	{
		CoreWebList<EduLeadClass> objEduLeadList = null;
		EduLeadClass objEduLead = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EducationLeads WHERE EduLead_FirstName like '%' + @EduLead_FirstName + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@EduLead_FirstName", strEduLeadFirstName);
			objReader = objCommand.ExecuteReader();
			objEduLeadList = new CoreWebList<EduLeadClass>();
			while (objReader.Read())
			{
				objEduLead = new EduLeadClass();
				objEduLead.iID = int.Parse(objReader["EduLead_ID"].ToString());
				objEduLead.iCurrentQualificationID = int.Parse(objReader["EduLead_CurrentQualificationID"].ToString());
				objEduLead.iEducationInterestID = int.Parse(objReader["EduLead_EducationInterestID"].ToString());
				objEduLead.strType = objReader["EduLead_Type"].ToString();
				objEduLead.iTypeId = int.Parse(objReader["EduLead_TypeId"].ToString());
				objEduLead.strFirstName = objReader["EduLead_FirstName"].ToString();
				objEduLead.strLastName = objReader["EduLead_LastName"].ToString();
				objEduLead.strEmail = objReader["EduLead_Email"].ToString();
				objEduLead.dtDoB = DateTime.Parse(objReader["EduLead_DoB"].ToString());
				objEduLead.strMobileNo = objReader["EduLead_MobileNo"].ToString();
				objEduLead.strComment = objReader["EduLead_Comment"].ToString();
				objEduLead.bEducationLoan = bool.Parse(objReader["EduLead_EducationLoan"].ToString());
				objEduLead.strIpAddrs = objReader["EduLead_IpAddrs"].ToString();
				objEduLead.dtRegDate = DateTime.Parse(objReader["EduLead_RegDate"].ToString());
				objEduLeadList.Add(objEduLead);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEduLeadList;
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

	public CoreWebList<EduLeadClass> fn_getEduLeadByEducationInterestID(int iEducationInterestID)
	{
		CoreWebList<EduLeadClass> objEduLeadList = null;
		EduLeadClass objEduLead = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EducationLeads WHERE EduLead_EducationInterestID=@EduLead_EducationInterestID", objConnection);
			objCommand.Parameters.AddWithValue("@EduLead_EducationInterestID", iEducationInterestID);
			objReader = objCommand.ExecuteReader();
			objEduLeadList = new CoreWebList<EduLeadClass>();
			while (objReader.Read())
			{
				objEduLead = new EduLeadClass();
				objEduLead.iID = int.Parse(objReader["EduLead_ID"].ToString());
				objEduLead.iCurrentQualificationID = int.Parse(objReader["EduLead_CurrentQualificationID"].ToString());
				objEduLead.iEducationInterestID = int.Parse(objReader["EduLead_EducationInterestID"].ToString());
				objEduLead.strType = objReader["EduLead_Type"].ToString();
				objEduLead.iTypeId = int.Parse(objReader["EduLead_TypeId"].ToString());
				objEduLead.strFirstName = objReader["EduLead_FirstName"].ToString();
				objEduLead.strLastName = objReader["EduLead_LastName"].ToString();
				objEduLead.strEmail = objReader["EduLead_Email"].ToString();
				objEduLead.dtDoB = DateTime.Parse(objReader["EduLead_DoB"].ToString());
				objEduLead.strMobileNo = objReader["EduLead_MobileNo"].ToString();
				objEduLead.strComment = objReader["EduLead_Comment"].ToString();
				objEduLead.bEducationLoan = bool.Parse(objReader["EduLead_EducationLoan"].ToString());
				objEduLead.strIpAddrs = objReader["EduLead_IpAddrs"].ToString();
				objEduLead.dtRegDate = DateTime.Parse(objReader["EduLead_RegDate"].ToString());
				objEduLeadList.Add(objEduLead);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEduLeadList;
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

	public CoreWebList<EduLeadClass> fn_getEduLeadByCurrentQualificationID(int iCurrentQualificationID)
	{
		CoreWebList<EduLeadClass> objEduLeadList = null;
		EduLeadClass objEduLead = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EducationLeads WHERE EduLead_CurrentQualificationID=@EduLead_CurrentQualificationID", objConnection);
			objCommand.Parameters.AddWithValue("@EduLead_CurrentQualificationID", iCurrentQualificationID);
			objReader = objCommand.ExecuteReader();
			objEduLeadList = new CoreWebList<EduLeadClass>();
			while (objReader.Read())
			{
				objEduLead = new EduLeadClass();
				objEduLead.iID = int.Parse(objReader["EduLead_ID"].ToString());
				objEduLead.iCurrentQualificationID = int.Parse(objReader["EduLead_CurrentQualificationID"].ToString());
				objEduLead.iEducationInterestID = int.Parse(objReader["EduLead_EducationInterestID"].ToString());
				objEduLead.strType = objReader["EduLead_Type"].ToString();
				objEduLead.iTypeId = int.Parse(objReader["EduLead_TypeId"].ToString());
				objEduLead.strFirstName = objReader["EduLead_FirstName"].ToString();
				objEduLead.strLastName = objReader["EduLead_LastName"].ToString();
				objEduLead.strEmail = objReader["EduLead_Email"].ToString();
				objEduLead.dtDoB = DateTime.Parse(objReader["EduLead_DoB"].ToString());
				objEduLead.strMobileNo = objReader["EduLead_MobileNo"].ToString();
				objEduLead.strComment = objReader["EduLead_Comment"].ToString();
				objEduLead.bEducationLoan = bool.Parse(objReader["EduLead_EducationLoan"].ToString());
				objEduLead.strIpAddrs = objReader["EduLead_IpAddrs"].ToString();
				objEduLead.dtRegDate = DateTime.Parse(objReader["EduLead_RegDate"].ToString());
				objEduLeadList.Add(objEduLead);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEduLeadList;
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

	public string fn_ChangeEduLeadEducationLoanStatus(EduLeadClass objEduLead)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_EducationLeads SET EduLead_EducationLoan=@EduLead_EducationLoan WHERE EduLead_ID=@EduLead_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("EduLead_ID", objEduLead.iID);
			objCommand.Parameters.AddWithValue("EduLead_EducationLoan", objEduLead.bEducationLoan);

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

}
