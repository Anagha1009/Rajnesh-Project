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
/// Summary description for PageGeneratorClass
/// </summary>

public class PageGeneratorClass
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

	private string _strMetaTitle = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strMetaTitle
	{
		get
		{
			return _strMetaTitle;
		}
		set
		{
			_strMetaTitle = value;
		}
	}

	private string _strMetaDesc = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strMetaDesc
	{
		get
		{
			return _strMetaDesc;
		}
		set
		{
			_strMetaDesc = value;
		}
	}

	private string _strMetaKeys = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strMetaKeys
	{
		get
		{
			return _strMetaKeys;
		}
		set
		{
			_strMetaKeys = value;
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

	private DateTime _dtCreatedDate = DateTime.Now;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public DateTime dtCreatedDate
	{
		get
		{
			return _dtCreatedDate;
		}
		set
		{
			_dtCreatedDate = value;
		}
	}

	public string fn_savePageGenerator()
	{
		DBPageGeneratorClass objdb = new DBPageGeneratorClass();
		return objdb.fn_savePageGenerator(this);
	}

	public string fn_editPageGenerator()
	{
		DBPageGeneratorClass objdb = new DBPageGeneratorClass();
		return objdb.fn_editPageGenerator(this);
	}

	public string fn_deletePageGenerator()
	{
		DBPageGeneratorClass objdb = new DBPageGeneratorClass();
		return objdb.fn_deletePageGenerator(iID);
	}

	public CoreWebList<PageGeneratorClass> fn_getPageGeneratorList()
	{
		DBPageGeneratorClass objdb = new DBPageGeneratorClass();
		return objdb.fn_getPageGeneratorList();
	}

	public CoreWebList<PageGeneratorClass> fn_getPageGeneratorByID()
	{
		DBPageGeneratorClass objdb = new DBPageGeneratorClass();
		return objdb.fn_getPageGeneratorByID(iID);
	}

	public CoreWebList<PageGeneratorClass> fn_getPageGeneratorByName()
	{
		DBPageGeneratorClass objdb = new DBPageGeneratorClass();
		return objdb.fn_getPageGeneratorByName(strTitle);
	}

	public CoreWebList<PageGeneratorClass> fn_getPageGeneratorByKeys()
	{
		DBPageGeneratorClass objdb = new DBPageGeneratorClass();
		return objdb.fn_getPageGeneratorByKeys(strTitle);
	}

}
