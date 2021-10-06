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
/// Summary description for CompetitionEntryClass
/// </summary>

public class CompetitionEntryClass
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

    private int _iCompetitionID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCompetitionID
    {
        get
        {
            return _iCompetitionID;
        }
        set
        {
            _iCompetitionID = value;
        }
    }

	private int _iUserID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iUserID
	{
		get
		{
			return _iUserID;
		}
		set
		{
			_iUserID = value;
		}
	}

	private int _iOptionID = 0;
	[Conversion(DataTableConversion = true, AllowDbNull = false)]
	public int iOptionID
	{
		get
		{
			return _iOptionID;
		}
		set
		{
			_iOptionID = value;
		}
	}

	public string fn_saveCompetitionEntry()
	{
		DBCompetitionEntryClass objdb = new DBCompetitionEntryClass();
		return objdb.fn_saveCompetitionEntry(this);
	}

	public string fn_editCompetitionEntry()
	{
		DBCompetitionEntryClass objdb = new DBCompetitionEntryClass();
		return objdb.fn_editCompetitionEntry(this);
	}

	public string fn_deleteCompetitionEntry()
	{
		DBCompetitionEntryClass objdb = new DBCompetitionEntryClass();
		return objdb.fn_deleteCompetitionEntry(iID);
	}

	public string fn_deleteCompetitionEntryByUserID()
	{
		DBCompetitionEntryClass objdb = new DBCompetitionEntryClass();
		return objdb.fn_deleteCompetitionEntryByUserID(iUserID);
	}

	public CoreWebList<CompetitionEntryClass> fn_getCompetitionEntryList()
	{
		DBCompetitionEntryClass objdb = new DBCompetitionEntryClass();
		return objdb.fn_getCompetitionEntryList();
	}

	public CoreWebList<CompetitionEntryClass> fn_getCompetitionEntryByID()
	{
		DBCompetitionEntryClass objdb = new DBCompetitionEntryClass();
		return objdb.fn_getCompetitionEntryByID(iID);
	}

	public CoreWebList<CompetitionEntryClass> fn_getCompetitionEntryByOptionID()
	{
		DBCompetitionEntryClass objdb = new DBCompetitionEntryClass();
		return objdb.fn_getCompetitionEntryByOptionID(iOptionID);
	}

	public CoreWebList<CompetitionEntryClass> fn_getCompetitionEntryByUserID()
	{
		DBCompetitionEntryClass objdb = new DBCompetitionEntryClass();
		return objdb.fn_getCompetitionEntryByUserID(iUserID);
	}

    public CoreWebList<CompetitionEntryClass> fn_getCheckCompetitionEntryByUserID()
    {
        DBCompetitionEntryClass objdb = new DBCompetitionEntryClass();
        return objdb.fn_getCheckCompetitionEntryByUserID(iCompetitionID, iUserID);
    }

}
