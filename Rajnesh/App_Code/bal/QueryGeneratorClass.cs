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
/// Summary description for QueryGeneratorClass
/// </summary>

public class QueryGeneratorClass
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

	private int _iCityID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iCityID
	{
		get
		{
			return _iCityID;
		}
		set
		{
			_iCityID = value;
		}
	}

	private int _iCategoryID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iCategoryID
	{
		get
		{
			return _iCategoryID;
		}
		set
		{
			_iCategoryID = value;
		}
	}

	private string _strType = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strType
	{
		get
		{
			return _strType;
		}
		set
		{
			_strType = value;
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

	private string _strIdentity = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strIdentity
	{
		get
		{
			return _strIdentity;
		}
		set
		{
			_strIdentity = value;
		}
	}

	private string _strMetaTitle = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strMetaTitle
	{
		get
		{
			return _strMetaTitle;
		}
		set
		{
			_strMetaTitle = value;
		}
	}

	private string _strMetaDesc = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strMetaDesc
	{
		get
		{
			return _strMetaDesc;
		}
		set
		{
			_strMetaDesc = value;
		}
	}

	private string _strMetakeys = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strMetakeys
	{
		get
		{
			return _strMetakeys;
		}
		set
		{
			_strMetakeys = value;
		}
	}

    private string _strYoutubeTitle = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strYoutubeTitle
    {
        get
        {
            return _strYoutubeTitle;
        }
        set
        {
            _strYoutubeTitle = value;
        }
    }

    private string _strYoutube = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strYoutube
    {
        get
        {
            return _strYoutube;
        }
        set
        {
            _strYoutube = value;
        }
    }

    public string fn_saveQueryGenerator()
	{
		DBQueryGeneratorClass objdb = new DBQueryGeneratorClass();
		return objdb.fn_saveQueryGenerator(this);
	}

	public string fn_editQueryGenerator()
	{
		DBQueryGeneratorClass objdb = new DBQueryGeneratorClass();
		return objdb.fn_editQueryGenerator(this);
	}

	public string fn_deleteQueryGenerator()
	{
		DBQueryGeneratorClass objdb = new DBQueryGeneratorClass();
		return objdb.fn_deleteQueryGenerator(iID);
	}

	public CoreWebList<QueryGeneratorClass> fn_getQueryGeneratorList()
	{
		DBQueryGeneratorClass objdb = new DBQueryGeneratorClass();
		return objdb.fn_getQueryGeneratorList();
	}

    public CoreWebList<QueryGeneratorClass> fn_getRandomQueryGeneratorList()
    {
        DBQueryGeneratorClass objdb = new DBQueryGeneratorClass();
        return objdb.fn_getRandomQueryGeneratorList();
    }

	public CoreWebList<QueryGeneratorClass> fn_getQueryGeneratorByID()
	{
		DBQueryGeneratorClass objdb = new DBQueryGeneratorClass();
		return objdb.fn_getQueryGeneratorByID(iID);
	}

	public CoreWebList<QueryGeneratorClass> fn_getQueryGeneratorByName()
	{
		DBQueryGeneratorClass objdb = new DBQueryGeneratorClass();
		return objdb.fn_getQueryGeneratorByName(strTitle);
	}

	public CoreWebList<QueryGeneratorClass> fn_getQueryGeneratorByKeys()
	{
		DBQueryGeneratorClass objdb = new DBQueryGeneratorClass();
		return objdb.fn_getQueryGeneratorByKeys(strTitle);
	}

}
