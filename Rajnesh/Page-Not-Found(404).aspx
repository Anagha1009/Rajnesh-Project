<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Page-Not-Found(404).aspx.cs" Inherits="Page_not_found" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="Pager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Page Not Found 404</title>
    <meta name="Description" content="Page Not Found 404" />
    <meta name="Keywords" content="Page Not Found 404" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scrManager" runat="server">
    </asp:ScriptManager>
    <div class="box">
        <div class="heading">
            <a href="#">Page Not Found 404</a>
        </div>
        <div class="box-content">
            <div>
                <img src="images/PageNotFound.jpg" alt="Page Not Found" />
                <a href="https://www.eduvidya.com/">Please visit our home page</a>
            </div>
        </div>
    </div>

</asp:Content>
