using System;
using System.Collections.Generic;
using System.Web;
using yo_lib;

/// <summary>
/// Summary description for LikeClass
/// </summary>
public class LikeClass
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

    private int _iLikeCount = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iLikeCount
    {
        get
        {
            return _iLikeCount;
        }
        set
        {
            _iLikeCount = value;
        }
    }

    private int _iDisLikeCount = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iDisLikeCount
    {
        get
        {
            return _iDisLikeCount;
        }
        set
        {
            _iDisLikeCount = value;
        }
    }

    

    public string fn_SaveLike()
    {
        DBLikeClass objdb = new DBLikeClass();
        return objdb.fn_SaveLike(strType, iTypeID, iLikeCount, iDisLikeCount);
    }

    public string fn_IncLike()
    {
        DBLikeClass objdb = new DBLikeClass();
        return objdb.fn_IncLike(iID);
    }

    public string fn_IncDisLike()
    {
        DBLikeClass objdb = new DBLikeClass();
        return objdb.fn_IncDisLike(iID);
    }

    public CoreWebList<LikeClass> fn_getLikeByTypeID()
    {
        DBLikeClass objdb = new DBLikeClass();
        return objdb.fn_getLikeByTypeID(iTypeID, strType);
    }

}
