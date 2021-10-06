using System;
using System.Data;
using System.Collections;
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
/// Summary description for SchoolClass
/// </summary>

public class SchoolClass
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

	private int _iCityID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iCityID
	{
		get
		{
			return _iCityID;
		}
		set
		{
			_iCityID = value;
		}
	}

    private int _iRank = 0;
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

	private string _strFacilities = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strFacilities
	{
		get
		{
			return _strFacilities;
		}
		set
		{
			_strFacilities = value;
		}
	}

	private string _strContactDetails = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strContactDetails
	{
		get
		{
			return _strContactDetails;
		}
		set
		{
			_strContactDetails = value;
		}
	}

	private string _strAfflialtedBoard = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strAfflialtedBoard
	{
		get
		{
			return _strAfflialtedBoard;
		}
		set
		{
			_strAfflialtedBoard = value;
		}
	}

	private string _strTrust = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strTrust
	{
		get
		{
			return _strTrust;
		}
		set
		{
			_strTrust = value;
		}
	}

	private string _strPrincipal = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strPrincipal
	{
		get
		{
			return _strPrincipal;
		}
		set
		{
			_strPrincipal = value;
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

	private string _strPhoto = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strPhoto
	{
		get
		{
			return _strPhoto;
		}
		set
		{
			_strPhoto = value;
		}
	}

	public string fn_saveSchool()
	{
		DBSchoolClass objdb = new DBSchoolClass();
		return objdb.fn_saveSchool(this);
	}

	public string fn_editSchool()
	{
		DBSchoolClass objdb = new DBSchoolClass();
		return objdb.fn_editSchool(this);
	}

	public string fn_deleteSchool()
	{
		DBSchoolClass objdb = new DBSchoolClass();
		return objdb.fn_deleteSchool(iID);
	}

	public CoreWebList<SchoolClass> fn_getSchoolList()
	{
		DBSchoolClass objdb = new DBSchoolClass();
		return objdb.fn_getSchoolList();
	}

    public CoreWebList<SchoolClass> fn_getHomeFeaturedSchoolList()
    {
        DBSchoolClass objdb = new DBSchoolClass();
        return objdb.fn_getHomeFeaturedSchoolList();
    }

    public CoreWebList<SchoolClass> fn_getRandomSchoolList()
    {
        DBSchoolClass objdb = new DBSchoolClass();
        return objdb.fn_getRandomSchoolList();
    }

    public CoreWebList<SchoolClass> fn_get_Random_SchoolList()
    {
        DBSchoolClass objdb = new DBSchoolClass();
        return objdb.fn_get_Random_SchoolList();
    }

    public CoreWebList<SchoolClass> fn_getSchoolListByQuery(string strQuery)
    {
        DBSchoolClass objdb = new DBSchoolClass();
        return objdb.fn_getSchoolListByQuery(strQuery);
    }

	public CoreWebList<SchoolClass> fn_getSchoolByID()
	{
		DBSchoolClass objdb = new DBSchoolClass();
		return objdb.fn_getSchoolByID(iID);
	}

    public CoreWebList<SchoolClass> fn_getSchoolByIdentity(string strIdentity)
    {
        DBSchoolClass objdb = new DBSchoolClass();
        return objdb.fn_getSchoolByIdentity(strIdentity);
    }

	public CoreWebList<SchoolClass> fn_getSchoolByName()
	{
		DBSchoolClass objdb = new DBSchoolClass();
		return objdb.fn_getSchoolByName(strTitle);
	}

	public CoreWebList<SchoolClass> fn_getSchoolByKeys()
	{
		DBSchoolClass objdb = new DBSchoolClass();
		return objdb.fn_getSchoolByKeys(strTitle);
	}

	public CoreWebList<SchoolClass> fn_getSchoolByCityID()
	{
		DBSchoolClass objdb = new DBSchoolClass();
		return objdb.fn_getSchoolByCityID(iCityID);
	}

    public CoreWebList<SchoolClass> fn_getRandomSchoolByCityID()
    {
        DBSchoolClass objdb = new DBSchoolClass();
        return objdb.fn_getRandomSchoolByCityID(iCityID);
    }

	public string fn_ChangeSchoolFeaturedStatus()
	{
		DBSchoolClass objdb = new DBSchoolClass();
		return objdb.fn_ChangeSchoolFeaturedStatus(this);
	}

    public string fn_ChangeSchoolHomeFeaturedStatus()
    {
        DBSchoolClass objdb = new DBSchoolClass();
        return objdb.fn_ChangeSchoolHomeFeaturedStatus(this);
    }

}
