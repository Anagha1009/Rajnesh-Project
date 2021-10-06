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
/// Summary description for CommentKeysClass
/// </summary>
public class CommentKeysClass
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

    private string _strTitle = "";
    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strTitle
    {
        get
        {
            return _strTitle;
        }
        set
        {
            _strTitle = value;
        }
    }

    public string fn_saveCommentKeys()
    {
        DBCommentKeysClass objdb = new DBCommentKeysClass();
        return objdb.fn_saveCommentKeys(this);
    }

    public string fn_editCommentKeys()
    {
        DBCommentKeysClass objdb = new DBCommentKeysClass();
        return objdb.fn_editCommentKeys(this);
    }

    public string fn_deleteCommentKeys()
    {
        DBCommentKeysClass objdb = new DBCommentKeysClass();
        return objdb.fn_deleteCommentKeys(iID);
    }

    public CoreWebList<CommentKeysClass> fn_getCommentKeyByID()
    {
        DBCommentKeysClass objdb = new DBCommentKeysClass();
        return objdb.fn_getCommentKeyByID(iID);
    }

    public CoreWebList<CommentKeysClass> fn_getCommentKeyByKeys(string strkeys)
    {
        DBCommentKeysClass objdb = new DBCommentKeysClass();
        return objdb.fn_getCommentKeyByKeys(strkeys);
    }

    public CoreWebList<CommentKeysClass> fn_getCommentKeysList()
    {
        DBCommentKeysClass objdb = new DBCommentKeysClass();
        return objdb.fn_getCommentKeysList();
    }
}
