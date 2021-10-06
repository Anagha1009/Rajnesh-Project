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
/// Summary description for ModeofStudyClass
/// </summary>

public class ModeofStudyClass
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

	public string fn_saveModeofStudy()
	{
		DBModeofStudyClass objdb = new DBModeofStudyClass();
		return objdb.fn_saveModeofStudy(this);
	}

	public string fn_editModeofStudy()
	{
		DBModeofStudyClass objdb = new DBModeofStudyClass();
		return objdb.fn_editModeofStudy(this);
	}

	public string fn_deleteModeofStudy()
	{
		DBModeofStudyClass objdb = new DBModeofStudyClass();
		return objdb.fn_deleteModeofStudy(iID);
	}

	public CoreWebList<ModeofStudyClass> fn_getModeofStudyList()
	{
		DBModeofStudyClass objdb = new DBModeofStudyClass();
		return objdb.fn_getModeofStudyList();
	}

	public CoreWebList<ModeofStudyClass> fn_getModeofStudyByID()
	{
		DBModeofStudyClass objdb = new DBModeofStudyClass();
		return objdb.fn_getModeofStudyByID(iID);
	}

	public CoreWebList<ModeofStudyClass> fn_getModeofStudyByName()
	{
		DBModeofStudyClass objdb = new DBModeofStudyClass();
		return objdb.fn_getModeofStudyByName(strTitle);
	}

	public CoreWebList<ModeofStudyClass> fn_getModeofStudyByKeys()
	{
		DBModeofStudyClass objdb = new DBModeofStudyClass();
		return objdb.fn_getModeofStudyByKeys(strTitle);
	}

}
