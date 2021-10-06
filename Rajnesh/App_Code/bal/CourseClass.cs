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
/// Summary description for CourseClass
/// </summary>

public class CourseClass
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

	private int _iUniversityID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iUniversityID
	{
		get
		{
			return _iUniversityID;
		}
		set
		{
			_iUniversityID = value;
		}
	}

	private int _iModeofStudyID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iModeofStudyID
	{
		get
		{
			return _iModeofStudyID;
		}
		set
		{
			_iModeofStudyID = value;
		}
	}

	private int _iLevelofStudyID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iLevelofStudyID
	{
		get
		{
			return _iLevelofStudyID;
		}
		set
		{
			_iLevelofStudyID = value;
		}
	}

    private string _strModeofStudy = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strModeofStudy
    {
        get
        {
            return _strModeofStudy;
        }
        set
        {
            _strModeofStudy = value;
        }
    }

    private string _strLevelofStudy = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strLevelofStudy
    {
        get
        {
            return _strLevelofStudy;
        }
        set
        {
            _strLevelofStudy = value;
        }
    }

    private string _strUniversity = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strUniversity
    {
        get
        {
            return _strUniversity;
        }
        set
        {
            _strUniversity   = value;
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

	private string _strFees = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strFees
	{
		get
		{
			return _strFees;
		}
		set
		{
			_strFees = value;
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

	private string _strEligibility = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strEligibility
	{
		get
		{
			return _strEligibility;
		}
		set
		{
			_strEligibility = value;
		}
	}

	private string _strAdmissionCriteria = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strAdmissionCriteria
	{
		get
		{
			return _strAdmissionCriteria;
		}
		set
		{
			_strAdmissionCriteria = value;
		}
	}

	public string fn_saveCourse()
	{
		DBCourseClass objdb = new DBCourseClass();
		return objdb.fn_saveCourse(this);
	}

	public string fn_editCourse()
	{
		DBCourseClass objdb = new DBCourseClass();
		return objdb.fn_editCourse(this);
	}

	public string fn_deleteCourse()
	{
		DBCourseClass objdb = new DBCourseClass();
		return objdb.fn_deleteCourse(iID);
	}

	public CoreWebList<CourseClass> fn_getCourseList()
	{
		DBCourseClass objdb = new DBCourseClass();
		return objdb.fn_getCourseList();
	}

	public CoreWebList<CourseClass> fn_getCourseByID()
	{
		DBCourseClass objdb = new DBCourseClass();
		return objdb.fn_getCourseByID(iID);
	}

	public CoreWebList<CourseClass> fn_getCourseByName()
	{
		DBCourseClass objdb = new DBCourseClass();
		return objdb.fn_getCourseByName(strTitle);
	}

	public CoreWebList<CourseClass> fn_getCourseByKeys()
	{
		DBCourseClass objdb = new DBCourseClass();
		return objdb.fn_getCourseByKeys(strTitle);
	}

	public CoreWebList<CourseClass> fn_getCourseByLevelofStudyID()
	{
		DBCourseClass objdb = new DBCourseClass();
		return objdb.fn_getCourseByLevelofStudyID(iLevelofStudyID);
	}

	public CoreWebList<CourseClass> fn_getCourseByModeofStudyID()
	{
		DBCourseClass objdb = new DBCourseClass();
		return objdb.fn_getCourseByModeofStudyID(iModeofStudyID);
	}

	public CoreWebList<CourseClass> fn_getCourseByUniversityID()
	{
		DBCourseClass objdb = new DBCourseClass();
		return objdb.fn_getCourseByUniversityID(iUniversityID);
	}

}
