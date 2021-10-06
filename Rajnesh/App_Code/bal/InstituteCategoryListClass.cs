using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using yo_lib;

/// <summary>
/// Summary description for InstituteCategoryListClass
/// </summary>
public class InstituteCategoryListClass
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

    private int _iInstID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iInstID 
    {
        get
        {
            return _iInstID;
        }
        set
        {
            _iInstID = value;
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

    private int _iSubCatID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iSubCatID
    {
        get
        {
            return _iSubCatID;
        }
        set
        {
            _iSubCatID = value;
        }
    }

    private int[] _iCatIDArray = new int[1];

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int[] iCatIDArray 
    {
        get
        {
            return _iCatIDArray;
        }
        set
        {
            _iCatIDArray = value;
        }
    }

    public string fn_saveInstCategoryList()
    {
        DBInstituteCategoryListClass objdb = new DBInstituteCategoryListClass();
        return objdb.fn_saveInstCategoryList(iCatIDArray, iInstID);
    }

    public string fn_editInstCategoryList()
    {
        DBInstituteCategoryListClass objdb = new DBInstituteCategoryListClass();
        return objdb.fn_editInstCategoryList(iID, iCatIDArray, iInstID, iSubCatID);
    }

    public string fn_deleteInstCategoryList()
    {
        DBInstituteCategoryListClass objdb = new DBInstituteCategoryListClass();
        return objdb.fn_deleteInstCategoryList(iID);
    }

    public CoreWebList<InstituteCategoryListClass> fn_getInstCategoryListByID()
    {
        DBInstituteCategoryListClass objdb = new DBInstituteCategoryListClass();
        return objdb.fn_getInstCategoryListByID(iID);
    }

    public CoreWebList<InstituteCategoryListClass> fn_getInstCategoryList()
    {
        DBInstituteCategoryListClass objdb = new DBInstituteCategoryListClass();
        return objdb.fn_getInstCategoryList();
    }

    public ArrayList fn_getInstCategoryListBy_InstID()
    {
        DBInstituteCategoryListClass objdb = new DBInstituteCategoryListClass();
        return objdb.fn_getInstCategoryListBy_InstID(iInstID);
    }

    public ArrayList fn_getInstCategoryArrayListBy_InstID()
    {
        DBInstituteCategoryListClass objdb = new DBInstituteCategoryListClass();
        return objdb.fn_getInstCategoryArrayListBy_InstID(iInstID);
    }

    public CoreWebList<InstituteCategoryListClass> fn_getInstCategoryListByInstID()
    {
        DBInstituteCategoryListClass objdb = new DBInstituteCategoryListClass();
        return objdb.fn_getInstCategoryListByInstID(iInstID);
    }

    public CoreWebList<InstituteCategoryListClass> fn_getRandomInstCategoryListByInstID()
    {
        DBInstituteCategoryListClass objdb = new DBInstituteCategoryListClass();
        return objdb.fn_getRandomInstCategoryListByInstID(iInstID);
    }
}
