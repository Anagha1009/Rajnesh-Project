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
/// Summary description for NewsClass
/// </summary>

public class NewsClass
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

	public string fn_saveNews()
	{
		DBNewsClass objdb = new DBNewsClass();
		return objdb.fn_saveNews(this);
	}

	public string fn_editNews()
	{
		DBNewsClass objdb = new DBNewsClass();
		return objdb.fn_editNews(this);
	}

	public string fn_deleteNews()
	{
		DBNewsClass objdb = new DBNewsClass();
		return objdb.fn_deleteNews(iID);
	}

	public CoreWebList<NewsClass> fn_getNewsList()
	{
		DBNewsClass objdb = new DBNewsClass();
		return objdb.fn_getNewsList();
	}

    public CoreWebList<NewsClass> fn_getTopNewsList()
    {
        DBNewsClass objdb = new DBNewsClass();
        return objdb.fn_getTopNewsList();
    }

	public CoreWebList<NewsClass> fn_getNewsByID()
	{
		DBNewsClass objdb = new DBNewsClass();
		return objdb.fn_getNewsByID(iID);
	}

	public CoreWebList<NewsClass> fn_getNewsByName()
	{
		DBNewsClass objdb = new DBNewsClass();
		return objdb.fn_getNewsByName(strTitle);
	}

	public CoreWebList<NewsClass> fn_getNewsByKeys()
	{
		DBNewsClass objdb = new DBNewsClass();
		return objdb.fn_getNewsByKeys(strTitle);
	}
}
