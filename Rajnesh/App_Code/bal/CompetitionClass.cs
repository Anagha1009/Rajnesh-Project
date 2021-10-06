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
/// Summary description for CompetitionClass
/// </summary>

public class CompetitionClass
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

	private string _strShortDetails = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strShortDetails
	{
		get
		{
			return _strShortDetails;
		}
		set
		{
			_strShortDetails = value;
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

	private string _strPrizeDetails = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strPrizeDetails
	{
		get
		{
			return _strPrizeDetails;
		}
		set
		{
			_strPrizeDetails = value;
		}
	}

	private string _strBgColor = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strBgColor
	{
		get
		{
			return _strBgColor;
		}
		set
		{
			_strBgColor = value;
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

	public string fn_saveCompetition()
	{
		DBCompetitionClass objdb = new DBCompetitionClass();
		return objdb.fn_saveCompetition(this);
	}

	public string fn_editCompetition()
	{
		DBCompetitionClass objdb = new DBCompetitionClass();
		return objdb.fn_editCompetition(this);
	}

	public string fn_deleteCompetition()
	{
		DBCompetitionClass objdb = new DBCompetitionClass();
		return objdb.fn_deleteCompetition(iID);
	}

	public CoreWebList<CompetitionClass> fn_getCompetitionList()
	{
		DBCompetitionClass objdb = new DBCompetitionClass();
		return objdb.fn_getCompetitionList();
	}

    public CoreWebList<CompetitionClass> fn_getRandomCompetitionList()
    {
        DBCompetitionClass objdb = new DBCompetitionClass();
        return objdb.fn_getRandomCompetitionList();
    }

	public CoreWebList<CompetitionClass> fn_getCompetitionByID()
	{
		DBCompetitionClass objdb = new DBCompetitionClass();
		return objdb.fn_getCompetitionByID(iID);
	}

    public CoreWebList<CompetitionClass> fn_getOtherCompetitionByID()
    {
        DBCompetitionClass objdb = new DBCompetitionClass();
        return objdb.fn_getOtherCompetitionByID(iID);
    }

	public CoreWebList<CompetitionClass> fn_getCompetitionByName()
	{
		DBCompetitionClass objdb = new DBCompetitionClass();
		return objdb.fn_getCompetitionByName(strTitle);
	}

	public CoreWebList<CompetitionClass> fn_getCompetitionByKeys()
	{
		DBCompetitionClass objdb = new DBCompetitionClass();
		return objdb.fn_getCompetitionByKeys(strTitle);
	}

	public string fn_ChangeCompetitionActiveStatus()
	{
		DBCompetitionClass objdb = new DBCompetitionClass();
		return objdb.fn_ChangeCompetitionActiveStatus(this);
	}

}
