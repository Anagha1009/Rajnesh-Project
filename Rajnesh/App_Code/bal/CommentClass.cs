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
/// Summary description for CommentClass
/// </summary>

public class CommentClass
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

    private string _strType = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strType
    {
        get
        {
            return _strType;
        }
        set
        {
            _strType = value;
        }
    }

	private string _strName = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strName
	{
		get
		{
			return _strName;
		}
		set
		{
			_strName = value;
		}
	}

	private string _strEmail = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strEmail
	{
		get
		{
			return _strEmail;
		}
		set
		{
			_strEmail = value;
		}
	}

	private string _strPhone = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strPhone
	{
		get
		{
			return _strPhone;
		}
		set
		{
			_strPhone = value;
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

	private int _iRate = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iRate
	{
		get
		{
			return _iRate;
		}
		set
		{
			_iRate = value;
		}
	}

    private string _strIpAddrs = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strIpAddrs
    {
        get
        {
            return _strIpAddrs;
        }
        set
        {
            _strIpAddrs = value;
        }
    }

    private bool _bActive = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bActive
    {
        get
        {
            return _bActive;
        }
        set
        {
            _bActive = value;
        }
    }

    private bool _bAbuse = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bAbuse
    {
        get
        {
            return _bAbuse;
        }
        set
        {
            _bAbuse = value;
        }
    }

	private DateTime _dtDate = DateTime.Now;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public DateTime dtDate
	{
		get
		{
			return _dtDate;
		}
		set
		{
			_dtDate = value;
		}
	}

	public string fn_saveComment()
	{
		DBCommentClass objdb = new DBCommentClass();
		return objdb.fn_saveComment(this);
	}

	public string fn_editComment()
	{
		DBCommentClass objdb = new DBCommentClass();
		return objdb.fn_editComment(this);
	}

	public string fn_deleteComment()
	{
		DBCommentClass objdb = new DBCommentClass();
		return objdb.fn_deleteComment(iID);
	}

	public CoreWebList<CommentClass> fn_getCommentList()
	{
		DBCommentClass objdb = new DBCommentClass();
		return objdb.fn_getCommentList();
	}

    public CoreWebList<CommentClass> fn_getReportedCommentList()
    {
        DBCommentClass objdb = new DBCommentClass();
        return objdb.fn_getReportedCommentList();
    }

	public CoreWebList<CommentClass> fn_getCommentByID()
	{
		DBCommentClass objdb = new DBCommentClass();
		return objdb.fn_getCommentByID(iID);
	}

    public CoreWebList<CommentClass> fn_getCommentByUrl()
    {
        DBCommentClass objdb = new DBCommentClass();
        return objdb.fn_getCommentByUrl(strType, strUrl);
    }

    public CoreWebList<CommentClass> fn_getSearchComment()
    {
        DBCommentClass objdb = new DBCommentClass();
        return objdb.fn_getSearchComment(strTitle);
    }

    public CoreWebList<CommentClass> fn_getSearchAbusedComment()
    {
        DBCommentClass objdb = new DBCommentClass();
        return objdb.fn_getSearchAbusedComment(strTitle);
    }

	public string fn_ChangeCommentActiveStatus()
	{
		DBCommentClass objdb = new DBCommentClass();
		return objdb.fn_ChangeCommentActiveStatus(this);
	}

    public string fn_ChangeCommentAbuseStatus()
    {
        DBCommentClass objdb = new DBCommentClass();
        return objdb.fn_ChangeCommentAbuseStatus(this);
    }

}
