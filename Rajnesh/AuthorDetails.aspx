<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="AuthorDetails.aspx.cs" Inherits="City_AuthorDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
    <div class="box">
        <div class="heading">
            <a href="#">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></a>
        </div>
        <div class="box-content">

            <div class="list">
                <p>
                    Given below is the list of Authors.
                </p>

            </div>

            <div class="filter-result">

                <div class="detail-list">
                    <ul>
                        <li>
                            <div class="imgblock">
                                <img id="img_Photo" runat="server" />
                            </div>
                            <div class="contentblock">
                                <asp:Literal ID="ltl_Details" runat="server"></asp:Literal>
                                <br />
                                <asp:Literal ID="ltl_Email" runat="server"></asp:Literal>
                                <br />
                                <asp:Literal ID="ltl_Connect" runat="server"></asp:Literal>
                            </div>

                        </li>
                    </ul>
                </div>
            </div>
        </div>

    </div>
 
</asp:Content>
