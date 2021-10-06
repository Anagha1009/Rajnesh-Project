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
/// Summary description for PagePhotoClass
/// </summary>

public class PagePhotoClass
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

	public string fn_savePagePhoto()
	{
		DBPagePhotoClass objdb = new DBPagePhotoClass();
		return objdb.fn_savePagePhoto(this);
	}

	public string fn_editPagePhoto()
	{
		DBPagePhotoClass objdb = new DBPagePhotoClass();
		return objdb.fn_editPagePhoto(this);
	}

	public string fn_deletePagePhoto()
	{
		DBPagePhotoClass objdb = new DBPagePhotoClass();
		return objdb.fn_deletePagePhoto(iID);
	}

	public CoreWebList<PagePhotoClass> fn_getPagePhotoList()
	{
		DBPagePhotoClass objdb = new DBPagePhotoClass();
		return objdb.fn_getPagePhotoList();
	}

	public CoreWebList<PagePhotoClass> fn_getPagePhotoByID()
	{
		DBPagePhotoClass objdb = new DBPagePhotoClass();
		return objdb.fn_getPagePhotoByID(iID);
	}

	public CoreWebList<PagePhotoClass> fn_getPagePhotoByName()
	{
		DBPagePhotoClass objdb = new DBPagePhotoClass();
		return objdb.fn_getPagePhotoByName(strTitle);
	}

	public CoreWebList<PagePhotoClass> fn_getPagePhotoByKeys()
	{
		DBPagePhotoClass objdb = new DBPagePhotoClass();
		return objdb.fn_getPagePhotoByKeys(strTitle);
	}

	public CoreWebList<PagePhotoClass> fn_getPagePhotoByPageID()
	{
		DBPagePhotoClass objdb = new DBPagePhotoClass();
		return objdb.fn_getPagePhotoByPageID(iPageID);
	}

}
