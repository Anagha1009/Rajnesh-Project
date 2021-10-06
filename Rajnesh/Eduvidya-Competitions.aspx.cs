using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using yo_lib;
using System.IO;

public partial class Competition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                info1.Visible = false;
                error1.Visible = false;

                if (Session["CompetitionId"] != null && Session["CompetitionUser"] != null)
                {
                    int iCompetitionId = int.Parse(Session["CompetitionId"].ToString());
                    int iCompetitionUserId = int.Parse(Session["CompetitionUser"].ToString());

                    CompetitionClass objCompete = new CompetitionClass();
                    objCompete.iID = iCompetitionId;
                    CoreWebList<CompetitionClass> objCompeteList = objCompete.fn_getCompetitionByID();
                    if (objCompeteList.Count > 0)
                    {
                        ltl_Title.Text = objCompeteList[0].strTitle;
                        img_Icon.Src = VirtualPathUtility.ToAbsolute("~/files/Competition/" + objCompeteList[0].strPhoto);
                        ltl_Details.Text = "<div class='_CompeteDetails'>" + objCompeteList[0].strDetails + "</div><div style='clear:both'>&nbsp;</div>";

                        ViewState["CompetitionId"] = objCompeteList[0].iID;
                        ViewState["CompetitionType"] = objCompeteList[0].strType;

                        ltl_CompetitionTitle.Text = objCompeteList[0].strTitle;
                        ltl_CompetitionDetails.Text = objCompeteList[0].strShortDetails;
                        ltl_Prizes.Text = objCompeteList[0].strPrizeDetails;
                        imgCompetition.Src = VirtualPathUtility.ToAbsolute("~/files/Competition/" + objCompeteList[0].strPhoto);
                        imgCompetition.Alt = objCompeteList[0].strTitle;

                        CompetitionDetailsBox.Attributes.Add("style", "background-color: " + objCompeteList[0].strBgColor);
                    }

                    if (ViewState["CompetitionType"].ToString() == "Quiz")
                    {
                        CompetitionEntryClass objCompetitionEntry = new CompetitionEntryClass();
                        objCompetitionEntry.iCompetitionID = iCompetitionId;
                        objCompetitionEntry.iUserID = iCompetitionUserId;
                        CoreWebList<CompetitionEntryClass> objCompetitionEntryList = objCompetitionEntry.fn_getCheckCompetitionEntryByUserID();
                        if (objCompetitionEntryList.Count > 0)
                        {
                            ltl_MessageBox.Text = "<div class='_messageBox'><div class='Message_Info'><img src='" + VirtualPathUtility.ToAbsolute("~/images/info.png") + "'></div>You have Already Participated in this Competition!</div>";
                            tbl_CompetitionUserDetails.Visible = false;
                            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "PopUp", "setTimeout('fn_getPopup()',900);", true);

                            tr_Quiz.Visible = false;
                            tr_Multimedia.Visible = false;
                            tr_button.Visible = false;
                        }
                        else
                        {
                            fn_BindFirstCompetitionQuiz();
                            tr_Quiz.Visible = true;
                            tr_Multimedia.Visible = false;
                            tr_button.Visible = true;
                        }
                    }
                    else if (ViewState["CompetitionType"].ToString() == "Multimedia")
                    {
                        CompetitionFileClass objCompetitionFile = new CompetitionFileClass();
                        objCompetitionFile.iCompetitionID = iCompetitionId;
                        objCompetitionFile.iUserID = iCompetitionUserId;
                        CoreWebList<CompetitionFileClass> objCompetitionFileList = objCompetitionFile.fn_getCheckUserParticipation();
                        if (objCompetitionFileList.Count > 0)
                        {
                            ltl_MessageBox.Text = "<div class='_messageBox'><div class='Message_Info'><img src='" + VirtualPathUtility.ToAbsolute("~/images/info.png") + "'></div>You have Already Participated in this Competition!</div>";
                            tbl_CompetitionUserDetails.Visible = false;
                            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "PopUp", "setTimeout('fn_getPopup()',900);", true);

                            tr_Quiz.Visible = false;
                            tr_Multimedia.Visible = false;
                            tr_button.Visible = false;
                        }
                        else
                        {
                            tr_Multimedia.Visible = true;
                            tr_Quiz.Visible = false;
                            tr_button.Visible = true;
                        }
                    }

                    fn_BindQualifictionDDL();
                    fn_BindCityDDL();
                    fn_BindDaysDropDownList();
                    fn_BindMonthDropDownList();
                    fn_BindYearDropDownList();

                    CompetitionUserClass objCompeteUser = new CompetitionUserClass();
                    objCompeteUser.iID = iCompetitionUserId;
                    CoreWebList<CompetitionUserClass> objCompeteUserList = objCompeteUser.fn_getCompetitionUserByID();
                    if (objCompeteUserList.Count > 0)
                    {
                        txtName.Text = objCompeteUserList[0].strName;
                        txtEmail.Text = objCompeteUserList[0].strEmail;
                        txtPhone.Text = objCompeteUserList[0].strMobile;
                        txtAddress.Text = objCompeteUserList[0].strAddress;

                        if (objCompeteUserList[0].dtDoB != null)
                        {
                            int iDay = objCompeteUserList[0].dtDoB.Day;
                            int iMonth = objCompeteUserList[0].dtDoB.Month;
                            int iYear = objCompeteUserList[0].dtDoB.Year;

                            DateTime dt = new DateTime(1901, 1, 1);

                            if (objCompeteUserList[0].dtDoB != dt)
                            {
                                ddl_Day.SelectedValue = objCompeteUserList[0].dtDoB.Day.ToString();
                                ddl_Month.SelectedValue = objCompeteUserList[0].dtDoB.Month.ToString();
                                ddl_Year.SelectedValue = objCompeteUserList[0].dtDoB.Year.ToString();
                            }
                        }

                        if (objCompeteUserList[0].bGender == true)
                        {
                            rd_Gender.SelectedValue = "1";
                        }
                        else
                        {
                            rd_Gender.SelectedValue = "0";
                        }

                        if (objCompeteUserList[0].iCityID > 0)
                        {
                            ddlCity.SelectedValue = objCompeteUserList[0].iCityID.ToString();
                        }

                        if (objCompeteUserList[0].iQualificationID > 0)
                        {
                            ddlQualification.SelectedValue = objCompeteUserList[0].iQualificationID.ToString();
                        }
                    }
                }
                else
                {
                    Response.Redirect(VirtualPathUtility.ToAbsolute("~/"), false);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindFirstCompetitionQuiz()
    {
        try
        {
            CompetitionQuizClass objCompeteQuiz = new CompetitionQuizClass();
            objCompeteQuiz.iCompetitionID = int.Parse(ViewState["CompetitionId"].ToString());
            CoreWebList<CompetitionQuizClass> objCompeteQuizList = objCompeteQuiz.fn_getCompetitionQuizByCompetitionID();
            if (objCompeteQuizList.Count > 0)
            {
                ltl_Title.Text = objCompeteQuizList[0].strTitle;
                img_Icon.Src = VirtualPathUtility.ToAbsolute("~/files/CompetitionIcon/" + objCompeteQuizList[0].strIcon);

                fn_BindCompetitionQuizOption(objCompeteQuizList[0].iID);
            }
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindNextCompetistionQuiz()
    {
        try
        {
            CompetitionQuizClass objCompeteQuiz = new CompetitionQuizClass();
            objCompeteQuiz.iID = int.Parse(hf_QuizId.Value);
            objCompeteQuiz.iCompetitionID = int.Parse(ViewState["CompetitionId"].ToString());
            CoreWebList<CompetitionQuizClass> objCompeteQuizList = objCompeteQuiz.fn_getNextCompetitionQuiz();
            if (objCompeteQuizList.Count > 0)
            {
                ltl_Title.Text = objCompeteQuizList[0].strTitle;
                img_Icon.Src = VirtualPathUtility.ToAbsolute("~/files/CompetitionIcon/" + objCompeteQuizList[0].strIcon);

                fn_BindCompetitionQuizOption(objCompeteQuizList[0].iID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "PopUp", "setTimeout('fn_getPopup()',900);", true);
                tbl_Competion.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void fn_BindCompetitionQuizOption(int iQuizID)
    {
        try
        {
            hf_QuizId.Value = iQuizID.ToString();
            rd_CompeteOptions.Items.Clear();

            CompetitionQuizOptionClass objCompeteQuizOption = new CompetitionQuizOptionClass();
            objCompeteQuizOption.iQuizID = iQuizID;
            CoreWebList<CompetitionQuizOptionClass> objCompeteQuizOptionList = objCompeteQuizOption.fn_getCompetitionQuizOptionByQuizID();
            if (objCompeteQuizOptionList.Count > 0)
            {
                ListItem lst;

                for (int i = 0; i < objCompeteQuizOptionList.Count; i++)
                {
                    lst = new ListItem();

                    if (objCompeteQuizOptionList[i].strLogo != "")
                    {
                        lst.Text = "<div class='_CompeteOption'><img src='" + VirtualPathUtility.ToAbsolute("~/files/CompetitionQuizOption/" + objCompeteQuizOptionList[i].strLogo) + "' /></div>" + objCompeteQuizOptionList[i].strTitle;
                    }
                    else
                    {
                        lst.Text = objCompeteQuizOptionList[i].strTitle;
                    }

                    lst.Value = objCompeteQuizOptionList[i].iID.ToString();

                    rd_CompeteOptions.Items.Add(lst);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void btn_Compete_Click(object sender, EventArgs e)
    {
        try 
        {
            if (ViewState["CompetitionId"] != null && ViewState["CompetitionType"] != null && Session["CompetitionUser"] != null)
            {
                string strCompetitionType = ViewState["CompetitionType"].ToString();
                int iCompetitionUser = int.Parse(Session["CompetitionUser"].ToString());
                int iCompetitionId = int.Parse(ViewState["CompetitionId"].ToString());

                if (strCompetitionType == "Quiz")
                {
                    if (rd_CompeteOptions.SelectedValue != null && rd_CompeteOptions.SelectedValue != "" && Session["CompetitionUser"] != null)
                    {
                        CompetitionEntryClass objCompetitionEntry = new CompetitionEntryClass();
                        objCompetitionEntry.iUserID = int.Parse(Session["CompetitionUser"].ToString());
                        objCompetitionEntry.iOptionID = int.Parse(rd_CompeteOptions.SelectedValue);
                        string strResponse = objCompetitionEntry.fn_saveCompetitionEntry();

                        if (strResponse.Contains("SUCCESS"))
                        {
                            fn_BindNextCompetistionQuiz();
                        }
                    }
                }
                else if (strCompetitionType == "Multimedia")
                {
                    if (fn_ValidEntry() == true)
                    {
                        cls_common objCFC = new cls_common();
                        string strResponse = "";

                        CompetitionFileClass objCompetitionFile = new CompetitionFileClass();
                        objCompetitionFile.iUserID = iCompetitionUser;
                        objCompetitionFile.iCompetitionID = iCompetitionId;

                        if (fp_File1.HasFile)
                        {
                            string strRanFileName = objCFC.file_name(fp_File1.FileName);
                            string strDocPath = Server.MapPath("~/files/CompetitionFile/" + strRanFileName);
                            fp_File1.SaveAs(strDocPath);

                            objCompetitionFile.strTitle = txt_Title1.Text.Trim();
                            objCompetitionFile.strFile = strRanFileName;

                            strResponse = objCompetitionFile.fn_saveCompetitionFile();
                        }

                        if (fp_File2.HasFile)
                        {
                            string strRanFileName = objCFC.file_name(fp_File2.FileName);
                            string strDocPath = Server.MapPath("~/files/CompetitionFile/" + strRanFileName);
                            fp_File2.SaveAs(strDocPath);

                            objCompetitionFile.strTitle = txt_Title2.Text.Trim();
                            objCompetitionFile.strFile = strRanFileName;

                            strResponse = objCompetitionFile.fn_saveCompetitionFile();
                        }

                        if (fp_File3.HasFile)
                        {
                            string strRanFileName = objCFC.file_name(fp_File3.FileName);
                            string strDocPath = Server.MapPath("~/files/CompetitionFile/" + strRanFileName);
                            fp_File3.SaveAs(strDocPath);

                            objCompetitionFile.strTitle = txt_Title3.Text.Trim();
                            objCompetitionFile.strFile = strRanFileName;

                            strResponse = objCompetitionFile.fn_saveCompetitionFile();
                        }

                        if (fp_File4.HasFile)
                        {
                            string strRanFileName = objCFC.file_name(fp_File4.FileName);
                            string strDocPath = Server.MapPath("~/files/CompetitionFile/" + strRanFileName);
                            fp_File4.SaveAs(strDocPath);

                            objCompetitionFile.strTitle = txt_Title4.Text.Trim();
                            objCompetitionFile.strFile = strRanFileName;

                            strResponse = objCompetitionFile.fn_saveCompetitionFile();
                        }

                        if (fp_File5.HasFile)
                        {
                            string strRanFileName = objCFC.file_name(fp_File5.FileName);
                            string strDocPath = Server.MapPath("~/files/CompetitionFile/" + strRanFileName);
                            fp_File5.SaveAs(strDocPath);

                            objCompetitionFile.strTitle = txt_Title5.Text.Trim();
                            objCompetitionFile.strFile = strRanFileName;

                            strResponse = objCompetitionFile.fn_saveCompetitionFile();
                        }

                        txt_Title1.Text = "";
                        txt_Title2.Text = "";
                        txt_Title3.Text = "";
                        txt_Title4.Text = "";
                        txt_Title5.Text = "";

                        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "PopUp", "setTimeout('fn_getPopup()',900);", true);
                        tbl_Competion.Visible = false;
                    }
                    else
                    {
                        ltl_CompetitionMessageBox.Text = "<div class='_messageBox'><div class='Message_Info'><img src='" + VirtualPathUtility.ToAbsolute("~/images/info.png") + "'></div>Please Upload Valid file only!</div>";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "PopUp", "setTimeout('fn_ShowPopup()',900);", true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (Session["CompetitionUser"] != null)
                {
                    CompetitionUserClass objCompetitionUser = new CompetitionUserClass();
                    objCompetitionUser.iID = int.Parse(Session["CompetitionUser"].ToString());
                    objCompetitionUser.iCityID = int.Parse(ddlCity.SelectedValue);
                    objCompetitionUser.iQualificationID = int.Parse(ddlQualification.SelectedValue);
                    objCompetitionUser.strName = txtName.Text.Trim();
                    objCompetitionUser.strEmail = txtEmail.Text.Trim();
                    objCompetitionUser.dtDoB = fn_formatDate();

                    if (rd_Gender.SelectedValue == "1")
                    {
                        objCompetitionUser.bGender = true;
                    }
                    else
                    {
                        objCompetitionUser.bGender = false;
                    }

                    objCompetitionUser.strMobile = txtPhone.Text.Trim();
                    objCompetitionUser.strAddress = txtAddress.Text.Trim();

                    string strResponse = objCompetitionUser.fn_edit_CompetitionUser();

                    if (strResponse.Contains("SUCCESS"))
                    {
                        ltl_MessageBox.Text = "<div class='_messageBox'><div class='Message_Info'><img src='" + VirtualPathUtility.ToAbsolute("~/images/info.png" ) + "'></div>Thank You for Taking Part in this Competition! The Winner will be Announced Soon! You might be Interested in Other EduVidya Competitons : </div>";

                        CompetitionClass objCompete = new CompetitionClass();
                        objCompete.iID = int.Parse(Session["CompetitionId"].ToString());
                        CoreWebList<CompetitionClass> objCompeteList = objCompete.fn_getOtherCompetitionByID();
                        if(objCompeteList.Count > 0)
                        {
                            rpt_OtherCompetition.DataSource = objCompeteList;
                            rpt_OtherCompetition.DataBind();
                        }

                        tbl_CompetitionUserDetails.Visible = false;
                        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "PopUp", "setTimeout('fn_getPopup()',900);", true);
                    }
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


    protected bool fn_ValidEntry()
    {
        try
        {
            if ((fn_CheckValidFile(fp_File1) == true) && (fn_CheckValidFile(fp_File2) == true) && (fn_CheckValidFile(fp_File3) == true) && (fn_CheckValidFile(fp_File4) == true) && (fn_CheckValidFile(fp_File5) == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected bool fn_CheckValidFile(FileUpload fp_upload)
    {
        try
        {
            bool isValidFile = false;

            if (fp_upload.HasFile)
            {
                string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "flv", "avi", "mov", "mp4", "mpg", "wmv", "3gp", "swf" };
                string ext = Path.GetExtension(fp_upload.PostedFile.FileName);

                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }
            }
            else
            {
                isValidFile = true;
            }

            return isValidFile;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void rpt_OtherCompetition_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if(e.CommandName == "Compete")
            {
                int iCompetitionID = int.Parse(e.CommandArgument.ToString());
                Session["CompetitionId"] = iCompetitionID;
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/Eduvidya-Competitions.aspx"));
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}