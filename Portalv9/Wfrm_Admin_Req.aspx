<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_Req.aspx.vb" Inherits="Portalv9.Wfrm_Req" MasterPageFile="~/MasterPages/Adminmasteranidada.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Panel ID="Panel1" runat="server" Height="342px" Width="774px">
    
        <table style="Z-INDEX: 100; LEFT: 2px; TOP: 2px; height: 324px; width: 88%;" cellSpacing="0"
				cellPadding="0" border="0">
				<tr>
					<td vAlign="top" class="style1">
					</td>
					<td vAlign="top" align="left" width="*">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<table id="Table1" cellSpacing="0" cellPadding="0" width="654" border="0">
										<TR>
											<TD noWrap class="style2"></TD>
											<TD noWrap class="style3"></TD>
											<TD noWrap class="style4">
							                    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="624px" Height="5px" Font-Names="Arial"
									                Font-Bold="True" Font-Italic="True"> Texto en el page_ load
								                </asp:label>											
											</TD>
										</TR>
										<TR>
											<TD noWrap class="style5"></TD>
											<TD noWrap class="style7"></TD>
											<TD noWrap class="style8">
                                                <asp:button id="btnAddPSesion" runat="server" Width="168px" Text="Agregar Requerimiento" Font-Size="XX-Small"></asp:button>
                                                <INPUT id="hiddenPSesion" style="WIDTH: 88px; HEIGHT: 14px" type="hidden" size="9" name="hiddenPSesion"
													runat="server"></TD>
										</TR>
										<TR>
											<TD noWrap class="style6"></TD>
											<TD noWrap class="style9"></TD>
											<TD vAlign="top" noWrap align="left" class="style10">
											    <asp:datagrid id="grdPSesion" runat="server" Width="626px" AutoGenerateColumns="False" BorderWidth="1px"
													AllowPaging="True" AllowSorting="True" Height="91px">
													<SelectedItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="Black" BackColor="#B4C8DC"></SelectedItemStyle>
													<EditItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="Black" BackColor="#B4C8DC"></EditItemStyle>
													<AlternatingItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="Black" BackColor="#EAEAEA"></AlternatingItemStyle>
													<ItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="Black"></ItemStyle>
													<HeaderStyle Font-Size="X-Small" Font-Names="Arial Narrow" 
                                                Font-Bold="True" ForeColor="White"
														BackColor="Gray"></HeaderStyle>
													<FooterStyle Font-Size="X-Small" Font-Names="Arial" HorizontalAlign="Center" ForeColor="Black"
														BackColor="CornflowerBlue"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="RequerimientoID" ReadOnly="True" HeaderText="ID">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Nombre">
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
														<asp:TemplateColumn HeaderText="Descripci&#243;n">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<ItemTemplate>
																<asp:Label id="lblDescripcion" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
																</asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox id="TextDescripcion" runat="server" Width="305px" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
																</asp:TextBox>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Actualizar" CancelText="Cancelar" EditText="Editar">
															<HeaderStyle Width="50px"></HeaderStyle>
															<ItemStyle Font-Size="XX-Small" Font-Names="Arial" HorizontalAlign="Center"></ItemStyle>
														</asp:EditCommandColumn>
														<asp:ButtonColumn Text="X" HeaderText="Eliminar" CommandName="Delete">
															<HeaderStyle HorizontalAlign="Left" Width="40px"></HeaderStyle>
															<ItemStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Italic="True" Font-Bold="True"
																HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
														</asp:ButtonColumn>
													</Columns>
													<PagerStyle Font-Size="XX-Small" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Center"
														Mode="NumericPages"></PagerStyle>
												</asp:datagrid>
											</TD>
										</TR>
									</table>
								</td>
							</tr>
						</table>						
						<cc1:msgbox id="MsgBox1" runat="server"></cc1:msgbox>
					</td>
				</tr>
			</table>
    </asp:Panel>

</asp:Content>


