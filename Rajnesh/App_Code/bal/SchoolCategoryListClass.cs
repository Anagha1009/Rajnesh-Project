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
/// Summary description for SchoolCategoryListClass
/// </summary>

public class SchoolCategoryListClass
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

	private int _iCategoryID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iCategoryID
	{
		get
		{
			return _iCategoryID;
		}
		set
		{
			_iCategoryID = value;
		}
	}

	public string fn_saveSchoolCategoryList()
	{
		DBSchoolCategoryListClass objdb = new DBSchoolCategoryListClass();
		return objdb.fn_saveSchoolCategoryList(this);
	}

	public string fn_editSchoolCategoryList()
	{
		DBSchoolCategoryListClass objdb = new DBSchoolCategoryListClass();
		return objdb.fn_editSchoolCategoryList(this);
	}

	public string fn_deleteSchoolCategoryList()
	{
		DBSchoolCategoryListClass objdb = new DBSchoolCategoryListClass();
		return objdb.fn_deleteSchoolCategoryList(iID);
	}

    public string fn_deleteSchoolCategoryBySchoolID()
    {
        DBSchoolCategoryListClass objdb = new DBSchoolCategoryListClass();
        return objdb.fn_deleteSchoolCategoryBySchoolID(iSchoolID);
    }

    public CoreWebList<SchoolCategoryListClass> fn_getSchoolCategoryList()
	{
		DBSchoolCategoryListClass objdb = new DBSchoolCategoryListClass();
		return objdb.fn_getSchoolCategoryList();
	}

	public CoreWebList<SchoolCategoryListClass> fn_getSchoolCategoryListByID()
	{
		DBSchoolCategoryListClass objdb = new DBSchoolCategoryListClass();
		return objdb.fn_getSchoolCategoryListByID(iID);
	}

    public CoreWebList<SchoolCategoryListClass> fn_getSchoolCategoryListBySchoolID()
    {
        DBSchoolCategoryListClass objdb = new DBSchoolCategoryListClass();
        return objdb.fn_getSchoolCategoryListBySchoolID(iSchoolID);
    }

}
