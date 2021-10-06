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
/// Summary description for UserClass
/// </summary>
public class UserClass
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

    private int _iCityID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iCityID
    {
        get
        {
            return _iCityID;
        }
        set
        {
            _iCityID = value;
        }
    }

    private string _strName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strName
    {
        get
        {
            return _strName;
        }
        set
        {
            _strName = value;
        }
    }


    private string _strEmail = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strEmail
    {
        get
        {
            return _strEmail;
        }
        set
        {
            _strEmail = value;
        }
    }

    private string _strPassword = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strPassword
    {
        get
        {
            return _strPassword;
        }
        set
        {
            _strPassword = value;
        }
    }


    private DateTime _dtDOB = DateTime.Now;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public DateTime dtDOB
    {
        get
        {
            return _dtDOB;
        }
        set
        {
            _dtDOB = value;
        }
    }

    private bool _bGender = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bGender
    {
        get
        {
            return _bGender;
        }
        set
        {
            _bGender = value;
        }
    }

    
    private string _strPhone = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strPhone
    {
        get
        {
            return _strPhone;
        }
        set
        {
            _strPhone = value;
        }
    }

    private string _strPhoto = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strPhoto
    {
        get
        {
            return _strPhoto;
        }
        set
        {
            _strPhoto = value;
        }
    }

    private DateTime _dtRegDate = DateTime.Now;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public DateTime dtRegDate
    {
        get
        {
            return _dtRegDate;
        }
        set
        {
            _dtRegDate = value;
        }
    }


    private string _strIpAddress = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strIpAddress
    {
        get
        {
            return _strIpAddress;
        }
        set
        {
            _strIpAddress = value;
        }
    }


    private bool _bActive = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bActive
    {
        get
        {
            return _bActive;
        }
        set
        {
            _bActive = value;
        }
    }


    public int fn_saveUser()
    {
        DBUserClass objdb = new DBUserClass();
        return objdb.fn_saveUser(this);
    }

    public string fn_editUser()
    {
        DBUserClass objdb = new DBUserClass();
        return objdb.fn_editUser(this);
    }

    public string fn_editUserStatus()
    {
        DBUserClass objdb = new DBUserClass();
        return objdb.fn_editUserStatus(this);
    }

    public string fn_deleteUser()
    {
        DBUserClass objdb = new DBUserClass();
        return objdb.fn_deleteUser(iID);
    }

    public CoreWebList<UserClass> fn_getUserByID()
    {
        DBUserClass objdb = new DBUserClass();
        return objdb.fn_getUserByID(iID);
    }

    public CoreWebList<UserClass> fn_getUserByEmail()
    {
        DBUserClass objdb = new DBUserClass();
        return objdb.fn_getUserByEmail(strEmail);
    }

    public CoreWebList<UserClass> fn_CheckLogin()
    {
        DBUserClass objdb = new DBUserClass();
        return objdb.fn_CheckLogin(strEmail, strPassword);
    }

    public CoreWebList<UserClass> fn_getUserByKeys(string strkeys)
    {
        DBUserClass objdb = new DBUserClass();
        return objdb.fn_getUserByKeys(strkeys);
    }

    public CoreWebList<UserClass> fn_getUserList()
    {
        DBUserClass objdb = new DBUserClass();
        return objdb.fn_getUserList();
    }
}
