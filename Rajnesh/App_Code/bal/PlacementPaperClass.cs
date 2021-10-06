using System;
using System.Collections.Generic;
using System.Web;
using yo_lib;

/// <summary>
/// Summary description for PlacementPaperClass
/// </summary>
public class PlacementPaperClass
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

    private string _strCompanyName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCompanyName
    {
        get
        {
            return _strCompanyName;
        }
        set
        {
            _strCompanyName = value;
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

    private string _strSubmittedBy = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strSubmittedBy
    {
        get
        {
            return _strSubmittedBy;
        }
        set
        {
            _strSubmittedBy = value;
        }
    }

    private string _strSubmittedByEmail = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strSubmittedByEmail
    {
        get
        {
            return _strSubmittedByEmail;
        }
        set
        {
            _strSubmittedByEmail = value;
        }
    }


    private DateTime _dtSubmittedDate = System.DateTime.Now;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public DateTime dtSubmittedDate
    {
        get
        {
            return _dtSubmittedDate;
        }
        set
        {
            _dtSubmittedDate = value;
        }
    }

    public string fn_SavePaper()
    {
        DBPlacementPaperClass objdb = new DBPlacementPaperClass();
        return objdb.fn_SavePaper(strCompanyName, strDescription, strSubmittedBy, strSubmittedByEmail);
    }

    public string fn_EditPaper()
    {
        DBPlacementPaperClass objdb = new DBPlacementPaperClass();
        return objdb.fn_EditPaper(iID, strCompanyName, strDescription);
    }

    public string fn_Deletepaper()
    {
        DBPlacementPaperClass objdb = new DBPlacementPaperClass();
        return objdb.fn_Deletepaper(iID);
    }

    public CoreWebList<PlacementPaperClass> fn_GetPaperByID()
    {
        DBPlacementPaperClass objdb = new DBPlacementPaperClass();
        return objdb.fn_GetPaperByID(iID);
    }

    public CoreWebList<PlacementPaperClass> fn_GetPaperList()
    {
        DBPlacementPaperClass objdb = new DBPlacementPaperClass();
        return objdb.fn_GetPaperList();
    }
}
