using yo_lib;

/// <summary>
///     Summary description for JobCompanyClass
/// </summary>
public class JobCompanyClass
{
    private string _strContactDetails = "";
    private string _strEmail = "";
    private string _strJobCompanyDesc = "";
    private string _strJobCompanyName = "";
    private string _strLogo = "";

    public JobCompanyClass()
    {
        bFeatured = false;
        iCategoryID = 0;
        iID = 0;
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iID { get; set; }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCategoryID { get; set; }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strJobCompanyName
    {
        get { return _strJobCompanyName; }
        set { _strJobCompanyName = value; }
    }


    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strContactDetails
    {
        get { return _strContactDetails; }
        set { _strContactDetails = value; }
    }


    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strJobCompanyDesc
    {
        get { return _strJobCompanyDesc; }
        set { _strJobCompanyDesc = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strEmail
    {
        get { return _strEmail; }
        set { _strEmail = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strLogo
    {
        get { return _strLogo; }
        set { _strLogo = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bFeatured { get; set; }


    public string fn_SaveJobCompany()
    {
        var objdb = new DBJobCompanyClass();
        return objdb.fn_SaveJobCompany(iCategoryID, strJobCompanyName, strJobCompanyDesc, strContactDetails, strEmail,
            bFeatured, strLogo);
    }

    public string fn_EditJobCompany()
    {
        var objdb = new DBJobCompanyClass();
        return objdb.fn_EditJobCompany(iID, iCategoryID, strJobCompanyName, strJobCompanyDesc, strContactDetails,
            strEmail, bFeatured, strLogo);
    }

    public string fn_DeleteJobCompany()
    {
        var objdb = new DBJobCompanyClass();
        return objdb.fn_DeleteJobCompany(iID);
    }

    public CoreWebList<JobCompanyClass> fn_GetFeturedJobCompanyByID()
    {
        var objdb = new DBJobCompanyClass();
        return objdb.fn_GetFeturedJobCompanyByID(iID);
    }

    public CoreWebList<JobCompanyClass> fn_GetJobCompanyByID()
    {
        var objdb = new DBJobCompanyClass();
        return objdb.fn_GetJobCompanyByID(iID);
    }

    public CoreWebList<JobCompanyClass> fn_GetFeaturedCompany()
    {
        var objdb = new DBJobCompanyClass();
        return objdb.fn_GetFeaturedCompany();
    }

    public CoreWebList<JobCompanyClass> fn_GetJobCompanyByName()
    {
        var objdb = new DBJobCompanyClass();
        return objdb.fn_GetJobCompanyByName(strJobCompanyName);
    }

    public CoreWebList<JobCompanyClass> fn_SearchJobCompanyByName()
    {
        var objdb = new DBJobCompanyClass();
        return objdb.fn_SearchJobCompanyByName(strJobCompanyName);
    }

    public CoreWebList<JobCompanyClass> fn_GetJobCompanyList()
    {
        var objdb = new DBJobCompanyClass();
        return objdb.fn_GetJobCompanyList();
    }

    public CoreWebList<JobCompanyClass> fn_Get_JobCompanyList()
    {
        var objdb = new DBJobCompanyClass();
        return objdb.fn_Get_JobCompanyList();
    }

    public string fn_EditFeatured()
    {
        var objdb = new DBJobCompanyClass();
        return objdb.fn_EditFeatured(iID, bFeatured);
    }
}