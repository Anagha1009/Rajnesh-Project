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
/// Summary description for CompetitionQuizClass
/// </summary>

public class CompetitionQuizClass
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

	private string _strIcon = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strIcon
	{
		get
		{
			return _strIcon;
		}
		set
		{
			_strIcon = value;
		}
	}

	public string fn_saveCompetitionQuiz()
	{
		DBCompetitionQuizClass objdb = new DBCompetitionQuizClass();
		return objdb.fn_saveCompetitionQuiz(this);
	}

	public string fn_editCompetitionQuiz()
	{
		DBCompetitionQuizClass objdb = new DBCompetitionQuizClass();
		return objdb.fn_editCompetitionQuiz(this);
	}

	public string fn_deleteCompetitionQuiz()
	{
		DBCompetitionQuizClass objdb = new DBCompetitionQuizClass();
		return objdb.fn_deleteCompetitionQuiz(iID);
	}

	public CoreWebList<CompetitionQuizClass> fn_getCompetitionQuizList()
	{
		DBCompetitionQuizClass objdb = new DBCompetitionQuizClass();
		return objdb.fn_getCompetitionQuizList();
	}

	public CoreWebList<CompetitionQuizClass> fn_getCompetitionQuizByID()
	{
		DBCompetitionQuizClass objdb = new DBCompetitionQuizClass();
		return objdb.fn_getCompetitionQuizByID(iID);
	}

	public CoreWebList<CompetitionQuizClass> fn_getCompetitionQuizByName()
	{
		DBCompetitionQuizClass objdb = new DBCompetitionQuizClass();
		return objdb.fn_getCompetitionQuizByName(strTitle);
	}

	public CoreWebList<CompetitionQuizClass> fn_getCompetitionQuizByKeys()
	{
		DBCompetitionQuizClass objdb = new DBCompetitionQuizClass();
		return objdb.fn_getCompetitionQuizByKeys(strTitle);
	}

	public CoreWebList<CompetitionQuizClass> fn_getCompetitionQuizByCompetitionID()
	{
		DBCompetitionQuizClass objdb = new DBCompetitionQuizClass();
		return objdb.fn_getCompetitionQuizByCompetitionID(iCompetitionID);
	}

    public CoreWebList<CompetitionQuizClass> fn_getNextCompetitionQuiz()
    {
        DBCompetitionQuizClass objdb = new DBCompetitionQuizClass();
        return objdb.fn_getNextCompetitionQuiz(iCompetitionID, iID);
    }

}
