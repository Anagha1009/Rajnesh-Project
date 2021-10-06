using System;
using System.Collections.Generic;
using System.Web;
using yo_lib;

/// <summary>
/// Summary description for RatingClass
/// </summary>
public class RatingClass
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

    private int _iTypeID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iTypeID
    {
        get
        {
            return _iTypeID;
        }
        set
        {
            _iTypeID = value;
        }
    }

    private float _fCount = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public float fCount
    {
        get
        {
            return _fCount;
        }
        set
        {
            _fCount = value;
        }
    }

    private int _iClicks = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iClicks
    {
        get
        {
            return _iClicks;
        }
        set
        {
            _iClicks = value;
        }
    }

    

    public string fn_SaveRating()
    {
        DBratingClass objdb = new DBratingClass();
        return objdb.fn_SaveRating(strType, iTypeID, fCount, iClicks);
    }

    public string fn_EditRating()
    {
        DBratingClass objdb = new DBratingClass();
        return objdb.fn_EditRating(iID, fCount, iClicks);
    }

    public CoreWebList<RatingClass> fn_getRatingByTypeID()
    {
        DBratingClass objdb = new DBratingClass();
        return objdb.fn_getRatingByTypeID(iTypeID, strType);
    }

}
