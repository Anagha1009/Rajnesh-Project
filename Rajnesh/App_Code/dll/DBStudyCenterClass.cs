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
/// Summary description for DBStudyCenterClass
/// </summary>
public class DBStudyCenterClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

	public string fn_saveStudyCenter(StudyCenterClass objStudyCenter)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO edu_StudyCenter (StudyCenter_UniversityID, StudyCenter_Title, StudyCenter_Desc, StudyCenter_Addrs) VALUES (@StudyCenter_UniversityID, @StudyCenter_Title, @StudyCenter_Desc, @StudyCenter_Addrs)",objConnection) ;
			objCommand.Parameters.AddWithValue("@StudyCenter_UniversityID", objStudyCenter.iUniversityID);
			objCommand.Parameters.AddWithValue("@StudyCenter_Title", objStudyCenter.strStudyCenterTitle);
			objCommand.Parameters.AddWithValue("@StudyCenter_Desc", objStudyCenter.strStudyCenterDesc);
			objCommand.Parameters.AddWithValue("@StudyCenter_Addrs", objStudyCenter.strStudyCenterAddrs);

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

	public string fn_editStudyCenter(StudyCenterClass objStudyCenter)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE edu_StudyCenter SET StudyCenter_UniversityID=@StudyCenter_UniversityID, StudyCenter_Title=@StudyCenter_Title, StudyCenter_Desc=@StudyCenter_Desc, StudyCenter_Addrs=@StudyCenter_Addrs WHERE StudyCenter_ID=@StudyCenter_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@StudyCenter_ID", objStudyCenter.iID);
			objCommand.Parameters.AddWithValue("@StudyCenter_UniversityID", objStudyCenter.iUniversityID);
			objCommand.Parameters.AddWithValue("@StudyCenter_Title", objStudyCenter.strStudyCenterTitle);
			objCommand.Parameters.AddWithValue("@StudyCenter_Desc", objStudyCenter.strStudyCenterDesc);
			objCommand.Parameters.AddWithValue("@StudyCenter_Addrs", objStudyCenter.strStudyCenterAddrs);

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

	public string fn_deleteStudyCenter(int iStudyCenterID)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM edu_StudyCenter WHERE StudyCenter_ID=@StudyCenter_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@StudyCenter_ID", iStudyCenterID);

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

	public CoreWebList<StudyCenterClass> fn_getStudyCenterList()
	{
		CoreWebList<StudyCenterClass> objStudyCenterList = null;
		StudyCenterClass objStudyCenter = null;
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM edu_StudyCenter", objConnection);
			objReader = objCommand.ExecuteReader();
			objStudyCenterList = new CoreWebList<StudyCenterClass>();
			while (objReader.Read())
			{
				objStudyCenter = new StudyCenterClass();
				objStudyCenter.iID = int.Parse(objReader["StudyCenter_ID"].ToString());
				objStudyCenter.iUniversityID = int.Parse(objReader["StudyCenter_UniversityID"].ToString());
				objStudyCenter.strStudyCenterTitle = objReader["StudyCenter_Title"].ToString();
				objStudyCenter.strStudyCenterDesc = objReader["StudyCenter_Desc"].ToString();
				objStudyCenter.strStudyCenterAddrs = objReader["StudyCenter_Addrs"].ToString();
				objStudyCenterList.Add(objStudyCenter);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objStudyCenterList;
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

	public CoreWebList<StudyCenterClass> fn_getStudyCenterByID(int iStudyCenterID)
	{
		CoreWebList<StudyCenterClass> objStudyCenterList = null;
		StudyCenterClass objStudyCenter = null;
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=StudyCenter_UniversityID) StudyCenter_UniversityName, * FROM edu_StudyCenter WHERE StudyCenter_ID=@StudyCenter_ID", objConnection);
			objCommand.Parameters.AddWithValue("@StudyCenter_ID", iStudyCenterID);
			objReader = objCommand.ExecuteReader();
			objStudyCenterList = new CoreWebList<StudyCenterClass>();
			if (objReader.Read())
			{
				objStudyCenter = new StudyCenterClass();
				objStudyCenter.iID = int.Parse(objReader["StudyCenter_ID"].ToString());
				objStudyCenter.iUniversityID = int.Parse(objReader["StudyCenter_UniversityID"].ToString());
                objStudyCenter.strUniversityName = objReader["StudyCenter_UniversityName"].ToString();
				objStudyCenter.strStudyCenterTitle = objReader["StudyCenter_Title"].ToString();
				objStudyCenter.strStudyCenterDesc = objReader["StudyCenter_Desc"].ToString();
				objStudyCenter.strStudyCenterAddrs = objReader["StudyCenter_Addrs"].ToString();
				objStudyCenterList.Add(objStudyCenter);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objStudyCenterList;
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

    public CoreWebList<StudyCenterClass> fn_getStudyCenterByName(string strStudyCenter)
    {
        CoreWebList<StudyCenterClass> objStudyCenterList = null;
        StudyCenterClass objStudyCenter = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=StudyCenter_UniversityID) StudyCenter_UniversityName, * FROM edu_StudyCenter WHERE StudyCenter_Title=@StudyCenter_Title", objConnection);
            objCommand.Parameters.AddWithValue("@StudyCenter_Title", strStudyCenter);
            objReader = objCommand.ExecuteReader();
            objStudyCenterList = new CoreWebList<StudyCenterClass>();
            if (objReader.Read())
            {
                objStudyCenter = new StudyCenterClass();
                objStudyCenter.iID = int.Parse(objReader["StudyCenter_ID"].ToString());
                objStudyCenter.iUniversityID = int.Parse(objReader["StudyCenter_UniversityID"].ToString());
                objStudyCenter.strUniversityName = objReader["StudyCenter_UniversityName"].ToString();
                objStudyCenter.strStudyCenterTitle = objReader["StudyCenter_Title"].ToString();
                objStudyCenter.strStudyCenterDesc = objReader["StudyCenter_Desc"].ToString();
                objStudyCenter.strStudyCenterAddrs = objReader["StudyCenter_Addrs"].ToString();
                objStudyCenterList.Add(objStudyCenter);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objStudyCenterList;
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

    public CoreWebList<StudyCenterClass> fn_getStudyCenterByUniversityID(int iUniversityID)
    {
        CoreWebList<StudyCenterClass> objStudyCenterList = null;
        StudyCenterClass objStudyCenter = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=StudyCenter_UniversityID) StudyCenter_UniversityName, * FROM edu_StudyCenter WHERE StudyCenter_UniversityID=@StudyCenter_UniversityID", objConnection);
            objCommand.Parameters.AddWithValue("@StudyCenter_UniversityID", iUniversityID);
            objReader = objCommand.ExecuteReader();
            objStudyCenterList = new CoreWebList<StudyCenterClass>();
            while (objReader.Read())
            {
                objStudyCenter = new StudyCenterClass();
                objStudyCenter.iID = int.Parse(objReader["StudyCenter_ID"].ToString());
                objStudyCenter.iUniversityID = int.Parse(objReader["StudyCenter_UniversityID"].ToString());
                objStudyCenter.strUniversityName = objReader["StudyCenter_UniversityName"].ToString();
                objStudyCenter.strStudyCenterTitle = objReader["StudyCenter_Title"].ToString();
                objStudyCenter.strStudyCenterDesc = objReader["StudyCenter_Desc"].ToString();
                objStudyCenter.strStudyCenterAddrs = objReader["StudyCenter_Addrs"].ToString();
                objStudyCenterList.Add(objStudyCenter);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objStudyCenterList;
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

    public CoreWebList<StudyCenterClass> fn_getStudyCenterByKeys(string strKeys)
    {
        CoreWebList<StudyCenterClass> objStudyCenterList = null;
        StudyCenterClass objStudyCenter = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM edu_StudyCenter WHERE StudyCenter_Title like '%' + @StudyCenter_Title + '%'", objConnection);
            objCommand.Parameters.AddWithValue("@StudyCenter_Title", strKeys);
            objReader = objCommand.ExecuteReader();
            objStudyCenterList = new CoreWebList<StudyCenterClass>();
            while (objReader.Read())
            {
                objStudyCenter = new StudyCenterClass();
                objStudyCenter.iID = int.Parse(objReader["StudyCenter_ID"].ToString());
                objStudyCenter.iUniversityID = int.Parse(objReader["StudyCenter_UniversityID"].ToString());
                objStudyCenter.strStudyCenterTitle = objReader["StudyCenter_Title"].ToString();
                objStudyCenter.strStudyCenterDesc = objReader["StudyCenter_Desc"].ToString();
                objStudyCenter.strStudyCenterAddrs = objReader["StudyCenter_Addrs"].ToString();
                objStudyCenterList.Add(objStudyCenter);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objStudyCenterList;
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
