<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="ReviewDetails.aspx.cs" Inherits="Review_Details" %>

<asp:Content ID="MetaContent" runat="server" ContentPlaceHolderID="head">
    <asp:Literal ID="ltl_metaTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaDesc" runat="server"></asp:Literal>
    <asp:Literal ID="ltl_metaKeys" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cp_left" runat="Server">
    <asp:ScriptManager ID="scrManager" runat="server">
    </asp:ScriptManager>
    <table width="100%" cellpadding="0px" cellspacing="0px" border="0px" align="left">
        <tr>
            <td align="left" class="bestplace_head">
                <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="justify" class="best_border">
                <span class="_reviewInstituteTitle">
                    <asp:Literal ID="ltl_Institute" runat="server"></asp:Literal>
                </span>
                <div class="clr_box"></div>
                <table width="100%" cellpadding="2px" cellspacing="2px" border="0px">
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_Details" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:HiddenField ID="hf_ReviewID" runat="server" />
                            <asp:Repeater ID="rpt_ReviewFactors" runat="server" OnItemDataBound="rpt_ReviewFactors_ItemDataBound">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hf_FactorID" runat="server" Value='<%# Eval("iID") %>' />
                                    <div class="_factorTitle">
                                        <%# Eval("strTitle") %>
                                    </div>
                                    <div style="clear: both">
                                    </div>
                                    <asp:Repeater ID="rpt_Ratings" runat="server">
                                        <ItemTemplate>
                                            <div>
                                                <div class="_factor">
                                                    <%# Eval("strFactor")%>
                                                </div>
                                                <div>
                                                    <asp:Rating ID="rt_Rate" runat="server" CurrentRating='<%# Eval("iFactorValue")%>'
                                                        StarCssClass="StarCss" FilledStarCssClass="FilledStarCss" EmptyStarCssClass="EmptyStarCss"
                                                        WaitingStarCssClass="WaitingStarCss" Enabled="false">
                                                    </asp:Rating>
                                                </div>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
                <div class="clr_box">&nbsp;</div>
                <asp:Literal ID="ltl_PostedBy" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="bottom">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
