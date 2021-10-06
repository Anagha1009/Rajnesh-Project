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
/// Summary description for DBStateMasterClass
/// </summary>
public class DBStateMasterClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    

    public string fn_saveState(string strStateName)
    {        
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO edu_State (state_title) VALUES (@name)", objConnection);
            objCommand.Parameters.AddWithValue("@name", strStateName);
            

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

    public string fn_editState(int iStateID, string strStateName)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_State SET state_title = @name  WHERE state_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@name", strStateName);
                        
            objCommand.Parameters.AddWithValue("@ID", iStateID);

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
            //ErrorClass objError = new ErrorClass();
            //objError.fn_LogError(ex.Message, ex.StackTrace, 1);

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

    public string fn_deleteState(int iStateID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_State WHERE state_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iStateID);

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
            //ErrorClass objError = new ErrorClass();
            //objError.fn_LogError(ex.Message, ex.StackTrace, 1);

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

    public CoreWebList<StateMasterClass> fn_getStateListByID(int iID)
    {
        CoreWebList<StateMasterClass> objStateList = null;
        StateMasterClass objState = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strSql = "SELECT edu_State.state_id, edu_State.state_title  FROM edu_State WHERE edu_State.state_id=@iID";

            objCommand = new SqlCommand(strSql, objConnection);

            objCommand.Parameters.AddWithValue("@iID", iID);

            objReader = objCommand.ExecuteReader();

            objStateList = new CoreWebList<StateMasterClass>();

            while (objReader.Read())
            {
                objState = new StateMasterClass();
                objState.iID = int.Parse(objReader[0].ToString());
                objState.strStateName = objReader[1].ToString();
                                
                objStateList.Add(objState);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objStateList;
        }
        catch (Exception ex)
        {
            //ErrorClass objError = new ErrorClass();
            //objError.fn_LogError(ex.Message, ex.StackTrace, 1);

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

    public CoreWebList<StateMasterClass> fn_getStateList()
    {
        CoreWebList<StateMasterClass> objStateList = null;
        StateMasterClass objState = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strSql = "SELECT edu_State.state_id,edu_State.state_title FROM edu_State";

            objCommand = new SqlCommand(strSql, objConnection);

            objReader = objCommand.ExecuteReader();

            objStateList = new CoreWebList<StateMasterClass>();

            while (objReader.Read())
            {
                objState = new StateMasterClass();
                objState.iID = int.Parse(objReader[0].ToString());
                objState.strStateName = objReader[1].ToString();
                
                objStateList.Add(objState);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objStateList;
        }
        catch (Exception ex)
        {
            //ErrorClass objError = new ErrorClass();
            //objError.fn_LogError(ex.Message, ex.StackTrace, 1);

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

    

    internal CoreWebList<StateMasterClass> fn_getStateByStateName(string strStateName)
    {
        CoreWebList<StateMasterClass> objStateList = null;
        StateMasterClass objState = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strSql = "SELECT edu_State.state_id, edu_State.state_title FROM edu_State WHERE edu_State.state_title = @stateTitle";

            objCommand = new SqlCommand(strSql, objConnection);

            objCommand.Parameters.AddWithValue("@stateTitle", strStateName);

            objReader = objCommand.ExecuteReader();

            objStateList = new CoreWebList<StateMasterClass>();

            while (objReader.Read())
            {
                objState = new StateMasterClass();
                objState.iID = int.Parse(objReader[0].ToString());
                objState.strStateName = objReader[1].ToString();
                
                objStateList.Add(objState);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objStateList;
        }
        catch (Exception ex)
        {
            //ErrorClass objError = new ErrorClass();
            //objError.fn_LogError(ex.Message, ex.StackTrace, 1);

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
