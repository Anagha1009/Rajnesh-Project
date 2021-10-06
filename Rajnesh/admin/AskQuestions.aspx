<%@ Page Title="Admin :: Question List" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="AskQuestions.aspx.cs" Inherits="admin_AskQuestions" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <br />
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <br />
    <table align="center" width="100%" border="0">
        <tr>
            <td align="left" colspan="4">
                <table>
                    <tr>
                        <td style="width: 90%">
                            <asp:Label ID="Label3" CssClass="font_title_text" runat="server" Text="Q&nbsp;U&nbsp;E&nbsp;S&nbsp;T&nbsp;I&nbsp;O&nbsp;N&nbsp;&nbsp;&nbsp;&nbsp;L&nbsp;I&nbsp;S&nbsp;T"></asp:Label>
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                </table>
                <hr />
            </td>
        </tr>
        <tr>
            <td width="550px">
                <table width="100%">
                    <tr>
                        <td width="120px">
                            Search Question
                        </td>
                        <td>
                            :
                        </td>
                        <td width="280px">
                            <asp:TextBox ID="txtSearch" runat="server" Width="270px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="Search" Width="110px"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:GridView ID="grdUserMaster" runat="server" Width="100%" AllowPaging="True" PageSize="10" AutoGenerateColumns="False" EmptyDataText="No Records Found" EmptyDataRowStyle-ForeColor="red"
                    EmptyDataRowStyle-HorizontalAlign="Center" AlternatingRowStyle-BackColor="#F7F7F7"
                    CellPadding="4" DataKeyNames="iID" RowStyle-HorizontalAlign="Left" CaptionAlign="Left"
                    OnPageIndexChanging="grdUserMaster_PageIndexChanging" OnRowDeleting="grdUserMaster_RowDeleting" OnRowDataBound="grdUserMaster_RowDataBound">
                    <HeaderStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfldId" runat="server" Value='<%#Eval("iID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="strQuestion" HeaderText="Question">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbl_Date" Text='<% #Eval("dtDate","{0:MMMM dd, yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answers" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlkDetails" runat="server" Text="View" NavigateUrl='<%# "viewAnswers.aspx?QID=" + Eval("iID")  %>'>
                                </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answer Now" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlAnsNow" runat="server" Text="Answer Now" NavigateUrl='<%# "AnswerNow.aspx?QID=" + Eval("iID")  %>'>
                                </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <a href='<%# "EditQuestion.aspx?QuestionId=" + Eval("iID") %>'><img src="images/edit.jpg" alt=""/></a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" />
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                    ImageUrl="~/Admin/images/cross.gif" OnClientClick='return confirm("Are you sure you want to delete this item?");' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Left" />
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
