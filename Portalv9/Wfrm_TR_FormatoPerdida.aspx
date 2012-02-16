<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_TR_FormatoPerdida.aspx.vb" Inherits="Portalv9.Wfrm_TR_FormatoPerdida" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Wfrm_TR_FormatoPerdida</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bottomMargin="0" topMargin="0" leftMargin="0" rightMargin="0"
		oncontextmenu="return false">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 800px; HEIGHT: 264px; TOP: 8px; LEFT: 8px"
				borderColor="#eaeaea" width="800" align="left" border="1">
				<TR>
					<TD style="HEIGHT: 1px" width="70%">
						<asp:label id="lblTitle" runat="server" Font-Italic="True" Font-Bold="True" Width="544px" Height="5px"
							Font-Size="10pt" Font-Names="Arial">Acta de pérdida de cajas faltantes</asp:label>
						<asp:hyperlink id="Regresar" runat="server" ImageUrl="Images/regresar.gif" NavigateUrl="wfrm_TR_SegumientoInconsistencias.aspx"></asp:hyperlink></TD>
					<TD style="HEIGHT: 1px" vAlign="middle" width="30%">
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
									<TD style="WIDTH: 211px; HEIGHT: 16px" vAlign="middle" align="right"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2">No. 
												de orden de tránsito:&nbsp;</FONT></B></TD>
									<TD style="HEIGHT: 16px" vAlign="middle" align="left">
										<asp:label id="lblFolio_transito" runat="server" Font-Names="Arial" Font-Size="10pt" Width="374px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 4px" vAlign="middle" align="right"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2">Núm. 
												de caja:&nbsp;</FONT></B></TD>
									<TD style="HEIGHT: 4px" vAlign="middle" align="left">
										<asp:label id="lblCaja" runat="server" Width="374px" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 8px" vAlign="middle" align="right"></TD>
									<TD style="HEIGHT: 8px" vAlign="middle"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 8px" vAlign="middle" align="right"></TD>
									<TD style="HEIGHT: 8px" vAlign="middle"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 211px; HEIGHT: 8px" vAlign="top" align="left" colSpan="2"><TABLE id="Table3" style="WIDTH: 600px; HEIGHT: 40px" cellSpacing="0" cellPadding="0" width="600"
											border="0">
											<TR>
												<TD style="FONT-FAMILY: Arial; HEIGHT: 23px; FONT-SIZE: 10pt" vAlign="middle" align="left">&nbsp;Expedientes&nbsp;dentro 
													de la caja:</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 168px; HEIGHT: 12px" vAlign="middle" align="left" colSpan="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"></FONT></B></FONT></B>
													<P align="left"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2">
																<asp:table id="tblFolios" runat="server" Width="336px"></asp:table></FONT></B></P>
												</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 168px; HEIGHT: 4px" vAlign="bottom" align="left"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"></FONT></B></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</DIV>
						<asp:label id="lblError" runat="server" Font-Size="X-Small" Font-Names="Arial" ForeColor="Red"></asp:label><BR>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>

