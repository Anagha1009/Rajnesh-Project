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
/// Summary description for UniversityCategoryClass
/// </summary>
public class UniversityCategoryClass
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

    private string _strCategoryTitle = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCategoryTitle
    {
        get
        {
            return _strCategoryTitle;
        }
        set
        {
            _strCategoryTitle = value;
        }
    }


    private string _strCategoryDesc = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCategoryDesc
    {
        get
        {
            return _strCategoryDesc;
        }
        set
        {
            _strCategoryDesc = value;
        }
    }

    public string fn_saveCategory()
    {
        DBUniversityCategoryClass objdb = new DBUniversityCategoryClass();
        return objdb.fn_saveCategory(strCategoryTitle, strCategoryDesc);
    }

    public string fn_editCategory()
    {
        DBUniversityCategoryClass objdb = new DBUniversityCategoryClass();
        return objdb.fn_editCategory(iID, strCategoryTitle, strCategoryDesc);
    }

    public string fn_deleteCategory()
    {
        DBUniversityCategoryClass objdb = new DBUniversityCategoryClass();
        return objdb.fn_deleteCategory(iID);
    }

    public CoreWebList<UniversityCategoryClass> fn_getCategoryByID()
    {
        DBUniversityCategoryClass objdb = new DBUniversityCategoryClass();
        return objdb.fn_getCategoryByID(iID);
    }

    public CoreWebList<UniversityCategoryClass> fn_getCategoryList()
    {
        DBUniversityCategoryClass objdb = new DBUniversityCategoryClass();
        return objdb.fn_getCategoryList();
    }
}
