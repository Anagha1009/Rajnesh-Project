using System;
using System.Collections.Generic;
using System.Data;
using FredCK.FCKeditorV2;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;
using System.IO;
using System.Text.RegularExpressions;

public partial class admin_QueryGenerator : System.Web.UI.Page
{
    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
            {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }

            return (SortDirection)ViewState["sortDirection"];
        }
        set
        {
            ViewState["sortDirection"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Check login session 
            //If not logged in redirect to admin login page
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx?flag=1");
            }

            info.Visible = false;
            error.Visible = false;

            info_dv.Visible = false;
            error_dv.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                QueryGeneratorClass objQuery = new QueryGeneratorClass();
                CoreWebList<QueryGeneratorClass> objQueryList = objQuery.fn_getQueryGeneratorList();

                if (objQueryList.Count > 0)
                {
                    DataTable dtQuery = (DataTable)objQueryList;
                    ViewState["dtQuery"] = dtQuery;
                    grd_Query.DataSource = dtQuery;
                }
                else
                {
                    grd_Query.DataSource = null;
                }

                grd_Query.DataBind();

                if (grd_Query.SelectedIndex < 0)
                {
                    dv_Query.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + "Line :" + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Query_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dtQuery = (DataTable)ViewState["dtQuery"];
            grd_Query.PageIndex = e.NewPageIndex;
            grd_Query.DataSource = dtQuery;
            grd_Query.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void grd_Query_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            QueryGeneratorClass objQuery = new QueryGeneratorClass();
            objQuery.iID = int.Parse(grd_Query.DataKeys[e.RowIndex].Value.ToString());

            string strResponse = objQuery.fn_deleteQueryGenerator();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info.FindControl("mssg")).Text = strResponse;
                info.Visible = true;
            }
            else
            {
                ((Label)error.FindControl("mssg")).Text = strResponse;
                error.Visible = true;
            }

            grd_Query.DataSource = objQuery.fn_getQueryGeneratorList();
            grd_Query.DataBind();

            dv_Query.ChangeMode(DetailsViewMode.Insert);
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void grd_Query_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (grd_Query.SelectedIndex < 0)
            {
                // Insert Mode
                dv_Query.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                // Edit Mode
                dv_Query.ChangeMode(DetailsViewMode.Edit);

                QueryGeneratorClass objQuery = new QueryGeneratorClass();
                objQuery.iID = int.Parse(grd_Query.SelectedDataKey.Value.ToString());

                dv_Query.DataSource = objQuery.fn_getQueryGeneratorByID();
                dv_Query.DataBind();
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Query_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_Query.FindControl("txtTitle");
            TextBox txtYoutubeTitle = (TextBox)dv_Query.FindControl("txtYoutubeTitle");
            TextBox txtYoutube = (TextBox)dv_Query.FindControl("txtYoutube");
            TextBox txtDesc = (TextBox)dv_Query.FindControl("txtDesc");
            TextBox txtMetaTitle = (TextBox)dv_Query.FindControl("txtMetaTitle");
            TextBox txtMetaDesc = (TextBox)dv_Query.FindControl("txtMetaDesc");
            TextBox txtMetaKeys = (TextBox)dv_Query.FindControl("txtMetaKeys");
            RadioButton rd_University = (RadioButton)dv_Query.FindControl("rd_University");
            RadioButton rd_Institute = (RadioButton)dv_Query.FindControl("rd_Institute");
            RadioButton rd_Schools = (RadioButton)dv_Query.FindControl("rd_Schools");
            RadioButton rd_Courses = (RadioButton)dv_Query.FindControl("rd_Courses");
            DropDownList ddl_Category = (DropDownList)dv_Query.FindControl("ddl_Category");
            DropDownList ddl_City = (DropDownList)dv_Query.FindControl("ddl_City");
            ListBox ListBox_Institute = (ListBox)dv_Query.FindControl("ListBox_Institute");

            QueryGeneratorClass objQuery = new QueryGeneratorClass();

            string strType = "";

            if (rd_University.Checked == true)
            {
                strType = "University";
            }
            else if (rd_Institute.Checked == true)
            {
                strType = "Institute";
            }
            else if (rd_Courses.Checked == true)
            {
                strType = "Courses";
            }
            else if (rd_Schools.Checked == true)
            {
                strType = "School";
            }

            string strIdentity = "";
            
            for (int i = 0; i < ListBox_Institute.Items.Count; i++)
            {
                if (ListBox_Institute.Items[i].Selected == true)
                {
                    strIdentity += ListBox_Institute.Items[i].Value.ToString() + ",";
                }
            }

            strIdentity = strIdentity.TrimEnd(',');

            objQuery.strType = strType;
            
            if (ddl_Category.SelectedValue != "0")
            {
                objQuery.iCategoryID = int.Parse(ddl_Category.SelectedValue);
            }

            if (ddl_City.SelectedValue != "0")
            {
                objQuery.iCityID = int.Parse(ddl_City.SelectedValue);
            }

            objQuery.strIdentity = strIdentity;
            objQuery.strTitle = txtTitle.Text.Trim();
            objQuery.strYoutubeTitle = txtYoutubeTitle.Text.Trim();
            objQuery.strYoutube = txtYoutube.Text.Trim();
            objQuery.strDesc = txtDesc.Text.Trim();
            objQuery.strMetaTitle = txtMetaTitle.Text;
            objQuery.strMetaDesc = txtMetaDesc.Text;
            objQuery.strMetakeys = txtMetaKeys.Text;

            string strResponse = objQuery.fn_saveQueryGenerator();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info_dv.FindControl("mssg")).Text = strResponse;
                info_dv.Visible = true;
            }
            else
            {
                ((Label)error_dv.FindControl("mssg")).Text = strResponse;
                error_dv.Visible = true;
            }

            // Bind Data To grid
            grd_Query.DataSource = objQuery.fn_getQueryGeneratorList();
            grd_Query.DataBind();

            // reset fields
            txtTitle.Text = "";
            txtYoutubeTitle.Text = "";
            txtYoutube.Text = "";
            txtDesc.Text = "";
            txtMetaTitle.Text = "";
            txtMetaDesc.Text = "";
            txtMetaKeys.Text = "";
            ddl_Category.SelectedIndex = 0;
            ddl_City.SelectedIndex = 0;
            ListBox_Institute.Items.Clear();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Query_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtTitle = (TextBox)dv_Query.FindControl("txtTitle");
            TextBox txtYoutubeTitle = (TextBox)dv_Query.FindControl("txtYoutubeTitle");
            TextBox txtYoutube = (TextBox)dv_Query.FindControl("txtYoutube");
            TextBox txtDesc = (TextBox)dv_Query.FindControl("txtDesc");
            TextBox txtMetaTitle = (TextBox)dv_Query.FindControl("txtMetaTitle");
            TextBox txtMetaDesc = (TextBox)dv_Query.FindControl("txtMetaDesc");
            TextBox txtMetaKeys = (TextBox)dv_Query.FindControl("txtMetaKeys");
            RadioButton rd_University = (RadioButton)dv_Query.FindControl("rd_University");
            RadioButton rd_Institute = (RadioButton)dv_Query.FindControl("rd_Institute");
            RadioButton rd_Schools = (RadioButton)dv_Query.FindControl("rd_Schools");
            RadioButton rd_Courses = (RadioButton)dv_Query.FindControl("rd_Courses");
            DropDownList ddl_Category = (DropDownList)dv_Query.FindControl("ddl_Category");
            DropDownList ddl_City = (DropDownList)dv_Query.FindControl("ddl_City");
            ListBox ListBox_Institute = (ListBox)dv_Query.FindControl("ListBox_Institute");

            QueryGeneratorClass objQuery = new QueryGeneratorClass();
            objQuery.iID = int.Parse(dv_Query.DataKey.Value.ToString());
            
            string strType = "";

            if (rd_University.Checked == true)
            {
                strType = "University";
            }
            else if (rd_Institute.Checked == true)
            {
                strType = "Institute";
            }
            else if (rd_Courses.Checked == true)
            {
                strType = "Courses";
            }
            else if (rd_Schools.Checked == true)
            {
                strType = "School";
            }

            string strIdentity = "";

            for (int i = 0; i < ListBox_Institute.Items.Count; i++)
            {
                if (ListBox_Institute.Items[i].Selected == true)
                {
                    strIdentity += ListBox_Institute.Items[i].Value.ToString() + ",";
                }
            }

            strIdentity = strIdentity.TrimEnd(',');

            objQuery.strType = strType;

            if (ddl_Category.SelectedValue != "0")
            {
                objQuery.iCategoryID = int.Parse(ddl_Category.SelectedValue);
            }

            if (ddl_City.SelectedValue != "0")
            {
                objQuery.iCityID = int.Parse(ddl_City.SelectedValue);
            }

            objQuery.strIdentity = strIdentity;
            objQuery.strTitle = txtTitle.Text.Trim();
            objQuery.strYoutubeTitle = txtYoutubeTitle.Text.Trim();
            objQuery.strYoutube = txtYoutube.Text.Trim();
            objQuery.strDesc = txtDesc.Text.Trim();
            objQuery.strMetaTitle = txtMetaTitle.Text;
            objQuery.strMetaDesc = txtMetaDesc.Text;
            objQuery.strMetakeys = txtMetaKeys.Text;

            string strResponse = objQuery.fn_editQueryGenerator();

            if (strResponse.StartsWith("SUCCESS"))
            {
                ((Label)info_dv.FindControl("mssg")).Text = strResponse;
                info_dv.Visible = true;
            }
            else
            {
                ((Label)error_dv.FindControl("mssg")).Text = strResponse;
                error_dv.Visible = true;
            }

            dv_Query.ChangeMode(DetailsViewMode.ReadOnly);

            objQuery.iID = int.Parse(grd_Query.SelectedDataKey.Value.ToString());

            dv_Query.DataSource = objQuery.fn_getQueryGeneratorByID();
            dv_Query.DataBind();

            // Bind Data To grid            
            grd_Query.DataSource = objQuery.fn_getQueryGeneratorList();
            grd_Query.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Query_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (dv_Query.CurrentMode == DetailsViewMode.Insert && e.NewMode == DetailsViewMode.ReadOnly)
            {
                dv_Query.ChangeMode(DetailsViewMode.Insert);
            }
            else
            {
                dv_Query.ChangeMode(e.NewMode);

                if (grd_Query.SelectedIndex >= 0)
                {
                    QueryGeneratorClass objQuery = new QueryGeneratorClass();
                    objQuery.iID = int.Parse(grd_Query.SelectedDataKey.Value.ToString());

                    dv_Query.DataSource = objQuery.fn_getQueryGeneratorByID();
                    dv_Query.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message;
            error.Visible = true;
        }
    }

    protected void dv_Query_DataBound(object sender, EventArgs e)
    {
        try
        {
            if (dv_Query.CurrentMode == DetailsViewMode.Insert)
            {
                fn_BindCityDDL();
                fn_BindUniversity();
            }

            if (dv_Query.CurrentMode == DetailsViewMode.Edit)
            {
                fn_BindCityDDL();

                RadioButton rd_University = (RadioButton)dv_Query.FindControl("rd_University");
                RadioButton rd_Institute = (RadioButton)dv_Query.FindControl("rd_Institute");
                RadioButton rd_Schools = (RadioButton)dv_Query.FindControl("rd_Schools");
                RadioButton rd_Courses = (RadioButton)dv_Query.FindControl("rd_Courses");
                DropDownList ddl_Category = (DropDownList)dv_Query.FindControl("ddl_Category");
                DropDownList ddl_City = (DropDownList)dv_Query.FindControl("ddl_City");
                ListBox ListBox_Institute = (ListBox)dv_Query.FindControl("ListBox_Institute");

                QueryGeneratorClass objQuery = new QueryGeneratorClass();
                objQuery.iID = int.Parse(grd_Query.SelectedDataKey.Value.ToString());
                CoreWebList<QueryGeneratorClass> objQueryList = objQuery.fn_getQueryGeneratorByID();
                if (objQueryList.Count > 0)
                {
                    if (objQueryList[0].iCategoryID != 0)
                    {
                        ddl_Category.SelectedValue = objQueryList[0].iCategoryID.ToString();
                    }
                    if (objQueryList[0].iCityID != 0)
                    {
                        ddl_City.SelectedValue = objQueryList[0].iCityID.ToString();
                    }

                    if (objQueryList[0].strType == "University")
                    {
                        rd_University.Checked = true;
                        fn_BindUniversity();
                    }
                    else if (objQueryList[0].strType == "Institute")
                    {
                        fn_BindInstituteCategoryDDL();
                        rd_Institute.Checked = true;
                        fn_BindInstitutes();
                    }
                    else if (objQueryList[0].strType == "School")
                    {
                        fn_BindSchoolCategoryDDL();
                        rd_Schools.Checked = true;
                        fn_BindSchools();
                    }
                    else if (objQueryList[0].strType == "Courses")
                    {
                        fn_BindInstituteCategoryDDL();
                        rd_Courses.Checked = true;
                        fn_BindCourses();
                    }

                    string strIDs = objQueryList[0].strIdentity;
                    strIDs = strIDs.Replace("'", "");
                    string[] myArray = strIDs.Split(',');

                    for (int i = 0; i < ListBox_Institute.Items.Count; i++)
                    {
                        int itemID = int.Parse(ListBox_Institute.Items[i].Value);

                        for (int j = 0; j < myArray.Length; j++)
                        {
                            int Item = int.Parse(myArray[j].ToString());
                            if (Item == itemID)
                            {
                                ListBox_Institute.Items[i].Selected = true;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }

    protected void rd_University_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddl_Category = (DropDownList)dv_Query.FindControl("ddl_Category");
            if (ddl_Category != null)
            {
                ddl_Category.Visible=false;
            }

            fn_BindUniversity();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void rd_Courses_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            fn_BindInstituteCategoryDDL();
            fn_BindCourses();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void rd_Institute_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            fn_BindInstituteCategoryDDL();
            fn_BindInstitutes();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void rd_Schools_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            fn_BindSchoolCategoryDDL();
            fn_BindSchools();
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
    
    public void fn_BindInstituteCategoryDDL()
    {
        try
        {
            DropDownList ddl_Category = (DropDownList)dv_Query.FindControl("ddl_Category");

            if (ddl_Category != null)
            {
                ddl_Category.Visible = true;

                InstituteCategoryClass objCategory = new InstituteCategoryClass();
                ddl_Category.DataSource = objCategory.fn_getCategoryList();
                ddl_Category.DataTextField = "strCategoryTitle";
                ddl_Category.DataValueField = "iID";
                ddl_Category.DataBind();
                ddl_Category.Items.Insert(0, new ListItem("Select Category", "0"));
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    public void fn_BindSchoolCategoryDDL()
    {
        try
        {
            DropDownList ddl_Category = (DropDownList)dv_Query.FindControl("ddl_Category");

            if (ddl_Category != null)
            {
                ddl_Category.Visible = true;

                SchoolCategoryClass objCategory = new SchoolCategoryClass();
                ddl_Category.DataSource = objCategory.fn_getSchoolCategoryList();
                ddl_Category.DataTextField = "strTitle";
                ddl_Category.DataValueField = "iID";
                ddl_Category.DataBind();
                ddl_Category.Items.Insert(0, new ListItem("Select Category", "0"));
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    public void fn_BindCityDDL()
    {
        try
        {
            DropDownList ddl_City = (DropDownList)dv_Query.FindControl("ddl_City");

            if (ddl_City != null)
            {
                CityClass objCity = new CityClass();
                ddl_City.DataSource = objCity.fn_getCityList();
                ddl_City.DataTextField = "strTitle";
                ddl_City.DataValueField = "iID";
                ddl_City.DataBind();
                ddl_City.Items.Insert(0, new ListItem("Select City", "0"));
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            RadioButton rd_University = (RadioButton)dv_Query.FindControl("rd_University");
            RadioButton rd_Institute = (RadioButton)dv_Query.FindControl("rd_Institute");
            RadioButton rd_Schools = (RadioButton)dv_Query.FindControl("rd_Schools");
            RadioButton rd_Courses = (RadioButton)dv_Query.FindControl("rd_Courses");
            
            if (rd_University.Checked == true)
            {
                fn_BindUniversity();
            }
            else if (rd_Institute.Checked == true)
            {
                fn_BindInstitutes();
            }
            else if (rd_Schools.Checked == true)
            {
                fn_BindSchools();
            }
            else if (rd_Courses.Checked == true)
            {
                fn_BindCourses();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            RadioButton rd_University = (RadioButton)dv_Query.FindControl("rd_University");
            RadioButton rd_Institute = (RadioButton)dv_Query.FindControl("rd_Institute");
            RadioButton rd_Schools = (RadioButton)dv_Query.FindControl("rd_Schools");
            RadioButton rd_Courses = (RadioButton)dv_Query.FindControl("rd_Courses");

            if (rd_University.Checked == true)
            {
                fn_BindUniversity();
            }
            else if (rd_Institute.Checked == true)
            {
                fn_BindInstitutes();
            }
            else if (rd_Schools.Checked == true)
            {
                fn_BindSchools();
            }
            else if (rd_Courses.Checked == true)
            {
                fn_BindCourses();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    public void fn_BindUniversity()
    {
        try
        {
            ListBox ListBox_Institute = (ListBox)dv_Query.FindControl("ListBox_Institute");
            DropDownList ddl_City = (DropDownList)dv_Query.FindControl("ddl_City");

            if (ListBox_Institute != null && ddl_City != null)
            {
                string strQuery = "SELECT * FROM edu_UniversityList";

                if (ddl_City.SelectedValue != "0")
                {
                     strQuery += " WHERE universityList_city='" + ddl_City.SelectedItem.Text + "'";
                }

                UniversityListClass objUniversity = new UniversityListClass();
                CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_getUniversityListByQuery(strQuery);
                if (objUniversityList.Count > 0)
                {
                    ListBox_Institute.DataSource = objUniversityList;
                    ListBox_Institute.DataTextField = "strTitle";
                    ListBox_Institute.DataValueField = "iID";
                    ListBox_Institute.DataBind();
                }
                else
                {
                    ListBox_Institute.Items.Clear();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    public void fn_BindInstitutes()
    {
        try
        {
            ListBox ListBox_Institute = (ListBox)dv_Query.FindControl("ListBox_Institute");
            DropDownList ddl_Category = (DropDownList)dv_Query.FindControl("ddl_Category");
            DropDownList ddl_City = (DropDownList)dv_Query.FindControl("ddl_City");

            if (ListBox_Institute != null && ddl_Category != null && ddl_City != null)
            {
                
                string strQuery = "SELECT * FROM tbl_Institutes";
                bool bStatus = false;

                if (ddl_Category.SelectedValue != "0")
                {
                    strQuery += " WHERE Institute_ID IN (SELECT instituteCategoryList_instituteID FROM edu_InstituteCategoryList WHERE instituteCategoryList_catID=" + ddl_Category.SelectedValue + ")";
                    bStatus = true;
                }

                if (ddl_City.SelectedValue != "0")
                {
                    if (bStatus == false)
                    {
                        strQuery += " WHERE Institute_CityID=" + ddl_City.SelectedValue;
                    }
                    else
                    {
                        strQuery += " AND Institute_CityID=" + ddl_City.SelectedValue;
                    }
                }

                InstituteClass objInstitute = new InstituteClass();
                CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteListByQuery(strQuery);
                if (objInstituteList.Count > 0)
                {
                    ListBox_Institute.DataSource = objInstituteList;
                    ListBox_Institute.DataTextField = "strTitle";
                    ListBox_Institute.DataValueField = "iID";
                    ListBox_Institute.DataBind();
                }
                else
                {
                    ListBox_Institute.Items.Clear();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    public void fn_BindCourses()
    {
        try
        {
            ListBox ListBox_Institute = (ListBox)dv_Query.FindControl("ListBox_Institute");
            DropDownList ddl_Category = (DropDownList)dv_Query.FindControl("ddl_Category");
            DropDownList ddl_City = (DropDownList)dv_Query.FindControl("ddl_City");

            if (ListBox_Institute != null && ddl_Category != null && ddl_City != null)
            {
                string strQuery = "SELECT * FROM dbo.tbl_InstituteCourses";
                bool bStatus = false;

                if (ddl_Category.SelectedValue != "0")
                {
                    strQuery += " WHERE InstituteCourse_CategoryID=" + ddl_Category.SelectedValue;
                    bStatus = true;
                }

                if (ddl_City.SelectedValue != "0")
                {
                    if (bStatus == false)
                    {
                        strQuery += " WHERE InstituteCourse_InstituteID IN (SELECT Institute_ID FROM tbl_Institutes WHERE Institute_CityID=" + ddl_City.SelectedValue + ")";
                    }
                    else
                    {
                        strQuery += " AND InstituteCourse_InstituteID IN (SELECT Institute_ID FROM tbl_Institutes WHERE Institute_CityID=" + ddl_City.SelectedValue + ")";
                    }
                }

                InstituteCourseClass objCourses = new InstituteCourseClass();
                CoreWebList<InstituteCourseClass> objCoursesList = objCourses.fn_getInstituteCourseListByQuery(strQuery);
                if (objCoursesList.Count > 0)
                {
                    ListBox_Institute.DataSource = objCoursesList;
                    ListBox_Institute.DataTextField = "strTitle";
                    ListBox_Institute.DataValueField = "iID";
                    ListBox_Institute.DataBind();
                }
                else
                {
                    ListBox_Institute.Items.Clear();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    public void fn_BindSchools()
    {
        try
        {
            ListBox ListBox_Institute = (ListBox)dv_Query.FindControl("ListBox_Institute");
            DropDownList ddl_Category = (DropDownList)dv_Query.FindControl("ddl_Category");
            DropDownList ddl_City = (DropDownList)dv_Query.FindControl("ddl_City");

            if (ListBox_Institute != null && ddl_Category != null && ddl_City != null)
            {
                string strQuery = "SELECT * FROM tbl_Schools";
                bool bStatus = false;

                if (ddl_Category.SelectedValue != "0")
                {
                    strQuery += " WHERE School_ID IN (SELECT SchoolCategoryList_SchoolID FROM tbl_SchoolCategoryList WHERE SchoolCategoryList_CategoryID=" + ddl_Category.SelectedValue + ")";
                    bStatus = true;
                }

                if (ddl_City.SelectedValue != "0")
                {
                    if (bStatus == false)
                    {
                        strQuery += " WHERE School_CityID=" + ddl_City.SelectedValue;
                    }
                    else
                    {
                        strQuery += " AND School_CityID=" + ddl_City.SelectedValue;
                    }
                }

                SchoolClass objSchool = new SchoolClass();
                CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolListByQuery(strQuery);
                if (objSchoolList.Count > 0)
                {
                    ListBox_Institute.DataSource = objSchoolList;
                    ListBox_Institute.DataTextField = "strTitle";
                    ListBox_Institute.DataValueField = "iID";
                    ListBox_Institute.DataBind();
                }
                else
                {
                    ListBox_Institute.Items.Clear();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            QueryGeneratorClass objQuery = new QueryGeneratorClass();
            objQuery.strTitle = txtSearch.Text.Trim();
            CoreWebList<QueryGeneratorClass> objQueryList = objQuery.fn_getQueryGeneratorByKeys();
            if (objQueryList.Count > 0)
            {
                DataTable dtQuery = (DataTable)objQueryList;
                grd_Query.DataSource = objQueryList;
            }
            else
            {
                grd_Query.DataSource = null;
            }
            grd_Query.DataBind();
        }
        catch (Exception ex)
        {
            ((Label)error.FindControl("mssg")).Text = "ERROR : " + ex.Message + ex.StackTrace;
            error.Visible = true;
        }
    }
}