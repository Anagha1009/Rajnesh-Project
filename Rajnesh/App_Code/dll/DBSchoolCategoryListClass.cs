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
/// Summary description for DBSchoolCategoryListClass
/// </summary>
public class DBSchoolCategoryListClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    private string strCoreConnectionString = ConfigurationManager.ConnectionStrings["CoreConnectionString"].ConnectionString;

	public string fn_saveSchoolCategoryList(SchoolCategoryListClass objSchoolCategoryList)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("INSERT INTO tbl_SchoolCategoryList (SchoolCategoryList_SchoolID, SchoolCategoryList_CategoryID) VALUES (@SchoolCategoryList_SchoolID, @SchoolCategoryList_CategoryID)",objConnection) ;
			objCommand.Parameters.AddWithValue("@SchoolCategoryList_SchoolID", objSchoolCategoryList.iSchoolID);
			objCommand.Parameters.AddWithValue("@SchoolCategoryList_CategoryID", objSchoolCategoryList.iCategoryID);

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

	public string fn_editSchoolCategoryList(SchoolCategoryListClass objSchoolCategoryList)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("UPDATE tbl_SchoolCategoryList SET SchoolCategoryList_SchoolID=@SchoolCategoryList_SchoolID, SchoolCategoryList_CategoryID=@SchoolCategoryList_CategoryID WHERE SchoolCategoryList_ID=@SchoolCategoryList_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@SchoolCategoryList_ID", objSchoolCategoryList.iID);
			objCommand.Parameters.AddWithValue("@SchoolCategoryList_SchoolID", objSchoolCategoryList.iSchoolID);
			objCommand.Parameters.AddWithValue("@SchoolCategoryList_CategoryID", objSchoolCategoryList.iCategoryID);

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

	public string fn_deleteSchoolCategoryList(int iSchoolCategoryListID)
	{
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("DELETE FROM tbl_SchoolCategoryList WHERE SchoolCategoryList_ID=@SchoolCategoryList_ID",objConnection) ;
			objCommand.Parameters.AddWithValue("@SchoolCategoryList_ID", iSchoolCategoryListID);

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

    public string fn_deleteSchoolCategoryBySchoolID(int iSchoolID)
    {
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("DELETE FROM tbl_SchoolCategoryList WHERE SchoolCategoryList_SchoolID=@SchoolCategoryList_SchoolID", objConnection);
            objCommand.Parameters.AddWithValue("@SchoolCategoryList_SchoolID", iSchoolID);

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

	public CoreWebList<SchoolCategoryListClass> fn_getSchoolCategoryList()
	{
		CoreWebList<SchoolCategoryListClass> objSchoolCategoryListList = null;
		SchoolCategoryListClass objSchoolCategoryList = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolCategoryList", objConnection);
			objReader = objCommand.ExecuteReader();
			objSchoolCategoryListList = new CoreWebList<SchoolCategoryListClass>();
			while (objReader.Read())
			{
				objSchoolCategoryList = new SchoolCategoryListClass();
				objSchoolCategoryList.iID = int.Parse(objReader["SchoolCategoryList_ID"].ToString());
				objSchoolCategoryList.iSchoolID = int.Parse(objReader["SchoolCategoryList_SchoolID"].ToString());
				objSchoolCategoryList.iCategoryID = int.Parse(objReader["SchoolCategoryList_CategoryID"].ToString());
				objSchoolCategoryListList.Add(objSchoolCategoryList);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolCategoryListList;
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

	public CoreWebList<SchoolCategoryListClass> fn_getSchoolCategoryListByID(int iSchoolCategoryListID)
	{
		CoreWebList<SchoolCategoryListClass> objSchoolCategoryListList = null;
		SchoolCategoryListClass objSchoolCategoryList = null;
		try
		{
			objConnection = new SqlConnection(strCoreConnectionString);
			objConnection.Open();
			objCommand = new SqlCommand("SELECT * FROM tbl_SchoolCategoryList WHERE SchoolCategoryList_ID=@SchoolCategoryList_ID", objConnection);
			objCommand.Parameters.AddWithValue("@SchoolCategoryList_ID", iSchoolCategoryListID);
			objReader = objCommand.ExecuteReader();
			objSchoolCategoryListList = new CoreWebList<SchoolCategoryListClass>();
			if (objReader.Read())
			{
				objSchoolCategoryList = new SchoolCategoryListClass();
				objSchoolCategoryList.iID = int.Parse(objReader["SchoolCategoryList_ID"].ToString());
				objSchoolCategoryList.iSchoolID = int.Parse(objReader["SchoolCategoryList_SchoolID"].ToString());
				objSchoolCategoryList.iCategoryID = int.Parse(objReader["SchoolCategoryList_CategoryID"].ToString());
				objSchoolCategoryListList.Add(objSchoolCategoryList);
			}
			if (objReader != null)
			{
				objReader.Close();
			}
			return objSchoolCategoryListList;
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

    public CoreWebList<SchoolCategoryListClass> fn_getSchoolCategoryListBySchoolID(int iSchoolID)
    {
        CoreWebList<SchoolCategoryListClass> objSchoolCategoryListList = null;
        SchoolCategoryListClass objSchoolCategoryList = null;
        try
        {
            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_SchoolCategoryList WHERE SchoolCategoryList_SchoolID=@SchoolCategoryList_SchoolID", objConnection);
            objCommand.Parameters.AddWithValue("@SchoolCategoryList_SchoolID", iSchoolID);
            objReader = objCommand.ExecuteReader();
            objSchoolCategoryListList = new CoreWebList<SchoolCategoryListClass>();
            while (objReader.Read())
            {
                objSchoolCategoryList = new SchoolCategoryListClass();
                objSchoolCategoryList.iID = int.Parse(objReader["SchoolCategoryList_ID"].ToString());
                objSchoolCategoryList.iSchoolID = int.Parse(objReader["SchoolCategoryList_SchoolID"].ToString());
                objSchoolCategoryList.iCategoryID = int.Parse(objReader["SchoolCategoryList_CategoryID"].ToString());
                objSchoolCategoryListList.Add(objSchoolCategoryList);
            }
            if (objReader != null)
            {
                objReader.Close();
            }
            return objSchoolCategoryListList;
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
