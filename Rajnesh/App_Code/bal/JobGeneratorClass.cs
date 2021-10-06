using System;
using System.Collections.Generic;
using System.Web;
using yo_lib;

/// <summary>
/// Summary description for JobGeneratorClass
/// </summary>

public class JobGeneratorClass
{
    #region "Properties"

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

    private int _iCategory = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCategory
    {
        get
        {
            return _iCategory;
        }
        set
        {
            _iCategory = value;
        }
    }

    private int _iSubCategory = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iSubCategory 
    {
        get
        {
            return _iSubCategory;
        }
        set
        {
            _iSubCategory = value;
        }
    }

    private int _iComapny = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iComapny
    {
        get
        {
            return _iComapny;
        }
        set
        {
            _iComapny = value;
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

    private string _strPageTitle = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strPageTitle 
    {
        get
        {
            return _strPageTitle;
        }
        set
        {
            _strPageTitle = value;
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

    private string _strIdentities = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strIdentities
    {
        get
        {
            return _strIdentities;
        }
        set
        {
            _strIdentities = value;
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


    private string _strH1 = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strH1
    {
        get
        {
            return _strH1;
        }
        set
        {
            _strH1 = value;
        }
    }

    private string _strH2 = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strH2
    {
        get
        {
            return _strH2;
        }
        set
        {
            _strH2 = value;
        }
    }


    private string _strH3 = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strH3
    {
        get
        {
            return _strH3;
        }
        set
        {
            _strH3 = value;
        }
    }
    
    private string _strH4 = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strH4
    {
        get
        {
            return _strH4;
        }
        set
        {
            _strH4 = value;
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

    private string _strMetaDescription = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strMetaDescription
    {
        get
        {
            return _strMetaDescription;
        }
        set
        {
            _strMetaDescription = value;
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

    private bool _bCompany = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bCompany
    {
        get
        {
            return _bCompany;
        }
        set
        {
            _bCompany = value;
        }
    }

    private bool _bCategory = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bCategory
    {
        get
        {
            return _bCategory;
        }
        set
        {
            _bCategory = value;
        }
    }

    private bool _bLocation = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bLocation
    {
        get
        {
            return _bLocation;
        }
        set
        {
            _bLocation = value;
        }
    }

    private bool _bLinkStatus = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bLinkStatus
    {
        get
        {
            return _bLinkStatus;
        }
        set
        {
            _bLinkStatus = value;
        }
    }

    private string _strTargetUrl = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strTargetUrl
    {
        get
        {
            return _strTargetUrl;
        }
        set
        {
            _strTargetUrl = value;
        }
    }

    private DateTime _dtCreatedDate = DateTime.Now;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public DateTime dtCreatedDate
    {
        get
        {
            return _dtCreatedDate;
        }
        set
        {
            _dtCreatedDate = value;
        }
    }

    #endregion

    #region "functions"

    public string fn_SaveJobGenerator()
    {
        DBJobGeneratorClass objdb = new DBJobGeneratorClass();
        return objdb.fn_SaveJobGenerator(strFileName, strPageTitle, strType, strIdentities, strH1, strH2, strH3, strH4, strMetaTitle, strMetaDescription, strKeywords, iCategory, iSubCategory, strCity, iComapny, bCompany, bCategory, bLocation, bLinkStatus, strTargetUrl);
    }

    public string fn_EditJob()
    {
        DBJobGeneratorClass objdb = new DBJobGeneratorClass();
        return objdb.fn_EditJob(iID, strFileName, strPageTitle, strType, strIdentities, strH1, strH2, strH3, strH4, strMetaTitle, strMetaDescription, strKeywords, iCategory, iSubCategory, strCity, iComapny, bCompany, bCategory, bLocation, bLinkStatus, strTargetUrl);
    }

    public CoreWebList<JobGeneratorClass> fn_GetJobById()
    {
        DBJobGeneratorClass objdb = new DBJobGeneratorClass();
        return objdb.fn_GetJobById(iID);
    }

    public CoreWebList<JobGeneratorClass> fn_GetJobByFileName()
    {
        DBJobGeneratorClass objdb = new DBJobGeneratorClass();
        return objdb.fn_GetJobByFileName(strFileName);
    }

    public CoreWebList<JobGeneratorClass> fn_GetRandomJobByCategoryID()
    {
        DBJobGeneratorClass objdb = new DBJobGeneratorClass();
        return objdb.fn_GetRandomJobByCategoryID(iCategory);
    }

    public CoreWebList<JobGeneratorClass> fn_GetRandomJobBy_CategoryID()
    {
        DBJobGeneratorClass objdb = new DBJobGeneratorClass();
        return objdb.fn_GetRandomJobBy_CategoryID(iCategory);
    }

    public CoreWebList<JobGeneratorClass> fn_GetJobBypageTitle()
    {
        DBJobGeneratorClass objdb = new DBJobGeneratorClass();
        return objdb.fn_GetJobBypageTitle(strPageTitle);
    }


    public string fn_DeleteJob()
    {
        DBJobGeneratorClass objdb = new DBJobGeneratorClass();
        return objdb.fn_DeleteJob(iID);
    }

    public CoreWebList<JobGeneratorClass> fn_GetJobList()
    {
        DBJobGeneratorClass objdb = new DBJobGeneratorClass();
        return objdb.fn_GetJobList();
    }

    public CoreWebList<JobGeneratorClass> fn_Get_JobList()
    {
        DBJobGeneratorClass objdb = new DBJobGeneratorClass();
        return objdb.fn_Get_JobList();
    }

    public CoreWebList<JobGeneratorClass> fn_Get_JobListByLinkStatus()
    {
        DBJobGeneratorClass objdb = new DBJobGeneratorClass();
        return objdb.fn_Get_JobListByLinkStatus();
    }

    public CoreWebList<JobGeneratorClass> fn_Get_JobListforCustomPager(int iRowStart, int iRowEnd)
    {
        DBJobGeneratorClass objdb = new DBJobGeneratorClass();
        return objdb.fn_Get_JobListforCustomPager(iRowStart, iRowEnd);
    }

    public CoreWebList<JobGeneratorClass> fn_Get_JobByQuery(string strQuery)
    {
        DBJobGeneratorClass objdb = new DBJobGeneratorClass();
        return objdb.fn_Get_JobByQuery(strQuery);
    }

    public CoreWebList<JobGeneratorClass> fn_GetJobByTargetUrl()
    {
        DBJobGeneratorClass objdb = new DBJobGeneratorClass();
        return objdb.fn_GetJobByTargetUrl(strTargetUrl);
    }

    #endregion

}
