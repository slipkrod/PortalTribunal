<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_DynamicUsr.aspx.vb" Inherits="Portalv9.Wfrm_DynamicUsr" MasterPageFile="~/Masterpages/Adminmaster2col.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
    
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">        
    .<script type="text/javascript" language="javascript" id="clientEventHandlersJS" >
	    function getconfirm() 
		    { 
		    if (confirm("¿Seguro de querer eliminar este registro?")==true) 
			    return true; 
		    else 
			    return false; 
		    }
    </script><asp:Panel ID="Panel1" runat="server" Height="420px" Width="808px">
    
			<table style="LEFT: 2px; WIDTH: 656px; TOP: 2px; cellSpacing="0"
				cellPadding="0" width="656" border="0">
				<tr>
					<td style="HEIGHT: 325px" vAlign="top" align="left" width="*">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td style="HEIGHT: 184px">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD noWrap class="style9"></TD>
											<TD noWrap class="style4"></TD>
											<TD noWrap class="style5" colspan="3">&nbsp;
												<asp:label id="lblTitle" runat="server" Font-Size="Small" Width="554px" Font-Names="Arial"
													Font-Bold="True" Font-Italic="True"> Texto en el 
                                                page_ load</asp:label></TD>
										</TR>
										<TR>
											<TD noWrap class="style9"></TD>
											<TD noWrap class="style6"></TD>
											<TD class="style4">
                                                <asp:button id="btnAddNew" runat="server" Font-Size="XX-Small" 
                                            Width="168px" Text="Agregar Campo Dinámico"></asp:button>
                                                <INPUT id="hiddenPGrupo" style="WIDTH: 88px; " type="hidden" size="9" name="hiddenPSesion"
													runat="server"></TD>
											<td class="style8">
                                    <asp:Label ID="lblBuscar" runat="server" Font-Names="Arial" 
                                        Font-Size="XX-Small" Width="89px" Height="16px">Buscar Campo</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBuscar" runat="server" Font-Size="XX-Small" MaxLength="50" 
                                        tabIndex="14" Width="185px"></asp:TextBox>
                                    <asp:Button ID="btnBuscar" runat="server" tabIndex="15" Text="Buscar..." />
                                </td>
										</TR>
										<TR>
											<TD noWrap class="style2"></TD>
											<TD style="WIDTH: 21px; HEIGHT: 210px" noWrap></TD>
											<TD style="WIDTH: 632px; HEIGHT: 210px" vAlign="top" noWrap align="left" 
                                            colspan="3">
                                            <asp:datagrid id="grdCampos" runat="server" Width="626px" 
                                            Height="91px" ForeColor="#333333" PageSize="15"
													AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4" GridLines="None">
													<SelectedItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="#333333" 
                                                        BackColor="#D1DDF1" Font-Bold="True"></SelectedItemStyle>
													<EditItemStyle Font-Size="XX-Small" Font-Names="Arial" BackColor="#2461BF"></EditItemStyle>
													<AlternatingItemStyle Font-Size="XX-Small" Font-Names="Arial" BackColor="White"></AlternatingItemStyle>
													<ItemStyle Font-Size="XX-Small" Font-Names="Arial" BackColor="#EFF3FB"></ItemStyle>
													<HeaderStyle Font-Size="X-Small" Font-Names="Arial Narrow" 
                                                        Font-Bold="True" HorizontalAlign="Center"
														ForeColor="White" BackColor="#9DBADA">
													</HeaderStyle>
													<FooterStyle Font-Size="X-Small" Font-Names="Arial" HorizontalAlign="Center" ForeColor="White"
														BackColor="#507CD1" Font-Bold="True"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="DynamicUsrID" ReadOnly="True" HeaderText="ID" Visible="false">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Etiqueta">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<ItemTemplate>
																<asp:Label id="lblEtiqueta" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Etiqueta") %>'>
																</asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox id="TextEtiqueta" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Etiqueta") %>'>
																</asp:TextBox>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Tipo">
															<ItemTemplate>
															    <%#Container.DataItem("TipoDato")%>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:DropDownList id="ddTipoDato" SelectedValue='<%# ObtenerValueTipoDato(IIf(DataBinder.Eval(Container, "DataItem.TipoDato") Is System.DBNull.Value, "", DataBinder.Eval(Container, "DataItem.TipoDato")))  %>' Runat="server">
																    <asp:ListItem>Texto</asp:ListItem>
                                                                    <asp:ListItem>Número</asp:ListItem>
                                                                    <asp:ListItem>Fecha</asp:ListItem>
																</asp:DropDownList>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Orden">
															<ItemTemplate>
															    <%#Container.DataItem("Orden")%>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox id="TextOrden" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Orden") %>'>
																</asp:TextBox>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Obligatorio">
															<ItemTemplate>
																<asp:CheckBox id="CheckObligatorio" runat="server" Text=" " Enabled="False" Checked='<%# iif(DataBinder.Eval(Container, "DataItem.Obligatorio") Is System.DBNull.Value, 0, DataBinder.Eval(Container, "DataItem.Obligatorio")) %>'>
																</asp:CheckBox>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:CheckBox id="CheckObligatorio" runat="server" Text=" " Checked='<%# iif(DataBinder.Eval(Container, "DataItem.Obligatorio") Is System.DBNull.Value, 0, DataBinder.Eval(Container, "DataItem.Obligatorio")) %>'>
																</asp:CheckBox>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Long. Min">
															<ItemTemplate>
															    <%#Container.DataItem("Minlen")%>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox id="TextMinlen" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Minlen") %>'>
																</asp:TextBox>
															</EditItemTemplate>
														</asp:TemplateColumn>
														
														<asp:TemplateColumn HeaderText="Long. Max">
															<ItemTemplate>
															    <%#Container.DataItem("Maxlen")%>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox id="TextMaxlen" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Maxlen") %>'>
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
													<PagerStyle Font-Size="XX-Small" Font-Underline="True" Font-Names="Arial" HorizontalAlign="Center"
														ForeColor="White" BackColor="#9DBADA" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
						<cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox></td>
				</tr>
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

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server" >

    <style type="text/css">
        .style2
        {
            height: 210px;
            width: 52px;
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
        .style8
        {
            width: 85px;
            height: 50px;
        }
        .style9
        {
            width: 52px;
            height: 35px;
        }
    </style>

</asp:Content>
