using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using yo_lib;

/// <summary>
/// Summary description for UniversityTypeClass
/// </summary>
public class UniversityTypeClass
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

    private string _strTypeTitle = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strTypeTitle
    {
        get
        {
            return _strTypeTitle;
        }
        set
        {
            _strTypeTitle = value;
        }
    }


    private string _strTypeDesc = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strTypeDesc
    {
        get
        {
            return _strTypeDesc;
        }
        set
        {
            _strTypeDesc = value;
        }
    }

    public string fn_saveType()
    {
        DBUniversityTypeClass objdb = new DBUniversityTypeClass();
        return objdb.fn_saveType(strTypeTitle, strTypeDesc);
    }

    public string fn_editType()
    {
        DBUniversityTypeClass objdb = new DBUniversityTypeClass();
        return objdb.fn_editType(iID, strTypeTitle, strTypeDesc);
    }

    public string fn_deleteType()
    {
        DBUniversityTypeClass objdb = new DBUniversityTypeClass();
        return objdb.fn_deleteType(iID);
    }

    public CoreWebList<UniversityTypeClass> fn_getTypeByID()
    {
        DBUniversityTypeClass objdb = new DBUniversityTypeClass();
        return objdb.fn_getTypeByID(iID);
    }

    public CoreWebList<UniversityTypeClass> fn_getTypeList()
    {
        DBUniversityTypeClass objdb = new DBUniversityTypeClass();
        return objdb.fn_getTypeList();
    }
}
