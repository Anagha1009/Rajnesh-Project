using System;
using yo_lib;

/// <summary>
///     Summary description for EmployerClass
/// </summary>
public class EmployerClass
{
    private DateTime _dtRegisterDate = DateTime.Now;
    private string _strAccType = "";
    private string _strCity = "";
    private string _strCompany = "";
    private string _strCompanyDetails = "";
    private string _strCountry = "";
    private string _strDesignation = "";
    private string _strEmail = "";
    private string _strFName = "";
    private string _strIndustry = "";
    private string _strIndustryType = "";
    private string _strLName = "";
    private string _strPassword = "";
    private string _strPhone = "";
    private string _strPincode = "";
    private string _strWebsite = "";

    public EmployerClass()
    {
        bActivate = false;
        iEmpTotal = 0;
        iID = 0;
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iID { get; set; }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iEmpTotal { get; set; }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strFName
    {
        get { return _strFName; }
        set { _strFName = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strLName
    {
        get { return _strLName; }
        set { _strLName = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strAccType
    {
        get { return _strAccType; }
        set { _strAccType = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strEmail
    {
        get { return _strEmail; }
        set { _strEmail = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strPassword
    {
        get { return _strPassword; }
        set { _strPassword = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCompany
    {
        get { return _strCompany; }
        set { _strCompany = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strDesignation
    {
        get { return _strDesignation; }
        set { _strDesignation = value; }
    }


    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strPincode
    {
        get { return _strPincode; }
        set { _strPincode = value; }
    }


    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCity
    {
        get { return _strCity; }
        set { _strCity = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCountry
    {
        get { return _strCountry; }
        set { _strCountry = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strPhone
    {
        get { return _strPhone; }
        set { _strPhone = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strWebsite
    {
        get { return _strWebsite; }
        set { _strWebsite = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strCompanyDetails
    {
        get { return _strCompanyDetails; }
        set { _strCompanyDetails = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strIndustry
    {
        get { return _strIndustry; }
        set { _strIndustry = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strIndustryType
    {
        get { return _strIndustryType; }
        set { _strIndustryType = value; }
    }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bActivate { get; set; }

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public DateTime dtRegisterDate
    {
        get { return _dtRegisterDate; }
        set { _dtRegisterDate = value; }
    }

    public int fn_saveEmployer()
    {
        var objdb = new DBEmployerClass();
        return objdb.fn_saveEmployer(this);
    }

    public string fn_editEmployer()
    {
        var objdb = new DBEmployerClass();
        return objdb.fn_editEmployer(this);
    }

    public string fn_deleteEmployer()
    {
        var objdb = new DBEmployerClass();
        return objdb.fn_deleteEmployer(this);
    }

    public CoreWebList<EmployerClass> fn_getEmployerByID()
    {
        var objdb = new DBEmployerClass();
        return objdb.fn_getEmployerByID(this);
    }

    public CoreWebList<EmployerClass> fn_getEmployerList()
    {
        var objdb = new DBEmployerClass();
        return objdb.fn_getEmployerList();
    }

    public string fn_changeUserActivateStatus()
    {
        var objdb = new DBEmployerClass();
        return objdb.fn_changeUserActivateStatus(this);
    }

    public CoreWebList<EmployerClass> fn_checkLogin()
    {
        var objdb = new DBEmployerClass();
        return objdb.fn_checkLogin(this);
    }

    public bool fn_checkEmail()
    {
        var objdb = new DBEmployerClass();
        return objdb.fn_checkEmail(this);
    }
}