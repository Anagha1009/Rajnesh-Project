<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Education_Help" %>

<%@ Register Src="~/UserControls/info.ascx" TagName="Info" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/error.ascx" TagName="Error" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="https://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Eduvidya.com Initiative for Online Education Help</title>
    <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="js/jquery.easing.1.3.js" type="text/javascript"></script>
    <script type="text/javascript">
        function fn_displayLogin() {
            var tar = $('#Contain9ner');
            tar.fadeIn().animate({ top: $(window).height() / 2 - tar.outerHeight() / 2 }, { duration: 1001, queue: false, easing: 'easeOutBounce' }, function () { });
        }
    </script>
    <link href='https://fonts.googleapis.com/css?family=Joti+One' rel='stylesheet' type='text/css' />
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 40 && charCode != 41 && charCode != 43 && charCode != 45 && charCode > 32 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scrManager" runat="server">
    </asp:ScriptManager>
    <table width="100%" cellpadding="0px" cellspacing="0px" border="0px" align="center">
        <tr>
            <td align="right" class="topPatti">
                Welcome Admin!&nbsp;&nbsp;|&nbsp;&nbsp;<asp:LinkButton ID="btn_LogOut" runat="server"
                    Text="Log Off" CssClass="LogOff" OnClick="btn_LogOut_Click"></asp:LinkButton>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-left: 20px">
                <table width="100%" cellpadding="0px" cellspacing="0px" border="0px" id="Container">
                    <tr>
                        <td align="left" valign="top" width="270px">
                            <div class="logo">
                                <a href="https://www.eduvidya.com">
                                    <img src="img/EducationHelp.png" alt="Education-help" width="110px" />
                                    EduVidya.com</a> <span class="tagline">HelpDesk!</span>
                            </div>
                        </td>
                        <td align="left" valign="top">
                            <div id="mainContent" runat="server">
                                <asp:Info ID="info1" runat="server" />
                                <asp:Error ID="error1" runat="server" />
                                <br />
                                <asp:UpdatePanel ID="up_EducationLeads" runat="server">
                                    <ContentTemplate>
                                        <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                            <tr>
                                                <td align="left" style="border-bottom: 1px dashed #ccc">
                                                    <table cellpadding="5px" cellspacing="5px" border="0px">
                                                        <tr>
                                                            <td align="center">
                                                                Type
                                                            </td>
                                                            <td align="center">
                                                                Institution
                                                            </td>
                                                            <td align="center">
                                                                Education Interest
                                                            </td>
                                                            <td align="center">
                                                                City
                                                            </td>
                                                            <td align="center">
                                                                From Date
                                                            </td>
                                                            <td align="center">
                                                                To Date
                                                            </td>
                                                            <td align="center">
                                                                Name/Email/Phone
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddl_Type" runat="server" CssClass="ddlbox" Width="140px" OnSelectedIndexChanged="ddl_Type_SelectedIndexChanged"
                                                                    AutoPostBack="true">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Institute" Value="Institute"></asp:ListItem>
                                                                    <asp:ListItem Text="Schools" Value="Schools"></asp:ListItem>
                                                                    <asp:ListItem Text="University" Value="University"></asp:ListItem>
                                                                    <asp:ListItem Text="DistanceUniversity" Value="DistanceUniversity"></asp:ListItem>
                                                                    <asp:ListItem Text="DistanceCollege" Value="DistanceCollege"></asp:ListItem>
                                                                    <asp:ListItem Text="InstitueCourses" Value="InstitueCourses"></asp:ListItem>
                                                                    <asp:ListItem Text="UniversityCourses" Value="UniversityCourses"></asp:ListItem>
                                                                    <asp:ListItem Text="DistanceUniversityCourses" Value="DistanceUniversityCourses"></asp:ListItem>
                                                                    <asp:ListItem Text="Exam" Value="Exam"></asp:ListItem>
                                                                    <asp:ListItem Text="Links" Value="Links"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddl_Institution" runat="server" CssClass="ddlbox" Width="140px">
                                                                    <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddl_EducationInterest" runat="server" CssClass="ddlbox">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddl_City" runat="server" CssClass="ddlbox">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtbox" Width="81px"></asp:TextBox>
                                                                <asp:CalendarExtender ID="clFromDate" runat="server" TargetControlID="txtFromDate"
                                                                    Format="MM/dd/yyyy">
                                                                </asp:CalendarExtender>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtToDate" runat="server" CssClass="txtbox" Width="81px"></asp:TextBox>
                                                                <asp:CalendarExtender ID="clToDate" runat="server" TargetControlID="txtToDate" Format="MM/dd/yyyy">
                                                                </asp:CalendarExtender>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtKeys" runat="server" CssClass="txtbox"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/img/details.png" OnClick="btnSearch_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:GridView ID="grd_Records" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                                                        AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                                                        EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                                                        AlternatingRowStyle-BackColor="#F7F7F7" CellPadding="1" CellSpacing="1" DataKeyNames="iID"
                                                        OnRowDeleting="grd_Records_RowDeleting" OnSorting="grd_Records_Sorting" OnPageIndexChanging="grd_Records_PageIndexChanging"
                                                        OnSelectedIndexChanged="grd_Records_SelectedIndexChanged" PageSize="25">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="strFullName" HeaderText="Name" SortExpression="strFullName">
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="strEmail" HeaderText="Email" SortExpression="strEmail">
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="strMobileNo" HeaderText="MobileNo" SortExpression="strEmail">
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="dtRegDate" HeaderText="Date" SortExpression="dtRegDate">
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="strType" HeaderText="Lead Type" SortExpression="strType">
                                                                <ItemStyle HorizontalAlign="center" Width="221px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="strInstitutionName" HeaderText="Institution Name" SortExpression="strInstitutionName">
                                                                <ItemStyle HorizontalAlign="center" Width="221px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="strCity" HeaderText="City" SortExpression="strCity">
                                                                <ItemStyle HorizontalAlign="center" Width="221px" />
                                                            </asp:BoundField>
                                                            <asp:CommandField ButtonType="Image" HeaderText="Details" CausesValidation="false"
                                                                SelectImageUrl="~/img/details.png" ControlStyle-CssClass="_edit" ShowSelectButton="True">
                                                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                            </asp:CommandField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                                        ImageUrl="~/Admin/images/cross.gif" BackColor="Transparent" OnClientClick='return confirm("Are you sure you want to delete this entry?");' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <AlternatingRowStyle BackColor="#F7F7F7"></AlternatingRowStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr id="tr_details" runat="server">
                                                <td align="left">
                                                    <div id="ScrollHere">
                                                    </div>
                                                    <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                                        <tr>
                                                            <td align="left" colspan="3">
                                                                <h3>
                                                                    Education Lead Details</h3>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="170px">
                                                                <b>First Name</b>
                                                            </td>
                                                            <td width="10px">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_FirstName" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="170px">
                                                                <b>Last Name</b>
                                                            </td>
                                                            <td width="10px">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_LastName" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="170px">
                                                                <b>Email</b>
                                                            </td>
                                                            <td width="10px">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_Email" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="170px">
                                                                <b>Date of Birth</b>
                                                            </td>
                                                            <td width="10px">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_DoB" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="170px">
                                                                <b>Current Qualification</b>
                                                            </td>
                                                            <td width="10px">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_Qualification" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="170px">
                                                                <b>Education Interest</b>
                                                            </td>
                                                            <td width="10px">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_EducationInterest" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="170px">
                                                                <b>Lead Type</b>
                                                            </td>
                                                            <td width="10px">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_Type" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="170px">
                                                                <b>Institution Name</b>
                                                            </td>
                                                            <td width="10px">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_InstitutionName" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="170px">
                                                                <b>Mobile No</b>
                                                            </td>
                                                            <td width="10px">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_MobileNo" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="170px">
                                                                <b>City</b>
                                                            </td>
                                                            <td width="10px">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_City" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="170px">
                                                                <b>Education Loan?</b>
                                                            </td>
                                                            <td width="10px">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_EducationLoan" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="170px">
                                                                <b>Comments</b>
                                                            </td>
                                                            <td width="10px">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_Comments" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="170px">
                                                                <b>Ip Address</b>
                                                            </td>
                                                            <td width="10px">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_IpAddress" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="170px">
                                                                <b>Date</b>
                                                            </td>
                                                            <td width="10px">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Literal ID="ltl_Date" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div style="float: left; padding-left: 10px">
                                    <asp:Button ID="btnExport" runat="server" Text="Export To Excel" CssClass="btnSubmit"
                                        OnClick="btnExport_Click" />
                                </div>
                                <asp:UpdateProgress ID="up_Progress" runat="server" AssociatedUpdatePanelID="up_EducationLeads">
                                    <ProgressTemplate>
                                        <div id="Progress_Back">
                                        </div>
                                        <div id="Loader">
                                            <img src="img/loader_1.gif" alt="loading" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                            <div id="adminBox" runat="server">
                                <img src="img/Control-Panel.png" alt="Welcome Admin" /><br />
                                Welcome Admin!
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" class="footer">
                &copy;&nbsp;Copyrights | 2013 - 2014 | www.EduVidya.com
            </td>
        </tr>
    </table>
    <div id="Contain9ner">
        <span class="login_Info">
            <asp:Literal ID="ltl_Info" runat="server"></asp:Literal></span>
        <table width="100%" align="center" id="code_box" runat="server">
            <tr>
                <td align="left" colspan="3" class="loginHeader">
                    Please Login to Continue
                </td>
                <td rowspan="7" align="center" width="140px">
                    <img src="img/Key.png" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="71px" align="left" class="headings">
                    User
                </td>
                <td width="40px" align="left">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtUser" runat="server" CssClass="txtbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="71px" align="left" class="headings">
                    Password
                </td>
                <td width="40px" align="left">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="txtbox" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
                <td align="left">
                    <asp:Button ID="btn_Login" runat="server" Text="Login" OnClick="btn_Login_Click"
                        CssClass="btnSubmit" Style="padding: 7px 35px" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
