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
/// Summary description for TeamMemberClass
/// </summary>

public class TeamMemberClass
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

	private string _strDesignation = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strDesignation
	{
		get
		{
			return _strDesignation;
		}
		set
		{
			_strDesignation = value;
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

	private string _strFacebook = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strFacebook
	{
		get
		{
			return _strFacebook;
		}
		set
		{
			_strFacebook = value;
		}
	}

	private string _strTwitter = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strTwitter
	{
		get
		{
			return _strTwitter;
		}
		set
		{
			_strTwitter = value;
		}
	}

	private string _strLinkedIn = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strLinkedIn
	{
		get
		{
			return _strLinkedIn;
		}
		set
		{
			_strLinkedIn = value;
		}
	}

	private string _strGooglePlus = "";
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public string strGooglePlus
	{
		get
		{
			return _strGooglePlus;
		}
		set
		{
			_strGooglePlus = value;
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

	public string fn_saveTeamMember()
	{
		DBTeamMemberClass objdb = new DBTeamMemberClass();
		return objdb.fn_saveTeamMember(this);
	}

	public string fn_editTeamMember()
	{
		DBTeamMemberClass objdb = new DBTeamMemberClass();
		return objdb.fn_editTeamMember(this);
	}

	public string fn_deleteTeamMember()
	{
		DBTeamMemberClass objdb = new DBTeamMemberClass();
		return objdb.fn_deleteTeamMember(iID);
	}

	public CoreWebList<TeamMemberClass> fn_getTeamMemberList()
	{
		DBTeamMemberClass objdb = new DBTeamMemberClass();
		return objdb.fn_getTeamMemberList();
	}

	public CoreWebList<TeamMemberClass> fn_getTeamMemberByID()
	{
		DBTeamMemberClass objdb = new DBTeamMemberClass();
		return objdb.fn_getTeamMemberByID(iID);
	}

	public CoreWebList<TeamMemberClass> fn_getTeamMemberByName()
	{
		DBTeamMemberClass objdb = new DBTeamMemberClass();
		return objdb.fn_getTeamMemberByName(strName);
	}

	public CoreWebList<TeamMemberClass> fn_getTeamMemberByKeys()
	{
		DBTeamMemberClass objdb = new DBTeamMemberClass();
		return objdb.fn_getTeamMemberByKeys(strName);
	}

}
