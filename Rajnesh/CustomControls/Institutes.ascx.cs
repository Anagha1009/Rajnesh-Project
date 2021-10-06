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
                InstituteClass objInstitute = new InstituteClass();
                CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_get_Random_InstituteList();
                if (objInstituteList.Count > 0)
                {
                    rpt_Institutes.DataSource = objInstituteList;
                    rpt_Institutes.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + ex.StackTrace);
            }
        }
    }
}