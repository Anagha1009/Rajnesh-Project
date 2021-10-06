using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;
using System.Data;

public partial class Our_team : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TeamMemberClass objTeam = new TeamMemberClass();
        CoreWebList<TeamMemberClass>objTeamList = objTeam.fn_getTeamMemberList();
        if (objTeamList.Count > 0)
        {
            rpt_TeamMembers.DataSource = objTeamList;
            rpt_TeamMembers.DataBind();
        }
    }
}
