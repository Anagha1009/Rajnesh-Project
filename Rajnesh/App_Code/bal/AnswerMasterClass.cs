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
/// Summary description for AnswerMasterClass
/// </summary>
public class AnswerMasterClass
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

    private int _iQuestionID = 0;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iQuestionID
    {
        get
        {
            return _iQuestionID;
        }
        set
        {
            _iQuestionID = value;
        }
    }

    private int _iUserID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iUserID
    {
        get
        {
            return _iUserID;
        }
        set
        {
            _iUserID = value;
        }
    }

    private DateTime _dtDate = DateTime.Now;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public DateTime dtDate
    {
        get
        {
            return _dtDate;
        }
        set
        {
            _dtDate = value;
        }
    }

    private string _strUserName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strUserName
    {
        get
        {
            return _strUserName;
        }
        set
        {
            _strUserName = value;
        }
    }

    private string _strReply = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strReply
    {
        get
        {
            return _strReply;
        }
        set
        {
            _strReply = value;
        }
    }

    public string fn_saveAnswer()
    {
        DBAnswerMasterClass objdb = new DBAnswerMasterClass();
        return objdb.fn_saveAnswer(this);
    }

    public string fn_deleteAnswer()
    {
        DBAnswerMasterClass objdb = new DBAnswerMasterClass();
        return objdb.fn_deleteAnswer(iID);
    }

    public CoreWebList<AnswerMasterClass> fn_getAnswerListByQuestionID()
    {
        DBAnswerMasterClass objSM = new DBAnswerMasterClass();
        return objSM.fn_getAnswerListByQuestionID(iQuestionID);
    }

    public CoreWebList<AnswerMasterClass> fn_getAnswerByID()
    {
        DBAnswerMasterClass objSM = new DBAnswerMasterClass();
        return objSM.fn_getAnswerByID(iID);
    }
}
