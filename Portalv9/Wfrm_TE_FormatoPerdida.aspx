<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_TE_FormatoPerdida.aspx.vb" Inherits="Portalv9.Wfrm_TE_FormatoPerdida" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 800px; POSITION: absolute; TOP: 8px; HEIGHT: 362px"
				borderColor="#eaeaea" width="800" align="left" border="1">
				<TR>
					<TD style="HEIGHT: 2px" width="70%">
						<asp:label id="lblTitle" runat="server" Font-Italic="True" Font-Bold="True" Width="544px" Height="5px"
							Font-Size="10pt" Font-Names="Arial"> Acta de pérdida</asp:label>
						<asp:hyperlink id="Regresar" runat="server" ImageUrl="Images/regresar.gif"></asp:hyperlink></TD>
					<TD style="HEIGHT: 2px" vAlign="middle" width="30%">
						<DIV align="center"></DIV>
						<DIV align="center">
							</DIV>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="2">
						<DIV align="center">
							<TABLE id="Table2" style="WIDTH: 762px; HEIGHT: 152px" cellSpacing="0" cellPadding="0"
								width="762" border="0" runat="server">
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 4px" vAlign="middle" align="right"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2">Fecha 
												:&nbsp;</FONT></B></TD>
									<TD style="HEIGHT: 4px" vAlign="middle" align="left">
										<asp:label id="lblFecha" runat="server" Width="206px" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 4px" vAlign="middle" align="right"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2">Hora 
												:&nbsp;</FONT></B></TD>
									<TD style="HEIGHT: 4px" vAlign="middle" align="left">
										<asp:label id="lblHora" runat="server" Width="206px" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 4px" vAlign="middle" align="right"></TD>
									<TD style="HEIGHT: 4px" vAlign="middle" align="left"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 4px" vAlign="middle" align="right"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2">Solicitó 
												el envío:&nbsp;</FONT></B></TD>
									<TD style="HEIGHT: 4px" vAlign="middle" align="left">
										<asp:label id="lblUsuario" runat="server" Width="374px" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 4px" vAlign="middle" align="right"></TD>
									<TD style="HEIGHT: 4px" vAlign="middle" align="left"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 4px" vAlign="middle" align="right"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2">Es 
												confidencial ?:&nbsp;</FONT></B></TD>
									<TD style="HEIGHT: 4px" vAlign="middle" align="left">
										<P align="left">
											<asp:checkbox id="chkConfiddencial" runat="server" Enabled="False"></asp:checkbox></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 2px" vAlign="middle" align="right"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2">Tipo 
														de expediente :&nbsp; </FONT></B></FONT></B>
									</TD>
									<TD style="FONT-SIZE: 10pt; FONT-FAMILY: Arial; HEIGHT: 2px" vAlign="middle" align="left">
										<P align="left"><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2">
												<asp:label id="lblTipoExpediente" runat="server" Width="528px" Font-Size="10pt" Font-Names="Arial"></asp:label></FONT></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 1px" vAlign="middle" align="right"><STRONG><FONT face="Arial" size="2">Entidad&nbsp;:&nbsp;
											</FONT></STRONG>
									</TD>
									<TD style="FONT-SIZE: 10pt; FONT-FAMILY: Arial; HEIGHT: 1px" vAlign="middle" align="left">
										<asp:label id="lblEntidad" runat="server" Width="528px" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 7px" vAlign="middle" align="right"><STRONG><FONT face="Arial" size="2">Area&nbsp;administrativa&nbsp;:&nbsp;
											</FONT></STRONG>
									</TD>
									<TD style="FONT-SIZE: 10pt; FONT-FAMILY: Arial; HEIGHT: 7px" vAlign="middle" align="left">
										<asp:label id="lblArea" runat="server" Width="528px" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 12px" vAlign="middle" align="right"><STRONG><FONT face="Arial" size="2">Año 
												:&nbsp; </FONT></STRONG>
									</TD>
									<TD style="FONT-SIZE: 10pt; FONT-FAMILY: Arial; HEIGHT: 12px" vAlign="middle" align="left">
										<asp:label id="lblAno" runat="server" Width="528px" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 5px" vAlign="middle" align="right"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2">Mes&nbsp;:</FONT></B><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2">&nbsp;
											</FONT></B>
									</TD>
									<TD style="HEIGHT: 5px" vAlign="middle">
										<asp:label id="lblMes" runat="server" Width="528px" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
									<TD style="HEIGHT: 5px" vAlign="middle" align="left"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 4px" vAlign="middle" align="right"><STRONG><FONT face="Arial" size="2">Día&nbsp;:&nbsp;
											</FONT></STRONG>
									</TD>
									<TD style="HEIGHT: 4px" vAlign="middle" align="left">
										<asp:label id="lblDia" runat="server" Width="528px" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 7px" vAlign="top" align="right"><B><FONT face="Arial, Helvetica, sans-serif" color="white" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#ffffff" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2">
																				Código&nbsp;del expediente :&nbsp;</FONT></B></FONT></B></FONT></B></FONT></B></FONT></B></TD>
									<TD style="HEIGHT: 7px" vAlign="top">
										<asp:label id="lblLLave" runat="server" Width="528px" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 4px" vAlign="top" align="right"><B><FONT face="Arial, Helvetica, sans-serif" color="white" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#ffffff" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2">Índice 
																				de búsqueda&nbsp;:&nbsp;</FONT></B></FONT></B></FONT></B></FONT></B>
											</FONT></B>
									</TD>
									<TD style="HEIGHT: 4px" vAlign="top">
										<asp:label id="lblIndice" runat="server" Width="528px" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 8px" vAlign="middle" align="right"></TD>
									<TD style="HEIGHT: 8px" vAlign="middle">
										<asp:label id="lblInstancia" runat="server" Width="528px" Font-Size="10pt" Font-Names="Arial"
											Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 8px" vAlign="middle" align="right"></TD>
									<TD style="HEIGHT: 8px" vAlign="middle"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 8px" vAlign="middle" align="right"><B><FONT face="Arial, Helvetica, sans-serif" color="white" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#ffffff" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2">Observaciones&nbsp;:&nbsp;</FONT></B></FONT></B></FONT></B></FONT></B>
											</FONT></B>
									</TD>
									<TD style="HEIGHT: 8px" vAlign="middle">
										<asp:label id="lblObservaciones" runat="server" Width="528px" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
								</TR>
							</TABLE>
						</DIV>
						<asp:label id="lblError" runat="server" Font-Size="X-Small" Font-Names="Arial" ForeColor="Red"></asp:label><BR>
					</TD>
				</TR>
			</TABLE>

    </div>
    </form>
</body>
</html>
