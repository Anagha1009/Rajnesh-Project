<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Banner.ascx.cs" Inherits="UserControls_InstituteBanner" %>
<link href="Gallery.css" rel="stylesheet" type="text/css" />

<div class="box" id="Banner_Box" runat="server">
    <div class="heading">
        <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
    </div>
    <div class="box-content">
        <div class="list">
            <p>
                <asp:Literal ID="ltl_Rank" runat="server"></asp:Literal>
            </p>

        </div>
        <div class="filter-result">
            <div class="detail-list">
                <ul>
                    <li>
                        <a id="hyp_Next" runat="server" target="_blank" class="bannerClick">
                            <div class="imgblock">
                                <img src="" id="img_BannerDetailPhoto" runat="server" />
                            </div>
                            <div class="contentblock">
                                <asp:Literal ID="ltl_BannerDetailTitle" runat="server"></asp:Literal>
                            </div>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>
<%--<table width="100%" cellpadding="2" cellspacing="2" border="0" class="Banner_Box"
    id="Banner_Box" runat="server">
    <tr>
        <td align="left" class="_mainTitle">
            <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td align="center">
            <a id="hyp_Next" runat="server" target="_blank" class="bannerClick">
                <div>
                    <div class="title">
                        <asp:Literal ID="ltl_Rank" runat="server"></asp:Literal>
                    </div>
                    <div class="clr">
                    </div>
                    <div class="photos">
                        <img src="" id="img_BannerDetailPhoto" runat="server" />
                    </div>
                    <div class="clr">
                    </div>
                    <div class="title">
                        <asp:Literal ID="ltl_BannerDetailTitle" runat="server"></asp:Literal>
                    </div>
                    <div class="clr" style="height: 20px">
                        &nbsp;
                    </div>
                    Click Here for Full List
                </div>
            </a>
        </td>
    </tr>
</table>--%>
