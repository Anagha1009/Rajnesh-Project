using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using yo_lib;

/// <summary>
/// Summary description for DBDLCoursesClass
/// </summary>
public class DBDLCoursesClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    internal string fn_saveDLCourse(int iDistanceID, int iTypeID, string strName, string strDescription)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_DLCourses(DLCourses_DLID,DLCourses_TypeID,DLCourses_Name,DLCourses_Description) VALUES (@iDistanceID,@iTypeID,@strName,@strDescription)", objConnection);

            objCommand.Parameters.AddWithValue("@iDistanceID", iDistanceID);
            objCommand.Parameters.AddWithValue("@iTypeID", iTypeID);
            objCommand.Parameters.AddWithValue("@strName", strName);
            objCommand.Parameters.AddWithValue("@strDescription", strDescription);


            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been inserted";
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

    internal string fn_editDLCourse(int iID, int iDistanceID, int iTypeID, string strName, string strDescription)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();
            objCommand = new SqlCommand("UPDATE edu_DLCourses SET DLCourses_DLID = @iDistanceID,DLCourses_TypeID = @iTypeID,DLCourses_Name = @strName,DLCourses_Description = @strDescription WHERE DLCourses_ID = @iID", objConnection);
            objCommand.Parameters.AddWithValue("@iID", iID);
            objCommand.Parameters.AddWithValue("@iDistanceID", iDistanceID);
            objCommand.Parameters.AddWithValue("@iTypeID", iTypeID);
            objCommand.Parameters.AddWithValue("@strName", strName);
            objCommand.Parameters.AddWithValue("@strDescription", strDescription);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been updated";
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

    internal string fn_deleteDLCourse(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_DLCourses WHERE DLCourses_ID = @iID", objConnection);
            objCommand.Parameters.AddWithValue("@iID", iID);
            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been deleted";
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

    internal CoreWebList<DLCoursesClass> fn_getDLCourseByID(int iID)
    {
        CoreWebList<DLCoursesClass> objCategoryList = null;
        DLCoursesClass objCategory = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            //objCommand = new SqlCommand("SELECT * FROM edu_DLCourses WHERE DLCourses_ID = @iID", objConnection);
            objCommand = new SqlCommand("SELECT edu_CourseType.courseType_id, edu_CourseType.courseType_title, edu_DLCourses.DLCourses_ID, edu_DLCourses.DLCourses_DLID,edu_DLCourses.DLCourses_TypeID, edu_DLCourses.DLCourses_Name, edu_DLCourses.DLCourses_Description FROM edu_CourseType INNER JOIN edu_DLCourses ON edu_CourseType.courseType_id = edu_DLCourses.DLCourses_TypeID WHERE edu_DLCourses.DLCourses_ID = @iID", objConnection);
            objCommand.Parameters.AddWithValue("@iID", iID);
            objReader = objCommand.ExecuteReader();
            objCategoryList = new CoreWebList<DLCoursesClass>();
            if (objReader.Read())
            {
                objCategory = new DLCoursesClass();
                objCategory.iID = int.Parse(objReader["DLCourses_ID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLCourses_DLID"].ToString());
                objCategory.iTypeID = int.Parse(objReader["DLCourses_TypeID"].ToString());
                objCategory.strName = objReader["DLCourses_Name"].ToString();
                objCategory.strDescription = objReader["DLCourses_Description"].ToString();
                objCategory.strType = objReader["courseType_title"].ToString();
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

    internal CoreWebList<DLCoursesClass> fn_getDL_Course_By_ID(int iID)
    {
        CoreWebList<DLCoursesClass> objCategoryList = null;
        DLCoursesClass objCategory = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT (SELECT distancelearning_type FROM edu_DistanceLearning WHERE distancelearning_id=DLCourses_DLID)Distance_UniversityType,(SELECT distancelearning_name FROM edu_DistanceLearning dl WHERE dl.distancelearning_id = dlcourse.DLCourses_DLID) AS Institute, * FROM edu_DLCourses dlcourse WHERE DLCourses_ID = @iID", objConnection);
            objCommand.Parameters.AddWithValue("@iID", iID);
            objReader = objCommand.ExecuteReader();
            objCategoryList = new CoreWebList<DLCoursesClass>();
            if (objReader.Read())
            {
                objCategory = new DLCoursesClass();
                objCategory.iID = int.Parse(objReader["DLCourses_ID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLCourses_DLID"].ToString());
                objCategory.iTypeID = int.Parse(objReader["DLCourses_TypeID"].ToString());
                objCategory.strName = objReader["DLCourses_Name"].ToString();
                
                objCategory.strType = objReader["Distance_UniversityType"].ToString();
                if (objReader["Distance_UniversityType"].ToString() == "Institute")
                {
                    objCategory.strType = "Colleges";
                }
                
                objCategory.strInstitute = objReader["Institute"].ToString();
                objCategory.strDescription = objReader["DLCourses_Description"].ToString();
                
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

    internal yo_lib.CoreWebList<DLCoursesClass> fn_getDLCourseList()
    {
        CoreWebList<DLCoursesClass> objCategoryList = null;
        DLCoursesClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            //objCommand = new SqlCommand("SELECT * FROM edu_DLCourses", objConnection);
            objCommand = new SqlCommand("SELECT edu_CourseType.courseType_id, edu_CourseType.courseType_title, edu_DLCourses.DLCourses_ID, edu_DLCourses.DLCourses_DLID,edu_DLCourses.DLCourses_TypeID, edu_DLCourses.DLCourses_Name, edu_DLCourses.DLCourses_Description FROM edu_CourseType INNER JOIN edu_DLCourses ON edu_CourseType.courseType_id = edu_DLCourses.DLCourses_TypeID", objConnection);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<DLCoursesClass>();

            while (objReader.Read())
            {
                objCategory = new DLCoursesClass();
                objCategory.iID = int.Parse(objReader["DLCourses_ID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLCourses_DLID"].ToString());
                objCategory.iTypeID = int.Parse(objReader["DLCourses_TypeID"].ToString());
                objCategory.strName = objReader["DLCourses_Name"].ToString();
                objCategory.strDescription = objReader["DLCourses_Description"].ToString();
                objCategory.strType = objReader["courseType_title"].ToString();
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

    internal yo_lib.CoreWebList<DLCoursesClass> fn_getCoursesList()
    {
        CoreWebList<DLCoursesClass> objCategoryList = null;
        DLCoursesClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT (SELECT distancelearning_type FROM edu_DistanceLearning WHERE distancelearning_id=DLCourses_DLID)Distance_UniversityType, (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=DLCourses_DLID)Distance_University, * FROM edu_DLCourses ORDER BY DLCourses_Name ASC", objConnection);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<DLCoursesClass>();

            while (objReader.Read())
            {
                objCategory = new DLCoursesClass();
                objCategory.iID = int.Parse(objReader["DLCourses_ID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLCourses_DLID"].ToString());
                objCategory.iTypeID = int.Parse(objReader["DLCourses_TypeID"].ToString());
                
                objCategory.strType = objReader["Distance_UniversityType"].ToString();
                if (objReader["Distance_UniversityType"].ToString() == "Institute")
                {
                    objCategory.strType = "Colleges";
                }
                
                objCategory.strInstitute = objReader["Distance_University"].ToString();
                objCategory.strName = objReader["DLCourses_Name"].ToString();
                objCategory.strDescription = objReader["DLCourses_Description"].ToString();
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

    internal yo_lib.CoreWebList<DLCoursesClass> fn_getRandom_CoursesList()
    {
        CoreWebList<DLCoursesClass> objCategoryList = null;
        DLCoursesClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 5 (SELECT distancelearning_type FROM edu_DistanceLearning WHERE distancelearning_id=DLCourses_DLID)Distance_UniversityType, (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=DLCourses_DLID)Distance_University, * FROM edu_DLCourses ORDER BY NEWID()", objConnection);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<DLCoursesClass>();

            while (objReader.Read())
            {
                objCategory = new DLCoursesClass();
                objCategory.iID = int.Parse(objReader["DLCourses_ID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLCourses_DLID"].ToString());
                objCategory.iTypeID = int.Parse(objReader["DLCourses_TypeID"].ToString());

                objCategory.strType = objReader["Distance_UniversityType"].ToString();
                if (objReader["Distance_UniversityType"].ToString() == "Institute")
                {
                    objCategory.strType = "Colleges";
                }

                objCategory.strInstitute = objReader["Distance_University"].ToString();
                objCategory.strName = objReader["DLCourses_Name"].ToString();
                objCategory.strDescription = objReader["DLCourses_Description"].ToString();
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

    internal yo_lib.CoreWebList<DLCoursesClass> fn_getCourseByName(string strName)
    {
        CoreWebList<DLCoursesClass> objCategoryList = null;
        DLCoursesClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT (SELECT distancelearning_type FROM edu_DistanceLearning WHERE distancelearning_id=DLCourses_DLID)Distance_UniversityType, (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=DLCourses_DLID)Distance_University, * FROM edu_DLCourses WHERE DLCourses_Name=@DLCourses_Name", objConnection);
            objCommand.Parameters.AddWithValue("@DLCourses_Name", strName);
            objReader = objCommand.ExecuteReader();
            
            objCategoryList = new CoreWebList<DLCoursesClass>();

            while (objReader.Read())
            {
                objCategory = new DLCoursesClass();
                objCategory.iID = int.Parse(objReader["DLCourses_ID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLCourses_DLID"].ToString());
                objCategory.iTypeID = int.Parse(objReader["DLCourses_TypeID"].ToString());

                objCategory.strType = objReader["Distance_UniversityType"].ToString();
                if (objReader["Distance_UniversityType"].ToString() == "Institute")
                {
                    objCategory.strType = "Colleges";
                }

                objCategory.strInstitute = objReader["Distance_University"].ToString();
                objCategory.strName = objReader["DLCourses_Name"].ToString();
                objCategory.strDescription = objReader["DLCourses_Description"].ToString();
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
    
    internal yo_lib.CoreWebList<DLCoursesClass> fn_getRandomDLCourseList()
    {
        CoreWebList<DLCoursesClass> objCategoryList = null;
        DLCoursesClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 5 (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=DLCourses_DLID)Distance_University, * FROM edu_DLCourses ORDER BY NEWID()", objConnection);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<DLCoursesClass>();

            while (objReader.Read())
            {
                objCategory = new DLCoursesClass();
                objCategory.iID = int.Parse(objReader["DLCourses_ID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLCourses_DLID"].ToString());
                objCategory.iTypeID = int.Parse(objReader["DLCourses_TypeID"].ToString());
                objCategory.strInstitute = objReader["Distance_University"].ToString();
                objCategory.strName = objReader["DLCourses_Name"].ToString();
                objCategory.strDescription = objReader["DLCourses_Description"].ToString();
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

    internal CoreWebList<DLCoursesClass> fn_getDLCourseByDistanceID(int iDistanceID)
    {
        CoreWebList<DLCoursesClass> objCategoryList = null;
        DLCoursesClass objCategory = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();

            objCommand = new SqlCommand("SELECT (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=DLCourses_DLID)Distance_University, edu_CourseType.courseType_id, edu_CourseType.courseType_title, edu_DLCourses.DLCourses_ID, edu_DLCourses.DLCourses_DLID,edu_DLCourses.DLCourses_TypeID, edu_DLCourses.DLCourses_Name, edu_DLCourses.DLCourses_Description FROM edu_CourseType INNER JOIN edu_DLCourses ON edu_CourseType.courseType_id = edu_DLCourses.DLCourses_TypeID WHERE edu_DLCourses.DLCourses_DLID = @iDistanceID", objConnection);
            objCommand.Parameters.AddWithValue("@iDistanceID", iDistanceID);
            objReader = objCommand.ExecuteReader();
            objCategoryList = new CoreWebList<DLCoursesClass>();
            while (objReader.Read())
            {
                objCategory = new DLCoursesClass();
                objCategory.iID = int.Parse(objReader["DLCourses_ID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLCourses_DLID"].ToString());
                objCategory.iTypeID = int.Parse(objReader["DLCourses_TypeID"].ToString());
                objCategory.strInstitute = objReader["Distance_University"].ToString();
                objCategory.strName = objReader["DLCourses_Name"].ToString();
                objCategory.strDescription = objReader["DLCourses_Description"].ToString();
                objCategory.strType = objReader["courseType_title"].ToString();
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

    internal CoreWebList<DLCoursesClass> fn_getRandomDLCourseByDistanceID(int iDistanceID)
    {
        CoreWebList<DLCoursesClass> objCategoryList = null;
        DLCoursesClass objCategory = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 5 (SELECT distancelearning_name FROM edu_DistanceLearning WHERE distancelearning_id=DLCourses_DLID)Distance_University, edu_CourseType.courseType_id, edu_CourseType.courseType_title, edu_DLCourses.DLCourses_ID, edu_DLCourses.DLCourses_DLID,edu_DLCourses.DLCourses_TypeID, edu_DLCourses.DLCourses_Name, edu_DLCourses.DLCourses_Description FROM edu_CourseType INNER JOIN edu_DLCourses ON edu_CourseType.courseType_id = edu_DLCourses.DLCourses_TypeID WHERE edu_DLCourses.DLCourses_DLID=@iDistanceID ORDER BY NEWID()", objConnection);
            objCommand.Parameters.AddWithValue("@iDistanceID", iDistanceID);
            objReader = objCommand.ExecuteReader();
            objCategoryList = new CoreWebList<DLCoursesClass>();
            while (objReader.Read())
            {
                objCategory = new DLCoursesClass();
                objCategory.iID = int.Parse(objReader["DLCourses_ID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLCourses_DLID"].ToString());
                objCategory.iTypeID = int.Parse(objReader["DLCourses_TypeID"].ToString());
                objCategory.strInstitute = objReader["Distance_University"].ToString();
                objCategory.strName = objReader["DLCourses_Name"].ToString();
                objCategory.strDescription = objReader["DLCourses_Description"].ToString();
                objCategory.strType = objReader["courseType_title"].ToString();
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

    internal CoreWebList<DLCoursesClass> fn_SearchCoursesList(string strSearchQuery)
    {
        CoreWebList<DLCoursesClass> objCategoryList = null;
        DLCoursesClass objCategory = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand(strSearchQuery, objConnection);
            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<DLCoursesClass>();
            while (objReader.Read())
            {
                objCategory = new DLCoursesClass();
                objCategory.iID = int.Parse(objReader["DLCourses_ID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLCourses_DLID"].ToString());
                objCategory.iTypeID = int.Parse(objReader["DLCourses_TypeID"].ToString());
                objCategory.strName = objReader["DLCourses_Name"].ToString();
                objCategory.strDescription = objReader["DLCourses_Description"].ToString();
                //objCategory.strType = objReader["courseType_title"].ToString();
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

    internal CoreWebList<DLCoursesClass> fn_Search_Courses_List(int DLID, string DLCourses)
    {
        CoreWebList<DLCoursesClass> objCategoryList = null;
        DLCoursesClass objCategory = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM edu_DLCourses WHERE DLCourses_DLID=@DLCourses_DLID AND DLCourses_Name LIKE '%' + @DLCourses_Name + '%' ORDER BY DLCourses_Name", objConnection);

            objCommand.Parameters.AddWithValue("@DLCourses_DLID", DLID);
            objCommand.Parameters.AddWithValue("@DLCourses_Name", DLCourses);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<DLCoursesClass>();
            while (objReader.Read())
            {
                objCategory = new DLCoursesClass();
                objCategory.iID = int.Parse(objReader["DLCourses_ID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLCourses_DLID"].ToString());
                objCategory.iTypeID = int.Parse(objReader["DLCourses_TypeID"].ToString());
                objCategory.strName = objReader["DLCourses_Name"].ToString();
                objCategory.strDescription = objReader["DLCourses_Description"].ToString();
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

    internal CoreWebList<DLCoursesClass> fn_SearchDLInst_ForClient(string strQuery)
    {
        CoreWebList<DLCoursesClass> objDLList = null;
        DLCoursesClass objDL = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();


            objCommand = new SqlCommand(strQuery, objConnection);
            objReader = objCommand.ExecuteReader();

            objDLList = new CoreWebList<DLCoursesClass>();

            while (objReader.Read())
            {
                objDL = new DLCoursesClass();
                objDL.iID = int.Parse(objReader["DLCourses_ID"].ToString());
                objDL.iDistanceID = int.Parse(objReader["DLCourses_DLID"].ToString());
                objDL.strInstitute = objReader["distancelearning_name"].ToString();
                objDL.strName = objReader["DLCourses_Name"].ToString();
                objDL.strCity = objReader["dlCenter_City"].ToString();
                //objDL.strEmail = objReader["testpreparation_email"].ToString();
                //objDL.strWebsite = objReader["testpreparation_website"].ToString();
                //if (strQuery.Contains("distancelearning_logo"))
                //    objDL.strImage = objReader["distancelearning_logo"].ToString();
                //if (strQuery.Contains("distancelearning_desc"))
                //    objDL.strDesc = objReader["distancelearning_desc"].ToString();
                //objDL.strContactInfo = objReader["testpreparation_contactinfo"].ToString();
                //objDL.bIsFeatured = bool.Parse(objReader["distancelearning_featured"].ToString());
                objDL.iCenterCount = int.Parse(objReader["IDCOUNT"].ToString());

                ///objDL.strType = objReader["testPreparationCourses_type"].ToString();

                objDLList.Add(objDL);
            }
            if (objReader != null)
            {
                objReader.Close();
            }

            return objDLList;
        }
        catch (Exception ex)
        {
            throw ex;
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
