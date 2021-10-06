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
/// Summary description for DBFacultyClass
/// </summary>
public class DBFacultyClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

	public string fn_saveFaculty(FacultyClass objFaculty)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO edu_Faculty (Faculty_UniversityID, Faculty_Name, Faculty_Dept, Faculty_Designation, Faculty_Profile, Faculty_Photo) VALUES (@Faculty_UniversityID, @Faculty_Name, @Faculty_Dept, @Faculty_Designation, @Faculty_Profile, @Faculty_Photo)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Faculty_UniversityID", objFaculty.iUniversityID);
			objCommand.Parameters.AddWithValue("@Faculty_Name", objFaculty.strFacultyName);
			objCommand.Parameters.AddWithValue("@Faculty_Dept", objFaculty.strFacultyDept);
			objCommand.Parameters.AddWithValue("@Faculty_Designation", objFaculty.strFacultyDesignation);
			objCommand.Parameters.AddWithValue("@Faculty_Profile", objFaculty.strFacultyProfile);
			objCommand.Parameters.AddWithValue("@Faculty_Photo", objFaculty.strFacultyPhoto);

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

	public string fn_editFaculty(FacultyClass objFaculty)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE edu_Faculty SET Faculty_UniversityID=@Faculty_UniversityID, Faculty_Name=@Faculty_Name, Faculty_Dept=@Faculty_Dept, Faculty_Designation=@Faculty_Designation, Faculty_Profile=@Faculty_Profile, Faculty_Photo=@Faculty_Photo WHERE Faculty_ID=@Faculty_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Faculty_ID", objFaculty.iID);
			objCommand.Parameters.AddWithValue("@Faculty_UniversityID", objFaculty.iUniversityID);
			objCommand.Parameters.AddWithValue("@Faculty_Name", objFaculty.strFacultyName);
			objCommand.Parameters.AddWithValue("@Faculty_Dept", objFaculty.strFacultyDept);
			objCommand.Parameters.AddWithValue("@Faculty_Designation", objFaculty.strFacultyDesignation);
			objCommand.Parameters.AddWithValue("@Faculty_Profile", objFaculty.strFacultyProfile);
			objCommand.Parameters.AddWithValue("@Faculty_Photo", objFaculty.strFacultyPhoto);

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

	public string fn_deleteFaculty(int iFacultyID)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM edu_Faculty WHERE Faculty_ID=@Faculty_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Faculty_ID", iFacultyID);

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

	public CoreWebList<FacultyClass> fn_getFacultyList()
	{
		CoreWebList<FacultyClass> objFacultyList = null;
		FacultyClass objFaculty = null;
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM edu_Faculty", objConnection);
			objReader = objCommand.ExecuteReader();
			objFacultyList = new CoreWebList<FacultyClass>();
			while (objReader.Read())
			{
				objFaculty = new FacultyClass();
				objFaculty.iID = int.Parse(objReader["Faculty_ID"].ToString());
				objFaculty.iUniversityID = int.Parse(objReader["Faculty_UniversityID"].ToString());
				objFaculty.strFacultyName = objReader["Faculty_Name"].ToString();
				objFaculty.strFacultyDept = objReader["Faculty_Dept"].ToString();
				objFaculty.strFacultyDesignation = objReader["Faculty_Designation"].ToString();
				objFaculty.strFacultyProfile = objReader["Faculty_Profile"].ToString();
				objFaculty.strFacultyPhoto = objReader["Faculty_Photo"].ToString();
				objFacultyList.Add(objFaculty);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objFacultyList;
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

	public CoreWebList<FacultyClass> fn_getFacultyByID(int iFacultyID)
	{
		CoreWebList<FacultyClass> objFacultyList = null;
		FacultyClass objFaculty = null;
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=Faculty_UniversityID) StudyCenter_UniversityName, * FROM edu_Faculty WHERE Faculty_ID=@Faculty_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Faculty_ID", iFacultyID);
			objReader = objCommand.ExecuteReader();
			objFacultyList = new CoreWebList<FacultyClass>();
			if (objReader.Read())
			{
				objFaculty = new FacultyClass();
				objFaculty.iID = int.Parse(objReader["Faculty_ID"].ToString());
				objFaculty.iUniversityID = int.Parse(objReader["Faculty_UniversityID"].ToString());
                objFaculty.strUniversityName = objReader["StudyCenter_UniversityName"].ToString();
				objFaculty.strFacultyName = objReader["Faculty_Name"].ToString();
				objFaculty.strFacultyDept = objReader["Faculty_Dept"].ToString();
				objFaculty.strFacultyDesignation = objReader["Faculty_Designation"].ToString();
				objFaculty.strFacultyProfile = objReader["Faculty_Profile"].ToString();
				objFaculty.strFacultyPhoto = objReader["Faculty_Photo"].ToString();
				objFacultyList.Add(objFaculty);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objFacultyList;
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

    public CoreWebList<FacultyClass> fn_getFacultyByName(string strFaculty)
    {
        CoreWebList<FacultyClass> objFacultyList = null;
        FacultyClass objFaculty = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=Faculty_UniversityID) StudyCenter_UniversityName, * FROM edu_Faculty WHERE Faculty_Name=@Faculty_Name", objConnection);
            objCommand.Parameters.AddWithValue("@Faculty_Name", strFaculty);
            objReader = objCommand.ExecuteReader();
            objFacultyList = new CoreWebList<FacultyClass>();
            if (objReader.Read())
            {
                objFaculty = new FacultyClass();
                objFaculty.iID = int.Parse(objReader["Faculty_ID"].ToString());
                objFaculty.iUniversityID = int.Parse(objReader["Faculty_UniversityID"].ToString());
                objFaculty.strUniversityName = objReader["StudyCenter_UniversityName"].ToString();
                objFaculty.strFacultyName = objReader["Faculty_Name"].ToString();
                objFaculty.strFacultyDept = objReader["Faculty_Dept"].ToString();
                objFaculty.strFacultyDesignation = objReader["Faculty_Designation"].ToString();
                objFaculty.strFacultyProfile = objReader["Faculty_Profile"].ToString();
                objFaculty.strFacultyPhoto = objReader["Faculty_Photo"].ToString();
                objFacultyList.Add(objFaculty);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objFacultyList;
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

    public CoreWebList<FacultyClass> fn_getFacultyByUniversityID(int iUniversityID)
    {
        CoreWebList<FacultyClass> objFacultyList = null;
        FacultyClass objFaculty = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=Faculty_UniversityID) StudyCenter_UniversityName, * FROM edu_Faculty WHERE Faculty_UniversityID=@Faculty_UniversityID", objConnection);
            objCommand.Parameters.AddWithValue("@Faculty_UniversityID", iUniversityID);
            objReader = objCommand.ExecuteReader();
            objFacultyList = new CoreWebList<FacultyClass>();
            while (objReader.Read())
            {
                objFaculty = new FacultyClass();
                objFaculty.iID = int.Parse(objReader["Faculty_ID"].ToString());
                objFaculty.iUniversityID = int.Parse(objReader["Faculty_UniversityID"].ToString());
                objFaculty.strUniversityName = objReader["StudyCenter_UniversityName"].ToString();
                objFaculty.strFacultyName = objReader["Faculty_Name"].ToString();
                objFaculty.strFacultyDept = objReader["Faculty_Dept"].ToString();
                objFaculty.strFacultyDesignation = objReader["Faculty_Designation"].ToString();
                objFaculty.strFacultyProfile = objReader["Faculty_Profile"].ToString();
                objFaculty.strFacultyPhoto = objReader["Faculty_Photo"].ToString();
                objFacultyList.Add(objFaculty);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objFacultyList;
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

    public CoreWebList<FacultyClass> fn_getFacultyByKeys(string strFaculty)
    {
        CoreWebList<FacultyClass> objFacultyList = null;
        FacultyClass objFaculty = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM edu_Faculty WHERE Faculty_Name like '%' + @Faculty_Name + '%'", objConnection);
            objCommand.Parameters.AddWithValue("@Faculty_Name", strFaculty);
            objReader = objCommand.ExecuteReader();
            objFacultyList = new CoreWebList<FacultyClass>();
            while (objReader.Read())
            {
                objFaculty = new FacultyClass();
                objFaculty.iID = int.Parse(objReader["Faculty_ID"].ToString());
                objFaculty.iUniversityID = int.Parse(objReader["Faculty_UniversityID"].ToString());
                objFaculty.strFacultyName = objReader["Faculty_Name"].ToString();
                objFaculty.strFacultyDept = objReader["Faculty_Dept"].ToString();
                objFaculty.strFacultyDesignation = objReader["Faculty_Designation"].ToString();
                objFaculty.strFacultyProfile = objReader["Faculty_Profile"].ToString();
                objFaculty.strFacultyPhoto = objReader["Faculty_Photo"].ToString();
                objFacultyList.Add(objFaculty);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objFacultyList;
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
