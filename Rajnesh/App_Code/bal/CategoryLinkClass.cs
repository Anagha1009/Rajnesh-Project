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
/// Summary description for CategoryLinkClass
/// </summary>

public class CategoryLinkClass
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

	public string fn_saveCategoryLink()
	{
		DBCategoryLinkClass objdb = new DBCategoryLinkClass();
		return objdb.fn_saveCategoryLink(this);
	}

	public string fn_editCategoryLink()
	{
		DBCategoryLinkClass objdb = new DBCategoryLinkClass();
		return objdb.fn_editCategoryLink(this);
	}

	public string fn_deleteCategoryLink()
	{
		DBCategoryLinkClass objdb = new DBCategoryLinkClass();
		return objdb.fn_deleteCategoryLink(iID);
	}

	public CoreWebList<CategoryLinkClass> fn_getCategoryLinkList()
	{
		DBCategoryLinkClass objdb = new DBCategoryLinkClass();
		return objdb.fn_getCategoryLinkList();
	}

	public CoreWebList<CategoryLinkClass> fn_getCategoryLinkByID()
	{
		DBCategoryLinkClass objdb = new DBCategoryLinkClass();
		return objdb.fn_getCategoryLinkByID(iID);
	}

	public CoreWebList<CategoryLinkClass> fn_getCategoryLinkByName()
	{
		DBCategoryLinkClass objdb = new DBCategoryLinkClass();
		return objdb.fn_getCategoryLinkByName(strTitle);
	}

	public CoreWebList<CategoryLinkClass> fn_getCategoryLinkByKeys()
	{
		DBCategoryLinkClass objdb = new DBCategoryLinkClass();
		return objdb.fn_getCategoryLinkByKeys(strTitle);
	}

	public CoreWebList<CategoryLinkClass> fn_getCategoryLinkByCategoryID()
	{
		DBCategoryLinkClass objdb = new DBCategoryLinkClass();
		return objdb.fn_getCategoryLinkByCategoryID(iCategoryID);
	}

}
