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
/// Summary description for InstituteClass
/// </summary>

public class InstituteClass
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

    private int _iEntranceExamID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iEntranceExamID
    {
        get
        {
            return _iEntranceExamID;
        }
        set
        {
            _iEntranceExamID = value;
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

	private string _strPlacements = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strPlacements
	{
		get
		{
			return _strPlacements;
		}
		set
		{
			_strPlacements = value;
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

	public string fn_saveInstitute()
	{
		DBInstituteClass objdb = new DBInstituteClass();
		return objdb.fn_saveInstitute(this);
	}

	public string fn_editInstitute()
	{
		DBInstituteClass objdb = new DBInstituteClass();
		return objdb.fn_editInstitute(this);
	}

	public string fn_deleteInstitute()
	{
		DBInstituteClass objdb = new DBInstituteClass();
		return objdb.fn_deleteInstitute(iID);
	}

	public CoreWebList<InstituteClass> fn_getInstituteList()
	{
		DBInstituteClass objdb = new DBInstituteClass();
		return objdb.fn_getInstituteList();
	}

    public CoreWebList<InstituteClass> fn_getHomeFeaturedInstituteList()
    {
        DBInstituteClass objdb = new DBInstituteClass();
        return objdb.fn_getHomeFeaturedInstituteList();
    }

    public CoreWebList<InstituteClass> fn_getInstituteListByQuery(string strQuery)
    {
        DBInstituteClass objdb = new DBInstituteClass();
        return objdb.fn_getInstituteListByQuery(strQuery);
    }

    public CoreWebList<InstituteClass> fn_SearchByQuery(string strQuery)
    {
        DBInstituteClass objdb = new DBInstituteClass();
        return objdb.fn_SearchByQuery(strQuery);
    }

	public CoreWebList<InstituteClass> fn_getInstituteByID()
	{
		DBInstituteClass objdb = new DBInstituteClass();
		return objdb.fn_getInstituteByID(iID);
	}

    public CoreWebList<InstituteClass> fn_getInstituteByEntranceExamID()
    {
        DBInstituteClass objdb = new DBInstituteClass();
        return objdb.fn_getInstituteByEntranceExamID(iEntranceExamID);
    }

    public CoreWebList<InstituteClass> fn_getInstituteByIdentity(string strIdentity)
    {
        DBInstituteClass objdb = new DBInstituteClass();
        return objdb.fn_getInstituteByIdentity(strIdentity, iCategoryID);
    }

	public CoreWebList<InstituteClass> fn_getInstituteByName()
	{
		DBInstituteClass objdb = new DBInstituteClass();
		return objdb.fn_getInstituteByName(strTitle);
	}

	public CoreWebList<InstituteClass> fn_getInstituteByKeys()
	{
		DBInstituteClass objdb = new DBInstituteClass();
		return objdb.fn_getInstituteByKeys(strTitle);
	}

	public CoreWebList<InstituteClass> fn_getInstituteByCityID()
	{
		DBInstituteClass objdb = new DBInstituteClass();
		return objdb.fn_getInstituteByCityID(iCityID);
	}

    public CoreWebList<InstituteClass> fn_getInstituteByCategoryIDCityID()
    {
        DBInstituteClass objdb = new DBInstituteClass();
        return objdb.fn_getInstituteByCategoryIDCityID(iCategoryID, iCityID);
    }

    public CoreWebList<InstituteClass> fn_getRandomInstituteByCityID()
    {
        DBInstituteClass objdb = new DBInstituteClass();
        return objdb.fn_getRandomInstituteByCityID(iCityID);
    }

    public CoreWebList<InstituteClass> fn_getRandomInstituteList()
    {
        DBInstituteClass objdb = new DBInstituteClass();
        return objdb.fn_getRandomInstituteList();
    }

    public CoreWebList<InstituteClass> fn_get_Random_InstituteList()
    {
        DBInstituteClass objdb = new DBInstituteClass();
        return objdb.fn_get_Random_InstituteList();
    }

	public string fn_ChangeInstituteFeaturedStatus()
	{
		DBInstituteClass objdb = new DBInstituteClass();
		return objdb.fn_ChangeInstituteFeaturedStatus(this);
	}

    public string fn_ChangeInstituteHomeFeaturedStatus()
    {
        DBInstituteClass objdb = new DBInstituteClass();
        return objdb.fn_ChangeInstituteHomeFeaturedStatus(this);
    }

}
