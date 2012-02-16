<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_VersionApp.aspx.vb" Inherits="Portalv9.Wfrm_VersionApp" MasterPageFile="~/MasterPages/1.Master" %>
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

<link href="css/Grids.css" rel="stylesheet" type="text/css" />
 		<table style="LEFT: 2px; TOP: 2px;  cellspacing="0" cellPadding="0" border="0">
			<tr>
				<td vAlign="top" align="left" width="*">
					<table cellspacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td class="style9" colspan=2>
							   <br/>
                               <br/>
							   <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="34px" Font-Names="Arial"  Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
							</td>
						</tr>						
						<tr valign="top">
							<td colspan=2 class="style5" style="vertical-align: middle">
	                          <asp:Button id="btnAdVersion" runat="server" Text="Agregar Versión" Font-Size="XX-Small"></asp:Button>
	                          <input id="hiddenAplicacionID" type="hidden" name="hiddenAplicacionID" runat="server">
							</td>
						</tr>
						<tr>
						<td colspan=2 >	
						    <asp:label id="lblApp" runat="server" Font-Size="XX-Small" Width="100px" 
                                Height="16px" Font-Names="Arial"
								Font-Bold="True" >Aplicación:</asp:label>                                        
                                <asp:DropDownList ID="ddlApp" runat="server" Height="16px" Width="250px" 
                                AutoPostBack="True" Font-Names="Arial" Font-Size="XX-Small"></asp:DropDownList>												                                         										    
						</td>
						</tr>
						<tr valign="top">
							<td valign="top" colspan=2 align="left" class="style6">
                            <asp:datagrid id="grdVerApp" runat="server" Width="592px" AutoGenerateColumns="False"
                                AllowPaging="True" AllowSorting="True" Height="6px" PageSize="15" CellPadding="3" 
                                GridLines="None">
							<SelectedItemStyle CssClass="SelectedItemStyle" ></SelectedItemStyle>
							<EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
							<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemStyle"></ItemStyle>
							<HeaderStyle CssClass="Encabezados"></HeaderStyle>
							<FooterStyle CssClass="FooterStyle"></FooterStyle>
                                <Columns>
                                    <asp:BoundColumn DataField="VersionAplicacionID" HeaderText="<span class='EncabezadosText'>ID</span>" ReadOnly="True" ></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Mayor" HeaderText="<span class='EncabezadosText'>Mayor</span>"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Menor" HeaderText="<span class='EncabezadosText'>Menor</span>"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Revision" HeaderText="<span class='EncabezadosText'>Revisión</span>"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Descripcion" HeaderText="<span class='EncabezadosText'>Descripción</span>"></asp:BoundColumn>
                                    <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Actualizar" 
                                        HeaderText="Editar" CancelText="Cancelar" EditText="Editar" 
                                        HeaderStyle-CssClass="EncabezadosText">
<HeaderStyle CssClass="EncabezadosText"></HeaderStyle>
                                    </asp:EditCommandColumn>
                                    <asp:ButtonColumn Text="X" HeaderText="Eliminar" CommandName="Delete" HeaderStyle-CssClass="EncabezadosText">
<HeaderStyle CssClass="EncabezadosText"></HeaderStyle>

                                        <ItemStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Italic="True" Font-Bold="True"
	                                        HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
                                    </asp:ButtonColumn>
				                    <asp:BoundColumn  Visible="False" DataField="AplicacionID" ReadOnly="True" 
                                        HeaderText="AplicacionID"></asp:BoundColumn>
                                </Columns>
							<PagerStyle CssClass="PagerStyle" PageButtonCount="15" Mode="NumericPages" ></PagerStyle>
                            </asp:datagrid>					                                            	                                        
                            </TD>
						</TR>
					</TABLE>						
					<cc1:msgbox id="MsgBox1" runat="server"></cc1:msgbox></td>
				</td>
			</tr>
		</table>
		
</asp:Content>				
