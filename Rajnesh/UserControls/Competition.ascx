<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Competition.ascx.cs" Inherits="UserControls_Register" %>
<script type="text/javascript">
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode != 40 && charCode != 41 && charCode != 43 && charCode != 45 && charCode > 32 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }

    function fn_getPopup() {
        $('#Competition_Box').reveal($(this).data());
    }
</script>
<link href='https://fonts.googleapis.com/css?family=Joti+One' rel='stylesheet' type='text/css' />
<link href="https://www.eduvidya.com/css/Competition_Styles.css" rel="stylesheet" type="text/css" />
<table cellpadding="0px" cellspacing="0px" border="0px">
    <tr>
        <td align="left" id="Compete_Box">
            <asp:UpdatePanel ID="pnl_Compete" runat="server">
                <ContentTemplate>
                    <a href="javascript:void(0)" data-reveal-id="Competition_Box"  class="iClick">
                       <div>
                                <div  class="_Compete_title">
                                    <b>
                                        <asp:Literal ID="ltl_Title" runat="server"></asp:Literal></b>
                                </div>
                            
                                <div >
                                    <asp:Literal ID="ltl_ShortDetails" runat="server"></asp:Literal>
                                </div>
                          
                                <div >
                                    <img id="img_Compete" runat="server" />
                                </div>
                            
                           </div> 

                    </a>
                    <div id="Competition_Box" class="reveal-modal xlarge">
                       <div> 
                           <div>
                                    <asp:Button ID="btn_FacebookConnect" runat="server" Text="Connect with Facebook"
                                        CssClass="btn_Compete" OnClick="btn_FacebookConnect_Click" />
                              </div>
                                    <asp:Button ID="btn_EmailConnect" runat="server" Text="Connect with Email" CssClass="btn_Compete"
                                        OnClick="btn_EmailConnect_Click" />
                              <div>
                                 
                                  
                                  <div id="tbl_Competition" runat="server">
                                    <div >
                                                <span class="_CompeteTitle">Please Enter your Name / Email Address to Continue..</span><br />
                                            </div>
       
                             <b>Name:</b>
             
                    <asp:TextBox ID="txtName" runat="server" CssClass="txtCompetition"></asp:TextBox>
                
                    <asp:RequiredFieldValidator ID="rfvCompeteName" ValidationGroup="vgCompetition" runat="server"
                        ErrorMessage="First Name" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtName">&nbsp;</asp:RequiredFieldValidator>
            
                    <b>Email:</b>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txtCompetition"></asp:TextBox>
                
                    <asp:RequiredFieldValidator ID="rfvCompeteEmail" ValidationGroup="vgCompetition"
                        runat="server" ErrorMessage="Email" SetFocusOnError="true" Display="Dynamic"
                        ControlToValidate="txtEmail">&nbsp;</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                            ID="revCompeteEmail" runat="server" ErrorMessage="Invalid E-mail ID" ControlToValidate="txtEmail"
                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="vgCompetition" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
              
                    <asp:LinkButton ID="btn_Submit" runat="server" Text="Continue" CssClass="btn_Compete"
                                                    OnClick="btn_Submit_Click" ValidationGroup="vgCompetition"></asp:LinkButton>
                                           </div>
                        <a class="close-reveal-modal">&#215;</a>
                           </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
