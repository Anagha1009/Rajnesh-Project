using System;
using System.Data;
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
/// Summary description for StateMasterClass
/// </summary>
public class StateMasterClass
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

    private string _strStateName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strStateName
    {
        get
        {
            return _strStateName;
        }
        set
        {
            _strStateName = value;
        }
    }

 
    public string fn_saveState()
    {
        DBStateMasterClass objdb = new DBStateMasterClass();
        return objdb.fn_saveState(strStateName);
    }

    public string fn_editState()
    {
        DBStateMasterClass objdb = new DBStateMasterClass();
        return objdb.fn_editState(iID, strStateName);
    }

    public string fn_deleteState()
    {
        DBStateMasterClass objdb = new DBStateMasterClass();
        return objdb.fn_deleteState(iID);
    }

    public CoreWebList<StateMasterClass> fn_getStateList()
    {
        DBStateMasterClass objdb = new DBStateMasterClass();
        return objdb.fn_getStateList();
    }

    public CoreWebList<StateMasterClass> fn_getStateListByID()
    {
        DBStateMasterClass objdb = new DBStateMasterClass();
        return objdb.fn_getStateListByID(iID);
    }

    public CoreWebList<StateMasterClass> fn_getStateByStateName()
    {
        DBStateMasterClass objdb = new DBStateMasterClass();
        return objdb.fn_getStateByStateName(strStateName);
    }

    
}
