using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;
using System.Net.Mail;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Globalization;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            info1.Visible = false;
            error1.Visible = false;

            Literal ltl_bredcrumbs = (Literal)Master.FindControl("ltl_bredcrumbs");
            ltl_bredcrumbs.Text = "<a href='https://www.recruitmentexam.com/'>Home</a>&nbsp;>&nbsp;Register";

            fn_BindCityDropDownList();
            fn_BindDaysDropDownList();
            fn_BindMonthDropDownList();
            fn_BindYearDropDownList();

            if (Session["userId"] != null)
            {
                UserClass objUser = new UserClass();
                objUser.iID = int.Parse(Session["userId"].ToString());
                CoreWebList<UserClass> objUserList = objUser.fn_getUserByID();
                if (objUserList.Count > 0)
                {
                    txtName.Text = objUserList[0].strName;

                    if (objUserList[0].bGender == true)
                    {
                        rb_male.Checked = true;
                        rb_female.Checked = false;
                    }
                    else
                    {
                        rb_male.Checked = false;
                        rb_female.Checked = true;
                    }

                    string str = objUserList[0].dtDOB.ToShortDateString();

                    string[] strDate = str.Split('/');
                    int Month = int.Parse(strDate[0]);
                    int Day = int.Parse(strDate[1]);
                    int Year = int.Parse(strDate[2]);

                    ddl_Day.SelectedValue = Day.ToString();
                    ddl_Month.SelectedValue = Month.ToString();
                    ddl_Year.SelectedValue = Year.ToString();

                    ddlCity.SelectedValue = objUserList[0].iCityID.ToString();
                    txtPhone.Text = objUserList[0].strPhone;
                    txtEmail.Text = objUserList[0].strEmail;

                    if (objUserList[0].strPhoto != "")
                    {
                        img_userPhoto.Src = "https://www.recruitmentexam.com/admin/uploads/User_photos/" + objUserList[0].strPhoto;
                        hf_Photo.Value = objUserList[0].strPhoto;
                    }
                    else
                    {
                        img_userPhoto.Src = "https://www.recruitmentexam.com/images/Avatar.jpeg";
                    }

                    txtEmail.Enabled = false;

                    tr_Pass.Visible = false;
                    tr_RePass.Visible = false;
                    tr_Verification.Visible = false;
                    tr_Verification_001.Visible = false;
                    tr_Verification_002.Visible = false;
                    tr_License.Visible = false;
                    tr_License_001.Visible = false;
                    tr_License_002.Visible = false;
                }
            }
            else
            {
                img_userPhoto.Visible = false;
            }
        }


    }

    protected void lbRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            imgVerificationCode.ImageUrl = "RandomImage.aspx";
            if (iRandomImageID == 2)
            {
                imgVerificationCode.ImageUrl = "RandomImage.aspx";
                iRandomImageID = 0;
            }
            else
            {
                imgVerificationCode.ImageUrl = "RandomImage2.aspx";
                iRandomImageID = 2;
            }
            txtSecurityCode.Focus();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    private int iRandomImageID
    {
        get
        {
            if (ViewState["randomImgID"] == null)
            {
                return 0;
            }
            else
            {
                return (int)ViewState["randomImgID"];
            }
        }
        set
        {
            ViewState["randomImgID"] = value;
        }
    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Session["userId"] == null)
            {
                if (Session["RandomString"].ToString() == txtSecurityCode.Text.Trim())
                {
                    if (chk_agree.Checked)
                    {
                        if (Page.IsValid)
                        {

                            UserClass oUser = new UserClass();
                            oUser.strEmail = txtEmail.Text.Trim();
                            CoreWebList<UserClass> oUserList = oUser.fn_getUserByEmail();
                            if (oUserList.Count > 0)
                            {
                                ((Label)error1.FindControl("mssg")).Text = "This Email-ID is already registered!";
                                error1.Visible = true;
                            }
                            else
                            {
                                fn_RegisterUser();
                            }
                        }
                    }
                    else
                    {
                        ((Label)error1.FindControl("mssg")).Text = "Please agree to our terms & Conditions!";
                        error1.Visible = true;
                    }
                }
                else
                {
                    ((Label)error1.FindControl("mssg")).Text = "Invalid Security Code";
                    error1.Visible = true;
                }
            }
            else
            {
                UserClass objUser = new UserClass();
                objUser.iID = int.Parse(Session["userId"].ToString());
                objUser.iCityID = int.Parse(ddlCity.SelectedValue);
                objUser.strName = txtName.Text.Trim();
                objUser.strEmail = txtEmail.Text.Trim();
                objUser.strPhone = txtPhone.Text.Trim();
                objUser.dtDOB = fn_formatDate();

                if (rb_male.Checked)
                {
                    objUser.bGender = true;
                }
                else
                {
                    objUser.bGender = false;
                }

                if (fp_upload.HasFile)
                {
                    if (File.Exists(MapPath("~/admin/uploads/User_photos/" + hf_Photo.Value)))
                    {
                        File.Delete((MapPath("~/admin/uploads/User_photos/" + hf_Photo.Value)));
                    }

                    cls_common objCFC = new cls_common();
                    string strRanFileName = objCFC.file_name(fp_upload.FileName);
                    string strDocPath = Server.MapPath("~/admin/uploads/User_photos/" + strRanFileName);
                    fp_upload.SaveAs(strDocPath);
                    objUser.strPhoto = strRanFileName;

                    img_userPhoto.Src = "https://www.recruitmentexam.com/admin/uploads/User_photos/" + strRanFileName;
                }
                else
                {
                    objUser.strPhoto = hf_Photo.Value;
                }

                string strResult = objUser.fn_editUser();

                if (strResult.Contains("SUCCESS"))
                {
                    ((Label)info1.FindControl("mssg")).Text = "You have Successfully updated Your Profile Details";
                    info1.Visible = true;
                }
                else
                {
                    ((Label)error1.FindControl("mssg")).Text = strResult;
                    error1.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    public void fn_RegisterUser()
    {
        try
        {
            UserClass objUser = new UserClass();
            objUser.iCityID = int.Parse(ddlCity.SelectedValue);
            objUser.strName = txtName.Text.Trim();
            objUser.strEmail = txtEmail.Text.Trim();
            objUser.strPassword = txtPassword.Text.Trim();
            objUser.dtDOB = fn_formatDate();

            if (rb_male.Checked)
            {
                objUser.bGender = true;
            }
            else
            {
                objUser.bGender = false;
            }

            if (fp_upload.HasFile)
            {
                cls_common objCFC = new cls_common();
                string strRanFileName = objCFC.file_name(fp_upload.FileName);
                string strDocPath = Server.MapPath("admin/uploads/User_photos/" + strRanFileName);
                fp_upload.SaveAs(strDocPath);
                objUser.strPhoto = strRanFileName;
            }

            objUser.strPhone = txtPhone.Text.Trim();
            objUser.strIpAddress = HttpContext.Current.Request.UserHostAddress;

            int userId = objUser.fn_saveUser();

            if (userId > 0)
            {
                fn_SendMail(userId);

                ((Label)info1.FindControl("mssg")).Text = "You have Successfully Registered With Us!<br/>Please Check your Email for Account Activation Link";
                info1.Visible = true;
                tbl_Reg.Visible = false;
            }

        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindCityDropDownList()
    {
        try
        {
            CityMasterClass objCity = new CityMasterClass();
            ddlCity.DataSource = objCity.fn_getCityList();
            ddlCity.DataTextField = "strCityName";
            ddlCity.DataValueField = "iID";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("Select", "0"));

        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    public void fn_SendMail(int iUserId)
    {
        SmtpClient mailClient = null;
        MailMessage message = null;

        try
        {
            UserClass objUM = new UserClass();
            objUM.iID = iUserId;
            CoreWebList<UserClass> objUserList = objUM.fn_getUserByID();
            if (objUserList.Count > 0)
            {
                string strEmail = objUserList[0].strEmail;
                string strPassword = objUserList[0].strPassword;
                string strName = objUserList[0].strName;
                string strUserId = objUserList[0].iID.ToString();
                string strMD5 = MD5(strUserId);

                StreamReader reader = new StreamReader(Server.MapPath("~/EmailLayout.htm"));
                string content = reader.ReadToEnd();
                reader.Close();

                content = Regex.Replace(content, "#Name", objUserList[0].strName);
                content = Regex.Replace(content, "#Email", strEmail);
                content = Regex.Replace(content, "#Password", strPassword);
                content = Regex.Replace(content, "#Link", "<a href='" + ConfigurationManager.AppSettings["ConfirmRegistrationUrl"].ToString() + strUserId + "&key=" + strMD5 + "'>Click here to Activate your account</a>");

                mailClient = new SmtpClient();
                message = new MailMessage();

                //SMTP MAIL HOST
                mailClient.Host = ConfigurationManager.AppSettings["SMTP_MAIL_SERVER"];

                //SMTP MAIL PORT
                mailClient.Port = 25;

                //NETWORK CREDENTIALS
                string strMailUserName = ConfigurationManager.AppSettings["FROM_ADDR"];
                string strMailPassword = ConfigurationManager.AppSettings["FROM_ADDR_PASS"];

                System.Net.NetworkCredential SMTPUserInfo =
                    new System.Net.NetworkCredential(strMailUserName, strMailPassword);
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = SMTPUserInfo;

                //FROM MAIL ADDRESS
                MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FROM_ADDR"]);
                message.From = fromAddress;

                //TO MAIL ADDRESS
                message.To.Add(strEmail);

                message.Subject = "Recruitmentexam.com : Activate Your Account";

                message.Body = content;

                message.IsBodyHtml = true;
                mailClient.Send(message);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
        finally
        {

        }
    }

    static string MD5(string strString)
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

    public DateTime fn_formatDate()
    {
        int Day = int.Parse(ddl_Day.SelectedValue);
        int Month = int.Parse(ddl_Month.SelectedValue);
        int Year = int.Parse(ddl_Year.SelectedValue);

        DateTime dt_Date = new DateTime(Year, Month, Day, 00, 00, 00);
        return dt_Date;
    }

    protected void fn_BindDaysDropDownList()
    {
        try
        {
            ListItem lst;
            for (int i = 1; i <= 31; i++)
            {
                lst = new ListItem();
                lst.Text = i.ToString();
                lst.Value = i.ToString();
                ddl_Day.Items.Add(lst);
            }

            ddl_Day.Items.Insert(0, new ListItem("Select", "0"));

        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindMonthDropDownList()
    {
        try
        {
            ListItem lst;
            int iMonth = 0;
            foreach (var item in DateTimeFormatInfo.CurrentInfo.MonthNames)
            {
                iMonth = iMonth + 1;
                lst = new ListItem();
                lst.Text = item;
                lst.Value = iMonth.ToString();
                ddl_Month.Items.Add(lst);
            }
            ddl_Month.Items.Insert(0, new ListItem("Select", "0"));

            lst = new ListItem();
            lst.Text = "";
            lst.Value = "13";

            ddl_Month.Items.Remove(lst);

        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindYearDropDownList()
    {
        try
        {
            ListItem lst;
            for (int i = 1900; i <= DateTime.Now.Year; i++)
            {
                lst = new ListItem();
                lst.Text = i.ToString();
                lst.Value = i.ToString();
                ddl_Year.Items.Add(lst);
            }

            ddl_Year.Items.Insert(0, new ListItem("Select", "0"));

        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }
}