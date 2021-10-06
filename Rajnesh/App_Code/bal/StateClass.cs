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
/// Summary description for StateClass
/// </summary>

public class StateClass
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

	public string fn_saveState()
	{
		DBStateClass objdb = new DBStateClass();
		return objdb.fn_saveState(this);
	}

	public string fn_editState()
	{
		DBStateClass objdb = new DBStateClass();
		return objdb.fn_editState(this);
	}

	public string fn_deleteState()
	{
		DBStateClass objdb = new DBStateClass();
		return objdb.fn_deleteState(iID);
	}

	public CoreWebList<StateClass> fn_getStateList()
	{
		DBStateClass objdb = new DBStateClass();
		return objdb.fn_getStateList();
	}

	public CoreWebList<StateClass> fn_getStateByID()
	{
		DBStateClass objdb = new DBStateClass();
		return objdb.fn_getStateByID(iID);
	}

	public CoreWebList<StateClass> fn_getStateByName()
	{
		DBStateClass objdb = new DBStateClass();
		return objdb.fn_getStateByName(strTitle);
	}

	public CoreWebList<StateClass> fn_getStateByKeys()
	{
		DBStateClass objdb = new DBStateClass();
		return objdb.fn_getStateByKeys(strTitle);
	}

}
