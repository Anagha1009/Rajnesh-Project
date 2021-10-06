<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CompareBox.ascx.cs" Inherits="UserControls_WebUserControl2" %>
<%--<link href="https://www.eduvidya.com/InfiniteTrips/css/Compare.css" rel="stylesheet" type="text/css" />--%>

<asp:UpdatePanel ID="pnl_Update" runat="server">
    <ContentTemplate>
        <h4>You can Compare a Minimum of 2 and Maximum of 3 Colleges at a Time!</h4>
        <div>
            <asp:ValidationSummary ID="vsCompareBox" runat="server" ValidationGroup="vg_Compare_Institutes" HeaderText="You must Select atleast 2 Institutes to Compare : " CssClass="vs_Summary" />
        </div>
        <div class="course-type">
            <asp:DropDownList ID="ddl_InstCategory" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvInstituteCategory" InitialValue="0" runat="server" ErrorMessage="" Text="&nbsp;" Display="Dynamic"
                ControlToValidate="ddl_InstCategory" SetFocusOnError="true"
                ValidationGroup="vg_Compare_Institutes">&nbsp;</asp:RequiredFieldValidator>
        </div>
        <div class="height-10"></div>
        <ul class="filter">
            <li>
                <div class="college-location">
                    <asp:DropDownList ID="ddl_City1" runat="server" OnSelectedIndexChanged="ddl_City_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCity1" InitialValue="0" runat="server" ErrorMessage="" Text="&nbsp;" Display="Dynamic" ControlToValidate="ddl_City1" SetFocusOnError="true" ValidationGroup="vg_Compare_Institutes">&nbsp;</asp:RequiredFieldValidator>
                </div>
                <div class="height-10"></div>
                <div class="select-institute">
                    <asp:DropDownList ID="ddl_Institute1" runat="server">
                        <asp:ListItem Text="Select Institute"
                            Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvInstitute1"
                        InitialValue="0" runat="server" ErrorMessage=""
                        Text="&nbsp;" Display="Dynamic"
                        ControlToValidate="ddl_Institute1" SetFocusOnError="true"
                        ValidationGroup="vg_Compare_Institutes">&nbsp;</asp:RequiredFieldValidator>
                </div>
            </li>
            <li>
                <div class="college-location">
                    <asp:DropDownList ID="ddl_City2" runat="server"
                        OnSelectedIndexChanged="ddl_City_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCity2"
                        InitialValue="0" runat="server" ErrorMessage=""
                        Text="&nbsp;" Display="Dynamic"
                        ControlToValidate="ddl_City2" SetFocusOnError="true"
                        ValidationGroup="vg_Compare_Institutes">&nbsp;</asp:RequiredFieldValidator>
                </div>
                <div class="height-10"></div>
                <div class="select-institute">
                    <asp:DropDownList ID="ddl_Institute2" runat="server">
                        <asp:ListItem Text="Select Institute"
                            Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvInstitute2"
                        InitialValue="0" runat="server" ErrorMessage=""
                        Text="&nbsp;" Display="Dynamic"
                        ControlToValidate="ddl_Institute2" SetFocusOnError="true"
                        ValidationGroup="vg_Compare_Institutes">&nbsp;</asp:RequiredFieldValidator>
                </div>

            </li>
            <li>
                <div class="college-location">
                    <asp:DropDownList ID="ddl_City3" runat="server"
                        OnSelectedIndexChanged="ddl_City_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                <div class="height-10"></div>
                <div class="select-institute">
                    <asp:DropDownList ID="ddl_Institute3" runat="server">
                        <asp:ListItem Text="Select Institute"
                            Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>

            </li>

            <li>
                <div class="compare-now">
                    <%--   <asp:LinkButton ID="btn_Compare" runat="server" Text="Compare Now" CssClass="btnSubmit"
                        OnClick="btn_Compare_Click" ValidationGroup="vg_Compare_Institutes"></asp:LinkButton>--%>
                    <asp:Button ID="btnSubmit" runat="server"
                        ValidationGroup="vg_Compare_Institutes" Text="Compare Now"
                        CssClass="btnSubmit" OnClick="btn_Compare_Click" />
                </div>
            </li>
        </ul>
    </ContentTemplate>
</asp:UpdatePanel>



