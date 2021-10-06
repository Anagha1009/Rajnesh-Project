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
/// Summary description for CompetitionUserClass
/// </summary>

public class CompetitionUserClass
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

    private int _iCompetitionID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCompetitionID
    {
        get
        {
            return _iCompetitionID;
        }
        set
        {
            _iCompetitionID = value;
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

	private int _iQualificationID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iQualificationID
	{
		get
		{
			return _iQualificationID;
		}
		set
		{
			_iQualificationID = value;
		}
	}

    private bool _bAnswer = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bAnswer
    {
        get
        {
            return _bAnswer;
        }
        set
        {
            _bAnswer = value;
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

    private string _strQualification = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strQualification
    {
        get
        {
            return _strQualification;
        }
        set
        {
            _strQualification = value;
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

    private bool _bGender = true;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bGender
    {
        get
        {
            return _bGender;
        }
        set
        {
            _bGender = value;
        }
    }

	private string _strMobile = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strMobile
	{
		get
		{
			return _strMobile;
		}
		set
		{
			_strMobile = value;
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

    private string _strFacebookID = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strFacebookID
    {
        get
        {
            return _strFacebookID;
        }
        set
        {
            _strFacebookID = value;
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

	private DateTime _dtDate = DateTime.Now;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public DateTime dtDate
	{
		get
		{
			return _dtDate;
		}
		set
		{
			_dtDate = value;
		}
	}

    public int fn_saveCompetitionUser()
    {
        DBCompetitionUserClass objdb = new DBCompetitionUserClass();
        return objdb.fn_saveCompetitionUser(this);
    }

    public int fn_save_CompetitionUser()
    {
        DBCompetitionUserClass objdb = new DBCompetitionUserClass();
        return objdb.fn_save_CompetitionUser(this);
    }

    public string fn_editCompetitionUser()
	{
		DBCompetitionUserClass objdb = new DBCompetitionUserClass();
		return objdb.fn_editCompetitionUser(this);
	}

    public string fn_edit_CompetitionUser()
    {
        DBCompetitionUserClass objdb = new DBCompetitionUserClass();
        return objdb.fn_edit_CompetitionUser(this);
    }

	public string fn_deleteCompetitionUser()
	{
		DBCompetitionUserClass objdb = new DBCompetitionUserClass();
		return objdb.fn_deleteCompetitionUser(iID);
	}

	public CoreWebList<CompetitionUserClass> fn_getCompetitionUserList()
	{
		DBCompetitionUserClass objdb = new DBCompetitionUserClass();
		return objdb.fn_getCompetitionUserList();
	}

	public CoreWebList<CompetitionUserClass> fn_getCompetitionUserByID()
	{
		DBCompetitionUserClass objdb = new DBCompetitionUserClass();
		return objdb.fn_getCompetitionUserByID(iID);
	}

    public CoreWebList<CompetitionUserClass> fn_getCompetitionUserByCompetitionID()
    {
        DBCompetitionUserClass objdb = new DBCompetitionUserClass();
        return objdb.fn_getCompetitionUserByCompetitionID(iCompetitionID);
    }

    public CoreWebList<CompetitionUserClass> fn_getCompetitionFileUserByCompetitionID()
    {
        DBCompetitionUserClass objdb = new DBCompetitionUserClass();
        return objdb.fn_getCompetitionFileUserByCompetitionID(iCompetitionID);
    }

	public CoreWebList<CompetitionUserClass> fn_getCompetitionUserByName()
	{
		DBCompetitionUserClass objdb = new DBCompetitionUserClass();
		return objdb.fn_getCompetitionUserByName(strName);
	}

    public CoreWebList<CompetitionUserClass> fn_getNewsLetterUsers(string strQuery)
    {
        DBCompetitionUserClass objdb = new DBCompetitionUserClass();
        return objdb.fn_getNewsLetterUsers(strQuery);
    }

    public CoreWebList<CompetitionUserClass> fn_getCompetitionUserByEmail()
    {
        DBCompetitionUserClass objdb = new DBCompetitionUserClass();
        return objdb.fn_getCompetitionUserByEmail(strEmail);
    }

	public CoreWebList<CompetitionUserClass> fn_getCompetitionUserByKeys()
	{
		DBCompetitionUserClass objdb = new DBCompetitionUserClass();
		return objdb.fn_getCompetitionUserByKeys(strName, iCompetitionID);
	}

    public CoreWebList<CompetitionUserClass> fn_getCompetitionFileUserByKeys()
    {
        DBCompetitionUserClass objdb = new DBCompetitionUserClass();
        return objdb.fn_getCompetitionFileUserByKeys(iCompetitionID, strName);
    }

    public CoreWebList<CompetitionUserClass> fn_getCompetitionUserAnswersByID()
    {
        DBCompetitionUserClass objdb = new DBCompetitionUserClass();
        return objdb.fn_getCompetitionUserAnswersByID(iCompetitionID, iID);
    }

	public CoreWebList<CompetitionUserClass> fn_getCompetitionUserByQualificationID()
	{
		DBCompetitionUserClass objdb = new DBCompetitionUserClass();
		return objdb.fn_getCompetitionUserByQualificationID(iQualificationID);
	}

}
