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
/// Summary description for BoxClass
/// </summary>

public class BoxClass
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

	private int _iPageID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iPageID
	{
		get
		{
			return _iPageID;
		}
		set
		{
			_iPageID = value;
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

	public string fn_saveBox()
	{
		DBBoxClass objdb = new DBBoxClass();
		return objdb.fn_saveBox(this);
	}

	public string fn_editBox()
	{
		DBBoxClass objdb = new DBBoxClass();
		return objdb.fn_editBox(this);
	}

	public string fn_deleteBox()
	{
		DBBoxClass objdb = new DBBoxClass();
		return objdb.fn_deleteBox(iID);
	}

	public CoreWebList<BoxClass> fn_getBoxList()
	{
		DBBoxClass objdb = new DBBoxClass();
		return objdb.fn_getBoxList();
	}

	public CoreWebList<BoxClass> fn_getBoxByID()
	{
		DBBoxClass objdb = new DBBoxClass();
		return objdb.fn_getBoxByID(iID);
	}

	public CoreWebList<BoxClass> fn_getBoxByName()
	{
		DBBoxClass objdb = new DBBoxClass();
		return objdb.fn_getBoxByName(strTitle);
	}

	public CoreWebList<BoxClass> fn_getBoxByKeys()
	{
		DBBoxClass objdb = new DBBoxClass();
		return objdb.fn_getBoxByKeys(strTitle);
	}

	public CoreWebList<BoxClass> fn_getBoxByPageID()
	{
		DBBoxClass objdb = new DBBoxClass();
		return objdb.fn_getBoxByPageID(iPageID);
	}

}
