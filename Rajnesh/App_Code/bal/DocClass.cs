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
/// Summary description for DocClass
/// </summary>

public class DocClass
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

	public string fn_saveDoc()
	{
		DBDocClass objdb = new DBDocClass();
		return objdb.fn_saveDoc(this);
	}

	public string fn_editDoc()
	{
		DBDocClass objdb = new DBDocClass();
		return objdb.fn_editDoc(this);
	}

	public string fn_deleteDoc()
	{
		DBDocClass objdb = new DBDocClass();
		return objdb.fn_deleteDoc(iID);
	}

	public CoreWebList<DocClass> fn_getDocList()
	{
		DBDocClass objdb = new DBDocClass();
		return objdb.fn_getDocList();
	}

	public CoreWebList<DocClass> fn_getDocByID()
	{
		DBDocClass objdb = new DBDocClass();
		return objdb.fn_getDocByID(iID);
	}

    public CoreWebList<DocClass> fn_getDocByKeys()
    {
        DBDocClass objdb = new DBDocClass();
        return objdb.fn_getDocByKeys(strFile);
    }

}
