using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using yo_lib;
using System.Collections;


public partial class BlogDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                if (RouteData.Values["Blog"] != null)
                {
                    BlogClass objBlog = new BlogClass();
                    objBlog.strTitle = RouteData.Values["Blog"].ToString().Replace("-", " ");
                    CoreWebList<BlogClass> objBlogList = objBlog.fn_getBlogByTitle();
                    if (objBlogList.Count > 0)
                    {
                        ltl_Title.Text = objBlogList[0].strTitle;

                        img_Blogs.Src = "https://www.eduvidya.com/files/Blog/" + objBlogList[0].strImage;
                        img_Blogs.Alt = objBlogList[0].strTitle;

                        ltl_Desc.Text = objBlogList[0].strDescription;

                        PageTitle.InnerText = objBlogList[0].strTitle;
                        MetaDesc.Attributes.Add("content", PageTitle.InnerText);
                        MetaKeywords.Attributes.Add("content", PageTitle.InnerText);

                        PageTitle.InnerText = PageTitle.InnerText.ToUpper();

                        HtmlControl dynamicid = (HtmlControl)Master.FindControl("dynamicid");
                        dynamicid.ID = "details-page";
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
