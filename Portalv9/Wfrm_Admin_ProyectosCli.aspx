<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_ProyectosCli.aspx.vb" Inherits="Portalv9.Wfrm_ProyectosCli" MasterPageFile="~/MasterPages/1.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" language="javascript" id="clientEventHandlersJS" >
        function getconfirm() {
            if (confirm("¿Seguro de querer eliminar este registro?") == true)
                return true;
            else
                return false;
        }
        
    </script>
    <link href="css/Grids.css" rel="stylesheet" type="text/css" />
        <asp:Panel ID="Panel1" runat="server">
 		<table style="LEFT: 2px; TOP: 2px;" cellspacing="0" cellPadding="0" border="0">
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
                                <asp:button id="btnAddProy" runat="server" Font-Size="XX-Small" Width="168px" Text="Agregar Proyecto"></asp:button>
                                <input id="hiddenPProy" style="WIDTH: 88px; " type="hidden" size="9" name="hiddenPSesion" runat="server">
                                <input id="hiddenClienteID" style="WIDTH: 88px; " type="hidden" size="9" name="hiddenClienteID" runat="server">
							</TD>
							<td class="style8">
                                <asp:Label ID="lblSelCli" runat="server" Font-Names="Arial" 
                                Font-Size="XX-Small" Width="89px" Height="16px">Cliente:</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCli" runat="server" Width="185px" tabIndex="14"
                                AutoPostBack="True" Font-Names="Arial" Font-Size="XX-Small"></asp:DropDownList>
                            </td>
						</TR>
						<TR>
							<TD style="WIDTH: 632px; HEIGHT: 210px" vAlign="top" noWrap align="left" 
                            colspan="3">
                                <asp:datagrid id="grdProy" runat="server" Width="626px" AutoGenerateColumns="False"
							    AllowPaging="True" AllowSorting="True" Height="91px" PageSize="15" CellPadding="4" GridLines="None" 
                                    Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Strikeout="False" Font-Underline="False" >
							    <SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
							    <EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
							    <AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
							    <ItemStyle CssClass="ItemStyle"></ItemStyle>
							    <HeaderStyle CssClass="Encabezados"></HeaderStyle>
							    <FooterStyle CssClass="FooterStyle"></FooterStyle>
							    <Columns>
								    <asp:BoundColumn DataField="ProyectoID" ReadOnly="True" HeaderText="ID" 
                                        Visible="false" ItemStyle-CssClass="EncabezadosText">
									    <ItemStyle HorizontalAlign="Left"></ItemStyle>
								    </asp:BoundColumn>
								    <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText"  HeaderText="Siglas">
									    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                            Font-Strikeout="False" Font-Underline="False"  />
									    <ItemStyle HorizontalAlign="Left"></ItemStyle>
									    <ItemTemplate>
										    <asp:Label id=lblSiglas runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Siglas") %>'>
										    </asp:Label>
									    </ItemTemplate>
									    <EditItemTemplate>
										    <asp:TextBox id=TextSiglas runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Siglas") %>'>
										    </asp:TextBox>
									    </EditItemTemplate>
								    </asp:TemplateColumn>
								    <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Nombre">
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
								    <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Descripci&#243;n">
									    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                            Font-Strikeout="False" Font-Underline="False"  />
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
								    <asp:EditCommandColumn ButtonType="LinkButton" HeaderText="Editar" UpdateText="Actualizar" CancelText="Cancelar" EditText="Editar">
									    <HeaderStyle Width="50px" Font-Bold="False" Font-Italic="False" 
                                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                            CssClass="EncabezadosText"></HeaderStyle>
									    <ItemStyle Font-Size="XX-Small" Font-Names="Arial" HorizontalAlign="Center"></ItemStyle>
								    </asp:EditCommandColumn>
								    <asp:ButtonColumn Text="X" HeaderText="Eliminar" CommandName="Delete">
									    <HeaderStyle CssClass="EncabezadosText" HorizontalAlign="Left" Width="40px" Font-Bold="True" 
                                            Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                            Font-Underline="False" ></HeaderStyle>
									    <ItemStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Italic="True" Font-Bold="True"
										    HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
								    </asp:ButtonColumn>
							    </Columns>
							    <PagerStyle CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>
						    </asp:datagrid>
                            </TD>
						</TR>
					</TABLE>            
					<cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
				</td>
			</tr>
			<tr><td colspan=2> 
				    <asp:HiddenField ID="HiddenField1" runat="server" />
				    <asp:HiddenField ID="HiddenField2" runat="server" />
				    <asp:HiddenField ID="HiddenField3" runat="server" />
              </td></tr>
	</table>
    </asp:Panel>
</asp:Content>


