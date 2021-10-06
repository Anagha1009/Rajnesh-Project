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
/// Summary description for QualificationClass
/// </summary>

public class QualificationClass
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

	public string fn_saveQualification()
	{
		DBQualificationClass objdb = new DBQualificationClass();
		return objdb.fn_saveQualification(this);
	}

	public string fn_editQualification()
	{
		DBQualificationClass objdb = new DBQualificationClass();
		return objdb.fn_editQualification(this);
	}

	public string fn_deleteQualification()
	{
		DBQualificationClass objdb = new DBQualificationClass();
		return objdb.fn_deleteQualification(iID);
	}

	public CoreWebList<QualificationClass> fn_getQualificationList()
	{
		DBQualificationClass objdb = new DBQualificationClass();
		return objdb.fn_getQualificationList();
	}

	public CoreWebList<QualificationClass> fn_getQualificationByID()
	{
		DBQualificationClass objdb = new DBQualificationClass();
		return objdb.fn_getQualificationByID(iID);
	}

	public CoreWebList<QualificationClass> fn_getQualificationByName()
	{
		DBQualificationClass objdb = new DBQualificationClass();
		return objdb.fn_getQualificationByName(strTitle);
	}

	public CoreWebList<QualificationClass> fn_getQualificationByKeys()
	{
		DBQualificationClass objdb = new DBQualificationClass();
		return objdb.fn_getQualificationByKeys(strTitle);
	}

}
