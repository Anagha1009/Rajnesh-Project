using System;
using System.Collections.Generic;
using System.Web;
using yo_lib;

/// <summary>
/// Summary description for JobCategoryClass
/// </summary>
public class JobCategoryClass
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

    private string _strJobCategoryName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strJobCategoryName
    {
        get
        {
            return _strJobCategoryName;
        }
        set
        {
            _strJobCategoryName = value;
        }
    }

    private string _strJobCategoryDesc = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strJobCategoryDesc
    {
        get
        {
            return _strJobCategoryDesc;
        }
        set
        {
            _strJobCategoryDesc = value;
        }
    }


    public string fn_SaveJobCategory()
    {
        DBJobCategoryClass objdb = new DBJobCategoryClass();
        return objdb.fn_SaveJobCategory(strJobCategoryName, strJobCategoryDesc);
    }

    public string fn_EditJobCategory()
    {
        DBJobCategoryClass objdb = new DBJobCategoryClass();
        return objdb.fn_EditJobCategory(iID, strJobCategoryName, strJobCategoryDesc);
    }

    public string fn_DeleteJobCategory()
    {
        DBJobCategoryClass objdb = new DBJobCategoryClass();
        return objdb.fn_DeleteJobCategory(iID);
    }

    public CoreWebList<JobCategoryClass> fn_GetJobCategoryByID()
    {
        DBJobCategoryClass objdb = new DBJobCategoryClass();
        return objdb.fn_GetJobCategoryByID(iID);
    }

    public CoreWebList<JobCategoryClass> fn_GetJobCategoryList()
    {
        DBJobCategoryClass objdb = new DBJobCategoryClass();
        return objdb.fn_GetJobCategoryList();
    }
}
