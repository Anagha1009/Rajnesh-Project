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
/// Summary description for EntranceCollegeClass
/// </summary>

public class EntranceCollegeClass
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

	private int _iCollegeID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iCollegeID
	{
		get
		{
			return _iCollegeID;
		}
		set
		{
			_iCollegeID = value;
		}
	}

	public string fn_saveEntranceCollege()
	{
		DBEntranceCollegeClass objdb = new DBEntranceCollegeClass();
		return objdb.fn_saveEntranceCollege(this);
	}

	public string fn_editEntranceCollege()
	{
		DBEntranceCollegeClass objdb = new DBEntranceCollegeClass();
		return objdb.fn_editEntranceCollege(this);
	}

	public string fn_deleteEntranceCollege()
	{
		DBEntranceCollegeClass objdb = new DBEntranceCollegeClass();
		return objdb.fn_deleteEntranceCollege(iID);
	}

    public string fn_deleteEntranceCollegeByExamID()
    {
        DBEntranceCollegeClass objdb = new DBEntranceCollegeClass();
        return objdb.fn_deleteEntranceCollegeByExamID(iExamID);
    }

	public CoreWebList<EntranceCollegeClass> fn_getEntranceCollegeList()
	{
		DBEntranceCollegeClass objdb = new DBEntranceCollegeClass();
		return objdb.fn_getEntranceCollegeList();
	}

	public CoreWebList<EntranceCollegeClass> fn_getEntranceCollegeByID()
	{
		DBEntranceCollegeClass objdb = new DBEntranceCollegeClass();
		return objdb.fn_getEntranceCollegeByID(iID);
	}

    public CoreWebList<EntranceCollegeClass> fn_getEntranceCollegeByExamID()
	{
		DBEntranceCollegeClass objdb = new DBEntranceCollegeClass();
		return objdb.fn_getEntranceCollegeByExamID(iExamID);
	}

	public CoreWebList<EntranceCollegeClass> fn_getEntranceCollegeByCollegeID()
	{
		DBEntranceCollegeClass objdb = new DBEntranceCollegeClass();
		return objdb.fn_getEntranceCollegeByCollegeID(iCollegeID);
	}

}
