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
/// Summary description for ExamClass
/// </summary>

public class ExamClass
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

	private string _strExamTitle = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strExamTitle
	{
		get
		{
			return _strExamTitle;
		}
		set
		{
			_strExamTitle = value;
		}
	}

	private string _strExamDesc = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strExamDesc
	{
		get
		{
			return _strExamDesc;
		}
		set
		{
			_strExamDesc = value;
		}
	}

	public string fn_saveExam()
	{
		DBExamClass objdb = new DBExamClass();
		return objdb.fn_saveExam(this);
	}

	public string fn_editExam()
	{
		DBExamClass objdb = new DBExamClass();
		return objdb.fn_editExam(this);
	}

	public string fn_deleteExam()
	{
		DBExamClass objdb = new DBExamClass();
		return objdb.fn_deleteExam(iID);
	}

	public CoreWebList<ExamClass> fn_getExamList()
	{
		DBExamClass objdb = new DBExamClass();
		return objdb.fn_getExamList();
	}

	public CoreWebList<ExamClass> fn_getExamByID()
	{
		DBExamClass objdb = new DBExamClass();
		return objdb.fn_getExamByID(iID);
	}

    public CoreWebList<ExamClass> fn_getExamByTitle()
    {
        DBExamClass objdb = new DBExamClass();
        return objdb.fn_getExamByTitle(strExamTitle);
    }

    public CoreWebList<ExamClass> fn_getExamByUniversityID()
    {
        DBExamClass objdb = new DBExamClass();
        return objdb.fn_getExamByUniversityID(iUniversityID);
    }

    public CoreWebList<ExamClass> fn_getExamByKeys(string strKeys)
    {
        DBExamClass objdb = new DBExamClass();
        return objdb.fn_getExamByKeys(strKeys);
    }

}
