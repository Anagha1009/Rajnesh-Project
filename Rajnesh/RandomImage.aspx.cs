using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public partial class RandomImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "image/jpeg";
        string strFinalTxt = "";        
        while (true)
        {
            string sTxt = GetRandomString(6);
            if (sTxt.Contains("o") || sTxt.Contains("O") || sTxt.Contains("0") || sTxt.Contains("1") || sTxt.Contains("l") || sTxt.Contains("I") || sTxt.Contains("i"))
            {
                // discard
            }
            else
            {
                strFinalTxt = sTxt;
                break;
            }
        }

        Session["RandomString"] = strFinalTxt;
        Bitmap bmp = generateImage(strFinalTxt);
        bmp.Save(Response.OutputStream, ImageFormat.Jpeg);
        bmp.Dispose();
        if (!Page.IsPostBack)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }
    }
    
    public string GetRandomString(int iLength)
    {
        string strCharPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

        Random random = new Random();
        int iMin = 0;
        int iMax = strCharPool.Length - 1;

        StringBuilder rs = new StringBuilder();
        while (iLength-- > 0)
        {
            rs.Append(strCharPool[random.Next(iMin, iMax)]);
        }

        return rs.ToString();
    }

    public Bitmap generateImage(string sTextToImg)
    {
        PixelFormat pxImagePattern = PixelFormat.Format32bppArgb;
        Bitmap bmpImage = new Bitmap(1, 1, pxImagePattern);
        Font fntImageFont = new Font("Trebuchets", 18);
        Graphics gdImageGrp = Graphics.FromImage(bmpImage);

        float iWidth = gdImageGrp.MeasureString(sTextToImg, fntImageFont).Width + 20;
        float iHeight = gdImageGrp.MeasureString(sTextToImg, fntImageFont).Height + 20;

        bmpImage = new Bitmap((int)iWidth, (int)iHeight, pxImagePattern);
        gdImageGrp = Graphics.FromImage(bmpImage);
        gdImageGrp.Clear(Color.FromArgb(229,230,231));
        gdImageGrp.TextRenderingHint = TextRenderingHint.AntiAlias;
        gdImageGrp.DrawString(sTextToImg, fntImageFont, new SolidBrush(Color.Black), 10, 10);
        gdImageGrp.Flush();

        return bmpImage;
    }
}
