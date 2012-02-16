<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_LogEventos.aspx.vb" Inherits="Portalv9.Wfrm_LogEventos" MasterPageFile="~/MasterPages/1.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" src="script.js" type="text/javascript">
    </script>
 <link href="css/Grids.css" rel="stylesheet" type="text/css" />
    <asp:Panel ID="Panel1" runat="server" >
			<table style="LEFT: 2px; TOP: 2px;"  
                cellSpacing="0" cellPadding="0" border="0">
				<TBODY>
					<tr>
						
						<td vAlign="top" align="left" width="*">
							&#160;</td>
						<td align="left" valign="top" width="*">
							<table align="center" border="0" cellpadding="0" cellspacing="0" 
                                style="width: 79%">
								<tbody>
									<tr>
										<td class="style2">
											<asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Italic="True" 
                                                Font-Names="Arial" Font-Size="Small" Height="19px"> Texto en el 
                                            page_ load</asp:Label></td>
									</tr>
									<tr>
										<td>
											<p>&#160;</p>
											<p>
												<table id="Table1" style="WIDTH: 535px; HEIGHT: 118px" width="535">
													<tr>
														<td align="right" class="FormLabel" 
                                                style="WIDTH: 120px; HEIGHT: 5px" width="120"><font color="#000066" 
                                                face="Verdana,Arial" size="1">Usuario:</font></td>
														<td class="FormInput" colspan="2" style="HEIGHT: 5px">
                                                            <asp:DropDownList ID="DropUsr" runat="server" Width="342px">
                                            </asp:DropDownList></td>
													</tr>
													<tr>
														<td align="right" class="FormLabel" 
                                                style="WIDTH: 120px; HEIGHT: 26px" width="120"><font color="#000066" 
                                                face="Verdana,Arial" size="1">Eventos:</font></td>
														<td class="FormInput" colspan="2" style="HEIGHT: 26px">
                                                            <asp:DropDownList ID="DropEventos" runat="server" Width="342px">
                                            </asp:DropDownList></td>
													</tr>
													<tr>
														<td align="right" style="WIDTH: 120px; HEIGHT: 20px">
                                                            <font color="#000066" size="1">Rango de Fechas:</font></td>
														<td align="left" colspan="2" style="HEIGHT: 20px">
                                                            <font color="#000066" size="1">&#160;Del:</font>
															<asp:TextBox ID="FechaIni" runat="server" BorderStyle="Solid" 
                                                BorderWidth="1px" Columns="12" CssClass="standard-text" ReadOnly="false" 
                                                Width="68px"></asp:TextBox>
                                                            <cc2:CalendarExtender ID="FechaIni_CalendarExtender" runat="server" 
                                                                Enabled="True" TargetControlID="FechaIni" Format="dd/MM/yyyy" PopupButtonID="images/icon-calendar.gif">
                                                            </cc2:CalendarExtender>
                                                            
                                                            														
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                                runat="server" ControlToValidate="FechaIni" Display="Dynamic" 
                                                ErrorMessage="Requerido!" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                                            &#160;&#160;&#160;&#160;&#160;<font color="#000066" size="1">Al:</font>
															<asp:TextBox ID="FechaFin" runat="server" BorderStyle="Solid" 
                                                BorderWidth="1px" Columns="12" CssClass="standard-text" ReadOnly="false" 
                                                Width="68px"></asp:TextBox>                                                            
                                                            <cc2:CalendarExtender ID="FechaFin_CalendarExtender" runat="server" 
                                                                Enabled="True" TargetControlID="FechaFin" Format="dd/MM/yyyy">
                                                            </cc2:CalendarExtender>
                                                            
															<asp:RequiredFieldValidator ID="Requiredfieldvalidator1" 
                                                runat="server" ControlToValidate="FechaFin" Display="Dynamic" 
                                                ErrorMessage="Requerido!" Font-Size="XX-Small"></asp:RequiredFieldValidator></FONT></td>
													</tr>
													<tr>
													    <td colspan="3">
													        &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;<asp:CompareValidator 
                                                                ID="cvStartDate" runat="server" ControlToValidate="FechaIni" Display="Dynamic" 
                                                                ErrorMessage="Fecha no valida [mm/dd/yyyy]" Operator="DataTypeCheck" 
                                                                Type="Date"></asp:CompareValidator>
													    &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
                                                            <asp:CompareValidator ID="cvEndDate" runat="server" 
                                                                ControlToValidate="FechaFin" Display="Dynamic" 
                                                                ErrorMessage="Fecha no valida [mm/dd/yyyy]" Operator="DataTypeCheck" 
                                                                Type="Date"></asp:CompareValidator>
													    </td>
													</tr>																										
													<tr>
														<td align="center" colspan="3"><asp:Button ID="btnBuscar" Runat="server" 
                                                                CssClass="Button" Text="Buscar"></asp:Button></td>
													</tr>
												</table>
												<input id="htmlHiddenSortExpression" runat="server" 
                                                name="htmlHiddenSortExpression" type="hidden" value="FechaHoraInicio">
												</p>
										    <p>
                                                <asp:DataGrid ID="grdResultLogs" runat="server" AllowPaging="True" 
                                                    AllowSorting="True" AutoGenerateColumns="False" Height="64px" >
                                                    <SelectedItemStyle CssClass="SelectedItemStyle" />
                                                    <EditItemStyle CssClass="EditItemStyle" />
                                                    <AlternatingItemStyle CssClass="AlternatingItemStyle" />
                                                    <ItemStyle CssClass="ItemStyle" />
                                                    <HeaderStyle CssClass="Encabezados" />
                                                    <FooterStyle CssClass="FooterStyle" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="FechaHoraInicio" 
                                                            HeaderText="&lt;span class='EncabezadosText'&gt;Fecha y hora&lt;/span&gt;" 
                                                            SortExpression="FechaHoraInicio">
                                                            <HeaderStyle CssClass="Encabezados" Width="150px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="UsrId" 
                                                            HeaderText="&lt;span class='EncabezadosText'&gt;User Id&lt;/span&gt;" 
                                                            SortExpression="UsrId">
                                                            <HeaderStyle Width="150px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="dsAcceso" 
                                                            HeaderText="&lt;span class='EncabezadosText'&gt;Evento efectuado&lt;/span&gt;" 
                                                            SortExpression="dsAcceso">
                                                            <HeaderStyle Width="300px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="RESPUESTA" 
                                                            HeaderText="&lt;span class='EncabezadosText'&gt;Estatus&lt;/span&gt;" 
                                                            SortExpression="RESPUESTA">
                                                            <HeaderStyle Width="70px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="IP" 
                                                            HeaderText="&lt;span class='EncabezadosText'&gt;Dirección IP&lt;/span&gt;" 
                                                            SortExpression="IP">
                                                            <HeaderStyle Width="90px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Respuesta" HeaderText="Respuesta" 
                                                            SortExpression="Respuesta" Visible="False">
                                                            <HeaderStyle Width="100px" />
                                                        </asp:BoundColumn>
                                                    </Columns>
                                                    <PagerStyle Font-Size="X-Small" HorizontalAlign="Center" Mode="NumericPages" 
                                                        NextPageText="" Position="TopAndBottom" PrevPageText="" />
                                                </asp:DataGrid>
                                                </input>
                                            </p>
										</td>
									</tr>
								</tbody>
							</table>
							<cc1:MsgBox ID="dlgBoxExcepciones" runat="server"></cc1:MsgBox>
                            <cc2:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </cc2:ToolkitScriptManager>
                        </td>
					</tr>
				</TBODY>
			</table>
    </asp:Panel>

</asp:Content>

