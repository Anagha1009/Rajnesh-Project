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
/// Summary description for CompetitionFileClass
/// </summary>

public class CompetitionFileClass
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

	private int _iUserID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iUserID
	{
		get
		{
			return _iUserID;
		}
		set
		{
			_iUserID = value;
		}
	}

	private int _iCompetitionID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iCompetitionID
	{
		get
		{
			return _iCompetitionID;
		}
		set
		{
			_iCompetitionID = value;
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

	private string _strFile = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strFile
	{
		get
		{
			return _strFile;
		}
		set
		{
			_strFile = value;
		}
	}

	public string fn_saveCompetitionFile()
	{
		DBCompetitionFileClass objdb = new DBCompetitionFileClass();
		return objdb.fn_saveCompetitionFile(this);
	}

	public string fn_editCompetitionFile()
	{
		DBCompetitionFileClass objdb = new DBCompetitionFileClass();
		return objdb.fn_editCompetitionFile(this);
	}

	public string fn_deleteCompetitionFile()
	{
		DBCompetitionFileClass objdb = new DBCompetitionFileClass();
		return objdb.fn_deleteCompetitionFile(iID);
	}

	public CoreWebList<CompetitionFileClass> fn_getCompetitionFileList()
	{
		DBCompetitionFileClass objdb = new DBCompetitionFileClass();
		return objdb.fn_getCompetitionFileList();
	}

	public CoreWebList<CompetitionFileClass> fn_getCompetitionFileByID()
	{
		DBCompetitionFileClass objdb = new DBCompetitionFileClass();
		return objdb.fn_getCompetitionFileByID(iID);
	}

	public CoreWebList<CompetitionFileClass> fn_getCompetitionFileByName()
	{
		DBCompetitionFileClass objdb = new DBCompetitionFileClass();
		return objdb.fn_getCompetitionFileByName(strTitle);
	}

	public CoreWebList<CompetitionFileClass> fn_getCompetitionFileByKeys()
	{
		DBCompetitionFileClass objdb = new DBCompetitionFileClass();
		return objdb.fn_getCompetitionFileByKeys(strTitle);
	}

	public CoreWebList<CompetitionFileClass> fn_getCompetitionFileByCompetitionID()
	{
		DBCompetitionFileClass objdb = new DBCompetitionFileClass();
		return objdb.fn_getCompetitionFileByCompetitionID(iCompetitionID);
	}

    public CoreWebList<CompetitionFileClass> fn_getCompetitionFileByCompetitionIDUserID()
    {
        DBCompetitionFileClass objdb = new DBCompetitionFileClass();
        return objdb.fn_getCompetitionFileByCompetitionIDUserID(iCompetitionID, iUserID);
    }

	public CoreWebList<CompetitionFileClass> fn_getCompetitionFileByUserID()
	{
		DBCompetitionFileClass objdb = new DBCompetitionFileClass();
		return objdb.fn_getCompetitionFileByUserID(iUserID);
	}

    public CoreWebList<CompetitionFileClass> fn_getCheckUserParticipation()
    {
        DBCompetitionFileClass objdb = new DBCompetitionFileClass();
        return objdb.fn_getCheckUserParticipation(iCompetitionID, iUserID);
    }

}
