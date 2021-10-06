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
/// Summary description for DBInstituteClass
/// </summary>
public class DBInstituteClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveInstitute(InstituteClass objInstitute)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_Institutes (Institute_CityID, Institute_Title, Institute_Desc, Institute_EstablishedIn, Institute_AffiliatedTo, Institute_ContactDetails, Institute_Placements, Institute_Admissions, Institute_Facilities, Institute_Website, Institute_Featured, Institute_Photo) VALUES (@Institute_CityID, @Institute_Title, @Institute_Desc, @Institute_EstablishedIn, @Institute_AffiliatedTo, @Institute_ContactDetails, @Institute_Placements, @Institute_Admissions, @Institute_Facilities, @Institute_Website, @Institute_Featured, @Institute_Photo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Institute_CityID", objInstitute.iCityID);
			objCommand.Parameters.AddWithValue("@Institute_Title", objInstitute.strTitle);
			objCommand.Parameters.AddWithValue("@Institute_Desc", objInstitute.strDesc);
			objCommand.Parameters.AddWithValue("@Institute_EstablishedIn", objInstitute.strEstablishedIn);
			objCommand.Parameters.AddWithValue("@Institute_AffiliatedTo", objInstitute.strAffiliatedTo);
			objCommand.Parameters.AddWithValue("@Institute_ContactDetails", objInstitute.strContactDetails);
			objCommand.Parameters.AddWithValue("@Institute_Placements", objInstitute.strPlacements);
			objCommand.Parameters.AddWithValue("@Institute_Admissions", objInstitute.strAdmissions);
			objCommand.Parameters.AddWithValue("@Institute_Facilities", objInstitute.strFacilities);
			objCommand.Parameters.AddWithValue("@Institute_Website", objInstitute.strWebsite);
			objCommand.Parameters.AddWithValue("@Institute_Featured", objInstitute.bFeatured);
			objCommand.Parameters.AddWithValue("@Institute_Photo", objInstitute.strPhoto);

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

	public string fn_editInstitute(InstituteClass objInstitute)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Institutes SET Institute_CityID=@Institute_CityID, Institute_Title=@Institute_Title, Institute_Desc=@Institute_Desc, Institute_EstablishedIn=@Institute_EstablishedIn, Institute_AffiliatedTo=@Institute_AffiliatedTo, Institute_ContactDetails=@Institute_ContactDetails, Institute_Placements=@Institute_Placements, Institute_Admissions=@Institute_Admissions, Institute_Facilities=@Institute_Facilities, Institute_Website=@Institute_Website, Institute_Featured=@Institute_Featured, Institute_Photo=@Institute_Photo WHERE Institute_ID=@Institute_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Institute_ID", objInstitute.iID);
			objCommand.Parameters.AddWithValue("@Institute_CityID", objInstitute.iCityID);
			objCommand.Parameters.AddWithValue("@Institute_Title", objInstitute.strTitle);
			objCommand.Parameters.AddWithValue("@Institute_Desc", objInstitute.strDesc);
			objCommand.Parameters.AddWithValue("@Institute_EstablishedIn", objInstitute.strEstablishedIn);
			objCommand.Parameters.AddWithValue("@Institute_AffiliatedTo", objInstitute.strAffiliatedTo);
			objCommand.Parameters.AddWithValue("@Institute_ContactDetails", objInstitute.strContactDetails);
			objCommand.Parameters.AddWithValue("@Institute_Placements", objInstitute.strPlacements);
			objCommand.Parameters.AddWithValue("@Institute_Admissions", objInstitute.strAdmissions);
			objCommand.Parameters.AddWithValue("@Institute_Facilities", objInstitute.strFacilities);
			objCommand.Parameters.AddWithValue("@Institute_Website", objInstitute.strWebsite);
			objCommand.Parameters.AddWithValue("@Institute_Featured", objInstitute.bFeatured);
			objCommand.Parameters.AddWithValue("@Institute_Photo", objInstitute.strPhoto);

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

	public string fn_deleteInstitute(int iInstituteID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Institutes WHERE Institute_ID=@Institute_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Institute_ID", iInstituteID);

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

	public CoreWebList<InstituteClass> fn_getInstituteList()
	{
		CoreWebList<InstituteClass> objInstituteList = null;
		InstituteClass objInstitute = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Institutes ORDER BY Institute_Featured DESC, Institute_Title ASC", objConnection);
			objReader = objCommand.ExecuteReader();
			objInstituteList = new CoreWebList<InstituteClass>();
			while (objReader.Read())
			{
				objInstitute = new InstituteClass();
				objInstitute.iID = int.Parse(objReader["Institute_ID"].ToString());
				objInstitute.iCityID = int.Parse(objReader["Institute_CityID"].ToString());
				objInstitute.strTitle = objReader["Institute_Title"].ToString();
				objInstitute.strDesc = objReader["Institute_Desc"].ToString();
				objInstitute.strEstablishedIn = objReader["Institute_EstablishedIn"].ToString();
				objInstitute.strAffiliatedTo = objReader["Institute_AffiliatedTo"].ToString();
				objInstitute.strContactDetails = objReader["Institute_ContactDetails"].ToString();
				objInstitute.strPlacements = objReader["Institute_Placements"].ToString();
				objInstitute.strAdmissions = objReader["Institute_Admissions"].ToString();
				objInstitute.strFacilities = objReader["Institute_Facilities"].ToString();
				objInstitute.strWebsite = objReader["Institute_Website"].ToString();
				objInstitute.bFeatured = bool.Parse(objReader["Institute_Featured"].ToString());
                objInstitute.bHomeFeatured = bool.Parse(objReader["Institute_HomeFeatured"].ToString());
				objInstitute.strPhoto = objReader["Institute_Photo"].ToString();
				objInstituteList.Add(objInstitute);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteList;
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

    public CoreWebList<InstituteClass> fn_getHomeFeaturedInstituteList()
    {
        CoreWebList<InstituteClass> objInstituteList = null;
        InstituteClass objInstitute = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Institutes WHERE Institute_HomeFeatured='true' ORDER BY Institute_Title ASC", objConnection);
            objReader = objCommand.ExecuteReader();
            objInstituteList = new CoreWebList<InstituteClass>();
            while (objReader.Read())
            {
                objInstitute = new InstituteClass();
                objInstitute.iID = int.Parse(objReader["Institute_ID"].ToString());
                objInstitute.iCityID = int.Parse(objReader["Institute_CityID"].ToString());
                objInstitute.strTitle = objReader["Institute_Title"].ToString();
                objInstitute.strDesc = objReader["Institute_Desc"].ToString();
                objInstitute.strEstablishedIn = objReader["Institute_EstablishedIn"].ToString();
                objInstitute.strAffiliatedTo = objReader["Institute_AffiliatedTo"].ToString();
                objInstitute.strContactDetails = objReader["Institute_ContactDetails"].ToString();
                objInstitute.strPlacements = objReader["Institute_Placements"].ToString();
                objInstitute.strAdmissions = objReader["Institute_Admissions"].ToString();
                objInstitute.strFacilities = objReader["Institute_Facilities"].ToString();
                objInstitute.strWebsite = objReader["Institute_Website"].ToString();
                objInstitute.bFeatured = bool.Parse(objReader["Institute_Featured"].ToString());
                objInstitute.bHomeFeatured = bool.Parse(objReader["Institute_HomeFeatured"].ToString());
                objInstitute.strPhoto = objReader["Institute_Photo"].ToString();
                objInstituteList.Add(objInstitute);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteList;
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

    public CoreWebList<InstituteClass> fn_SearchByQuery(string strQuery)
    {
        CoreWebList<InstituteClass> objInstituteList = null;
        InstituteClass objInstitute = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();
            objInstituteList = new CoreWebList<InstituteClass>();
            while (objReader.Read())
            {
                objInstitute = new InstituteClass();
                objInstitute.iID = int.Parse(objReader["Institute_ID"].ToString());
                objInstitute.iCityID = int.Parse(objReader["Institute_CityID"].ToString());
                objInstitute.strTitle = objReader["Institute_Title"].ToString();
                objInstitute.strDesc = objReader["Institute_Desc"].ToString();
                objInstitute.strEstablishedIn = objReader["Institute_EstablishedIn"].ToString();
                objInstitute.strAffiliatedTo = objReader["Institute_AffiliatedTo"].ToString();
                objInstitute.strContactDetails = objReader["Institute_ContactDetails"].ToString();
                objInstitute.strPlacements = objReader["Institute_Placements"].ToString();
                objInstitute.strAdmissions = objReader["Institute_Admissions"].ToString();
                objInstitute.strFacilities = objReader["Institute_Facilities"].ToString();
                objInstitute.strWebsite = objReader["Institute_Website"].ToString();
                objInstitute.bFeatured = bool.Parse(objReader["Institute_Featured"].ToString());
                objInstitute.bHomeFeatured = bool.Parse(objReader["Institute_HomeFeatured"].ToString());
                objInstitute.strPhoto = objReader["Institute_Photo"].ToString();
                objInstituteList.Add(objInstitute);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteList;
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

    public CoreWebList<InstituteClass> fn_getInstituteListByQuery(string strQuery)
    {
        CoreWebList<InstituteClass> objInstituteList = null;
        InstituteClass objInstitute = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();
            objInstituteList = new CoreWebList<InstituteClass>();
            while (objReader.Read())
            {
                objInstitute = new InstituteClass();
                objInstitute.iID = int.Parse(objReader["Institute_ID"].ToString());
                objInstitute.strTitle = objReader["Institute_Title"].ToString();
                objInstituteList.Add(objInstitute);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteList;
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

	public CoreWebList<InstituteClass> fn_getInstituteByID(int iInstituteID)
	{
		CoreWebList<InstituteClass> objInstituteList = null;
		InstituteClass objInstitute = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT City_Title FROM tbl_City cty WHERE cty.City_ID=inst.Institute_CityID)Institute_City, * FROM tbl_Institutes inst WHERE inst.Institute_ID=@Institute_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Institute_ID", iInstituteID);
			objReader = objCommand.ExecuteReader();
			objInstituteList = new CoreWebList<InstituteClass>();
			if (objReader.Read())
			{
				objInstitute = new InstituteClass();
				objInstitute.iID = int.Parse(objReader["Institute_ID"].ToString());
				objInstitute.iCityID = int.Parse(objReader["Institute_CityID"].ToString());
                objInstitute.strCity = objReader["Institute_City"].ToString();
                objInstitute.strTitle = objReader["Institute_Title"].ToString();
				objInstitute.strDesc = objReader["Institute_Desc"].ToString();
				objInstitute.strEstablishedIn = objReader["Institute_EstablishedIn"].ToString();
				objInstitute.strAffiliatedTo = objReader["Institute_AffiliatedTo"].ToString();
				objInstitute.strContactDetails = objReader["Institute_ContactDetails"].ToString();
				objInstitute.strPlacements = objReader["Institute_Placements"].ToString();
				objInstitute.strAdmissions = objReader["Institute_Admissions"].ToString();
				objInstitute.strFacilities = objReader["Institute_Facilities"].ToString();
				objInstitute.strWebsite = objReader["Institute_Website"].ToString();
				objInstitute.bFeatured = bool.Parse(objReader["Institute_Featured"].ToString());
                objInstitute.bHomeFeatured = bool.Parse(objReader["Institute_HomeFeatured"].ToString());
				objInstitute.strPhoto = objReader["Institute_Photo"].ToString();
				objInstituteList.Add(objInstitute);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteList;
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

    public CoreWebList<InstituteClass> fn_getInstituteByIdentity(string strIdentity, int iCategoryID)
    {
        CoreWebList<InstituteClass> objInstituteList = null;
        InstituteClass objInstitute = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT City_Title FROM tbl_City cty WHERE cty.City_ID=inst.Institute_CityID)Institute_City, *,  (SELECT ISNULL(MAX(CategoryRank_Rank), 999) FROM dbo.tbl_CategoryRankings rnk WHERE CategoryRank_CategoryID=@CategoryRank_CategoryID AND rnk.CategoryRank_InstituteID=inst.Institute_ID) AS Rankings FROM tbl_Institutes inst WHERE inst.Institute_ID IN (" + strIdentity + ") ORDER BY Institute_Featured DESC, Rankings ASC", objConnection);
            objCommand.Parameters.AddWithValue("@CategoryRank_CategoryID", iCategoryID);
            objReader = objCommand.ExecuteReader();
            objInstituteList = new CoreWebList<InstituteClass>();
            while (objReader.Read())
            {
                objInstitute = new InstituteClass();
                objInstitute.iID = int.Parse(objReader["Institute_ID"].ToString());
                objInstitute.iCityID = int.Parse(objReader["Institute_CityID"].ToString());
                objInstitute.strCity = objReader["Institute_City"].ToString();
                objInstitute.strTitle = objReader["Institute_Title"].ToString();
                objInstitute.strDesc = objReader["Institute_Desc"].ToString();
                objInstitute.strEstablishedIn = objReader["Institute_EstablishedIn"].ToString();
                objInstitute.strAffiliatedTo = objReader["Institute_AffiliatedTo"].ToString();
                objInstitute.strContactDetails = objReader["Institute_ContactDetails"].ToString();
                objInstitute.strPlacements = objReader["Institute_Placements"].ToString();
                objInstitute.strAdmissions = objReader["Institute_Admissions"].ToString();
                objInstitute.strFacilities = objReader["Institute_Facilities"].ToString();
                objInstitute.strWebsite = objReader["Institute_Website"].ToString();
                objInstitute.bFeatured = bool.Parse(objReader["Institute_Featured"].ToString());
                objInstitute.bHomeFeatured = bool.Parse(objReader["Institute_HomeFeatured"].ToString());
                objInstitute.strPhoto = objReader["Institute_Photo"].ToString();
                objInstituteList.Add(objInstitute);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteList;
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

    public CoreWebList<InstituteClass> fn_getInstituteByEntranceExamID(int iEntranceExamID)
    {
        CoreWebList<InstituteClass> objInstituteList = null;
        InstituteClass objInstitute = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT City_Title FROM tbl_City cty WHERE cty.City_ID=inst.Institute_CityID)Institute_City, * FROM tbl_Institutes inst WHERE inst.Institute_ID IN (SELECT EntranceColleges_CollegeID FROM tbl_EntranceColleges WHERE EntranceColleges_ExamID=@EntranceColleges_ExamID)", objConnection);
            objCommand.Parameters.AddWithValue("@EntranceColleges_ExamID", iEntranceExamID);
            objReader = objCommand.ExecuteReader();
            objInstituteList = new CoreWebList<InstituteClass>();
            while (objReader.Read())
            {
                objInstitute = new InstituteClass();
                objInstitute.iID = int.Parse(objReader["Institute_ID"].ToString());
                objInstitute.iCityID = int.Parse(objReader["Institute_CityID"].ToString());
                objInstitute.strCity = objReader["Institute_City"].ToString();
                objInstitute.strTitle = objReader["Institute_Title"].ToString();
                objInstitute.strDesc = objReader["Institute_Desc"].ToString();
                objInstitute.strEstablishedIn = objReader["Institute_EstablishedIn"].ToString();
                objInstitute.strAffiliatedTo = objReader["Institute_AffiliatedTo"].ToString();
                objInstitute.strContactDetails = objReader["Institute_ContactDetails"].ToString();
                objInstitute.strPlacements = objReader["Institute_Placements"].ToString();
                objInstitute.strAdmissions = objReader["Institute_Admissions"].ToString();
                objInstitute.strFacilities = objReader["Institute_Facilities"].ToString();
                objInstitute.strWebsite = objReader["Institute_Website"].ToString();
                objInstitute.bFeatured = bool.Parse(objReader["Institute_Featured"].ToString());
                objInstitute.bHomeFeatured = bool.Parse(objReader["Institute_HomeFeatured"].ToString());
                objInstitute.strPhoto = objReader["Institute_Photo"].ToString();
                objInstituteList.Add(objInstitute);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteList;
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

	public CoreWebList<InstituteClass> fn_getInstituteByName(string strInstituteTitle)
	{
		CoreWebList<InstituteClass> objInstituteList = null;
		InstituteClass objInstitute = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Institutes WHERE Institute_Title=@Institute_Title", objConnection);
			objCommand.Parameters.AddWithValue("@Institute_Title", strInstituteTitle);
			objReader = objCommand.ExecuteReader();
			objInstituteList = new CoreWebList<InstituteClass>();
			if (objReader.Read())
			{
				objInstitute = new InstituteClass();
				objInstitute.iID = int.Parse(objReader["Institute_ID"].ToString());
				objInstitute.iCityID = int.Parse(objReader["Institute_CityID"].ToString());
				objInstitute.strTitle = objReader["Institute_Title"].ToString();
				objInstitute.strDesc = objReader["Institute_Desc"].ToString();
				objInstitute.strEstablishedIn = objReader["Institute_EstablishedIn"].ToString();
				objInstitute.strAffiliatedTo = objReader["Institute_AffiliatedTo"].ToString();
				objInstitute.strContactDetails = objReader["Institute_ContactDetails"].ToString();
				objInstitute.strPlacements = objReader["Institute_Placements"].ToString();
				objInstitute.strAdmissions = objReader["Institute_Admissions"].ToString();
				objInstitute.strFacilities = objReader["Institute_Facilities"].ToString();
				objInstitute.strWebsite = objReader["Institute_Website"].ToString();
				objInstitute.bFeatured = bool.Parse(objReader["Institute_Featured"].ToString());
                objInstitute.bHomeFeatured = bool.Parse(objReader["Institute_HomeFeatured"].ToString());
				objInstitute.strPhoto = objReader["Institute_Photo"].ToString();
				objInstituteList.Add(objInstitute);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteList;
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

	public CoreWebList<InstituteClass> fn_getInstituteByKeys(string strInstituteTitle)
	{
		CoreWebList<InstituteClass> objInstituteList = null;
		InstituteClass objInstitute = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Institutes WHERE Institute_Title like '%' + @Institute_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Institute_Title", strInstituteTitle);
			objReader = objCommand.ExecuteReader();
			objInstituteList = new CoreWebList<InstituteClass>();
			while (objReader.Read())
			{
				objInstitute = new InstituteClass();
				objInstitute.iID = int.Parse(objReader["Institute_ID"].ToString());
				objInstitute.iCityID = int.Parse(objReader["Institute_CityID"].ToString());
				objInstitute.strTitle = objReader["Institute_Title"].ToString();
				objInstitute.strDesc = objReader["Institute_Desc"].ToString();
				objInstitute.strEstablishedIn = objReader["Institute_EstablishedIn"].ToString();
				objInstitute.strAffiliatedTo = objReader["Institute_AffiliatedTo"].ToString();
				objInstitute.strContactDetails = objReader["Institute_ContactDetails"].ToString();
				objInstitute.strPlacements = objReader["Institute_Placements"].ToString();
				objInstitute.strAdmissions = objReader["Institute_Admissions"].ToString();
				objInstitute.strFacilities = objReader["Institute_Facilities"].ToString();
				objInstitute.strWebsite = objReader["Institute_Website"].ToString();
				objInstitute.bFeatured = bool.Parse(objReader["Institute_Featured"].ToString());
                objInstitute.bHomeFeatured = bool.Parse(objReader["Institute_HomeFeatured"].ToString());
				objInstitute.strPhoto = objReader["Institute_Photo"].ToString();
				objInstituteList.Add(objInstitute);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteList;
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

    public CoreWebList<InstituteClass> fn_getInstituteByCityID(int iCityID)
    {
        CoreWebList<InstituteClass> objInstituteList = null;
        InstituteClass objInstitute = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Institutes WHERE Institute_CityID=@Institute_CityID ORDER BY Institute_Title ASC", objConnection);
            objCommand.Parameters.AddWithValue("@Institute_CityID", iCityID);
            objReader = objCommand.ExecuteReader();
            objInstituteList = new CoreWebList<InstituteClass>();
            while (objReader.Read())
            {
                objInstitute = new InstituteClass();
                objInstitute.iID = int.Parse(objReader["Institute_ID"].ToString());
                objInstitute.iCityID = int.Parse(objReader["Institute_CityID"].ToString());
                objInstitute.strTitle = objReader["Institute_Title"].ToString();
                objInstitute.strDesc = objReader["Institute_Desc"].ToString();
                objInstitute.strEstablishedIn = objReader["Institute_EstablishedIn"].ToString();
                objInstitute.strAffiliatedTo = objReader["Institute_AffiliatedTo"].ToString();
                objInstitute.strContactDetails = objReader["Institute_ContactDetails"].ToString();
                objInstitute.strPlacements = objReader["Institute_Placements"].ToString();
                objInstitute.strAdmissions = objReader["Institute_Admissions"].ToString();
                objInstitute.strFacilities = objReader["Institute_Facilities"].ToString();
                objInstitute.strWebsite = objReader["Institute_Website"].ToString();
                objInstitute.bFeatured = bool.Parse(objReader["Institute_Featured"].ToString());
                objInstitute.bHomeFeatured = bool.Parse(objReader["Institute_HomeFeatured"].ToString());
                objInstitute.strPhoto = objReader["Institute_Photo"].ToString();
                objInstituteList.Add(objInstitute);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteList;
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

    public CoreWebList<InstituteClass> fn_getInstituteByCategoryIDCityID(int iCategoryID, int iCityID)
    {
        CoreWebList<InstituteClass> objInstituteList = null;
        InstituteClass objInstitute = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT Inst.* FROM tbl_Institutes Inst join edu_InstituteCategoryList Cat on Inst.Institute_ID=Cat.instituteCategoryList_instituteID WHERE Inst.Institute_CityID=@Institute_CityID AND Cat.instituteCategoryList_catID=@instituteCategoryList_catID ORDER BY Institute_Title ASC", objConnection);
            objCommand.Parameters.AddWithValue("@Institute_CityID", iCityID);
            objCommand.Parameters.AddWithValue("@instituteCategoryList_catID", iCategoryID);
            objReader = objCommand.ExecuteReader();
            objInstituteList = new CoreWebList<InstituteClass>();
            while (objReader.Read())
            {
                objInstitute = new InstituteClass();
                objInstitute.iID = int.Parse(objReader["Institute_ID"].ToString());
                objInstitute.iCityID = int.Parse(objReader["Institute_CityID"].ToString());
                objInstitute.strTitle = objReader["Institute_Title"].ToString();
                objInstitute.strDesc = objReader["Institute_Desc"].ToString();
                objInstitute.strEstablishedIn = objReader["Institute_EstablishedIn"].ToString();
                objInstitute.strAffiliatedTo = objReader["Institute_AffiliatedTo"].ToString();
                objInstitute.strContactDetails = objReader["Institute_ContactDetails"].ToString();
                objInstitute.strPlacements = objReader["Institute_Placements"].ToString();
                objInstitute.strAdmissions = objReader["Institute_Admissions"].ToString();
                objInstitute.strFacilities = objReader["Institute_Facilities"].ToString();
                objInstitute.strWebsite = objReader["Institute_Website"].ToString();
                objInstitute.bFeatured = bool.Parse(objReader["Institute_Featured"].ToString());
                objInstitute.bHomeFeatured = bool.Parse(objReader["Institute_HomeFeatured"].ToString());
                objInstitute.strPhoto = objReader["Institute_Photo"].ToString();
                objInstituteList.Add(objInstitute);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteList;
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

    public CoreWebList<InstituteClass> fn_getRandomInstituteByCityID(int iCityID)
    {
        CoreWebList<InstituteClass> objInstituteList = null;
        InstituteClass objInstitute = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 5 * FROM tbl_Institutes WHERE Institute_CityID=@Institute_CityID ORDER BY NEWID()", objConnection);
            objCommand.Parameters.AddWithValue("@Institute_CityID", iCityID);
            objReader = objCommand.ExecuteReader();
            objInstituteList = new CoreWebList<InstituteClass>();
            while (objReader.Read())
            {
                objInstitute = new InstituteClass();
                objInstitute.iID = int.Parse(objReader["Institute_ID"].ToString());
                objInstitute.iCityID = int.Parse(objReader["Institute_CityID"].ToString());
                objInstitute.strTitle = objReader["Institute_Title"].ToString();
                objInstitute.strDesc = objReader["Institute_Desc"].ToString();
                objInstitute.strEstablishedIn = objReader["Institute_EstablishedIn"].ToString();
                objInstitute.strAffiliatedTo = objReader["Institute_AffiliatedTo"].ToString();
                objInstitute.strContactDetails = objReader["Institute_ContactDetails"].ToString();
                objInstitute.strPlacements = objReader["Institute_Placements"].ToString();
                objInstitute.strAdmissions = objReader["Institute_Admissions"].ToString();
                objInstitute.strFacilities = objReader["Institute_Facilities"].ToString();
                objInstitute.strWebsite = objReader["Institute_Website"].ToString();
                objInstitute.bFeatured = bool.Parse(objReader["Institute_Featured"].ToString());
                objInstitute.bHomeFeatured = bool.Parse(objReader["Institute_HomeFeatured"].ToString());
                objInstitute.strPhoto = objReader["Institute_Photo"].ToString();
                objInstituteList.Add(objInstitute);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteList;
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

    public CoreWebList<InstituteClass> fn_getRandomInstituteList()
    {
        CoreWebList<InstituteClass> objInstituteList = null;
        InstituteClass objInstitute = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 6 * FROM tbl_Institutes ORDER BY NEWID()", objConnection);
            objReader = objCommand.ExecuteReader();
            objInstituteList = new CoreWebList<InstituteClass>();
            while (objReader.Read())
            {
                objInstitute = new InstituteClass();
                objInstitute.iID = int.Parse(objReader["Institute_ID"].ToString());
                objInstitute.iCityID = int.Parse(objReader["Institute_CityID"].ToString());
                objInstitute.strTitle = objReader["Institute_Title"].ToString();
                objInstitute.strDesc = objReader["Institute_Desc"].ToString();
                objInstitute.strEstablishedIn = objReader["Institute_EstablishedIn"].ToString();
                objInstitute.strAffiliatedTo = objReader["Institute_AffiliatedTo"].ToString();
                objInstitute.strContactDetails = objReader["Institute_ContactDetails"].ToString();
                objInstitute.strPlacements = objReader["Institute_Placements"].ToString();
                objInstitute.strAdmissions = objReader["Institute_Admissions"].ToString();
                objInstitute.strFacilities = objReader["Institute_Facilities"].ToString();
                objInstitute.strWebsite = objReader["Institute_Website"].ToString();
                objInstitute.bFeatured = bool.Parse(objReader["Institute_Featured"].ToString());
                objInstitute.bHomeFeatured = bool.Parse(objReader["Institute_HomeFeatured"].ToString());
                objInstitute.strPhoto = objReader["Institute_Photo"].ToString();
                objInstituteList.Add(objInstitute);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteList;
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

    public CoreWebList<InstituteClass> fn_get_Random_InstituteList()
    {
        CoreWebList<InstituteClass> objInstituteList = null;
        InstituteClass objInstitute = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 5 * FROM tbl_Institutes ORDER BY NEWID()", objConnection);
            objReader = objCommand.ExecuteReader();
            objInstituteList = new CoreWebList<InstituteClass>();
            while (objReader.Read())
            {
                objInstitute = new InstituteClass();
                objInstitute.iID = int.Parse(objReader["Institute_ID"].ToString());
                objInstitute.iCityID = int.Parse(objReader["Institute_CityID"].ToString());
                objInstitute.strTitle = objReader["Institute_Title"].ToString();
                objInstitute.strDesc = objReader["Institute_Desc"].ToString();
                objInstitute.strEstablishedIn = objReader["Institute_EstablishedIn"].ToString();
                objInstitute.strAffiliatedTo = objReader["Institute_AffiliatedTo"].ToString();
                objInstitute.strContactDetails = objReader["Institute_ContactDetails"].ToString();
                objInstitute.strPlacements = objReader["Institute_Placements"].ToString();
                objInstitute.strAdmissions = objReader["Institute_Admissions"].ToString();
                objInstitute.strFacilities = objReader["Institute_Facilities"].ToString();
                objInstitute.strWebsite = objReader["Institute_Website"].ToString();
                objInstitute.bFeatured = bool.Parse(objReader["Institute_Featured"].ToString());
                objInstitute.bHomeFeatured = bool.Parse(objReader["Institute_HomeFeatured"].ToString());
                objInstitute.strPhoto = objReader["Institute_Photo"].ToString();
                objInstituteList.Add(objInstitute);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteList;
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

	public string fn_ChangeInstituteFeaturedStatus(InstituteClass objInstitute)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Institutes SET Institute_Featured=@Institute_Featured WHERE Institute_ID=@Institute_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("Institute_ID", objInstitute.iID);
			objCommand.Parameters.AddWithValue("Institute_Featured", objInstitute.bFeatured);

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

    public string fn_ChangeInstituteHomeFeaturedStatus(InstituteClass objInstitute)
    {
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_Institutes SET Institute_HomeFeatured=@Institute_HomeFeatured WHERE Institute_ID=@Institute_ID", objConnection);
            objCommand.Parameters.AddWithValue("Institute_ID", objInstitute.iID);
            objCommand.Parameters.AddWithValue("Institute_HomeFeatured", objInstitute.bHomeFeatured);

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
