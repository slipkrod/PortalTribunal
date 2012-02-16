<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_GrupoAdmin.aspx.vb" Inherits="Portalv9.Wfrm_GrupoAdmin" MasterPageFile="~/Masterpages/Adminmaster2col.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    
    <script type="text/javascript" language="javascript" id="clientEventHandlersJS" >
        function getconfirm() {
            if (confirm("¿Seguro de querer eliminar este registro?") == true)
                return true;
            else
                return false;
        }
        
    </script>
    <link href="Grids.css" rel="stylesheet" type="text/css" />
        <asp:Panel ID="Panel1" runat="server" Height="420px" Width="808px">
    
			<table style="LEFT: 2px; WIDTH: 656px; TOP: 2px; width="656" border="0">
				<tr>
					<td style="HEIGHT: 325px" vAlign="top" align="left" width="*">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td style="HEIGHT: 184px">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD noWrap class="style3"></TD>
											<TD noWrap class="style4"></TD>
											<TD noWrap class="style5" colspan="3">&nbsp;
												<asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Font-Names="Arial"
													Font-Bold="True" Font-Italic="True"> Texto en el 
                                                page_ load</asp:label></TD>
										</TR>
										<TR>
											<TD noWrap class="style1"></TD>
											<TD noWrap class="style6"></TD>
											<TD class="style4">
                                                <asp:button id="btnAddPGrupo" runat="server" Font-Size="XX-Small" Width="168px" Text="Agregar Grupo Administrativo"></asp:button>
                                                <INPUT id="hiddenPGrupo" style="WIDTH: 88px; " type="hidden" size="9" name="hiddenPSesion"
													runat="server"></TD>
											<td class="style8">
                                    <asp:Label ID="lblBuscar" runat="server" Font-Names="Arial" 
                                        Font-Size="XX-Small" Width="89px" Height="16px">Buscar Grupo:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBuscar" runat="server" Font-Size="XX-Small" MaxLength="50" 
                                        tabIndex="14" Width="185px"></asp:TextBox>
                                    <asp:Button ID="btnBuscar" runat="server" tabIndex="15" Text="Buscar..." 
                                        Height="26px" CssClass="standard-text" />
                                </td>
										</TR>
										<TR>
											<TD noWrap class="style2"></TD>
											<TD style="WIDTH: 21px; HEIGHT: 210px" noWrap></TD>
											<TD style="WIDTH: 632px; HEIGHT: 210px" vAlign="top" noWrap align="left" 
                                            colspan="3">
                                            <asp:datagrid id="grdPGrupo" runat="server" Width="626px" Height="91px" ForeColor="Blue"
                                                    PageSize="15" AutoGenerateColumns="False" AllowPaging="True" 
                                                    AllowSorting="True" CellPadding="4" GridLines="None">
													<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
													<EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
													<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemStyle"></ItemStyle>
													<HeaderStyle CssClass="Encabezados"></HeaderStyle>
													<FooterStyle CssClass="FooterStyle"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="GrupoAdminID" ReadOnly="True" HeaderText="ID" Visible="false">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Nombre" HeaderStyle-CssClass="EncabezadosText">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<ItemTemplate>
																<asp:Label id="lblNombre" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'>
																</asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox id="TextNombre" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'>
																</asp:TextBox>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Descripci&#243;n" HeaderStyle-CssClass="EncabezadosText">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<ItemTemplate>															
																<asp:label id="lbldescripcion" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion")%>'>
																</asp:label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox id="TextDescripcion" runat="server" Width="305px" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
																</asp:TextBox>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Responsable" HeaderStyle-CssClass="EncabezadosText">
															<ItemTemplate>
															    <asp:Label ID="lblresposable" runat="server" Text='<%#Container.DataItem("NombreResp")%>'>
															    </asp:Label> 
															</ItemTemplate>
															<EditItemTemplate>
																<asp:DropDownList id="ddResponsable" DataValueField="NoIdentidad" DataTextField="Nombre" DataSource="<%# ObtenerUsuarios() %>"  SelectedValue='<%# ObtenerValueUsuario(IIf(DataBinder.Eval(Container, "DataItem.ResponsableID") Is System.DBNull.Value, -1, DataBinder.Eval(Container, "DataItem.ResponsableID"))) %>' Runat="server">
																</asp:DropDownList>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Gpo Padre" HeaderStyle-CssClass="EncabezadosText">
														<ItemTemplate>
														<asp:Label ID="lblgrupopadre" runat="server" Text='<%#Container.DataItem("NombrePadre")%>'>
															    </asp:Label> 														
														</ItemTemplate>
														    <EditItemTemplate>
														        <asp:DropDownList ID="ddgpopadre" DataValueField="GrupoAdminID" DataTextField="Nombre" DataSource="<%# ObtenerGrupos() %>"  SelectedValue='<%# ObtenerValueGrupo(IIf(DataBinder.Eval(Container, "DataItem.GrupoAdminID") Is System.DBNull.Value, -1, DataBinder.Eval(Container, "DataItem.GrupoAdminID"))) %>' Runat="server">
														        </asp:DropDownList>
														    </EditItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Cliente" HeaderStyle-CssClass="EncabezadosText">
															<ItemTemplate>
																<%#Container.DataItem("NombreCliente")%>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:DropDownList id="ddCliente" DataValueField="ClienteID" DataTextField="Nombre" DataSource="<%# ObtenerClientes() %>"  SelectedValue='<%# ObtenerValueCliente(IIf(DataBinder.Eval(Container, "DataItem.ClienteID") Is System.DBNull.Value, -1, DataBinder.Eval(Container, "DataItem.ClienteID"))) %>' Runat="server"  >
																</asp:DropDownList>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Actualizar" CancelText="Cancelar" EditText="Editar" HeaderText = "Editar" HeaderStyle-CssClass="EncabezadosText">
															<ItemStyle Font-Size="XX-Small" Font-Names="Arial" HorizontalAlign="Center"></ItemStyle>
														</asp:EditCommandColumn>
														<asp:ButtonColumn Text="X" HeaderText="Eliminar" CommandName="Delete" HeaderStyle-CssClass="EncabezadosText">
															<ItemStyle Font-Size="X-Small" Font-Names="Arial " Font-Italic="True" Font-Bold="True"
																HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
														</asp:ButtonColumn>
													</Columns>
													<PagerStyle CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>
												</asp:datagrid>
</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
						<cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox></td>
				</tr>
				<tr>
				    <asp:HiddenField ID="HiddenField1" runat="server" />
				    <asp:HiddenField ID="HiddenField2" runat="server" />
				    <asp:HiddenField ID="HiddenField3" runat="server" />
				    <asp:HiddenField ID="HiddenField4" runat="server" />
				    <asp:HiddenField ID="HiddenField5" runat="server" />
                </tr>
			</table>
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder4" runat="server" >

    <style type="text/css">
        .style1
        {
            width: 50px;
            height: 35px;
        }
        .style2
        {
            height: 210px;
            width: 50px;
        }
        .style3
        {
            width: 50px;
            height: 50px;
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
        .style6
        {
            width: 21px;
            height: 35px;
        }
        .style7
        {
            width: 632px;
            height: 35px;
        }
    </style>
</asp:Content>
