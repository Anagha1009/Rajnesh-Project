using yo_lib;

/// <summary>
/// Summary description for LinkClass
/// </summary>

public class LinkClass
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

	public string fn_saveLink()
	{
		DBLinkClass objdb = new DBLinkClass();
		return objdb.fn_saveLink(this);
	}

	public string fn_editLink()
	{
		DBLinkClass objdb = new DBLinkClass();
		return objdb.fn_editLink(this);
	}

	public string fn_deleteLink()
	{
		DBLinkClass objdb = new DBLinkClass();
		return objdb.fn_deleteLink(iID);
	}

	public CoreWebList<LinkClass> fn_getLinkList()
	{
		DBLinkClass objdb = new DBLinkClass();
		return objdb.fn_getLinkList();
	}

	public CoreWebList<LinkClass> fn_getLinkByID()
	{
		DBLinkClass objdb = new DBLinkClass();
		return objdb.fn_getLinkByID(iID);
	}

	public CoreWebList<LinkClass> fn_getLinkByName()
	{
		DBLinkClass objdb = new DBLinkClass();
		return objdb.fn_getLinkByName(strTitle);
	}

    public CoreWebList<LinkClass> fn_getLinkByTargetUrl()
    {
        DBLinkClass objdb = new DBLinkClass();
        return objdb.fn_getLinkByTargetUrl(strTargetUrl);
    }

	public CoreWebList<LinkClass> fn_getLinkByKeys()
	{
		DBLinkClass objdb = new DBLinkClass();
		return objdb.fn_getLinkByKeys(strTitle);
	}

}
