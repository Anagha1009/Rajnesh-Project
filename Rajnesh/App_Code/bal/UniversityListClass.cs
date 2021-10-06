using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using yo_lib;

/// <summary>
/// Summary description for UniversityListClass
/// </summary>
public class UniversityListClass
{
    #region UniversityList (edu_UniversityList)
    private int _iID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iID
    {
        get
        {
            return _iID;
        }
        set
        {
            _iID = value;
        }
    }

    private int _iInstituteID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iInstituteID
    {
        get
        {
            return _iInstituteID;
        }
        set
        {
            _iInstituteID = value;
        }
    }

    private int _iCatID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCatID
    {
        get
        {
            return _iCatID;
        }
        set
        {
            _iCatID = value;
        }
    }

    private int _iSubCatID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iSubCatID
    {
        get
        {
            return _iSubCatID;
        }
        set
        {
            _iSubCatID = value;
        }
    }

    private int _iTypeID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iTypeID
    {
        get
        {
            return _iTypeID;
        }
        set
        {
            _iTypeID = value;
        }
    }

    private int _iRank = 4000;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iRank
    {
        get
        {
            return _iRank;
        }
        set
        {
            _iRank = value;
        }
    }

    private string _strTypeTitle = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strTypeTitle
    {
        get
        {
            return _strTypeTitle;
        }
        set
        {
            _strTypeTitle = value;
        }
    }

    private string _strImage = "noImage.jpg";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strImage
    {
        get
        {
            return _strImage;
        }
        set
        {
            _strImage = value;
        }
    }

    private string _strInstitute = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strInstitute
    {
        get
        {
            return _strInstitute;
        }
        set
        {
            _strInstitute = value;
        }
    }

    private string _strTitle = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strTitle
    {
        get
        {
            return _strTitle;
        }
        set
        {
            _strTitle = value;
        }
    }

    private string _strDesc = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strDesc
    {
        get
        {
            return _strDesc;
        }
        set
        {
            _strDesc = value;
        }
    }

    private string _strIDS = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strIDS
    {
        get
        {
            return _strIDS;
        }
        set
        {
            _strIDS = value;
        }
    }

    private string _strExamTimeTable = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strExamTimeTable
    {
        get
        {
            return _strExamTimeTable;
        }
        set
        {
            _strExamTimeTable = value;
        }
    }


    private string _strAdmissions = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strAdmissions
    {
        get
        {
            return _strAdmissions;
        }
        set
        {
            _strAdmissions = value;
        }
    }


    private string _strInfrastructure = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strInfrastructure
    {
        get
        {
            return _strInfrastructure;
        }
        set
        {
            _strInfrastructure = value;
        }
    }

    private string _strResults = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strResults
    {
        get
        {
            return _strResults;
        }
        set
        {
            _strResults = value;
        }
    }

    private string _strAddress = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strAddress
    {
        get
        {
            return _strAddress;
        }
        set
        {
            _strAddress = value;
        }
    }


    private string _strCity = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCity
    {
        get
        {
            return _strCity;
        }
        set
        {
            _strCity = value;
        }
    }

    private string _strState = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strState
    {
        get
        {
            return _strState;
        }
        set
        {
            _strState = value;
        }
    }

    private string _strCountry = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCountry
    {
        get
        {
            return _strCountry;
        }
        set
        {
            _strCountry = value;
        }
    }

    private string _strPinCode = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strPinCode
    {
        get
        {
            return _strPinCode;
        }
        set
        {
            _strPinCode = value;
        }
    }

    private string _strPhone = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strPhone
    {
        get
        {
            return _strPhone;
        }
        set
        {
            _strPhone = value;
        }
    }

    private string _strFax = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strFax
    {
        get
        {
            return _strFax;
        }
        set
        {
            _strFax = value;
        }
    }

    private string _strEmail = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strEmail
    {
        get
        {
            return _strEmail;
        }
        set
        {
            _strEmail = value;
        }
    }

    private string _strWebsite = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strWebsite
    {
        get
        {
            return _strWebsite;
        }
        set
        {
            _strWebsite = value;
        }
    }

    private string _strCategoryTitle = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCategoryTitle
    {
        get
        {
            return _strCategoryTitle;
        }
        set
        {
            _strCategoryTitle = value;
        }
    }

