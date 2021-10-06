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
/// Summary description for PageClass
/// </summary>

public class PageClass
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

	public string fn_savePage()
	{
		DBPageClass objdb = new DBPageClass();
		return objdb.fn_savePage(this);
	}

	public string fn_editPage()
	{
		DBPageClass objdb = new DBPageClass();
		return objdb.fn_editPage(this);
	}

	public string fn_deletePage()
	{
		DBPageClass objdb = new DBPageClass();
		return objdb.fn_deletePage(iID);
	}

	public CoreWebList<PageClass> fn_getPageList()
	{
		DBPageClass objdb = new DBPageClass();
		return objdb.fn_getPageList();
	}

	public CoreWebList<PageClass> fn_getPageByID()
	{
		DBPageClass objdb = new DBPageClass();
		return objdb.fn_getPageByID(iID);
	}

	public CoreWebList<PageClass> fn_getPageByName()
	{
		DBPageClass objdb = new DBPageClass();
		return objdb.fn_getPageByName(strTitle);
	}

	public CoreWebList<PageClass> fn_getPageByKeys()
	{
		DBPageClass objdb = new DBPageClass();
		return objdb.fn_getPageByKeys(strTitle);
	}

	public CoreWebList<PageClass> fn_getPageByCategoryID()
	{
		DBPageClass objdb = new DBPageClass();
		return objdb.fn_getPageByCategoryID(iCategoryID);
	}

}
