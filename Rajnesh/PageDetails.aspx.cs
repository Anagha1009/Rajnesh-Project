using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yo_lib;

public partial class Page_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (RouteData.Values["Page"] != null)
            {
                string strPage = RouteData.Values["Page"].ToString().Replace("-", " ");
                PageClass objPage = new PageClass();
                objPage.strTitle = strPage;
                CoreWebList<PageClass> objPageList = objPage.fn_getPageByName();
                if (objPageList.Count > 0)
                {
                    int PageId = objPageList[0].iID;

                    ltl_Title.Text = "<h1>" + objPageList[0].strTitle + "</h1>";
                    ltl_Details.Text = objPageList[0].strDetails;

                    BoxClass objBox = new BoxClass();
                    objBox.iPageID = PageId;
                    CoreWebList<BoxClass> objBoxList = objBox.fn_getBoxByPageID();
                    if (objBoxList.Count > 0)
                    {
                        rpt_Boxes.DataSource = objBoxList;
                        rpt_Boxes.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void rpt_Boxes_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rpt_Links = (Repeater)e.Item.FindControl("rpt_Links");
                HiddenField hf_BoxID =(HiddenField)e.Item.FindControl("hf_BoxID");
                if (rpt_Links != null && hf_BoxID != null)
                {
                    BoxLinkClass objBoxLink = new BoxLinkClass();
                    objBoxLink.iBoxID = int.Parse(hf_BoxID.Value);
                    CoreWebList<BoxLinkClass> objBoxLinkList = objBoxLink.fn_getBoxLinkByBoxID();
                    if (objBoxLinkList.Count > 0)
                    {
                        rpt_Links.DataSource = objBoxLinkList;
                        rpt_Links.DataBind();
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