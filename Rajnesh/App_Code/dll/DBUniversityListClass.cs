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
using System.Collections;
using yo_lib;

/// <summary>
/// Summary description for DBUniversityListClass
/// </summary>
public class DBUniversityListClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;
    private SqlCommand objCommand1 = null;

    public string strDBError = null;

    internal string fn_saveUniversityList(int iCatID, int iSubCatID, int iTypeID, string strTitle, string strDesc, string strAddress, string strCountry, string strState, string strCity, string strPinCode, string strPhone, string strFax, string strEmail, string strWebsite, string strImage, bool bFeatured, string strEstablishedIn, string strAffiliatedTo, int iRank, string strFileName, string strHeader1, string strHeader2, string strHeader3, string strMetaTitle, string strMetaDesc, string strMetaKeywords, string strKeywords, string strExamTimeTable, string strAdmissions, string strInfrastructure, string strResults)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_UniversityList(universityList_typeID,universityList_title,universityList_desc,universityList_examtimetable,universityList_address,universityList_city,universityList_email,universityList_website,universityList_image,universityList_featured,universityList_establishedIn,universityList_affiliatedTo, universityList_Rank, universityList_FileName, universityList_State, Header1, Header2, Header3, Meta_title, Meta_Description, Meta_Keywords, Keywords, universityList_admissions, universityList_infrastructure, universityList_results) VALUES (@TypeID,@Title,@Desc,@universityList_examtimetable,@Address,@City,@Email,@Website,@Image,@Featured,@EstablishedIn,@AffiliatedTo, @universityList_Rank, @universityList_FileName, @universityList_State, @Header1, @Header2, @Header3, @Meta_title, @Meta_Description, @Meta_Keywords, @Keywords, @universityList_admissions, @universityList_infrastructure, @universityList_results)", objConnection);

            objCommand.Parameters.AddWithValue("@TypeID", iTypeID);
            objCommand.Parameters.AddWithValue("@Title", strTitle);
            objCommand.Parameters.AddWithValue("@Desc", strDesc);
            objCommand.Parameters.AddWithValue("@universityList_examtimetable", strExamTimeTable);
            objCommand.Parameters.AddWithValue("@Address", strAddress);
            objCommand.Parameters.AddWithValue("@City", strCity);
            objCommand.Parameters.AddWithValue("@Email", strEmail);
            objCommand.Parameters.AddWithValue("@Website", strWebsite);
            objCommand.Parameters.AddWithValue("@Image", strImage);
            objCommand.Parameters.AddWithValue("@Featured", bFeatured);
            objCommand.Parameters.AddWithValue("@EstablishedIn", strEstablishedIn);
            objCommand.Parameters.AddWithValue("@AffiliatedTo", strAffiliatedTo);
            objCommand.Parameters.AddWithValue("@universityList_Rank", iRank);

            objCommand.Parameters.AddWithValue("@universityList_FileName", strFileName);
            objCommand.Parameters.AddWithValue("@universityList_State", strState);
            objCommand.Parameters.AddWithValue("@Header1", strHeader1);
            objCommand.Parameters.AddWithValue("@Header2", strHeader2);
            objCommand.Parameters.AddWithValue("@Header3", strHeader3);
            objCommand.Parameters.AddWithValue("@Meta_title", strMetaTitle);
            objCommand.Parameters.AddWithValue("@Meta_Description", strMetaDesc);
            objCommand.Parameters.AddWithValue("@Meta_Keywords", strMetaKeywords);
            objCommand.Parameters.AddWithValue("@Keywords", strKeywords);

            objCommand.Parameters.AddWithValue("@universityList_admissions", strAdmissions);
            objCommand.Parameters.AddWithValue("@universityList_infrastructure", strInfrastructure);
            objCommand.Parameters.AddWithValue("@universityList_results", strResults);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been inserted";
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

    internal string fn_editUniversityList(int iID, int iCatID, int iSubCatID, int iTypeID, string strTitle, string strDesc, string strAddress, string strCountry, string strState, string strCity, string strPinCode, string strPhone, string strFax, string strEmail, string strWebsite, string strImage, bool bFeatured, string strEstablishedIn, string strAffiliatedTo, int iRank, string strFileName, string strHeader1, string strHeader2, string strHeader3, string strMetaTitle, string strMetaDesc, string strMetaKeywords, string strKeywords, string strExamTimeTable, string strAdmissions, string strInfrastructure, string strResults)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_UniversityList SET  universityList_typeID = @TypeID,universityList_title = @Title ,universityList_desc = @Desc , universityList_examtimetable=@universityList_examtimetable, universityList_address = @Address ,universityList_city = @City ,universityList_email = @Email ,universityList_website = @Website ,universityList_image=@Image, universityList_featured=@Featured, universityList_establishedIn=@EstablishedIn, universityList_affiliatedTo=@AffiliatedTo, universityList_Rank=@universityList_Rank, universityList_FileName=@universityList_FileName, universityList_State=@universityList_State, Header1=@Header1, Header2=@Header2, Header3=@Header3, Meta_title=@Meta_title, Meta_Description=@Meta_Description, Meta_Keywords=@Meta_Keywords, Keywords=@Keywords, universityList_admissions=@universityList_admissions, universityList_infrastructure=@universityList_infrastructure, universityList_results=@universityList_results  WHERE universityList_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@TypeID", iTypeID);
            objCommand.Parameters.AddWithValue("@Title", strTitle);
            objCommand.Parameters.AddWithValue("@Desc", strDesc);
            objCommand.Parameters.AddWithValue("@universityList_examtimetable", strExamTimeTable);
            objCommand.Parameters.AddWithValue("@Address", strAddress);
            objCommand.Parameters.AddWithValue("@City", strCity);
            objCommand.Parameters.AddWithValue("@Email", strEmail);
            objCommand.Parameters.AddWithValue("@Website", strWebsite);
            objCommand.Parameters.AddWithValue("@Image", strImage);
            objCommand.Parameters.AddWithValue("@Featured", bFeatured);
            objCommand.Parameters.AddWithValue("@EstablishedIn", strEstablishedIn);
            objCommand.Parameters.AddWithValue("@AffiliatedTo", strAffiliatedTo);
            objCommand.Parameters.AddWithValue("@universityList_Rank", iRank);

            objCommand.Parameters.AddWithValue("@universityList_FileName", strFileName);
            objCommand.Parameters.AddWithValue("@universityList_State", strState);
            objCommand.Parameters.AddWithValue("@Header1", strHeader1);
            objCommand.Parameters.AddWithValue("@Header2", strHeader2);
            objCommand.Parameters.AddWithValue("@Header3", strHeader3);
            objCommand.Parameters.AddWithValue("@Meta_title", strMetaTitle);
            objCommand.Parameters.AddWithValue("@Meta_Description", strMetaDesc);
            objCommand.Parameters.AddWithValue("@Meta_Keywords", strMetaKeywords);
            objCommand.Parameters.AddWithValue("@Keywords", strKeywords);

            objCommand.Parameters.AddWithValue("@universityList_admissions", strAdmissions);
            objCommand.Parameters.AddWithValue("@universityList_infrastructure", strInfrastructure);
            objCommand.Parameters.AddWithValue("@universityList_results", strResults);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been updated";
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

    internal string fn_deleteUniversity(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_UniversityList WHERE universityList_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been deleted";
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

    internal CoreWebList<UniversityListClass> fn_getUniversityByID(int iID)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityList INNER JOIN edu_UniversityType ON edu_UniversityList.universityList_typeID = edu_UniversityType.universityType_id WHERE universityList_id = @ID ORDER BY universityList_title ASC", objConnection);
            
            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            if (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strExamTimeTable = objReader["universityList_examtimetable"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.bHomeFeatured = bool.Parse(objReader["universityList_HomeFeatured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();
                objUniversity.strTypeTitle = objReader["universityType_title"].ToString();

                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

                objUniversity.strAdmissions = objReader["universityList_admissions"].ToString();
                objUniversity.strInfrastructure = objReader["universityList_infrastructure"].ToString();
                objUniversity.strResults = objReader["universityList_results"].ToString();

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


    internal CoreWebList<UniversityListClass> fn_getUniversityByFileName(string strFileName)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityList INNER JOIN edu_UniversityType ON edu_UniversityList.universityList_typeID = edu_UniversityType.universityType_id WHERE universityList_FileName Like '%" + strFileName + "%'  ORDER BY universityList_title ASC", objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            if (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strExamTimeTable = objReader["universityList_examtimetable"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.bHomeFeatured = bool.Parse(objReader["universityList_HomeFeatured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();
                objUniversity.strTypeTitle = objReader["universityType_title"].ToString();

                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

                objUniversity.strAdmissions = objReader["universityList_admissions"].ToString();
                objUniversity.strInfrastructure = objReader["universityList_infrastructure"].ToString();
                objUniversity.strResults = objReader["universityList_results"].ToString();

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

    internal CoreWebList<UniversityListClass> fn_getUniversityByTitle(string strTitle)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityList INNER JOIN edu_UniversityType ON edu_UniversityList.universityList_typeID = edu_UniversityType.universityType_id WHERE universityList_title Like '%' + @universityList_title + '%'  ORDER BY universityList_title ASC", objConnection);
            objCommand.Parameters.AddWithValue("@universityList_title", strTitle);
            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            if (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strExamTimeTable = objReader["universityList_examtimetable"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.bHomeFeatured = bool.Parse(objReader["universityList_HomeFeatured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();
                objUniversity.strTypeTitle = objReader["universityType_title"].ToString();

                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

                objUniversity.strAdmissions = objReader["universityList_admissions"].ToString();
                objUniversity.strInfrastructure = objReader["universityList_infrastructure"].ToString();
                objUniversity.strResults = objReader["universityList_results"].ToString();

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

    internal CoreWebList<UniversityListClass> fn_getUniversityByName(string strTitle)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityList INNER JOIN edu_UniversityType ON edu_UniversityList.universityList_typeID = edu_UniversityType.universityType_id WHERE universityList_title=@universityList_title", objConnection);
            objCommand.Parameters.AddWithValue("@universityList_title", strTitle);
            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            if (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strExamTimeTable = objReader["universityList_examtimetable"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.bHomeFeatured = bool.Parse(objReader["universityList_HomeFeatured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();
                objUniversity.strTypeTitle = objReader["universityType_title"].ToString();

                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

                objUniversity.strAdmissions = objReader["universityList_admissions"].ToString();
                objUniversity.strInfrastructure = objReader["universityList_infrastructure"].ToString();
                objUniversity.strResults = objReader["universityList_results"].ToString();

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

    internal CoreWebList<UniversityListClass> fn_getUniversityByIdentities(string strIDs)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityList INNER JOIN edu_UniversityType ON edu_UniversityList.universityList_typeID = edu_UniversityType.universityType_id WHERE universityList_id IN(" + strIDs + ") ORDER BY universityList_featured DESC, universityList_Rank ASC", objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strExamTimeTable = objReader["universityList_examtimetable"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.bHomeFeatured = bool.Parse(objReader["universityList_HomeFeatured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();
                objUniversity.strTypeTitle = objReader["universityType_title"].ToString();
                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

                objUniversity.strAdmissions = objReader["universityList_admissions"].ToString();
                objUniversity.strInfrastructure = objReader["universityList_infrastructure"].ToString();
                objUniversity.strResults = objReader["universityList_results"].ToString();

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


    internal CoreWebList<UniversityListClass> fn_getUniversityListByCatID(int iCatID)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityList WHERE universityList_catID = @CatID ORDER BY universityList_title ASC", objConnection);
            
            objCommand.Parameters.AddWithValue("@CatID", iCatID);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            if (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strExamTimeTable = objReader["universityList_examtimetable"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.bHomeFeatured = bool.Parse(objReader["universityList_HomeFeatured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();
                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

                objUniversity.strAdmissions = objReader["universityList_admissions"].ToString();
                objUniversity.strInfrastructure = objReader["universityList_infrastructure"].ToString();
                objUniversity.strResults = objReader["universityList_results"].ToString();

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

    internal CoreWebList<UniversityListClass> fn_getUniversityListByIDs(string strIDs)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityList WHERE universityList_id IN (" + strIDs +") ORDER BY universityList_title ASC", objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while(objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strExamTimeTable = objReader["universityList_examtimetable"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.bHomeFeatured = bool.Parse(objReader["universityList_HomeFeatured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();
                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

                objUniversity.strAdmissions = objReader["universityList_admissions"].ToString();
                objUniversity.strInfrastructure = objReader["universityList_infrastructure"].ToString();
                objUniversity.strResults = objReader["universityList_results"].ToString();

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

    internal CoreWebList<UniversityListClass> fn_getUniversityListBySubCatID(int iSubCatID)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityList WHERE universityList_subCatID = @SubCatID ORDER BY universityList_title", objConnection);
            
            objCommand.Parameters.AddWithValue("@SubCatID", iSubCatID);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            if (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strExamTimeTable = objReader["universityList_examtimetable"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.bHomeFeatured = bool.Parse(objReader["universityList_HomeFeatured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();
                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

                objUniversity.strAdmissions = objReader["universityList_admissions"].ToString();
                objUniversity.strInfrastructure = objReader["universityList_infrastructure"].ToString();
                objUniversity.strResults = objReader["universityList_results"].ToString();

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

    internal CoreWebList<UniversityListClass> fn_getUniversityList()
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT edu_UniversityList.*, edu_UniversityType.universityType_title FROM edu_UniversityList INNER JOIN edu_UniversityType ON edu_UniversityList.universityList_typeID = edu_UniversityType.universityType_id ORDER BY universityList_featured DESC,universityList_title ASC", objConnection);
            
            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strExamTimeTable = objReader["universityList_examtimetable"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.bHomeFeatured = bool.Parse(objReader["universityList_HomeFeatured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();
                objUniversity.strTypeTitle = objReader["universityType_title"].ToString();

                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

                objUniversity.strAdmissions = objReader["universityList_admissions"].ToString();
                objUniversity.strInfrastructure = objReader["universityList_infrastructure"].ToString();
                objUniversity.strResults = objReader["universityList_results"].ToString();

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

    internal CoreWebList<UniversityListClass> fn_getHomeFeaturedUniversityList()
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT edu_UniversityList.*, edu_UniversityType.universityType_title FROM edu_UniversityList INNER JOIN edu_UniversityType ON edu_UniversityList.universityList_typeID = edu_UniversityType.universityType_id WHERE universityList_HomeFeatured='true' ORDER BY universityList_featured DESC,universityList_title ASC", objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strExamTimeTable = objReader["universityList_examtimetable"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.bHomeFeatured = bool.Parse(objReader["universityList_HomeFeatured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();
                objUniversity.strTypeTitle = objReader["universityType_title"].ToString();

                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

                objUniversity.strAdmissions = objReader["universityList_admissions"].ToString();
                objUniversity.strInfrastructure = objReader["universityList_infrastructure"].ToString();
                objUniversity.strResults = objReader["universityList_results"].ToString();

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

    internal CoreWebList<UniversityListClass> fn_getRandomUniversityList()
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 6 * FROM edu_UniversityList ORDER BY NEWID()", objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strExamTimeTable = objReader["universityList_examtimetable"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.bHomeFeatured = bool.Parse(objReader["universityList_HomeFeatured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();

                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

                objUniversity.strAdmissions = objReader["universityList_admissions"].ToString();
                objUniversity.strInfrastructure = objReader["universityList_infrastructure"].ToString();
                objUniversity.strResults = objReader["universityList_results"].ToString();

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

    internal CoreWebList<UniversityListClass> fn_get_Random_UniversityList()
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 5 * FROM edu_UniversityList ORDER BY NEWID()", objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strExamTimeTable = objReader["universityList_examtimetable"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.bHomeFeatured = bool.Parse(objReader["universityList_HomeFeatured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();

                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

                objUniversity.strAdmissions = objReader["universityList_admissions"].ToString();
                objUniversity.strInfrastructure = objReader["universityList_infrastructure"].ToString();
                objUniversity.strResults = objReader["universityList_results"].ToString();

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

    internal CoreWebList<UniversityListClass> fn_getUniversityListByQuery(string strQuery)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
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

    internal CoreWebList<UniversityListClass> fn_getUniversityListByRandom()
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 15 * FROM edu_UniversityList ORDER BY universityList_Rank ASC", objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.bHomeFeatured = bool.Parse(objReader["universityList_HomeFeatured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();

                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

                objUniversity.strAdmissions = objReader["universityList_admissions"].ToString();
                objUniversity.strInfrastructure = objReader["universityList_infrastructure"].ToString();
                objUniversity.strResults = objReader["universityList_results"].ToString();

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


    internal CoreWebList<UniversityListClass> fn_searchUniversityList(string strQuery)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand(strQuery, objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
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



    /*---------------------17/Aug/2010-----------------------------*/

    internal CoreWebList<UniversityListClass> fn_GetUniversityListByCity(string strCity)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityList WHERE universityList_city IN(" + strCity + ") ORDER BY universityList_Rank", objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();
                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();


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

    internal CoreWebList<UniversityListClass> fn_GetUniversityByCity(string strCity)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM edu_UniversityList WHERE universityList_city=@universityList_city ORDER BY universityList_title ASC", objConnection);
            objCommand.Parameters.AddWithValue("@universityList_city", strCity);
            objReader = objCommand.ExecuteReader();
            objUniversityList = new CoreWebList<UniversityListClass>();
            
            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();

                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();
                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();


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

    /*-------------------------------------------------------------*/



    // New Function for search 13/8/2010

    internal CoreWebList<UniversityListClass> fn_searchUniversityListinAdmin(string strQuery)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();
            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();
            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.strTypeTitle = objReader["universityType_title"].ToString();

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


    //


    //internal CoreWebList<UniversityListClass> fn_getUniversityListByCatID_And_SubCatID(int iCatID, int iSubCatID)
    //{
    //    CoreWebList<UniversityListClass> objUniversityList = null;
    //    UniversityListClass objUniversity = null;

    //    try
    //    {
    //        objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    //        objConnection.Open();

    //        objCommand = new SqlCommand("SELECT * FROM edu_UniversityCategory INNER JOIN edu_UniversityList ON edu_UniversityCategory.universityCategory_id = edu_UniversityList.universityList_catID INNER JOIN edu_UniversitySubCategory ON edu_UniversityCategory.universityCategory_id = edu_UniversitySubCategory.universitySubCategory_catID AND edu_UniversityList.universityList_subCatID = edu_UniversitySubCategory.universitySubCategory_id WHERE universityList_catID=@CatID AND universityList_subCatID = @SubCatID", objConnection);
    //        objCommand.Parameters.AddWithValue("@SubCatID", iSubCatID);
    //        objCommand.Parameters.AddWithValue("@CatID", iCatID);

    //        objReader = objCommand.ExecuteReader();

    //        objUniversityList = new CoreWebList<UniversityListClass>();

    //        while (objReader.Read())
    //        {
    //            objUniversity = new UniversityListClass();
    //            objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
    //            objUniversity.iCatID = int.Parse(objReader["universityList_catID"].ToString());
    //            objUniversity.iSubCatID = int.Parse(objReader["universityList_subCatID"].ToString());
    //            objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
    //            objUniversity.strTitle = objReader["universityList_title"].ToString();
    //            objUniversity.strDesc = objReader["universityList_desc"].ToString();
    //            objUniversity.strAddress = objReader["universityList_address"].ToString();
    //            objUniversity.strCity = objReader["universityList_city"].ToString();
    //            objUniversity.strState = objReader["universityList_state"].ToString();
    //            objUniversity.strCountry = objReader["universityList_country"].ToString();
    //            objUniversity.strPinCode = objReader["universityList_pinCode"].ToString();
    //            objUniversity.strPhone = objReader["universityList_phone"].ToString();
    //            objUniversity.strFax = objReader["universityList_fax"].ToString();
    //            objUniversity.strEmail = objReader["universityList_email"].ToString();
    //            objUniversity.strWebsite = objReader["universityList_website"].ToString();
    //            objUniversity.strImage = objReader["universityList_image"].ToString();
    //            objUniversity.strCategoryTitle = objReader["universityCategory_title"].ToString();
    //            objUniversity.strSubCategoryTitle = objReader["universitySubCategory_title"].ToString();
    //            objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
    //            objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();  
    //            objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                
    //            objUniversityList.Add(objUniversity);
    //        }

    //        if (objReader != null)
    //        {
    //            objReader.Close();
    //        }

    //        return objUniversityList;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        if (objReader != null)
    //        {
    //            objReader.Close();
    //        }

    //        if (objConnection != null)
    //        {
    //            objConnection.Close();
    //        }
    //    }
    //}

    internal string fn_editUniversityWithoutImage(int iID, int iCatID, int iSubCatID, int iTypeID, string strTitle, string strDesc, string strAddress, string strCountry, string strState, string strCity, string strPinCode, string strPhone, string strFax, string strEmail, string strWebsite, bool bFeatured, string strEstablishedIn, string strAffiliatedTo, int iRank, string strFileName, string strHeader1, string strHeader2, string strHeader3, string strMetaTitle, string strMetaDesc, string strMetaKeywords, string strKeywords, string strExamTimeTable, string strAdmissions, string strInfrastructure, string strResults)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_UniversityList SET  universityList_typeID = @TypeID,universityList_title = @Title ,universityList_desc = @Desc, universityList_examtimetable=@universityList_examtimetable, universityList_address = @Address ,universityList_city = @City ,universityList_email = @Email ,universityList_website = @Website ,universityList_featured=@Featured,universityList_establishedIn=@EstablishedIn,universityList_affiliatedTo=@AffiliatedTo, universityList_Rank=@universityList_Rank, universityList_FileName=@universityList_FileName, universityList_State=@universityList_State, Header1=@Header1, Header2=@Header2, Header3=@Header3, Meta_title=@Meta_title, Meta_Description=@Meta_Description, Meta_Keywords=@Meta_Keywords, Keywords=@Keywords, universityList_admissions=@universityList_admissions, universityList_infrastructure=@universityList_infrastructure, universityList_results=@universityList_results  WHERE universityList_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@TypeID", iTypeID);
            objCommand.Parameters.AddWithValue("@Title", strTitle);
            objCommand.Parameters.AddWithValue("@Desc", strDesc);
            objCommand.Parameters.AddWithValue("@universityList_examtimetable", strExamTimeTable);
            objCommand.Parameters.AddWithValue("@Address", strAddress);
            objCommand.Parameters.AddWithValue("@City", strCity);
            objCommand.Parameters.AddWithValue("@Email", strEmail);
            objCommand.Parameters.AddWithValue("@Website", strWebsite);
            objCommand.Parameters.AddWithValue("@Featured", bFeatured);
            objCommand.Parameters.AddWithValue("@EstablishedIn", strEstablishedIn);
            objCommand.Parameters.AddWithValue("@AffiliatedTo", strAffiliatedTo);
            objCommand.Parameters.AddWithValue("@universityList_Rank", iRank);

            objCommand.Parameters.AddWithValue("@universityList_FileName", strFileName);
            objCommand.Parameters.AddWithValue("@universityList_State", strState);
            objCommand.Parameters.AddWithValue("@Header1", strHeader1);
            objCommand.Parameters.AddWithValue("@Header2", strHeader2);
            objCommand.Parameters.AddWithValue("@Header3", strHeader3);
            objCommand.Parameters.AddWithValue("@Meta_title", strMetaTitle);
            objCommand.Parameters.AddWithValue("@Meta_Description", strMetaDesc);
            objCommand.Parameters.AddWithValue("@Meta_Keywords", strMetaKeywords);
            objCommand.Parameters.AddWithValue("@Keywords", strKeywords);

            objCommand.Parameters.AddWithValue("@universityList_admissions", strAdmissions);
            objCommand.Parameters.AddWithValue("@universityList_infrastructure", strInfrastructure);
            objCommand.Parameters.AddWithValue("@universityList_results", strResults);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been updated";
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










    internal string fn_edit_University(int iID, string strFileName, string strHeader1, string strHeader2, string strHeader3, string strMetaTitle, string strMetaDesc, string strMetaKeywords, string strKeywords, string strAdmissions, string strInfrastructure, string strResults)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_UniversityList SET universityList_FileName=@universityList_FileName, Header1=@Header1, Header2=@Header2, Header3=@Header3, Meta_title=@Meta_title, Meta_Description=@Meta_Description, Meta_Keywords=@Meta_Keywords, Keywords=@Keywords, universityList_admissions=@universityList_admissions, universityList_infrastructure=@universityList_infrastructure, universityList_results=@universityList_results  WHERE universityList_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@universityList_FileName", strFileName);
            objCommand.Parameters.AddWithValue("@Header1", strHeader1);
            objCommand.Parameters.AddWithValue("@Header2", strHeader2);
            objCommand.Parameters.AddWithValue("@Header3", strHeader3);
            objCommand.Parameters.AddWithValue("@Meta_title", strMetaTitle);
            objCommand.Parameters.AddWithValue("@Meta_Description", strMetaDesc);
            objCommand.Parameters.AddWithValue("@Meta_Keywords", strMetaKeywords);
            objCommand.Parameters.AddWithValue("@Keywords", strKeywords);

            objCommand.Parameters.AddWithValue("@universityList_admissions", strAdmissions);
            objCommand.Parameters.AddWithValue("@universityList_infrastructure", strInfrastructure);
            objCommand.Parameters.AddWithValue("@universityList_results", strResults);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been updated";
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








    internal bool fn_getFeaturedStatusByID(int iID)
    {
        UniversityListClass objIM = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT universityList_featured FROM edu_UniversityList WHERE universityList_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            while (objReader.Read())
            {
                objIM = new UniversityListClass();

                objIM.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
            }

            return objIM.bFeatured;
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

    internal string fn_changeFeaturedStatus(int iID, bool bFeatured)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_UniversityList SET universityList_featured=@Featured WHERE universityList_id = @ID ", objConnection);

            objCommand.Parameters.AddWithValue("@Featured", bFeatured);
            objCommand.Parameters.AddWithValue("@ID", iID);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been updated";
            }
            else
            {
                return "ERROR : SQL Exception";
            }

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

    internal string fn_changeHomeFeaturedStatus(int iID, bool bHomeFeatured)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_UniversityList SET universityList_HomeFeatured=@universityList_HomeFeatured WHERE universityList_id=@ID ", objConnection);
            objCommand.Parameters.AddWithValue("@universityList_HomeFeatured", bHomeFeatured);
            objCommand.Parameters.AddWithValue("@ID", iID);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been updated";
            }
            else
            {
                return "ERROR : SQL Exception";
            }

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

    internal CoreWebList<UniversityListClass> fn_getUnivListBy_CityName(string strCity)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityList WHERE universityList_city =" + "'" + strCity + "' ORDER BY universityList_title ASC", objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strExamTimeTable = objReader["universityList_examtimetable"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();

                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

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

    internal CoreWebList<UniversityListClass> fn_getUnivListBy_Type(int iTypeID)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityList WHERE universityList_typeID =" + "'" + iTypeID + "' ORDER BY universityList_title ASC", objConnection);


            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iRank = int.Parse(objReader["universityList_Rank"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strExamTimeTable = objReader["universityList_examtimetable"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();

                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

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

    internal CoreWebList<UniversityListClass> fn_getUnivListBy_TypeAndCity(int iTypeID, string strCity)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strQuery = "";

            if (iTypeID == 0 && strCity == "All")
            {
                strQuery = "select Distinct(universityList_title),universityList_city,universityList_id,universityList_typeID,universityList_featured from edu_UniversityList inner Join edu_UniversityType on universityList_typeID = universityType_id  ORDER BY universityList_featured DESC,universityList_title ASC";
            }
            else if (iTypeID == 0 && strCity != "All")
            {
                strQuery = "select Distinct(universityList_title),universityList_city,universityList_id,universityList_typeID,universityList_featured from edu_UniversityList inner Join edu_UniversityType on universityList_typeID = universityType_id WHERE universityList_city ='" + strCity + "' ORDER BY universityList_featured DESC,universityList_title ASC";
            }
            else if (iTypeID != 0 && strCity == "All")
            {
                strQuery = "select Distinct(universityList_title),universityList_city,universityList_id,universityList_typeID,universityList_featured from edu_UniversityList inner Join edu_UniversityType on universityList_typeID = universityType_id WHERE universityList_typeID ='" + iTypeID + "' ORDER BY universityList_featured DESC,universityList_title ASC";
            }
            else
            {
                strQuery = "select Distinct(universityList_title),universityList_city,universityList_id,universityList_typeID,universityList_featured from edu_UniversityList inner Join edu_UniversityType on universityList_typeID = universityType_id WHERE universityList_typeID ='" + iTypeID + "' AND universityList_city ='" + strCity + "' ORDER BY universityList_featured DESC,universityList_title ASC";
            }

            objCommand = new SqlCommand(strQuery , objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                //objUniversity.strDesc = objReader["universityList_desc"].ToString();
                //objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                //objUniversity.strEmail = objReader["universityList_email"].ToString();
                //objUniversity.strWebsite = objReader["universityList_website"].ToString();
                //objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                //objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                //objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();

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

    internal CoreWebList<UniversityListClass> fn_get_FeaturedUniversities(int iStartRow, int iEndRow)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("Select *  From (SELECT *, row_number() OVER (ORDER BY universityList_title ASC) as TR FROM edu_UniversityList Where universityList_featured = '1' ) As TR Where TR between @StartRow and @EndRow", objConnection);

            objCommand.Parameters.AddWithValue("@StartRow", iStartRow);
            objCommand.Parameters.AddWithValue("@EndRow", iEndRow);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();

                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

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

    internal CoreWebList<UniversityListClass> fn_get_FeaturedUniversitiesbyCity(int iStartRow, int iEndRow, String strCity)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("Select *  From (SELECT *, row_number() OVER (ORDER BY universityList_title ASC) as TR FROM edu_UniversityList Where universityList_featured = '1' AND universityList_city = @City ) As TR Where TR between @StartRow and @EndRow", objConnection);

            objCommand.Parameters.AddWithValue("@StartRow", iStartRow);
            objCommand.Parameters.AddWithValue("@EndRow", iEndRow);
            objCommand.Parameters.AddWithValue("@City", strCity);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();

                objUniversity.strFileName = objReader["universityList_FileName"].ToString();
                objUniversity.strState = objReader["universityList_State"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

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

    #region UniversityCourses (edu_UniversityCourses)


    public CoreWebList<UniversityListClass> fn_GetUniversityCourseListByCourseID(int iCourseID)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityCourses WHERE universitycourses_id = @universitycourses_id ORDER BY universitycourses_name", objConnection);

            objCommand.Parameters.AddWithValue("@universitycourses_id", iCourseID);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();

                objUniversity.iCourseID = int.Parse(objReader["universitycourses_id"].ToString());
                objUniversity.strCourseName = objReader["universitycourses_name"].ToString();
                objUniversity.strCourseDetails = objReader["universitycourses_details"].ToString();
                
                objUniversity.iID = int.Parse(objReader["universitycourses_universityID"].ToString());
                objUniversity.strFileName = objReader["FileName"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

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

    public CoreWebList<UniversityListClass> fn_GetUniversityCoursebyFileName(string strFileName)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityCourses WHERE FileName like '%" + strFileName + "%'", objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();

                objUniversity.iCourseID = int.Parse(objReader["universitycourses_id"].ToString());
                objUniversity.iID = int.Parse(objReader["universitycourses_universityID"].ToString());
                objUniversity.strCourseName = objReader["universitycourses_name"].ToString();
                objUniversity.strCourseDetails = objReader["universitycourses_details"].ToString();

                objUniversity.iID = int.Parse(objReader["universitycourses_universityID"].ToString());
                objUniversity.strFileName = objReader["FileName"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

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

    public CoreWebList<UniversityListClass> fn_GetUniversityCoursebyTitle(string strTitle)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT (SELECT universityList_title FROM edu_UniversityList WHERE universityList_id=universitycourses_universityID)universitycourses_university, * FROM edu_UniversityCourses WHERE universitycourses_name like '%' + @universitycourses_name + '%'", objConnection);
            objCommand.Parameters.AddWithValue("@universitycourses_name", strTitle);
            objReader = objCommand.ExecuteReader();
            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();

                objUniversity.iCourseID = int.Parse(objReader["universitycourses_id"].ToString());
                objUniversity.iID = int.Parse(objReader["universitycourses_universityID"].ToString());
                objUniversity.strInstitute = objReader["universitycourses_university"].ToString();
                objUniversity.strCourseName = objReader["universitycourses_name"].ToString();
                objUniversity.strCourseDetails = objReader["universitycourses_details"].ToString();

                objUniversity.iID = int.Parse(objReader["universitycourses_universityID"].ToString());
                objUniversity.strFileName = objReader["FileName"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

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

    public CoreWebList<UniversityListClass> fn_GetUniversityCourseList()
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT edu_UniversityCourses.*, (select universityList_title from edu_UniversityList where universityList_id = universitycourses_universityID) as UniversityTitle FROM edu_UniversityCourses ORDER BY universitycourses_name ASC", objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();

                objUniversity.iCourseID = int.Parse(objReader["universitycourses_id"].ToString());
                objUniversity.strCourseName = objReader["universitycourses_name"].ToString();
                objUniversity.strCourseDetails = objReader["universitycourses_details"].ToString();

                objUniversity.iID = int.Parse(objReader["universitycourses_universityID"].ToString());
                objUniversity.strFileName = objReader["FileName"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();
                objUniversity.strTitle = objReader["UniversityTitle"].ToString();

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

    public CoreWebList<UniversityListClass> fn_GetRandomUniversityCourseList()
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 10 *, (select universityList_title from edu_UniversityList where universityList_id = universitycourses_universityID) as UniversityTitle FROM edu_UniversityCourses ORDER BY NEWID()", objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();

                objUniversity.iCourseID = int.Parse(objReader["universitycourses_id"].ToString());
                objUniversity.strCourseName = objReader["universitycourses_name"].ToString();
                objUniversity.strCourseDetails = objReader["universitycourses_details"].ToString();

                objUniversity.iID = int.Parse(objReader["universitycourses_universityID"].ToString());
                objUniversity.strFileName = objReader["FileName"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();
                objUniversity.strTitle = objReader["UniversityTitle"].ToString();

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

    public CoreWebList<UniversityListClass> fn_GetUniversityCourseListByQuery(string strQuery)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand(strQuery, objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();

                objUniversity.iCourseID = int.Parse(objReader["universitycourses_id"].ToString());
                objUniversity.strCourseName = objReader["universitycourses_name"].ToString();
                objUniversity.strCourseDetails = objReader["universitycourses_details"].ToString();

                objUniversity.iID = int.Parse(objReader["universitycourses_universityID"].ToString());
                objUniversity.strFileName = objReader["FileName"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();
                objUniversity.strTitle = objReader["UniversityTitle"].ToString();

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


    public CoreWebList<UniversityListClass> fn_GetUniversityCourseListRandom()
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 5 edu_UniversityCourses.*, (select universityList_title from edu_UniversityList where universityList_id = universitycourses_universityID) as UniversityTitle FROM edu_UniversityCourses ORDER BY NEWID()", objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();

                objUniversity.iCourseID = int.Parse(objReader["universitycourses_id"].ToString());
                objUniversity.strCourseName = objReader["universitycourses_name"].ToString();
                objUniversity.strCourseDetails = objReader["universitycourses_details"].ToString();

                objUniversity.iID = int.Parse(objReader["universitycourses_universityID"].ToString());
                objUniversity.strFileName = objReader["FileName"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();
                objUniversity.strTitle = objReader["UniversityTitle"].ToString();

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


    public CoreWebList<UniversityListClass> fn_GetUniversityCourseListByIDs(string strIDs)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT edu_UniversityCourses.*, (select universityList_title from edu_UniversityList where universityList_id = universitycourses_universityID) as UniversityTitle FROM edu_UniversityCourses WHERE universitycourses_id IN (" + strIDs + ")", objConnection);

            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();

                objUniversity.iCourseID = int.Parse(objReader["universitycourses_id"].ToString());
                objUniversity.strCourseName = objReader["universitycourses_name"].ToString();
                objUniversity.strCourseDetails = objReader["universitycourses_details"].ToString();

                objUniversity.iID = int.Parse(objReader["universitycourses_universityID"].ToString());
                objUniversity.strFileName = objReader["FileName"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();
                objUniversity.strTitle = objReader["UniversityTitle"].ToString();

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


    public string fn_SaveUniversityCourses(int iUniversityID, string strCourseName, string strCourseDesc, string strFileName, string strHeader1, string strHeader2, string strHeader3, string strMetaTitle, string strMetaDesc, string strMetaKeywords, string strKeywords)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_UniversityCourses(universitycourses_universityID, universitycourses_name, universitycourses_details, FileName, Header1, Header2, Header3, Meta_title, Meta_Description, Meta_Keywords, Keywords) VALUES (@universitycourses_universityID, @universitycourses_name,@universitycourses_details, @FileName, @Header1, @Header2, @Header3, @Meta_title, @Meta_Description, @Meta_Keywords, @Keywords)", objConnection);

            objCommand.Parameters.AddWithValue("@universitycourses_universityID", iUniversityID);

            objCommand.Parameters.AddWithValue("@universitycourses_name", strCourseName);
            objCommand.Parameters.AddWithValue("@universitycourses_details", strCourseDesc);

            objCommand.Parameters.AddWithValue("@FileName", strFileName);
            objCommand.Parameters.AddWithValue("@Header1", strHeader1);
            objCommand.Parameters.AddWithValue("@Header2", strHeader2);
            objCommand.Parameters.AddWithValue("@Header3", strHeader3);
            objCommand.Parameters.AddWithValue("@Meta_title", strMetaTitle);
            objCommand.Parameters.AddWithValue("@Meta_Description", strMetaDesc);
            objCommand.Parameters.AddWithValue("@Meta_Keywords", strMetaKeywords);
            objCommand.Parameters.AddWithValue("@Keywords", strKeywords);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been inserted";
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

    public string fn_EditUniversityCourses(int iCourseID, string strCourseName, string strCourseDesc, string strFileName, string strHeader1, string strHeader2, string strHeader3, string strMetaTitle, string strMetaDesc, string strMetaKeywords, string strKeywords)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_UniversityCourses SET universitycourses_name = @universitycourses_name, universitycourses_details = @universitycourses_details, FileName=@FileName, Header1=@Header1, Header2=@Header2, Header3=@Header3, Meta_title=@Meta_title, Meta_Description=@Meta_Description, Meta_Keywords=@Meta_Keywords, Keywords=@Keywords WHERE universitycourses_id = @universitycourses_id", objConnection);

            objCommand.Parameters.AddWithValue("@universitycourses_id", iCourseID);
            objCommand.Parameters.AddWithValue("@universitycourses_name", strCourseName);
            objCommand.Parameters.AddWithValue("@universitycourses_details", strCourseDesc);

            objCommand.Parameters.AddWithValue("@FileName", strFileName);
            objCommand.Parameters.AddWithValue("@Header1", strHeader1);
            objCommand.Parameters.AddWithValue("@Header2", strHeader2);
            objCommand.Parameters.AddWithValue("@Header3", strHeader3);
            objCommand.Parameters.AddWithValue("@Meta_title", strMetaTitle);
            objCommand.Parameters.AddWithValue("@Meta_Description", strMetaDesc);
            objCommand.Parameters.AddWithValue("@Meta_Keywords", strMetaKeywords);
            objCommand.Parameters.AddWithValue("@Keywords", strKeywords);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been updated";
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

    public string fn_DeleteUniversityCourses(int iCourseID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_UniversityCourses WHERE universitycourses_id = @universitycourses_id", objConnection);

            objCommand.Parameters.AddWithValue("@universitycourses_id", iCourseID);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been deleted";
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

    public CoreWebList<UniversityListClass> fn_SearchCoursesList(string strSearchQuery)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand(strSearchQuery, objConnection);
            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {

                objUniversity = new UniversityListClass();

                objUniversity.iCourseID = int.Parse(objReader["universitycourses_id"].ToString());
                
                objUniversity.strCourseName = objReader["universitycourses_name"].ToString();
                objUniversity.strTypeTitle = objReader["Universitycourses_type"].ToString();
                objUniversity.strCourseDetails = objReader["universitycourses_details"].ToString();
                objUniversity.strCity = objReader["university_city"].ToString();

                objUniversity.iID = int.Parse(objReader["universitycourses_universityID"].ToString());
                objUniversity.strFileName = objReader["FileName"].ToString();
                objUniversity.strHeader1 = objReader["Header1"].ToString();
                objUniversity.strHeader2 = objReader["Header2"].ToString();
                objUniversity.strHeader3 = objReader["Header3"].ToString();
                objUniversity.strMetaTitle = objReader["Meta_title"].ToString();
                objUniversity.strMetaDesc = objReader["Meta_Description"].ToString();
                objUniversity.strMetaKeywords = objReader["Meta_Keywords"].ToString();
                objUniversity.strKeywords = objReader["Keywords"].ToString();

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
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    #endregion

    #region  UniversityCourseList (edu_UniversityCourseList)
    public string fn_SaveUniversityCourseList(int[] iCourseIDArr, int iUniversityID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();

            objCommand1 = new SqlCommand("DELETE FROM edu_UniversityCourseList WHERE university_id=@InstID", 
                objConnection);

            objCommand1.Parameters.AddWithValue("@InstID", iUniversityID);

            objCommand1.ExecuteNonQuery();

            for (int i = 0; i < iCourseIDArr.Length; i++)
            {
                if (iCourseIDArr[i] != 0)
                {
                    objCommand = new SqlCommand("INSERT INTO edu_UniversityCourseList(university_id,course_id) VALUES (@InstID, @CourseID)", objConnection);

                    objCommand.Parameters.AddWithValue("@CourseID", iCourseIDArr[i]);
                    objCommand.Parameters.AddWithValue("@InstID", iUniversityID);

                    objCommand.ExecuteNonQuery();
                }
            }

            return "SUCCESS : Record has been inserted";
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

    public string fn_EditUniversityCourseList(int iUniversityCourseListID, int[] iCourseIDArr, 
        int iUniversityID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand1 = new SqlCommand("DELETE FROM edu_UniversityCourseList WHERE university_id=@InstID",
                objConnection);

            objCommand1.Parameters.AddWithValue("@InstID", iUniversityID);

            objCommand.ExecuteNonQuery();

            for (int i = 0; i < iCourseIDArr.Length; i++)
            {
                if (iCourseIDArr[i] != 0)
                {

                    objCommand = new SqlCommand("UPDATE edu_UniversityCourseList SET university_id = @InstID, course_id=@CourseID WHERE universitycourselist_id = @ID", objConnection);

                    objCommand.Parameters.AddWithValue("@ID", iUniversityCourseListID);
                    objCommand.Parameters.AddWithValue("@CourseID", iCourseIDArr[i]);
                    objCommand.Parameters.AddWithValue("@InstID", iUniversityID);

                    objCommand.ExecuteNonQuery();
                }
            }

            return "SUCCESS : Record has been updated";
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

    public string fn_DeleteUniversityCourseList(int iUniversityCourseListID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = 
                new SqlCommand("DELETE FROM edu_UniversityCourseList WHERE universitycourselist_id = @ID", 
                    objConnection);

            objCommand.Parameters.AddWithValue("@ID", iUniversityCourseListID);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been deleted";
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
    
    public CoreWebList<UniversityListClass> fn_getUniversityCourseList()
    {
        CoreWebList<UniversityListClass> objUnivCourseList = null;
        UniversityListClass objUnivCourse = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityCourseList", objConnection);

            objReader = objCommand.ExecuteReader();

            objUnivCourseList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUnivCourse = new UniversityListClass();

                objUnivCourse.iUniversityCourseListID = 
                    int.Parse(objReader["universitycourselist_id"].ToString());
                objUnivCourse.iID = int.Parse(objReader["university_id"].ToString());
                objUnivCourse.iCourseID = int.Parse(objReader["course_id"].ToString());
                
                objUnivCourseList.Add(objUnivCourse);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objUnivCourseList;
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

    public CoreWebList<UniversityListClass> fn_getUniversityCourseListByID(int iUniversityCourseListID)
    {
        CoreWebList<UniversityListClass> objUnivCourseList = null;
        UniversityListClass objUnivCourse = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_UniversityCourseList WHERE universitycourselist_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iUniversityCourseListID);

            objReader = objCommand.ExecuteReader();

            objUnivCourseList = new CoreWebList<UniversityListClass>();

            if (objReader.Read())
            {
                objUnivCourse = new UniversityListClass();

                objUnivCourse.iUniversityCourseListID =
                    int.Parse(objReader["universitycourselist_id"].ToString());
                objUnivCourse.iID = int.Parse(objReader["university_id"].ToString());
                objUnivCourse.iCourseID = int.Parse(objReader["course_id"].ToString());

                objUnivCourseList.Add(objUnivCourse);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objUnivCourseList;
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

    public CoreWebList<UniversityListClass> fn_getUniversityCourseByName(string strTitle)
    {
        CoreWebList<UniversityListClass> objUnivCourseList = null;
        UniversityListClass objUnivCourse = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM dbo.edu_UniversityCourses WHERE universitycourses_name=@universitycourses_name", objConnection);
            objCommand.Parameters.AddWithValue("@universitycourses_name", strTitle);
            objReader = objCommand.ExecuteReader();
            objUnivCourseList = new CoreWebList<UniversityListClass>();

            if (objReader.Read())
            {
                objUnivCourse = new UniversityListClass();
                objUnivCourse.iID = int.Parse(objReader["universitycourses_universityID"].ToString());
                objUnivCourse.iCourseID = int.Parse(objReader["universitycourses_id"].ToString());
                objUnivCourse.strCourseName = objReader["universitycourses_name"].ToString();
                objUnivCourse.strCourseDetails = objReader["universitycourses_details"].ToString();
                objUnivCourseList.Add(objUnivCourse);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objUnivCourseList;
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

    public ArrayList fn_ArrayListGetUniversityCourseListByUniversityID(int iUniversityID)
    {
        ArrayList objList = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = 
                new SqlCommand("SELECT * FROM edu_UniversityCourseList WHERE university_id = @InstID", 
                    objConnection);

            objCommand.Parameters.AddWithValue("@InstID", iUniversityID);

            objReader = objCommand.ExecuteReader();

            objList = new ArrayList();

            while (objReader.Read())
            {
                objList.Add(int.Parse(objReader["course_id"].ToString()));
            }

            return objList;
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

    public CoreWebList<UniversityListClass> fn_GetUniversityCourseListByUniversityID(int iUniversityID)
    {
        CoreWebList<UniversityListClass> objUnivCourseList = null;
        UniversityListClass objUnivCourse = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT (SELECT universityList_title FROM edu_UniversityList WHERE universityList_id=universitycourses_universityID)University_title, * FROM edu_UniversityCourses where universitycourses_universityID=@iUniversityID ORDER BY universitycourses_name", objConnection);
            
            objCommand.Parameters.AddWithValue("@iUniversityID", iUniversityID);

            objReader = objCommand.ExecuteReader();

            objUnivCourseList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUnivCourse = new UniversityListClass();

                objUnivCourse.iID = int.Parse(objReader["universitycourses_universityID"].ToString());
                objUnivCourse.iCourseID = int.Parse(objReader["universitycourses_id"].ToString());
                objUnivCourse.strInstitute = objReader["University_title"].ToString();
                objUnivCourse.strCourseName = objReader["universitycourses_name"].ToString();
                objUnivCourse.strFileName = objReader["FileName"].ToString();
                objUnivCourse.strCourseDetails = objReader["universitycourses_details"].ToString();

                objUnivCourseList.Add(objUnivCourse);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objUnivCourseList;
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

    public CoreWebList<UniversityListClass> fn_GetRandomUniversityCourseListByUniversityID(int iUniversityID)
    {
        CoreWebList<UniversityListClass> objUnivCourseList = null;
        UniversityListClass objUnivCourse = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 5 (SELECT universityList_title FROM edu_UniversityList WHERE universityList_id=universitycourses_universityID)University_title, * FROM edu_UniversityCourses where universitycourses_universityID=@iUniversityID ORDER BY NEWID()", objConnection);

            objCommand.Parameters.AddWithValue("@iUniversityID", iUniversityID);

            objReader = objCommand.ExecuteReader();

            objUnivCourseList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUnivCourse = new UniversityListClass();

                objUnivCourse.iID = int.Parse(objReader["universitycourses_universityID"].ToString());
                objUnivCourse.iCourseID = int.Parse(objReader["universitycourses_id"].ToString());
                objUnivCourse.strInstitute = objReader["University_title"].ToString();
                objUnivCourse.strCourseName = objReader["universitycourses_name"].ToString();
                objUnivCourse.strFileName = objReader["FileName"].ToString();
                objUnivCourse.strCourseDetails = objReader["universitycourses_details"].ToString();

                objUnivCourseList.Add(objUnivCourse);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objUnivCourseList;
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
    #endregion

    internal CoreWebList<UniversityListClass> fn_SearchClient_Universities(string strName, string strLocation)
    {
        CoreWebList<UniversityListClass> objUniversityList = null;
        UniversityListClass objUniversity = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strQuery = "SELECT edu_UniversityList.*, edu_UniversityType.universityType_title FROM edu_UniversityList INNER JOIN edu_UniversityType ON edu_UniversityList.universityList_typeID = edu_UniversityType.universityType_id ";

            bool bFlag = false;

            if (strName != "")
            {
                if (bFlag)
                {
                    strQuery += " AND universityList_title LIKE '" + strName + "%'";
                }
                else
                {
                    strQuery += " WHERE universityList_title LIKE '" + strName + "%'";
                }
                bFlag = true;
            }

            if (strLocation != "")
            {
                if (bFlag)
                {
                    strQuery += " AND universityList_city LIKE '" + strLocation + "%'";
                }
                else
                {
                    strQuery += " WHERE universityList_city LIKE '" + strLocation + "%'";
                }
                bFlag = true;
            }

            strQuery += " ORDER BY universityList_title";

            objCommand = new SqlCommand(strQuery, objConnection);
            
            objReader = objCommand.ExecuteReader();

            objUniversityList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUniversity = new UniversityListClass();
                objUniversity.iID = int.Parse(objReader["universityList_id"].ToString());
                objUniversity.iTypeID = int.Parse(objReader["universityList_typeID"].ToString());
                objUniversity.strTitle = objReader["universityList_title"].ToString();
                objUniversity.strDesc = objReader["universityList_desc"].ToString();
                objUniversity.strAddress = objReader["universityList_address"].ToString();
                objUniversity.strCity = objReader["universityList_city"].ToString();
                objUniversity.strEmail = objReader["universityList_email"].ToString();
                objUniversity.strWebsite = objReader["universityList_website"].ToString();
                objUniversity.strImage = objReader["universityList_image"].ToString();
                objUniversity.bFeatured = bool.Parse(objReader["universityList_featured"].ToString());
                objUniversity.strEstablishedIn = objReader["universityList_establishedIn"].ToString();
                objUniversity.strAffiliatedTo = objReader["universityList_affiliatedTo"].ToString();
                objUniversity.strTypeTitle = objReader["universityType_title"].ToString();  
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

    internal CoreWebList<UniversityListClass> fn_getAffiliatedInstitutesByUnivID(int iUniversityID)
    {
        CoreWebList<UniversityListClass> objUnivCourseList = null;
        UniversityListClass objUnivCourse = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("Select I.institute_id, I.institute_title From edu_Institute I Inner Join edu_AffiliationList A on  A.affiliationlist_InstID = I.institute_id Inner Join edu_UniversityList U on A.affiliationlist_UnivID = U.universityList_id WHERE U.universityList_id  = @iUniversityID", objConnection);

            objCommand.Parameters.AddWithValue("@iUniversityID", iUniversityID);

            objReader = objCommand.ExecuteReader();

            objUnivCourseList = new CoreWebList<UniversityListClass>();

            while (objReader.Read())
            {
                objUnivCourse = new UniversityListClass();

                objUnivCourse.iInstituteID = int.Parse(objReader["institute_id"].ToString());
                objUnivCourse.strInstitute = objReader["institute_title"].ToString();

                objUnivCourseList.Add(objUnivCourse);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objUnivCourseList;
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