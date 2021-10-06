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
/// Summary description for UniversityClass
/// </summary>

public class UniversityClass
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

    private int _iCountryID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCountryID
    {
        get
        {
            return _iCountryID;
        }
        set
        {
            _iCountryID = value;
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

	private string _strDetails = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strDetails
	{
		get
		{
			return _strDetails;
		}
		set
		{
			_strDetails = value;
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

	private string _strRanking = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strRanking
	{
		get
		{
			return _strRanking;
		}
		set
		{
			_strRanking = value;
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

	private string _strLogo = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strLogo
	{
		get
		{
			return _strLogo;
		}
		set
		{
			_strLogo = value;
		}
	}

	private DateTime _dtCeratedDate = DateTime.Now;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public DateTime dtCeratedDate
	{
		get
		{
			return _dtCeratedDate;
		}
		set
		{
			_dtCeratedDate = value;
		}
	}

	public string fn_saveUniversity()
	{
		DBUniversityClass objdb = new DBUniversityClass();
		return objdb.fn_saveUniversity(this);
	}

	public string fn_editUniversity()
	{
		DBUniversityClass objdb = new DBUniversityClass();
		return objdb.fn_editUniversity(this);
	}

	public string fn_deleteUniversity()
	{
		DBUniversityClass objdb = new DBUniversityClass();
		return objdb.fn_deleteUniversity(iID);
	}

	public CoreWebList<UniversityClass> fn_getUniversityList()
	{
		DBUniversityClass objdb = new DBUniversityClass();
		return objdb.fn_getUniversityList();
	}

	public CoreWebList<UniversityClass> fn_getUniversityByID()
	{
		DBUniversityClass objdb = new DBUniversityClass();
		return objdb.fn_getUniversityByID(iID);
	}

    public CoreWebList<UniversityClass> fn_getUniversityByCountryID()
    {
        DBUniversityClass objdb = new DBUniversityClass();
        return objdb.fn_getUniversityByCountryID(iCountryID);
    }

	public CoreWebList<UniversityClass> fn_getUniversityByName()
	{
		DBUniversityClass objdb = new DBUniversityClass();
		return objdb.fn_getUniversityByName(strTitle);
	}

	public CoreWebList<UniversityClass> fn_getUniversityByKeys()
	{
		DBUniversityClass objdb = new DBUniversityClass();
		return objdb.fn_getUniversityByKeys(strTitle);
	}

}
