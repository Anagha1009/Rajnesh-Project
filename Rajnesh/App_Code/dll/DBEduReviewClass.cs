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
/// Summary description for DBEduReviewClass
/// </summary>
public class DBEduReviewClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public int fn_saveEduReview(EduReviewClass objEduReview)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_EduReviews (EduReview_InstitutionType, EduReview_InstitutionID, EduReview_UserType, EduReview_Title, EduReview_Details, EduReview_IpAddrs, EduReview_Date) VALUES (@EduReview_InstitutionType, @EduReview_InstitutionID, @EduReview_UserType, @EduReview_Title, @EduReview_Details, @EduReview_IpAddrs, @EduReview_Date);SELECT @PK_New = @@IDENTITY", objConnection);

            SqlParameter insertedKey = new SqlParameter("@PK_New", SqlDbType.Int);
            insertedKey.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(insertedKey);

			objCommand.Parameters.AddWithValue("@EduReview_InstitutionType", objEduReview.strInstitutionType);
			objCommand.Parameters.AddWithValue("@EduReview_InstitutionID", objEduReview.iInstitutionID);
			objCommand.Parameters.AddWithValue("@EduReview_UserType", objEduReview.strUserType);
			objCommand.Parameters.AddWithValue("@EduReview_Name", objEduReview.strName);
			objCommand.Parameters.AddWithValue("@EduReview_Email", objEduReview.strEmail);
			objCommand.Parameters.AddWithValue("@EduReview_MobileNo", objEduReview.strMobileNo);
			objCommand.Parameters.AddWithValue("@EduReview_Title", objEduReview.strTitle);
			objCommand.Parameters.AddWithValue("@EduReview_Details", objEduReview.strDetails);
			objCommand.Parameters.AddWithValue("@EduReview_IpAddrs", objEduReview.strIpAddrs);
			objCommand.Parameters.AddWithValue("@EduReview_Date", objEduReview.dtDate);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                int iUserID = int.Parse(objCommand.Parameters["@PK_New"].Value.ToString());
                return iUserID;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

	public string fn_editEduReview(EduReviewClass objEduReview)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_EduReviews SET EduReview_Name=@EduReview_Name, EduReview_Email=@EduReview_Email, EduReview_MobileNo=@EduReview_MobileNo WHERE EduReview_ID=@EduReview_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@EduReview_ID", objEduReview.iID);
			objCommand.Parameters.AddWithValue("@EduReview_Name", objEduReview.strName);
			objCommand.Parameters.AddWithValue("@EduReview_Email", objEduReview.strEmail);
			objCommand.Parameters.AddWithValue("@EduReview_MobileNo", objEduReview.strMobileNo);

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

    public string fn_ChangeReviewActiveStatus(EduReviewClass objEduReview)
    {
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_EduReviews SET EduReview_Active=@EduReview_Active WHERE EduReview_ID=@EduReview_ID", objConnection);
            objCommand.Parameters.AddWithValue("@EduReview_ID", objEduReview.iID);
            objCommand.Parameters.AddWithValue("@EduReview_Active", objEduReview.bActive);

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

	public string fn_deleteEduReview(int iEduReviewID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_EduReviews WHERE EduReview_ID=@EduReview_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@EduReview_ID", iEduReviewID);

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

	public CoreWebList<EduReviewClass> fn_getEduReviewList()
	{
		CoreWebList<EduReviewClass> objEduReviewList = null;
		EduReviewClass objEduReview = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_EduReviews ORDER BY EduReview_Date DESC", objConnection);
			objReader = objCommand.ExecuteReader();
			objEduReviewList = new CoreWebList<EduReviewClass>();
			while (objReader.Read())
			{
				objEduReview = new EduReviewClass();
				objEduReview.iID = int.Parse(objReader["EduReview_ID"].ToString());
				objEduReview.strInstitutionType = objReader["EduReview_InstitutionType"].ToString();
				objEduReview.iInstitutionID = int.Parse(objReader["EduReview_InstitutionID"].ToString());
				objEduReview.strUserType = objReader["EduReview_UserType"].ToString();
				objEduReview.strName = objReader["EduReview_Name"].ToString();
				objEduReview.strEmail = objReader["EduReview_Email"].ToString();
				objEduReview.strMobileNo = objReader["EduReview_MobileNo"].ToString();
				objEduReview.strTitle = objReader["EduReview_Title"].ToString();
				objEduReview.strDetails = objReader["EduReview_Details"].ToString();
                objEduReview.bActive = bool.Parse(objReader["EduReview_Active"].ToString());
				objEduReview.strIpAddrs = objReader["EduReview_IpAddrs"].ToString();
				objEduReview.dtDate = DateTime.Parse(objReader["EduReview_Date"].ToString());
				objEduReviewList.Add(objEduReview);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEduReviewList;
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

	public CoreWebList<EduReviewClass> fn_getEduReviewByID(int iEduReviewID)
	{
		CoreWebList<EduReviewClass> objEduReviewList = null;
		EduReviewClass objEduReview = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT* FROM tbl_EduReviews WHERE EduReview_ID=@EduReview_ID", objConnection);
			objCommand.Parameters.AddWithValue("@EduReview_ID", iEduReviewID);
			objReader = objCommand.ExecuteReader();
			objEduReviewList = new CoreWebList<EduReviewClass>();
			if (objReader.Read())
			{
				objEduReview = new EduReviewClass();
				objEduReview.iID = int.Parse(objReader["EduReview_ID"].ToString());
				objEduReview.strInstitutionType = objReader["EduReview_InstitutionType"].ToString();
				objEduReview.iInstitutionID = int.Parse(objReader["EduReview_InstitutionID"].ToString());
                objEduReview.strUserType = objReader["EduReview_UserType"].ToString();
				objEduReview.strName = objReader["EduReview_Name"].ToString();
				objEduReview.strEmail = objReader["EduReview_Email"].ToString();
				objEduReview.strMobileNo = objReader["EduReview_MobileNo"].ToString();
				objEduReview.strTitle = objReader["EduReview_Title"].ToString();
				objEduReview.strDetails = objReader["EduReview_Details"].ToString();
                objEduReview.bActive = bool.Parse(objReader["EduReview_Active"].ToString());
				objEduReview.strIpAddrs = objReader["EduReview_IpAddrs"].ToString();
				objEduReview.dtDate = DateTime.Parse(objReader["EduReview_Date"].ToString());
				objEduReviewList.Add(objEduReview);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEduReviewList;
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

	public CoreWebList<EduReviewClass> fn_getEduReviewByName(string strEduReviewTitle)
	{
		CoreWebList<EduReviewClass> objEduReviewList = null;
		EduReviewClass objEduReview = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EduReviews WHERE EduReview_Title=@EduReview_Title", objConnection);
			objCommand.Parameters.AddWithValue("@EduReview_Title", strEduReviewTitle);
			objReader = objCommand.ExecuteReader();
			objEduReviewList = new CoreWebList<EduReviewClass>();
			if (objReader.Read())
			{
				objEduReview = new EduReviewClass();
				objEduReview.iID = int.Parse(objReader["EduReview_ID"].ToString());
				objEduReview.strInstitutionType = objReader["EduReview_InstitutionType"].ToString();
				objEduReview.iInstitutionID = int.Parse(objReader["EduReview_InstitutionID"].ToString());
				objEduReview.strUserType = objReader["EduReview_UserType"].ToString();
				objEduReview.strName = objReader["EduReview_Name"].ToString();
				objEduReview.strEmail = objReader["EduReview_Email"].ToString();
				objEduReview.strMobileNo = objReader["EduReview_MobileNo"].ToString();
				objEduReview.strTitle = objReader["EduReview_Title"].ToString();
				objEduReview.strDetails = objReader["EduReview_Details"].ToString();
                objEduReview.bActive = bool.Parse(objReader["EduReview_Active"].ToString());
				objEduReview.strIpAddrs = objReader["EduReview_IpAddrs"].ToString();
				objEduReview.dtDate = DateTime.Parse(objReader["EduReview_Date"].ToString());
				objEduReviewList.Add(objEduReview);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEduReviewList;
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

    public CoreWebList<EduReviewClass> fn_getEduReviewByKeys(string strTitle)
    {
        CoreWebList<EduReviewClass> objEduReviewList = null;
        EduReviewClass objEduReview = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_EduReviews WHERE EduReview_Title like '%' + @EduReview_Title + '%'", objConnection);
            objCommand.Parameters.AddWithValue("@EduReview_Title", strTitle);
            objReader = objCommand.ExecuteReader();
            objEduReviewList = new CoreWebList<EduReviewClass>();
            while (objReader.Read())
            {
                objEduReview = new EduReviewClass();
                objEduReview.iID = int.Parse(objReader["EduReview_ID"].ToString());
                objEduReview.strInstitutionType = objReader["EduReview_InstitutionType"].ToString();
                objEduReview.iInstitutionID = int.Parse(objReader["EduReview_InstitutionID"].ToString());
                objEduReview.strUserType = objReader["EduReview_UserType"].ToString();
                objEduReview.strName = objReader["EduReview_Name"].ToString();
                objEduReview.strEmail = objReader["EduReview_Email"].ToString();
                objEduReview.strMobileNo = objReader["EduReview_MobileNo"].ToString();
                objEduReview.strTitle = objReader["EduReview_Title"].ToString();
                objEduReview.strDetails = objReader["EduReview_Details"].ToString();
                objEduReview.bActive = bool.Parse(objReader["EduReview_Active"].ToString());
                objEduReview.strIpAddrs = objReader["EduReview_IpAddrs"].ToString();
                objEduReview.dtDate = DateTime.Parse(objReader["EduReview_Date"].ToString());
                objEduReviewList.Add(objEduReview);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objEduReviewList;
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

	public CoreWebList<EduReviewClass> fn_getEduReviewByTypeKeys(string strInstitutionType, string strTitle)
	{
		CoreWebList<EduReviewClass> objEduReviewList = null;
		EduReviewClass objEduReview = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_EduReviews WHERE EduReview_InstitutionType=@EduReview_InstitutionType AND EduReview_Title like '%' + @EduReview_Title + '%' AND EduReview_Active='true' ORDER BY EduReview_Date DESC", objConnection);
            objCommand.Parameters.AddWithValue("@EduReview_InstitutionType", strInstitutionType);
            objCommand.Parameters.AddWithValue("@EduReview_Title", strTitle);
			objReader = objCommand.ExecuteReader();
			objEduReviewList = new CoreWebList<EduReviewClass>();
			while (objReader.Read())
			{
				objEduReview = new EduReviewClass();
				objEduReview.iID = int.Parse(objReader["EduReview_ID"].ToString());
				objEduReview.strInstitutionType = objReader["EduReview_InstitutionType"].ToString();
				objEduReview.iInstitutionID = int.Parse(objReader["EduReview_InstitutionID"].ToString());
				objEduReview.strUserType = objReader["EduReview_UserType"].ToString();
				objEduReview.strName = objReader["EduReview_Name"].ToString();
				objEduReview.strEmail = objReader["EduReview_Email"].ToString();
				objEduReview.strMobileNo = objReader["EduReview_MobileNo"].ToString();
				objEduReview.strTitle = objReader["EduReview_Title"].ToString();
				objEduReview.strDetails = objReader["EduReview_Details"].ToString();
                objEduReview.bActive = bool.Parse(objReader["EduReview_Active"].ToString());
				objEduReview.strIpAddrs = objReader["EduReview_IpAddrs"].ToString();
				objEduReview.dtDate = DateTime.Parse(objReader["EduReview_Date"].ToString());
				objEduReviewList.Add(objEduReview);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEduReviewList;
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

    public CoreWebList<EduReviewClass> fn_getEduReviewByType(string strInstitutionType, int InstitutionTypeID)
    {
        CoreWebList<EduReviewClass> objEduReviewList = null;
        EduReviewClass objEduReview = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_EduReviews WHERE EduReview_InstitutionType=@EduReview_InstitutionType AND EduReview_InstitutionID=@EduReview_InstitutionID AND EduReview_Active='true'", objConnection);
            objCommand.Parameters.AddWithValue("@EduReview_InstitutionType", strInstitutionType);
            objCommand.Parameters.AddWithValue("@EduReview_InstitutionID", InstitutionTypeID);
            objReader = objCommand.ExecuteReader();
            objEduReviewList = new CoreWebList<EduReviewClass>();
            while (objReader.Read())
            {
                objEduReview = new EduReviewClass();
                objEduReview.iID = int.Parse(objReader["EduReview_ID"].ToString());
                objEduReview.strInstitutionType = objReader["EduReview_InstitutionType"].ToString();
                objEduReview.iInstitutionID = int.Parse(objReader["EduReview_InstitutionID"].ToString());
                objEduReview.strUserType = objReader["EduReview_UserType"].ToString();
                objEduReview.strName = objReader["EduReview_Name"].ToString();
                objEduReview.strEmail = objReader["EduReview_Email"].ToString();
                objEduReview.strMobileNo = objReader["EduReview_MobileNo"].ToString();
                objEduReview.strTitle = objReader["EduReview_Title"].ToString();
                objEduReview.strDetails = objReader["EduReview_Details"].ToString();
                objEduReview.bActive = bool.Parse(objReader["EduReview_Active"].ToString());
                objEduReview.strIpAddrs = objReader["EduReview_IpAddrs"].ToString();
                objEduReview.dtDate = DateTime.Parse(objReader["EduReview_Date"].ToString());
                objEduReviewList.Add(objEduReview);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objEduReviewList;
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

    public CoreWebList<EduReviewClass> fn_getInstituteReviewById(int InstituteID)
    {
        CoreWebList<EduReviewClass> objEduReviewList = null;
        EduReviewClass objEduReview = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT Inst.Institute_Title, Rew.* FROM tbl_EduReviews Rew join tbl_Institutes Inst on Rew.EduReview_InstitutionID=Inst.Institute_ID WHERE Rew.EduReview_InstitutionType='Institute' AND Rew.EduReview_InstitutionID=@EduReview_InstitutionID AND Rew.EduReview_Active='true'", objConnection);
            objCommand.Parameters.AddWithValue("@EduReview_InstitutionID", InstituteID);
            objReader = objCommand.ExecuteReader();
            objEduReviewList = new CoreWebList<EduReviewClass>();
            while (objReader.Read())
            {
                objEduReview = new EduReviewClass();
                objEduReview.iID = int.Parse(objReader["EduReview_ID"].ToString());
                objEduReview.strInstitutionType = objReader["EduReview_InstitutionType"].ToString();
                objEduReview.iInstitutionID = int.Parse(objReader["EduReview_InstitutionID"].ToString());
                objEduReview.strInstitute = objReader["Institute_Title"].ToString();
                objEduReview.strUserType = objReader["EduReview_UserType"].ToString();
                objEduReview.strName = objReader["EduReview_Name"].ToString();
                objEduReview.strEmail = objReader["EduReview_Email"].ToString();
                objEduReview.strMobileNo = objReader["EduReview_MobileNo"].ToString();
                objEduReview.strTitle = objReader["EduReview_Title"].ToString();
                objEduReview.strDetails = objReader["EduReview_Details"].ToString();
                objEduReview.bActive = bool.Parse(objReader["EduReview_Active"].ToString());
                objEduReview.strIpAddrs = objReader["EduReview_IpAddrs"].ToString();
                objEduReview.dtDate = DateTime.Parse(objReader["EduReview_Date"].ToString());
                objEduReviewList.Add(objEduReview);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objEduReviewList;
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
