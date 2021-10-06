<%@ Page Title="Control Panel | TeamMember" Language="C#" MasterPageFile="~/admin/Master.master"
    AutoEventWireup="true" CodeFile="TeamMembers.aspx.cs" Inherits="admin_TeamMember" MaintainScrollPositionOnPostback="true"
    ValidateRequest="false" %>

<%@ Register TagName="errorMssg" Src="~/admin/errorUserControl.ascx" TagPrefix="yo" %>
<%@ Register TagName="infoMssg" Src="~/admin/infoUserControl.ascx" TagPrefix="yo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="Server">
    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>
    <yo:errorMssg ID="error" runat="server" Visible="false" />
    <yo:infoMssg ID="info" runat="server" Visible="false" />
    <table width="95%" border="0" align="center">
        <tr>
            <td align="left">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td width="90px">
                            Keywords :
                        </td>
                        <td width="290px">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="txtBox">
                            </asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:ImageButton ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                CausesValidation="false" ImageUrl="~/admin/images/Search.png" BackColor="White" />
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
            <td align="left">
                <asp:GridView ID="grd_Records" runat="server" Width="100%" GridLines="None" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                    EmptyDataRowStyle-ForeColor="red" EmptyDataRowStyle-HorizontalAlign="Center"
                    CssClass="tableMain" CellPadding="1" CellSpacing="1" DataKeyNames="iID" OnRowDeleting="grd_Records_RowDeleting"
                    OnSelectedIndexChanged="grd_Records_SelectedIndexChanged" OnSorting="grd_Records_Sorting"
                    OnPageIndexChanging="grd_Records_PageIndexChanging" PageSize="25">
                    <HeaderStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red"></EmptyDataRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.&nbsp;No.">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
						<asp:TemplateField HeaderText="Photo">
							<ItemStyle HorizontalAlign="Center" Width="10%" />
							<ItemTemplate>
								<img src='<%# "../files/TeamMember/" + Eval("strPhoto") %>' alt="" class="photo" />
							</ItemTemplate>
						</asp:TemplateField>

						<asp:BoundField DataField="strName" HeaderText="Name" SortExpression="strName"><ItemStyle HorizontalAlign="center" /></asp:BoundField>

                        <asp:CommandField ButtonType="Image" HeaderText="Edit" CausesValidation="false" SelectImageUrl="~/admin/images/edit_1.png"
                            ControlStyle-CssClass="_edit" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    ImageUrl="~/Admin/images/delete.png" BackColor="Transparent" OnClientClick='return confirm("Are you sure you want to delete this entry?");' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BackColor="#F7F7F7"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <yo:infoMssg ID="info_dv" runat="server" Visible="false" />
    <yo:errorMssg ID="error_dv" runat="server" Visible="false" />
    <br />
    <table width="95%" align="center">
        <tr>
            <td align="left" class="font_title_text">
                TeamMember Details
            </td>
        </tr>
        <tr>
            <td>
                <div id="ScrollHere">
                </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a valid value in the following fields:">
                </asp:ValidationSummary>
                <br />
                <asp:DetailsView ID="dv_Records" runat="server" AutoGenerateRows="False" DataKeyNames="iID"
                    Width="95%" GridLines="None" CellPadding="3" CellSpacing="3" OnItemInserting="dv_Records_ItemInserting"
                    OnItemUpdating="dv_Records_ItemUpdating" OnModeChanging="dv_Records_ModeChanging">
                    <Fields>
                        <asp:TemplateField ShowHeader="false">
                            <InsertItemTemplate>
                                <table width="100%" cellpadding="3px" cellspacing="3px" border="0px">
                                    
									<tr>
										<td align="left" class="subTitle">
											Name
										</td>
										<td align="left">
											<asp:textbox ID="txtName" runat="server" CssClass="txtbox"></asp:textbox>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											Designation
										</td>
										<td align="left">
											<asp:textbox ID="txtDesignation" runat="server" CssClass="txtbox"></asp:textbox>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											Details
										</td>
										<td align="left">
											<asp:textbox ID="txtDetails" runat="server" TextMode="MultiLine" CssClass="ckeditor"></asp:textbox>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											Facebook
										</td>
										<td align="left">
											<asp:textbox ID="txtFacebook" runat="server" CssClass="txtbox"></asp:textbox>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											Twitter
										</td>
										<td align="left">
											<asp:textbox ID="txtTwitter" runat="server" CssClass="txtbox"></asp:textbox>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											LinkedIn
										</td>
										<td align="left">
											<asp:textbox ID="txtLinkedIn" runat="server" CssClass="txtbox"></asp:textbox>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											GooglePlus
										</td>
										<td align="left">
											<asp:textbox ID="txtGooglePlus" runat="server" CssClass="txtbox"></asp:textbox>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											Photo
										</td>
										<td align="left">
											<asp:fileupload ID="fu_Photo" runat="server" />
										</td>
									</tr>

                                </table>
                            </InsertItemTemplate>
                            <EditItemTemplate>
                                <table width="100%" cellpadding="3px" cellspacing="3px" border="0px">
                                    
									<tr>
										<td align="left" class="subTitle">
											Name
										</td>
										<td align="left">
											<asp:textbox ID="txtName" runat="server" CssClass="txtbox" Text='<%# Eval("strName") %>'></asp:textbox>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											Designation
										</td>
										<td align="left">
											<asp:textbox ID="txtDesignation" runat="server" CssClass="txtbox" Text='<%# Eval("strDesignation") %>'></asp:textbox>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											Details
										</td>
										<td align="left">
											<asp:textbox ID="txtDetails" runat="server" TextMode="MultiLine" CssClass="ckeditor" Text='<%# Eval("strDetails") %>'></asp:textbox>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											Facebook
										</td>
										<td align="left">
											<asp:textbox ID="txtFacebook" runat="server" CssClass="txtbox" Text='<%# Eval("strFacebook") %>'></asp:textbox>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											Twitter
										</td>
										<td align="left">
											<asp:textbox ID="txtTwitter" runat="server" CssClass="txtbox" Text='<%# Eval("strTwitter") %>'></asp:textbox>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											LinkedIn
										</td>
										<td align="left">
											<asp:textbox ID="txtLinkedIn" runat="server" CssClass="txtbox" Text='<%# Eval("strLinkedIn") %>'></asp:textbox>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											GooglePlus
										</td>
										<td align="left">
											<asp:textbox ID="txtGooglePlus" runat="server" CssClass="txtbox" Text='<%# Eval("strGooglePlus") %>'></asp:textbox>
										</td>
									</tr>

									<tr>
										<td align="left" valign="top" class="subTitle">
											Photo
										</td>
										<td align="left" valign="top">
											<table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
												<tr>
													<td align="left" valign="top" class="_photo_box">
														<img src='<%# VirtualPathUtility.ToAbsolute("~/files/TeamMember/" + Eval("strPhoto"))%>' alt="" />
													</td>
												</tr>
												<tr>
													<td align="left" valign="top">
														<asp:fileupload ID="fu_Photo" runat="server"/>
														<asp:hiddenfield ID="hf_Photo" runat="server" value='<%# Eval("strPhoto") %>' />
													</td>
												</tr>
											</table>
										</td>
									</tr>

                                </table>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <table width="100%" cellpadding="3px" cellspacing="3px" border="0px">
                                    
									<tr>
										<td align="left" class="subTitle">
											Name
										</td>
										<td align="left">
											<%# Eval("strName") %>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											Designation
										</td>
										<td align="left">
											<%# Eval("strDesignation") %>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											Details
										</td>
										<td align="left">
											<%# Eval("strDetails") %>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											Facebook
										</td>
										<td align="left">
											<%# Eval("strFacebook") %>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											Twitter
										</td>
										<td align="left">
											<%# Eval("strTwitter") %>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											LinkedIn
										</td>
										<td align="left">
											<%# Eval("strLinkedIn") %>
										</td>
									</tr>

									<tr>
										<td align="left" class="subTitle">
											GooglePlus
										</td>
										<td align="left">
											<%# Eval("strGooglePlus") %>
										</td>
									</tr>

									<tr>
										<td align="left" valign="top" class="subTitle">
											Photo
										</td>
										<td align="left" valign="top">
											<div class="_photo_box">
												<img src='<%# VirtualPathUtility.ToAbsolute("~/files/TeamMember/" + Eval("strPhoto"))%>' alt="" />
											</div>
										</td>
									</tr>

                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" ControlStyle-CssClass="btn" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
