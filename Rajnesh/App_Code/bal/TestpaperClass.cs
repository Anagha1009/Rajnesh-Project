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
/// Summary description for TestpaperClass
/// </summary>

public class TestpaperClass
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

	private int _iCourseID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iCourseID
	{
		get
		{
			return _iCourseID;
		}
		set
		{
			_iCourseID = value;
		}
	}

    private string _strCourseName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCourseName
    {
        get
        {
            return _strCourseName;
        }
        set
        {
            _strCourseName = value;
        }
    }

	private string _strTestpaperTitle = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strTestpaperTitle
	{
		get
		{
			return _strTestpaperTitle;
		}
		set
		{
			_strTestpaperTitle = value;
		}
	}

	private string _strTestpaperDesc = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strTestpaperDesc
	{
		get
		{
			return _strTestpaperDesc;
		}
		set
		{
			_strTestpaperDesc = value;
		}
	}

	public string fn_saveTestpaper()
	{
		DBTestpaperClass objdb = new DBTestpaperClass();
		return objdb.fn_saveTestpaper(this);
	}

	public string fn_editTestpaper()
	{
		DBTestpaperClass objdb = new DBTestpaperClass();
		return objdb.fn_editTestpaper(this);
	}

	public string fn_deleteTestpaper()
	{
		DBTestpaperClass objdb = new DBTestpaperClass();
		return objdb.fn_deleteTestpaper(iID);
	}

	public CoreWebList<TestpaperClass> fn_getTestpaperList()
	{
		DBTestpaperClass objdb = new DBTestpaperClass();
		return objdb.fn_getTestpaperList();
	}

	public CoreWebList<TestpaperClass> fn_getTestpaperByID()
	{
		DBTestpaperClass objdb = new DBTestpaperClass();
		return objdb.fn_getTestpaperByID(iID);
	}

    public CoreWebList<TestpaperClass> fn_getTestpaperByName()
    {
        DBTestpaperClass objdb = new DBTestpaperClass();
        return objdb.fn_getTestpaperByName(strTestpaperTitle);
    }

    public CoreWebList<TestpaperClass> fn_getTestpaperByCourseID()
    {
        DBTestpaperClass objdb = new DBTestpaperClass();
        return objdb.fn_getTestpaperByCourseID(iCourseID);
    }

    public CoreWebList<TestpaperClass> fn_getTestpaperByKeys(string strKeys)
    {
        DBTestpaperClass objdb = new DBTestpaperClass();
        return objdb.fn_getTestpaperByKeys(strKeys);
    }

}
