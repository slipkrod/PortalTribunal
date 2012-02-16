<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_ClientesProyecto.aspx.vb" Inherits="Portalv9.Wfrm_ClientesProyecto" MasterPageFile="~/MasterPages/1.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<%@ Register TagPrefix="DBWC" Namespace="DBauer.Web.UI.WebControls" Assembly="DBauer.Web.UI.WebControls.HierarGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<script type="text/javascript" id="vs_defaultClientScript" language="javascript">
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
		<table style="LEFT: 2px; TOP: 2px;" cellspacing="0" cellPadding="0" border="0">
			<tr>
                <td style="WIDTH: 100px" vAlign="top" width="100" class="style10"></td>
				<td vAlign="top" align="left" width="*">
					<table cellspacing="0" cellPadding="0" width="100%" border="0">
                           <tr>
						        <td class="style9">
						         <br/>
                                 <br/>
							     <asp:label id="lblTitle" runat="server" Font-Size="Small"  
                                        Height="34px" Font-Names="Arial"  Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
						    	</td>
						   </tr>					
				   		   <tr>
								<TD noWrap class="style7">
                                <asp:Button ID="btnAddAplicacion" runat="server" Font-Size="XX-Small" Text="Agregar nuevo Cliente" Width="168px" />
                                 <input id="hiddenCliente" runat="server" name="hiddenCliente" size="9" style="WIDTH: 88px; HEIGHT: 14px" type="hidden"></input>
                              </TD>
							</TR>
						   <TR>
								<TD noWrap align="left" style="WIDTH: 632px; HEIGHT: 301px" valign="top">
                                 <asp:DataGrid ID="grdClienteP" runat="server" AllowPaging="True" 
                                                    AllowSorting="True" AutoGenerateColumns="False" 
                                        CellPadding="4" GridLines="None" Height="64px" PageSize="15" Width="626px" 
                                        Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                        Font-Strikeout="False" Font-Underline="False">
			                                        <SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
			                                        <EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
			                                        <AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
			                                        <ItemStyle CssClass="ItemStyle"></ItemStyle>
			                                        <HeaderStyle CssClass="Encabezados"></HeaderStyle>
			                                        <FooterStyle CssClass="FooterStyle"></FooterStyle>	
                                                    <Columns>
                                                        <asp:BoundColumn DataField="ClienteID" HeaderText="ID" ReadOnly="True" Visible="false">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Nombre">
                                                            <HeaderStyle CssClass="EncabezadosText" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNombre" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextNombre" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'>
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" 
                                                            HeaderText="Descripción">
                                                            <HeaderStyle CssClass="EncabezadosText" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldescripcion" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion")%>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextDescripcion" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' Width="305px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" 
                                                            HeaderText="Dirección 1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDireccion1" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Direccion1")%>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextDireccion1" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Direccion1") %>' Width="305px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle CssClass="EncabezadosText" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" 
                                                            HeaderText="Dirección 2">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDireccion2" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Direccion2")%>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextDireccion2" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Direccion2") %>' Width="305px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle CssClass="EncabezadosText" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" 
                                                            HeaderText="Teléfono">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTelefono" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Telefono")%>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextTelefono" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Telefono") %>' Width="305px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle CssClass="EncabezadosText" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" 
                                                            HeaderText="Correo Electrónico">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmail" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.email")%>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextEmail" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.email") %>' Width="305px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle CssClass="EncabezadosText" />
                                                        </asp:TemplateColumn>
                                                        <asp:EditCommandColumn ButtonType="LinkButton" CancelText="Cancelar" 
                                                            EditText="Editar" HeaderStyle-CssClass="EncabezadosText" HeaderText="Editar" 
                                                            UpdateText="Actualizar">
                                                            <HeaderStyle CssClass="EncabezadosText" />
                                                            <ItemStyle Font-Names="Arial" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                        </asp:EditCommandColumn>
                                                        <asp:ButtonColumn CommandName="Delete" HeaderStyle-CssClass="EncabezadosText" 
                                                            HeaderText="Eliminar" Text="X">
                                                            <HeaderStyle CssClass="EncabezadosText" />
                                                            <ItemStyle Font-Bold="True" Font-Italic="True" Font-Names="Arial " 
                                                                Font-Size="X-Small" ForeColor="#C00000" HorizontalAlign="Center" />
                                                        </asp:ButtonColumn>
                                                    </Columns>
     												<PagerStyle CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>                                               
                                                </asp:DataGrid>
                                 </TD>
							</TR>
					</table>
					<cc1:msgbox id="MsgBox1" runat="server"></cc1:msgbox>
				</td>
			</tr>
			<tr>
				<td vAlign="top" align="left" width="*" colspan =2>
        		    <asp:HiddenField ID="HiddenField1" runat="server" />
				    <asp:HiddenField ID="HiddenField2" runat="server" />
				    <asp:HiddenField ID="HiddenField3" runat="server" />
				    <asp:HiddenField ID="HiddenField4" runat="server" />
				    <asp:HiddenField ID="HiddenField5" runat="server" />
				    <asp:HiddenField ID="HiddenField6" runat="server" />
				</td>     
            </tr>
	  </table>    
    </asp:Panel>
   
</asp:Content>

