using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.IO;

/// <summary>
/// Summary description for DistanceLearningClass
/// </summary>
public class DistanceLearningClass
{
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

    private int _iCenterCount = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCenterCount
    {
        get
        {
            return _iCenterCount;
        }
        set
        {
            _iCenterCount = value;
        }
    }

    private string _strType = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strType
    {
        get
        {
            return _strType;
        }
        set
        {
            _strType = value;
        }
    }

    private string _strName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strName
    {
        get
        {
            return _strName;
        }
        set
        {
            _strName = value;
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

    private string _strExamDetails = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strExamDetails
    {
        get
        {
            return _strExamDetails;
        }
        set
        {
            _strExamDetails = value;
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

    private string _strContactInfo = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strContactInfo
    {
        get
        {
            return _strContactInfo;
        }
        set
        {
            _strContactInfo = value;
        }
    }
    
    private bool _bIsFeatured = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bIsFeatured
    {
        get
        {
            return _bIsFeatured;
        }
        set
        {
            _bIsFeatured = value;
        }
    }

    private int _iCategoryID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCategoryID
    {
        get
        {
            return _iCategoryID;
        }
        set
        {
            _iCategoryID = value;
        }
    }

    public string fn_SaveDistanceLearning()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_SaveDistanceLearning(strType, strName, strCity, strEmail, strWebsite, strImage, strDesc, strExamDetails,
            strContactInfo, bIsFeatured, strAdmissions, strResults);
    }

    public string fn_EditDistanceLearning()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_EditDistanceLearning(iID, strType, strName, strCity, strEmail, strWebsite, strImage, strDesc, strExamDetails,
            strContactInfo, bIsFeatured, strAdmissions, strResults);
    }

    public string fn_EditDistanceLearningWithoutImage()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_EditDistanceLearningWithoutImage(iID, strType, strName, strCity, strEmail, strWebsite,
            strDesc, strExamDetails, strContactInfo, bIsFeatured, strAdmissions, strResults);
    }

    public string fn_DeleteDistanceLearning()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_DeleteDistanceLearning(iID);
    }

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningByID()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetDistanceLearningByID(iID);
    }

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningByIdentities(string strIDs)
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetDistanceLearningByIdentities(strIDs);
    }

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningList()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetDistanceLearningList();
    }

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningListByType()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetDistanceLearningListByType(strType);
    }

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningListByName()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetDistanceLearningListByName(strName);
    }

    public CoreWebList<DistanceLearningClass> fn_GetRandomDistanceLearningListByType()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetRandomDistanceLearningListByType(strType);
    }

    public CoreWebList<DistanceLearningClass> fn_GetRandom_DistanceLearningListByType()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetRandom_DistanceLearningListByType(strType);
    }

    public CoreWebList<DistanceLearningClass> fn_GetRandomDistanceLearning()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetRandomDistanceLearning();
    }

    public CoreWebList<DistanceLearningClass> fn_Get_Random_DistanceLearningListByType()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_Get_Random_DistanceLearningListByType(strType);
    }

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningListGroupedByCENTERID()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetDistanceLearningListGroupedByCENTERID();
    }

    public CoreWebList<DistanceLearningClass> fn_SearchDLInst_ForClient(string strQuery)
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_SearchDLInst_ForClient(strQuery);
    }

    public CoreWebList<DistanceLearningClass> fn_SearchDLInst_ForClient()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_SearchDLInst_ForClient(iCategoryID, strCity, strName);
    }

    public CoreWebList<DistanceLearningClass> fn_SearchDistanceLearningInstitutes(string strQuery)
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_SearchDistanceLearningInstitutes(strQuery);
    }

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningInstitutesByCatID()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetDistanceLearningInstitutesByCatID(iCategoryID);
    }

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningInstitutesByKeyword(string strQuery)
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetDistanceLearningInstitutesByKeyword(strQuery);  
    }

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningInstitutesByCity()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetDistanceLearningInstitutesByCity(strCity);
    }

    public CoreWebList<DistanceLearningClass> fn_GetDistanceUniversityByCity()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetDistanceUniversityByCity(strCity);
    }

    public CoreWebList<DistanceLearningClass> fn_GetDistanceCollegesByCity()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetDistanceCollegesByCity(strCity);
    }

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningInstitutesByInstName()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetDistanceLearningInstitutesByInstName(strName);
    }

    public CoreWebList<DistanceLearningClass> fn_SearchDistanceLearningList(string strQuery)
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_SearchDistanceLearningList(strQuery);
    }

    public bool fn_GetFeaturedStatusByID()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetFeaturedStatusByID(iID);
    }

    public string fn_ChangeFeaturedStatus()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_ChangeFeaturedStatus(iID, bIsFeatured);
    }

    public CoreWebList<DistanceLearningClass> fn_GetDistanceLearningByCategoryID()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetDistanceLearningByCategoryID(iCategoryID);
    }

    public CoreWebList<DistanceLearningClass> fn_GetDLByCategoryID()
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetDLByCategoryID(iCategoryID);
    }

    public CoreWebList<DistanceLearningClass> fn_SearchDistanceLearningListClient(string strQuery)
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_SearchDistanceLearningListClient(strQuery);
    }
    public CoreWebList<DistanceLearningClass> fn_GetFeaturedInstitutes(int startRow, int endRow)
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_GetFeaturedInstitutes(startRow, endRow);
    }

    public CoreWebList<DistanceLearningClass> fn_Get_FeaturedInstitutesbyLocationAndCatID(string strQuery)
    {
        DBDistanceLearningClass objdb = new DBDistanceLearningClass();
        return objdb.fn_Get_FeaturedInstitutesbyLocationAndCatID(strQuery);
    }
}