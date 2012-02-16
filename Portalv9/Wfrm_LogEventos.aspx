<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_LogEventos.aspx.vb" Inherits="Portalv9.Wfrm_LogEventos" MasterPageFile="~/Masterpages/Adminmaster2col.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">    
    <script language="javascript" src="script.js" type="text/javascript">
    </script>
          
    <asp:Panel ID="Panel1" runat="server" Height="452px" Width="651px">
			<table style="LEFT: 2px; TOP: 2px; width: 620px; height: 374px;"  
                cellSpacing="0" cellPadding="0" border="0">
				<TBODY>
					<tr>
						<td vAlign="top" class="style1">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </td>
						<td vAlign="top" align="left" width="*">
							&#160;</td>
						<td align="left" valign="top" width="*">
							<table align="center" border="0" cellpadding="0" cellspacing="0" 
                                style="width: 79%">
								<tbody>
									<tr>
										<td class="style2">
											<asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Italic="True" 
                                                Font-Names="Arial" Font-Size="Small" Height="19px" Width="232px"> Texto en el 
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
                                                            <asp:HyperLink ID="CalendarIniHiperLink" runat="server">
                                                                <img alt="" border="0" src="images/icon-calendar.gif" />
                                                            </asp:HyperLink>
                                                            														
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                                runat="server" ControlToValidate="FechaIni" Display="Dynamic" 
                                                ErrorMessage="Requerido!" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                                            &#160;&#160;&#160;&#160;&#160;<font color="#000066" size="1">Al:</font>
															<asp:TextBox ID="FechaFin" runat="server" BorderStyle="Solid" 
                                                BorderWidth="1px" Columns="12" CssClass="standard-text" ReadOnly="false" 
                                                Width="68px"></asp:TextBox>                                                            
                                                            <asp:HyperLink ID="CalendarFinHiperLink" runat="server">
                                                                <img alt="" border="0" src="images/icon-calendar.gif" />
                                                            </asp:HyperLink>
                                                            
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
												<asp:DataGrid ID="grdResultLogs" runat="server" AllowPaging="True" 
                                                AllowSorting="True" AutoGenerateColumns="False" Height="137px" Width="820px">
													<FooterStyle Wrap="False"></FooterStyle>
                                                    
													<SelectedItemStyle Font-Names="Arial" Font-Size="XX-Small" Wrap="False">
                                                    </SelectedItemStyle>
                                                    
													<EditItemStyle Font-Names="Arial" Font-Size="XX-Small" Wrap="False">
                                                    </EditItemStyle>
                                                    
													<AlternatingItemStyle Font-Names="Arial" Font-Size="XX-Small" Wrap="False">
                                                    </AlternatingItemStyle>
                                                    
													<ItemStyle Font-Names="Arial" Font-Size="XX-Small" HorizontalAlign="Left" 
                                                        VerticalAlign="Top" Wrap="False"></ItemStyle>
                                                    
													<HeaderStyle BackColor="Gray" CssClass="grid-header" Font-Bold="True" 
                                                        Font-Names="Arial" Font-Size="XX-Small" ForeColor="White" 
                                                        HorizontalAlign="Center" Wrap="False"></HeaderStyle>
                                                    
													<Columns>
														<asp:BoundColumn DataField="FechaHoraInicio" HeaderText="Fecha y hora" 
                                                            SortExpression="FechaHoraInicio">
															<HeaderStyle Width="150px"></HeaderStyle>
                                                        
														</asp:BoundColumn>
														<asp:BoundColumn DataField="UsrId" HeaderText="User Id" SortExpression="UsrId">
															<HeaderStyle Width="150px"></HeaderStyle>
                                                        
														</asp:BoundColumn>
														<asp:BoundColumn DataField="dsAcceso" HeaderText="Evento efectuado" 
                                                            SortExpression="dsAcceso">
															<HeaderStyle Width="300px"></HeaderStyle>
                                                        
														</asp:BoundColumn>
														<asp:BoundColumn DataField="RESPUESTA" HeaderText="Estatus" SortExpression="RESPUESTA">
															<HeaderStyle Width="70px"></HeaderStyle>
                                                        
														</asp:BoundColumn>
														<asp:BoundColumn DataField="IP" HeaderText="Dirección IP" SortExpression="IP">
															<HeaderStyle Width="90px"></HeaderStyle>
                                                        
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Respuesta" HeaderText="Respuesta" 
                                                            SortExpression="Respuesta" Visible="False">
															<HeaderStyle Width="100px"></HeaderStyle>
                                                        
														</asp:BoundColumn>
													</Columns>
                                                    
													<PagerStyle Font-Size="X-Small" HorizontalAlign="Center" Mode="NumericPages" 
                                                        NextPageText="" Position="TopAndBottom" PrevPageText=""></PagerStyle>
                                                    
												</asp:DataGrid></input></p>
										</td>
									</tr>
								</tbody>
							</table>
							<cc1:MsgBox ID="dlgBoxExcepciones" runat="server"></cc1:MsgBox></td>
					</tr>
				</TBODY>
			</table>
    </asp:Panel>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server" >


    <style type="text/css">
        .style1
        {
            width: 68px;
        }
        .style2
        {
            height: 50px;
        }
    </style>

</asp:Content>
