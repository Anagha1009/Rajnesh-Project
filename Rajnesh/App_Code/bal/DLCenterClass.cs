using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using yo_lib;

/// <summary>
/// Summary description for DLCenterClass
/// </summary>
public class DLCenterClass
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

    private int _iDLInstituteID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iDLInstituteID
    {
        get
        {
            return _iDLInstituteID;
        }
        set
        {
            _iDLInstituteID = value;
        }
    }

    private string _strCity = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCity
    {
        get
        {
            return _strCity;
        }
        set
        {
            _strCity = value;
        }
    }

    private string _strAddress = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strAddress
    {
        get
        {
            return _strAddress;
        }
        set
        {
            _strAddress = value;
        }
    }


    public string fn_SaveDLCentre()
    {
        DBDLCenterClass objdb = new DBDLCenterClass();
        return objdb.fn_SaveDLCentre(iDLInstituteID, strCity, strAddress);
    }

    public string fn_EditDLCentre()
    {
        DBDLCenterClass objdb = new DBDLCenterClass();
        return objdb.fn_EditDLCentre(iID, iDLInstituteID, strCity, strAddress);
    }

    public string fn_DeleteDLCentre()
    {
        DBDLCenterClass objdb = new DBDLCenterClass();
        return objdb.fn_DeleteDLCentre(iID);
    }

    public CoreWebList<DLCenterClass> fn_GetDLCentreByID()
    {
        DBDLCenterClass objdb = new DBDLCenterClass();
        return objdb.fn_GetDLCentreByID(iID);
    }

    public CoreWebList<DLCenterClass> fn_GetDLCentreList()
    {
        DBDLCenterClass objdb = new DBDLCenterClass();
        return objdb.fn_GetDLCentreList();
    }

    public CoreWebList<DLCenterClass> fn_get_DLCentreListByInstituteID()
    {
        DBDLCenterClass objdb = new DBDLCenterClass();
        return objdb.fn_get_DLCentreListByInstituteID(iDLInstituteID);
    }

    public CoreWebList<DLCenterClass> fn_get_CitiesByInstituteID()
    {
        DBDLCenterClass objdb = new DBDLCenterClass();
        return objdb.fn_get_CitiesByInstituteID(iDLInstituteID);
    }

    public CoreWebList<DLCenterClass> fn_get_DLCentreListByCityName()
    {
        DBDLCenterClass objdb = new DBDLCenterClass();
        return objdb.fn_get_DLCentreListByCityName(strCity, iDLInstituteID);
    }
}
