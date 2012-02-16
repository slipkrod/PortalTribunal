<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_PoliticasSesion.aspx.vb" Inherits="Portalv9.Wfrm_PoliticasSesion" MasterPageFile="~/MasterPages/Admin.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div id="content-container-one-div">
    <style type="text/css">
        #Table1
        {
            margin-top: 0px;
        }
        .style1
        {
            width: 21px;
            height: 50px;
        }
        .style6
        {
            width: 21px;
            height: 35px;
        }
    </style>
<link href="css/Grids.css" rel="stylesheet" type="text/css" />
    <asp:Panel ID="Panel1" runat="server" >
 		<table style="LEFT: 2px; TOP: 2px;" cellspacing="0" cellpadding="0" border="0">
			<tr>
                <td style="WIDTH: 100px" valign="top" width="100" class="style10"></td>
				<td valign="top" align="left" >
					<table cellspacing="0" cellpadding="0" width="100%" border="0">
						<tr>
							<td class="style9">
							   <br/>
                               <br/>
							   <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="624px" Height="34px" Font-Names="Arial"  Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
							</td>
						</tr>
						<TR>
							<TD noWrap class="style6">
                                <asp:Button ID="btnAddPSesion" runat="server" Font-Size="XX-Small" 
                                    Text="Agregar Nueva Política de Sesión" Width="168px" />
                                <input id="hiddenPSesion" runat="server" name="hiddenPSesion" size="9" 
                                    style="WIDTH: 88px; HEIGHT: 14px" type="hidden">
                                </input>
                            </TD>
						</TR>
						<TR>
							<TD noWrap align="left" style="WIDTH: 21px; HEIGHT: 301px" valign="top">
                                    <asp:DataGrid ID="grdPSesion" runat="server" AllowPaging="True" 
                                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                                        GridLines="None" Height="64px" PageSize="15" Width="626px" Font-Bold="False" 
                                        Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                        Font-Underline="False">
                                        <SelectedItemStyle CssClass="SelectedItemStyle" />
                                        <EditItemStyle CssClass="EditItemStyle" />
                                        <AlternatingItemStyle CssClass="AlternatingItemStyle" />
                                        <ItemStyle CssClass="ItemStyle" />
                                        <HeaderStyle CssClass="Encabezados" />
                                        <FooterStyle CssClass="FooterStyle" />
                                        <Columns>
                                            <asp:BoundColumn DataField="PoliticaSesionID" HeaderText="ID" ReadOnly="True" 
                                                Visible="false">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:TemplateColumn  HeaderStyle-CssClass="EncabezadosText" HeaderText="Nombre">
                                                <HeaderStyle CssClass="EncabezadosText" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblnombre" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'> </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="Textnombre" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'>
                                                    </asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Descripción">
                                                <HeaderStyle CssClass="EncabezadosText" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDescripcion" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextDescripcion" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' Width="305px">
                                                    </asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Duración">
                                                <HeaderStyle CssClass="EncabezadosText" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblduracion" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.DuracionMinutos") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="Textduracion" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.DuracionMinutos") %>' 
                                                        Width="23px">
                                                    </asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Fallidos Totales" HeaderStyle-CssClass="EncabezadosText">
                                                <HeaderStyle CssClass="EncabezadosText" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFallidos" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.IntentosFallidosConsec") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="Textfallidos" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.IntentosFallidosConsec") %>' 
                                                        Width="23px">
                                                    </asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Fallidos Día">
                                                <HeaderStyle CssClass="EncabezadosText" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFallidosDia" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.IntentosFallidosDia") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextfallidosDia" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.IntentosFallidosDia") %>' 
                                                        Width="23px"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="MultiSesión">
                                                <HeaderStyle CssClass="EncabezadosText" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckMultisesion" runat="server" 
                                                        Checked='<%# DataBinder.Eval(Container, "DataItem.PermitirMultiSesion") %>' 
                                                        Enabled="False" Text=" " Width="17px" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="CheckEditMultisesion" runat="server" Text=" " Width="17px" />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Inhab. Días">
                                                <HeaderStyle CssClass="EncabezadosText" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInhabDias" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.PeriodoInhabCtaDias") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextInhabDias" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.PeriodoInhabCtaDias") %>' 
                                                        Width="23px">
                                                    </asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Borrar Días">
                                                <HeaderStyle CssClass="EncabezadosText" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBorrarDias" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.PeriodoBorrarCtaDias") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBorrarDias" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.PeriodoBorrarCtaDias") %>' 
                                                        Width="23px">
                                                    </asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
								    <asp:EditCommandColumn ButtonType="LinkButton" HeaderText="Editar" UpdateText="Actualizar" CancelText="Cancelar" EditText="Editar">
									    <HeaderStyle Width="50px" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" CssClass="EncabezadosText"></HeaderStyle>
									    <ItemStyle Font-Size="XX-Small" Font-Names="Arial" HorizontalAlign="Center"></ItemStyle>
								    </asp:EditCommandColumn>
                                            <asp:ButtonColumn CommandName="Delete" HeaderText="Eliminar" Text="X">
                                                <HeaderStyle CssClass="EncabezadosText" HorizontalAlign="center" Width="40px" />
                                                <ItemStyle Font-Bold="True" Font-Italic="True" Font-Names="Arial Narrow" 
                                                    Font-Size="X-Small" ForeColor="#C00000" HorizontalAlign="Center"  />
                                            </asp:ButtonColumn>
                                        </Columns>
                                        <PagerStyle CssClass="PagerStyle" Mode="NumericPages" />
                                    </asp:DataGrid>
                                	<cc1:MsgBox id="MsgBox1" runat="server"></cc1:MsgBox>
                            </TD>
						</TR>
					</TABLE>		
				</td>
			</tr>
			<TR>
                <td style="WIDTH: 100px" vAlign="top" width="100" class="style10"></td>
				<td vAlign="top" align="left" >
				    <asp:HiddenField ID="HiddenField1" runat="server" Visible="False" />
				    <asp:HiddenField ID="HiddenField2" runat="server" />
				    <asp:HiddenField ID="HiddenField3" runat="server" />
				    <asp:HiddenField ID="HiddenField4" runat="server" />
				    <asp:HiddenField ID="HiddenField5" runat="server" />
				    <asp:HiddenField ID="HiddenField6" runat="server" />
				    <asp:HiddenField ID="HiddenField7" runat="server" />
				    <asp:HiddenField ID="HiddenField8" runat="server" />
                </td> 
            </TR>
		</table>
    </asp:Panel>
    </div>
</asp:Content>

