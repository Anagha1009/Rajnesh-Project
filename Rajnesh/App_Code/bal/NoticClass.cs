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
/// Summary description for NoticClass
/// </summary>

public class NoticClass
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

	public string fn_saveNotification()
	{
		DBNoticClass objdb = new DBNoticClass();
		return objdb.fn_saveNotification(this);
	}

	public string fn_editNotification()
	{
		DBNoticClass objdb = new DBNoticClass();
		return objdb.fn_editNotification(this);
	}

	public string fn_deleteNotification()
	{
		DBNoticClass objdb = new DBNoticClass();
		return objdb.fn_deleteNotification(iID);
	}

	public CoreWebList<NoticClass> fn_getNotificationList()
	{
		DBNoticClass objdb = new DBNoticClass();
		return objdb.fn_getNotificationList();
	}

	public CoreWebList<NoticClass> fn_getNotificationByID()
	{
		DBNoticClass objdb = new DBNoticClass();
		return objdb.fn_getNotificationByID(iID);
	}

	public CoreWebList<NoticClass> fn_getNotificationByName()
	{
		DBNoticClass objdb = new DBNoticClass();
		return objdb.fn_getNotificationByName(strTitle);
	}

	public CoreWebList<NoticClass> fn_getNotificationByKeys()
	{
		DBNoticClass objdb = new DBNoticClass();
		return objdb.fn_getNotificationByKeys(strTitle);
	}

	public CoreWebList<NoticClass> fn_getNotificationByUniversityID()
	{
		DBNoticClass objdb = new DBNoticClass();
		return objdb.fn_getNotificationByUniversityID(iUniversityID);
	}

}
