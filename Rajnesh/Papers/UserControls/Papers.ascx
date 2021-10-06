<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Papers.ascx.cs" Inherits="Papers_UserControls_Papers" %>

<script>
    $("#btnSearch").click(function () {
        debugger;
        $("#btnSearch").trigger("click");;
        //e.preventDefault();
        //$("#btnSearch").click('javascript:WebForm_DoPostBackWithOptions');
    });
</script>
<div class="height-10"></div>
<div class="box">
    <div class="heading">
        <asp:HyperLink ID="hlTitle" runat="server" Text="" NavigateUrl="#"></asp:HyperLink>
    </div>

    <div class="box-content">
        <%--<div class="search">
            <div class="course-type">
                <asp:DropDownList ID="ddlCategory" runat="server"
                    CssClass="dropbox">
                </asp:DropDownList>
            </div>
            <div class="course-type">
                <asp:DropDownList ID="ddlCompany" runat="server"
                    CssClass="dropbox">
                </asp:DropDownList>
            </div>
            <div class="college-location">
                <asp:DropDownList ID="ddlCity" runat="server"
                    CssClass="dropbox">
                </asp:DropDownList>
            </div>
            <div class="search-btn">
                <asp:Button ID="btnSearch" runat="server" ClientIDMode="Static"
                    ValidationGroup="vg_search" Text="Search"
                    CssClass="btnSubmit" OnClick="btnSearch_Click" />
            </div>
        </div>--%>
        <asp:Literal ID="lblDescription" runat="server"></asp:Literal>
        <div class="height-10"></div>
        <div class="rating">
            <div id="score" style="cursor: pointer;">
                <div class="Ratingleft">
                    <asp:Rating ID="rt_Rate" runat="server" StarCssClass="StarCss" FilledStarCssClass="FilledStarCss" EmptyStarCssClass="EmptyStarCss"
                        WaitingStarCssClass="WaitingStarCss" AutoPostBack="true"
                        OnChanged="rt_Rate_Changed" MaxRating="5">
                    </asp:Rating>
                </div>
            </div>
            <div class="rating-text">
                <asp:Literal ID="ltl_RatingBox" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="social-share">
            <script type="text/javascript">

                var switchTo5x = true;</script>
            <script type="text/javascript"
                src="http://w.sharethis.com/button/buttons.js"></script>
            <script type="text/javascript">

                stLight.options({
                    publisher: "48258661-ca69-42d4-831c-4dc41b9328a1"

                });</script>
            <span class='st_googleplus_large' displaytext='Google +'></span><span class='st_facebook_large' displaytext='Facebook'></span><span class='st_twitter_large' displaytext='Tweet'></span><span class='st_linkedin_large' displaytext='LinkedIn'></span><span class='st_sharethis_large' displaytext='ShareThis'></span><span class='st_email_large' displaytext='Email'></span>
        </div>
        <div class="height-10"></div>
        <div class="height-10"></div>
        <div class="list">
            <asp:GridView ID="grd_papers" runat="server" Width="98%" GridLines="None" AllowPaging="True"
                AllowSorting="false" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                PageSize="20" CellPadding="0" CellSpacing="0" PagerSettings-Position="TopAndBottom"
                PagerSettings-PageButtonCount="10" PagerStyle-BorderWidth="0" PagerStyle-HorizontalAlign="Right"
                PagerStyle-CssClass="pagelinks" PagerStyle-BorderColor="White" PagerSettings-Mode="NumericFirstLast"
                OnPageIndexChanging="grd_papers_PageIndexChanging">
                <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast"></PagerSettings>
                <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                <Columns>
                    <asp:TemplateField ShowHeader="true" 
                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="heading">
                        <HeaderStyle HorizontalAlign="Left" CssClass="heading"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Left" Width="97%" VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:HiddenField ID="hfldID" runat="server" Value='<%# Eval("iID") %>' />
                            <ul style="float: left;">
                                <li>
                                        <img src="../images/course_bullet.png" alt="" />
                                    <div class="jobs_info">
                                        <asp:HyperLink ID="Jobs" runat="server" NavigateUrl='<%# "/Placement-Paper-Details.aspx?Paper=" + Eval("strTitle").ToString().Replace("&","-").Replace("?","-").Replace(" ","-").Replace(",","-").Replace("---","-").Replace("--","-") + "&PaperID=" + Eval("iID") %>'
                                            CssClass="jobs" CausesValidation="false" Text='<%# Eval("strTitle") %>'></asp:HyperLink>
                                    </div>
                                    </li>
                                    <li>
                                    <div class="jobs_location">
                                        <span class="">
                                            <asp:Label ID="lblCompany" runat="server" Font-Size="12px" Text='<%# Eval("strCompany") %>'></asp:Label></span>
                                    </div>
                                </li>
                            </ul>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <div>
                               <ul>
                                   <li>
                                       Placement Papers
                                   </li>
                                   <li>
                                       Company Name
                                   </li>
                               </ul>
                            </div>
                        </HeaderTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle HorizontalAlign="Right" BorderColor="White" BorderWidth="0px" CssClass="pagelinks"></PagerStyle>
            </asp:GridView>
        </div>
    </div>
</div>

