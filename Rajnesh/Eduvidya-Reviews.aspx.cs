using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using yo_lib;

public partial class Education_Reviews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                info1.Visible = false;
                error1.Visible = false;

                fn_BindReviewFactors();

                if (Session["InstitutionType"] != null && Session["InstitutionTypeID"] != null &&  Session["InstitutionName"] != null)
                {
                    string strInstitutionType = Session["InstitutionType"].ToString();
                    string strInstitutionName = Session["InstitutionName"].ToString();
                    int InstitutionID = int.Parse(Session["InstitutionTypeID"].ToString());

                    ViewState["vsInstitutionType"] = strInstitutionType;
                    ViewState["vsInstitutionName"] = strInstitutionName;
                    ViewState["vsInstitutionTypeID"] = InstitutionID;

                    ltl_InstitutionName.Text = strInstitutionName;
                }
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
            if (Session["RandomString"].ToString() == txtSecurityCode.Text.Trim())
            {
                if (Page.IsValid)
                {
                    EduReviewClass objEduReview = new EduReviewClass();
                    objEduReview.strInstitutionType = ViewState["vsInstitutionType"].ToString();
                    objEduReview.iInstitutionID = int.Parse(ViewState["vsInstitutionTypeID"].ToString());
                    objEduReview.strUserType = rd_StudentType.SelectedValue;
                    objEduReview.strTitle = txtTitle.Text.Trim();
                    objEduReview.strDetails = editor1.Text.Trim();
                    objEduReview.strIpAddrs = HttpContext.Current.Request.UserHostAddress;

                    int iUserReviewID = objEduReview.fn_saveEduReview();
                    ViewState["ReviewID"] = iUserReviewID;

                    if (iUserReviewID > 0)
                    {
                        fn_SaveReviewDetails(iUserReviewID);
                        tbl_EduCationReviews.Visible = false;

                        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "PopUp", "setTimeout('fn_getPopup()',900);", true);
                    }
                }
            }
            else
            {
                ((Label)error1.FindControl("mssg")).Text = "You Have Entered Invalid Security Code!";
                error1.Visible = true;
            }
        }
        catch (Exception ex)
        {
            ((Label)error1.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error1.Visible = true;
        }
    }

    public void fn_SaveReviewDetails(int iReviewID)
    {
        try
        {
            EduReviewDetailClass objReviewDetail = new EduReviewDetailClass();
            objReviewDetail.iReviewID = iReviewID;

            for (int i = 0; i < rpt_ReviewFactors.Items.Count; i++)
            {
                Repeater rpt_Ratings = ((Repeater)rpt_ReviewFactors.Items[i].FindControl("rpt_Ratings"));

                if (rpt_Ratings != null)
                {
                    foreach (RepeaterItem item in rpt_Ratings.Items)
                    {
                        DropDownList ddl_FactorValues = (DropDownList)item.FindControl("ddl_FactorValues");
                        HiddenField hf_ReviewFactorID = (HiddenField)item.FindControl("hf_ReviewFactorID");

                        objReviewDetail.iFactorID = int.Parse(hf_ReviewFactorID.Value);
                        objReviewDetail.iFactorValue = int.Parse(ddl_FactorValues.SelectedValue);

                        string strResponse = objReviewDetail.fn_saveEduReviewDetail();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindReviewFactors()
    {
        try
        {
            FactorHeadingClass objFactor = new FactorHeadingClass();
            CoreWebList<FactorHeadingClass> objFactorList = objFactor.fn_getFactorHeadingList();
            if (objFactorList.Count > 0)
            {
                rpt_ReviewFactors.DataSource = objFactorList;
                rpt_ReviewFactors.DataBind();
            }
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

    protected void rpt_ReviewFactors_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hf_FactorID = (HiddenField)e.Item.FindControl("hf_FactorID");
                Repeater rpt_Ratings = (Repeater)e.Item.FindControl("rpt_Ratings");
                if (hf_FactorID != null && rpt_Ratings != null)
                {
                    FactorClass objFactor = new FactorClass();
                    objFactor.iHeadingID = int.Parse(hf_FactorID.Value);
                    CoreWebList<FactorClass> objFactorList = objFactor.fn_getFactorByHeadingID();
                    if (objFactorList.Count > 0)
                    {
                        rpt_Ratings.DataSource = objFactorList;
                        rpt_Ratings.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void btn_UserDetails_Click(object sender, EventArgs e)
    {
        try
        {
            EduReviewClass objEduReview = new EduReviewClass();
            objEduReview.iID = int.Parse(ViewState["ReviewID"].ToString());
            objEduReview.strName = txtName.Text.Trim();
            objEduReview.strEmail = txtEmail.Text.Trim();
            objEduReview.strMobileNo = txtPhone.Text.Trim();

            string strResponse = objEduReview.fn_editEduReview();

            ltl_ReviewMessageBox.Text = "<div class='_messageBox'><div class='Message_Info'><img src='" + VirtualPathUtility.ToAbsolute("~/images/info.png") + "'></div>Thank You for Giving Your Review!</div>";
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "PopUp", "setTimeout('fn_ShowMessage()',900);", true);

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }

    }
}