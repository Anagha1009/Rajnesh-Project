using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class UserControls_WebUserControl2 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                fn_BindCategoryDDL();
                fn_BindCityDDL(ddl_City1);
                fn_BindCityDDL(ddl_City2);
                fn_BindCityDDL(ddl_City3);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindCategoryDDL()
    {
        try
        {
            InstituteCategoryClass objCategory = new InstituteCategoryClass();
            ddl_InstCategory.DataSource = objCategory.fn_getOrderedCategoryList();
            ddl_InstCategory.DataTextField = "strCategoryTitle";
            ddl_InstCategory.DataValueField = "iID";
            ddl_InstCategory.DataBind();
            ddl_InstCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }


    protected void fn_BindCityDDL(DropDownList ddlCity)
    {
        try
        {
            CityClass objCity = new CityClass();
            ddlCity.DataSource = objCity.fn_getCityList();
            ddlCity.DataTextField = "strTitle";
            ddlCity.DataValueField = "iID";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("Select City", "0"));
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void fn_BindInstituteDDL(DropDownList ddl_Instituite, int iCityID)
    {
        try
        {
            InstituteClass objInstitute = new InstituteClass();

            objInstitute.iCategoryID = int.Parse(ddl_InstCategory.SelectedValue);
            objInstitute.iCityID = iCityID;
            ddl_Instituite.DataSource = objInstitute.fn_getInstituteByCategoryIDCityID();
            ddl_Instituite.DataTextField = "strTitle";
            ddl_Instituite.DataValueField = "iID";
            ddl_Instituite.DataBind();
            ddl_Instituite.Items.Insert(0, new ListItem("Select Institute", "0"));
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void ddl_City_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlCity = ((DropDownList)sender);
            string strCityID = ddlCity.ID;
            int iCityID = int.Parse(ddlCity.SelectedValue);

            if (strCityID == "ddl_City1")
            {
                fn_BindInstituteDDL(ddl_Institute1, iCityID);
            }

            else if (strCityID == "ddl_City2")
            {
                fn_BindInstituteDDL(ddl_Institute2, iCityID);
            }

            else if (strCityID == "ddl_City3")
            {
                fn_BindInstituteDDL(ddl_Institute3, iCityID);
            }
            
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void btn_Compare_Click(object sender, EventArgs e)
    {
        try
        {
            string strTitle = "";
            string strInstitute1 = "";
            string strInstitute2 = "";
            string strInstitute3 = "";

            int iInstituteId1 = 0;
            int iInstituteId2 = 0;
            int iInstituteId3 = 0;

            string strUrl = "";

            if (ddl_Institute1.SelectedValue != "0" && ddl_Institute2.SelectedValue != "0" && ddl_Institute3.SelectedValue != "0")
            {
                strInstitute1 = fn_trimInstitute(ddl_Institute1.SelectedItem.Text);
                strInstitute2 = fn_trimInstitute(ddl_Institute2.SelectedItem.Text);
                strInstitute3 = fn_trimInstitute(ddl_Institute3.SelectedItem.Text);

                iInstituteId1 = int.Parse(ddl_Institute1.SelectedValue);
                iInstituteId2 = int.Parse(ddl_Institute2.SelectedValue);
                iInstituteId3 = int.Parse(ddl_Institute3.SelectedValue);

                strUrl = VirtualPathUtility.ToAbsolute("~/Compare-Institutes.aspx?Institute1=" + strInstitute1 + "&Institute2=" + strInstitute2 + "&Institute3=" + strInstitute3 + "&InstituteID1=" + iInstituteId1 + "&InstituteID2=" + iInstituteId2 + "&InstituteID3=" + iInstituteId3);

                strTitle = "Compare " + ddl_Institute1.SelectedItem.Text + " With " + ddl_Institute2.SelectedItem.Text + " And " + ddl_Institute3.SelectedItem.Text;
            }

            else if (ddl_Institute1.SelectedValue != "0" && ddl_Institute2.SelectedValue != "0" && ddl_Institute3.SelectedValue == "0")
            {
                strInstitute1 = fn_trimInstitute(ddl_Institute1.SelectedItem.Text);
                strInstitute2 = fn_trimInstitute(ddl_Institute2.SelectedItem.Text);

                iInstituteId1 = int.Parse(ddl_Institute1.SelectedValue);
                iInstituteId2 = int.Parse(ddl_Institute2.SelectedValue);

                strUrl = VirtualPathUtility.ToAbsolute("~/Compare-Institutes.aspx?Institute1=" + strInstitute1 + "&Institute2=" + strInstitute2 + "&InstituteID1=" + iInstituteId1 + "&InstituteID2=" + iInstituteId2);

                strTitle = "Compare " + ddl_Institute1.SelectedItem.Text + " And " + ddl_Institute2.SelectedItem.Text;
            }

            fn_StoreComparision(strTitle, iInstituteId1, iInstituteId2, iInstituteId3);
            Response.Redirect(strUrl);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected string fn_trimInstitute(string strInstitute)
    {
        try
        {
            strInstitute = strInstitute.Trim().Replace(" ", "-").Replace("&", "-").Replace("?", "-").Replace(",", "-").Replace(":", "-").Replace("---", "-").Replace("--", "-");
            return strInstitute;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void fn_StoreComparision(string strTitle, int iInstituteID1, int iInstituteID2, int iInstituteID3)
    {
        try
        {
            //CompareInstituteClass objCompareInstitute = new CompareInstituteClass();
            //objCompareInstitute.iInstituteID1 = iInstituteID1;
            //objCompareInstitute.iInstituteID2 = iInstituteID2;
            //objCompareInstitute.iInstituteID3 = iInstituteID3;
            //CoreWebList<CompareInstituteClass> objCompareInstituteList = objCompareInstitute.fn_getCompareInstituteByInstituteID();
            //if (objCompareInstituteList.Count == 0)
            //{
            //    objCompareInstitute.strTitle = strTitle;
            //    string strResponse = objCompareInstitute.fn_saveCompareInstitute();
            //}
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }
}