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
/// Summary description for ExamResultClass
/// </summary>

public class ExamResultClass
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
	
    private string _strExamResultTitle = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strExamResultTitle
	{
		get
		{
			return _strExamResultTitle;
		}
		set
		{
			_strExamResultTitle = value;
		}
	}

	private string _strExamResultDesc = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strExamResultDesc
	{
		get
		{
			return _strExamResultDesc;
		}
		set
		{
			_strExamResultDesc = value;
		}
	}

	public string fn_saveExamResult()
	{
		DBExamResultClass objdb = new DBExamResultClass();
		return objdb.fn_saveExamResult(this);
	}

	public string fn_editExamResult()
	{
		DBExamResultClass objdb = new DBExamResultClass();
		return objdb.fn_editExamResult(this);
	}

	public string fn_deleteExamResult()
	{
		DBExamResultClass objdb = new DBExamResultClass();
		return objdb.fn_deleteExamResult(iID);
	}

	public CoreWebList<ExamResultClass> fn_getExamResultList()
	{
		DBExamResultClass objdb = new DBExamResultClass();
		return objdb.fn_getExamResultList();
	}

	public CoreWebList<ExamResultClass> fn_getExamResultByID()
	{
		DBExamResultClass objdb = new DBExamResultClass();
		return objdb.fn_getExamResultByID(iID);
	}

    public CoreWebList<ExamResultClass> fn_getExamResultByCourseID()
    {
        DBExamResultClass objdb = new DBExamResultClass();
        return objdb.fn_getExamResultByCourseID(iCourseID);
    }

    public CoreWebList<ExamResultClass> fn_getExamResultByName()
    {
        DBExamResultClass objdb = new DBExamResultClass();
        return objdb.fn_getExamResultByName(strExamResultTitle);
    }

    public CoreWebList<ExamResultClass> fn_getExamResultByKeys(string strKeys)
    {
        DBExamResultClass objdb = new DBExamResultClass();
        return objdb.fn_getExamResultByKeys(strKeys);
    }

}
