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
/// Summary description for CountryMasterClass
/// </summary>
public class CountryMasterClass
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

    private string _strCountryName = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCountryName
    {
        get
        {
            return _strCountryName;
        }
        set
        {
            _strCountryName = value;
        }
    }

    private int _iGMT = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iGMT
    {
        get
        {
            return _iGMT;
        }
        set
        {
            _iGMT = value;
        }
    }

    private int _iDoneByID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iDoneByID
    {
        get
        {
            return _iDoneByID;
        }
        set
        {
            _iDoneByID = value;
        }
    }

    public string fn_saveCountry()
    {
        DBCountryMasterClass objdb = new DBCountryMasterClass();
        return objdb.fn_saveCountry(strCountryName);
    }

    public string fn_editCountry()
    {
        DBCountryMasterClass objdb = new DBCountryMasterClass();
        return objdb.fn_editCountry(iID, strCountryName);
    }

    public string fn_deleteCountry()
    {
        DBCountryMasterClass objdb = new DBCountryMasterClass();
        return objdb.fn_deleteCountry(iID);
    }

    public CoreWebList<CountryMasterClass> fn_getCountryByID()
    {
        DBCountryMasterClass objdb = new DBCountryMasterClass();
        return objdb.fn_getCountryByID(iID);
    }

    public CoreWebList<CountryMasterClass> fn_getCountryByCoutryName()
    {
        DBCountryMasterClass objdb = new DBCountryMasterClass();
        return objdb.fn_getCountryByCoutryName(strCountryName);
    }

    public CoreWebList<CountryMasterClass> fn_getCountryList()
    {
        DBCountryMasterClass objdb = new DBCountryMasterClass();
        return objdb.fn_getCountryList();
    }
}
