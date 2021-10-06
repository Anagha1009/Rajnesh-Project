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
/// Summary description for InstituteCategoryClass
/// </summary>
public class InstituteCategoryClass
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

    private string _strImage = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strImage
    {
        get
        {
            return _strImage;
        }
        set
        {
            _strImage = value;
        }
    }

    private int _iOrder = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iOrder
    {
        get
        {
            return _iOrder;
        }
        set
        {
            _iOrder = value;
        }
    }

    public string fn_saveCategory()
    {
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_saveCategory(strCategoryTitle, strCategoryDesc, strImage, iOrder);
    }

    public string fn_editCategory()
    {
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_editCategory(iID, strCategoryTitle, strCategoryDesc, strImage, iOrder);
    }

    public string fn_editCategoryWithoutImage()
    {
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_editCategoryWithoutImage(iID, strCategoryTitle, strCategoryDesc, iOrder);
    }

    public string fn_deleteCategory()
    {
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_deleteCategory(iID);
    }

    public CoreWebList<InstituteCategoryClass> fn_getCategoryByID()
    {
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_getCategoryByID(iID);
    }

    public CoreWebList<InstituteCategoryClass> fn_getCategoryList()
    {
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_getCategoryList();
    }

    public CoreWebList<InstituteCategoryClass> fn_getOrderedCategoryList()
    {
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_getOrderedCategoryList();
    }

    public CoreWebList<InstituteCategoryClass> fn_getCategoryList_Top8()
    {
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_getCategoryList_Top8();
    }

    public CoreWebList<InstituteCategoryClass> fn_getCategoryList_Top3()
    {
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_getCategoryList_Top3();
    }




    #region Institute Subcategory 

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
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_saveSubCategory(iCatID, strSubCategoryTitle, strSubCategoryDesc);
    }

    public string fn_editSubCategory()
    {
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_editSubCategory(iCatID, iSubCatID, strSubCategoryTitle, strSubCategoryDesc);
    }

    
    public string fn_deleteSubCategory()
    {
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_deleteSubCategory(iSubCatID);
    }

    public CoreWebList<InstituteCategoryClass> fn_getSubCategoryByID()
    {
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_getSubCategoryByID(iSubCatID);
    }

    public CoreWebList<InstituteCategoryClass> fn_getSubCategoryList()
    {
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_getSubCategoryList();
    }

    public CoreWebList<InstituteCategoryClass> fn_getSubCategoryByCatID()
    {
        DBInstituteCategoryClass objdb = new DBInstituteCategoryClass();
        return objdb.fn_getSubCategoryByCatID(iCatID);
    }
    #endregion
}
