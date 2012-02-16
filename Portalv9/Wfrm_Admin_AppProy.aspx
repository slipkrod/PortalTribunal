<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_AppProy.aspx.vb" Inherits="Portalv9.Wfrm_AppProy" MasterPageFile="~/MasterPages/1.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript" language="javascript" id="clientEventHandlersJS" >
		function getconfirm() 
			{ 
			if (confirm("¿Seguro de querer eliminar este registro?")==true) 
				return true; 
			else 
				return false; 
			}
	</script>
     <link rel="stylesheet" type="text/css" href="css/Grids.css">
    <asp:Panel ID="Panel1" runat="server">
		<table style="LEFT: 2px; TOP: 2px;" cellspacing="0" cellPadding="0" border="0">
			<tr>
                
				<td vAlign="top" align="left" width="*">
					<table cellspacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td>
							 <br/>
                             <br/>
							 <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="34px" Font-Names="Arial"  Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
							</td>
						</tr>
						<tr>
							<td style="vertical-align: middle" class="style3">									
                                <asp:Button ID="btnAddNew" Runat="server" CausesValidation="False" 
                                Font-Size="XX-Small" Text="Agregar Nueva Conexión" 
                                Width="144px"></asp:Button>
                                <input id="htmlHiddenSortExpression" runat="server" 
                                name="htmlHiddenSortExpression" style="WIDTH: 155px; HEIGHT: 14px" 
                                type="hidden" value="aplicacionId"></input>
                                <input id="hiddenProy" runat="server" name="hiddenProy" size="9" 
                                style="WIDTH: 88px; HEIGHT: 14px" type="hidden"></input>
                                <input id="hiddenApli" runat="server" name="hiddenApli" size="9" style="WIDTH: 88px; HEIGHT: 14px" 
                                type="hidden"></input>
							</td>
						</tr>
					</table>
					<asp:datagrid id="grdAppProy" runat="server" Width="544px" Height="64px" 
                        HorizontalAlign="Justify" AllowPaging="True" AutoGenerateColumns="False"
						AllowSorting="True" DataKeyField="ProyectoID" PageSize="15" Font-Bold="False" 
                        Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                        Font-Underline="False" style="margin-left: 0px" CellPadding="4" 
                        GridLines="None" >
                        <SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
                        <EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
                        <AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
                        <ItemStyle CssClass="ItemStyle"></ItemStyle>
                        <HeaderStyle CssClass="Encabezados"></HeaderStyle>
                        <FooterStyle CssClass="FooterStyle"></FooterStyle>	
						<Columns>
							<asp:ButtonColumn Text="Editar" DataTextField="ProyectoID" SortExpression="ProyectoID" HeaderText="<span class='EncabezadosText'>ProyectoID</span>"	CommandName="Editar" >
							</asp:ButtonColumn>
							<asp:BoundColumn Visible="False" DataField="ProyectoID"></asp:BoundColumn>
							<asp:BoundColumn DataField="AplicacionID" SortExpression="AplicacionID"  HeaderText="<span class='EncabezadosText'>AplicacionID</span>">
							</asp:BoundColumn>
							<asp:BoundColumn DataField="UID_" SortExpression="UID_" HeaderText="<span class='EncabezadosText'>Usuario</span>" HeaderStyle-CssClass="EncabezadosText">
							</asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="PWD" HeaderStyle-CssClass="EncabezadosText"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="DSN" HeaderStyle-CssClass="EncabezadosText"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="Driver" ItemStyle-CssClass="EncabezadosText"  HeaderStyle-CssClass="EncabezadosText"></asp:BoundColumn>
							<asp:BoundColumn DataField="Server" SortExpression="Server" HeaderText="<span class='EncabezadosText'>Server</span>"></asp:BoundColumn>
							<asp:BoundColumn DataField="BDNombre" SortExpression="BDNombre" HeaderText="<span class='EncabezadosText'>BDNombre</span>" HeaderStyle-CssClass="EncabezadosText"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="Argumento" HeaderStyle-CssClass="EncabezadosText"></asp:BoundColumn>
							<asp:ButtonColumn Visible="True" Text="X" HeaderText="Eliminar" CommandName="Delete">
								<HeaderStyle CssClass="EncabezadosText" HorizontalAlign="Center"></HeaderStyle>
								<ItemStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Italic="True" Font-Bold="True" HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
							</asp:ButtonColumn>
						</Columns>
						<PagerStyle CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>
					</asp:datagrid>
					<asp:panel id="pnlFormAppProy" Font-Size="XX-Small" Width="548px" Height="244px" Font-Names="Arial Narrow" Runat="server" BorderWidth="1px" BorderStyle="Solid" ForeColor="Red" BorderColor="#7F9DB9" Visible="False">
                       <TABLE id="Table1" style="WIDTH: 541px; HEIGHT: 203px" cellspacing="0" cellPadding="0" border="0">
							<TR>
								<TD style="HEIGHT: 23px">
                                    <FONT style="COLOR: #000099" face="Arial" size="2">&nbsp;Datos 
										de Aplicación/Proyecto.</FONT>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 552px; HEIGHT: 5px" vAlign="top"><FONT face="Arial" size="1">&nbsp;&nbsp; 
										Proyecto:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:DropDownList id="ListaProy" runat="server" Font-Names="Arial" Width="360px" Font-Size="XX-Small"></asp:DropDownList>
										<asp:RequiredFieldValidator id="RrfvListaProy" runat="server" Font-Size="XX-Small" ControlToValidate="ListaProy"
											ErrorMessage="*"></asp:RequiredFieldValidator></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 552px; HEIGHT: 7px" vAlign="top"><FONT face="Arial" size="1">&nbsp;&nbsp; 
										Aplicación:&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:DropDownList id="ListaAplicacion" runat="server" Font-Names="Arial" Width="360px" Font-Size="XX-Small"></asp:DropDownList>
										<asp:RequiredFieldValidator id="rfvListAplicacion" runat="server" Font-Size="XX-Small" ControlToValidate="ListaAplicacion"
											ErrorMessage="*"></asp:RequiredFieldValidator>&nbsp;&nbsp; </FONT>
								</TD>
							</TR>
							<TR vAlign="top">
								<TD style="WIDTH: 551px; HEIGHT: 14px">
                                    <font face="Arial" size="1">&#160;&#160;Usuario:&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
										<asp:TextBox ID="txtUser" runat="server" Font-Size="XX-Small" 
                                MaxLength="50" Width="324px"></asp:TextBox>
                                    <font face="Arial" size="1">
										<asp:RegularExpressionValidator ID="revUSR" runat="server" 
                                ControlToValidate="txtUser" ErrorMessage="No válido!!" Font-Size="XX-Small" 
                                ValidationExpression="^[a-zA-Z-0-9_\s|]+$"></asp:RegularExpressionValidator></font></font></TD>
							</TR>
							<TR vAlign="top">
								<TD style="WIDTH: 551px; HEIGHT: 14px">
                                    <font face="Arial" size="1">&#160; 
										Contraseña: &#160;&#160;&#160;
										<asp:TextBox ID="txtPwd" runat="server" Font-Size="XX-Small" 
                                MaxLength="50" TextMode="Password" Visible="False" Width="324px"></asp:TextBox>
                                    <font face="Arial" size="1">
										<asp:RegularExpressionValidator ID="revPWD" runat="server" 
                                ControlToValidate="txtPwd" ErrorMessage="No válido!!" Font-Size="XX-Small" 
                                ValidationExpression="^[a-zA-Z-0-9_\s|]+$"></asp:RegularExpressionValidator></font></font></TD>
							</TR>
							<TR vAlign="top">
								<TD style="WIDTH: 551px; HEIGHT: 14px">
                                    <font face="Arial" size="1">&#160; 
										DNS:&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 
										&#160;&#160;&#160;
										<asp:TextBox ID="txtDSN" runat="server" Font-Size="XX-Small" 
                                MaxLength="50" Width="324px"></asp:TextBox>
                                    <font face="Arial" size="1">
										<asp:RegularExpressionValidator ID="revDSN" runat="server" 
                                ControlToValidate="txtDSN" ErrorMessage="No válido!!" Font-Size="XX-Small" 
                                ValidationExpression="^[a-zA-Z-0-9_\s|]+$"></asp:RegularExpressionValidator></font></font></TD>
							</TR>
							<TR vAlign="top">
								<TD style="WIDTH: 551px; HEIGHT: 14px">
                                    <font face="Arial" size="1">&#160; 
										Driver:&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 
										&#160;&#160;&#160;&#160;
										<asp:TextBox ID="txtDriver" runat="server" Font-Size="XX-Small" 
                                MaxLength="50" Width="324px"></asp:TextBox>
										<asp:RegularExpressionValidator ID="revDriver" runat="server" 
                                ControlToValidate="txtDriver" ErrorMessage="No válido!!" Font-Size="XX-Small" 
                                ValidationExpression="^[a-zA-Z-0-9_\s|]+$"></asp:RegularExpressionValidator></font></TD>
							</TR>
							<TR vAlign="top">
								<TD style="WIDTH: 551px; HEIGHT: 14px">
                                    <font face="Arial" size="1">&#160; 
										Servidor:&#160;&#160;&#160;&#160;&#160;&#160; &#160;&#160;
										<asp:TextBox ID="txtServidor" runat="server" Font-Size="XX-Small" 
                                MaxLength="50" Width="224px"></asp:TextBox>
										<asp:RequiredFieldValidator ID="rfvServidor" runat="server" 
                                ControlToValidate="txtServidor" ErrorMessage="*" Font-Size="XX-Small"></asp:RequiredFieldValidator>
										<asp:RegularExpressionValidator ID="revServer" runat="server" 
                                ControlToValidate="txtServidor" ErrorMessage="No válido!!" Font-Size="XX-Small" 
                                ValidationExpression="^[a-zA-Z-0-9_\s|]+$"></asp:RegularExpressionValidator></font></TD>
							</TR>
							<TR vAlign="top">
								<TD style="WIDTH: 551px; HEIGHT: 14px">
                                    <font face="Arial" size="1">&#160; 
										Base de Datos:
										<asp:TextBox ID="txtBD" runat="server" Font-Size="XX-Small" 
                                MaxLength="50" Width="225px" Height="16px"></asp:TextBox>
										<asp:RequiredFieldValidator ID="rfvBD" runat="server" 
                                ControlToValidate="txtBD" ErrorMessage="*" Font-Size="XX-Small"></asp:RequiredFieldValidator>
										<asp:RegularExpressionValidator ID="revBD" runat="server" 
                                ControlToValidate="txtBD" ErrorMessage="No válido!!" Font-Size="XX-Small" 
                                ValidationExpression="^[a-zA-Z-0-9_\s|]+$"></asp:RegularExpressionValidator></font></TD>
							</TR>
							<TR vAlign="top">
								<TD style="WIDTH: 551px; HEIGHT: 14px">
                                    <font face="Arial" size="1">&#160; 
										Argumento:&#160;&#160;&#160;&#160;&#160;
										<asp:TextBox ID="txtArgumento" runat="server" Font-Size="XX-Small" 
                                MaxLength="50" Width="24px"></asp:TextBox>
										<asp:RegularExpressionValidator ID="revArgumento" runat="server" 
                                ControlToValidate="txtArgumento" ErrorMessage="No válido!!" 
                                Font-Size="XX-Small" ValidationExpression="^[0-9\s|]+$"></asp:RegularExpressionValidator></font></TD>
							</TR>
							<TR vAlign="middle" align="center">
								<TD vAlign="middle" align="center">
									<asp:Button id="btnSave" runat="server" Text="Salvar Cambios"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:Button id="btnCancelar" runat="server" Text="Cancelar" 
                                CausesValidation="False"></asp:Button></TD>
							</TR>
						</TABLE>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    * Requerido</asp:panel>
                    <br />
                    <cc1:msgbox id="dlgBoxExcepciones" runat="server" ForeColor="Red"></cc1:msgbox>
                 </td>
			</tr>
		</table>
    </asp:Panel>
			
</asp:Content>	