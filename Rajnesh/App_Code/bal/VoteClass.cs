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
/// Summary description for VoteClass
/// </summary>

public class VoteClass
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

    private int _iVoteCounts = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iVoteCounts
    {
        get
        {
            return _iVoteCounts;
        }
        set
        {
            _iVoteCounts = value;
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

    private string _strIcon = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strIcon
    {
        get
        {
            return _strIcon;
        }
        set
        {
            _strIcon = value;
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

	public string fn_saveVote()
	{
		DBVoteClass objdb = new DBVoteClass();
		return objdb.fn_saveVote(this);
	}

	public string fn_editVote()
	{
		DBVoteClass objdb = new DBVoteClass();
		return objdb.fn_editVote(this);
	}

	public string fn_deleteVote()
	{
		DBVoteClass objdb = new DBVoteClass();
		return objdb.fn_deleteVote(iID);
	}

	public CoreWebList<VoteClass> fn_getVoteList()
	{
		DBVoteClass objdb = new DBVoteClass();
		return objdb.fn_getVoteList();
	}

    public CoreWebList<VoteClass> fn_getTopEntry(int CurrentId)
    {
        DBVoteClass objdb = new DBVoteClass();
        return objdb.fn_getTopEntry(CurrentId);
    }

	public CoreWebList<VoteClass> fn_getVoteByID()
	{
		DBVoteClass objdb = new DBVoteClass();
		return objdb.fn_getVoteByID(iID);
	}

	public CoreWebList<VoteClass> fn_getVoteByName()
	{
		DBVoteClass objdb = new DBVoteClass();
		return objdb.fn_getVoteByName(strTitle);
	}

	public CoreWebList<VoteClass> fn_getVoteByKeys()
	{
		DBVoteClass objdb = new DBVoteClass();
		return objdb.fn_getVoteByKeys(strTitle);
	}

	public string fn_ChangeVoteActiveStatus()
	{
		DBVoteClass objdb = new DBVoteClass();
		return objdb.fn_ChangeVoteActiveStatus(this);
	}

}
