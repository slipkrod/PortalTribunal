<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_CambiaPwd.aspx.vb" Inherits="Portalv9.Wfrm_Admin_CambiaPwd" MasterPageFile="~/MasterPages/1.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
<asp:Label ID="lbltitulo" runat="server" Text="Cambio de Contraseña" > </asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 50px;
        }
        .style2
        {
            width: 251px;
        }
        .style6
        {
            width: 100px;
        }
    </style>

    <script type="text/javascript" language="javascript" src="Scripts/md5.js" id="clientEventHandlersJSX"></script>
    <script type="text/javascript" language="javascript" id="clientEventHandlersJS" >

       function Form1_onsubmit() {
       
          
	        if (document.forms[0].elements['txtPwdNuevo1'].value != document.forms[0].elements['txtPwdNuevo2'].value) {
		        alert("La nueva contraseña deberá coincidir en ambos campos de captura");
		        document.forms[0].elements['txtPwdNuevo1'].value='';
		        document.forms[0].elements['txtPwdNuevo2'].value='';
		        document.forms[0].elements['txtPwdNuevoMD5'].value='';
		        return false;
	        }
	        
	        if (!ValidaReglaPwd(document.forms[0].elements['txtPwdNuevo1'].value)) {
		        document.forms[0].elements['txtPwdNuevo1'].value='';
		        document.forms[0].elements['txtPwdNuevo2'].value='';
		        document.forms[0].elements['txtPwdNuevoMD5'].value='';
		        return false;
	        }
	        
	        if (!ValidaCarRepetidos(document.forms[0].elements['txtPwdNuevo1'].value)) {
	            n=NumCarCons();
	            alert("La contraseña no puede tener un caracter mas de " + n + " veces consecutivas");
		        document.forms[0].elements['txtPwdNuevo1'].value='';
		        document.forms[0].elements['txtPwdNuevo2'].value='';
		        document.forms[0].elements['txtPwdNuevoMD5'].value='';
		        return false;
	        }
	
	        if (!ValidaCarIguales(document.forms[0].elements['txtPwdNuevo1'].value)) {
	            n=NumCarIguales();
	            alert("La contraseña no puede tener un caracter mas de " + n + " veces iguales");
		        document.forms[0].elements['txtPwdNuevo1'].value='';
		        document.forms[0].elements['txtPwdNuevo2'].value='';
		        document.forms[0].elements['txtPwdNuevoMD5'].value='';
		        return false;
	        }
	        document.forms[0].elements['txtPwdMD5'].value=hex_md5(document.forms[0].elements['txtPwd'].value);
	        document.forms[0].elements['txtPwdNuevoMD5'].value=hex_md5(document.forms[0].elements['txtPwdNuevo1'].value);
	        document.forms[0].elements['txtPwdNuevo1'].value='';
	        document.forms[0].elements['txtPwdNuevo2'].value='';
	        return true;
        }
    </script>
     <link rel="stylesheet" type="text/css" href="css/Grids.css">    
    <asp:Panel ID="Panel1" runat="server" >
   		<table style="LEFT: 2px; TOP: 2px; " cellspacing="0" cellPadding="0" border="0">
			<tr>
                
				<td vAlign="top" align="left" width="*">
                  <table id="Table4" style="WIDTH: HEIGHT: 232px" cellSpacing="0" cellPadding="0"	border="0"  >
	                <TR align="left" valign="top">
	                   <td class="style9">
			                 <br/>
                             <br/>
			                 <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="34px" Font-Names="Arial"  Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
		                </td>
	                </TR>
	                <TR vAlign="top" align="left" >
			                <TD class="style9">
				                <TABLE class="tan-border" id="Table3" style="WIDTH: 456px; HEIGHT: 166px" cellSpacing="0"
					                cellPadding="0" width="456" border="0">
					                <TR valign="middle">
						                <TD valign="middle">
							                <TABLE id="Table1" cellSpacing="0" cellPadding="0" align="center" border="0">
								                <TR>
									                <TD style="WIDTH: 180px" align="right">
                                                        <asp:label id="Label1" runat="server">Id. de Usuario</asp:label></TD>
									                <TD align="left" class="style2">
                                                        <asp:textbox id="txtUsrID" runat="server" 
                            Width="221px" ReadOnly="True" TabIndex="1"></asp:textbox>
									                <asp:RequiredFieldValidator ID="rfvUsuario" 
                            runat="server" ControlToValidate="txtUsrID" ErrorMessage="*" 
                            Font-Size="XX-Small"></asp:RequiredFieldValidator></TD>
								                </TR>
								                <TR>
									                <TD style="WIDTH: 180px" align="right">
                                                        <asp:label id="Label2" runat="server">Contraseña actual</asp:label></TD>
									                <TD align="left" class="style2">
                                                        <INPUT language="javascript" id="txtPwd" 
                            style="WIDTH: 221px; HEIGHT: 22px" tabIndex="2"
											                type="password" size="31" name="txtPwd"  onkeydown="if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('ctl00$ContentPlaceHolder1$btnActualizar').click();return false;}} else {return true};">
									                </TD>
								                </TR>
								                <TR>
									                <TD style="WIDTH: 180px" align="right">
                                                        <asp:label id="Label3" runat="server">Nueva contraseña</asp:label></TD>
									                <TD align="left" class="style2">
                                                        <INPUT language="javascript" id="txtPwdNuevo1" 
                            style="WIDTH: 221px; HEIGHT: 22px" tabIndex="3"
											                type="password" size="31" name="txtPwdNuevo1" onkeydown="if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('ctl00$ContentPlaceHolder1$btnActualizar').click();return false;}} else {return true};">
									                </TD>
								                </TR>
								                <TR>
									                <TD style="WIDTH: 180px" align="right">
                                                        <asp:label id="Label4" runat="server">Repetir nueva 
                                                        contraseña</asp:label></TD>
									                <TD align="left" class="style2">
                                                        <INPUT language="javascript" id="txtPwdNuevo2" 
                            style="WIDTH: 221px; HEIGHT: 22px" tabIndex="4"
											                type="password" size="31" name="txtPwdNuevo2" onkeydown="if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('ctl00$ContentPlaceHolder1$btnActualizar').click();return false;}} else {return true};">
									                </TD>
								                </TR>
								                <TR>
									                <TD style="HEIGHT: 35px" align="center" colSpan="2">
									                <asp:button id="btnActualizar" tabIndex="5" 
                            runat="server" Text="Actualizar" OnClientClick="return Form1_onsubmit();" ></asp:button></TD>
								                </TR>
								                <TR>
									                <TD style="WIDTH: 180px" align="right">
                                                        <INPUT language="javascript" id="txtPwdMD5" style="WIDTH: 104px; HEIGHT: 22px" type="hidden"
											                size="12" name="txtPwdMD5">&nbsp;
									                </TD>
									                <TD style="color: #FF0000;" align="right" 
                            class="style2">
                                                        <INPUT language="javascript" id="txtPwdNuevoMD5" style="WIDTH: 104px; HEIGHT: 22px" type="hidden"
											                size="12" name="txtPwdNuevoMD5">*Requerido</TD>
								                </TR>
								                <TR>
									                <TD colSpan="2">&nbsp;<cc1:msgbox id="dlgBoxExcepciones" runat="server"></cc1:msgbox>
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
