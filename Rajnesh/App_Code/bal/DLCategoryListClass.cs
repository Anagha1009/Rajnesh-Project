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
/// Summary description for DLCategoryListClass
/// </summary>
public class DLCategoryListClass
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

    private int _iDistanceID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iDistanceID
    {
        get
        {
            return _iDistanceID;
        }
        set
        {
            _iDistanceID = value;
        }
    }

    private int _iCatID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCatID
    {
        get
        {
            return _iCatID;
        }
        set
        {
            _iCatID = value;
        }
    }
   
    private int[] _iCatIDArray = new int[1];

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int[] iCatIDArray
    {
        get
        {
            return _iCatIDArray;
        }
        set
        {
            _iCatIDArray = value;
        }
    }

    public string fn_saveDLCategoryList()
    {
        DBDLCategoryListClass objdb = new DBDLCategoryListClass();
        return objdb.fn_saveDLCategoryList(iCatIDArray, iDistanceID);
    }

    public string fn_editDLCategoryList()
    {
        DBDLCategoryListClass objdb = new DBDLCategoryListClass();
        return objdb.fn_editDLCategoryList(iID, iCatIDArray, iDistanceID);
    }

    public string fn_deleteDLCategoryList()
    {
        DBDLCategoryListClass objdb = new DBDLCategoryListClass();
        return objdb.fn_deleteDLCategoryList(iID);
    }

    public CoreWebList<DLCategoryListClass> fn_getDLCategoryListByID()
    {
        DBDLCategoryListClass objdb = new DBDLCategoryListClass();
        return objdb.fn_getDLCategoryListByID(iID);
    }

    public CoreWebList<DLCategoryListClass> fn_getDLCategoryList()
    {
        DBDLCategoryListClass objdb = new DBDLCategoryListClass();
        return objdb.fn_getDLCategoryList();
    }

    public ArrayList fn_getDLCategoryListBy_DLID()
    {
        DBDLCategoryListClass objdb = new DBDLCategoryListClass();
        return objdb.fn_getDLCategoryListBy_DLID(iDistanceID);
    }

    public CoreWebList<DLCategoryListClass> fn_getDLCategoryListByDLID()
    {
        DBDLCategoryListClass objdb = new DBDLCategoryListClass();
        return objdb.fn_getDLCategoryListByDLID(iDistanceID);
    }
}
