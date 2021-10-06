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
                DistanceLearningClass objDistance = new DistanceLearningClass();
                objDistance.strType = "University";
                CoreWebList<DistanceLearningClass> objDistanceList = objDistance.fn_Get_Random_DistanceLearningListByType();
                if (objDistanceList.Count > 0)
                {
                    rpt_DistanceUniversity.DataSource = objDistanceList;
                    rpt_DistanceUniversity.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + ex.StackTrace);
            }
        }
    }
}