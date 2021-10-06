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
/// Summary description for DBQuestionMasterClass
/// </summary>
public class DBQuestionMasterClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;


    public string fn_saveQuestion(int iUserID, string strQuestion, string strUserName,int iAbuseUserID,bool bAbuse, string strType)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO  tbl_QuestionMaster (Question_UserID, Question_QuestionText, Question_Name,Question_Abuse,Question_AbuseUserID, Question_Type) VALUES (@Question_UserID,@Question_QuestionText, @strUserName,@abuse,@abuseUserId, @Question_Type)", objConnection);
            objCommand.Parameters.AddWithValue("@Question_QuestionText", strQuestion);
            objCommand.Parameters.AddWithValue("@Question_UserID", iUserID);
            objCommand.Parameters.AddWithValue("@strUserName", strUserName);
            objCommand.Parameters.AddWithValue("@abuseUserId",iAbuseUserID);
            objCommand.Parameters.AddWithValue("@abuse", bAbuse);
            objCommand.Parameters.AddWithValue("@Question_Type", strType);

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



    public int fn_save_Question(int iUserID, string strQuestion, string strUserName, int iAbuseUserID, bool bAbuse, string strType)
    {
        try
        {
            int iQuestionID = 0;

            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO  tbl_QuestionMaster (Question_UserID, Question_QuestionText, Question_Name,Question_Abuse,Question_AbuseUserID, Question_Type) VALUES (@Question_UserID,@Question_QuestionText, @strUserName,@abuse,@abuseUserId, @Question_Type);SELECT @pk_new = @@IDENTITY", objConnection);
            objCommand.Parameters.AddWithValue("@Question_QuestionText", strQuestion);
            objCommand.Parameters.AddWithValue("@Question_UserID", iUserID);
            objCommand.Parameters.AddWithValue("@strUserName", strUserName);
            objCommand.Parameters.AddWithValue("@abuseUserId", iAbuseUserID);
            objCommand.Parameters.AddWithValue("@abuse", bAbuse);
            objCommand.Parameters.AddWithValue("@Question_Type", strType);


            SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
            spInsertedKey.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(spInsertedKey);


            if (objCommand.ExecuteNonQuery() > 0)
            {

                iQuestionID = int.Parse(objCommand.Parameters["@pk_new"].Value.ToString());
                return iQuestionID;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }



    public string fn_editQuestion(int iID, int iUserID, string strQuestion, int iAbuseUserID, bool bAbuse)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE  tbl_QuestionMaster SET  Question_QuestionText = @Question_QuestionText,Question_UserID = @Question_UserID, Question_Abuse=@abuse,Question_AbuseUserID=@iUserID  WHERE Question_id = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@Question_QuestionText", strQuestion);
            objCommand.Parameters.AddWithValue("@Question_UserID", iUserID);
            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@abuseUserId", iAbuseUserID);
            objCommand.Parameters.AddWithValue("@abuse", bAbuse);

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


    public string fn_edit_Question(int iID, string strQuestion)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE tbl_QuestionMaster SET Question_QuestionText=@Question_QuestionText WHERE Question_id = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@Question_QuestionText", strQuestion);

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


    public string fn_deleteQuestion(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM  tbl_QuestionMaster WHERE Question_id = @ID", objConnection);
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

    public CoreWebList<QuestionMasterClass> fn_getQuestionListByID(int iID)
    {
        CoreWebList<QuestionMasterClass> objQuestionList = null;
        QuestionMasterClass objQuestion = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strSql = "SELECT * FROM tbl_QuestionMaster WHERE  Question_id=@iID order by Question_Date";

            objCommand = new SqlCommand(strSql, objConnection);

            objCommand.Parameters.AddWithValue("@iID", iID);

            objReader = objCommand.ExecuteReader();

            objQuestionList = new CoreWebList<QuestionMasterClass>();

            while (objReader.Read())
            {
                objQuestion = new QuestionMasterClass();
                objQuestion.iID = int.Parse(objReader["Question_ID"].ToString());
                objQuestion.strQuestion = objReader["Question_QuestionText"].ToString();
                objQuestion.iUserID = int.Parse(objReader["Question_UserID"].ToString());
                objQuestion.dtDate = DateTime.Parse(objReader["Question_Date"].ToString());
                //objQuestion.strUserName = objReader["UserName"].ToString();
                objQuestion.iAbuseUserID = int.Parse(objReader["Question_AbuseUserID"].ToString());
                objQuestion.bAbuse = bool.Parse(objReader["Question_Abuse"].ToString());
                objQuestion.strType = objReader["Question_Type"].ToString();

                objQuestionList.Add(objQuestion);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objQuestionList;
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

    public CoreWebList<QuestionMasterClass> fn_getQuestionList()
    {
        CoreWebList<QuestionMasterClass> objQuestionList = null;
        QuestionMasterClass objQuestion = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strSql = "SELECT * FROM tbl_QuestionMaster order by Question_Date desc";

            objCommand = new SqlCommand(strSql, objConnection);

            objReader = objCommand.ExecuteReader();

            objQuestionList = new CoreWebList<QuestionMasterClass>();

            while (objReader.Read())
            {
                objQuestion = new QuestionMasterClass();
                objQuestion.iID = int.Parse(objReader["Question_id"].ToString());
                objQuestion.strQuestion = objReader["Question_QuestionText"].ToString();
                objQuestion.iUserID = int.Parse(objReader["Question_UserID"].ToString());
                objQuestion.dtDate = DateTime.Parse(objReader["Question_Date"].ToString());
                objQuestion.iAbuseUserID = int.Parse(objReader["Question_AbuseUserID"].ToString());
                objQuestion.bAbuse = bool.Parse(objReader["Question_Abuse"].ToString());
                objQuestion.strType = objReader["Question_Type"].ToString();

                objQuestionList.Add(objQuestion);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objQuestionList;
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

    public CoreWebList<QuestionMasterClass> fn_getRandomQuestionList(int iRowCount)
    {
        CoreWebList<QuestionMasterClass> objQuestionList = null;
        QuestionMasterClass objQuestion = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strSql = "SELECT TOP " + iRowCount + " * FROM tbl_QuestionMaster order by NEWID()";

            objCommand = new SqlCommand(strSql, objConnection);

            objReader = objCommand.ExecuteReader();

            objQuestionList = new CoreWebList<QuestionMasterClass>();

            while (objReader.Read())
            {
                objQuestion = new QuestionMasterClass();
                objQuestion.iID = int.Parse(objReader["Question_id"].ToString());
                objQuestion.strQuestion = objReader["Question_QuestionText"].ToString();
                objQuestion.iUserID = int.Parse(objReader["Question_UserID"].ToString());
                objQuestion.dtDate = DateTime.Parse(objReader["Question_Date"].ToString());
                objQuestion.iAbuseUserID = int.Parse(objReader["Question_AbuseUserID"].ToString());
                objQuestion.bAbuse = bool.Parse(objReader["Question_Abuse"].ToString());
                objQuestion.strType = objReader["Question_Type"].ToString();

                objQuestionList.Add(objQuestion);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objQuestionList;
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

    public CoreWebList<QuestionMasterClass> fn_getRandomQuestionListByType(int iRowCount, string strType)
    {
        CoreWebList<QuestionMasterClass> objQuestionList = null;
        QuestionMasterClass objQuestion = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strSql = "SELECT TOP " + iRowCount + " * FROM tbl_QuestionMaster WHERE Question_Type=@Question_Type order by NEWID()";
            
            objCommand = new SqlCommand(strSql, objConnection);
            
            objCommand.Parameters.AddWithValue("@Question_Type", strType);
            
            objReader = objCommand.ExecuteReader();

            objQuestionList = new CoreWebList<QuestionMasterClass>();

            while (objReader.Read())
            {
                objQuestion = new QuestionMasterClass();
                objQuestion.iID = int.Parse(objReader["Question_id"].ToString());
                objQuestion.strQuestion = objReader["Question_QuestionText"].ToString();
                objQuestion.iUserID = int.Parse(objReader["Question_UserID"].ToString());
                objQuestion.dtDate = DateTime.Parse(objReader["Question_Date"].ToString());
                objQuestion.iAbuseUserID = int.Parse(objReader["Question_AbuseUserID"].ToString());
                objQuestion.bAbuse = bool.Parse(objReader["Question_Abuse"].ToString());
                objQuestion.strType = objReader["Question_Type"].ToString();

                objQuestionList.Add(objQuestion);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objQuestionList;
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

    public CoreWebList<QuestionMasterClass> fn_getQuestionByKey(string strKey)
    {
        CoreWebList<QuestionMasterClass> objQuestionList = null;
        QuestionMasterClass objQuestion = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strSql = "SELECT * FROM tbl_QuestionMaster WHERE Question_QuestionText like '%" + strKey + "%'";

            objCommand = new SqlCommand(strSql, objConnection);

            objReader = objCommand.ExecuteReader();

            objQuestionList = new CoreWebList<QuestionMasterClass>();

            while (objReader.Read())
            {
                objQuestion = new QuestionMasterClass();
                objQuestion.iID = int.Parse(objReader["Question_id"].ToString());
                objQuestion.strQuestion = objReader["Question_QuestionText"].ToString();
                objQuestion.iUserID = int.Parse(objReader["Question_UserID"].ToString());
                objQuestion.dtDate = DateTime.Parse(objReader["Question_Date"].ToString());
                objQuestion.iAbuseUserID = int.Parse(objReader["Question_AbuseUserID"].ToString());
                objQuestion.bAbuse = bool.Parse(objReader["Question_Abuse"].ToString());
                objQuestion.strUserName = objReader["Question_Name"].ToString();
                objQuestion.strType = objReader["Question_Type"].ToString();
                
                objQuestionList.Add(objQuestion);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objQuestionList;
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

    public CoreWebList<QuestionMasterClass> fn_getQuestion_List()
    {
        CoreWebList<QuestionMasterClass> objQuestionList = null;
        QuestionMasterClass objQuestion = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strSql = "SELECT * from tbl_QuestionMaster";

            objCommand = new SqlCommand(strSql, objConnection);

            objReader = objCommand.ExecuteReader();

            objQuestionList = new CoreWebList<QuestionMasterClass>();

            while (objReader.Read())
            {
                objQuestion = new QuestionMasterClass();
                objQuestion.iID = int.Parse(objReader["Question_id"].ToString());
                objQuestion.strQuestion = objReader["Question_QuestionText"].ToString();
                objQuestion.iUserID = int.Parse(objReader["Question_UserID"].ToString());
                objQuestion.dtDate = DateTime.Parse(objReader["Question_Date"].ToString());
                objQuestion.iAbuseUserID = int.Parse(objReader["Question_AbuseUserID"].ToString());
                objQuestion.bAbuse = bool.Parse(objReader["Question_Abuse"].ToString());
                objQuestion.strType = objReader["Question_Type"].ToString();

                objQuestionList.Add(objQuestion);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objQuestionList;
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


    public CoreWebList<QuestionMasterClass> fn_getQuestionListByUserID(int iUserID)
    {
        CoreWebList<QuestionMasterClass> objQuestionList = null;
        QuestionMasterClass objQuestion = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strSql = "SELECT  * FROM tbl_QuestionMaster WHERE Question_UserID = @iUserID";

            objCommand = new SqlCommand(strSql, objConnection);

            objCommand.Parameters.AddWithValue("@iUserID", iUserID);

            objReader = objCommand.ExecuteReader();

            objQuestionList = new CoreWebList<QuestionMasterClass>();

            while (objReader.Read())
            {
                objQuestion = new QuestionMasterClass();
                objQuestion.iID = int.Parse(objReader["Question_id"].ToString());
                objQuestion.strQuestion = objReader["Question_QuestionText"].ToString();
                objQuestion.iUserID = int.Parse(objReader["Question_UserID"].ToString());
                objQuestion.dtDate = DateTime.Parse(objReader["Question_Date"].ToString());
                objQuestion.strUserName = objReader["UserName"].ToString();
                objQuestion.iAbuseUserID = int.Parse(objReader["Question_AbuseUserID"].ToString());
                objQuestion.bAbuse = bool.Parse(objReader["Question_Abuse"].ToString());
                objQuestion.strType = objReader["Question_Type"].ToString();

                objQuestionList.Add(objQuestion);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objQuestionList;
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

    internal CoreWebList<QuestionMasterClass> fn_getQuestionByID(int iID)
    {
        CoreWebList<QuestionMasterClass> objQuestionList = null;
        QuestionMasterClass objQuestion = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strSql = "SELECT * FROM tbl_QuestionMaster WHERE  Question_id=@Question_id order by Question_Date";
            objCommand = new SqlCommand(strSql, objConnection);
            objCommand.Parameters.AddWithValue("@Question_id", iID);
            objReader = objCommand.ExecuteReader();
            objQuestionList = new CoreWebList<QuestionMasterClass>();

            while (objReader.Read())
            {
                objQuestion = new QuestionMasterClass();
                objQuestion.iID = int.Parse(objReader["Question_ID"].ToString());
                objQuestion.strQuestion = objReader["Question_QuestionText"].ToString();
                objQuestion.iUserID = int.Parse(objReader["Question_UserID"].ToString());
                objQuestion.dtDate = DateTime.Parse(objReader["Question_Date"].ToString());
                objQuestion.strUserName = objReader["Question_Name"].ToString();
                objQuestion.iAbuseUserID = int.Parse(objReader["Question_AbuseUserID"].ToString());
                objQuestion.bAbuse = bool.Parse(objReader["Question_Abuse"].ToString());
                objQuestion.strEmailId = objReader["Question_Email"].ToString();
                objQuestion.strType = objReader["Question_Type"].ToString();

                objQuestionList.Add(objQuestion);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objQuestionList;
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

    internal CoreWebList<QuestionMasterClass> fn_getQuestionByQuery(string strQuery)
    {
        CoreWebList<QuestionMasterClass> objQuestionList = null;
        QuestionMasterClass objQuestion = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strSql = strQuery;
            objCommand = new SqlCommand(strSql, objConnection);
            objReader = objCommand.ExecuteReader();
            objQuestionList = new CoreWebList<QuestionMasterClass>();

            while (objReader.Read())
            {
                objQuestion = new QuestionMasterClass();
                objQuestion.iID = int.Parse(objReader["Question_ID"].ToString());
                objQuestion.strQuestion = objReader["Question_QuestionText"].ToString();
                objQuestion.iUserID = int.Parse(objReader["Question_UserID"].ToString());
                objQuestion.dtDate = DateTime.Parse(objReader["Question_Date"].ToString());
                objQuestion.strUserName = objReader["Question_Name"].ToString();
                objQuestion.iAbuseUserID = int.Parse(objReader["Question_AbuseUserID"].ToString());
                objQuestion.bAbuse = bool.Parse(objReader["Question_Abuse"].ToString());
                objQuestion.strEmailId = objReader["Question_Email"].ToString();
                objQuestion.strType = objReader["Question_Type"].ToString();

                objQuestionList.Add(objQuestion);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objQuestionList;
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

    public string fn_RemoveFromadmin(int iId, bool bAbuse)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();

            objCommand = new SqlCommand("UPDATE tbl_QuestionMaster SET Question_Abuse=@abuse WHERE Question_ID = @ID ", objConnection);

            objCommand.Parameters.AddWithValue("@abuse", bAbuse);
            objCommand.Parameters.AddWithValue("@ID", iId);

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
    public string fn_RemoveFromClient(int iUserID, int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            objConnection.Open();

            objCommand = new SqlCommand("UPDATE tbl_QuestionMaster SET Question_Abuse = 1, Question_AbuseUserID = @UserID  WHERE Question_ID = @ID ", objConnection);

            objCommand.Parameters.AddWithValue("@ID", iID);
            objCommand.Parameters.AddWithValue("@UserID", iUserID);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Request Sent";
            }
            else
            {
                return "ERROR : SQL Exception";
            }

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
    public bool fn_RemoveByID(int iId)
    {
        QuestionMasterClass objCM = null;
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT Question_Abuse FROM tbl_QuestionMaster WHERE Question_ID = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iId);

            objReader = objCommand.ExecuteReader();

            while (objReader.Read())
            {
                objCM = new QuestionMasterClass();

                objCM.bAbuse = bool.Parse(objReader["Question_Abuse"].ToString());
            }

            return objCM.bAbuse;
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
    public CoreWebList<QuestionMasterClass> fn_getAbuseList()
    {
        CoreWebList<QuestionMasterClass> objQuestionList = null;
        QuestionMasterClass objQuestion = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT  QM.*,UI.user_fName+ ' '+ UI.user_lName as UserName FROM tbl_QuestionMaster AS QM INNER JOIN edu_UserInfo AS UI ON QM.Question_AbuseUserID = UI.user_ID where QM.Question_Abuse='true' order by QM.Question_Date desc", objConnection);

            objReader = objCommand.ExecuteReader();

            objQuestionList = new CoreWebList<QuestionMasterClass>();

            while (objReader.Read())
            {
                objQuestion = new QuestionMasterClass();
                objQuestion.iID = int.Parse(objReader["Question_id"].ToString());
                objQuestion.strQuestion = objReader["Question_QuestionText"].ToString();
                objQuestion.iUserID = int.Parse(objReader["Question_UserID"].ToString());
                objQuestion.dtDate = DateTime.Parse(objReader["Question_Date"].ToString());
                objQuestion.iAbuseUserID = int.Parse(objReader["Question_AbuseUserID"].ToString());
                objQuestion.bAbuse = bool.Parse(objReader["Question_Abuse"].ToString());
                objQuestion.strType = objReader["Question_Type"].ToString();

                if (objReader["Question_UserID"].ToString() != "0")
                {
                    objQuestion.strUserName = objReader["UserName"].ToString();
                }
                else
                {
                    objQuestion.strUserName = objReader["Question_Name"].ToString();
                }

                objQuestionList.Add(objQuestion);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objQuestionList;
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



    /*----------------13/7/2010-------------------*/


    public CoreWebList<QuestionMasterClass> fn_getAbuseQuestionList()
    {
        CoreWebList<QuestionMasterClass> objQuestionList = null;
        QuestionMasterClass objQuestion = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT Question_ID, Question_UserID, Question_QuestionText, Question_Date, Question_Name, Question_Abuse,Question_AbuseUserID FROM dbo.tbl_QuestionMaster WHERE(Question_Abuse = 'true')", objConnection);

            objReader = objCommand.ExecuteReader();

            objQuestionList = new CoreWebList<QuestionMasterClass>();

            while (objReader.Read())
            {
                objQuestion = new QuestionMasterClass();
                objQuestion.iID = int.Parse(objReader["Question_id"].ToString());
                objQuestion.strQuestion = objReader["Question_QuestionText"].ToString();
                objQuestion.iUserID = int.Parse(objReader["Question_UserID"].ToString());
                objQuestion.dtDate = DateTime.Parse(objReader["Question_Date"].ToString());
                objQuestion.iAbuseUserID = int.Parse(objReader["Question_AbuseUserID"].ToString());
                objQuestion.bAbuse = bool.Parse(objReader["Question_Abuse"].ToString());
                objQuestion.strType = objReader["Question_Type"].ToString();

                if (objReader["Question_UserID"].ToString() == "0")
                {
                    objQuestion.strUserName = objReader["Question_Name"].ToString();
                }
                objQuestionList.Add(objQuestion);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objQuestionList;
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



    /*--------------------------------------------*/

    public CoreWebList<QuestionMasterClass> fn_QuestionListRandom(int iStartRow, int iEndRow)
    {
        CoreWebList<QuestionMasterClass> objQuestionList = null;
        QuestionMasterClass objQuestion = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            string strSql = "Select *  From (SELECT *, row_number() OVER (order by  newid()) as TR FROM tbl_QuestionMaster ) As TR Where TR between @StartRow and @EndRow";

            objCommand = new SqlCommand(strSql, objConnection);

            objCommand.Parameters.AddWithValue("@StartRow", iStartRow);
            objCommand.Parameters.AddWithValue("@EndRow", iEndRow);
            

            objReader = objCommand.ExecuteReader();

            objQuestionList = new CoreWebList<QuestionMasterClass>();

            while (objReader.Read())
            {
                objQuestion = new QuestionMasterClass();
                objQuestion.iID = int.Parse(objReader["Question_id"].ToString());
                objQuestion.strQuestion = objReader["Question_QuestionText"].ToString();
                objQuestion.iUserID = int.Parse(objReader["Question_UserID"].ToString());
                objQuestion.dtDate = DateTime.Parse(objReader["Question_Date"].ToString());
                objQuestion.iAbuseUserID = int.Parse(objReader["Question_AbuseUserID"].ToString());
                objQuestion.bAbuse = bool.Parse(objReader["Question_Abuse"].ToString());
                objQuestion.strUserName = objReader["Question_Name"].ToString();
                objQuestion.strType = objReader["Question_Type"].ToString();

                objQuestionList.Add(objQuestion);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objQuestionList;
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
