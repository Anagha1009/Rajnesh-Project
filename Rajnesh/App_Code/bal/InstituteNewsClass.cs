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
/// Summary description for InstituteNewsClass
/// </summary>

public class InstituteNewsClass
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

	private int _iInstituteID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iInstituteID
	{
		get
		{
			return _iInstituteID;
		}
		set
		{
			_iInstituteID = value;
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

	private string _strDesc = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strDesc
	{
		get
		{
			return _strDesc;
		}
		set
		{
			_strDesc = value;
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

	public string fn_saveInstituteNews()
	{
		DBInstituteNewsClass objdb = new DBInstituteNewsClass();
		return objdb.fn_saveInstituteNews(this);
	}

	public string fn_editInstituteNews()
	{
		DBInstituteNewsClass objdb = new DBInstituteNewsClass();
		return objdb.fn_editInstituteNews(this);
	}

	public string fn_deleteInstituteNews()
	{
		DBInstituteNewsClass objdb = new DBInstituteNewsClass();
		return objdb.fn_deleteInstituteNews(iID);
	}

	public CoreWebList<InstituteNewsClass> fn_getInstituteNewsList()
	{
		DBInstituteNewsClass objdb = new DBInstituteNewsClass();
		return objdb.fn_getInstituteNewsList();
	}

	public CoreWebList<InstituteNewsClass> fn_getInstituteNewsByID()
	{
		DBInstituteNewsClass objdb = new DBInstituteNewsClass();
		return objdb.fn_getInstituteNewsByID(iID);
	}

	public CoreWebList<InstituteNewsClass> fn_getInstituteNewsByName()
	{
		DBInstituteNewsClass objdb = new DBInstituteNewsClass();
		return objdb.fn_getInstituteNewsByName(strTitle);
	}

	public CoreWebList<InstituteNewsClass> fn_getInstituteNewsByKeys()
	{
		DBInstituteNewsClass objdb = new DBInstituteNewsClass();
		return objdb.fn_getInstituteNewsByKeys(strTitle);
	}

	public CoreWebList<InstituteNewsClass> fn_getInstituteNewsByInstituteID()
	{
		DBInstituteNewsClass objdb = new DBInstituteNewsClass();
		return objdb.fn_getInstituteNewsByInstituteID(iInstituteID);
	}

}
