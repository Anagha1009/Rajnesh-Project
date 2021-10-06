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
/// Summary description for BoxLinkClass
/// </summary>

public class BoxLinkClass
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

	private int _iBoxID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iBoxID
	{
		get
		{
			return _iBoxID;
		}
		set
		{
			_iBoxID = value;
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

	private string _strUrl = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strUrl
	{
		get
		{
			return _strUrl;
		}
		set
		{
			_strUrl = value;
		}
	}

	public string fn_saveBoxLink()
	{
		DBBoxLinkClass objdb = new DBBoxLinkClass();
		return objdb.fn_saveBoxLink(this);
	}

	public string fn_editBoxLink()
	{
		DBBoxLinkClass objdb = new DBBoxLinkClass();
		return objdb.fn_editBoxLink(this);
	}

	public string fn_deleteBoxLink()
	{
		DBBoxLinkClass objdb = new DBBoxLinkClass();
		return objdb.fn_deleteBoxLink(iID);
	}

	public CoreWebList<BoxLinkClass> fn_getBoxLinkList()
	{
		DBBoxLinkClass objdb = new DBBoxLinkClass();
		return objdb.fn_getBoxLinkList();
	}

	public CoreWebList<BoxLinkClass> fn_getBoxLinkByID()
	{
		DBBoxLinkClass objdb = new DBBoxLinkClass();
		return objdb.fn_getBoxLinkByID(iID);
	}

	public CoreWebList<BoxLinkClass> fn_getBoxLinkByName()
	{
		DBBoxLinkClass objdb = new DBBoxLinkClass();
		return objdb.fn_getBoxLinkByName(strTitle);
	}

	public CoreWebList<BoxLinkClass> fn_getBoxLinkByKeys()
	{
		DBBoxLinkClass objdb = new DBBoxLinkClass();
		return objdb.fn_getBoxLinkByKeys(strTitle);
	}

	public CoreWebList<BoxLinkClass> fn_getBoxLinkByBoxID()
	{
		DBBoxLinkClass objdb = new DBBoxLinkClass();
		return objdb.fn_getBoxLinkByBoxID(iBoxID);
	}

}
