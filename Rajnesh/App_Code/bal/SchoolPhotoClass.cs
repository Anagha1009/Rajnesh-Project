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
/// Summary description for SchoolPhotoClass
/// </summary>

public class SchoolPhotoClass
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

	private int _iSchoolID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iSchoolID
	{
		get
		{
			return _iSchoolID;
		}
		set
		{
			_iSchoolID = value;
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

	public string fn_saveSchoolPhoto()
	{
		DBSchoolPhotoClass objdb = new DBSchoolPhotoClass();
		return objdb.fn_saveSchoolPhoto(this);
	}

	public string fn_editSchoolPhoto()
	{
		DBSchoolPhotoClass objdb = new DBSchoolPhotoClass();
		return objdb.fn_editSchoolPhoto(this);
	}

	public string fn_deleteSchoolPhoto()
	{
		DBSchoolPhotoClass objdb = new DBSchoolPhotoClass();
		return objdb.fn_deleteSchoolPhoto(iID);
	}

	public CoreWebList<SchoolPhotoClass> fn_getSchoolPhotoList()
	{
		DBSchoolPhotoClass objdb = new DBSchoolPhotoClass();
		return objdb.fn_getSchoolPhotoList();
	}

	public CoreWebList<SchoolPhotoClass> fn_getSchoolPhotoByID()
	{
		DBSchoolPhotoClass objdb = new DBSchoolPhotoClass();
		return objdb.fn_getSchoolPhotoByID(iID);
	}

	public CoreWebList<SchoolPhotoClass> fn_getSchoolPhotoByName()
	{
		DBSchoolPhotoClass objdb = new DBSchoolPhotoClass();
		return objdb.fn_getSchoolPhotoByName(strTitle);
	}

	public CoreWebList<SchoolPhotoClass> fn_getSchoolPhotoByKeys()
	{
		DBSchoolPhotoClass objdb = new DBSchoolPhotoClass();
		return objdb.fn_getSchoolPhotoByKeys(strTitle);
	}

	public CoreWebList<SchoolPhotoClass> fn_getSchoolPhotoBySchoolID()
	{
		DBSchoolPhotoClass objdb = new DBSchoolPhotoClass();
		return objdb.fn_getSchoolPhotoBySchoolID(iSchoolID);
	}

}
