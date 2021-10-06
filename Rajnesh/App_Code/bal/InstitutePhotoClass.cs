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
/// Summary description for InstitutePhotoClass
/// </summary>

public class InstitutePhotoClass
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

	public string fn_saveInstitutePhoto()
	{
		DBInstitutePhotoClass objdb = new DBInstitutePhotoClass();
		return objdb.fn_saveInstitutePhoto(this);
	}

	public string fn_editInstitutePhoto()
	{
		DBInstitutePhotoClass objdb = new DBInstitutePhotoClass();
		return objdb.fn_editInstitutePhoto(this);
	}

	public string fn_deleteInstitutePhoto()
	{
		DBInstitutePhotoClass objdb = new DBInstitutePhotoClass();
		return objdb.fn_deleteInstitutePhoto(iID);
	}

	public CoreWebList<InstitutePhotoClass> fn_getInstitutePhotoList()
	{
		DBInstitutePhotoClass objdb = new DBInstitutePhotoClass();
		return objdb.fn_getInstitutePhotoList();
	}

	public CoreWebList<InstitutePhotoClass> fn_getInstitutePhotoByID()
	{
		DBInstitutePhotoClass objdb = new DBInstitutePhotoClass();
		return objdb.fn_getInstitutePhotoByID(iID);
	}

	public CoreWebList<InstitutePhotoClass> fn_getInstitutePhotoByName()
	{
		DBInstitutePhotoClass objdb = new DBInstitutePhotoClass();
		return objdb.fn_getInstitutePhotoByName(strTitle);
	}

	public CoreWebList<InstitutePhotoClass> fn_getInstitutePhotoByKeys()
	{
		DBInstitutePhotoClass objdb = new DBInstitutePhotoClass();
		return objdb.fn_getInstitutePhotoByKeys(strTitle);
	}

	public CoreWebList<InstitutePhotoClass> fn_getInstitutePhotoByInstituteID()
	{
		DBInstitutePhotoClass objdb = new DBInstitutePhotoClass();
		return objdb.fn_getInstitutePhotoByInstituteID(iInstituteID);
	}

}
