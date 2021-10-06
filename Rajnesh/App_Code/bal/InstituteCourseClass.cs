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
/// Summary description for InstituteCourseClass
/// </summary>

public class InstituteCourseClass
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

    private int _iCategoryID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCategoryID
    {
        get
        {
            return _iCategoryID;
        }
        set
        {
            _iCategoryID = value;
        }
    }

	private int _iInstituteID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iInstituteID
	{
		get
		{
			return _iInstituteID;
		}
		set
		{
			_iInstituteID = value;
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

	private string _strDesc = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strDesc
	{
		get
		{
			return _strDesc;
		}
		set
		{
			_strDesc = value;
		}
	}

	private string _strSyllabus = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strSyllabus
	{
		get
		{
			return _strSyllabus;
		}
		set
		{
			_strSyllabus = value;
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

	public string fn_saveInstituteCourse()
	{
		DBInstituteCourseClass objdb = new DBInstituteCourseClass();
		return objdb.fn_saveInstituteCourse(this);
	}

	public string fn_editInstituteCourse()
	{
		DBInstituteCourseClass objdb = new DBInstituteCourseClass();
		return objdb.fn_editInstituteCourse(this);
	}

	public string fn_deleteInstituteCourse()
	{
		DBInstituteCourseClass objdb = new DBInstituteCourseClass();
		return objdb.fn_deleteInstituteCourse(iID);
	}

	public CoreWebList<InstituteCourseClass> fn_getInstituteCourseList()
	{
		DBInstituteCourseClass objdb = new DBInstituteCourseClass();
		return objdb.fn_getInstituteCourseList();
	}

    public CoreWebList<InstituteCourseClass> fn_get_Institute_CourseList()
    {
        DBInstituteCourseClass objdb = new DBInstituteCourseClass();
        return objdb.fn_get_Institute_CourseList();
    }

    public CoreWebList<InstituteCourseClass> fn_getInstituteCourseListByQuery(string strQuery)
    {
        DBInstituteCourseClass objdb = new DBInstituteCourseClass();
        return objdb.fn_getInstituteCourseListByQuery(strQuery);
    }

	public CoreWebList<InstituteCourseClass> fn_getInstituteCourseByID()
	{
		DBInstituteCourseClass objdb = new DBInstituteCourseClass();
		return objdb.fn_getInstituteCourseByID(iID);
	}

    public CoreWebList<InstituteCourseClass> fn_getInstituteCourseListbyCategoryID()
    {
        DBInstituteCourseClass objdb = new DBInstituteCourseClass();
        return objdb.fn_getInstituteCourseListbyCategoryID(iCategoryID);
    }

    public CoreWebList<InstituteCourseClass> fn_getInstituteCourseByIdentity(string strIdentity)
    {
        DBInstituteCourseClass objdb = new DBInstituteCourseClass();
        return objdb.fn_getInstituteCourseByIdentity(strIdentity);
    }

    public CoreWebList<InstituteCourseClass> fn_getInstituteCourseByCourse()
    {
        DBInstituteCourseClass objdb = new DBInstituteCourseClass();
        return objdb.fn_getInstituteCourseByCourse(iInstituteID, strTitle);
    }

    public CoreWebList<InstituteCourseClass> fn_getSimilarCourseByCityCategory(int iCityID)
    {
        DBInstituteCourseClass objdb = new DBInstituteCourseClass();
        return objdb.fn_getSimilarCourseByCityCategory(iID, iCategoryID, iCityID);
    }

	public CoreWebList<InstituteCourseClass> fn_getInstituteCourseByName()
	{
		DBInstituteCourseClass objdb = new DBInstituteCourseClass();
		return objdb.fn_getInstituteCourseByName(strTitle);
	}

	public CoreWebList<InstituteCourseClass> fn_getInstituteCourseByKeys()
	{
		DBInstituteCourseClass objdb = new DBInstituteCourseClass();
		return objdb.fn_getInstituteCourseByKeys(strTitle);
	}

	public CoreWebList<InstituteCourseClass> fn_getInstituteCourseByInstituteID()
	{
		DBInstituteCourseClass objdb = new DBInstituteCourseClass();
		return objdb.fn_getInstituteCourseByInstituteID(iInstituteID);
	}

}
