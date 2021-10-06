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
/// Summary description for BannerDetailClass
/// </summary>

public class BannerDetailClass
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

	private int _iBannerID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iBannerID
	{
		get
		{
			return _iBannerID;
		}
		set
		{
			_iBannerID = value;
		}
	}

	private int _iOrder = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iOrder
	{
		get
		{
			return _iOrder;
		}
		set
		{
			_iOrder = value;
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

	private string _strLink = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strLink
	{
		get
		{
			return _strLink;
		}
		set
		{
			_strLink = value;
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

	public string fn_saveBannerDetail()
	{
		DBBannerDetailClass objdb = new DBBannerDetailClass();
		return objdb.fn_saveBannerDetail(this);
	}

	public string fn_editBannerDetail()
	{
		DBBannerDetailClass objdb = new DBBannerDetailClass();
		return objdb.fn_editBannerDetail(this);
	}

	public string fn_deleteBannerDetail()
	{
		DBBannerDetailClass objdb = new DBBannerDetailClass();
		return objdb.fn_deleteBannerDetail(iID);
	}

	public CoreWebList<BannerDetailClass> fn_getBannerDetailList()
	{
		DBBannerDetailClass objdb = new DBBannerDetailClass();
		return objdb.fn_getBannerDetailList();
	}

	public CoreWebList<BannerDetailClass> fn_getBannerDetailByID()
	{
		DBBannerDetailClass objdb = new DBBannerDetailClass();
		return objdb.fn_getBannerDetailByID(iID);
	}

	public CoreWebList<BannerDetailClass> fn_getBannerDetailByName()
	{
		DBBannerDetailClass objdb = new DBBannerDetailClass();
		return objdb.fn_getBannerDetailByName(strTitle);
	}

	public CoreWebList<BannerDetailClass> fn_getBannerDetailByKeys()
	{
		DBBannerDetailClass objdb = new DBBannerDetailClass();
		return objdb.fn_getBannerDetailByKeys(strTitle);
	}

	public CoreWebList<BannerDetailClass> fn_getBannerDetailByBannerID()
	{
		DBBannerDetailClass objdb = new DBBannerDetailClass();
		return objdb.fn_getBannerDetailByBannerID(iBannerID);
	}

}
