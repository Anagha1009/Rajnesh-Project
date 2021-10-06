using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using yo_lib;

/// <summary>
/// Summary description for CityMasterClass
/// </summary>
public class CityMasterClass
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

    private string _strCityName = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCityName
    {
        get
        {
            return _strCityName;
        }
        set
        {
            _strCityName = value;
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

    private string _strStateName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strStateName
    {
        get
        {
            return _strStateName;
        }
        set
        {
            _strStateName = value;
        }
    }

    private string _strCategory = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCategory
    {
        get
        {
            return _strCategory;
        }
        set
        {
            _strCategory = value;
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

    private int _iCountryID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCountryID
    {
        get
        {
            return _iCountryID;
        }
        set
        {
            _iCountryID = value;
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



    public string fn_saveCity()
    {
        DBCityMasterClass objdb = new DBCityMasterClass();
        return objdb.fn_saveCity(strCityName, iCountryID);
    }

    public string fn_editCity()
    {
        DBCityMasterClass objdb = new DBCityMasterClass();
        return objdb.fn_editCity(iID, strCityName, iCountryID);
    }

    public string fn_deleteCity()
    {
        DBCityMasterClass objdb = new DBCityMasterClass();
        return objdb.fn_deleteCity(iID);
    }

    public CoreWebList<CityMasterClass> fn_getCityList()
    {
        DBCityMasterClass objdb = new DBCityMasterClass();
        return objdb.fn_getCityList();
    }

    public CoreWebList<CityMasterClass> fn_getJobCityList()
    {
        DBCityMasterClass objdb = new DBCityMasterClass();
        return objdb.fn_getJobCityList();
    }

    public CoreWebList<CityMasterClass> fn_getCityListByID()
    {
        return (new DBCityMasterClass()).fn_getCityListByID(iID);
    }


    public CoreWebList<CityMasterClass> fn_getCityByName()
    {
        return (new DBCityMasterClass()).fn_getCityByName(strCityName);
    }

    public CoreWebList<CityMasterClass> fn_getCityListByCountryID()
    {
        return (new DBCityMasterClass()).fn_getCityListByCountryID(iCountryID);
    }

    public string fn_getOtherCityID()
    {
        return (new DBCityMasterClass()).fn_getOtherCityID();
    }

    public CoreWebList<CityMasterClass> fn_getCityListByCityID_And_CountryID()
    {
        return (new DBCityMasterClass()).fn_getCityListByCityID_And_CountryID(iID, iCountryID);
    }

    public CoreWebList<CityMasterClass> fn_getCityListByCountryName()
    {
        return (new DBCityMasterClass()).fn_getCityListByCountryName(strCountryName);
    }

    public CoreWebList<CityMasterClass> fn_getCityListForIndia()
    {
        return (new DBCityMasterClass()).fn_getCityListForIndia();
    }
}
