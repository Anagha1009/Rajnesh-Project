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
/// Summary description for QueryLinkClass
/// </summary>

public class QueryLinkClass
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

	private int _iQueryID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iQueryID
	{
		get
		{
			return _iQueryID;
		}
		set
		{
			_iQueryID = value;
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

	private string _strLink = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strLink
	{
		get
		{
			return _strLink;
		}
		set
		{
			_strLink = value;
		}
	}

	public string fn_saveQueryLink()
	{
		DBQueryLinkClass objdb = new DBQueryLinkClass();
		return objdb.fn_saveQueryLink(this);
	}

	public string fn_editQueryLink()
	{
		DBQueryLinkClass objdb = new DBQueryLinkClass();
		return objdb.fn_editQueryLink(this);
	}

	public string fn_deleteQueryLink()
	{
		DBQueryLinkClass objdb = new DBQueryLinkClass();
		return objdb.fn_deleteQueryLink(iID);
	}

	public CoreWebList<QueryLinkClass> fn_getQueryLinkList()
	{
		DBQueryLinkClass objdb = new DBQueryLinkClass();
		return objdb.fn_getQueryLinkList();
	}

	public CoreWebList<QueryLinkClass> fn_getQueryLinkByID()
	{
		DBQueryLinkClass objdb = new DBQueryLinkClass();
		return objdb.fn_getQueryLinkByID(iID);
	}

	public CoreWebList<QueryLinkClass> fn_getQueryLinkByName()
	{
		DBQueryLinkClass objdb = new DBQueryLinkClass();
		return objdb.fn_getQueryLinkByName(strTitle);
	}

	public CoreWebList<QueryLinkClass> fn_getQueryLinkByKeys()
	{
		DBQueryLinkClass objdb = new DBQueryLinkClass();
		return objdb.fn_getQueryLinkByKeys(strTitle);
	}

	public CoreWebList<QueryLinkClass> fn_getQueryLinkByQueryID()
	{
		DBQueryLinkClass objdb = new DBQueryLinkClass();
		return objdb.fn_getQueryLinkByQueryID(iQueryID);
	}

}
