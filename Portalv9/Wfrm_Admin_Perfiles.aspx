<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_Perfiles.aspx.vb" Inherits="Portalv9.Wfrm_Perfiles" MasterPageFile="~/MasterPages/1.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 50px;
            height: 35px;
        }
        .style4
        {
            width: 21px;
            height: 50px;
        }
        .style5
        {
            width: 632px;
            height: 50px;
        }
        .style8
        {
            width: 63px;
            height: 35px;
        }
        .style9
        {
            width: 133px;
        }
        .style10
        {
            width: 133px;
            height: 35px;
        }
        .style11
        {
            width: 85px;
            height: 50px;
        }
        .style12
        {
            width: 133px;
            height: 22px;
        }
        .style13
        {
            width: 632px;
            height: 48px;
        }
        .style15
        {
            width: 632px;
            height: 33px;
        }
        .style16
        {
            width: 632px;
            height: 22px;
        }
        </style>
    <link href="css/Grids.css" rel="stylesheet" type="text/css" />
    <asp:Panel ID="Panel2" runat="server" > 
 		<table style="LEFT: 2px; TOP: 2px; " cellspacing="0" cellPadding="0" border="0">
			<tr>
                
				<td vAlign="top" align="left">
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
									<asp:button id="btnAddNew" Font-Size="XX-Small" Width="144px" CssClass="Button" 
                                        Runat="server"	CausesValidation="False" Text="Agregar Nuevo Perfil"></asp:button>
                                        <input id="htmlHiddenSortExpression" runat="server"  name="htmlHiddenSortExpression" style="WIDTH: 155px; HEIGHT: 14px" type="hidden" value="PerfilUsuarioID"></input>
                                        <input id="hiddenPerfilID" runat="server" name="hiddenPerfilID" size="9" style="WIDTH: 88px; HEIGHT: 14px" type="hidden"></input>
                                </td>
							    <td class="style11" align="right">
                                    <asp:Label ID="lblBuscar" runat="server" Font-Names="Arial" 
                                        Font-Size="XX-Small" Width="113px">Buscar Perfil:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBuscar" runat="server" Font-Size="XX-Small" MaxLength="50" 
                                        tabIndex="14" Width="185px"></asp:TextBox>
                                    <asp:Button ID="btnBuscar" runat="server" tabIndex="15" Text="Buscar..." CssClass="Button" />
                                </td>
                                
							</tr>
						</table>
						<asp:datagrid id="grdPerfiles" runat="server" Width="605px" Height="64px" DataKeyField="PerfilUsuarioID"
							AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" HorizontalAlign="Justify" 
                            PageSize="15" CellPadding="4" GridLines="None" 
                            style="margin-top: 0px" Font-Bold="False" Font-Italic="False" 
                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
			                <SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
			                <EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
			                <AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
			                <ItemStyle CssClass="ItemStyle"></ItemStyle>
			                <HeaderStyle CssClass="Encabezados"></HeaderStyle>
			                <FooterStyle CssClass="FooterStyle"></FooterStyle>	
							<Columns>
								<asp:BoundColumn DataField="PerfilUsuarioID" Visible="false" SortExpression="PerfilUsuarioID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="Nombre" SortExpression="Nombre" ReadOnly="True" HeaderText="<span class='EncabezadosText'>Nombre</span>"></asp:BoundColumn>
								<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" ReadOnly="True" HeaderText="<span class='EncabezadosText'>Descripci&#243;n</span>"></asp:BoundColumn>
								<asp:BoundColumn DataField="NombreSesion" SortExpression="NombreSesion" ReadOnly="True" HeaderText="<span class='EncabezadosText'>Pol. Sesi&#243;n</span>"></asp:BoundColumn>
								<asp:BoundColumn DataField="NombrePassword" SortExpression="NombrePassword" ReadOnly="True" HeaderText="<span class='EncabezadosText'>Pol. Contrase&#241;a</span>"></asp:BoundColumn>
								<asp:ButtonColumn Visible="True" Text="Editar" HeaderText="Editar" CommandName="Editar">
									<HeaderStyle CssClass="EncabezadosText" HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle Font-Size="XX-Small" Font-Italic="False" Font-Bold="True"
										HorizontalAlign="Center" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
								</asp:ButtonColumn>
								<asp:ButtonColumn Visible="True" Text="X" HeaderText="Eliminar" CommandName="Eliminar">
									<HeaderStyle CssClass="EncabezadosText"  HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle Font-Names="Arial" Font-Size="XX-Small" Font-Italic="True" Font-Bold="True"
										HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="PerfilUsuarioID" HeaderText="PerfilUsuarioID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="PoliticaPwdId" HeaderText="PoliticaPwdId"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="PoliticaSesionId" HeaderText="PoliticaSesionId"></asp:BoundColumn>
							</Columns>
						<PagerStyle CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
						<br />
						<asp:panel id="pnlFormUser" Font-Size="XX-Small" Width="605px" Height="423px" 
                            Font-Names="Arial Narrow"	Runat="server" BorderWidth="1px" BorderStyle="Solid" 
                            ForeColor="Red" BorderColor="#7F9DB9" Visible="False">
                            <table id="Table3" style="WIDTH: 600px; HEIGHT: 384px" cellSpacing="0" cellPadding="0" border="0">
                            <tr>
                                <td colspan="2">
                                    <font face="Arial" size="2" style="COLOR: #000099">&nbsp;Datos del Perfil.</font>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="style12">
                                    <font face="Arial" size="1">&nbsp;Nombre:</font>
                                </td>
                                <td class="style16">
                                    <asp:TextBox ID="txtNombre" runat="server" Font-Size="XX-Small" MaxLength="50" 
                                        Width="350px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" 
                                        ControlToValidate="txtNombre" ErrorMessage="*" Font-Names="Arial" 
                                        Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revNombre" runat="server" 
                                        ControlToValidate="txtNombre" ErrorMessage="No válido!!" Font-Names="Arial" 
                                        Font-Size="XX-Small" 
                                        ValidationExpression="^[a-zA-Z0-9-_\s|á|é|í|ó|ú|Á|É|Í|Ó|Ú|ñ|Ñ|&amp;]+$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="style10">
                                    <font face="Arial" size="1">&nbsp;Descripción:</font>
                                </td>
                                <td class="style5">
                                    <asp:TextBox ID="txtDescripcion" runat="server" Font-Size="XX-Small" 
                                        MaxLength="50" Width="350px"></asp:TextBox>
                                    <font face="Arial" size="1">
                                    <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" 
                                        ControlToValidate="txtDescripcion" ErrorMessage="*" Font-Names="Arial" 
                                        Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                    </font>
                                    <asp:RegularExpressionValidator ID="revDescripcion" runat="server" 
                                        ControlToValidate="txtDescripcion" ErrorMessage="No válido!!" 
                                        Font-Names="Arial" Font-Size="XX-Small" 
                                        ValidationExpression="^[a-zA-Z0-9-_\s|á|é|í|ó|ú|Á|É|Í|Ó|Ú|ñ|Ñ|&amp;]+$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="style10">
                                    <font face="Arial" size="1">&nbsp;Política de Sesión:</font>
                                </td>
                                <td class="style8" valign="top">
                                    <asp:DropDownList ID="DropPolSesion" runat="server" Font-Names="Arial" 
                                        Font-Size="XX-Small" Width="368px">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="style10">
                                    <font face="Arial" size="1">&nbsp;Política de Contraseña:</font>
                                </td>
                                <td class="style8" valign="top">
                                    <asp:DropDownList ID="DropPolContra" runat="server" Font-Names="Arial" 
                                        Font-Size="XX-Small" Width="368px">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="style9">
                                    <font face="Arial" size="1">&nbsp;Permisos:</font>
                                </td>
                                <td class="style15" valign="top">
                                    <asp:Panel ID="Panel3" runat="server" BorderColor="Silver" BorderStyle="Solid" 
                                        BorderWidth="1px" Height="145px" ScrollBars="Vertical" Width="427px">
                                        <asp:CheckBoxList ID="chklstPermisos" runat="server" CellPadding="0" 
                                            CellSpacing="0">
                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </td>
                               
                            </tr>
                            <tr valign="top">
                                <td class="style9">
                                    <font face="Arial" size="1">&nbsp;Proyectos:</font>
                                </td>
                                <td class="style13" valign="top">
                                    <asp:ListBox ID="ListProyectos" runat="server" Font-Names="Arial" 
                                        Font-Size="XX-Small" Height="54px" Rows="8" SelectionMode="Multiple" 
                                        Width="434px"></asp:ListBox>
                                    <asp:RequiredFieldValidator ID="RevProyectos" runat="server" 
                                        ControlToValidate="ListProyectos" ErrorMessage="*" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="center" valign="middle">
                                <td align="center" colspan="2" valign="middle">
                                    <asp:Button ID="btnSave" runat="server" Text="Salvar Cambios" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" 
                                        Text="Cancelar" />
                                </td>
                            </tr>
							</table>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;* 
                            Requerido</asp:panel>
                        <cc1:msgbox id="dlgBoxExcepciones" runat="server"></cc1:msgbox>
                 </td>
		    </tr>
		    <tr>
		      <td>
				    <asp:HiddenField ID="HiddenField1" runat="server" />
				    <asp:HiddenField ID="HiddenField2" runat="server" />
				    <asp:HiddenField ID="HiddenField3" runat="server" />
				    <asp:HiddenField ID="HiddenField4" runat="server" />
				    <asp:HiddenField ID="HiddenField5" runat="server" />
				    <asp:HiddenField ID="HiddenField6" runat="server" />
				 </td>
		     </tr>     
		</table>
	</asp:panel>   
</asp:Content>
