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
                if (strUrl.Contains("/colleges/"))
                {
                    if (this.Page.RouteData.Values["College"] != null)
                    {
                        InstituteClass objInstitute = new InstituteClass();
                        objInstitute.strTitle = this.Page.RouteData.Values["College"].ToString().Replace("-", " ");
                        CoreWebList<InstituteClass> objInstituteList = objInstitute.fn_getInstituteByName();
                        if (objInstituteList.Count > 0)
                        {
                            InstituteClass obj_Institute = new InstituteClass();
                            obj_Institute.iCityID = objInstituteList[0].iCityID;
                            CoreWebList<InstituteClass> obj_InstituteList = obj_Institute.fn_getRandomInstituteByCityID();
                            if (obj_InstituteList.Count > 0)
                            {
                                rpt_Institutes.DataSource = obj_InstituteList;
                                rpt_Institutes.DataBind();
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