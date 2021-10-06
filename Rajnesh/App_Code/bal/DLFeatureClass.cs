using System;
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
/// Summary description for DLFeatureClass
/// </summary>
public class DLFeatureClass
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

    private int _iCourseID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCourseID
    {
        get
        {
            return _iCourseID;
        }
        set
        {
            _iCourseID = value;
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

    private string _strDescription = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strDescription
    {
        get
        {
            return _strDescription;
        }
        set
        {
            _strDescription = value;
        }
    }


    public string fn_saveDLFeature()
    {
        DBDLFeatureClass objdb = new DBDLFeatureClass();
        return objdb.fn_saveDLFeature(iCourseID, iDistanceID, strName, strDescription);
    }

    public string fn_editDLFeature()
    {
        DBDLFeatureClass objdb = new DBDLFeatureClass();
        return objdb.fn_editDLFeature(iID, iCourseID, iDistanceID, strName, strDescription);
    }

    public string fn_deleteDLFeature()
    {
        DBDLFeatureClass objdb = new DBDLFeatureClass();
        return objdb.fn_deleteDLFeature(iID);
    }

    public CoreWebList<DLFeatureClass> fn_getDLFeatureByID()
    {
        DBDLFeatureClass objdb = new DBDLFeatureClass();
        return objdb.fn_getDLFeatureByID(iID);
    }

    public CoreWebList<DLFeatureClass> fn_getDLFeatureByCourseID()
    {
        DBDLFeatureClass objdb = new DBDLFeatureClass();
        return objdb.fn_getDLFeatureByCourseID(iCourseID);
    }

    public CoreWebList<DLFeatureClass> fn_getDLFeatureList()
    {
        DBDLFeatureClass objdb = new DBDLFeatureClass();
        return objdb.fn_getDLFeatureList();
    }
}
