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
/// Summary description for CityClass
/// </summary>

public class CityClass
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

	private int _iStateID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iStateID
	{
		get
		{
			return _iStateID;
		}
		set
		{
			_iStateID = value;
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

	public string fn_saveCity()
	{
		DBCityClass objdb = new DBCityClass();
		return objdb.fn_saveCity(this);
	}

	public string fn_editCity()
	{
		DBCityClass objdb = new DBCityClass();
		return objdb.fn_editCity(this);
	}

	public string fn_deleteCity()
	{
		DBCityClass objdb = new DBCityClass();
		return objdb.fn_deleteCity(iID);
	}

	public CoreWebList<CityClass> fn_getCityList()
	{
		DBCityClass objdb = new DBCityClass();
		return objdb.fn_getCityList();
	}

	public CoreWebList<CityClass> fn_getCityByID()
	{
		DBCityClass objdb = new DBCityClass();
		return objdb.fn_getCityByID(iID);
	}

	public CoreWebList<CityClass> fn_getCityByName()
	{
		DBCityClass objdb = new DBCityClass();
		return objdb.fn_getCityByName(strTitle);
	}

	public CoreWebList<CityClass> fn_getCityByKeys()
	{
		DBCityClass objdb = new DBCityClass();
		return objdb.fn_getCityByKeys(strTitle);
	}

	public CoreWebList<CityClass> fn_getCityByStateID()
	{
		DBCityClass objdb = new DBCityClass();
		return objdb.fn_getCityByStateID(iStateID);
	}

}
