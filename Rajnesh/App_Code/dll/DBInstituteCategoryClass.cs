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
/// Summary description for DBInstituteCategoryClass
/// </summary>
public class DBInstituteCategoryClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    public string fn_saveCategory(string strCategoryTitle, string strCategoryDesc, string strImage, int iOrder)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_InstituteCategory(instituteCategory_title,instituteCategory_desc,instituteCategory_image,instituteCategory_order) VALUES (@CategoryTitle,@CategoryDesc,@Image,@iOrder)", objConnection);
            objCommand.Parameters.AddWithValue("@CategoryTitle", strCategoryTitle);
            objCommand.Parameters.AddWithValue("@CategoryDesc", strCategoryDesc);
            objCommand.Parameters.AddWithValue("@Image", strImage);
            objCommand.Parameters.AddWithValue("@iOrder", iOrder);

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

    public string fn_editCategory(int iID, string strCategoryTitle, string strCategoryDesc, string strImage, int iOrder)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_InstituteCategory SET instituteCategory_title = @CategoryTitle, instituteCategory_desc=@CategoryDesc, instituteCategory_image = @Image,instituteCategory_order = @iOrder WHERE instituteCategory_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@CategoryTitle", strCategoryTitle);
            objCommand.Parameters.AddWithValue("@CategoryDesc", strCategoryDesc);
            objCommand.Parameters.AddWithValue("@Image", strImage);
            objCommand.Parameters.AddWithValue("@iOrder", iOrder);

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

    public string fn_deleteCategory(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_InstituteCategory WHERE instituteCategory_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

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

    public CoreWebList<InstituteCategoryClass> fn_getCategoryList()
    {
        CoreWebList<InstituteCategoryClass> objCategoryList = null;
        InstituteCategoryClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_InstituteCategory ORDER BY instituteCategory_order", objConnection);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<InstituteCategoryClass>();

            while (objReader.Read())
            {
                objCategory = new InstituteCategoryClass();
                objCategory.iID = int.Parse(objReader["instituteCategory_id"].ToString());
                objCategory.strCategoryTitle = objReader["instituteCategory_title"].ToString();
                objCategory.strCategoryDesc = objReader["instituteCategory_desc"].ToString();
                objCategory.strImage = objReader["instituteCategory_image"].ToString();
                objCategory.iOrder = int.Parse(objReader["instituteCategory_order"].ToString());
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

    public CoreWebList<InstituteCategoryClass> fn_getOrderedCategoryList()
    {
        CoreWebList<InstituteCategoryClass> objCategoryList = null;
        InstituteCategoryClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_InstituteCategory ORDER BY instituteCategory_title", objConnection);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<InstituteCategoryClass>();

            while (objReader.Read())
            {
                objCategory = new InstituteCategoryClass();
                objCategory.iID = int.Parse(objReader["instituteCategory_id"].ToString());
                objCategory.strCategoryTitle = objReader["instituteCategory_title"].ToString();
                objCategory.strCategoryDesc = objReader["instituteCategory_desc"].ToString();
                objCategory.strImage = objReader["instituteCategory_image"].ToString();
                objCategory.iOrder = int.Parse(objReader["instituteCategory_order"].ToString());
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

    public CoreWebList<InstituteCategoryClass> fn_getCategoryByID(int iID)
    {
        CoreWebList<InstituteCategoryClass> objCategoryList = null;
        InstituteCategoryClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_InstituteCategory WHERE instituteCategory_id = @ID ", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<InstituteCategoryClass>();

            if (objReader.Read())
            {
                objCategory = new InstituteCategoryClass();
                objCategory.iID = int.Parse(objReader["instituteCategory_id"].ToString());
                objCategory.strCategoryTitle = objReader["instituteCategory_title"].ToString();
                objCategory.strCategoryDesc = objReader["instituteCategory_desc"].ToString();
                objCategory.strImage = objReader["instituteCategory_image"].ToString();
                objCategory.iOrder = int.Parse(objReader["instituteCategory_order"].ToString());
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

    internal string fn_editCategoryWithoutImage(int iID, string strCategoryTitle, string strCategoryDesc, int iOrder)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_InstituteCategory SET instituteCategory_title = @CategoryTitle, instituteCategory_desc=@CategoryDesc,instituteCategory_order = @iOrder WHERE instituteCategory_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@CategoryTitle", strCategoryTitle);
            objCommand.Parameters.AddWithValue("@CategoryDesc", strCategoryDesc);
            objCommand.Parameters.AddWithValue("@iOrder", iOrder);


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


    #region Instituet SubCategory

    internal string fn_saveSubCategory(int iCatID, string strSubCategoryTitle, string strSubCategoryDesc)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_instituteSubCategory(instituteSubCategory_catid,instituteSubCategory_title,instituteSubCategory_desc) VALUES (@CatID,@Title,@Desc)", objConnection);
            objCommand.Parameters.AddWithValue("@CatID", iCatID);
            objCommand.Parameters.AddWithValue("@Title", strSubCategoryTitle);
            objCommand.Parameters.AddWithValue("@Desc", strSubCategoryDesc);
            
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

    internal string fn_editSubCategory(int iCatID, int iSubCatID, string strSubCategoryTitle, string strSubCategoryDesc)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_instituteSubCategory SET instituteSubCategory_catid=@CatID,instituteSubCategory_title = @Title, instituteSubCategory_desc=@Desc  WHERE instituteSubCategory_id = @SubCatID", objConnection);
            objCommand.Parameters.AddWithValue("@CatID", iCatID);
            objCommand.Parameters.AddWithValue("@SubCatID", iSubCatID);
            objCommand.Parameters.AddWithValue("@Title", strSubCategoryTitle);
            objCommand.Parameters.AddWithValue("@Desc", strSubCategoryDesc);
            
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

    internal string fn_deleteSubCategory(int iSubCatID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_instituteSubCategory WHERE instituteSubCategory_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iSubCatID);

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
            return "ERROR : " + ex.Message ;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    internal CoreWebList<InstituteCategoryClass> fn_getSubCategoryByID(int iSubCatID)
    {
        CoreWebList<InstituteCategoryClass> objCategoryList = null;
        InstituteCategoryClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_instituteSubCategory WHERE instituteSubCategory_id = @ID ORDER BY instituteSubCategory_title", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iSubCatID);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<InstituteCategoryClass>();

            if (objReader.Read())
            {
                objCategory = new InstituteCategoryClass();
                objCategory.iCatID = int.Parse(objReader["instituteSubCategory_catid"].ToString());
                objCategory.iSubCatID = int.Parse(objReader["instituteSubCategory_id"].ToString());
                objCategory.strSubCategoryTitle = objReader["instituteSubCategory_title"].ToString();
                objCategory.strSubCategoryDesc = objReader["instituteSubCategory_desc"].ToString();
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

    internal CoreWebList<InstituteCategoryClass> fn_getSubCategoryList()
    {
        CoreWebList<InstituteCategoryClass> objCategoryList = null;
        InstituteCategoryClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_instituteSubCategory ORDER BY instituteSubCategory_title", objConnection);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<InstituteCategoryClass>();

            while (objReader.Read())
            {
                objCategory = new InstituteCategoryClass();
                objCategory.iCatID = int.Parse(objReader["instituteSubCategory_catid"].ToString());
                objCategory.iSubCatID = int.Parse(objReader["instituteSubCategory_id"].ToString());
                objCategory.strSubCategoryTitle = objReader["instituteSubCategory_title"].ToString();
                objCategory.strSubCategoryDesc = objReader["instituteSubCategory_desc"].ToString();
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

    #endregion

    internal CoreWebList<InstituteCategoryClass> fn_getSubCategoryByCatID(int iCatID)
    {
        CoreWebList<InstituteCategoryClass> objCategoryList = null;
        InstituteCategoryClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_instituteSubCategory WHERE instituteSubCategory_catid = @CatID ORDER BY instituteSubCategory_title", objConnection);
            objCommand.Parameters.AddWithValue("@CatID", iCatID);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<InstituteCategoryClass>();

            while (objReader.Read())
            {
                objCategory = new InstituteCategoryClass();
                objCategory.iCatID = int.Parse(objReader["instituteSubCategory_catid"].ToString());
                objCategory.iSubCatID = int.Parse(objReader["instituteSubCategory_id"].ToString());
                objCategory.strSubCategoryTitle = objReader["instituteSubCategory_title"].ToString();
                objCategory.strSubCategoryDesc = objReader["instituteSubCategory_desc"].ToString();
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

    internal CoreWebList<InstituteCategoryClass> fn_getCategoryList_Top8()
    {
        CoreWebList<InstituteCategoryClass> objCategoryList = null;
        InstituteCategoryClass objCategory = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT TOP 8 * FROM edu_InstituteCategory ORDER BY instituteCategory_order", objConnection);
            objReader = objCommand.ExecuteReader();
            objCategoryList = new CoreWebList<InstituteCategoryClass>();
            while (objReader.Read())
            {
                objCategory = new InstituteCategoryClass();
                objCategory.iID = int.Parse(objReader["instituteCategory_id"].ToString());
                objCategory.strCategoryTitle = objReader["instituteCategory_title"].ToString();
                objCategory.strCategoryDesc = objReader["instituteCategory_desc"].ToString();
                objCategory.strImage = objReader["instituteCategory_image"].ToString();
                objCategory.iOrder = int.Parse(objReader["instituteCategory_order"].ToString());
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

    internal CoreWebList<InstituteCategoryClass> fn_getCategoryList_Top3()
    {
        CoreWebList<InstituteCategoryClass> objCategoryList = null;
        InstituteCategoryClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 3 * FROM edu_InstituteCategory ORDER BY newid(),instituteCategory_title", objConnection);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<InstituteCategoryClass>();

            while (objReader.Read())
            {
                objCategory = new InstituteCategoryClass();
                objCategory.iID = int.Parse(objReader["instituteCategory_id"].ToString());
                objCategory.strCategoryTitle = objReader["instituteCategory_title"].ToString();
                objCategory.strCategoryDesc = objReader["instituteCategory_desc"].ToString();
                objCategory.strImage = objReader["instituteCategory_image"].ToString();
                objCategory.iOrder = int.Parse(objReader["instituteCategory_order"].ToString());
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
}
