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
/// Summary description for DBEduReviewDetailClass
/// </summary>
public class DBEduReviewDetailClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveEduReviewDetail(EduReviewDetailClass objEduReviewDetail)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_EduReviewDetails (EduReviewDetail_ReviewID, EduReviewDetail_FactorID, EduReviewDetail_FactorValue) VALUES (@EduReviewDetail_ReviewID, @EduReviewDetail_FactorID, @EduReviewDetail_FactorValue)",objConnection) ;
			objCommand.Parameters.AddWithValue("@EduReviewDetail_ReviewID", objEduReviewDetail.iReviewID);
			objCommand.Parameters.AddWithValue("@EduReviewDetail_FactorID", objEduReviewDetail.iFactorID);
			objCommand.Parameters.AddWithValue("@EduReviewDetail_FactorValue", objEduReviewDetail.iFactorValue);

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

	public string fn_editEduReviewDetail(EduReviewDetailClass objEduReviewDetail)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_EduReviewDetails SET EduReviewDetail_ReviewID=@EduReviewDetail_ReviewID, EduReviewDetail_FactorID=@EduReviewDetail_FactorID, EduReviewDetail_FactorValue=@EduReviewDetail_FactorValue WHERE EduReviewDetail_ID=@EduReviewDetail_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@EduReviewDetail_ID", objEduReviewDetail.iID);
			objCommand.Parameters.AddWithValue("@EduReviewDetail_FactorID", objEduReviewDetail.iFactorID);
			objCommand.Parameters.AddWithValue("@EduReviewDetail_FactorValue", objEduReviewDetail.iFactorValue);

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

	public string fn_deleteEduReviewDetail(int iEduReviewDetailID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_EduReviewDetails WHERE EduReviewDetail_ID=@EduReviewDetail_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@EduReviewDetail_ID", iEduReviewDetailID);

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

	public CoreWebList<EduReviewDetailClass> fn_getEduReviewDetailList()
	{
		CoreWebList<EduReviewDetailClass> objEduReviewDetailList = null;
		EduReviewDetailClass objEduReviewDetail = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EduReviewDetails", objConnection);
			objReader = objCommand.ExecuteReader();
			objEduReviewDetailList = new CoreWebList<EduReviewDetailClass>();
			while (objReader.Read())
			{
				objEduReviewDetail = new EduReviewDetailClass();
				objEduReviewDetail.iID = int.Parse(objReader["EduReviewDetail_ID"].ToString());
				objEduReviewDetail.iReviewID = int.Parse(objReader["EduReviewDetail_ReviewID"].ToString());
				objEduReviewDetail.iFactorID = int.Parse(objReader["EduReviewDetail_FactorID"].ToString());
				objEduReviewDetail.iFactorValue = int.Parse(objReader["EduReviewDetail_FactorValue"].ToString());
				objEduReviewDetailList.Add(objEduReviewDetail);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEduReviewDetailList;
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

	public CoreWebList<EduReviewDetailClass> fn_getEduReviewDetailByID(int iEduReviewDetailID)
	{
		CoreWebList<EduReviewDetailClass> objEduReviewDetailList = null;
		EduReviewDetailClass objEduReviewDetail = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EduReviewDetails WHERE EduReviewDetail_ID=@EduReviewDetail_ID", objConnection);
			objCommand.Parameters.AddWithValue("@EduReviewDetail_ID", iEduReviewDetailID);
			objReader = objCommand.ExecuteReader();
			objEduReviewDetailList = new CoreWebList<EduReviewDetailClass>();
			if (objReader.Read())
			{
				objEduReviewDetail = new EduReviewDetailClass();
				objEduReviewDetail.iID = int.Parse(objReader["EduReviewDetail_ID"].ToString());
				objEduReviewDetail.iReviewID = int.Parse(objReader["EduReviewDetail_ReviewID"].ToString());
				objEduReviewDetail.iFactorID = int.Parse(objReader["EduReviewDetail_FactorID"].ToString());
				objEduReviewDetail.iFactorValue = int.Parse(objReader["EduReviewDetail_FactorValue"].ToString());
				objEduReviewDetailList.Add(objEduReviewDetail);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEduReviewDetailList;
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

	public CoreWebList<EduReviewDetailClass> fn_getEduReviewDetailByReviewID(int iReviewID)
	{
		CoreWebList<EduReviewDetailClass> objEduReviewDetailList = null;
		EduReviewDetailClass objEduReviewDetail = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EduReviewDetails WHERE EduReviewDetail_ReviewID=@EduReviewDetail_ReviewID", objConnection);
			objCommand.Parameters.AddWithValue("@EduReviewDetail_ReviewID", iReviewID);
			objReader = objCommand.ExecuteReader();
			objEduReviewDetailList = new CoreWebList<EduReviewDetailClass>();
			while (objReader.Read())
			{
				objEduReviewDetail = new EduReviewDetailClass();
				objEduReviewDetail.iID = int.Parse(objReader["EduReviewDetail_ID"].ToString());
				objEduReviewDetail.iReviewID = int.Parse(objReader["EduReviewDetail_ReviewID"].ToString());
				objEduReviewDetail.iFactorID = int.Parse(objReader["EduReviewDetail_FactorID"].ToString());
				objEduReviewDetail.iFactorValue = int.Parse(objReader["EduReviewDetail_FactorValue"].ToString());
				objEduReviewDetailList.Add(objEduReviewDetail);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEduReviewDetailList;
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

	public CoreWebList<EduReviewDetailClass> fn_getEduReviewDetailByFactorID(int iFactorID)
	{
		CoreWebList<EduReviewDetailClass> objEduReviewDetailList = null;
		EduReviewDetailClass objEduReviewDetail = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_EduReviewDetails WHERE EduReviewDetail_FactorID=@EduReviewDetail_FactorID", objConnection);
			objCommand.Parameters.AddWithValue("@EduReviewDetail_FactorID", iFactorID);
			objReader = objCommand.ExecuteReader();
			objEduReviewDetailList = new CoreWebList<EduReviewDetailClass>();
			while (objReader.Read())
			{
				objEduReviewDetail = new EduReviewDetailClass();
				objEduReviewDetail.iID = int.Parse(objReader["EduReviewDetail_ID"].ToString());
				objEduReviewDetail.iReviewID = int.Parse(objReader["EduReviewDetail_ReviewID"].ToString());
				objEduReviewDetail.iFactorID = int.Parse(objReader["EduReviewDetail_FactorID"].ToString());
				objEduReviewDetail.iFactorValue = int.Parse(objReader["EduReviewDetail_FactorValue"].ToString());
				objEduReviewDetailList.Add(objEduReviewDetail);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objEduReviewDetailList;
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

    public CoreWebList<EduReviewDetailClass> fn_getEduReviewDetailByFactorHeadingID(int iReviewID, int iFactorHeadingID)
    {
        CoreWebList<EduReviewDetailClass> objEduReviewDetailList = null;
        EduReviewDetailClass objEduReviewDetail = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT Fact.Factor_Title, Det.* FROM tbl_EduReviewDetails Det join tbl_Factors Fact on Det.EduReviewDetail_FactorID=Fact.Factor_ID WHERE Det.EduReviewDetail_ReviewID=@EduReviewDetail_ReviewID AND Fact.Factor_HeadingID=@Factor_HeadingID", objConnection);
            objCommand.Parameters.AddWithValue("@EduReviewDetail_ReviewID", iReviewID);
            objCommand.Parameters.AddWithValue("@Factor_HeadingID", iFactorHeadingID);
            objReader = objCommand.ExecuteReader();
            objEduReviewDetailList = new CoreWebList<EduReviewDetailClass>();
            while (objReader.Read())
            {
                objEduReviewDetail = new EduReviewDetailClass();
                objEduReviewDetail.iID = int.Parse(objReader["EduReviewDetail_ID"].ToString());
                objEduReviewDetail.strFactor = objReader["Factor_Title"].ToString();
                objEduReviewDetail.iReviewID = int.Parse(objReader["EduReviewDetail_ReviewID"].ToString());
                objEduReviewDetail.iFactorID = int.Parse(objReader["EduReviewDetail_FactorID"].ToString());
                objEduReviewDetail.iFactorValue = int.Parse(objReader["EduReviewDetail_FactorValue"].ToString());
                objEduReviewDetailList.Add(objEduReviewDetail);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objEduReviewDetailList;
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
