using System;
using System.Collections.Generic;
using System.Web;
using yo_lib;

/// <summary>
/// Summary description for PaperGeneratorClass
/// </summary>

public class PaperGeneratorClass
{
    #region "Properties"

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


    private string _strFileName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strFileName
    {
        get
        {
            return _strFileName;
        }
        set
        {
            _strFileName = value;
        }
    }

    private string _strPageTitle = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strPageTitle 
    {
        get
        {
            return _strPageTitle;
        }
        set
        {
            _strPageTitle = value;
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

    private string _strIdentities = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strIdentities
    {
        get
        {
            return _strIdentities;
        }
        set
        {
            _strIdentities = value;
        }
    }


    private string _strH1 = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strH1
    {
        get
        {
            return _strH1;
        }
        set
        {
            _strH1 = value;
        }
    }

    private string _strH2 = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strH2
    {
        get
        {
            return _strH2;
        }
        set
        {
            _strH2 = value;
        }
    }


    private string _strH3 = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strH3
    {
        get
        {
            return _strH3;
        }
        set
        {
            _strH3 = value;
        }
    }
    
    private string _strH4 = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strH4
    {
        get
        {
            return _strH4;
        }
        set
        {
            _strH4 = value;
        }
    }


    private string _strMetaTitle = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strMetaTitle
    {
        get
        {
            return _strMetaTitle;
        }
        set
        {
            _strMetaTitle = value;
        }
    }

    private string _strMetaDescription = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strMetaDescription
    {
        get
        {
            return _strMetaDescription;
        }
        set
        {
            _strMetaDescription = value;
        }
    }


    private string _strKeywords = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strKeywords
    {
        get
        {
            return _strKeywords;
        }
        set
        {
            _strKeywords = value;
        }
    }

    private bool _bPaper = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bPaper
    {
        get
        {
            return _bPaper;
        }
        set
        {
            _bPaper = value;
        }
    }


    private bool _bQuestion = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bQuestion
    {
        get
        {
            return _bQuestion;
        }
        set
        {
            _bQuestion = value;
        }
    }


    private bool _bHome = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bHome
    {
        get
        {
            return _bHome;
        }
        set
        {
            _bHome = value;
        }
    }


    #endregion

    #region "functions"

    public string fn_SavePaperGenerator()
    {
        DBPaperGeneratorClass objdb = new DBPaperGeneratorClass();
        return objdb.fn_SavePaperGenerator(strFileName, strPageTitle, strType, strIdentities, strH1, strH2, strH3, strH4, strMetaTitle, strMetaDescription, strKeywords, strCompany, bPaper, bQuestion,strCategory);
    }

    public string fn_EditPaper()
    {
        var objdb = new DBPaperGeneratorClass();
        return objdb.fn_EditPaper(iID, strFileName, strPageTitle, strType, strIdentities, strH1, strH2, strH3, strH4, strMetaTitle, strMetaDescription, strKeywords, strCompany, strCategory, bPaper, bQuestion);
    }

    public string fn_ChangePaperStatus()
    {
        DBPaperGeneratorClass objdb = new DBPaperGeneratorClass();
        return objdb.fn_ChangePaperStatus(iID, bHome);
    }

    public CoreWebList<PaperGeneratorClass> fn_GetPaperById()
    {
        DBPaperGeneratorClass objdb = new DBPaperGeneratorClass();
        return objdb.fn_GetPaperById(iID);
    }

    public CoreWebList<PaperGeneratorClass> fn_GetPaperByFileName()
    {
        DBPaperGeneratorClass objdb = new DBPaperGeneratorClass();
        return objdb.fn_GetPaperByFileName(strFileName);
    }

    public string fn_DeletePaper()
    {
        DBPaperGeneratorClass objdb = new DBPaperGeneratorClass();
        return objdb.fn_DeletePaper(iID);
    }

    public CoreWebList<PaperGeneratorClass> fn_Get_PaperList()
    {
        DBPaperGeneratorClass objdb = new DBPaperGeneratorClass();
        return objdb.fn_GetPaperList();
    }

    public CoreWebList<PaperGeneratorClass> fn_GetPaperListByPageTitle()
    {
        DBPaperGeneratorClass objdb = new DBPaperGeneratorClass();
        return objdb.fn_GetPaperListByPageTitle(strPageTitle);
    }

    public CoreWebList<PaperGeneratorClass> fn_Get_Placement_Paper_List()
    {
        DBPaperGeneratorClass objdb = new DBPaperGeneratorClass();
        return objdb.fn_Get_Placement_Paper_List();
    }

    public CoreWebList<PaperGeneratorClass> fn_GetRandomPapersByRowCount(int RowCount)
    {
        DBPaperGeneratorClass objdb = new DBPaperGeneratorClass();
        return objdb.fn_GetRandomPapersByRowCount(RowCount);
    }

    public CoreWebList<PaperGeneratorClass> fn_GetPaperByQuery(string strQuery)
    {
        DBPaperGeneratorClass objdb = new DBPaperGeneratorClass();
        return objdb.fn_GetPaperByQuery(strQuery);
    }

    public CoreWebList<PaperGeneratorClass> fn_GetPaperListByFileName()
    {
        DBPaperGeneratorClass objdb = new DBPaperGeneratorClass();
        return objdb.fn_GetPaperListByFileName(strFileName);
    }

    public CoreWebList<PaperGeneratorClass> fn_GetRandomPapersByCategory()
    {
        DBPaperGeneratorClass objdb = new DBPaperGeneratorClass();
        return objdb.fn_GetRandomPapersByCategoryID(strCategory);
    }

    #endregion

}
