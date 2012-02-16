<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_AppProy.aspx.vb" Inherits="Portalv9.Wfrm_AppProy" MasterPageFile="~/Masterpages/Adminmaster2col.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">    
    <script type="text/javascript" language="javascript" id="clientEventHandlersJS" >
		function getconfirm() 
			{ 
			if (confirm("¿Seguro de querer eliminar este registro?")==true) 
				return true; 
			else 
				return false; 
			}
	</script>


    <asp:Panel ID="Panel1" runat="server" Height="663px" Width="789px">
	
		<table style="LEFT: 2px; TOP: 2px; height: 625px; width: 751px;" 
            cellspacing="0" cellPadding="0" border="0">
			<tr>
				<td vAlign="top" class="style1"></td>
				<td vAlign="top" align="left" width="*">
					<table cellspacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td class="style2">
							    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="624px" Height="5px" Font-Names="Arial"
									Font-Bold="True" Font-Italic="True"> Texto en el page_ load
								</asp:label>
						    </td>
						</tr>
						<tr>
							<td style="vertical-align: middle" class="style3">									
                                <asp:Button ID="btnAddNew" Runat="server" CausesValidation="False" 
                                CssClass="Button" Font-Size="XX-Small" Text="Agregar Nueva Conexión" 
                                Width="144px"></asp:Button>
                                <input id="htmlHiddenSortExpression" runat="server" 
                                name="htmlHiddenSortExpression" style="WIDTH: 155px; HEIGHT: 14px" 
                                type="hidden" value="aplicacionId">
                                <input id="hiddenProy" runat="server" name="hiddenProy" size="9" 
                                style="WIDTH: 88px; HEIGHT: 14px" type="hidden">
                                <input id="hiddenApli" 
                                runat="server" name="hiddenApli" size="9" style="WIDTH: 88px; HEIGHT: 14px" 
                                type="hidden"></input></input></input>
							</td>
						</tr>
					</table>
					<asp:datagrid id="grdAppProy" runat="server" Width="544px" Height="64px" 
                        HorizontalAlign="Justify" AllowPaging="True" AutoGenerateColumns="False"
						AllowSorting="True" DataKeyField="ProyectoID" PageSize="15" Font-Bold="False" 
                        Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                        Font-Underline="False" style="margin-left: 0px" CellPadding="4" 
                        ForeColor="#333333" GridLines="None">
						<SelectedItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="#333333" 
                            BackColor="#D1DDF1" Font-Bold="True"></SelectedItemStyle>
						<EditItemStyle Font-Size="XX-Small" Font-Names="Arial" BackColor="#2461BF"></EditItemStyle>
						<AlternatingItemStyle Font-Size="XX-Small" Font-Names="Arial" BackColor="White"></AlternatingItemStyle>
						<ItemStyle Font-Size="XX-Small" Font-Names="Arial" BackColor="#EFF3FB" ></ItemStyle>
						<HeaderStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Bold="True" HorizontalAlign="Left"
							ForeColor="White" BackColor="#9DBADA"></HeaderStyle>
						<FooterStyle Font-Size="Smaller" HorizontalAlign="Center" ForeColor="White" 
                            BackColor="#9DBADA" Font-Bold="True"></FooterStyle>
						<Columns>
							<asp:ButtonColumn Text="Editar" DataTextField="ProyectoID" SortExpression="ProyectoID" HeaderText="ProyectoID"
								CommandName="Editar">
								<ItemStyle HorizontalAlign="Left"></ItemStyle>
							</asp:ButtonColumn>
							<asp:BoundColumn Visible="False" DataField="ProyectoID" ></asp:BoundColumn>
							<asp:BoundColumn DataField="AplicacionID" SortExpression="AplicacionID" HeaderText="AplicacionID" ></asp:BoundColumn>
							<asp:BoundColumn DataField="UID_" SortExpression="UID_" HeaderText="Usuario"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="PWD"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="DSN"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="Driver"></asp:BoundColumn>
							<asp:BoundColumn DataField="Server" SortExpression="Server" HeaderText="Server"></asp:BoundColumn>
							<asp:BoundColumn DataField="BDNombre" SortExpression="BDNombre" HeaderText="BDNombre"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="Argumento"></asp:BoundColumn>
							<asp:ButtonColumn Visible="True" Text="X" HeaderText="Eliminar" CommandName="Delete">
								<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
								<ItemStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Italic="True" Font-Bold="True"
									HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
							</asp:ButtonColumn>
						</Columns>
						<PagerStyle Font-Size="XX-Small" Font-Underline="True" HorizontalAlign="Center"
							ForeColor="White" BackColor="#9DBADA" PageButtonCount="15" Mode="NumericPages"></PagerStyle>
					</asp:datagrid><asp:panel id="pnlFormAppProy" Font-Size="XX-Small" Width="548px" Height="244px" Font-Names="Arial Narrow"
						Runat="server" BorderWidth="1px" BorderStyle="Solid" ForeColor="Red" BorderColor="#7F9DB9" Visible="False">
  <TABLE id="Table1" style="WIDTH: 541px; HEIGHT: 203px" cellspacing="0" cellPadding="0"
							border="0">
							<TR>
								<TD style="HEIGHT: 23px" colSpan="2">
                                    <FONT style="COLOR: #000099" face="Arial" size="2">&nbsp;Datos 
										de Aplicación/Proyecto.</FONT>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 552px; HEIGHT: 5px" vAlign="top" colSpan="2"><FONT face="Arial" size="1">&nbsp;&nbsp; 
										Proyecto:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:DropDownList id="ListaProy" runat="server" Font-Names="Arial" Width="360px" Font-Size="XX-Small"></asp:DropDownList>
										<asp:RequiredFieldValidator id="RrfvListaProy" runat="server" Font-Size="XX-Small" ControlToValidate="ListaProy"
											ErrorMessage="*"></asp:RequiredFieldValidator></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 552px; HEIGHT: 7px" vAlign="top" colSpan="2"><FONT face="Arial" size="1">&nbsp;&nbsp; 
										Aplicación:&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:DropDownList id="ListaAplicacion" runat="server" Font-Names="Arial" Width="360px" Font-Size="XX-Small"></asp:DropDownList>
										<asp:RequiredFieldValidator id="rfvListAplicacion" runat="server" Font-Size="XX-Small" ControlToValidate="ListaAplicacion"
											ErrorMessage="*"></asp:RequiredFieldValidator>&nbsp;&nbsp; </FONT>
								</TD>
							</TR>
							<TR vAlign="top">
								<TD style="WIDTH: 551px; HEIGHT: 14px" colSpan="2">
                                    <font face="Arial" size="1">&#160;&#160;Usuario:&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
										<asp:TextBox ID="txtUser" runat="server" Font-Size="XX-Small" 
                                MaxLength="50" Width="324px"></asp:TextBox>
                                    <font face="Arial" size="1">
										<asp:RegularExpressionValidator ID="revUSR" runat="server" 
                                ControlToValidate="txtUser" ErrorMessage="No válido!!" Font-Size="XX-Small" 
                                ValidationExpression="^[a-zA-Z-0-9_\s|]+$"></asp:RegularExpressionValidator></font></font></TD>
							</TR>
							<TR vAlign="top">
								<TD style="WIDTH: 551px; HEIGHT: 14px" colSpan="2">
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
								<TD style="WIDTH: 551px; HEIGHT: 14px" colSpan="2">
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
								<TD style="WIDTH: 551px; HEIGHT: 14px" colSpan="2">
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
								<TD style="WIDTH: 551px; HEIGHT: 14px" colSpan="2">
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
								<TD style="WIDTH: 551px; HEIGHT: 14px" colSpan="2">
                                    <font face="Arial" size="1">&#160; 
										Base de Datos:
										<asp:TextBox ID="txtBD" runat="server" Font-Size="XX-Small" 
                                MaxLength="50" Width="224px"></asp:TextBox>
										<asp:RequiredFieldValidator ID="rfvBD" runat="server" 
                                ControlToValidate="txtBD" ErrorMessage="*" Font-Size="XX-Small"></asp:RequiredFieldValidator>
										<asp:RegularExpressionValidator ID="revBD" runat="server" 
                                ControlToValidate="txtBD" ErrorMessage="No válido!!" Font-Size="XX-Small" 
                                ValidationExpression="^[a-zA-Z-0-9_\s|]+$"></asp:RegularExpressionValidator></font></TD>
							</TR>
							<TR vAlign="top">
								<TD style="WIDTH: 551px; HEIGHT: 14px" colSpan="2">
                                    <font face="Arial" size="1">&#160; 
										Argumento:&#160;&#160;&#160;&#160;&#160;
										<asp:TextBox ID="txtArgumento" runat="server" Font-Size="XX-Small" 
                                MaxLength="50" Width="24px"></asp:TextBox>
										<asp:RegularExpressionValidator ID="revArgumento" runat="server" 
                                ControlToValidate="txtArgumento" ErrorMessage="No válido!!" 
                                Font-Size="XX-Small" ValidationExpression="^[0-9\s|]+$"></asp:RegularExpressionValidator></font></TD>
							</TR>
							<TR vAlign="middle" align="center">
								<TD vAlign="middle" align="center" colSpan="2">
									<asp:Button id="btnSave" runat="server" Text="Salvar Cambios"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:Button id="btnCancelar" runat="server" Text="Cancelar" 
                                CausesValidation="False"></asp:Button></TD>
							</TR>
						</TABLE>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    * Requerido</asp:panel>
                    <br />
                    <cc1:msgbox id="dlgBoxExcepciones" runat="server" ForeColor="Red"></cc1:msgbox></td>
				</TD></tr>
		</table>
    </asp:Panel>
			
</asp:Content>	
			
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server" >

    <style type="text/css">
        .style1
        {
            width: 50px;
        }
        .style2
        {
            height: 50px;
        }
        .style3
        {
            height: 35px;
        }
    </style>

</asp:Content>
				