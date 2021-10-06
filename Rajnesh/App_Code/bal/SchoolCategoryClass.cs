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
/// Summary description for SchoolCategoryClass
/// </summary>

public class SchoolCategoryClass
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

	public string fn_saveSchoolCategory()
	{
		DBSchoolCategoryClass objdb = new DBSchoolCategoryClass();
		return objdb.fn_saveSchoolCategory(this);
	}

	public string fn_editSchoolCategory()
	{
		DBSchoolCategoryClass objdb = new DBSchoolCategoryClass();
		return objdb.fn_editSchoolCategory(this);
	}

	public string fn_deleteSchoolCategory()
	{
		DBSchoolCategoryClass objdb = new DBSchoolCategoryClass();
		return objdb.fn_deleteSchoolCategory(iID);
	}

	public CoreWebList<SchoolCategoryClass> fn_getSchoolCategoryList()
	{
		DBSchoolCategoryClass objdb = new DBSchoolCategoryClass();
		return objdb.fn_getSchoolCategoryList();
	}

	public CoreWebList<SchoolCategoryClass> fn_getSchoolCategoryByID()
	{
		DBSchoolCategoryClass objdb = new DBSchoolCategoryClass();
		return objdb.fn_getSchoolCategoryByID(iID);
	}

	public CoreWebList<SchoolCategoryClass> fn_getSchoolCategoryByName()
	{
		DBSchoolCategoryClass objdb = new DBSchoolCategoryClass();
		return objdb.fn_getSchoolCategoryByName(strTitle);
	}

	public CoreWebList<SchoolCategoryClass> fn_getSchoolCategoryByKeys()
	{
		DBSchoolCategoryClass objdb = new DBSchoolCategoryClass();
		return objdb.fn_getSchoolCategoryByKeys(strTitle);
	}

}
