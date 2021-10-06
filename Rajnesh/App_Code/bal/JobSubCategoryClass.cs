using System;
using System.Collections.Generic;
using System.Web;
using yo_lib;

/// <summary>
/// Summary description for JobSubCategoryClass
/// </summary>
public class JobSubCategoryClass
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

    private int _iCategoryID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCategoryID
    {
        get
        {
            return _iCategoryID;
        }
        set
        {
            _iCategoryID = value;
        }
    }

    private string _strJobSubCategoryName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strJobSubCategoryName
    {
        get
        {
            return _strJobSubCategoryName;
        }
        set
        {
            _strJobSubCategoryName = value;
        }
    }

    private string _strJobSubCategoryDesc = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strJobSubCategoryDesc
    {
        get
        {
            return _strJobSubCategoryDesc;
        }
        set
        {
            _strJobSubCategoryDesc = value;
        }
    }


    public string fn_SaveJobSubCategory()
    {
        DBJobSubCategoryClass objdb = new DBJobSubCategoryClass();
        return objdb.fn_SaveJobSubCategory(iCategoryID, strJobSubCategoryName, strJobSubCategoryDesc);
    }

    public string fn_EditJobSubCategory()
    {
        DBJobSubCategoryClass objdb = new DBJobSubCategoryClass();
        return objdb.fn_EditJobSubCategory(iID, iCategoryID, strJobSubCategoryName, strJobSubCategoryDesc);
    }

    public string fn_DeleteJobSubCategory()
    {
        DBJobSubCategoryClass objdb = new DBJobSubCategoryClass();
        return objdb.fn_DeleteJobSubCategory(iID);
    }

    public CoreWebList<JobSubCategoryClass> fn_GetJobSubCategoryByID()
    {
        DBJobSubCategoryClass objdb = new DBJobSubCategoryClass();
        return objdb.fn_GetJobSubCategoryByID(iID);
    }

    public CoreWebList<JobSubCategoryClass> fn_GetJobSubCategoryByCategoryID()
    {
        DBJobSubCategoryClass objdb = new DBJobSubCategoryClass();
        return objdb.fn_GetJobSubCategoryByCategoryID(iCategoryID);
    }

    public CoreWebList<JobSubCategoryClass> fn_GetJobSubCategoryList()
    {
        DBJobSubCategoryClass objdb = new DBJobSubCategoryClass();
        return objdb.fn_GetJobSubCategoryList();
    }
}
