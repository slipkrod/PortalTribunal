<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_Usuarios.aspx.vb" Inherits="Portalv9.Wfrm_Usuarios" MasterPageFile="~/MasterPages/1.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 19px;
        }
        .style2
        {
            width: 50px;
        }
        .style3
        {
            height: 25px;
            width: 210px;
        }
        .style4
        {
            width: 169px;
        }
        .style5
        {
            width: 117px;
        }
    </style>
    <link href="css/Grids.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="Scripts/md5.js" id="clientEventHandlersJSX">
    </script>    
    <script language="javascript" src="script.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" id="clientEventHandlersJS" >
        function Form1_onsubmit() {
            document.forms[0].elements['txtPwdMD5'].value = hex_md5(document.forms[0].elements['txtPwd'].value);
            document.forms[0].elements['txtPwd'].value = '';
            return true;
        }
    </script>
    <asp:Panel ID="Panel1" runat="server"> 
 		<table style="LEFT: 2px; TOP: 2px;" cellspacing="0" cellPadding="0" border="0">
			<tr>
                
				<td vAlign="top" align="left" width="*">
					<table cellspacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td class="style9" colspan=3>
							   <br/>
                               <br/>
							   <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="34px" Font-Names="Arial"  Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
							</td>
						</tr>
						<tr>
								<td class="style4">
									<asp:button id="btnAddNew" Font-Size="XX-Small" Width="144px" CssClass="Button" Runat="server"
											CausesValidation="False" Text="Agregar Nuevo Usuario"></asp:button>
                                        <input id="htmlHiddenSortExpression" runat="server" 
                                        name="htmlHiddenSortExpression" style="WIDTH: 155px; HEIGHT: 14px" 
                                        type="hidden" value="ApellidoP">
                                        <input id="hiddenNoIdentidad" runat="server" name="hiddenNoIdentidad" 
                                        size="9" style="WIDTH: 88px; HEIGHT: 14px" type="hidden"></input></input>
								</td>
							    <td class="style5">
                                    <asp:Label ID="lblBuscar" runat="server" Font-Names="Arial" 
                                        Font-Size="XX-Small" Width="113px">Buscar Usuario:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBuscar" runat="server" Font-Size="XX-Small" MaxLength="50" 
                                        tabIndex="14" Width="185px"></asp:TextBox>
                                    <asp:Button ID="btnBuscar" runat="server" tabIndex="15" Text="Buscar..." />
                                </td>
						</tr>
					</table>
					<asp:datagrid id="grdUser" runat="server" Width="605px" Height="64px" 
                            HorizontalAlign="Justify" AllowPaging="True" AutoGenerateColumns="False"
							AllowSorting="True" DataKeyField="UsrID" style="margin-bottom: 0px; margin-top: 10px;" CellPadding="4" 
                            GridLines="None" Font-Bold="False" 
                        Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                        Font-Underline="False">
							<SelectedItemStyle CssClass="SelectedItemStyle" ></SelectedItemStyle>
							<EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
							<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemStyle"></ItemStyle>
							<HeaderStyle CssClass="Encabezados"></HeaderStyle>
							<FooterStyle CssClass="FooterStyle"></FooterStyle>
							<Columns>
								<asp:ButtonColumn  Text="Editar" DataTextField="ApellidoP" SortExpression="ApellidoP" HeaderText="<span class='EncabezadosText'>Apellido P</span>"
									CommandName="Editar" ItemStyle-CssClass ="EncabezadosText" >
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="ApellidoP" SortExpression="ApellidoP"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApellidoM" SortExpression="ApellidoM" HeaderText="<span class='EncabezadosText'>Apellido M</span>"></asp:BoundColumn>
								<asp:BoundColumn DataField="Nombre" SortExpression="Nombre" HeaderText="<span class='EncabezadosText'>Nombre</span>"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="UsrID" SortExpression="UsrID" HeaderText="Login"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Pwd" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="FechaCreacionPwd"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Desactivado" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="IntentosFallidosConsec"></asp:BoundColumn>
								<asp:ButtonColumn Text="Editar" DataTextField="UsrID" SortExpression="Usrid" HeaderText="<span class='EncabezadosText'>Login</span>" CommandName="Editar"></asp:ButtonColumn>
								<asp:ButtonColumn Text="X" HeaderText="Eliminar" CommandName="Eliminar">
									<HeaderStyle HorizontalAlign="Center" CssClass="EncabezadosText"></HeaderStyle>
									<ItemStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Italic="True" Font-Bold="True"
										HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="NoIdentidad"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DebeCambiarPwd"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="GrupoAdminID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Email" HeaderText="Email"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DomicilioID" HeaderText="DomicilioID"></asp:BoundColumn>								
							</Columns>
							<PagerStyle CssClass="PagerStyle" PageButtonCount="15" Mode="NumericPages" ></PagerStyle>
						</asp:datagrid>
						<br />
						<asp:panel id="pnlFormUser" Font-Size="XX-Small" Width="605px" Height="360px" Font-Names="Arial Narrow"
							Runat="server" BorderWidth="1px" BorderStyle="Solid" ForeColor="Red" BorderColor="#7F9DB9" Visible="False">
                           <TABLE id="Table2" style="WIDTH: 600px; HEIGHT: 344px" cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD style="HEIGHT: 25px" vAlign="middle" colSpan="4">
                                        <FONT style="COLOR: #000099" face="Arial" size="2">&#160;Datos 
                                        del Usuario.</FONT>
									</TD>
								</TR>
								<TR style="WIDTH: 600px">
									<TD style="WIDTH: 90px; HEIGHT: 25px" vAlign="middle">
										<asp:Label id="Label1" runat="server" Font-Size="XX-Small" Width="90px" Font-Names="Arial">&nbsp;Nombre:</asp:Label></TD>
									<TD style="WIDTH: 510px" vAlign="middle" colSpan="3">
										<asp:TextBox id="txtNombre" tabIndex="1" runat="server" 
                                    Font-Size="XX-Small" Width="256px" MaxLength="50"></asp:TextBox>
										<asp:RequiredFieldValidator id="rfvNombre" runat="server" Font-Size="XX-Small" ErrorMessage="*" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
										<asp:RegularExpressionValidator id="revNombre" runat="server" Font-Size="XX-Small" ErrorMessage="No válido!!" ControlToValidate="txtNombre"
											ValidationExpression="^[a-zA-Z-_\s|á|é|í|ó|ú|Á|É|Í|Ó|Ú|ñ|Ñ]+$"></asp:RegularExpressionValidator></TD>
								</TR>
								<TR style="WIDTH: 600px">
									<TD style="WIDTH: 90px; HEIGHT: 25px" vAlign="middle">
										<asp:Label id="Label2" runat="server" Font-Size="XX-Small" Width="90px" Font-Names="Arial">&nbsp;Apellido Paterno:</asp:Label></TD>
									<TD vAlign="middle" class="style3">
										<asp:TextBox id="txtApellidoP" tabIndex="2" runat="server" Font-Size="XX-Small" Width="130px"
											MaxLength="50"></asp:TextBox><FONT face="Arial" size="1">
											<asp:RequiredFieldValidator id="rfvApellidoP" runat="server" Font-Size="XX-Small" ErrorMessage="*" ControlToValidate="txtApellidoP"></asp:RequiredFieldValidator>
											<asp:RegularExpressionValidator id="revApellidop" runat="server" Font-Size="XX-Small" Font-Names="Arial" ErrorMessage="No válido!!"
												ControlToValidate="txtApellidoP" ValidationExpression="^[a-zA-Z-_\s|á|é|í|ó|ú|Á|É|Í|Ó|Ú|ñ|Ñ]+$"></asp:RegularExpressionValidator></FONT></TD>
									<TD style="WIDTH: 90px; HEIGHT: 25px" vAlign="middle">
										<asp:Label id="Label3" runat="server" Font-Size="XX-Small" Width="90px" Font-Names="Arial">&nbsp;Apellido Materno:</asp:Label></TD>
									<TD style="WIDTH: 210px; HEIGHT: 25px" vAlign="middle">
										<asp:TextBox id="txtApellidoM" tabIndex="3" runat="server" Font-Size="XX-Small" Width="130px"
											MaxLength="50"></asp:TextBox><FONT face="Arial" size="1">
											<asp:RequiredFieldValidator id="rfvPwd" runat="server" Font-Size="XX-Small" ErrorMessage="*" ControlToValidate="txtApellidoM"></asp:RequiredFieldValidator>
											<asp:RegularExpressionValidator id="revApellidom" runat="server" Font-Size="XX-Small" ErrorMessage="No válido!!"
												ControlToValidate="txtApellidoM" ValidationExpression="^[a-zA-Z-_\s|á|é|í|ó|ú|Á|É|Í|Ó|Ú|ñ|Ñ]+$"></asp:RegularExpressionValidator></FONT></TD>
								</TR>
								<TR style="WIDTH: 600px">
									<TD style="WIDTH: 90px; HEIGHT: 25px" vAlign="middle">
										<asp:Label id="Label7" runat="server" Font-Size="XX-Small" Width="90px" Font-Names="Arial">&nbsp;Email:</asp:Label></TD>
									<TD style="WIDTH: 510px; HEIGHT: 25px" vAlign="middle" colSpan="3">
										<asp:TextBox id="txtEmail" tabIndex="4" runat="server" Font-Size="XX-Small" Width="256px" MaxLength="50"></asp:TextBox>
										<asp:RequiredFieldValidator id="rfvusr" runat="server" Font-Size="XX-Small" ErrorMessage="*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                        <font face="Arial" size="1">
											<asp:RegularExpressionValidator ID="revemai" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage="No válido!!" Font-Size="XX-Small" 
                                    ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"></asp:RegularExpressionValidator></font></TD>
								</TR>
								<TR style="WIDTH: 600px">
									<TD style="WIDTH: 90px; HEIGHT: 25px" vAlign="middle">
										<asp:Label id="Label4" runat="server" Font-Size="XX-Small" Width="90px" Font-Names="Arial">&nbsp;Login:</asp:Label></TD>
									<TD vAlign="middle" class="style3">
										<asp:TextBox id="txtLogin" tabIndex="6" runat="server" Font-Size="XX-Small" Width="130px" MaxLength="50"></asp:TextBox>
                                        <font face="Arial" size="1">
											<asp:RequiredFieldValidator ID="rfvusrid" runat="server" 
                                    ControlToValidate="txtLogin" ErrorMessage="*" Font-Size="XX-Small"></asp:RequiredFieldValidator>
											<asp:RegularExpressionValidator ID="revEmail" runat="server" 
                                    ControlToValidate="txtLogin" ErrorMessage="No válido!!" Font-Size="XX-Small" 
                                    ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator></font></TD>
									<TD style="WIDTH: 90px; HEIGHT: 25px" vAlign="middle">
										<asp:Label id="LabelPwd" runat="server" Font-Size="XX-Small" Width="90px" Font-Names="Arial">&nbsp;Password:</asp:Label></TD>
									<TD style="WIDTH: 210px; HEIGHT: 25px" vAlign="middle">
                                        <font face="Arial" size="1">
											<asp:TextBox ID="txtPwd" runat="server" Font-Size="XX-Small" 
                                    tabIndex="7" textMode="Password" Width="130px"></asp:TextBox>
											<asp:RequiredFieldValidator ID="rfvpwd1" runat="server" 
                                    ControlToValidate="txtPwd" ErrorMessage="*" Font-Size="XX-Small"></asp:RequiredFieldValidator></font></TD>
								</TR>
								<TR style="WIDTH: 600px">
									<TD style="HEIGHT: 25px" vAlign="middle" colSpan="2">
                                        &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
										<asp:CheckBox id="CheckDeshabilitar" tabIndex="8" runat="server" Font-Size="XX-Small" Font-Names="Arial"
											Text="Deshabilitar acceso"></asp:CheckBox></TD>
									<TD style="WIDTH: 300px; HEIGHT: 25px" vAlign="middle" colSpan="2">
										<asp:CheckBox id="CheckChangePwd" tabIndex="9" runat="server" Font-Size="XX-Small" Font-Names="Arial"
											Text="Debe cambiar el password"></asp:CheckBox></TD>
								</TR>
								<TR style="WIDTH: 600px">
									<TD style="WIDTH: 90px; HEIGHT: 25px" vAlign="middle">
										<asp:Label id="Label5" runat="server" Font-Size="XX-Small" Width="90px" Font-Names="Arial">&nbsp;Grupo:</asp:Label></TD>
									<TD style="WIDTH: 510px; HEIGHT: 25px" vAlign="middle" colSpan="3">
										<asp:DropDownList id="DropGrupoAdmin" tabIndex="10" runat="server" Font-Size="XX-Small" Width="256px"
											Font-Names="Arial"></asp:DropDownList>
                                        <font face="Arial" size="1">
											<asp:RequiredFieldValidator ID="rfvgrupoid" runat="server" 
                                    ControlToValidate="DropGrupoAdmin" ErrorMessage="*" Font-Size="XX-Small"></asp:RequiredFieldValidator>&#160;&#160;
											<input id="txtPwdMD5" language="javascript" name="txtPwdMD5" 
                                    size="16" style="WIDTH: 128px; HEIGHT: 22px" type="hidden"> </input></input></font>
									</TD>
								</TR>
								<TR style="WIDTH: 600px">
									<TD style="WIDTH: 90px; HEIGHT: 25px" vAlign="top">
										<asp:Label id="Label6" runat="server" Font-Size="XX-Small" Width="90px" Font-Names="Arial">&nbsp;Perfiles:</asp:Label></TD>
									<TD style="WIDTH: 510px; HEIGHT: 100px" vAlign="middle" colSpan="3">
									<asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" 
                                    BorderWidth="1px" Height="98px" ScrollBars="Vertical" Width="440px" 
                                    BorderColor="Silver">
                                            <asp:CheckBoxList ID="ListPerfil" runat="server" CellPadding="0" 
                                                CellSpacing="0" TabIndex="11">
                                            </asp:CheckBoxList>
                                        </asp:Panel>									
                                        </TD>
								</TR>
								<TR style="WIDTH: 600px">
									<TD style="WIDTH: 600px; HEIGHT: 30px" vAlign="middle" align="left" 
                                    colSpan="4">
										<asp:Table ID="tblCampos" runat="server" HorizontalAlign="Left">
                                            <asp:TableRow ID="TableRow1" runat="server">
                                                <asp:TableCell ID="TableCell1" runat="server"></asp:TableCell>
                                                <asp:TableCell ID="TableCell2" runat="server"></asp:TableCell>
                                                <asp:TableCell ID="TableCell3" runat="server"></asp:TableCell>
                                                <asp:TableCell runat="server"></asp:TableCell>
                                                <asp:TableCell runat="server"></asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </TD>
								</TR>
							    <tr style="WIDTH: 600px">
                                    <td align="center" colspan="4" style="WIDTH: 600px; HEIGHT: 30px" 
                                        valign="middle">
                                        <asp:Button ID="btnSave" runat="server" tabIndex="12" Text="Salvar Cambios" 
                                            Height="26px" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" 
                                            tabIndex="13" Text="Cancelar" />
                                    </td>
                                </tr>
							</TABLE>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;* 
         
                            Requerido</asp:panel>
                        <br />
                        <br />
                        <cc1:msgbox id="MsgBox1" runat="server"></cc1:msgbox>
                      </td>
			</tr>
			<tr>
			<td colspan=2>
				<asp:HiddenField ID="HiddenField1" runat="server" />
				<asp:HiddenField ID="HiddenField2" runat="server" />
				<asp:HiddenField ID="HiddenField3" runat="server" />
				<asp:HiddenField ID="HiddenField4" runat="server" />
				<asp:HiddenField ID="HiddenField5" runat="server" />
				<asp:HiddenField ID="HiddenField7" runat="server" />
				<asp:HiddenField ID="HiddenField8" runat="server" />
				<asp:HiddenField ID="HiddenField9" runat="server" />
				<asp:HiddenField ID="HiddenField10" runat="server" />
				<asp:HiddenField ID="HiddenField11" runat="server" />
			 </td>
			</tr> 
		 </table>
	</asp:panel>
</asp:Content>
