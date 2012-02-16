<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_RequerimentoMod.aspx.vb" Inherits="Portalv9.Wfrm_RequerimentoMod" MasterPageFile="~/MasterPages/Adminmasteranidada.master" %>
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

<table cellspacing="0" cellpadding="0" border="0" 
                style="width: 90%; height: 447px">
				<tr>
					<td style="WIDTH: 1px" valign="top" width="1"></td>
					<td valign="top" align="left" width="*">
						<table cellspacing="0" cellpadding="0" border="0" style="width: 156%">
							<tr valign="top">
								<td valign="top">
									<TABLE id="Table1" cellspacing="0" cellpadding="0" border="0" 
                                        style="WIDTH: 782px; POSITION: static; HEIGHT: 160px">
										
										<tr valign="top">
											<td nowrap class="style7"></td>
											<td noWrap class="style8"></td>
											<td noWrap class="style9"><br /><br />
											    &nbsp; &nbsp;
												<asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="5px" Font-Names="Arial"
													Font-Bold="True" Font-Italic="True">Requerimientos:</asp:label>
											</td>
										</tr>										
										<tr valign="top">
											<td noWrap class="style1"></td>
											<td noWrap class="style3"></td>
											<td noWrap class="style5" style="vertical-align: middle">
	                                            <asp:Button id="btnAddMod" runat="server" Text="Agregar Requerimiento" 
                                                    Font-Size="XX-Small"></asp:Button>
	                                            <input id="hiddenModuloID" type="hidden" name="hiddenModuloID" runat="server">
											</td>
										</tr>
										<tr>
										<td noWrap class="style1"></td>
										<td noWrap class="style3"></td>
										<td>	
										    <asp:label id="lblMod" runat="server" Font-Size="XX-Small" Width="100px" 
                                                Height="16px" Font-Names="Arial"
												Font-Bold="True" >Módulo:</asp:label>                                        
                                                <asp:DropDownList ID="ddlMod" runat="server" Height="16px" Width="250px" 
                                                AutoPostBack="True"></asp:DropDownList>												                                         										    
										</td>
										</tr>
										<tr valign="top">
											<td nowrap class="style2"></td>
											<td nowrap class="style4"></td>
											<td valign="top" nowrap align="left" class="style6">
	                                        <asp:datagrid id="DG1" style="Z-INDEX: 101" runat="server" AllowPaging="True" AutoGenerateColumns="False"
		                                        CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#999999"
		                                        Width="100%" Height="208px">
		                                        <SelectedItemStyle Font-Size="XX-Small" Font-Names="Arial" Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
		                                        <EditItemStyle Font-Size="XX-Small" Font-Names="Arial"></EditItemStyle>
		                                        <AlternatingItemStyle Font-Size="XX-Small" Font-Names="Arial" BackColor="Gainsboro"></AlternatingItemStyle>
		                                        <ItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
		                                        <HeaderStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Bold="True" ForeColor="White"
			                                        BackColor="Gray"></HeaderStyle>
		                                        <Columns>
			                                        <asp:BoundColumn DataField="ReqModuloID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
			                                        <asp:TemplateColumn HeaderText="Requerimiento">
				                                        <ItemTemplate>
					                                        <%#Container.DataItem("Nombre")%>					                                       
				                                        </ItemTemplate>				                                        
				                                        <EditItemTemplate>
					                                        <asp:DropDownList Runat="server" ID="ddReq" DataSource="<%# ObtenerRequerimientos() %>" DataTextField="Nombre" DataValueField="RequerimientoID" />
				                                        </EditItemTemplate>
			                                        </asp:TemplateColumn>
			                                        <asp:BoundColumn DataField="Tag" HeaderText="Tag"></asp:BoundColumn>
			                                        <asp:BoundColumn DataField="Descripcion" ReadOnly="True" HeaderText="Descripci&#243;n"></asp:BoundColumn>
			                                        <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Actualizar" HeaderText="Edici&#243;n" CancelText="Cancelar"
				                                        EditText="Edici&#243;n"></asp:EditCommandColumn>
			                                        <asp:ButtonColumn Text="X" HeaderText="Borrar" CommandName="Delete">
				                                        <ItemStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Italic="True" Font-Bold="True"
					                                        HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
			                                        </asp:ButtonColumn>
			                                        <asp:BoundColumn Visible="False" DataField="ModuloID" ReadOnly="True" HeaderText="ModuloID"></asp:BoundColumn>
		                                        </Columns>
		                                        <PagerStyle Font-Size="XX-Small" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Center"
			                                        Mode="NumericPages"></PagerStyle>
	                                        </asp:datagrid>
												                                        </TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
						<cc1:msgbox id="MsgBox1" runat="server"></cc1:msgbox></td>
				</tr>
			</table>

			
</asp:Content>				
