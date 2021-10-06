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
using System.Collections;
using yo_lib;

/// <summary>
/// Summary description for DBInstituteCategoryListClass
/// </summary>
public class DBInstituteCategoryListClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;
    private SqlCommand objCommand1 = null;

    public string strDBError = null;

    public string fn_saveInstCategoryList(int[] iCatIDArr, int iInstID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand1 = new SqlCommand("DELETE FROM edu_InstituteCategoryList WHERE instituteCategoryList_instituteID=@InstID", objConnection);
            objCommand1.Parameters.AddWithValue("@InstID", iInstID);

            objCommand1.ExecuteNonQuery();

            //HttpContext.Current.Response.Write("Institute ID : "+iInstID.ToString());

            for (int i = 0; i < iCatIDArr.Length; i++)
            {
                if (iCatIDArr[i] != 0)
                {
                    objCommand = new SqlCommand("INSERT INTO edu_InstituteCategoryList(instituteCategoryList_instituteID,instituteCategoryList_catID) VALUES (@InstID,@CatID)", objConnection);
                    objCommand.Parameters.AddWithValue("@CatID", iCatIDArr[i]);
                    objCommand.Parameters.AddWithValue("@InstID", iInstID);
                    objCommand.ExecuteNonQuery();
                }
            }

            //if (objCommand.ExecuteNonQuery() > 0)
            //{
                return "SUCCESS : Record has been inserted";
            //}
            //else
            //{
            //    return "ERROR : SQL Exception";
            //}
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

    public string fn_editInstCategoryList(int iID, int[] iCatIDArr, int iInstID, int iSubCatID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand1 = new SqlCommand("DELETE FROM edu_InstituteCategoryList WHERE instituteCategoryList_instituteID=@InstID", objConnection);
            objCommand1.Parameters.AddWithValue("@InstID", iInstID);

            objCommand.ExecuteNonQuery();

            for (int i = 0; i < iCatIDArr.Length; i++)
            {
                if (iCatIDArr[i] != 0)
                {

                    objCommand = new SqlCommand("UPDATE edu_InstituteCategoryList SET instituteCategoryList_instituteID = @InstID, instituteCategoryList_catID=@CatID, instituteCategoryList_SubCatID = @instituteCategoryList_SubCatID  WHERE instituteCategoryList_id = @ID", objConnection);
                    objCommand.Parameters.AddWithValue("@ID", iID);
                    objCommand.Parameters.AddWithValue("@CatID", iCatIDArr[i]);
                    objCommand.Parameters.AddWithValue("@InstID", iInstID);
                    objCommand.Parameters.AddWithValue("instituteCategoryList_SubCatID", iSubCatID);

                    objCommand.ExecuteNonQuery();
                }
            }

            //if (objCommand.ExecuteNonQuery() > 0)
            //{
                return "SUCCESS : Record has been updated";
            //}
            //else
            //{
            //    return "ERROR : SQL Exception";
            //}
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

    public string fn_deleteInstCategoryList(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_InstituteCategoryList WHERE instituteCategoryList_id = @ID", objConnection);
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

    public CoreWebList<InstituteCategoryListClass> fn_getInstCategoryList()
    {
        CoreWebList<InstituteCategoryListClass> objCategoryList = null;
        InstituteCategoryListClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_InstituteCategoryList", objConnection);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<InstituteCategoryListClass>();

            while (objReader.Read())
            {
                objCategory = new InstituteCategoryListClass();
                objCategory.iID = int.Parse(objReader["instituteCategoryList_id"].ToString());
                objCategory.iInstID = int.Parse(objReader["instituteCategoryList_instituteID"].ToString());
                objCategory.iCatID = int.Parse(objReader["instituteCategoryList_catID"].ToString());
                objCategory.iSubCatID = int.Parse(objReader["instituteCategoryList_SubCatID"].ToString());
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

    public CoreWebList<InstituteCategoryListClass> fn_getInstCategoryListByID(int iID)
    {
        CoreWebList<InstituteCategoryListClass> objCategoryList = null;
        InstituteCategoryListClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_InstituteCategoryList WHERE instituteCategoryList_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<InstituteCategoryListClass>();

            if (objReader.Read())
            {
                objCategory = new InstituteCategoryListClass();
                objCategory.iID = int.Parse(objReader["instituteCategoryList_id"].ToString());
                objCategory.iInstID = int.Parse(objReader["instituteCategoryList_instituteID"].ToString());
                objCategory.iCatID = int.Parse(objReader["instituteCategoryList_catID"].ToString());
                objCategory.iSubCatID = int.Parse(objReader["instituteCategoryList_SubCatID"].ToString());
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

    public ArrayList fn_getInstCategoryListBy_InstID(int iInstID)
    {
        CoreWebList<InstituteCategoryListClass> objCategoryList = null;
        InstituteCategoryListClass objCategory = null;

        ArrayList objList = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_InstituteCategoryList WHERE instituteCategoryList_instituteID = @InstID", objConnection);
            objCommand.Parameters.AddWithValue("@InstID", iInstID);

            objReader = objCommand.ExecuteReader();

            int i = 0;

            objList = new ArrayList();
            while (objReader.Read())
            {
                objList.Add(int.Parse(objReader["instituteCategoryList_catID"].ToString()));
            }

            return objList;
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

    /*-------------------------18/7/2010----------------------------*/

    public ArrayList fn_getInstCategoryArrayListBy_InstID(int iInstID)
    {
        ArrayList objList = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_InstituteCategoryList WHERE instituteCategoryList_instituteID = @InstID", objConnection);
            objCommand.Parameters.AddWithValue("@InstID", iInstID);

            objReader = objCommand.ExecuteReader();

            int i = 0;

            objList = new ArrayList();
            while (objReader.Read())
            {
                objList.Add(int.Parse(objReader["instituteCategoryList_catID"].ToString()));
            }

            return objList;
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


    /*--------------------------------------------------------------*/

    internal CoreWebList<InstituteCategoryListClass> fn_getInstCategoryListByInstID(int iInstID)
    {
        CoreWebList<InstituteCategoryListClass> objCategoryList = null;
        InstituteCategoryListClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_InstituteCategoryList WHERE instituteCategoryList_instituteID = @iInstID", objConnection);
            objCommand.Parameters.AddWithValue("@iInstID", iInstID);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<InstituteCategoryListClass>();

            if (objReader.Read())
            {
                objCategory = new InstituteCategoryListClass();
                objCategory.iID = int.Parse(objReader["instituteCategoryList_id"].ToString());
                objCategory.iInstID = int.Parse(objReader["instituteCategoryList_instituteID"].ToString());
                objCategory.iCatID = int.Parse(objReader["instituteCategoryList_catID"].ToString());
                objCategory.iSubCatID = int.Parse(objReader["instituteCategoryList_SubCatID"].ToString());
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


    internal CoreWebList<InstituteCategoryListClass> fn_getRandomInstCategoryListByInstID(int iInstID)
    {
        CoreWebList<InstituteCategoryListClass> objCategoryList = null;
        InstituteCategoryListClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT TOP 1 * FROM edu_InstituteCategoryList WHERE instituteCategoryList_instituteID = @iInstID ORDER BY NEWID()", objConnection);
            objCommand.Parameters.AddWithValue("@iInstID", iInstID);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<InstituteCategoryListClass>();

            if (objReader.Read())
            {
                objCategory = new InstituteCategoryListClass();
                objCategory.iID = int.Parse(objReader["instituteCategoryList_id"].ToString());
                objCategory.iInstID = int.Parse(objReader["instituteCategoryList_instituteID"].ToString());
                objCategory.iCatID = int.Parse(objReader["instituteCategoryList_catID"].ToString());
                objCategory.iSubCatID = int.Parse(objReader["instituteCategoryList_SubCatID"].ToString());
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
