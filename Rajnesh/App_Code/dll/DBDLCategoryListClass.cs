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
/// Summary description for DBDLCategoryListClass
/// </summary>
public class DBDLCategoryListClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;
    private SqlCommand objCommand1 = null;

    public string strDBError = null;

    internal string fn_saveDLCategoryList(int[] iCatIDArray, int iDistanceID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand1 = new SqlCommand("DELETE FROM edu_DLCategoryList WHERE DLCategoryList_DLID = @iDistanceID", objConnection);
            objCommand1.Parameters.AddWithValue("@iDistanceID", iDistanceID);

            objCommand1.ExecuteNonQuery();

            //HttpContext.Current.Response.Write("Institute ID : "+iDistanceID.ToString());

            for (int i = 0; i < iCatIDArray.Length; i++)
            {
                if (iCatIDArray[i] != 0)
                {
                    objCommand = new SqlCommand("INSERT INTO edu_DLCategoryList(DLCategoryList_DLID,DLCategoryList_CatID) VALUES (@iDistanceID,@CatID)", objConnection);
                    objCommand.Parameters.AddWithValue("@CatID", iCatIDArray[i]);
                    objCommand.Parameters.AddWithValue("@iDistanceID", iDistanceID);
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

    internal string fn_editDLCategoryList(int iID, int[] iCatIDArray, int iDistanceID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand1 = new SqlCommand("DELETE FROM edu_DLCategoryList WHERE DLCategoryList_DLID=@iDistanceID", objConnection);
            objCommand1.Parameters.AddWithValue("@iDistanceID", iDistanceID);

            objCommand.ExecuteNonQuery();

            for (int i = 0; i < iCatIDArray.Length; i++)
            {
                if (iCatIDArray[i] != 0)
                {

                    objCommand = new SqlCommand("UPDATE edu_DLCategoryList SET DLCategoryList_DLID = @iDistanceID, DLCategoryList_CatID=@CatID, instituteCategoryList_SubCatID = @instituteCategoryList_SubCatID  WHERE DLCategoryList_ID = @ID", objConnection);
                    objCommand.Parameters.AddWithValue("@ID", iID);
                    objCommand.Parameters.AddWithValue("@CatID", iCatIDArray[i]);
                    objCommand.Parameters.AddWithValue("@iDistanceID", iDistanceID);                  

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

    internal string fn_deleteDLCategoryList(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_DLCategoryList WHERE DLCategoryList_ID = @ID", objConnection);
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

    internal CoreWebList<DLCategoryListClass> fn_getDLCategoryListByID(int iID)
    {
        CoreWebList<DLCategoryListClass> objCategoryList = null;
        DLCategoryListClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_DLCategoryList WHERE DLCategoryList_ID = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<DLCategoryListClass>();

            if (objReader.Read())
            {
                objCategory = new DLCategoryListClass();
                objCategory.iID = int.Parse(objReader["DLCategoryList_ID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLCategoryList_DLID"].ToString());
                objCategory.iCatID = int.Parse(objReader["DLCategoryList_CatID"].ToString());               
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

    internal CoreWebList<DLCategoryListClass> fn_getDLCategoryList()
    {
        throw new NotImplementedException();
    }

    internal ArrayList fn_getDLCategoryListBy_DLID(int iDistanceID)
    {       

        ArrayList objList = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_DLCategoryList WHERE DLCategoryList_DLID = @iDistanceID", objConnection);
            objCommand.Parameters.AddWithValue("@iDistanceID", iDistanceID);

            objReader = objCommand.ExecuteReader();

            int i = 0;

            objList = new ArrayList();
            while (objReader.Read())
            {
                objList.Add(int.Parse(objReader["DLCategoryList_CatID"].ToString()));
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

    internal CoreWebList<DLCategoryListClass> fn_getDLCategoryListByDLID(int iDistanceID)
    {
        CoreWebList<DLCategoryListClass> objCategoryList = null;
        DLCategoryListClass objCategory = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_DLCategoryList WHERE DLCategoryList_DLID = @iDistanceID", objConnection);
            objCommand.Parameters.AddWithValue("@iDistanceID", iDistanceID);

            objReader = objCommand.ExecuteReader();

            objCategoryList = new CoreWebList<DLCategoryListClass>();

            if (objReader.Read())
            {
                objCategory = new DLCategoryListClass();
                objCategory.iID = int.Parse(objReader["DLCategoryList_ID"].ToString());
                objCategory.iDistanceID = int.Parse(objReader["DLCategoryList_DLID"].ToString());
                objCategory.iCatID = int.Parse(objReader["DLCategoryList_CatID"].ToString());               
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
