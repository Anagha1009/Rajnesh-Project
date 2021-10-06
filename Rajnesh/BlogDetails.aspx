<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="BlogDetails.aspx.cs" Inherits="BlogDetails" %>

<asp:Content ID="MetaContent" runat="server" ContentPlaceHolderID="head">
    <title id="PageTitle" runat="server"></title>
    <meta runat="server" id="MetaDesc" name="Description" content="" />
    <meta runat="server" id="MetaKeywords" name="Keywords" content="" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cp_left" runat="Server">
          <asp:ScriptManager ID="src" runat="server">
                    </asp:ScriptManager>
    <div class="box">
        <div class="heading">
            <a href="#">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></a>
        </div>
        <div class="box-content">
            <div class="filter-result">
                <div class="detail-list">
                    <ul>
                        <li>
                            <div class="imgblock">
                                <img id="img_Blogs" runat="server" />
                            </div>
                            <div class="contentblock">
                                <asp:Literal ID="ltl_Desc" runat="server"></asp:Literal>
                            </div>

                        </li>
                    </ul>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
