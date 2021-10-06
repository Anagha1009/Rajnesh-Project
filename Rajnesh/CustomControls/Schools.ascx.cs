using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class UserControls_Controls : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                SchoolClass objSchools = new SchoolClass();
                CoreWebList<SchoolClass> objSchoolList = objSchools.fn_get_Random_SchoolList();
                if (objSchoolList.Count > 0)
                {
                    rpt_Schools.DataSource = objSchoolList;
                    rpt_Schools.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + ex.StackTrace);
            }
        }
    }
}