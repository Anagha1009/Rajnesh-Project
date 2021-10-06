using System;
using System.Collections.Generic;
using System.Web;
using yo_lib;

/// <summary>
/// Summary description for DownloadsClass
/// </summary>
public class DownloadsClass
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

    private int _iTypeID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iTypeID
    {
        get
        {
            return _iTypeID;
        }
        set
        {
            _iTypeID = value;
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

    public string fn_saveFile()
    {        
        DBDownloadsClass objdb = new DBDownloadsClass();
        return objdb.fn_saveFile(strTitle, iTypeID, strType, strFileName);
    }

    public string fn_deleteFile()
    {
        DBDownloadsClass objdb = new DBDownloadsClass();
        return objdb.fn_deleteFile(iID);
    }

    public CoreWebList<DownloadsClass> fn_getFileByID()
    {
        DBDownloadsClass objdb = new DBDownloadsClass();
        return objdb.fn_getFileByID(iID);
    }

    public CoreWebList<DownloadsClass> fn_getFileList()
    {
        DBDownloadsClass objdb = new DBDownloadsClass();
        return objdb.fn_getFileList();
    }

    public CoreWebList<DownloadsClass> fn_getFileByType()
    {
        DBDownloadsClass objdb = new DBDownloadsClass();
        return objdb.fn_getFileByType(strType);
    }

    public CoreWebList<DownloadsClass> fn_getFileByTypeAndTypeID()
    {
        DBDownloadsClass objdb = new DBDownloadsClass();
        return objdb.fn_getFileByTypeAndTypeID(strType, iTypeID);
    }

	public DownloadsClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