    private string _strSubCategoryTitle = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strSubCategoryTitle
    {
        get
        {
            return _strSubCategoryTitle;
        }
        set
        {
            _strSubCategoryTitle = value;
        }

    }

    private bool _bFeatured = false;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bFeatured
    {
        get
        {
            return _bFeatured;
        }
        set
        {
            _bFeatured = value;
        }
    }

    private bool _bHomeFeatured = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bHomeFeatured
    {
        get
        {
            return _bHomeFeatured;
        }
        set
        {
            _bHomeFeatured = value;
        }
    }

    private string _strEstablishedIn = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strEstablishedIn
    {
        get
        {
            return _strEstablishedIn;
        }
        set
        {
            _strEstablishedIn = value;
        }
    }

    private string _strAffiliatedTo = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strAffiliatedTo
    {
        get
        {
            return _strAffiliatedTo;
        }
        set
        {
            _strAffiliatedTo = value;
        }
    }


    private string _strFileName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strFileName
    {
        get
        {
            return _strFileName;
        }
        set
        {
            _strFileName = value;
        }
    }

    private string _strHeader1 = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strHeader1
    {
        get
        {
            return _strHeader1;
        }
        set
        {
            _strHeader1 = value;
        }
    }


    private string _strHeader2 = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strHeader2
    {
        get
        {
            return _strHeader2;
        }
        set
        {
            _strHeader2 = value;
        }
    }


    private string _strHeader3 = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strHeader3
    {
        get
        {
            return _strHeader3;
        }
        set
        {
            _strHeader3 = value;
        }
    }


    private string _strMetaTitle = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strMetaTitle
    {
        get
        {
            return _strMetaTitle;
        }
        set
        {
            _strMetaTitle = value;
        }
    }

    private string _strMetaDesc = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strMetaDesc
    {
        get
        {
            return _strMetaDesc;
        }
        set
        {
            _strMetaDesc = value;
        }
    }

    private string _strMetaKeywords = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strMetaKeywords
    {
        get
        {
            return _strMetaKeywords;
        }
        set
        {
            _strMetaKeywords = value;
        }
    }

    private string _strKeywords = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strKeywords
    {
        get
        {
            return _strKeywords;
        }
        set
        {
            _strKeywords = value;
        }
    }


