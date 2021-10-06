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
/// Summary description for CategoryRankClass
/// </summary>

public class CategoryRankClass
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

	private int _iRank = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iRank
	{
		get
		{
			return _iRank;
		}
		set
		{
			_iRank = value;
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


	public string fn_saveCategoryRank()
	{
		DBCategoryRankClass objdb = new DBCategoryRankClass();
		return objdb.fn_saveCategoryRank(this);
	}

	public string fn_editCategoryRank()
	{
		DBCategoryRankClass objdb = new DBCategoryRankClass();
		return objdb.fn_editCategoryRank(this);
	}

	public string fn_deleteCategoryRank()
	{
		DBCategoryRankClass objdb = new DBCategoryRankClass();
		return objdb.fn_deleteCategoryRank(iID);
	}

	public CoreWebList<CategoryRankClass> fn_getCategoryRankList()
	{
		DBCategoryRankClass objdb = new DBCategoryRankClass();
		return objdb.fn_getCategoryRankList();
	}

	public CoreWebList<CategoryRankClass> fn_getCategoryRankByID()
	{
		DBCategoryRankClass objdb = new DBCategoryRankClass();
		return objdb.fn_getCategoryRankByID(iID);
	}

	public CoreWebList<CategoryRankClass> fn_getCategoryRankByCategoryID()
	{
		DBCategoryRankClass objdb = new DBCategoryRankClass();
		return objdb.fn_getCategoryRankByCategoryID(iCategoryID);
	}

	public CoreWebList<CategoryRankClass> fn_getCategoryRankByInstituteID()
	{
		DBCategoryRankClass objdb = new DBCategoryRankClass();
		return objdb.fn_getCategoryRankByInstituteID(iInstituteID);
	}

}
