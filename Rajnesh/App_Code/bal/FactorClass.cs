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
/// Summary description for FactorClass
/// </summary>

public class FactorClass
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

	private int _iHeadingID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iHeadingID
	{
		get
		{
			return _iHeadingID;
		}
		set
		{
			_iHeadingID = value;
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

	public string fn_saveFactor()
	{
		DBFactorClass objdb = new DBFactorClass();
		return objdb.fn_saveFactor(this);
	}

	public string fn_editFactor()
	{
		DBFactorClass objdb = new DBFactorClass();
		return objdb.fn_editFactor(this);
	}

	public string fn_deleteFactor()
	{
		DBFactorClass objdb = new DBFactorClass();
		return objdb.fn_deleteFactor(iID);
	}

	public CoreWebList<FactorClass> fn_getFactorList()
	{
		DBFactorClass objdb = new DBFactorClass();
		return objdb.fn_getFactorList();
	}

	public CoreWebList<FactorClass> fn_getFactorByID()
	{
		DBFactorClass objdb = new DBFactorClass();
		return objdb.fn_getFactorByID(iID);
	}

	public CoreWebList<FactorClass> fn_getFactorByName()
	{
		DBFactorClass objdb = new DBFactorClass();
		return objdb.fn_getFactorByName(strTitle);
	}

	public CoreWebList<FactorClass> fn_getFactorByKeys()
	{
		DBFactorClass objdb = new DBFactorClass();
		return objdb.fn_getFactorByKeys(strTitle);
	}

	public CoreWebList<FactorClass> fn_getFactorByHeadingID()
	{
		DBFactorClass objdb = new DBFactorClass();
		return objdb.fn_getFactorByHeadingID(iHeadingID);
	}

}
