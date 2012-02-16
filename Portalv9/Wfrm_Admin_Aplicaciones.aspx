<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_Aplicaciones.aspx.vb" Inherits="Portalv9.Wfrm_Aplicaciones" MasterPageFile="~/MasterPages/1.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<%@ Register TagPrefix="DBWC" Namespace="DBauer.Web.UI.WebControls" Assembly="DBauer.Web.UI.WebControls.HierarGrid" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text=" Administración--&gt; Unidad Documental Compuesta - Subserie"></asp:Label>
</div>
</asp:Content>
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
			<table style="LEFT: 2px; TOP: 2px; height: 411px;" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td style="WIDTH: 100px" vAlign="top" width="100"></td>
					<td vAlign="top" align="left" width="*">
						<table cellSpacing="0" cellPadding="0" border="0" >
							<tr valign="top">
								<td valign="top">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr valign="top">
							                <td class="style9">
							                 <br/>
                                             <br/>
							                 <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="34px" Font-Names="Arial"  Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
							                </td>
						                </tr>
										<tr valign="top">
											<td class="style5" style="vertical-align: middle">
                                                <asp:button id="btnAddAplicacion" runat="server" Width="168px" Text="Agregar nueva Aplicación"
													Font-Size="XX-Small"></asp:button>
													<INPUT id="hiddenApp" style="WIDTH: 80px; HEIGHT: 14px" type="hidden" size="8" name="hiddenApp"
													runat="server">
											</td>
										</tr>
										<tr valign="top">
											<td valign="top" align="left" class="style6">
												<asp:datagrid id="grdApp" runat="server" Width="536px" AutoGenerateColumns="False"
													AllowPaging="True" AllowSorting="True" Height="64px" PageSize="15" CellPadding="4" GridLines="None">
			                                        <SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
			                                        <EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
			                                        <AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
			                                        <ItemStyle CssClass="ItemStyle"></ItemStyle>
			                                        <HeaderStyle CssClass="Encabezados"></HeaderStyle>
			                                        <FooterStyle CssClass="FooterStyle"></FooterStyle>	
			                                        <Columns>
														<asp:BoundColumn DataField="AplicacionID" ReadOnly="True" HeaderText="ID" 
                                                            Visible="false" ItemStyle-CssClass="EncabezadosText">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Nombre" HeaderStyle-CssClass="EncabezadosText">
															<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<ItemTemplate>
																<asp:Label id=lblnombre runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'>
																</asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox id=Textnombre runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'>
																</asp:TextBox>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Descripci&#243;n" HeaderStyle-CssClass="EncabezadosText">
															<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<ItemTemplate>
																<asp:Label id=lblDescripcion runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
																</asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox id=TextDescripcion runat="server" Width="305px" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
																</asp:TextBox>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:EditCommandColumn ButtonType="LinkButton"  HeaderStyle-CssClass="EncabezadosText" HeaderText="Editar" UpdateText="Actualizar" CancelText="Cancelar" EditText="Editar">
															<HeaderStyle Font-Bold="True" Font-Italic="False" 
                                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" 
                                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
														</asp:EditCommandColumn>
														<asp:ButtonColumn Text="X" HeaderStyle-CssClass="EncabezadosText" HeaderText="Eliminar" CommandName="Delete">
															<HeaderStyle HorizontalAlign="Center" Font-Bold="True" 
                                                                Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                                                Font-Underline="False"></HeaderStyle>
															<ItemStyle Font-Italic="False" Font-Bold="True"
																HorizontalAlign="Center" ForeColor="#C00000" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
														</asp:ButtonColumn>
													</Columns>
													<PagerStyle CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>
												</asp:datagrid>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<asp:HiddenField ID="HiddenField1" runat="server" />
				                <asp:HiddenField ID="HiddenField2" runat="server" />
							</tr>
						</table>						
						<cc1:msgbox id="MsgBox1" runat="server"></cc1:msgbox></td>
				</tr>
			</table>
	</asp:Panel> 		
</asp:Content>				

				
