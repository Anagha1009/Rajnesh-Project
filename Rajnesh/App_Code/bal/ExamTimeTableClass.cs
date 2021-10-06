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
/// Summary description for ExamTimeTableClass
/// </summary>

public class ExamTimeTableClass
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

	public string fn_saveExamTimeTable()
	{
		DBExamTimeTableClass objdb = new DBExamTimeTableClass();
		return objdb.fn_saveExamTimeTable(this);
	}

	public string fn_editExamTimeTable()
	{
		DBExamTimeTableClass objdb = new DBExamTimeTableClass();
		return objdb.fn_editExamTimeTable(this);
	}

	public string fn_deleteExamTimeTable()
	{
		DBExamTimeTableClass objdb = new DBExamTimeTableClass();
		return objdb.fn_deleteExamTimeTable(iID);
	}

	public CoreWebList<ExamTimeTableClass> fn_getExamTimeTableList()
	{
		DBExamTimeTableClass objdb = new DBExamTimeTableClass();
		return objdb.fn_getExamTimeTableList();
	}

	public CoreWebList<ExamTimeTableClass> fn_getExamTimeTableByID()
	{
		DBExamTimeTableClass objdb = new DBExamTimeTableClass();
		return objdb.fn_getExamTimeTableByID(iID);
	}

	public CoreWebList<ExamTimeTableClass> fn_getExamTimeTableByName()
	{
		DBExamTimeTableClass objdb = new DBExamTimeTableClass();
		return objdb.fn_getExamTimeTableByName(strTitle);
	}

	public CoreWebList<ExamTimeTableClass> fn_getExamTimeTableByKeys()
	{
		DBExamTimeTableClass objdb = new DBExamTimeTableClass();
		return objdb.fn_getExamTimeTableByKeys(strTitle);
	}

	public CoreWebList<ExamTimeTableClass> fn_getExamTimeTableByUniversityID()
	{
		DBExamTimeTableClass objdb = new DBExamTimeTableClass();
		return objdb.fn_getExamTimeTableByUniversityID(iUniversityID);
	}

}
