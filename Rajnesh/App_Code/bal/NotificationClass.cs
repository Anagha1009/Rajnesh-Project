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
/// Summary description for NotificationClass
/// </summary>

public class NotificationClass
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

    private string _strUniversityName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strUniversityName
    {
        get
        {
            return _strUniversityName;
        }
        set
        {
            _strUniversityName = value;
        }
    }

	private string _strNotificationTitle = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strNotificationTitle
	{
		get
		{
			return _strNotificationTitle;
		}
		set
		{
			_strNotificationTitle = value;
		}
	}

	private string _strNotificationDesc = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strNotificationDesc
	{
		get
		{
			return _strNotificationDesc;
		}
		set
		{
			_strNotificationDesc = value;
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
		DBNotificationClass objdb = new DBNotificationClass();
		return objdb.fn_saveNotification(this);
	}

	public string fn_editNotification()
	{
		DBNotificationClass objdb = new DBNotificationClass();
		return objdb.fn_editNotification(this);
	}

	public string fn_deleteNotification()
	{
		DBNotificationClass objdb = new DBNotificationClass();
		return objdb.fn_deleteNotification(iID);
	}

	public CoreWebList<NotificationClass> fn_getNotificationList()
	{
		DBNotificationClass objdb = new DBNotificationClass();
		return objdb.fn_getNotificationList();
	}

	public CoreWebList<NotificationClass> fn_getNotificationByID()
	{
		DBNotificationClass objdb = new DBNotificationClass();
		return objdb.fn_getNotificationByID(iID);
	}

    public CoreWebList<NotificationClass> fn_getNotificationByName()
    {
        DBNotificationClass objdb = new DBNotificationClass();
        return objdb.fn_getNotificationByName(strNotificationTitle);
    }

    public CoreWebList<NotificationClass> fn_getNotificationByUniversityID()
    {
        DBNotificationClass objdb = new DBNotificationClass();
        return objdb.fn_getNotificationByUniversityID(iUniversityID);
    }

    public CoreWebList<NotificationClass> fn_getNotificationByKeys(string strKeys)
    {
        DBNotificationClass objdb = new DBNotificationClass();
        return objdb.fn_getNotificationByKeys(strKeys);
    }

}
