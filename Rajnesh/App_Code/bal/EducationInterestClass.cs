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
/// Summary description for EducationInterestClass
/// </summary>

public class EducationInterestClass
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

	public string fn_saveEducationInterest()
	{
		DBEducationInterestClass objdb = new DBEducationInterestClass();
		return objdb.fn_saveEducationInterest(this);
	}

	public string fn_editEducationInterest()
	{
		DBEducationInterestClass objdb = new DBEducationInterestClass();
		return objdb.fn_editEducationInterest(this);
	}

	public string fn_deleteEducationInterest()
	{
		DBEducationInterestClass objdb = new DBEducationInterestClass();
		return objdb.fn_deleteEducationInterest(iID);
	}

	public CoreWebList<EducationInterestClass> fn_getEducationInterestList()
	{
		DBEducationInterestClass objdb = new DBEducationInterestClass();
		return objdb.fn_getEducationInterestList();
	}

	public CoreWebList<EducationInterestClass> fn_getEducationInterestByID()
	{
		DBEducationInterestClass objdb = new DBEducationInterestClass();
		return objdb.fn_getEducationInterestByID(iID);
	}

	public CoreWebList<EducationInterestClass> fn_getEducationInterestByName()
	{
		DBEducationInterestClass objdb = new DBEducationInterestClass();
		return objdb.fn_getEducationInterestByName(strTitle);
	}

	public CoreWebList<EducationInterestClass> fn_getEducationInterestByKeys()
	{
		DBEducationInterestClass objdb = new DBEducationInterestClass();
		return objdb.fn_getEducationInterestByKeys(strTitle);
	}

}
