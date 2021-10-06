using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Education_Help : System.Web.UI.Page
{
    string strType = "";
    int TypeId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["Type"] != null && Session["typeId"] != null)
                {
                    strType = Session["Type"].ToString();
                    TypeId = int.Parse(Session["typeId"].ToString());

                    ViewState["Type"] = strType;
                    ViewState["TypeId"] = TypeId;
                }

                info1.Visible = false;
                error1.Visible = false;

                fn_BindQualifictionDDL();
                fn_BindEducationInterestDDL();
                fn_BindCityDDL();

                fn_BindDaysDropDownList();
                fn_BindMonthDropDownList();
                fn_BindYearDropDownList();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["Type"] != null && ViewState["TypeId"] != null)
            {
                strType = ViewState["Type"].ToString();
                TypeId = int.Parse(ViewState["TypeId"].ToString());

                if (Session["RandomString"].ToString() == txtSecurityCode.Text.Trim())
                {
                    if (Page.IsValid)
                    {
                        EduLeadClass objEduLead = new EduLeadClass();
                        objEduLead.iCurrentQualificationID = int.Parse(ddlQualification.SelectedValue);
                        objEduLead.iEducationInterestID = int.Parse(ddlEducationInterest.SelectedValue);
                        objEduLead.iCityID = int.Parse(ddlCity.SelectedValue);
                        objEduLead.strType = strType;
                        objEduLead.iTypeId = TypeId;
                        objEduLead.strFirstName = txtFirstName.Text.Trim();
                        objEduLead.strLastName = txtLastName.Text.Trim();
                        objEduLead.strEmail = txtEmail.Text.Trim();
                        objEduLead.dtDoB = fn_formatDate();
                        objEduLead.strMobileNo = txtPhone.Text.Trim();
                        objEduLead.strComment = txtComment.Text.Trim();
                        objEduLead.bEducationLoan = chk_EducationLoan.Checked;
                        objEduLead.strIpAddrs = HttpContext.Current.Request.UserHostAddress;

                        string strResponse = objEduLead.fn_saveEduLead();

                        if (strResponse.Contains("SUCCESS"))
                        {
                            ((Label)info1.FindControl("mssg")).Text = "Thank you for Registering with us. Your Request has been posted successfully, We will get back to you soon!";
                            info1.Visible = true;
                            tbl_EduCationHelp.Visible = false;
                        }
                    }
                }
                else
                {
                    ((Label)error1.FindControl("mssg")).Text = "You Have Entered Invalid Security Code!";
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

    public DateTime fn_formatDate()
    {
        int Day = int.Parse(ddl_Day.SelectedValue);
        int Month = int.Parse(ddl_Month.SelectedValue);
        int Year = int.Parse(ddl_Year.SelectedValue);

        DateTime dt_Date = new DateTime(Year, Month, Day, 00, 00, 00);
        return dt_Date;
    }

    protected void fn_BindQualifictionDDL()
    {
        try
        {
            QualificationClass objQualification = new QualificationClass();
            ddlQualification.DataSource = objQualification.fn_getQualificationList();
            ddlQualification.DataTextField = "strTitle";
            ddlQualification.DataValueField = "iID";
            ddlQualification.DataBind();
            ddlQualification.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindEducationInterestDDL()
    {
        try
        {
            EducationInterestClass objEducationInterest = new EducationInterestClass();
            ddlEducationInterest.DataSource = objEducationInterest.fn_getEducationInterestList();
            ddlEducationInterest.DataTextField = "strTitle";
            ddlEducationInterest.DataValueField = "iID";
            ddlEducationInterest.DataBind();
            ddlEducationInterest.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindCityDDL()
    {
        try
        {
            CityClass objCity = new CityClass();
            ddlCity.DataSource = objCity.fn_getCityList();
            ddlCity.DataTextField = "strTitle";
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
            ddl_Day.Items.Insert(0, new ListItem("Day", "0"));
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
            ddl_Month.Items.Insert(0, new ListItem("Month", "0"));

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
            ddl_Year.Items.Insert(0, new ListItem("Year", "0"));
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
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
    
}