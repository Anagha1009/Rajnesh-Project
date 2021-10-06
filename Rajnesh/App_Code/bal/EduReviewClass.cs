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
/// Summary description for EduReviewClass
/// </summary>

public class EduReviewClass
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

	private string _strInstitutionType = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strInstitutionType
	{
		get
		{
			return _strInstitutionType;
		}
		set
		{
			_strInstitutionType = value;
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

	private int _iInstitutionID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iInstitutionID
	{
		get
		{
			return _iInstitutionID;
		}
		set
		{
			_iInstitutionID = value;
		}
	}

	private string _strUserType = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strUserType
	{
		get
		{
			return _strUserType;
		}
		set
		{
			_strUserType = value;
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

    private bool _bActive = false;
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

	public int fn_saveEduReview()
	{
		DBEduReviewClass objdb = new DBEduReviewClass();
		return objdb.fn_saveEduReview(this);
	}

	public string fn_editEduReview()
	{
		DBEduReviewClass objdb = new DBEduReviewClass();
		return objdb.fn_editEduReview(this);
	}

	public string fn_deleteEduReview()
	{
		DBEduReviewClass objdb = new DBEduReviewClass();
		return objdb.fn_deleteEduReview(iID);
	}

    public string fn_ChangeReviewActiveStatus()
    {
        DBEduReviewClass objdb = new DBEduReviewClass();
        return objdb.fn_ChangeReviewActiveStatus(this);
    }

	public CoreWebList<EduReviewClass> fn_getEduReviewList()
	{
		DBEduReviewClass objdb = new DBEduReviewClass();
		return objdb.fn_getEduReviewList();
	}

    public CoreWebList<EduReviewClass> fn_getEduReviewByType()
    {
        DBEduReviewClass objdb = new DBEduReviewClass();
        return objdb.fn_getEduReviewByType(strInstitutionType, iInstitutionID);
    }

    public CoreWebList<EduReviewClass> fn_getInstituteReviewById()
    {
        DBEduReviewClass objdb = new DBEduReviewClass();
        return objdb.fn_getInstituteReviewById(iInstitutionID);
    }

	public CoreWebList<EduReviewClass> fn_getEduReviewByID()
	{
		DBEduReviewClass objdb = new DBEduReviewClass();
		return objdb.fn_getEduReviewByID(iID);
	}

	public CoreWebList<EduReviewClass> fn_getEduReviewByName()
	{
		DBEduReviewClass objdb = new DBEduReviewClass();
		return objdb.fn_getEduReviewByName(strTitle);
	}

	public CoreWebList<EduReviewClass> fn_getEduReviewByKeys()
	{
		DBEduReviewClass objdb = new DBEduReviewClass();
        return objdb.fn_getEduReviewByKeys(strTitle);
	}

    public CoreWebList<EduReviewClass> fn_getEduReviewByTypeKeys()
    {
        DBEduReviewClass objdb = new DBEduReviewClass();
        return objdb.fn_getEduReviewByTypeKeys(strInstitutionType, strTitle);
    }

}
