<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_DynamicUsr.aspx.vb" Inherits="Portalv9.Wfrm_DynamicUsr" MasterPageFile="~/MasterPages/1.master" %>
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
<asp:Panel ID="Panel1" runat="server" >
		<table style="LEFT: 2px; TOP: 2px; " cellspacing="0" cellPadding="0" border="0">
			<tr>
               
				<td vAlign="top" align="left" width="*">
					<table cellspacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td class="style9" colspan=3>
							   <br/>
                               <br/>
							   <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="34px" Font-Names="Arial"  Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
							</td>
						</tr>
						<TR>
							<TD class="style4">
                               <asp:button id="btnAddNew" runat="server" Font-Size="XX-Small" Width="168px" Text="Agregar Campo Dinámico"></asp:button>
                               <INPUT id="hiddenPGrupo" style="WIDTH: 88px; " type="hidden" size="9" name="hiddenPSesion" runat="server">
                             </TD>
							<td class="style8">
                                    <asp:Label ID="lblBuscar" runat="server" Font-Names="Arial" Font-Size="XX-Small" Width="89px" Height="16px">Buscar Campo</asp:Label>
                             </td>
                            <td>
                                    <asp:TextBox ID="txtBuscar" runat="server" Font-Size="XX-Small" MaxLength="50" 
                                        tabIndex="14" Width="185px"></asp:TextBox>
                                    <asp:Button ID="btnBuscar" runat="server" tabIndex="15" Text="Buscar..." />
                             </td>
						</TR>
						<TR>
							 <TD colspan=3 style="WIDTH: 632px; HEIGHT: 210px" vAlign="top" noWrap align="left" >
                                  <asp:datagrid id="grdCampos" runat="server" Width="626px" Height="64px" PageSize="15"	AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4" GridLines="None">
                                    <SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
                                    <EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
                                    <AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
                                    <ItemStyle CssClass="ItemStyle"></ItemStyle>
                                    <HeaderStyle CssClass="Encabezados"></HeaderStyle>
                                    <FooterStyle CssClass="FooterStyle"></FooterStyle>	
									<Columns>
										<asp:BoundColumn DataField="DynamicUsrID" ReadOnly="True" HeaderText="ID" Visible="false">
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText"  HeaderText="Etiqueta">
											<HeaderStyle CssClass="EncabezadosText" />
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
										<asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Tipo">
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
										    <HeaderStyle CssClass="EncabezadosText" />
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Orden">
											<ItemTemplate>
											    <%#Container.DataItem("Orden")%>
											</ItemTemplate>
											<EditItemTemplate>
												<asp:TextBox id="TextOrden" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Orden") %>'>
												</asp:TextBox>
											</EditItemTemplate>
										    <HeaderStyle CssClass="EncabezadosText" />
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Obligatorio">
											<ItemTemplate>
												<asp:CheckBox id="CheckObligatorio" runat="server" Text=" " Enabled="False" Checked='<%# iif(DataBinder.Eval(Container, "DataItem.Obligatorio") Is System.DBNull.Value, 0, DataBinder.Eval(Container, "DataItem.Obligatorio")) %>'>
												</asp:CheckBox>
											</ItemTemplate>
											<EditItemTemplate>
												<asp:CheckBox id="CheckObligatorio" runat="server" Text=" " Checked='<%# iif(DataBinder.Eval(Container, "DataItem.Obligatorio") Is System.DBNull.Value, 0, DataBinder.Eval(Container, "DataItem.Obligatorio")) %>'>
												</asp:CheckBox>
											</EditItemTemplate>
										    <HeaderStyle CssClass="EncabezadosText" />
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Long. Min">
											<ItemTemplate>
											    <%#Container.DataItem("Minlen")%>
											</ItemTemplate>
											<EditItemTemplate>
												<asp:TextBox id="TextMinlen" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Minlen") %>'>
												</asp:TextBox>
											</EditItemTemplate>
										    <HeaderStyle CssClass="EncabezadosText" />
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Long. Max">
											<ItemTemplate>
											    <%#Container.DataItem("Maxlen")%>
											</ItemTemplate>
											<EditItemTemplate>
												<asp:TextBox id="TextMaxlen" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Maxlen") %>'>
												</asp:TextBox>
											</EditItemTemplate>
										    <HeaderStyle CssClass="EncabezadosText" />
										</asp:TemplateColumn>
										<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Actualizar" CancelText="Cancelar" EditText="Editar">
											<HeaderStyle CssClass="EncabezadosText" Width="50px"></HeaderStyle>
											<ItemStyle Font-Size="XX-Small" Font-Names="Arial" HorizontalAlign="Center"></ItemStyle>
										</asp:EditCommandColumn>
										<asp:ButtonColumn Text="X" HeaderText="Eliminar" CommandName="Delete">
											<HeaderStyle CssClass="EncabezadosText" HorizontalAlign="Left" Width="40px"></HeaderStyle>
											<ItemStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Italic="True" Font-Bold="True"
												HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
										</asp:ButtonColumn>
									</Columns>
						            <PagerStyle CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>
								 </asp:datagrid>
							  </TD>
							</TR>
					</table>
					<br />
					<cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox></td>
				</tr>
				<TR>
				 <td colspan=2>
				    <asp:HiddenField ID="HiddenField1" runat="server" />
				    <asp:HiddenField ID="HiddenField2" runat="server" />
				    <asp:HiddenField ID="HiddenField3" runat="server" />
				    <asp:HiddenField ID="HiddenField4" runat="server" />
				    <asp:HiddenField ID="HiddenField5" runat="server" />
				    <asp:HiddenField ID="HiddenField6" runat="server" />
                 </td>
                </TR>
			</table>
    </asp:Panel>
</asp:Content>