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
/// Summary description for EduReviewDetailClass
/// </summary>

public class EduReviewDetailClass
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

    private string _strFactor = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strFactor
    {
        get
        {
            return _strFactor;
        }
        set
        {
            _strFactor = value;
        }
    }

	private int _iReviewID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iReviewID
	{
		get
		{
			return _iReviewID;
		}
		set
		{
			_iReviewID = value;
		}
	}

	private int _iFactorID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iFactorID
	{
		get
		{
			return _iFactorID;
		}
		set
		{
			_iFactorID = value;
		}
	}

	private int _iFactorValue = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iFactorValue
	{
		get
		{
			return _iFactorValue;
		}
		set
		{
			_iFactorValue = value;
		}
	}

	public string fn_saveEduReviewDetail()
	{
		DBEduReviewDetailClass objdb = new DBEduReviewDetailClass();
		return objdb.fn_saveEduReviewDetail(this);
	}

	public string fn_editEduReviewDetail()
	{
		DBEduReviewDetailClass objdb = new DBEduReviewDetailClass();
		return objdb.fn_editEduReviewDetail(this);
	}

	public string fn_deleteEduReviewDetail()
	{
		DBEduReviewDetailClass objdb = new DBEduReviewDetailClass();
		return objdb.fn_deleteEduReviewDetail(iID);
	}

	public CoreWebList<EduReviewDetailClass> fn_getEduReviewDetailList()
	{
		DBEduReviewDetailClass objdb = new DBEduReviewDetailClass();
		return objdb.fn_getEduReviewDetailList();
	}

	public CoreWebList<EduReviewDetailClass> fn_getEduReviewDetailByID()
	{
		DBEduReviewDetailClass objdb = new DBEduReviewDetailClass();
		return objdb.fn_getEduReviewDetailByID(iID);
	}

	public CoreWebList<EduReviewDetailClass> fn_getEduReviewDetailByReviewID()
	{
		DBEduReviewDetailClass objdb = new DBEduReviewDetailClass();
		return objdb.fn_getEduReviewDetailByReviewID(iReviewID);
	}

	public CoreWebList<EduReviewDetailClass> fn_getEduReviewDetailByFactorID()
	{
		DBEduReviewDetailClass objdb = new DBEduReviewDetailClass();
		return objdb.fn_getEduReviewDetailByFactorID(iFactorID);
	}

    public CoreWebList<EduReviewDetailClass> fn_getEduReviewDetailByFactorHeadingID()
    {
        DBEduReviewDetailClass objdb = new DBEduReviewDetailClass();
        return objdb.fn_getEduReviewDetailByFactorHeadingID(iReviewID, iFactorID);
    }

}
