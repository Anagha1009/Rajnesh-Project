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
/// Summary description for ArticleClass
/// </summary>

public class ArticleClass
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

	private int _iCountryID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iCountryID
	{
		get
		{
			return _iCountryID;
		}
		set
		{
			_iCountryID = value;
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

	public string fn_saveArticle()
	{
		DBArticleClass objdb = new DBArticleClass();
		return objdb.fn_saveArticle(this);
	}

	public string fn_editArticle()
	{
		DBArticleClass objdb = new DBArticleClass();
		return objdb.fn_editArticle(this);
	}

	public string fn_deleteArticle()
	{
		DBArticleClass objdb = new DBArticleClass();
		return objdb.fn_deleteArticle(iID);
	}

	public CoreWebList<ArticleClass> fn_getArticleList()
	{
		DBArticleClass objdb = new DBArticleClass();
		return objdb.fn_getArticleList();
	}

	public CoreWebList<ArticleClass> fn_getArticleByID()
	{
		DBArticleClass objdb = new DBArticleClass();
		return objdb.fn_getArticleByID(iID);
	}

	public CoreWebList<ArticleClass> fn_getArticleByName()
	{
		DBArticleClass objdb = new DBArticleClass();
		return objdb.fn_getArticleByName(strTitle);
	}

	public CoreWebList<ArticleClass> fn_getArticleByKeys()
	{
		DBArticleClass objdb = new DBArticleClass();
		return objdb.fn_getArticleByKeys(strTitle);
	}

	public CoreWebList<ArticleClass> fn_getArticleByCountryID()
	{
		DBArticleClass objdb = new DBArticleClass();
		return objdb.fn_getArticleByCountryID(iCountryID);
	}

}
