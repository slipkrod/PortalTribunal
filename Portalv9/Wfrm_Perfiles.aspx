<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Wfrm_Perfiles.aspx.vb" Inherits="Portalv9.Wfrm_Perfiles"  MasterPageFile="~/Masterpages/Adminmaster2col.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server" >
    <asp:Panel ID="Panel1" runat="server" Height="819px" Width="765px">
			<table style="LEFT: 2px; TOP: 2px; height: 783px; width: 720px;" 
                cellSpacing="0" cllPadding="0" border="0">
				<tr>
					<td vAlign="top" class="style2"></td>
					<td vAlign="top" align="left" width="*">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="style1" colspan="3"><asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="5px" Font-Names="Arial"
										Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label></td>
							</tr>
							<tr>
								<td class="style10">									
									<asp:button id="btnAddNew" Font-Size="XX-Small" Width="144px" Text="Agregar Nuevo Perfil" CausesValidation="False"
											Runat="server" CssClass="Button"></asp:button>
                                        <input id="htmlHiddenSortExpression" runat="server" 
                                        name="htmlHiddenSortExpression" style="WIDTH: 155px; HEIGHT: 14px" 
                                        type="hidden" value="PerfilUsuarioID">
                                        <input id="hiddenPerfilID" runat="server" name="hiddenPerfilID" size="9" 
                                        style="WIDTH: 88px; HEIGHT: 14px" type="hidden"></input></input>
								</td>
							    <td class="style11">
                                    <asp:Label ID="lblBuscar" runat="server" Font-Names="Arial" 
                                        Font-Size="XX-Small" Width="74px">Buscar Perfil:</asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:TextBox ID="txtBuscar" runat="server" Font-Size="XX-Small" MaxLength="50" 
                                        tabIndex="14" Width="185px"></asp:TextBox>
                                    <asp:Button ID="btnBuscar" runat="server" tabIndex="15" Text="Buscar..." />
                                </td>
							</tr>
						</table>
						<asp:datagrid id="grdPerfiles" runat="server" Width="640px" Height="64px" DataKeyField="PerfilUsuarioID"
							AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" HorizontalAlign="Justify" 
                            PageSize="15" CellPadding="4" ForeColor="#333333" GridLines="None">
							<SelectedItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="#333333" CssClass="DataGrid_SelectedItemStyle"
								BackColor="#D1DDF1" Font-Bold="True"></SelectedItemStyle>
							<EditItemStyle Font-Size="XX-Small" Font-Names="Arial" BackColor="#2461BF"></EditItemStyle>
							<AlternatingItemStyle Font-Size="XX-Small" Font-Names="Arial" CssClass="DataGrid_AlternatingItemStyle"
								BackColor="White"></AlternatingItemStyle>
							<ItemStyle Font-Size="XX-Small" Font-Names="Arial" 
                                CssClass="DataGrid_ItemStyle" BackColor="#EFF3FB"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Bold="True" HorizontalAlign="Center"
								ForeColor="White" CssClass="DataGrid_HeaderStyle" BackColor="#9DBADA"></HeaderStyle>
							<FooterStyle Font-Size="Smaller" HorizontalAlign="Center" ForeColor="White" CssClass="DataGrid_FooterStyle"
								BackColor="#507CD1" Font-Bold="True"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="PerfilUsuarioID" Visible="false" SortExpression="PerfilUsuarioID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="Nombre" SortExpression="Nombre" ReadOnly="True" HeaderText="Nombre"></asp:BoundColumn>
								<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" ReadOnly="True" HeaderText="Descripci&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="NombreSesion" SortExpression="NombreSesion" ReadOnly="True" HeaderText="Pol. Sesi&#243;n"></asp:BoundColumn>
								<asp:BoundColumn DataField="NombrePassword" SortExpression="NombrePassword" ReadOnly="True" HeaderText="Pol. Contrase&#241;a"></asp:BoundColumn>
								<asp:ButtonColumn Visible="True" Text="Editar" HeaderText="Editar" CommandName="Editar">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Italic="True" Font-Bold="True"
										HorizontalAlign="Center" ForeColor=Black></ItemStyle>
								</asp:ButtonColumn>
								<asp:ButtonColumn Visible="True" Text="X" HeaderText="Eliminar" CommandName="Eliminar">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Italic="True" Font-Bold="True"
										HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="PerfilUsuarioID" HeaderText="PerfilUsuarioID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="PoliticaPwdId" HeaderText="PoliticaPwdId"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="PoliticaSesionId" HeaderText="PoliticaSesionId"></asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="XX-Small" Font-Underline="True" HorizontalAlign="Center"
								ForeColor="White" BackColor="#9DBADA" PageButtonCount="15" Mode="NumericPages" Font-Bold="False" 
                                Font-Italic="False" Font-Overline="False" Font-Strikeout="False" ></PagerStyle>
						</asp:datagrid>
                        <asp:panel id="pnlFormUser" Font-Size="XX-Small" Width="627px" 
                            Height="485px" Font-Names="Arial Narrow"
							Runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False" BorderColor="#7F9DB9" 
                            ForeColor="Red">
      <TABLE id="Table1" style="WIDTH: 621px; HEIGHT: 244px" cellSpacing="0" cellPadding="0"
								border="0">
								<TR>
									<TD colSpan="3">
									    <FONT style="COLOR: #000099" face="Arial" size="2">&#160;Datos 
                                        del Perfil.</FONT>
									</TD>
								</TR>
								<TR vAlign="top">
								    <td class="style6">
								        <font face="Arial" size="1">&nbsp;Nombre:</font>
								    </td>
									<td class="style5" colspan="2">									    
											<asp:TextBox id="txtNombre" runat="server" Width="350px" 
                                            Font-Size="XX-Small" MaxLength="50"></asp:TextBox>
											<asp:RequiredFieldValidator id="rfvNombre" runat="server" 
                                            Font-Size="XX-Small" ErrorMessage="*" ControlToValidate="txtNombre" 
                                            Font-Names="Arial"></asp:RequiredFieldValidator>
											<asp:RegularExpressionValidator id="revNombre" runat="server" 
                                            Font-Size="XX-Small" ErrorMessage="No válido!!" ControlToValidate="txtNombre"
												ValidationExpression="^[a-zA-Z0-9-_\s|á|é|í|ó|ú|Á|É|Í|Ó|Ú|ñ|Ñ|&amp;]+$" Font-Names="Arial"></asp:RegularExpressionValidator>
										
								    </td>
								</TR>
								<TR vAlign="top">
								    <td class="style6">
								        <FONT face="Arial" size="1">&nbsp;Descripción:</FONT>
								    </td>
									<TD class="style5" colspan="2">									
										<asp:TextBox id="txtDescripcion" runat="server" Width="350px" 
                                    Font-Size="XX-Small" MaxLength="50"></asp:TextBox>
                                        <font face="Arial" size="1">
										<asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" 
                                            ControlToValidate="txtDescripcion" ErrorMessage="*" 
                                    Font-Size="XX-Small" Font-Names="Arial"></asp:RequiredFieldValidator></font>
										<asp:RegularExpressionValidator id="revDescripcion" runat="server" Font-Names="Arial" Font-Size="XX-Small" ErrorMessage="No válido!!"
												ControlToValidate="txtDescripcion" ValidationExpression="^[a-zA-Z0-9-_\s|á|é|í|ó|ú|Á|É|Í|Ó|Ú|ñ|Ñ|&amp;]+$"></asp:RegularExpressionValidator>
									</TD>
								</TR>
								<TR vAlign="top">
								    <td class="style6">
								        <FONT face="Arial" size="1">&nbsp;Política de Sesión:</FONT>
								    </td>
									<TD vAlign="top" class="style8" colspan="2">
										<asp:DropDownList id="DropPolSesion" runat="server" Font-Names="Arial" Width="368px" Font-Size="XX-Small"></asp:DropDownList>
                                        &#160;&#160;										
									</TD>
								</TR>
								<TR vAlign="top">
								    <td class="style6">
								        <FONT face="Arial" size="1">&nbsp;Política de Contraseña:</FONT>
								    </td>
									<TD vAlign="top" class="style8" colspan="2">
										<asp:DropDownList id="DropPolContra" runat="server" Font-Names="Arial" Width="368px" Font-Size="XX-Small"></asp:DropDownList>
                                        &#160;&#160;										
									</TD>
								</TR>
								<TR vAlign="top">
								    <td class="style9">
								        <FONT face="Arial" size="1">&nbsp;Permisos:</FONT>
								    </td>
									<TD vAlign="top" class="style15">
                                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" 
                                    BorderWidth="1px" Height="145px" ScrollBars="Vertical" Width="427px" 
                                    BorderColor="Silver">
                                            <asp:CheckBoxList ID="chklstPermisos" runat="server" CellPadding="0" 
                                                CellSpacing="0">
                                            </asp:CheckBoxList>
                                        </asp:Panel>
                                    </TD>
									<td class="style14" valign="top">
										<br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </td>
								</TR>
								<TR vAlign="top">
								    <td class="style12">
								        <FONT face="Arial" size="1">&nbsp;Proyectos:</FONT>
								    </td>
									<TD vAlign="top" class="style13" colspan="2"> 
										<asp:ListBox id="ListProyectos" runat="server" Font-Names="Arial" 
                                    Height="54px" Width="434px"
											Font-Size="XX-Small" Rows="8" SelectionMode="Multiple"></asp:ListBox>
										<asp:RequiredFieldValidator id="RevProyectos" runat="server" Font-Size="XX-Small" ErrorMessage="*" ControlToValidate="ListProyectos"></asp:RequiredFieldValidator></TD>
								</TR>
								<TR vAlign="middle" align="center">								    
									<TD vAlign="middle" align="center" colSpan="3">
										<asp:Button id="btnSave" runat="server" Text="Salvar Cambios"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Button id="btnCancelar" runat="server" Text="Cancelar" 
                                    CausesValidation="False"></asp:Button></TD>
								</TR>
							</TABLE>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            * Requerido</asp:panel><cc1:msgbox id="dlgBoxExcepciones" runat="server" ForeColor="Red"></cc1:msgbox></td>
					</TD></tr>
					<TR>
				    <asp:HiddenField ID="HiddenField1" runat="server" />
				    <asp:HiddenField ID="HiddenField2" runat="server" />
				    <asp:HiddenField ID="HiddenField3" runat="server" />
				    <asp:HiddenField ID="HiddenField4" runat="server" />
				    <asp:HiddenField ID="HiddenField5" runat="server" />
				    <asp:HiddenField ID="HiddenField6" runat="server" />
                </TR>
			</table>
    </asp:Panel>
</asp:content>


<%--<---<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            height: 50px;
        }
        .style2
        {
            width: 48px;
        }
        .style3
        {
            height: 35px;
        }
        .style5
        {
            width: 551px;
            height: 25px;
        }
        .style6
        {
            height: 25px;
            width: 172px;
        }
        .style8
        {
            width: 552px;
            height: 25px;
        }
        .style9
        {
            width: 172px;
            height: 153px;
        }
        .style10
        {
            width: 172px;
            height: 106px;
        }
        .style11
        {
            width: 46px;
            height: 106px;
        }
        .style12
        {
            width: 172px;
            height: 59px;
        }
        .style13
        {
            width: 552px;
            height: 59px;
        }
        .style14
        {
            width: 552px;
            height: 153px;
        }
        .style15
        {
            width: 445px;
            height: 153px;
        }
    </style>

</asp:Content>-->
--%>