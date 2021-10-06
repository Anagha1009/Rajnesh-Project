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
/// Summary description for DBInstituteCourseClass
/// </summary>
public class DBInstituteCourseClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveInstituteCourse(InstituteCourseClass objInstituteCourse)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("INSERT INTO tbl_InstituteCourses (InstituteCourse_CategoryID, InstituteCourse_InstituteID, InstituteCourse_Title, InstituteCourse_Desc, InstituteCourse_Syllabus, InstituteCourse_Fees, InstituteCourse_Eligibility) VALUES (@InstituteCourse_CategoryID, @InstituteCourse_InstituteID, @InstituteCourse_Title, @InstituteCourse_Desc, @InstituteCourse_Syllabus, @InstituteCourse_Fees, @InstituteCourse_Eligibility)", objConnection);
            objCommand.Parameters.AddWithValue("@InstituteCourse_CategoryID", objInstituteCourse.iCategoryID);
            objCommand.Parameters.AddWithValue("@InstituteCourse_InstituteID", objInstituteCourse.iInstituteID);
			objCommand.Parameters.AddWithValue("@InstituteCourse_Title", objInstituteCourse.strTitle);
			objCommand.Parameters.AddWithValue("@InstituteCourse_Desc", objInstituteCourse.strDesc);
			objCommand.Parameters.AddWithValue("@InstituteCourse_Syllabus", objInstituteCourse.strSyllabus);
			objCommand.Parameters.AddWithValue("@InstituteCourse_Fees", objInstituteCourse.strFees);
			objCommand.Parameters.AddWithValue("@InstituteCourse_Eligibility", objInstituteCourse.strEligibility);

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

	public string fn_editInstituteCourse(InstituteCourseClass objInstituteCourse)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("UPDATE tbl_InstituteCourses SET InstituteCourse_CategoryID=@InstituteCourse_CategoryID, InstituteCourse_InstituteID=@InstituteCourse_InstituteID, InstituteCourse_Title=@InstituteCourse_Title, InstituteCourse_Desc=@InstituteCourse_Desc, InstituteCourse_Syllabus=@InstituteCourse_Syllabus, InstituteCourse_Fees=@InstituteCourse_Fees, InstituteCourse_Eligibility=@InstituteCourse_Eligibility WHERE InstituteCourse_ID=@InstituteCourse_ID", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteCourse_ID", objInstituteCourse.iID);
            objCommand.Parameters.AddWithValue("@InstituteCourse_CategoryID", objInstituteCourse.iCategoryID);
			objCommand.Parameters.AddWithValue("@InstituteCourse_InstituteID", objInstituteCourse.iInstituteID);
			objCommand.Parameters.AddWithValue("@InstituteCourse_Title", objInstituteCourse.strTitle);
			objCommand.Parameters.AddWithValue("@InstituteCourse_Desc", objInstituteCourse.strDesc);
			objCommand.Parameters.AddWithValue("@InstituteCourse_Syllabus", objInstituteCourse.strSyllabus);
			objCommand.Parameters.AddWithValue("@InstituteCourse_Fees", objInstituteCourse.strFees);
			objCommand.Parameters.AddWithValue("@InstituteCourse_Eligibility", objInstituteCourse.strEligibility);

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

	public string fn_deleteInstituteCourse(int iInstituteCourseID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_InstituteCourses WHERE InstituteCourse_ID=@InstituteCourse_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@InstituteCourse_ID", iInstituteCourseID);

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

	public CoreWebList<InstituteCourseClass> fn_getInstituteCourseList()
	{
		CoreWebList<InstituteCourseClass> objInstituteCourseList = null;
		InstituteCourseClass objInstituteCourse = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT Institute_Title FROM tbl_Institutes inst WHERE inst.Institute_ID=course.InstituteCourse_InstituteID)InstituteCourse_Institute, * FROM tbl_InstituteCourses course ORDER BY course.InstituteCourse_Title ASC", objConnection);
			objReader = objCommand.ExecuteReader();
			objInstituteCourseList = new CoreWebList<InstituteCourseClass>();
			while (objReader.Read())
			{
				objInstituteCourse = new InstituteCourseClass();
				objInstituteCourse.iID = int.Parse(objReader["InstituteCourse_ID"].ToString());
                objInstituteCourse.iCategoryID = int.Parse(objReader["InstituteCourse_CategoryID"].ToString());
                objInstituteCourse.iInstituteID = int.Parse(objReader["InstituteCourse_InstituteID"].ToString());
                objInstituteCourse.strInstitute = objReader["InstituteCourse_Institute"].ToString();
                objInstituteCourse.strTitle = objReader["InstituteCourse_Title"].ToString();
				objInstituteCourse.strDesc = objReader["InstituteCourse_Desc"].ToString();
				objInstituteCourse.strSyllabus = objReader["InstituteCourse_Syllabus"].ToString();
				objInstituteCourse.strFees = objReader["InstituteCourse_Fees"].ToString();
				objInstituteCourse.strEligibility = objReader["InstituteCourse_Eligibility"].ToString();
				objInstituteCourseList.Add(objInstituteCourse);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteCourseList;
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

    public CoreWebList<InstituteCourseClass> fn_get_Institute_CourseList()
    {
        CoreWebList<InstituteCourseClass> objInstituteCourseList = null;
        InstituteCourseClass objInstituteCourse = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT co.InstituteCourse_ID, co.InstituteCourse_Title, inst.Institute_Title FROM tbl_InstituteCourses co join tbl_Institutes inst on co.InstituteCourse_InstituteID=inst.Institute_ID ORDER BY inst.Institute_Title ASC", objConnection);
            objReader = objCommand.ExecuteReader();
            objInstituteCourseList = new CoreWebList<InstituteCourseClass>();
            while (objReader.Read())
            {
                objInstituteCourse = new InstituteCourseClass();
                objInstituteCourse.iID = int.Parse(objReader["InstituteCourse_ID"].ToString());
                objInstituteCourse.strInstitute = objReader["Institute_Title"].ToString();
                objInstituteCourse.strTitle = objReader["InstituteCourse_Title"].ToString() + " (" + objReader["Institute_Title"].ToString() + ")";
                
                objInstituteCourseList.Add(objInstituteCourse);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteCourseList;
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

    public CoreWebList<InstituteCourseClass> fn_getInstituteCourseListByQuery(string strQuery)
    {
        CoreWebList<InstituteCourseClass> objInstituteCourseList = null;
        InstituteCourseClass objInstituteCourse = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();
            objInstituteCourseList = new CoreWebList<InstituteCourseClass>();
            while (objReader.Read())
            {
                objInstituteCourse = new InstituteCourseClass();
                objInstituteCourse.iID = int.Parse(objReader["InstituteCourse_ID"].ToString());
                objInstituteCourse.strTitle = objReader["InstituteCourse_Title"].ToString();
                objInstituteCourseList.Add(objInstituteCourse);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteCourseList;
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

	public CoreWebList<InstituteCourseClass> fn_getInstituteCourseByID(int iInstituteCourseID)
	{
		CoreWebList<InstituteCourseClass> objInstituteCourseList = null;
		InstituteCourseClass objInstituteCourse = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteCourses WHERE InstituteCourse_ID=@InstituteCourse_ID", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteCourse_ID", iInstituteCourseID);
			objReader = objCommand.ExecuteReader();
			objInstituteCourseList = new CoreWebList<InstituteCourseClass>();
			if (objReader.Read())
			{
				objInstituteCourse = new InstituteCourseClass();
				objInstituteCourse.iID = int.Parse(objReader["InstituteCourse_ID"].ToString());
                objInstituteCourse.iCategoryID = int.Parse(objReader["InstituteCourse_CategoryID"].ToString());
				objInstituteCourse.iInstituteID = int.Parse(objReader["InstituteCourse_InstituteID"].ToString());
				objInstituteCourse.strTitle = objReader["InstituteCourse_Title"].ToString();
				objInstituteCourse.strDesc = objReader["InstituteCourse_Desc"].ToString();
				objInstituteCourse.strSyllabus = objReader["InstituteCourse_Syllabus"].ToString();
				objInstituteCourse.strFees = objReader["InstituteCourse_Fees"].ToString();
				objInstituteCourse.strEligibility = objReader["InstituteCourse_Eligibility"].ToString();
				objInstituteCourseList.Add(objInstituteCourse);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteCourseList;
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

    public CoreWebList<InstituteCourseClass> fn_getInstituteCourseListbyCategoryID(int iCategoryID)
    {
        CoreWebList<InstituteCourseClass> objInstituteCourseList = null;
        InstituteCourseClass objInstituteCourse = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT Institute_Title FROM tbl_Institutes inst WHERE inst.Institute_ID=course.InstituteCourse_InstituteID)InstituteCourse_Institute, * FROM tbl_InstituteCourses course WHERE course.InstituteCourse_CategoryID=@InstituteCourse_CategoryID", objConnection);
            objCommand.Parameters.AddWithValue("@InstituteCourse_CategoryID", iCategoryID);
            objReader = objCommand.ExecuteReader();
            objInstituteCourseList = new CoreWebList<InstituteCourseClass>();
            while (objReader.Read())
            {
                objInstituteCourse = new InstituteCourseClass();
                objInstituteCourse.iID = int.Parse(objReader["InstituteCourse_ID"].ToString());
                objInstituteCourse.iCategoryID = int.Parse(objReader["InstituteCourse_CategoryID"].ToString());
                objInstituteCourse.iInstituteID = int.Parse(objReader["InstituteCourse_InstituteID"].ToString());
                objInstituteCourse.strInstitute = objReader["InstituteCourse_Institute"].ToString();
                objInstituteCourse.strTitle = objReader["InstituteCourse_Title"].ToString();
                objInstituteCourse.strDesc = objReader["InstituteCourse_Desc"].ToString();
                objInstituteCourse.strSyllabus = objReader["InstituteCourse_Syllabus"].ToString();
                objInstituteCourse.strFees = objReader["InstituteCourse_Fees"].ToString();
                objInstituteCourse.strEligibility = objReader["InstituteCourse_Eligibility"].ToString();
                objInstituteCourseList.Add(objInstituteCourse);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteCourseList;
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

    public CoreWebList<InstituteCourseClass> fn_getInstituteCourseByIdentity(string strIdentity)
    {
        CoreWebList<InstituteCourseClass> objInstituteCourseList = null;
        InstituteCourseClass objInstituteCourse = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT Institute_Title FROM tbl_Institutes inst WHERE inst.Institute_ID=course.InstituteCourse_InstituteID)InstituteCourse_Institute, * FROM tbl_InstituteCourses course WHERE course.InstituteCourse_ID IN (" + strIdentity + ")", objConnection);
            objReader = objCommand.ExecuteReader();
            objInstituteCourseList = new CoreWebList<InstituteCourseClass>();
            while (objReader.Read())
            {
                objInstituteCourse = new InstituteCourseClass();
                objInstituteCourse.iID = int.Parse(objReader["InstituteCourse_ID"].ToString());
                objInstituteCourse.iCategoryID = int.Parse(objReader["InstituteCourse_CategoryID"].ToString());
                objInstituteCourse.iInstituteID = int.Parse(objReader["InstituteCourse_InstituteID"].ToString());
                objInstituteCourse.strInstitute = objReader["InstituteCourse_Institute"].ToString();
                objInstituteCourse.strTitle = objReader["InstituteCourse_Title"].ToString();
                objInstituteCourse.strDesc = objReader["InstituteCourse_Desc"].ToString();
                objInstituteCourse.strSyllabus = objReader["InstituteCourse_Syllabus"].ToString();
                objInstituteCourse.strFees = objReader["InstituteCourse_Fees"].ToString();
                objInstituteCourse.strEligibility = objReader["InstituteCourse_Eligibility"].ToString();
                objInstituteCourseList.Add(objInstituteCourse);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteCourseList;
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

    public CoreWebList<InstituteCourseClass> fn_getInstituteCourseByCourse(int iInstituteID, string strTitle)
    {
        CoreWebList<InstituteCourseClass> objInstituteCourseList = null;
        InstituteCourseClass objInstituteCourse = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_InstituteCourses WHERE InstituteCourse_InstituteID=@InstituteCourse_InstituteID AND InstituteCourse_Title=@InstituteCourse_Title", objConnection);
            objCommand.Parameters.AddWithValue("@InstituteCourse_InstituteID", iInstituteID);
            objCommand.Parameters.AddWithValue("@InstituteCourse_Title", strTitle);
            objReader = objCommand.ExecuteReader();
            objInstituteCourseList = new CoreWebList<InstituteCourseClass>();
            if (objReader.Read())
            {
                objInstituteCourse = new InstituteCourseClass();
                objInstituteCourse.iID = int.Parse(objReader["InstituteCourse_ID"].ToString());
                objInstituteCourse.iCategoryID = int.Parse(objReader["InstituteCourse_CategoryID"].ToString());
                objInstituteCourse.iInstituteID = int.Parse(objReader["InstituteCourse_InstituteID"].ToString());
                objInstituteCourse.strTitle = objReader["InstituteCourse_Title"].ToString();
                objInstituteCourse.strDesc = objReader["InstituteCourse_Desc"].ToString();
                objInstituteCourse.strSyllabus = objReader["InstituteCourse_Syllabus"].ToString();
                objInstituteCourse.strFees = objReader["InstituteCourse_Fees"].ToString();
                objInstituteCourse.strEligibility = objReader["InstituteCourse_Eligibility"].ToString();
                objInstituteCourseList.Add(objInstituteCourse);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteCourseList;
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

    public CoreWebList<InstituteCourseClass> fn_getSimilarCourseByCityCategory(int iID, int iCategoryID, int iCityID)
    {
        CoreWebList<InstituteCourseClass> objInstituteCourseList = null;
        InstituteCourseClass objInstituteCourse = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 7 * FROM tbl_InstituteCourses course join tbl_Institutes inst on course.InstituteCourse_InstituteID=inst.Institute_ID WHERE course.InstituteCourse_CategoryID=@InstituteCourse_CategoryID AND inst.Institute_CityID=@Institute_CityID AND course.InstituteCourse_ID != @InstituteCourse_ID ORDER BY NEWID()", objConnection);
            objCommand.Parameters.AddWithValue("@InstituteCourse_ID", iID);
            objCommand.Parameters.AddWithValue("@InstituteCourse_CategoryID", iCategoryID);
            objCommand.Parameters.AddWithValue("@Institute_CityID", iCityID);
            objReader = objCommand.ExecuteReader();
            objInstituteCourseList = new CoreWebList<InstituteCourseClass>();
            while (objReader.Read())
            {
                objInstituteCourse = new InstituteCourseClass();
                objInstituteCourse.iID = int.Parse(objReader["InstituteCourse_ID"].ToString());
                objInstituteCourse.iCategoryID = int.Parse(objReader["InstituteCourse_CategoryID"].ToString());
                objInstituteCourse.iInstituteID = int.Parse(objReader["InstituteCourse_InstituteID"].ToString());
                objInstituteCourse.strInstitute = objReader["Institute_Title"].ToString();
                objInstituteCourse.strTitle = objReader["InstituteCourse_Title"].ToString();
                objInstituteCourse.strDesc = objReader["InstituteCourse_Desc"].ToString();
                objInstituteCourse.strSyllabus = objReader["InstituteCourse_Syllabus"].ToString();
                objInstituteCourse.strFees = objReader["InstituteCourse_Fees"].ToString();
                objInstituteCourse.strEligibility = objReader["InstituteCourse_Eligibility"].ToString();
                objInstituteCourseList.Add(objInstituteCourse);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objInstituteCourseList;
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

	public CoreWebList<InstituteCourseClass> fn_getInstituteCourseByName(string strInstituteCourseTitle)
	{
		CoreWebList<InstituteCourseClass> objInstituteCourseList = null;
		InstituteCourseClass objInstituteCourse = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteCourses WHERE InstituteCourse_Title=@InstituteCourse_Title", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteCourse_Title", strInstituteCourseTitle);
			objReader = objCommand.ExecuteReader();
			objInstituteCourseList = new CoreWebList<InstituteCourseClass>();
			if (objReader.Read())
			{
				objInstituteCourse = new InstituteCourseClass();
				objInstituteCourse.iID = int.Parse(objReader["InstituteCourse_ID"].ToString());
                objInstituteCourse.iCategoryID = int.Parse(objReader["InstituteCourse_CategoryID"].ToString());
				objInstituteCourse.iInstituteID = int.Parse(objReader["InstituteCourse_InstituteID"].ToString());
				objInstituteCourse.strTitle = objReader["InstituteCourse_Title"].ToString();
				objInstituteCourse.strDesc = objReader["InstituteCourse_Desc"].ToString();
				objInstituteCourse.strSyllabus = objReader["InstituteCourse_Syllabus"].ToString();
				objInstituteCourse.strFees = objReader["InstituteCourse_Fees"].ToString();
				objInstituteCourse.strEligibility = objReader["InstituteCourse_Eligibility"].ToString();
				objInstituteCourseList.Add(objInstituteCourse);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteCourseList;
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

	public CoreWebList<InstituteCourseClass> fn_getInstituteCourseByKeys(string strInstituteCourseTitle)
	{
		CoreWebList<InstituteCourseClass> objInstituteCourseList = null;
		InstituteCourseClass objInstituteCourse = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_InstituteCourses WHERE InstituteCourse_Title like '%' + @InstituteCourse_Title + '%'", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteCourse_Title", strInstituteCourseTitle);
			objReader = objCommand.ExecuteReader();
			objInstituteCourseList = new CoreWebList<InstituteCourseClass>();
			while (objReader.Read())
			{
				objInstituteCourse = new InstituteCourseClass();
				objInstituteCourse.iID = int.Parse(objReader["InstituteCourse_ID"].ToString());
                objInstituteCourse.iCategoryID = int.Parse(objReader["InstituteCourse_CategoryID"].ToString());
				objInstituteCourse.iInstituteID = int.Parse(objReader["InstituteCourse_InstituteID"].ToString());
				objInstituteCourse.strTitle = objReader["InstituteCourse_Title"].ToString();
				objInstituteCourse.strDesc = objReader["InstituteCourse_Desc"].ToString();
				objInstituteCourse.strSyllabus = objReader["InstituteCourse_Syllabus"].ToString();
				objInstituteCourse.strFees = objReader["InstituteCourse_Fees"].ToString();
				objInstituteCourse.strEligibility = objReader["InstituteCourse_Eligibility"].ToString();
				objInstituteCourseList.Add(objInstituteCourse);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteCourseList;
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

	public CoreWebList<InstituteCourseClass> fn_getInstituteCourseByInstituteID(int iInstituteID)
	{
		CoreWebList<InstituteCourseClass> objInstituteCourseList = null;
		InstituteCourseClass objInstituteCourse = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
            objCommand = new SqlCommand("SELECT Inst.Institute_Title, Course.* FROM tbl_InstituteCourses Course join tbl_Institutes Inst on Course.InstituteCourse_InstituteID=Inst.Institute_ID WHERE InstituteCourse_InstituteID=@InstituteCourse_InstituteID", objConnection);
			objCommand.Parameters.AddWithValue("@InstituteCourse_InstituteID", iInstituteID);
			objReader = objCommand.ExecuteReader();
			objInstituteCourseList = new CoreWebList<InstituteCourseClass>();
			while (objReader.Read())
			{
				objInstituteCourse = new InstituteCourseClass();
				objInstituteCourse.iID = int.Parse(objReader["InstituteCourse_ID"].ToString());
                objInstituteCourse.iCategoryID = int.Parse(objReader["InstituteCourse_CategoryID"].ToString());
				objInstituteCourse.iInstituteID = int.Parse(objReader["InstituteCourse_InstituteID"].ToString());
                objInstituteCourse.strInstitute = objReader["Institute_Title"].ToString();
                objInstituteCourse.strTitle = objReader["InstituteCourse_Title"].ToString();
				objInstituteCourse.strDesc = objReader["InstituteCourse_Desc"].ToString();
				objInstituteCourse.strSyllabus = objReader["InstituteCourse_Syllabus"].ToString();
				objInstituteCourse.strFees = objReader["InstituteCourse_Fees"].ToString();
				objInstituteCourse.strEligibility = objReader["InstituteCourse_Eligibility"].ToString();
				objInstituteCourseList.Add(objInstituteCourse);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objInstituteCourseList;
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
