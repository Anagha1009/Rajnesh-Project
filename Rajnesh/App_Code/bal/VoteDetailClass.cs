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
/// Summary description for VoteDetailClass
/// </summary>

public class VoteDetailClass
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

	private int _iVoteID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iVoteID
	{
		get
		{
			return _iVoteID;
		}
		set
		{
			_iVoteID = value;
		}
	}

    private string _strVoteTitle = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strVoteTitle
    {
        get
        {
            return _strVoteTitle;
        }
        set
        {
            _strVoteTitle = value;
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

    private float _fPercentage = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public float fPercentage
    {
        get
        {
            return _fPercentage;
        }
        set
        {
            _fPercentage = value;
        }
    }

	public string fn_saveVoteDetail()
	{
		DBVoteDetailClass objdb = new DBVoteDetailClass();
		return objdb.fn_saveVoteDetail(this);
	}

	public string fn_editVoteDetail()
	{
		DBVoteDetailClass objdb = new DBVoteDetailClass();
		return objdb.fn_editVoteDetail(this);
	}

    public string fn_AddVotes()
    {
        DBVoteDetailClass objdb = new DBVoteDetailClass();
        return objdb.fn_AddVotes(iID);
    }

	public string fn_deleteVoteDetail()
	{
		DBVoteDetailClass objdb = new DBVoteDetailClass();
		return objdb.fn_deleteVoteDetail(iID);
	}

	public CoreWebList<VoteDetailClass> fn_getVoteDetailList()
	{
		DBVoteDetailClass objdb = new DBVoteDetailClass();
		return objdb.fn_getVoteDetailList();
	}

	public CoreWebList<VoteDetailClass> fn_getVoteDetailByID()
	{
		DBVoteDetailClass objdb = new DBVoteDetailClass();
		return objdb.fn_getVoteDetailByID(iID);
	}

	public CoreWebList<VoteDetailClass> fn_getVoteDetailByName()
	{
		DBVoteDetailClass objdb = new DBVoteDetailClass();
		return objdb.fn_getVoteDetailByName(strTitle);
	}

	public CoreWebList<VoteDetailClass> fn_getVoteDetailByKeys()
	{
		DBVoteDetailClass objdb = new DBVoteDetailClass();
		return objdb.fn_getVoteDetailByKeys(strTitle);
	}

	public CoreWebList<VoteDetailClass> fn_getVoteDetailByVoteID()
	{
		DBVoteDetailClass objdb = new DBVoteDetailClass();
		return objdb.fn_getVoteDetailByVoteID(iVoteID);
	}

    public CoreWebList<VoteDetailClass> fn_getVoteDetailByUrl()
    {
        DBVoteDetailClass objdb = new DBVoteDetailClass();
        return objdb.fn_getVoteDetailByUrl(strUrl);
    }

    public CoreWebList<VoteDetailClass> fn_getVotePercentage()
    {
        DBVoteDetailClass objdb = new DBVoteDetailClass();
        return objdb.fn_getVotePercentage(iVoteID);
    }

    public CoreWebList<VoteDetailClass> fn_getRandomVotes()
    {
        DBVoteDetailClass objdb = new DBVoteDetailClass();
        return objdb.fn_getRandomVotes();
    }

}
