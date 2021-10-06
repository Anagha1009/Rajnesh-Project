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
/// Summary description for ImagesClass
/// </summary>
public class ImagesClass
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

    private int _iTypeID = 0;

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public int iTypeID
    {
        get
        {
            return _iTypeID;
        }
        set
        {
            _iTypeID = value;
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

    private string _strThumbnail = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strThumbnail
    {
        get
        {
            return _strThumbnail;
        }
        set
        {
            _strThumbnail = value;
        }
    }

    private string _strBigImage = "";

    [Conversion(DataTableConversion = true, AllowDbNull = false)]
    public string strBigImage
    {
        get
        {
            return _strBigImage;
        }
        set
        {
            _strBigImage = value;
        }
    }

    public string fn_saveImage()
    {
        DBImagesClass objdb = new DBImagesClass();
        return objdb.fn_saveImage(strTitle, iTypeID, strType, strThumbnail, strBigImage);
    }

    public string fn_deleteImage()
    {
        DBImagesClass objdb = new DBImagesClass();
        return objdb.fn_deleteImage(iID);
    }

    public CoreWebList<ImagesClass> fn_getImageByID()
    {
        DBImagesClass objdb = new DBImagesClass();
        return objdb.fn_getImageByID(iID);
    }

    public CoreWebList<ImagesClass> fn_getImagesList()
    {
        DBImagesClass objdb = new DBImagesClass();
        return objdb.fn_getImagesList();
    }

    public CoreWebList<ImagesClass> fn_getImageByType()
    {
        DBImagesClass objdb = new DBImagesClass();
        return objdb.fn_getImageByType(strType);
    }

    public CoreWebList<ImagesClass> fn_getImageByTypeAndTypeID()
    {
        DBImagesClass objdb = new DBImagesClass();
        return objdb.fn_getImageByTypeAndTypeID(strType, iTypeID);
    }

	public ImagesClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
