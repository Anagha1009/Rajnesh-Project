<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="NewsDetails.aspx.cs" Inherits="Admissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scManager" runat="server"></asp:ScriptManager>
    <div class="box">
        <div class="heading"><a href="#">
            <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></a></div>
        <div class="box-content">
            <div class="filter-result">
                <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
            </div>
            <div>
                <script type="text/javascript">                        var switchTo5x = true;</script>
                <script type="text/javascript" src="/js/button.js"></script>
                <%--<script type="text/javascript" src="https://w.sharethis.com/button/buttons.js"></script>--%>
                <script type="text/javascript">                        stLight.options({ publisher: "48258661-ca69-42d4-831c-4dc41b9328a1" });</script>
                <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large'
                    displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large'
                        displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
            </div>

        </div>
    </div>
  
</asp:Content>
