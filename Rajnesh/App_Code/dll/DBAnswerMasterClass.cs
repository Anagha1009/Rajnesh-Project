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
/// Summary description for DBAnswerMasterClass
/// </summary>
public class DBAnswerMasterClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    public string fn_saveAnswer(AnswerMasterClass objAnswer)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO  tbl_AnswerMaster (Answer_QID, Answer_UserID, Answer_Reply) VALUES (@Answer_QID, @Answer_UserID, @Answer_Reply)", objConnection);

            objCommand.Parameters.AddWithValue("@Answer_QID", objAnswer.iQuestionID);
            objCommand.Parameters.AddWithValue("@Answer_UserID", objAnswer.iUserID);
            objCommand.Parameters.AddWithValue("@Answer_Reply", objAnswer.strReply);

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

    public string fn_deleteAnswer(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM  tbl_AnswerMaster WHERE Answer_ID=@ID", objConnection);
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

    public CoreWebList<AnswerMasterClass> fn_getAnswerListByQuestionID(int iQuestionID)
    {
        CoreWebList<AnswerMasterClass> objAnswerList = null;
        AnswerMasterClass objAnswer = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strSql = "SELECT * FROM  tbl_AnswerMaster WHERE Answer_QID=@Answer_QID order by Answer_Date Desc";
            objCommand = new SqlCommand(strSql, objConnection);
            objCommand.Parameters.AddWithValue("@Answer_QID", iQuestionID);
            objReader = objCommand.ExecuteReader();
            objAnswerList = new CoreWebList<AnswerMasterClass>();

            while (objReader.Read())
            {
                objAnswer = new AnswerMasterClass();
                
                objAnswer.iID = int.Parse(objReader["Answer_ID"].ToString());
                objAnswer.iQuestionID = int.Parse(objReader["Answer_QID"].ToString());
                objAnswer.iUserID = int.Parse(objReader["Answer_UserID"].ToString());
                objAnswer.strReply = objReader["Answer_Reply"].ToString();
                objAnswer.dtDate = DateTime.Parse(objReader["Answer_Date"].ToString());

                objAnswerList.Add(objAnswer);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objAnswerList;
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

    internal CoreWebList<AnswerMasterClass> fn_getAnswerByID(int iID)
    {
        CoreWebList<AnswerMasterClass> objAnswerList = null;
        AnswerMasterClass objAnswer = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();
            string strSql = "SELECT * FROM tbl_AnswerMaster WHERE Answer_ID=@ID order by Answer_Date Desc";
            objCommand = new SqlCommand(strSql, objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objAnswerList = new CoreWebList<AnswerMasterClass>();

            while (objReader.Read())
            {
                objAnswer = new AnswerMasterClass();

                objAnswer.iID = int.Parse(objReader["Answer_ID"].ToString());
                objAnswer.iQuestionID = int.Parse(objReader["Answer_QID"].ToString());
                objAnswer.iUserID = int.Parse(objReader["Answer_UserID"].ToString());
                objAnswer.strReply = objReader["Answer_Reply"].ToString();
                objAnswer.dtDate = DateTime.Parse(objReader["Answer_Date"].ToString());

                objAnswerList.Add(objAnswer);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objAnswerList;
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
