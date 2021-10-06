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
/// Summary description for CommentReplyClass
/// </summary>

public class CommentReplyClass
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

	private int _iCommentID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iCommentID
	{
		get
		{
			return _iCommentID;
		}
		set
		{
			_iCommentID = value;
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

	private string _strReply = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strReply
	{
		get
		{
			return _strReply;
		}
		set
		{
			_strReply = value;
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

	public string fn_saveCommentReply()
	{
		DBCommentReplyClass objdb = new DBCommentReplyClass();
		return objdb.fn_saveCommentReply(this);
	}

	public string fn_editCommentReply()
	{
		DBCommentReplyClass objdb = new DBCommentReplyClass();
		return objdb.fn_editCommentReply(this);
	}

	public string fn_deleteCommentReply()
	{
		DBCommentReplyClass objdb = new DBCommentReplyClass();
		return objdb.fn_deleteCommentReply(iID);
	}

	public CoreWebList<CommentReplyClass> fn_getCommentReplyList()
	{
		DBCommentReplyClass objdb = new DBCommentReplyClass();
		return objdb.fn_getCommentReplyList();
	}

	public CoreWebList<CommentReplyClass> fn_getCommentReplyByID()
	{
		DBCommentReplyClass objdb = new DBCommentReplyClass();
		return objdb.fn_getCommentReplyByID(iID);
	}

	public CoreWebList<CommentReplyClass> fn_getCommentReplyByName()
	{
		DBCommentReplyClass objdb = new DBCommentReplyClass();
		return objdb.fn_getCommentReplyByName(strName);
	}

	public CoreWebList<CommentReplyClass> fn_getCommentReplyByKeys()
	{
		DBCommentReplyClass objdb = new DBCommentReplyClass();
		return objdb.fn_getCommentReplyByKeys(strName);
	}

	public CoreWebList<CommentReplyClass> fn_getCommentReplyByCommentID()
	{
		DBCommentReplyClass objdb = new DBCommentReplyClass();
		return objdb.fn_getCommentReplyByCommentID(iCommentID);
	}

    public CoreWebList<CommentReplyClass> fn_getTopCommentReplyByCommentID()
    {
        DBCommentReplyClass objdb = new DBCommentReplyClass();
        return objdb.fn_getTopCommentReplyByCommentID(iCommentID);
    }

	public string fn_ChangeCommentReplyActiveStatus()
	{
		DBCommentReplyClass objdb = new DBCommentReplyClass();
		return objdb.fn_ChangeCommentReplyActiveStatus(this);
	}

}
