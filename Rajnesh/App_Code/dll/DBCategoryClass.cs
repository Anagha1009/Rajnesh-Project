using System;
using System.Data;
using System.Data.SqlClient;
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
/// Summary description for DBCategoryClass
/// </summary>
public class DBCategoryClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveCategory(CategoryClass objCategory)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_Category (Category_OrderNo, Category_Title, Category_Url, Category_ShortDesc, Category_LongDesc, Category_SmallImage, Category_MediumImage, Category_BigImage, Category_TitleColorCode, Category_ContentColorCode, Category_ShowHome) VALUES (@Category_OrderNo, @Category_Title, @Category_Url, @Category_ShortDesc, @Category_LongDesc, @Category_SmallImage, @Category_MediumImage, @Category_BigImage, @Category_TitleColorCode, @Category_ContentColorCode, @Category_ShowHome)", objConnection);
            objCommand.Parameters.AddWithValue("@Category_OrderNo", objCategory.iOrderNo);
            objCommand.Parameters.AddWithValue("@Category_Title", objCategory.strTitle);
            objCommand.Parameters.AddWithValue("@Category_Url", objCategory.strUrl);
			objCommand.Parameters.AddWithValue("@Category_ShortDesc", objCategory.strShortDesc);
			objCommand.Parameters.AddWithValue("@Category_LongDesc", objCategory.strLongDesc);
			objCommand.Parameters.AddWithValue("@Category_SmallImage", objCategory.strSmallImage);
			objCommand.Parameters.AddWithValue("@Category_MediumImage", objCategory.strMediumImage);
			objCommand.Parameters.AddWithValue("@Category_BigImage", objCategory.strBigImage);
			objCommand.Parameters.AddWithValue("@Category_TitleColorCode", objCategory.strTitleColorCode);
			objCommand.Parameters.AddWithValue("@Category_ContentColorCode", objCategory.strContentColorCode);
			objCommand.Parameters.AddWithValue("@Category_ShowHome", objCategory.bShowHome);

			if (objCommand.ExecuteNonQuery() > 0)
			{
				return "SUCCESS : Record has been inserted successfully!";
			}
			else
			{
				return "ERROR : SQL Exception";
			}
		}
		catch (Exception ex)
		{
				return "ERROR : " + ex.Message;
			}
			finally
			{
				if (objConnection != null)
			{
				objConnection.Close();
			}
		}
	}

	public string fn_editCategory(CategoryClass objCategory)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_Category SET Category_OrderNo=@Category_OrderNo, Category_Title=@Category_Title, Category_Url=@Category_Url, Category_ShortDesc=@Category_ShortDesc, Category_LongDesc=@Category_LongDesc, Category_SmallImage=@Category_SmallImage, Category_MediumImage=@Category_MediumImage, Category_BigImage=@Category_BigImage, Category_TitleColorCode=@Category_TitleColorCode, Category_ContentColorCode=@Category_ContentColorCode WHERE Category_ID=@Category_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Category_ID", objCategory.iID);
            objCommand.Parameters.AddWithValue("@Category_OrderNo", objCategory.iOrderNo);
			objCommand.Parameters.AddWithValue("@Category_Title", objCategory.strTitle);
            objCommand.Parameters.AddWithValue("@Category_Url", objCategory.strUrl);
			objCommand.Parameters.AddWithValue("@Category_ShortDesc", objCategory.strShortDesc);
			objCommand.Parameters.AddWithValue("@Category_LongDesc", objCategory.strLongDesc);
			objCommand.Parameters.AddWithValue("@Category_SmallImage", objCategory.strSmallImage);
			objCommand.Parameters.AddWithValue("@Category_MediumImage", objCategory.strMediumImage);
			objCommand.Parameters.AddWithValue("@Category_BigImage", objCategory.strBigImage);
			objCommand.Parameters.AddWithValue("@Category_TitleColorCode", objCategory.strTitleColorCode);
			objCommand.Parameters.AddWithValue("@Category_ContentColorCode", objCategory.strContentColorCode);

			if (objCommand.ExecuteNonQuery() > 0)
			{
				return "SUCCESS : Record has been updated successfully!";
			}
			else
			{
				return "ERROR : SQL Exception";
			}
		}
		catch (Exception ex)
		{
				return "ERROR : " + ex.Message;
			}
			finally
			{
				if (objConnection != null)
			{
				objConnection.Close();
			}
		}
	}

	public string fn_deleteCategory(int iCategoryID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Category WHERE Category_ID=@Category_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Category_ID", iCategoryID);

			if (objCommand.ExecuteNonQuery() > 0)
			{
				return "SUCCESS : Record has been deleted successfully!";
			}
			else
			{
				return "ERROR : SQL Exception";
			}
		}
		catch (Exception ex)
		{
				return "ERROR : " + ex.Message;
			}
			finally
			{
				if (objConnection != null)
			{
				objConnection.Close();
			}
		}
	}

	public CoreWebList<CategoryClass> fn_getCategoryList()
	{
		CoreWebList<CategoryClass> objCategoryList = null;
		CategoryClass objCategory = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Category", objConnection);
			objReader = objCommand.ExecuteReader();
			objCategoryList = new CoreWebList<CategoryClass>();
			while (objReader.Read())
			{
				objCategory = new CategoryClass();
				objCategory.iID = int.Parse(objReader["Category_ID"].ToString());
                objCategory.iOrderNo = int.Parse(objReader["Category_OrderNo"].ToString());
				objCategory.strTitle = objReader["Category_Title"].ToString();
                objCategory.strUrl = objReader["Category_Url"].ToString();
				objCategory.strShortDesc = objReader["Category_ShortDesc"].ToString();
				objCategory.strLongDesc = objReader["Category_LongDesc"].ToString();
				objCategory.strSmallImage = objReader["Category_SmallImage"].ToString();
				objCategory.strMediumImage = objReader["Category_MediumImage"].ToString();
				objCategory.strBigImage = objReader["Category_BigImage"].ToString();
				objCategory.strTitleColorCode = objReader["Category_TitleColorCode"].ToString();
				objCategory.strContentColorCode = objReader["Category_ContentColorCode"].ToString();
				objCategory.bShowHome = bool.Parse(objReader["Category_ShowHome"].ToString());
				objCategoryList.Add(objCategory);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCategoryList;
		}
		catch (Exception ex)
		{
				throw ex;
		}
		finally
		{
			if (objReader != null)
			{
				objReader.Close();
			}
			if (objConnection != null)
			{
				objConnection.Close();
			}
		}
	}

    public CoreWebList<CategoryClass> fn_getHomeCategoryList()
    {
        CoreWebList<CategoryClass> objCategoryList = null;
        CategoryClass objCategory = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Category WHERE Category_ShowHome='true' ORDER BY Category_OrderNo ASC", objConnection);
            objReader = objCommand.ExecuteReader();
            objCategoryList = new CoreWebList<CategoryClass>();
            while (objReader.Read())
            {
                objCategory = new CategoryClass();
                objCategory.iID = int.Parse(objReader["Category_ID"].ToString());
                objCategory.iOrderNo = int.Parse(objReader["Category_OrderNo"].ToString());
                objCategory.strTitle = objReader["Category_Title"].ToString();
                objCategory.strUrl = objReader["Category_Url"].ToString();
                objCategory.strShortDesc = objReader["Category_ShortDesc"].ToString();
                objCategory.strLongDesc = objReader["Category_LongDesc"].ToString();
                objCategory.strSmallImage = objReader["Category_SmallImage"].ToString();
                objCategory.strMediumImage = objReader["Category_MediumImage"].ToString();
                objCategory.strBigImage = objReader["Category_BigImage"].ToString();
                objCategory.strTitleColorCode = objReader["Category_TitleColorCode"].ToString();
                objCategory.strContentColorCode = objReader["Category_ContentColorCode"].ToString();
                objCategory.bShowHome = bool.Parse(objReader["Category_ShowHome"].ToString());
                objCategoryList.Add(objCategory);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objCategoryList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

	public CoreWebList<CategoryClass> fn_getCategoryByID(int iCategoryID)
	{
		CoreWebList<CategoryClass> objCategoryList = null;
		CategoryClass objCategory = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Category WHERE Category_ID=@Category_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Category_ID", iCategoryID);
			objReader = objCommand.ExecuteReader();
			objCategoryList = new CoreWebList<CategoryClass>();
			if (objReader.Read())
			{
				objCategory = new CategoryClass();
				objCategory.iID = int.Parse(objReader["Category_ID"].ToString());
                objCategory.iOrderNo = int.Parse(objReader["Category_OrderNo"].ToString());
				objCategory.strTitle = objReader["Category_Title"].ToString();
                objCategory.strUrl = objReader["Category_Url"].ToString();
				objCategory.strShortDesc = objReader["Category_ShortDesc"].ToString();
				objCategory.strLongDesc = objReader["Category_LongDesc"].ToString();
				objCategory.strSmallImage = objReader["Category_SmallImage"].ToString();
				objCategory.strMediumImage = objReader["Category_MediumImage"].ToString();
				objCategory.strBigImage = objReader["Category_BigImage"].ToString();
				objCategory.strTitleColorCode = objReader["Category_TitleColorCode"].ToString();
				objCategory.strContentColorCode = objReader["Category_ContentColorCode"].ToString();
				objCategory.bShowHome = bool.Parse(objReader["Category_ShowHome"].ToString());
				objCategoryList.Add(objCategory);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCategoryList;
		}
		catch (Exception ex)
		{
				throw ex;
		}
		finally
		{
			if (objReader != null)
			{
				objReader.Close();
			}
			if (objConnection != null)
			{
				objConnection.Close();
			}
		}
	}

	public CoreWebList<CategoryClass> fn_getCategoryByName(string strCategoryTitle)
	{
		CoreWebList<CategoryClass> objCategoryList = null;
		CategoryClass objCategory = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Category WHERE Category_Title=@Category_Title", objConnection);
			objCommand.Parameters.AddWithValue("@Category_Title", strCategoryTitle);
			objReader = objCommand.ExecuteReader();
			objCategoryList = new CoreWebList<CategoryClass>();
			if (objReader.Read())
			{
				objCategory = new CategoryClass();
				objCategory.iID = int.Parse(objReader["Category_ID"].ToString());
                objCategory.iOrderNo = int.Parse(objReader["Category_OrderNo"].ToString());
				objCategory.strTitle = objReader["Category_Title"].ToString();
                objCategory.strUrl = objReader["Category_Url"].ToString();
				objCategory.strShortDesc = objReader["Category_ShortDesc"].ToString();
				objCategory.strLongDesc = objReader["Category_LongDesc"].ToString();
				objCategory.strSmallImage = objReader["Category_SmallImage"].ToString();
				objCategory.strMediumImage = objReader["Category_MediumImage"].ToString();
				objCategory.strBigImage = objReader["Category_BigImage"].ToString();
				objCategory.strTitleColorCode = objReader["Category_TitleColorCode"].ToString();
				objCategory.strContentColorCode = objReader["Category_ContentColorCode"].ToString();
				objCategory.bShowHome = bool.Parse(objReader["Category_ShowHome"].ToString());
				objCategoryList.Add(objCategory);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCategoryList;
		}
		catch (Exception ex)
		{
				throw ex;
		}
		finally
		{
			if (objReader != null)
			{
				objReader.Close();
			}
			if (objConnection != null)
			{
				objConnection.Close();
			}
		}
	}

	public CoreWebList<CategoryClass> fn_getCategoryByKeys(string strCategoryTitle)
	{
		CoreWebList<CategoryClass> objCategoryList = null;
		CategoryClass objCategory = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Category WHERE Category_Title like '%' + @Category_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Category_Title", strCategoryTitle);
			objReader = objCommand.ExecuteReader();
			objCategoryList = new CoreWebList<CategoryClass>();
			while (objReader.Read())
			{
				objCategory = new CategoryClass();
				objCategory.iID = int.Parse(objReader["Category_ID"].ToString());
                objCategory.iOrderNo = int.Parse(objReader["Category_OrderNo"].ToString());
				objCategory.strTitle = objReader["Category_Title"].ToString();
                objCategory.strUrl = objReader["Category_Url"].ToString();
				objCategory.strShortDesc = objReader["Category_ShortDesc"].ToString();
				objCategory.strLongDesc = objReader["Category_LongDesc"].ToString();
				objCategory.strSmallImage = objReader["Category_SmallImage"].ToString();
				objCategory.strMediumImage = objReader["Category_MediumImage"].ToString();
				objCategory.strBigImage = objReader["Category_BigImage"].ToString();
				objCategory.strTitleColorCode = objReader["Category_TitleColorCode"].ToString();
				objCategory.strContentColorCode = objReader["Category_ContentColorCode"].ToString();
				objCategory.bShowHome = bool.Parse(objReader["Category_ShowHome"].ToString());
				objCategoryList.Add(objCategory);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCategoryList;
		}
		catch (Exception ex)
		{
				throw ex;
		}
		finally
		{
			if (objReader != null)
			{
				objReader.Close();
			}
			if (objConnection != null)
			{
				objConnection.Close();
			}
		}
	}

	public string fn_ChangeCategoryShowHomeStatus(CategoryClass objCategory)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Category SET Category_ShowHome=@Category_ShowHome WHERE Category_ID=@Category_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("Category_ID", objCategory.iID);
			objCommand.Parameters.AddWithValue("Category_ShowHome", objCategory.bShowHome);

			if (objCommand.ExecuteNonQuery() > 0)
			{
				return "SUCCESS : Record has been updated successfully!";
			}
			else
			{
				return "ERROR : SQL Exception";
			}
		}
		catch (Exception ex)
		{
				return "ERROR : " + ex.Message;
			}
			finally
			{
				if (objConnection != null)
			{
				objConnection.Close();
			}
		}
	}

}
