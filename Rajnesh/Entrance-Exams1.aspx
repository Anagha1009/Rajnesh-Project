<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Entrance-Exams.aspx.cs" Inherits="EntranceExam" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="Pager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Entrance Exams in India 2018 for MBA, Engineering, Medical, Law</title>
    <meta name="Description" content="Get List of Entrance Exams in India 2018 for MBA, Engineering, Medical, Law, Architecture and Civil Services" />
    <meta name="Keywords" content="Entrance Exams in India " />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <div class="box">
        <div class="heading"><a href="#">Entrance Exams in India 2018</a></div>
        <div class="box-content">


            <div class="rating">
                <div id="score" style="cursor: pointer;">
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
                    <div class="Ratingleft">
                        <asp:Rating ID="rt_Rate" runat="server" StarCssClass="StarCss" FilledStarCssClass="FilledStarCss"
                            EmptyStarCssClass="EmptyStarCss" WaitingStarCssClass="WaitingStarCss" AutoPostBack="true"
                            OnChanged="rt_Rate_Changed" MaxRating="5">
                        </asp:Rating>
                    </div>
                </div>
                <div class="rating-text">
                    <asp:Literal ID="ltl_RatingBox" runat="server"></asp:Literal>
                </div>
            </div>

            <div class="social-share">
                <script type="text/javascript">   var switchTo5x = true;</script>
                <script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>
                <script type="text/javascript"> stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                    displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
            </div>
            <div class="height-10"></div>
            <div class="list">
                <p>
                    Given below is the List of Entrance Exams in India 2018 for MBA, Engineering, Medical, Law, Architecture and Civil Services Exam. There is no escaping exam in India. Whether you want to work for a private company or for government sector, you will have to go through the rigors of exams. It is not just jobs, even getting through to desired courses (graduate and post graduate) requires the aspiring candidates to go through these entrance exams.
                </p>
                <br />
                <p>
                    Some of the most popular entrance exams in India are for engineering, medical, mba, banks and civil services. Each exam has its own set of rules and regulations. Most of the exams are conducted at the national level. There are certain exams by some colleges that are held for admission to their very own courses only.
                </p>
                <br />
                <ul>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Blogs/Engineering-Exams-in-India">Engineering Exams in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Blogs/Medical-Exams-in-India">Medical Exams in India</a></li>
                    <li class="round-arrow-bullet"><a href="https://www.eduvidya.com/Blogs/MBA-Exams-in-India">MBA Exams in India</a></li>
                </ul>
            </div>

            <div class="filter-result">

                <div class="detail-list">
                    <ul>
                        <asp:Repeater ID="rpt_EntranceExam" runat="server">
                            <ItemTemplate>
                                <li>
                                    <a href='<%# VirtualPathUtility.ToAbsolute("~/Entrance-Exam/" + Eval("strTitle").ToString().Replace(" ","-")) %>'>
                                        <%# Eval("strTitle") %></a><br />
                                    <span><%# ((bool)(Eval("strDesc").ToString().Length > 210)) == true ? Eval("strDesc").ToString().Replace("<p>", "").Replace("</p>", "").Substring(0, 210) + " ..." : Eval("strDesc")%></span>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="google-ad">
                <script type="text/javascript"><!--
    google_ad_client = "ca-pub-4037987430386783";
    /* Eduvidya-Link-728&#42;15 */
    google_ad_slot = "4438952914";
    google_ad_width = 728;
    google_ad_height = 15;
    //-->
                </script>
                <script type="text/javascript" src="https://pagead2.googlesyndication.com/pagead/show_ads.js">
                </script>
            </div>
        </div>

    </div>
</asp:Content>
