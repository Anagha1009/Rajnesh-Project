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
/// Summary description for CompetitionQuizOptionClass
/// </summary>

public class CompetitionQuizOptionClass
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

	private int _iQuizID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iQuizID
	{
		get
		{
			return _iQuizID;
		}
		set
		{
			_iQuizID = value;
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

	private string _strLogo = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strLogo
	{
		get
		{
			return _strLogo;
		}
		set
		{
			_strLogo = value;
		}
	}

	private bool _bAnswer = false;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public bool bAnswer
	{
		get
		{
			return _bAnswer;
		}
		set
		{
			_bAnswer = value;
		}
	}

	public string fn_saveCompetitionQuizOption()
	{
		DBCompetitionQuizOptionClass objdb = new DBCompetitionQuizOptionClass();
		return objdb.fn_saveCompetitionQuizOption(this);
	}

	public string fn_editCompetitionQuizOption()
	{
		DBCompetitionQuizOptionClass objdb = new DBCompetitionQuizOptionClass();
		return objdb.fn_editCompetitionQuizOption(this);
	}

	public string fn_deleteCompetitionQuizOption()
	{
		DBCompetitionQuizOptionClass objdb = new DBCompetitionQuizOptionClass();
		return objdb.fn_deleteCompetitionQuizOption(iID);
	}

	public CoreWebList<CompetitionQuizOptionClass> fn_getCompetitionQuizOptionList()
	{
		DBCompetitionQuizOptionClass objdb = new DBCompetitionQuizOptionClass();
		return objdb.fn_getCompetitionQuizOptionList();
	}

	public CoreWebList<CompetitionQuizOptionClass> fn_getCompetitionQuizOptionByID()
	{
		DBCompetitionQuizOptionClass objdb = new DBCompetitionQuizOptionClass();
		return objdb.fn_getCompetitionQuizOptionByID(iID);
	}

	public CoreWebList<CompetitionQuizOptionClass> fn_getCompetitionQuizOptionByName()
	{
		DBCompetitionQuizOptionClass objdb = new DBCompetitionQuizOptionClass();
		return objdb.fn_getCompetitionQuizOptionByName(strTitle);
	}

	public CoreWebList<CompetitionQuizOptionClass> fn_getCompetitionQuizOptionByKeys()
	{
		DBCompetitionQuizOptionClass objdb = new DBCompetitionQuizOptionClass();
		return objdb.fn_getCompetitionQuizOptionByKeys(strTitle);
	}

	public CoreWebList<CompetitionQuizOptionClass> fn_getCompetitionQuizOptionByQuizID()
	{
		DBCompetitionQuizOptionClass objdb = new DBCompetitionQuizOptionClass();
		return objdb.fn_getCompetitionQuizOptionByQuizID(iQuizID);
	}

	public string fn_ChangeCompetitionQuizOptionAnswerStatus()
	{
		DBCompetitionQuizOptionClass objdb = new DBCompetitionQuizOptionClass();
		return objdb.fn_ChangeCompetitionQuizOptionAnswerStatus(this);
	}

}
