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
/// Summary description for DBUniversityClass
/// </summary>
public class DBUniversityClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveUniversity(UniversityClass objUniversity)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_University (University_CountryID, University_Title, University_Details, University_EstablishedIn, University_AffiliatedTo, University_Admissions, University_Infrastructure, University_Placements, University_Ranking, University_ContactDetails, University_Email, University_Website, University_Logo, University_CeratedDate) VALUES (@University_CountryID, @University_Title, @University_Details, @University_EstablishedIn, @University_AffiliatedTo, @University_Admissions, @University_Infrastructure, @University_Placements, @University_Ranking, @University_ContactDetails, @University_Email, @University_Website, @University_Logo, @University_CeratedDate)", objConnection);

            objCommand.Parameters.AddWithValue("@University_CountryID", objUniversity.iCountryID);
            objCommand.Parameters.AddWithValue("@University_Title", objUniversity.strTitle);
			objCommand.Parameters.AddWithValue("@University_Details", objUniversity.strDetails);
			objCommand.Parameters.AddWithValue("@University_EstablishedIn", objUniversity.strEstablishedIn);
			objCommand.Parameters.AddWithValue("@University_AffiliatedTo", objUniversity.strAffiliatedTo);
			objCommand.Parameters.AddWithValue("@University_Admissions", objUniversity.strAdmissions);
			objCommand.Parameters.AddWithValue("@University_Infrastructure", objUniversity.strInfrastructure);
			objCommand.Parameters.AddWithValue("@University_Placements", objUniversity.strPlacements);
			objCommand.Parameters.AddWithValue("@University_Ranking", objUniversity.strRanking);
			objCommand.Parameters.AddWithValue("@University_ContactDetails", objUniversity.strContactDetails);
			objCommand.Parameters.AddWithValue("@University_Email", objUniversity.strEmail);
			objCommand.Parameters.AddWithValue("@University_Website", objUniversity.strWebsite);
			objCommand.Parameters.AddWithValue("@University_Logo", objUniversity.strLogo);
			objCommand.Parameters.AddWithValue("@University_CeratedDate", objUniversity.dtCeratedDate);

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

	public string fn_editUniversity(UniversityClass objUniversity)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_University SET University_Title=@University_Title, University_Details=@University_Details, University_EstablishedIn=@University_EstablishedIn, University_AffiliatedTo=@University_AffiliatedTo, University_Admissions=@University_Admissions, University_Infrastructure=@University_Infrastructure, University_Placements=@University_Placements, University_Ranking=@University_Ranking, University_ContactDetails=@University_ContactDetails, University_Email=@University_Email, University_Website=@University_Website, University_Logo=@University_Logo, University_CeratedDate=@University_CeratedDate WHERE University_ID=@University_ID",objConnection) ;

            objCommand.Parameters.AddWithValue("@University_ID", objUniversity.iID);
            objCommand.Parameters.AddWithValue("@University_Title", objUniversity.strTitle);
            objCommand.Parameters.AddWithValue("@University_Details", objUniversity.strDetails);
            objCommand.Parameters.AddWithValue("@University_EstablishedIn", objUniversity.strEstablishedIn);
            objCommand.Parameters.AddWithValue("@University_AffiliatedTo", objUniversity.strAffiliatedTo);
            objCommand.Parameters.AddWithValue("@University_Admissions", objUniversity.strAdmissions);
            objCommand.Parameters.AddWithValue("@University_Infrastructure", objUniversity.strInfrastructure);
            objCommand.Parameters.AddWithValue("@University_Placements", objUniversity.strPlacements);
            objCommand.Parameters.AddWithValue("@University_Ranking", objUniversity.strRanking);
            objCommand.Parameters.AddWithValue("@University_ContactDetails", objUniversity.strContactDetails);
            objCommand.Parameters.AddWithValue("@University_Email", objUniversity.strEmail);
            objCommand.Parameters.AddWithValue("@University_Website", objUniversity.strWebsite);
            objCommand.Parameters.AddWithValue("@University_Logo", objUniversity.strLogo);
            objCommand.Parameters.AddWithValue("@University_CeratedDate", objUniversity.dtCeratedDate);

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

	public string fn_deleteUniversity(int iUniversityID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_University WHERE University_ID=@University_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@University_ID", iUniversityID);

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

	public CoreWebList<UniversityClass> fn_getUniversityList()
	{
		CoreWebList<UniversityClass> objUniversityList = null;
		UniversityClass objUniversity = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_University", objConnection);
			objReader = objCommand.ExecuteReader();
			objUniversityList = new CoreWebList<UniversityClass>();
			while (objReader.Read())
			{
				objUniversity = new UniversityClass();
				objUniversity.iID = int.Parse(objReader["University_ID"].ToString());
                objUniversity.iCountryID = int.Parse(objReader["University_CountryID"].ToString());
				objUniversity.strTitle = objReader["University_Title"].ToString();
				objUniversity.strDetails = objReader["University_Details"].ToString();
				objUniversity.strEstablishedIn = objReader["University_EstablishedIn"].ToString();
				objUniversity.strAffiliatedTo = objReader["University_AffiliatedTo"].ToString();
				objUniversity.strAdmissions = objReader["University_Admissions"].ToString();
				objUniversity.strInfrastructure = objReader["University_Infrastructure"].ToString();
				objUniversity.strPlacements = objReader["University_Placements"].ToString();
				objUniversity.strRanking = objReader["University_Ranking"].ToString();
				objUniversity.strContactDetails = objReader["University_ContactDetails"].ToString();
				objUniversity.strEmail = objReader["University_Email"].ToString();
				objUniversity.strWebsite = objReader["University_Website"].ToString();
				objUniversity.strLogo = objReader["University_Logo"].ToString();
				objUniversity.dtCeratedDate = DateTime.Parse(objReader["University_CeratedDate"].ToString());
				objUniversityList.Add(objUniversity);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objUniversityList;
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

	public CoreWebList<UniversityClass> fn_getUniversityByID(int iUniversityID)
	{
		CoreWebList<UniversityClass> objUniversityList = null;
		UniversityClass objUniversity = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_University WHERE University_ID=@University_ID", objConnection);
			objCommand.Parameters.AddWithValue("@University_ID", iUniversityID);
			objReader = objCommand.ExecuteReader();
			objUniversityList = new CoreWebList<UniversityClass>();
			if (objReader.Read())
			{
				objUniversity = new UniversityClass();
				objUniversity.iID = int.Parse(objReader["University_ID"].ToString());
                objUniversity.iCountryID = int.Parse(objReader["University_CountryID"].ToString());
				objUniversity.strTitle = objReader["University_Title"].ToString();
				objUniversity.strDetails = objReader["University_Details"].ToString();
				objUniversity.strEstablishedIn = objReader["University_EstablishedIn"].ToString();
				objUniversity.strAffiliatedTo = objReader["University_AffiliatedTo"].ToString();
				objUniversity.strAdmissions = objReader["University_Admissions"].ToString();
				objUniversity.strInfrastructure = objReader["University_Infrastructure"].ToString();
				objUniversity.strPlacements = objReader["University_Placements"].ToString();
				objUniversity.strRanking = objReader["University_Ranking"].ToString();
				objUniversity.strContactDetails = objReader["University_ContactDetails"].ToString();
				objUniversity.strEmail = objReader["University_Email"].ToString();
				objUniversity.strWebsite = objReader["University_Website"].ToString();
				objUniversity.strLogo = objReader["University_Logo"].ToString();
				objUniversity.dtCeratedDate = DateTime.Parse(objReader["University_CeratedDate"].ToString());
				objUniversityList.Add(objUniversity);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objUniversityList;
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

    public CoreWebList<UniversityClass> fn_getUniversityByCountryID(int iCountryID)
    {
        CoreWebList<UniversityClass> objUniversityList = null;
        UniversityClass objUniversity = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_University WHERE University_CountryID=@University_CountryID", objConnection);
            objCommand.Parameters.AddWithValue("@University_CountryID", iCountryID);
            objReader = objCommand.ExecuteReader();
            objUniversityList = new CoreWebList<UniversityClass>();
            while (objReader.Read())
            {
                objUniversity = new UniversityClass();
                objUniversity.iID = int.Parse(objReader["University_ID"].ToString());
                objUniversity.iCountryID = int.Parse(objReader["University_CountryID"].ToString());
                objUniversity.strTitle = objReader["University_Title"].ToString();
                objUniversity.strDetails = objReader["University_Details"].ToString();
                objUniversity.strEstablishedIn = objReader["University_EstablishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["University_AffiliatedTo"].ToString();
                objUniversity.strAdmissions = objReader["University_Admissions"].ToString();
                objUniversity.strInfrastructure = objReader["University_Infrastructure"].ToString();
                objUniversity.strPlacements = objReader["University_Placements"].ToString();
                objUniversity.strRanking = objReader["University_Ranking"].ToString();
                objUniversity.strContactDetails = objReader["University_ContactDetails"].ToString();
                objUniversity.strEmail = objReader["University_Email"].ToString();
                objUniversity.strWebsite = objReader["University_Website"].ToString();
                objUniversity.strLogo = objReader["University_Logo"].ToString();
                objUniversity.dtCeratedDate = DateTime.Parse(objReader["University_CeratedDate"].ToString());
                objUniversityList.Add(objUniversity);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objUniversityList;
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

	public CoreWebList<UniversityClass> fn_getUniversityByName(string strUniversityTitle)
	{
		CoreWebList<UniversityClass> objUniversityList = null;
		UniversityClass objUniversity = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_University WHERE University_Title=@University_Title", objConnection);
			objCommand.Parameters.AddWithValue("@University_Title", strUniversityTitle);
			objReader = objCommand.ExecuteReader();
			objUniversityList = new CoreWebList<UniversityClass>();
			if (objReader.Read())
			{
				objUniversity = new UniversityClass();
				objUniversity.iID = int.Parse(objReader["University_ID"].ToString());
                objUniversity.iCountryID = int.Parse(objReader["University_CountryID"].ToString());
				objUniversity.strTitle = objReader["University_Title"].ToString();
				objUniversity.strDetails = objReader["University_Details"].ToString();
				objUniversity.strEstablishedIn = objReader["University_EstablishedIn"].ToString();
				objUniversity.strAffiliatedTo = objReader["University_AffiliatedTo"].ToString();
				objUniversity.strAdmissions = objReader["University_Admissions"].ToString();
				objUniversity.strInfrastructure = objReader["University_Infrastructure"].ToString();
				objUniversity.strPlacements = objReader["University_Placements"].ToString();
				objUniversity.strRanking = objReader["University_Ranking"].ToString();
				objUniversity.strContactDetails = objReader["University_ContactDetails"].ToString();
				objUniversity.strEmail = objReader["University_Email"].ToString();
				objUniversity.strWebsite = objReader["University_Website"].ToString();
				objUniversity.strLogo = objReader["University_Logo"].ToString();
				objUniversity.dtCeratedDate = DateTime.Parse(objReader["University_CeratedDate"].ToString());
				objUniversityList.Add(objUniversity);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objUniversityList;
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

	public CoreWebList<UniversityClass> fn_getUniversityByKeys(string strUniversityTitle)
	{
		CoreWebList<UniversityClass> objUniversityList = null;
		UniversityClass objUniversity = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_University WHERE University_Title like '%' + @University_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@University_Title", strUniversityTitle);
			objReader = objCommand.ExecuteReader();
			objUniversityList = new CoreWebList<UniversityClass>();
			while (objReader.Read())
			{
				objUniversity = new UniversityClass();
				objUniversity.iID = int.Parse(objReader["University_ID"].ToString());
                objUniversity.iCountryID = int.Parse(objReader["University_CountryID"].ToString());
				objUniversity.strTitle = objReader["University_Title"].ToString();
				objUniversity.strDetails = objReader["University_Details"].ToString();
				objUniversity.strEstablishedIn = objReader["University_EstablishedIn"].ToString();
				objUniversity.strAffiliatedTo = objReader["University_AffiliatedTo"].ToString();
				objUniversity.strAdmissions = objReader["University_Admissions"].ToString();
				objUniversity.strInfrastructure = objReader["University_Infrastructure"].ToString();
				objUniversity.strPlacements = objReader["University_Placements"].ToString();
				objUniversity.strRanking = objReader["University_Ranking"].ToString();
				objUniversity.strContactDetails = objReader["University_ContactDetails"].ToString();
				objUniversity.strEmail = objReader["University_Email"].ToString();
				objUniversity.strWebsite = objReader["University_Website"].ToString();
				objUniversity.strLogo = objReader["University_Logo"].ToString();
				objUniversity.dtCeratedDate = DateTime.Parse(objReader["University_CeratedDate"].ToString());
				objUniversityList.Add(objUniversity);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objUniversityList;
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
