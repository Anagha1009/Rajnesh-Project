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
/// Summary description for EntranceCategoryClass
/// </summary>

public class EntranceCategoryClass
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

	public string fn_saveEntranceCategory()
	{
		DBEntranceCategoryClass objdb = new DBEntranceCategoryClass();
		return objdb.fn_saveEntranceCategory(this);
	}

	public string fn_editEntranceCategory()
	{
		DBEntranceCategoryClass objdb = new DBEntranceCategoryClass();
		return objdb.fn_editEntranceCategory(this);
	}

	public string fn_deleteEntranceCategory()
	{
		DBEntranceCategoryClass objdb = new DBEntranceCategoryClass();
		return objdb.fn_deleteEntranceCategory(iID);
	}

	public CoreWebList<EntranceCategoryClass> fn_getEntranceCategoryList()
	{
		DBEntranceCategoryClass objdb = new DBEntranceCategoryClass();
		return objdb.fn_getEntranceCategoryList();
	}

	public CoreWebList<EntranceCategoryClass> fn_getEntranceCategoryByID()
	{
		DBEntranceCategoryClass objdb = new DBEntranceCategoryClass();
		return objdb.fn_getEntranceCategoryByID(iID);
	}

	public CoreWebList<EntranceCategoryClass> fn_getEntranceCategoryByName()
	{
		DBEntranceCategoryClass objdb = new DBEntranceCategoryClass();
		return objdb.fn_getEntranceCategoryByName(strTitle);
	}

	public CoreWebList<EntranceCategoryClass> fn_getEntranceCategoryByKeys()
	{
		DBEntranceCategoryClass objdb = new DBEntranceCategoryClass();
		return objdb.fn_getEntranceCategoryByKeys(strTitle);
	}

}
