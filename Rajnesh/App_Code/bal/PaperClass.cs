using System;
using System.Collections.Generic;
using System.Web;
using yo_lib;

/// <summary>
/// Summary description for PaperClass
/// </summary>
public class PaperClass
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

    private string _strCompany = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCompany
    {
        get
        {
            return _strCompany;
        }
        set
        {
            _strCompany = value;
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

    private DateTime _dtDate = System.DateTime.Now;
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

    private string _strCategory = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCategory
    {
        get
        {
            return _strCategory;
        }
        set
        {
            _strCategory = value;
        }
    }


    public string fn_SavePaper()
    {
        DBPaperClass objdb = new DBPaperClass();
        return objdb.fn_SavePaper(strTitle, strCompany, strDescription, strCategory);
    }

    public string fn_EditPaper()
    {
        var objdb = new DBPaperClass();
        return objdb.fn_EditPaper(iID, strTitle, strCompany, strDescription, strCategory);
    }

    public string fn_Deletepaper()
    {
        DBPaperClass objdb = new DBPaperClass();
        return objdb.fn_Deletepaper(iID);
    }

    public CoreWebList<PaperClass> fn_GetPaperByID()
    {
        DBPaperClass objdb = new DBPaperClass();
        return objdb.fn_GetPaperByID(iID);
    }

    public CoreWebList<PaperClass> fn_GetPaperList()
    {
        DBPaperClass objdb = new DBPaperClass();
        return objdb.fn_GetPaperList();
    }

    public CoreWebList<PaperClass> fn_GetPaperListByPageTitle()
    {
        DBPaperClass objdb = new DBPaperClass();
        return objdb.fn_GetPaperListByPageTitle(strTitle);
    }

    public CoreWebList<PaperClass> fn_GetPaperByQuery(string strQuery)
    {
        DBPaperClass objdb = new DBPaperClass();
        return objdb.fn_GetPaperByQuery(strQuery);
    }
}
