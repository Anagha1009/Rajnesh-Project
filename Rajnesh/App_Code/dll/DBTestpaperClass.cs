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
/// Summary description for DBTestpaperClass
/// </summary>
public class DBTestpaperClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

	public string fn_saveTestpaper(TestpaperClass objTestpaper)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO edu_Testpapers (Testpaper_CourseID, Testpaper_Title, Testpaper_Desc) VALUES (@Testpaper_CourseID, @Testpaper_Title, @Testpaper_Desc)",objConnection) ;
			objCommand.Parameters.AddWithValue("@Testpaper_CourseID", objTestpaper.iCourseID);
			objCommand.Parameters.AddWithValue("@Testpaper_Title", objTestpaper.strTestpaperTitle);
			objCommand.Parameters.AddWithValue("@Testpaper_Desc", objTestpaper.strTestpaperDesc);

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

	public string fn_editTestpaper(TestpaperClass objTestpaper)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE edu_Testpapers SET Testpaper_CourseID=@Testpaper_CourseID, Testpaper_Title=@Testpaper_Title, Testpaper_Desc=@Testpaper_Desc WHERE Testpaper_ID=@Testpaper_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Testpaper_ID", objTestpaper.iID);
			objCommand.Parameters.AddWithValue("@Testpaper_CourseID", objTestpaper.iCourseID);
			objCommand.Parameters.AddWithValue("@Testpaper_Title", objTestpaper.strTestpaperTitle);
			objCommand.Parameters.AddWithValue("@Testpaper_Desc", objTestpaper.strTestpaperDesc);

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

	public string fn_deleteTestpaper(int iTestpaperID)
	{
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM edu_Testpapers WHERE Testpaper_ID=@Testpaper_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@Testpaper_ID", iTestpaperID);

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

	public CoreWebList<TestpaperClass> fn_getTestpaperList()
	{
		CoreWebList<TestpaperClass> objTestpaperList = null;
		TestpaperClass objTestpaper = null;
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM edu_Testpapers", objConnection);
			objReader = objCommand.ExecuteReader();
			objTestpaperList = new CoreWebList<TestpaperClass>();
			while (objReader.Read())
			{
				objTestpaper = new TestpaperClass();
				objTestpaper.iID = int.Parse(objReader["Testpaper_ID"].ToString());
				objTestpaper.iCourseID = int.Parse(objReader["Testpaper_CourseID"].ToString());
				objTestpaper.strTestpaperTitle = objReader["Testpaper_Title"].ToString();
				objTestpaper.strTestpaperDesc = objReader["Testpaper_Desc"].ToString();
				objTestpaperList.Add(objTestpaper);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objTestpaperList;
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

	public CoreWebList<TestpaperClass> fn_getTestpaperByID(int iTestpaperID)
	{
		CoreWebList<TestpaperClass> objTestpaperList = null;
		TestpaperClass objTestpaper = null;
		try
		{
			objConnection = new SqlConnection(strConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM edu_Testpapers WHERE Testpaper_ID=@Testpaper_ID", objConnection);
			objCommand.Parameters.AddWithValue("@Testpaper_ID", iTestpaperID);
			objReader = objCommand.ExecuteReader();
			objTestpaperList = new CoreWebList<TestpaperClass>();
			if (objReader.Read())
			{
				objTestpaper = new TestpaperClass();
				objTestpaper.iID = int.Parse(objReader["Testpaper_ID"].ToString());
				objTestpaper.iCourseID = int.Parse(objReader["Testpaper_CourseID"].ToString());
				objTestpaper.strTestpaperTitle = objReader["Testpaper_Title"].ToString();
				objTestpaper.strTestpaperDesc = objReader["Testpaper_Desc"].ToString();
				objTestpaperList.Add(objTestpaper);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objTestpaperList;
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

    public CoreWebList<TestpaperClass> fn_getTestpaperByName(string strName)
    {
        CoreWebList<TestpaperClass> objTestpaperList = null;
        TestpaperClass objTestpaper = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT DLCourses_Name FROM edu_DLCourses WHERE DLCourses_ID=Testpaper_CourseID) Testpaper_CourseName, * FROM edu_Testpapers WHERE Testpaper_Title=@Testpaper_Title", objConnection);
            objCommand.Parameters.AddWithValue("@Testpaper_Title", strName);
            objReader = objCommand.ExecuteReader();
            objTestpaperList = new CoreWebList<TestpaperClass>();
            while (objReader.Read())
            {
                objTestpaper = new TestpaperClass();
                objTestpaper.iID = int.Parse(objReader["Testpaper_ID"].ToString());
                objTestpaper.iCourseID = int.Parse(objReader["Testpaper_CourseID"].ToString());
                objTestpaper.strCourseName = objReader["Testpaper_CourseName"].ToString();
                objTestpaper.strTestpaperTitle = objReader["Testpaper_Title"].ToString();
                objTestpaper.strTestpaperDesc = objReader["Testpaper_Desc"].ToString();
                objTestpaperList.Add(objTestpaper);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objTestpaperList;
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

    public CoreWebList<TestpaperClass> fn_getTestpaperByCourseID(int iCourseID)
    {
        CoreWebList<TestpaperClass> objTestpaperList = null;
        TestpaperClass objTestpaper = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT DLCourses_Name FROM edu_DLCourses WHERE DLCourses_ID=Testpaper_CourseID) Testpaper_CourseName, * FROM edu_Testpapers WHERE Testpaper_CourseID=@Testpaper_CourseID", objConnection);
            objCommand.Parameters.AddWithValue("@Testpaper_CourseID", iCourseID);
            objReader = objCommand.ExecuteReader();
            objTestpaperList = new CoreWebList<TestpaperClass>();
            while (objReader.Read())
            {
                objTestpaper = new TestpaperClass();
                objTestpaper.iID = int.Parse(objReader["Testpaper_ID"].ToString());
                objTestpaper.iCourseID = int.Parse(objReader["Testpaper_CourseID"].ToString());
                objTestpaper.strCourseName = objReader["Testpaper_CourseName"].ToString();
                objTestpaper.strTestpaperTitle = objReader["Testpaper_Title"].ToString();
                objTestpaper.strTestpaperDesc = objReader["Testpaper_Desc"].ToString();
                objTestpaperList.Add(objTestpaper);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objTestpaperList;
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

    public CoreWebList<TestpaperClass> fn_getTestpaperByKeys(string strKeys)
    {
        CoreWebList<TestpaperClass> objTestpaperList = null;
        TestpaperClass objTestpaper = null;
        try
        {
            objConnection = new SqlConnection(strConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM edu_Testpapers WHERE Testpaper_Title like '%' + @Testpaper_Title + '%'", objConnection);
            objCommand.Parameters.AddWithValue("@Testpaper_Title", strKeys);
            objReader = objCommand.ExecuteReader();
            objTestpaperList = new CoreWebList<TestpaperClass>();
            while (objReader.Read())
            {
                objTestpaper = new TestpaperClass();
                objTestpaper.iID = int.Parse(objReader["Testpaper_ID"].ToString());
                objTestpaper.iCourseID = int.Parse(objReader["Testpaper_CourseID"].ToString());
                objTestpaper.strTestpaperTitle = objReader["Testpaper_Title"].ToString();
                objTestpaper.strTestpaperDesc = objReader["Testpaper_Desc"].ToString();
                objTestpaperList.Add(objTestpaper);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objTestpaperList;
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
