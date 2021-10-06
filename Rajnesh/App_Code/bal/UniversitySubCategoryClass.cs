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
/// Summary description for UniversitySubCategoryClass
/// </summary>
public class UniversitySubCategoryClass
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

    private int _iCatID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCatID
    {
        get
        {
            return _iCatID;
        }
        set
        {
            _iCatID = value;
        }
    }

    private string _strSubCategoryTitle = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strSubCategoryTitle
    {
        get
        {
            return _strSubCategoryTitle;
        }
        set
        {
            _strSubCategoryTitle = value;
        }
    }


    private string _strSubCategoryDesc = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strSubCategoryDesc
    {
        get
        {
            return _strSubCategoryDesc;
        }
        set
        {
            _strSubCategoryDesc = value;
        }
    }

    public string fn_saveSubCategory()
    {
        DBUniversitySubCategoryClass objdb = new DBUniversitySubCategoryClass();
        return objdb.fn_saveSubCategory(iCatID, strSubCategoryTitle, strSubCategoryDesc);
    }

    public string fn_editSubCategory()
    {
        DBUniversitySubCategoryClass objdb = new DBUniversitySubCategoryClass();
        return objdb.fn_editSubCategory(iID, iCatID, strSubCategoryTitle, strSubCategoryDesc);
    }

    public string fn_deleteSubCategory()
    {
        DBUniversitySubCategoryClass objdb = new DBUniversitySubCategoryClass();
        return objdb.fn_deleteSubCategory(iID);
    }

    public CoreWebList<UniversitySubCategoryClass> fn_getSubCategoryByID()
    {
        DBUniversitySubCategoryClass objdb = new DBUniversitySubCategoryClass();
        return objdb.fn_getSubCategoryByID(iID);
    }

    public CoreWebList<UniversitySubCategoryClass> fn_getSubCategoryByCatID()
    {
        DBUniversitySubCategoryClass objdb = new DBUniversitySubCategoryClass();
        return objdb.fn_getSubCategoryByCatID(iCatID);
    }

    public CoreWebList<UniversitySubCategoryClass> fn_getSubCategoryList()
    {
        DBUniversitySubCategoryClass objdb = new DBUniversitySubCategoryClass();
        return objdb.fn_getSubCategoryList();
    }
}
