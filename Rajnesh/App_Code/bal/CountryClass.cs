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
/// Summary description for CountryClass
/// </summary>

public class CountryClass
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

	public string fn_saveCountry()
	{
		DBCountryClass objdb = new DBCountryClass();
		return objdb.fn_saveCountry(this);
	}

	public string fn_editCountry()
	{
		DBCountryClass objdb = new DBCountryClass();
		return objdb.fn_editCountry(this);
	}

	public string fn_deleteCountry()
	{
		DBCountryClass objdb = new DBCountryClass();
		return objdb.fn_deleteCountry(iID);
	}

	public CoreWebList<CountryClass> fn_getCountryList()
	{
		DBCountryClass objdb = new DBCountryClass();
		return objdb.fn_getCountryList();
	}

	public CoreWebList<CountryClass> fn_getCountryByID()
	{
		DBCountryClass objdb = new DBCountryClass();
		return objdb.fn_getCountryByID(iID);
	}

	public CoreWebList<CountryClass> fn_getCountryByName()
	{
		DBCountryClass objdb = new DBCountryClass();
		return objdb.fn_getCountryByName(strTitle);
	}

	public CoreWebList<CountryClass> fn_getCountryByKeys()
	{
		DBCountryClass objdb = new DBCountryClass();
		return objdb.fn_getCountryByKeys(strTitle);
	}

}
