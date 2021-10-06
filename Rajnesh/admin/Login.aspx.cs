using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_Login : System.Web.UI.Page
{
    private SqlConnection objConnection = null;
    private SqlDataReader objReader = null;
    private SqlCommand objCommand = null;
    private string strCoreConnectionString = "Data Source=180.149.240.190;Initial Catalog=db_mehanEdu;User ID=User_mehanEdu1;Password=mehanEdu123!@#";

    protected void Page_Load(object sender, EventArgs e)
    {
        info.Visible = false;
        error.Visible = false;

        if (!IsPostBack)
        {
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"] == "sesion_expired")
                {
                    lbl_Error.Text = "Session has expired.";
                    error.Visible = true;
                }
                else if (Request.QueryString["flag"] == "unauthorised")
                {
                    lbl_Error.Text = "You are not authorised to view.";
                    error.Visible = true;
                }
                else if (Request.QueryString["flag"] == "log_out")
                {
                    lbl_Info.Text = "You have successfully logged out.";
                    info.Visible = true;
                }
                else if (Request.QueryString["flag"] == "module_disabled")
                {
                    lbl_Info.Text = "You have not assigned to access any module";
                    info.Visible = true;
                }
            }
        }
    }

    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        try
        {
            info.Visible = false;

            if (txtLogin.Text != null && txtPassword != null)
            {
                System.Uri Url = Request.Url;
                string strWebUrl = Url.Host.ToString().Replace("http://", "").Replace("www.", "");
                string strLogin = txtLogin.Text;
                string strPassword = fn_GenearteCode(txtPassword.Text);

                bool bValidLogin = fn_getValidateUser(strWebUrl, strLogin, strPassword);

                if (bValidLogin == true)
                {
                    Session["login_type"] = "Admin";
                    Session["admin_id"] = 0;
                    Session["login"] = txtLogin.Text;
                    Session["admin"] = txtLogin.Text;
                    Response.Redirect("~/admin/Default.aspx");
                }
                else
                {
                    lbl_Error.Text = "Login / Password Incorrect";
                    error.Visible = true;
                }
            }
            else
            {
                lbl_Error.Text = "Login / Password Incorrect";
                error.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lbl_Error.Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    public bool fn_getValidateUser(string strWebUrl, string strLogin, string strPassword)
    {
        try
        {
            bool bValid_User = false;

            objConnection = new SqlConnection(strCoreConnectionString);
            objConnection.Open();
            objCommand = new SqlCommand("SELECT * FROM tbl_Credentials WHERE Credential_WebUrl like '%' + @Credential_WebUrl + '%' AND Credential_Login=@Credential_Login AND Credential_Password=@Credential_Password", objConnection);
            objCommand.Parameters.AddWithValue("@Credential_WebUrl", strWebUrl);
            objCommand.Parameters.AddWithValue("@Credential_Login", strLogin);
            objCommand.Parameters.AddWithValue("@Credential_Password", strPassword);
            objReader = objCommand.ExecuteReader();
            if (objReader.Read())
            {
                bValid_User = true;
            }

            if (objReader != null)
            {
                objReader.Close();
            }
            return bValid_User;
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

    static string fn_GenearteCode(string strString)
    {
        byte[] textBytes = System.Text.Encoding.Default.GetBytes(strString);
        try
        {
            System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler;
            cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] hash = cryptHandler.ComputeHash(textBytes);
            string ret = "";

            foreach (byte a in hash)
            {
                if (a < 16)
                {
                    ret += "0" + a.ToString("x");
                }
                else
                {
                    ret += a.ToString("x");
                }
            }
            return ret;
        }
        catch
        {
            throw;
        }
    }
}