    public string fn_saveUniversityList()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_saveUniversityList(iCatID, iSubCatID, iTypeID, strTitle, strDesc, strAddress, strCountry, strState, strCity, strPinCode, strPhone, strFax, strEmail, strWebsite, strImage, bFeatured, strEstablishedIn, strAffiliatedTo, iRank, strFileName, strHeader1, strHeader2, strHeader3, strMetaTitle, strMetaDesc, strMetaKeywords, strKeywords, strExamTimeTable, strAdmissions, strInfrastructure, strResults);
    }

    public string fn_editUniversityList()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_editUniversityList(iID, iCatID, iSubCatID, iTypeID, strTitle, strDesc, strAddress, strCountry, strState, strCity, strPinCode, strPhone, strFax, strEmail, strWebsite, strImage, bFeatured, strEstablishedIn, strAffiliatedTo, iRank, strFileName, strHeader1, strHeader2, strHeader3, strMetaTitle, strMetaDesc, strMetaKeywords, strKeywords, strExamTimeTable, strAdmissions, strInfrastructure, strResults);
    }

    public string fn_editUniversityWithoutImage()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_editUniversityWithoutImage(iID, iCatID, iSubCatID, iTypeID, strTitle, strDesc, strAddress, strCountry, strState, strCity, strPinCode, strPhone, strFax, strEmail, strWebsite, bFeatured, strEstablishedIn, strAffiliatedTo, iRank, strFileName, strHeader1, strHeader2, strHeader3, strMetaTitle, strMetaDesc, strMetaKeywords, strKeywords, strExamTimeTable, strAdmissions, strInfrastructure, strResults);
    }

    public string fn_edit_University()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_edit_University(iID, strFileName, strHeader1, strHeader2, strHeader3, strMetaTitle, strMetaDesc, strMetaKeywords, strKeywords, strAdmissions, strInfrastructure, strResults);
    }

    public string fn_deleteUniversity()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_deleteUniversity(iID);
    }

    public CoreWebList<UniversityListClass> fn_getUniversityByID()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUniversityByID(iID);
    }

    public CoreWebList<UniversityListClass> fn_getUniversityByTitle()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUniversityByTitle(strTitle);
    }

    public CoreWebList<UniversityListClass> fn_getUniversityByName()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUniversityByName(strTitle);
    }

    public CoreWebList<UniversityListClass> fn_getUniversityByFileName()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUniversityByFileName(strFileName);
    }

    public CoreWebList<UniversityListClass> fn_getUniversityByIdentities(string strIDs)
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUniversityByIdentities(strIDs);
    }

    public CoreWebList<UniversityListClass> fn_getUniversityListByCatID()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUniversityListByCatID(iCatID);
    }

    public CoreWebList<UniversityListClass> fn_getUniversityListByIDs()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUniversityListByIDs(strIDS);
    }

    public CoreWebList<UniversityListClass> fn_getUniversityListBySubCatID()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUniversityListBySubCatID(iSubCatID);
    }
    
    public CoreWebList<UniversityListClass> fn_getUniversityList()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUniversityList();
    }

    public CoreWebList<UniversityListClass> fn_getHomeFeaturedUniversityList()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getHomeFeaturedUniversityList();
    }

    public CoreWebList<UniversityListClass> fn_getRandomUniversityList()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getRandomUniversityList();
    }

    public CoreWebList<UniversityListClass> fn_get_Random_UniversityList()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_get_Random_UniversityList();
    }

    public CoreWebList<UniversityListClass> fn_getUniversityListByQuery(string strQuery)
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUniversityListByQuery(strQuery);
    }

    public CoreWebList<UniversityListClass> fn_getUniversityListByRandom()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUniversityListByRandom();
    }

    public CoreWebList<UniversityListClass> fn_searchUniversityList(string strQuery)
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_searchUniversityList(strQuery);
    }

    public CoreWebList<UniversityListClass> fn_GetUniversityListByCity()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_GetUniversityListByCity(strCity);
    }

    public CoreWebList<UniversityListClass> fn_GetUniversityByCity()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_GetUniversityByCity(strCity);
    }

    public CoreWebList<UniversityListClass> fn_searchUniversityListinAdmin(string strQuery)
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_searchUniversityListinAdmin(strQuery);
    }

    public bool fn_getFeaturedStatusByID()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getFeaturedStatusByID(iID);
    }

    public string fn_changeFeaturedStatus()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_changeFeaturedStatus(iID, bFeatured);
    }

    public string fn_changeHomeFeaturedStatus()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_changeHomeFeaturedStatus(iID, bHomeFeatured);
    }

    public CoreWebList<UniversityListClass> fn_getUnivListBy_CityName()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUnivListBy_CityName(strCity);
    }

    public CoreWebList<UniversityListClass> fn_getUnivListBy_Type()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUnivListBy_Type(iTypeID);
    }

    public CoreWebList<UniversityListClass> fn_getUnivListBy_TypeAndCity()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUnivListBy_TypeAndCity(iTypeID, strCity);
    }

    public CoreWebList<UniversityListClass> fn_get_FeaturedUniversities(int iStartRow, int iEndRow)
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_get_FeaturedUniversities(iStartRow, iEndRow);
    }

    public CoreWebList<UniversityListClass> fn_get_FeaturedUniversitiesbyCity(int iStartRow, int iEndRow, String strCity)
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_get_FeaturedUniversitiesbyCity(iStartRow, iEndRow, strCity);
    }

    public CoreWebList<UniversityListClass> fn_SearchClient_Universities(string strName, string strLocation)
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_SearchClient_Universities(strName, strLocation);
    }

    #endregion

    #region UniversityCourses (edu_UniversityCourses)

    private int _iCourseID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCourseID
    {
        get
        {
            return _iCourseID;
        }
        set
        {
            _iCourseID = value;
        }
    }


    private string _strCourseName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCourseName
    {
        get
        {
            return _strCourseName;
        }
        set
        {
            _strCourseName = value;
        }
    }

    private string _strCourseDetails = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCourseDetails
    {
        get
        {
            return _strCourseDetails;
        }
        set
        {
            _strCourseDetails = value;
        }
    }

    public CoreWebList<UniversityListClass> fn_GetUniversityCourseListByCourseID()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_GetUniversityCourseListByCourseID(iCourseID);
    }

    public CoreWebList<UniversityListClass> fn_GetUniversityCoursebyFileName()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_GetUniversityCoursebyFileName(strFileName);
    }

    public CoreWebList<UniversityListClass> fn_GetUniversityCoursebyTitle()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_GetUniversityCoursebyTitle(strTitle);
    }

    public string fn_SaveUniversityCourses()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_SaveUniversityCourses(iID, strCourseName, strCourseDetails, strFileName, strHeader1, strHeader2, strHeader3, strMetaTitle, strMetaDesc, strMetaKeywords, strKeywords);
    }

    public string fn_EditUniversityCourses()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_EditUniversityCourses(iCourseID, strCourseName, strCourseDetails, strFileName, strHeader1, strHeader2, strHeader3, strMetaTitle, strMetaDesc, strMetaKeywords, strKeywords);
    }

    public string fn_DeleteUniversityCourses()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_DeleteUniversityCourses(iCourseID);
    }

    public CoreWebList<UniversityListClass> fn_GetUniversityCourseList()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_GetUniversityCourseList();
    }

    public CoreWebList<UniversityListClass> fn_GetRandomUniversityCourseList()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_GetRandomUniversityCourseList();
    }

    public CoreWebList<UniversityListClass> fn_GetUniversityCourseListByQuery(string strQuery)
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_GetUniversityCourseListByQuery(strQuery);
    }

    public CoreWebList<UniversityListClass> fn_GetUniversityCourseListRandom()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_GetUniversityCourseListRandom();
    }

    public CoreWebList<UniversityListClass> fn_GetUniversityCourseListByIDs()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_GetUniversityCourseListByIDs(strIDS);
    }

    public CoreWebList<UniversityListClass> fn_SearchCoursesList(string strQuery)
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_SearchCoursesList(strQuery);
    }

    
    #endregion

    #region UniversityCourseList (edu_UniversityCourseList)
    
    private int _iUniversityCourseListID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iUniversityCourseListID
    {
        get
        {
            return _iUniversityCourseListID;
        }
        set
        {
            _iUniversityCourseListID = value;
        }
    }

    private int[] _iCourseIDArray = new int[1];
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int[] iCourseIDArray
    {
        get
        {
            return _iCourseIDArray;
        }
        set
        {
            _iCourseIDArray = value;
        }
    }

    public string fn_SaveUniversityCourseList()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_SaveUniversityCourseList(iCourseIDArray, iID);
    }

    public string fn_EditUniversityCourseList()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_EditUniversityCourseList(iUniversityCourseListID, iCourseIDArray, iID);
    }

    public string fn_DeleteUniversityCourseList()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_DeleteUniversityCourseList(iUniversityCourseListID);
    }

    public CoreWebList<UniversityListClass> fn_getUniversityCourseList()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUniversityCourseList();
    }

    public CoreWebList<UniversityListClass> fn_getUniversityCourseListByID()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUniversityCourseListByID(iUniversityCourseListID);
    }

    public CoreWebList<UniversityListClass> fn_getUniversityCourseByName()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getUniversityCourseByName(strCourseName);
    }

    public ArrayList fn_ArrayListGetUniversityCourseListByUniversityID()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_ArrayListGetUniversityCourseListByUniversityID(iID);
    }

    public CoreWebList<UniversityListClass> fn_GetUniversityCourseListByUniversityID()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_GetUniversityCourseListByUniversityID(iID);
    }

    public CoreWebList<UniversityListClass> fn_GetRandomUniversityCourseListByUniversityID()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_GetRandomUniversityCourseListByUniversityID(iID);
    }

    #endregion

    public CoreWebList<UniversityListClass> fn_getAffiliatedInstitutesByUnivID()
    {
        DBUniversityListClass objdb = new DBUniversityListClass();
        return objdb.fn_getAffiliatedInstitutesByUnivID(iID);
    }
}