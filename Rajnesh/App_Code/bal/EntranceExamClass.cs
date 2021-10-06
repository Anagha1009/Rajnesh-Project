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
/// Summary description for EntranceExamClass
/// </summary>

public class EntranceExamClass
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

	private string _strAdmissions = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strAdmissions
	{
		get
		{
			return _strAdmissions;
		}
		set
		{
			_strAdmissions = value;
		}
	}

	private string _strDates = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strDates
	{
		get
		{
			return _strDates;
		}
		set
		{
			_strDates = value;
		}
	}

	private string _strSyllabus = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strSyllabus
	{
		get
		{
			return _strSyllabus;
		}
		set
		{
			_strSyllabus = value;
		}
	}

	private string _strPaperPatterns = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strPaperPatterns
	{
		get
		{
			return _strPaperPatterns;
		}
		set
		{
			_strPaperPatterns = value;
		}
	}

	private string _strPreparation = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strPreparation
	{
		get
		{
			return _strPreparation;
		}
		set
		{
			_strPreparation = value;
		}
	}

    private string _strNotifications = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strNotifications
    {
        get
        {
            return _strNotifications;
        }
        set
        {
            _strNotifications = value;
        }
    }

	public string fn_saveEntranceExam()
	{
		DBEntranceExamClass objdb = new DBEntranceExamClass();
		return objdb.fn_saveEntranceExam(this);
	}

	public string fn_editEntranceExam()
	{
		DBEntranceExamClass objdb = new DBEntranceExamClass();
		return objdb.fn_editEntranceExam(this);
	}

	public string fn_deleteEntranceExam()
	{
		DBEntranceExamClass objdb = new DBEntranceExamClass();
		return objdb.fn_deleteEntranceExam(iID);
	}

	public CoreWebList<EntranceExamClass> fn_getEntranceExamList()
	{
		DBEntranceExamClass objdb = new DBEntranceExamClass();
		return objdb.fn_getEntranceExamList();
	}

	public CoreWebList<EntranceExamClass> fn_getEntranceExamByID()
	{
		DBEntranceExamClass objdb = new DBEntranceExamClass();
		return objdb.fn_getEntranceExamByID(iID);
	}

	public CoreWebList<EntranceExamClass> fn_getEntranceExamByName()
	{
		DBEntranceExamClass objdb = new DBEntranceExamClass();
		return objdb.fn_getEntranceExamByName(strTitle);
	}

	public CoreWebList<EntranceExamClass> fn_getEntranceExamByKeys()
	{
		DBEntranceExamClass objdb = new DBEntranceExamClass();
		return objdb.fn_getEntranceExamByKeys(strTitle);
	}

	public CoreWebList<EntranceExamClass> fn_getEntranceExamByCategoryID()
	{
		DBEntranceExamClass objdb = new DBEntranceExamClass();
		return objdb.fn_getEntranceExamByCategoryID(iCategoryID);
	}

    public CoreWebList<EntranceExamClass> fn_getRandomEntranceExamByCategoryID()
    {
        DBEntranceExamClass objdb = new DBEntranceExamClass();
        return objdb.fn_getRandomEntranceExamByCategoryID(iCategoryID);
    }

}
