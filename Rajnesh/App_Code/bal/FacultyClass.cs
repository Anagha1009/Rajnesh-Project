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
/// Summary description for FacultyClass
/// </summary>

public class FacultyClass
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

    private string _strUniversityName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strUniversityName
    {
        get
        {
            return _strUniversityName;
        }
        set
        {
            _strUniversityName = value;
        }
    }

	private string _strFacultyName = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strFacultyName
	{
		get
		{
			return _strFacultyName;
		}
		set
		{
			_strFacultyName = value;
		}
	}

	private string _strFacultyDept = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strFacultyDept
	{
		get
		{
			return _strFacultyDept;
		}
		set
		{
			_strFacultyDept = value;
		}
	}

	private string _strFacultyDesignation = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strFacultyDesignation
	{
		get
		{
			return _strFacultyDesignation;
		}
		set
		{
			_strFacultyDesignation = value;
		}
	}

	private string _strFacultyProfile = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strFacultyProfile
	{
		get
		{
			return _strFacultyProfile;
		}
		set
		{
			_strFacultyProfile = value;
		}
	}

	private string _strFacultyPhoto = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strFacultyPhoto
	{
		get
		{
			return _strFacultyPhoto;
		}
		set
		{
			_strFacultyPhoto = value;
		}
	}

	public string fn_saveFaculty()
	{
		DBFacultyClass objdb = new DBFacultyClass();
		return objdb.fn_saveFaculty(this);
	}

	public string fn_editFaculty()
	{
		DBFacultyClass objdb = new DBFacultyClass();
		return objdb.fn_editFaculty(this);
	}

	public string fn_deleteFaculty()
	{
		DBFacultyClass objdb = new DBFacultyClass();
		return objdb.fn_deleteFaculty(iID);
	}

	public CoreWebList<FacultyClass> fn_getFacultyList()
	{
		DBFacultyClass objdb = new DBFacultyClass();
		return objdb.fn_getFacultyList();
	}

	public CoreWebList<FacultyClass> fn_getFacultyByID()
	{
		DBFacultyClass objdb = new DBFacultyClass();
		return objdb.fn_getFacultyByID(iID);
	}

    public CoreWebList<FacultyClass> fn_getFacultyByName()
    {
        DBFacultyClass objdb = new DBFacultyClass();
        return objdb.fn_getFacultyByName(strFacultyName);
    }


    public CoreWebList<FacultyClass> fn_getFacultyByUniversityID()
    {
        DBFacultyClass objdb = new DBFacultyClass();
        return objdb.fn_getFacultyByUniversityID(iUniversityID);
    }

    public CoreWebList<FacultyClass> fn_getFacultyByKeys(string strKeys)
    {
        DBFacultyClass objdb = new DBFacultyClass();
        return objdb.fn_getFacultyByKeys(strKeys);
    }

}
