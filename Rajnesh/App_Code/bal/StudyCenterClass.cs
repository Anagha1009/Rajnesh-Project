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
/// Summary description for StudyCenterClass
/// </summary>

public class StudyCenterClass
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

	
    private string _strStudyCenterTitle = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strStudyCenterTitle
	{
		get
		{
			return _strStudyCenterTitle;
		}
		set
		{
			_strStudyCenterTitle = value;
		}
	}

	private string _strStudyCenterDesc = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strStudyCenterDesc
	{
		get
		{
			return _strStudyCenterDesc;
		}
		set
		{
			_strStudyCenterDesc = value;
		}
	}

	private string _strStudyCenterAddrs = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strStudyCenterAddrs
	{
		get
		{
			return _strStudyCenterAddrs;
		}
		set
		{
			_strStudyCenterAddrs = value;
		}
	}

	public string fn_saveStudyCenter()
	{
		DBStudyCenterClass objdb = new DBStudyCenterClass();
		return objdb.fn_saveStudyCenter(this);
	}

	public string fn_editStudyCenter()
	{
		DBStudyCenterClass objdb = new DBStudyCenterClass();
		return objdb.fn_editStudyCenter(this);
	}

	public string fn_deleteStudyCenter()
	{
		DBStudyCenterClass objdb = new DBStudyCenterClass();
		return objdb.fn_deleteStudyCenter(iID);
	}

	public CoreWebList<StudyCenterClass> fn_getStudyCenterList()
	{
		DBStudyCenterClass objdb = new DBStudyCenterClass();
		return objdb.fn_getStudyCenterList();
	}

	public CoreWebList<StudyCenterClass> fn_getStudyCenterByID()
	{
		DBStudyCenterClass objdb = new DBStudyCenterClass();
		return objdb.fn_getStudyCenterByID(iID);
	}

    public CoreWebList<StudyCenterClass> fn_getStudyCenterByName()
    {
        DBStudyCenterClass objdb = new DBStudyCenterClass();
        return objdb.fn_getStudyCenterByName(strStudyCenterTitle);
    }

    public CoreWebList<StudyCenterClass> fn_getStudyCenterByKeys(string strKeys)
    {
        DBStudyCenterClass objdb = new DBStudyCenterClass();
        return objdb.fn_getStudyCenterByKeys(strKeys);
    }

    public CoreWebList<StudyCenterClass> fn_getStudyCenterByUniversityID()
    {
        DBStudyCenterClass objdb = new DBStudyCenterClass();
        return objdb.fn_getStudyCenterByUniversityID(iUniversityID);
    }

}
