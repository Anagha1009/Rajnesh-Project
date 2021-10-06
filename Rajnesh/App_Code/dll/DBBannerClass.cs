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
/// Summary description for DBBannerClass
/// </summary>
public class DBBannerClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveBanner(BannerClass objBanner)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_Banners (Banner_Title, Banner_Details, Banner_TargetUrl, Banner_Photo) VALUES (@Banner_Title, @Banner_Details, @Banner_TargetUrl, @Banner_Photo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Banner_Title", objBanner.strTitle);
			objCommand.Parameters.AddWithValue("@Banner_Details", objBanner.strDetails);
			objCommand.Parameters.AddWithValue("@Banner_TargetUrl", objBanner.strTargetUrl);
			objCommand.Parameters.AddWithValue("@Banner_Photo", objBanner.strPhoto);

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

	public string fn_editBanner(BannerClass objBanner)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Banners SET Banner_Title=@Banner_Title, Banner_Details=@Banner_Details, Banner_TargetUrl=@Banner_TargetUrl, Banner_Photo=@Banner_Photo WHERE Banner_ID=@Banner_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Banner_ID", objBanner.iID);
			objCommand.Parameters.AddWithValue("@Banner_Title", objBanner.strTitle);
			objCommand.Parameters.AddWithValue("@Banner_Details", objBanner.strDetails);
			objCommand.Parameters.AddWithValue("@Banner_TargetUrl", objBanner.strTargetUrl);
			objCommand.Parameters.AddWithValue("@Banner_Photo", objBanner.strPhoto);

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

	public string fn_deleteBanner(int iBannerID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Banners WHERE Banner_ID=@Banner_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Banner_ID", iBannerID);

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

	public CoreWebList<BannerClass> fn_getBannerList()
	{
		CoreWebList<BannerClass> objBannerList = null;
		BannerClass objBanner = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Banners", objConnection);
			objReader = objCommand.ExecuteReader();
			objBannerList = new CoreWebList<BannerClass>();
			while (objReader.Read())
			{
				objBanner = new BannerClass();
				objBanner.iID = int.Parse(objReader["Banner_ID"].ToString());
				objBanner.strTitle = objReader["Banner_Title"].ToString();
				objBanner.strDetails = objReader["Banner_Details"].ToString();
				objBanner.strTargetUrl = objReader["Banner_TargetUrl"].ToString();
				objBanner.strPhoto = objReader["Banner_Photo"].ToString();
				objBannerList.Add(objBanner);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBannerList;
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

	public CoreWebList<BannerClass> fn_getBannerByID(int iBannerID)
	{
		CoreWebList<BannerClass> objBannerList = null;
		BannerClass objBanner = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Banners Bnr join tbl_BannerDetails Det on Bnr.Banner_ID=Det.BannerDetail_BannerID WHERE Bnr.Banner_ID=@Banner_ID ORDER BY Det.BannerDetail_Order ASC", objConnection);
			objCommand.Parameters.AddWithValue("@Banner_ID", iBannerID);
			objReader = objCommand.ExecuteReader();
			objBannerList = new CoreWebList<BannerClass>();
			while (objReader.Read())
			{
                objBanner = new BannerClass();
                objBanner.iID = int.Parse(objReader["Banner_ID"].ToString());
                objBanner.iOrderID = int.Parse(objReader["BannerDetail_Order"].ToString());

                objBanner.strDetailTitle = objReader["BannerDetail_Title"].ToString();
                objBanner.strDetailDesc = objReader["BannerDetail_Details"].ToString();
                objBanner.strDetailLink = objReader["BannerDetail_Link"].ToString();
                objBanner.strDetailPhoto = objReader["BannerDetail_Photo"].ToString();

                objBanner.strTitle = objReader["Banner_Title"].ToString();
                objBanner.strDetails = objReader["Banner_Details"].ToString();
                objBanner.strTargetUrl = objReader["Banner_TargetUrl"].ToString();
                objBanner.strPhoto = objReader["Banner_Photo"].ToString();
                objBannerList.Add(objBanner);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBannerList;
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

	public CoreWebList<BannerClass> fn_getBannerByName(string strBannerTitle)
	{
		CoreWebList<BannerClass> objBannerList = null;
		BannerClass objBanner = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Banners Bnr join tbl_BannerDetails Det on Bnr.Banner_ID=Det.BannerDetail_BannerID WHERE Bnr.Banner_Title=@Banner_Title ORDER BY Det.BannerDetail_Order ASC", objConnection);
			objCommand.Parameters.AddWithValue("@Banner_Title", strBannerTitle);
			objReader = objCommand.ExecuteReader();
			objBannerList = new CoreWebList<BannerClass>();
			while (objReader.Read())
			{
                objBanner = new BannerClass();
                objBanner.iID = int.Parse(objReader["Banner_ID"].ToString());
                objBanner.iOrderID = int.Parse(objReader["BannerDetail_Order"].ToString());

                objBanner.strDetailTitle = objReader["BannerDetail_Title"].ToString();
                objBanner.strDetailDesc = objReader["BannerDetail_Details"].ToString();
                objBanner.strDetailLink = objReader["BannerDetail_Link"].ToString();
                objBanner.strDetailPhoto = objReader["BannerDetail_Photo"].ToString();

                objBanner.strTitle = objReader["Banner_Title"].ToString();
                objBanner.strDetails = objReader["Banner_Details"].ToString();
                objBanner.strTargetUrl = objReader["Banner_TargetUrl"].ToString();
                objBanner.strPhoto = objReader["Banner_Photo"].ToString();
                objBannerList.Add(objBanner);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBannerList;
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

    public CoreWebList<BannerClass> fn_getBannerByTargetUrl(string strTargetUrl)
    {
        CoreWebList<BannerClass> objBannerList = null;
        BannerClass objBanner = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Banners Bnr join tbl_BannerDetails Det on Bnr.Banner_ID=Det.BannerDetail_BannerID WHERE Bnr.Banner_TargetUrl=@Banner_TargetUrl ORDER BY Det.BannerDetail_Order ASC", objConnection);
            objCommand.Parameters.AddWithValue("@Banner_TargetUrl", strTargetUrl);
            objReader = objCommand.ExecuteReader();
            objBannerList = new CoreWebList<BannerClass>();
            while (objReader.Read())
            {
                objBanner = new BannerClass();
                objBanner.iID = int.Parse(objReader["Banner_ID"].ToString());
                objBanner.iOrderID = int.Parse(objReader["BannerDetail_Order"].ToString());

                objBanner.strDetailTitle = objReader["BannerDetail_Title"].ToString();
                objBanner.strDetailDesc = objReader["BannerDetail_Details"].ToString();
                objBanner.strDetailLink = objReader["BannerDetail_Link"].ToString();
                objBanner.strDetailPhoto = objReader["BannerDetail_Photo"].ToString();

                objBanner.strTitle = objReader["Banner_Title"].ToString();
                objBanner.strDetails = objReader["Banner_Details"].ToString();
                objBanner.strTargetUrl = objReader["Banner_TargetUrl"].ToString();
                objBanner.strPhoto = objReader["Banner_Photo"].ToString();
                objBannerList.Add(objBanner);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objBannerList;
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

	public CoreWebList<BannerClass> fn_getBannerByKeys(string strBannerTitle)
	{
		CoreWebList<BannerClass> objBannerList = null;
		BannerClass objBanner = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Banners WHERE Banner_Title like '%' + @Banner_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Banner_Title", strBannerTitle);
			objReader = objCommand.ExecuteReader();
			objBannerList = new CoreWebList<BannerClass>();
			while (objReader.Read())
			{
				objBanner = new BannerClass();
				objBanner.iID = int.Parse(objReader["Banner_ID"].ToString());
				objBanner.strTitle = objReader["Banner_Title"].ToString();
				objBanner.strDetails = objReader["Banner_Details"].ToString();
				objBanner.strTargetUrl = objReader["Banner_TargetUrl"].ToString();
				objBanner.strPhoto = objReader["Banner_Photo"].ToString();
				objBannerList.Add(objBanner);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objBannerList;
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
