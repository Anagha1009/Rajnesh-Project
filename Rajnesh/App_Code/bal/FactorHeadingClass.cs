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
/// Summary description for FactorHeadingClass
/// </summary>

public class FactorHeadingClass
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

	private string _strIcon = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strIcon
	{
		get
		{
			return _strIcon;
		}
		set
		{
			_strIcon = value;
		}
	}

	public string fn_saveFactorHeading()
	{
		DBFactorHeadingClass objdb = new DBFactorHeadingClass();
		return objdb.fn_saveFactorHeading(this);
	}

	public string fn_editFactorHeading()
	{
		DBFactorHeadingClass objdb = new DBFactorHeadingClass();
		return objdb.fn_editFactorHeading(this);
	}

	public string fn_deleteFactorHeading()
	{
		DBFactorHeadingClass objdb = new DBFactorHeadingClass();
		return objdb.fn_deleteFactorHeading(iID);
	}

	public CoreWebList<FactorHeadingClass> fn_getFactorHeadingList()
	{
		DBFactorHeadingClass objdb = new DBFactorHeadingClass();
		return objdb.fn_getFactorHeadingList();
	}

	public CoreWebList<FactorHeadingClass> fn_getFactorHeadingByID()
	{
		DBFactorHeadingClass objdb = new DBFactorHeadingClass();
		return objdb.fn_getFactorHeadingByID(iID);
	}

	public CoreWebList<FactorHeadingClass> fn_getFactorHeadingByName()
	{
		DBFactorHeadingClass objdb = new DBFactorHeadingClass();
		return objdb.fn_getFactorHeadingByName(strTitle);
	}

	public CoreWebList<FactorHeadingClass> fn_getFactorHeadingByKeys()
	{
		DBFactorHeadingClass objdb = new DBFactorHeadingClass();
		return objdb.fn_getFactorHeadingByKeys(strTitle);
	}

}
