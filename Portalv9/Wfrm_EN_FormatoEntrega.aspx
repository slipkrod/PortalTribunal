<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_EN_FormatoEntrega.aspx.vb" Inherits="Portalv9.Wfrm_EN_FormatoEntrega" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
			<TABLE id="Table1" style="WIDTH: 738px; HEIGHT: 248px" borderColor="#eaeaea" width="738"
				align="left" border="1">
				<TR>
					<TD style="HEIGHT: 11px" colSpan="2"><asp:label id="lblTitle" runat="server" 
                            Font-Names="Arial" Font-Size="10pt" Width="544px" Height="16px"
							Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label></TD>
					<TD style="HEIGHT: 11px" vAlign="middle" width="30%">

					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 523px; FONT-FAMILY: Arial; HEIGHT: 12px" align="left"
						width="523">Fecha:</TD>
					<TD style="HEIGHT: 12px" vAlign="middle" width="849"><asp:label id="lblFecha" runat="server" Font-Names="Arial" Font-Size="10pt" Width="206px"></asp:label></TD>
					<TD style="HEIGHT: 12px" vAlign="middle" width="30%"></TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 523px; FONT-FAMILY: Arial; HEIGHT: 23px" align="left"
						width="523">Hora:</TD>
					<TD style="HEIGHT: 23px" vAlign="middle" width="849"><asp:label id="lblHora" runat="server" Font-Names="Arial" Font-Size="10pt" Width="206px"></asp:label></TD>
					<TD style="HEIGHT: 23px" vAlign="middle" width="30%"></TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 523px; FONT-FAMILY: Arial; HEIGHT: 12px" align="left"
						width="523">
						<P>Mensajería:</P>
					</TD>
					<TD style="HEIGHT: 12px; vertical-align: top;" vAlign="middle" width="849"><asp:label id="lblMensajeria" runat="server" Font-Names="Arial" Font-Size="10pt" Width="374px"></asp:label></TD>
					<TD style="HEIGHT: 12px" vAlign="middle" width="30%"></TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 523px; FONT-FAMILY: Arial; HEIGHT: 12px" align="left"
						width="523">Quién&nbsp;entrega:</TD>
					<TD style="HEIGHT: 12px" vAlign="middle" width="849"><asp:label id="lblEntrega" runat="server" Font-Names="Arial" Font-Size="10pt" Width="374px"></asp:label></TD>
					<TD style="HEIGHT: 12px" vAlign="middle" width="30%"></TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 523px; FONT-FAMILY: Arial; HEIGHT: 12px" align="left"
						width="523">Observaciones:</TD>
					<TD style="HEIGHT: 12px" vAlign="middle" width="849"><asp:label id="lblObservaciones" runat="server" Font-Names="Arial" Font-Size="10pt" Width="374px"></asp:label></TD>
					<TD style="HEIGHT: 12px" vAlign="middle" width="30%"></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<DIV align="center">
							<TABLE id="Table2" style="WIDTH: 600px; HEIGHT: 40px" cellSpacing="0" cellPadding="0" width="600"
								border="0">
								<TR>
									<TD style="FONT-SIZE: 10pt; WIDTH: 168px; FONT-FAMILY: Arial; HEIGHT: 23px" vAlign="middle"
										align="center">Folios de bolsas entregadas:</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 168px; HEIGHT: 12px" vAlign="middle" align="left" colSpan="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"></FONT></B></FONT></B>
										<P align="left"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"><asp:table id="tblFolios" runat="server" Width="336px"></asp:table></FONT></B></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 168px; HEIGHT: 4px" vAlign="bottom" align="left"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"></FONT></B></TD>
								</TR>
							</TABLE>
						</DIV>
						<asp:label id="lblError" runat="server" Font-Names="Arial" Font-Size="X-Small" ForeColor="Red"></asp:label><BR>
					</TD>
				</TR>
			</TABLE>

</asp:Content>
