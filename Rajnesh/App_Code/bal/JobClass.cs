using System;
using System.Collections.Generic;
using System.Web;
using yo_lib;

/// <summary>
/// Summary description for JobClass
/// </summary>
public class JobClass
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

    private string _strCategory = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCategory
    {
        get
        {
            return _strCategory;
        }
        set
        {
            _strCategory = value;
        }
    }

    private string _strSubCategory = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strSubCategory
    {
        get
        {
            return _strSubCategory;
        }
        set
        {
            _strSubCategory = value;
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


    private string _strDescription = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strDescription
    {
        get
        {
            return _strDescription;
        }
        set
        {
            _strDescription = value;
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


    private int _iSubCategoryID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iSubCategoryID
    {
        get
        {
            return _iSubCategoryID;
        }
        set
        {
            _iSubCategoryID = value;
        }
    }

    private int _iCompanyID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCompanyID
    {
        get
        {
            return _iCompanyID;
        }
        set
        {
            _iCompanyID = value;
        }
    }


    private int _iLocationID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iLocationID
    {
        get
        {
            return _iLocationID;
        }
        set
        {
            _iLocationID = value;
        }
    }

    private int _iPostedBy = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iPostedBy
    {
        get
        {
            return _iPostedBy;
        }
        set
        {
            _iPostedBy = value;
        }
    }

    private DateTime _dtPostedDate = System.DateTime.Now;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public DateTime dtPostedDate
    {
        get
        {
            return _dtPostedDate;
        }
        set
        {
            _dtPostedDate = value;
        }
    }

    private bool _bActive = true;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bActive
    {
        get
        {
            return _bActive;
        }
        set
        {
            _bActive = value;
        }
    }

    private bool _bGovernment = true;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bGovernment
    {
        get
        {
            return _bGovernment;
        }
        set
        {
            _bGovernment = value;
        }
    }

    private DateTime _dtExpirationDate = DateTime.Now;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public DateTime dtExpirationDate
    {
        get
        {
            return _dtExpirationDate;
        }
        set
        {
            _dtExpirationDate = value;
        }
    }

    private string _strIdentity = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strIdentity
    {
        get
        {
            return _strIdentity;
        }
        set
        {
            _strIdentity = value;
        }
    }

    public string fn_SaveJob()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_SaveJob(strTitle, strDescription, iCategoryID, iSubCategoryID, iLocationID, iCompanyID, iPostedBy, bActive, dtExpirationDate);
    }


    public string fn_editJob()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_editJob(iID, strTitle, strDescription, iCategoryID, iSubCategoryID, iLocationID, iCompanyID, dtExpirationDate);
    }

    public string fn_ChangeGovernmentStatus()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_ChangeGovernmentStatus(iID, bGovernment);
    }

    public string fn_ChangeJobStatus()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_ChangeJobStatus(iID, bActive);
    }


    public string fn_deleteJob()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_deleteJob(iID);
    }


    public CoreWebList<JobClass> fn_get_JobList()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_get_JobList();
    }

    public CoreWebList<JobClass> fn_getLatest_JobList()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_getLatest_JobList();
    }

    public CoreWebList<JobClass> fn_get_JobByQuery(string strQuery)
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_get_JobByQuery(strQuery);
    }

    public CoreWebList<JobClass> fn_get_JobListByRandom()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_get_JobListByRandom();
    }


    public CoreWebList<JobClass> fn_get_JobListinRangeByRandom()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_get_JobListinRangeByRandom();
    }


    public CoreWebList<JobClass> fn_get_JobListByQuery(string strQuery)
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_get_JobListByQuery(strQuery);
    }


    public CoreWebList<JobClass> fn_get_JobByID()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_get_JobByID(iID);
    }

    public CoreWebList<JobClass> fn_get_JobByUserID()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_get_JobByUserID(iPostedBy);
    }


    public CoreWebList<JobClass> fn_get_RandomJobByCategoryID()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_get_RandomJobByCategoryID(iCategoryID);
    }

    public CoreWebList<JobClass> fn_getRandomGovernmentJobs()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_getRandomGovernmentJobs();
    }

    public CoreWebList<JobClass> fn_getLatestJobs()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_getLatestJobs();
    }

    public CoreWebList<JobClass> fn_getRandomJobByCategoryID()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_getRandomJobByCategoryID(iCategoryID);
    }

    public CoreWebList<JobClass> fn_getRandomJobByCompanyID()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_getRandomJobByCompanyID(iCompanyID);
    }

    public CoreWebList<JobClass> fn_getRandomJobBy_CompanyID()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_getRandomJobBy_CompanyID(iCompanyID);
    }

    public CoreWebList<JobClass> fn_getJobByCategoryID()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_getJobByCategoryID(iCategoryID);
    }


    public CoreWebList<JobClass> fn_get_RandomJobByCompanyID()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_get_RandomJobByCompanyID(iCompanyID);
    }

    public CoreWebList<JobClass> fn_getRandomJobs()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_getRandomJobs(iCategoryID, iLocationID);
    }

    public CoreWebList<JobClass> fn_getJobByCompanyID()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_getJobByCompanyID(iCompanyID);
    }


    public CoreWebList<JobClass> fn_get_JobByIdentity(string strIdentities)
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_get_JobByIdentity(strIdentities);
    }

    public CoreWebList<JobClass> fn_getRandomJobByIdentity()
    {
        DBJobClass objdb = new DBJobClass();
        return objdb.fn_getRandomJobByIdentity(strIdentity);
    }

}
