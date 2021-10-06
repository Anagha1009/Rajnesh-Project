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
/// Summary description for DBCompetitionUserClass
/// </summary>
public class DBCompetitionUserClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

    public int fn_saveCompetitionUser(CompetitionUserClass objCompetitionUser)
    {
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_CompetitionUsers (CompetitionUser_Name,  CompetitionUser_Email, CompetitionUser_IpAddrs, CompetitionUser_Date) VALUES (@CompetitionUser_Name, @CompetitionUser_Email, @CompetitionUser_IpAddrs, @CompetitionUser_Date);SELECT @PK_New = @@IDENTITY", objConnection);

            SqlParameter insertedKey = new SqlParameter("@PK_New", SqlDbType.Int);
            insertedKey.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(insertedKey);

            objCommand.Parameters.AddWithValue("@CompetitionUser_Name", objCompetitionUser.strName);
            objCommand.Parameters.AddWithValue("@CompetitionUser_Email", objCompetitionUser.strEmail);
            objCommand.Parameters.AddWithValue("@CompetitionUser_IpAddrs", objCompetitionUser.strIpAddrs);
            objCommand.Parameters.AddWithValue("@CompetitionUser_Date", objCompetitionUser.dtDate);

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

    public int fn_save_CompetitionUser(CompetitionUserClass objCompetitionUser)
    {
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_CompetitionUsers (CompetitionUser_Name,  CompetitionUser_Email, CompetitionUser_DoB, CompetitionUser_Gender, CompetitionUser_FacebookID, CompetitionUser_IpAddrs,  CompetitionUser_Date) VALUES (@CompetitionUser_Name, @CompetitionUser_Email, @CompetitionUser_DoB, @CompetitionUser_Gender, @CompetitionUser_FacebookID, @CompetitionUser_IpAddrs, @CompetitionUser_Date);SELECT @PK_New = @@IDENTITY", objConnection);

            SqlParameter insertedKey = new SqlParameter("@PK_New", SqlDbType.Int);
            insertedKey.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(insertedKey);

            objCommand.Parameters.AddWithValue("@CompetitionUser_Name", objCompetitionUser.strName);
            objCommand.Parameters.AddWithValue("@CompetitionUser_Email", objCompetitionUser.strEmail);

            objCommand.Parameters.AddWithValue("@CompetitionUser_DoB", objCompetitionUser.dtDoB);
            objCommand.Parameters.AddWithValue("@CompetitionUser_Gender", objCompetitionUser.bGender);
            objCommand.Parameters.AddWithValue("@CompetitionUser_FacebookID", objCompetitionUser.strFacebookID);

            objCommand.Parameters.AddWithValue("@CompetitionUser_IpAddrs", objCompetitionUser.strIpAddrs);
            objCommand.Parameters.AddWithValue("@CompetitionUser_Date", objCompetitionUser.dtDate);

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
    
    public string fn_editCompetitionUser(CompetitionUserClass objCompetitionUser)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_CompetitionUsers SET CompetitionUser_CityID=@CompetitionUser_CityID, CompetitionUser_QualificationID=@CompetitionUser_QualificationID, CompetitionUser_DoB=@CompetitionUser_DoB, CompetitionUser_Gender=@CompetitionUser_Gender, CompetitionUser_Mobile=@CompetitionUser_Mobile, CompetitionUser_Address=@CompetitionUser_Address WHERE CompetitionUser_ID=@CompetitionUser_ID", objConnection);
            objCommand.Parameters.AddWithValue("@CompetitionUser_CityID", objCompetitionUser.iCityID);
            objCommand.Parameters.AddWithValue("@CompetitionUser_QualificationID", objCompetitionUser.iQualificationID);
            objCommand.Parameters.AddWithValue("@CompetitionUser_DoB", objCompetitionUser.dtDoB);
            objCommand.Parameters.AddWithValue("@CompetitionUser_Mobile", objCompetitionUser.strMobile);
			objCommand.Parameters.AddWithValue("@CompetitionUser_Address", objCompetitionUser.strAddress);

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

    public string fn_edit_CompetitionUser(CompetitionUserClass objCompetitionUser)
    {
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_CompetitionUsers SET CompetitionUser_CityID=@CompetitionUser_CityID, CompetitionUser_QualificationID=@CompetitionUser_QualificationID, CompetitionUser_Name=@CompetitionUser_Name, CompetitionUser_Email=@CompetitionUser_Email, CompetitionUser_DoB=@CompetitionUser_DoB, CompetitionUser_Gender=@CompetitionUser_Gender, CompetitionUser_Mobile=@CompetitionUser_Mobile, CompetitionUser_Address=@CompetitionUser_Address WHERE CompetitionUser_ID=@CompetitionUser_ID", objConnection);
            objCommand.Parameters.AddWithValue("@CompetitionUser_ID", objCompetitionUser.iID);
            objCommand.Parameters.AddWithValue("@CompetitionUser_CityID", objCompetitionUser.iCityID);
            objCommand.Parameters.AddWithValue("@CompetitionUser_QualificationID", objCompetitionUser.iQualificationID);
            objCommand.Parameters.AddWithValue("@CompetitionUser_Name", objCompetitionUser.strName);
            objCommand.Parameters.AddWithValue("@CompetitionUser_Email", objCompetitionUser.strEmail);
            objCommand.Parameters.AddWithValue("@CompetitionUser_DoB", objCompetitionUser.dtDoB);
            objCommand.Parameters.AddWithValue("@CompetitionUser_Gender", objCompetitionUser.bGender);
            objCommand.Parameters.AddWithValue("@CompetitionUser_Mobile", objCompetitionUser.strMobile);
            objCommand.Parameters.AddWithValue("@CompetitionUser_Address", objCompetitionUser.strAddress);

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

	public string fn_deleteCompetitionUser(int iCompetitionUserID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_CompetitionUsers WHERE CompetitionUser_ID=@CompetitionUser_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CompetitionUser_ID", iCompetitionUserID);

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

	public CoreWebList<CompetitionUserClass> fn_getCompetitionUserList()
	{
		CoreWebList<CompetitionUserClass> objCompetitionUserList = null;
		CompetitionUserClass objCompetitionUser = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionUsers", objConnection);
			objReader = objCommand.ExecuteReader();
			objCompetitionUserList = new CoreWebList<CompetitionUserClass>();
			while (objReader.Read())
			{
				objCompetitionUser = new CompetitionUserClass();
				objCompetitionUser.iID = int.Parse(objReader["CompetitionUser_ID"].ToString());
                objCompetitionUser.iCityID = int.Parse(objReader["CompetitionUser_CityID"].ToString());
                objCompetitionUser.iQualificationID = int.Parse(objReader["CompetitionUser_QualificationID"].ToString());
				objCompetitionUser.strName = objReader["CompetitionUser_Name"].ToString();
				objCompetitionUser.strEmail = objReader["CompetitionUser_Email"].ToString();
                objCompetitionUser.dtDoB = DateTime.Parse(objReader["CompetitionUser_DoB"].ToString());
				objCompetitionUser.strMobile = objReader["CompetitionUser_Mobile"].ToString();
				objCompetitionUser.strAddress = objReader["CompetitionUser_Address"].ToString();
				objCompetitionUser.strIpAddrs = objReader["CompetitionUser_IpAddrs"].ToString();
				objCompetitionUser.dtDate = DateTime.Parse(objReader["CompetitionUser_Date"].ToString());
				objCompetitionUserList.Add(objCompetitionUser);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionUserList;
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

	public CoreWebList<CompetitionUserClass> fn_getCompetitionUserByID(int iCompetitionUserID)
	{
		CoreWebList<CompetitionUserClass> objCompetitionUserList = null;
		CompetitionUserClass objCompetitionUser = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT cty.City_Title,Qua.Qualification_Title, * FROM tbl_CompetitionUsers usr left join tbl_City cty on usr.CompetitionUser_CityID=cty.City_ID left join tbl_Qualifications Qua on usr.CompetitionUser_QualificationID=Qua.Qualification_ID WHERE CompetitionUser_ID=@CompetitionUser_ID", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionUser_ID", iCompetitionUserID);
			objReader = objCommand.ExecuteReader();
			objCompetitionUserList = new CoreWebList<CompetitionUserClass>();
			if (objReader.Read())
			{
                objCompetitionUser = new CompetitionUserClass();
                objCompetitionUser.iID = int.Parse(objReader["CompetitionUser_ID"].ToString());
                objCompetitionUser.iCityID = int.Parse(objReader["CompetitionUser_CityID"].ToString());
                objCompetitionUser.iQualificationID = int.Parse(objReader["CompetitionUser_QualificationID"].ToString());

                objCompetitionUser.strCity = objReader["City_Title"].ToString();
                objCompetitionUser.strQualification = objReader["Qualification_Title"].ToString();

                objCompetitionUser.strName = objReader["CompetitionUser_Name"].ToString();
                objCompetitionUser.strEmail = objReader["CompetitionUser_Email"].ToString();
                objCompetitionUser.dtDoB = DateTime.Parse(objReader["CompetitionUser_DoB"].ToString());
                objCompetitionUser.bGender = bool.Parse(objReader["CompetitionUser_Gender"].ToString());
                objCompetitionUser.strMobile = objReader["CompetitionUser_Mobile"].ToString();
                objCompetitionUser.strAddress = objReader["CompetitionUser_Address"].ToString();
                objCompetitionUser.strIpAddrs = objReader["CompetitionUser_IpAddrs"].ToString();
                objCompetitionUser.dtDate = DateTime.Parse(objReader["CompetitionUser_Date"].ToString());
                objCompetitionUserList.Add(objCompetitionUser);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionUserList;
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

    public CoreWebList<CompetitionUserClass> fn_getCompetitionUserAnswersByID(int iCompetitionID, int iCompetitionUserID)
    {
        CoreWebList<CompetitionUserClass> objCompetitionUserList = null;
        CompetitionUserClass objCompetitionUser = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT qopt.CompetitionQuizOption_Answer FROM tbl_CompetitionUsers usr join tbl_CompetitionEntry ent on usr.CompetitionUser_ID=ent.CompetitionEntry_UserID join tbl_CompetitionQuizOptions qopt on ent.CompetitionEntry_OptionID=qopt.CompetitionQuizOption_ID join tbl_CompetitionQuiz Qz on qopt.CompetitionQuizOption_QuizID=Qz.CompetitionQuiz_ID WHERE Qz.CompetitionQuiz_CompetitionID=@CompetitionQuiz_CompetitionID AND ent.CompetitionEntry_UserID=@CompetitionEntry_UserID", objConnection);
            objCommand.Parameters.AddWithValue("@CompetitionQuiz_CompetitionID", iCompetitionID);
            objCommand.Parameters.AddWithValue("@CompetitionEntry_UserID", iCompetitionUserID);
            objReader = objCommand.ExecuteReader();
            objCompetitionUserList = new CoreWebList<CompetitionUserClass>();
            while (objReader.Read())
            {
                objCompetitionUser = new CompetitionUserClass();
                objCompetitionUser.bAnswer = bool.Parse(objReader["CompetitionQuizOption_Answer"].ToString());
                objCompetitionUserList.Add(objCompetitionUser);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCompetitionUserList;
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

    public CoreWebList<CompetitionUserClass> fn_getCompetitionUserByCompetitionID(int iCompetitionID)
    {
        CoreWebList<CompetitionUserClass> objCompetitionUserList = null;
        CompetitionUserClass objCompetitionUser = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionUsers WHERE CompetitionUser_ID IN(SELECT DISTINCT usr.CompetitionUser_ID FROM tbl_CompetitionUsers usr join tbl_CompetitionEntry ent on usr.CompetitionUser_ID=ent.CompetitionEntry_UserID join tbl_CompetitionQuizOptions qopt on ent.CompetitionEntry_OptionID=qopt.CompetitionQuizOption_ID join tbl_CompetitionQuiz Qz on qopt.CompetitionQuizOption_QuizID=Qz.CompetitionQuiz_ID WHERE Qz.CompetitionQuiz_CompetitionID=@CompetitionQuiz_CompetitionID) ORDER BY CompetitionUser_Date DESC", objConnection);
            objCommand.Parameters.AddWithValue("@CompetitionQuiz_CompetitionID", iCompetitionID);
            objReader = objCommand.ExecuteReader();
            objCompetitionUserList = new CoreWebList<CompetitionUserClass>();
            while (objReader.Read())
            {
                objCompetitionUser = new CompetitionUserClass();
                objCompetitionUser.iID = int.Parse(objReader["CompetitionUser_ID"].ToString());
                objCompetitionUser.iCityID = int.Parse(objReader["CompetitionUser_CityID"].ToString());
                objCompetitionUser.iQualificationID = int.Parse(objReader["CompetitionUser_QualificationID"].ToString());
                objCompetitionUser.strName = objReader["CompetitionUser_Name"].ToString();
                objCompetitionUser.strEmail = objReader["CompetitionUser_Email"].ToString();
                objCompetitionUser.dtDoB = DateTime.Parse(objReader["CompetitionUser_DoB"].ToString());
                objCompetitionUser.bGender = bool.Parse(objReader["CompetitionUser_Gender"].ToString());
                objCompetitionUser.strMobile = objReader["CompetitionUser_Mobile"].ToString();
                objCompetitionUser.strAddress = objReader["CompetitionUser_Address"].ToString();
                objCompetitionUser.strIpAddrs = objReader["CompetitionUser_IpAddrs"].ToString();
                objCompetitionUser.dtDate = DateTime.Parse(objReader["CompetitionUser_Date"].ToString());
                objCompetitionUserList.Add(objCompetitionUser);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCompetitionUserList;
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

    public CoreWebList<CompetitionUserClass> fn_getCompetitionFileUserByCompetitionID(int iCompetitionID)
    {
        CoreWebList<CompetitionUserClass> objCompetitionUserList = null;
        CompetitionUserClass objCompetitionUser = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionUsers WHERE CompetitionUser_ID IN(SELECT DISTINCT CompetitionUser_ID FROM tbl_CompetitionUsers users left join dbo.tbl_CompetitionFiles files  on users.CompetitionUser_ID=files.CompetitionFile_UserID WHERE files.CompetitionFile_CompetitionID=@CompetitionFile_CompetitionID) ORDER BY CompetitionUser_Date DESC", objConnection);
            objCommand.Parameters.AddWithValue("@CompetitionFile_CompetitionID", iCompetitionID);
            objReader = objCommand.ExecuteReader();
            objCompetitionUserList = new CoreWebList<CompetitionUserClass>();
            while (objReader.Read())
            {
                objCompetitionUser = new CompetitionUserClass();
                objCompetitionUser.iID = int.Parse(objReader["CompetitionUser_ID"].ToString());
                objCompetitionUser.iCityID = int.Parse(objReader["CompetitionUser_CityID"].ToString());
                objCompetitionUser.iQualificationID = int.Parse(objReader["CompetitionUser_QualificationID"].ToString());
                objCompetitionUser.strName = objReader["CompetitionUser_Name"].ToString();
                objCompetitionUser.strEmail = objReader["CompetitionUser_Email"].ToString();
                objCompetitionUser.dtDoB = DateTime.Parse(objReader["CompetitionUser_DoB"].ToString());
                objCompetitionUser.bGender = bool.Parse(objReader["CompetitionUser_Gender"].ToString());
                objCompetitionUser.strMobile = objReader["CompetitionUser_Mobile"].ToString();
                objCompetitionUser.strAddress = objReader["CompetitionUser_Address"].ToString();
                objCompetitionUser.strIpAddrs = objReader["CompetitionUser_IpAddrs"].ToString();
                objCompetitionUser.dtDate = DateTime.Parse(objReader["CompetitionUser_Date"].ToString());
                objCompetitionUserList.Add(objCompetitionUser);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCompetitionUserList;
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

    public CoreWebList<CompetitionUserClass> fn_getCompetitionFileUserByKeys(int iCompetitionID, string strKeys)
    {
        CoreWebList<CompetitionUserClass> objCompetitionUserList = null;
        CompetitionUserClass objCompetitionUser = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionUsers WHERE (CompetitionUser_ID IN(SELECT DISTINCT CompetitionUser_ID FROM tbl_CompetitionUsers users left join dbo.tbl_CompetitionFiles files  on users.CompetitionUser_ID=files.CompetitionFile_UserID WHERE files.CompetitionFile_CompetitionID=@CompetitionFile_CompetitionID)) AND ((CompetitionUser_Name like '%' + @Keys + '%') OR (CompetitionUser_Email like '%' + @Keys + '%') OR (CompetitionUser_Mobile like '%' + @Keys + '%')) ORDER BY CompetitionUser_Date DESC", objConnection);
            objCommand.Parameters.AddWithValue("@CompetitionFile_CompetitionID", iCompetitionID);
            objCommand.Parameters.AddWithValue("@Keys", strKeys);
            objReader = objCommand.ExecuteReader();
            objCompetitionUserList = new CoreWebList<CompetitionUserClass>();
            while (objReader.Read())
            {
                objCompetitionUser = new CompetitionUserClass();
                objCompetitionUser.iID = int.Parse(objReader["CompetitionUser_ID"].ToString());
                objCompetitionUser.iCityID = int.Parse(objReader["CompetitionUser_CityID"].ToString());
                objCompetitionUser.iQualificationID = int.Parse(objReader["CompetitionUser_QualificationID"].ToString());
                objCompetitionUser.strName = objReader["CompetitionUser_Name"].ToString();
                objCompetitionUser.strEmail = objReader["CompetitionUser_Email"].ToString();
                objCompetitionUser.dtDoB = DateTime.Parse(objReader["CompetitionUser_DoB"].ToString());
                objCompetitionUser.bGender = bool.Parse(objReader["CompetitionUser_Gender"].ToString());
                objCompetitionUser.strMobile = objReader["CompetitionUser_Mobile"].ToString();
                objCompetitionUser.strAddress = objReader["CompetitionUser_Address"].ToString();
                objCompetitionUser.strIpAddrs = objReader["CompetitionUser_IpAddrs"].ToString();
                objCompetitionUser.dtDate = DateTime.Parse(objReader["CompetitionUser_Date"].ToString());
                objCompetitionUserList.Add(objCompetitionUser);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCompetitionUserList;
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

	public CoreWebList<CompetitionUserClass> fn_getCompetitionUserByName(string strCompetitionUserName)
	{
		CoreWebList<CompetitionUserClass> objCompetitionUserList = null;
		CompetitionUserClass objCompetitionUser = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionUsers WHERE CompetitionUser_Name=@CompetitionUser_Name", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionUser_Name", strCompetitionUserName);
			objReader = objCommand.ExecuteReader();
			objCompetitionUserList = new CoreWebList<CompetitionUserClass>();
			if (objReader.Read())
			{
                objCompetitionUser = new CompetitionUserClass();
                objCompetitionUser.iID = int.Parse(objReader["CompetitionUser_ID"].ToString());
                objCompetitionUser.iCityID = int.Parse(objReader["CompetitionUser_CityID"].ToString());
                objCompetitionUser.iQualificationID = int.Parse(objReader["CompetitionUser_QualificationID"].ToString());
                objCompetitionUser.strName = objReader["CompetitionUser_Name"].ToString();
                objCompetitionUser.strEmail = objReader["CompetitionUser_Email"].ToString();
                objCompetitionUser.dtDoB = DateTime.Parse(objReader["CompetitionUser_DoB"].ToString());
                objCompetitionUser.strMobile = objReader["CompetitionUser_Mobile"].ToString();
                objCompetitionUser.strAddress = objReader["CompetitionUser_Address"].ToString();
                objCompetitionUser.strIpAddrs = objReader["CompetitionUser_IpAddrs"].ToString();
                objCompetitionUser.dtDate = DateTime.Parse(objReader["CompetitionUser_Date"].ToString());
                objCompetitionUserList.Add(objCompetitionUser);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionUserList;
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

    public CoreWebList<CompetitionUserClass> fn_getNewsLetterUsers(string strQuery)
    {
        CoreWebList<CompetitionUserClass> objCompetitionUserList = null;
        CompetitionUserClass objCompetitionUser = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();
            objCompetitionUserList = new CoreWebList<CompetitionUserClass>();
            while (objReader.Read())
            {
                objCompetitionUser = new CompetitionUserClass();
                objCompetitionUser.strName = objReader["Name"].ToString();
                objCompetitionUser.strEmail = objReader["Email"].ToString();
                objCompetitionUserList.Add(objCompetitionUser);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCompetitionUserList;
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

    public CoreWebList<CompetitionUserClass> fn_getCompetitionUserByEmail(string strCompetitionUserEmail)
    {
        CoreWebList<CompetitionUserClass> objCompetitionUserList = null;
        CompetitionUserClass objCompetitionUser = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionUsers WHERE CompetitionUser_Email=@CompetitionUser_Email", objConnection);
            objCommand.Parameters.AddWithValue("@CompetitionUser_Email", strCompetitionUserEmail);
            objReader = objCommand.ExecuteReader();
            objCompetitionUserList = new CoreWebList<CompetitionUserClass>();
            if (objReader.Read())
            {
                objCompetitionUser = new CompetitionUserClass();
                objCompetitionUser.iID = int.Parse(objReader["CompetitionUser_ID"].ToString());
                objCompetitionUser.strName = objReader["CompetitionUser_Name"].ToString();
                objCompetitionUser.strEmail = objReader["CompetitionUser_Email"].ToString();
                objCompetitionUser.strIpAddrs = objReader["CompetitionUser_IpAddrs"].ToString();
                objCompetitionUser.dtDate = DateTime.Parse(objReader["CompetitionUser_Date"].ToString());
                objCompetitionUserList.Add(objCompetitionUser);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCompetitionUserList;
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

	public CoreWebList<CompetitionUserClass> fn_getCompetitionUserByKeys(string strCompetitionUserName, int iCompetitionID)
	{
		CoreWebList<CompetitionUserClass> objCompetitionUserList = null;
		CompetitionUserClass objCompetitionUser = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionUsers WHERE CompetitionUser_ID IN(SELECT DISTINCT usr.CompetitionUser_ID FROM tbl_CompetitionUsers usr join tbl_CompetitionEntry ent on usr.CompetitionUser_ID=ent.CompetitionEntry_UserID join tbl_CompetitionQuizOptions qopt on ent.CompetitionEntry_OptionID=qopt.CompetitionQuizOption_ID join tbl_CompetitionQuiz Qz on qopt.CompetitionQuizOption_QuizID=Qz.CompetitionQuiz_ID WHERE Qz.CompetitionQuiz_CompetitionID=@CompetitionQuiz_CompetitionID) AND ((CompetitionUser_Name like @Keys + '%') OR (CompetitionUser_Email like '%' + @Keys + '%') OR (CompetitionUser_Mobile like '%' + @Keys + '%'))", objConnection);
            objCommand.Parameters.AddWithValue("@CompetitionQuiz_CompetitionID", iCompetitionID);
            objCommand.Parameters.AddWithValue("@Keys", strCompetitionUserName);
			objReader = objCommand.ExecuteReader();
			objCompetitionUserList = new CoreWebList<CompetitionUserClass>();
			while (objReader.Read())
			{
                objCompetitionUser = new CompetitionUserClass();
                objCompetitionUser.iID = int.Parse(objReader["CompetitionUser_ID"].ToString());
                objCompetitionUser.iCityID = int.Parse(objReader["CompetitionUser_CityID"].ToString());
                objCompetitionUser.iQualificationID = int.Parse(objReader["CompetitionUser_QualificationID"].ToString());
                objCompetitionUser.strName = objReader["CompetitionUser_Name"].ToString();
                objCompetitionUser.strEmail = objReader["CompetitionUser_Email"].ToString();
                objCompetitionUser.dtDoB = DateTime.Parse(objReader["CompetitionUser_DoB"].ToString());
                objCompetitionUser.strMobile = objReader["CompetitionUser_Mobile"].ToString();
                objCompetitionUser.strAddress = objReader["CompetitionUser_Address"].ToString();
                objCompetitionUser.strIpAddrs = objReader["CompetitionUser_IpAddrs"].ToString();
                objCompetitionUser.dtDate = DateTime.Parse(objReader["CompetitionUser_Date"].ToString());
                objCompetitionUserList.Add(objCompetitionUser);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionUserList;
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

	public CoreWebList<CompetitionUserClass> fn_getCompetitionUserByQualificationID(int iQualificationID)
	{
		CoreWebList<CompetitionUserClass> objCompetitionUserList = null;
		CompetitionUserClass objCompetitionUser = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CompetitionUsers WHERE CompetitionUser_QualificationID=@CompetitionUser_QualificationID", objConnection);
			objCommand.Parameters.AddWithValue("@CompetitionUser_QualificationID", iQualificationID);
			objReader = objCommand.ExecuteReader();
			objCompetitionUserList = new CoreWebList<CompetitionUserClass>();
			while (objReader.Read())
			{
                objCompetitionUser = new CompetitionUserClass();
                objCompetitionUser.iID = int.Parse(objReader["CompetitionUser_ID"].ToString());
                objCompetitionUser.iCityID = int.Parse(objReader["CompetitionUser_CityID"].ToString());
                objCompetitionUser.iQualificationID = int.Parse(objReader["CompetitionUser_QualificationID"].ToString());
                objCompetitionUser.strName = objReader["CompetitionUser_Name"].ToString();
                objCompetitionUser.strEmail = objReader["CompetitionUser_Email"].ToString();
                objCompetitionUser.dtDoB = DateTime.Parse(objReader["CompetitionUser_DoB"].ToString());
                objCompetitionUser.strMobile = objReader["CompetitionUser_Mobile"].ToString();
                objCompetitionUser.strAddress = objReader["CompetitionUser_Address"].ToString();
                objCompetitionUser.strIpAddrs = objReader["CompetitionUser_IpAddrs"].ToString();
                objCompetitionUser.dtDate = DateTime.Parse(objReader["CompetitionUser_Date"].ToString());
                objCompetitionUserList.Add(objCompetitionUser);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCompetitionUserList;
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
