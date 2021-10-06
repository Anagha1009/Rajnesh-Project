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
/// Summary description for LevelofStudyClass
/// </summary>

public class LevelofStudyClass
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

	public string fn_saveLevelofStudy()
	{
		DBLevelofStudyClass objdb = new DBLevelofStudyClass();
		return objdb.fn_saveLevelofStudy(this);
	}

	public string fn_editLevelofStudy()
	{
		DBLevelofStudyClass objdb = new DBLevelofStudyClass();
		return objdb.fn_editLevelofStudy(this);
	}

	public string fn_deleteLevelofStudy()
	{
		DBLevelofStudyClass objdb = new DBLevelofStudyClass();
		return objdb.fn_deleteLevelofStudy(iID);
	}

	public CoreWebList<LevelofStudyClass> fn_getLevelofStudyList()
	{
		DBLevelofStudyClass objdb = new DBLevelofStudyClass();
		return objdb.fn_getLevelofStudyList();
	}

	public CoreWebList<LevelofStudyClass> fn_getLevelofStudyByID()
	{
		DBLevelofStudyClass objdb = new DBLevelofStudyClass();
		return objdb.fn_getLevelofStudyByID(iID);
	}

	public CoreWebList<LevelofStudyClass> fn_getLevelofStudyByName()
	{
		DBLevelofStudyClass objdb = new DBLevelofStudyClass();
		return objdb.fn_getLevelofStudyByName(strTitle);
	}

	public CoreWebList<LevelofStudyClass> fn_getLevelofStudyByKeys()
	{
		DBLevelofStudyClass objdb = new DBLevelofStudyClass();
		return objdb.fn_getLevelofStudyByKeys(strTitle);
	}

}
