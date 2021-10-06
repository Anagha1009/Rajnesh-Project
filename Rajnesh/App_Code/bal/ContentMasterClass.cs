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
/// Summary description for OverviewClass
/// </summary>
public class ContentMasterClass
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

    private string _strContentText = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strContentText
    {
        get
        {
            return _strContentText;
        }
        set
        {
            _strContentText = value;
        }
    }

    private string _strContentType = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strContentType
    {
        get
        {
            return _strContentType;
        }
        set
        {
            _strContentType = value;
        }
    }

    public string fn_saveContent()
    {
        DBContentMasterClass objdb = new DBContentMasterClass();
        return objdb.fn_saveContent(strContentText, strContentType);   
    }

    public string fn_editContent()
    {
        DBContentMasterClass objdb = new DBContentMasterClass();
        return objdb.fn_editContent(strContentText,strContentType); 
    }

    public CoreWebList<ContentMasterClass> fn_getContent()
    {
        DBContentMasterClass objdb = new DBContentMasterClass();
        return objdb.fn_getContent(strContentType);
    }
}
