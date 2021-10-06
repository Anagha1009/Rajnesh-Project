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
                UniversityListClass objUniversity = new UniversityListClass();
                CoreWebList<UniversityListClass> objUniversityList = objUniversity.fn_get_Random_UniversityList();
                if (objUniversityList.Count > 0)
                {
                    rpt_University.DataSource = objUniversityList;
                    rpt_University.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + ex.StackTrace);
            }
        }
    }
}