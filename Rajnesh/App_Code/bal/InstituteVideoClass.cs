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
/// Summary description for InstituteVideoClass
/// </summary>

public class InstituteVideoClass
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

	private int _iInstituteID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iInstituteID
	{
		get
		{
			return _iInstituteID;
		}
		set
		{
			_iInstituteID = value;
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

	private string _strUrl = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strUrl
	{
		get
		{
			return _strUrl;
		}
		set
		{
			_strUrl = value;
		}
	}

	public string fn_saveInstituteVideo()
	{
		DBInstituteVideoClass objdb = new DBInstituteVideoClass();
		return objdb.fn_saveInstituteVideo(this);
	}

	public string fn_editInstituteVideo()
	{
		DBInstituteVideoClass objdb = new DBInstituteVideoClass();
		return objdb.fn_editInstituteVideo(this);
	}

	public string fn_deleteInstituteVideo()
	{
		DBInstituteVideoClass objdb = new DBInstituteVideoClass();
		return objdb.fn_deleteInstituteVideo(iID);
	}

	public CoreWebList<InstituteVideoClass> fn_getInstituteVideoList()
	{
		DBInstituteVideoClass objdb = new DBInstituteVideoClass();
		return objdb.fn_getInstituteVideoList();
	}

	public CoreWebList<InstituteVideoClass> fn_getInstituteVideoByID()
	{
		DBInstituteVideoClass objdb = new DBInstituteVideoClass();
		return objdb.fn_getInstituteVideoByID(iID);
	}

    public CoreWebList<InstituteVideoClass> fn_getInstituteVideoByInstituteID()
    {
        DBInstituteVideoClass objdb = new DBInstituteVideoClass();
        return objdb.fn_getInstituteVideoByInstituteID(iInstituteID);
    }

	public CoreWebList<InstituteVideoClass> fn_getInstituteVideoByName()
	{
		DBInstituteVideoClass objdb = new DBInstituteVideoClass();
		return objdb.fn_getInstituteVideoByName(strTitle);
	}

	public CoreWebList<InstituteVideoClass> fn_getInstituteVideoByKeys()
	{
		DBInstituteVideoClass objdb = new DBInstituteVideoClass();
		return objdb.fn_getInstituteVideoByKeys(strTitle);
	}

}
