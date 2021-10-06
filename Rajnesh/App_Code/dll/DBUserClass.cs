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
/// Summary description for DBUserClass
/// </summary>
public class DBUserClass
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;

    public string strDBError = null;

    public int fn_saveUser(UserClass oUser)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("INSERT INTO tbl_Users (City_id, Name, Email, Password, Date_birth, Gender, Phone, Photo, Reg_Date, Ip_Address) VALUES (@City_id, @Name, @Email, @Password, @Date_birth, @Gender, @Phone, @Photo,  @Reg_Date, @Ip_Address);SELECT @PK_New = @@IDENTITY", objConnection);

            SqlParameter insertedKey = new SqlParameter("@PK_New", SqlDbType.Int);
            insertedKey.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(insertedKey);

            objCommand.Parameters.AddWithValue("@City_id", oUser.iCityID);
            objCommand.Parameters.AddWithValue("@Name", oUser.strName);
            objCommand.Parameters.AddWithValue("@Email", oUser.strEmail);
            objCommand.Parameters.AddWithValue("@Password", oUser.strPassword);
            objCommand.Parameters.AddWithValue("@Date_birth", oUser.dtDOB);
            objCommand.Parameters.AddWithValue("@Gender", oUser.bGender);
            objCommand.Parameters.AddWithValue("@Phone", oUser.strPhone);
            objCommand.Parameters.AddWithValue("@Photo", oUser.strPhoto);
            objCommand.Parameters.AddWithValue("@Reg_Date", DateTime.Now);
            objCommand.Parameters.AddWithValue("@Ip_Address", oUser.strIpAddress);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                int iUserID = int.Parse(objCommand.Parameters["@PK_New"].Value.ToString());
                return iUserID;
            }
            else
            {
                return 0;
            }
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

    public string fn_editUser(UserClass oUser)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE tbl_Users SET City_id=@City_id, Name=@Name, Email=@Email, Date_birth=@Date_birth, Gender=@Gender, Phone=@Phone, Photo=@Photo WHERE ID = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", oUser.iID);
            objCommand.Parameters.AddWithValue("@City_id", oUser.iCityID);
            objCommand.Parameters.AddWithValue("@Name", oUser.strName);
            objCommand.Parameters.AddWithValue("@Email", oUser.strEmail);
            objCommand.Parameters.AddWithValue("@Date_birth", oUser.dtDOB);
            objCommand.Parameters.AddWithValue("@Gender", oUser.bGender);
            objCommand.Parameters.AddWithValue("@Phone", oUser.strPhone);
            objCommand.Parameters.AddWithValue("@Photo", oUser.strPhoto);

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

    public string fn_editUserStatus(UserClass oUser)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("UPDATE tbl_Users SET Active=@Active WHERE ID = @ID", objConnection);

            objCommand.Parameters.AddWithValue("@ID", oUser.iID);
            objCommand.Parameters.AddWithValue("@Active", oUser.bActive);


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

    public string fn_deleteUser(int iID)
    {
        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM tbl_Users WHERE ID = @ID", objConnection);
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
    
    public CoreWebList<UserClass> fn_getUserList()
    {
        CoreWebList<UserClass> objUserList = null;
        UserClass objUser = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM tbl_Users", objConnection);

            objReader = objCommand.ExecuteReader();

            objUserList = new CoreWebList<UserClass>();

            while (objReader.Read())
            {
                objUser = new UserClass();

                objUser.iID = int.Parse(objReader["ID"].ToString());
                objUser.iCityID = int.Parse(objReader["City_id"].ToString());
                objUser.strName = objReader["Name"].ToString();
                objUser.strEmail = objReader["Email"].ToString();
                objUser.strPassword = objReader["Password"].ToString();
                objUser.dtDOB = DateTime.Parse(objReader["Date_birth"].ToString());
                objUser.bGender = bool.Parse(objReader["Gender"].ToString());
                objUser.strPhone = objReader["Phone"].ToString();
                objUser.strPhoto = objReader["Photo"].ToString();
                objUser.dtRegDate = DateTime.Parse(objReader["Reg_Date"].ToString());
                objUser.strIpAddress = objReader["Ip_Address"].ToString();
                objUser.bActive = bool.Parse(objReader["Active"].ToString());

                objUserList.Add(objUser);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objUserList;
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

    public CoreWebList<UserClass> fn_getUserByID(int iID)
    {
        CoreWebList<UserClass> objUserList = null;
        UserClass objUser = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM tbl_Users WHERE ID = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", iID);

            objReader = objCommand.ExecuteReader();

            objUserList = new CoreWebList<UserClass>();

            if (objReader.Read())
            {
                objUser = new UserClass();

                objUser.iID = int.Parse(objReader["ID"].ToString());
                objUser.iCityID = int.Parse(objReader["City_id"].ToString());
                objUser.strName = objReader["Name"].ToString();
                objUser.strEmail = objReader["Email"].ToString();
                objUser.strPassword = objReader["Password"].ToString();
                objUser.dtDOB = DateTime.Parse(objReader["Date_birth"].ToString());
                objUser.bGender = bool.Parse(objReader["Gender"].ToString());
                objUser.strPhone = objReader["Phone"].ToString();
                objUser.strPhoto = objReader["Photo"].ToString();
                objUser.dtRegDate = DateTime.Parse(objReader["Reg_Date"].ToString());
                objUser.strIpAddress = objReader["Ip_Address"].ToString();
                objUser.bActive = bool.Parse(objReader["Active"].ToString());

                objUserList.Add(objUser);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objUserList;
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

    public CoreWebList<UserClass> fn_getUserByEmail(string strEmail)
    {
        CoreWebList<UserClass> objUserList = null;
        UserClass objUser = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM tbl_Users WHERE Email = @Email", objConnection);
            objCommand.Parameters.AddWithValue("@Email", strEmail);

            objReader = objCommand.ExecuteReader();

            objUserList = new CoreWebList<UserClass>();

            if (objReader.Read())
            {
                objUser = new UserClass();

                objUser.iID = int.Parse(objReader["ID"].ToString());
                objUser.iCityID = int.Parse(objReader["City_id"].ToString());
                objUser.strName = objReader["Name"].ToString();
                objUser.strEmail = objReader["Email"].ToString();
                objUser.strPassword = objReader["Password"].ToString();
                objUser.dtDOB = DateTime.Parse(objReader["Date_birth"].ToString());
                objUser.bGender = bool.Parse(objReader["Gender"].ToString());
                objUser.strPhone = objReader["Phone"].ToString();
                objUser.strPhoto = objReader["Photo"].ToString();
                objUser.dtRegDate = DateTime.Parse(objReader["Reg_Date"].ToString());
                objUser.strIpAddress = objReader["Ip_Address"].ToString();
                objUser.bActive = bool.Parse(objReader["Active"].ToString());

                objUserList.Add(objUser);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objUserList;
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

    public CoreWebList<UserClass> fn_CheckLogin(string strEmail, string strPassword)
    {
        CoreWebList<UserClass> objUserList = null;
        UserClass objUser = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM tbl_Users WHERE Email=@Email AND Password=@Password", objConnection);
            objCommand.Parameters.AddWithValue("@Email", strEmail);
            objCommand.Parameters.AddWithValue("@Password", strPassword);

            objReader = objCommand.ExecuteReader();

            objUserList = new CoreWebList<UserClass>();

            if (objReader.Read())
            {
                objUser = new UserClass();

                objUser.iID = int.Parse(objReader["ID"].ToString());
                objUser.iCityID = int.Parse(objReader["City_id"].ToString());
                objUser.strName = objReader["Name"].ToString();
                objUser.strEmail = objReader["Email"].ToString();
                objUser.strPassword = objReader["Password"].ToString();
                objUser.dtDOB = DateTime.Parse(objReader["Date_birth"].ToString());
                objUser.bGender = bool.Parse(objReader["Gender"].ToString());
                objUser.strPhone = objReader["Phone"].ToString();
                objUser.strPhoto = objReader["Photo"].ToString();
                objUser.dtRegDate = DateTime.Parse(objReader["Reg_Date"].ToString());
                objUser.strIpAddress = objReader["Ip_Address"].ToString();
                objUser.bActive = bool.Parse(objReader["Active"].ToString());

                objUserList.Add(objUser);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objUserList;
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

    public CoreWebList<UserClass> fn_getUserByKeys(string strkeys)
    {
        CoreWebList<UserClass> objUserList = null;
        UserClass objUser = null;

        try
        {
            objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM tbl_Users WHERE Title like '%" + strkeys + "%'", objConnection);

            objReader = objCommand.ExecuteReader();

            objUserList = new CoreWebList<UserClass>();

            while (objReader.Read())
            {
                objUser = new UserClass();

                objUser.iID = int.Parse(objReader["ID"].ToString());
                objUser.iCityID = int.Parse(objReader["City_id"].ToString());
                objUser.strName = objReader["Name"].ToString();
                objUser.strEmail = objReader["Email"].ToString();
                objUser.strPassword = objReader["Password"].ToString();
                objUser.dtDOB = DateTime.Parse(objReader["Date_birth"].ToString());
                objUser.bGender = bool.Parse(objReader["Gender"].ToString());
                objUser.strPhone = objReader["Phone"].ToString();
                objUser.strPhoto = objReader["Photo"].ToString();
                objUser.dtRegDate = DateTime.Parse(objReader["Reg_Date"].ToString());
                objUser.strIpAddress = objReader["Ip_Address"].ToString();
                objUser.bActive = bool.Parse(objReader["Active"].ToString());

                objUserList.Add(objUser);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objUserList;
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
