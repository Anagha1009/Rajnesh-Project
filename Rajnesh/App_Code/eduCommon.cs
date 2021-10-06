using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for eduCommon
/// </summary>
public class eduCommon
{
	public eduCommon()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string fn_GetShortText(string strText)
    {
        try
        {
            if (strText.Contains("."))
            {
                strText = strText.Substring(0, strText.IndexOf('.') + 1);
            }

            return strText;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static string fn_TrimHtmlContent(string source)
    {
        return Regex.Replace(source, "<.*?>", string.Empty);
    }
}