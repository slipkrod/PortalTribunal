<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_Modulos.aspx.vb" Inherits="Portalv9.Wfrm_Modulos" MasterPageFile="~/MasterPages/Adminmasteranidada.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<%@ Register TagPrefix="DBWC" Namespace="DBauer.Web.UI.WebControls" Assembly="DBauer.Web.UI.WebControls.HierarGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">

	<script id="vs_defaultClientScript" language="javascript" type="text/javascript" >
		function getconfirm() 
			{ 
			if (confirm("¿Seguro de querer eliminar este registro?")==true) 
				return true; 
			else 
				return false; 
			}
	</script>
    
    <asp:Panel ID="Panel1" runat="server" >
			<table style="LEFT: 2px; TOP: 2px; cellSpacing="0" cellPadding="0"
				 border="0">
				<tr>
					<td style="WIDTH: 162px" vAlign="top" width="600px"></td>
					
						<table cellSpacing="0" cellPadding="0" border="0" 
                            style="width: 97%; height: 414px;">
							<tr>
								<td>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0">
										<tr>
											<TD noWrap class="style2"></TD>
											<TD colspan="2">&nbsp;
							                    <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="5px" Font-Names="Arial"
									                Font-Bold="True" Font-Italic="True"> Texto en el 
                                                page_ load
								                </asp:label>
                                            </TD> 								              
										</tr>
										<TR>
											<TD noWrap class="style2"></TD>
											<TD colspan="2">
                                                <asp:button id="btnAddAplicacion" runat="server" Width="168px" Text="Agregar nuevo Módulo" Font-Size="XX-Small"></asp:button>
                                                <input id="hiddenAplicacionID" type="hidden" name="hiddenAplicacionID" runat="server" />
                                                <input id="hiddenVersionID" type="hidden" name="hiddenVersionID" runat="server" />
                                            </TD>
										</TR>										
										<TR>
											<TD noWrap class="style3"></TD>											
											<TD colspan="2" class="style4">
                                                <asp:label id="lblApp" runat="server" Font-Size="XX-Small"  
                                                Height="16px" Font-Names="Arial"
										        Font-Bold="True" Width="100px" >Aplicación:</asp:label>
										        <asp:dropdownlist id="ddlApp" runat="server" Height="16px" Width="250px" AutoPostBack="True"></asp:dropdownlist>
									        </TD>											
										</TR>
										<TR>
											<TD noWrap class="style3"></TD>
											<TD colspan="2" class="style4">
                                                <asp:label id="Label2" runat="server" Font-Size="XX-Small" 
                                                Height="16px" Font-Names="Arial"
										        Font-Bold="True" Width="100px" >Versión:</asp:label>
										        <asp:dropdownlist id="ddlVer" runat="server" Height="16px" Width="250px" AutoPostBack="True"></asp:dropdownlist>
									        </TD>
										</TR>
										<TR>
											<TD noWrap class="style2"></TD>
											<TD colspan="2" style="WIDTH: 632px; HEIGHT: 301px" vAlign="top" noWrap align="left"><DBWC:HIERARGRID id="HG1" style="Z-INDEX: 101" runat="server" Width="100%" AutoGenerateColumns="False"
													TemplateDataMode="Table" LoadControlMode="UserControl" TemplateCachingBase="Tablename" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#999999"
													AllowPaging="True">
													<PagerStyle Font-Size="XX-Small" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Center"
														Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="Black" BackColor="#EAEAEA"></AlternatingItemStyle>
													<EditItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="Black" BackColor="#B4C8DC"></EditItemStyle>
													<FooterStyle Font-Size="X-Small" Font-Names="Arial" HorizontalAlign="Center" ForeColor="Black"
														BackColor="CornflowerBlue"></FooterStyle>
													<SelectedItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="Black" BackColor="#B4C8DC"></SelectedItemStyle>
													<ItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="Black"></ItemStyle>
													<HeaderStyle Font-Size="X-Small" Font-Names="Arial Narrow" 
                                            Font-Bold="True" HorizontalAlign="Center"
														ForeColor="White" BackColor="Gray"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="ModuloID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
														<asp:BoundColumn DataField="NbModulo" HeaderText="Nombre"></asp:BoundColumn>
														<asp:BoundColumn DataField="Descripcion" HeaderText="Descripcion"></asp:BoundColumn>
														<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Actualizar" HeaderText="Edici&#243;n" CancelText="Cancelar"
															EditText="Edici&#243;n"></asp:EditCommandColumn>
														<asp:ButtonColumn Text="X" HeaderText="Borrar" CommandName="Delete">
															<ItemStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Italic="True" Font-Bold="True"
																HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
														</asp:ButtonColumn>														
													</Columns>
												</DBWC:HIERARGRID></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
						<cc1:msgbox id="MsgBox1" runat="server"></cc1:msgbox></td>
				</tr>
			</table>
    </asp:Panel>

</asp:Content>

