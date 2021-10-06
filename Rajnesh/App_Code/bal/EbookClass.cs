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
/// Summary description for EbookClass
/// </summary>

public class EbookClass
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

	private string _strFile = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strFile
	{
		get
		{
			return _strFile;
		}
		set
		{
			_strFile = value;
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

	public string fn_saveEbook()
	{
		DBEbookClass objdb = new DBEbookClass();
		return objdb.fn_saveEbook(this);
	}

	public string fn_editEbook()
	{
		DBEbookClass objdb = new DBEbookClass();
		return objdb.fn_editEbook(this);
	}

	public string fn_deleteEbook()
	{
		DBEbookClass objdb = new DBEbookClass();
		return objdb.fn_deleteEbook(iID);
	}

	public CoreWebList<EbookClass> fn_getEbookList()
	{
		DBEbookClass objdb = new DBEbookClass();
		return objdb.fn_getEbookList();
	}

	public CoreWebList<EbookClass> fn_getEbookByID()
	{
		DBEbookClass objdb = new DBEbookClass();
		return objdb.fn_getEbookByID(iID);
	}

	public CoreWebList<EbookClass> fn_getEbookByName()
	{
		DBEbookClass objdb = new DBEbookClass();
		return objdb.fn_getEbookByName(strTitle);
	}

	public CoreWebList<EbookClass> fn_getEbookByKeys()
	{
		DBEbookClass objdb = new DBEbookClass();
		return objdb.fn_getEbookByKeys(strTitle);
	}

}
