<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_EN_FormatoRecepcion.aspx.vb" Inherits="Portalv9.Wfrm_EN_FormatoRecepcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
			<TABLE id="Table1" style="WIDTH: 888px; HEIGHT: 224px" borderColor="#eaeaea" width="888"
				align="left" border="1">
				<TR>
					<TD style="WIDTH: 742px; HEIGHT: 19px" width="742" colSpan="2">
                        <asp:label id="lblTitle" runat="server" Font-Names="Arial" Font-Size="10pt" 
                            Width="544px" Height="16px"
							Font-Bold="True" Font-Italic="True"> Consulta->Archivo Central/Recepción de folios</asp:label></TD>
					<TD style="HEIGHT: 19px" vAlign="middle">
					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 152px; FONT-FAMILY: Arial; HEIGHT: 12px" align="left"
						width="152">Fecha:</TD>
					<TD style="WIDTH: 584px; HEIGHT: 12px" vAlign="middle" width="584"><asp:label id="lblFecha" runat="server" Font-Names="Arial" Font-Size="10pt" Width="206px"></asp:label></TD>
					<TD style="HEIGHT: 12px" vAlign="middle"></TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 152px; FONT-FAMILY: Arial; HEIGHT: 23px" align="left"
						width="152">Hora:</TD>
					<TD style="WIDTH: 584px; HEIGHT: 23px" vAlign="middle" width="584"><asp:label id="lblHora" runat="server" Font-Names="Arial" Font-Size="10pt" Width="206px"></asp:label></TD>
					<TD style="HEIGHT: 23px" vAlign="middle"></TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 152px; FONT-FAMILY: Arial; HEIGHT: 12px" align="left"
						width="152">Usuario que solicita:</TD>
					<TD style="WIDTH: 584px; HEIGHT: 12px" vAlign="middle" width="584"><asp:label id="lblUsuario" runat="server" Font-Names="Arial" Font-Size="10pt" Width="374px"></asp:label></TD>
					<TD style="HEIGHT: 12px" vAlign="middle"></TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 152px; FONT-FAMILY: Arial; HEIGHT: 12px" align="left"
						width="152">Usuario que envía:</TD>
					<TD style="WIDTH: 584px; HEIGHT: 12px" vAlign="middle" width="584">
						<asp:label id="lblRecibe" runat="server" Width="374px" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
					<TD style="HEIGHT: 12px" vAlign="middle"></TD>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="3" align="left">
						<TABLE id="Table2" style="WIDTH: 552px; HEIGHT: 72px" cellSpacing="0" cellPadding="0" width="552"
							border="0">
							<TR>
								<TD style="FONT-SIZE: 10pt; WIDTH: 179px; FONT-FAMILY: Arial; HEIGHT: 23px" vAlign="middle"
									align="left">Folios de bolsas cerradas:</TD>
								<TD style="HEIGHT: 23px" vAlign="middle" align="left">
									<P align="left">&nbsp;</P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 168px; HEIGHT: 27px" vAlign="middle" align="right" colSpan="2">
									<P align="left"><asp:label id="txtFolioBolsa" runat="server" Font-Names="Arial" Font-Size="10pt" Width="216px"></asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 179px" vAlign="bottom" align="left"><B><FONT face="Arial, Helvetica, sans-serif" color="#000000" size="2"></FONT></B></TD>
								<TD vAlign="middle" align="left"></TD>
							</TR>
						</TABLE>
						<asp:label id="lblError" runat="server" Font-Names="Arial" Font-Size="X-Small" ForeColor="Red"></asp:label><BR>
					</TD>
				</TR>
			</TABLE>

</asp:Content>
