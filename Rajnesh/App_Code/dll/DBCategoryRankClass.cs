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
/// Summary description for DBCategoryRankClass
/// </summary>
public class DBCategoryRankClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveCategoryRank(CategoryRankClass objCategoryRank)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_CategoryRankings (CategoryRank_InstituteID, CategoryRank_CategoryID, CategoryRank_Rank) VALUES (@CategoryRank_InstituteID, @CategoryRank_CategoryID, @CategoryRank_Rank)",objConnection) ;
			objCommand.Parameters.AddWithValue("@CategoryRank_InstituteID", objCategoryRank.iInstituteID);
			objCommand.Parameters.AddWithValue("@CategoryRank_CategoryID", objCategoryRank.iCategoryID);
			objCommand.Parameters.AddWithValue("@CategoryRank_Rank", objCategoryRank.iRank);

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

	public string fn_editCategoryRank(CategoryRankClass objCategoryRank)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_CategoryRankings SET CategoryRank_CategoryID=@CategoryRank_CategoryID, CategoryRank_Rank=@CategoryRank_Rank WHERE CategoryRank_ID=@CategoryRank_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CategoryRank_ID", objCategoryRank.iID);
			objCommand.Parameters.AddWithValue("@CategoryRank_CategoryID", objCategoryRank.iCategoryID);
			objCommand.Parameters.AddWithValue("@CategoryRank_Rank", objCategoryRank.iRank);

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

	public string fn_deleteCategoryRank(int iCategoryRankID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_CategoryRankings WHERE CategoryRank_ID=@CategoryRank_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@CategoryRank_ID", iCategoryRankID);

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

	public CoreWebList<CategoryRankClass> fn_getCategoryRankList()
	{
		CoreWebList<CategoryRankClass> objCategoryRankList = null;
		CategoryRankClass objCategoryRank = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CategoryRankings", objConnection);
			objReader = objCommand.ExecuteReader();
			objCategoryRankList = new CoreWebList<CategoryRankClass>();
			while (objReader.Read())
			{
				objCategoryRank = new CategoryRankClass();
				objCategoryRank.iID = int.Parse(objReader["CategoryRank_ID"].ToString());
				objCategoryRank.iInstituteID = int.Parse(objReader["CategoryRank_InstituteID"].ToString());
				objCategoryRank.iCategoryID = int.Parse(objReader["CategoryRank_CategoryID"].ToString());
				objCategoryRank.iRank = int.Parse(objReader["CategoryRank_Rank"].ToString());
				objCategoryRankList.Add(objCategoryRank);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCategoryRankList;
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

	public CoreWebList<CategoryRankClass> fn_getCategoryRankByID(int iCategoryRankID)
	{
		CoreWebList<CategoryRankClass> objCategoryRankList = null;
		CategoryRankClass objCategoryRank = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CategoryRankings WHERE CategoryRank_ID=@CategoryRank_ID", objConnection);
			objCommand.Parameters.AddWithValue("@CategoryRank_ID", iCategoryRankID);
			objReader = objCommand.ExecuteReader();
			objCategoryRankList = new CoreWebList<CategoryRankClass>();
			if (objReader.Read())
			{
				objCategoryRank = new CategoryRankClass();
				objCategoryRank.iID = int.Parse(objReader["CategoryRank_ID"].ToString());
				objCategoryRank.iInstituteID = int.Parse(objReader["CategoryRank_InstituteID"].ToString());
				objCategoryRank.iCategoryID = int.Parse(objReader["CategoryRank_CategoryID"].ToString());
				objCategoryRank.iRank = int.Parse(objReader["CategoryRank_Rank"].ToString());
				objCategoryRankList.Add(objCategoryRank);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCategoryRankList;
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

	public CoreWebList<CategoryRankClass> fn_getCategoryRankByCategoryID(int iCategoryID)
	{
		CoreWebList<CategoryRankClass> objCategoryRankList = null;
		CategoryRankClass objCategoryRank = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_CategoryRankings WHERE CategoryRank_CategoryID=@CategoryRank_CategoryID", objConnection);
			objCommand.Parameters.AddWithValue("@CategoryRank_CategoryID", iCategoryID);
			objReader = objCommand.ExecuteReader();
			objCategoryRankList = new CoreWebList<CategoryRankClass>();
			while (objReader.Read())
			{
				objCategoryRank = new CategoryRankClass();
				objCategoryRank.iID = int.Parse(objReader["CategoryRank_ID"].ToString());
				objCategoryRank.iInstituteID = int.Parse(objReader["CategoryRank_InstituteID"].ToString());
				objCategoryRank.iCategoryID = int.Parse(objReader["CategoryRank_CategoryID"].ToString());
				objCategoryRank.iRank = int.Parse(objReader["CategoryRank_Rank"].ToString());
				objCategoryRankList.Add(objCategoryRank);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCategoryRankList;
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

	public CoreWebList<CategoryRankClass> fn_getCategoryRankByInstituteID(int iInstituteID)
	{
		CoreWebList<CategoryRankClass> objCategoryRankList = null;
		CategoryRankClass objCategoryRank = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT Institute_Title FROM dbo.tbl_Institutes inst WHERE inst.Institute_ID=rnk.CategoryRank_InstituteID)CategoryRank_Institute, (SELECT instituteCategory_title FROM dbo.edu_InstituteCategory cat WHERE cat.instituteCategory_id=rnk.CategoryRank_CategoryID)CategoryRank_Category, * FROM tbl_CategoryRankings rnk WHERE CategoryRank_InstituteID=@CategoryRank_InstituteID", objConnection);
			objCommand.Parameters.AddWithValue("@CategoryRank_InstituteID", iInstituteID);
			objReader = objCommand.ExecuteReader();
			objCategoryRankList = new CoreWebList<CategoryRankClass>();
			while (objReader.Read())
			{
				objCategoryRank = new CategoryRankClass();
				objCategoryRank.iID = int.Parse(objReader["CategoryRank_ID"].ToString());
				objCategoryRank.iInstituteID = int.Parse(objReader["CategoryRank_InstituteID"].ToString());
				objCategoryRank.iCategoryID = int.Parse(objReader["CategoryRank_CategoryID"].ToString());
				objCategoryRank.iRank = int.Parse(objReader["CategoryRank_Rank"].ToString());

                objCategoryRank.strInstitute = objReader["CategoryRank_Institute"].ToString();
                objCategoryRank.strCategory = objReader["CategoryRank_Category"].ToString();

				objCategoryRankList.Add(objCategoryRank);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCategoryRankList;
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

}
