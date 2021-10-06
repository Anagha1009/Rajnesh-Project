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
/// Summary description for UniversityVideoClass
/// </summary>

public class UniversityVideoClass
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

	public string fn_saveUniversityVideo()
	{
		DBUniversityVideoClass objdb = new DBUniversityVideoClass();
		return objdb.fn_saveUniversityVideo(this);
	}

	public string fn_editUniversityVideo()
	{
		DBUniversityVideoClass objdb = new DBUniversityVideoClass();
		return objdb.fn_editUniversityVideo(this);
	}

	public string fn_deleteUniversityVideo()
	{
		DBUniversityVideoClass objdb = new DBUniversityVideoClass();
		return objdb.fn_deleteUniversityVideo(iID);
	}

	public CoreWebList<UniversityVideoClass> fn_getUniversityVideoList()
	{
		DBUniversityVideoClass objdb = new DBUniversityVideoClass();
		return objdb.fn_getUniversityVideoList();
	}

	public CoreWebList<UniversityVideoClass> fn_getUniversityVideoByID()
	{
		DBUniversityVideoClass objdb = new DBUniversityVideoClass();
		return objdb.fn_getUniversityVideoByID(iID);
	}

	public CoreWebList<UniversityVideoClass> fn_getUniversityVideoByName()
	{
		DBUniversityVideoClass objdb = new DBUniversityVideoClass();
		return objdb.fn_getUniversityVideoByName(strTitle);
	}

	public CoreWebList<UniversityVideoClass> fn_getUniversityVideoByKeys()
	{
		DBUniversityVideoClass objdb = new DBUniversityVideoClass();
		return objdb.fn_getUniversityVideoByKeys(strTitle);
	}

	public CoreWebList<UniversityVideoClass> fn_getUniversityVideoByUniversityID()
	{
		DBUniversityVideoClass objdb = new DBUniversityVideoClass();
		return objdb.fn_getUniversityVideoByUniversityID(iUniversityID);
	}

}
