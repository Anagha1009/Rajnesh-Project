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
/// Summary description for BlogClass
/// </summary>

public class BlogClass
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

	private string _strDescription = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strDescription
	{
		get
		{
			return _strDescription;
		}
		set
		{
			_strDescription = value;
		}
	}

	private string _strImage = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strImage
	{
		get
		{
			return _strImage;
		}
		set
		{
			_strImage = value;
		}
	}

	private DateTime _dtCreatedOn = DateTime.Now;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public DateTime dtCreatedOn
	{
		get
		{
			return _dtCreatedOn;
		}
		set
		{
			_dtCreatedOn = value;
		}
	}

	public string fn_saveBlog()
	{
		DBBlogClass objdb = new DBBlogClass();
		return objdb.fn_saveBlog(this);
	}

	public string fn_editBlog()
	{
		DBBlogClass objdb = new DBBlogClass();
		return objdb.fn_editBlog(this);
	}

	public string fn_deleteBlog()
	{
		DBBlogClass objdb = new DBBlogClass();
		return objdb.fn_deleteBlog(iID);
	}

	public CoreWebList<BlogClass> fn_getBlogList()
	{
		DBBlogClass objdb = new DBBlogClass();
		return objdb.fn_getBlogList();
	}

	public CoreWebList<BlogClass> fn_getBlogByID()
	{
		DBBlogClass objdb = new DBBlogClass();
		return objdb.fn_getBlogByID(iID);
	}

    public CoreWebList<BlogClass> fn_getBlogByTitle()
	{
		DBBlogClass objdb = new DBBlogClass();
        return objdb.fn_getBlogByTitle(strTitle);
	}

	public CoreWebList<BlogClass> fn_getBlogByKeys()
	{
		DBBlogClass objdb = new DBBlogClass();
		return objdb.fn_getBlogByKeys(strTitle);
	}

}
