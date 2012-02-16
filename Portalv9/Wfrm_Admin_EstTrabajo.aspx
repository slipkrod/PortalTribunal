<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_EstTrabajo.aspx.vb" Inherits="Portalv9.Wfrm_EstTrabajo" MasterPageFile="~/MasterPages/1.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link rel="stylesheet" type="text/css" href="css/Grids.css">
    <asp:Panel ID="Panel1" runat="server" >
		<table style="LEFT: 2px; TOP: 2px; " cellspacing="0" cellPadding="0" border="0">
			<tr>
                
				<td vAlign="top" align="left" width="*">
					<table cellspacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td class="style9" >
							   <br/>
                               <br/>
							   <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="34px" Font-Names="Arial"  Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
							</td>
						</tr>
						<TR>
							<TD noWrap class="style8">
                                <asp:Button ID="btnAddPEstTra" runat="server" Font-Size="XX-Small"  Text="Agregar Estación" Width="168px" />
                                <input id="hiddenPEstTra" runat="server" name="hiddenPEstTra" size="9"  style="WIDTH: 88px; HEIGHT: 14px" type="hidden"></input>
                            </TD>
						</TR>
						<TR>
					  	   <TD noWrap class="style10" align="left" valign="top">
                                <asp:DataGrid ID="grdEstTra" runat="server" AllowPaging="True" 
                                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                                    GridLines="None" Height="64px" PageSize="15" Width="626px">
                                    <SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
                                    <EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
                                    <AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
                                    <ItemStyle CssClass="ItemStyle"></ItemStyle>
                                    <HeaderStyle CssClass="Encabezados"></HeaderStyle>
                                    <FooterStyle CssClass="FooterStyle"></FooterStyle>	
                                    <Columns>
                                        <asp:BoundColumn DataField="EstacionTrabajoID" HeaderText="ID" ReadOnly="True" 
                                            Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="IP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIP" runat="server" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.IP")%>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextIP" runat="server" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.IP") %>' Width="305px">
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Nombre">
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
                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Dominio">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblDominio" runat="server" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Dominio")%>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextDominio" runat="server" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Dominio") %>' Width="305px">
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Alias">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAlias" runat="server" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Alias")%>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextAlias" runat="server" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Alias") %>' Width="305px">
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" 
                                            HeaderText="Llave Pública">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLlavePublica" runat="server" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.LlavePublica")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextLlavePublica" runat="server" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.LlavePublica") %>' Width="305px">
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Estatus">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Status")%>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextStatus" runat="server" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Status") %>' Width="305px">
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:EditCommandColumn ButtonType="LinkButton" CancelText="Cancelar" 
                                            EditText="Editar" HeaderStyle-CssClass="EncabezadosText" HeaderText="Editar" 
                                            UpdateText="Actualizar">
                                            <ItemStyle Font-Names="Arial" Font-Size="XX-Small" HorizontalAlign="Center" />
                                        </asp:EditCommandColumn>
                                        <asp:ButtonColumn CommandName="Delete" HeaderStyle-CssClass="EncabezadosText" 
                                            HeaderText="Eliminar" Text="X">
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
				 <td>
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

