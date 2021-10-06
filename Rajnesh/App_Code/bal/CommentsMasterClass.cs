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
/// Summary description for CommentsMasterClass
/// </summary>
public class CommentsMasterClass
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
    
    private string _strComment= "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strComment
    {
        get
        {
            return _strComment;
        }
        set
        {
            _strComment = value;
        }
    }

    private string _strUrl = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strUrl
    {
        get
        {
            return _strUrl;
        }
        set
        {
            _strUrl = value;
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

    private string _strIp = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strIp
    {
        get
        {
            return _strIp;
        }
        set
        {
            _strIp = value;
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

    private bool _bQuest = false;
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public bool bQuest
    {
        get
        {
            return _bQuest;
        }
        set
        {
            _bQuest = value;
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

    public string fn_saveComment()
    {
        DBCommentMasterClass objdb = new DBCommentMasterClass();
        return objdb.fn_saveComment(this);
    }

    public string fn_deleteComment()
    {
        DBCommentMasterClass objdb = new DBCommentMasterClass();
        return objdb.fn_deleteComment(iID);
    }

    public CoreWebList<CommentsMasterClass> fn_getCommentList()
    {
        DBCommentMasterClass objdb = new DBCommentMasterClass();
        return objdb.fn_getCommentList();
    }

    public CoreWebList<CommentsMasterClass> fn_get_CommentList()
    {
        DBCommentMasterClass objdb = new DBCommentMasterClass();
        return objdb.fn_get_CommentList();
    }

    public CoreWebList<CommentsMasterClass> fn_getCommentByID()
    {
        DBCommentMasterClass objdb = new DBCommentMasterClass();
        return objdb.fn_getCommentByID(iID);
    }

    public CoreWebList<CommentsMasterClass> fn_getCommentByUrl()
    {
        DBCommentMasterClass objdb = new DBCommentMasterClass();
        return objdb.fn_getCommentByUrl(strUrl);
    }

    public CoreWebList<CommentsMasterClass> fn_getAbusedComments()
    {
        DBCommentMasterClass objdb = new DBCommentMasterClass();
        return objdb.fn_getAbusedComments();
    }

    public CoreWebList<CommentsMasterClass> fn_getActiveCommentByUrl()
    {
        DBCommentMasterClass objdb = new DBCommentMasterClass();
        return objdb.fn_getActiveCommentByUrl(strUrl);
    }

    public string fn_ChangeCommentStatus()
    {
        DBCommentMasterClass objdb = new DBCommentMasterClass();
        return objdb.fn_ChangeCommentStatus(this);
    }

    public string fn_ChangeCommentQuestStatus()
    {
        DBCommentMasterClass objdb = new DBCommentMasterClass();
        return objdb.fn_ChangeCommentQuestStatus(this);
    }

    public string fn_ChangeAbusedCommentStatus()
    {
        DBCommentMasterClass objdb = new DBCommentMasterClass();
        return objdb.fn_ChangeAbusedCommentStatus(this);
    }
}
