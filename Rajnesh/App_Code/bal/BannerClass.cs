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
/// Summary description for BannerClass
/// </summary>

public class BannerClass
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

    private int _iOrderID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iOrderID
    {
        get
        {
            return _iOrderID;
        }
        set
        {
            _iOrderID = value;
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

    private string _strDetailTitle = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strDetailTitle
    {
        get
        {
            return _strDetailTitle;
        }
        set
        {
            _strDetailTitle = value;
        }
    }

    private string _strDetailDesc = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strDetailDesc
    {
        get
        {
            return _strDetailDesc;
        }
        set
        {
            _strDetailDesc = value;
        }
    }

    private string _strDetailLink = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strDetailLink
    {
        get
        {
            return _strDetailLink;
        }
        set
        {
            _strDetailLink = value;
        }
    }

    private string _strDetailPhoto = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strDetailPhoto
    {
        get
        {
            return _strDetailPhoto;
        }
        set
        {
            _strDetailPhoto = value;
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

	private string _strTargetUrl = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strTargetUrl
	{
		get
		{
			return _strTargetUrl;
		}
		set
		{
			_strTargetUrl = value;
		}
	}

	private string _strPhoto = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strPhoto
	{
		get
		{
			return _strPhoto;
		}
		set
		{
			_strPhoto = value;
		}
	}

	public string fn_saveBanner()
	{
		DBBannerClass objdb = new DBBannerClass();
		return objdb.fn_saveBanner(this);
	}

	public string fn_editBanner()
	{
		DBBannerClass objdb = new DBBannerClass();
		return objdb.fn_editBanner(this);
	}

	public string fn_deleteBanner()
	{
		DBBannerClass objdb = new DBBannerClass();
		return objdb.fn_deleteBanner(iID);
	}

	public CoreWebList<BannerClass> fn_getBannerList()
	{
		DBBannerClass objdb = new DBBannerClass();
		return objdb.fn_getBannerList();
	}

	public CoreWebList<BannerClass> fn_getBannerByID()
	{
		DBBannerClass objdb = new DBBannerClass();
		return objdb.fn_getBannerByID(iID);
	}

	public CoreWebList<BannerClass> fn_getBannerByName()
	{
		DBBannerClass objdb = new DBBannerClass();
		return objdb.fn_getBannerByName(strTitle);
	}

    public CoreWebList<BannerClass> fn_getBannerByTargetUrl()
    {
        DBBannerClass objdb = new DBBannerClass();
        return objdb.fn_getBannerByTargetUrl(strTargetUrl);
    }

	public CoreWebList<BannerClass> fn_getBannerByKeys()
	{
		DBBannerClass objdb = new DBBannerClass();
		return objdb.fn_getBannerByKeys(strTitle);
	}

}
