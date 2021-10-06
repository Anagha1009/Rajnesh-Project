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
/// Summary description for SchoolVideoClass
/// </summary>

public class SchoolVideoClass
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

	public string fn_saveSchoolVideo()
	{
		DBSchoolVideoClass objdb = new DBSchoolVideoClass();
		return objdb.fn_saveSchoolVideo(this);
	}

	public string fn_editSchoolVideo()
	{
		DBSchoolVideoClass objdb = new DBSchoolVideoClass();
		return objdb.fn_editSchoolVideo(this);
	}

	public string fn_deleteSchoolVideo()
	{
		DBSchoolVideoClass objdb = new DBSchoolVideoClass();
		return objdb.fn_deleteSchoolVideo(iID);
	}

	public CoreWebList<SchoolVideoClass> fn_getSchoolVideoList()
	{
		DBSchoolVideoClass objdb = new DBSchoolVideoClass();
		return objdb.fn_getSchoolVideoList();
	}

	public CoreWebList<SchoolVideoClass> fn_getSchoolVideoByID()
	{
		DBSchoolVideoClass objdb = new DBSchoolVideoClass();
		return objdb.fn_getSchoolVideoByID(iID);
	}

	public CoreWebList<SchoolVideoClass> fn_getSchoolVideoByName()
	{
		DBSchoolVideoClass objdb = new DBSchoolVideoClass();
		return objdb.fn_getSchoolVideoByName(strTitle);
	}

	public CoreWebList<SchoolVideoClass> fn_getSchoolVideoByKeys()
	{
		DBSchoolVideoClass objdb = new DBSchoolVideoClass();
		return objdb.fn_getSchoolVideoByKeys(strTitle);
	}

	public CoreWebList<SchoolVideoClass> fn_getSchoolVideoBySchoolID()
	{
		DBSchoolVideoClass objdb = new DBSchoolVideoClass();
		return objdb.fn_getSchoolVideoBySchoolID(iSchoolID);
	}

}
