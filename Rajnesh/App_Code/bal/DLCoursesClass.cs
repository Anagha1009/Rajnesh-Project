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
/// Summary description for DLCoursesClass
/// </summary>
public class DLCoursesClass
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

    private int _iCenterCount = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCenterCount
    {
        get
        {
            return _iCenterCount;
        }
        set
        {
            _iCenterCount = value;
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

    private string _strInstitute = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strInstitute
    {
        get
        {
            return _strInstitute;
        }
        set
        {
            _strInstitute = value;
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


    public string fn_saveDLCourse()
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_saveDLCourse(iDistanceID, iTypeID, strName, strDescription);
    }

    public string fn_editDLCourse()
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_editDLCourse(iID, iDistanceID, iTypeID, strName, strDescription);
    }

    public string fn_deleteDLCourse()
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_deleteDLCourse(iID);
    }

    public CoreWebList<DLCoursesClass> fn_getDLCourseByID()
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_getDLCourseByID(iID);
    }

    public CoreWebList<DLCoursesClass> fn_getCourseByName()
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_getCourseByName(strName);
    }

    public CoreWebList<DLCoursesClass> fn_getDL_Course_By_ID()
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_getDL_Course_By_ID(iID);
    }

    public CoreWebList<DLCoursesClass> fn_getDLCourseByDistanceID()
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_getDLCourseByDistanceID(iDistanceID);
    }

    public CoreWebList<DLCoursesClass> fn_getRandomDLCourseByDistanceID()
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_getRandomDLCourseByDistanceID(iDistanceID);
    }

    public CoreWebList<DLCoursesClass> fn_getDLCourseList()
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_getDLCourseList();
    }

    public CoreWebList<DLCoursesClass> fn_getRandomDLCourseList()
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_getRandomDLCourseList();
    }

    public CoreWebList<DLCoursesClass> fn_getCoursesList()
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_getCoursesList();
    }

    public CoreWebList<DLCoursesClass> fn_getRandom_CoursesList()
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_getRandom_CoursesList();
    }

    public CoreWebList<DLCoursesClass> fn_SearchCoursesList(string strQuery)
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_SearchCoursesList(strQuery);
    }

    public CoreWebList<DLCoursesClass> fn_Search_Courses_List()
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_Search_Courses_List(iID, strName);
    }

    public CoreWebList<DLCoursesClass> fn_SearchDLInst_ForClient(string strQuery)
    {
        DBDLCoursesClass objdb = new DBDLCoursesClass();
        return objdb.fn_SearchDLInst_ForClient(strQuery);
    }
}
