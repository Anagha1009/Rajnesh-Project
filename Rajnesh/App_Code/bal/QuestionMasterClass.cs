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
/// Summary description for QuestionMasterClass
/// </summary>
public class QuestionMasterClass
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

    private int _iAbuseUserID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iAbuseUserID
    {
        get
        {
            return _iAbuseUserID;
        }
        set
        {
            _iAbuseUserID = value;
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
    private bool _bAbuse = false;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bAbuse
    {
        get
        {
            return _bAbuse;
        }
        set
        {
            _bAbuse = value;
        }
    }

    private string _strType = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strType
    {
        get
        {
            return _strType;
        }
        set
        {
            _strType = value;
        }
    }

    private string _strQuestion = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strQuestion
    {
        get
        {
            return _strQuestion;
        }
        set
        {
            _strQuestion = value;
        }
    }

    private string _strEmailId = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strEmailId
    {
        get { return _strEmailId; }
        set { _strEmailId = value; }
    }
   
    private DateTime  _dtDate = DateTime.Now;
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
    private string _strQuestionName = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strQuestionName
    {
        get
        {
            return _strQuestionName;
        }
        set
        {
            _strQuestionName = value;
        }
    }

    public string fn_saveQuestion()
    {
        DBQuestionMasterClass objdb = new DBQuestionMasterClass();
        return objdb.fn_saveQuestion(iUserID,strQuestion, strUserName,iAbuseUserID,bAbuse, strType);
    }


    public int fn_save_Question()
    {
        DBQuestionMasterClass objdb = new DBQuestionMasterClass();
        return objdb.fn_save_Question(iUserID, strQuestion, strUserName, iAbuseUserID, bAbuse, strType);
    }


    public string fn_editQuestion()
    {
        DBQuestionMasterClass objdb = new DBQuestionMasterClass();
        return objdb.fn_editQuestion(iID, iUserID, strQuestion, iAbuseUserID, bAbuse);
    }

    public string fn_edit_Question()
    {
        DBQuestionMasterClass objdb = new DBQuestionMasterClass();
        return objdb.fn_edit_Question(iID, strQuestion);
    }

    public string fn_deleteQuestion()
    {
        DBQuestionMasterClass objdb = new DBQuestionMasterClass();
        return objdb.fn_deleteQuestion(iID);
    }

    public CoreWebList<QuestionMasterClass> fn_getQuestionList()
    {
        DBQuestionMasterClass objdb = new DBQuestionMasterClass();
        return objdb.fn_getQuestionList();
    }

    public CoreWebList<QuestionMasterClass> fn_getRandomQuestionList(int iRowCount)
    {
        DBQuestionMasterClass objdb = new DBQuestionMasterClass();
        return objdb.fn_getRandomQuestionList(iRowCount);
    }

    public CoreWebList<QuestionMasterClass> fn_getRandomQuestionListByType(int iRowCount)
    {
        DBQuestionMasterClass objdb = new DBQuestionMasterClass();
        return objdb.fn_getRandomQuestionListByType(iRowCount, strType);
    }

    public CoreWebList<QuestionMasterClass> fn_getQuestionByKey(string strKey)
    {
        DBQuestionMasterClass objdb = new DBQuestionMasterClass();
        return objdb.fn_getQuestionByKey(strKey);
    }

    public CoreWebList<QuestionMasterClass> fn_getQuestion_List()
    {
        DBQuestionMasterClass objdb = new DBQuestionMasterClass();
        return objdb.fn_getQuestion_List();
    }

    public CoreWebList<QuestionMasterClass> fn_getQuestionListByID()
    {
        DBQuestionMasterClass objdb = new DBQuestionMasterClass();
        return objdb.fn_getQuestionListByID(iID);
    }

    public CoreWebList<QuestionMasterClass> fn_getQuestionListByUserID()
    {
        DBQuestionMasterClass objSM = new DBQuestionMasterClass();
        return objSM.fn_getQuestionListByUserID(iUserID);
    }


    public CoreWebList<QuestionMasterClass> fn_getQuestionByID()
    {
        DBQuestionMasterClass objdb = new DBQuestionMasterClass();
        return objdb.fn_getQuestionByID(iID);
    }

    public CoreWebList<QuestionMasterClass> fn_getQuestionByQuery(string strQuery)
    {
        DBQuestionMasterClass objdb = new DBQuestionMasterClass();
        return objdb.fn_getQuestionByQuery(strQuery);
    }
    
    public string fn_RemoveFromadmin()
    {
        DBQuestionMasterClass objSM = new DBQuestionMasterClass();
        return objSM.fn_RemoveFromadmin(iID, bAbuse);
    }
    public string fn_RemoveFromClient()
    {
        DBQuestionMasterClass objSM = new DBQuestionMasterClass();
        return objSM.fn_RemoveFromClient(iUserID, iID);
    }
    public bool fn_RemoveByID()
    {
        DBQuestionMasterClass objSM = new DBQuestionMasterClass();
        return objSM.fn_RemoveByID(iID);
    }
    public CoreWebList<QuestionMasterClass> fn_getAbuseList()
    {
        DBQuestionMasterClass objSM = new DBQuestionMasterClass();
        return objSM.fn_getAbuseList();
    }

    public CoreWebList<QuestionMasterClass> fn_getAbuseQuestionList()
    {
        DBQuestionMasterClass objSM = new DBQuestionMasterClass();
        return objSM.fn_getAbuseQuestionList();
    }

    public CoreWebList<QuestionMasterClass> fn_QuestionListRandom(int iStartRow, int iEndRow)
    {
        DBQuestionMasterClass objSM = new DBQuestionMasterClass();
        return objSM.fn_QuestionListRandom(iStartRow,iEndRow);
    }
}
