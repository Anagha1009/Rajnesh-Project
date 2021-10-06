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
/// Summary description for UniversityPhotoClass
/// </summary>

public class UniversityPhotoClass
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

	private int _iUniversityID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iUniversityID
	{
		get
		{
			return _iUniversityID;
		}
		set
		{
			_iUniversityID = value;
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

	public string fn_saveUniversityPhoto()
	{
		DBUniversityPhotoClass objdb = new DBUniversityPhotoClass();
		return objdb.fn_saveUniversityPhoto(this);
	}

	public string fn_editUniversityPhoto()
	{
		DBUniversityPhotoClass objdb = new DBUniversityPhotoClass();
		return objdb.fn_editUniversityPhoto(this);
	}

	public string fn_deleteUniversityPhoto()
	{
		DBUniversityPhotoClass objdb = new DBUniversityPhotoClass();
		return objdb.fn_deleteUniversityPhoto(iID);
	}

	public CoreWebList<UniversityPhotoClass> fn_getUniversityPhotoList()
	{
		DBUniversityPhotoClass objdb = new DBUniversityPhotoClass();
		return objdb.fn_getUniversityPhotoList();
	}

	public CoreWebList<UniversityPhotoClass> fn_getUniversityPhotoByID()
	{
		DBUniversityPhotoClass objdb = new DBUniversityPhotoClass();
		return objdb.fn_getUniversityPhotoByID(iID);
	}

	public CoreWebList<UniversityPhotoClass> fn_getUniversityPhotoByName()
	{
		DBUniversityPhotoClass objdb = new DBUniversityPhotoClass();
		return objdb.fn_getUniversityPhotoByName(strTitle);
	}

	public CoreWebList<UniversityPhotoClass> fn_getUniversityPhotoByKeys()
	{
		DBUniversityPhotoClass objdb = new DBUniversityPhotoClass();
		return objdb.fn_getUniversityPhotoByKeys(strTitle);
	}

	public CoreWebList<UniversityPhotoClass> fn_getUniversityPhotoByUniversityID()
	{
		DBUniversityPhotoClass objdb = new DBUniversityPhotoClass();
		return objdb.fn_getUniversityPhotoByUniversityID(iUniversityID);
	}

}
