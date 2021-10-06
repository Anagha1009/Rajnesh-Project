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
/// Summary description for DBCourseClass
/// </summary>
public class DBCourseClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveCourse(CourseClass objCourse)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_Courses (Course_UniversityID, Course_ModeofStudyID, Course_LevelofStudyID, Course_Title, Course_Fees, Course_Details, Course_Eligibility, Course_AdmissionCriteria) VALUES (@Course_UniversityID, @Course_ModeofStudyID, @Course_LevelofStudyID, @Course_Title, @Course_Fees, @Course_Details, @Course_Eligibility, @Course_AdmissionCriteria)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Course_UniversityID", objCourse.iUniversityID);
			objCommand.Parameters.AddWithValue("@Course_ModeofStudyID", objCourse.iModeofStudyID);
			objCommand.Parameters.AddWithValue("@Course_LevelofStudyID", objCourse.iLevelofStudyID);
			objCommand.Parameters.AddWithValue("@Course_Title", objCourse.strTitle);
			objCommand.Parameters.AddWithValue("@Course_Fees", objCourse.strFees);
			objCommand.Parameters.AddWithValue("@Course_Details", objCourse.strDetails);
			objCommand.Parameters.AddWithValue("@Course_Eligibility", objCourse.strEligibility);
			objCommand.Parameters.AddWithValue("@Course_AdmissionCriteria", objCourse.strAdmissionCriteria);

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

	public string fn_editCourse(CourseClass objCourse)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_Courses SET Course_ModeofStudyID=@Course_ModeofStudyID, Course_LevelofStudyID=@Course_LevelofStudyID, Course_Title=@Course_Title, Course_Fees=@Course_Fees, Course_Details=@Course_Details, Course_Eligibility=@Course_Eligibility, Course_AdmissionCriteria=@Course_AdmissionCriteria WHERE Course_ID=@Course_ID",objConnection);
            objCommand.Parameters.AddWithValue("@Course_ID", objCourse.iID);
			objCommand.Parameters.AddWithValue("@Course_ModeofStudyID", objCourse.iModeofStudyID);
			objCommand.Parameters.AddWithValue("@Course_LevelofStudyID", objCourse.iLevelofStudyID);
			objCommand.Parameters.AddWithValue("@Course_Title", objCourse.strTitle);
			objCommand.Parameters.AddWithValue("@Course_Fees", objCourse.strFees);
			objCommand.Parameters.AddWithValue("@Course_Details", objCourse.strDetails);
			objCommand.Parameters.AddWithValue("@Course_Eligibility", objCourse.strEligibility);
			objCommand.Parameters.AddWithValue("@Course_AdmissionCriteria", objCourse.strAdmissionCriteria);

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

	public string fn_deleteCourse(int iCourseID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_Courses WHERE Course_ID=@Course_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Course_ID", iCourseID);

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

	public CoreWebList<CourseClass> fn_getCourseList()
	{
		CoreWebList<CourseClass> objCourseList = null;
		CourseClass objCourse = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Courses", objConnection);
			objReader = objCommand.ExecuteReader();
			objCourseList = new CoreWebList<CourseClass>();
			while (objReader.Read())
			{
				objCourse = new CourseClass();
				objCourse.iID = int.Parse(objReader["Course_ID"].ToString());
				objCourse.iUniversityID = int.Parse(objReader["Course_UniversityID"].ToString());
				objCourse.iModeofStudyID = int.Parse(objReader["Course_ModeofStudyID"].ToString());
				objCourse.iLevelofStudyID = int.Parse(objReader["Course_LevelofStudyID"].ToString());
				objCourse.strTitle = objReader["Course_Title"].ToString();
				objCourse.strFees = objReader["Course_Fees"].ToString();
				objCourse.strDetails = objReader["Course_Details"].ToString();
				objCourse.strEligibility = objReader["Course_Eligibility"].ToString();
				objCourse.strAdmissionCriteria = objReader["Course_AdmissionCriteria"].ToString();
				objCourseList.Add(objCourse);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCourseList;
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

	public CoreWebList<CourseClass> fn_getCourseByID(int iCourseID)
	{
		CoreWebList<CourseClass> objCourseList = null;
		CourseClass objCourse = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Courses WHERE Course_ID=@Course_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Course_ID", iCourseID);
			objReader = objCommand.ExecuteReader();
			objCourseList = new CoreWebList<CourseClass>();
			if (objReader.Read())
			{
				objCourse = new CourseClass();
				objCourse.iID = int.Parse(objReader["Course_ID"].ToString());
				objCourse.iUniversityID = int.Parse(objReader["Course_UniversityID"].ToString());
				objCourse.iModeofStudyID = int.Parse(objReader["Course_ModeofStudyID"].ToString());
				objCourse.iLevelofStudyID = int.Parse(objReader["Course_LevelofStudyID"].ToString());
				objCourse.strTitle = objReader["Course_Title"].ToString();
				objCourse.strFees = objReader["Course_Fees"].ToString();
				objCourse.strDetails = objReader["Course_Details"].ToString();
				objCourse.strEligibility = objReader["Course_Eligibility"].ToString();
				objCourse.strAdmissionCriteria = objReader["Course_AdmissionCriteria"].ToString();
				objCourseList.Add(objCourse);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCourseList;
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

	public CoreWebList<CourseClass> fn_getCourseByName(string strCourseTitle)
	{
		CoreWebList<CourseClass> objCourseList = null;
		CourseClass objCourse = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT co.*, univ.University_Title, mo.ModeofStudy_Title, lev.LevelofStudy_Title FROM tbl_Courses co join tbl_University univ on co.Course_UniversityID=univ.University_ID join tbl_ModeofStudy mo on co.Course_ModeofStudyID=mo.ModeofStudy_ID join tbl_LevelofStudy lev on co.Course_LevelofStudyID=lev.LevelofStudy_ID WHERE co.Course_Title=@Course_Title", objConnection);
			objCommand.Parameters.AddWithValue("@Course_Title", strCourseTitle);
			objReader = objCommand.ExecuteReader();
			objCourseList = new CoreWebList<CourseClass>();
			if (objReader.Read())
			{
				objCourse = new CourseClass();
				objCourse.iID = int.Parse(objReader["Course_ID"].ToString());
				objCourse.iUniversityID = int.Parse(objReader["Course_UniversityID"].ToString());
				objCourse.iModeofStudyID = int.Parse(objReader["Course_ModeofStudyID"].ToString());
				objCourse.iLevelofStudyID = int.Parse(objReader["Course_LevelofStudyID"].ToString());

                objCourse.strUniversity = objReader["University_Title"].ToString();
                objCourse.strModeofStudy = objReader["ModeofStudy_Title"].ToString();
                objCourse.strLevelofStudy = objReader["LevelofStudy_Title"].ToString();
                
                objCourse.strTitle = objReader["Course_Title"].ToString();
				objCourse.strFees = objReader["Course_Fees"].ToString();
				objCourse.strDetails = objReader["Course_Details"].ToString();
				objCourse.strEligibility = objReader["Course_Eligibility"].ToString();
				objCourse.strAdmissionCriteria = objReader["Course_AdmissionCriteria"].ToString();
				objCourseList.Add(objCourse);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCourseList;
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

	public CoreWebList<CourseClass> fn_getCourseByKeys(string strCourseTitle)
	{
		CoreWebList<CourseClass> objCourseList = null;
		CourseClass objCourse = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Courses WHERE Course_Title like '%' + @Course_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@Course_Title", strCourseTitle);
			objReader = objCommand.ExecuteReader();
			objCourseList = new CoreWebList<CourseClass>();
			while (objReader.Read())
			{
				objCourse = new CourseClass();
				objCourse.iID = int.Parse(objReader["Course_ID"].ToString());
				objCourse.iUniversityID = int.Parse(objReader["Course_UniversityID"].ToString());
				objCourse.iModeofStudyID = int.Parse(objReader["Course_ModeofStudyID"].ToString());
				objCourse.iLevelofStudyID = int.Parse(objReader["Course_LevelofStudyID"].ToString());
				objCourse.strTitle = objReader["Course_Title"].ToString();
				objCourse.strFees = objReader["Course_Fees"].ToString();
				objCourse.strDetails = objReader["Course_Details"].ToString();
				objCourse.strEligibility = objReader["Course_Eligibility"].ToString();
				objCourse.strAdmissionCriteria = objReader["Course_AdmissionCriteria"].ToString();
				objCourseList.Add(objCourse);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCourseList;
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

	public CoreWebList<CourseClass> fn_getCourseByLevelofStudyID(int iLevelofStudyID)
	{
		CoreWebList<CourseClass> objCourseList = null;
		CourseClass objCourse = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Courses WHERE Course_LevelofStudyID=@Course_LevelofStudyID", objConnection);
			objCommand.Parameters.AddWithValue("@Course_LevelofStudyID", iLevelofStudyID);
			objReader = objCommand.ExecuteReader();
			objCourseList = new CoreWebList<CourseClass>();
			while (objReader.Read())
			{
				objCourse = new CourseClass();
				objCourse.iID = int.Parse(objReader["Course_ID"].ToString());
				objCourse.iUniversityID = int.Parse(objReader["Course_UniversityID"].ToString());
				objCourse.iModeofStudyID = int.Parse(objReader["Course_ModeofStudyID"].ToString());
				objCourse.iLevelofStudyID = int.Parse(objReader["Course_LevelofStudyID"].ToString());
				objCourse.strTitle = objReader["Course_Title"].ToString();
				objCourse.strFees = objReader["Course_Fees"].ToString();
				objCourse.strDetails = objReader["Course_Details"].ToString();
				objCourse.strEligibility = objReader["Course_Eligibility"].ToString();
				objCourse.strAdmissionCriteria = objReader["Course_AdmissionCriteria"].ToString();
				objCourseList.Add(objCourse);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCourseList;
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

	public CoreWebList<CourseClass> fn_getCourseByModeofStudyID(int iModeofStudyID)
	{
		CoreWebList<CourseClass> objCourseList = null;
		CourseClass objCourse = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Courses WHERE Course_ModeofStudyID=@Course_ModeofStudyID", objConnection);
			objCommand.Parameters.AddWithValue("@Course_ModeofStudyID", iModeofStudyID);
			objReader = objCommand.ExecuteReader();
			objCourseList = new CoreWebList<CourseClass>();
			while (objReader.Read())
			{
				objCourse = new CourseClass();
				objCourse.iID = int.Parse(objReader["Course_ID"].ToString());
				objCourse.iUniversityID = int.Parse(objReader["Course_UniversityID"].ToString());
				objCourse.iModeofStudyID = int.Parse(objReader["Course_ModeofStudyID"].ToString());
				objCourse.iLevelofStudyID = int.Parse(objReader["Course_LevelofStudyID"].ToString());
				objCourse.strTitle = objReader["Course_Title"].ToString();
				objCourse.strFees = objReader["Course_Fees"].ToString();
				objCourse.strDetails = objReader["Course_Details"].ToString();
				objCourse.strEligibility = objReader["Course_Eligibility"].ToString();
				objCourse.strAdmissionCriteria = objReader["Course_AdmissionCriteria"].ToString();
				objCourseList.Add(objCourse);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCourseList;
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

	public CoreWebList<CourseClass> fn_getCourseByUniversityID(int iUniversityID)
	{
		CoreWebList<CourseClass> objCourseList = null;
		CourseClass objCourse = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_Courses WHERE Course_UniversityID=@Course_UniversityID", objConnection);
			objCommand.Parameters.AddWithValue("@Course_UniversityID", iUniversityID);
			objReader = objCommand.ExecuteReader();
			objCourseList = new CoreWebList<CourseClass>();
			while (objReader.Read())
			{
				objCourse = new CourseClass();
				objCourse.iID = int.Parse(objReader["Course_ID"].ToString());
				objCourse.iUniversityID = int.Parse(objReader["Course_UniversityID"].ToString());
				objCourse.iModeofStudyID = int.Parse(objReader["Course_ModeofStudyID"].ToString());
				objCourse.iLevelofStudyID = int.Parse(objReader["Course_LevelofStudyID"].ToString());
				objCourse.strTitle = objReader["Course_Title"].ToString();
				objCourse.strFees = objReader["Course_Fees"].ToString();
				objCourse.strDetails = objReader["Course_Details"].ToString();
				objCourse.strEligibility = objReader["Course_Eligibility"].ToString();
				objCourse.strAdmissionCriteria = objReader["Course_AdmissionCriteria"].ToString();
				objCourseList.Add(objCourse);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objCourseList;
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
