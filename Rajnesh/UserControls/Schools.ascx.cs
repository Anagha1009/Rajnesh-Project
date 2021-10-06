using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class UserControls_Schools : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string strUrl = Request.Url.ToString().ToLower();
                if (strUrl.Contains("/schools/"))
                {
                    if (this.Page.RouteData.Values["School"] != null)
                    {
                        SchoolClass objSchool = new SchoolClass();
                        objSchool.strTitle = this.Page.RouteData.Values["School"].ToString().Replace("-", " ");
                        CoreWebList<SchoolClass> objSchoolList = objSchool.fn_getSchoolByName();
                        if (objSchoolList.Count > 0)
                        {
                            SchoolClass obj_School = new SchoolClass();
                            obj_School.iCityID = objSchoolList[0].iCityID;
                            CoreWebList<SchoolClass> obj_SchoolList = obj_School.fn_getRandomSchoolByCityID();
                            if (obj_SchoolList.Count > 0)
                            {
                                rpt_Schools.DataSource = obj_SchoolList;
                                rpt_Schools.DataBind();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + ex.StackTrace);
            }
        }
    }
}