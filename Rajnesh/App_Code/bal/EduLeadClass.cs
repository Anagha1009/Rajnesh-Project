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
/// Summary description for EduLeadClass
/// </summary>

public class EduLeadClass
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

	private int _iCurrentQualificationID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iCurrentQualificationID
	{
		get
		{
			return _iCurrentQualificationID;
		}
		set
		{
			_iCurrentQualificationID = value;
		}
	}

	private int _iEducationInterestID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iEducationInterestID
	{
		get
		{
			return _iEducationInterestID;
		}
		set
		{
			_iEducationInterestID = value;
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

	private int _iTypeId = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iTypeId
	{
		get
		{
			return _iTypeId;
		}
		set
		{
			_iTypeId = value;
		}
	}

    private string _strInstitutionName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strInstitutionName
    {
        get
        {
            return _strInstitutionName;
        }
        set
        {
            _strInstitutionName = value;
        }
    }

    private string _strFirstName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strFirstName
    {
        get
        {
            return _strFirstName;
        }
        set
        {
            _strFirstName = value;
        }
    }

    private string _strLastName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strLastName
    {
        get
        {
            return _strLastName;
        }
        set
        {
            _strLastName = value;
        }
    }

    private string _strFullName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strFullName
    {
        get
        {
            return _strFullName;
        }
        set
        {
            _strFullName = value;
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

    private DateTime _dtDoB = DateTime.Now;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public DateTime dtDoB
    {
        get
        {
            return _dtDoB;
        }
        set
        {
            _dtDoB = value;
        }
    }

    private string _strMobileNo = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strMobileNo
    {
        get
        {
            return _strMobileNo;
        }
        set
        {
            _strMobileNo = value;
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

    private string _strCurrentQualification = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCurrentQualification
    {
        get
        {
            return _strCurrentQualification;
        }
        set
        {
            _strCurrentQualification = value;
        }
    }

	private string _strEducationInterest = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strEducationInterest
	{
		get
		{
            return _strEducationInterest;
		}
		set
		{
            _strEducationInterest = value;
		}
	}

	private string _strComment = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strComment
	{
		get
		{
			return _strComment;
		}
		set
		{
			_strComment = value;
		}
	}

	private bool _bEducationLoan = false;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public bool bEducationLoan
	{
		get
		{
			return _bEducationLoan;
		}
		set
		{
			_bEducationLoan = value;
		}
	}

	private string _strIpAddrs = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strIpAddrs
	{
		get
		{
			return _strIpAddrs;
		}
		set
		{
			_strIpAddrs = value;
		}
	}

    private string _strFromDate = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strFromDate
    {
        get
        {
            return _strFromDate;
        }
        set
        {
            _strFromDate = value;
        }
    }

    private string _strToDate = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strToDate
    {
        get
        {
            return _strToDate;
        }
        set
        {
            _strToDate = value;
        }
    }

    private string _strKeys = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strKeys
    {
        get
        {
            return _strKeys;
        }
        set
        {
            _strKeys = value;
        }
    }

	private DateTime _dtRegDate = DateTime.Now;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public DateTime dtRegDate
	{
		get
		{
			return _dtRegDate;
		}
		set
		{
			_dtRegDate = value;
		}
	}

	public string fn_saveEduLead()
	{
		DBEduLeadClass objdb = new DBEduLeadClass();
		return objdb.fn_saveEduLead(this);
	}

	public string fn_deleteEduLead()
	{
		DBEduLeadClass objdb = new DBEduLeadClass();
		return objdb.fn_deleteEduLead(iID);
	}

	public CoreWebList<EduLeadClass> fn_getEduLeadList()
	{
		DBEduLeadClass objdb = new DBEduLeadClass();
		return objdb.fn_getEduLeadList();
	}

    public CoreWebList<EduLeadClass> fn_SearchEducationLeads()
    {
        DBEduLeadClass objdb = new DBEduLeadClass();
        return objdb.fn_SearchEducationLeads(this);
    }

    public CoreWebList<EduLeadClass> fn_getEduLeadLinks()
    {
        DBEduLeadClass objdb = new DBEduLeadClass();
        return objdb.fn_getEduLeadLinks();
    }

	public CoreWebList<EduLeadClass> fn_getEduLeadByID()
	{
		DBEduLeadClass objdb = new DBEduLeadClass();
		return objdb.fn_getEduLeadByID(iID);
	}

	public CoreWebList<EduLeadClass> fn_getEduLeadByName()
	{
		DBEduLeadClass objdb = new DBEduLeadClass();
		return objdb.fn_getEduLeadByName(strFirstName);
	}

	public CoreWebList<EduLeadClass> fn_getEduLeadByKeys()
	{
		DBEduLeadClass objdb = new DBEduLeadClass();
		return objdb.fn_getEduLeadByKeys(strFirstName);
	}

	public CoreWebList<EduLeadClass> fn_getEduLeadByEducationInterestID()
	{
		DBEduLeadClass objdb = new DBEduLeadClass();
		return objdb.fn_getEduLeadByEducationInterestID(iEducationInterestID);
	}

	public CoreWebList<EduLeadClass> fn_getEduLeadByCurrentQualificationID()
	{
		DBEduLeadClass objdb = new DBEduLeadClass();
		return objdb.fn_getEduLeadByCurrentQualificationID(iCurrentQualificationID);
	}

	public string fn_ChangeEduLeadEducationLoanStatus()
	{
		DBEduLeadClass objdb = new DBEduLeadClass();
		return objdb.fn_ChangeEduLeadEducationLoanStatus(this);
	}

}
