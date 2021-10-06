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
/// Summary description for DBBannerDetailClass
/// </summary>
public class DBBannerDetailClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveBannerDetail(BannerDetailClass objBannerDetail)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_BannerDetails (BannerDetail_BannerID, BannerDetail_Order, BannerDetail_Title, BannerDetail_Details, BannerDetail_Link, BannerDetail_Photo) VALUES (@BannerDetail_BannerID, @BannerDetail_Order, @BannerDetail_Title, @BannerDetail_Details, @BannerDetail_Link, @BannerDetail_Photo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@BannerDetail_BannerID", objBannerDetail.iBannerID);
			objCommand.Parameters.AddWithValue("@BannerDetail_Order", objBannerDetail.iOrder);
			objCommand.Parameters.AddWithValue("@BannerDetail_Title", objBannerDetail.strTitle);
			objCommand.Parameters.AddWithValue("@BannerDetail_Details", objBannerDetail.strDetails);
			objCommand.Parameters.AddWithValue("@BannerDetail_Link", objBannerDetail.strLink);
			objCommand.Parameters.AddWithValue("@BannerDetail_Photo", objBannerDetail.strPhoto);

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

	public string fn_editBannerDetail(BannerDetailClass objBannerDetail)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_BannerDetails SET BannerDetail_Order=@BannerDetail_Order, BannerDetail_Title=@BannerDetail_Title, BannerDetail_Details=@BannerDetail_Details, BannerDetail_Link=@BannerDetail_Link, BannerDetail_Photo=@BannerDetail_Photo WHERE BannerDetail_ID=@BannerDetail_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@BannerDetail_ID", objBannerDetail.iID);
            objCommand.Parameters.AddWithValue("@BannerDetail_Order", objBannerDetail.iOrder);
            objCommand.Parameters.AddWithValue("@BannerDetail_Title", objBannerDetail.strTitle);
            objCommand.Parameters.AddWithValue("@BannerDetail_Details", objBannerDetail.strDetails);
            objCommand.Parameters.AddWithValue("@BannerDetail_Link", objBannerDetail.strLink);
            objCommand.Parameters.AddWithValue("@BannerDetail_Photo", objBannerDetail.strPhoto);

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

	public string fn_deleteBannerDetail(int iBannerDetailID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_BannerDetails WHERE BannerDetail_ID=@BannerDetail_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@BannerDetail_ID", iBannerDetailID);

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

	public CoreWebList<BannerDetailClass> fn_getBannerDetailList()
	{
		CoreWebList<BannerDetailClass> objBannerDetailList = null;
		BannerDetailClass objBannerDetail = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_BannerDetails", objConnection);
			objReader = objCommand.ExecuteReader();
			objBannerDetailList = new CoreWebList<BannerDetailClass>();
			while (objReader.Read())
			{
				objBannerDetail = new BannerDetailClass();
				objBannerDetail.iID = int.Parse(objReader["BannerDetail_ID"].ToString());
				objBannerDetail.iBannerID = int.Parse(objReader["BannerDetail_BannerID"].ToString());
				objBannerDetail.iOrder = int.Parse(objReader["BannerDetail_Order"].ToString());
				objBannerDetail.strTitle = objReader["BannerDetail_Title"].ToString();
				objBannerDetail.strDetails = objReader["BannerDetail_Details"].ToString();
				objBannerDetail.strLink = objReader["BannerDetail_Link"].ToString();
				objBannerDetail.strPhoto = objReader["BannerDetail_Photo"].ToString();
				objBannerDetailList.Add(objBannerDetail);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBannerDetailList;
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

	public CoreWebList<BannerDetailClass> fn_getBannerDetailByID(int iBannerDetailID)
	{
		CoreWebList<BannerDetailClass> objBannerDetailList = null;
		BannerDetailClass objBannerDetail = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_BannerDetails WHERE BannerDetail_ID=@BannerDetail_ID", objConnection);
			objCommand.Parameters.AddWithValue("@BannerDetail_ID", iBannerDetailID);
			objReader = objCommand.ExecuteReader();
			objBannerDetailList = new CoreWebList<BannerDetailClass>();
			if (objReader.Read())
			{
				objBannerDetail = new BannerDetailClass();
				objBannerDetail.iID = int.Parse(objReader["BannerDetail_ID"].ToString());
				objBannerDetail.iBannerID = int.Parse(objReader["BannerDetail_BannerID"].ToString());
				objBannerDetail.iOrder = int.Parse(objReader["BannerDetail_Order"].ToString());
				objBannerDetail.strTitle = objReader["BannerDetail_Title"].ToString();
				objBannerDetail.strDetails = objReader["BannerDetail_Details"].ToString();
				objBannerDetail.strLink = objReader["BannerDetail_Link"].ToString();
				objBannerDetail.strPhoto = objReader["BannerDetail_Photo"].ToString();
				objBannerDetailList.Add(objBannerDetail);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBannerDetailList;
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

	public CoreWebList<BannerDetailClass> fn_getBannerDetailByName(string strBannerDetailTitle)
	{
		CoreWebList<BannerDetailClass> objBannerDetailList = null;
		BannerDetailClass objBannerDetail = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_BannerDetails WHERE BannerDetail_Title=@BannerDetail_Title", objConnection);
			objCommand.Parameters.AddWithValue("@BannerDetail_Title", strBannerDetailTitle);
			objReader = objCommand.ExecuteReader();
			objBannerDetailList = new CoreWebList<BannerDetailClass>();
			if (objReader.Read())
			{
				objBannerDetail = new BannerDetailClass();
				objBannerDetail.iID = int.Parse(objReader["BannerDetail_ID"].ToString());
				objBannerDetail.iBannerID = int.Parse(objReader["BannerDetail_BannerID"].ToString());
				objBannerDetail.iOrder = int.Parse(objReader["BannerDetail_Order"].ToString());
				objBannerDetail.strTitle = objReader["BannerDetail_Title"].ToString();
				objBannerDetail.strDetails = objReader["BannerDetail_Details"].ToString();
				objBannerDetail.strLink = objReader["BannerDetail_Link"].ToString();
				objBannerDetail.strPhoto = objReader["BannerDetail_Photo"].ToString();
				objBannerDetailList.Add(objBannerDetail);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBannerDetailList;
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

	public CoreWebList<BannerDetailClass> fn_getBannerDetailByKeys(string strBannerDetailTitle)
	{
		CoreWebList<BannerDetailClass> objBannerDetailList = null;
		BannerDetailClass objBannerDetail = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_BannerDetails WHERE BannerDetail_Title like '%' + @BannerDetail_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@BannerDetail_Title", strBannerDetailTitle);
			objReader = objCommand.ExecuteReader();
			objBannerDetailList = new CoreWebList<BannerDetailClass>();
			while (objReader.Read())
			{
				objBannerDetail = new BannerDetailClass();
				objBannerDetail.iID = int.Parse(objReader["BannerDetail_ID"].ToString());
				objBannerDetail.iBannerID = int.Parse(objReader["BannerDetail_BannerID"].ToString());
				objBannerDetail.iOrder = int.Parse(objReader["BannerDetail_Order"].ToString());
				objBannerDetail.strTitle = objReader["BannerDetail_Title"].ToString();
				objBannerDetail.strDetails = objReader["BannerDetail_Details"].ToString();
				objBannerDetail.strLink = objReader["BannerDetail_Link"].ToString();
				objBannerDetail.strPhoto = objReader["BannerDetail_Photo"].ToString();
				objBannerDetailList.Add(objBannerDetail);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBannerDetailList;
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

	public CoreWebList<BannerDetailClass> fn_getBannerDetailByBannerID(int iBannerID)
	{
		CoreWebList<BannerDetailClass> objBannerDetailList = null;
		BannerDetailClass objBannerDetail = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_BannerDetails WHERE BannerDetail_BannerID=@BannerDetail_BannerID", objConnection);
			objCommand.Parameters.AddWithValue("@BannerDetail_BannerID", iBannerID);
			objReader = objCommand.ExecuteReader();
			objBannerDetailList = new CoreWebList<BannerDetailClass>();
			while (objReader.Read())
			{
				objBannerDetail = new BannerDetailClass();
				objBannerDetail.iID = int.Parse(objReader["BannerDetail_ID"].ToString());
				objBannerDetail.iBannerID = int.Parse(objReader["BannerDetail_BannerID"].ToString());
				objBannerDetail.iOrder = int.Parse(objReader["BannerDetail_Order"].ToString());
				objBannerDetail.strTitle = objReader["BannerDetail_Title"].ToString();
				objBannerDetail.strDetails = objReader["BannerDetail_Details"].ToString();
				objBannerDetail.strLink = objReader["BannerDetail_Link"].ToString();
				objBannerDetail.strPhoto = objReader["BannerDetail_Photo"].ToString();
				objBannerDetailList.Add(objBannerDetail);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBannerDetailList;
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
