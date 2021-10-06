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
/// Summary description for CategoryClass
/// </summary>

public class CategoryClass
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

    private int _iOrderNo = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iOrderNo
    {
        get
        {
            return _iOrderNo;
        }
        set
        {
            _iOrderNo = value;
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

    private string _strUrl = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strUrl
    {
        get
        {
            return _strUrl;
        }
        set
        {
            _strUrl = value;
        }
    }

	private string _strShortDesc = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strShortDesc
	{
		get
		{
			return _strShortDesc;
		}
		set
		{
			_strShortDesc = value;
		}
	}

	private string _strLongDesc = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strLongDesc
	{
		get
		{
			return _strLongDesc;
		}
		set
		{
			_strLongDesc = value;
		}
	}

	private string _strSmallImage = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strSmallImage
	{
		get
		{
			return _strSmallImage;
		}
		set
		{
			_strSmallImage = value;
		}
	}

	private string _strMediumImage = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strMediumImage
	{
		get
		{
			return _strMediumImage;
		}
		set
		{
			_strMediumImage = value;
		}
	}

	private string _strBigImage = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strBigImage
	{
		get
		{
			return _strBigImage;
		}
		set
		{
			_strBigImage = value;
		}
	}

	private string _strTitleColorCode = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strTitleColorCode
	{
		get
		{
			return _strTitleColorCode;
		}
		set
		{
			_strTitleColorCode = value;
		}
	}

	private string _strContentColorCode = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strContentColorCode
	{
		get
		{
			return _strContentColorCode;
		}
		set
		{
			_strContentColorCode = value;
		}
	}

	private bool _bShowHome = false;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public bool bShowHome
	{
		get
		{
			return _bShowHome;
		}
		set
		{
			_bShowHome = value;
		}
	}

	public string fn_saveCategory()
	{
		DBCategoryClass objdb = new DBCategoryClass();
		return objdb.fn_saveCategory(this);
	}

	public string fn_editCategory()
	{
		DBCategoryClass objdb = new DBCategoryClass();
		return objdb.fn_editCategory(this);
	}

	public string fn_deleteCategory()
	{
		DBCategoryClass objdb = new DBCategoryClass();
		return objdb.fn_deleteCategory(iID);
	}

	public CoreWebList<CategoryClass> fn_getCategoryList()
	{
		DBCategoryClass objdb = new DBCategoryClass();
		return objdb.fn_getCategoryList();
	}

    public CoreWebList<CategoryClass> fn_getHomeCategoryList()
    {
        DBCategoryClass objdb = new DBCategoryClass();
        return objdb.fn_getHomeCategoryList();
    }

	public CoreWebList<CategoryClass> fn_getCategoryByID()
	{
		DBCategoryClass objdb = new DBCategoryClass();
		return objdb.fn_getCategoryByID(iID);
	}

	public CoreWebList<CategoryClass> fn_getCategoryByName()
	{
		DBCategoryClass objdb = new DBCategoryClass();
		return objdb.fn_getCategoryByName(strTitle);
	}

	public CoreWebList<CategoryClass> fn_getCategoryByKeys()
	{
		DBCategoryClass objdb = new DBCategoryClass();
		return objdb.fn_getCategoryByKeys(strTitle);
	}

	public string fn_ChangeCategoryShowHomeStatus()
	{
		DBCategoryClass objdb = new DBCategoryClass();
		return objdb.fn_ChangeCategoryShowHomeStatus(this);
	}

}
