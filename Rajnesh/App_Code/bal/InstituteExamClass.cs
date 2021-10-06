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
/// Summary description for InstituteExamClass
/// </summary>

public class InstituteExamClass
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

	private int _iInstituteID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iInstituteID
	{
		get
		{
			return _iInstituteID;
		}
		set
		{
			_iInstituteID = value;
		}
	}

	private int _iExamID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iExamID
	{
		get
		{
			return _iExamID;
		}
		set
		{
			_iExamID = value;
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

	public string fn_saveInstituteExam()
	{
		DBInstituteExamClass objdb = new DBInstituteExamClass();
		return objdb.fn_saveInstituteExam(this);
	}

	public string fn_editInstituteExam()
	{
		DBInstituteExamClass objdb = new DBInstituteExamClass();
		return objdb.fn_editInstituteExam(this);
	}

	public string fn_deleteInstituteExam()
	{
		DBInstituteExamClass objdb = new DBInstituteExamClass();
		return objdb.fn_deleteInstituteExam(iID);
	}

	public string fn_deleteInstituteExamByInstituteID()
	{
		DBInstituteExamClass objdb = new DBInstituteExamClass();
		return objdb.fn_deleteInstituteExamByInstituteID(iInstituteID);
	}

	public CoreWebList<InstituteExamClass> fn_getInstituteExamList()
	{
		DBInstituteExamClass objdb = new DBInstituteExamClass();
		return objdb.fn_getInstituteExamList();
	}

	public CoreWebList<InstituteExamClass> fn_getInstituteExamByID()
	{
		DBInstituteExamClass objdb = new DBInstituteExamClass();
		return objdb.fn_getInstituteExamByID(iID);
	}

	public CoreWebList<InstituteExamClass> fn_getInstituteExamByExamID()
	{
		DBInstituteExamClass objdb = new DBInstituteExamClass();
		return objdb.fn_getInstituteExamByExamID(iExamID);
	}

	public CoreWebList<InstituteExamClass> fn_getInstituteExamByInstituteID()
	{
		DBInstituteExamClass objdb = new DBInstituteExamClass();
		return objdb.fn_getInstituteExamByInstituteID(iInstituteID);
	}

}
