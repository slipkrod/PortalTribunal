<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_ReseteaPwd.aspx.vb" Inherits="Portalv9.Wfrm_ReseteaPwd" MasterPageFile="~/MasterPages/1.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <style type="text/css">
        .style1
        {
            height: 50px;
        }
    </style>

    <script type="text/javascript" language="javascript" src="Scripts/md5.js" id="clientEventHandlersJSX">
    </script>

    <script type="text/javascript" language="javascript" id="clientEventHandlersJS" >
        
        function Form1_onsubmit() {
        	
        	if (document.forms[0].elements['txtPwdNuevo1'].value != document.forms[0].elements['txtPwdNuevo2'].value) {
		        alert("La nueva contraseña deberá coincidir en ambos campos de captura");
		        document.forms[0].elements['txtPwdNuevo1'].value='';
		        document.forms[0].elements['txtPwdNuevo2'].value='';
		        document.forms[0].elements['txtPwdNuevoMD5'].value='';
		        return false;
	        }

	        document.forms[0].elements['txtPwdNuevoMD5'].value=hex_md5(document.forms[0].elements['txtPwdNuevo1'].value);
	        document.forms[0].elements['txtPwdNuevo1'].value='';
	        document.forms[0].elements['txtPwdNuevo2'].value='';
	        return true;
        }
                
    </script>

    <asp:Panel ID="Panel1" runat="server" >
 		<table style="LEFT: 2px; TOP: 2px;" cellspacing="0" cellPadding="0" border="0">
			<tr>
                <td style="WIDTH: 100px" vAlign="top" width="100" class="style10"></td>
				<td vAlign="top" align="left" width="*">
					<table cellspacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td class="style9">
							   <br/>
                               <br/>
							   <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="34px" Font-Names="Arial"  Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
							</td>
						</tr>
				        <TR vAlign="top" align="left">
					       <TD>
					     	<TABLE class="tan-border" id="Table3" style="WIDTH: 456px; HEIGHT: 166px" cellSpacing="0"
							cellPadding="0" width="456" border="0">
							<TR vAlign="middle">
								<TD vAlign="middle">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" align="center" border="0">
										<TR>
											<TD style="WIDTH: 180px" align="right">
                                                <asp:label id="Label1" runat="server">Id. de Usuario</asp:label></TD>
											<TD style="WIDTH: 222px" align="center">
                                                <asp:textbox id="txtUsrID" runat="server" 
                    Width="221px" TabIndex="1"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 180px" align="right">
                                                <asp:label id="Label3" runat="server">Nueva contraseña</asp:label></TD>
											<TD style="WIDTH: 222px" align="center">
                                                <INPUT language="javascript" id="txtPwdNuevo1" style="WIDTH: 221px; HEIGHT: 22px" tabIndex="2"
													type="password" size="31" name="txtPwdNuevo1" onkeydown="if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('ctl00$ContentPlaceHolder1$btnActualizar').click();return false;}} else {return true};" >
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 180px" align="right">
                                                <asp:label id="Label4" runat="server">Repetir nueva 
                                                contraseña</asp:label></TD>
											<TD style="WIDTH: 222px" align="center">
                                                <INPUT language="javascript" id="txtPwdNuevo2" style="WIDTH: 221px; HEIGHT: 22px" tabIndex="3"
													type="password" size="31" name="txtPwdNuevo2"  onkeydown="if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('ctl00$ContentPlaceHolder1$btnActualizar').click();return false;}} else {return true};">
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 402px; HEIGHT: 35px" align="center" colSpan="2"><asp:button id="btnActualizar" tabIndex="4" runat="server" Text="Actualizar" OnClientClick="return Form1_onsubmit();" ></asp:button></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 180px" align="right">&nbsp;
											</TD>
											<TD style="WIDTH: 222px" align="left">
                                                <INPUT language="javascript" id="txtPwdNuevoMD5" style="WIDTH: 104px; HEIGHT: 22px" 
													size="12" name="txtPwdNuevoMD5" type="hidden"  ></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 402px" colSpan="2">&nbsp;<cc1:msgbox id="dlgBoxExcepciones" runat="server"></cc1:msgbox>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					      </TD>
				         </TR>
			      </TABLE>
			    </td>
			   </tr> 
	</table> 		       
    </asp:Panel>

</asp:Content>
