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
/// Summary description for DBSchoolClass
/// </summary>
public class DBSchoolClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveSchool(SchoolClass objSchool)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_Schools (School_CityID, School_Rank, School_Title, School_Desc, School_Admissions, School_Facilities, School_ContactDetails, School_AfflialtedBoard, School_Trust, School_Principal, School_Website, School_Featured, School_Photo) VALUES (@School_CityID, @School_Rank, @School_Title, @School_Desc, @School_Admissions, @School_Facilities, @School_ContactDetails, @School_AfflialtedBoard, @School_Trust, @School_Principal, @School_Website, @School_Featured, @School_Photo)", objConnection);
			objCommand.Parameters.AddWithValue("@School_CityID", objSchool.iCityID);
            objCommand.Parameters.AddWithValue("@School_Rank", objSchool.iRank);
			objCommand.Parameters.AddWithValue("@School_Title", objSchool.strTitle);
			objCommand.Parameters.AddWithValue("@School_Desc", objSchool.strDesc);
			objCommand.Parameters.AddWithValue("@School_Admissions", objSchool.strAdmissions);
			objCommand.Parameters.AddWithValue("@School_Facilities", objSchool.strFacilities);
			objCommand.Parameters.AddWithValue("@School_ContactDetails", objSchool.strContactDetails);
			objCommand.Parameters.AddWithValue("@School_AfflialtedBoard", objSchool.strAfflialtedBoard);
			objCommand.Parameters.AddWithValue("@School_Trust", objSchool.strTrust);
			objCommand.Parameters.AddWithValue("@School_Principal", objSchool.strPrincipal);
			objCommand.Parameters.AddWithValue("@School_Website", objSchool.strWebsite);
			objCommand.Parameters.AddWithValue("@School_Featured", objSchool.bFeatured);
			objCommand.Parameters.AddWithValue("@School_Photo", objSchool.strPhoto);

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

	public string fn_editSchool(SchoolClass objSchool)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_Schools SET School_CityID=@School_CityID, School_Rank=@School_Rank, School_Title=@School_Title, School_Desc=@School_Desc, School_Admissions=@School_Admissions, School_Facilities=@School_Facilities, School_ContactDetails=@School_ContactDetails, School_AfflialtedBoard=@School_AfflialtedBoard, School_Trust=@School_Trust, School_Principal=@School_Principal, School_Website=@School_Website, School_Featured=@School_Featured, School_Photo=@School_Photo WHERE School_ID=@School_ID", objConnection);
			objCommand.Parameters.AddWithValue("@School_ID", objSchool.iID);
			objCommand.Parameters.AddWithValue("@School_CityID", objSchool.iCityID);
            objCommand.Parameters.AddWithValue("@School_Rank", objSchool.iRank);
			objCommand.Parameters.AddWithValue("@School_Title", objSchool.strTitle);
			objCommand.Parameters.AddWithValue("@School_Desc", objSchool.strDesc);
			objCommand.Parameters.AddWithValue("@School_Admissions", objSchool.strAdmissions);
			objCommand.Parameters.AddWithValue("@School_Facilities", objSchool.strFacilities);
			objCommand.Parameters.AddWithValue("@School_ContactDetails", objSchool.strContactDetails);
			objCommand.Parameters.AddWithValue("@School_AfflialtedBoard", objSchool.strAfflialtedBoard);
			objCommand.Parameters.AddWithValue("@School_Trust", objSchool.strTrust);
			objCommand.Parameters.AddWithValue("@School_Principal", objSchool.strPrincipal);
			objCommand.Parameters.AddWithValue("@School_Website", objSchool.strWebsite);
			objCommand.Parameters.AddWithValue("@School_Featured", objSchool.bFeatured);
			objCommand.Parameters.AddWithValue("@School_Photo", objSchool.strPhoto);

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

	public string fn_deleteSchool(int iSchoolID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Schools WHERE School_ID=@School_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@School_ID", iSchoolID);

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

	public CoreWebList<SchoolClass> fn_getSchoolList()
	{
		CoreWebList<SchoolClass> objSchoolList = null;
		SchoolClass objSchool = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Schools ORDER BY School_Title ASC", objConnection);
			objReader = objCommand.ExecuteReader();
			objSchoolList = new CoreWebList<SchoolClass>();
			while (objReader.Read())
			{
				objSchool = new SchoolClass();
				objSchool.iID = int.Parse(objReader["School_ID"].ToString());
				objSchool.iCityID = int.Parse(objReader["School_CityID"].ToString());
                objSchool.iRank = int.Parse(objReader["School_Rank"].ToString());
				objSchool.strTitle = objReader["School_Title"].ToString();
				objSchool.strDesc = objReader["School_Desc"].ToString();
				objSchool.strAdmissions = objReader["School_Admissions"].ToString();
				objSchool.strFacilities = objReader["School_Facilities"].ToString();
				objSchool.strContactDetails = objReader["School_ContactDetails"].ToString();
				objSchool.strAfflialtedBoard = objReader["School_AfflialtedBoard"].ToString();
				objSchool.strTrust = objReader["School_Trust"].ToString();
				objSchool.strPrincipal = objReader["School_Principal"].ToString();
				objSchool.strWebsite = objReader["School_Website"].ToString();
				objSchool.bFeatured = bool.Parse(objReader["School_Featured"].ToString());
                objSchool.bHomeFeatured = bool.Parse(objReader["School_HomeFeatured"].ToString());
				objSchool.strPhoto = objReader["School_Photo"].ToString();
				objSchoolList.Add(objSchool);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolList;
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

    public CoreWebList<SchoolClass> fn_getHomeFeaturedSchoolList()
    {
        CoreWebList<SchoolClass> objSchoolList = null;
        SchoolClass objSchool = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Schools WHERE School_HomeFeatured='true' ORDER BY School_Title ASC", objConnection);
            objReader = objCommand.ExecuteReader();
            objSchoolList = new CoreWebList<SchoolClass>();
            while (objReader.Read())
            {
                objSchool = new SchoolClass();
                objSchool.iID = int.Parse(objReader["School_ID"].ToString());
                objSchool.iCityID = int.Parse(objReader["School_CityID"].ToString());
                objSchool.iRank = int.Parse(objReader["School_Rank"].ToString());
                objSchool.strTitle = objReader["School_Title"].ToString();
                objSchool.strDesc = objReader["School_Desc"].ToString();
                objSchool.strAdmissions = objReader["School_Admissions"].ToString();
                objSchool.strFacilities = objReader["School_Facilities"].ToString();
                objSchool.strContactDetails = objReader["School_ContactDetails"].ToString();
                objSchool.strAfflialtedBoard = objReader["School_AfflialtedBoard"].ToString();
                objSchool.strTrust = objReader["School_Trust"].ToString();
                objSchool.strPrincipal = objReader["School_Principal"].ToString();
                objSchool.strWebsite = objReader["School_Website"].ToString();
                objSchool.bFeatured = bool.Parse(objReader["School_Featured"].ToString());
                objSchool.bHomeFeatured = bool.Parse(objReader["School_HomeFeatured"].ToString());
                objSchool.strPhoto = objReader["School_Photo"].ToString();
                objSchoolList.Add(objSchool);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objSchoolList;
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

    public CoreWebList<SchoolClass> fn_getSchoolListByQuery(string strQuery)
    {
        CoreWebList<SchoolClass> objSchoolList = null;
        SchoolClass objSchool = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();
            objSchoolList = new CoreWebList<SchoolClass>();
            while (objReader.Read())
            {
                objSchool = new SchoolClass();
                objSchool.iID = int.Parse(objReader["School_ID"].ToString());
                objSchool.iCityID = int.Parse(objReader["School_CityID"].ToString());
                objSchool.iRank = int.Parse(objReader["School_Rank"].ToString());
                objSchool.strTitle = objReader["School_Title"].ToString();
                objSchool.strDesc = objReader["School_Desc"].ToString();
                objSchool.strAdmissions = objReader["School_Admissions"].ToString();
                objSchool.strFacilities = objReader["School_Facilities"].ToString();
                objSchool.strContactDetails = objReader["School_ContactDetails"].ToString();
                objSchool.strAfflialtedBoard = objReader["School_AfflialtedBoard"].ToString();
                objSchool.strTrust = objReader["School_Trust"].ToString();
                objSchool.strPrincipal = objReader["School_Principal"].ToString();
                objSchool.strWebsite = objReader["School_Website"].ToString();
                objSchool.bFeatured = bool.Parse(objReader["School_Featured"].ToString());
                objSchool.bHomeFeatured = bool.Parse(objReader["School_HomeFeatured"].ToString());
                objSchool.strPhoto = objReader["School_Photo"].ToString();
                objSchoolList.Add(objSchool);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objSchoolList;
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

	public CoreWebList<SchoolClass> fn_getSchoolByID(int iSchoolID)
	{
		CoreWebList<SchoolClass> objSchoolList = null;
		SchoolClass objSchool = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Schools WHERE School_ID=@School_ID", objConnection);
			objCommand.Parameters.AddWithValue("@School_ID", iSchoolID);
			objReader = objCommand.ExecuteReader();
			objSchoolList = new CoreWebList<SchoolClass>();
			if (objReader.Read())
			{
				objSchool = new SchoolClass();
				objSchool.iID = int.Parse(objReader["School_ID"].ToString());
				objSchool.iCityID = int.Parse(objReader["School_CityID"].ToString());
                objSchool.iRank = int.Parse(objReader["School_Rank"].ToString());
				objSchool.strTitle = objReader["School_Title"].ToString();
				objSchool.strDesc = objReader["School_Desc"].ToString();
				objSchool.strAdmissions = objReader["School_Admissions"].ToString();
				objSchool.strFacilities = objReader["School_Facilities"].ToString();
				objSchool.strContactDetails = objReader["School_ContactDetails"].ToString();
				objSchool.strAfflialtedBoard = objReader["School_AfflialtedBoard"].ToString();
				objSchool.strTrust = objReader["School_Trust"].ToString();
				objSchool.strPrincipal = objReader["School_Principal"].ToString();
				objSchool.strWebsite = objReader["School_Website"].ToString();
				objSchool.bFeatured = bool.Parse(objReader["School_Featured"].ToString());
                objSchool.bHomeFeatured = bool.Parse(objReader["School_HomeFeatured"].ToString());
				objSchool.strPhoto = objReader["School_Photo"].ToString();
				objSchoolList.Add(objSchool);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolList;
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

    public CoreWebList<SchoolClass> fn_getSchoolByIdentity(string strIdentity)
    {
        CoreWebList<SchoolClass> objSchoolList = null;
        SchoolClass objSchool = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT City_Title FROM tbl_City cty WHERE cty.City_ID=sch.School_CityID)School_City, * FROM tbl_Schools sch WHERE sch.School_ID IN (" + strIdentity + ") ORDER BY sch.School_Featured DESC, sch.School_Rank ASC", objConnection);
            objReader = objCommand.ExecuteReader();
            objSchoolList = new CoreWebList<SchoolClass>();
            while (objReader.Read())
            {
                objSchool = new SchoolClass();
                objSchool.iID = int.Parse(objReader["School_ID"].ToString());
                objSchool.iCityID = int.Parse(objReader["School_CityID"].ToString());
                objSchool.iRank = int.Parse(objReader["School_Rank"].ToString());
                objSchool.strCity = objReader["School_City"].ToString();
                objSchool.strTitle = objReader["School_Title"].ToString();
                objSchool.strDesc = objReader["School_Desc"].ToString();
                objSchool.strAdmissions = objReader["School_Admissions"].ToString();
                objSchool.strFacilities = objReader["School_Facilities"].ToString();
                objSchool.strContactDetails = objReader["School_ContactDetails"].ToString();
                objSchool.strAfflialtedBoard = objReader["School_AfflialtedBoard"].ToString();
                objSchool.strTrust = objReader["School_Trust"].ToString();
                objSchool.strPrincipal = objReader["School_Principal"].ToString();
                objSchool.strWebsite = objReader["School_Website"].ToString();
                objSchool.bFeatured = bool.Parse(objReader["School_Featured"].ToString());
                objSchool.bHomeFeatured = bool.Parse(objReader["School_HomeFeatured"].ToString());
                objSchool.strPhoto = objReader["School_Photo"].ToString();
                objSchoolList.Add(objSchool);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objSchoolList;
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

	public CoreWebList<SchoolClass> fn_getSchoolByName(string strSchoolTitle)
	{
		CoreWebList<SchoolClass> objSchoolList = null;
		SchoolClass objSchool = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT City_Title FROM tbl_City cty WHERE cty.City_ID=sch.School_CityID)School_City, * FROM tbl_Schools sch WHERE sch.School_Title=@School_Title", objConnection);
			objCommand.Parameters.AddWithValue("@School_Title", strSchoolTitle);
			objReader = objCommand.ExecuteReader();
			objSchoolList = new CoreWebList<SchoolClass>();
			if (objReader.Read())
			{
				objSchool = new SchoolClass();
				objSchool.iID = int.Parse(objReader["School_ID"].ToString());
				objSchool.iCityID = int.Parse(objReader["School_CityID"].ToString());
                objSchool.iRank = int.Parse(objReader["School_Rank"].ToString());
                objSchool.strCity = objReader["School_City"].ToString();
                objSchool.strTitle = objReader["School_Title"].ToString();
				objSchool.strDesc = objReader["School_Desc"].ToString();
				objSchool.strAdmissions = objReader["School_Admissions"].ToString();
				objSchool.strFacilities = objReader["School_Facilities"].ToString();
				objSchool.strContactDetails = objReader["School_ContactDetails"].ToString();
				objSchool.strAfflialtedBoard = objReader["School_AfflialtedBoard"].ToString();
				objSchool.strTrust = objReader["School_Trust"].ToString();
				objSchool.strPrincipal = objReader["School_Principal"].ToString();
				objSchool.strWebsite = objReader["School_Website"].ToString();
				objSchool.bFeatured = bool.Parse(objReader["School_Featured"].ToString());
                objSchool.bHomeFeatured = bool.Parse(objReader["School_HomeFeatured"].ToString());
				objSchool.strPhoto = objReader["School_Photo"].ToString();
				objSchoolList.Add(objSchool);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolList;
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

	public CoreWebList<SchoolClass> fn_getSchoolByKeys(string strSchoolTitle)
	{
		CoreWebList<SchoolClass> objSchoolList = null;
		SchoolClass objSchool = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Schools WHERE School_Title like '%' + @School_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@School_Title", strSchoolTitle);
			objReader = objCommand.ExecuteReader();
			objSchoolList = new CoreWebList<SchoolClass>();
			while (objReader.Read())
			{
				objSchool = new SchoolClass();
				objSchool.iID = int.Parse(objReader["School_ID"].ToString());
				objSchool.iCityID = int.Parse(objReader["School_CityID"].ToString());
                objSchool.iRank = int.Parse(objReader["School_Rank"].ToString());
				objSchool.strTitle = objReader["School_Title"].ToString();
				objSchool.strDesc = objReader["School_Desc"].ToString();
				objSchool.strAdmissions = objReader["School_Admissions"].ToString();
				objSchool.strFacilities = objReader["School_Facilities"].ToString();
				objSchool.strContactDetails = objReader["School_ContactDetails"].ToString();
				objSchool.strAfflialtedBoard = objReader["School_AfflialtedBoard"].ToString();
				objSchool.strTrust = objReader["School_Trust"].ToString();
				objSchool.strPrincipal = objReader["School_Principal"].ToString();
				objSchool.strWebsite = objReader["School_Website"].ToString();
				objSchool.bFeatured = bool.Parse(objReader["School_Featured"].ToString());
                objSchool.bHomeFeatured = bool.Parse(objReader["School_HomeFeatured"].ToString());
				objSchool.strPhoto = objReader["School_Photo"].ToString();
				objSchoolList.Add(objSchool);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolList;
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

	public CoreWebList<SchoolClass> fn_getSchoolByCityID(int iCityID)
	{
		CoreWebList<SchoolClass> objSchoolList = null;
		SchoolClass objSchool = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Schools WHERE School_CityID=@School_CityID", objConnection);
			objCommand.Parameters.AddWithValue("@School_CityID", iCityID);
			objReader = objCommand.ExecuteReader();
			objSchoolList = new CoreWebList<SchoolClass>();
			while (objReader.Read())
			{
				objSchool = new SchoolClass();
				objSchool.iID = int.Parse(objReader["School_ID"].ToString());
				objSchool.iCityID = int.Parse(objReader["School_CityID"].ToString());
				objSchool.strTitle = objReader["School_Title"].ToString();
				objSchool.strDesc = objReader["School_Desc"].ToString();
				objSchool.strAdmissions = objReader["School_Admissions"].ToString();
				objSchool.strFacilities = objReader["School_Facilities"].ToString();
				objSchool.strContactDetails = objReader["School_ContactDetails"].ToString();
				objSchool.strAfflialtedBoard = objReader["School_AfflialtedBoard"].ToString();
				objSchool.strTrust = objReader["School_Trust"].ToString();
				objSchool.strPrincipal = objReader["School_Principal"].ToString();
				objSchool.strWebsite = objReader["School_Website"].ToString();
				objSchool.bFeatured = bool.Parse(objReader["School_Featured"].ToString());
                objSchool.bHomeFeatured = bool.Parse(objReader["School_HomeFeatured"].ToString());
				objSchool.strPhoto = objReader["School_Photo"].ToString();
				objSchoolList.Add(objSchool);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolList;
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

    public CoreWebList<SchoolClass> fn_getRandomSchoolByCityID(int iCityID)
    {
        CoreWebList<SchoolClass> objSchoolList = null;
        SchoolClass objSchool = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 5 * FROM tbl_Schools WHERE School_CityID=@School_CityID ORDER BY NEWID()", objConnection);
            objCommand.Parameters.AddWithValue("@School_CityID", iCityID);
            objReader = objCommand.ExecuteReader();
            objSchoolList = new CoreWebList<SchoolClass>();
            while (objReader.Read())
            {
                objSchool = new SchoolClass();
                objSchool.iID = int.Parse(objReader["School_ID"].ToString());
                objSchool.iCityID = int.Parse(objReader["School_CityID"].ToString());
                objSchool.iRank = int.Parse(objReader["School_Rank"].ToString());
                objSchool.strTitle = objReader["School_Title"].ToString();
                objSchool.strDesc = objReader["School_Desc"].ToString();
                objSchool.strAdmissions = objReader["School_Admissions"].ToString();
                objSchool.strFacilities = objReader["School_Facilities"].ToString();
                objSchool.strContactDetails = objReader["School_ContactDetails"].ToString();
                objSchool.strAfflialtedBoard = objReader["School_AfflialtedBoard"].ToString();
                objSchool.strTrust = objReader["School_Trust"].ToString();
                objSchool.strPrincipal = objReader["School_Principal"].ToString();
                objSchool.strWebsite = objReader["School_Website"].ToString();
                objSchool.bFeatured = bool.Parse(objReader["School_Featured"].ToString());
                objSchool.bHomeFeatured = bool.Parse(objReader["School_HomeFeatured"].ToString());
                objSchool.strPhoto = objReader["School_Photo"].ToString();
                objSchoolList.Add(objSchool);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objSchoolList;
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

    public CoreWebList<SchoolClass> fn_getRandomSchoolList()
    {
        CoreWebList<SchoolClass> objSchoolList = null;
        SchoolClass objSchool = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 6 * FROM tbl_Schools ORDER BY NEWID()", objConnection);
            objReader = objCommand.ExecuteReader();
            objSchoolList = new CoreWebList<SchoolClass>();
            while (objReader.Read())
            {
                objSchool = new SchoolClass();
                objSchool.iID = int.Parse(objReader["School_ID"].ToString());
                objSchool.iCityID = int.Parse(objReader["School_CityID"].ToString());
                objSchool.iRank = int.Parse(objReader["School_Rank"].ToString());
                objSchool.strTitle = objReader["School_Title"].ToString();
                objSchool.strDesc = objReader["School_Desc"].ToString();
                objSchool.strAdmissions = objReader["School_Admissions"].ToString();
                objSchool.strFacilities = objReader["School_Facilities"].ToString();
                objSchool.strContactDetails = objReader["School_ContactDetails"].ToString();
                objSchool.strAfflialtedBoard = objReader["School_AfflialtedBoard"].ToString();
                objSchool.strTrust = objReader["School_Trust"].ToString();
                objSchool.strPrincipal = objReader["School_Principal"].ToString();
                objSchool.strWebsite = objReader["School_Website"].ToString();
                objSchool.bFeatured = bool.Parse(objReader["School_Featured"].ToString());
                objSchool.bHomeFeatured = bool.Parse(objReader["School_HomeFeatured"].ToString());
                objSchool.strPhoto = objReader["School_Photo"].ToString();
                objSchoolList.Add(objSchool);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objSchoolList;
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

    public CoreWebList<SchoolClass> fn_get_Random_SchoolList()
    {
        CoreWebList<SchoolClass> objSchoolList = null;
        SchoolClass objSchool = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 5 * FROM tbl_Schools ORDER BY NEWID()", objConnection);
            objReader = objCommand.ExecuteReader();
            objSchoolList = new CoreWebList<SchoolClass>();
            while (objReader.Read())
            {
                objSchool = new SchoolClass();
                objSchool.iID = int.Parse(objReader["School_ID"].ToString());
                objSchool.iCityID = int.Parse(objReader["School_CityID"].ToString());
                objSchool.iRank = int.Parse(objReader["School_Rank"].ToString());
                objSchool.strTitle = objReader["School_Title"].ToString();
                objSchool.strDesc = objReader["School_Desc"].ToString();
                objSchool.strAdmissions = objReader["School_Admissions"].ToString();
                objSchool.strFacilities = objReader["School_Facilities"].ToString();
                objSchool.strContactDetails = objReader["School_ContactDetails"].ToString();
                objSchool.strAfflialtedBoard = objReader["School_AfflialtedBoard"].ToString();
                objSchool.strTrust = objReader["School_Trust"].ToString();
                objSchool.strPrincipal = objReader["School_Principal"].ToString();
                objSchool.strWebsite = objReader["School_Website"].ToString();
                objSchool.bFeatured = bool.Parse(objReader["School_Featured"].ToString());
                objSchool.bHomeFeatured = bool.Parse(objReader["School_HomeFeatured"].ToString());
                objSchool.strPhoto = objReader["School_Photo"].ToString();
                objSchoolList.Add(objSchool);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objSchoolList;
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

	public string fn_ChangeSchoolFeaturedStatus(SchoolClass objSchool)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Schools SET School_Featured=@School_Featured WHERE School_ID=@School_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("School_ID", objSchool.iID);
			objCommand.Parameters.AddWithValue("School_Featured", objSchool.bFeatured);

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

    public string fn_ChangeSchoolHomeFeaturedStatus(SchoolClass objSchool)
    {
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_Schools SET School_HomeFeatured=@School_HomeFeatured WHERE School_ID=@School_ID", objConnection);
            objCommand.Parameters.AddWithValue("School_ID", objSchool.iID);
            objCommand.Parameters.AddWithValue("School_HomeFeatured", objSchool.bHomeFeatured);

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
