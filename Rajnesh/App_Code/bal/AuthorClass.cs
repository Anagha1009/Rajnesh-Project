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
/// Summary description for AuthorClass
/// </summary>

public class AuthorClass
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

	private string _strName = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strName
	{
		get
		{
			return _strName;
		}
		set
		{
			_strName = value;
		}
	}

	private string _strEmail = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strEmail
	{
		get
		{
			return _strEmail;
		}
		set
		{
			_strEmail = value;
		}
	}

	private string _strConnectUrl = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strConnectUrl
	{
		get
		{
			return _strConnectUrl;
		}
		set
		{
			_strConnectUrl = value;
		}
	}

	private string _strDetails = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strDetails
	{
		get
		{
			return _strDetails;
		}
		set
		{
			_strDetails = value;
		}
	}

	private string _strPhoto = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strPhoto
	{
		get
		{
			return _strPhoto;
		}
		set
		{
			_strPhoto = value;
		}
	}

	public string fn_saveAuthor()
	{
		DBAuthorClass objdb = new DBAuthorClass();
		return objdb.fn_saveAuthor(this);
	}

	public string fn_editAuthor()
	{
		DBAuthorClass objdb = new DBAuthorClass();
		return objdb.fn_editAuthor(this);
	}

	public string fn_deleteAuthor()
	{
		DBAuthorClass objdb = new DBAuthorClass();
		return objdb.fn_deleteAuthor(iID);
	}

	public CoreWebList<AuthorClass> fn_getAuthorList()
	{
		DBAuthorClass objdb = new DBAuthorClass();
		return objdb.fn_getAuthorList();
	}

	public CoreWebList<AuthorClass> fn_getAuthorByID()
	{
		DBAuthorClass objdb = new DBAuthorClass();
		return objdb.fn_getAuthorByID(iID);
	}

	public CoreWebList<AuthorClass> fn_getAuthorByName()
	{
		DBAuthorClass objdb = new DBAuthorClass();
		return objdb.fn_getAuthorByName(strName);
	}

	public CoreWebList<AuthorClass> fn_getAuthorByKeys()
	{
		DBAuthorClass objdb = new DBAuthorClass();
		return objdb.fn_getAuthorByKeys(strName);
	}

    public CoreWebList<AuthorClass> fn_getTopAuthorList()
    {
        DBAuthorClass objdb = new DBAuthorClass();
        return objdb.fn_getTopAuthorList();
    }

}
